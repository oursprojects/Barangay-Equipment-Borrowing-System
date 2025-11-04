Imports System.Data.OleDb

Public Class FrmEquipmentEdit
    Private equipmentID As Integer = 0
    Private isEditMode As Boolean = False

    Public Sub New()
        InitializeComponent()
        isEditMode = False
        Me.Text = "Add New Equipment"
    End Sub

    Public Sub New(id As Integer)
        InitializeComponent()
        equipmentID = id
        isEditMode = True
        Me.Text = "Edit Equipment"
        LoadEquipment()
    End Sub

    Private Sub LoadEquipment()
        Dim sql As String = "SELECT * FROM Equipment WHERE EquipmentID = ?"
        Dim params As New List(Of OleDb.OleDbParameter) From {
            New OleDb.OleDbParameter() With {.Value = equipmentID}
        }
        Dim dt As DataTable = DataAccess.GetTable(sql, params)

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            txtItemName.Text = If(IsDBNull(row("ItemName")), "", row("ItemName").ToString())
            txtCategory.Text = If(IsDBNull(row("Category")), "", row("Category").ToString())
            txtDescription.Text = If(IsDBNull(row("Description")), "", row("Description").ToString())
            txtStock.Text = If(IsDBNull(row("Stock")), "0", row("Stock").ToString())
            txtUnit.Text = If(IsDBNull(row("Unit")), "", row("Unit").ToString())
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInput() Then
            Return
        End If

        Try
            If isEditMode Then
                UpdateEquipment()
            Else
                InsertEquipment()
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving equipment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtItemName.Text) Then
            MessageBox.Show("Item Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtStock.Text) Then
            MessageBox.Show("Stock is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStock.Focus()
            Return False
        End If

        Dim stock As Integer
        If Not Integer.TryParse(txtStock.Text, stock) OrElse stock < 0 Then
            MessageBox.Show("Stock must be a valid positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStock.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub InsertEquipment()
        Dim sql As String = "INSERT INTO Equipment (ItemName, Category, Description, Stock, Unit, CreatedAt, UpdatedAt) VALUES (?, ?, ?, ?, ?, NOW(), NOW())"
        Dim categoryValue As Object = If(String.IsNullOrWhiteSpace(txtCategory.Text), DirectCast(DBNull.Value, Object), DirectCast(txtCategory.Text.Trim(), Object))
        Dim descriptionValue As Object = If(String.IsNullOrWhiteSpace(txtDescription.Text), DirectCast(DBNull.Value, Object), DirectCast(txtDescription.Text.Trim(), Object))
        Dim unitValue As Object = If(String.IsNullOrWhiteSpace(txtUnit.Text), DirectCast(DBNull.Value, Object), DirectCast(txtUnit.Text.Trim(), Object))
        Dim params As New List(Of OleDb.OleDbParameter) From {
            New OleDb.OleDbParameter() With {.Value = txtItemName.Text.Trim()},
            New OleDb.OleDbParameter() With {.Value = categoryValue},
            New OleDb.OleDbParameter() With {.Value = descriptionValue},
            New OleDb.OleDbParameter() With {.Value = CInt(txtStock.Text)},
            New OleDb.OleDbParameter() With {.Value = unitValue}
        }

        Dim rowsAffected As Integer = DataAccess.ExecNonQuery(sql, params)
        If rowsAffected > 0 Then
            MessageBox.Show("Equipment added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Throw New Exception("Failed to insert equipment.")
        End If
    End Sub

    Private Sub UpdateEquipment()
        Dim sql As String = "UPDATE Equipment SET ItemName = ?, Category = ?, Description = ?, Stock = ?, Unit = ?, UpdatedAt = NOW() WHERE EquipmentID = ?"
        Dim categoryValue As Object = If(String.IsNullOrWhiteSpace(txtCategory.Text), DirectCast(DBNull.Value, Object), DirectCast(txtCategory.Text.Trim(), Object))
        Dim descriptionValue As Object = If(String.IsNullOrWhiteSpace(txtDescription.Text), DirectCast(DBNull.Value, Object), DirectCast(txtDescription.Text.Trim(), Object))
        Dim unitValue As Object = If(String.IsNullOrWhiteSpace(txtUnit.Text), DirectCast(DBNull.Value, Object), DirectCast(txtUnit.Text.Trim(), Object))
        Dim params As New List(Of OleDb.OleDbParameter) From {
            New OleDb.OleDbParameter() With {.Value = txtItemName.Text.Trim()},
            New OleDb.OleDbParameter() With {.Value = categoryValue},
            New OleDb.OleDbParameter() With {.Value = descriptionValue},
            New OleDb.OleDbParameter() With {.Value = CInt(txtStock.Text)},
            New OleDb.OleDbParameter() With {.Value = unitValue},
            New OleDb.OleDbParameter() With {.Value = equipmentID}
        }

        Dim rowsAffected As Integer = DataAccess.ExecNonQuery(sql, params)
        If rowsAffected > 0 Then
            MessageBox.Show("Equipment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Throw New Exception("Failed to update equipment.")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStock.KeyPress
        ' Only allow numbers and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
End Class

