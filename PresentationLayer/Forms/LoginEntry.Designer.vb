Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginEntry
    Inherits BFMain

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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkSaveUserNameAndPassword = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.floPasswordEntry = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboBranchIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.textNewPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.textBoxPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.textConfirmation = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblConfirmation = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btn_Login = New System.Windows.Forms.Button()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.floPasswordEntry.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.AATM.PresentationLayer.Forms.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(116, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 150)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label4, 2)
        Me.Label4.DisplayOnly = True
        Me.Label4.EditingMode = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(0, 26)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "User Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Translatable = True
        '
        'txtUserName
        '
        Me.txtUserName.BackColor = System.Drawing.Color.White
        Me.txtUserName.BegFindValue = Nothing
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserName.ComputedValue = False
        Me.txtUserName.CustomFormat = Nothing
        Me.txtUserName.DataBoundControl = True
        Me.txtUserName.EditingMode = False
        Me.txtUserName.EndFindValue = Nothing
        Me.txtUserName.FieldDescription = Nothing
        Me.txtUserName.FieldName = Nothing
        Me.txtUserName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtUserName.FindEnabled = False
        Me.txtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtUserName.ForeColor = System.Drawing.Color.Black
        Me.txtUserName.LinkedLabel = Nothing
        Me.txtUserName.Location = New System.Drawing.Point(120, 26)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(0)
        Me.txtUserName.MaximumValue = Nothing
        Me.txtUserName.MinimumValue = Nothing
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.OldValue = Nothing
        Me.txtUserName.OverrideMaxLength = 0
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtUserName.Size = New System.Drawing.Size(278, 23)
        Me.txtUserName.TabIndex = 0
        Me.txtUserName.Translatable = False
        '
        'Label3
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label3, 2)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(0, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Password:"
        '
        'chkSaveUserNameAndPassword
        '
        Me.chkSaveUserNameAndPassword.BackColor = System.Drawing.Color.White
        Me.chkSaveUserNameAndPassword.BegFindValue = Nothing
        Me.chkSaveUserNameAndPassword.DisplayOnly = False
        Me.chkSaveUserNameAndPassword.EditingMode = True
        Me.chkSaveUserNameAndPassword.EndFindValue = Nothing
        Me.chkSaveUserNameAndPassword.FieldDescription = Nothing
        Me.chkSaveUserNameAndPassword.FieldName = Nothing
        Me.chkSaveUserNameAndPassword.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkSaveUserNameAndPassword.FindEnabled = False
        Me.chkSaveUserNameAndPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSaveUserNameAndPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkSaveUserNameAndPassword.ForeColor = System.Drawing.Color.Black
        Me.chkSaveUserNameAndPassword.IFindableControl_FindEnabled = False
        Me.chkSaveUserNameAndPassword.IgnoreCase = False
        Me.chkSaveUserNameAndPassword.LinkedLabel = Nothing
        Me.chkSaveUserNameAndPassword.Location = New System.Drawing.Point(1, 119)
        Me.chkSaveUserNameAndPassword.Margin = New System.Windows.Forms.Padding(1)
        Me.chkSaveUserNameAndPassword.Name = "chkSaveUserNameAndPassword"
        Me.chkSaveUserNameAndPassword.NoLabel = True
        Me.chkSaveUserNameAndPassword.OldValue = Nothing
        Me.chkSaveUserNameAndPassword.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkSaveUserNameAndPassword.Size = New System.Drawing.Size(13, 13)
        Me.chkSaveUserNameAndPassword.TabIndex = 22
        Me.chkSaveUserNameAndPassword.Text = " "
        Me.chkSaveUserNameAndPassword.Translatable = False
        Me.chkSaveUserNameAndPassword.UseVisualStyleBackColor = False
        '
        'CLabel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel2, 2)
        Me.CLabel2.DisplayOnly = True
        Me.CLabel2.EditingMode = False
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CLabel2.Location = New System.Drawing.Point(16, 119)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(249, 23)
        Me.CLabel2.TabIndex = 24
        Me.CLabel2.Text = "Save User Name and Password"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = True
        '
        'lblNewPassword
        '
        Me.lblNewPassword.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblNewPassword, 2)
        Me.lblNewPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNewPassword.Location = New System.Drawing.Point(0, 72)
        Me.lblNewPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblNewPassword, 2)
        Me.lblNewPassword.Size = New System.Drawing.Size(90, 20)
        Me.lblNewPassword.TabIndex = 31
        Me.lblNewPassword.Text = "New Password:"
        Me.lblNewPassword.Visible = False
        '
        'floPasswordEntry
        '
        Me.floPasswordEntry.BackColor = System.Drawing.Color.Transparent
        Me.floPasswordEntry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floPasswordEntry.Controls.Add(Me.TableLayoutPanel1)
        Me.floPasswordEntry.Location = New System.Drawing.Point(12, 177)
        Me.floPasswordEntry.Name = "floPasswordEntry"
        Me.floPasswordEntry.Size = New System.Drawing.Size(413, 153)
        Me.floPasswordEntry.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.cboBranchIdNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.textNewPassword, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.textBoxPassword, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.textConfirmation, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblConfirmation, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.chkSaveUserNameAndPassword, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNewPassword, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUserName, 2, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(403, 145)
        Me.TableLayoutPanel1.TabIndex = 33
        '
        'cboBranchIdNo
        '
        Me.cboBranchIdNo.BackColor = System.Drawing.Color.White
        Me.cboBranchIdNo.BegFindValue = Nothing
        Me.cboBranchIdNo.ChangingSearchValueOnly = False
        Me.cboBranchIdNo.CurrentSearchTerm = ""
        Me.cboBranchIdNo.DataValue = Nothing
        Me.cboBranchIdNo.DefaultValue = Nothing
        Me.cboBranchIdNo.DisplayMember = "Name"
        Me.cboBranchIdNo.EditingMode = True
        Me.cboBranchIdNo.EndFindValue = Nothing
        Me.cboBranchIdNo.FieldDescription = Nothing
        Me.cboBranchIdNo.FieldName = Nothing
        Me.cboBranchIdNo.FilterRule = Nothing
        Me.cboBranchIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboBranchIdNo.FindEnabled = False
        Me.cboBranchIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboBranchIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboBranchIdNo.FormattingEnabled = True
        Me.cboBranchIdNo.HideWhenNotEditingOrAdding = False
        Me.cboBranchIdNo.IgnoreCase = False
        Me.cboBranchIdNo.IntegralHeight = False
        Me.cboBranchIdNo.LimitToList = False
        Me.cboBranchIdNo.LinkedLabel = Nothing
        Me.cboBranchIdNo.Location = New System.Drawing.Point(121, 1)
        Me.cboBranchIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboBranchIdNo.Name = "cboBranchIdNo"
        Me.cboBranchIdNo.OldValue = 0
        Me.cboBranchIdNo.OriginalDataSource = Nothing
        Me.cboBranchIdNo.OriginalList = Nothing
        Me.cboBranchIdNo.OverrideDropDownStyleList = False
        Me.cboBranchIdNo.PreviousSearchTerm = Nothing
        Me.cboBranchIdNo.PropertySelector = Nothing
        Me.cboBranchIdNo.ReadOnlyCombo = False
        Me.cboBranchIdNo.Size = New System.Drawing.Size(277, 24)
        Me.cboBranchIdNo.SuggestBoxHeight = 200
        Me.cboBranchIdNo.SuggestListOrderRule = Nothing
        Me.cboBranchIdNo.TabIndex = 36
        Me.cboBranchIdNo.TextToSearch = Nothing
        Me.cboBranchIdNo.Translatable = False
        Me.cboBranchIdNo.ValueIsMandatory = False
        Me.cboBranchIdNo.ValueIsNullable = False
        Me.cboBranchIdNo.ValueIsNumeric = False
        Me.cboBranchIdNo.ValueMember = "IdNo"
        '
        'CLabel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel1, 2)
        Me.CLabel1.DisplayOnly = True
        Me.CLabel1.EditingMode = False
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel1.Location = New System.Drawing.Point(0, 0)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(120, 20)
        Me.CLabel1.TabIndex = 35
        Me.CLabel1.Text = "Branch Name"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = True
        '
        'textNewPassword
        '
        Me.textNewPassword.BackColor = System.Drawing.Color.White
        Me.textNewPassword.BegFindValue = Nothing
        Me.textNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textNewPassword.ComputedValue = False
        Me.textNewPassword.CustomFormat = Nothing
        Me.textNewPassword.DataBoundControl = True
        Me.textNewPassword.EditingMode = False
        Me.textNewPassword.EndFindValue = Nothing
        Me.textNewPassword.FieldDescription = Nothing
        Me.textNewPassword.FieldName = Nothing
        Me.textNewPassword.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.textNewPassword.FindEnabled = False
        Me.textNewPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.textNewPassword.ForeColor = System.Drawing.Color.Black
        Me.textNewPassword.LinkedLabel = Nothing
        Me.textNewPassword.Location = New System.Drawing.Point(120, 72)
        Me.textNewPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.textNewPassword.MaximumValue = Nothing
        Me.textNewPassword.MinimumValue = Nothing
        Me.textNewPassword.Name = "textNewPassword"
        Me.textNewPassword.OldValue = Nothing
        Me.textNewPassword.OverrideMaxLength = 0
        Me.textNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textNewPassword.ReadOnly = True
        Me.textNewPassword.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.textNewPassword.Size = New System.Drawing.Size(278, 23)
        Me.textNewPassword.TabIndex = 2
        Me.textNewPassword.Text = "1"
        Me.textNewPassword.Translatable = False
        Me.textNewPassword.Visible = False
        '
        'textBoxPassword
        '
        Me.textBoxPassword.BackColor = System.Drawing.Color.White
        Me.textBoxPassword.BegFindValue = Nothing
        Me.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textBoxPassword.ComputedValue = False
        Me.textBoxPassword.CustomFormat = Nothing
        Me.textBoxPassword.DataBoundControl = True
        Me.textBoxPassword.EditingMode = False
        Me.textBoxPassword.EndFindValue = Nothing
        Me.textBoxPassword.FieldDescription = Nothing
        Me.textBoxPassword.FieldName = Nothing
        Me.textBoxPassword.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.textBoxPassword.FindEnabled = False
        Me.textBoxPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.textBoxPassword.ForeColor = System.Drawing.Color.Black
        Me.textBoxPassword.LinkedLabel = Nothing
        Me.textBoxPassword.Location = New System.Drawing.Point(120, 49)
        Me.textBoxPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.textBoxPassword.MaximumValue = Nothing
        Me.textBoxPassword.MinimumValue = Nothing
        Me.textBoxPassword.Name = "textBoxPassword"
        Me.textBoxPassword.OldValue = Nothing
        Me.textBoxPassword.OverrideMaxLength = 0
        Me.textBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBoxPassword.ReadOnly = True
        Me.textBoxPassword.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.textBoxPassword.Size = New System.Drawing.Size(278, 23)
        Me.textBoxPassword.TabIndex = 1
        Me.textBoxPassword.Text = "1"
        Me.textBoxPassword.Translatable = False
        '
        'textConfirmation
        '
        Me.textConfirmation.BackColor = System.Drawing.Color.White
        Me.textConfirmation.BegFindValue = Nothing
        Me.textConfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textConfirmation.ComputedValue = False
        Me.textConfirmation.CustomFormat = Nothing
        Me.textConfirmation.DataBoundControl = True
        Me.textConfirmation.EditingMode = False
        Me.textConfirmation.EndFindValue = Nothing
        Me.textConfirmation.FieldDescription = Nothing
        Me.textConfirmation.FieldName = Nothing
        Me.textConfirmation.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.textConfirmation.FindEnabled = False
        Me.textConfirmation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.textConfirmation.ForeColor = System.Drawing.Color.Black
        Me.textConfirmation.LinkedLabel = Nothing
        Me.textConfirmation.Location = New System.Drawing.Point(120, 95)
        Me.textConfirmation.Margin = New System.Windows.Forms.Padding(0)
        Me.textConfirmation.MaximumValue = Nothing
        Me.textConfirmation.MinimumValue = Nothing
        Me.textConfirmation.Name = "textConfirmation"
        Me.textConfirmation.OldValue = Nothing
        Me.textConfirmation.OverrideMaxLength = 0
        Me.textConfirmation.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textConfirmation.ReadOnly = True
        Me.textConfirmation.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.textConfirmation.Size = New System.Drawing.Size(278, 23)
        Me.textConfirmation.TabIndex = 3
        Me.textConfirmation.Text = "1"
        Me.textConfirmation.Translatable = False
        Me.textConfirmation.Visible = False
        '
        'lblConfirmation
        '
        Me.lblConfirmation.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblConfirmation, 2)
        Me.lblConfirmation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblConfirmation.Location = New System.Drawing.Point(0, 95)
        Me.lblConfirmation.Margin = New System.Windows.Forms.Padding(0)
        Me.lblConfirmation.Name = "lblConfirmation"
        Me.lblConfirmation.Size = New System.Drawing.Size(120, 20)
        Me.lblConfirmation.TabIndex = 34
        Me.lblConfirmation.Text = "Confirm Password:"
        Me.lblConfirmation.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnCancel, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Login, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 337)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(432, 37)
        Me.TableLayoutPanel2.TabIndex = 34
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancel.BackColor = System.Drawing.Color.Green
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(69, 7)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(77, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btn_Login
        '
        Me.btn_Login.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_Login.BackColor = System.Drawing.Color.Green
        Me.btn_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Login.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Login.ForeColor = System.Drawing.Color.White
        Me.btn_Login.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Login.ImageIndex = 0
        Me.btn_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_Login.Location = New System.Drawing.Point(286, 7)
        Me.btn_Login.Name = "btn_Login"
        Me.btn_Login.Size = New System.Drawing.Size(75, 23)
        Me.btn_Login.TabIndex = 1
        Me.btn_Login.Text = "Login"
        Me.btn_Login.UseVisualStyleBackColor = False
        '
        'LoginEntry
        '
        Me.ClientSize = New System.Drawing.Size(432, 374)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.floPasswordEntry)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "LoginEntry"
        Me.Text = "Login Form"
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.floPasswordEntry.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As CLabel
    Friend WithEvents txtUserName As CTextBox
    Friend WithEvents chkSaveUserNameAndPassword As CCheckBox
    Friend WithEvents CLabel2 As CLabel
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents floPasswordEntry As CFlowLayout
    Friend WithEvents textConfirmation As CTextBox
    Friend WithEvents lblConfirmation As Label
    Friend WithEvents textNewPassword As CTextBox
    Friend WithEvents textBoxPassword As CTextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btn_Login As Button
    Friend WithEvents CLabel1 As CLabel
    Friend WithEvents cboBranchIdNo As CaComboBox
End Class