Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms


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
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
        Me.TreeViewTableName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TreeViewTableName.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.Location = New System.Drawing.Point(0, 53)
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 205)
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
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
        Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Left
        Me.CFlowLayout1.Location = New System.Drawing.Point(300, 53)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.CFlowLayout1.Size = New System.Drawing.Size(501, 205)
        Me.CFlowLayout1.TabIndex = 125
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(152, 23)
        Me.lblIdNo.TabIndex = 111
        Me.lblIdNo.Text = "ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.TxtIdNo, true)
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.Location = New System.Drawing.Point(165, 11)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.Size = New System.Drawing.Size(77, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblUserName
        '
        Me.lblUserName.DisplayOnly = true
        Me.lblUserName.EditingMode = false
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUserName.Location = New System.Drawing.Point(11, 36)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(152, 23)
        Me.lblUserName.TabIndex = 116
        Me.lblUserName.Text = "Login User Name"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtUserName
        '
        Me.TxtUserName.BackColor = System.Drawing.Color.White
        Me.TxtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUserName.ComputedValue = false
        Me.TxtUserName.CustomFormat = Nothing
        Me.TxtUserName.DataBoundControl = true
        Me.TxtUserName.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.TxtUserName, true)
        Me.TxtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtUserName.ForeColor = System.Drawing.Color.Black
        Me.TxtUserName.LinkedLabel = Me.lblUserName
        Me.TxtUserName.Location = New System.Drawing.Point(165, 36)
        Me.TxtUserName.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtUserName.MaximumValue = Nothing
        Me.TxtUserName.MinimumValue = Nothing
        Me.TxtUserName.Name = "TxtUserName"
        Me.TxtUserName.OldValue = Nothing
        Me.TxtUserName.ReadOnly = true
        Me.TxtUserName.Size = New System.Drawing.Size(200, 23)
        Me.TxtUserName.TabIndex = 1
        '
        'lblFullName
        '
        Me.lblFullName.DisplayOnly = true
        Me.lblFullName.EditingMode = false
        Me.lblFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblFullName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFullName.Location = New System.Drawing.Point(11, 61)
        Me.lblFullName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(152, 23)
        Me.lblFullName.TabIndex = 118
        Me.lblFullName.Text = "Full Name"
        Me.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFullName
        '
        Me.TxtFullName.BackColor = System.Drawing.Color.White
        Me.TxtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFullName.ComputedValue = false
        Me.TxtFullName.CustomFormat = Nothing
        Me.TxtFullName.DataBoundControl = true
        Me.TxtFullName.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.TxtFullName, true)
        Me.TxtFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtFullName.ForeColor = System.Drawing.Color.Black
        Me.TxtFullName.LinkedLabel = Me.lblFullName
        Me.TxtFullName.Location = New System.Drawing.Point(165, 61)
        Me.TxtFullName.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtFullName.MaximumValue = Nothing
        Me.TxtFullName.MinimumValue = Nothing
        Me.TxtFullName.Name = "TxtFullName"
        Me.TxtFullName.OldValue = Nothing
        Me.TxtFullName.ReadOnly = true
        Me.TxtFullName.Size = New System.Drawing.Size(320, 23)
        Me.TxtFullName.TabIndex = 2
        '
        'lblFullNameAra
        '
        Me.lblFullNameAra.DisplayOnly = true
        Me.lblFullNameAra.EditingMode = false
        Me.lblFullNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblFullNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFullNameAra.Location = New System.Drawing.Point(11, 86)
        Me.lblFullNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblFullNameAra.Name = "lblFullNameAra"
        Me.lblFullNameAra.Size = New System.Drawing.Size(152, 23)
        Me.lblFullNameAra.TabIndex = 127
        Me.lblFullNameAra.Text = "Full Name Arabic"
        Me.lblFullNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFullNameAra
        '
        Me.txtFullNameAra.BackColor = System.Drawing.Color.White
        Me.txtFullNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFullNameAra.ComputedValue = false
        Me.txtFullNameAra.CustomFormat = Nothing
        Me.txtFullNameAra.DataBoundControl = true
        Me.txtFullNameAra.EditingMode = false
        Me.txtFullNameAra.EnglishControl = Me.TxtFullName
        Me.txtFullNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtFullNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtFullNameAra.LinkedLabel = Me.lblFullNameAra
        Me.txtFullNameAra.Location = New System.Drawing.Point(165, 86)
        Me.txtFullNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtFullNameAra.MaximumValue = Nothing
        Me.txtFullNameAra.MinimumValue = Nothing
        Me.txtFullNameAra.Name = "txtFullNameAra"
        Me.txtFullNameAra.OldValue = Nothing
        Me.txtFullNameAra.ReadOnly = true
        Me.txtFullNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtFullNameAra.Size = New System.Drawing.Size(320, 23)
        Me.txtFullNameAra.TabIndex = 3
        Me.txtFullNameAra.ValueIsMandatory = true
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel1.Location = New System.Drawing.Point(11, 111)
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
        Me.cacSecurityLevel.DropDownHeight = 1
        Me.cacSecurityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacSecurityLevel.EditingMode = false
        Me.cacSecurityLevel.FilterRule = Nothing
        Me.cacSecurityLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacSecurityLevel.ForeColor = System.Drawing.Color.Black
        Me.cacSecurityLevel.FormattingEnabled = true
        Me.cacSecurityLevel.HideWhenNotEditingOrAdding = false
        Me.cacSecurityLevel.IntegralHeight = false
        Me.cacSecurityLevel.LinkedLabel = Nothing
        Me.cacSecurityLevel.Location = New System.Drawing.Point(165, 111)
        Me.cacSecurityLevel.Margin = New System.Windows.Forms.Padding(1)
        Me.cacSecurityLevel.Name = "cacSecurityLevel"
        Me.cacSecurityLevel.OldValue = 0
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
        Me.lblPassword.DisplayOnly = true
        Me.lblPassword.EditingMode = false
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPassword.Location = New System.Drawing.Point(11, 137)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(152, 23)
        Me.lblPassword.TabIndex = 117
        Me.lblPassword.Text = "Password"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPassword
        '
        Me.TxtPassword.BackColor = System.Drawing.Color.White
        Me.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPassword.ComputedValue = false
        Me.TxtPassword.CustomFormat = Nothing
        Me.TxtPassword.DataBoundControl = true
        Me.TxtPassword.EditingMode = false
        Me.CFlowLayout1.SetFlowBreak(Me.TxtPassword, true)
        Me.TxtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtPassword.ForeColor = System.Drawing.Color.Black
        Me.TxtPassword.LinkedLabel = Me.lblPassword
        Me.TxtPassword.Location = New System.Drawing.Point(165, 137)
        Me.TxtPassword.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtPassword.MaximumValue = Nothing
        Me.TxtPassword.MinimumValue = Nothing
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.OldValue = Nothing
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.ReadOnly = true
        Me.TxtPassword.SecurityKey = ""
        Me.TxtPassword.Size = New System.Drawing.Size(320, 23)
        Me.TxtPassword.TabIndex = 5
        '
        'lblSecurityGroupID
        '
        Me.lblSecurityGroupID.DisplayOnly = true
        Me.lblSecurityGroupID.EditingMode = false
        Me.lblSecurityGroupID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSecurityGroupID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSecurityGroupID.Location = New System.Drawing.Point(11, 162)
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
        Me.cacSecurityGroupIdNo.DropDownHeight = 1
        Me.cacSecurityGroupIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacSecurityGroupIdNo.EditingMode = false
        Me.cacSecurityGroupIdNo.FilterRule = Nothing
        Me.cacSecurityGroupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacSecurityGroupIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacSecurityGroupIdNo.FormattingEnabled = true
        Me.cacSecurityGroupIdNo.HideWhenNotEditingOrAdding = false
        Me.cacSecurityGroupIdNo.IntegralHeight = false
        Me.cacSecurityGroupIdNo.LinkedLabel = Nothing
        Me.cacSecurityGroupIdNo.Location = New System.Drawing.Point(165, 162)
        Me.cacSecurityGroupIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacSecurityGroupIdNo.Name = "cacSecurityGroupIdNo"
        Me.cacSecurityGroupIdNo.OldValue = 0
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(801, 258)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.MinimumSize = New System.Drawing.Size(817, 262)
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
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
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
End NameSpace