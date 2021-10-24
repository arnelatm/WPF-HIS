Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserEntryTv))
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblUserName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtUserName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacSecurityLevel = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPassword = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblSecurityGroupID = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacSecurityGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CFlowLayout1)
        Me.SplitContainer1.Size = New System.Drawing.Size(801, 458)
        Me.SplitContainer1.SplitterDistance = 296
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.Size = New System.Drawing.Size(296, 458)
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblUserName)
        Me.CFlowLayout1.Controls.Add(Me.TxtUserName)
        Me.CFlowLayout1.Controls.Add(Me.lblEmployeeIdNo)
        Me.CFlowLayout1.Controls.Add(Me.cacEmployeeIdNo)
        Me.CFlowLayout1.Controls.Add(Me.CLabel1)
        Me.CFlowLayout1.Controls.Add(Me.cacSecurityLevel)
        Me.CFlowLayout1.Controls.Add(Me.lblPassword)
        Me.CFlowLayout1.Controls.Add(Me.TxtPassword)
        Me.CFlowLayout1.Controls.Add(Me.lblSecurityGroupID)
        Me.CFlowLayout1.Controls.Add(Me.cacSecurityGroupIdNo)
        Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFlowLayout1.Location = New System.Drawing.Point(0, 0)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.CFlowLayout1.Size = New System.Drawing.Size(495, 458)
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
        Me.lblIdNo.Translatable = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.EditingMode = false
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
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
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(77, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
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
        Me.lblUserName.Translatable = true
        '
        'TxtUserName
        '
        Me.TxtUserName.BackColor = System.Drawing.Color.White
        Me.TxtUserName.BegFindValue = Nothing
        Me.TxtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUserName.ComputedValue = false
        Me.TxtUserName.CustomFormat = Nothing
        Me.TxtUserName.DataBoundControl = true
        Me.TxtUserName.EditingMode = false
        Me.TxtUserName.EndFindValue = Nothing
        Me.TxtUserName.FieldDescription = Nothing
        Me.TxtUserName.FieldName = Nothing
        Me.TxtUserName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtUserName.FindEnabled = true
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
        Me.TxtUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtUserName.Size = New System.Drawing.Size(200, 23)
        Me.TxtUserName.TabIndex = 1
        Me.TxtUserName.Translatable = false
        Me.TxtUserName.ValueIsUnique = true
        '
        'lblEmployeeIdNo
        '
        Me.lblEmployeeIdNo.DisplayOnly = true
        Me.lblEmployeeIdNo.EditingMode = false
        Me.lblEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEmployeeIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmployeeIdNo.Location = New System.Drawing.Point(11, 61)
        Me.lblEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
        Me.lblEmployeeIdNo.Size = New System.Drawing.Size(152, 23)
        Me.lblEmployeeIdNo.TabIndex = 130
        Me.lblEmployeeIdNo.Text = "Employee Name/Code"
        Me.lblEmployeeIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEmployeeIdNo.Translatable = true
        '
        'cacEmployeeIdNo
        '
        Me.cacEmployeeIdNo.BackColor = System.Drawing.Color.White
        Me.cacEmployeeIdNo.BegFindValue = Nothing
        Me.cacEmployeeIdNo.ChangingSearchValueOnly = false
        Me.cacEmployeeIdNo.CurrentSearchTerm = ""
        Me.cacEmployeeIdNo.DefaultValue = Nothing
        Me.cacEmployeeIdNo.DisplayMember = "Name"
        Me.cacEmployeeIdNo.EditingMode = false
        Me.cacEmployeeIdNo.EndFindValue = Nothing
        Me.cacEmployeeIdNo.FieldDescription = Nothing
        Me.cacEmployeeIdNo.FieldName = Nothing
        Me.cacEmployeeIdNo.FilterRule = Nothing
        Me.cacEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacEmployeeIdNo.FindEnabled = false
        Me.cacEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacEmployeeIdNo.FormattingEnabled = true
        Me.cacEmployeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cacEmployeeIdNo.IgnoreCase = false
        Me.cacEmployeeIdNo.IntegralHeight = false
        Me.cacEmployeeIdNo.LinkedLabel = Nothing
        Me.cacEmployeeIdNo.Location = New System.Drawing.Point(165, 61)
        Me.cacEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacEmployeeIdNo.Name = "cacEmployeeIdNo"
        Me.cacEmployeeIdNo.OldValue = 0
        Me.cacEmployeeIdNo.OriginalDataSource = Nothing
        Me.cacEmployeeIdNo.OriginalList = Nothing
        Me.cacEmployeeIdNo.OverrideDropDownStyleList = false
        Me.cacEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cacEmployeeIdNo.PropertySelector = Nothing
        Me.cacEmployeeIdNo.ReadOnlyCombo = false
        Me.cacEmployeeIdNo.Size = New System.Drawing.Size(320, 24)
        Me.cacEmployeeIdNo.SuggestBoxHeight = 200
        Me.cacEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cacEmployeeIdNo.TabIndex = 131
        Me.cacEmployeeIdNo.TextToSearch = Nothing
        Me.cacEmployeeIdNo.Translatable = false
        Me.cacEmployeeIdNo.ValueIsMandatory = false
        Me.cacEmployeeIdNo.ValueIsNullable = false
        Me.cacEmployeeIdNo.ValueIsNumeric = false
        Me.cacEmployeeIdNo.ValueMember = "IdNo"
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel1.Location = New System.Drawing.Point(11, 87)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(152, 23)
        Me.CLabel1.TabIndex = 128
        Me.CLabel1.Text = "Security Level"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'cacSecurityLevel
        '
        Me.cacSecurityLevel.BackColor = System.Drawing.Color.White
        Me.cacSecurityLevel.BegFindValue = Nothing
        Me.cacSecurityLevel.ChangingSearchValueOnly = false
        Me.cacSecurityLevel.CurrentSearchTerm = ""
        Me.cacSecurityLevel.DefaultValue = Nothing
        Me.cacSecurityLevel.DisplayMember = "Name"
        Me.cacSecurityLevel.EditingMode = false
        Me.cacSecurityLevel.EndFindValue = Nothing
        Me.cacSecurityLevel.FieldDescription = Nothing
        Me.cacSecurityLevel.FieldName = Nothing
        Me.cacSecurityLevel.FilterRule = Nothing
        Me.cacSecurityLevel.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacSecurityLevel.FindEnabled = false
        Me.cacSecurityLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacSecurityLevel.ForeColor = System.Drawing.Color.Black
        Me.cacSecurityLevel.FormattingEnabled = true
        Me.cacSecurityLevel.HideWhenNotEditingOrAdding = false
        Me.cacSecurityLevel.IgnoreCase = false
        Me.cacSecurityLevel.IntegralHeight = false
        Me.cacSecurityLevel.LinkedLabel = Nothing
        Me.cacSecurityLevel.Location = New System.Drawing.Point(165, 87)
        Me.cacSecurityLevel.Margin = New System.Windows.Forms.Padding(1)
        Me.cacSecurityLevel.Name = "cacSecurityLevel"
        Me.cacSecurityLevel.OldValue = 0
        Me.cacSecurityLevel.OriginalDataSource = Nothing
        Me.cacSecurityLevel.OriginalList = Nothing
        Me.cacSecurityLevel.OverrideDropDownStyleList = false
        Me.cacSecurityLevel.PreviousSearchTerm = Nothing
        Me.cacSecurityLevel.PropertySelector = Nothing
        Me.cacSecurityLevel.ReadOnlyCombo = false
        Me.cacSecurityLevel.Size = New System.Drawing.Size(320, 24)
        Me.cacSecurityLevel.SuggestBoxHeight = 200
        Me.cacSecurityLevel.SuggestListOrderRule = Nothing
        Me.cacSecurityLevel.TabIndex = 4
        Me.cacSecurityLevel.TextToSearch = Nothing
        Me.cacSecurityLevel.Translatable = false
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
        Me.lblPassword.Location = New System.Drawing.Point(11, 113)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(152, 23)
        Me.lblPassword.TabIndex = 117
        Me.lblPassword.Text = "Password"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPassword.Translatable = true
        '
        'TxtPassword
        '
        Me.TxtPassword.BackColor = System.Drawing.Color.White
        Me.TxtPassword.BegFindValue = Nothing
        Me.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPassword.ComputedValue = false
        Me.TxtPassword.CustomFormat = Nothing
        Me.TxtPassword.DataBoundControl = true
        Me.TxtPassword.EditingMode = false
        Me.TxtPassword.EndFindValue = Nothing
        Me.TxtPassword.FieldDescription = Nothing
        Me.TxtPassword.FieldName = Nothing
        Me.TxtPassword.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtPassword.FindEnabled = true
        Me.CFlowLayout1.SetFlowBreak(Me.TxtPassword, true)
        Me.TxtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtPassword.ForeColor = System.Drawing.Color.Black
        Me.TxtPassword.LinkedLabel = Me.lblPassword
        Me.TxtPassword.Location = New System.Drawing.Point(165, 113)
        Me.TxtPassword.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtPassword.MaximumValue = Nothing
        Me.TxtPassword.MinimumValue = Nothing
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.OldValue = Nothing
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.ReadOnly = true
        Me.TxtPassword.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtPassword.SecurityKey = ""
        Me.TxtPassword.Size = New System.Drawing.Size(320, 23)
        Me.TxtPassword.TabIndex = 5
        Me.TxtPassword.Translatable = false
        '
        'lblSecurityGroupID
        '
        Me.lblSecurityGroupID.DisplayOnly = true
        Me.lblSecurityGroupID.EditingMode = false
        Me.lblSecurityGroupID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSecurityGroupID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSecurityGroupID.Location = New System.Drawing.Point(11, 138)
        Me.lblSecurityGroupID.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSecurityGroupID.Name = "lblSecurityGroupID"
        Me.lblSecurityGroupID.Size = New System.Drawing.Size(152, 23)
        Me.lblSecurityGroupID.TabIndex = 119
        Me.lblSecurityGroupID.Text = "Security Group"
        Me.lblSecurityGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSecurityGroupID.Translatable = true
        '
        'cacSecurityGroupIdNo
        '
        Me.cacSecurityGroupIdNo.BackColor = System.Drawing.Color.White
        Me.cacSecurityGroupIdNo.BegFindValue = Nothing
        Me.cacSecurityGroupIdNo.ChangingSearchValueOnly = false
        Me.cacSecurityGroupIdNo.CurrentSearchTerm = ""
        Me.cacSecurityGroupIdNo.DefaultValue = Nothing
        Me.cacSecurityGroupIdNo.DisplayMember = "Name"
        Me.cacSecurityGroupIdNo.EditingMode = false
        Me.cacSecurityGroupIdNo.EndFindValue = Nothing
        Me.cacSecurityGroupIdNo.FieldDescription = Nothing
        Me.cacSecurityGroupIdNo.FieldName = Nothing
        Me.cacSecurityGroupIdNo.FilterRule = Nothing
        Me.cacSecurityGroupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cacSecurityGroupIdNo.FindEnabled = false
        Me.cacSecurityGroupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacSecurityGroupIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacSecurityGroupIdNo.FormattingEnabled = true
        Me.cacSecurityGroupIdNo.HideWhenNotEditingOrAdding = false
        Me.cacSecurityGroupIdNo.IgnoreCase = false
        Me.cacSecurityGroupIdNo.IntegralHeight = false
        Me.cacSecurityGroupIdNo.LinkedLabel = Nothing
        Me.cacSecurityGroupIdNo.Location = New System.Drawing.Point(165, 138)
        Me.cacSecurityGroupIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacSecurityGroupIdNo.Name = "cacSecurityGroupIdNo"
        Me.cacSecurityGroupIdNo.OldValue = 0
        Me.cacSecurityGroupIdNo.OriginalDataSource = Nothing
        Me.cacSecurityGroupIdNo.OriginalList = Nothing
        Me.cacSecurityGroupIdNo.OverrideDropDownStyleList = false
        Me.cacSecurityGroupIdNo.PreviousSearchTerm = Nothing
        Me.cacSecurityGroupIdNo.PropertySelector = Nothing
        Me.cacSecurityGroupIdNo.ReadOnlyCombo = false
        Me.cacSecurityGroupIdNo.Size = New System.Drawing.Size(320, 24)
        Me.cacSecurityGroupIdNo.SuggestBoxHeight = 200
        Me.cacSecurityGroupIdNo.SuggestListOrderRule = Nothing
        Me.cacSecurityGroupIdNo.TabIndex = 6
        Me.cacSecurityGroupIdNo.TextToSearch = Nothing
        Me.cacSecurityGroupIdNo.Translatable = false
        Me.cacSecurityGroupIdNo.ValueIsMandatory = false
        Me.cacSecurityGroupIdNo.ValueIsNullable = false
        Me.cacSecurityGroupIdNo.ValueIsNumeric = false
        Me.cacSecurityGroupIdNo.ValueMember = "IdNo"
        '
        'UserEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(801, 511)
        Me.MinimumSize = New System.Drawing.Size(817, 262)
        Me.Name = "UserEntryTv"
        Me.Text = "User Maintenance Form"
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
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
        Friend WithEvents lblPassword As CLabel
        Friend WithEvents TxtPassword As CTextBox
        Friend WithEvents lblSecurityGroupID As CLabel
        Friend WithEvents cacSecurityGroupIdNo As CaComboBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents cacSecurityLevel As CaComboBox
        Friend WithEvents lblEmployeeIdNo As CLabel
        Friend WithEvents cacEmployeeIdNo As CaComboBox
    End Class
End NameSpace