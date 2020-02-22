Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floPurchaseJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvProfitCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgvJournalIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemVatAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewSalesCashItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.bsSalesCashItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.floJournalItemsFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblTotals = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTotalSales = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalDeposits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTotalBankCharges = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalBankChargesVat = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.floSalesCashItemsFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.btnHideJournalEntries = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.dgvSequenceSc = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvCashCode = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvSaleAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvDepositAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvRate = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvComputedBankCharge = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvComputedVat = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvActualBankCharge = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvActualVat = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvBankChargeDifference = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvVatDifference = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floFullEntryArea.SuspendLayout
        Me.floPurchaseJournalHeader.SuspendLayout
        Me.floHeader1.SuspendLayout
        Me.floHeader2.SuspendLayout
        Me.floPurchaseJournalItems.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewSalesCashItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsSalesCashItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floJournalItemsFooter.SuspendLayout
        Me.floSalesCashItemsFooter.SuspendLayout
        Me.SuspendLayout
        '
        'floFullEntryArea
        '
        Me.floFullEntryArea.BackColor = System.Drawing.Color.Transparent
        Me.floFullEntryArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floFullEntryArea.Controls.Add(Me.floPurchaseJournalHeader)
        Me.floFullEntryArea.Controls.Add(Me.floPurchaseJournalItems)
        Me.floFullEntryArea.Controls.Add(Me.floJournalItemsFooter)
        Me.floFullEntryArea.Controls.Add(Me.floSalesCashItemsFooter)
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
        Me.txtPayeeName.Name = "txtPayeeName"
        Me.txtPayeeName.ValueIsMandatory = true
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
        Me.floHeader2.Controls.Add(Me.txtDateCreated)
        Me.floPurchaseJournalHeader.SetFlowBreak(Me.floHeader2, true)
        resources.ApplyResources(Me.floHeader2, "floHeader2")
        Me.floHeader2.Name = "floHeader2"
        Me.floHeader2.TabStop = true
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
        '
        'floPurchaseJournalItems
        '
        Me.floPurchaseJournalItems.BackColor = System.Drawing.Color.Transparent
        Me.floPurchaseJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewJournalItems)
        Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewSalesCashItems)
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
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.DataGridViewCheckBoxColumn3, Me.dgvDebit, Me.dgvCredit, Me.dgvProfitCenterIdNo, Me.dgvNotes, Me.dgvIdNo, Me.DataGridViewCheckBoxColumn2, Me.dgvJournalIdNo, Me.ItemVatAmount})
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
        Me.dgvSequence.EditingMode = false
        resources.ApplyResources(Me.dgvSequence, "dgvSequence")
        Me.dgvSequence.Name = "dgvSequence"
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
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "Posted"
        resources.ApplyResources(Me.DataGridViewCheckBoxColumn3, "DataGridViewCheckBoxColumn3")
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
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
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "Cancelled"
        resources.ApplyResources(Me.DataGridViewCheckBoxColumn2, "DataGridViewCheckBoxColumn2")
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        '
        'dgvJournalIdNo
        '
        Me.dgvJournalIdNo.DataPropertyName = "JournalIdNo"
        resources.ApplyResources(Me.dgvJournalIdNo, "dgvJournalIdNo")
        Me.dgvJournalIdNo.Name = "dgvJournalIdNo"
        '
        'ItemVatAmount
        '
        resources.ApplyResources(Me.ItemVatAmount, "ItemVatAmount")
        Me.ItemVatAmount.Name = "ItemVatAmount"
        '
        'bsJournalItems
        '
        Me.bsJournalItems.DataSource = GetType(AATM.Accounts.BusinessLayer.SalesJournal)
        '
        'DataGridViewSalesCashItems
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewSalesCashItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewSalesCashItems.AutoGenerateColumns = false
        Me.DataGridViewSalesCashItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSalesCashItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceSc, Me.dgvCashCode, Me.dgvSaleAmount, Me.dgvDepositAmount, Me.dgvRate, Me.dgvComputedBankCharge, Me.dgvComputedVat, Me.dgvActualBankCharge, Me.dgvActualVat, Me.dgvBankChargeDifference, Me.dgvVatDifference, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.DataGridViewSalesCashItems.DataInGridChanged = false
        Me.DataGridViewSalesCashItems.DataSource = Me.bsSalesCashItems
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewSalesCashItems.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewSalesCashItems.DisplayOnly = false
        Me.DataGridViewSalesCashItems.EditingMode = false
        Me.DataGridViewSalesCashItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        resources.ApplyResources(Me.DataGridViewSalesCashItems, "DataGridViewSalesCashItems")
        Me.DataGridViewSalesCashItems.Name = "DataGridViewSalesCashItems"
        Me.DataGridViewSalesCashItems.SequenceColumn = "dgvSequenceSc"
        Me.DataGridViewSalesCashItems.StartTrackingChanges = false
        '
        'bsSalesCashItems
        '
        Me.bsSalesCashItems.DataSource = GetType(AATM.Accounts.BusinessLayer.SalesCashItem)
        '
        'floJournalItemsFooter
        '
        Me.floJournalItemsFooter.BackColor = System.Drawing.Color.Transparent
        Me.floJournalItemsFooter.Controls.Add(Me.lblTotals)
        Me.floJournalItemsFooter.Controls.Add(Me.txtTotalSales)
        Me.floJournalItemsFooter.Controls.Add(Me.txtTotalDeposits)
        Me.floJournalItemsFooter.Controls.Add(Me.CLabel2)
        Me.floJournalItemsFooter.Controls.Add(Me.txtTotalBankCharges)
        Me.floJournalItemsFooter.Controls.Add(Me.txtTotalBankChargesVat)
        Me.floJournalItemsFooter.Controls.Add(Me.btnViewGL)
        resources.ApplyResources(Me.floJournalItemsFooter, "floJournalItemsFooter")
        Me.floJournalItemsFooter.Name = "floJournalItemsFooter"
        '
        'lblTotals
        '
        resources.ApplyResources(Me.lblTotals, "lblTotals")
        Me.lblTotals.Name = "lblTotals"
        '
        'txtTotalSales
        '
        Me.txtTotalSales.BackColor = System.Drawing.Color.White
        Me.txtTotalSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalSales.ComputedValue = false
        Me.txtTotalSales.CustomFormat = "N2"
        Me.txtTotalSales.DataBoundControl = true
        Me.txtTotalSales.DisplayOnly = true
        Me.txtTotalSales.EditingMode = true
        resources.ApplyResources(Me.txtTotalSales, "txtTotalSales")
        Me.txtTotalSales.ForeColor = System.Drawing.Color.Black
        Me.txtTotalSales.LinkedLabel = Nothing
        Me.txtTotalSales.Name = "txtTotalSales"
        Me.txtTotalSales.ReadOnly = true
        Me.txtTotalSales.ValueIsMandatory = true
        '
        'txtTotalDeposits
        '
        Me.txtTotalDeposits.BackColor = System.Drawing.Color.White
        Me.txtTotalDeposits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDeposits.ComputedValue = false
        Me.txtTotalDeposits.CustomFormat = "N2"
        Me.txtTotalDeposits.DataBoundControl = true
        Me.txtTotalDeposits.DisplayOnly = true
        Me.txtTotalDeposits.EditingMode = true
        resources.ApplyResources(Me.txtTotalDeposits, "txtTotalDeposits")
        Me.txtTotalDeposits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDeposits.LinkedLabel = Nothing
        Me.txtTotalDeposits.Name = "txtTotalDeposits"
        Me.txtTotalDeposits.ReadOnly = true
        Me.txtTotalDeposits.ValueIsMandatory = true
        '
        'CLabel2
        '
        resources.ApplyResources(Me.CLabel2, "CLabel2")
        Me.CLabel2.Name = "CLabel2"
        '
        'txtTotalBankCharges
        '
        Me.txtTotalBankCharges.BackColor = System.Drawing.Color.White
        Me.txtTotalBankCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBankCharges.ComputedValue = false
        Me.txtTotalBankCharges.CustomFormat = "N2"
        Me.txtTotalBankCharges.DataBoundControl = true
        Me.txtTotalBankCharges.DisplayOnly = true
        Me.txtTotalBankCharges.EditingMode = true
        resources.ApplyResources(Me.txtTotalBankCharges, "txtTotalBankCharges")
        Me.txtTotalBankCharges.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBankCharges.LinkedLabel = Nothing
        Me.txtTotalBankCharges.Name = "txtTotalBankCharges"
        Me.txtTotalBankCharges.ReadOnly = true
        Me.txtTotalBankCharges.ValueIsMandatory = true
        '
        'txtTotalBankChargesVat
        '
        Me.txtTotalBankChargesVat.BackColor = System.Drawing.Color.White
        Me.txtTotalBankChargesVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBankChargesVat.ComputedValue = false
        Me.txtTotalBankChargesVat.CustomFormat = "N2"
        Me.txtTotalBankChargesVat.DataBoundControl = true
        Me.txtTotalBankChargesVat.DisplayOnly = true
        Me.txtTotalBankChargesVat.EditingMode = true
        resources.ApplyResources(Me.txtTotalBankChargesVat, "txtTotalBankChargesVat")
        Me.txtTotalBankChargesVat.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBankChargesVat.LinkedLabel = Nothing
        Me.txtTotalBankChargesVat.Name = "txtTotalBankChargesVat"
        Me.txtTotalBankChargesVat.ReadOnly = true
        Me.txtTotalBankChargesVat.ValueIsMandatory = true
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
        'floSalesCashItemsFooter
        '
        Me.floSalesCashItemsFooter.BackColor = System.Drawing.Color.Transparent
        Me.floSalesCashItemsFooter.Controls.Add(Me.CLabel1)
        Me.floSalesCashItemsFooter.Controls.Add(Me.txtTotalDebits)
        Me.floSalesCashItemsFooter.Controls.Add(Me.txtTotalCredits)
        Me.floSalesCashItemsFooter.Controls.Add(Me.btnHideJournalEntries)
        resources.ApplyResources(Me.floSalesCashItemsFooter, "floSalesCashItemsFooter")
        Me.floSalesCashItemsFooter.Name = "floSalesCashItemsFooter"
        '
        'CLabel1
        '
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.Name = "CLabel1"
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
        Me.txtTotalCredits.ReadOnly = true
        Me.txtTotalCredits.TabStop = false
        Me.txtTotalCredits.ValueIsMandatory = true
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
        Me.dgvSequenceSc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'dgvCashCode
        '
        Me.dgvCashCode.DataPropertyName = "CashCode"
        resources.ApplyResources(Me.dgvCashCode, "dgvCashCode")
        Me.dgvCashCode.Name = "dgvCashCode"
        Me.dgvCashCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCashCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        Me.dgvDepositAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDepositAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvRate
        '
        Me.dgvRate.DataPropertyName = "Rate"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.Format = "###,##0.00"
        Me.dgvRate.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvRate.EditingMode = false
        resources.ApplyResources(Me.dgvRate, "dgvRate")
        Me.dgvRate.Name = "dgvRate"
        Me.dgvRate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvComputedBankCharge
        '
        Me.dgvComputedBankCharge.DataPropertyName = "ComputedBankCharge"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.Format = "###,##0.00"
        Me.dgvComputedBankCharge.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvComputedBankCharge.EditingMode = false
        resources.ApplyResources(Me.dgvComputedBankCharge, "dgvComputedBankCharge")
        Me.dgvComputedBankCharge.Name = "dgvComputedBankCharge"
        Me.dgvComputedBankCharge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComputedBankCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvComputedVat
        '
        Me.dgvComputedVat.DataPropertyName = "ComputedBankChargeVat"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.Format = "###,##0.00"
        Me.dgvComputedVat.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvComputedVat.EditingMode = false
        resources.ApplyResources(Me.dgvComputedVat, "dgvComputedVat")
        Me.dgvComputedVat.Name = "dgvComputedVat"
        Me.dgvComputedVat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComputedVat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvActualBankCharge
        '
        Me.dgvActualBankCharge.DataPropertyName = "ActualBankCharge"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.Format = "###,##0.00"
        Me.dgvActualBankCharge.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvActualBankCharge.EditingMode = false
        resources.ApplyResources(Me.dgvActualBankCharge, "dgvActualBankCharge")
        Me.dgvActualBankCharge.Name = "dgvActualBankCharge"
        Me.dgvActualBankCharge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvActualBankCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvActualVat
        '
        Me.dgvActualVat.DataPropertyName = "ActualBankChargeVat"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.Format = "###,##0.00"
        Me.dgvActualVat.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvActualVat.EditingMode = false
        resources.ApplyResources(Me.dgvActualVat, "dgvActualVat")
        Me.dgvActualVat.Name = "dgvActualVat"
        Me.dgvActualVat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvActualVat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        Me.dgvVatDifference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVatDifference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IdNo"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "SalesJournalIdNo"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'SalesJournalEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floFullEntryArea)
        Me.Name = "SalesJournalEntry"
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
        CType(Me.DataGridViewSalesCashItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsSalesCashItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.floJournalItemsFooter.ResumeLayout(false)
        Me.floJournalItemsFooter.PerformLayout
        Me.floSalesCashItemsFooter.ResumeLayout(false)
        Me.floSalesCashItemsFooter.PerformLayout
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
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floPurchaseJournalItems As CFlowLayout
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents floJournalItemsFooter As CFlowLayout
        Friend WithEvents lblTotals As CLabel
        Friend WithEvents txtTotalDebits As CTextBox
        Friend WithEvents txtTotalCredits As CTextBox
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents chkCancelled As CCheckBox
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents txtTotalSales As CTextBox
        Friend WithEvents txtPayeeName As CTextBox
        Friend WithEvents floHeader1 As CFlowLayout
        Friend WithEvents floHeader2 As CFlowLayout
        Friend WithEvents txtDateCreated As CTextBox
        Friend WithEvents DataGridViewSalesCashItems As CDataGridView
        Friend WithEvents bsSalesCashItems As Windows.Forms.BindingSource
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents DiscountTakenDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OriginalAmountDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PaidAmountDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PayeeTypeDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SpecialAccountDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents btnViewGL As CButton
        Friend WithEvents txtTotalDeposits As CTextBox
        Friend WithEvents txtTotalBankCharges As CTextBox
        Friend WithEvents txtTotalBankChargesVat As CTextBox
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
        Friend WithEvents floSalesCashItemsFooter As CFlowLayout
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents btnHideJournalEntries As CButton
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn3 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents dgvDebit As CdgvColumnMoney
        Friend WithEvents dgvCredit As CdgvColumnMoney
        Friend WithEvents dgvProfitCenterIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvNotes As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As CdgvColumnText
        Friend WithEvents DataGridViewCheckBoxColumn2 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents dgvJournalIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ItemVatAmount As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceSc As CdgvColumnText
        Friend WithEvents dgvCashCode As CaDgvComboBoxColumn
        Friend WithEvents dgvSaleAmount As CdgvColumnMoney
        Friend WithEvents dgvDepositAmount As CdgvColumnMoney
        Friend WithEvents dgvRate As CdgvColumnMoney
        Friend WithEvents dgvComputedBankCharge As CdgvColumnMoney
        Friend WithEvents dgvComputedVat As CdgvColumnMoney
        Friend WithEvents dgvActualBankCharge As CdgvColumnMoney
        Friend WithEvents dgvActualVat As CdgvColumnMoney
        Friend WithEvents dgvBankChargeDifference As CdgvColumnMoney
        Friend WithEvents dgvVatDifference As CdgvColumnMoney
        Friend WithEvents DataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace