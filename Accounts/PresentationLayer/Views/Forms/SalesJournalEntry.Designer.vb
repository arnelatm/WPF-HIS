Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SalesJournalEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesJournalEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floHeader2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
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
        Me.dgvNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgvJournalIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemVatAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewSalesDeposits = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.bsSalesDeposits = New System.Windows.Forms.BindingSource(Me.components)
        Me.floJournalItemsFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.floSalesDepositsFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnHideJournalEntries = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.dgvSequenceSc = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvDepositTypeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvSaleAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvDepositAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvActualVat = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvActualBankCharge = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvRate = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvComputedBankCharge = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvComputedVat = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvBankChargeDifference = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvVatDifference = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DgvSalesJournalIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floFullEntryArea.SuspendLayout
        Me.floPurchaseJournalHeader.SuspendLayout
        Me.floHeader1.SuspendLayout
        Me.floHeader2.SuspendLayout
        Me.floPurchaseJournalItems.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewSalesDeposits,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsSalesDeposits,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floJournalItemsFooter.SuspendLayout
        Me.floSalesDepositsFooter.SuspendLayout
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
        Me.floFullEntryArea.Controls.Add(Me.floJournalItemsFooter)
        Me.floFullEntryArea.Controls.Add(Me.floSalesDepositsFooter)
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
        Me.floHeader1.Controls.Add(Me.txtPayeeName)
        Me.floHeader1.Controls.Add(Me.lblAccountIdNo)
        Me.floHeader1.Controls.Add(Me.cboAccountIdNo)
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
        Me.txtJournalCode.MaximumValue = Nothing
        Me.txtJournalCode.MinimumValue = Nothing
        Me.txtJournalCode.Name = "txtJournalCode"
        Me.txtJournalCode.OldValue = Nothing
        Me.txtJournalCode.ReadOnly = true
        Me.txtJournalCode.TabStop = false
        Me.txtJournalCode.ValueIsMandatory = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = true
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.DisplayOnly = true
        Me.lblReferenceNo.EditingMode = false
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
        Me.txtReferenceNo.MaximumValue = Nothing
        Me.txtReferenceNo.MinimumValue = Nothing
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.OldValue = Nothing
        Me.txtReferenceNo.ReadOnly = true
        Me.txtReferenceNo.ValueIsMandatory = true
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.DisplayOnly = true
        Me.lblTransactionDate.EditingMode = false
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
        Me.txtPayeeName.LinkedLabel = Nothing
        Me.txtPayeeName.MaximumValue = Nothing
        Me.txtPayeeName.MinimumValue = Nothing
        Me.txtPayeeName.Name = "txtPayeeName"
        Me.txtPayeeName.OldValue = Nothing
        Me.txtPayeeName.ReadOnly = true
        Me.txtPayeeName.ValueIsMandatory = true
        '
        'lblAccountIdNo
        '
        Me.lblAccountIdNo.DisplayOnly = true
        Me.lblAccountIdNo.EditingMode = false
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
        Me.cboAccountIdNo.DropDownHeight = 1
        Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
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
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
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
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.ValueIsMandatory = true
        '
        'floHeader2
        '
        Me.floHeader2.BackColor = System.Drawing.Color.Transparent
        Me.floHeader2.Controls.Add(Me.lblCancelled)
        Me.floHeader2.Controls.Add(Me.chkCancelled)
        Me.floHeader2.Controls.Add(Me.lblPosted)
        Me.floHeader2.Controls.Add(Me.chkPosted)
        Me.floHeader2.Controls.Add(Me.lblDateCreated)
        Me.floHeader2.Controls.Add(Me.dtpDateCreated)
        Me.floPurchaseJournalHeader.SetFlowBreak(Me.floHeader2, true)
        resources.ApplyResources(Me.floHeader2, "floHeader2")
        Me.floHeader2.Name = "floHeader2"
        Me.floHeader2.TabStop = true
        '
        'lblCancelled
        '
        Me.lblCancelled.DisplayOnly = true
        Me.lblCancelled.EditingMode = false
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
        Me.chkCancelled.NoLabel = true
        Me.chkCancelled.OldValue = Nothing
        Me.chkCancelled.UseVisualStyleBackColor = false
        '
        'lblPosted
        '
        Me.lblPosted.DisplayOnly = true
        Me.lblPosted.EditingMode = false
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
        Me.chkPosted.NoLabel = true
        Me.chkPosted.OldValue = Nothing
        Me.chkPosted.UseVisualStyleBackColor = false
        '
        'lblDateCreated
        '
        Me.lblDateCreated.DisplayOnly = true
        Me.lblDateCreated.EditingMode = false
        resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
        Me.lblDateCreated.Name = "lblDateCreated"
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
        Me.dtpDateCreated.TargetCalendar = Nothing
        Me.dtpDateCreated.Value = Nothing
        Me.dtpDateCreated.ValueIsMandatory = false
        Me.dtpDateCreated.ValueIsNullable = false
        '
        'floPurchaseJournalItems
        '
        Me.floPurchaseJournalItems.BackColor = System.Drawing.Color.Transparent
        Me.floPurchaseJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewJournalItems)
        Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewSalesDeposits)
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
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.dgvIdNo, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewCheckBoxColumn2, Me.dgvJournalIdNo, Me.ItemVatAmount})
        Me.DataGridViewJournalItems.DataInGridChanged = false
        Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewJournalItems.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewJournalItems.DgvFooter = Nothing
        Me.DataGridViewJournalItems.DisplayOnly = false
        resources.ApplyResources(Me.DataGridViewJournalItems, "DataGridViewJournalItems")
        Me.DataGridViewJournalItems.Ea = EventAggregator1
        Me.DataGridViewJournalItems.EditingMode = false
        Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewJournalItems.FirstRowDeletionEnabled = false
        Me.DataGridViewJournalItems.FirstRowInsertionEnabled = false
        Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
        Me.DataGridViewJournalItems.ReadOnly = true
        Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
        Me.DataGridViewJournalItems.ShowFooter = false
        Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = true
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
        Me.dgvAccountIdNo.DisplayStyleForCurrentCellOnly = true
        Me.dgvAccountIdNo.FillWeight = 1!
        resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.ReadOnly = true
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
        Me.dgvDebit.ReadOnly = true
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
        Me.dgvCredit.ReadOnly = true
        Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvRevCostCenterIdNo
        '
        Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
        resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
        Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
        Me.dgvRevCostCenterIdNo.ReadOnly = true
        Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvNotes
        '
        Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNotes.DataPropertyName = "Notes"
        resources.ApplyResources(Me.dgvNotes, "dgvNotes")
        Me.dgvNotes.Name = "dgvNotes"
        Me.dgvNotes.ReadOnly = true
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
        Me.dgvIdNo.ReadOnly = true
        Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "Posted"
        resources.ApplyResources(Me.DataGridViewCheckBoxColumn3, "DataGridViewCheckBoxColumn3")
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.ReadOnly = true
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "Cancelled"
        resources.ApplyResources(Me.DataGridViewCheckBoxColumn2, "DataGridViewCheckBoxColumn2")
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ReadOnly = true
        '
        'dgvJournalIdNo
        '
        Me.dgvJournalIdNo.DataPropertyName = "JournalIdNo"
        resources.ApplyResources(Me.dgvJournalIdNo, "dgvJournalIdNo")
        Me.dgvJournalIdNo.Name = "dgvJournalIdNo"
        Me.dgvJournalIdNo.ReadOnly = true
        '
        'ItemVatAmount
        '
        resources.ApplyResources(Me.ItemVatAmount, "ItemVatAmount")
        Me.ItemVatAmount.Name = "ItemVatAmount"
        Me.ItemVatAmount.ReadOnly = true
        '
        'bsJournalItems
        '
        Me.bsJournalItems.DataSource = GetType(AATM.Accounts.BusinessLayer.SalesJournal)
        '
        'DataGridViewSalesDeposits
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewSalesDeposits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewSalesDeposits.AutoGenerateColumns = false
        Me.DataGridViewSalesDeposits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSalesDeposits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceSc, Me.dgvDepositTypeIdNo, Me.dgvSaleAmount, Me.dgvDepositAmount, Me.dgvActualVat, Me.dgvActualBankCharge, Me.dgvRate, Me.dgvComputedBankCharge, Me.dgvComputedVat, Me.dgvBankChargeDifference, Me.dgvVatDifference, Me.DataGridViewTextBoxColumn1, Me.DgvSalesJournalIdNo})
        Me.DataGridViewSalesDeposits.DataInGridChanged = false
        Me.DataGridViewSalesDeposits.DataSource = Me.bsSalesDeposits
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewSalesDeposits.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewSalesDeposits.DgvFooter = Nothing
        Me.DataGridViewSalesDeposits.DisplayOnly = false
        Me.DataGridViewSalesDeposits.Ea = EventAggregator2
        Me.DataGridViewSalesDeposits.EditingMode = false
        Me.DataGridViewSalesDeposits.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewSalesDeposits.FirstRowDeletionEnabled = true
        Me.DataGridViewSalesDeposits.FirstRowInsertionEnabled = true
        resources.ApplyResources(Me.DataGridViewSalesDeposits, "DataGridViewSalesDeposits")
        Me.DataGridViewSalesDeposits.Name = "DataGridViewSalesDeposits"
        Me.DataGridViewSalesDeposits.ReadOnly = true
        Me.DataGridViewSalesDeposits.SequenceColumn = "dgvSequenceSc"
        Me.DataGridViewSalesDeposits.SequenceFieldName = "Sequence"
        Me.DataGridViewSalesDeposits.ShowFooter = false
        Me.DataGridViewSalesDeposits.ShowInsertColumnWhenEditing = true
        Me.DataGridViewSalesDeposits.StartTrackingChanges = false
        '
        'bsSalesDeposits
        '
        Me.bsSalesDeposits.DataSource = GetType(AATM.Accounts.PresentationLayer.Views.SalesDepositView)
        '
        'floJournalItemsFooter
        '
        Me.floJournalItemsFooter.BackColor = System.Drawing.Color.Transparent
        Me.floJournalItemsFooter.Controls.Add(Me.btnViewGL)
        resources.ApplyResources(Me.floJournalItemsFooter, "floJournalItemsFooter")
        Me.floJournalItemsFooter.Name = "floJournalItemsFooter"
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
        'floSalesDepositsFooter
        '
        Me.floSalesDepositsFooter.BackColor = System.Drawing.Color.Transparent
        Me.floSalesDepositsFooter.Controls.Add(Me.CLabel1)
        Me.floSalesDepositsFooter.Controls.Add(Me.btnHideJournalEntries)
        resources.ApplyResources(Me.floSalesDepositsFooter, "floSalesDepositsFooter")
        Me.floSalesDepositsFooter.Name = "floSalesDepositsFooter"
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
        '
        'btnHideJournalEntries
        '
        Me.btnHideJournalEntries.DesignerSelected = false
        Me.btnHideJournalEntries.DisplayOnly = true
        resources.ApplyResources(Me.btnHideJournalEntries, "btnHideJournalEntries")
        Me.btnHideJournalEntries.ImageIndex = 0
        Me.btnHideJournalEntries.Name = "btnHideJournalEntries"
        Me.btnHideJournalEntries.OriginalImageName = Nothing
        Me.btnHideJournalEntries.SecurityKey = ""
        '
        'dgvSequenceSc
        '
        Me.dgvSequenceSc.DataPropertyName = "Sequence"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.dgvSequenceSc.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvSequenceSc.DisplayOnly = true
        Me.dgvSequenceSc.EditingMode = true
        resources.ApplyResources(Me.dgvSequenceSc, "dgvSequenceSc")
        Me.dgvSequenceSc.Name = "dgvSequenceSc"
        Me.dgvSequenceSc.ReadOnly = true
        Me.dgvSequenceSc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvDepositTypeIdNo
        '
        Me.dgvDepositTypeIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvDepositTypeIdNo.DataPropertyName = "DepositTypeIdNo"
        resources.ApplyResources(Me.dgvDepositTypeIdNo, "dgvDepositTypeIdNo")
        Me.dgvDepositTypeIdNo.Name = "dgvDepositTypeIdNo"
        Me.dgvDepositTypeIdNo.ReadOnly = true
        Me.dgvDepositTypeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDepositTypeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvSaleAmount
        '
        Me.dgvSaleAmount.DataPropertyName = "SaleAmount"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.Format = "###,##0.00"
        Me.dgvSaleAmount.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvSaleAmount.EditingMode = false
        resources.ApplyResources(Me.dgvSaleAmount, "dgvSaleAmount")
        Me.dgvSaleAmount.Name = "dgvSaleAmount"
        Me.dgvSaleAmount.ReadOnly = true
        Me.dgvSaleAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSaleAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvDepositAmount
        '
        Me.dgvDepositAmount.DataPropertyName = "DepositAmount"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.Format = "###,##0.00"
        Me.dgvDepositAmount.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvDepositAmount.EditingMode = false
        resources.ApplyResources(Me.dgvDepositAmount, "dgvDepositAmount")
        Me.dgvDepositAmount.Name = "dgvDepositAmount"
        Me.dgvDepositAmount.ReadOnly = true
        Me.dgvDepositAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'dgvActualVat
        '
        Me.dgvActualVat.DataPropertyName = "ActualVatAmount"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.Format = "###,##0.00"
        Me.dgvActualVat.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvActualVat.EditingMode = false
        resources.ApplyResources(Me.dgvActualVat, "dgvActualVat")
        Me.dgvActualVat.Name = "dgvActualVat"
        Me.dgvActualVat.ReadOnly = true
        Me.dgvActualVat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvActualVat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvActualBankCharge
        '
        Me.dgvActualBankCharge.DataPropertyName = "ActualBankCharge"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.Format = "###,##0.00"
        Me.dgvActualBankCharge.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvActualBankCharge.EditingMode = false
        resources.ApplyResources(Me.dgvActualBankCharge, "dgvActualBankCharge")
        Me.dgvActualBankCharge.Name = "dgvActualBankCharge"
        Me.dgvActualBankCharge.ReadOnly = true
        Me.dgvActualBankCharge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvActualBankCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvRate
        '
        Me.dgvRate.DataPropertyName = "Rate"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.Format = "###,##0.00"
        Me.dgvRate.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvRate.EditingMode = false
        resources.ApplyResources(Me.dgvRate, "dgvRate")
        Me.dgvRate.Name = "dgvRate"
        Me.dgvRate.ReadOnly = true
        Me.dgvRate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvComputedBankCharge
        '
        Me.dgvComputedBankCharge.DataPropertyName = "ComputedBankCharge"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.Format = "###,##0.00"
        Me.dgvComputedBankCharge.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvComputedBankCharge.EditingMode = false
        resources.ApplyResources(Me.dgvComputedBankCharge, "dgvComputedBankCharge")
        Me.dgvComputedBankCharge.Name = "dgvComputedBankCharge"
        Me.dgvComputedBankCharge.ReadOnly = true
        Me.dgvComputedBankCharge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComputedBankCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvComputedVat
        '
        Me.dgvComputedVat.DataPropertyName = "ComputedBankChargeVat"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.Format = "###,##0.00"
        Me.dgvComputedVat.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvComputedVat.EditingMode = false
        resources.ApplyResources(Me.dgvComputedVat, "dgvComputedVat")
        Me.dgvComputedVat.Name = "dgvComputedVat"
        Me.dgvComputedVat.ReadOnly = true
        Me.dgvComputedVat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComputedVat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvBankChargeDifference
        '
        Me.dgvBankChargeDifference.DataPropertyName = "BankChargeDifference"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.Format = "###,##0.00"
        Me.dgvBankChargeDifference.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvBankChargeDifference.EditingMode = false
        resources.ApplyResources(Me.dgvBankChargeDifference, "dgvBankChargeDifference")
        Me.dgvBankChargeDifference.Name = "dgvBankChargeDifference"
        Me.dgvBankChargeDifference.ReadOnly = true
        Me.dgvBankChargeDifference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBankChargeDifference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvVatDifference
        '
        Me.dgvVatDifference.DataPropertyName = "BankChargeVatDifference"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.Format = "###,##0.00"
        Me.dgvVatDifference.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvVatDifference.EditingMode = false
        resources.ApplyResources(Me.dgvVatDifference, "dgvVatDifference")
        Me.dgvVatDifference.Name = "dgvVatDifference"
        Me.dgvVatDifference.ReadOnly = true
        Me.dgvVatDifference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVatDifference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = true
        '
        'DgvSalesJournalIdNo
        '
        Me.DgvSalesJournalIdNo.DataPropertyName = "SalesJournalIdNo"
        resources.ApplyResources(Me.DgvSalesJournalIdNo, "DgvSalesJournalIdNo")
        Me.DgvSalesJournalIdNo.Name = "DgvSalesJournalIdNo"
        Me.DgvSalesJournalIdNo.ReadOnly = true
        '
        'SalesJournalEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floFullEntryArea)
        Me.Name = "SalesJournalEntry"
        Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floFullEntryArea.ResumeLayout(false)
        Me.floPurchaseJournalHeader.ResumeLayout(false)
        Me.floHeader1.ResumeLayout(false)
        Me.floHeader1.PerformLayout
        Me.floHeader2.ResumeLayout(false)
        Me.floPurchaseJournalItems.ResumeLayout(false)
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewSalesDeposits,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsSalesDeposits,System.ComponentModel.ISupportInitialize).EndInit
        Me.floJournalItemsFooter.ResumeLayout(false)
        Me.floSalesDepositsFooter.ResumeLayout(false)
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
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floPurchaseJournalItems As CFlowLayout
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents floJournalItemsFooter As CFlowLayout
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents chkCancelled As CCheckBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents txtPayeeName As CTextBox
        Friend WithEvents floHeader1 As CFlowLayout
        Friend WithEvents floHeader2 As CFlowLayout
        Friend WithEvents bsSalesDeposits As Windows.Forms.BindingSource
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents DiscountTakenDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OriginalAmountDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PaidAmountDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PayeeTypeDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SpecialAccountDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btnViewGL As CButton
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents DateCreatedDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents NotesDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PostedDataGridViewCheckBoxColumn As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents ReferenceNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TotalBankChargesDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TotalSalesDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TotalBankChargesVatDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents TransactionDateDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SalesJournalIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents floSalesDepositsFooter As CFlowLayout
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents btnHideJournalEntries As CButton
        Public WithEvents DataGridViewSalesDeposits As CDataGridView
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvColumnMoney
        Friend WithEvents dgvCredit As CdgvColumnMoney
        Friend WithEvents dgvRevCostCenterIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvNotes As DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As CdgvColumnText
        Friend WithEvents DataGridViewCheckBoxColumn3 As DataGridViewCheckBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
        Friend WithEvents dgvJournalIdNo As DataGridViewTextBoxColumn
        Friend WithEvents ItemVatAmount As DataGridViewTextBoxColumn
        Friend WithEvents dtpDateCreated As CCustomDateTimePicker
        Friend WithEvents dgvSequenceSc As CdgvColumnText
        Friend WithEvents dgvDepositTypeIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvSaleAmount As CdgvColumnMoney
        Friend WithEvents dgvDepositAmount As CdgvColumnMoney
        Friend WithEvents dgvActualVat As CdgvColumnMoney
        Friend WithEvents dgvActualBankCharge As CdgvColumnMoney
        Friend WithEvents dgvRate As CdgvColumnMoney
        Friend WithEvents dgvComputedBankCharge As CdgvColumnMoney
        Friend WithEvents dgvComputedVat As CdgvColumnMoney
        Friend WithEvents dgvBankChargeDifference As CdgvColumnMoney
        Friend WithEvents dgvVatDifference As CdgvColumnMoney
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DgvSalesJournalIdNo As DataGridViewTextBoxColumn
    End Class
End Namespace