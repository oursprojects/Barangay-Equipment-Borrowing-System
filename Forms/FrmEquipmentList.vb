Imports System.Data
Imports System.Data.OleDb

Public Class FrmEquipmentList
    Private dtEquipment As DataTable
    Private bsEquipment As BindingSource

    Private Sub FrmEquipmentList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Equipment Maintenance"
        LoadEquipment()
        SetupDataGridView()
    End Sub

    Private Sub LoadEquipment()
        Dim sql As String = "SELECT EquipmentID, ItemName, Category, Description, Stock, Unit, CreatedAt, UpdatedAt FROM Equipment ORDER BY ItemName"
        dtEquipment = DataAccess.GetTable(sql)
        bsEquipment = New BindingSource()
        bsEquipment.DataSource = dtEquipment
        dgvEquipment.DataSource = bsEquipment
    End Sub

    Private Sub SetupDataGridView()
        dgvEquipment.AutoGenerateColumns = False
        dgvEquipment.Columns.Clear()

        dgvEquipment.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "EquipmentID",
            .DataPropertyName = "EquipmentID",
            .HeaderText = "ID",
            .Width = 60,
            .ReadOnly = True
        })

        dgvEquipment.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "ItemName",
            .HeaderText = "Item Name",
            .Width = 150
        })

        dgvEquipment.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Category",
            .HeaderText = "Category",
            .Width = 120
        })

        dgvEquipment.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Description",
            .HeaderText = "Description",
            .Width = 200
        })

        dgvEquipment.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Stock",
            .HeaderText = "Stock",
            .Width = 80
        })

        dgvEquipment.Columns.Add(New DataGridViewTextBoxColumn() With {
            .DataPropertyName = "Unit",
            .HeaderText = "Unit",
            .Width = 80
        })
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New FrmEquipmentEdit()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadEquipment()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvEquipment.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an equipment item to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Get the EquipmentID from the bound data source, not from the grid cell
        Dim selectedRow As DataRowView = DirectCast(bsEquipment.Current, DataRowView)
        Dim equipmentID As Integer = CInt(selectedRow("EquipmentID"))
        Dim frm As New FrmEquipmentEdit(equipmentID)
        If frm.ShowDialog() = DialogResult.OK Then
            LoadEquipment()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvEquipment.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an equipment item to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Get values from the bound data source
        Dim selectedRow As DataRowView = DirectCast(bsEquipment.Current, DataRowView)
        Dim equipmentID As Integer = CInt(selectedRow("EquipmentID"))
        Dim itemName As String = selectedRow("ItemName").ToString()

        If MessageBox.Show($"Are you sure you want to delete '{itemName}'?", "Confirm Delete", 
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            ' Check if equipment is used in any borrowing
            Dim checkSql As String = "SELECT COUNT(*) FROM BorrowingItems WHERE EquipmentID = ?"
            Dim params As New List(Of OleDb.OleDbParameter) From {
                New OleDb.OleDbParameter() With {.Value = equipmentID}
            }
            Dim count As Integer = CInt(DataAccess.ExecScalar(checkSql, params))

            If count > 0 Then
                MessageBox.Show("Cannot delete this equipment. It is being used in borrowing transactions.", 
                              "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Delete equipment
            Dim deleteSql As String = "DELETE FROM Equipment WHERE EquipmentID = ?"
            Dim rowsAffected As Integer = DataAccess.ExecNonQuery(deleteSql, params)

            If rowsAffected > 0 Then
                MessageBox.Show("Equipment deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadEquipment()
            Else
                MessageBox.Show("Failed to delete equipment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadEquipment()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim where As New List(Of String)
        Dim params As New List(Of OleDb.OleDbParameter)

        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            where.Add("ItemName LIKE ?")
            params.Add(New OleDb.OleDbParameter() With {.Value = "%" & txtSearch.Text.Trim() & "%"})
        End If

        If Not String.IsNullOrWhiteSpace(cboCategory.Text) Then
            where.Add("Category = ?")
            params.Add(New OleDb.OleDbParameter() With {.Value = cboCategory.Text.Trim()})
        End If

        Dim sql As String = "SELECT EquipmentID, ItemName, Category, Description, Stock, Unit, CreatedAt, UpdatedAt FROM Equipment"
        If where.Count > 0 Then
            sql &= " WHERE " & String.Join(" AND ", where)
        End If

        sql &= " ORDER BY ItemName"

        dtEquipment = DataAccess.GetTable(sql, params)
        bsEquipment.DataSource = dtEquipment
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private _rows As List(Of DataRow)
    Private _rowIndex As Integer = 0

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If _rows Is Nothing Then
            _rows = dtEquipment.Rows.Cast(Of DataRow)().ToList()
            _rowIndex = 0
        End If

        Dim y As Integer = 80
        e.Graphics.DrawString("Equipment List", New Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, 80, 40)
        e.Graphics.DrawString("Printed: " & Now.ToString("yyyy-MM-dd HH:mm"), New Font("Segoe UI", 9), Brushes.Black, 80, 65)

        ' Header
        Dim headerFont As New Font("Consolas", 9, FontStyle.Bold)
        e.Graphics.DrawString("ID".PadRight(8) & "Item Name".PadRight(25) & "Category".PadRight(15) & "Stock".PadRight(10) & "Unit", 
                             headerFont, Brushes.Black, 80, y)
        y += 20
        e.Graphics.DrawLine(Pens.Black, 80, y, 700, y)
        y += 10

        ' Data rows
        Dim dataFont As New Font("Consolas", 9)
        While _rowIndex < _rows.Count
            Dim r As DataRow = _rows(_rowIndex)
            Dim line As String = $"{r("EquipmentID").ToString().PadRight(8)}{r("ItemName").ToString().PadRight(25)}{r("Category").ToString().PadRight(15)}{r("Stock").ToString().PadRight(10)}{r("Unit").ToString()}"
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

    Private Sub LoadCategories()
        Dim sql As String = "SELECT DISTINCT Category FROM Equipment WHERE Category IS NOT NULL ORDER BY Category"
        Dim dt As DataTable = DataAccess.GetTable(sql)
        cboCategory.Items.Clear()
        cboCategory.Items.Add("")
        For Each row As DataRow In dt.Rows
            If Not IsDBNull(row("Category")) Then
                cboCategory.Items.Add(row("Category").ToString())
            End If
        Next
    End Sub

    Private Sub FrmEquipmentList_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadCategories()
    End Sub
End Class

