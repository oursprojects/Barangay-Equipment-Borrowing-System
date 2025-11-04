<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBorrowerEdit
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
        lblFullName = New Label()
        txtFullName = New TextBox()
        lblContactNo = New Label()
        txtContactNo = New TextBox()
        lblAddress = New Label()
        txtAddress = New TextBox()
        lblEmail = New Label()
        txtEmail = New TextBox()
        btnSave = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.Location = New Point(26, 22)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(67, 15)
        lblFullName.TabIndex = 0
        lblFullName.Text = "Full Name :"
        ' 
        ' txtFullName
        ' 
        txtFullName.Location = New Point(114, 20)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(307, 23)
        txtFullName.TabIndex = 1
        ' 
        ' lblContactNo
        ' 
        lblContactNo.AutoSize = True
        lblContactNo.Location = New Point(26, 52)
        lblContactNo.Name = "lblContactNo"
        lblContactNo.Size = New Size(74, 15)
        lblContactNo.TabIndex = 2
        lblContactNo.Text = "Contact No :"
        ' 
        ' txtContactNo
        ' 
        txtContactNo.Location = New Point(114, 50)
        txtContactNo.Name = "txtContactNo"
        txtContactNo.Size = New Size(307, 23)
        txtContactNo.TabIndex = 3
        ' 
        ' lblAddress
        ' 
        lblAddress.AutoSize = True
        lblAddress.Location = New Point(26, 82)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(55, 15)
        lblAddress.TabIndex = 4
        lblAddress.Text = "Address :"
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(114, 80)
        txtAddress.Multiline = True
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(307, 61)
        txtAddress.TabIndex = 5
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(26, 150)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(42, 15)
        lblEmail.TabIndex = 6
        lblEmail.Text = "Email :"
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(114, 148)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(307, 23)
        txtEmail.TabIndex = 7
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(175, 188)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(82, 22)
        btnSave.TabIndex = 8
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(271, 188)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(82, 22)
        btnCancel.TabIndex = 9
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' FrmBorrowerEdit
        ' 
        AcceptButton = btnSave
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(455, 232)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(txtEmail)
        Controls.Add(lblEmail)
        Controls.Add(txtAddress)
        Controls.Add(lblAddress)
        Controls.Add(txtContactNo)
        Controls.Add(lblContactNo)
        Controls.Add(txtFullName)
        Controls.Add(lblFullName)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "FrmBorrowerEdit"
        StartPosition = FormStartPosition.CenterParent
        Text = "Borrower"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents lblFullName As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents lblContactNo As Label
    Friend WithEvents txtContactNo As TextBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class


