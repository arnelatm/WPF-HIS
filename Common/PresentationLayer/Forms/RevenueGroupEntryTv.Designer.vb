Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.LocalizationUtilities

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RevenueGroupEntryTv
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
        Dim LocalizableContent1 As AATM.Libraries.LocalizationUtilities.LocalizableContent
        Me._MBRevenueGroupCannotBeParentToItself = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MBParentWithChildrenChangedDisallowed = New AATM.Libraries.LocalizationUtilities.LocalizableMessageBox()
        Me._MSGMandatoryFields = New AATM.Libraries.LocalizationUtilities.LocalizableMessage()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtRevenueGroupCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtRevenueGroupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtRevenueGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblRevenueGroupCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblRevenueGroupName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblRevenueGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cacParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblRevCostCenter = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CaComboBox1 = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSortKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        LocalizableContent1 = New AATM.Libraries.LocalizationUtilities.LocalizableContent()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TreeViewTableName.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.Location = New System.Drawing.Point(0, 53)
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 272)
        '
        'LocalizableContent1
        '
        LocalizableContent1.MessageBoxes.Add(Me._MBRevenueGroupCannotBeParentToItself)
        LocalizableContent1.MessageBoxes.Add(Me._MBParentWithChildrenChangedDisallowed)
        LocalizableContent1.Messages.Add(Me._MSGMandatoryFields)
        '
        '_MBRevenueGroupCannotBeParentToItself
        '
        Me._MBRevenueGroupCannotBeParentToItself.Caption = "Invalid Parent"
        Me._MBRevenueGroupCannotBeParentToItself.Text = "Sorry, a Profit Center cannot be a parent to itself."
        '
        '_MBParentWithChildrenChangedDisallowed
        '
        Me._MBParentWithChildrenChangedDisallowed.Text = """Sorry, this Profit Center is a parent, you cannot change it's parent while child"& _ 
    "ren exists."""
        '
        '_MSGMandatoryFields
        '
        Me._MSGMandatoryFields.Value = "Following fields are mandatory, "
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, true)
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.Location = New System.Drawing.Point(256, 11)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'txtRevenueGroupCode
        '
        Me.txtRevenueGroupCode.BackColor = System.Drawing.Color.White
        Me.txtRevenueGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRevenueGroupCode.ComputedValue = false
        Me.txtRevenueGroupCode.CustomFormat = Nothing
        Me.txtRevenueGroupCode.DataBoundControl = true
        Me.txtRevenueGroupCode.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtRevenueGroupCode, true)
        Me.txtRevenueGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtRevenueGroupCode.ForeColor = System.Drawing.Color.Black
        Me.txtRevenueGroupCode.LinkedLabel = Nothing
        Me.txtRevenueGroupCode.Location = New System.Drawing.Point(256, 36)
        Me.txtRevenueGroupCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRevenueGroupCode.MaximumValue = Nothing
        Me.txtRevenueGroupCode.MinimumValue = Nothing
        Me.txtRevenueGroupCode.Name = "txtRevenueGroupCode"
        Me.txtRevenueGroupCode.OldValue = Nothing
        Me.txtRevenueGroupCode.ReadOnly = true
        Me.txtRevenueGroupCode.Size = New System.Drawing.Size(62, 23)
        Me.txtRevenueGroupCode.TabIndex = 0
        Me.txtRevenueGroupCode.ValueIsMandatory = true
        '
        'txtRevenueGroupName
        '
        Me.txtRevenueGroupName.BackColor = System.Drawing.Color.White
        Me.txtRevenueGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRevenueGroupName.ComputedValue = false
        Me.txtRevenueGroupName.CustomFormat = Nothing
        Me.txtRevenueGroupName.DataBoundControl = true
        Me.txtRevenueGroupName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtRevenueGroupName, true)
        Me.txtRevenueGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtRevenueGroupName.ForeColor = System.Drawing.Color.Black
        Me.txtRevenueGroupName.LinkedLabel = Nothing
        Me.txtRevenueGroupName.Location = New System.Drawing.Point(256, 61)
        Me.txtRevenueGroupName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRevenueGroupName.MaximumValue = Nothing
        Me.txtRevenueGroupName.MinimumValue = Nothing
        Me.txtRevenueGroupName.Name = "txtRevenueGroupName"
        Me.txtRevenueGroupName.OldValue = Nothing
        Me.txtRevenueGroupName.ReadOnly = true
        Me.txtRevenueGroupName.Size = New System.Drawing.Size(418, 23)
        Me.txtRevenueGroupName.TabIndex = 1
        Me.txtRevenueGroupName.ValueIsMandatory = true
        '
        'txtRevenueGroupNameAra
        '
        Me.txtRevenueGroupNameAra.BackColor = System.Drawing.Color.White
        Me.txtRevenueGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRevenueGroupNameAra.ComputedValue = false
        Me.txtRevenueGroupNameAra.CustomFormat = Nothing
        Me.txtRevenueGroupNameAra.DataBoundControl = true
        Me.txtRevenueGroupNameAra.EditingMode = false
        Me.txtRevenueGroupNameAra.EnglishControl = Me.txtRevenueGroupName
        Me.floDataDisplay.SetFlowBreak(Me.txtRevenueGroupNameAra, true)
        Me.txtRevenueGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtRevenueGroupNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtRevenueGroupNameAra.LinkedLabel = Nothing
        Me.txtRevenueGroupNameAra.Location = New System.Drawing.Point(256, 86)
        Me.txtRevenueGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtRevenueGroupNameAra.MaximumValue = Nothing
        Me.txtRevenueGroupNameAra.MinimumValue = Nothing
        Me.txtRevenueGroupNameAra.Name = "txtRevenueGroupNameAra"
        Me.txtRevenueGroupNameAra.OldValue = Nothing
        Me.txtRevenueGroupNameAra.ReadOnly = true
        Me.txtRevenueGroupNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtRevenueGroupNameAra.Size = New System.Drawing.Size(418, 23)
        Me.txtRevenueGroupNameAra.TabIndex = 2
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtNotes, true)
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(256, 193)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.Size = New System.Drawing.Size(418, 60)
        Me.txtNotes.TabIndex = 3
        Me.txtNotes.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblRevenueGroupCode)
        Me.floDataDisplay.Controls.Add(Me.txtRevenueGroupCode)
        Me.floDataDisplay.Controls.Add(Me.lblRevenueGroupName)
        Me.floDataDisplay.Controls.Add(Me.txtRevenueGroupName)
        Me.floDataDisplay.Controls.Add(Me.lblRevenueGroupNameAra)
        Me.floDataDisplay.Controls.Add(Me.txtRevenueGroupNameAra)
        Me.floDataDisplay.Controls.Add(Me.lblParentIdNo)
        Me.floDataDisplay.Controls.Add(Me.cacParentIdNo)
        Me.floDataDisplay.Controls.Add(Me.lblRevCostCenter)
        Me.floDataDisplay.Controls.Add(Me.CaComboBox1)
        Me.floDataDisplay.Controls.Add(Me.CLabel1)
        Me.floDataDisplay.Controls.Add(Me.txtLevelNumber)
        Me.floDataDisplay.Controls.Add(Me.lblNotes)
        Me.floDataDisplay.Controls.Add(Me.txtNotes)
        Me.floDataDisplay.Controls.Add(Me.txtSortKey)
        Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
        Me.floDataDisplay.Location = New System.Drawing.Point(300, 53)
        Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
        Me.floDataDisplay.Name = "floDataDisplay"
        Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.floDataDisplay.Size = New System.Drawing.Size(692, 272)
        Me.floDataDisplay.TabIndex = 147
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(243, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "Revenue Group ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRevenueGroupCode
        '
        Me.lblRevenueGroupCode.DisplayOnly = true
        Me.lblRevenueGroupCode.EditingMode = false
        Me.lblRevenueGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblRevenueGroupCode.Location = New System.Drawing.Point(11, 36)
        Me.lblRevenueGroupCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRevenueGroupCode.Name = "lblRevenueGroupCode"
        Me.lblRevenueGroupCode.Size = New System.Drawing.Size(243, 23)
        Me.lblRevenueGroupCode.TabIndex = 156
        Me.lblRevenueGroupCode.Text = "Revenue Group Code"
        Me.lblRevenueGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRevenueGroupName
        '
        Me.lblRevenueGroupName.DisplayOnly = true
        Me.lblRevenueGroupName.EditingMode = false
        Me.lblRevenueGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblRevenueGroupName.Location = New System.Drawing.Point(11, 61)
        Me.lblRevenueGroupName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRevenueGroupName.Name = "lblRevenueGroupName"
        Me.lblRevenueGroupName.Size = New System.Drawing.Size(243, 23)
        Me.lblRevenueGroupName.TabIndex = 157
        Me.lblRevenueGroupName.Text = "Revenue Group Name"
        Me.lblRevenueGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRevenueGroupNameAra
        '
        Me.lblRevenueGroupNameAra.DisplayOnly = true
        Me.lblRevenueGroupNameAra.EditingMode = false
        Me.lblRevenueGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblRevenueGroupNameAra.Location = New System.Drawing.Point(11, 86)
        Me.lblRevenueGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRevenueGroupNameAra.Name = "lblRevenueGroupNameAra"
        Me.lblRevenueGroupNameAra.Size = New System.Drawing.Size(243, 23)
        Me.lblRevenueGroupNameAra.TabIndex = 158
        Me.lblRevenueGroupNameAra.Text = "RevenueGroup Name (Arabic)"
        Me.lblRevenueGroupNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblParentIdNo
        '
        Me.lblParentIdNo.DisplayOnly = true
        Me.lblParentIdNo.EditingMode = false
        Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblParentIdNo.Location = New System.Drawing.Point(11, 111)
        Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblParentIdNo.Name = "lblParentIdNo"
        Me.lblParentIdNo.Size = New System.Drawing.Size(243, 23)
        Me.lblParentIdNo.TabIndex = 161
        Me.lblParentIdNo.Text = "Parent Rev. Group"
        Me.lblParentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cacParentIdNo
        '
        Me.cacParentIdNo.BackColor = System.Drawing.Color.White
        Me.cacParentIdNo.ChangingSearchValueOnly = false
        Me.cacParentIdNo.CurrentSearchTerm = ""
        Me.cacParentIdNo.DefaultValue = Nothing
        Me.cacParentIdNo.DisplayMember = "Name"
        Me.cacParentIdNo.DropDownHeight = 1
        Me.cacParentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cacParentIdNo.EditingMode = false
        Me.cacParentIdNo.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.cacParentIdNo, true)
        Me.cacParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cacParentIdNo.FormattingEnabled = true
        Me.cacParentIdNo.HideWhenNotEditingOrAdding = false
        Me.cacParentIdNo.IntegralHeight = false
        Me.cacParentIdNo.LinkedLabel = Nothing
        Me.cacParentIdNo.Location = New System.Drawing.Point(256, 111)
        Me.cacParentIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cacParentIdNo.Name = "cacParentIdNo"
        Me.cacParentIdNo.OldValue = 0
        Me.cacParentIdNo.OriginalDataSource = Nothing
        Me.cacParentIdNo.OriginalList = Nothing
        Me.cacParentIdNo.OverrideDropDownStyleList = false
        Me.cacParentIdNo.PreviousSearchTerm = Nothing
        Me.cacParentIdNo.PreviousSelectedIndex = -1
        Me.cacParentIdNo.PropertySelector = Nothing
        Me.cacParentIdNo.ReadOnlyCombo = false
        Me.cacParentIdNo.SearchAnywhere = false
        Me.cacParentIdNo.Size = New System.Drawing.Size(418, 24)
        Me.cacParentIdNo.SuggestBoxHeight = 200
        Me.cacParentIdNo.SuggestListOrderRule = Nothing
        Me.cacParentIdNo.TabIndex = 3
        Me.cacParentIdNo.TextToSearch = Nothing
        Me.cacParentIdNo.ValueIsMandatory = false
        Me.cacParentIdNo.ValueIsNullable = false
        Me.cacParentIdNo.ValueIsNumeric = false
        Me.cacParentIdNo.ValueMember = "IdNo"
        '
        'lblRevCostCenter
        '
        Me.lblRevCostCenter.DisplayOnly = true
        Me.lblRevCostCenter.EditingMode = false
        Me.lblRevCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblRevCostCenter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRevCostCenter.Location = New System.Drawing.Point(11, 137)
        Me.lblRevCostCenter.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRevCostCenter.Name = "lblRevCostCenter"
        Me.lblRevCostCenter.Size = New System.Drawing.Size(243, 26)
        Me.lblRevCostCenter.TabIndex = 160
        Me.lblRevCostCenter.Text = "Level"
        Me.lblRevCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CaComboBox1
        '
        Me.CaComboBox1.BackColor = System.Drawing.Color.White
        Me.CaComboBox1.ChangingSearchValueOnly = false
        Me.CaComboBox1.CurrentSearchTerm = ""
        Me.CaComboBox1.DefaultValue = Nothing
        Me.CaComboBox1.DisplayMember = "Name"
        Me.CaComboBox1.DropDownHeight = 1
        Me.CaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CaComboBox1.EditingMode = false
        Me.CaComboBox1.FilterRule = Nothing
        Me.floDataDisplay.SetFlowBreak(Me.CaComboBox1, true)
        Me.CaComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CaComboBox1.ForeColor = System.Drawing.Color.Black
        Me.CaComboBox1.FormattingEnabled = true
        Me.CaComboBox1.HideWhenNotEditingOrAdding = false
        Me.CaComboBox1.IntegralHeight = false
        Me.CaComboBox1.LinkedLabel = Nothing
        Me.CaComboBox1.Location = New System.Drawing.Point(256, 137)
        Me.CaComboBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CaComboBox1.Name = "CaComboBox1"
        Me.CaComboBox1.OldValue = 0
        Me.CaComboBox1.OriginalDataSource = Nothing
        Me.CaComboBox1.OriginalList = Nothing
        Me.CaComboBox1.OverrideDropDownStyleList = false
        Me.CaComboBox1.PreviousSearchTerm = Nothing
        Me.CaComboBox1.PreviousSelectedIndex = -1
        Me.CaComboBox1.PropertySelector = Nothing
        Me.CaComboBox1.ReadOnlyCombo = false
        Me.CaComboBox1.SearchAnywhere = false
        Me.CaComboBox1.Size = New System.Drawing.Size(418, 24)
        Me.CaComboBox1.SuggestBoxHeight = 200
        Me.CaComboBox1.SuggestListOrderRule = Nothing
        Me.CaComboBox1.TabIndex = 165
        Me.CaComboBox1.TextToSearch = Nothing
        Me.CaComboBox1.ValueIsMandatory = false
        Me.CaComboBox1.ValueIsNullable = false
        Me.CaComboBox1.ValueIsNumeric = false
        Me.CaComboBox1.ValueMember = "IdNo"
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel1.Location = New System.Drawing.Point(11, 165)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(243, 26)
        Me.CLabel1.TabIndex = 166
        Me.CLabel1.Text = "Level"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLevelNumber
        '
        Me.txtLevelNumber.BackColor = System.Drawing.Color.White
        Me.txtLevelNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLevelNumber.ComputedValue = false
        Me.txtLevelNumber.CustomFormat = Nothing
        Me.txtLevelNumber.DataBoundControl = true
        Me.txtLevelNumber.DisplayOnly = true
        Me.txtLevelNumber.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.txtLevelNumber, true)
        Me.txtLevelNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtLevelNumber.ForeColor = System.Drawing.Color.Black
        Me.txtLevelNumber.IgnoreNullCheck = true
        Me.txtLevelNumber.LinkedLabel = Me.lblRevCostCenter
        Me.txtLevelNumber.Location = New System.Drawing.Point(256, 165)
        Me.txtLevelNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtLevelNumber.MaximumValue = Nothing
        Me.txtLevelNumber.MinimumValue = Nothing
        Me.txtLevelNumber.Name = "txtLevelNumber"
        Me.txtLevelNumber.OldValue = Nothing
        Me.txtLevelNumber.ReadOnly = true
        Me.txtLevelNumber.Size = New System.Drawing.Size(74, 23)
        Me.txtLevelNumber.TabIndex = 163
        Me.txtLevelNumber.ValueIsMandatory = true
        Me.txtLevelNumber.ValueIsNumeric = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.Location = New System.Drawing.Point(11, 193)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(243, 30)
        Me.lblNotes.TabIndex = 159
        Me.lblNotes.Text = "Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSortKey
        '
        Me.txtSortKey.BackColor = System.Drawing.Color.White
        Me.txtSortKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSortKey.ComputedValue = false
        Me.txtSortKey.CustomFormat = Nothing
        Me.txtSortKey.DataBoundControl = true
        Me.txtSortKey.EditingMode = false
        Me.txtSortKey.Enabled = false
        Me.txtSortKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSortKey.ForeColor = System.Drawing.Color.Black
        Me.txtSortKey.LinkedLabel = Nothing
        Me.txtSortKey.Location = New System.Drawing.Point(13, 258)
        Me.txtSortKey.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSortKey.MaximumValue = Nothing
        Me.txtSortKey.MinimumValue = Nothing
        Me.txtSortKey.Name = "txtSortKey"
        Me.txtSortKey.OldValue = Nothing
        Me.txtSortKey.ReadOnly = true
        Me.txtSortKey.Size = New System.Drawing.Size(72, 23)
        Me.txtSortKey.TabIndex = 164
        Me.txtSortKey.ValueIsMandatory = true
        Me.txtSortKey.Visible = false
        '
        'RevenueGroupEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(995, 325)
        Me.Controls.Add(Me.floDataDisplay)
        Me.MinimumSize = New System.Drawing.Size(1011, 364)
        Me.Name = "RevenueGroupEntryTv"
        Me.Text = "RevenueGroups Maintenance Form"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtRevenueGroupCode As CTextBox
        Friend WithEvents txtRevenueGroupName As CTextBox
        Friend WithEvents txtRevenueGroupNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblRevenueGroupCode As CLabel
        Friend WithEvents lblRevenueGroupName As CLabel
        Friend WithEvents lblRevenueGroupNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents lblRevCostCenter As CLabel
        Friend WithEvents txtLevelNumber As CTextBox
        Friend WithEvents _MBRevenueGroupCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents txtSortKey As CTextBox
        Friend WithEvents cacParentIdNo As CaComboBox
        Friend WithEvents CaComboBox1 As CaComboBox
        Friend WithEvents CLabel1 As CLabel
    End Class
End Namespace