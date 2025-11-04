Imports System.Data
Imports System.Data.OleDb

Public Class FrmBorrowingList
    Private dtBorrowings As DataTable
    Private bsBorrowings As BindingSource

    Private Sub FrmBorrowingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Borrowings Transaction"
        LoadBorrowings()
        SetupDataGridView()
        LoadStatusCombo()
        LoadSortCombo()
    End Sub

    Private Sub LoadBorrowings()
        Dim sql As String = "SELECT b.BorrowingID, br.FullName, b.BorrowDate, b.ExpectedReturnDate, b.ActualReturnDate, b.Status, b.Notes " &
                           "FROM Borrowings b INNER JOIN Borrowers br ON b.BorrowerID = br.BorrowerID " &
                           "ORDER BY b.BorrowDate DESC"
        dtBorrowings = DataAccess.GetTable(sql)
        bsBorrowings = New BindingSource()
        bsBorrowings.DataSource = dtBorrowings
        dgvBorrowings.DataSource = bsBorrowings
    End Sub

    Private Sub SetupDataGridView()
        dgvBorrowings.AutoGenerateColumns = False
        dgvBorrowings.Columns.Clear()

        dgvBorrowings.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "BorrowingID",
            .HeaderText = "ID",
            .Width = 60,
            .ReadOnly = True
        })

        dgvBorrowings.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "FullName",
            .HeaderText = "Borrower",
            .Width = 180
        })

        dgvBorrowings.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "BorrowDate",
            .HeaderText = "Borrow Date",
            .Width = 120,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "yyyy-MM-dd"}
        })

        dgvBorrowings.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "ExpectedReturnDate",
            .HeaderText = "Expected Return",
            .Width = 120,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "yyyy-MM-dd"}
        })

        dgvBorrowings.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "ActualReturnDate",
            .HeaderText = "Actual Return",
            .Width = 120,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "yyyy-MM-dd"}
        })

        dgvBorrowings.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Status",
            .HeaderText = "Status",
            .Width = 80
        })
    End Sub

    Private Sub LoadStatusCombo()
        cboStatus.Items.Clear()
        cboStatus.Items.Add("All")
        cboStatus.Items.Add("Active")
        cboStatus.Items.Add("Returned")
        cboStatus.SelectedIndex = 0
    End Sub

    Private Sub LoadSortCombo()
        cboSort.Items.Clear()
        cboSort.Items.Add("b.BorrowDate DESC")
        cboSort.Items.Add("b.BorrowDate ASC")
        cboSort.Items.Add("br.FullName ASC")
        cboSort.Items.Add("b.Status ASC")
        cboSort.SelectedIndex = 0
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New FrmBorrowingEdit()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadBorrowings()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvBorrowings.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a borrowing transaction to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Get values from the bound data source
        Dim selectedRow As DataRowView = DirectCast(bsBorrowings.Current, DataRowView)
        Dim borrowingID As Integer = CInt(selectedRow("BorrowingID"))
        Dim status As String = selectedRow("Status").ToString()

        If status = "Returned" Then
            MessageBox.Show("Cannot edit a returned transaction.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim frm As New FrmBorrowingEdit(borrowingID)
        If frm.ShowDialog() = DialogResult.OK Then
            LoadBorrowings()
        End If
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        If dgvBorrowings.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a borrowing transaction to return.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Get values from the bound data source
        Dim selectedRow As DataRowView = DirectCast(bsBorrowings.Current, DataRowView)
        Dim borrowingID As Integer = CInt(selectedRow("BorrowingID"))
        Dim status As String = selectedRow("Status").ToString()

        If status = "Returned" Then
            MessageBox.Show("This transaction is already returned.", "Return Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim frm As New FrmBorrowingReturn(borrowingID)
        If frm.ShowDialog() = DialogResult.OK Then
            LoadBorrowings()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvBorrowings.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a borrowing transaction to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Get the BorrowingID from the bound data source
        Dim selectedRow As DataRowView = DirectCast(bsBorrowings.Current, DataRowView)
        Dim borrowingID As Integer = CInt(selectedRow("BorrowingID"))

        If MessageBox.Show("Are you sure you want to delete this borrowing transaction?", "Confirm Delete", 
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            ' Use transaction to delete header and items
            Dim commands As New List(Of DataAccess.TransactionCommand) From {
                New DataAccess.TransactionCommand("DELETE FROM BorrowingItems WHERE BorrowingID = ?",
                    New List(Of OleDb.OleDbParameter) From {New OleDb.OleDbParameter() With {.Value = borrowingID}}),
                New DataAccess.TransactionCommand("DELETE FROM Borrowings WHERE BorrowingID = ?",
                    New List(Of OleDb.OleDbParameter) From {New OleDb.OleDbParameter() With {.Value = borrowingID}})
            }

            Try
                If DataAccess.ExecuteTransaction(commands) Then
                    MessageBox.Show("Borrowing transaction deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadBorrowings()
                Else
                    MessageBox.Show("Failed to delete borrowing transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting transaction: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadBorrowings()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim where As New List(Of String)
        Dim params As New List(Of OleDb.OleDbParameter)

        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            where.Add("br.FullName LIKE ?")
            params.Add(New OleDb.OleDbParameter() With {.Value = "%" & txtSearch.Text.Trim() & "%"})
        End If

        If chkDateRange.Checked Then
            where.Add("b.BorrowDate BETWEEN ? AND ?")
            params.Add(New OleDb.OleDbParameter() With {.Value = dtpFrom.Value.Date})
            params.Add(New OleDb.OleDbParameter() With {.Value = dtpTo.Value.Date})
        End If

        If cboStatus.SelectedIndex > 0 Then
            where.Add("b.Status = ?")
            params.Add(New OleDb.OleDbParameter() With {.Value = cboStatus.SelectedItem.ToString()})
        End If

        Dim sql As String = "SELECT b.BorrowingID, br.FullName, b.BorrowDate, b.ExpectedReturnDate, b.ActualReturnDate, b.Status, b.Notes " &
                           "FROM Borrowings b INNER JOIN Borrowers br ON b.BorrowerID = br.BorrowerID"

        If where.Count > 0 Then
            sql &= " WHERE " & String.Join(" AND ", where)
        End If

        sql &= " ORDER BY " & cboSort.SelectedItem.ToString()

        dtBorrowings = DataAccess.GetTable(sql, params)
        bsBorrowings.DataSource = dtBorrowings
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private _rows As List(Of DataRow)
    Private _rowIndex As Integer = 0

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If _rows Is Nothing Then
            _rows = dtBorrowings.Rows.Cast(Of DataRow)().ToList()
            _rowIndex = 0
        End If

        Dim y As Integer = 80
        e.Graphics.DrawString("Borrowings Report", New Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, 80, 40)
        e.Graphics.DrawString("Printed: " & Now.ToString("yyyy-MM-dd HH:mm"), New Font("Segoe UI", 9), Brushes.Black, 80, 65)

        ' Header
        Dim headerFont As New Font("Consolas", 8, FontStyle.Bold)
        e.Graphics.DrawString("ID".PadRight(8) & "Borrower".PadRight(25) & "Borrow Date".PadRight(15) & "Expected".PadRight(15) & "Status", 
                             headerFont, Brushes.Black, 80, y)
        y += 20
        e.Graphics.DrawLine(Pens.Black, 80, y, 700, y)
        y += 10

        ' Data rows
        Dim dataFont As New Font("Consolas", 8)
        While _rowIndex < _rows.Count
            Dim r As DataRow = _rows(_rowIndex)
            Dim borrowDate As String = ""
            If Not IsDBNull(r("BorrowDate")) Then
                borrowDate = CDate(r("BorrowDate")).ToString("yyyy-MM-dd")
            End If
            Dim expectedReturn As String = ""
            If Not IsDBNull(r("ExpectedReturnDate")) Then
                expectedReturn = CDate(r("ExpectedReturnDate")).ToString("yyyy-MM-dd")
            End If
            Dim borrowerName As String = r("FullName").ToString()
            If borrowerName.Length > 23 Then borrowerName = borrowerName.Substring(0, 23)
            Dim line As String = $"{r("BorrowingID").ToString().PadRight(8)}{borrowerName.PadRight(25)}{borrowDate.PadRight(15)}{expectedReturn.PadRight(15)}{r("Status").ToString()}"
            e.Graphics.DrawString(line, dataFont, Brushes.Black, 80, y)
            y += 18
            _rowIndex += 1

            If y > e.MarginBounds.Bottom - 40 Then
                e.HasMorePages = True
                Return
            End If
        End While

        _rowIndex = 0
        _rows = Nothing
        e.HasMorePages = False
    End Sub

    Private Sub chkDateRange_CheckedChanged(sender As Object, e As EventArgs) Handles chkDateRange.CheckedChanged
        dtpFrom.Enabled = chkDateRange.Checked
        dtpTo.Enabled = chkDateRange.Checked
    End Sub
End Class

