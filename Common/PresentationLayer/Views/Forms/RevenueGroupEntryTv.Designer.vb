Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RevenueGroupEntryTv
        Inherits CFormEntryTv

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RevenueGroupEntryTv))
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
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
            Me.SplitContainer1.Size = New System.Drawing.Size(1056, 272)
            Me.SplitContainer1.SplitterDistance = 351
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Size = New System.Drawing.Size(351, 272)
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
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
            Me._MBParentWithChildrenChangedDisallowed.Text = """Sorry, this Profit Center is a parent, you cannot change it's parent while child" &
    "ren exists."""
            '
            '_MSGMandatoryFields
            '
            Me._MSGMandatoryFields.Value = "Following fields are mandatory, "
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(256, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtRevenueGroupCode
            '
            Me.txtRevenueGroupCode.BackColor = System.Drawing.Color.White
            Me.txtRevenueGroupCode.BegFindValue = Nothing
            Me.txtRevenueGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRevenueGroupCode.ComputedValue = False
            Me.txtRevenueGroupCode.CustomFormat = Nothing
            Me.txtRevenueGroupCode.DataBoundControl = True
            Me.txtRevenueGroupCode.EditingMode = False
            Me.txtRevenueGroupCode.EndFindValue = Nothing
            Me.txtRevenueGroupCode.FieldDescription = Nothing
            Me.txtRevenueGroupCode.FieldName = Nothing
            Me.txtRevenueGroupCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRevenueGroupCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtRevenueGroupCode, True)
            Me.txtRevenueGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRevenueGroupCode.ForeColor = System.Drawing.Color.Black
            Me.txtRevenueGroupCode.LinkedLabel = Nothing
            Me.txtRevenueGroupCode.Location = New System.Drawing.Point(256, 36)
            Me.txtRevenueGroupCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRevenueGroupCode.MaximumValue = Nothing
            Me.txtRevenueGroupCode.MinimumValue = Nothing
            Me.txtRevenueGroupCode.Name = "txtRevenueGroupCode"
            Me.txtRevenueGroupCode.OldValue = Nothing
            Me.txtRevenueGroupCode.ReadOnly = True
            Me.txtRevenueGroupCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRevenueGroupCode.Size = New System.Drawing.Size(62, 23)
            Me.txtRevenueGroupCode.TabIndex = 0
            Me.txtRevenueGroupCode.Translatable = False
            Me.txtRevenueGroupCode.ValueIsMandatory = True
            Me.txtRevenueGroupCode.ValueIsUnique = True
            '
            'txtRevenueGroupName
            '
            Me.txtRevenueGroupName.BackColor = System.Drawing.Color.White
            Me.txtRevenueGroupName.BegFindValue = Nothing
            Me.txtRevenueGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRevenueGroupName.ComputedValue = False
            Me.txtRevenueGroupName.CustomFormat = Nothing
            Me.txtRevenueGroupName.DataBoundControl = True
            Me.txtRevenueGroupName.EditingMode = False
            Me.txtRevenueGroupName.EndFindValue = Nothing
            Me.txtRevenueGroupName.FieldDescription = Nothing
            Me.txtRevenueGroupName.FieldName = Nothing
            Me.txtRevenueGroupName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRevenueGroupName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtRevenueGroupName, True)
            Me.txtRevenueGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRevenueGroupName.ForeColor = System.Drawing.Color.Black
            Me.txtRevenueGroupName.LinkedLabel = Nothing
            Me.txtRevenueGroupName.Location = New System.Drawing.Point(256, 61)
            Me.txtRevenueGroupName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRevenueGroupName.MaximumValue = Nothing
            Me.txtRevenueGroupName.MinimumValue = Nothing
            Me.txtRevenueGroupName.Name = "txtRevenueGroupName"
            Me.txtRevenueGroupName.OldValue = Nothing
            Me.txtRevenueGroupName.ReadOnly = True
            Me.txtRevenueGroupName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRevenueGroupName.Size = New System.Drawing.Size(418, 23)
            Me.txtRevenueGroupName.TabIndex = 1
            Me.txtRevenueGroupName.Translatable = False
            Me.txtRevenueGroupName.ValueIsMandatory = True
            Me.txtRevenueGroupName.ValueIsUnique = True
            '
            'txtRevenueGroupNameAra
            '
            Me.txtRevenueGroupNameAra.BackColor = System.Drawing.Color.White
            Me.txtRevenueGroupNameAra.BegFindValue = Nothing
            Me.txtRevenueGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRevenueGroupNameAra.ComputedValue = False
            Me.txtRevenueGroupNameAra.CustomFormat = Nothing
            Me.txtRevenueGroupNameAra.DataBoundControl = True
            Me.txtRevenueGroupNameAra.EditingMode = False
            Me.txtRevenueGroupNameAra.EndFindValue = Nothing
            Me.txtRevenueGroupNameAra.EnglishControl = Me.txtRevenueGroupName
            Me.txtRevenueGroupNameAra.FieldDescription = Nothing
            Me.txtRevenueGroupNameAra.FieldName = Nothing
            Me.txtRevenueGroupNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRevenueGroupNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtRevenueGroupNameAra, True)
            Me.txtRevenueGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRevenueGroupNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtRevenueGroupNameAra.LinkedLabel = Nothing
            Me.txtRevenueGroupNameAra.Location = New System.Drawing.Point(256, 86)
            Me.txtRevenueGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRevenueGroupNameAra.MaximumValue = Nothing
            Me.txtRevenueGroupNameAra.MinimumValue = Nothing
            Me.txtRevenueGroupNameAra.Name = "txtRevenueGroupNameAra"
            Me.txtRevenueGroupNameAra.OldValue = Nothing
            Me.txtRevenueGroupNameAra.ReadOnly = True
            Me.txtRevenueGroupNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtRevenueGroupNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRevenueGroupNameAra.Size = New System.Drawing.Size(418, 23)
            Me.txtRevenueGroupNameAra.TabIndex = 2
            Me.txtRevenueGroupNameAra.Translatable = False
            Me.txtRevenueGroupNameAra.ValueIsUnique = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtNotes, True)
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(256, 193)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(418, 60)
            Me.txtNotes.TabIndex = 3
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
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
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floDataDisplay.Location = New System.Drawing.Point(0, 0)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(695, 272)
            Me.floDataDisplay.TabIndex = 147
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(243, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "Revenue Group ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'lblRevenueGroupCode
            '
            Me.lblRevenueGroupCode.DisplayOnly = True
            Me.lblRevenueGroupCode.EditingMode = False
            Me.lblRevenueGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRevenueGroupCode.Location = New System.Drawing.Point(11, 36)
            Me.lblRevenueGroupCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevenueGroupCode.Name = "lblRevenueGroupCode"
            Me.lblRevenueGroupCode.Size = New System.Drawing.Size(243, 23)
            Me.lblRevenueGroupCode.TabIndex = 156
            Me.lblRevenueGroupCode.Text = "Revenue Group Code"
            Me.lblRevenueGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblRevenueGroupCode.Translatable = True
            '
            'lblRevenueGroupName
            '
            Me.lblRevenueGroupName.DisplayOnly = True
            Me.lblRevenueGroupName.EditingMode = False
            Me.lblRevenueGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRevenueGroupName.Location = New System.Drawing.Point(11, 61)
            Me.lblRevenueGroupName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevenueGroupName.Name = "lblRevenueGroupName"
            Me.lblRevenueGroupName.Size = New System.Drawing.Size(243, 23)
            Me.lblRevenueGroupName.TabIndex = 157
            Me.lblRevenueGroupName.Text = "Revenue Group Name"
            Me.lblRevenueGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblRevenueGroupName.Translatable = True
            '
            'lblRevenueGroupNameAra
            '
            Me.lblRevenueGroupNameAra.DisplayOnly = True
            Me.lblRevenueGroupNameAra.EditingMode = False
            Me.lblRevenueGroupNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRevenueGroupNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblRevenueGroupNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevenueGroupNameAra.Name = "lblRevenueGroupNameAra"
            Me.lblRevenueGroupNameAra.Size = New System.Drawing.Size(243, 23)
            Me.lblRevenueGroupNameAra.TabIndex = 158
            Me.lblRevenueGroupNameAra.Text = "RevenueGroup Name (Arabic)"
            Me.lblRevenueGroupNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblRevenueGroupNameAra.Translatable = True
            '
            'lblParentIdNo
            '
            Me.lblParentIdNo.DisplayOnly = True
            Me.lblParentIdNo.EditingMode = False
            Me.lblParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblParentIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblParentIdNo.Location = New System.Drawing.Point(11, 111)
            Me.lblParentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblParentIdNo.Name = "lblParentIdNo"
            Me.lblParentIdNo.Size = New System.Drawing.Size(243, 23)
            Me.lblParentIdNo.TabIndex = 161
            Me.lblParentIdNo.Text = "Parent Rev. Group"
            Me.lblParentIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblParentIdNo.Translatable = True
            '
            'cacParentIdNo
            '
            Me.cacParentIdNo.BackColor = System.Drawing.Color.White
            Me.cacParentIdNo.BegFindValue = Nothing
            Me.cacParentIdNo.ChangingSearchValueOnly = False
            Me.cacParentIdNo.CurrentSearchTerm = ""
            Me.cacParentIdNo.DefaultValue = Nothing
            Me.cacParentIdNo.DisplayMember = "Name"
            Me.cacParentIdNo.EditingMode = False
            Me.cacParentIdNo.EndFindValue = Nothing
            Me.cacParentIdNo.FieldDescription = Nothing
            Me.cacParentIdNo.FieldName = Nothing
            Me.cacParentIdNo.FilterRule = Nothing
            Me.cacParentIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cacParentIdNo.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.cacParentIdNo, True)
            Me.cacParentIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cacParentIdNo.ForeColor = System.Drawing.Color.Black
            Me.cacParentIdNo.FormattingEnabled = True
            Me.cacParentIdNo.HideWhenNotEditingOrAdding = False
            Me.cacParentIdNo.IgnoreCase = False
            Me.cacParentIdNo.IntegralHeight = False
            Me.cacParentIdNo.LinkedLabel = Nothing
            Me.cacParentIdNo.Location = New System.Drawing.Point(256, 111)
            Me.cacParentIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cacParentIdNo.Name = "cacParentIdNo"
            Me.cacParentIdNo.OldValue = 0
            Me.cacParentIdNo.OriginalDataSource = Nothing
            Me.cacParentIdNo.OriginalList = Nothing
            Me.cacParentIdNo.OverrideDropDownStyleList = False
            Me.cacParentIdNo.PreviousSearchTerm = Nothing
            Me.cacParentIdNo.PropertySelector = Nothing
            Me.cacParentIdNo.ReadOnlyCombo = False
            Me.cacParentIdNo.Size = New System.Drawing.Size(418, 24)
            Me.cacParentIdNo.SuggestBoxHeight = 200
            Me.cacParentIdNo.SuggestListOrderRule = Nothing
            Me.cacParentIdNo.TabIndex = 3
            Me.cacParentIdNo.TextToSearch = Nothing
            Me.cacParentIdNo.Translatable = False
            Me.cacParentIdNo.ValueIsMandatory = False
            Me.cacParentIdNo.ValueIsNullable = False
            Me.cacParentIdNo.ValueIsNumeric = False
            Me.cacParentIdNo.ValueMember = "IdNo"
            '
            'lblRevCostCenter
            '
            Me.lblRevCostCenter.DisplayOnly = True
            Me.lblRevCostCenter.EditingMode = False
            Me.lblRevCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblRevCostCenter.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblRevCostCenter.Location = New System.Drawing.Point(11, 137)
            Me.lblRevCostCenter.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRevCostCenter.Name = "lblRevCostCenter"
            Me.lblRevCostCenter.Size = New System.Drawing.Size(243, 26)
            Me.lblRevCostCenter.TabIndex = 160
            Me.lblRevCostCenter.Text = "Level"
            Me.lblRevCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblRevCostCenter.Translatable = True
            '
            'CaComboBox1
            '
            Me.CaComboBox1.BackColor = System.Drawing.Color.White
            Me.CaComboBox1.BegFindValue = Nothing
            Me.CaComboBox1.ChangingSearchValueOnly = False
            Me.CaComboBox1.CurrentSearchTerm = ""
            Me.CaComboBox1.DefaultValue = Nothing
            Me.CaComboBox1.DisplayMember = "Name"
            Me.CaComboBox1.EditingMode = False
            Me.CaComboBox1.EndFindValue = Nothing
            Me.CaComboBox1.FieldDescription = Nothing
            Me.CaComboBox1.FieldName = Nothing
            Me.CaComboBox1.FilterRule = Nothing
            Me.CaComboBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CaComboBox1.FindEnabled = False
            Me.floDataDisplay.SetFlowBreak(Me.CaComboBox1, True)
            Me.CaComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CaComboBox1.ForeColor = System.Drawing.Color.Black
            Me.CaComboBox1.FormattingEnabled = True
            Me.CaComboBox1.HideWhenNotEditingOrAdding = False
            Me.CaComboBox1.IgnoreCase = False
            Me.CaComboBox1.IntegralHeight = False
            Me.CaComboBox1.LinkedLabel = Nothing
            Me.CaComboBox1.Location = New System.Drawing.Point(256, 137)
            Me.CaComboBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CaComboBox1.Name = "CaComboBox1"
            Me.CaComboBox1.OldValue = 0
            Me.CaComboBox1.OriginalDataSource = Nothing
            Me.CaComboBox1.OriginalList = Nothing
            Me.CaComboBox1.OverrideDropDownStyleList = False
            Me.CaComboBox1.PreviousSearchTerm = Nothing
            Me.CaComboBox1.PropertySelector = Nothing
            Me.CaComboBox1.ReadOnlyCombo = False
            Me.CaComboBox1.Size = New System.Drawing.Size(418, 24)
            Me.CaComboBox1.SuggestBoxHeight = 200
            Me.CaComboBox1.SuggestListOrderRule = Nothing
            Me.CaComboBox1.TabIndex = 165
            Me.CaComboBox1.TextToSearch = Nothing
            Me.CaComboBox1.Translatable = False
            Me.CaComboBox1.ValueIsMandatory = False
            Me.CaComboBox1.ValueIsNullable = False
            Me.CaComboBox1.ValueIsNumeric = False
            Me.CaComboBox1.ValueMember = "IdNo"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(11, 165)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(243, 26)
            Me.CLabel1.TabIndex = 166
            Me.CLabel1.Text = "Level"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'txtLevelNumber
            '
            Me.txtLevelNumber.BackColor = System.Drawing.Color.White
            Me.txtLevelNumber.BegFindValue = Nothing
            Me.txtLevelNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLevelNumber.ComputedValue = False
            Me.txtLevelNumber.CustomFormat = Nothing
            Me.txtLevelNumber.DataBoundControl = True
            Me.txtLevelNumber.DisplayOnly = True
            Me.txtLevelNumber.EditingMode = True
            Me.txtLevelNumber.EndFindValue = Nothing
            Me.txtLevelNumber.FieldDescription = Nothing
            Me.txtLevelNumber.FieldName = Nothing
            Me.txtLevelNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLevelNumber.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtLevelNumber, True)
            Me.txtLevelNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtLevelNumber.ForeColor = System.Drawing.Color.Black
            Me.txtLevelNumber.IgnoreNullCheck = True
            Me.txtLevelNumber.LinkedLabel = Me.lblRevCostCenter
            Me.txtLevelNumber.Location = New System.Drawing.Point(256, 165)
            Me.txtLevelNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtLevelNumber.MaximumValue = Nothing
            Me.txtLevelNumber.MinimumValue = Nothing
            Me.txtLevelNumber.Name = "txtLevelNumber"
            Me.txtLevelNumber.OldValue = Nothing
            Me.txtLevelNumber.ReadOnly = True
            Me.txtLevelNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLevelNumber.Size = New System.Drawing.Size(74, 23)
            Me.txtLevelNumber.TabIndex = 163
            Me.txtLevelNumber.Translatable = False
            Me.txtLevelNumber.ValueIsMandatory = True
            Me.txtLevelNumber.ValueIsNumeric = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.Location = New System.Drawing.Point(11, 193)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(243, 30)
            Me.lblNotes.TabIndex = 159
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNotes.Translatable = True
            '
            'txtSortKey
            '
            Me.txtSortKey.BackColor = System.Drawing.Color.White
            Me.txtSortKey.BegFindValue = Nothing
            Me.txtSortKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSortKey.ComputedValue = False
            Me.txtSortKey.CustomFormat = Nothing
            Me.txtSortKey.DataBoundControl = True
            Me.txtSortKey.EditingMode = False
            Me.txtSortKey.Enabled = False
            Me.txtSortKey.EndFindValue = Nothing
            Me.txtSortKey.FieldDescription = Nothing
            Me.txtSortKey.FieldName = Nothing
            Me.txtSortKey.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSortKey.FindEnabled = True
            Me.txtSortKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSortKey.ForeColor = System.Drawing.Color.Black
            Me.txtSortKey.LinkedLabel = Nothing
            Me.txtSortKey.Location = New System.Drawing.Point(13, 258)
            Me.txtSortKey.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.txtSortKey.MaximumValue = Nothing
            Me.txtSortKey.MinimumValue = Nothing
            Me.txtSortKey.Name = "txtSortKey"
            Me.txtSortKey.OldValue = Nothing
            Me.txtSortKey.ReadOnly = True
            Me.txtSortKey.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSortKey.Size = New System.Drawing.Size(72, 23)
            Me.txtSortKey.TabIndex = 164
            Me.txtSortKey.Translatable = False
            Me.txtSortKey.ValueIsMandatory = True
            Me.txtSortKey.Visible = False
            '
            'RevenueGroupEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1056, 325)
            Me.MinimumSize = New System.Drawing.Size(1011, 364)
            Me.Name = "RevenueGroupEntryTv"
            Me.Text = "Revenue Groups Maintenance Form"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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