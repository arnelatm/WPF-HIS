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
        Me.Label4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.textBoxUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkSaveUserNameAndPassword = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.floPasswordEntry = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.textConfirmation = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblConfirmation = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.textBoxPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.textNewPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floPasswordEntry.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.TableLayoutPanel2.SuspendLayout
        Me.SuspendLayout
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'btn_Login
        '
        Me.btn_Login.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_Login.BackColor = System.Drawing.Color.Green
        Me.btn_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Login.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Login.ImageIndex = 0
        Me.btn_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Login.Location = New System.Drawing.Point(176, 3)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(75, 23)
        Me.btn_Login.TabIndex = 1
        Me.btn_Login.Text = "Login"
        Me.btn_Login.UseVisualStyleBackColor = false
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancel.BackColor = System.Drawing.Color.Green
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(32, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(77, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = false
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.AATM.PresentationLayer.Forms.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(62, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 150)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = false
        '
        'Label4
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label4, 2)
        Me.Label4.DisplayOnly = true
        Me.Label4.EditingMode = false
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
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
        Me.textBoxUserName.Location = New System.Drawing.Point(120, 0)
        Me.textBoxUserName.Margin = New System.Windows.Forms.Padding(0)
        Me.textBoxUserName.MaximumValue = Nothing
        Me.textBoxUserName.MinimumValue = Nothing
        Me.textBoxUserName.Name = "textBoxUserName"
        Me.textBoxUserName.OldValue = Nothing
        Me.textBoxUserName.ReadOnly = true
        Me.textBoxUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.textBoxUserName.Size = New System.Drawing.Size(171, 23)
        Me.textBoxUserName.TabIndex = 0
        '
        'Label3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label3, 2)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(0, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Password:"
        '
        'chkSaveUserNameAndPassword
        '
        Me.chkSaveUserNameAndPassword.Anchor = System.Windows.Forms.AnchorStyles.None
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
        Me.chkSaveUserNameAndPassword.Location = New System.Drawing.Point(1, 93)
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel2, 2)
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.CLabel2.Location = New System.Drawing.Point(27, 93)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(249, 23)
        Me.CLabel2.TabIndex = 24
        Me.CLabel2.Text = "Save User Name and Password"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNewPassword
        '
        Me.lblNewPassword.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblNewPassword, 2)
        Me.lblNewPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNewPassword.Location = New System.Drawing.Point(0, 46)
        Me.lblNewPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblNewPassword, 2)
        Me.lblNewPassword.Size = New System.Drawing.Size(90, 20)
        Me.lblNewPassword.TabIndex = 31
        Me.lblNewPassword.Text = "New Password:"
        Me.lblNewPassword.Visible = false
        '
        'floPasswordEntry
        '
        Me.floPasswordEntry.BackColor = System.Drawing.Color.Transparent
        Me.floPasswordEntry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floPasswordEntry.Controls.Add(Me.TableLayoutPanel1)
        Me.floPasswordEntry.Location = New System.Drawing.Point(12, 177)
        Me.floPasswordEntry.Name = "floPasswordEntry"
        Me.floPasswordEntry.Size = New System.Drawing.Size(302, 164)
        Me.floPasswordEntry.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.textNewPassword, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.textBoxPassword, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.textConfirmation, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblConfirmation, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.chkSaveUserNameAndPassword, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNewPassword, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.textBoxUserName, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 5)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(291, 152)
        Me.TableLayoutPanel1.TabIndex = 33
        '
        'textConfirmation
        '
        Me.textConfirmation.BackColor = System.Drawing.Color.White
        Me.textConfirmation.BegFindValue = Nothing
        Me.textConfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textConfirmation.ComputedValue = false
        Me.textConfirmation.CustomFormat = Nothing
        Me.textConfirmation.DataBoundControl = true
        Me.textConfirmation.EditingMode = false
        Me.textConfirmation.EndFindValue = Nothing
        Me.textConfirmation.FieldName = Nothing
        Me.textConfirmation.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.textConfirmation.FindEnabled = false
        Me.textConfirmation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.textConfirmation.ForeColor = System.Drawing.Color.Black
        Me.textConfirmation.LinkedLabel = Nothing
        Me.textConfirmation.Location = New System.Drawing.Point(120, 69)
        Me.textConfirmation.Margin = New System.Windows.Forms.Padding(0)
        Me.textConfirmation.MaximumValue = Nothing
        Me.textConfirmation.MinimumValue = Nothing
        Me.textConfirmation.Name = "textConfirmation"
        Me.textConfirmation.OldValue = Nothing
        Me.textConfirmation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textConfirmation.ReadOnly = true
        Me.textConfirmation.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.textConfirmation.Size = New System.Drawing.Size(171, 23)
        Me.textConfirmation.TabIndex = 3
        Me.textConfirmation.Text = "1"
        Me.textConfirmation.Visible = false
        '
        'lblConfirmation
        '
        Me.lblConfirmation.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblConfirmation, 2)
        Me.lblConfirmation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblConfirmation.Location = New System.Drawing.Point(0, 69)
        Me.lblConfirmation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblConfirmation.Name = "lblConfirmation"
        Me.lblConfirmation.Size = New System.Drawing.Size(120, 20)
        Me.lblConfirmation.TabIndex = 34
        Me.lblConfirmation.Text = "Confirm Password:"
        Me.lblConfirmation.Visible = false
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 3)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnCancel, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Login, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 120)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(285, 29)
        Me.TableLayoutPanel2.TabIndex = 33
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
        Me.textBoxPassword.Location = New System.Drawing.Point(120, 23)
        Me.textBoxPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.textBoxPassword.MaximumValue = Nothing
        Me.textBoxPassword.MinimumValue = Nothing
        Me.textBoxPassword.Name = "textBoxPassword"
        Me.textBoxPassword.OldValue = Nothing
        Me.textBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBoxPassword.ReadOnly = true
        Me.textBoxPassword.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.textBoxPassword.Size = New System.Drawing.Size(171, 23)
        Me.textBoxPassword.TabIndex = 1
        Me.textBoxPassword.Text = "1"
        '
        'textNewPassword
        '
        Me.textNewPassword.BackColor = System.Drawing.Color.White
        Me.textNewPassword.BegFindValue = Nothing
        Me.textNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textNewPassword.ComputedValue = false
        Me.textNewPassword.CustomFormat = Nothing
        Me.textNewPassword.DataBoundControl = true
        Me.textNewPassword.EditingMode = false
        Me.textNewPassword.EndFindValue = Nothing
        Me.textNewPassword.FieldName = Nothing
        Me.textNewPassword.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.textNewPassword.FindEnabled = false
        Me.textNewPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.textNewPassword.ForeColor = System.Drawing.Color.Black
        Me.textNewPassword.LinkedLabel = Nothing
        Me.textNewPassword.Location = New System.Drawing.Point(120, 46)
        Me.textNewPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.textNewPassword.MaximumValue = Nothing
        Me.textNewPassword.MinimumValue = Nothing
        Me.textNewPassword.Name = "textNewPassword"
        Me.textNewPassword.OldValue = Nothing
        Me.textNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textNewPassword.ReadOnly = true
        Me.textNewPassword.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.textNewPassword.Size = New System.Drawing.Size(171, 23)
        Me.textNewPassword.TabIndex = 2
        Me.textNewPassword.Text = "1"
        Me.textNewPassword.Visible = false
        '
        'LoginEntry
        '
        Me.AcceptButton = Me.btn_Login
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(326, 366)
        Me.Controls.Add(Me.floPasswordEntry)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "LoginEntry"
        Me.Text = "Login Form"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.floPasswordEntry.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents btn_Login As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label4 As CLabel
    Friend WithEvents textBoxUserName As CTextBox
    Friend WithEvents chkSaveUserNameAndPassword As CCheckBox
    Friend WithEvents CLabel2 As CLabel
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents floPasswordEntry As CFlowLayout
    Friend WithEvents textConfirmation As CTextBox
    Friend WithEvents lblConfirmation As Label
    Friend WithEvents textNewPassword As CTextBox
    Friend WithEvents textBoxPassword As CTextBox
End Class