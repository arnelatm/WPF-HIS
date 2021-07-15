Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UserEntryTv
        Inherits CFormEntryTvNew

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
            Me.TxtUserName.ReadOnly = True
            Me.TxtUserName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtUserName.Size = New System.Drawing.Size(200, 23)
            Me.TxtUserName.TabIndex = 1
            Me.TxtUserName.Translatable = False
            Me.TxtUserName.ValueIsUnique = True
            '
            'lblFullName
            '
            Me.lblFullName.DisplayOnly = True
            Me.lblFullName.EditingMode = False
            Me.lblFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblFullName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblFullName.Location = New System.Drawing.Point(11, 61)
            Me.lblFullName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblFullName.Name = "lblFullName"
            Me.lblFullName.Size = New System.Drawing.Size(152, 23)
            Me.lblFullName.TabIndex = 118
            Me.lblFullName.Text = "Full Name"
            Me.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblFullName.Translatable = True
            '
            'TxtFullName
            '
            Me.TxtFullName.BackColor = System.Drawing.Color.White
            Me.TxtFullName.BegFindValue = Nothing
            Me.TxtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtFullName.ComputedValue = False
            Me.TxtFullName.CustomFormat = Nothing
            Me.TxtFullName.DataBoundControl = True
            Me.TxtFullName.EditingMode = False
            Me.TxtFullName.EndFindValue = Nothing
            Me.TxtFullName.FieldDescription = Nothing
            Me.TxtFullName.FieldName = Nothing
            Me.TxtFullName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtFullName.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.TxtFullName, True)
            Me.TxtFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtFullName.ForeColor = System.Drawing.Color.Black
            Me.TxtFullName.LinkedLabel = Me.lblFullName
            Me.TxtFullName.Location = New System.Drawing.Point(165, 61)
            Me.TxtFullName.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtFullName.MaximumValue = Nothing
            Me.TxtFullName.MinimumValue = Nothing
            Me.TxtFullName.Name = "TxtFullName"
            Me.TxtFullName.OldValue = Nothing
            Me.TxtFullName.ReadOnly = True
            Me.TxtFullName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtFullName.Size = New System.Drawing.Size(320, 23)
            Me.TxtFullName.TabIndex = 2
            Me.TxtFullName.Translatable = False
            Me.TxtFullName.ValueIsUnique = True
            '
            'lblFullNameAra
            '
            Me.lblFullNameAra.DisplayOnly = True
            Me.lblFullNameAra.EditingMode = False
            Me.lblFullNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblFullNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblFullNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblFullNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblFullNameAra.Name = "lblFullNameAra"
            Me.lblFullNameAra.Size = New System.Drawing.Size(152, 23)
            Me.lblFullNameAra.TabIndex = 127
            Me.lblFullNameAra.Text = "Full Name Arabic"
            Me.lblFullNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblFullNameAra.Translatable = True
            '
            'txtFullNameAra
            '
            Me.txtFullNameAra.BackColor = System.Drawing.Color.White
            Me.txtFullNameAra.BegFindValue = Nothing
            Me.txtFullNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFullNameAra.ComputedValue = False
            Me.txtFullNameAra.CustomFormat = Nothing
            Me.txtFullNameAra.DataBoundControl = True
            Me.txtFullNameAra.EditingMode = False
            Me.txtFullNameAra.EndFindValue = Nothing
            Me.txtFullNameAra.EnglishControl = Me.TxtFullName
            Me.txtFullNameAra.FieldDescription = Nothing
            Me.txtFullNameAra.FieldName = Nothing
            Me.txtFullNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtFullNameAra.FindEnabled = True
            Me.txtFullNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtFullNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtFullNameAra.LinkedLabel = Me.lblFullNameAra
            Me.txtFullNameAra.Location = New System.Drawing.Point(165, 86)
            Me.txtFullNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtFullNameAra.MaximumValue = Nothing
            Me.txtFullNameAra.MinimumValue = Nothing
            Me.txtFullNameAra.Name = "txtFullNameAra"
            Me.txtFullNameAra.OldValue = Nothing
            Me.txtFullNameAra.ReadOnly = True
            Me.txtFullNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtFullNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtFullNameAra.Size = New System.Drawing.Size(320, 23)
            Me.txtFullNameAra.TabIndex = 3
            Me.txtFullNameAra.Translatable = False
            Me.txtFullNameAra.ValueIsMandatory = True
            Me.txtFullNameAra.ValueIsUnique = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(11, 111)
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
            Me.cacSecurityLevel.DefaultValue = Nothing
            Me.cacSecurityLevel.DisplayMember = "Name"
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
            Me.cacSecurityLevel.LinkedLabel = Nothing
            Me.cacSecurityLevel.Location = New System.Drawing.Point(165, 111)
            Me.cacSecurityLevel.Margin = New System.Windows.Forms.Padding(1)
            Me.cacSecurityLevel.Name = "cacSecurityLevel"
            Me.cacSecurityLevel.OldValue = 0
            Me.cacSecurityLevel.OriginalDataSource = Nothing
            Me.cacSecurityLevel.OriginalList = Nothing
            Me.cacSecurityLevel.OverrideDropDownStyleList = False
            Me.cacSecurityLevel.PreviousSearchTerm = Nothing
            Me.cacSecurityLevel.PropertySelector = Nothing
            Me.cacSecurityLevel.ReadOnlyCombo = False
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
            Me.lblPassword.Location = New System.Drawing.Point(11, 137)
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
            Me.TxtPassword.Location = New System.Drawing.Point(165, 137)
            Me.TxtPassword.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtPassword.MaximumValue = Nothing
            Me.TxtPassword.MinimumValue = Nothing
            Me.TxtPassword.Name = "TxtPassword"
            Me.TxtPassword.OldValue = Nothing
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
            Me.lblSecurityGroupID.Location = New System.Drawing.Point(11, 162)
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
            Me.cacSecurityGroupIdNo.DefaultValue = Nothing
            Me.cacSecurityGroupIdNo.DisplayMember = "Name"
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
            Me.cacSecurityGroupIdNo.LinkedLabel = Nothing
            Me.cacSecurityGroupIdNo.Location = New System.Drawing.Point(165, 162)
            Me.cacSecurityGroupIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacSecurityGroupIdNo.Name = "cacSecurityGroupIdNo"
            Me.cacSecurityGroupIdNo.OldValue = 0
            Me.cacSecurityGroupIdNo.OriginalDataSource = Nothing
            Me.cacSecurityGroupIdNo.OriginalList = Nothing
            Me.cacSecurityGroupIdNo.OverrideDropDownStyleList = False
            Me.cacSecurityGroupIdNo.PreviousSearchTerm = Nothing
            Me.cacSecurityGroupIdNo.PropertySelector = Nothing
            Me.cacSecurityGroupIdNo.ReadOnlyCombo = False
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