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
            Me.bsPayrollEarnAccounts = New System.Windows.Forms.BindingSource(Me.components)
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
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            CType(Me.bsPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tlpPaymentType.SuspendLayout()
            Me.SuspendLayout()
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
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
            'bsPayrollEarnAccounts
            '
            Me.bsPayrollEarnAccounts.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayElementAccountModel)
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
            Me.lblWithBankCharges.DisplayOnly = True
            Me.lblWithBankCharges.EditingMode = False
            Me.lblWithBankCharges.Name = "lblWithBankCharges"
            Me.lblWithBankCharges.Translatable = True
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.BegFindValue = Nothing
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.tlpPaymentType.SetColumnSpan(Me.cboAccountIdNo, 3)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.Cursor = System.Windows.Forms.Cursors.PanWest
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.EndFindValue = Nothing
            Me.cboAccountIdNo.FieldDescription = Nothing
            Me.cboAccountIdNo.FieldName = Nothing
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAccountIdNo.FindEnabled = False
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IgnoreCase = False
            Me.cboAccountIdNo.LinkedLabel = Nothing
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.Translatable = False
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Translatable = True
            '
            'txtDepositTypeNameAra
            '
            Me.txtDepositTypeNameAra.BackColor = System.Drawing.Color.White
            Me.txtDepositTypeNameAra.BegFindValue = Nothing
            Me.txtDepositTypeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpPaymentType.SetColumnSpan(Me.txtDepositTypeNameAra, 3)
            Me.txtDepositTypeNameAra.ComputedValue = False
            Me.txtDepositTypeNameAra.CustomFormat = Nothing
            Me.txtDepositTypeNameAra.DataBoundControl = True
            resources.ApplyResources(Me.txtDepositTypeNameAra, "txtDepositTypeNameAra")
            Me.txtDepositTypeNameAra.EditingMode = False
            Me.txtDepositTypeNameAra.EndFindValue = Nothing
            Me.txtDepositTypeNameAra.EnglishControl = Me.txtDepositTypeName
            Me.txtDepositTypeNameAra.FieldDescription = Nothing
            Me.txtDepositTypeNameAra.FieldName = Nothing
            Me.txtDepositTypeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDepositTypeNameAra.FindEnabled = True
            Me.txtDepositTypeNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtDepositTypeNameAra.LinkedLabel = Nothing
            Me.txtDepositTypeNameAra.MaximumValue = Nothing
            Me.txtDepositTypeNameAra.MinimumValue = Nothing
            Me.txtDepositTypeNameAra.Name = "txtDepositTypeNameAra"
            Me.txtDepositTypeNameAra.OldValue = Nothing
            Me.txtDepositTypeNameAra.ReadOnly = True
            Me.txtDepositTypeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDepositTypeNameAra.Translatable = False
            '
            'txtDepositTypeName
            '
            Me.txtDepositTypeName.BackColor = System.Drawing.Color.White
            Me.txtDepositTypeName.BegFindValue = Nothing
            Me.txtDepositTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpPaymentType.SetColumnSpan(Me.txtDepositTypeName, 3)
            Me.txtDepositTypeName.ComputedValue = False
            Me.txtDepositTypeName.CustomFormat = Nothing
            Me.txtDepositTypeName.DataBoundControl = True
            resources.ApplyResources(Me.txtDepositTypeName, "txtDepositTypeName")
            Me.txtDepositTypeName.EditingMode = False
            Me.txtDepositTypeName.EndFindValue = Nothing
            Me.txtDepositTypeName.FieldDescription = Nothing
            Me.txtDepositTypeName.FieldName = Nothing
            Me.txtDepositTypeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDepositTypeName.FindEnabled = True
            Me.txtDepositTypeName.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtDepositTypeName, CType(resources.GetObject("txtDepositTypeName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.txtDepositTypeName.LinkedLabel = Nothing
            Me.txtDepositTypeName.MaximumValue = Nothing
            Me.txtDepositTypeName.MinimumValue = Nothing
            Me.txtDepositTypeName.Name = "txtDepositTypeName"
            Me.txtDepositTypeName.OldValue = Nothing
            Me.txtDepositTypeName.ReadOnly = True
            Me.txtDepositTypeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDepositTypeName.Translatable = False
            Me.txtDepositTypeName.ValueIsMandatory = True
            '
            'lblName
            '
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            Me.lblName.Name = "lblName"
            Me.lblName.Translatable = True
            '
            'txtDepositTypeCode
            '
            Me.txtDepositTypeCode.BackColor = System.Drawing.Color.White
            Me.txtDepositTypeCode.BegFindValue = Nothing
            Me.txtDepositTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDepositTypeCode.ComputedValue = False
            Me.txtDepositTypeCode.CustomFormat = Nothing
            Me.txtDepositTypeCode.DataBoundControl = True
            resources.ApplyResources(Me.txtDepositTypeCode, "txtDepositTypeCode")
            Me.txtDepositTypeCode.EditingMode = True
            Me.txtDepositTypeCode.EndFindValue = Nothing
            Me.txtDepositTypeCode.FieldDescription = Nothing
            Me.txtDepositTypeCode.FieldName = Nothing
            Me.txtDepositTypeCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDepositTypeCode.FindEnabled = True
            Me.txtDepositTypeCode.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtDepositTypeCode, CType(resources.GetObject("txtDepositTypeCode.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.MyErrorProvider.SetIconPadding(Me.txtDepositTypeCode, CType(resources.GetObject("txtDepositTypeCode.IconPadding"), Integer))
            Me.txtDepositTypeCode.LinkedLabel = Nothing
            Me.txtDepositTypeCode.MaximumValue = Nothing
            Me.txtDepositTypeCode.MinimumValue = Nothing
            Me.txtDepositTypeCode.Name = "txtDepositTypeCode"
            Me.txtDepositTypeCode.OldValue = Nothing
            Me.txtDepositTypeCode.ReadOnly = True
            Me.txtDepositTypeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDepositTypeCode.Translatable = False
            Me.txtDepositTypeCode.ValueIsMandatory = True
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
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'CLabel1
            '
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'lblNameAra
            '
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            Me.lblNameAra.Name = "lblNameAra"
            Me.lblNameAra.Translatable = True
            '
            'lblBankChargesAccountIdNo
            '
            resources.ApplyResources(Me.lblBankChargesAccountIdNo, "lblBankChargesAccountIdNo")
            Me.lblBankChargesAccountIdNo.DisplayOnly = True
            Me.lblBankChargesAccountIdNo.EditingMode = False
            Me.lblBankChargesAccountIdNo.Name = "lblBankChargesAccountIdNo"
            Me.lblBankChargesAccountIdNo.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpPaymentType.SetColumnSpan(Me.txtNotes, 3)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'cboBankChargesAccountIdNo
            '
            Me.cboBankChargesAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboBankChargesAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboBankChargesAccountIdNo.BegFindValue = Nothing
            Me.cboBankChargesAccountIdNo.ChangingSearchValueOnly = False
            Me.tlpPaymentType.SetColumnSpan(Me.cboBankChargesAccountIdNo, 3)
            Me.cboBankChargesAccountIdNo.CurrentSearchTerm = ""
            Me.cboBankChargesAccountIdNo.Cursor = System.Windows.Forms.Cursors.PanWest
            Me.cboBankChargesAccountIdNo.DefaultValue = Nothing
            Me.cboBankChargesAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboBankChargesAccountIdNo, "cboBankChargesAccountIdNo")
            Me.cboBankChargesAccountIdNo.EditingMode = False
            Me.cboBankChargesAccountIdNo.EndFindValue = Nothing
            Me.cboBankChargesAccountIdNo.FieldDescription = Nothing
            Me.cboBankChargesAccountIdNo.FieldName = Nothing
            Me.cboBankChargesAccountIdNo.FilterRule = Nothing
            Me.cboBankChargesAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboBankChargesAccountIdNo.FindEnabled = False
            Me.cboBankChargesAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboBankChargesAccountIdNo.FormattingEnabled = True
            Me.cboBankChargesAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboBankChargesAccountIdNo.IgnoreCase = False
            Me.cboBankChargesAccountIdNo.LinkedLabel = Nothing
            Me.cboBankChargesAccountIdNo.Name = "cboBankChargesAccountIdNo"
            Me.cboBankChargesAccountIdNo.OldValue = 0
            Me.cboBankChargesAccountIdNo.OriginalDataSource = Nothing
            Me.cboBankChargesAccountIdNo.OriginalList = Nothing
            Me.cboBankChargesAccountIdNo.OverrideDropDownStyleList = False
            Me.cboBankChargesAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboBankChargesAccountIdNo.PropertySelector = Nothing
            Me.cboBankChargesAccountIdNo.ReadOnlyCombo = False
            Me.cboBankChargesAccountIdNo.SuggestBoxHeight = 200
            Me.cboBankChargesAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboBankChargesAccountIdNo.TextToSearch = Nothing
            Me.cboBankChargesAccountIdNo.Translatable = False
            Me.cboBankChargesAccountIdNo.ValueIsMandatory = False
            Me.cboBankChargesAccountIdNo.ValueIsNullable = False
            Me.cboBankChargesAccountIdNo.ValueIsNumeric = False
            Me.cboBankChargesAccountIdNo.ValueMember = "IdNo"
            '
            'lblBankChargesVatAccountIdNo
            '
            resources.ApplyResources(Me.lblBankChargesVatAccountIdNo, "lblBankChargesVatAccountIdNo")
            Me.lblBankChargesVatAccountIdNo.DisplayOnly = True
            Me.lblBankChargesVatAccountIdNo.EditingMode = False
            Me.lblBankChargesVatAccountIdNo.Name = "lblBankChargesVatAccountIdNo"
            Me.lblBankChargesVatAccountIdNo.Translatable = True
            '
            'cboBankChargesVatAccountIdNo
            '
            Me.cboBankChargesVatAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboBankChargesVatAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboBankChargesVatAccountIdNo.BegFindValue = Nothing
            Me.cboBankChargesVatAccountIdNo.ChangingSearchValueOnly = False
            Me.tlpPaymentType.SetColumnSpan(Me.cboBankChargesVatAccountIdNo, 3)
            Me.cboBankChargesVatAccountIdNo.CurrentSearchTerm = ""
            Me.cboBankChargesVatAccountIdNo.DefaultValue = Nothing
            Me.cboBankChargesVatAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboBankChargesVatAccountIdNo, "cboBankChargesVatAccountIdNo")
            Me.cboBankChargesVatAccountIdNo.EditingMode = False
            Me.cboBankChargesVatAccountIdNo.EndFindValue = Nothing
            Me.cboBankChargesVatAccountIdNo.FieldDescription = Nothing
            Me.cboBankChargesVatAccountIdNo.FieldName = Nothing
            Me.cboBankChargesVatAccountIdNo.FilterRule = Nothing
            Me.cboBankChargesVatAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboBankChargesVatAccountIdNo.FindEnabled = False
            Me.cboBankChargesVatAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboBankChargesVatAccountIdNo.FormattingEnabled = True
            Me.cboBankChargesVatAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboBankChargesVatAccountIdNo.IgnoreCase = False
            Me.cboBankChargesVatAccountIdNo.LinkedLabel = Nothing
            Me.cboBankChargesVatAccountIdNo.Name = "cboBankChargesVatAccountIdNo"
            Me.cboBankChargesVatAccountIdNo.OldValue = 0
            Me.cboBankChargesVatAccountIdNo.OriginalDataSource = Nothing
            Me.cboBankChargesVatAccountIdNo.OriginalList = Nothing
            Me.cboBankChargesVatAccountIdNo.OverrideDropDownStyleList = False
            Me.cboBankChargesVatAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboBankChargesVatAccountIdNo.PropertySelector = Nothing
            Me.cboBankChargesVatAccountIdNo.ReadOnlyCombo = False
            Me.cboBankChargesVatAccountIdNo.SuggestBoxHeight = 200
            Me.cboBankChargesVatAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboBankChargesVatAccountIdNo.TextToSearch = Nothing
            Me.cboBankChargesVatAccountIdNo.Translatable = False
            Me.cboBankChargesVatAccountIdNo.ValueIsMandatory = False
            Me.cboBankChargesVatAccountIdNo.ValueIsNullable = False
            Me.cboBankChargesVatAccountIdNo.ValueIsNumeric = False
            Me.cboBankChargesVatAccountIdNo.ValueMember = "IdNo"
            '
            'txtRate
            '
            Me.txtRate.BackColor = System.Drawing.Color.White
            Me.txtRate.BegFindValue = Nothing
            Me.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRate.ComputedValue = False
            Me.txtRate.CustomFormat = Nothing
            Me.txtRate.DataBoundControl = True
            resources.ApplyResources(Me.txtRate, "txtRate")
            Me.txtRate.EditingMode = True
            Me.txtRate.EndFindValue = Nothing
            Me.txtRate.FieldDescription = Nothing
            Me.txtRate.FieldName = Nothing
            Me.txtRate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRate.FindEnabled = True
            Me.txtRate.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtRate, CType(resources.GetObject("txtRate.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.MyErrorProvider.SetIconPadding(Me.txtRate, CType(resources.GetObject("txtRate.IconPadding"), Integer))
            Me.txtRate.LinkedLabel = Nothing
            Me.txtRate.MaximumValue = Nothing
            Me.txtRate.MinimumValue = Nothing
            Me.txtRate.Name = "txtRate"
            Me.txtRate.OldValue = Nothing
            Me.txtRate.ReadOnly = True
            Me.txtRate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRate.Translatable = False
            Me.txtRate.ValueIsMandatory = True
            '
            'lblRate
            '
            resources.ApplyResources(Me.lblRate, "lblRate")
            Me.lblRate.DisplayOnly = True
            Me.lblRate.EditingMode = False
            Me.lblRate.Name = "lblRate"
            Me.lblRate.Translatable = True
            '
            'lblNotes
            '
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'lblPercentSign
            '
            Me.lblPercentSign.DisplayOnly = True
            Me.lblPercentSign.EditingMode = False
            resources.ApplyResources(Me.lblPercentSign, "lblPercentSign")
            Me.lblPercentSign.Name = "lblPercentSign"
            Me.lblPercentSign.Translatable = True
            '
            'lblAccountIdNo
            '
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Translatable = True
            '
            'chkWithBankCharges
            '
            Me.chkWithBankCharges.BackColor = System.Drawing.Color.White
            Me.chkWithBankCharges.BegFindValue = Nothing
            Me.chkWithBankCharges.DisplayOnly = False
            Me.chkWithBankCharges.EditingMode = True
            Me.chkWithBankCharges.EndFindValue = Nothing
            Me.chkWithBankCharges.FieldDescription = Nothing
            Me.chkWithBankCharges.FieldName = Nothing
            Me.chkWithBankCharges.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkWithBankCharges.FindEnabled = False
            resources.ApplyResources(Me.chkWithBankCharges, "chkWithBankCharges")
            Me.chkWithBankCharges.ForeColor = System.Drawing.Color.Black
            Me.chkWithBankCharges.IFindableControl_FindEnabled = False
            Me.chkWithBankCharges.IgnoreCase = False
            Me.chkWithBankCharges.LinkedLabel = Nothing
            Me.chkWithBankCharges.Name = "chkWithBankCharges"
            Me.chkWithBankCharges.NoLabel = True
            Me.chkWithBankCharges.OldValue = Nothing
            Me.chkWithBankCharges.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkWithBankCharges.Translatable = False
            Me.chkWithBankCharges.UseVisualStyleBackColor = False
            '
            'DepositTypeEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.Name = "DepositTypeEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            CType(Me.bsPayrollEarnAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tlpPaymentType.ResumeLayout(False)
            Me.tlpPaymentType.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsPayrollEarnAccounts As BindingSource
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