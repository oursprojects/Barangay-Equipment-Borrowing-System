Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center the form on screen
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        ' Create and show FrmMain
        Dim mainForm As New FrmMain()
        AddHandler mainForm.FormClosed, AddressOf MainForm_FormClosed
        mainForm.Show()
        
        ' Hide this welcome form (don't close it, so app stays running)
        Me.Hide()
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs)
        ' When FrmMain closes, show welcome form again
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
End Class
