Imports System.Data
Imports System.Data.OleDb

Public Class FrmBorrowingReturn
    Private borrowingID As Integer
    Private dtItems As DataTable

    Public Sub New(id As Integer)
        InitializeComponent()
        borrowingID = id
        LoadBorrowingItems()
        SetupItemsGrid()
    End Sub

    Private Sub SetupItemsGrid()
        dgvItems.AutoGenerateColumns = False
        dgvItems.Columns.Clear()

        dgvItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "BorrowingItemID",
            .HeaderText = "ID",
            .Width = 60,
            .ReadOnly = True,
            .Visible = False
        })

        dgvItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "ItemName",
            .HeaderText = "Item Name",
            .Width = 200,
            .ReadOnly = True
        })

        dgvItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Quantity",
            .HeaderText = "Borrowed",
            .Width = 80,
            .ReadOnly = True
        })

        dgvItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "ReturnedQuantity",
            .HeaderText = "Already Returned",
            .Width = 120,
            .ReadOnly = True
        })

        Dim returnCol As New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "ReturnQuantity",
            .HeaderText = "Return Now",
            .Width = 100
        }
        dgvItems.Columns.Add(returnCol)
    End Sub

    Private Sub LoadBorrowingItems()
        Dim sql As String = "SELECT bi.BorrowingItemID, e.ItemName, bi.Quantity, " &
                           "IIF(IsNull(bi.ReturnedQuantity), 0, bi.ReturnedQuantity) AS ReturnedQuantity, " &
                           "(bi.Quantity - IIF(IsNull(bi.ReturnedQuantity), 0, bi.ReturnedQuantity)) AS Remaining, " &
                           "bi.EquipmentID " &
                           "FROM BorrowingItems bi INNER JOIN Equipment e ON bi.EquipmentID = e.EquipmentID " &
                           "WHERE bi.BorrowingID = ?"
        Dim params As New List(Of OleDb.OleDbParameter) From {
            New OleDb.OleDbParameter() With {.Value = borrowingID}
        }
        dtItems = DataAccess.GetTable(sql, params)
        dtItems.Columns.Add("ReturnQuantity", GetType(Integer))
        For Each row As DataRow In dtItems.Rows
            row("ReturnQuantity") = 0
            ' Ensure ReturnedQuantity is not NULL
            If IsDBNull(row("ReturnedQuantity")) Then
                row("ReturnedQuantity") = 0
            End If
        Next
        dgvItems.DataSource = dtItems

        ' Get borrowing info
        Dim borrowingSql As String = "SELECT b.BorrowDate, b.Status, br.FullName FROM Borrowings b " &
                                    "INNER JOIN Borrowers br ON b.BorrowerID = br.BorrowerID " &
                                    "WHERE b.BorrowingID = ?"
        Dim borrowingDt As DataTable = DataAccess.GetTable(borrowingSql, params)
        If borrowingDt.Rows.Count > 0 Then
            lblBorrower.Text = "Borrower: " & borrowingDt.Rows(0)("FullName").ToString()
            lblBorrowDate.Text = "Borrow Date: " & CDate(borrowingDt.Rows(0)("BorrowDate")).ToString("yyyy-MM-dd")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateReturns() Then
            Return
        End If

        Try
            ProcessReturn()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error processing return: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateReturns() As Boolean
        Dim hasReturn As Boolean = False
        For Each row As DataRow In dtItems.Rows
            Dim returnQty As Integer = CInt(row("ReturnQuantity"))
            Dim remaining As Integer = CInt(row("Remaining"))

            If returnQty < 0 Then
                MessageBox.Show("Return quantity cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If returnQty > remaining Then
                MessageBox.Show($"Return quantity cannot exceed remaining quantity for {row("ItemName")}.", 
                              "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If returnQty > 0 Then
                hasReturn = True
            End If
        Next

        If Not hasReturn Then
            MessageBox.Show("Please specify quantities to return.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub ProcessReturn()
        Dim connString As String = DataAccess.GetConnectionString()
        Dim totalReturned As Integer = 0
        Dim allReturned As Boolean = True

        Using cn As New OleDb.OleDbConnection(connString)
            cn.Open()
            Using tx As OleDb.OleDbTransaction = cn.BeginTransaction()
                Try
                    For Each row As DataRow In dtItems.Rows
                        Dim returnQty As Integer = CInt(row("ReturnQuantity"))
                        If returnQty > 0 Then
                            Dim borrowingItemID As Integer = CInt(row("BorrowingItemID"))
                            Dim equipmentID As Integer = CInt(row("EquipmentID"))
                            Dim currentReturnedQty As Integer = If(IsDBNull(row("ReturnedQuantity")), 0, CInt(row("ReturnedQuantity")))
                            Dim newReturnedQty As Integer = currentReturnedQty + returnQty

                            ' Update BorrowingItem
                            Dim updateItemSql As String = "UPDATE BorrowingItems SET ReturnedQuantity = ?, UpdatedAt = NOW() WHERE BorrowingItemID = ?"
                            Using cmd As New OleDb.OleDbCommand(updateItemSql, cn, tx)
                                cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = newReturnedQty})
                                cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = borrowingItemID})
                                cmd.ExecuteNonQuery()
                            End Using

                            ' Restore Equipment stock
                            Dim updateStockSql As String = "UPDATE Equipment SET Stock = Stock + ?, UpdatedAt = NOW() WHERE EquipmentID = ?"
                            Using cmd As New OleDb.OleDbCommand(updateStockSql, cn, tx)
                                cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = returnQty})
                                cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = equipmentID})
                                cmd.ExecuteNonQuery()
                            End Using

                            totalReturned += returnQty
                            If newReturnedQty < CInt(row("Quantity")) Then
                                allReturned = False
                            End If
                        Else
                            Dim currentReturnedQty As Integer = If(IsDBNull(row("ReturnedQuantity")), 0, CInt(row("ReturnedQuantity")))
                            If currentReturnedQty < CInt(row("Quantity")) Then
                                allReturned = False
                            End If
                        End If
                    Next

                    ' Update Borrowing status
                    Dim status As String = If(allReturned, "Returned", "Active")
                    Dim updateBorrowingSql As String = "UPDATE Borrowings SET Status = ?, ActualReturnDate = ?, UpdatedAt = NOW() WHERE BorrowingID = ?"
                    Using cmd As New OleDb.OleDbCommand(updateBorrowingSql, cn, tx)
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = status})
                        If allReturned Then
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = Today.Date})
                        Else
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = DBNull.Value})
                        End If
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = borrowingID})
                        cmd.ExecuteNonQuery()
                    End Using

                    tx.Commit()
                    MessageBox.Show($"Return processed successfully. {totalReturned} item(s) returned.", 
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvItems_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvItems.CellValidating
        If dgvItems.Columns(e.ColumnIndex).Name = "ReturnQuantity" Then
            Dim value As String = e.FormattedValue.ToString()
            If Not String.IsNullOrEmpty(value) Then
                Dim returnQty As Integer
                If Not Integer.TryParse(value, returnQty) Then
                    e.Cancel = True
                    MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub
End Class

