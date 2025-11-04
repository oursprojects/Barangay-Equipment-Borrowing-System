Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmAbout
    Private Sub FrmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "About - Barangay Equipment Borrowing System"
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class

