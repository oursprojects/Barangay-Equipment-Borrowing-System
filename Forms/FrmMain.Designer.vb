<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
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
        components = New ComponentModel.Container()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        MaintenanceToolStripMenuItem = New ToolStripMenuItem()
        EquipmentMaintenanceToolStripMenuItem = New ToolStripMenuItem()
        BorrowersMaintenanceToolStripMenuItem = New ToolStripMenuItem()
        TransactionsToolStripMenuItem = New ToolStripMenuItem()
        BorrowingsTransactionToolStripMenuItem = New ToolStripMenuItem()
        WindowToolStripMenuItem = New ToolStripMenuItem()
        CascadeToolStripMenuItem = New ToolStripMenuItem()
        TileHorizontalToolStripMenuItem = New ToolStripMenuItem()
        TileVerticalToolStripMenuItem = New ToolStripMenuItem()
        HelpToolStripMenuItem = New ToolStripMenuItem()
        AboutToolStripMenuItem = New ToolStripMenuItem()
        ToolStrip1 = New ToolStrip()
        btnEquipment = New ToolStripButton()
        btnBorrowers = New ToolStripButton()
        btnBorrowings = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        StatusStrip1 = New StatusStrip()
        lblDBStatus = New ToolStripStatusLabel()
        ToolStripStatusLabel1 = New ToolStripStatusLabel()
        lblDateTime = New ToolStripStatusLabel()
        TimerStatus = New Timer(components)
        pnlWelcome = New Panel()
        lblWelcomeTitle = New Label()
        lblWelcomeSubtitle = New Label()
        MenuStrip1.SuspendLayout()
        ToolStrip1.SuspendLayout()
        StatusStrip1.SuspendLayout()
        pnlWelcome.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, MaintenanceToolStripMenuItem, TransactionsToolStripMenuItem, WindowToolStripMenuItem, HelpToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(912, 27)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ExitToolStripMenuItem})
        FileToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(41, 23)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(99, 24)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' MaintenanceToolStripMenuItem
        ' 
        MaintenanceToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {EquipmentMaintenanceToolStripMenuItem, BorrowersMaintenanceToolStripMenuItem})
        MaintenanceToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem"
        MaintenanceToolStripMenuItem.Size = New Size(100, 23)
        MaintenanceToolStripMenuItem.Text = "Maintenance"
        ' 
        ' EquipmentMaintenanceToolStripMenuItem
        ' 
        EquipmentMaintenanceToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        EquipmentMaintenanceToolStripMenuItem.Name = "EquipmentMaintenanceToolStripMenuItem"
        EquipmentMaintenanceToolStripMenuItem.Size = New Size(227, 24)
        EquipmentMaintenanceToolStripMenuItem.Text = "Equipment Maintenance"
        ' 
        ' BorrowersMaintenanceToolStripMenuItem
        ' 
        BorrowersMaintenanceToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BorrowersMaintenanceToolStripMenuItem.Name = "BorrowersMaintenanceToolStripMenuItem"
        BorrowersMaintenanceToolStripMenuItem.Size = New Size(227, 24)
        BorrowersMaintenanceToolStripMenuItem.Text = "Borrowers Maintenance"
        ' 
        ' TransactionsToolStripMenuItem
        ' 
        TransactionsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {BorrowingsTransactionToolStripMenuItem})
        TransactionsToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TransactionsToolStripMenuItem.Name = "TransactionsToolStripMenuItem"
        TransactionsToolStripMenuItem.Size = New Size(96, 23)
        TransactionsToolStripMenuItem.Text = "Transactions"
        ' 
        ' BorrowingsTransactionToolStripMenuItem
        ' 
        BorrowingsTransactionToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BorrowingsTransactionToolStripMenuItem.Name = "BorrowingsTransactionToolStripMenuItem"
        BorrowingsTransactionToolStripMenuItem.Size = New Size(220, 24)
        BorrowingsTransactionToolStripMenuItem.Text = "Borrowings Transaction"
        ' 
        ' WindowToolStripMenuItem
        ' 
        WindowToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CascadeToolStripMenuItem, TileHorizontalToolStripMenuItem, TileVerticalToolStripMenuItem})
        WindowToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        WindowToolStripMenuItem.Size = New Size(71, 23)
        WindowToolStripMenuItem.Text = "Window"
        ' 
        ' CascadeToolStripMenuItem
        ' 
        CascadeToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        CascadeToolStripMenuItem.Size = New Size(165, 24)
        CascadeToolStripMenuItem.Text = "Cascade"
        ' 
        ' TileHorizontalToolStripMenuItem
        ' 
        TileHorizontalToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        TileHorizontalToolStripMenuItem.Size = New Size(165, 24)
        TileHorizontalToolStripMenuItem.Text = "Tile Horizontal"
        ' 
        ' TileVerticalToolStripMenuItem
        ' 
        TileVerticalToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        TileVerticalToolStripMenuItem.Size = New Size(165, 24)
        TileVerticalToolStripMenuItem.Text = "Tile Vertical"
        ' 
        ' HelpToolStripMenuItem
        ' 
        HelpToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AboutToolStripMenuItem})
        HelpToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        HelpToolStripMenuItem.Size = New Size(49, 23)
        HelpToolStripMenuItem.Text = "Help"
        ' 
        ' AboutToolStripMenuItem
        ' 
        AboutToolStripMenuItem.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        AboutToolStripMenuItem.Size = New Size(116, 24)
        AboutToolStripMenuItem.Text = "About"
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.ImageScalingSize = New Size(20, 20)
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnEquipment, btnBorrowers, btnBorrowings, ToolStripSeparator1})
        ToolStrip1.Location = New Point(0, 27)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(912, 26)
        ToolStrip1.TabIndex = 1
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' btnEquipment
        ' 
        btnEquipment.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEquipment.ImageTransparentColor = Color.Magenta
        btnEquipment.Name = "btnEquipment"
        btnEquipment.Size = New Size(84, 23)
        btnEquipment.Text = "Equipment"
        btnEquipment.ToolTipText = "Open Equipment Maintenance"
        ' 
        ' btnBorrowers
        ' 
        btnBorrowers.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnBorrowers.ImageTransparentColor = Color.Magenta
        btnBorrowers.Name = "btnBorrowers"
        btnBorrowers.Size = New Size(83, 23)
        btnBorrowers.Text = "Borrowers"
        btnBorrowers.ToolTipText = "Open Borrowers Maintenance"
        ' 
        ' btnBorrowings
        ' 
        btnBorrowings.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnBorrowings.ImageTransparentColor = Color.Magenta
        btnBorrowings.Name = "btnBorrowings"
        btnBorrowings.Size = New Size(90, 23)
        btnBorrowings.Text = "Borrowings"
        btnBorrowings.ToolTipText = "Open Borrowings Transaction"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 26)
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(20, 20)
        StatusStrip1.Items.AddRange(New ToolStripItem() {lblDBStatus, ToolStripStatusLabel1, lblDateTime})
        StatusStrip1.Location = New Point(0, 540)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(912, 22)
        StatusStrip1.TabIndex = 2
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' lblDBStatus
        ' 
        lblDBStatus.Name = "lblDBStatus"
        lblDBStatus.Size = New Size(112, 17)
        lblDBStatus.Text = "Database: Unknown"
        ' 
        ' ToolStripStatusLabel1
        ' 
        ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        ToolStripStatusLabel1.Size = New Size(10, 17)
        ToolStripStatusLabel1.Text = "|"
        ' 
        ' lblDateTime
        ' 
        lblDateTime.Name = "lblDateTime"
        lblDateTime.Size = New Size(84, 17)
        lblDateTime.Text = "Date/Time: ---"
        ' 
        ' TimerStatus
        ' 
        ' 
        ' pnlWelcome
        ' 
        pnlWelcome.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        pnlWelcome.Controls.Add(lblWelcomeTitle)
        pnlWelcome.Controls.Add(lblWelcomeSubtitle)
        pnlWelcome.Dock = DockStyle.Fill
        pnlWelcome.Location = New Point(0, 53)
        pnlWelcome.Margin = New Padding(3, 2, 3, 2)
        pnlWelcome.Name = "pnlWelcome"
        pnlWelcome.Size = New Size(912, 487)
        pnlWelcome.TabIndex = 3
        ' 
        ' lblWelcomeTitle
        ' 
        lblWelcomeTitle.Anchor = AnchorStyles.None
        lblWelcomeTitle.Font = New Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWelcomeTitle.ForeColor = Color.White
        lblWelcomeTitle.Location = New Point(106, 180)
        lblWelcomeTitle.Name = "lblWelcomeTitle"
        lblWelcomeTitle.Size = New Size(788, 61)
        lblWelcomeTitle.TabIndex = 0
        lblWelcomeTitle.Text = "Equipment Borrowing System"
        lblWelcomeTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblWelcomeSubtitle
        ' 
        lblWelcomeSubtitle.Anchor = AnchorStyles.None
        lblWelcomeSubtitle.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblWelcomeSubtitle.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        lblWelcomeSubtitle.Location = New Point(193, 254)
        lblWelcomeSubtitle.Name = "lblWelcomeSubtitle"
        lblWelcomeSubtitle.Size = New Size(525, 31)
        lblWelcomeSubtitle.TabIndex = 1
        lblWelcomeSubtitle.Text = "Barangay Equipment Management"
        lblWelcomeSubtitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' FrmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        ClientSize = New Size(912, 562)
        Controls.Add(pnlWelcome)
        Controls.Add(StatusStrip1)
        Controls.Add(ToolStrip1)
        Controls.Add(MenuStrip1)
        IsMdiContainer = True
        MainMenuStrip = MenuStrip1
        Name = "FrmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Barangay Equipment Borrowing System"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        pnlWelcome.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EquipmentMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BorrowersMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransactionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BorrowingsTransactionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnEquipment As ToolStripButton
    Friend WithEvents btnBorrowers As ToolStripButton
    Friend WithEvents btnBorrowings As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblDBStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblDateTime As ToolStripStatusLabel
    Friend WithEvents TimerStatus As Timer
    Friend WithEvents pnlWelcome As Panel
    Friend WithEvents lblWelcomeTitle As Label
    Friend WithEvents lblWelcomeSubtitle As Label
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
End Class


