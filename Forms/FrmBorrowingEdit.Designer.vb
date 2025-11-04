<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBorrowingEdit
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
        Me.lblBorrower = New System.Windows.Forms.Label()
        Me.cboBorrower = New System.Windows.Forms.ComboBox()
        Me.lblBorrowDate = New System.Windows.Forms.Label()
        Me.dtpBorrowDate = New System.Windows.Forms.DateTimePicker()
        Me.lblExpectedReturn = New System.Windows.Forms.Label()
        Me.dtpExpectedReturn = New System.Windows.Forms.DateTimePicker()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.grpItems = New System.Windows.Forms.GroupBox()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.btnRemoveItem = New System.Windows.Forms.Button()
        Me.btnAddItem = New System.Windows.Forms.Button()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.cboEquipment = New System.Windows.Forms.ComboBox()
        Me.lblEquipment = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grpItems.SuspendLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBorrower
        '
        Me.lblBorrower.AutoSize = True
        Me.lblBorrower.Location = New System.Drawing.Point(30, 30)
        Me.lblBorrower.Name = "lblBorrower"
        Me.lblBorrower.Size = New System.Drawing.Size(65, 20)
        Me.lblBorrower.TabIndex = 0
        Me.lblBorrower.Text = "Borrower*:"
        '
        'cboBorrower
        '
        Me.cboBorrower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBorrower.FormattingEnabled = True
        Me.cboBorrower.Location = New System.Drawing.Point(130, 27)
        Me.cboBorrower.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboBorrower.Name = "cboBorrower"
        Me.cboBorrower.Size = New System.Drawing.Size(350, 28)
        Me.cboBorrower.TabIndex = 1
        '
        'lblBorrowDate
        '
        Me.lblBorrowDate.AutoSize = True
        Me.lblBorrowDate.Location = New System.Drawing.Point(30, 70)
        Me.lblBorrowDate.Name = "lblBorrowDate"
        Me.lblBorrowDate.Size = New System.Drawing.Size(88, 20)
        Me.lblBorrowDate.TabIndex = 2
        Me.lblBorrowDate.Text = "Borrow Date*:"
        '
        'dtpBorrowDate
        '
        Me.dtpBorrowDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpBorrowDate.Location = New System.Drawing.Point(130, 67)
        Me.dtpBorrowDate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpBorrowDate.Name = "dtpBorrowDate"
        Me.dtpBorrowDate.Size = New System.Drawing.Size(150, 27)
        Me.dtpBorrowDate.TabIndex = 3
        '
        'lblExpectedReturn
        '
        Me.lblExpectedReturn.AutoSize = True
        Me.lblExpectedReturn.Location = New System.Drawing.Point(30, 110)
        Me.lblExpectedReturn.Name = "lblExpectedReturn"
        Me.lblExpectedReturn.Size = New System.Drawing.Size(125, 20)
        Me.lblExpectedReturn.TabIndex = 4
        Me.lblExpectedReturn.Text = "Expected Return*:"
        '
        'dtpExpectedReturn
        '
        Me.dtpExpectedReturn.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpExpectedReturn.Location = New System.Drawing.Point(160, 107)
        Me.dtpExpectedReturn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpExpectedReturn.Name = "dtpExpectedReturn"
        Me.dtpExpectedReturn.Size = New System.Drawing.Size(150, 27)
        Me.dtpExpectedReturn.TabIndex = 5
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(30, 150)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(48, 20)
        Me.lblNotes.TabIndex = 6
        Me.lblNotes.Text = "Notes:"
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(130, 147)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(350, 60)
        Me.txtNotes.TabIndex = 7
        '
        'grpItems
        '
        Me.grpItems.Controls.Add(Me.dgvItems)
        Me.grpItems.Controls.Add(Me.btnRemoveItem)
        Me.grpItems.Controls.Add(Me.btnAddItem)
        Me.grpItems.Controls.Add(Me.txtQuantity)
        Me.grpItems.Controls.Add(Me.lblQuantity)
        Me.grpItems.Controls.Add(Me.cboEquipment)
        Me.grpItems.Controls.Add(Me.lblEquipment)
        Me.grpItems.Location = New System.Drawing.Point(30, 220)
        Me.grpItems.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpItems.Name = "grpItems"
        Me.grpItems.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpItems.Size = New System.Drawing.Size(700, 350)
        Me.grpItems.TabIndex = 8
        Me.grpItems.TabStop = False
        Me.grpItems.Text = "Equipment Items"
        '
        'dgvItems
        '
        Me.dgvItems.AllowUserToAddRows = False
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.Location = New System.Drawing.Point(15, 120)
        Me.dgvItems.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.ReadOnly = True
        Me.dgvItems.RowHeadersWidth = 51
        Me.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItems.Size = New System.Drawing.Size(670, 220)
        Me.dgvItems.TabIndex = 6
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.Location = New System.Drawing.Point(590, 75)
        Me.btnRemoveItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Size = New System.Drawing.Size(95, 29)
        Me.btnRemoveItem.TabIndex = 5
        Me.btnRemoveItem.Text = "Remove"
        Me.btnRemoveItem.UseVisualStyleBackColor = True
        '
        'btnAddItem
        '
        Me.btnAddItem.Location = New System.Drawing.Point(490, 75)
        Me.btnAddItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(94, 29)
        Me.btnAddItem.TabIndex = 4
        Me.btnAddItem.Text = "Add"
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(400, 75)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(80, 27)
        Me.txtQuantity.TabIndex = 3
        Me.txtQuantity.Text = "1"
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Location = New System.Drawing.Point(330, 78)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(65, 20)
        Me.lblQuantity.TabIndex = 2
        Me.lblQuantity.Text = "Quantity:"
        '
        'cboEquipment
        '
        Me.cboEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEquipment.FormattingEnabled = True
        Me.cboEquipment.Location = New System.Drawing.Point(100, 75)
        Me.cboEquipment.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboEquipment.Name = "cboEquipment"
        Me.cboEquipment.Size = New System.Drawing.Size(220, 28)
        Me.cboEquipment.TabIndex = 1
        '
        'lblEquipment
        '
        Me.lblEquipment.AutoSize = True
        Me.lblEquipment.Location = New System.Drawing.Point(15, 78)
        Me.lblEquipment.Name = "lblEquipment"
        Me.lblEquipment.Size = New System.Drawing.Size(79, 20)
        Me.lblEquipment.TabIndex = 0
        Me.lblEquipment.Text = "Equipment:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(300, 590)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 29)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(410, 590)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 29)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FrmBorrowingEdit
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(760, 640)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpItems)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.dtpExpectedReturn)
        Me.Controls.Add(Me.lblExpectedReturn)
        Me.Controls.Add(Me.dtpBorrowDate)
        Me.Controls.Add(Me.lblBorrowDate)
        Me.Controls.Add(Me.cboBorrower)
        Me.Controls.Add(Me.lblBorrower)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBorrowingEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Borrowing Transaction"
        Me.grpItems.ResumeLayout(False)
        Me.grpItems.PerformLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblBorrower As Label
    Friend WithEvents cboBorrower As ComboBox
    Friend WithEvents lblBorrowDate As Label
    Friend WithEvents dtpBorrowDate As DateTimePicker
    Friend WithEvents lblExpectedReturn As Label
    Friend WithEvents dtpExpectedReturn As DateTimePicker
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents grpItems As GroupBox
    Friend WithEvents lblEquipment As Label
    Friend WithEvents cboEquipment As ComboBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents btnAddItem As Button
    Friend WithEvents btnRemoveItem As Button
    Friend WithEvents dgvItems As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class


