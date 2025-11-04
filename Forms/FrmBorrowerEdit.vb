Imports System.Data.OleDb

Public Class FrmBorrowerEdit
    Private borrowerID As Integer = 0
    Private isEditMode As Boolean = False

    Public Sub New()
        InitializeComponent()
        isEditMode = False
        Me.Text = "Add New Borrower"
    End Sub

    Public Sub New(id As Integer)
        InitializeComponent()
        borrowerID = id
        isEditMode = True
        Me.Text = "Edit Borrower"
        LoadBorrower()
    End Sub

    Private Sub LoadBorrower()
        Dim sql As String = "SELECT * FROM Borrowers WHERE BorrowerID = ?"
        Dim params As New List(Of OleDb.OleDbParameter) From {
            New OleDb.OleDbParameter() With {.Value = borrowerID}
        }
        Dim dt As DataTable = DataAccess.GetTable(sql, params)

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            txtFullName.Text = If(IsDBNull(row("FullName")), "", row("FullName").ToString())
            txtContactNo.Text = If(IsDBNull(row("ContactNo")), "", row("ContactNo").ToString())
            txtAddress.Text = If(IsDBNull(row("Address")), "", row("Address").ToString())
            txtEmail.Text = If(IsDBNull(row("Email")), "", row("Email").ToString())
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInput() Then
            Return
        End If

        Try
            If isEditMode Then
                UpdateBorrower()
            Else
                InsertBorrower()
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving borrower: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Full Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(txtEmail.Text) Then
            Try
                Dim addr As New System.Net.Mail.MailAddress(txtEmail.Text)
            Catch
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmail.Focus()
                Return False
            End Try
        End If

        Return True
    End Function

    Private Sub InsertBorrower()
        Dim sql As String = "INSERT INTO Borrowers (FullName, ContactNo, Address, Email, CreatedAt, UpdatedAt) VALUES (?, ?, ?, ?, NOW(), NOW())"
        Dim contactNoValue As Object = If(String.IsNullOrWhiteSpace(txtContactNo.Text), DirectCast(DBNull.Value, Object), DirectCast(txtContactNo.Text.Trim(), Object))
        Dim addressValue As Object = If(String.IsNullOrWhiteSpace(txtAddress.Text), DirectCast(DBNull.Value, Object), DirectCast(txtAddress.Text.Trim(), Object))
        Dim emailValue As Object = If(String.IsNullOrWhiteSpace(txtEmail.Text), DirectCast(DBNull.Value, Object), DirectCast(txtEmail.Text.Trim(), Object))
        Dim params As New List(Of OleDb.OleDbParameter) From {
            New OleDb.OleDbParameter() With {.Value = txtFullName.Text.Trim()},
            New OleDb.OleDbParameter() With {.Value = contactNoValue},
            New OleDb.OleDbParameter() With {.Value = addressValue},
            New OleDb.OleDbParameter() With {.Value = emailValue}
        }

        Dim rowsAffected As Integer = DataAccess.ExecNonQuery(sql, params)
        If rowsAffected > 0 Then
            MessageBox.Show("Borrower added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Throw New Exception("Failed to insert borrower.")
        End If
    End Sub

    Private Sub UpdateBorrower()
        Dim sql As String = "UPDATE Borrowers SET FullName = ?, ContactNo = ?, Address = ?, Email = ?, UpdatedAt = NOW() WHERE BorrowerID = ?"
        Dim contactNoValue As Object = If(String.IsNullOrWhiteSpace(txtContactNo.Text), DirectCast(DBNull.Value, Object), DirectCast(txtContactNo.Text.Trim(), Object))
        Dim addressValue As Object = If(String.IsNullOrWhiteSpace(txtAddress.Text), DirectCast(DBNull.Value, Object), DirectCast(txtAddress.Text.Trim(), Object))
        Dim emailValue As Object = If(String.IsNullOrWhiteSpace(txtEmail.Text), DirectCast(DBNull.Value, Object), DirectCast(txtEmail.Text.Trim(), Object))
        Dim params As New List(Of OleDb.OleDbParameter) From {
            New OleDb.OleDbParameter() With {.Value = txtFullName.Text.Trim()},
            New OleDb.OleDbParameter() With {.Value = contactNoValue},
            New OleDb.OleDbParameter() With {.Value = addressValue},
            New OleDb.OleDbParameter() With {.Value = emailValue},
            New OleDb.OleDbParameter() With {.Value = borrowerID}
        }

        Dim rowsAffected As Integer = DataAccess.ExecNonQuery(sql, params)
        If rowsAffected > 0 Then
            MessageBox.Show("Borrower updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Throw New Exception("Failed to update borrower.")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class

