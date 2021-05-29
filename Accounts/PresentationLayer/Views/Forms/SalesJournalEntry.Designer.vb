Imports AATM.Libraries.CBaseControlsLibrary
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
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.floFullEntryArea = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.floPurchaseJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.floHeader1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New CCustomDateTimePicker()
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
            Me.dtpDateCreated = New CCustomDateTimePicker()
            Me.floPurchaseJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvJournalIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ItemVatAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.DataGridViewSalesDeposits = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequenceSc = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvDepositTypeIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvSaleAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvDepositAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvVatAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvActualBankCharge = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvRate = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvComputedBankCharge = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvComputedVat = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvBankChargeDifference = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvVatDifference = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DgvSalesJournalIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsSalesDeposits = New System.Windows.Forms.BindingSource(Me.components)
            Me.floJournalItemsFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.floSalesDepositsFooter = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
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
            CType(Me.DataGridViewSalesDeposits, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsSalesDeposits, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floJournalItemsFooter.SuspendLayout()
            Me.floSalesDepositsFooter.SuspendLayout()
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
            Me.txtJournalCode.FindEnabled = False
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
            Me.TxtIdNo.FindEnabled = True
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
            Me.txtReferenceNo.FindEnabled = True
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
            Me.txtPayeeName.FindEnabled = False
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
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
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
            Me.txtNotes.FindEnabled = True
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
            Me.chkCancelled.NoLabel = True
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
            Me.chkPosted.NoLabel = True
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
            Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewSalesDeposits)
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
            Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewJournalItems.DefaultCellStyle = DataGridViewCellStyle8
            Me.DataGridViewJournalItems.DgvFooter = Nothing
            Me.DataGridViewJournalItems.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewJournalItems, "DataGridViewJournalItems")
            Me.DataGridViewJournalItems.Ea = EventAggregator1
            Me.DataGridViewJournalItems.EditingMode = False
            Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewJournalItems.FieldsDictionary = Nothing
            Me.DataGridViewJournalItems.FirstRowDeletionEnabled = False
            Me.DataGridViewJournalItems.FirstRowInsertionEnabled = False
            Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
            Me.DataGridViewJournalItems.ReadOnly = True
            Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
            Me.DataGridViewJournalItems.ShowFooter = False
            Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = True
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
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
            Me.dgvAccountIdNo.EditingMode = False
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
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.Format = "N2"
            Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle4
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
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.Format = "N2"
            Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle5
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
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvRevCostCenterIdNo.EditingMode = False
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
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle7
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
            'DataGridViewSalesDeposits
            '
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewSalesDeposits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewSalesDeposits.AutoGenerateColumns = False
            Me.DataGridViewSalesDeposits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewSalesDeposits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceSc, Me.dgvDepositTypeIdNo, Me.dgvSaleAmount, Me.dgvDepositAmount, Me.dgvVatAmount, Me.dgvActualBankCharge, Me.dgvRate, Me.dgvComputedBankCharge, Me.dgvComputedVat, Me.dgvBankChargeDifference, Me.dgvVatDifference, Me.DataGridViewTextBoxColumn1, Me.DgvSalesJournalIdNo})
            Me.DataGridViewSalesDeposits.DataSource = Me.bsSalesDeposits
            DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewSalesDeposits.DefaultCellStyle = DataGridViewCellStyle21
            Me.DataGridViewSalesDeposits.DgvFooter = Nothing
            Me.DataGridViewSalesDeposits.DisplayOnly = False
            Me.DataGridViewSalesDeposits.Ea = EventAggregator2
            Me.DataGridViewSalesDeposits.EditingMode = False
            Me.DataGridViewSalesDeposits.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewSalesDeposits.FieldsDictionary = Nothing
            Me.DataGridViewSalesDeposits.FirstRowDeletionEnabled = True
            Me.DataGridViewSalesDeposits.FirstRowInsertionEnabled = True
            resources.ApplyResources(Me.DataGridViewSalesDeposits, "DataGridViewSalesDeposits")
            Me.DataGridViewSalesDeposits.Name = "DataGridViewSalesDeposits"
            Me.DataGridViewSalesDeposits.ReadOnly = True
            Me.DataGridViewSalesDeposits.SequenceColumn = "dgvSequenceSc"
            Me.DataGridViewSalesDeposits.SequenceFieldName = "Sequence"
            Me.DataGridViewSalesDeposits.ShowFooter = False
            Me.DataGridViewSalesDeposits.ShowInsertColumnWhenEditing = True
            '
            'dgvSequenceSc
            '
            Me.dgvSequenceSc.DataPropertyName = "Sequence"
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceSc.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvSequenceSc.DisplayOnly = True
            Me.dgvSequenceSc.EditingMode = False
            resources.ApplyResources(Me.dgvSequenceSc, "dgvSequenceSc")
            Me.dgvSequenceSc.Name = "dgvSequenceSc"
            Me.dgvSequenceSc.ReadOnly = True
            Me.dgvSequenceSc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvDepositTypeIdNo
            '
            Me.dgvDepositTypeIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvDepositTypeIdNo.DataPropertyName = "DepositTypeIdNo"
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            Me.dgvDepositTypeIdNo.DefaultCellStyle = DataGridViewCellStyle11
            Me.dgvDepositTypeIdNo.EditingMode = False
            resources.ApplyResources(Me.dgvDepositTypeIdNo, "dgvDepositTypeIdNo")
            Me.dgvDepositTypeIdNo.Name = "dgvDepositTypeIdNo"
            Me.dgvDepositTypeIdNo.ReadOnly = True
            Me.dgvDepositTypeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDepositTypeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvSaleAmount
            '
            Me.dgvSaleAmount.DataPropertyName = "SaleAmount"
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle12.Format = "###,##0.00"
            Me.dgvSaleAmount.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvSaleAmount.EditingMode = False
            resources.ApplyResources(Me.dgvSaleAmount, "dgvSaleAmount")
            Me.dgvSaleAmount.Name = "dgvSaleAmount"
            Me.dgvSaleAmount.ReadOnly = True
            Me.dgvSaleAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSaleAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvDepositAmount
            '
            Me.dgvDepositAmount.DataPropertyName = "DepositAmount"
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.Format = "###,##0.00"
            Me.dgvDepositAmount.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvDepositAmount.EditingMode = False
            resources.ApplyResources(Me.dgvDepositAmount, "dgvDepositAmount")
            Me.dgvDepositAmount.Name = "dgvDepositAmount"
            Me.dgvDepositAmount.ReadOnly = True
            Me.dgvDepositAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            '
            'dgvVatAmount
            '
            Me.dgvVatAmount.DataPropertyName = "VatAmount"
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle14.Format = "###,##0.00"
            Me.dgvVatAmount.DefaultCellStyle = DataGridViewCellStyle14
            Me.dgvVatAmount.EditingMode = False
            resources.ApplyResources(Me.dgvVatAmount, "dgvVatAmount")
            Me.dgvVatAmount.Name = "dgvVatAmount"
            Me.dgvVatAmount.ReadOnly = True
            '
            'dgvActualBankCharge
            '
            Me.dgvActualBankCharge.DataPropertyName = "ActualBankCharge"
            DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle15.Format = "###,##0.00"
            Me.dgvActualBankCharge.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgvActualBankCharge.EditingMode = False
            resources.ApplyResources(Me.dgvActualBankCharge, "dgvActualBankCharge")
            Me.dgvActualBankCharge.Name = "dgvActualBankCharge"
            Me.dgvActualBankCharge.ReadOnly = True
            Me.dgvActualBankCharge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvActualBankCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvRate
            '
            Me.dgvRate.DataPropertyName = "Rate"
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle16.Format = "###,##0.00"
            Me.dgvRate.DefaultCellStyle = DataGridViewCellStyle16
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
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle17.Format = "###,##0.00"
            Me.dgvComputedBankCharge.DefaultCellStyle = DataGridViewCellStyle17
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
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle18.Format = "###,##0.00"
            Me.dgvComputedVat.DefaultCellStyle = DataGridViewCellStyle18
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
            DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle19.Format = "###,##0.00"
            Me.dgvBankChargeDifference.DefaultCellStyle = DataGridViewCellStyle19
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
            DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle20.Format = "###,##0.00"
            Me.dgvVatDifference.DefaultCellStyle = DataGridViewCellStyle20
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
            Me.btnViewGL.DesignerSelected = False
            Me.btnViewGL.DisplayOnly = True
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
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvAccountIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvMoneyColumn
        Friend WithEvents dgvCredit As CdgvMoneyColumn
        Friend WithEvents dgvRevCostCenterIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvNotes As DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As CDgvTextColumn
        Friend WithEvents DataGridViewCheckBoxColumn3 As DataGridViewCheckBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
        Friend WithEvents dgvJournalIdNo As DataGridViewTextBoxColumn
        Friend WithEvents ItemVatAmount As DataGridViewTextBoxColumn
        Friend WithEvents dtpDateCreated As CCustomDateTimePicker
        Friend WithEvents dgvSequenceSc As CDgvTextColumn
        Friend WithEvents dgvDepositTypeIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvSaleAmount As CdgvMoneyColumn
        Friend WithEvents dgvDepositAmount As CdgvMoneyColumn
        Friend WithEvents dgvVatAmount As CdgvMoneyColumn
        Friend WithEvents dgvActualBankCharge As CdgvMoneyColumn
        Friend WithEvents dgvRate As CdgvMoneyColumn
        Friend WithEvents dgvComputedBankCharge As CdgvMoneyColumn
        Friend WithEvents dgvComputedVat As CdgvMoneyColumn
        Friend WithEvents dgvBankChargeDifference As CdgvMoneyColumn
        Friend WithEvents dgvVatDifference As CdgvMoneyColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DgvSalesJournalIdNo As DataGridViewTextBoxColumn
    End Class
End Namespace