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
            Me.cacEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacSecurityLevel = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblPassword = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtPassword = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSecurityGroupID = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cacSecurityGroupIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblActive = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkActive = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
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
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
            Me.CFlowLayout1.Controls.Add(Me.lblActive)
            Me.CFlowLayout1.Controls.Add(Me.chkActive)
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout1.Location = New System.Drawing.Point(0, 0)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.CFlowLayout1.Size = New System.Drawing.Size(495, 458)
            Me.CFlowLayout1.TabIndex = 125
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(152, 23)
            Me.lblIdNo.TabIndex = 111
            Me.lblIdNo.Text = "ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.EditingMode = False
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(165, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(77, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblUserName
            '
            Me.lblUserName.DisplayOnly = True
            Me.lblUserName.EditingMode = False
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblUserName.Location = New System.Drawing.Point(11, 36)
            Me.lblUserName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(152, 23)
            Me.lblUserName.TabIndex = 116
            Me.lblUserName.Text = "Login User Name"
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblUserName.Translatable = True
            '
            'TxtUserName
            '
            Me.TxtUserName.BackColor = System.Drawing.Color.White
            Me.TxtUserName.BegFindValue = Nothing
            Me.TxtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtUserName.ComputedValue = False
            Me.TxtUserName.CustomFormat = Nothing
            Me.TxtUserName.DataBoundControl = True
            Me.TxtUserName.EditingMode = False
            Me.TxtUserName.EndFindValue = Nothing
            Me.TxtUserName.FieldDescription = Nothing
            Me.TxtUserName.FieldName = Nothing
            Me.TxtUserName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtUserName.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.TxtUserName, True)
            Me.TxtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtUserName.ForeColor = System.Drawing.Color.Black
            Me.TxtUserName.LinkedLabel = Me.lblUserName
            Me.TxtUserName.Location = New System.Drawing.Point(165, 36)
            Me.TxtUserName.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtUserName.MaximumValue = Nothing
            Me.TxtUserName.MinimumValue = Nothing
            Me.TxtUserName.Name = "TxtUserName"
            Me.TxtUserName.OldValue = Nothing
            Me.TxtUserName.OverrideMaxLength = 0
            Me.TxtUserName.ReadOnly = True
            Me.TxtUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtUserName.Size = New System.Drawing.Size(200, 23)
            Me.TxtUserName.TabIndex = 1
            Me.TxtUserName.Translatable = False
            Me.TxtUserName.ValueIsUnique = True
            '
            'lblEmployeeIdNo
            '
            Me.lblEmployeeIdNo.DisplayOnly = True
            Me.lblEmployeeIdNo.EditingMode = False
            Me.lblEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEmployeeIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblEmployeeIdNo.Location = New System.Drawing.Point(11, 61)
            Me.lblEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmployeeIdNo.Name = "lblEmployeeIdNo"
            Me.lblEmployeeIdNo.Size = New System.Drawing.Size(152, 23)
            Me.lblEmployeeIdNo.TabIndex = 130
            Me.lblEmployeeIdNo.Text = "Employee Name/Code"
            Me.lblEmployeeIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEmployeeIdNo.Translatable = True
            '
            'cacEmployeeIdNo
            '
            Me.cacEmployeeIdNo.BackColor = System.Drawing.Color.White
            Me.cacEmployeeIdNo.BegFindValue = Nothing
            Me.cacEmployeeIdNo.ChangingSearchValueOnly = False
            Me.cacEmployeeIdNo.CurrentSearchTerm = ""
            Me.cacEmployeeIdNo.DataValue = Nothing
            Me.cacEmployeeIdNo.DefaultValue = Nothing
            Me.cacEmployeeIdNo.DisplayMember = "Name"
            Me.cacEmployeeIdNo.DropDownHeight = 21
            Me.cacEmployeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cacEmployeeIdNo.Editable = True
            Me.cacEmployeeIdNo.EditingMode = False
            Me.cacEmployeeIdNo.EndFindValue = Nothing
            Me.cacEmployeeIdNo.FieldDescription = Nothing
            Me.cacEmployeeIdNo.FieldName = Nothing
            Me.cacEmployeeIdNo.FilterRule = Nothing
            Me.cacEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacEmployeeIdNo.FindEnabled = False
            Me.cacEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacEmployeeIdNo.FormattingEnabled = True
            Me.cacEmployeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cacEmployeeIdNo.IgnoreCase = False
            Me.cacEmployeeIdNo.IntegralHeight = False
            Me.cacEmployeeIdNo.LimitToList = False
            Me.cacEmployeeIdNo.LinkedLabel = Nothing
            Me.cacEmployeeIdNo.Location = New System.Drawing.Point(165, 61)
            Me.cacEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacEmployeeIdNo.MaxDropDownItems = 1
            Me.cacEmployeeIdNo.Name = "cacEmployeeIdNo"
            Me.cacEmployeeIdNo.OldValue = 0
            Me.cacEmployeeIdNo.OriginalDataSource = Nothing
            Me.cacEmployeeIdNo.OriginalList = Nothing
            Me.cacEmployeeIdNo.OverrideDropDownStyleList = False
            Me.cacEmployeeIdNo.PreviousSearchTerm = Nothing
            Me.cacEmployeeIdNo.PropertySelector = Nothing
            Me.cacEmployeeIdNo.Size = New System.Drawing.Size(320, 24)
            Me.cacEmployeeIdNo.SuggestBoxHeight = 200
            Me.cacEmployeeIdNo.SuggestListOrderRule = Nothing
            Me.cacEmployeeIdNo.TabIndex = 131
            Me.cacEmployeeIdNo.TextToSearch = Nothing
            Me.cacEmployeeIdNo.Translatable = False
            Me.cacEmployeeIdNo.ValueIsMandatory = False
            Me.cacEmployeeIdNo.ValueIsNullable = False
            Me.cacEmployeeIdNo.ValueIsNumeric = False
            Me.cacEmployeeIdNo.ValueMember = "IdNo"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(11, 87)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(152, 23)
            Me.CLabel1.TabIndex = 128
            Me.CLabel1.Text = "Security Level"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'cacSecurityLevel
            '
            Me.cacSecurityLevel.BackColor = System.Drawing.Color.White
            Me.cacSecurityLevel.BegFindValue = Nothing
            Me.cacSecurityLevel.ChangingSearchValueOnly = False
            Me.cacSecurityLevel.CurrentSearchTerm = ""
            Me.cacSecurityLevel.DataValue = Nothing
            Me.cacSecurityLevel.DefaultValue = Nothing
            Me.cacSecurityLevel.DisplayMember = "Name"
            Me.cacSecurityLevel.DropDownHeight = 21
            Me.cacSecurityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cacSecurityLevel.Editable = True
            Me.cacSecurityLevel.EditingMode = False
            Me.cacSecurityLevel.EndFindValue = Nothing
            Me.cacSecurityLevel.FieldDescription = Nothing
            Me.cacSecurityLevel.FieldName = Nothing
            Me.cacSecurityLevel.FilterRule = Nothing
            Me.cacSecurityLevel.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacSecurityLevel.FindEnabled = False
            Me.cacSecurityLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacSecurityLevel.ForeColor = System.Drawing.Color.Black
            Me.cacSecurityLevel.FormattingEnabled = True
            Me.cacSecurityLevel.HideWhenNotEditingOrAdding = False
            Me.cacSecurityLevel.IgnoreCase = False
            Me.cacSecurityLevel.IntegralHeight = False
            Me.cacSecurityLevel.LimitToList = False
            Me.cacSecurityLevel.LinkedLabel = Nothing
            Me.cacSecurityLevel.Location = New System.Drawing.Point(165, 87)
            Me.cacSecurityLevel.Margin = New System.Windows.Forms.Padding(1)
            Me.cacSecurityLevel.MaxDropDownItems = 1
            Me.cacSecurityLevel.Name = "cacSecurityLevel"
            Me.cacSecurityLevel.OldValue = 0
            Me.cacSecurityLevel.OriginalDataSource = Nothing
            Me.cacSecurityLevel.OriginalList = Nothing
            Me.cacSecurityLevel.OverrideDropDownStyleList = False
            Me.cacSecurityLevel.PreviousSearchTerm = Nothing
            Me.cacSecurityLevel.PropertySelector = Nothing
            Me.cacSecurityLevel.Size = New System.Drawing.Size(320, 24)
            Me.cacSecurityLevel.SuggestBoxHeight = 200
            Me.cacSecurityLevel.SuggestListOrderRule = Nothing
            Me.cacSecurityLevel.TabIndex = 4
            Me.cacSecurityLevel.TextToSearch = Nothing
            Me.cacSecurityLevel.Translatable = False
            Me.cacSecurityLevel.ValueIsMandatory = False
            Me.cacSecurityLevel.ValueIsNullable = False
            Me.cacSecurityLevel.ValueIsNumeric = False
            Me.cacSecurityLevel.ValueMember = "IdNo"
            '
            'lblPassword
            '
            Me.lblPassword.DisplayOnly = True
            Me.lblPassword.EditingMode = False
            Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPassword.Location = New System.Drawing.Point(11, 113)
            Me.lblPassword.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.Size = New System.Drawing.Size(152, 23)
            Me.lblPassword.TabIndex = 117
            Me.lblPassword.Text = "Password"
            Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPassword.Translatable = True
            '
            'TxtPassword
            '
            Me.TxtPassword.BackColor = System.Drawing.Color.White
            Me.TxtPassword.BegFindValue = Nothing
            Me.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtPassword.ComputedValue = False
            Me.TxtPassword.CustomFormat = Nothing
            Me.TxtPassword.DataBoundControl = True
            Me.TxtPassword.EditingMode = False
            Me.TxtPassword.EndFindValue = Nothing
            Me.TxtPassword.FieldDescription = Nothing
            Me.TxtPassword.FieldName = Nothing
            Me.TxtPassword.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtPassword.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.TxtPassword, True)
            Me.TxtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtPassword.ForeColor = System.Drawing.Color.Black
            Me.TxtPassword.LinkedLabel = Me.lblPassword
            Me.TxtPassword.Location = New System.Drawing.Point(165, 113)
            Me.TxtPassword.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtPassword.MaximumValue = Nothing
            Me.TxtPassword.MinimumValue = Nothing
            Me.TxtPassword.Name = "TxtPassword"
            Me.TxtPassword.OldValue = Nothing
            Me.TxtPassword.OverrideMaxLength = 0
            Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.TxtPassword.ReadOnly = True
            Me.TxtPassword.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtPassword.SecurityKey = ""
            Me.TxtPassword.Size = New System.Drawing.Size(320, 23)
            Me.TxtPassword.TabIndex = 5
            Me.TxtPassword.Translatable = False
            '
            'lblSecurityGroupID
            '
            Me.lblSecurityGroupID.DisplayOnly = True
            Me.lblSecurityGroupID.EditingMode = False
            Me.lblSecurityGroupID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSecurityGroupID.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSecurityGroupID.Location = New System.Drawing.Point(11, 138)
            Me.lblSecurityGroupID.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSecurityGroupID.Name = "lblSecurityGroupID"
            Me.lblSecurityGroupID.Size = New System.Drawing.Size(152, 23)
            Me.lblSecurityGroupID.TabIndex = 119
            Me.lblSecurityGroupID.Text = "Security Group"
            Me.lblSecurityGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSecurityGroupID.Translatable = True
            '
            'cacSecurityGroupIdNo
            '
            Me.cacSecurityGroupIdNo.BackColor = System.Drawing.Color.White
            Me.cacSecurityGroupIdNo.BegFindValue = Nothing
            Me.cacSecurityGroupIdNo.ChangingSearchValueOnly = False
            Me.cacSecurityGroupIdNo.CurrentSearchTerm = ""
            Me.cacSecurityGroupIdNo.DataValue = Nothing
            Me.cacSecurityGroupIdNo.DefaultValue = Nothing
            Me.cacSecurityGroupIdNo.DisplayMember = "Name"
            Me.cacSecurityGroupIdNo.DropDownHeight = 21
            Me.cacSecurityGroupIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cacSecurityGroupIdNo.Editable = True
            Me.cacSecurityGroupIdNo.EditingMode = False
            Me.cacSecurityGroupIdNo.EndFindValue = Nothing
            Me.cacSecurityGroupIdNo.FieldDescription = Nothing
            Me.cacSecurityGroupIdNo.FieldName = Nothing
            Me.cacSecurityGroupIdNo.FilterRule = Nothing
            Me.cacSecurityGroupIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacSecurityGroupIdNo.FindEnabled = False
            Me.cacSecurityGroupIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacSecurityGroupIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacSecurityGroupIdNo.FormattingEnabled = True
            Me.cacSecurityGroupIdNo.HideWhenNotEditingOrAdding = False
            Me.cacSecurityGroupIdNo.IgnoreCase = False
            Me.cacSecurityGroupIdNo.IntegralHeight = False
            Me.cacSecurityGroupIdNo.LimitToList = False
            Me.cacSecurityGroupIdNo.LinkedLabel = Nothing
            Me.cacSecurityGroupIdNo.Location = New System.Drawing.Point(165, 138)
            Me.cacSecurityGroupIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacSecurityGroupIdNo.MaxDropDownItems = 1
            Me.cacSecurityGroupIdNo.Name = "cacSecurityGroupIdNo"
            Me.cacSecurityGroupIdNo.OldValue = 0
            Me.cacSecurityGroupIdNo.OriginalDataSource = Nothing
            Me.cacSecurityGroupIdNo.OriginalList = Nothing
            Me.cacSecurityGroupIdNo.OverrideDropDownStyleList = False
            Me.cacSecurityGroupIdNo.PreviousSearchTerm = Nothing
            Me.cacSecurityGroupIdNo.PropertySelector = Nothing
            Me.cacSecurityGroupIdNo.Size = New System.Drawing.Size(320, 24)
            Me.cacSecurityGroupIdNo.SuggestBoxHeight = 200
            Me.cacSecurityGroupIdNo.SuggestListOrderRule = Nothing
            Me.cacSecurityGroupIdNo.TabIndex = 6
            Me.cacSecurityGroupIdNo.TextToSearch = Nothing
            Me.cacSecurityGroupIdNo.Translatable = False
            Me.cacSecurityGroupIdNo.ValueIsMandatory = False
            Me.cacSecurityGroupIdNo.ValueIsNullable = False
            Me.cacSecurityGroupIdNo.ValueIsNumeric = False
            Me.cacSecurityGroupIdNo.ValueMember = "IdNo"
            '
            'lblActive
            '
            Me.lblActive.DisplayOnly = True
            Me.lblActive.EditingMode = False
            Me.lblActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblActive.Location = New System.Drawing.Point(11, 164)
            Me.lblActive.Margin = New System.Windows.Forms.Padding(1)
            Me.lblActive.Name = "lblActive"
            Me.lblActive.Size = New System.Drawing.Size(152, 23)
            Me.lblActive.TabIndex = 132
            Me.lblActive.Text = "Active"
            Me.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblActive.Translatable = True
            '
            'chkActive
            '
            Me.chkActive.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkActive.AutoCheck = False
            Me.chkActive.BackColor = System.Drawing.Color.White
            Me.chkActive.BegFindValue = Nothing
            Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.DisplayOnly = False
            Me.chkActive.EditingMode = False
            Me.chkActive.EndFindValue = Nothing
            Me.chkActive.FieldDescription = Nothing
            Me.chkActive.FieldName = Nothing
            Me.chkActive.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkActive.FindEnabled = True
            Me.chkActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkActive.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.chkActive.ForeColor = System.Drawing.Color.Black
            Me.chkActive.IFindableControl_FindEnabled = False
            Me.chkActive.IgnoreCase = False
            Me.chkActive.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkActive.LinkedLabel = Nothing
            Me.chkActive.Location = New System.Drawing.Point(165, 164)
            Me.chkActive.Margin = New System.Windows.Forms.Padding(1)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.NoLabel = False
            Me.chkActive.OldValue = ""
            Me.chkActive.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkActive.Size = New System.Drawing.Size(13, 13)
            Me.chkActive.TabIndex = 133
            Me.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkActive.Translatable = False
            Me.chkActive.UseVisualStyleBackColor = False
            '
            'UserEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(801, 511)
            Me.MinimumSize = New System.Drawing.Size(817, 262)
            Me.Name = "UserEntryTv"
            Me.Text = "User Maintenance Form"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblUserName As CLabel
        Friend WithEvents TxtUserName As CTextBox
        Friend WithEvents lblPassword As CLabel
        Friend WithEvents TxtPassword As CTextBox
        Friend WithEvents lblSecurityGroupID As CLabel
        Friend WithEvents cacSecurityGroupIdNo As AtmComboBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents cacSecurityLevel As AtmComboBox
        Friend WithEvents lblEmployeeIdNo As CLabel
        Friend WithEvents cacEmployeeIdNo As AtmComboBox
        Friend WithEvents lblActive As CLabel
        Friend WithEvents chkActive As CCheckBox
    End Class
End NameSpace