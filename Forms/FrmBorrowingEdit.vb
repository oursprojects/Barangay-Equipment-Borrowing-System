Imports System.Data
Imports System.Data.OleDb

Public Class FrmBorrowingEdit
    Private borrowingID As Integer = 0
    Private isEditMode As Boolean = False
    Private dtItems As DataTable

    Public Sub New()
        InitializeComponent()
        isEditMode = False
        Me.Text = "New Borrowing Transaction"
        dtpBorrowDate.Value = Today
        dtpExpectedReturn.Value = Today.AddDays(3)
        LoadBorrowers()
        LoadEquipment()
        SetupItemsGrid()
    End Sub

    Public Sub New(id As Integer)
        InitializeComponent()
        borrowingID = id
        isEditMode = True
        Me.Text = "Edit Borrowing Transaction"
        LoadBorrowers()
        LoadEquipment()
        SetupItemsGrid()
        LoadBorrowing()
    End Sub

    Private Sub LoadBorrowers()
        Dim sql As String = "SELECT BorrowerID, FullName FROM Borrowers ORDER BY FullName"
        Dim dt As DataTable = DataAccess.GetTable(sql)
        cboBorrower.DataSource = dt
        cboBorrower.DisplayMember = "FullName"
        cboBorrower.ValueMember = "BorrowerID"
    End Sub

    Private Sub LoadEquipment()
        Dim sql As String = "SELECT EquipmentID, ItemName, Category, Stock FROM Equipment WHERE Stock > 0 ORDER BY ItemName"
        Dim dt As DataTable = DataAccess.GetTable(sql)
        cboEquipment.DataSource = dt
        cboEquipment.DisplayMember = "ItemName"
        cboEquipment.ValueMember = "EquipmentID"
    End Sub

    Private Sub SetupItemsGrid()
        dtItems = New DataTable()
        dtItems.Columns.Add("EquipmentID", GetType(Integer))
        dtItems.Columns.Add("ItemName", GetType(String))
        dtItems.Columns.Add("Category", GetType(String))
        dtItems.Columns.Add("Quantity", GetType(Integer))
        dtItems.Columns.Add("Stock", GetType(Integer))
        dgvItems.DataSource = dtItems
        dgvItems.AutoGenerateColumns = True
        dgvItems.Columns("EquipmentID").Visible = False
    End Sub

    Private Sub LoadBorrowing()
        Dim sql As String = "SELECT * FROM Borrowings WHERE BorrowingID = ?"
        Dim params As New List(Of OleDb.OleDbParameter) From {
            New OleDb.OleDbParameter() With {.Value = borrowingID}
        }
        Dim dt As DataTable = DataAccess.GetTable(sql, params)

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            cboBorrower.SelectedValue = row("BorrowerID")
            dtpBorrowDate.Value = CDate(row("BorrowDate"))
            If Not IsDBNull(row("ExpectedReturnDate")) Then
                dtpExpectedReturn.Value = CDate(row("ExpectedReturnDate"))
            End If
            txtNotes.Text = If(IsDBNull(row("Notes")), "", row("Notes").ToString())

            ' Load items - Create NEW parameter list (can't reuse the same one)
            Dim itemsSql As String = "SELECT bi.EquipmentID, e.ItemName, e.Category, bi.Quantity, e.Stock " &
                                    "FROM BorrowingItems bi INNER JOIN Equipment e ON bi.EquipmentID = e.EquipmentID " &
                                    "WHERE bi.BorrowingID = ?"
            Dim itemsParams As New List(Of OleDb.OleDbParameter) From {
                New OleDb.OleDbParameter() With {.Value = borrowingID}
            }
            Dim itemsDt As DataTable = DataAccess.GetTable(itemsSql, itemsParams)
            dtItems.Clear()
            For Each itemRow As DataRow In itemsDt.Rows
                dtItems.Rows.Add(itemRow("EquipmentID"), itemRow("ItemName"), itemRow("Category"), 
                                itemRow("Quantity"), itemRow("Stock"))
            Next
        End If
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If cboEquipment.SelectedValue Is Nothing Then
            MessageBox.Show("Please select an equipment item.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim quantity As Integer
        If Not Integer.TryParse(txtQuantity.Text, quantity) OrElse quantity <= 0 Then
            MessageBox.Show("Please enter a valid quantity greater than 0.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Return
        End If

        Dim equipmentID As Integer = CInt(cboEquipment.SelectedValue)
        Dim equipmentDt As DataTable = DirectCast(cboEquipment.DataSource, DataTable)
        Dim selectedRow As DataRow = Nothing
        For Each row As DataRow In equipmentDt.Rows
            If CInt(row("EquipmentID")) = equipmentID Then
                selectedRow = row
                Exit For
            End If
        Next
        
        If selectedRow Is Nothing Then
            MessageBox.Show("Equipment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        
        Dim availableStock As Integer = CInt(selectedRow("Stock"))

        ' Check if item already exists in grid
        Dim alreadyBorrowed As Integer = 0
        For Each row As DataRow In dtItems.Rows
            If CInt(row("EquipmentID")) = equipmentID Then
                alreadyBorrowed += CInt(row("Quantity"))
            End If
        Next

        If (alreadyBorrowed + quantity) > availableStock Then
            MessageBox.Show($"Insufficient stock. Available: {availableStock - alreadyBorrowed}, Requested: {quantity}", 
                          "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Find existing row
        Dim existingRow As DataRow = Nothing
        For Each row As DataRow In dtItems.Rows
            If CInt(row("EquipmentID")) = equipmentID Then
                existingRow = row
                Exit For
            End If
        Next

        If existingRow IsNot Nothing Then
            ' Update existing row
            existingRow("Quantity") = CInt(existingRow("Quantity")) + quantity
        Else
            ' Add new row
            dtItems.Rows.Add(equipmentID, selectedRow("ItemName"), selectedRow("Category"), quantity, availableStock)
        End If

        txtQuantity.Text = "1"
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvItems.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        dgvItems.Rows.RemoveAt(dgvItems.SelectedRows(0).Index)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInput() Then
            Return
        End If

        Try
            If isEditMode Then
                UpdateBorrowing()
            Else
                InsertBorrowing()
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving borrowing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        If cboBorrower.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a borrower.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBorrower.Focus()
            Return False
        End If

        If dtItems.Rows.Count = 0 Then
            MessageBox.Show("Please add at least one equipment item.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If dtpExpectedReturn.Value < dtpBorrowDate.Value Then
            MessageBox.Show("Expected return date must be after borrow date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpExpectedReturn.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub InsertBorrowing()
        Dim commands As New List(Of DataAccess.TransactionCommand)
        Dim borrowerID As Integer = CInt(cboBorrower.SelectedValue)

        ' 1. Insert Borrowing header
        Dim insertBorrowingSql As String = "INSERT INTO Borrowings (BorrowerID, BorrowDate, ExpectedReturnDate, Status, Notes, CreatedAt, UpdatedAt) VALUES (?, ?, ?, 'Active', ?, NOW(), NOW())"
        Dim notesValue As Object = If(String.IsNullOrWhiteSpace(txtNotes.Text), DirectCast(DBNull.Value, Object), DirectCast(txtNotes.Text.Trim(), Object))
        Dim borrowingParams As New List(Of OleDb.OleDbParameter) From {
            New OleDb.OleDbParameter() With {.Value = borrowerID},
            New OleDb.OleDbParameter() With {.Value = dtpBorrowDate.Value.Date},
            New OleDb.OleDbParameter() With {.Value = dtpExpectedReturn.Value.Date},
            New OleDb.OleDbParameter() With {.Value = notesValue}
        }
        commands.Add(New DataAccess.TransactionCommand(insertBorrowingSql, borrowingParams))

        ' 2. Get the new BorrowingID (Access doesn't support OUTPUT, so we'll use @@IDENTITY after insert)
        ' We need to do this in a two-step process for Access
        ' First, insert the header and get the ID
        Dim connString As String = DataAccess.GetConnectionString()
        Dim newBorrowingID As Integer = 0

        Using cn As New OleDb.OleDbConnection(connString)
            cn.Open()
            Using tx As OleDb.OleDbTransaction = cn.BeginTransaction()
                Try
                    ' Insert header - Create new parameters for this command
                    Using cmd As New OleDb.OleDbCommand(insertBorrowingSql, cn, tx)
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = borrowerID})
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = dtpBorrowDate.Value.Date})
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = dtpExpectedReturn.Value.Date})
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = notesValue})
                        cmd.ExecuteNonQuery()

                        ' Get new ID
                        Using cmd2 As New OleDb.OleDbCommand("SELECT @@IDENTITY", cn, tx)
                            newBorrowingID = CInt(cmd2.ExecuteScalar())
                        End Using
                    End Using

                    ' Insert items and update stock
                    For Each row As DataRow In dtItems.Rows
                        Dim equipmentID As Integer = CInt(row("EquipmentID"))
                        Dim quantity As Integer = CInt(row("Quantity"))

                        ' Insert BorrowingItem
                        Dim insertItemSql As String = "INSERT INTO BorrowingItems (BorrowingID, EquipmentID, Quantity, ReturnedQuantity, CreatedAt, UpdatedAt) VALUES (?, ?, ?, 0, NOW(), NOW())"
                        Using cmd As New OleDb.OleDbCommand(insertItemSql, cn, tx)
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = newBorrowingID})
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = equipmentID})
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = quantity})
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Update Equipment stock
                        Dim updateStockSql As String = "UPDATE Equipment SET Stock = Stock - ?, UpdatedAt = NOW() WHERE EquipmentID = ?"
                        Using cmd As New OleDb.OleDbCommand(updateStockSql, cn, tx)
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = quantity})
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = equipmentID})
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    tx.Commit()
                    MessageBox.Show("Borrowing transaction saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    Private Sub UpdateBorrowing()
        ' For update, we need to handle item changes and stock adjustments
        Dim connString As String = DataAccess.GetConnectionString()

        Using cn As New OleDb.OleDbConnection(connString)
            cn.Open()
            Using tx As OleDb.OleDbTransaction = cn.BeginTransaction()
                Try
                    ' 1. Update Borrowing header
                    Dim updateBorrowingSql As String = "UPDATE Borrowings SET BorrowerID = ?, BorrowDate = ?, ExpectedReturnDate = ?, Notes = ?, UpdatedAt = NOW() WHERE BorrowingID = ?"
                    Dim notesValue As Object = If(String.IsNullOrWhiteSpace(txtNotes.Text), DirectCast(DBNull.Value, Object), DirectCast(txtNotes.Text.Trim(), Object))
                    Using cmd As New OleDb.OleDbCommand(updateBorrowingSql, cn, tx)
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = CInt(cboBorrower.SelectedValue)})
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = dtpBorrowDate.Value.Date})
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = dtpExpectedReturn.Value.Date})
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = notesValue})
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = borrowingID})
                        cmd.ExecuteNonQuery()
                    End Using

                    ' 2. Get old items and restore stock
                    Dim oldItemsSql As String = "SELECT EquipmentID, Quantity FROM BorrowingItems WHERE BorrowingID = ?"
                    Using cmd As New OleDb.OleDbCommand(oldItemsSql, cn, tx)
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = borrowingID})
                        Using da As New OleDb.OleDbDataAdapter(cmd)
                            Dim oldItemsDt As New DataTable()
                            da.Fill(oldItemsDt)
                            For Each oldRow As DataRow In oldItemsDt.Rows
                                Dim restoreStockSql As String = "UPDATE Equipment SET Stock = Stock + ?, UpdatedAt = NOW() WHERE EquipmentID = ?"
                                Using restoreCmd As New OleDb.OleDbCommand(restoreStockSql, cn, tx)
                                    restoreCmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = CInt(oldRow("Quantity"))})
                                    restoreCmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = CInt(oldRow("EquipmentID"))})
                                    restoreCmd.ExecuteNonQuery()
                                End Using
                            Next
                        End Using
                    End Using

                    ' 3. Delete old items
                    Dim deleteItemsSql As String = "DELETE FROM BorrowingItems WHERE BorrowingID = ?"
                    Using cmd As New OleDb.OleDbCommand(deleteItemsSql, cn, tx)
                        cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = borrowingID})
                        cmd.ExecuteNonQuery()
                    End Using

                    ' 4. Insert new items and update stock
                    For Each row As DataRow In dtItems.Rows
                        Dim equipmentID As Integer = CInt(row("EquipmentID"))
                        Dim quantity As Integer = CInt(row("Quantity"))

                        ' Insert BorrowingItem
                        Dim insertItemSql As String = "INSERT INTO BorrowingItems (BorrowingID, EquipmentID, Quantity, ReturnedQuantity, CreatedAt, UpdatedAt) VALUES (?, ?, ?, 0, NOW(), NOW())"
                        Using cmd As New OleDb.OleDbCommand(insertItemSql, cn, tx)
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = borrowingID})
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = equipmentID})
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = quantity})
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Update Equipment stock
                        Dim updateStockSql As String = "UPDATE Equipment SET Stock = Stock - ?, UpdatedAt = NOW() WHERE EquipmentID = ?"
                        Using cmd As New OleDb.OleDbCommand(updateStockSql, cn, tx)
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = quantity})
                            cmd.Parameters.Add(New OleDb.OleDbParameter() With {.Value = equipmentID})
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    tx.Commit()
                    MessageBox.Show("Borrowing transaction updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
End Class

