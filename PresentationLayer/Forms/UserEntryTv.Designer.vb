Imports AATM.Libraries.CBaseControlsLibrary


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserEntryTv
    Inherits CFormEntryTv

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIDNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblUserName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblFullName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtFullName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblFullNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtFullNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacSecurityLevel = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPassword = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSecurityGroupID = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacSecurityGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 195)
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CFlowLayout1.Controls.Add(Me.lblIDNo)
        Me.CFlowLayout1.Controls.Add(Me.TxtIDNo)
        Me.CFlowLayout1.Controls.Add(Me.lblUserName)
        Me.CFlowLayout1.Controls.Add(Me.TxtUserName)
        Me.CFlowLayout1.Controls.Add(Me.lblFullName)
        Me.CFlowLayout1.Controls.Add(Me.TxtFullName)
        Me.CFlowLayout1.Controls.Add(Me.lblFullNameAra)
        Me.CFlowLayout1.Controls.Add(Me.txtFullNameAra)
        Me.CFlowLayout1.Controls.Add(Me.CLabel1)
        Me.CFlowLayout1.Controls.Add(Me.cacSecurityLevel)
        Me.CFlowLayout1.Controls.Add(Me.lblPassword)
        Me.CFlowLayout1.Controls.Add(Me.TxtPassword)
        Me.CFlowLayout1.Controls.Add(Me.lblSecurityGroupID)
        Me.CFlowLayout1.Controls.Add(Me.cacSecurityGroupIdNo)
        Me.CFlowLayout1.Location = New System.Drawing.Point(306, 12)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(494, 183)
        Me.CFlowLayout1.TabIndex = 125
        '
        'lblIDNo
        '
        Me.lblIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIDNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIDNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIDNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIDNo.Name = "lblIDNo"
        Me.lblIDNo.Size = New System.Drawing.Size(152, 23)
        Me.lblIDNo.TabIndex = 111
        Me.lblIDNo.Text = "ID No."
        Me.lblIDNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtIDNo
        '
        Me.TxtIDNo.AcceptsReturn = false
        Me.TxtIDNo.AcceptsTab = false
        Me.TxtIDNo.BackColor = System.Drawing.Color.White
        Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDNo.ComputedValue = false
        Me.TxtIDNo.DataBoundControl = true
        Me.TxtIDNo.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.TxtIDNo, true)
        Me.TxtIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Me.lblIDNo
        Me.TxtIDNo.Location = New System.Drawing.Point(155, 1)
        Me.TxtIDNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.Size = New System.Drawing.Size(77, 23)
        Me.TxtIDNo.TabIndex = 0
        Me.TxtIDNo.TabStop = false
        '
        'lblUserName
        '
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUserName.Location = New System.Drawing.Point(1, 26)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(152, 23)
        Me.lblUserName.TabIndex = 116
        Me.lblUserName.Text = "Login User Name"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtUserName
        '
        Me.TxtUserName.AcceptsReturn = false
        Me.TxtUserName.AcceptsTab = false
        Me.TxtUserName.BackColor = System.Drawing.Color.White
        Me.TxtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUserName.ComputedValue = false
        Me.TxtUserName.DataBoundControl = true
        Me.TxtUserName.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.TxtUserName, true)
        Me.TxtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtUserName.ForeColor = System.Drawing.Color.Black
        Me.TxtUserName.LinkedLabel = Me.lblUserName
        Me.TxtUserName.Location = New System.Drawing.Point(155, 26)
        Me.TxtUserName.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtUserName.Name = "TxtUserName"
        Me.TxtUserName.Size = New System.Drawing.Size(200, 23)
        Me.TxtUserName.TabIndex = 1
        '
        'lblFullName
        '
        Me.lblFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblFullName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFullName.Location = New System.Drawing.Point(1, 51)
        Me.lblFullName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(152, 23)
        Me.lblFullName.TabIndex = 118
        Me.lblFullName.Text = "Full Name"
        Me.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFullName
        '
        Me.TxtFullName.AcceptsReturn = false
        Me.TxtFullName.AcceptsTab = false
        Me.TxtFullName.BackColor = System.Drawing.Color.White
        Me.TxtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFullName.ComputedValue = false
        Me.TxtFullName.DataBoundControl = true
        Me.TxtFullName.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.TxtFullName, true)
        Me.TxtFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtFullName.ForeColor = System.Drawing.Color.Black
        Me.TxtFullName.LinkedLabel = Me.lblFullName
        Me.TxtFullName.Location = New System.Drawing.Point(155, 51)
        Me.TxtFullName.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtFullName.Name = "TxtFullName"
        Me.TxtFullName.Size = New System.Drawing.Size(320, 23)
        Me.TxtFullName.TabIndex = 2
        '
        'lblFullNameAra
        '
        Me.lblFullNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblFullNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFullNameAra.Location = New System.Drawing.Point(1, 76)
        Me.lblFullNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFullNameAra.Name = "lblFullNameAra"
        Me.lblFullNameAra.Size = New System.Drawing.Size(152, 23)
        Me.lblFullNameAra.TabIndex = 127
        Me.lblFullNameAra.Text = "Full Name Arabic"
        Me.lblFullNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFullNameAra
        '
        Me.txtFullNameAra.AcceptsReturn = false
        Me.txtFullNameAra.AcceptsTab = false
        Me.txtFullNameAra.BackColor = System.Drawing.Color.White
        Me.txtFullNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFullNameAra.ComputedValue = false
        Me.txtFullNameAra.DataBoundControl = true
        Me.txtFullNameAra.EditingMode = false
        Me.txtFullNameAra.EnglishControl = Me.TxtFullName
        Me.txtFullNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtFullNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtFullNameAra.LinkedLabel = Me.lblFullNameAra
        Me.txtFullNameAra.Location = New System.Drawing.Point(155, 76)
        Me.txtFullNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFullNameAra.Name = "txtFullNameAra"
        Me.txtFullNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtFullNameAra.Size = New System.Drawing.Size(320, 23)
        Me.txtFullNameAra.TabIndex = 3
        Me.txtFullNameAra.ValueIsMandatory = true
        '
        'CLabel1
        '
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel1.Location = New System.Drawing.Point(1, 101)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(152, 23)
        Me.CLabel1.TabIndex = 128
        Me.CLabel1.Text = "Security Level"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacSecurityLevel
        '
        Me.cacSecurityLevel.BackColor = System.Drawing.Color.White
        Me.cacSecurityLevel.ChangingSearchValueOnly = false
        Me.cacSecurityLevel.CurrentSearchTerm = ""
        Me.cacSecurityLevel.DefaultValue = Nothing
        Me.cacSecurityLevel.DisplayMember = "Name"
        Me.cacSecurityLevel.DropDownHeight = 200
        Me.cacSecurityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacSecurityLevel.EditingMode = false
        Me.cacSecurityLevel.FilterRule = Nothing
        Me.cacSecurityLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacSecurityLevel.ForeColor = System.Drawing.Color.Black
        Me.cacSecurityLevel.FormattingEnabled = true
        Me.cacSecurityLevel.HideWhenNotEditingOrAdding = false
        Me.cacSecurityLevel.LinkedLabel = Nothing
        Me.cacSecurityLevel.Location = New System.Drawing.Point(155, 101)
        Me.cacSecurityLevel.Margin = New System.Windows.Forms.Padding(1)
        Me.cacSecurityLevel.Name = "cacSecurityLevel"
        Me.cacSecurityLevel.OldValue = Nothing
        Me.cacSecurityLevel.OriginalDataSource = Nothing
        Me.cacSecurityLevel.OriginalList = Nothing
        Me.cacSecurityLevel.OverrideDropDownStyleList = false
        Me.cacSecurityLevel.PreviousSearchTerm = Nothing
        Me.cacSecurityLevel.PreviousSelectedIndex = -1
        Me.cacSecurityLevel.PropertySelector = Nothing
        Me.cacSecurityLevel.ReadOnlyCombo = false
        Me.cacSecurityLevel.SearchAnywhere = false
        Me.cacSecurityLevel.Size = New System.Drawing.Size(320, 24)
        Me.cacSecurityLevel.SuggestBoxHeight = 200
        Me.cacSecurityLevel.SuggestListOrderRule = Nothing
        Me.cacSecurityLevel.TabIndex = 4
        Me.cacSecurityLevel.TextToSearch = Nothing
        Me.cacSecurityLevel.ValueIsMandatory = false
        Me.cacSecurityLevel.ValueIsNullable = false
        Me.cacSecurityLevel.ValueIsNumeric = false
        Me.cacSecurityLevel.ValueMember = "IdNo"
        '
        'lblPassword
        '
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPassword.Location = New System.Drawing.Point(1, 127)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(152, 23)
        Me.lblPassword.TabIndex = 117
        Me.lblPassword.Text = "Password"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPassword
        '
        Me.TxtPassword.AcceptsReturn = false
        Me.TxtPassword.AcceptsTab = false
        Me.TxtPassword.BackColor = System.Drawing.Color.White
        Me.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPassword.ComputedValue = false
        Me.TxtPassword.DataBoundControl = true
        Me.TxtPassword.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.TxtPassword, true)
        Me.TxtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtPassword.ForeColor = System.Drawing.Color.Black
        Me.TxtPassword.LinkedLabel = Me.lblPassword
        Me.TxtPassword.Location = New System.Drawing.Point(155, 127)
        Me.TxtPassword.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.SecurityKey = ""
        Me.TxtPassword.Size = New System.Drawing.Size(320, 23)
        Me.TxtPassword.TabIndex = 5
        '
        'lblSecurityGroupID
        '
        Me.lblSecurityGroupID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSecurityGroupID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSecurityGroupID.Location = New System.Drawing.Point(1, 152)
        Me.lblSecurityGroupID.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSecurityGroupID.Name = "lblSecurityGroupID"
        Me.lblSecurityGroupID.Size = New System.Drawing.Size(152, 23)
        Me.lblSecurityGroupID.TabIndex = 119
        Me.lblSecurityGroupID.Text = "Security Group"
        Me.lblSecurityGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacSecurityGroupIdNo
        '
        Me.cacSecurityGroupIdNo.BackColor = System.Drawing.Color.White
        Me.cacSecurityGroupIdNo.ChangingSearchValueOnly = false
        Me.cacSecurityGroupIdNo.CurrentSearchTerm = ""
        Me.cacSecurityGroupIdNo.DefaultValue = Nothing
        Me.cacSecurityGroupIdNo.DisplayMember = "Name"
        Me.cacSecurityGroupIdNo.DropDownHeight = 200
        Me.cacSecurityGroupIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacSecurityGroupIdNo.EditingMode = false
        Me.cacSecurityGroupIdNo.FilterRule = Nothing
        Me.cacSecurityGroupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacSecurityGroupIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacSecurityGroupIdNo.FormattingEnabled = true
        Me.cacSecurityGroupIdNo.HideWhenNotEditingOrAdding = false
        Me.cacSecurityGroupIdNo.LinkedLabel = Nothing
        Me.cacSecurityGroupIdNo.Location = New System.Drawing.Point(155, 152)
        Me.cacSecurityGroupIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacSecurityGroupIdNo.Name = "cacSecurityGroupIdNo"
        Me.cacSecurityGroupIdNo.OldValue = Nothing
        Me.cacSecurityGroupIdNo.OriginalDataSource = Nothing
        Me.cacSecurityGroupIdNo.OriginalList = Nothing
        Me.cacSecurityGroupIdNo.OverrideDropDownStyleList = false
        Me.cacSecurityGroupIdNo.PreviousSearchTerm = Nothing
        Me.cacSecurityGroupIdNo.PreviousSelectedIndex = -1
        Me.cacSecurityGroupIdNo.PropertySelector = Nothing
        Me.cacSecurityGroupIdNo.ReadOnlyCombo = false
        Me.cacSecurityGroupIdNo.SearchAnywhere = false
        Me.cacSecurityGroupIdNo.Size = New System.Drawing.Size(320, 24)
        Me.cacSecurityGroupIdNo.SuggestBoxHeight = 200
        Me.cacSecurityGroupIdNo.SuggestListOrderRule = Nothing
        Me.cacSecurityGroupIdNo.TabIndex = 6
        Me.cacSecurityGroupIdNo.TextToSearch = Nothing
        Me.cacSecurityGroupIdNo.ValueIsMandatory = false
        Me.cacSecurityGroupIdNo.ValueIsNullable = false
        Me.cacSecurityGroupIdNo.ValueIsNumeric = false
        Me.cacSecurityGroupIdNo.ValueMember = "IdNo"
        '
        'UserEntryTv
        '
        Me.ClientSize = New System.Drawing.Size(833, 282)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "UserEntryTv"
        Me.Text = "User Maintenance Form"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

    End Sub

    Friend WithEvents CFlowLayout1 As CFlowLayout
    Friend WithEvents lblIDNo As CLabel
    Friend WithEvents TxtIDNo As CTextBox
    Friend WithEvents lblUserName As CLabel
    Friend WithEvents TxtUserName As CTextBox
    Friend WithEvents lblFullName As CLabel
    Friend WithEvents TxtFullName As CTextBox
    Friend WithEvents lblPassword As CLabel
    Friend WithEvents TxtPassword As CTextBox
    Friend WithEvents lblSecurityGroupID As CLabel
    Friend WithEvents lblFullNameAra As CLabel
    Friend WithEvents txtFullNameAra As CTextBoxArabic
    Friend WithEvents cacSecurityGroupIdNo As CaComboBox
    Friend WithEvents CLabel1 As CLabel
    Friend WithEvents cacSecurityLevel As CaComboBox
End Class