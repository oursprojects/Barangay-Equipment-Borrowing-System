<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.lblDevelopers = New System.Windows.Forms.Label()
        Me.lblDev1 = New System.Windows.Forms.Label()
        Me.lblDev2 = New System.Windows.Forms.Label()
        Me.lblDev3 = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(600, 150)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(560, 50)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Equipment Borrowing System"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = False
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(236, 240, 241)
        Me.lblSubtitle.Location = New System.Drawing.Point(20, 80)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(560, 30)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Barangay Equipment Management"
        Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlContent
        '
        Me.pnlContent.Controls.Add(Me.lblDescription)
        Me.pnlContent.Controls.Add(Me.lblVersion)
        Me.pnlContent.Controls.Add(Me.lblDev3)
        Me.pnlContent.Controls.Add(Me.lblDev2)
        Me.pnlContent.Controls.Add(Me.lblDev1)
        Me.pnlContent.Controls.Add(Me.lblDevelopers)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 150)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(30, 25, 30, 80)
        Me.pnlContent.Size = New System.Drawing.Size(600, 280)
        Me.pnlContent.TabIndex = 2
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblVersion.Location = New System.Drawing.Point(350, 25)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(220, 25)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "Version 1.0.0"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDevelopers
        '
        Me.lblDevelopers.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDevelopers.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblDevelopers.Location = New System.Drawing.Point(30, 25)
        Me.lblDevelopers.Name = "lblDevelopers"
        Me.lblDevelopers.Size = New System.Drawing.Size(200, 30)
        Me.lblDevelopers.TabIndex = 0
        Me.lblDevelopers.Text = "Developed By:"
        '
        'lblDev1
        '
        Me.lblDev1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDev1.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94)
        Me.lblDev1.Location = New System.Drawing.Point(50, 65)
        Me.lblDev1.Name = "lblDev1"
        Me.lblDev1.Size = New System.Drawing.Size(300, 30)
        Me.lblDev1.TabIndex = 1
        Me.lblDev1.Text = "• Mike Ryno Santiago"
        '
        'lblDev2
        '
        Me.lblDev2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDev2.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94)
        Me.lblDev2.Location = New System.Drawing.Point(50, 95)
        Me.lblDev2.Name = "lblDev2"
        Me.lblDev2.Size = New System.Drawing.Size(300, 30)
        Me.lblDev2.TabIndex = 2
        Me.lblDev2.Text = "• Jestoni Flores"
        '
        'lblDev3
        '
        Me.lblDev3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDev3.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94)
        Me.lblDev3.Location = New System.Drawing.Point(50, 125)
        Me.lblDev3.Name = "lblDev3"
        Me.lblDev3.Size = New System.Drawing.Size(300, 30)
        Me.lblDev3.TabIndex = 3
        Me.lblDev3.Text = "• Deejay Angelo"
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblDescription.Location = New System.Drawing.Point(30, 170)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(540, 60)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "A comprehensive system for managing barangay equipment borrowing transactions, inventory, and borrower records."
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(250, 380)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 40)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'FrmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(600, 430)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents lblDevelopers As Label
    Friend WithEvents lblDev1 As Label
    Friend WithEvents lblDev2 As Label
    Friend WithEvents lblDev3 As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents btnOK As Button
End Class

