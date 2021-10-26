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
        Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floHeader2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
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
        Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalSales = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalDeposits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalBankChargesVat = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalBankCharges = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
        'txtPayeeName
        '
        Me.txtPayeeName.BackColor = System.Drawing.Color.White
        Me.txtPayeeName.BegFindValue = Nothing
        Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayeeName.ComputedValue = false
        Me.txtPayeeName.CustomFormat = Nothing
        Me.txtPayeeName.DataBoundControl = true
        Me.txtPayeeName.EditingMode = false
        Me.txtPayeeName.EndFindValue = Nothing
        Me.txtPayeeName.FieldDescription = Nothing
        Me.txtPayeeName.FieldName = Nothing
        Me.txtPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayeeName.FindEnabled = false
        Me.floHeader1.SetFlowBreak(Me.txtPayeeName, true)
        resources.ApplyResources(Me.txtPayeeName, "txtPayeeName")
        Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
        Me.txtPayeeName.LinkedLabel = Nothing
        Me.txtPayeeName.MaximumValue = Nothing
        Me.txtPayeeName.MinimumValue = Nothing
        Me.txtPayeeName.Name = "txtPayeeName"
        Me.txtPayeeName.OldValue = Nothing
        Me.txtPayeeName.ReadOnly = true
        Me.txtPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayeeName.Translatable = false
        Me.txtPayeeName.ValueIsMandatory = true
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
        Me.floHeader1.SetFlowBreak(Me.cboAccountIdNo, true)
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
        Me.chkCancelled.FindEnabled = false
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
        Me.chkPosted.FindEnabled = false
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
        Me.chkApproved.FindEnabled = false
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
        Me.DataGridViewJournalItems.BegFindValue = Nothing
        Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.dgvIdNo, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewCheckBoxColumn2, Me.dgvJournalIdNo, Me.ItemVatAmount})
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
        Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAccountIdNo.DisplayStyleForCurrentCellOnly = true
        Me.dgvAccountIdNo.EditingMode = false
        Me.dgvAccountIdNo.FillWeight = 1!
        resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.ReadOnly = true
        Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountIdNo.Translatable = false
        '
        'dgvDebit
        '
        Me.dgvDebit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvDebit.BegFindValue = Nothing
        Me.dgvDebit.DataPropertyName = "Debit"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Format = "N2"
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
        Me.dgvCredit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCredit.BegFindValue = Nothing
        Me.dgvCredit.DataPropertyName = "Credit"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Format = "N2"
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
        Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRevCostCenterIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
        Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
        Me.dgvRevCostCenterIdNo.ReadOnly = true
        Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRevCostCenterIdNo.Translatable = false
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
        Me.dgvIdNo.BegFindValue = Nothing
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvIdNo.EditingMode = false
        Me.dgvIdNo.EndFindValue = Nothing
        Me.dgvIdNo.FieldDescription = Nothing
        Me.dgvIdNo.FieldName = Nothing
        Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvIdNo.FindEnabled = false
        resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
        Me.dgvIdNo.IgnoreCase = false
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
        Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvIdNo.Translatable = false
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
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewSalesDeposits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewSalesDeposits.AutoGenerateColumns = false
        Me.DataGridViewSalesDeposits.BegFindValue = Nothing
        Me.DataGridViewSalesDeposits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSalesDeposits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceSc, Me.dgvDepositTypeIdNo, Me.dgvSaleAmount, Me.dgvDepositAmount, Me.dgvVatAmount, Me.dgvActualBankCharge, Me.dgvRate, Me.dgvComputedBankCharge, Me.dgvComputedVat, Me.dgvBankChargeDifference, Me.dgvVatDifference, Me.DataGridViewTextBoxColumn1, Me.DgvSalesJournalIdNo})
        Me.DataGridViewSalesDeposits.DataSource = Me.bsSalesDeposits
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewSalesDeposits.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewSalesDeposits.DgvFooter = Nothing
        Me.DataGridViewSalesDeposits.DisplayOnly = false
        Me.DataGridViewSalesDeposits.Ea = EventAggregator2
        Me.DataGridViewSalesDeposits.EditingMode = false
        Me.DataGridViewSalesDeposits.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewSalesDeposits.EndFindValue = Nothing
        Me.DataGridViewSalesDeposits.FieldDescription = Nothing
        Me.DataGridViewSalesDeposits.FieldName = Nothing
        Me.DataGridViewSalesDeposits.FieldsDictionary = Nothing
        Me.DataGridViewSalesDeposits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewSalesDeposits.FindEnabled = false
        Me.DataGridViewSalesDeposits.FirstRowDeletionEnabled = true
        Me.DataGridViewSalesDeposits.FirstRowInsertionEnabled = true
        Me.DataGridViewSalesDeposits.IgnoreCase = false
        resources.ApplyResources(Me.DataGridViewSalesDeposits, "DataGridViewSalesDeposits")
        Me.DataGridViewSalesDeposits.Name = "DataGridViewSalesDeposits"
        Me.DataGridViewSalesDeposits.ReadOnly = true
        Me.DataGridViewSalesDeposits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewSalesDeposits.SequenceColumn = "dgvSequenceSc"
        Me.DataGridViewSalesDeposits.SequenceFieldName = "Sequence"
        Me.DataGridViewSalesDeposits.ShowFooter = false
        Me.DataGridViewSalesDeposits.ShowInsertColumnWhenEditing = true
        Me.DataGridViewSalesDeposits.Translatable = true
        '
        'dgvSequenceSc
        '
        Me.dgvSequenceSc.BegFindValue = Nothing
        Me.dgvSequenceSc.DataPropertyName = "Sequence"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.dgvSequenceSc.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvSequenceSc.DisplayOnly = true
        Me.dgvSequenceSc.EditingMode = false
        Me.dgvSequenceSc.EndFindValue = Nothing
        Me.dgvSequenceSc.FieldDescription = Nothing
        Me.dgvSequenceSc.FieldName = Nothing
        Me.dgvSequenceSc.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequenceSc.FindEnabled = false
        resources.ApplyResources(Me.dgvSequenceSc, "dgvSequenceSc")
        Me.dgvSequenceSc.IgnoreCase = false
        Me.dgvSequenceSc.Name = "dgvSequenceSc"
        Me.dgvSequenceSc.ReadOnly = true
        Me.dgvSequenceSc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequenceSc.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSequenceSc.Translatable = false
        '
        'dgvDepositTypeIdNo
        '
        Me.dgvDepositTypeIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvDepositTypeIdNo.DataPropertyName = "DepositTypeIdNo"
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        Me.dgvDepositTypeIdNo.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDepositTypeIdNo.EditingMode = false
        resources.ApplyResources(Me.dgvDepositTypeIdNo, "dgvDepositTypeIdNo")
        Me.dgvDepositTypeIdNo.Name = "dgvDepositTypeIdNo"
        Me.dgvDepositTypeIdNo.ReadOnly = true
        Me.dgvDepositTypeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDepositTypeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDepositTypeIdNo.Translatable = false
        '
        'dgvSaleAmount
        '
        Me.dgvSaleAmount.BegFindValue = Nothing
        Me.dgvSaleAmount.DataPropertyName = "SaleAmount"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.Format = "###,##0.00"
        Me.dgvSaleAmount.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvSaleAmount.EditingMode = false
        Me.dgvSaleAmount.EndFindValue = Nothing
        Me.dgvSaleAmount.FieldDescription = Nothing
        Me.dgvSaleAmount.FieldName = Nothing
        Me.dgvSaleAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSaleAmount.FindEnabled = false
        resources.ApplyResources(Me.dgvSaleAmount, "dgvSaleAmount")
        Me.dgvSaleAmount.Name = "dgvSaleAmount"
        Me.dgvSaleAmount.ReadOnly = true
        Me.dgvSaleAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSaleAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSaleAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvSaleAmount.Translatable = false
        '
        'dgvDepositAmount
        '
        Me.dgvDepositAmount.BegFindValue = Nothing
        Me.dgvDepositAmount.DataPropertyName = "DepositAmount"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.Format = "###,##0.00"
        Me.dgvDepositAmount.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvDepositAmount.EditingMode = false
        Me.dgvDepositAmount.EndFindValue = Nothing
        Me.dgvDepositAmount.FieldDescription = Nothing
        Me.dgvDepositAmount.FieldName = Nothing
        Me.dgvDepositAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDepositAmount.FindEnabled = false
        resources.ApplyResources(Me.dgvDepositAmount, "dgvDepositAmount")
        Me.dgvDepositAmount.Name = "dgvDepositAmount"
        Me.dgvDepositAmount.ReadOnly = true
        Me.dgvDepositAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDepositAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDepositAmount.Translatable = false
        '
        'dgvVatAmount
        '
        Me.dgvVatAmount.BegFindValue = Nothing
        Me.dgvVatAmount.DataPropertyName = "VatAmount"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.Format = "###,##0.00"
        Me.dgvVatAmount.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvVatAmount.EditingMode = false
        Me.dgvVatAmount.EndFindValue = Nothing
        Me.dgvVatAmount.FieldDescription = Nothing
        Me.dgvVatAmount.FieldName = Nothing
        Me.dgvVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvVatAmount.FindEnabled = false
        resources.ApplyResources(Me.dgvVatAmount, "dgvVatAmount")
        Me.dgvVatAmount.Name = "dgvVatAmount"
        Me.dgvVatAmount.ReadOnly = true
        Me.dgvVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvVatAmount.Translatable = false
        '
        'dgvActualBankCharge
        '
        Me.dgvActualBankCharge.BegFindValue = Nothing
        Me.dgvActualBankCharge.DataPropertyName = "ActualBankCharge"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.Format = "###,##0.00"
        Me.dgvActualBankCharge.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvActualBankCharge.EditingMode = false
        Me.dgvActualBankCharge.EndFindValue = Nothing
        Me.dgvActualBankCharge.FieldDescription = Nothing
        Me.dgvActualBankCharge.FieldName = Nothing
        Me.dgvActualBankCharge.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvActualBankCharge.FindEnabled = false
        resources.ApplyResources(Me.dgvActualBankCharge, "dgvActualBankCharge")
        Me.dgvActualBankCharge.Name = "dgvActualBankCharge"
        Me.dgvActualBankCharge.ReadOnly = true
        Me.dgvActualBankCharge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvActualBankCharge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvActualBankCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvActualBankCharge.Translatable = false
        '
        'dgvRate
        '
        Me.dgvRate.BegFindValue = Nothing
        Me.dgvRate.DataPropertyName = "Rate"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.Format = "###,##0.00"
        Me.dgvRate.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvRate.EditingMode = false
        Me.dgvRate.EndFindValue = Nothing
        Me.dgvRate.FieldDescription = Nothing
        Me.dgvRate.FieldName = Nothing
        Me.dgvRate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvRate.FindEnabled = false
        resources.ApplyResources(Me.dgvRate, "dgvRate")
        Me.dgvRate.Name = "dgvRate"
        Me.dgvRate.ReadOnly = true
        Me.dgvRate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvRate.Translatable = false
        '
        'dgvComputedBankCharge
        '
        Me.dgvComputedBankCharge.BegFindValue = Nothing
        Me.dgvComputedBankCharge.DataPropertyName = "ComputedBankCharge"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.Format = "###,##0.00"
        Me.dgvComputedBankCharge.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvComputedBankCharge.EditingMode = false
        Me.dgvComputedBankCharge.EndFindValue = Nothing
        Me.dgvComputedBankCharge.FieldDescription = Nothing
        Me.dgvComputedBankCharge.FieldName = Nothing
        Me.dgvComputedBankCharge.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvComputedBankCharge.FindEnabled = false
        resources.ApplyResources(Me.dgvComputedBankCharge, "dgvComputedBankCharge")
        Me.dgvComputedBankCharge.Name = "dgvComputedBankCharge"
        Me.dgvComputedBankCharge.ReadOnly = true
        Me.dgvComputedBankCharge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComputedBankCharge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvComputedBankCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvComputedBankCharge.Translatable = false
        '
        'dgvComputedVat
        '
        Me.dgvComputedVat.BegFindValue = Nothing
        Me.dgvComputedVat.DataPropertyName = "ComputedBankChargeVat"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.Format = "###,##0.00"
        Me.dgvComputedVat.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgvComputedVat.EditingMode = false
        Me.dgvComputedVat.EndFindValue = Nothing
        Me.dgvComputedVat.FieldDescription = Nothing
        Me.dgvComputedVat.FieldName = Nothing
        Me.dgvComputedVat.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvComputedVat.FindEnabled = false
        resources.ApplyResources(Me.dgvComputedVat, "dgvComputedVat")
        Me.dgvComputedVat.Name = "dgvComputedVat"
        Me.dgvComputedVat.ReadOnly = true
        Me.dgvComputedVat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComputedVat.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvComputedVat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvComputedVat.Translatable = false
        '
        'dgvBankChargeDifference
        '
        Me.dgvBankChargeDifference.BegFindValue = Nothing
        Me.dgvBankChargeDifference.DataPropertyName = "BankChargeDifference"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.Format = "###,##0.00"
        Me.dgvBankChargeDifference.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgvBankChargeDifference.EditingMode = false
        Me.dgvBankChargeDifference.EndFindValue = Nothing
        Me.dgvBankChargeDifference.FieldDescription = Nothing
        Me.dgvBankChargeDifference.FieldName = Nothing
        Me.dgvBankChargeDifference.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvBankChargeDifference.FindEnabled = false
        resources.ApplyResources(Me.dgvBankChargeDifference, "dgvBankChargeDifference")
        Me.dgvBankChargeDifference.Name = "dgvBankChargeDifference"
        Me.dgvBankChargeDifference.ReadOnly = true
        Me.dgvBankChargeDifference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBankChargeDifference.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvBankChargeDifference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvBankChargeDifference.Translatable = false
        '
        'dgvVatDifference
        '
        Me.dgvVatDifference.BegFindValue = Nothing
        Me.dgvVatDifference.DataPropertyName = "BankChargeVatDifference"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.Format = "###,##0.00"
        Me.dgvVatDifference.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgvVatDifference.EditingMode = false
        Me.dgvVatDifference.EndFindValue = Nothing
        Me.dgvVatDifference.FieldDescription = Nothing
        Me.dgvVatDifference.FieldName = Nothing
        Me.dgvVatDifference.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvVatDifference.FindEnabled = false
        resources.ApplyResources(Me.dgvVatDifference, "dgvVatDifference")
        Me.dgvVatDifference.Name = "dgvVatDifference"
        Me.dgvVatDifference.ReadOnly = true
        Me.dgvVatDifference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVatDifference.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvVatDifference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvVatDifference.Translatable = false
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
        Me.CLabel1.Translatable = true
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
        'txtTotalSales
        '
        Me.txtTotalSales.BackColor = System.Drawing.Color.White
        Me.txtTotalSales.BegFindValue = Nothing
        Me.txtTotalSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalSales.ComputedValue = false
        Me.txtTotalSales.CustomFormat = Nothing
        Me.txtTotalSales.DataBoundControl = true
        Me.txtTotalSales.EditingMode = true
        Me.txtTotalSales.EndFindValue = Nothing
        Me.txtTotalSales.FieldDescription = Nothing
        Me.txtTotalSales.FieldName = Nothing
        Me.txtTotalSales.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalSales.FindEnabled = false
        resources.ApplyResources(Me.txtTotalSales, "txtTotalSales")
        Me.txtTotalSales.ForeColor = System.Drawing.Color.Black
        Me.txtTotalSales.LinkedLabel = Nothing
        Me.txtTotalSales.MaximumValue = Nothing
        Me.txtTotalSales.MinimumValue = Nothing
        Me.txtTotalSales.Name = "txtTotalSales"
        Me.txtTotalSales.OldValue = Nothing
        Me.txtTotalSales.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalSales.Translatable = false
        '
        'txtTotalDeposits
        '
        Me.txtTotalDeposits.BackColor = System.Drawing.Color.White
        Me.txtTotalDeposits.BegFindValue = Nothing
        Me.txtTotalDeposits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDeposits.ComputedValue = false
        Me.txtTotalDeposits.CustomFormat = Nothing
        Me.txtTotalDeposits.DataBoundControl = true
        Me.txtTotalDeposits.EditingMode = true
        Me.txtTotalDeposits.EndFindValue = Nothing
        Me.txtTotalDeposits.FieldDescription = Nothing
        Me.txtTotalDeposits.FieldName = Nothing
        Me.txtTotalDeposits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalDeposits.FindEnabled = false
        resources.ApplyResources(Me.txtTotalDeposits, "txtTotalDeposits")
        Me.txtTotalDeposits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDeposits.LinkedLabel = Nothing
        Me.txtTotalDeposits.MaximumValue = Nothing
        Me.txtTotalDeposits.MinimumValue = Nothing
        Me.txtTotalDeposits.Name = "txtTotalDeposits"
        Me.txtTotalDeposits.OldValue = Nothing
        Me.txtTotalDeposits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalDeposits.Translatable = false
        '
        'txtTotalBankChargesVat
        '
        Me.txtTotalBankChargesVat.BackColor = System.Drawing.Color.White
        Me.txtTotalBankChargesVat.BegFindValue = Nothing
        Me.txtTotalBankChargesVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBankChargesVat.ComputedValue = false
        Me.txtTotalBankChargesVat.CustomFormat = Nothing
        Me.txtTotalBankChargesVat.DataBoundControl = true
        Me.txtTotalBankChargesVat.EditingMode = true
        Me.txtTotalBankChargesVat.EndFindValue = Nothing
        Me.txtTotalBankChargesVat.FieldDescription = Nothing
        Me.txtTotalBankChargesVat.FieldName = Nothing
        Me.txtTotalBankChargesVat.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalBankChargesVat.FindEnabled = false
        resources.ApplyResources(Me.txtTotalBankChargesVat, "txtTotalBankChargesVat")
        Me.txtTotalBankChargesVat.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBankChargesVat.LinkedLabel = Nothing
        Me.txtTotalBankChargesVat.MaximumValue = Nothing
        Me.txtTotalBankChargesVat.MinimumValue = Nothing
        Me.txtTotalBankChargesVat.Name = "txtTotalBankChargesVat"
        Me.txtTotalBankChargesVat.OldValue = Nothing
        Me.txtTotalBankChargesVat.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalBankChargesVat.Translatable = false
        '
        'txtTotalBankCharges
        '
        Me.txtTotalBankCharges.BackColor = System.Drawing.Color.White
        Me.txtTotalBankCharges.BegFindValue = Nothing
        Me.txtTotalBankCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBankCharges.ComputedValue = false
        Me.txtTotalBankCharges.CustomFormat = Nothing
        Me.txtTotalBankCharges.DataBoundControl = true
        Me.txtTotalBankCharges.EditingMode = true
        Me.txtTotalBankCharges.EndFindValue = Nothing
        Me.txtTotalBankCharges.FieldDescription = Nothing
        Me.txtTotalBankCharges.FieldName = Nothing
        Me.txtTotalBankCharges.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalBankCharges.FindEnabled = false
        resources.ApplyResources(Me.txtTotalBankCharges, "txtTotalBankCharges")
        Me.txtTotalBankCharges.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBankCharges.LinkedLabel = Nothing
        Me.txtTotalBankCharges.MaximumValue = Nothing
        Me.txtTotalBankCharges.MinimumValue = Nothing
        Me.txtTotalBankCharges.Name = "txtTotalBankCharges"
        Me.txtTotalBankCharges.OldValue = Nothing
        Me.txtTotalBankCharges.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalBankCharges.Translatable = false
        '
        'SalesJournalEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.txtTotalBankChargesVat)
        Me.Controls.Add(Me.txtTotalBankCharges)
        Me.Controls.Add(Me.txtTotalSales)
        Me.Controls.Add(Me.txtTotalDeposits)
        Me.Controls.Add(Me.txtTotalCredits)
        Me.Controls.Add(Me.txtTotalDebits)
        Me.Controls.Add(Me.floFullEntryArea)
        Me.Name = "SalesJournalEntry"
        Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
        Me.Controls.SetChildIndex(Me.txtTotalDebits, 0)
        Me.Controls.SetChildIndex(Me.txtTotalCredits, 0)
        Me.Controls.SetChildIndex(Me.txtTotalDeposits, 0)
        Me.Controls.SetChildIndex(Me.txtTotalSales, 0)
        Me.Controls.SetChildIndex(Me.txtTotalBankCharges, 0)
        Me.Controls.SetChildIndex(Me.txtTotalBankChargesVat, 0)
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
        Friend WithEvents lblDateCreated As CLabel
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
        Friend WithEvents chkCancelled As UcCheckBox
        Friend WithEvents chkPosted As UcCheckBox
        Friend WithEvents chkApproved As UcCheckBox
        Friend WithEvents txtTotalDebits As CTextBox
        Friend WithEvents txtTotalCredits As CTextBox
        Friend WithEvents txtTotalSales As CTextBox
        Friend WithEvents txtTotalDeposits As CTextBox
        Friend WithEvents txtTotalBankChargesVat As CTextBox
        Friend WithEvents txtTotalBankCharges As CTextBox
    End Class
End Namespace