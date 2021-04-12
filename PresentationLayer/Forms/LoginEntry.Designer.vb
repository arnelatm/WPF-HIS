Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginEntry
    Inherits BfMain

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btn_Login = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.Label4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.textBoxUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.textBoxPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.chkSaveUserNameAndPassword = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'btn_Login
        '
        Me.btn_Login.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btn_Login.BackColor = System.Drawing.Color.Green
        Me.btn_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Login.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Login.ImageIndex = 0
        Me.btn_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Login.Location = New System.Drawing.Point(200, 296)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(75, 33)
        Me.btn_Login.TabIndex = 20
        Me.btn_Login.Text = "Login"
        Me.btn_Login.UseVisualStyleBackColor = false
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Green
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(75, 296)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(77, 33)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = false
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.AATM.PresentationLayer.Forms.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(75, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 150)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = false
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CFlowLayout1.Controls.Add(Me.Label4)
        Me.CFlowLayout1.Controls.Add(Me.textBoxUserName)
        Me.CFlowLayout1.Controls.Add(Me.Label3)
        Me.CFlowLayout1.Controls.Add(Me.textBoxPassword)
        Me.CFlowLayout1.Controls.Add(Me.chkSaveUserNameAndPassword)
        Me.CFlowLayout1.Controls.Add(Me.CLabel2)
        Me.CFlowLayout1.Location = New System.Drawing.Point(12, 168)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(20)
        Me.CFlowLayout1.Size = New System.Drawing.Size(325, 112)
        Me.CFlowLayout1.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.DisplayOnly = true
        Me.Label4.EditingMode = false
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(20, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 20)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "User Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textBoxUserName
        '
        Me.textBoxUserName.BackColor = System.Drawing.Color.White
        Me.textBoxUserName.BegFindValue = Nothing
        Me.textBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textBoxUserName.ComputedValue = false
        Me.textBoxUserName.CustomFormat = Nothing
        Me.textBoxUserName.DataBoundControl = true
        Me.textBoxUserName.EditingMode = false
        Me.textBoxUserName.EndFindValue = Nothing
        Me.textBoxUserName.FieldName = Nothing
        Me.textBoxUserName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.textBoxUserName.FindEnabled = false
        Me.textBoxUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.textBoxUserName.ForeColor = System.Drawing.Color.Black
        Me.textBoxUserName.LinkedLabel = Nothing
        Me.textBoxUserName.Location = New System.Drawing.Point(96, 20)
        Me.textBoxUserName.Margin = New System.Windows.Forms.Padding(0)
        Me.textBoxUserName.MaximumValue = Nothing
        Me.textBoxUserName.MinimumValue = Nothing
        Me.textBoxUserName.Name = "textBoxUserName"
        Me.textBoxUserName.OldValue = Nothing
        Me.textBoxUserName.ReadOnly = true
        Me.textBoxUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.textBoxUserName.Size = New System.Drawing.Size(201, 23)
        Me.textBoxUserName.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(20, 43)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Password:"
        '
        'textBoxPassword
        '
        Me.textBoxPassword.BackColor = System.Drawing.Color.White
        Me.textBoxPassword.BegFindValue = Nothing
        Me.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textBoxPassword.ComputedValue = false
        Me.textBoxPassword.CustomFormat = Nothing
        Me.textBoxPassword.DataBoundControl = true
        Me.textBoxPassword.EditingMode = false
        Me.textBoxPassword.EndFindValue = Nothing
        Me.textBoxPassword.FieldName = Nothing
        Me.textBoxPassword.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.textBoxPassword.FindEnabled = false
        Me.textBoxPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.textBoxPassword.ForeColor = System.Drawing.Color.Black
        Me.textBoxPassword.LinkedLabel = Nothing
        Me.textBoxPassword.Location = New System.Drawing.Point(96, 43)
        Me.textBoxPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.textBoxPassword.MaximumValue = Nothing
        Me.textBoxPassword.MinimumValue = Nothing
        Me.textBoxPassword.Name = "textBoxPassword"
        Me.textBoxPassword.OldValue = Nothing
        Me.textBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBoxPassword.ReadOnly = true
        Me.textBoxPassword.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.textBoxPassword.Size = New System.Drawing.Size(201, 23)
        Me.textBoxPassword.TabIndex = 21
        Me.textBoxPassword.Text = "1"
        '
        'chkSaveUserNameAndPassword
        '
        Me.chkSaveUserNameAndPassword.BackColor = System.Drawing.Color.White
        Me.chkSaveUserNameAndPassword.BegFindValue = Nothing
        Me.chkSaveUserNameAndPassword.DisplayOnly = false
        Me.chkSaveUserNameAndPassword.EditingMode = true
        Me.chkSaveUserNameAndPassword.EndFindValue = Nothing
        Me.chkSaveUserNameAndPassword.FieldName = Nothing
        Me.chkSaveUserNameAndPassword.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkSaveUserNameAndPassword.FindEnabled = false
        Me.chkSaveUserNameAndPassword.FlatAppearance.BorderSize = 0
        Me.chkSaveUserNameAndPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSaveUserNameAndPassword.ForeColor = System.Drawing.Color.Black
        Me.chkSaveUserNameAndPassword.IFindableControl_FindEnabled = false
        Me.chkSaveUserNameAndPassword.LinkedLabel = Nothing
        Me.chkSaveUserNameAndPassword.Location = New System.Drawing.Point(21, 67)
        Me.chkSaveUserNameAndPassword.Margin = New System.Windows.Forms.Padding(1)
        Me.chkSaveUserNameAndPassword.Name = "chkSaveUserNameAndPassword"
        Me.chkSaveUserNameAndPassword.NoLabel = true
        Me.chkSaveUserNameAndPassword.OldValue = Nothing
        Me.chkSaveUserNameAndPassword.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkSaveUserNameAndPassword.Size = New System.Drawing.Size(24, 23)
        Me.chkSaveUserNameAndPassword.TabIndex = 22
        Me.chkSaveUserNameAndPassword.Text = "CCheckBox1"
        Me.chkSaveUserNameAndPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSaveUserNameAndPassword.UseVisualStyleBackColor = true
        '
        'CLabel2
        '
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(47, 67)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(249, 23)
        Me.CLabel2.TabIndex = 24
        Me.CLabel2.Text = "Save User Name and Password"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LoginEntry
        '
        Me.AcceptButton = Me.btn_Login
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(349, 341)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_Login)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "LoginEntry"
        Me.Text = "Login Form"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents btn_Login As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label4 As CLabel
    Friend WithEvents textBoxUserName As CTextBox
    Friend WithEvents textBoxPassword As CTextBox
    Friend WithEvents chkSaveUserNameAndPassword As CCheckBox
    Friend WithEvents CLabel2 As CLabel
End Class