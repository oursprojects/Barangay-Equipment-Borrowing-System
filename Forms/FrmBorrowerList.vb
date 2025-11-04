Imports System.Data
Imports System.Data.OleDb

Public Class FrmBorrowerList
    Private dtBorrowers As DataTable
    Private bsBorrowers As BindingSource

    Private Sub FrmBorrowerList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Borrowers Maintenance"
        LoadBorrowers()
        SetupDataGridView()
    End Sub

    Private Sub LoadBorrowers()
        Dim sql As String = "SELECT BorrowerID, FullName, ContactNo, Address, Email, CreatedAt, UpdatedAt FROM Borrowers ORDER BY FullName"
        dtBorrowers = DataAccess.GetTable(sql)
        bsBorrowers = New BindingSource()
        bsBorrowers.DataSource = dtBorrowers
        dgvBorrowers.DataSource = bsBorrowers
    End Sub

    Private Sub SetupDataGridView()
        dgvBorrowers.AutoGenerateColumns = False
        dgvBorrowers.Columns.Clear()

        dgvBorrowers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "BorrowerID",
            .HeaderText = "ID",
            .Width = 60,
            .ReadOnly = True
        })

        dgvBorrowers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "FullName",
            .HeaderText = "Full Name",
            .Width = 200
        })

        dgvBorrowers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "ContactNo",
            .HeaderText = "Contact No",
            .Width = 130
        })

        dgvBorrowers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Address",
            .HeaderText = "Address",
            .Width = 250
        })

        dgvBorrowers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Email",
            .HeaderText = "Email",
            .Width = 180
        })
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New FrmBorrowerEdit()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadBorrowers()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvBorrowers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a borrower to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Get the BorrowerID from the bound data source
        Dim selectedRow As DataRowView = DirectCast(bsBorrowers.Current, DataRowView)
        Dim borrowerID As Integer = CInt(selectedRow("BorrowerID"))
        Dim frm As New FrmBorrowerEdit(borrowerID)
        If frm.ShowDialog() = DialogResult.OK Then
            LoadBorrowers()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvBorrowers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a borrower to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Get values from the bound data source
        Dim selectedRow As DataRowView = DirectCast(bsBorrowers.Current, DataRowView)
        Dim borrowerID As Integer = CInt(selectedRow("BorrowerID"))
        Dim fullName As String = selectedRow("FullName").ToString()

        If MessageBox.Show($"Are you sure you want to delete '{fullName}'?", "Confirm Delete", 
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            ' Check if borrower has any borrowings
            Dim checkSql As String = "SELECT COUNT(*) FROM Borrowings WHERE BorrowerID = ?"
            Dim params As New List(Of OleDb.OleDbParameter) From {
                New OleDb.OleDbParameter() With {.Value = borrowerID}
            }
            Dim count As Integer = CInt(DataAccess.ExecScalar(checkSql, params))

            If count > 0 Then
                MessageBox.Show("Cannot delete this borrower. They have borrowing transactions.", 
                              "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Delete borrower
            Dim deleteSql As String = "DELETE FROM Borrowers WHERE BorrowerID = ?"
            Dim rowsAffected As Integer = DataAccess.ExecNonQuery(deleteSql, params)

            If rowsAffected > 0 Then
                MessageBox.Show("Borrower deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadBorrowers()
            Else
                MessageBox.Show("Failed to delete borrower.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadBorrowers()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim where As New List(Of String)
        Dim params As New List(Of OleDb.OleDbParameter)

        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            where.Add("FullName LIKE ?")
            params.Add(New OleDb.OleDbParameter() With {.Value = "%" & txtSearch.Text.Trim() & "%"})
        End If

        Dim sql As String = "SELECT BorrowerID, FullName, ContactNo, Address, Email, CreatedAt, UpdatedAt FROM Borrowers"
        If where.Count > 0 Then
            sql &= " WHERE " & String.Join(" AND ", where)
        End If

        sql &= " ORDER BY FullName"

        dtBorrowers = DataAccess.GetTable(sql, params)
        bsBorrowers.DataSource = dtBorrowers
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private _rows As List(Of DataRow)
    Private _rowIndex As Integer = 0

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If _rows Is Nothing Then
            _rows = dtBorrowers.Rows.Cast(Of DataRow)().ToList()
            _rowIndex = 0
        End If

        Dim y As Integer = 80
        e.Graphics.DrawString("Borrowers List", New Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, 80, 40)
        e.Graphics.DrawString("Printed: " & Now.ToString("yyyy-MM-dd HH:mm"), New Font("Segoe UI", 9), Brushes.Black, 80, 65)

        ' Header
        Dim headerFont As New Font("Consolas", 9, FontStyle.Bold)
        e.Graphics.DrawString("ID".PadRight(8) & "Full Name".PadRight(30) & "Contact No".PadRight(15) & "Address".PadRight(30) & "Email", 
                             headerFont, Brushes.Black, 80, y)
        y += 20
        e.Graphics.DrawLine(Pens.Black, 80, y, 700, y)
        y += 10

        ' Data rows
        Dim dataFont As New Font("Consolas", 9)
        While _rowIndex < _rows.Count
            Dim r As DataRow = _rows(_rowIndex)
            Dim fullName As String = r("FullName").ToString()
            If fullName.Length > 28 Then fullName = fullName.Substring(0, 28)
            Dim address As String = r("Address").ToString()
            If address.Length > 28 Then address = address.Substring(0, 28)
            Dim line As String = $"{r("BorrowerID").ToString().PadRight(8)}{fullName.PadRight(30)}{r("ContactNo").ToString().PadRight(15)}{address.PadRight(30)}{r("Email").ToString()}"
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
End Class

