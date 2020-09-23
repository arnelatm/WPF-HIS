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
            Me.DataGridViewSalesCashItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequenceSc = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvCashCode = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvSaleAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvActualBankCharge = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvActualVat = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvDepositAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvRate = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvComputedBankCharge = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvComputedVat = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvBankChargeDifference = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvVatDifference = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DgvSalesJournalIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsSalesCashItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.floJournalItemsFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.floSalesCashItemsFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnHideJournalEntries = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floFullEntryArea.SuspendLayout()
            Me.floPurchaseJournalHeader.SuspendLayout()
            Me.floHeader1.SuspendLayout()
            Me.floHeader2.SuspendLayout()
            Me.floPurchaseJournalItems.SuspendLayout()
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewSalesCashItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsSalesCashItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floJournalItemsFooter.SuspendLayout()
            Me.floSalesCashItemsFooter.SuspendLayout()
            Me.SuspendLayout()
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
            Me.floHeader1.Controls.Add(Me.txtPayeeName)
            Me.floHeader1.Controls.Add(Me.lblAccountIdNo)
            Me.floHeader1.Controls.Add(Me.cboAccountIdNo)
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
            'txtPayeeName
            '
            Me.txtPayeeName.BackColor = System.Drawing.Color.White
            Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayeeName.ComputedValue = False
            Me.txtPayeeName.CustomFormat = Nothing
            Me.txtPayeeName.DataBoundControl = True
            Me.txtPayeeName.EditingMode = False
            Me.floHeader1.SetFlowBreak(Me.txtPayeeName, True)
            resources.ApplyResources(Me.txtPayeeName, "txtPayeeName")
            Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
            Me.txtPayeeName.LinkedLabel = Nothing
            Me.txtPayeeName.MaximumValue = Nothing
            Me.txtPayeeName.MinimumValue = Nothing
            Me.txtPayeeName.Name = "txtPayeeName"
            Me.txtPayeeName.OldValue = Nothing
            Me.txtPayeeName.ReadOnly = True
            Me.txtPayeeName.ValueIsMandatory = True
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
            Me.floHeader1.SetFlowBreak(Me.cboAccountIdNo, True)
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
            Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewSalesCashItems)
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
            Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.dgvIdNo, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewCheckBoxColumn2, Me.dgvJournalIdNo, Me.ItemVatAmount})
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
            Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            Me.dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
            Me.dgvAccountIdNo.FillWeight = 1.0!
            resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
            Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
            Me.dgvAccountIdNo.ReadOnly = True
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
            Me.dgvDebit.EditingMode = False
            resources.ApplyResources(Me.dgvDebit, "dgvDebit")
            Me.dgvDebit.Name = "dgvDebit"
            Me.dgvDebit.ReadOnly = True
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
            Me.dgvCredit.EditingMode = False
            resources.ApplyResources(Me.dgvCredit, "dgvCredit")
            Me.dgvCredit.Name = "dgvCredit"
            Me.dgvCredit.ReadOnly = True
            Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
            resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
            Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.ReadOnly = True
            Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvNotes
            '
            Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvNotes.DataPropertyName = "Notes"
            resources.ApplyResources(Me.dgvNotes, "dgvNotes")
            Me.dgvNotes.Name = "dgvNotes"
            Me.dgvNotes.ReadOnly = True
            '
            'dgvIdNo
            '
            Me.dgvIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvIdNo.DataPropertyName = "IdNo"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'DataGridViewCheckBoxColumn3
            '
            Me.DataGridViewCheckBoxColumn3.DataPropertyName = "Posted"
            resources.ApplyResources(Me.DataGridViewCheckBoxColumn3, "DataGridViewCheckBoxColumn3")
            Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
            Me.DataGridViewCheckBoxColumn3.ReadOnly = True
            '
            'DataGridViewCheckBoxColumn2
            '
            Me.DataGridViewCheckBoxColumn2.DataPropertyName = "Cancelled"
            resources.ApplyResources(Me.DataGridViewCheckBoxColumn2, "DataGridViewCheckBoxColumn2")
            Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
            Me.DataGridViewCheckBoxColumn2.ReadOnly = True
            '
            'dgvJournalIdNo
            '
            Me.dgvJournalIdNo.DataPropertyName = "JournalIdNo"
            resources.ApplyResources(Me.dgvJournalIdNo, "dgvJournalIdNo")
            Me.dgvJournalIdNo.Name = "dgvJournalIdNo"
            Me.dgvJournalIdNo.ReadOnly = True
            '
            'ItemVatAmount
            '
            resources.ApplyResources(Me.ItemVatAmount, "ItemVatAmount")
            Me.ItemVatAmount.Name = "ItemVatAmount"
            Me.ItemVatAmount.ReadOnly = True
            '
            'bsJournalItems
            '
            Me.bsJournalItems.DataSource = GetType(AATM.Accounts.BusinessLayer.SalesJournal)
            '
            'DataGridViewSalesCashItems
            '
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewSalesCashItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridViewSalesCashItems.AutoGenerateColumns = False
            Me.DataGridViewSalesCashItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewSalesCashItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceSc, Me.dgvCashCode, Me.dgvSaleAmount, Me.dgvActualBankCharge, Me.dgvActualVat, Me.dgvDepositAmount, Me.dgvRate, Me.dgvComputedBankCharge, Me.dgvComputedVat, Me.dgvBankChargeDifference, Me.dgvVatDifference, Me.DataGridViewTextBoxColumn1, Me.DgvSalesJournalIdNo})
            Me.DataGridViewSalesCashItems.DataInGridChanged = False
            Me.DataGridViewSalesCashItems.DataSource = Me.bsSalesCashItems
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewSalesCashItems.DefaultCellStyle = DataGridViewCellStyle18
            Me.DataGridViewSalesCashItems.DisplayOnly = False
            Me.DataGridViewSalesCashItems.Ea = EventAggregator2
            Me.DataGridViewSalesCashItems.EditingMode = False
            Me.DataGridViewSalesCashItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewSalesCashItems.FirstRowDeletionEnabled = True
            Me.DataGridViewSalesCashItems.FirstRowInsertionEnabled = True
            resources.ApplyResources(Me.DataGridViewSalesCashItems, "DataGridViewSalesCashItems")
            Me.DataGridViewSalesCashItems.Name = "DataGridViewSalesCashItems"
            Me.DataGridViewSalesCashItems.ReadOnly = True
            Me.DataGridViewSalesCashItems.SequenceColumn = "dgvSequenceSc"
            Me.DataGridViewSalesCashItems.ShowInsertColumnWhenEditing = True
            Me.DataGridViewSalesCashItems.StartTrackingChanges = False
            '
            'dgvSequenceSc
            '
            Me.dgvSequenceSc.DataPropertyName = "Sequence"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceSc.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvSequenceSc.DisplayOnly = True
            Me.dgvSequenceSc.EditingMode = False
            resources.ApplyResources(Me.dgvSequenceSc, "dgvSequenceSc")
            Me.dgvSequenceSc.Name = "dgvSequenceSc"
            Me.dgvSequenceSc.ReadOnly = True
            Me.dgvSequenceSc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvCashCode
            '
            Me.dgvCashCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvCashCode.DataPropertyName = "CashCode"
            Me.dgvCashCode.DisplayStyleForCurrentCellOnly = True
            resources.ApplyResources(Me.dgvCashCode, "dgvCashCode")
            Me.dgvCashCode.Name = "dgvCashCode"
            Me.dgvCashCode.ReadOnly = True
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
            Me.dgvSaleAmount.EditingMode = False
            resources.ApplyResources(Me.dgvSaleAmount, "dgvSaleAmount")
            Me.dgvSaleAmount.Name = "dgvSaleAmount"
            Me.dgvSaleAmount.ReadOnly = True
            Me.dgvSaleAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSaleAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvActualBankCharge
            '
            Me.dgvActualBankCharge.DataPropertyName = "ActualBankCharge"
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.Format = "###,##0.00"
            Me.dgvActualBankCharge.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvActualBankCharge.EditingMode = False
            resources.ApplyResources(Me.dgvActualBankCharge, "dgvActualBankCharge")
            Me.dgvActualBankCharge.Name = "dgvActualBankCharge"
            Me.dgvActualBankCharge.ReadOnly = True
            Me.dgvActualBankCharge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvActualBankCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvActualVat
            '
            Me.dgvActualVat.DataPropertyName = "ActualBankChargeVat"
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.Format = "###,##0.00"
            Me.dgvActualVat.DefaultCellStyle = DataGridViewCellStyle11
            Me.dgvActualVat.EditingMode = False
            resources.ApplyResources(Me.dgvActualVat, "dgvActualVat")
            Me.dgvActualVat.Name = "dgvActualVat"
            Me.dgvActualVat.ReadOnly = True
            Me.dgvActualVat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvActualVat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvDepositAmount
            '
            Me.dgvDepositAmount.DataPropertyName = "DepositAmount"
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle12.Format = "###,##0.00"
            Me.dgvDepositAmount.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvDepositAmount.EditingMode = False
            resources.ApplyResources(Me.dgvDepositAmount, "dgvDepositAmount")
            Me.dgvDepositAmount.Name = "dgvDepositAmount"
            Me.dgvDepositAmount.ReadOnly = True
            Me.dgvDepositAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            '
            'dgvRate
            '
            Me.dgvRate.DataPropertyName = "Rate"
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.Format = "###,##0.00"
            Me.dgvRate.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvRate.EditingMode = False
            resources.ApplyResources(Me.dgvRate, "dgvRate")
            Me.dgvRate.Name = "dgvRate"
            Me.dgvRate.ReadOnly = True
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
            Me.dgvComputedBankCharge.EditingMode = False
            resources.ApplyResources(Me.dgvComputedBankCharge, "dgvComputedBankCharge")
            Me.dgvComputedBankCharge.Name = "dgvComputedBankCharge"
            Me.dgvComputedBankCharge.ReadOnly = True
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
            Me.dgvComputedVat.EditingMode = False
            resources.ApplyResources(Me.dgvComputedVat, "dgvComputedVat")
            Me.dgvComputedVat.Name = "dgvComputedVat"
            Me.dgvComputedVat.ReadOnly = True
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
            Me.dgvBankChargeDifference.EditingMode = False
            resources.ApplyResources(Me.dgvBankChargeDifference, "dgvBankChargeDifference")
            Me.dgvBankChargeDifference.Name = "dgvBankChargeDifference"
            Me.dgvBankChargeDifference.ReadOnly = True
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
            Me.dgvVatDifference.EditingMode = False
            resources.ApplyResources(Me.dgvVatDifference, "dgvVatDifference")
            Me.dgvVatDifference.Name = "dgvVatDifference"
            Me.dgvVatDifference.ReadOnly = True
            Me.dgvVatDifference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvVatDifference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            '
            'DgvSalesJournalIdNo
            '
            Me.DgvSalesJournalIdNo.DataPropertyName = "SalesJournalIdNo"
            resources.ApplyResources(Me.DgvSalesJournalIdNo, "DgvSalesJournalIdNo")
            Me.DgvSalesJournalIdNo.Name = "DgvSalesJournalIdNo"
            Me.DgvSalesJournalIdNo.ReadOnly = True
            '
            'bsSalesCashItems
            '
            Me.bsSalesCashItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Views.SalesCashItemView)
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
            Me.btnViewGL.DesignerSelected = False
            Me.btnViewGL.DisplayOnly = True
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
            Me.floSalesCashItemsFooter.Controls.Add(Me.btnHideJournalEntries)
            resources.ApplyResources(Me.floSalesCashItemsFooter, "floSalesCashItemsFooter")
            Me.floSalesCashItemsFooter.Name = "floSalesCashItemsFooter"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            '
            'btnHideJournalEntries
            '
            Me.btnHideJournalEntries.DesignerSelected = False
            Me.btnHideJournalEntries.DisplayOnly = True
            resources.ApplyResources(Me.btnHideJournalEntries, "btnHideJournalEntries")
            Me.btnHideJournalEntries.ImageIndex = 0
            Me.btnHideJournalEntries.Name = "btnHideJournalEntries"
            Me.btnHideJournalEntries.OriginalImageName = Nothing
            Me.btnHideJournalEntries.SecurityKey = ""
            '
            'SalesJournalEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floFullEntryArea)
            Me.Name = "SalesJournalEntry"
            Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floFullEntryArea.ResumeLayout(False)
            Me.floPurchaseJournalHeader.ResumeLayout(False)
            Me.floHeader1.ResumeLayout(False)
            Me.floHeader1.PerformLayout()
            Me.floHeader2.ResumeLayout(False)
            Me.floPurchaseJournalItems.ResumeLayout(False)
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewSalesCashItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsSalesCashItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.floJournalItemsFooter.ResumeLayout(false)
        Me.floSalesCashItemsFooter.ResumeLayout(false)
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
        Public WithEvents DataGridViewSalesCashItems As CDataGridView
        Friend WithEvents dgvSequenceSc As CdgvColumnText
        Friend WithEvents dgvCashCode As CaDgvComboBoxColumn
        Friend WithEvents dgvSaleAmount As CdgvColumnMoney
        Friend WithEvents dgvActualBankCharge As CdgvColumnMoney
        Friend WithEvents dgvActualVat As CdgvColumnMoney
        Friend WithEvents dgvDepositAmount As CdgvColumnMoney
        Friend WithEvents dgvRate As CdgvColumnMoney
        Friend WithEvents dgvComputedBankCharge As CdgvColumnMoney
        Friend WithEvents dgvComputedVat As CdgvColumnMoney
        Friend WithEvents dgvBankChargeDifference As CdgvColumnMoney
        Friend WithEvents dgvVatDifference As CdgvColumnMoney
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DgvSalesJournalIdNo As DataGridViewTextBoxColumn
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
    End Class
End Namespace