Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CashDisbursementJournalEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CashDisbursementJournalEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim SecurityPresenter1 As AATM.PresentationLayer.Presenters.SecurityPresenter = New AATM.PresentationLayer.Presenters.SecurityPresenter()
        Me.floFullEntryArea = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.floPurchaseJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.floHeader1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpTransactionDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblPaymentType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPaymentType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtORNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblVatNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblApplied = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblDiscountAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboDiscountAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floHeader2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtApplied = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtUnapplied = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCancelled = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floPurchaseJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvProfitCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemVatAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvJournalIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewCadOiItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequenceCadOi = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvJournalCode = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvJournalIdNoJi = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvPreviousBalance = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvNewBalance = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CadIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenInvoiceIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bscadOiItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.floFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblTotals = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floFullEntryArea.SuspendLayout
        Me.floPurchaseJournalHeader.SuspendLayout
        Me.floHeader1.SuspendLayout
        Me.floHeader2.SuspendLayout
        Me.floPurchaseJournalItems.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewCadOiItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bscadOiItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floFooter.SuspendLayout
        Me.SuspendLayout
        '
        'floFullEntryArea
        '
        Me.floFullEntryArea.BackColor = System.Drawing.Color.Transparent
        Me.floFullEntryArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floFullEntryArea.Controls.Add(Me.floPurchaseJournalHeader)
        Me.floFullEntryArea.Controls.Add(Me.floPurchaseJournalItems)
        Me.floFullEntryArea.Controls.Add(Me.floFooter)
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
        Me.floHeader1.Controls.Add(Me.TxtIDNo)
        Me.floHeader1.Controls.Add(Me.lblReferenceNo)
        Me.floHeader1.Controls.Add(Me.txtReferenceNo)
        Me.floHeader1.Controls.Add(Me.lblTransactionDate)
        Me.floHeader1.Controls.Add(Me.dtpTransactionDate)
        Me.floHeader1.Controls.Add(Me.lblPaymentType)
        Me.floHeader1.Controls.Add(Me.cboPaymentType)
        Me.floHeader1.Controls.Add(Me.lblSupplierIdNo)
        Me.floHeader1.Controls.Add(Me.cboPayeeIdNo)
        Me.floHeader1.Controls.Add(Me.txtPayeeName)
        Me.floHeader1.Controls.Add(Me.lblAccountIdNo)
        Me.floHeader1.Controls.Add(Me.cboAccountIdNo)
        Me.floHeader1.Controls.Add(Me.lblAmount)
        Me.floHeader1.Controls.Add(Me.txtAmount)
        Me.floHeader1.Controls.Add(Me.lblInvoiceNo)
        Me.floHeader1.Controls.Add(Me.txtORNumber)
        Me.floHeader1.Controls.Add(Me.lblVatNo)
        Me.floHeader1.Controls.Add(Me.txtVatNumber)
        Me.floHeader1.Controls.Add(Me.lblDiscountAccountIdNo)
        Me.floHeader1.Controls.Add(Me.cboDiscountAccountIdNo)
        Me.floHeader1.Controls.Add(Me.lblNotes)
        Me.floHeader1.Controls.Add(Me.txtNotes)
        resources.ApplyResources(Me.floHeader1, "floHeader1")
        Me.floHeader1.Name = "floHeader1"
        Me.floHeader1.TabStop = true
        '
        'lblIdNo
        '
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.Name = "lblIdNo"
        '
        'txtJournalCode
        '
        Me.txtJournalCode.BackColor = System.Drawing.Color.White
        Me.txtJournalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJournalCode.ComputedValue = true
        Me.txtJournalCode.CustomFormat = Nothing
        Me.txtJournalCode.DataBoundControl = true
        Me.txtJournalCode.DisplayOnly = true
        Me.txtJournalCode.EditingMode = true
        resources.ApplyResources(Me.txtJournalCode, "txtJournalCode")
        Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
        Me.txtJournalCode.LinkedLabel = Nothing
        Me.txtJournalCode.Name = "txtJournalCode"
        Me.txtJournalCode.OldValue = Nothing
        Me.txtJournalCode.ReadOnly = true
        Me.txtJournalCode.TabStop = false
        Me.txtJournalCode.ValueIsMandatory = true
        '
        'TxtIDNo
        '
        Me.TxtIDNo.BackColor = System.Drawing.Color.White
        Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDNo.ComputedValue = true
        Me.TxtIDNo.CustomFormat = Nothing
        Me.TxtIDNo.DataBoundControl = true
        Me.TxtIDNo.DisplayOnly = true
        Me.TxtIDNo.EditingMode = true
        resources.ApplyResources(Me.TxtIDNo, "TxtIDNo")
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Me.lblIdNo
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.OldValue = Nothing
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.Selectable = true
        '
        'lblReferenceNo
        '
        resources.ApplyResources(Me.lblReferenceNo, "lblReferenceNo")
        Me.lblReferenceNo.Name = "lblReferenceNo"
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.BackColor = System.Drawing.Color.White
        Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNo.ComputedValue = false
        Me.txtReferenceNo.CustomFormat = Nothing
        Me.txtReferenceNo.DataBoundControl = true
        Me.txtReferenceNo.EditingMode = false
        resources.ApplyResources(Me.txtReferenceNo, "txtReferenceNo")
        Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
        Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.OldValue = Nothing
        Me.txtReferenceNo.ValueIsMandatory = true
        '
        'lblTransactionDate
        '
        resources.ApplyResources(Me.lblTransactionDate, "lblTransactionDate")
        Me.lblTransactionDate.Name = "lblTransactionDate"
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
        Me.dtpTransactionDate.Value = Nothing
        Me.dtpTransactionDate.ValueIsMandatory = false
        Me.dtpTransactionDate.ValueIsNullable = false
        '
        'lblPaymentType
        '
        resources.ApplyResources(Me.lblPaymentType, "lblPaymentType")
        Me.lblPaymentType.Name = "lblPaymentType"
        '
        'cboPaymentType
        '
        Me.cboPaymentType.BackColor = System.Drawing.Color.White
        Me.cboPaymentType.ChangingSearchValueOnly = false
        Me.cboPaymentType.CurrentSearchTerm = ""
        Me.cboPaymentType.DefaultValue = "0"
        Me.cboPaymentType.DisplayMember = "Name"
        Me.cboPaymentType.DropDownHeight = 200
        Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentType.EditingMode = false
        Me.cboPaymentType.FilterRule = Nothing
        resources.ApplyResources(Me.cboPaymentType, "cboPaymentType")
        Me.cboPaymentType.ForeColor = System.Drawing.Color.Black
        Me.cboPaymentType.HideWhenNotEditingOrAdding = false
        Me.cboPaymentType.LinkedLabel = Me.lblPaymentType
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.OldValue = 0
        Me.cboPaymentType.OriginalDataSource = Nothing
        Me.cboPaymentType.OriginalList = Nothing
        Me.cboPaymentType.OverrideDropDownStyleList = false
        Me.cboPaymentType.PreviousSearchTerm = Nothing
        Me.cboPaymentType.PreviousSelectedIndex = 0
        Me.cboPaymentType.PropertySelector = Nothing
        Me.cboPaymentType.ReadOnlyCombo = false
        Me.cboPaymentType.SearchAnywhere = false
        Me.cboPaymentType.SuggestBoxHeight = 200
        Me.cboPaymentType.SuggestListOrderRule = Nothing
        Me.cboPaymentType.TextToSearch = Nothing
        Me.cboPaymentType.ValueIsMandatory = false
        Me.cboPaymentType.ValueIsNullable = false
        Me.cboPaymentType.ValueIsNumeric = false
        Me.cboPaymentType.ValueMember = "Code"
        '
        'lblSupplierIdNo
        '
        resources.ApplyResources(Me.lblSupplierIdNo, "lblSupplierIdNo")
        Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
        '
        'cboPayeeIdNo
        '
        Me.cboPayeeIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPayeeIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPayeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboPayeeIdNo.ChangingSearchValueOnly = false
        Me.cboPayeeIdNo.CurrentSearchTerm = ""
        Me.cboPayeeIdNo.DefaultValue = Nothing
        Me.cboPayeeIdNo.DisplayMember = "Name"
        Me.cboPayeeIdNo.DropDownHeight = 200
        Me.cboPayeeIdNo.EditingMode = false
        Me.cboPayeeIdNo.FilterRule = Nothing
        resources.ApplyResources(Me.cboPayeeIdNo, "cboPayeeIdNo")
        Me.cboPayeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPayeeIdNo.FormattingEnabled = true
        Me.cboPayeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPayeeIdNo.LinkedLabel = Nothing
        Me.cboPayeeIdNo.Name = "cboPayeeIdNo"
        Me.cboPayeeIdNo.OldValue = 0
        Me.cboPayeeIdNo.OriginalDataSource = Nothing
        Me.cboPayeeIdNo.OriginalList = Nothing
        Me.cboPayeeIdNo.OverrideDropDownStyleList = false
        Me.cboPayeeIdNo.PreviousSearchTerm = Nothing
        Me.cboPayeeIdNo.PreviousSelectedIndex = -1
        Me.cboPayeeIdNo.PropertySelector = Nothing
        Me.cboPayeeIdNo.ReadOnlyCombo = false
        Me.cboPayeeIdNo.SearchAnywhere = false
        Me.cboPayeeIdNo.SuggestBoxHeight = 200
        Me.cboPayeeIdNo.SuggestListOrderRule = Nothing
        Me.cboPayeeIdNo.TextToSearch = Nothing
        Me.cboPayeeIdNo.ValueIsMandatory = false
        Me.cboPayeeIdNo.ValueIsNullable = false
        Me.cboPayeeIdNo.ValueIsNumeric = false
        Me.cboPayeeIdNo.ValueMember = "IdNo"
        '
        'txtPayeeName
        '
        Me.txtPayeeName.BackColor = System.Drawing.Color.White
        Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayeeName.ComputedValue = false
        Me.txtPayeeName.CustomFormat = Nothing
        Me.txtPayeeName.DataBoundControl = true
        Me.txtPayeeName.EditingMode = false
        Me.floHeader1.SetFlowBreak(Me.txtPayeeName, true)
        resources.ApplyResources(Me.txtPayeeName, "txtPayeeName")
        Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
        Me.txtPayeeName.LinkedLabel = Me.lblAmount
        Me.txtPayeeName.Name = "txtPayeeName"
        Me.txtPayeeName.OldValue = Nothing
        Me.txtPayeeName.ValueIsMandatory = true
        '
        'lblAmount
        '
        resources.ApplyResources(Me.lblAmount, "lblAmount")
        Me.lblAmount.Name = "lblAmount"
        '
        'lblAccountIdNo
        '
        resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
        Me.lblAccountIdNo.Name = "lblAccountIdNo"
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.DefaultValue = ""
        Me.cboAccountIdNo.DisplayMember = "Name"
        Me.cboAccountIdNo.DropDownHeight = 200
        Me.cboAccountIdNo.EditingMode = false
        Me.cboAccountIdNo.FilterRule = Nothing
        Me.floHeader1.SetFlowBreak(Me.cboAccountIdNo, true)
        resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.OverrideDropDownStyleList = false
        Me.cboAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboAccountIdNo.PreviousSelectedIndex = 0
        Me.cboAccountIdNo.PropertySelector = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.SearchAnywhere = false
        Me.cboAccountIdNo.SuggestBoxHeight = 200
        Me.cboAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboAccountIdNo.TextToSearch = Nothing
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        Me.cboAccountIdNo.ValueMember = "IdNo"
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.ComputedValue = false
        Me.txtAmount.CustomFormat = "N2"
        Me.txtAmount.DataBoundControl = true
        Me.txtAmount.EditingMode = false
        resources.ApplyResources(Me.txtAmount, "txtAmount")
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.LinkedLabel = Me.lblAmount
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OldValue = Nothing
        Me.txtAmount.ValueIsMandatory = true
        Me.txtAmount.ValueIsNumeric = true
        '
        'lblInvoiceNo
        '
        resources.ApplyResources(Me.lblInvoiceNo, "lblInvoiceNo")
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        '
        'txtORNumber
        '
        Me.txtORNumber.BackColor = System.Drawing.Color.White
        Me.txtORNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtORNumber.ComputedValue = false
        Me.txtORNumber.CustomFormat = Nothing
        Me.txtORNumber.DataBoundControl = true
        Me.txtORNumber.EditingMode = false
        resources.ApplyResources(Me.txtORNumber, "txtORNumber")
        Me.txtORNumber.ForeColor = System.Drawing.Color.Black
        Me.txtORNumber.LinkedLabel = Me.lblInvoiceNo
        Me.txtORNumber.Name = "txtORNumber"
        Me.txtORNumber.OldValue = Nothing
        Me.txtORNumber.ValueIsMandatory = true
        '
        'lblVatNo
        '
        resources.ApplyResources(Me.lblVatNo, "lblVatNo")
        Me.lblVatNo.Name = "lblVatNo"
        '
        'txtVatNumber
        '
        Me.txtVatNumber.BackColor = System.Drawing.Color.White
        Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatNumber.ComputedValue = false
        Me.txtVatNumber.CustomFormat = Nothing
        Me.txtVatNumber.DataBoundControl = true
        Me.txtVatNumber.EditingMode = false
        resources.ApplyResources(Me.txtVatNumber, "txtVatNumber")
        Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
        Me.txtVatNumber.LinkedLabel = Me.lblApplied
        Me.txtVatNumber.Name = "txtVatNumber"
        Me.txtVatNumber.OldValue = Nothing
        Me.txtVatNumber.ValueIsMandatory = true
        Me.txtVatNumber.ValueIsNumeric = true
        '
        'lblApplied
        '
        resources.ApplyResources(Me.lblApplied, "lblApplied")
        Me.lblApplied.Name = "lblApplied"
        '
        'lblDiscountAccountIdNo
        '
        resources.ApplyResources(Me.lblDiscountAccountIdNo, "lblDiscountAccountIdNo")
        Me.lblDiscountAccountIdNo.Name = "lblDiscountAccountIdNo"
        '
        'cboDiscountAccountIdNo
        '
        Me.cboDiscountAccountIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboDiscountAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDiscountAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboDiscountAccountIdNo.ChangingSearchValueOnly = false
        Me.cboDiscountAccountIdNo.CurrentSearchTerm = ""
        Me.cboDiscountAccountIdNo.DefaultValue = Nothing
        Me.cboDiscountAccountIdNo.DisplayMember = "Name"
        Me.cboDiscountAccountIdNo.DropDownHeight = 200
        Me.cboDiscountAccountIdNo.EditingMode = false
        Me.cboDiscountAccountIdNo.FilterRule = Nothing
        Me.floHeader1.SetFlowBreak(Me.cboDiscountAccountIdNo, true)
        resources.ApplyResources(Me.cboDiscountAccountIdNo, "cboDiscountAccountIdNo")
        Me.cboDiscountAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboDiscountAccountIdNo.FormattingEnabled = true
        Me.cboDiscountAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboDiscountAccountIdNo.LinkedLabel = Nothing
        Me.cboDiscountAccountIdNo.Name = "cboDiscountAccountIdNo"
        Me.cboDiscountAccountIdNo.OldValue = 0
        Me.cboDiscountAccountIdNo.OriginalDataSource = Nothing
        Me.cboDiscountAccountIdNo.OriginalList = Nothing
        Me.cboDiscountAccountIdNo.OverrideDropDownStyleList = false
        Me.cboDiscountAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboDiscountAccountIdNo.PreviousSelectedIndex = 0
        Me.cboDiscountAccountIdNo.PropertySelector = Nothing
        Me.cboDiscountAccountIdNo.ReadOnlyCombo = false
        Me.cboDiscountAccountIdNo.SearchAnywhere = false
        Me.cboDiscountAccountIdNo.SuggestBoxHeight = 200
        Me.cboDiscountAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboDiscountAccountIdNo.TextToSearch = Nothing
        Me.cboDiscountAccountIdNo.ValueIsMandatory = false
        Me.cboDiscountAccountIdNo.ValueIsNullable = false
        Me.cboDiscountAccountIdNo.ValueIsNumeric = false
        Me.cboDiscountAccountIdNo.ValueMember = "IdNo"
        '
        'lblNotes
        '
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.Name = "lblNotes"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ValueIsMandatory = true
        '
        'floHeader2
        '
        Me.floHeader2.BackColor = System.Drawing.Color.Transparent
        Me.floHeader2.Controls.Add(Me.lblVatAmount)
        Me.floHeader2.Controls.Add(Me.txtVatAmount)
        Me.floHeader2.Controls.Add(Me.lblApplied)
        Me.floHeader2.Controls.Add(Me.txtApplied)
        Me.floHeader2.Controls.Add(Me.CLabel2)
        Me.floHeader2.Controls.Add(Me.txtUnapplied)
        Me.floHeader2.Controls.Add(Me.lblDiscountTaken)
        Me.floHeader2.Controls.Add(Me.txtDiscountTaken)
        Me.floHeader2.Controls.Add(Me.lblCancelled)
        Me.floHeader2.Controls.Add(Me.chkCancelled)
        Me.floHeader2.Controls.Add(Me.lblPosted)
        Me.floHeader2.Controls.Add(Me.chkPosted)
        Me.floHeader2.Controls.Add(Me.lblDateCreated)
        Me.floHeader2.Controls.Add(Me.txtDateCreated)
        Me.floPurchaseJournalHeader.SetFlowBreak(Me.floHeader2, true)
        resources.ApplyResources(Me.floHeader2, "floHeader2")
        Me.floHeader2.Name = "floHeader2"
        Me.floHeader2.TabStop = true
        '
        'lblVatAmount
        '
        resources.ApplyResources(Me.lblVatAmount, "lblVatAmount")
        Me.lblVatAmount.Name = "lblVatAmount"
        '
        'txtVatAmount
        '
        Me.txtVatAmount.BackColor = System.Drawing.Color.White
        Me.txtVatAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatAmount.ComputedValue = false
        Me.txtVatAmount.CustomFormat = "N2"
        Me.txtVatAmount.DataBoundControl = true
        Me.txtVatAmount.DisplayOnly = true
        Me.txtVatAmount.EditingMode = true
        resources.ApplyResources(Me.txtVatAmount, "txtVatAmount")
        Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
        Me.txtVatAmount.LinkedLabel = Me.lblApplied
        Me.txtVatAmount.Name = "txtVatAmount"
        Me.txtVatAmount.OldValue = Nothing
        Me.txtVatAmount.ReadOnly = true
        Me.txtVatAmount.TabStop = false
        Me.txtVatAmount.ValueIsMandatory = true
        '
        'txtApplied
        '
        Me.txtApplied.BackColor = System.Drawing.Color.White
        Me.txtApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApplied.ComputedValue = false
        Me.txtApplied.CustomFormat = "N2"
        Me.txtApplied.DataBoundControl = true
        Me.txtApplied.DisplayOnly = true
        Me.txtApplied.EditingMode = true
        resources.ApplyResources(Me.txtApplied, "txtApplied")
        Me.txtApplied.ForeColor = System.Drawing.Color.Black
        Me.txtApplied.LinkedLabel = Me.lblApplied
        Me.txtApplied.Name = "txtApplied"
        Me.txtApplied.OldValue = Nothing
        Me.txtApplied.ReadOnly = true
        Me.txtApplied.TabStop = false
        Me.txtApplied.ValueIsMandatory = true
        '
        'CLabel2
        '
        resources.ApplyResources(Me.CLabel2, "CLabel2")
        Me.CLabel2.Name = "CLabel2"
        '
        'txtUnapplied
        '
        Me.txtUnapplied.BackColor = System.Drawing.Color.White
        Me.txtUnapplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnapplied.ComputedValue = false
        Me.txtUnapplied.CustomFormat = "N2"
        Me.txtUnapplied.DataBoundControl = true
        Me.txtUnapplied.DisplayOnly = true
        Me.txtUnapplied.EditingMode = true
        Me.floHeader2.SetFlowBreak(Me.txtUnapplied, true)
        resources.ApplyResources(Me.txtUnapplied, "txtUnapplied")
        Me.txtUnapplied.ForeColor = System.Drawing.Color.Black
        Me.txtUnapplied.LinkedLabel = Me.CLabel2
        Me.txtUnapplied.Name = "txtUnapplied"
        Me.txtUnapplied.OldValue = Nothing
        Me.txtUnapplied.ReadOnly = true
        Me.txtUnapplied.TabStop = false
        Me.txtUnapplied.ValueIsMandatory = true
        '
        'lblDiscountTaken
        '
        resources.ApplyResources(Me.lblDiscountTaken, "lblDiscountTaken")
        Me.lblDiscountTaken.Name = "lblDiscountTaken"
        '
        'txtDiscountTaken
        '
        Me.txtDiscountTaken.BackColor = System.Drawing.Color.White
        Me.txtDiscountTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountTaken.ComputedValue = false
        Me.txtDiscountTaken.CustomFormat = "N2"
        Me.txtDiscountTaken.DataBoundControl = true
        Me.txtDiscountTaken.DisplayOnly = true
        Me.txtDiscountTaken.EditingMode = true
        resources.ApplyResources(Me.txtDiscountTaken, "txtDiscountTaken")
        Me.txtDiscountTaken.ForeColor = System.Drawing.Color.Black
        Me.txtDiscountTaken.LinkedLabel = Me.lblDiscountTaken
        Me.txtDiscountTaken.Name = "txtDiscountTaken"
        Me.txtDiscountTaken.OldValue = Nothing
        Me.txtDiscountTaken.ReadOnly = true
        Me.txtDiscountTaken.TabStop = false
        Me.txtDiscountTaken.ValueIsMandatory = true
        '
        'lblCancelled
        '
        resources.ApplyResources(Me.lblCancelled, "lblCancelled")
        Me.lblCancelled.Name = "lblCancelled"
        '
        'chkCancelled
        '
        resources.ApplyResources(Me.chkCancelled, "chkCancelled")
        Me.chkCancelled.AutoCheck = false
        Me.chkCancelled.BackColor = System.Drawing.Color.White
        Me.chkCancelled.DisplayOnly = true
        Me.chkCancelled.EditingMode = true
        Me.floHeader2.SetFlowBreak(Me.chkCancelled, true)
        Me.chkCancelled.ForeColor = System.Drawing.Color.Black
        Me.chkCancelled.LinkedLabel = Me.lblCancelled
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.TabStop = false
        Me.chkCancelled.UseVisualStyleBackColor = false
        '
        'lblPosted
        '
        resources.ApplyResources(Me.lblPosted, "lblPosted")
        Me.lblPosted.Name = "lblPosted"
        '
        'chkPosted
        '
        resources.ApplyResources(Me.chkPosted, "chkPosted")
        Me.chkPosted.AutoCheck = false
        Me.chkPosted.BackColor = System.Drawing.Color.White
        Me.chkPosted.DisplayOnly = true
        Me.chkPosted.EditingMode = true
        Me.floHeader2.SetFlowBreak(Me.chkPosted, true)
        Me.chkPosted.ForeColor = System.Drawing.Color.Black
        Me.chkPosted.LinkedLabel = Me.lblPosted
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.TabStop = false
        Me.chkPosted.UseVisualStyleBackColor = false
        '
        'lblDateCreated
        '
        resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
        Me.lblDateCreated.Name = "lblDateCreated"
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = false
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = true
        Me.txtDateCreated.EditingMode = false
        resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.TabStop = false
        '
        'floPurchaseJournalItems
        '
        Me.floPurchaseJournalItems.BackColor = System.Drawing.Color.Transparent
        Me.floPurchaseJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewJournalItems)
        Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewCadOiItems)
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
        Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvProfitCenterIdNo, Me.dgvNotes, Me.ItemVatAmount, Me.dgvIdNo, Me.dgvJournalIdNo, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewCheckBoxColumn1})
        Me.DataGridViewJournalItems.DataInGridChanged = false
        Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewJournalItems.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewJournalItems.DisplayOnly = false
        resources.ApplyResources(Me.DataGridViewJournalItems, "DataGridViewJournalItems")
        Me.DataGridViewJournalItems.EditingMode = false
        Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
        Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewJournalItems.StartTrackingChanges = false
        '
        'dgvSequence
        '
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSequence.DisplayOnly = true
        Me.dgvSequence.EditingMode = false
        resources.ApplyResources(Me.dgvSequence, "dgvSequence")
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        Me.dgvAccountIdNo.FillWeight = 1!
        resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvDebit
        '
        Me.dgvDebit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvDebit.DataPropertyName = "Debit"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Format = "N2"
        Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDebit.EditingMode = false
        resources.ApplyResources(Me.dgvDebit, "dgvDebit")
        Me.dgvDebit.Name = "dgvDebit"
        Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvCredit
        '
        Me.dgvCredit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCredit.DataPropertyName = "Credit"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Format = "N2"
        Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCredit.EditingMode = false
        resources.ApplyResources(Me.dgvCredit, "dgvCredit")
        Me.dgvCredit.Name = "dgvCredit"
        Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvProfitCenterIdNo
        '
        Me.dgvProfitCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvProfitCenterIdNo.DataPropertyName = "ProfitCenterIdNo"
        resources.ApplyResources(Me.dgvProfitCenterIdNo, "dgvProfitCenterIdNo")
        Me.dgvProfitCenterIdNo.Name = "dgvProfitCenterIdNo"
        Me.dgvProfitCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvNotes
        '
        Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNotes.DataPropertyName = "Notes"
        resources.ApplyResources(Me.dgvNotes, "dgvNotes")
        Me.dgvNotes.Name = "dgvNotes"
        '
        'ItemVatAmount
        '
        resources.ApplyResources(Me.ItemVatAmount, "ItemVatAmount")
        Me.ItemVatAmount.Name = "ItemVatAmount"
        '
        'dgvIdNo
        '
        Me.dgvIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvJournalIdNo
        '
        Me.dgvJournalIdNo.DataPropertyName = "JournalIdNo"
        resources.ApplyResources(Me.dgvJournalIdNo, "dgvJournalIdNo")
        Me.dgvJournalIdNo.Name = "dgvJournalIdNo"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "AccountIdNo"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn4, "DataGridViewTextBoxColumn4")
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "AccountName"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn5, "DataGridViewTextBoxColumn5")
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Cancelled"
        resources.ApplyResources(Me.DataGridViewCheckBoxColumn1, "DataGridViewCheckBoxColumn1")
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'bsJournalItems
        '
        Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
        '
        'DataGridViewCadOiItems
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewCadOiItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewCadOiItems.AutoGenerateColumns = false
        Me.DataGridViewCadOiItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCadOiItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceCadOi, Me.dgvInvoiceNo, Me.dgvTransactionDate, Me.dgvJournalCode, Me.dgvJournalIdNoJi, Me.dgvPreviousBalance, Me.dgvAmount, Me.dgvDiscountTaken, Me.dgvNewBalance, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn1, Me.CadIdNo, Me.DataGridViewTextBoxColumn3, Me.OpenInvoiceIdNo})
        Me.DataGridViewCadOiItems.DataInGridChanged = false
        Me.DataGridViewCadOiItems.DataSource = Me.bscadOiItems
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewCadOiItems.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewCadOiItems.DisplayOnly = false
        Me.DataGridViewCadOiItems.EditingMode = false
        Me.DataGridViewCadOiItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        resources.ApplyResources(Me.DataGridViewCadOiItems, "DataGridViewCadOiItems")
        Me.DataGridViewCadOiItems.Name = "DataGridViewCadOiItems"
        Me.DataGridViewCadOiItems.SequenceColumn = "dgvSequencecadOi"
        Me.DataGridViewCadOiItems.StartTrackingChanges = false
        '
        'dgvSequenceCadOi
        '
        Me.dgvSequenceCadOi.DataPropertyName = "Sequence"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.dgvSequenceCadOi.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvSequenceCadOi.EditingMode = false
        resources.ApplyResources(Me.dgvSequenceCadOi, "dgvSequenceCadOi")
        Me.dgvSequenceCadOi.Name = "dgvSequenceCadOi"
        '
        'dgvInvoiceNo
        '
        Me.dgvInvoiceNo.DataPropertyName = "InvoiceNo"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.dgvInvoiceNo.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvInvoiceNo.EditingMode = false
        resources.ApplyResources(Me.dgvInvoiceNo, "dgvInvoiceNo")
        Me.dgvInvoiceNo.Name = "dgvInvoiceNo"
        Me.dgvInvoiceNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvTransactionDate
        '
        Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvTransactionDate.EditingMode = false
        resources.ApplyResources(Me.dgvTransactionDate, "dgvTransactionDate")
        Me.dgvTransactionDate.Name = "dgvTransactionDate"
        Me.dgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvJournalCode
        '
        Me.dgvJournalCode.DataPropertyName = "JournalCode"
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        Me.dgvJournalCode.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvJournalCode.EditingMode = false
        resources.ApplyResources(Me.dgvJournalCode, "dgvJournalCode")
        Me.dgvJournalCode.Name = "dgvJournalCode"
        Me.dgvJournalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvJournalIdNoJi
        '
        Me.dgvJournalIdNoJi.DataPropertyName = "JournalIdNo"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.dgvJournalIdNoJi.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvJournalIdNoJi.EditingMode = false
        resources.ApplyResources(Me.dgvJournalIdNoJi, "dgvJournalIdNoJi")
        Me.dgvJournalIdNoJi.Name = "dgvJournalIdNoJi"
        Me.dgvJournalIdNoJi.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvPreviousBalance
        '
        Me.dgvPreviousBalance.DataPropertyName = "PreviousBalance"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.Format = "###,##0.00"
        Me.dgvPreviousBalance.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPreviousBalance.EditingMode = false
        resources.ApplyResources(Me.dgvPreviousBalance, "dgvPreviousBalance")
        Me.dgvPreviousBalance.Name = "dgvPreviousBalance"
        Me.dgvPreviousBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPreviousBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvAmount
        '
        Me.dgvAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.Format = "###,##0.00"
        Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvAmount.EditingMode = false
        resources.ApplyResources(Me.dgvAmount, "dgvAmount")
        Me.dgvAmount.Name = "dgvAmount"
        Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvDiscountTaken
        '
        Me.dgvDiscountTaken.DataPropertyName = "DiscountTaken"
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        Me.dgvDiscountTaken.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvDiscountTaken.EditingMode = false
        resources.ApplyResources(Me.dgvDiscountTaken, "dgvDiscountTaken")
        Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
        '
        'dgvNewBalance
        '
        Me.dgvNewBalance.DataPropertyName = "Balance"
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        Me.dgvNewBalance.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvNewBalance.EditingMode = false
        resources.ApplyResources(Me.dgvNewBalance, "dgvNewBalance")
        Me.dgvNewBalance.Name = "dgvNewBalance"
        Me.dgvNewBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "AccountIdNo"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'CadIdNo
        '
        Me.CadIdNo.DataPropertyName = "CadIdNo"
        resources.ApplyResources(Me.CadIdNo, "CadIdNo")
        Me.CadIdNo.Name = "CadIdNo"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "JournalItemIdNo"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn3, "DataGridViewTextBoxColumn3")
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'OpenInvoiceIdNo
        '
        Me.OpenInvoiceIdNo.DataPropertyName = "OpenInvoiceIdNo"
        resources.ApplyResources(Me.OpenInvoiceIdNo, "OpenInvoiceIdNo")
        Me.OpenInvoiceIdNo.Name = "OpenInvoiceIdNo"
        '
        'bscadOiItems
        '
        Me.bscadOiItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.CadOiItemModel)
        '
        'floFooter
        '
        Me.floFooter.BackColor = System.Drawing.Color.Transparent
        Me.floFooter.Controls.Add(Me.lblTotals)
        Me.floFooter.Controls.Add(Me.txtTotalDebits)
        Me.floFooter.Controls.Add(Me.txtTotalCredits)
        Me.floFooter.Controls.Add(Me.btnViewGL)
        resources.ApplyResources(Me.floFooter, "floFooter")
        Me.floFooter.Name = "floFooter"
        '
        'lblTotals
        '
        resources.ApplyResources(Me.lblTotals, "lblTotals")
        Me.lblTotals.Name = "lblTotals"
        '
        'txtTotalDebits
        '
        Me.txtTotalDebits.BackColor = System.Drawing.Color.White
        Me.txtTotalDebits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDebits.ComputedValue = true
        Me.txtTotalDebits.CustomFormat = "N2"
        Me.txtTotalDebits.DataBoundControl = true
        Me.txtTotalDebits.DisplayOnly = true
        Me.txtTotalDebits.EditingMode = true
        resources.ApplyResources(Me.txtTotalDebits, "txtTotalDebits")
        Me.txtTotalDebits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDebits.LinkedLabel = Me.lblTotals
        Me.txtTotalDebits.Name = "txtTotalDebits"
        Me.txtTotalDebits.OldValue = Nothing
        Me.txtTotalDebits.ReadOnly = true
        Me.txtTotalDebits.TabStop = false
        Me.txtTotalDebits.ValueIsMandatory = true
        '
        'txtTotalCredits
        '
        Me.txtTotalCredits.BackColor = System.Drawing.Color.White
        Me.txtTotalCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCredits.ComputedValue = true
        Me.txtTotalCredits.CustomFormat = "N2"
        Me.txtTotalCredits.DataBoundControl = true
        Me.txtTotalCredits.DisplayOnly = true
        Me.txtTotalCredits.EditingMode = true
        resources.ApplyResources(Me.txtTotalCredits, "txtTotalCredits")
        Me.txtTotalCredits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCredits.LinkedLabel = Me.lblTotals
        Me.txtTotalCredits.Name = "txtTotalCredits"
        Me.txtTotalCredits.OldValue = Nothing
        Me.txtTotalCredits.ReadOnly = true
        Me.txtTotalCredits.TabStop = false
        Me.txtTotalCredits.ValueIsMandatory = true
        '
        'btnViewGL
        '
        Me.btnViewGL.DesignerSelected = false
        Me.btnViewGL.DisplayOnly = true
        resources.ApplyResources(Me.btnViewGL, "btnViewGL")
        Me.btnViewGL.ImageIndex = 0
        Me.btnViewGL.Name = "btnViewGL"
        Me.btnViewGL.OriginalImageName = Nothing
        Me.btnViewGL.SecurityKey = ""
        '
        'CashDisbursementJournalEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floFullEntryArea)
        Me.Name = "CashDisbursementJournalEntry"
        Me.SecurityPresenterObj = SecurityPresenter1
        Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floFullEntryArea.ResumeLayout(false)
        Me.floPurchaseJournalHeader.ResumeLayout(false)
        Me.floHeader1.ResumeLayout(false)
        Me.floHeader1.PerformLayout
        Me.floHeader2.ResumeLayout(false)
        Me.floHeader2.PerformLayout
        Me.floPurchaseJournalItems.ResumeLayout(false)
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewCadOiItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bscadOiItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.floFooter.ResumeLayout(false)
        Me.floFooter.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents floFullEntryArea As CFlowLayout
        Friend WithEvents floPurchaseJournalHeader As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents txtJournalCode As CTextBox
        Friend WithEvents TxtIDNo As CTextBox
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblInvoiceNo As CLabel
        Friend WithEvents txtORNumber As CTextBox
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblPaymentType As CLabel
        Friend WithEvents lblSupplierIdNo As CLabel
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floPurchaseJournalItems As CFlowLayout
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents floFooter As CFlowLayout
        Friend WithEvents lblTotals As CLabel
        Friend WithEvents txtTotalDebits As CTextBox
        Friend WithEvents txtTotalCredits As CTextBox
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents chkCancelled As CCheckBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents cboPaymentType As CaComboBox
        Friend WithEvents lblDiscountTaken As CLabel
        Friend WithEvents txtDiscountTaken As CTextBox
        Friend WithEvents lblApplied As CLabel
        Friend WithEvents txtApplied As CTextBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents txtUnapplied As CTextBox
        Friend WithEvents lblDiscountAccountIdNo As CLabel
        Friend WithEvents cboDiscountAccountIdNo As CaComboBox
        Friend WithEvents txtPayeeName As CTextBox
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblVatNo As CLabel
        Friend WithEvents txtVatNumber As CTextBox
        Friend WithEvents floHeader1 As CFlowLayout
        Friend WithEvents floHeader2 As CFlowLayout
        Friend WithEvents lblVatAmount As CLabel
        Friend WithEvents txtVatAmount As CTextBox
        Friend WithEvents txtDateCreated As CTextBox
        Friend WithEvents cboPayeeIdNo As CaComboBox
        Friend WithEvents DataGridViewCadOiItems As CDataGridView
        Friend WithEvents bscadOiItems As Windows.Forms.BindingSource
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents DiscountTakenDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OriginalAmountDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PaidAmountDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PayeeTypeDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SpecialAccountDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNocadOi As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvJournalItemIdNo As CdgvColumnText
        Friend WithEvents dgvcadIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btnViewGL As CButton
        Friend WithEvents AccountIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CkdIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CdgvColumnText
        Friend WithEvents dgvSequenceCadOi As CdgvColumnText
        Friend WithEvents dgvInvoiceNo As CdgvColumnText
        Friend WithEvents dgvTransactionDate As CdgvColumnText
        Friend WithEvents dgvJournalCode As CdgvColumnText
        Friend WithEvents dgvJournalIdNoJi As CdgvColumnText
        Friend WithEvents dgvPreviousBalance As CdgvColumnMoney
        Friend WithEvents dgvAmount As CdgvColumnMoney
        Friend WithEvents dgvDiscountTaken As CdgvColumnText
        Friend WithEvents dgvNewBalance As CdgvColumnText
        Friend WithEvents DataGridViewTextBoxColumn2 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CadIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvColumnMoney
        Friend WithEvents dgvCredit As CdgvColumnMoney
        Friend WithEvents dgvProfitCenterIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvNotes As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ItemVatAmount As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As CdgvColumnText
        Friend WithEvents dgvJournalIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
    End Class
End Namespace