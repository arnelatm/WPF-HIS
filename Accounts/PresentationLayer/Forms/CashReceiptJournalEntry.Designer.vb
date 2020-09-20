Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms
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
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator2 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.floFullEntryArea = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.floPurchaseJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.floHeader1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
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
            Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCheckDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpCheckDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
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
            Me.lblCancelled = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpDateCreated = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.floPurchaseJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvNotesDescription = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
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
            Me.dgvSequenceCsrOi = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvJournalCode = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvJournalIdNoAp = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPreviousBalance = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvBalance = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.AccountIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsCsrOiItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.floFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floFullEntryArea.SuspendLayout()
            Me.floPurchaseJournalHeader.SuspendLayout()
            Me.floHeader1.SuspendLayout()
            Me.floHeader2.SuspendLayout()
            Me.floPurchaseJournalItems.SuspendLayout()
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewCsrOiItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsCsrOiItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floFooter.SuspendLayout()
            Me.SuspendLayout()
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
            resources.ApplyResources(Me.floFullEntryArea, "floFullEntryArea")
            Me.floFullEntryArea.Name = "floFullEntryArea"
            '
            'floPurchaseJournalHeader
            '
            Me.floPurchaseJournalHeader.BackColor = System.Drawing.Color.Transparent
            Me.floPurchaseJournalHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floPurchaseJournalHeader.Controls.Add(Me.floHeader1)
            Me.floPurchaseJournalHeader.Controls.Add(Me.floHeader2)
            Me.floFullEntryArea.SetFlowBreak(Me.floPurchaseJournalHeader, True)
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
            Me.floHeader1.TabStop = True
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'txtJournalCode
            '
            Me.txtJournalCode.BackColor = System.Drawing.Color.White
            Me.txtJournalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtJournalCode.ComputedValue = True
            Me.txtJournalCode.CustomFormat = Nothing
            Me.txtJournalCode.DataBoundControl = True
            Me.txtJournalCode.DisplayOnly = True
            Me.txtJournalCode.EditingMode = True
            resources.ApplyResources(Me.txtJournalCode, "txtJournalCode")
            Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
            Me.txtJournalCode.LinkedLabel = Nothing
            Me.txtJournalCode.MaximumValue = Nothing
            Me.txtJournalCode.MinimumValue = Nothing
            Me.txtJournalCode.Name = "txtJournalCode"
            Me.txtJournalCode.OldValue = Nothing
            Me.txtJournalCode.ReadOnly = True
            Me.txtJournalCode.TabStop = False
            Me.txtJournalCode.ValueIsMandatory = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = True
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblReferenceNo
            '
            Me.lblReferenceNo.DisplayOnly = True
            Me.lblReferenceNo.EditingMode = False
            resources.ApplyResources(Me.lblReferenceNo, "lblReferenceNo")
            Me.lblReferenceNo.Name = "lblReferenceNo"
            '
            'txtReferenceNo
            '
            Me.txtReferenceNo.BackColor = System.Drawing.Color.White
            Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReferenceNo.ComputedValue = False
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            Me.txtReferenceNo.EditingMode = False
            resources.ApplyResources(Me.txtReferenceNo, "txtReferenceNo")
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.ReadOnly = True
            Me.txtReferenceNo.ValueIsMandatory = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            resources.ApplyResources(Me.lblTransactionDate, "lblTransactionDate")
            Me.lblTransactionDate.Name = "lblTransactionDate"
            '
            'dtpTransactionDate
            '
            Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpTransactionDate.DefaultValue = Nothing
            Me.dtpTransactionDate.DisplayOnly = False
            Me.dtpTransactionDate.DtpDefaultValue = Nothing
            Me.dtpTransactionDate.EditingMode = False
            Me.dtpTransactionDate.EditsAllowed = False
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            resources.ApplyResources(Me.dtpTransactionDate, "dtpTransactionDate")
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.TargetCalendar = Nothing
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'lblInvoiceDate
            '
            Me.lblInvoiceDate.DisplayOnly = True
            Me.lblInvoiceDate.EditingMode = False
            resources.ApplyResources(Me.lblInvoiceDate, "lblInvoiceDate")
            Me.lblInvoiceDate.Name = "lblInvoiceDate"
            '
            'cboPayorType
            '
            Me.cboPayorType.BackColor = System.Drawing.Color.White
            Me.cboPayorType.ChangingSearchValueOnly = False
            Me.cboPayorType.CurrentSearchTerm = ""
            Me.cboPayorType.DefaultValue = "0"
            Me.cboPayorType.DisplayMember = "Name"
            Me.cboPayorType.DropDownHeight = 1
            Me.cboPayorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPayorType.EditingMode = False
            Me.cboPayorType.FilterRule = Nothing
            resources.ApplyResources(Me.cboPayorType, "cboPayorType")
            Me.cboPayorType.ForeColor = System.Drawing.Color.Black
            Me.cboPayorType.HideWhenNotEditingOrAdding = False
            Me.cboPayorType.LinkedLabel = Nothing
            Me.cboPayorType.Name = "cboPayorType"
            Me.cboPayorType.OldValue = 0
            Me.cboPayorType.OriginalDataSource = Nothing
            Me.cboPayorType.OriginalList = Nothing
            Me.cboPayorType.OverrideDropDownStyleList = False
            Me.cboPayorType.PreviousSearchTerm = Nothing
            Me.cboPayorType.PreviousSelectedIndex = 0
            Me.cboPayorType.PropertySelector = Nothing
            Me.cboPayorType.ReadOnlyCombo = False
            Me.cboPayorType.SearchAnywhere = False
            Me.cboPayorType.SuggestBoxHeight = 200
            Me.cboPayorType.SuggestListOrderRule = Nothing
            Me.cboPayorType.TextToSearch = Nothing
            Me.cboPayorType.ValueIsMandatory = False
            Me.cboPayorType.ValueIsNullable = False
            Me.cboPayorType.ValueIsNumeric = False
            Me.cboPayorType.ValueMember = "Code"
            '
            'lblSupplierIdNo
            '
            Me.lblSupplierIdNo.DisplayOnly = True
            Me.lblSupplierIdNo.EditingMode = False
            resources.ApplyResources(Me.lblSupplierIdNo, "lblSupplierIdNo")
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            '
            'cboPayorIdNo
            '
            Me.cboPayorIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPayorIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayorIdNo.ChangingSearchValueOnly = False
            Me.cboPayorIdNo.CurrentSearchTerm = ""
            Me.cboPayorIdNo.DefaultValue = Nothing
            Me.cboPayorIdNo.DisplayMember = "Name"
            Me.cboPayorIdNo.DropDownHeight = 1
            Me.cboPayorIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPayorIdNo.EditingMode = False
            Me.cboPayorIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cboPayorIdNo, "cboPayorIdNo")
            Me.cboPayorIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayorIdNo.FormattingEnabled = True
            Me.cboPayorIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayorIdNo.LinkedLabel = Me.lblSupplierIdNo
            Me.cboPayorIdNo.Name = "cboPayorIdNo"
            Me.cboPayorIdNo.OldValue = 0
            Me.cboPayorIdNo.OriginalDataSource = Nothing
            Me.cboPayorIdNo.OriginalList = Nothing
            Me.cboPayorIdNo.OverrideDropDownStyleList = False
            Me.cboPayorIdNo.PreviousSearchTerm = Nothing
            Me.cboPayorIdNo.PreviousSelectedIndex = -1
            Me.cboPayorIdNo.PropertySelector = Nothing
            Me.cboPayorIdNo.ReadOnlyCombo = False
            Me.cboPayorIdNo.SearchAnywhere = False
            Me.cboPayorIdNo.SuggestBoxHeight = 200
            Me.cboPayorIdNo.SuggestListOrderRule = Nothing
            Me.cboPayorIdNo.TextToSearch = Nothing
            Me.cboPayorIdNo.ValueIsMandatory = False
            Me.cboPayorIdNo.ValueIsNullable = False
            Me.cboPayorIdNo.ValueIsNumeric = False
            Me.cboPayorIdNo.ValueMember = "IdNo"
            '
            'txtPayorName
            '
            Me.txtPayorName.BackColor = System.Drawing.Color.White
            Me.txtPayorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayorName.ComputedValue = False
            Me.txtPayorName.CustomFormat = Nothing
            Me.txtPayorName.DataBoundControl = True
            Me.txtPayorName.EditingMode = False
            Me.floHeader1.SetFlowBreak(Me.txtPayorName, True)
            resources.ApplyResources(Me.txtPayorName, "txtPayorName")
            Me.txtPayorName.ForeColor = System.Drawing.Color.Black
            Me.txtPayorName.LinkedLabel = Me.lblAmount
            Me.txtPayorName.MaximumValue = Nothing
            Me.txtPayorName.MinimumValue = Nothing
            Me.txtPayorName.Name = "txtPayorName"
            Me.txtPayorName.OldValue = Nothing
            Me.txtPayorName.ReadOnly = True
            Me.txtPayorName.ValueIsMandatory = True
            '
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            resources.ApplyResources(Me.lblAmount, "lblAmount")
            Me.lblAmount.Name = "lblAmount"
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = ""
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.DropDownHeight = 1
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.FilterRule = Nothing
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PreviousSelectedIndex = 0
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.SearchAnywhere = False
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = "N2"
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = False
            resources.ApplyResources(Me.txtAmount, "txtAmount")
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblDiscountAccountIdNo
            '
            Me.lblDiscountAccountIdNo.DisplayOnly = True
            Me.lblDiscountAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblDiscountAccountIdNo, "lblDiscountAccountIdNo")
            Me.lblDiscountAccountIdNo.Name = "lblDiscountAccountIdNo"
            '
            'cboDiscountAccountIdNo
            '
            Me.cboDiscountAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboDiscountAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboDiscountAccountIdNo.ChangingSearchValueOnly = False
            Me.cboDiscountAccountIdNo.CurrentSearchTerm = ""
            Me.cboDiscountAccountIdNo.DefaultValue = Nothing
            Me.cboDiscountAccountIdNo.DisplayMember = "Name"
            Me.cboDiscountAccountIdNo.DropDownHeight = 1
            Me.cboDiscountAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboDiscountAccountIdNo.EditingMode = False
            Me.cboDiscountAccountIdNo.FilterRule = Nothing
            Me.floHeader1.SetFlowBreak(Me.cboDiscountAccountIdNo, True)
            resources.ApplyResources(Me.cboDiscountAccountIdNo, "cboDiscountAccountIdNo")
            Me.cboDiscountAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboDiscountAccountIdNo.FormattingEnabled = True
            Me.cboDiscountAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboDiscountAccountIdNo.LinkedLabel = Nothing
            Me.cboDiscountAccountIdNo.Name = "cboDiscountAccountIdNo"
            Me.cboDiscountAccountIdNo.OldValue = 0
            Me.cboDiscountAccountIdNo.OriginalDataSource = Nothing
            Me.cboDiscountAccountIdNo.OriginalList = Nothing
            Me.cboDiscountAccountIdNo.OverrideDropDownStyleList = False
            Me.cboDiscountAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboDiscountAccountIdNo.PreviousSelectedIndex = 0
            Me.cboDiscountAccountIdNo.PropertySelector = Nothing
            Me.cboDiscountAccountIdNo.ReadOnlyCombo = False
            Me.cboDiscountAccountIdNo.SearchAnywhere = False
            Me.cboDiscountAccountIdNo.SuggestBoxHeight = 200
            Me.cboDiscountAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboDiscountAccountIdNo.TextToSearch = Nothing
            Me.cboDiscountAccountIdNo.ValueIsMandatory = False
            Me.cboDiscountAccountIdNo.ValueIsNullable = False
            Me.cboDiscountAccountIdNo.ValueIsNumeric = False
            Me.cboDiscountAccountIdNo.ValueMember = "IdNo"
            '
            'lblCheckNumber
            '
            Me.lblCheckNumber.DisplayOnly = True
            Me.lblCheckNumber.EditingMode = False
            resources.ApplyResources(Me.lblCheckNumber, "lblCheckNumber")
            Me.lblCheckNumber.Name = "lblCheckNumber"
            '
            'txtCheckNumber
            '
            Me.txtCheckNumber.BackColor = System.Drawing.Color.White
            Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCheckNumber.ComputedValue = False
            Me.txtCheckNumber.CustomFormat = Nothing
            Me.txtCheckNumber.DataBoundControl = True
            Me.txtCheckNumber.EditingMode = False
            resources.ApplyResources(Me.txtCheckNumber, "txtCheckNumber")
            Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
            Me.txtCheckNumber.LinkedLabel = Me.lblCheckNumber
            Me.txtCheckNumber.MaximumValue = Nothing
            Me.txtCheckNumber.MinimumValue = Nothing
            Me.txtCheckNumber.Name = "txtCheckNumber"
            Me.txtCheckNumber.OldValue = Nothing
            Me.txtCheckNumber.ReadOnly = True
            Me.txtCheckNumber.ValueIsMandatory = True
            '
            'lblCheckDate
            '
            Me.lblCheckDate.DisplayOnly = True
            Me.lblCheckDate.EditingMode = False
            resources.ApplyResources(Me.lblCheckDate, "lblCheckDate")
            Me.lblCheckDate.Name = "lblCheckDate"
            '
            'dtpCheckDate
            '
            Me.dtpCheckDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpCheckDate.DefaultValue = Nothing
            Me.dtpCheckDate.DisplayOnly = False
            Me.dtpCheckDate.DtpDefaultValue = Nothing
            Me.dtpCheckDate.EditingMode = False
            Me.dtpCheckDate.EditsAllowed = False
            Me.dtpCheckDate.ForeColor = System.Drawing.Color.Black
            Me.dtpCheckDate.LinkedLabel = Nothing
            resources.ApplyResources(Me.dtpCheckDate, "dtpCheckDate")
            Me.dtpCheckDate.Name = "dtpCheckDate"
            Me.dtpCheckDate.ReadOnlyDp = False
            Me.dtpCheckDate.SecurityKey = Nothing
            Me.dtpCheckDate.ShowLongDate = False
            Me.dtpCheckDate.ShowTime = False
            Me.dtpCheckDate.TargetCalendar = Nothing
            Me.dtpCheckDate.Value = Nothing
            Me.dtpCheckDate.ValueIsMandatory = False
            Me.dtpCheckDate.ValueIsNullable = False
            '
            'lblInvoiceNo
            '
            Me.lblInvoiceNo.DisplayOnly = True
            Me.lblInvoiceNo.EditingMode = False
            resources.ApplyResources(Me.lblInvoiceNo, "lblInvoiceNo")
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            '
            'txtORNumber
            '
            Me.txtORNumber.BackColor = System.Drawing.Color.White
            Me.txtORNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtORNumber.ComputedValue = False
            Me.txtORNumber.CustomFormat = Nothing
            Me.txtORNumber.DataBoundControl = True
            Me.txtORNumber.EditingMode = False
            resources.ApplyResources(Me.txtORNumber, "txtORNumber")
            Me.txtORNumber.ForeColor = System.Drawing.Color.Black
            Me.txtORNumber.LinkedLabel = Me.lblInvoiceNo
            Me.txtORNumber.MaximumValue = Nothing
            Me.txtORNumber.MinimumValue = Nothing
            Me.txtORNumber.Name = "txtORNumber"
            Me.txtORNumber.OldValue = Nothing
            Me.txtORNumber.ReadOnly = True
            Me.txtORNumber.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.ValueIsMandatory = True
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
            Me.floHeader2.Controls.Add(Me.lblCancelled)
            Me.floHeader2.Controls.Add(Me.chkCancelled)
            Me.floHeader2.Controls.Add(Me.lblPosted)
            Me.floHeader2.Controls.Add(Me.chkPosted)
            Me.floHeader2.Controls.Add(Me.lblDateCreated)
            Me.floHeader2.Controls.Add(Me.dtpDateCreated)
            Me.floPurchaseJournalHeader.SetFlowBreak(Me.floHeader2, True)
            resources.ApplyResources(Me.floHeader2, "floHeader2")
            Me.floHeader2.Name = "floHeader2"
            Me.floHeader2.TabStop = True
            '
            'lblApplied
            '
            Me.lblApplied.DisplayOnly = True
            Me.lblApplied.EditingMode = False
            resources.ApplyResources(Me.lblApplied, "lblApplied")
            Me.lblApplied.Name = "lblApplied"
            '
            'txtApplied
            '
            Me.txtApplied.BackColor = System.Drawing.Color.White
            Me.txtApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtApplied.ComputedValue = False
            Me.txtApplied.CustomFormat = "N2"
            Me.txtApplied.DataBoundControl = True
            Me.txtApplied.DisplayOnly = True
            Me.txtApplied.EditingMode = True
            resources.ApplyResources(Me.txtApplied, "txtApplied")
            Me.txtApplied.ForeColor = System.Drawing.Color.Black
            Me.txtApplied.LinkedLabel = Me.lblApplied
            Me.txtApplied.MaximumValue = Nothing
            Me.txtApplied.MinimumValue = Nothing
            Me.txtApplied.Name = "txtApplied"
            Me.txtApplied.OldValue = Nothing
            Me.txtApplied.ReadOnly = True
            Me.txtApplied.ValueIsMandatory = True
            Me.txtApplied.ValueIsNumeric = True
            '
            'lblUnapplied
            '
            Me.lblUnapplied.DisplayOnly = True
            Me.lblUnapplied.EditingMode = False
            resources.ApplyResources(Me.lblUnapplied, "lblUnapplied")
            Me.lblUnapplied.Name = "lblUnapplied"
            '
            'txtUnapplied
            '
            Me.txtUnapplied.BackColor = System.Drawing.Color.White
            Me.txtUnapplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnapplied.ComputedValue = False
            Me.txtUnapplied.CustomFormat = "N2"
            Me.txtUnapplied.DataBoundControl = True
            Me.txtUnapplied.DisplayOnly = True
            Me.txtUnapplied.EditingMode = True
            Me.floHeader2.SetFlowBreak(Me.txtUnapplied, True)
            resources.ApplyResources(Me.txtUnapplied, "txtUnapplied")
            Me.txtUnapplied.ForeColor = System.Drawing.Color.Black
            Me.txtUnapplied.LinkedLabel = Me.lblUnapplied
            Me.txtUnapplied.MaximumValue = Nothing
            Me.txtUnapplied.MinimumValue = Nothing
            Me.txtUnapplied.Name = "txtUnapplied"
            Me.txtUnapplied.OldValue = Nothing
            Me.txtUnapplied.ReadOnly = True
            Me.txtUnapplied.ValueIsMandatory = True
            Me.txtUnapplied.ValueIsNumeric = True
            '
            'lblDiscountTaken
            '
            Me.lblDiscountTaken.DisplayOnly = True
            Me.lblDiscountTaken.EditingMode = False
            resources.ApplyResources(Me.lblDiscountTaken, "lblDiscountTaken")
            Me.lblDiscountTaken.Name = "lblDiscountTaken"
            '
            'txtDiscountTaken
            '
            Me.txtDiscountTaken.BackColor = System.Drawing.Color.White
            Me.txtDiscountTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDiscountTaken.ComputedValue = False
            Me.txtDiscountTaken.CustomFormat = "N2"
            Me.txtDiscountTaken.DataBoundControl = True
            Me.txtDiscountTaken.DisplayOnly = True
            Me.txtDiscountTaken.EditingMode = True
            resources.ApplyResources(Me.txtDiscountTaken, "txtDiscountTaken")
            Me.txtDiscountTaken.ForeColor = System.Drawing.Color.Black
            Me.txtDiscountTaken.LinkedLabel = Me.lblDiscountTaken
            Me.txtDiscountTaken.MaximumValue = Nothing
            Me.txtDiscountTaken.MinimumValue = Nothing
            Me.txtDiscountTaken.Name = "txtDiscountTaken"
            Me.txtDiscountTaken.OldValue = Nothing
            Me.txtDiscountTaken.ReadOnly = True
            Me.txtDiscountTaken.ValueIsMandatory = True
            Me.txtDiscountTaken.ValueIsNumeric = True
            '
            'lblCancelled
            '
            Me.lblCancelled.DisplayOnly = True
            Me.lblCancelled.EditingMode = False
            resources.ApplyResources(Me.lblCancelled, "lblCancelled")
            Me.lblCancelled.Name = "lblCancelled"
            '
            'chkCancelled
            '
            resources.ApplyResources(Me.chkCancelled, "chkCancelled")
            Me.chkCancelled.AutoCheck = False
            Me.chkCancelled.BackColor = System.Drawing.Color.White
            Me.chkCancelled.DisplayOnly = True
            Me.chkCancelled.EditingMode = True
            Me.floHeader2.SetFlowBreak(Me.chkCancelled, True)
            Me.chkCancelled.ForeColor = System.Drawing.Color.Black
            Me.chkCancelled.LinkedLabel = Me.lblCancelled
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.OldValue = Nothing
            Me.chkCancelled.UseVisualStyleBackColor = False
            '
            'lblPosted
            '
            Me.lblPosted.DisplayOnly = True
            Me.lblPosted.EditingMode = False
            resources.ApplyResources(Me.lblPosted, "lblPosted")
            Me.lblPosted.Name = "lblPosted"
            '
            'chkPosted
            '
            resources.ApplyResources(Me.chkPosted, "chkPosted")
            Me.chkPosted.AutoCheck = False
            Me.chkPosted.BackColor = System.Drawing.Color.White
            Me.chkPosted.DisplayOnly = True
            Me.chkPosted.EditingMode = True
            Me.floHeader2.SetFlowBreak(Me.chkPosted, True)
            Me.chkPosted.ForeColor = System.Drawing.Color.Black
            Me.chkPosted.LinkedLabel = Me.lblPosted
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.OldValue = Nothing
            Me.chkPosted.UseVisualStyleBackColor = False
            '
            'lblDateCreated
            '
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
            Me.lblDateCreated.Name = "lblDateCreated"
            '
            'dtpDateCreated
            '
            Me.dtpDateCreated.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpDateCreated.DefaultValue = Nothing
            Me.dtpDateCreated.DisplayOnly = True
            Me.dtpDateCreated.DtpDefaultValue = Nothing
            Me.dtpDateCreated.EditingMode = False
            Me.dtpDateCreated.EditsAllowed = False
            Me.dtpDateCreated.ForeColor = System.Drawing.Color.Black
            Me.dtpDateCreated.LinkedLabel = Nothing
            resources.ApplyResources(Me.dtpDateCreated, "dtpDateCreated")
            Me.dtpDateCreated.Name = "dtpDateCreated"
            Me.dtpDateCreated.ReadOnlyDp = True
            Me.dtpDateCreated.SecurityKey = Nothing
            Me.dtpDateCreated.ShowLongDate = False
            Me.dtpDateCreated.ShowTime = True
            Me.dtpDateCreated.TargetCalendar = Nothing
            Me.dtpDateCreated.Value = Nothing
            Me.dtpDateCreated.ValueIsMandatory = False
            Me.dtpDateCreated.ValueIsNullable = False
            '
            'floPurchaseJournalItems
            '
            Me.floPurchaseJournalItems.BackColor = System.Drawing.Color.Transparent
            Me.floPurchaseJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewJournalItems)
            Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewCsrOiItems)
            Me.floFullEntryArea.SetFlowBreak(Me.floPurchaseJournalItems, True)
            resources.ApplyResources(Me.floPurchaseJournalItems, "floPurchaseJournalItems")
            Me.floPurchaseJournalItems.Name = "floPurchaseJournalItems"
            Me.floPurchaseJournalItems.TabStop = True
            '
            'DataGridViewJournalItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewJournalItems.AutoGenerateColumns = False
            Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotesDescription, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn1, Me.DiscountTakenDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn1, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PaidAmountDataGridViewTextBoxColumn, Me.PayeeTypeDataGridViewTextBoxColumn, Me.SpecialAccountDataGridViewTextBoxColumn})
            Me.DataGridViewJournalItems.DataInGridChanged = False
            Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewJournalItems.DefaultCellStyle = DataGridViewCellStyle6
            Me.DataGridViewJournalItems.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewJournalItems, "DataGridViewJournalItems")
            Me.DataGridViewJournalItems.Ea = EventAggregator1
            Me.DataGridViewJournalItems.EditingMode = False
            Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewJournalItems.FirstRowDeletionEnabled = False
            Me.DataGridViewJournalItems.FirstRowInsertionEnabled = False
            Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
            Me.DataGridViewJournalItems.ReadOnly = True
            Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = True
            Me.DataGridViewJournalItems.StartTrackingChanges = False
            '
            'dgvSequence
            '
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
            Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
            Me.dgvAccountIdNo.ReadOnly = True
            Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAccountIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvDebit
            '
            Me.dgvDebit.DataPropertyName = "Debit"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle3.Format = "###,##0.00"
            Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvDebit.EditingMode = False
            resources.ApplyResources(Me.dgvDebit, "dgvDebit")
            Me.dgvDebit.Name = "dgvDebit"
            Me.dgvDebit.ReadOnly = True
            Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvCredit
            '
            Me.dgvCredit.DataPropertyName = "Credit"
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.Format = "###,##0.00"
            Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvCredit.EditingMode = False
            resources.ApplyResources(Me.dgvCredit, "dgvCredit")
            Me.dgvCredit.Name = "dgvCredit"
            Me.dgvCredit.ReadOnly = True
            Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
            resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
            Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.ReadOnly = True
            Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvRevCostCenterIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvNotesDescription
            '
            Me.dgvNotesDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvNotesDescription.DataPropertyName = "Notes"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvNotesDescription.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvNotesDescription.EditingMode = False
            resources.ApplyResources(Me.dgvNotesDescription, "dgvNotesDescription")
            Me.dgvNotesDescription.Name = "dgvNotesDescription"
            Me.dgvNotesDescription.ReadOnly = True
            Me.dgvNotesDescription.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'AccountNameDataGridViewTextBoxColumn
            '
            Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
            resources.ApplyResources(Me.AccountNameDataGridViewTextBoxColumn, "AccountNameDataGridViewTextBoxColumn")
            Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
            Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CancelledDataGridViewCheckBoxColumn1
            '
            Me.CancelledDataGridViewCheckBoxColumn1.DataPropertyName = "Cancelled"
            resources.ApplyResources(Me.CancelledDataGridViewCheckBoxColumn1, "CancelledDataGridViewCheckBoxColumn1")
            Me.CancelledDataGridViewCheckBoxColumn1.Name = "CancelledDataGridViewCheckBoxColumn1"
            Me.CancelledDataGridViewCheckBoxColumn1.ReadOnly = True
            '
            'DiscountTakenDataGridViewTextBoxColumn
            '
            Me.DiscountTakenDataGridViewTextBoxColumn.DataPropertyName = "DiscountTaken"
            resources.ApplyResources(Me.DiscountTakenDataGridViewTextBoxColumn, "DiscountTakenDataGridViewTextBoxColumn")
            Me.DiscountTakenDataGridViewTextBoxColumn.Name = "DiscountTakenDataGridViewTextBoxColumn"
            Me.DiscountTakenDataGridViewTextBoxColumn.ReadOnly = True
            '
            'IdNoDataGridViewTextBoxColumn1
            '
            Me.IdNoDataGridViewTextBoxColumn1.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn1, "IdNoDataGridViewTextBoxColumn1")
            Me.IdNoDataGridViewTextBoxColumn1.Name = "IdNoDataGridViewTextBoxColumn1"
            Me.IdNoDataGridViewTextBoxColumn1.ReadOnly = True
            '
            'JournalIdNoDataGridViewTextBoxColumn
            '
            Me.JournalIdNoDataGridViewTextBoxColumn.DataPropertyName = "JournalIdNo"
            resources.ApplyResources(Me.JournalIdNoDataGridViewTextBoxColumn, "JournalIdNoDataGridViewTextBoxColumn")
            Me.JournalIdNoDataGridViewTextBoxColumn.Name = "JournalIdNoDataGridViewTextBoxColumn"
            Me.JournalIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'OpenInvoiceIdNoDataGridViewTextBoxColumn1
            '
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1.DataPropertyName = "OpenInvoiceIdNo"
            resources.ApplyResources(Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1, "OpenInvoiceIdNoDataGridViewTextBoxColumn1")
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1.Name = "OpenInvoiceIdNoDataGridViewTextBoxColumn1"
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn1.ReadOnly = True
            '
            'OriginalAmountDataGridViewTextBoxColumn
            '
            Me.OriginalAmountDataGridViewTextBoxColumn.DataPropertyName = "OriginalAmount"
            resources.ApplyResources(Me.OriginalAmountDataGridViewTextBoxColumn, "OriginalAmountDataGridViewTextBoxColumn")
            Me.OriginalAmountDataGridViewTextBoxColumn.Name = "OriginalAmountDataGridViewTextBoxColumn"
            Me.OriginalAmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PaidAmountDataGridViewTextBoxColumn
            '
            Me.PaidAmountDataGridViewTextBoxColumn.DataPropertyName = "PaidAmount"
            resources.ApplyResources(Me.PaidAmountDataGridViewTextBoxColumn, "PaidAmountDataGridViewTextBoxColumn")
            Me.PaidAmountDataGridViewTextBoxColumn.Name = "PaidAmountDataGridViewTextBoxColumn"
            Me.PaidAmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PayeeTypeDataGridViewTextBoxColumn
            '
            Me.PayeeTypeDataGridViewTextBoxColumn.DataPropertyName = "PayeeType"
            resources.ApplyResources(Me.PayeeTypeDataGridViewTextBoxColumn, "PayeeTypeDataGridViewTextBoxColumn")
            Me.PayeeTypeDataGridViewTextBoxColumn.Name = "PayeeTypeDataGridViewTextBoxColumn"
            Me.PayeeTypeDataGridViewTextBoxColumn.ReadOnly = True
            '
            'SpecialAccountDataGridViewTextBoxColumn
            '
            Me.SpecialAccountDataGridViewTextBoxColumn.DataPropertyName = "SpecialAccount"
            resources.ApplyResources(Me.SpecialAccountDataGridViewTextBoxColumn, "SpecialAccountDataGridViewTextBoxColumn")
            Me.SpecialAccountDataGridViewTextBoxColumn.Name = "SpecialAccountDataGridViewTextBoxColumn"
            Me.SpecialAccountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'bsJournalItems
            '
            Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
            '
            'DataGridViewCsrOiItems
            '
            Me.DataGridViewCsrOiItems.AllowUserToAddRows = False
            Me.DataGridViewCsrOiItems.AllowUserToDeleteRows = False
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewCsrOiItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridViewCsrOiItems.AutoGenerateColumns = False
            Me.DataGridViewCsrOiItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewCsrOiItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceCsrOi, Me.dgvInvoiceNo, Me.dgvTransactionDate, Me.dgvJournalCode, Me.dgvJournalIdNoAp, Me.dgvPreviousBalance, Me.dgvAmount, Me.dgvDiscountTaken, Me.dgvBalance, Me.AccountIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn})
            Me.DataGridViewCsrOiItems.DataInGridChanged = False
            Me.DataGridViewCsrOiItems.DataSource = Me.bsCsrOiItems
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewCsrOiItems.DefaultCellStyle = DataGridViewCellStyle17
            Me.DataGridViewCsrOiItems.DisplayOnly = False
            Me.DataGridViewCsrOiItems.Ea = EventAggregator2
            Me.DataGridViewCsrOiItems.EditingMode = False
            Me.DataGridViewCsrOiItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewCsrOiItems.FirstRowDeletionEnabled = False
            Me.DataGridViewCsrOiItems.FirstRowInsertionEnabled = False
            resources.ApplyResources(Me.DataGridViewCsrOiItems, "DataGridViewCsrOiItems")
            Me.DataGridViewCsrOiItems.Name = "DataGridViewCsrOiItems"
            Me.DataGridViewCsrOiItems.ReadOnly = True
            Me.DataGridViewCsrOiItems.SequenceColumn = "dgvSequenceCsrOi"
            Me.DataGridViewCsrOiItems.ShowInsertColumnWhenEditing = False
            Me.DataGridViewCsrOiItems.StartTrackingChanges = False
            '
            'dgvSequenceCsrOi
            '
            Me.dgvSequenceCsrOi.DataPropertyName = "Sequence"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceCsrOi.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvSequenceCsrOi.DisplayOnly = True
            Me.dgvSequenceCsrOi.EditingMode = False
            resources.ApplyResources(Me.dgvSequenceCsrOi, "dgvSequenceCsrOi")
            Me.dgvSequenceCsrOi.Name = "dgvSequenceCsrOi"
            Me.dgvSequenceCsrOi.ReadOnly = True
            Me.dgvSequenceCsrOi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'dgvInvoiceNo
            '
            Me.dgvInvoiceNo.DataPropertyName = "InvoiceNo"
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvInvoiceNo.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvInvoiceNo.DisplayOnly = True
            Me.dgvInvoiceNo.EditingMode = False
            resources.ApplyResources(Me.dgvInvoiceNo, "dgvInvoiceNo")
            Me.dgvInvoiceNo.Name = "dgvInvoiceNo"
            Me.dgvInvoiceNo.ReadOnly = True
            '
            'dgvTransactionDate
            '
            Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvTransactionDate.DisplayOnly = True
            Me.dgvTransactionDate.EditingMode = False
            resources.ApplyResources(Me.dgvTransactionDate, "dgvTransactionDate")
            Me.dgvTransactionDate.Name = "dgvTransactionDate"
            Me.dgvTransactionDate.ReadOnly = True
            Me.dgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvTransactionDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'dgvJournalCode
            '
            Me.dgvJournalCode.DataPropertyName = "JournalCode"
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalCode.DefaultCellStyle = DataGridViewCellStyle11
            Me.dgvJournalCode.DisplayOnly = True
            Me.dgvJournalCode.EditingMode = False
            resources.ApplyResources(Me.dgvJournalCode, "dgvJournalCode")
            Me.dgvJournalCode.Name = "dgvJournalCode"
            Me.dgvJournalCode.ReadOnly = True
            Me.dgvJournalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvJournalCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'dgvJournalIdNoAp
            '
            Me.dgvJournalIdNoAp.DataPropertyName = "JournalIdNo"
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalIdNoAp.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvJournalIdNoAp.DisplayOnly = True
            Me.dgvJournalIdNoAp.EditingMode = False
            resources.ApplyResources(Me.dgvJournalIdNoAp, "dgvJournalIdNoAp")
            Me.dgvJournalIdNoAp.Name = "dgvJournalIdNoAp"
            Me.dgvJournalIdNoAp.ReadOnly = True
            '
            'dgvPreviousBalance
            '
            Me.dgvPreviousBalance.DataPropertyName = "PreviousBalance"
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.Format = "###,##0.00"
            Me.dgvPreviousBalance.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvPreviousBalance.EditingMode = False
            resources.ApplyResources(Me.dgvPreviousBalance, "dgvPreviousBalance")
            Me.dgvPreviousBalance.Name = "dgvPreviousBalance"
            Me.dgvPreviousBalance.ReadOnly = True
            Me.dgvPreviousBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvAmount
            '
            Me.dgvAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle14.Format = "###,##0.00"
            Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle14
            Me.dgvAmount.EditingMode = False
            resources.ApplyResources(Me.dgvAmount, "dgvAmount")
            Me.dgvAmount.Name = "dgvAmount"
            Me.dgvAmount.ReadOnly = True
            Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvDiscountTaken
            '
            Me.dgvDiscountTaken.DataPropertyName = "DiscountTaken"
            DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle15.Format = "###,##0.00"
            Me.dgvDiscountTaken.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgvDiscountTaken.EditingMode = False
            resources.ApplyResources(Me.dgvDiscountTaken, "dgvDiscountTaken")
            Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
            Me.dgvDiscountTaken.ReadOnly = True
            Me.dgvDiscountTaken.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvBalance
            '
            Me.dgvBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvBalance.DataPropertyName = "Balance"
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle16.Format = "###,##0.00"
            Me.dgvBalance.DefaultCellStyle = DataGridViewCellStyle16
            Me.dgvBalance.EditingMode = False
            resources.ApplyResources(Me.dgvBalance, "dgvBalance")
            Me.dgvBalance.Name = "dgvBalance"
            Me.dgvBalance.ReadOnly = True
            '
            'AccountIdNoDataGridViewTextBoxColumn
            '
            Me.AccountIdNoDataGridViewTextBoxColumn.DataPropertyName = "AccountIdNo"
            resources.ApplyResources(Me.AccountIdNoDataGridViewTextBoxColumn, "AccountIdNoDataGridViewTextBoxColumn")
            Me.AccountIdNoDataGridViewTextBoxColumn.Name = "AccountIdNoDataGridViewTextBoxColumn"
            Me.AccountIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn, "IdNoDataGridViewTextBoxColumn")
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
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
            Me.btnViewGL.DesignerSelected = False
            Me.btnViewGL.DisplayOnly = True
            resources.ApplyResources(Me.btnViewGL, "btnViewGL")
            Me.btnViewGL.ImageIndex = 0
            Me.btnViewGL.Name = "btnViewGL"
            Me.btnViewGL.OriginalImageName = Nothing
            Me.btnViewGL.SecurityKey = ""
            '
            'CashReceiptJournalEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floFullEntryArea)
            Me.Name = "CashReceiptJournalEntry"
            Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floFullEntryArea.ResumeLayout(false)
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
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents chkCancelled As CCheckBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents chkPosted As CCheckBox
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
        Friend WithEvents dgvJournalIdNoJi As CdgvColumnText
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCsrOi As CdgvColumnText
        Friend WithEvents dgvInvoiceNo As CdgvColumnText
        Friend WithEvents dgvTransactionDate As CdgvColumnText
        Friend WithEvents dgvJournalCode As CdgvColumnText
        Friend WithEvents dgvJournalIdNoAp As CdgvColumnText
        Friend WithEvents dgvPreviousBalance As CdgvColumnMoney
        Friend WithEvents dgvAmount As CdgvColumnMoney
        Friend WithEvents dgvDiscountTaken As CdgvColumnMoney
        Friend WithEvents dgvBalance As CdgvColumnMoney
        Friend WithEvents AccountIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvColumnMoney
        Friend WithEvents dgvCredit As CdgvColumnMoney
        Friend WithEvents dgvRevCostCenterIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvNotesDescription As CdgvColumnText
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
    End Class
End Namespace