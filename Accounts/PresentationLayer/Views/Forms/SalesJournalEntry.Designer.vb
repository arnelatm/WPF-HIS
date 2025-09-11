Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Presentation.Forms

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
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floHeader2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.chkApproved = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpDateCreated = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.floPurchaseJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
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
            Me.DataGridViewSalesDeposits = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
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
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'txtJournalCode
            '
            Me.txtJournalCode.BackColor = System.Drawing.Color.White
            Me.txtJournalCode.BegFindValue = Nothing
            Me.txtJournalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtJournalCode.ComputedValue = True
            Me.txtJournalCode.CustomFormat = Nothing
            Me.txtJournalCode.DataBoundControl = True
            Me.txtJournalCode.DisplayOnly = True
            Me.txtJournalCode.EditingMode = True
            Me.txtJournalCode.EndFindValue = Nothing
            Me.txtJournalCode.FieldDescription = Nothing
            Me.txtJournalCode.FieldName = Nothing
            Me.txtJournalCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtJournalCode.FindEnabled = False
            resources.ApplyResources(Me.txtJournalCode, "txtJournalCode")
            Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
            Me.txtJournalCode.LinkedLabel = Nothing
            Me.txtJournalCode.MaximumValue = Nothing
            Me.txtJournalCode.MinimumValue = Nothing
            Me.txtJournalCode.Name = "txtJournalCode"
            Me.txtJournalCode.OldValue = Nothing
            Me.txtJournalCode.OverrideMaxLength = 0
            Me.txtJournalCode.ReadOnly = True
            Me.txtJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalCode.TabStop = False
            Me.txtJournalCode.Translatable = False
            Me.txtJournalCode.ValueIsMandatory = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = True
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblReferenceNo
            '
            Me.lblReferenceNo.BackColor = System.Drawing.Color.Transparent
            Me.lblReferenceNo.DisplayOnly = True
            Me.lblReferenceNo.EditingMode = False
            resources.ApplyResources(Me.lblReferenceNo, "lblReferenceNo")
            Me.lblReferenceNo.Name = "lblReferenceNo"
            Me.lblReferenceNo.Translatable = True
            '
            'txtReferenceNo
            '
            Me.txtReferenceNo.BackColor = System.Drawing.Color.White
            Me.txtReferenceNo.BegFindValue = Nothing
            Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReferenceNo.ComputedValue = False
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            Me.txtReferenceNo.EditingMode = False
            Me.txtReferenceNo.EndFindValue = Nothing
            Me.txtReferenceNo.FieldDescription = Nothing
            Me.txtReferenceNo.FieldName = Nothing
            Me.txtReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReferenceNo.FindEnabled = True
            resources.ApplyResources(Me.txtReferenceNo, "txtReferenceNo")
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.OverrideMaxLength = 0
            Me.txtReferenceNo.ReadOnly = True
            Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReferenceNo.Translatable = False
            Me.txtReferenceNo.ValueIsMandatory = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.BackColor = System.Drawing.Color.Transparent
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            resources.ApplyResources(Me.lblTransactionDate, "lblTransactionDate")
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Translatable = True
            '
            'dtpTransactionDate
            '
            resources.ApplyResources(Me.dtpTransactionDate, "dtpTransactionDate")
            Me.dtpTransactionDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpTransactionDate.DefaultValue = Nothing
            Me.dtpTransactionDate.DisplayOnly = False
            Me.dtpTransactionDate.DtpDefaultValue = Nothing
            Me.dtpTransactionDate.EditingMode = False
            Me.dtpTransactionDate.EditsAllowed = False
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.TargetCalendar = Nothing
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'txtPayeeName
            '
            Me.txtPayeeName.BackColor = System.Drawing.Color.White
            Me.txtPayeeName.BegFindValue = Nothing
            Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayeeName.ComputedValue = False
            Me.txtPayeeName.CustomFormat = Nothing
            Me.txtPayeeName.DataBoundControl = True
            Me.txtPayeeName.EditingMode = False
            Me.txtPayeeName.EndFindValue = Nothing
            Me.txtPayeeName.FieldDescription = Nothing
            Me.txtPayeeName.FieldName = Nothing
            Me.txtPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayeeName.FindEnabled = False
            Me.floHeader1.SetFlowBreak(Me.txtPayeeName, True)
            resources.ApplyResources(Me.txtPayeeName, "txtPayeeName")
            Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
            Me.txtPayeeName.LinkedLabel = Nothing
            Me.txtPayeeName.MaximumValue = Nothing
            Me.txtPayeeName.MinimumValue = Nothing
            Me.txtPayeeName.Name = "txtPayeeName"
            Me.txtPayeeName.OldValue = Nothing
            Me.txtPayeeName.OverrideMaxLength = 0
            Me.txtPayeeName.ReadOnly = True
            Me.txtPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayeeName.Translatable = False
            Me.txtPayeeName.ValueIsMandatory = True
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Translatable = True
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.BegFindValue = Nothing
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DataValue = Nothing
            Me.cboAccountIdNo.DefaultValue = ""
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.DropDownHeight = 21
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboAccountIdNo.Editable = True
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.EndFindValue = Nothing
            Me.cboAccountIdNo.FieldDescription = Nothing
            Me.cboAccountIdNo.FieldName = Nothing
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAccountIdNo.FindEnabled = False
            Me.floHeader1.SetFlowBreak(Me.cboAccountIdNo, True)
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IgnoreCase = False
            Me.cboAccountIdNo.LimitToList = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestCharCount = 0
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.Translatable = False
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'lblNotes
            '
            Me.lblNotes.BackColor = System.Drawing.Color.Transparent
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'floHeader2
            '
            Me.floHeader2.BackColor = System.Drawing.Color.Transparent
            Me.floHeader2.Controls.Add(Me.chkCancelled)
            Me.floHeader2.Controls.Add(Me.chkPosted)
            Me.floHeader2.Controls.Add(Me.chkApproved)
            Me.floHeader2.Controls.Add(Me.lblDateCreated)
            Me.floHeader2.Controls.Add(Me.dtpDateCreated)
            Me.floPurchaseJournalHeader.SetFlowBreak(Me.floHeader2, True)
            resources.ApplyResources(Me.floHeader2, "floHeader2")
            Me.floHeader2.Name = "floHeader2"
            Me.floHeader2.TabStop = True
            '
            'chkCancelled
            '
            resources.ApplyResources(Me.chkCancelled, "chkCancelled")
            Me.chkCancelled.BackColor = System.Drawing.Color.Transparent
            Me.chkCancelled.BegFindValue = Nothing
            Me.chkCancelled.Checked = False
            Me.chkCancelled.DisplayOnly = True
            Me.chkCancelled.EditingMode = False
            Me.chkCancelled.EndFindValue = Nothing
            Me.chkCancelled.FieldDescription = Nothing
            Me.chkCancelled.FieldName = Nothing
            Me.chkCancelled.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkCancelled.FindEnabled = False
            Me.chkCancelled.IgnoreCase = False
            Me.chkCancelled.LinkedLabel = Nothing
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkCancelled.TabStop = False
            Me.chkCancelled.Translatable = True
            '
            'chkPosted
            '
            resources.ApplyResources(Me.chkPosted, "chkPosted")
            Me.chkPosted.BackColor = System.Drawing.Color.Transparent
            Me.chkPosted.BegFindValue = Nothing
            Me.chkPosted.Checked = False
            Me.chkPosted.DisplayOnly = True
            Me.chkPosted.EditingMode = False
            Me.chkPosted.EndFindValue = Nothing
            Me.chkPosted.FieldDescription = Nothing
            Me.chkPosted.FieldName = Nothing
            Me.chkPosted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkPosted.FindEnabled = False
            Me.chkPosted.IgnoreCase = False
            Me.chkPosted.LinkedLabel = Nothing
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkPosted.TabStop = False
            Me.chkPosted.Translatable = True
            '
            'chkApproved
            '
            resources.ApplyResources(Me.chkApproved, "chkApproved")
            Me.chkApproved.BackColor = System.Drawing.Color.Transparent
            Me.chkApproved.BegFindValue = Nothing
            Me.chkApproved.Checked = False
            Me.chkApproved.EditingMode = False
            Me.chkApproved.EndFindValue = Nothing
            Me.chkApproved.FieldDescription = Nothing
            Me.chkApproved.FieldName = Nothing
            Me.chkApproved.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkApproved.FindEnabled = False
            Me.floHeader2.SetFlowBreak(Me.chkApproved, True)
            Me.chkApproved.IgnoreCase = False
            Me.chkApproved.LinkedLabel = Nothing
            Me.chkApproved.Name = "chkApproved"
            Me.chkApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkApproved.Translatable = True
            '
            'lblDateCreated
            '
            Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
            Me.lblDateCreated.Name = "lblDateCreated"
            Me.lblDateCreated.Translatable = True
            '
            'dtpDateCreated
            '
            resources.ApplyResources(Me.dtpDateCreated, "dtpDateCreated")
            Me.dtpDateCreated.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpDateCreated.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpDateCreated.DefaultValue = Nothing
            Me.dtpDateCreated.DisplayOnly = True
            Me.dtpDateCreated.DtpDefaultValue = Nothing
            Me.dtpDateCreated.EditingMode = False
            Me.dtpDateCreated.EditsAllowed = False
            Me.dtpDateCreated.ForeColor = System.Drawing.Color.Black
            Me.dtpDateCreated.LinkedLabel = Nothing
            Me.dtpDateCreated.Name = "dtpDateCreated"
            Me.dtpDateCreated.ReadOnlyDp = True
            Me.dtpDateCreated.SecurityKey = Nothing
            Me.dtpDateCreated.ShowLongDate = False
            Me.dtpDateCreated.ShowTime = True
            Me.dtpDateCreated.TargetCalendar = Nothing
            Me.dtpDateCreated.Translatable = False
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
            Me.DataGridViewJournalItems.BegFindValue = Nothing
            Me.DataGridViewJournalItems.Cached = False
            Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.dgvIdNo, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewCheckBoxColumn2, Me.dgvJournalIdNo, Me.ItemVatAmount})
            Me.DataGridViewJournalItems.DataFilter = Nothing
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
            Me.DataGridViewJournalItems.EndFindValue = Nothing
            Me.DataGridViewJournalItems.FieldDescription = Nothing
            Me.DataGridViewJournalItems.FieldName = Nothing
            Me.DataGridViewJournalItems.FieldsDictionary = Nothing
            Me.DataGridViewJournalItems.FindColumnNo = CType(0, Short)
            Me.DataGridViewJournalItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewJournalItems.FindEnabled = False
            Me.DataGridViewJournalItems.FirstRowDeletionEnabled = False
            Me.DataGridViewJournalItems.FirstRowInsertionEnabled = False
            Me.DataGridViewJournalItems.IgnoreCase = False
            Me.DataGridViewJournalItems.IsDirty = False
            Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
            Me.DataGridViewJournalItems.OldCellValue = Nothing
            Me.DataGridViewJournalItems.ReadOnly = True
            Me.DataGridViewJournalItems.Searchable = True
            Me.DataGridViewJournalItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewJournalItems.SecurityKey = ""
            Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
            Me.DataGridViewJournalItems.ShowFooter = False
            Me.DataGridViewJournalItems.Translatable = True
            '
            'dgvSequence
            '
            Me.dgvSequence.BegFindValue = Nothing
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.EndFindValue = Nothing
            Me.dgvSequence.FieldDescription = Nothing
            Me.dgvSequence.FieldName = Nothing
            Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequence.FindEnabled = False
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.IgnoreCase = False
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequence.Translatable = False
            '
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.AutoComplete = False
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
            Me.dgvAccountIdNo.SuggestCharCount = 0
            Me.dgvAccountIdNo.Translatable = False
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
            Me.dgvDebit.EditingMode = False
            Me.dgvDebit.EndFindValue = Nothing
            Me.dgvDebit.FieldDescription = Nothing
            Me.dgvDebit.FieldName = Nothing
            Me.dgvDebit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDebit.FindEnabled = False
            resources.ApplyResources(Me.dgvDebit, "dgvDebit")
            Me.dgvDebit.Name = "dgvDebit"
            Me.dgvDebit.ReadOnly = True
            Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDebit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDebit.Translatable = False
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
            Me.dgvCredit.EditingMode = False
            Me.dgvCredit.EndFindValue = Nothing
            Me.dgvCredit.FieldDescription = Nothing
            Me.dgvCredit.FieldName = Nothing
            Me.dgvCredit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvCredit.FindEnabled = False
            resources.ApplyResources(Me.dgvCredit, "dgvCredit")
            Me.dgvCredit.Name = "dgvCredit"
            Me.dgvCredit.ReadOnly = True
            Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCredit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvCredit.Translatable = False
            '
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.AutoComplete = False
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
            Me.dgvRevCostCenterIdNo.SuggestCharCount = 0
            Me.dgvRevCostCenterIdNo.Translatable = False
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
            Me.dgvIdNo.BegFindValue = Nothing
            Me.dgvIdNo.DataPropertyName = "IdNo"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvIdNo.EditingMode = False
            Me.dgvIdNo.EndFindValue = Nothing
            Me.dgvIdNo.FieldDescription = Nothing
            Me.dgvIdNo.FieldName = Nothing
            Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvIdNo.FindEnabled = False
            resources.ApplyResources(Me.dgvIdNo, "dgvIdNo")
            Me.dgvIdNo.IgnoreCase = False
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvIdNo.Translatable = False
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
            Me.DataGridViewSalesDeposits.BegFindValue = Nothing
            Me.DataGridViewSalesDeposits.Cached = False
            Me.DataGridViewSalesDeposits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewSalesDeposits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceSc, Me.dgvDepositTypeIdNo, Me.dgvSaleAmount, Me.dgvDepositAmount, Me.dgvVatAmount, Me.dgvActualBankCharge, Me.dgvRate, Me.dgvComputedBankCharge, Me.dgvComputedVat, Me.dgvBankChargeDifference, Me.dgvVatDifference, Me.DataGridViewTextBoxColumn1, Me.DgvSalesJournalIdNo})
            Me.DataGridViewSalesDeposits.DataFilter = Nothing
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
            Me.DataGridViewSalesDeposits.EndFindValue = Nothing
            Me.DataGridViewSalesDeposits.FieldDescription = Nothing
            Me.DataGridViewSalesDeposits.FieldName = Nothing
            Me.DataGridViewSalesDeposits.FieldsDictionary = Nothing
            Me.DataGridViewSalesDeposits.FindColumnNo = CType(0, Short)
            Me.DataGridViewSalesDeposits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewSalesDeposits.FindEnabled = False
            Me.DataGridViewSalesDeposits.FirstRowDeletionEnabled = True
            Me.DataGridViewSalesDeposits.FirstRowInsertionEnabled = True
            Me.DataGridViewSalesDeposits.IgnoreCase = False
            Me.DataGridViewSalesDeposits.IsDirty = False
            resources.ApplyResources(Me.DataGridViewSalesDeposits, "DataGridViewSalesDeposits")
            Me.DataGridViewSalesDeposits.Name = "DataGridViewSalesDeposits"
            Me.DataGridViewSalesDeposits.OldCellValue = Nothing
            Me.DataGridViewSalesDeposits.ReadOnly = True
            Me.DataGridViewSalesDeposits.Searchable = True
            Me.DataGridViewSalesDeposits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewSalesDeposits.SecurityKey = ""
            Me.DataGridViewSalesDeposits.SequenceColumn = "dgvSequenceSc"
            Me.DataGridViewSalesDeposits.SequenceFieldName = "Sequence"
            Me.DataGridViewSalesDeposits.ShowFooter = False
            Me.DataGridViewSalesDeposits.Translatable = True
            '
            'dgvSequenceSc
            '
            Me.dgvSequenceSc.BegFindValue = Nothing
            Me.dgvSequenceSc.DataPropertyName = "Sequence"
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceSc.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvSequenceSc.DisplayOnly = True
            Me.dgvSequenceSc.EditingMode = False
            Me.dgvSequenceSc.EndFindValue = Nothing
            Me.dgvSequenceSc.FieldDescription = Nothing
            Me.dgvSequenceSc.FieldName = Nothing
            Me.dgvSequenceSc.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequenceSc.FindEnabled = False
            resources.ApplyResources(Me.dgvSequenceSc, "dgvSequenceSc")
            Me.dgvSequenceSc.IgnoreCase = False
            Me.dgvSequenceSc.Name = "dgvSequenceSc"
            Me.dgvSequenceSc.ReadOnly = True
            Me.dgvSequenceSc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequenceSc.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequenceSc.Translatable = False
            '
            'dgvDepositTypeIdNo
            '
            Me.dgvDepositTypeIdNo.AutoComplete = False
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
            Me.dgvDepositTypeIdNo.SuggestCharCount = 0
            Me.dgvDepositTypeIdNo.Translatable = False
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
            Me.dgvSaleAmount.EditingMode = False
            Me.dgvSaleAmount.EndFindValue = Nothing
            Me.dgvSaleAmount.FieldDescription = Nothing
            Me.dgvSaleAmount.FieldName = Nothing
            Me.dgvSaleAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSaleAmount.FindEnabled = False
            resources.ApplyResources(Me.dgvSaleAmount, "dgvSaleAmount")
            Me.dgvSaleAmount.Name = "dgvSaleAmount"
            Me.dgvSaleAmount.ReadOnly = True
            Me.dgvSaleAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSaleAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSaleAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvSaleAmount.Translatable = False
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
            Me.dgvDepositAmount.EditingMode = False
            Me.dgvDepositAmount.EndFindValue = Nothing
            Me.dgvDepositAmount.FieldDescription = Nothing
            Me.dgvDepositAmount.FieldName = Nothing
            Me.dgvDepositAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDepositAmount.FindEnabled = False
            resources.ApplyResources(Me.dgvDepositAmount, "dgvDepositAmount")
            Me.dgvDepositAmount.Name = "dgvDepositAmount"
            Me.dgvDepositAmount.ReadOnly = True
            Me.dgvDepositAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvDepositAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDepositAmount.Translatable = False
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
            Me.dgvVatAmount.EditingMode = False
            Me.dgvVatAmount.EndFindValue = Nothing
            Me.dgvVatAmount.FieldDescription = Nothing
            Me.dgvVatAmount.FieldName = Nothing
            Me.dgvVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvVatAmount.FindEnabled = False
            resources.ApplyResources(Me.dgvVatAmount, "dgvVatAmount")
            Me.dgvVatAmount.Name = "dgvVatAmount"
            Me.dgvVatAmount.ReadOnly = True
            Me.dgvVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvVatAmount.Translatable = False
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
            Me.dgvActualBankCharge.EditingMode = False
            Me.dgvActualBankCharge.EndFindValue = Nothing
            Me.dgvActualBankCharge.FieldDescription = Nothing
            Me.dgvActualBankCharge.FieldName = Nothing
            Me.dgvActualBankCharge.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvActualBankCharge.FindEnabled = False
            resources.ApplyResources(Me.dgvActualBankCharge, "dgvActualBankCharge")
            Me.dgvActualBankCharge.Name = "dgvActualBankCharge"
            Me.dgvActualBankCharge.ReadOnly = True
            Me.dgvActualBankCharge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvActualBankCharge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvActualBankCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvActualBankCharge.Translatable = False
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
            Me.dgvRate.EditingMode = False
            Me.dgvRate.EndFindValue = Nothing
            Me.dgvRate.FieldDescription = Nothing
            Me.dgvRate.FieldName = Nothing
            Me.dgvRate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvRate.FindEnabled = False
            resources.ApplyResources(Me.dgvRate, "dgvRate")
            Me.dgvRate.Name = "dgvRate"
            Me.dgvRate.ReadOnly = True
            Me.dgvRate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvRate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvRate.Translatable = False
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
            Me.dgvComputedBankCharge.EditingMode = False
            Me.dgvComputedBankCharge.EndFindValue = Nothing
            Me.dgvComputedBankCharge.FieldDescription = Nothing
            Me.dgvComputedBankCharge.FieldName = Nothing
            Me.dgvComputedBankCharge.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvComputedBankCharge.FindEnabled = False
            resources.ApplyResources(Me.dgvComputedBankCharge, "dgvComputedBankCharge")
            Me.dgvComputedBankCharge.Name = "dgvComputedBankCharge"
            Me.dgvComputedBankCharge.ReadOnly = True
            Me.dgvComputedBankCharge.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvComputedBankCharge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvComputedBankCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvComputedBankCharge.Translatable = False
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
            Me.dgvComputedVat.EditingMode = False
            Me.dgvComputedVat.EndFindValue = Nothing
            Me.dgvComputedVat.FieldDescription = Nothing
            Me.dgvComputedVat.FieldName = Nothing
            Me.dgvComputedVat.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvComputedVat.FindEnabled = False
            resources.ApplyResources(Me.dgvComputedVat, "dgvComputedVat")
            Me.dgvComputedVat.Name = "dgvComputedVat"
            Me.dgvComputedVat.ReadOnly = True
            Me.dgvComputedVat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvComputedVat.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvComputedVat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvComputedVat.Translatable = False
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
            Me.dgvBankChargeDifference.EditingMode = False
            Me.dgvBankChargeDifference.EndFindValue = Nothing
            Me.dgvBankChargeDifference.FieldDescription = Nothing
            Me.dgvBankChargeDifference.FieldName = Nothing
            Me.dgvBankChargeDifference.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvBankChargeDifference.FindEnabled = False
            resources.ApplyResources(Me.dgvBankChargeDifference, "dgvBankChargeDifference")
            Me.dgvBankChargeDifference.Name = "dgvBankChargeDifference"
            Me.dgvBankChargeDifference.ReadOnly = True
            Me.dgvBankChargeDifference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvBankChargeDifference.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvBankChargeDifference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvBankChargeDifference.Translatable = False
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
            Me.dgvVatDifference.EditingMode = False
            Me.dgvVatDifference.EndFindValue = Nothing
            Me.dgvVatDifference.FieldDescription = Nothing
            Me.dgvVatDifference.FieldName = Nothing
            Me.dgvVatDifference.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvVatDifference.FindEnabled = False
            resources.ApplyResources(Me.dgvVatDifference, "dgvVatDifference")
            Me.dgvVatDifference.Name = "dgvVatDifference"
            Me.dgvVatDifference.ReadOnly = True
            Me.dgvVatDifference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvVatDifference.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvVatDifference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvVatDifference.Translatable = False
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
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'btnHideJournalEntries
            '
            Me.btnHideJournalEntries.DesignerSelected = False
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
            Me.txtTotalDebits.ComputedValue = False
            Me.txtTotalDebits.CustomFormat = Nothing
            Me.txtTotalDebits.DataBoundControl = True
            Me.txtTotalDebits.EditingMode = True
            Me.txtTotalDebits.EndFindValue = Nothing
            Me.txtTotalDebits.FieldDescription = Nothing
            Me.txtTotalDebits.FieldName = Nothing
            Me.txtTotalDebits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalDebits.FindEnabled = False
            resources.ApplyResources(Me.txtTotalDebits, "txtTotalDebits")
            Me.txtTotalDebits.ForeColor = System.Drawing.Color.Black
            Me.txtTotalDebits.LinkedLabel = Nothing
            Me.txtTotalDebits.MaximumValue = Nothing
            Me.txtTotalDebits.MinimumValue = Nothing
            Me.txtTotalDebits.Name = "txtTotalDebits"
            Me.txtTotalDebits.OldValue = Nothing
            Me.txtTotalDebits.OverrideMaxLength = 0
            Me.txtTotalDebits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalDebits.Translatable = False
            '
            'txtTotalCredits
            '
            Me.txtTotalCredits.BackColor = System.Drawing.Color.White
            Me.txtTotalCredits.BegFindValue = Nothing
            Me.txtTotalCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalCredits.ComputedValue = False
            Me.txtTotalCredits.CustomFormat = Nothing
            Me.txtTotalCredits.DataBoundControl = True
            Me.txtTotalCredits.EditingMode = True
            Me.txtTotalCredits.EndFindValue = Nothing
            Me.txtTotalCredits.FieldDescription = Nothing
            Me.txtTotalCredits.FieldName = Nothing
            Me.txtTotalCredits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalCredits.FindEnabled = False
            resources.ApplyResources(Me.txtTotalCredits, "txtTotalCredits")
            Me.txtTotalCredits.ForeColor = System.Drawing.Color.Black
            Me.txtTotalCredits.LinkedLabel = Nothing
            Me.txtTotalCredits.MaximumValue = Nothing
            Me.txtTotalCredits.MinimumValue = Nothing
            Me.txtTotalCredits.Name = "txtTotalCredits"
            Me.txtTotalCredits.OldValue = Nothing
            Me.txtTotalCredits.OverrideMaxLength = 0
            Me.txtTotalCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalCredits.Translatable = False
            '
            'txtTotalSales
            '
            Me.txtTotalSales.BackColor = System.Drawing.Color.White
            Me.txtTotalSales.BegFindValue = Nothing
            Me.txtTotalSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalSales.ComputedValue = False
            Me.txtTotalSales.CustomFormat = Nothing
            Me.txtTotalSales.DataBoundControl = True
            Me.txtTotalSales.EditingMode = True
            Me.txtTotalSales.EndFindValue = Nothing
            Me.txtTotalSales.FieldDescription = Nothing
            Me.txtTotalSales.FieldName = Nothing
            Me.txtTotalSales.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalSales.FindEnabled = False
            resources.ApplyResources(Me.txtTotalSales, "txtTotalSales")
            Me.txtTotalSales.ForeColor = System.Drawing.Color.Black
            Me.txtTotalSales.LinkedLabel = Nothing
            Me.txtTotalSales.MaximumValue = Nothing
            Me.txtTotalSales.MinimumValue = Nothing
            Me.txtTotalSales.Name = "txtTotalSales"
            Me.txtTotalSales.OldValue = Nothing
            Me.txtTotalSales.OverrideMaxLength = 0
            Me.txtTotalSales.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalSales.Translatable = False
            '
            'txtTotalDeposits
            '
            Me.txtTotalDeposits.BackColor = System.Drawing.Color.White
            Me.txtTotalDeposits.BegFindValue = Nothing
            Me.txtTotalDeposits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalDeposits.ComputedValue = False
            Me.txtTotalDeposits.CustomFormat = Nothing
            Me.txtTotalDeposits.DataBoundControl = True
            Me.txtTotalDeposits.EditingMode = True
            Me.txtTotalDeposits.EndFindValue = Nothing
            Me.txtTotalDeposits.FieldDescription = Nothing
            Me.txtTotalDeposits.FieldName = Nothing
            Me.txtTotalDeposits.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalDeposits.FindEnabled = False
            resources.ApplyResources(Me.txtTotalDeposits, "txtTotalDeposits")
            Me.txtTotalDeposits.ForeColor = System.Drawing.Color.Black
            Me.txtTotalDeposits.LinkedLabel = Nothing
            Me.txtTotalDeposits.MaximumValue = Nothing
            Me.txtTotalDeposits.MinimumValue = Nothing
            Me.txtTotalDeposits.Name = "txtTotalDeposits"
            Me.txtTotalDeposits.OldValue = Nothing
            Me.txtTotalDeposits.OverrideMaxLength = 0
            Me.txtTotalDeposits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalDeposits.Translatable = False
            '
            'txtTotalBankChargesVat
            '
            Me.txtTotalBankChargesVat.BackColor = System.Drawing.Color.White
            Me.txtTotalBankChargesVat.BegFindValue = Nothing
            Me.txtTotalBankChargesVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalBankChargesVat.ComputedValue = False
            Me.txtTotalBankChargesVat.CustomFormat = Nothing
            Me.txtTotalBankChargesVat.DataBoundControl = True
            Me.txtTotalBankChargesVat.EditingMode = True
            Me.txtTotalBankChargesVat.EndFindValue = Nothing
            Me.txtTotalBankChargesVat.FieldDescription = Nothing
            Me.txtTotalBankChargesVat.FieldName = Nothing
            Me.txtTotalBankChargesVat.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalBankChargesVat.FindEnabled = False
            resources.ApplyResources(Me.txtTotalBankChargesVat, "txtTotalBankChargesVat")
            Me.txtTotalBankChargesVat.ForeColor = System.Drawing.Color.Black
            Me.txtTotalBankChargesVat.LinkedLabel = Nothing
            Me.txtTotalBankChargesVat.MaximumValue = Nothing
            Me.txtTotalBankChargesVat.MinimumValue = Nothing
            Me.txtTotalBankChargesVat.Name = "txtTotalBankChargesVat"
            Me.txtTotalBankChargesVat.OldValue = Nothing
            Me.txtTotalBankChargesVat.OverrideMaxLength = 0
            Me.txtTotalBankChargesVat.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalBankChargesVat.Translatable = False
            '
            'txtTotalBankCharges
            '
            Me.txtTotalBankCharges.BackColor = System.Drawing.Color.White
            Me.txtTotalBankCharges.BegFindValue = Nothing
            Me.txtTotalBankCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalBankCharges.ComputedValue = False
            Me.txtTotalBankCharges.CustomFormat = Nothing
            Me.txtTotalBankCharges.DataBoundControl = True
            Me.txtTotalBankCharges.EditingMode = True
            Me.txtTotalBankCharges.EndFindValue = Nothing
            Me.txtTotalBankCharges.FieldDescription = Nothing
            Me.txtTotalBankCharges.FieldName = Nothing
            Me.txtTotalBankCharges.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalBankCharges.FindEnabled = False
            resources.ApplyResources(Me.txtTotalBankCharges, "txtTotalBankCharges")
            Me.txtTotalBankCharges.ForeColor = System.Drawing.Color.Black
            Me.txtTotalBankCharges.LinkedLabel = Nothing
            Me.txtTotalBankCharges.MaximumValue = Nothing
            Me.txtTotalBankCharges.MinimumValue = Nothing
            Me.txtTotalBankCharges.Name = "txtTotalBankCharges"
            Me.txtTotalBankCharges.OldValue = Nothing
            Me.txtTotalBankCharges.OverrideMaxLength = 0
            Me.txtTotalBankCharges.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalBankCharges.Translatable = False
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
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floFullEntryArea.ResumeLayout(False)
            Me.floPurchaseJournalHeader.ResumeLayout(False)
            Me.floHeader1.ResumeLayout(False)
            Me.floHeader1.PerformLayout()
            Me.floHeader2.ResumeLayout(False)
            Me.floHeader2.PerformLayout()
            Me.floPurchaseJournalItems.ResumeLayout(False)
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
        Friend WithEvents DataGridViewJournalItems As CtDataGridView
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
        Friend WithEvents cboAccountIdNo As CtCombobox
        Friend WithEvents floSalesDepositsFooter As CFlowLayout
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents btnHideJournalEntries As CButton
        Public WithEvents DataGridViewSalesDeposits As CtDataGridView
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