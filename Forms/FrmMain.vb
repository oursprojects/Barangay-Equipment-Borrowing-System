Imports System.Drawing
Imports System.Windows.Forms
Imports System

Public Class FrmMain
    Private dbStatus As String = "Disconnected"


    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Barangay Equipment Borrowing System"
        Me.WindowState = FormWindowState.Maximized
        
        ' Set form background color
        Me.BackColor = Color.FromArgb(240, 240, 240)
        
        ' Initialize status bar
        dbStatus = "Disconnected"
        UpdateStatusBar()
        
        ' Start timer for status bar updates
        If TimerStatus IsNot Nothing Then
            TimerStatus.Start()
        End If
        
        ' Test database connection
        Try
            Dim connectionResult As String = DataAccess.TestConnection()
            If connectionResult <> "OK" Then
                dbStatus = "Error"
                UpdateStatusBar()
                MessageBox.Show(connectionResult, 
                              "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                dbStatus = "Connected"
                UpdateStatusBar()
                ' Seed database if empty
                DatabaseSeeder.SeedDatabase()
            End If
        Catch ex As Exception
            dbStatus = "Error"
            UpdateStatusBar()
        End Try
    End Sub

    Private Sub UpdateStatusBar()
        Try
            If lblDBStatus IsNot Nothing Then
                lblDBStatus.Text = "Database: " & dbStatus
                If dbStatus = "Connected" Then
                    lblDBStatus.ForeColor = Color.Green
                ElseIf dbStatus = "Error" Then
                    lblDBStatus.ForeColor = Color.Red
                Else
                    lblDBStatus.ForeColor = Color.Orange
                End If
            End If
        Catch
            ' Ignore errors
        End Try
    End Sub

    Private Sub TimerStatus_Tick(sender As Object, e As EventArgs) Handles TimerStatus.Tick
        Try
            If lblDateTime IsNot Nothing Then
                lblDateTime.Text = "Date/Time: " & Now.ToString("yyyy-MM-dd HH:mm:ss")
            End If
        Catch
            ' Ignore errors
        End Try
    End Sub

    Private Sub EquipmentMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipmentMaintenanceToolStripMenuItem.Click
        Dim frm As New FrmEquipmentList
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BorrowersMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrowersMaintenanceToolStripMenuItem.Click
        Dim frm As New FrmBorrowerList
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BorrowingsTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrowingsTransactionToolStripMenuItem.Click
        Dim frm As New FrmBorrowingList
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ' Close FrmMain - welcome form will be shown again automatically
        Me.Close()
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub BtnEquipment_Click(sender As Object, e As EventArgs) Handles btnEquipment.Click
        EquipmentMaintenanceToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub BtnBorrowers_Click(sender As Object, e As EventArgs) Handles btnBorrowers.Click
        BorrowersMaintenanceToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub BtnBorrowings_Click(sender As Object, e As EventArgs) Handles btnBorrowings.Click
        BorrowingsTransactionToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub FrmMain_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate
        ' Hide welcome panel when a child form is opened
        Try
            If pnlWelcome IsNot Nothing Then
                If Me.MdiChildren.Length > 0 Then
                    pnlWelcome.Visible = False
                Else
                    pnlWelcome.Visible = True
                End If
            End If
        Catch
            ' Ignore errors
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmAbout As New FrmAbout()
        frmAbout.ShowDialog(Me)
    End Sub
End Class

