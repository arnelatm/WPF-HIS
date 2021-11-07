Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CashReceiptJournalEntry
        Inherits CFormEntry

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CashReceiptJournalEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator2 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.floFullEntryArea = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.floPurchaseJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.floHeader1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayorType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayorIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.txtPayorName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDiscountAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboDiscountAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblVatNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCheckDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpCheckDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtORNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floHeader2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblApplied = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtApplied = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblUnapplied = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtUnapplied = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.chkApproved = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateCreated = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.floPurchaseJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvNotesDescription = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CancelledDataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DiscountTakenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JournalIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OriginalAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaidAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayeeTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecialAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewCsrOiItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequenceCsrOi = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvJournalCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvJournalIdNoAp = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvPreviousBalance = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvBalance = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.AccountIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsCsrOiItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.floFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnAutoApply = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floFullEntryArea.SuspendLayout
        Me.floPurchaseJournalHeader.SuspendLayout
        Me.floHeader1.SuspendLayout
        Me.floHeader2.SuspendLayout
        Me.floPurchaseJournalItems.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewCsrOiItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsCsrOiItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floFooter.SuspendLayout
        Me.SuspendLayout
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'floFullEntryArea
        '
        Me.floFullEntryArea.BackColor = System.Drawing.Color.Transparent
        Me.floFullEntryArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floFullEntryArea.Controls.Add(Me.floPurchaseJournalHeader)
        Me.floFullEntryArea.Controls.Add(Me.floPurchaseJournalItems)
        Me.floFullEntryArea.Controls.Add(Me.floFooter)
        Me.floFullEntryArea.Controls.Add(Me.btnAutoApply)
        Me.floFullEntryArea.Controls.Add(Me.txtTotalCredits)
        Me.floFullEntryArea.Controls.Add(Me.txtTotalDebits)
        resources.ApplyResources(Me.floFullEntryArea, "floFullEntryArea")
        Me.floFullEntryArea.Name = "floFullEntryArea"
        '
        'floPurchaseJournalHeader
        '
        Me.floPurchaseJournalHeader.BackColor = System.Drawing.Color.Transparent
        Me.floPurchaseJournalHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floPurchaseJournalHeader.Controls.Add(Me.floHeader1)
        Me.floPurchaseJournalHeader.Controls.Add(Me.floHeader2)
        Me.floFullEntryArea.SetFlowBreak(Me.floPurchaseJournalHeader, true)
        resources.ApplyResources(Me.floPurchaseJournalHeader, "floPurchaseJournalHeader")
        Me.floPurchaseJournalHeader.Name = "floPurchaseJournalHeader"
        '
        'floHeader1
        '
        Me.floHeader1.BackColor = System.Drawing.Color.Transparent
        Me.floHeader1.Controls.Add(Me.lblIdNo)
        Me.floHeader1.Controls.Add(Me.txtJournalCode)
        Me.floHeader1.Controls.Add(Me.TxtIdNo)
        Me.floHeader1.Controls.Add(Me.lblReferenceNo)
        Me.floHeader1.Controls.Add(Me.txtReferenceNo)
        Me.floHeader1.Controls.Add(Me.lblTransactionDate)
        Me.floHeader1.Controls.Add(Me.dtpTransactionDate)
        Me.floHeader1.Controls.Add(Me.lblInvoiceDate)
        Me.floHeader1.Controls.Add(Me.cboPayorType)
        Me.floHeader1.Controls.Add(Me.lblSupplierIdNo)
        Me.floHeader1.Controls.Add(Me.cboPayorIdNo)
        Me.floHeader1.Controls.Add(Me.txtPayorName)
        Me.floHeader1.Controls.Add(Me.lblAccountIdNo)
        Me.floHeader1.Controls.Add(Me.cboAccountIdNo)
        Me.floHeader1.Controls.Add(Me.lblAmount)
        Me.floHeader1.Controls.Add(Me.txtAmount)
        Me.floHeader1.Controls.Add(Me.lblDiscountAccountIdNo)
        Me.floHeader1.Controls.Add(Me.cboDiscountAccountIdNo)
        Me.floHeader1.Controls.Add(Me.lblVatNumber)
        Me.floHeader1.Controls.Add(Me.txtVatNumber)
        Me.floHeader1.Controls.Add(Me.lblCheckNumber)
        Me.floHeader1.Controls.Add(Me.txtCheckNumber)
        Me.floHeader1.Controls.Add(Me.lblCheckDate)
        Me.floHeader1.Controls.Add(Me.dtpCheckDate)
        Me.floHeader1.Controls.Add(Me.lblInvoiceNo)
        Me.floHeader1.Controls.Add(Me.txtORNumber)
        Me.floHeader1.Controls.Add(Me.lblNotes)
        Me.floHeader1.Controls.Add(Me.txtNotes)
        resources.ApplyResources(Me.floHeader1, "floHeader1")
        Me.floHeader1.Name = "floHeader1"
        Me.floHeader1.TabStop = true
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Translatable = true
        '
        'txtJournalCode
        '
        Me.txtJournalCode.BackColor = System.Drawing.Color.White
        Me.txtJournalCode.BegFindValue = Nothing
        Me.txtJournalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJournalCode.ComputedValue = true
        Me.txtJournalCode.CustomFormat = Nothing
        Me.txtJournalCode.DataBoundControl = true
        Me.txtJournalCode.DisplayOnly = true
        Me.txtJournalCode.EditingMode = true
        Me.txtJournalCode.EndFindValue = Nothing
        Me.txtJournalCode.FieldDescription = Nothing
        Me.txtJournalCode.FieldName = Nothing
        Me.txtJournalCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtJournalCode.FindEnabled = false
        resources.ApplyResources(Me.txtJournalCode, "txtJournalCode")
        Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
        Me.txtJournalCode.LinkedLabel = Nothing
        Me.txtJournalCode.MaximumValue = Nothing
        Me.txtJournalCode.MinimumValue = Nothing
        Me.txtJournalCode.Name = "txtJournalCode"
        Me.txtJournalCode.OldValue = Nothing
        Me.txtJournalCode.ReadOnly = true
        Me.txtJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtJournalCode.TabStop = false
        Me.txtJournalCode.Translatable = false
        Me.txtJournalCode.ValueIsMandatory = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = true
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.DisplayOnly = true
        Me.lblReferenceNo.EditingMode = false
        resources.ApplyResources(Me.lblReferenceNo, "lblReferenceNo")
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Translatable = true
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.BackColor = System.Drawing.Color.White
        Me.txtReferenceNo.BegFindValue = Nothing
        Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNo.ComputedValue = false
        Me.txtReferenceNo.CustomFormat = Nothing
        Me.txtReferenceNo.DataBoundControl = true
        Me.txtReferenceNo.EditingMode = false
        Me.txtReferenceNo.EndFindValue = Nothing
        Me.txtReferenceNo.FieldDescription = Nothing
        Me.txtReferenceNo.FieldName = Nothing
        Me.txtReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtReferenceNo.FindEnabled = true
        resources.ApplyResources(Me.txtReferenceNo, "txtReferenceNo")
        Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
        Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
        Me.txtReferenceNo.MaximumValue = Nothing
        Me.txtReferenceNo.MinimumValue = Nothing
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.OldValue = Nothing
        Me.txtReferenceNo.ReadOnly = true
        Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtReferenceNo.Translatable = false
        Me.txtReferenceNo.ValueIsMandatory = true
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.DisplayOnly = true
        Me.lblTransactionDate.EditingMode = false
        resources.ApplyResources(Me.lblTransactionDate, "lblTransactionDate")
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Translatable = true
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpTransactionDate.DefaultValue = Nothing
        Me.dtpTransactionDate.DisplayOnly = false
        Me.dtpTransactionDate.DtpDefaultValue = Nothing
        Me.dtpTransactionDate.EditingMode = false
        Me.dtpTransactionDate.EditsAllowed = false
        Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
        Me.dtpTransactionDate.LinkedLabel = Nothing
        resources.ApplyResources(Me.dtpTransactionDate, "dtpTransactionDate")
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ReadOnlyDp = false
        Me.dtpTransactionDate.SecurityKey = Nothing
        Me.dtpTransactionDate.ShowLongDate = false
        Me.dtpTransactionDate.ShowTime = false
        Me.dtpTransactionDate.TargetCalendar = Nothing
        Me.dtpTransactionDate.Translatable = false
        Me.dtpTransactionDate.Value = Nothing
        Me.dtpTransactionDate.ValueIsMandatory = false
        Me.dtpTransactionDate.ValueIsNullable = false
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.DisplayOnly = true
        Me.lblInvoiceDate.EditingMode = false
        resources.ApplyResources(Me.lblInvoiceDate, "lblInvoiceDate")
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Translatable = true
        '
        'cboPayorType
        '
        Me.cboPayorType.BackColor = System.Drawing.Color.White
        Me.cboPayorType.BegFindValue = Nothing
        Me.cboPayorType.ChangingSearchValueOnly = false
        Me.cboPayorType.CurrentSearchTerm = ""
        Me.cboPayorType.DefaultValue = "0"
        Me.cboPayorType.DisplayMember = "Name"
        Me.cboPayorType.EditingMode = false
        Me.cboPayorType.EndFindValue = Nothing
        Me.cboPayorType.FieldDescription = Nothing
        Me.cboPayorType.FieldName = Nothing
        Me.cboPayorType.FilterRule = Nothing
        Me.cboPayorType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPayorType.FindEnabled = false
        resources.ApplyResources(Me.cboPayorType, "cboPayorType")
        Me.cboPayorType.ForeColor = System.Drawing.Color.Black
        Me.cboPayorType.HideWhenNotEditingOrAdding = false
        Me.cboPayorType.IgnoreCase = false
        Me.cboPayorType.LinkedLabel = Nothing
        Me.cboPayorType.Name = "cboPayorType"
        Me.cboPayorType.OldValue = 0
        Me.cboPayorType.OriginalDataSource = Nothing
        Me.cboPayorType.OriginalList = Nothing
        Me.cboPayorType.OverrideDropDownStyleList = false
        Me.cboPayorType.PreviousSearchTerm = Nothing
        Me.cboPayorType.PropertySelector = Nothing
        Me.cboPayorType.ReadOnlyCombo = false
        Me.cboPayorType.SuggestBoxHeight = 200
        Me.cboPayorType.SuggestListOrderRule = Nothing
        Me.cboPayorType.TextToSearch = Nothing
        Me.cboPayorType.Translatable = false
        Me.cboPayorType.ValueIsMandatory = false
        Me.cboPayorType.ValueIsNullable = false
        Me.cboPayorType.ValueIsNumeric = false
        Me.cboPayorType.ValueMember = "Code"
        '
        'lblSupplierIdNo
        '
        Me.lblSupplierIdNo.DisplayOnly = true
        Me.lblSupplierIdNo.EditingMode = false
        resources.ApplyResources(Me.lblSupplierIdNo, "lblSupplierIdNo")
        Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
        Me.lblSupplierIdNo.Translatable = true
        '
        'cboPayorIdNo
        '
        Me.cboPayorIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPayorIdNo.BackColor = System.Drawing.Color.White
        Me.cboPayorIdNo.BegFindValue = Nothing
        Me.cboPayorIdNo.ChangingSearchValueOnly = false
        Me.cboPayorIdNo.CurrentSearchTerm = ""
        Me.cboPayorIdNo.DefaultValue = Nothing
        Me.cboPayorIdNo.DisplayMember = "Name"
        Me.cboPayorIdNo.EditingMode = false
        Me.cboPayorIdNo.EndFindValue = Nothing
        Me.cboPayorIdNo.FieldDescription = Nothing
        Me.cboPayorIdNo.FieldName = Nothing
        Me.cboPayorIdNo.FilterRule = Nothing
        Me.cboPayorIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPayorIdNo.FindEnabled = false
        resources.ApplyResources(Me.cboPayorIdNo, "cboPayorIdNo")
        Me.cboPayorIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPayorIdNo.FormattingEnabled = true
        Me.cboPayorIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPayorIdNo.IgnoreCase = false
        Me.cboPayorIdNo.LinkedLabel = Me.lblSupplierIdNo
        Me.cboPayorIdNo.Name = "cboPayorIdNo"
        Me.cboPayorIdNo.OldValue = 0
        Me.cboPayorIdNo.OriginalDataSource = Nothing
        Me.cboPayorIdNo.OriginalList = Nothing
        Me.cboPayorIdNo.OverrideDropDownStyleList = false
        Me.cboPayorIdNo.PreviousSearchTerm = Nothing
        Me.cboPayorIdNo.PropertySelector = Nothing
        Me.cboPayorIdNo.ReadOnlyCombo = false
        Me.cboPayorIdNo.SuggestBoxHeight = 200
        Me.cboPayorIdNo.SuggestListOrderRule = Nothing
        Me.cboPayorIdNo.TextToSearch = Nothing
        Me.cboPayorIdNo.Translatable = false
        Me.cboPayorIdNo.ValueIsMandatory = false
        Me.cboPayorIdNo.ValueIsNullable = false
        Me.cboPayorIdNo.ValueIsNumeric = false
        Me.cboPayorIdNo.ValueMember = "IdNo"
        '
        'txtPayorName
        '
        Me.txtPayorName.BackColor = System.Drawing.Color.White
        Me.txtPayorName.BegFindValue = Nothing
        Me.txtPayorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayorName.ComputedValue = false
        Me.txtPayorName.CustomFormat = Nothing
        Me.txtPayorName.DataBoundControl = true
        Me.txtPayorName.EditingMode = false
        Me.txtPayorName.EndFindValue = Nothing
        Me.txtPayorName.FieldDescription = Nothing
        Me.txtPayorName.FieldName = Nothing
        Me.txtPayorName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayorName.FindEnabled = false
        Me.floHeader1.SetFlowBreak(Me.txtPayorName, true)
        resources.ApplyResources(Me.txtPayorName, "txtPayorName")
        Me.txtPayorName.ForeColor = System.Drawing.Color.Black
        Me.txtPayorName.LinkedLabel = Me.lblAmount
        Me.txtPayorName.MaximumValue = Nothing
        Me.txtPayorName.MinimumValue = Nothing
        Me.txtPayorName.Name = "txtPayorName"
        Me.txtPayorName.OldValue = Nothing
        Me.txtPayorName.ReadOnly = true
        Me.txtPayorName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayorName.Translatable = false
        Me.txtPayorName.ValueIsMandatory = true
        '
        'lblAmount
        '
        Me.lblAmount.DisplayOnly = true
        Me.lblAmount.EditingMode = false
        resources.ApplyResources(Me.lblAmount, "lblAmount")
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Translatable = true
        '
        'lblAccountIdNo
        '
        Me.lblAccountIdNo.DisplayOnly = true
        Me.lblAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
        Me.lblAccountIdNo.Name = "lblAccountIdNo"
        Me.lblAccountIdNo.Translatable = true
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.BegFindValue = Nothing
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.DefaultValue = ""
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
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.IgnoreCase = false
        Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
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
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BegFindValue = Nothing
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.ComputedValue = false
        Me.txtAmount.CustomFormat = "N2"
        Me.txtAmount.DataBoundControl = true
        Me.txtAmount.EditingMode = false
        Me.txtAmount.EndFindValue = Nothing
        Me.txtAmount.FieldDescription = Nothing
        Me.txtAmount.FieldName = Nothing
        Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtAmount.FindEnabled = true
        resources.ApplyResources(Me.txtAmount, "txtAmount")
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.LinkedLabel = Me.lblAmount
        Me.txtAmount.MaximumValue = Nothing
        Me.txtAmount.MinimumValue = Nothing
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OldValue = Nothing
        Me.txtAmount.ReadOnly = true
        Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtAmount.Translatable = false
        Me.txtAmount.ValueIsMandatory = true
        Me.txtAmount.ValueIsNumeric = true
        '
        'lblDiscountAccountIdNo
        '
        Me.lblDiscountAccountIdNo.DisplayOnly = true
        Me.lblDiscountAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.lblDiscountAccountIdNo, "lblDiscountAccountIdNo")
        Me.lblDiscountAccountIdNo.Name = "lblDiscountAccountIdNo"
        Me.lblDiscountAccountIdNo.Translatable = true
        '
        'cboDiscountAccountIdNo
        '
        Me.cboDiscountAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDiscountAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboDiscountAccountIdNo.BegFindValue = Nothing
        Me.cboDiscountAccountIdNo.ChangingSearchValueOnly = false
        Me.cboDiscountAccountIdNo.CurrentSearchTerm = ""
        Me.cboDiscountAccountIdNo.DefaultValue = Nothing
        Me.cboDiscountAccountIdNo.DisplayMember = "Name"
        Me.cboDiscountAccountIdNo.EditingMode = false
        Me.cboDiscountAccountIdNo.EndFindValue = Nothing
        Me.cboDiscountAccountIdNo.FieldDescription = Nothing
        Me.cboDiscountAccountIdNo.FieldName = Nothing
        Me.cboDiscountAccountIdNo.FilterRule = Nothing
        Me.cboDiscountAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDiscountAccountIdNo.FindEnabled = false
        resources.ApplyResources(Me.cboDiscountAccountIdNo, "cboDiscountAccountIdNo")
        Me.cboDiscountAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboDiscountAccountIdNo.FormattingEnabled = true
        Me.cboDiscountAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboDiscountAccountIdNo.IgnoreCase = false
        Me.cboDiscountAccountIdNo.LinkedLabel = Nothing
        Me.cboDiscountAccountIdNo.Name = "cboDiscountAccountIdNo"
        Me.cboDiscountAccountIdNo.OldValue = 0
        Me.cboDiscountAccountIdNo.OriginalDataSource = Nothing
        Me.cboDiscountAccountIdNo.OriginalList = Nothing
        Me.cboDiscountAccountIdNo.OverrideDropDownStyleList = false
        Me.cboDiscountAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboDiscountAccountIdNo.PropertySelector = Nothing
        Me.cboDiscountAccountIdNo.ReadOnlyCombo = false
        Me.cboDiscountAccountIdNo.SuggestBoxHeight = 200
        Me.cboDiscountAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboDiscountAccountIdNo.TextToSearch = Nothing
        Me.cboDiscountAccountIdNo.Translatable = false
        Me.cboDiscountAccountIdNo.ValueIsMandatory = false
        Me.cboDiscountAccountIdNo.ValueIsNullable = false
        Me.cboDiscountAccountIdNo.ValueIsNumeric = false
        Me.cboDiscountAccountIdNo.ValueMember = "IdNo"
        '
        'lblVatNumber
        '
        Me.lblVatNumber.DisplayOnly = true
        Me.lblVatNumber.EditingMode = false
        resources.ApplyResources(Me.lblVatNumber, "lblVatNumber")
        Me.lblVatNumber.Name = "lblVatNumber"
        Me.lblVatNumber.Translatable = true
        '
        'txtVatNumber
        '
        Me.txtVatNumber.BackColor = System.Drawing.Color.White
        Me.txtVatNumber.BegFindValue = Nothing
        Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatNumber.ComputedValue = false
        Me.txtVatNumber.CustomFormat = "N2"
        Me.txtVatNumber.DataBoundControl = true
        Me.txtVatNumber.EditingMode = false
        Me.txtVatNumber.EndFindValue = Nothing
        Me.txtVatNumber.FieldDescription = Nothing
        Me.txtVatNumber.FieldName = Nothing
        Me.txtVatNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtVatNumber.FindEnabled = true
        resources.ApplyResources(Me.txtVatNumber, "txtVatNumber")
        Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
        Me.txtVatNumber.LinkedLabel = Me.lblAmount
        Me.txtVatNumber.MaximumValue = Nothing
        Me.txtVatNumber.MinimumValue = Nothing
        Me.txtVatNumber.Name = "txtVatNumber"
        Me.txtVatNumber.OldValue = Nothing
        Me.txtVatNumber.ReadOnly = true
        Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtVatNumber.Translatable = false
        Me.txtVatNumber.ValueIsMandatory = true
        Me.txtVatNumber.ValueIsNumeric = true
        '
        'lblCheckNumber
        '
        Me.lblCheckNumber.DisplayOnly = true
        Me.lblCheckNumber.EditingMode = false
        resources.ApplyResources(Me.lblCheckNumber, "lblCheckNumber")
        Me.lblCheckNumber.Name = "lblCheckNumber"
        Me.lblCheckNumber.Translatable = true
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BackColor = System.Drawing.Color.White
        Me.txtCheckNumber.BegFindValue = Nothing
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.ComputedValue = false
        Me.txtCheckNumber.CustomFormat = Nothing
        Me.txtCheckNumber.DataBoundControl = true
        Me.txtCheckNumber.EditingMode = false
        Me.txtCheckNumber.EndFindValue = Nothing
        Me.txtCheckNumber.FieldDescription = Nothing
        Me.txtCheckNumber.FieldName = Nothing
        Me.txtCheckNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCheckNumber.FindEnabled = true
        resources.ApplyResources(Me.txtCheckNumber, "txtCheckNumber")
        Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
        Me.txtCheckNumber.LinkedLabel = Me.lblCheckNumber
        Me.txtCheckNumber.MaximumValue = Nothing
        Me.txtCheckNumber.MinimumValue = Nothing
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.OldValue = Nothing
        Me.txtCheckNumber.ReadOnly = true
        Me.txtCheckNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCheckNumber.Translatable = false
        Me.txtCheckNumber.ValueIsMandatory = true
        '
        'lblCheckDate
        '
        Me.lblCheckDate.DisplayOnly = true
        Me.lblCheckDate.EditingMode = false
        resources.ApplyResources(Me.lblCheckDate, "lblCheckDate")
        Me.lblCheckDate.Name = "lblCheckDate"
        Me.lblCheckDate.Translatable = true
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpCheckDate.DefaultValue = Nothing
        Me.dtpCheckDate.DisplayOnly = false
        Me.dtpCheckDate.DtpDefaultValue = Nothing
        Me.dtpCheckDate.EditingMode = false
        Me.dtpCheckDate.EditsAllowed = false
        Me.dtpCheckDate.ForeColor = System.Drawing.Color.Black
        Me.dtpCheckDate.LinkedLabel = Nothing
        resources.ApplyResources(Me.dtpCheckDate, "dtpCheckDate")
        Me.dtpCheckDate.Name = "dtpCheckDate"
        Me.dtpCheckDate.ReadOnlyDp = false
        Me.dtpCheckDate.SecurityKey = Nothing
        Me.dtpCheckDate.ShowLongDate = false
        Me.dtpCheckDate.ShowTime = false
        Me.dtpCheckDate.TargetCalendar = Nothing
        Me.dtpCheckDate.Translatable = false
        Me.dtpCheckDate.Value = Nothing
        Me.dtpCheckDate.ValueIsMandatory = false
        Me.dtpCheckDate.ValueIsNullable = false
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.DisplayOnly = true
        Me.lblInvoiceNo.EditingMode = false
        resources.ApplyResources(Me.lblInvoiceNo, "lblInvoiceNo")
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Translatable = true
        '
        'txtORNumber
        '
        Me.txtORNumber.BackColor = System.Drawing.Color.White
        Me.txtORNumber.BegFindValue = Nothing
        Me.txtORNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtORNumber.ComputedValue = false
        Me.txtORNumber.CustomFormat = Nothing
        Me.txtORNumber.DataBoundControl = true
        Me.txtORNumber.EditingMode = false
        Me.txtORNumber.EndFindValue = Nothing
        Me.txtORNumber.FieldDescription = Nothing
        Me.txtORNumber.FieldName = Nothing
        Me.txtORNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtORNumber.FindEnabled = true
        resources.ApplyResources(Me.txtORNumber, "txtORNumber")
        Me.txtORNumber.ForeColor = System.Drawing.Color.Black
        Me.txtORNumber.LinkedLabel = Me.lblInvoiceNo
        Me.txtORNumber.MaximumValue = Nothing
        Me.txtORNumber.MinimumValue = Nothing
        Me.txtORNumber.Name = "txtORNumber"
        Me.txtORNumber.OldValue = Nothing
        Me.txtORNumber.ReadOnly = true
        Me.txtORNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtORNumber.Translatable = false
        Me.txtORNumber.ValueIsMandatory = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Translatable = true
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
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
        'floHeader2
        '
        Me.floHeader2.BackColor = System.Drawing.Color.Transparent
        Me.floHeader2.Controls.Add(Me.lblApplied)
        Me.floHeader2.Controls.Add(Me.txtApplied)
        Me.floHeader2.Controls.Add(Me.lblUnapplied)
        Me.floHeader2.Controls.Add(Me.txtUnapplied)
        Me.floHeader2.Controls.Add(Me.lblDiscountTaken)
        Me.floHeader2.Controls.Add(Me.txtDiscountTaken)
        Me.floHeader2.Controls.Add(Me.lblVatAmount)
        Me.floHeader2.Controls.Add(Me.txtVatAmount)
        Me.floHeader2.Controls.Add(Me.chkCancelled)
        Me.floHeader2.Controls.Add(Me.chkPosted)
        Me.floHeader2.Controls.Add(Me.chkApproved)
        Me.floHeader2.Controls.Add(Me.lblDateCreated)
        Me.floHeader2.Controls.Add(Me.dtpDateCreated)
        Me.floPurchaseJournalHeader.SetFlowBreak(Me.floHeader2, true)
        resources.ApplyResources(Me.floHeader2, "floHeader2")
        Me.floHeader2.Name = "floHeader2"
        Me.floHeader2.TabStop = true
        '
        'lblApplied
        '
        Me.lblApplied.DisplayOnly = true
        Me.lblApplied.EditingMode = false
        resources.ApplyResources(Me.lblApplied, "lblApplied")
        Me.lblApplied.Name = "lblApplied"
        Me.lblApplied.Translatable = true
        '
        'txtApplied
        '
        Me.txtApplied.BackColor = System.Drawing.Color.White
        Me.txtApplied.BegFindValue = Nothing
        Me.txtApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApplied.ComputedValue = false
        Me.txtApplied.CustomFormat = "N2"
        Me.txtApplied.DataBoundControl = true
        Me.txtApplied.DisplayOnly = true
        Me.txtApplied.EditingMode = true
        Me.txtApplied.EndFindValue = Nothing
        Me.txtApplied.FieldDescription = Nothing
        Me.txtApplied.FieldName = Nothing
        Me.txtApplied.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtApplied.FindEnabled = true
        resources.ApplyResources(Me.txtApplied, "txtApplied")
        Me.txtApplied.ForeColor = System.Drawing.Color.Black
        Me.txtApplied.LinkedLabel = Me.lblApplied
        Me.txtApplied.MaximumValue = Nothing
        Me.txtApplied.MinimumValue = Nothing
        Me.txtApplied.Name = "txtApplied"
        Me.txtApplied.OldValue = Nothing
        Me.txtApplied.ReadOnly = true
        Me.txtApplied.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtApplied.TabStop = false
        Me.txtApplied.Translatable = false
        Me.txtApplied.ValueIsMandatory = true
        Me.txtApplied.ValueIsNumeric = true
        '
        'lblUnapplied
        '
        Me.lblUnapplied.DisplayOnly = true
        Me.lblUnapplied.EditingMode = false
        resources.ApplyResources(Me.lblUnapplied, "lblUnapplied")
        Me.lblUnapplied.Name = "lblUnapplied"
        Me.lblUnapplied.Translatable = true
        '
        'txtUnapplied
        '
        Me.txtUnapplied.BackColor = System.Drawing.Color.White
        Me.txtUnapplied.BegFindValue = Nothing
        Me.txtUnapplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnapplied.ComputedValue = false
        Me.txtUnapplied.CustomFormat = "N2"
        Me.txtUnapplied.DataBoundControl = true
        Me.txtUnapplied.DisplayOnly = true
        Me.txtUnapplied.EditingMode = true
        Me.txtUnapplied.EndFindValue = Nothing
        Me.txtUnapplied.FieldDescription = Nothing
        Me.txtUnapplied.FieldName = Nothing
        Me.txtUnapplied.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtUnapplied.FindEnabled = true
        Me.floHeader2.SetFlowBreak(Me.txtUnapplied, true)
        resources.ApplyResources(Me.txtUnapplied, "txtUnapplied")
        Me.txtUnapplied.ForeColor = System.Drawing.Color.Black
        Me.txtUnapplied.LinkedLabel = Me.lblUnapplied
        Me.txtUnapplied.MaximumValue = Nothing
        Me.txtUnapplied.MinimumValue = Nothing
        Me.txtUnapplied.Name = "txtUnapplied"
        Me.txtUnapplied.OldValue = Nothing
        Me.txtUnapplied.ReadOnly = true
        Me.txtUnapplied.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtUnapplied.TabStop = false
        Me.txtUnapplied.Translatable = false
        Me.txtUnapplied.ValueIsMandatory = true
        Me.txtUnapplied.ValueIsNumeric = true
        '
        'lblDiscountTaken
        '
        Me.lblDiscountTaken.DisplayOnly = true
        Me.lblDiscountTaken.EditingMode = false
        resources.ApplyResources(Me.lblDiscountTaken, "lblDiscountTaken")
        Me.lblDiscountTaken.Name = "lblDiscountTaken"
        Me.lblDiscountTaken.Translatable = true
        '
        'txtDiscountTaken
        '
        Me.txtDiscountTaken.BackColor = System.Drawing.Color.White
        Me.txtDiscountTaken.BegFindValue = Nothing
        Me.txtDiscountTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountTaken.ComputedValue = false
        Me.txtDiscountTaken.CustomFormat = "N2"
        Me.txtDiscountTaken.DataBoundControl = true
        Me.txtDiscountTaken.DisplayOnly = true
        Me.txtDiscountTaken.EditingMode = true
        Me.txtDiscountTaken.EndFindValue = Nothing
        Me.txtDiscountTaken.FieldDescription = Nothing
        Me.txtDiscountTaken.FieldName = Nothing
        Me.txtDiscountTaken.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDiscountTaken.FindEnabled = true
        resources.ApplyResources(Me.txtDiscountTaken, "txtDiscountTaken")
        Me.txtDiscountTaken.ForeColor = System.Drawing.Color.Black
        Me.txtDiscountTaken.LinkedLabel = Me.lblDiscountTaken
        Me.txtDiscountTaken.MaximumValue = Nothing
        Me.txtDiscountTaken.MinimumValue = Nothing
        Me.txtDiscountTaken.Name = "txtDiscountTaken"
        Me.txtDiscountTaken.OldValue = Nothing
        Me.txtDiscountTaken.ReadOnly = true
        Me.txtDiscountTaken.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDiscountTaken.TabStop = false
        Me.txtDiscountTaken.Translatable = false
        Me.txtDiscountTaken.ValueIsMandatory = true
        Me.txtDiscountTaken.ValueIsNumeric = true
        '
        'lblVatAmount
        '
        Me.lblVatAmount.DisplayOnly = true
        Me.lblVatAmount.EditingMode = false
        resources.ApplyResources(Me.lblVatAmount, "lblVatAmount")
        Me.lblVatAmount.Name = "lblVatAmount"
        Me.lblVatAmount.Translatable = true
        '
        'txtVatAmount
        '
        Me.txtVatAmount.BackColor = System.Drawing.Color.White
        Me.txtVatAmount.BegFindValue = Nothing
        Me.txtVatAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatAmount.ComputedValue = false
        Me.txtVatAmount.CustomFormat = "N2"
        Me.txtVatAmount.DataBoundControl = true
        Me.txtVatAmount.DisplayOnly = true
        Me.txtVatAmount.EditingMode = true
        Me.txtVatAmount.EndFindValue = Nothing
        Me.txtVatAmount.FieldDescription = Nothing
        Me.txtVatAmount.FieldName = Nothing
        Me.txtVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtVatAmount.FindEnabled = true
        resources.ApplyResources(Me.txtVatAmount, "txtVatAmount")
        Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
        Me.txtVatAmount.LinkedLabel = Me.lblDiscountTaken
        Me.txtVatAmount.MaximumValue = Nothing
        Me.txtVatAmount.MinimumValue = Nothing
        Me.txtVatAmount.Name = "txtVatAmount"
        Me.txtVatAmount.OldValue = Nothing
        Me.txtVatAmount.ReadOnly = true
        Me.txtVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtVatAmount.TabStop = false
        Me.txtVatAmount.Translatable = false
        Me.txtVatAmount.ValueIsMandatory = true
        Me.txtVatAmount.ValueIsNumeric = true
        '
        'chkCancelled
        '
        resources.ApplyResources(Me.chkCancelled, "chkCancelled")
        Me.chkCancelled.BackColor = System.Drawing.Color.Transparent
        Me.chkCancelled.BegFindValue = Nothing
        Me.chkCancelled.Checked = false
        Me.chkCancelled.DisplayOnly = true
        Me.chkCancelled.EditingMode = false
        Me.chkCancelled.EndFindValue = Nothing
        Me.chkCancelled.FieldDescription = Nothing
        Me.chkCancelled.FieldName = Nothing
        Me.chkCancelled.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkCancelled.FindEnabled = true
        Me.chkCancelled.IgnoreCase = false
        Me.chkCancelled.LinkedLabel = Nothing
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkCancelled.TabStop = false
        Me.chkCancelled.Translatable = true
        '
        'chkPosted
        '
        resources.ApplyResources(Me.chkPosted, "chkPosted")
        Me.chkPosted.BackColor = System.Drawing.Color.Transparent
        Me.chkPosted.BegFindValue = Nothing
        Me.chkPosted.Checked = false
        Me.chkPosted.DisplayOnly = true
        Me.chkPosted.EditingMode = false
        Me.chkPosted.EndFindValue = Nothing
        Me.chkPosted.FieldDescription = Nothing
        Me.chkPosted.FieldName = Nothing
        Me.chkPosted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkPosted.FindEnabled = true
        Me.chkPosted.IgnoreCase = false
        Me.chkPosted.LinkedLabel = Nothing
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkPosted.TabStop = false
        Me.chkPosted.Translatable = true
        '
        'chkApproved
        '
        resources.ApplyResources(Me.chkApproved, "chkApproved")
        Me.chkApproved.BackColor = System.Drawing.Color.Transparent
        Me.chkApproved.BegFindValue = Nothing
        Me.chkApproved.Checked = false
        Me.chkApproved.EditingMode = false
        Me.chkApproved.EndFindValue = Nothing
        Me.chkApproved.FieldDescription = Nothing
        Me.chkApproved.FieldName = Nothing
        Me.chkApproved.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkApproved.FindEnabled = true
        Me.floHeader2.SetFlowBreak(Me.chkApproved, true)
        Me.chkApproved.IgnoreCase = false
        Me.chkApproved.LinkedLabel = Nothing
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkApproved.Translatable = true
        '
        'lblDateCreated
        '
        Me.lblDateCreated.DisplayOnly = true
        Me.lblDateCreated.EditingMode = false
        resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Translatable = true
        '
        'dtpDateCreated
        '
        Me.dtpDateCreated.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateCreated.DefaultValue = Nothing
        Me.dtpDateCreated.DisplayOnly = true
        Me.dtpDateCreated.DtpDefaultValue = Nothing
        Me.dtpDateCreated.EditingMode = false
        Me.dtpDateCreated.EditsAllowed = false
        Me.dtpDateCreated.ForeColor = System.Drawing.Color.Black
        Me.dtpDateCreated.LinkedLabel = Nothing
        resources.ApplyResources(Me.dtpDateCreated, "dtpDateCreated")
        Me.dtpDateCreated.Name = "dtpDateCreated"
        Me.dtpDateCreated.ReadOnlyDp = true
        Me.dtpDateCreated.SecurityKey = Nothing
        Me.dtpDateCreated.ShowLongDate = false
        Me.dtpDateCreated.ShowTime = true
        Me.dtpDateCreated.TabStop = false
        Me.dtpDateCreated.TargetCalendar = Nothing
        Me.dtpDateCreated.Translatable = false
        Me.dtpDateCreated.Value = Nothing
        Me.dtpDateCreated.ValueIsMandatory = false
        Me.dtpDateCreated.ValueIsNullable = false
        '
        'floPurchaseJournalItems
        '
        Me.floPurchaseJournalItems.BackColor = System.Drawing.Color.Transparent
        Me.floPurchaseJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewJournalItems)
        Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewCsrOiItems)
        Me.floFullEntryArea.SetFlowBreak(Me.floPurchaseJournalItems, true)
        resources.ApplyResources(Me.floPurchaseJournalItems, "floPurchaseJournalItems")
        Me.floPurchaseJournalItems.Name = "floPurchaseJournalItems"
        Me.floPurchaseJournalItems.TabStop = true
        '
        'DataGridViewJournalItems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewJournalItems.AutoGenerateColumns = false
        Me.DataGridViewJournalItems.BegFindValue = Nothing
        Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotesDescription, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn1, Me.DiscountTakenDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn1, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PaidAmountDataGridViewTextBoxColumn, Me.PayeeTypeDataGridViewTextBoxColumn, Me.SpecialAccountDataGridViewTextBoxColumn})
        Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewJournalItems.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewJournalItems.DgvFooter = Nothing
        Me.DataGridViewJournalItems.DisplayOnly = false
        resources.ApplyResources(Me.DataGridViewJournalItems, "DataGridViewJournalItems")
        Me.DataGridViewJournalItems.Ea = EventAggregator1
        Me.DataGridViewJournalItems.EditingMode = false
        Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewJournalItems.EndFindValue = Nothing
        Me.DataGridViewJournalItems.FieldDescription = Nothing
        Me.DataGridViewJournalItems.FieldName = Nothing
        Me.DataGridViewJournalItems.FieldsDictionary = Nothing
        Me.DataGridViewJournalItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewJournalItems.FindEnabled = false
        Me.DataGridViewJournalItems.FirstRowDeletionEnabled = false
        Me.DataGridViewJournalItems.FirstRowInsertionEnabled = false
        Me.DataGridViewJournalItems.IgnoreCase = false
        Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
        Me.DataGridViewJournalItems.ReadOnly = true
        Me.DataGridViewJournalItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewJournalItems.SecurityKey = ""
        Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
        Me.DataGridViewJournalItems.ShowFooter = false
        Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = true
        Me.DataGridViewJournalItems.Translatable = true
        '
        'dgvSequence
        '
        Me.dgvSequence.BegFindValue = Nothing
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSequence.DisplayOnly = true
        Me.dgvSequence.EditingMode = false
        Me.dgvSequence.EndFindValue = Nothing
        Me.dgvSequence.FieldDescription = Nothing
        Me.dgvSequence.FieldName = Nothing
        Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequence.FindEnabled = false
        resources.ApplyResources(Me.dgvSequence, "dgvSequence")
        Me.dgvSequence.IgnoreCase = false
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSequence.Translatable = false
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAccountIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.ReadOnly = true
        Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvAccountIdNo.Translatable = false
        '
        'dgvDebit
        '
        Me.dgvDebit.BegFindValue = Nothing
        Me.dgvDebit.DataPropertyName = "Debit"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Format = "###,##0.00"
        Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDebit.EditingMode = false
        Me.dgvDebit.EndFindValue = Nothing
        Me.dgvDebit.FieldDescription = Nothing
        Me.dgvDebit.FieldName = Nothing
        Me.dgvDebit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDebit.FindEnabled = false
        resources.ApplyResources(Me.dgvDebit, "dgvDebit")
        Me.dgvDebit.Name = "dgvDebit"
        Me.dgvDebit.ReadOnly = true
        Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDebit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDebit.Translatable = false
        '
        'dgvCredit
        '
        Me.dgvCredit.BegFindValue = Nothing
        Me.dgvCredit.DataPropertyName = "Credit"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Format = "###,##0.00"
        Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCredit.EditingMode = false
        Me.dgvCredit.EndFindValue = Nothing
        Me.dgvCredit.FieldDescription = Nothing
        Me.dgvCredit.FieldName = Nothing
        Me.dgvCredit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvCredit.FindEnabled = false
        resources.ApplyResources(Me.dgvCredit, "dgvCredit")
        Me.dgvCredit.Name = "dgvCredit"
        Me.dgvCredit.ReadOnly = true
        Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCredit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvCredit.Translatable = false
        '
        'dgvRevCostCenterIdNo
        '
        Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRevCostCenterIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
        Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
        Me.dgvRevCostCenterIdNo.ReadOnly = true
        Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRevCostCenterIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvRevCostCenterIdNo.Translatable = false
        '
        'dgvNotesDescription
        '
        Me.dgvNotesDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNotesDescription.BegFindValue = Nothing
        Me.dgvNotesDescription.DataPropertyName = "Notes"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.dgvNotesDescription.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvNotesDescription.EditingMode = false
        Me.dgvNotesDescription.EndFindValue = Nothing
        Me.dgvNotesDescription.FieldDescription = Nothing
        Me.dgvNotesDescription.FieldName = Nothing
        Me.dgvNotesDescription.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvNotesDescription.FindEnabled = false
        resources.ApplyResources(Me.dgvNotesDescription, "dgvNotesDescription")
        Me.dgvNotesDescription.IgnoreCase = false
        Me.dgvNotesDescription.Name = "dgvNotesDescription"
        Me.dgvNotesDescription.ReadOnly = true
        Me.dgvNotesDescription.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNotesDescription.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvNotesDescription.Translatable = false
        '
        'AccountNameDataGridViewTextBoxColumn
        '
        Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
        resources.ApplyResources(Me.AccountNameDataGridViewTextBoxColumn, "AccountNameDataGridViewTextBoxColumn")
        Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
        Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'CancelledDataGridViewCheckBoxColumn1
        '
        Me.CancelledDataGridViewCheckBoxColumn1.DataPropertyName = "Cancelled"
        resources.ApplyResources(Me.CancelledDataGridViewCheckBoxColumn1, "CancelledDataGridViewCheckBoxColumn1")
        Me.CancelledDataGridViewCheckBoxColumn1.Name = "CancelledDataGridViewCheckBoxColumn1"
        Me.CancelledDataGridViewCheckBoxColumn1.ReadOnly = true
        '
        'DiscountTakenDataGridViewTextBoxColumn
        '
        Me.DiscountTakenDataGridViewTextBoxColumn.DataPropertyName = "DiscountTaken"
        resources.ApplyResources(Me.DiscountTakenDataGridViewTextBoxColumn, "DiscountTakenDataGridViewTextBoxColumn")
        Me.DiscountTakenDataGridViewTextBoxColumn.Name = "DiscountTakenDataGridViewTextBoxColumn"
        Me.DiscountTakenDataGridViewTextBoxColumn.ReadOnly = true
        '
        'IdNoDataGridViewTextBoxColumn1
        '
        Me.IdNoDataGridViewTextBoxColumn1.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn1, "IdNoDataGridViewTextBoxColumn1")
        Me.IdNoDataGridViewTextBoxColumn1.Name = "IdNoDataGridViewTextBoxColumn1"
        Me.IdNoDataGridViewTextBoxColumn1.ReadOnly = true
        '
        'JournalIdNoDataGridViewTextBoxColumn
        '
        Me.JournalIdNoDataGridViewTextBoxColumn.DataPropertyName = "JournalIdNo"
        resources.ApplyResources(Me.JournalIdNoDataGridViewTextBoxColumn, "JournalIdNoDataGridViewTextBoxColumn")
        Me.JournalIdNoDataGridViewTextBoxColumn.Name = "JournalIdNoDataGridViewTextBoxColumn"
        Me.JournalIdNoDataGridViewTextBoxColumn.ReadOnly = true
        '
        'OpenInvoiceIdNoDataGridViewTextBoxColumn1
        '
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1.DataPropertyName = "OpenInvoiceIdNo"
        resources.ApplyResources(Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1, "OpenInvoiceIdNoDataGridViewTextBoxColumn1")
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1.Name = "OpenInvoiceIdNoDataGridViewTextBoxColumn1"
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1.ReadOnly = true
        '
        'OriginalAmountDataGridViewTextBoxColumn
        '
        Me.OriginalAmountDataGridViewTextBoxColumn.DataPropertyName = "OriginalAmount"
        resources.ApplyResources(Me.OriginalAmountDataGridViewTextBoxColumn, "OriginalAmountDataGridViewTextBoxColumn")
        Me.OriginalAmountDataGridViewTextBoxColumn.Name = "OriginalAmountDataGridViewTextBoxColumn"
        Me.OriginalAmountDataGridViewTextBoxColumn.ReadOnly = true
        '
        'PaidAmountDataGridViewTextBoxColumn
        '
        Me.PaidAmountDataGridViewTextBoxColumn.DataPropertyName = "PaidAmount"
        resources.ApplyResources(Me.PaidAmountDataGridViewTextBoxColumn, "PaidAmountDataGridViewTextBoxColumn")
        Me.PaidAmountDataGridViewTextBoxColumn.Name = "PaidAmountDataGridViewTextBoxColumn"
        Me.PaidAmountDataGridViewTextBoxColumn.ReadOnly = true
        '
        'PayeeTypeDataGridViewTextBoxColumn
        '
        Me.PayeeTypeDataGridViewTextBoxColumn.DataPropertyName = "PayeeType"
        resources.ApplyResources(Me.PayeeTypeDataGridViewTextBoxColumn, "PayeeTypeDataGridViewTextBoxColumn")
        Me.PayeeTypeDataGridViewTextBoxColumn.Name = "PayeeTypeDataGridViewTextBoxColumn"
        Me.PayeeTypeDataGridViewTextBoxColumn.ReadOnly = true
        '
        'SpecialAccountDataGridViewTextBoxColumn
        '
        Me.SpecialAccountDataGridViewTextBoxColumn.DataPropertyName = "SpecialAccount"
        resources.ApplyResources(Me.SpecialAccountDataGridViewTextBoxColumn, "SpecialAccountDataGridViewTextBoxColumn")
        Me.SpecialAccountDataGridViewTextBoxColumn.Name = "SpecialAccountDataGridViewTextBoxColumn"
        Me.SpecialAccountDataGridViewTextBoxColumn.ReadOnly = true
        '
        'bsJournalItems
        '
        Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
        '
        'DataGridViewCsrOiItems
        '
        Me.DataGridViewCsrOiItems.AllowUserToAddRows = false
        Me.DataGridViewCsrOiItems.AllowUserToDeleteRows = false
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewCsrOiItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewCsrOiItems.AutoGenerateColumns = false
        Me.DataGridViewCsrOiItems.BegFindValue = Nothing
        Me.DataGridViewCsrOiItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCsrOiItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceCsrOi, Me.dgvInvoiceNo, Me.dgvTransactionDate, Me.dgvJournalCode, Me.dgvJournalIdNoAp, Me.dgvPreviousBalance, Me.dgvAmount, Me.dgvDiscountTaken, Me.dgvBalance, Me.AccountIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn})
        Me.DataGridViewCsrOiItems.DataSource = Me.bsCsrOiItems
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewCsrOiItems.DefaultCellStyle = DataGridViewCellStyle19
        Me.DataGridViewCsrOiItems.DgvFooter = Nothing
        Me.DataGridViewCsrOiItems.DisplayOnly = false
        Me.DataGridViewCsrOiItems.Ea = EventAggregator2
        Me.DataGridViewCsrOiItems.EditingMode = false
        Me.DataGridViewCsrOiItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewCsrOiItems.EndFindValue = Nothing
        Me.DataGridViewCsrOiItems.FieldDescription = Nothing
        Me.DataGridViewCsrOiItems.FieldName = Nothing
        Me.DataGridViewCsrOiItems.FieldsDictionary = Nothing
        Me.DataGridViewCsrOiItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewCsrOiItems.FindEnabled = false
        Me.DataGridViewCsrOiItems.FirstRowDeletionEnabled = false
        Me.DataGridViewCsrOiItems.FirstRowInsertionEnabled = false
        Me.DataGridViewCsrOiItems.IgnoreCase = false
        resources.ApplyResources(Me.DataGridViewCsrOiItems, "DataGridViewCsrOiItems")
        Me.DataGridViewCsrOiItems.Name = "DataGridViewCsrOiItems"
        Me.DataGridViewCsrOiItems.ReadOnly = true
        Me.DataGridViewCsrOiItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewCsrOiItems.SecurityKey = ""
        Me.DataGridViewCsrOiItems.SequenceColumn = "dgvSequenceCsrOi"
        Me.DataGridViewCsrOiItems.SequenceFieldName = "Sequence"
        Me.DataGridViewCsrOiItems.ShowFooter = false
        Me.DataGridViewCsrOiItems.ShowInsertColumnWhenEditing = false
        Me.DataGridViewCsrOiItems.Translatable = true
        '
        'dgvSequenceCsrOi
        '
        Me.dgvSequenceCsrOi.BegFindValue = Nothing
        Me.dgvSequenceCsrOi.DataPropertyName = "Sequence"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.dgvSequenceCsrOi.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvSequenceCsrOi.DisplayOnly = true
        Me.dgvSequenceCsrOi.EditingMode = false
        Me.dgvSequenceCsrOi.EndFindValue = Nothing
        Me.dgvSequenceCsrOi.FieldDescription = Nothing
        Me.dgvSequenceCsrOi.FieldName = Nothing
        Me.dgvSequenceCsrOi.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequenceCsrOi.FindEnabled = false
        resources.ApplyResources(Me.dgvSequenceCsrOi, "dgvSequenceCsrOi")
        Me.dgvSequenceCsrOi.IgnoreCase = false
        Me.dgvSequenceCsrOi.Name = "dgvSequenceCsrOi"
        Me.dgvSequenceCsrOi.ReadOnly = true
        Me.dgvSequenceCsrOi.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSequenceCsrOi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgvSequenceCsrOi.Translatable = false
        '
        'dgvInvoiceNo
        '
        Me.dgvInvoiceNo.BegFindValue = Nothing
        Me.dgvInvoiceNo.DataPropertyName = "InvoiceNo"
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        Me.dgvInvoiceNo.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvInvoiceNo.DisplayOnly = true
        Me.dgvInvoiceNo.EditingMode = false
        Me.dgvInvoiceNo.EndFindValue = Nothing
        Me.dgvInvoiceNo.FieldDescription = Nothing
        Me.dgvInvoiceNo.FieldName = Nothing
        Me.dgvInvoiceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvInvoiceNo.FindEnabled = false
        resources.ApplyResources(Me.dgvInvoiceNo, "dgvInvoiceNo")
        Me.dgvInvoiceNo.IgnoreCase = false
        Me.dgvInvoiceNo.Name = "dgvInvoiceNo"
        Me.dgvInvoiceNo.ReadOnly = true
        Me.dgvInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvInvoiceNo.Translatable = false
        '
        'dgvTransactionDate
        '
        Me.dgvTransactionDate.BegFindValue = Nothing
        Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvTransactionDate.DisplayOnly = true
        Me.dgvTransactionDate.EditingMode = false
        Me.dgvTransactionDate.EndFindValue = Nothing
        Me.dgvTransactionDate.FieldDescription = Nothing
        Me.dgvTransactionDate.FieldName = Nothing
        Me.dgvTransactionDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvTransactionDate.FindEnabled = false
        resources.ApplyResources(Me.dgvTransactionDate, "dgvTransactionDate")
        Me.dgvTransactionDate.IgnoreCase = false
        Me.dgvTransactionDate.Name = "dgvTransactionDate"
        Me.dgvTransactionDate.ReadOnly = true
        Me.dgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvTransactionDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgvTransactionDate.Translatable = false
        '
        'dgvJournalCode
        '
        Me.dgvJournalCode.BegFindValue = Nothing
        Me.dgvJournalCode.DataPropertyName = "JournalCode"
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        Me.dgvJournalCode.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvJournalCode.DisplayOnly = true
        Me.dgvJournalCode.EditingMode = false
        Me.dgvJournalCode.EndFindValue = Nothing
        Me.dgvJournalCode.FieldDescription = Nothing
        Me.dgvJournalCode.FieldName = Nothing
        Me.dgvJournalCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvJournalCode.FindEnabled = false
        resources.ApplyResources(Me.dgvJournalCode, "dgvJournalCode")
        Me.dgvJournalCode.IgnoreCase = false
        Me.dgvJournalCode.Name = "dgvJournalCode"
        Me.dgvJournalCode.ReadOnly = true
        Me.dgvJournalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvJournalCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgvJournalCode.Translatable = false
        '
        'dgvJournalIdNoAp
        '
        Me.dgvJournalIdNoAp.BegFindValue = Nothing
        Me.dgvJournalIdNoAp.DataPropertyName = "JournalIdNo"
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        Me.dgvJournalIdNoAp.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvJournalIdNoAp.DisplayOnly = true
        Me.dgvJournalIdNoAp.EditingMode = false
        Me.dgvJournalIdNoAp.EndFindValue = Nothing
        Me.dgvJournalIdNoAp.FieldDescription = Nothing
        Me.dgvJournalIdNoAp.FieldName = Nothing
        Me.dgvJournalIdNoAp.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvJournalIdNoAp.FindEnabled = false
        resources.ApplyResources(Me.dgvJournalIdNoAp, "dgvJournalIdNoAp")
        Me.dgvJournalIdNoAp.IgnoreCase = false
        Me.dgvJournalIdNoAp.Name = "dgvJournalIdNoAp"
        Me.dgvJournalIdNoAp.ReadOnly = true
        Me.dgvJournalIdNoAp.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvJournalIdNoAp.Translatable = false
        '
        'dgvPreviousBalance
        '
        Me.dgvPreviousBalance.BegFindValue = Nothing
        Me.dgvPreviousBalance.DataPropertyName = "PreviousBalance"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.Format = "###,##0.00"
        Me.dgvPreviousBalance.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvPreviousBalance.EditingMode = false
        Me.dgvPreviousBalance.EndFindValue = Nothing
        Me.dgvPreviousBalance.FieldDescription = Nothing
        Me.dgvPreviousBalance.FieldName = Nothing
        Me.dgvPreviousBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvPreviousBalance.FindEnabled = false
        resources.ApplyResources(Me.dgvPreviousBalance, "dgvPreviousBalance")
        Me.dgvPreviousBalance.Name = "dgvPreviousBalance"
        Me.dgvPreviousBalance.ReadOnly = true
        Me.dgvPreviousBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPreviousBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvPreviousBalance.Translatable = false
        '
        'dgvAmount
        '
        Me.dgvAmount.BegFindValue = Nothing
        Me.dgvAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.Format = "###,##0.00"
        Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvAmount.EditingMode = false
        Me.dgvAmount.EndFindValue = Nothing
        Me.dgvAmount.FieldDescription = Nothing
        Me.dgvAmount.FieldName = Nothing
        Me.dgvAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvAmount.FindEnabled = false
        resources.ApplyResources(Me.dgvAmount, "dgvAmount")
        Me.dgvAmount.Name = "dgvAmount"
        Me.dgvAmount.ReadOnly = true
        Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvAmount.Translatable = false
        '
        'dgvDiscountTaken
        '
        Me.dgvDiscountTaken.BegFindValue = Nothing
        Me.dgvDiscountTaken.DataPropertyName = "DiscountTaken"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.Format = "###,##0.00"
        Me.dgvDiscountTaken.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvDiscountTaken.EditingMode = false
        Me.dgvDiscountTaken.EndFindValue = Nothing
        Me.dgvDiscountTaken.FieldDescription = Nothing
        Me.dgvDiscountTaken.FieldName = Nothing
        Me.dgvDiscountTaken.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDiscountTaken.FindEnabled = false
        resources.ApplyResources(Me.dgvDiscountTaken, "dgvDiscountTaken")
        Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
        Me.dgvDiscountTaken.ReadOnly = true
        Me.dgvDiscountTaken.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiscountTaken.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDiscountTaken.Translatable = false
        '
        'dgvBalance
        '
        Me.dgvBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvBalance.BegFindValue = Nothing
        Me.dgvBalance.DataPropertyName = "Balance"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.Format = "###,##0.00"
        Me.dgvBalance.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgvBalance.EditingMode = false
        Me.dgvBalance.EndFindValue = Nothing
        Me.dgvBalance.FieldDescription = Nothing
        Me.dgvBalance.FieldName = Nothing
        Me.dgvBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvBalance.FindEnabled = false
        resources.ApplyResources(Me.dgvBalance, "dgvBalance")
        Me.dgvBalance.Name = "dgvBalance"
        Me.dgvBalance.ReadOnly = true
        Me.dgvBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvBalance.Translatable = false
        '
        'AccountIdNoDataGridViewTextBoxColumn
        '
        Me.AccountIdNoDataGridViewTextBoxColumn.DataPropertyName = "AccountIdNo"
        resources.ApplyResources(Me.AccountIdNoDataGridViewTextBoxColumn, "AccountIdNoDataGridViewTextBoxColumn")
        Me.AccountIdNoDataGridViewTextBoxColumn.Name = "AccountIdNoDataGridViewTextBoxColumn"
        Me.AccountIdNoDataGridViewTextBoxColumn.ReadOnly = true
        '
        'IdNoDataGridViewTextBoxColumn
        '
        Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn, "IdNoDataGridViewTextBoxColumn")
        Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
        Me.IdNoDataGridViewTextBoxColumn.ReadOnly = true
        '
        'bsCsrOiItems
        '
        Me.bsCsrOiItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.CsrOiItemModel)
        '
        'floFooter
        '
        Me.floFooter.BackColor = System.Drawing.Color.Transparent
        Me.floFooter.Controls.Add(Me.btnViewGL)
        resources.ApplyResources(Me.floFooter, "floFooter")
        Me.floFooter.Name = "floFooter"
        '
        'btnViewGL
        '
        Me.btnViewGL.DesignerSelected = false
        resources.ApplyResources(Me.btnViewGL, "btnViewGL")
        Me.btnViewGL.ImageIndex = 0
        Me.btnViewGL.Name = "btnViewGL"
        Me.btnViewGL.OriginalImageName = Nothing
        Me.btnViewGL.SecurityKey = ""
        '
        'btnAutoApply
        '
        Me.btnAutoApply.DesignerSelected = false
        resources.ApplyResources(Me.btnAutoApply, "btnAutoApply")
        Me.btnAutoApply.ImageIndex = 0
        Me.btnAutoApply.Name = "btnAutoApply"
        Me.btnAutoApply.OriginalImageName = Nothing
        Me.btnAutoApply.SecurityKey = ""
        Me.btnAutoApply.TabStop = false
        '
        'txtTotalCredits
        '
        Me.txtTotalCredits.BackColor = System.Drawing.Color.White
        Me.txtTotalCredits.BegFindValue = Nothing
        Me.txtTotalCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCredits.ComputedValue = false
        Me.txtTotalCredits.CustomFormat = Nothing
        Me.txtTotalCredits.DataBoundControl = true
        Me.txtTotalCredits.EditingMode = true
        Me.txtTotalCredits.EndFindValue = Nothing
        Me.txtTotalCredits.FieldDescription = Nothing
        Me.txtTotalCredits.FieldName = Nothing
        Me.txtTotalCredits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalCredits.FindEnabled = false
        resources.ApplyResources(Me.txtTotalCredits, "txtTotalCredits")
        Me.txtTotalCredits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCredits.LinkedLabel = Nothing
        Me.txtTotalCredits.MaximumValue = Nothing
        Me.txtTotalCredits.MinimumValue = Nothing
        Me.txtTotalCredits.Name = "txtTotalCredits"
        Me.txtTotalCredits.OldValue = Nothing
        Me.txtTotalCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalCredits.Translatable = false
        '
        'txtTotalDebits
        '
        Me.txtTotalDebits.BackColor = System.Drawing.Color.White
        Me.txtTotalDebits.BegFindValue = Nothing
        Me.txtTotalDebits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDebits.ComputedValue = false
        Me.txtTotalDebits.CustomFormat = Nothing
        Me.txtTotalDebits.DataBoundControl = true
        Me.txtTotalDebits.EditingMode = true
        Me.txtTotalDebits.EndFindValue = Nothing
        Me.txtTotalDebits.FieldDescription = Nothing
        Me.txtTotalDebits.FieldName = Nothing
        Me.txtTotalDebits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalDebits.FindEnabled = false
        resources.ApplyResources(Me.txtTotalDebits, "txtTotalDebits")
        Me.txtTotalDebits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDebits.LinkedLabel = Nothing
        Me.txtTotalDebits.MaximumValue = Nothing
        Me.txtTotalDebits.MinimumValue = Nothing
        Me.txtTotalDebits.Name = "txtTotalDebits"
        Me.txtTotalDebits.OldValue = Nothing
        Me.txtTotalDebits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalDebits.Translatable = false
        '
        'CashReceiptJournalEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floFullEntryArea)
        Me.Name = "CashReceiptJournalEntry"
        Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floFullEntryArea.ResumeLayout(false)
        Me.floFullEntryArea.PerformLayout
        Me.floPurchaseJournalHeader.ResumeLayout(false)
        Me.floHeader1.ResumeLayout(false)
        Me.floHeader1.PerformLayout
        Me.floHeader2.ResumeLayout(false)
        Me.floHeader2.PerformLayout
        Me.floPurchaseJournalItems.ResumeLayout(false)
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewCsrOiItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsCsrOiItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.floFooter.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents floFullEntryArea As CFlowLayout
        Friend WithEvents floPurchaseJournalHeader As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents txtJournalCode As CTextBox
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblInvoiceNo As CLabel
        Friend WithEvents txtORNumber As CTextBox
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblInvoiceDate As CLabel
        Friend WithEvents lblCheckDate As CLabel
        Friend WithEvents dtpCheckDate As CCustomDateTimePicker
        Friend WithEvents lblSupplierIdNo As CLabel
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floPurchaseJournalItems As CFlowLayout
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents floFooter As CFlowLayout
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents cboPayorType As CaComboBox
        Friend WithEvents lblCheckNumber As CLabel
        Friend WithEvents txtCheckNumber As CTextBox
        Friend WithEvents lblDiscountTaken As CLabel
        Friend WithEvents txtDiscountTaken As CTextBox
        Friend WithEvents lblApplied As CLabel
        Friend WithEvents lblUnapplied As CLabel
        Friend WithEvents txtUnapplied As CTextBox
        Friend WithEvents lblDiscountAccountIdNo As CLabel
        Friend WithEvents cboDiscountAccountIdNo As CaComboBox
        Friend WithEvents txtPayorName As CTextBox
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents cboPayorIdNo As CaComboBox
        Friend WithEvents floHeader1 As CFlowLayout
        Friend WithEvents floHeader2 As CFlowLayout
        Friend WithEvents txtApplied As CTextBox
        Friend WithEvents bsCsrOiItems As Windows.Forms.BindingSource
        Friend WithEvents DataGridViewCsrOiItems As CDataGridView
        Friend WithEvents btnViewGL As CButton
        Friend WithEvents dgvJournalIdNoJi As CDgvTextColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCsrOi As CDgvTextColumn
        Friend WithEvents dgvInvoiceNo As CDgvTextColumn
        Friend WithEvents dgvTransactionDate As CDgvTextColumn
        Friend WithEvents dgvJournalCode As CDgvTextColumn
        Friend WithEvents dgvJournalIdNoAp As CDgvTextColumn
        Friend WithEvents dgvPreviousBalance As CdgvMoneyColumn
        Friend WithEvents dgvAmount As CdgvMoneyColumn
        Friend WithEvents dgvDiscountTaken As CdgvMoneyColumn
        Friend WithEvents dgvBalance As CdgvMoneyColumn
        Friend WithEvents AccountIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvAccountIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvMoneyColumn
        Friend WithEvents dgvCredit As CdgvMoneyColumn
        Friend WithEvents dgvRevCostCenterIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvNotesDescription As CDgvTextColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
        Friend WithEvents DiscountTakenDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents JournalIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents OriginalAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PaidAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayeeTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SpecialAccountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dtpDateCreated As CCustomDateTimePicker
        Friend WithEvents lblVatNumber As CLabel
        Friend WithEvents txtVatNumber As CTextBox
        Friend WithEvents lblVatAmount As CLabel
        Friend WithEvents txtVatAmount As CTextBox
        Friend WithEvents btnAutoApply As CButton
        Friend WithEvents chkCancelled As UcCheckBox
        Friend WithEvents chkPosted As UcCheckBox
        Friend WithEvents chkApproved As UcCheckBox
        Friend WithEvents txtTotalCredits As CTextBox
        Friend WithEvents txtTotalDebits As CTextBox
    End Class
End Namespace