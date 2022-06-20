Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DepositTypeEntryTv
        Inherits CFormEntryTv

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DepositTypeEntryTv))
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.tlpPaymentType = New System.Windows.Forms.TableLayoutPanel()
        Me.lblWithBankCharges = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDepositTypeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtDepositTypeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDepositTypeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblBankChargesAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.cboBankChargesAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblBankChargesVatAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboBankChargesVatAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.txtRate = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblRate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPercentSign = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkWithBankCharges = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.tlpPaymentType.SuspendLayout
        Me.SuspendLayout
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.FormTreeView, "FormTreeView")
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
        Me.floDataDisplay.Controls.Add(Me.tlpPaymentType)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'tlpPaymentType
        '
        resources.ApplyResources(Me.tlpPaymentType, "tlpPaymentType")
        Me.tlpPaymentType.Controls.Add(Me.lblWithBankCharges, 0, 4)
        Me.tlpPaymentType.Controls.Add(Me.cboAccountIdNo, 1, 3)
        Me.tlpPaymentType.Controls.Add(Me.lblCode, 2, 0)
        Me.tlpPaymentType.Controls.Add(Me.txtDepositTypeNameAra, 1, 2)
        Me.tlpPaymentType.Controls.Add(Me.lblName, 0, 1)
        Me.tlpPaymentType.Controls.Add(Me.txtDepositTypeCode, 3, 0)
        Me.tlpPaymentType.Controls.Add(Me.TxtIdNo, 1, 0)
        Me.tlpPaymentType.Controls.Add(Me.CLabel1, 0, 0)
        Me.tlpPaymentType.Controls.Add(Me.txtDepositTypeName, 1, 1)
        Me.tlpPaymentType.Controls.Add(Me.lblNameAra, 0, 2)
        Me.tlpPaymentType.Controls.Add(Me.lblBankChargesAccountIdNo, 0, 6)
        Me.tlpPaymentType.Controls.Add(Me.txtNotes, 1, 8)
        Me.tlpPaymentType.Controls.Add(Me.cboBankChargesAccountIdNo, 1, 6)
        Me.tlpPaymentType.Controls.Add(Me.lblBankChargesVatAccountIdNo, 0, 7)
        Me.tlpPaymentType.Controls.Add(Me.cboBankChargesVatAccountIdNo, 1, 7)
        Me.tlpPaymentType.Controls.Add(Me.txtRate, 1, 5)
        Me.tlpPaymentType.Controls.Add(Me.lblRate, 0, 5)
        Me.tlpPaymentType.Controls.Add(Me.lblNotes, 0, 8)
        Me.tlpPaymentType.Controls.Add(Me.lblPercentSign, 2, 5)
        Me.tlpPaymentType.Controls.Add(Me.lblAccountIdNo, 0, 3)
        Me.tlpPaymentType.Controls.Add(Me.chkWithBankCharges, 1, 4)
        Me.tlpPaymentType.Name = "tlpPaymentType"
        '
        'lblWithBankCharges
        '
        resources.ApplyResources(Me.lblWithBankCharges, "lblWithBankCharges")
        Me.lblWithBankCharges.DisplayOnly = true
        Me.lblWithBankCharges.EditingMode = false
        Me.lblWithBankCharges.Name = "lblWithBankCharges"
        Me.lblWithBankCharges.Translatable = true
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.BegFindValue = Nothing
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.tlpPaymentType.SetColumnSpan(Me.cboAccountIdNo, 3)
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.Cursor = System.Windows.Forms.Cursors.PanWest
        Me.cboAccountIdNo.DefaultValue = Nothing
        Me.cboAccountIdNo.DisplayMember = "Name"
        Me.cboAccountIdNo.EditingMode = false
        Me.cboAccountIdNo.EndFindValue = Nothing
        Me.cboAccountIdNo.FieldDescription = Nothing
        Me.cboAccountIdNo.FieldName = Nothing
        Me.cboAccountIdNo.FilterRule = Nothing
        Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboAccountIdNo.FindEnabled = false
        resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.FormattingEnabled = true
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.IgnoreCase = false
        Me.cboAccountIdNo.LinkedLabel = Nothing
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.OverrideDropDownStyleList = false
        Me.cboAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboAccountIdNo.PropertySelector = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.SuggestBoxHeight = 200
        Me.cboAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboAccountIdNo.TextToSearch = Nothing
        Me.cboAccountIdNo.Translatable = false
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        Me.cboAccountIdNo.ValueMember = "IdNo"
        '
        'lblCode
        '
        Me.lblCode.DisplayOnly = true
        Me.lblCode.EditingMode = false
        resources.ApplyResources(Me.lblCode, "lblCode")
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Translatable = true
        '
        'txtDepositTypeNameAra
        '
        Me.txtDepositTypeNameAra.BackColor = System.Drawing.Color.White
        Me.txtDepositTypeNameAra.BegFindValue = Nothing
        Me.txtDepositTypeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPaymentType.SetColumnSpan(Me.txtDepositTypeNameAra, 3)
        Me.txtDepositTypeNameAra.ComputedValue = false
        Me.txtDepositTypeNameAra.CustomFormat = Nothing
        Me.txtDepositTypeNameAra.DataBoundControl = true
        resources.ApplyResources(Me.txtDepositTypeNameAra, "txtDepositTypeNameAra")
        Me.txtDepositTypeNameAra.EditingMode = false
        Me.txtDepositTypeNameAra.EndFindValue = Nothing
        Me.txtDepositTypeNameAra.EnglishControl = Me.txtDepositTypeName
        Me.txtDepositTypeNameAra.FieldDescription = Nothing
        Me.txtDepositTypeNameAra.FieldName = Nothing
        Me.txtDepositTypeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDepositTypeNameAra.FindEnabled = true
        Me.txtDepositTypeNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtDepositTypeNameAra.LinkedLabel = Nothing
        Me.txtDepositTypeNameAra.MaximumValue = Nothing
        Me.txtDepositTypeNameAra.MinimumValue = Nothing
        Me.txtDepositTypeNameAra.Name = "txtDepositTypeNameAra"
        Me.txtDepositTypeNameAra.OldValue = Nothing
        Me.txtDepositTypeNameAra.ReadOnly = true
        Me.txtDepositTypeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDepositTypeNameAra.Translatable = false
        '
        'txtDepositTypeName
        '
        Me.txtDepositTypeName.BackColor = System.Drawing.Color.White
        Me.txtDepositTypeName.BegFindValue = Nothing
        Me.txtDepositTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPaymentType.SetColumnSpan(Me.txtDepositTypeName, 3)
        Me.txtDepositTypeName.ComputedValue = false
        Me.txtDepositTypeName.CustomFormat = Nothing
        Me.txtDepositTypeName.DataBoundControl = true
        resources.ApplyResources(Me.txtDepositTypeName, "txtDepositTypeName")
        Me.txtDepositTypeName.EditingMode = false
        Me.txtDepositTypeName.EndFindValue = Nothing
        Me.txtDepositTypeName.FieldDescription = Nothing
        Me.txtDepositTypeName.FieldName = Nothing
        Me.txtDepositTypeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDepositTypeName.FindEnabled = true
        Me.txtDepositTypeName.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtDepositTypeName, CType(resources.GetObject("txtDepositTypeName.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.txtDepositTypeName.LinkedLabel = Nothing
        Me.txtDepositTypeName.MaximumValue = Nothing
        Me.txtDepositTypeName.MinimumValue = Nothing
        Me.txtDepositTypeName.Name = "txtDepositTypeName"
        Me.txtDepositTypeName.OldValue = Nothing
        Me.txtDepositTypeName.ReadOnly = true
        Me.txtDepositTypeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDepositTypeName.Translatable = false
        Me.txtDepositTypeName.ValueIsMandatory = true
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.DisplayOnly = true
        Me.lblName.EditingMode = false
        Me.lblName.Name = "lblName"
        Me.lblName.Translatable = true
        '
        'txtDepositTypeCode
        '
        Me.txtDepositTypeCode.BackColor = System.Drawing.Color.White
        Me.txtDepositTypeCode.BegFindValue = Nothing
        Me.txtDepositTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepositTypeCode.ComputedValue = false
        Me.txtDepositTypeCode.CustomFormat = Nothing
        Me.txtDepositTypeCode.DataBoundControl = true
        resources.ApplyResources(Me.txtDepositTypeCode, "txtDepositTypeCode")
        Me.txtDepositTypeCode.EditingMode = true
        Me.txtDepositTypeCode.EndFindValue = Nothing
        Me.txtDepositTypeCode.FieldDescription = Nothing
        Me.txtDepositTypeCode.FieldName = Nothing
        Me.txtDepositTypeCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDepositTypeCode.FindEnabled = true
        Me.txtDepositTypeCode.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtDepositTypeCode, CType(resources.GetObject("txtDepositTypeCode.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.txtDepositTypeCode, CType(resources.GetObject("txtDepositTypeCode.IconPadding"),Integer))
        Me.txtDepositTypeCode.LinkedLabel = Nothing
        Me.txtDepositTypeCode.MaximumValue = Nothing
        Me.txtDepositTypeCode.MinimumValue = Nothing
        Me.txtDepositTypeCode.Name = "txtDepositTypeCode"
        Me.txtDepositTypeCode.OldValue = Nothing
        Me.txtDepositTypeCode.ReadOnly = true
        Me.txtDepositTypeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDepositTypeCode.Translatable = false
        Me.txtDepositTypeCode.ValueIsMandatory = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'CLabel1
        '
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Translatable = true
        '
        'lblNameAra
        '
        resources.ApplyResources(Me.lblNameAra, "lblNameAra")
        Me.lblNameAra.DisplayOnly = true
        Me.lblNameAra.EditingMode = false
        Me.lblNameAra.Name = "lblNameAra"
        Me.lblNameAra.Translatable = true
        '
        'lblBankChargesAccountIdNo
        '
        resources.ApplyResources(Me.lblBankChargesAccountIdNo, "lblBankChargesAccountIdNo")
        Me.lblBankChargesAccountIdNo.DisplayOnly = true
        Me.lblBankChargesAccountIdNo.EditingMode = false
        Me.lblBankChargesAccountIdNo.Name = "lblBankChargesAccountIdNo"
        Me.lblBankChargesAccountIdNo.Translatable = true
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpPaymentType.SetColumnSpan(Me.txtNotes, 3)
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Translatable = false
        Me.txtNotes.ValueIsMandatory = true
        '
        'cboBankChargesAccountIdNo
        '
        Me.cboBankChargesAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBankChargesAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboBankChargesAccountIdNo.BegFindValue = Nothing
        Me.cboBankChargesAccountIdNo.ChangingSearchValueOnly = false
        Me.tlpPaymentType.SetColumnSpan(Me.cboBankChargesAccountIdNo, 3)
        Me.cboBankChargesAccountIdNo.CurrentSearchTerm = ""
        Me.cboBankChargesAccountIdNo.Cursor = System.Windows.Forms.Cursors.PanWest
        Me.cboBankChargesAccountIdNo.DefaultValue = Nothing
        Me.cboBankChargesAccountIdNo.DisplayMember = "Name"
        resources.ApplyResources(Me.cboBankChargesAccountIdNo, "cboBankChargesAccountIdNo")
        Me.cboBankChargesAccountIdNo.EditingMode = false
        Me.cboBankChargesAccountIdNo.EndFindValue = Nothing
        Me.cboBankChargesAccountIdNo.FieldDescription = Nothing
        Me.cboBankChargesAccountIdNo.FieldName = Nothing
        Me.cboBankChargesAccountIdNo.FilterRule = Nothing
        Me.cboBankChargesAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboBankChargesAccountIdNo.FindEnabled = false
        Me.cboBankChargesAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboBankChargesAccountIdNo.FormattingEnabled = true
        Me.cboBankChargesAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboBankChargesAccountIdNo.IgnoreCase = false
        Me.cboBankChargesAccountIdNo.LinkedLabel = Nothing
        Me.cboBankChargesAccountIdNo.Name = "cboBankChargesAccountIdNo"
        Me.cboBankChargesAccountIdNo.OldValue = 0
        Me.cboBankChargesAccountIdNo.OriginalDataSource = Nothing
        Me.cboBankChargesAccountIdNo.OriginalList = Nothing
        Me.cboBankChargesAccountIdNo.OverrideDropDownStyleList = false
        Me.cboBankChargesAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboBankChargesAccountIdNo.PropertySelector = Nothing
        Me.cboBankChargesAccountIdNo.ReadOnlyCombo = false
        Me.cboBankChargesAccountIdNo.SuggestBoxHeight = 200
        Me.cboBankChargesAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboBankChargesAccountIdNo.TextToSearch = Nothing
        Me.cboBankChargesAccountIdNo.Translatable = false
        Me.cboBankChargesAccountIdNo.ValueIsMandatory = false
        Me.cboBankChargesAccountIdNo.ValueIsNullable = false
        Me.cboBankChargesAccountIdNo.ValueIsNumeric = false
        Me.cboBankChargesAccountIdNo.ValueMember = "IdNo"
        '
        'lblBankChargesVatAccountIdNo
        '
        resources.ApplyResources(Me.lblBankChargesVatAccountIdNo, "lblBankChargesVatAccountIdNo")
        Me.lblBankChargesVatAccountIdNo.DisplayOnly = true
        Me.lblBankChargesVatAccountIdNo.EditingMode = false
        Me.lblBankChargesVatAccountIdNo.Name = "lblBankChargesVatAccountIdNo"
        Me.lblBankChargesVatAccountIdNo.Translatable = true
        '
        'cboBankChargesVatAccountIdNo
        '
        Me.cboBankChargesVatAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBankChargesVatAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboBankChargesVatAccountIdNo.BegFindValue = Nothing
        Me.cboBankChargesVatAccountIdNo.ChangingSearchValueOnly = false
        Me.tlpPaymentType.SetColumnSpan(Me.cboBankChargesVatAccountIdNo, 3)
        Me.cboBankChargesVatAccountIdNo.CurrentSearchTerm = ""
        Me.cboBankChargesVatAccountIdNo.DefaultValue = Nothing
        Me.cboBankChargesVatAccountIdNo.DisplayMember = "Name"
        resources.ApplyResources(Me.cboBankChargesVatAccountIdNo, "cboBankChargesVatAccountIdNo")
        Me.cboBankChargesVatAccountIdNo.EditingMode = false
        Me.cboBankChargesVatAccountIdNo.EndFindValue = Nothing
        Me.cboBankChargesVatAccountIdNo.FieldDescription = Nothing
        Me.cboBankChargesVatAccountIdNo.FieldName = Nothing
        Me.cboBankChargesVatAccountIdNo.FilterRule = Nothing
        Me.cboBankChargesVatAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboBankChargesVatAccountIdNo.FindEnabled = false
        Me.cboBankChargesVatAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboBankChargesVatAccountIdNo.FormattingEnabled = true
        Me.cboBankChargesVatAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboBankChargesVatAccountIdNo.IgnoreCase = false
        Me.cboBankChargesVatAccountIdNo.LinkedLabel = Nothing
        Me.cboBankChargesVatAccountIdNo.Name = "cboBankChargesVatAccountIdNo"
        Me.cboBankChargesVatAccountIdNo.OldValue = 0
        Me.cboBankChargesVatAccountIdNo.OriginalDataSource = Nothing
        Me.cboBankChargesVatAccountIdNo.OriginalList = Nothing
        Me.cboBankChargesVatAccountIdNo.OverrideDropDownStyleList = false
        Me.cboBankChargesVatAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboBankChargesVatAccountIdNo.PropertySelector = Nothing
        Me.cboBankChargesVatAccountIdNo.ReadOnlyCombo = false
        Me.cboBankChargesVatAccountIdNo.SuggestBoxHeight = 200
        Me.cboBankChargesVatAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboBankChargesVatAccountIdNo.TextToSearch = Nothing
        Me.cboBankChargesVatAccountIdNo.Translatable = false
        Me.cboBankChargesVatAccountIdNo.ValueIsMandatory = false
        Me.cboBankChargesVatAccountIdNo.ValueIsNullable = false
        Me.cboBankChargesVatAccountIdNo.ValueIsNumeric = false
        Me.cboBankChargesVatAccountIdNo.ValueMember = "IdNo"
        '
        'txtRate
        '
        Me.txtRate.BackColor = System.Drawing.Color.White
        Me.txtRate.BegFindValue = Nothing
        Me.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRate.ComputedValue = false
        Me.txtRate.CustomFormat = Nothing
        Me.txtRate.DataBoundControl = true
        resources.ApplyResources(Me.txtRate, "txtRate")
        Me.txtRate.EditingMode = true
        Me.txtRate.EndFindValue = Nothing
        Me.txtRate.FieldDescription = Nothing
        Me.txtRate.FieldName = Nothing
        Me.txtRate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtRate.FindEnabled = true
        Me.txtRate.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtRate, CType(resources.GetObject("txtRate.IconAlignment"),System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.txtRate, CType(resources.GetObject("txtRate.IconPadding"),Integer))
        Me.txtRate.LinkedLabel = Nothing
        Me.txtRate.MaximumValue = Nothing
        Me.txtRate.MinimumValue = Nothing
        Me.txtRate.Name = "txtRate"
        Me.txtRate.OldValue = Nothing
        Me.txtRate.ReadOnly = true
        Me.txtRate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtRate.Translatable = false
        Me.txtRate.ValueIsMandatory = true
        '
        'lblRate
        '
        resources.ApplyResources(Me.lblRate, "lblRate")
        Me.lblRate.DisplayOnly = true
        Me.lblRate.EditingMode = false
        Me.lblRate.Name = "lblRate"
        Me.lblRate.Translatable = true
        '
        'lblNotes
        '
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Translatable = true
        '
        'lblPercentSign
        '
        Me.lblPercentSign.DisplayOnly = true
        Me.lblPercentSign.EditingMode = false
        resources.ApplyResources(Me.lblPercentSign, "lblPercentSign")
        Me.lblPercentSign.Name = "lblPercentSign"
        Me.lblPercentSign.Translatable = true
        '
        'lblAccountIdNo
        '
        resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
        Me.lblAccountIdNo.DisplayOnly = true
        Me.lblAccountIdNo.EditingMode = false
        Me.lblAccountIdNo.Name = "lblAccountIdNo"
        Me.lblAccountIdNo.Translatable = true
        '
        'chkWithBankCharges
        '
        Me.chkWithBankCharges.BackColor = System.Drawing.Color.White
        Me.chkWithBankCharges.BegFindValue = Nothing
        Me.chkWithBankCharges.DisplayOnly = false
        Me.chkWithBankCharges.EditingMode = true
        Me.chkWithBankCharges.EndFindValue = Nothing
        Me.chkWithBankCharges.FieldDescription = Nothing
        Me.chkWithBankCharges.FieldName = Nothing
        Me.chkWithBankCharges.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkWithBankCharges.FindEnabled = false
        resources.ApplyResources(Me.chkWithBankCharges, "chkWithBankCharges")
        Me.chkWithBankCharges.ForeColor = System.Drawing.Color.Black
        Me.chkWithBankCharges.IFindableControl_FindEnabled = false
        Me.chkWithBankCharges.IgnoreCase = false
        Me.chkWithBankCharges.LinkedLabel = Nothing
        Me.chkWithBankCharges.Name = "chkWithBankCharges"
        Me.chkWithBankCharges.NoLabel = true
        Me.chkWithBankCharges.OldValue = Nothing
        Me.chkWithBankCharges.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkWithBankCharges.Translatable = false
        Me.chkWithBankCharges.UseVisualStyleBackColor = false
        '
        'DepositTypeEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.Name = "DepositTypeEntryTv"
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.tlpPaymentType.ResumeLayout(false)
        Me.tlpPaymentType.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents tlpPaymentType As TableLayoutPanel
        Friend WithEvents lblWithBankCharges As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblCode As CLabel
        Friend WithEvents txtDepositTypeNameAra As CTextBoxArabic
        Friend WithEvents txtDepositTypeName As CTextBox
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtDepositTypeCode As CTextBox
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblBankChargesAccountIdNo As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents cboBankChargesAccountIdNo As CaComboBox
        Friend WithEvents lblBankChargesVatAccountIdNo As CLabel
        Friend WithEvents cboBankChargesVatAccountIdNo As CaComboBox
        Friend WithEvents txtRate As CTextBox
        Friend WithEvents lblRate As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblPercentSign As CLabel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents chkWithBankCharges As CCheckBox
    End Class
End Namespace