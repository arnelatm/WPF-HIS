Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ApJournalEntry
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
        Dim LocalizableContent1 As AATM.Libraries.LocalizationUtilities.LocalizableContent
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApJournalEntry))
            Me.floApJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CancelledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.JournalIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OriginalAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayeeTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvPaidAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvDiscountTaken = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OpenInvoiceIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvSpecialAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ItemVatAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.floApJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.lblTransactionType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboTransactionType = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblDueDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpDueDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.lblVatNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpSettlementDueDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPercent = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.chkApproved = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floFullEntryArea = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            LocalizableContent1 = New AATM.Libraries.LocalizationUtilities.LocalizableContent()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floApJournalItems.SuspendLayout()
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floApJournalHeader.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            Me.CFlowLayout2.SuspendLayout()
            Me.floFullEntryArea.SuspendLayout()
            Me.SuspendLayout()
            '
            'floApJournalItems
            '
            Me.floApJournalItems.BackColor = System.Drawing.Color.Transparent
            Me.floApJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floApJournalItems.Controls.Add(Me.DataGridViewJournalItems)
            Me.floFullEntryArea.SetFlowBreak(Me.floApJournalItems, True)
            Me.floApJournalItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.floApJournalItems.Location = New System.Drawing.Point(4, 278)
            Me.floApJournalItems.Margin = New System.Windows.Forms.Padding(4)
            Me.floApJournalItems.Name = "floApJournalItems"
            Me.floApJournalItems.Size = New System.Drawing.Size(1377, 368)
            Me.floApJournalItems.TabIndex = 1
            '
            'DataGridViewJournalItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewJournalItems.AutoGenerateColumns = False
            Me.DataGridViewJournalItems.BegFindValue = Nothing
            Me.DataGridViewJournalItems.Cached = False
            Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.dgvIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PayeeTypeDataGridViewTextBoxColumn, Me.dgvPaidAmount, Me.dgvDiscountTaken, Me.OpenInvoiceIdNo, Me.dgvSpecialAccount, Me.ItemVatAmount})
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
            Me.DataGridViewJournalItems.Dock = System.Windows.Forms.DockStyle.Left
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
            Me.DataGridViewJournalItems.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewJournalItems.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
            Me.DataGridViewJournalItems.OldCellValue = Nothing
            Me.DataGridViewJournalItems.ReadOnly = True
            Me.DataGridViewJournalItems.RowHeadersWidth = 51
            Me.DataGridViewJournalItems.Searchable = True
            Me.DataGridViewJournalItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewJournalItems.SecurityKey = ""
            Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
            Me.DataGridViewJournalItems.ShowFooter = False
            Me.DataGridViewJournalItems.Size = New System.Drawing.Size(1364, 351)
            Me.DataGridViewJournalItems.TabIndex = 12
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
            Me.dgvSequence.HeaderText = "Seq."
            Me.dgvSequence.IgnoreCase = False
            Me.dgvSequence.MinimumWidth = 50
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequence.Translatable = False
            Me.dgvSequence.Width = 50
            '
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.AutoComplete = False
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvAccountIdNo.EditingMode = False
            Me.dgvAccountIdNo.HeaderText = "Account Code-Name"
            Me.dgvAccountIdNo.MinimumWidth = 6
            Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
            Me.dgvAccountIdNo.ReadOnly = True
            Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAccountIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvAccountIdNo.SuggestCharCount = 0
            Me.dgvAccountIdNo.Translatable = False
            Me.dgvAccountIdNo.Width = 200
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
            Me.dgvDebit.EditingMode = False
            Me.dgvDebit.EndFindValue = Nothing
            Me.dgvDebit.FieldDescription = Nothing
            Me.dgvDebit.FieldName = Nothing
            Me.dgvDebit.FillWeight = 90.0!
            Me.dgvDebit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDebit.FindEnabled = False
            Me.dgvDebit.HeaderText = "Debit"
            Me.dgvDebit.MinimumWidth = 6
            Me.dgvDebit.Name = "dgvDebit"
            Me.dgvDebit.ReadOnly = True
            Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDebit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDebit.Translatable = False
            Me.dgvDebit.Width = 125
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
            Me.dgvCredit.EditingMode = False
            Me.dgvCredit.EndFindValue = Nothing
            Me.dgvCredit.FieldDescription = Nothing
            Me.dgvCredit.FieldName = Nothing
            Me.dgvCredit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvCredit.FindEnabled = False
            Me.dgvCredit.HeaderText = "Credit"
            Me.dgvCredit.MinimumWidth = 6
            Me.dgvCredit.Name = "dgvCredit"
            Me.dgvCredit.ReadOnly = True
            Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCredit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvCredit.Translatable = False
            Me.dgvCredit.Width = 90
            '
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.AutoComplete = False
            Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvRevCostCenterIdNo.EditingMode = False
            Me.dgvRevCostCenterIdNo.HeaderText = "Revenue/Cost Center Code-Name"
            Me.dgvRevCostCenterIdNo.MinimumWidth = 6
            Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.ReadOnly = True
            Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvRevCostCenterIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvRevCostCenterIdNo.SuggestCharCount = 0
            Me.dgvRevCostCenterIdNo.Translatable = False
            Me.dgvRevCostCenterIdNo.Width = 200
            '
            'dgvNotes
            '
            Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvNotes.BegFindValue = Nothing
            Me.dgvNotes.DataPropertyName = "Notes"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvNotes.EditingMode = False
            Me.dgvNotes.EndFindValue = Nothing
            Me.dgvNotes.FieldDescription = Nothing
            Me.dgvNotes.FieldName = Nothing
            Me.dgvNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvNotes.FindEnabled = False
            Me.dgvNotes.HeaderText = "Notes"
            Me.dgvNotes.IgnoreCase = False
            Me.dgvNotes.MinimumWidth = 6
            Me.dgvNotes.Name = "dgvNotes"
            Me.dgvNotes.ReadOnly = True
            Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvNotes.Translatable = False
            '
            'dgvIdNo
            '
            Me.dgvIdNo.DataPropertyName = "IdNo"
            Me.dgvIdNo.HeaderText = "IdNo"
            Me.dgvIdNo.MinimumWidth = 6
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Visible = False
            Me.dgvIdNo.Width = 125
            '
            'AccountNameDataGridViewTextBoxColumn
            '
            Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
            Me.AccountNameDataGridViewTextBoxColumn.HeaderText = "AccountName"
            Me.AccountNameDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
            Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = True
            Me.AccountNameDataGridViewTextBoxColumn.Visible = False
            Me.AccountNameDataGridViewTextBoxColumn.Width = 125
            '
            'CancelledDataGridViewCheckBoxColumn
            '
            Me.CancelledDataGridViewCheckBoxColumn.DataPropertyName = "Cancelled"
            Me.CancelledDataGridViewCheckBoxColumn.HeaderText = "Cancelled"
            Me.CancelledDataGridViewCheckBoxColumn.MinimumWidth = 6
            Me.CancelledDataGridViewCheckBoxColumn.Name = "CancelledDataGridViewCheckBoxColumn"
            Me.CancelledDataGridViewCheckBoxColumn.ReadOnly = True
            Me.CancelledDataGridViewCheckBoxColumn.Visible = False
            Me.CancelledDataGridViewCheckBoxColumn.Width = 125
            '
            'JournalIdNoDataGridViewTextBoxColumn
            '
            Me.JournalIdNoDataGridViewTextBoxColumn.DataPropertyName = "JournalIdNo"
            Me.JournalIdNoDataGridViewTextBoxColumn.HeaderText = "JournalIdNo"
            Me.JournalIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.JournalIdNoDataGridViewTextBoxColumn.Name = "JournalIdNoDataGridViewTextBoxColumn"
            Me.JournalIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.JournalIdNoDataGridViewTextBoxColumn.Visible = False
            Me.JournalIdNoDataGridViewTextBoxColumn.Width = 125
            '
            'OriginalAmountDataGridViewTextBoxColumn
            '
            Me.OriginalAmountDataGridViewTextBoxColumn.DataPropertyName = "OriginalAmount"
            Me.OriginalAmountDataGridViewTextBoxColumn.HeaderText = "OriginalAmount"
            Me.OriginalAmountDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.OriginalAmountDataGridViewTextBoxColumn.Name = "OriginalAmountDataGridViewTextBoxColumn"
            Me.OriginalAmountDataGridViewTextBoxColumn.ReadOnly = True
            Me.OriginalAmountDataGridViewTextBoxColumn.Visible = False
            Me.OriginalAmountDataGridViewTextBoxColumn.Width = 125
            '
            'PayeeTypeDataGridViewTextBoxColumn
            '
            Me.PayeeTypeDataGridViewTextBoxColumn.DataPropertyName = "PayeeType"
            Me.PayeeTypeDataGridViewTextBoxColumn.HeaderText = "PayeeType"
            Me.PayeeTypeDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.PayeeTypeDataGridViewTextBoxColumn.Name = "PayeeTypeDataGridViewTextBoxColumn"
            Me.PayeeTypeDataGridViewTextBoxColumn.ReadOnly = True
            Me.PayeeTypeDataGridViewTextBoxColumn.Visible = False
            Me.PayeeTypeDataGridViewTextBoxColumn.Width = 125
            '
            'dgvPaidAmount
            '
            Me.dgvPaidAmount.DataPropertyName = "PaidAmount"
            Me.dgvPaidAmount.HeaderText = "PaidAmount"
            Me.dgvPaidAmount.MinimumWidth = 6
            Me.dgvPaidAmount.Name = "dgvPaidAmount"
            Me.dgvPaidAmount.ReadOnly = True
            Me.dgvPaidAmount.Visible = False
            Me.dgvPaidAmount.Width = 125
            '
            'dgvDiscountTaken
            '
            Me.dgvDiscountTaken.DataPropertyName = "DiscountTaken"
            Me.dgvDiscountTaken.HeaderText = "DiscountTaken"
            Me.dgvDiscountTaken.MinimumWidth = 6
            Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
            Me.dgvDiscountTaken.ReadOnly = True
            Me.dgvDiscountTaken.Visible = False
            Me.dgvDiscountTaken.Width = 125
            '
            'OpenInvoiceIdNo
            '
            Me.OpenInvoiceIdNo.DataPropertyName = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNo.HeaderText = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNo.MinimumWidth = 6
            Me.OpenInvoiceIdNo.Name = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNo.ReadOnly = True
            Me.OpenInvoiceIdNo.Visible = False
            Me.OpenInvoiceIdNo.Width = 125
            '
            'dgvSpecialAccount
            '
            Me.dgvSpecialAccount.DataPropertyName = "SpecialAccount"
            Me.dgvSpecialAccount.HeaderText = "SpecialAccount"
            Me.dgvSpecialAccount.MinimumWidth = 6
            Me.dgvSpecialAccount.Name = "dgvSpecialAccount"
            Me.dgvSpecialAccount.ReadOnly = True
            Me.dgvSpecialAccount.Visible = False
            Me.dgvSpecialAccount.Width = 125
            '
            'ItemVatAmount
            '
            Me.ItemVatAmount.HeaderText = "ItemVatAmount"
            Me.ItemVatAmount.MinimumWidth = 6
            Me.ItemVatAmount.Name = "ItemVatAmount"
            Me.ItemVatAmount.ReadOnly = True
            Me.ItemVatAmount.Visible = False
            Me.ItemVatAmount.Width = 125
            '
            'bsJournalItems
            '
            Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
            '
            'floApJournalHeader
            '
            Me.floApJournalHeader.BackColor = System.Drawing.Color.Transparent
            Me.floApJournalHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floApJournalHeader.Controls.Add(Me.CFlowLayout3)
            Me.floApJournalHeader.Controls.Add(Me.CFlowLayout2)
            Me.floFullEntryArea.SetFlowBreak(Me.floApJournalHeader, True)
            Me.floApJournalHeader.Location = New System.Drawing.Point(4, 4)
            Me.floApJournalHeader.Margin = New System.Windows.Forms.Padding(4, 4, 0, 4)
            Me.floApJournalHeader.Name = "floApJournalHeader"
            Me.floApJournalHeader.Size = New System.Drawing.Size(1377, 266)
            Me.floApJournalHeader.TabIndex = 0
            '
            'CFlowLayout3
            '
            Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout3.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout3.Controls.Add(Me.txtJournalCode)
            Me.CFlowLayout3.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblReferenceNo)
            Me.CFlowLayout3.Controls.Add(Me.txtReferenceNo)
            Me.CFlowLayout3.Controls.Add(Me.lblTransactionDate)
            Me.CFlowLayout3.Controls.Add(Me.dtpTransactionDate)
            Me.CFlowLayout3.Controls.Add(Me.lblSupplierIdNo)
            Me.CFlowLayout3.Controls.Add(Me.cboSupplierIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblTransactionType)
            Me.CFlowLayout3.Controls.Add(Me.cboTransactionType)
            Me.CFlowLayout3.Controls.Add(Me.lblAmount)
            Me.CFlowLayout3.Controls.Add(Me.txtAmount)
            Me.CFlowLayout3.Controls.Add(Me.lblInvoiceDate)
            Me.CFlowLayout3.Controls.Add(Me.dtpInvoiceDate)
            Me.CFlowLayout3.Controls.Add(Me.lblDueDate)
            Me.CFlowLayout3.Controls.Add(Me.dtpDueDate)
            Me.CFlowLayout3.Controls.Add(Me.lblInvoiceNo)
            Me.CFlowLayout3.Controls.Add(Me.txtInvoiceNo)
            Me.CFlowLayout3.Controls.Add(Me.lblAccountIdNo)
            Me.CFlowLayout3.Controls.Add(Me.cboAccountIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblVatNumber)
            Me.CFlowLayout3.Controls.Add(Me.txtVatNumber)
            Me.CFlowLayout3.Controls.Add(Me.lblNotes)
            Me.CFlowLayout3.Controls.Add(Me.txtNotes)
            Me.CFlowLayout3.Location = New System.Drawing.Point(4, 4)
            Me.CFlowLayout3.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout3.Name = "CFlowLayout3"
            Me.CFlowLayout3.Padding = New System.Windows.Forms.Padding(20, 18, 20, 18)
            Me.CFlowLayout3.Size = New System.Drawing.Size(1011, 251)
            Me.CFlowLayout3.TabIndex = 0
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(21, 19)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(193, 28)
            Me.lblIdNo.TabIndex = 160
            Me.lblIdNo.Text = "Transaction No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.txtJournalCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
            Me.txtJournalCode.LinkedLabel = Nothing
            Me.txtJournalCode.Location = New System.Drawing.Point(216, 19)
            Me.txtJournalCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtJournalCode.MaximumValue = Nothing
            Me.txtJournalCode.MinimumValue = Nothing
            Me.txtJournalCode.Name = "txtJournalCode"
            Me.txtJournalCode.OldValue = Nothing
            Me.txtJournalCode.OverrideMaxLength = 0
            Me.txtJournalCode.ReadOnly = True
            Me.txtJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalCode.Size = New System.Drawing.Size(33, 26)
            Me.txtJournalCode.TabIndex = 163
            Me.txtJournalCode.TabStop = False
            Me.txtJournalCode.Text = "AP"
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
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(251, 19)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(83, 26)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblReferenceNo
            '
            Me.lblReferenceNo.BackColor = System.Drawing.Color.Transparent
            Me.lblReferenceNo.DisplayOnly = True
            Me.lblReferenceNo.EditingMode = False
            Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReferenceNo.Location = New System.Drawing.Point(336, 19)
            Me.lblReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReferenceNo.Name = "lblReferenceNo"
            Me.lblReferenceNo.Size = New System.Drawing.Size(171, 28)
            Me.lblReferenceNo.TabIndex = 158
            Me.lblReferenceNo.Text = "Reference No.:"
            Me.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
            Me.txtReferenceNo.Location = New System.Drawing.Point(509, 19)
            Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.OverrideMaxLength = 0
            Me.txtReferenceNo.ReadOnly = True
            Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReferenceNo.Size = New System.Drawing.Size(119, 26)
            Me.txtReferenceNo.TabIndex = 1
            Me.txtReferenceNo.Translatable = False
            Me.txtReferenceNo.ValueIsMandatory = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.BackColor = System.Drawing.Color.Transparent
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionDate.Location = New System.Drawing.Point(630, 19)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(173, 28)
            Me.lblTransactionDate.TabIndex = 5
            Me.lblTransactionDate.Text = "Transaction Date:"
            Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblTransactionDate.Translatable = True
            '
            'dtpTransactionDate
            '
            Me.dtpTransactionDate.AutoSize = True
            Me.dtpTransactionDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpTransactionDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpTransactionDate.DefaultValue = Nothing
            Me.dtpTransactionDate.DisplayOnly = False
            Me.dtpTransactionDate.DtpDefaultValue = Nothing
            Me.dtpTransactionDate.EditingMode = False
            Me.dtpTransactionDate.EditsAllowed = False
            Me.CFlowLayout3.SetFlowBreak(Me.dtpTransactionDate, True)
            Me.dtpTransactionDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Location = New System.Drawing.Point(804, 18)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(124, 27)
            Me.dtpTransactionDate.TabIndex = 2
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'lblSupplierIdNo
            '
            Me.lblSupplierIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierIdNo.DisplayOnly = True
            Me.lblSupplierIdNo.EditingMode = False
            Me.lblSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSupplierIdNo.Location = New System.Drawing.Point(21, 49)
            Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            Me.lblSupplierIdNo.Size = New System.Drawing.Size(193, 28)
            Me.lblSupplierIdNo.TabIndex = 254
            Me.lblSupplierIdNo.Text = "Supplier Code/Name"
            Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierIdNo.Translatable = True
            '
            'cboSupplierIdNo
            '
            Me.cboSupplierIdNo.BackColor = System.Drawing.Color.White
            Me.cboSupplierIdNo.BegFindValue = Nothing
            Me.cboSupplierIdNo.ChangingSearchValueOnly = False
            Me.cboSupplierIdNo.CurrentSearchTerm = ""
            Me.cboSupplierIdNo.DataValue = Nothing
            Me.cboSupplierIdNo.DefaultValue = Nothing
            Me.cboSupplierIdNo.DisplayMember = "Name"
            Me.cboSupplierIdNo.Editable = True
            Me.cboSupplierIdNo.EditingMode = True
            Me.cboSupplierIdNo.EndFindValue = Nothing
            Me.cboSupplierIdNo.FieldDescription = Nothing
            Me.cboSupplierIdNo.FieldName = Nothing
            Me.cboSupplierIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSupplierIdNo.FindEnabled = False
            Me.cboSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboSupplierIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSupplierIdNo.FormattingEnabled = True
            Me.cboSupplierIdNo.HideWhenNotEditingOrAdding = False
            Me.cboSupplierIdNo.IgnoreCase = False
            Me.cboSupplierIdNo.IntegralHeight = False
            Me.cboSupplierIdNo.LimitToList = False
            Me.cboSupplierIdNo.LinkedLabel = Me.lblSupplierIdNo
            Me.cboSupplierIdNo.Location = New System.Drawing.Point(216, 49)
            Me.cboSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboSupplierIdNo.Name = "cboSupplierIdNo"
            Me.cboSupplierIdNo.OldValue = 0
            Me.cboSupplierIdNo.OriginalDataSource = Nothing
            Me.cboSupplierIdNo.OriginalList = Nothing
            Me.cboSupplierIdNo.OverrideDropDownStyleList = False
            Me.cboSupplierIdNo.PreviousSearchTerm = Nothing
            Me.cboSupplierIdNo.Size = New System.Drawing.Size(765, 28)
            Me.cboSupplierIdNo.SuggestBoxHeight = 200
            Me.cboSupplierIdNo.SuggestCharCount = 0
            Me.cboSupplierIdNo.TabIndex = 3
            Me.cboSupplierIdNo.TextToSearch = Nothing
            Me.cboSupplierIdNo.Translatable = False
            Me.cboSupplierIdNo.ValueIsMandatory = False
            Me.cboSupplierIdNo.ValueIsNullable = False
            Me.cboSupplierIdNo.ValueIsNumeric = False
            Me.cboSupplierIdNo.ValueMember = "IdNo"
            '
            'lblTransactionType
            '
            Me.lblTransactionType.BackColor = System.Drawing.Color.Transparent
            Me.lblTransactionType.DisplayOnly = True
            Me.lblTransactionType.EditingMode = False
            Me.lblTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionType.Location = New System.Drawing.Point(21, 79)
            Me.lblTransactionType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionType.Name = "lblTransactionType"
            Me.lblTransactionType.Size = New System.Drawing.Size(193, 28)
            Me.lblTransactionType.TabIndex = 267
            Me.lblTransactionType.Text = "Transaction Type:"
            Me.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblTransactionType.Translatable = True
            '
            'cboTransactionType
            '
            Me.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboTransactionType.BackColor = System.Drawing.Color.White
            Me.cboTransactionType.BegFindValue = Nothing
            Me.cboTransactionType.ChangingSearchValueOnly = False
            Me.cboTransactionType.CurrentSearchTerm = ""
            Me.cboTransactionType.DataValue = Nothing
            Me.cboTransactionType.DefaultValue = "0"
            Me.cboTransactionType.DisplayMember = "Name"
            Me.cboTransactionType.DropDownHeight = 24
            Me.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboTransactionType.Editable = True
            Me.cboTransactionType.EditingMode = False
            Me.cboTransactionType.EndFindValue = Nothing
            Me.cboTransactionType.FieldDescription = Nothing
            Me.cboTransactionType.FieldName = Nothing
            Me.cboTransactionType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboTransactionType.FindEnabled = False
            Me.cboTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboTransactionType.ForeColor = System.Drawing.Color.Black
            Me.cboTransactionType.HideWhenNotEditingOrAdding = False
            Me.cboTransactionType.IgnoreCase = False
            Me.cboTransactionType.IntegralHeight = False
            Me.cboTransactionType.LimitToList = False
            Me.cboTransactionType.LinkedLabel = Nothing
            Me.cboTransactionType.Location = New System.Drawing.Point(216, 79)
            Me.cboTransactionType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboTransactionType.MaxDropDownItems = 1
            Me.cboTransactionType.Name = "cboTransactionType"
            Me.cboTransactionType.OldValue = 0
            Me.cboTransactionType.OriginalDataSource = Nothing
            Me.cboTransactionType.OriginalList = Nothing
            Me.cboTransactionType.OverrideDropDownStyleList = False
            Me.cboTransactionType.PreviousSearchTerm = Nothing
            Me.cboTransactionType.Size = New System.Drawing.Size(161, 29)
            Me.cboTransactionType.SuggestBoxHeight = 200
            Me.cboTransactionType.SuggestCharCount = 0
            Me.cboTransactionType.TabIndex = 4
            Me.cboTransactionType.TextToSearch = Nothing
            Me.cboTransactionType.Translatable = False
            Me.cboTransactionType.ValueIsMandatory = False
            Me.cboTransactionType.ValueIsNullable = False
            Me.cboTransactionType.ValueIsNumeric = False
            Me.cboTransactionType.ValueMember = "Code"
            '
            'lblAmount
            '
            Me.lblAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(379, 79)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(128, 28)
            Me.lblAmount.TabIndex = 264
            Me.lblAmount.Text = "Amount:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAmount.Translatable = True
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BegFindValue = Nothing
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = Nothing
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = False
            Me.txtAmount.EndFindValue = Nothing
            Me.txtAmount.FieldDescription = Nothing
            Me.txtAmount.FieldName = Nothing
            Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAmount.FindEnabled = True
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.Location = New System.Drawing.Point(509, 79)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.OverrideMaxLength = 0
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Size = New System.Drawing.Size(119, 26)
            Me.txtAmount.TabIndex = 5
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.Translatable = False
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblInvoiceDate
            '
            Me.lblInvoiceDate.BackColor = System.Drawing.Color.Transparent
            Me.lblInvoiceDate.DisplayOnly = True
            Me.lblInvoiceDate.EditingMode = False
            Me.lblInvoiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceDate.Location = New System.Drawing.Point(630, 79)
            Me.lblInvoiceDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceDate.Name = "lblInvoiceDate"
            Me.lblInvoiceDate.Size = New System.Drawing.Size(173, 28)
            Me.lblInvoiceDate.TabIndex = 257
            Me.lblInvoiceDate.Text = "Supplier Doc. Date:"
            Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblInvoiceDate.Translatable = True
            '
            'dtpInvoiceDate
            '
            Me.dtpInvoiceDate.AutoSize = True
            Me.dtpInvoiceDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpInvoiceDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpInvoiceDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpInvoiceDate.DefaultValue = Nothing
            Me.dtpInvoiceDate.DisplayOnly = False
            Me.dtpInvoiceDate.DtpDefaultValue = Nothing
            Me.dtpInvoiceDate.EditingMode = False
            Me.dtpInvoiceDate.EditsAllowed = False
            Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.dtpInvoiceDate.LinkedLabel = Nothing
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(804, 78)
            Me.dtpInvoiceDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
            Me.dtpInvoiceDate.ReadOnlyDp = False
            Me.dtpInvoiceDate.SecurityKey = Nothing
            Me.dtpInvoiceDate.ShowLongDate = False
            Me.dtpInvoiceDate.ShowTime = False
            Me.dtpInvoiceDate.Size = New System.Drawing.Size(124, 27)
            Me.dtpInvoiceDate.TabIndex = 6
            Me.dtpInvoiceDate.TargetCalendar = CType(resources.GetObject("dtpInvoiceDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpInvoiceDate.Translatable = False
            Me.dtpInvoiceDate.Value = Nothing
            Me.dtpInvoiceDate.ValueIsMandatory = False
            Me.dtpInvoiceDate.ValueIsNullable = False
            '
            'lblDueDate
            '
            Me.lblDueDate.BackColor = System.Drawing.Color.Transparent
            Me.lblDueDate.DisplayOnly = True
            Me.lblDueDate.EditingMode = False
            Me.lblDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDueDate.Location = New System.Drawing.Point(21, 110)
            Me.lblDueDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(193, 28)
            Me.lblDueDate.TabIndex = 259
            Me.lblDueDate.Text = "Due Date:"
            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDueDate.Translatable = True
            '
            'dtpDueDate
            '
            Me.dtpDueDate.AutoSize = True
            Me.dtpDueDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpDueDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpDueDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpDueDate.DefaultValue = Nothing
            Me.dtpDueDate.DisplayOnly = False
            Me.dtpDueDate.DtpDefaultValue = Nothing
            Me.dtpDueDate.EditingMode = False
            Me.dtpDueDate.EditsAllowed = False
            Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpDueDate.ForeColor = System.Drawing.Color.Black
            Me.dtpDueDate.LinkedLabel = Nothing
            Me.dtpDueDate.Location = New System.Drawing.Point(215, 109)
            Me.dtpDueDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.ReadOnlyDp = False
            Me.dtpDueDate.SecurityKey = Nothing
            Me.dtpDueDate.ShowLongDate = False
            Me.dtpDueDate.ShowTime = False
            Me.dtpDueDate.Size = New System.Drawing.Size(124, 27)
            Me.dtpDueDate.TabIndex = 7
            Me.dtpDueDate.TargetCalendar = CType(resources.GetObject("dtpDueDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpDueDate.Translatable = False
            Me.dtpDueDate.Value = Nothing
            Me.dtpDueDate.ValueIsMandatory = False
            Me.dtpDueDate.ValueIsNullable = False
            '
            'lblInvoiceNo
            '
            Me.lblInvoiceNo.BackColor = System.Drawing.Color.Transparent
            Me.lblInvoiceNo.DisplayOnly = True
            Me.lblInvoiceNo.EditingMode = False
            Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceNo.Location = New System.Drawing.Point(340, 110)
            Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            Me.lblInvoiceNo.Size = New System.Drawing.Size(433, 28)
            Me.lblInvoiceNo.TabIndex = 254
            Me.lblInvoiceNo.Text = "Supplier Invoice/Reference No.:"
            Me.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblInvoiceNo.Translatable = True
            '
            'txtInvoiceNo
            '
            Me.txtInvoiceNo.BackColor = System.Drawing.Color.White
            Me.txtInvoiceNo.BegFindValue = Nothing
            Me.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInvoiceNo.ComputedValue = False
            Me.txtInvoiceNo.CustomFormat = Nothing
            Me.txtInvoiceNo.DataBoundControl = True
            Me.txtInvoiceNo.EditingMode = False
            Me.txtInvoiceNo.EndFindValue = Nothing
            Me.txtInvoiceNo.FieldDescription = Nothing
            Me.txtInvoiceNo.FieldName = Nothing
            Me.txtInvoiceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtInvoiceNo.FindEnabled = True
            Me.CFlowLayout3.SetFlowBreak(Me.txtInvoiceNo, True)
            Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtInvoiceNo.ForeColor = System.Drawing.Color.Black
            Me.txtInvoiceNo.LinkedLabel = Me.lblInvoiceNo
            Me.txtInvoiceNo.Location = New System.Drawing.Point(775, 110)
            Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtInvoiceNo.MaximumValue = Nothing
            Me.txtInvoiceNo.MinimumValue = Nothing
            Me.txtInvoiceNo.Name = "txtInvoiceNo"
            Me.txtInvoiceNo.OldValue = Nothing
            Me.txtInvoiceNo.OverrideMaxLength = 0
            Me.txtInvoiceNo.ReadOnly = True
            Me.txtInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtInvoiceNo.Size = New System.Drawing.Size(162, 26)
            Me.txtInvoiceNo.TabIndex = 8
            Me.txtInvoiceNo.Translatable = False
            Me.txtInvoiceNo.ValueIsMandatory = True
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAccountIdNo.Location = New System.Drawing.Point(21, 140)
            Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Size = New System.Drawing.Size(193, 30)
            Me.lblAccountIdNo.TabIndex = 266
            Me.lblAccountIdNo.Text = "Acct. to Credit:"
            Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAccountIdNo.Translatable = True
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.BegFindValue = Nothing
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DataValue = Nothing
            Me.cboAccountIdNo.DefaultValue = ""
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.DropDownHeight = 24
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboAccountIdNo.Editable = True
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.EndFindValue = Nothing
            Me.cboAccountIdNo.FieldDescription = Nothing
            Me.cboAccountIdNo.FieldName = Nothing
            Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAccountIdNo.FindEnabled = False
            Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IgnoreCase = False
            Me.cboAccountIdNo.IntegralHeight = False
            Me.cboAccountIdNo.LimitToList = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
            Me.cboAccountIdNo.Location = New System.Drawing.Point(216, 140)
            Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboAccountIdNo.MaxDropDownItems = 1
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.Size = New System.Drawing.Size(472, 29)
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestCharCount = 0
            Me.cboAccountIdNo.TabIndex = 9
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.Translatable = False
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'lblVatNumber
            '
            Me.lblVatNumber.BackColor = System.Drawing.Color.Transparent
            Me.lblVatNumber.DisplayOnly = True
            Me.lblVatNumber.EditingMode = False
            Me.lblVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatNumber.Location = New System.Drawing.Point(690, 140)
            Me.lblVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatNumber.Name = "lblVatNumber"
            Me.lblVatNumber.Size = New System.Drawing.Size(129, 28)
            Me.lblVatNumber.TabIndex = 0
            Me.lblVatNumber.Text = "Vat Number:"
            Me.lblVatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblVatNumber.Translatable = True
            '
            'txtVatNumber
            '
            Me.txtVatNumber.BackColor = System.Drawing.Color.White
            Me.txtVatNumber.BegFindValue = Nothing
            Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVatNumber.ComputedValue = False
            Me.txtVatNumber.CustomFormat = Nothing
            Me.txtVatNumber.DataBoundControl = True
            Me.txtVatNumber.EditingMode = False
            Me.txtVatNumber.EndFindValue = Nothing
            Me.txtVatNumber.FieldDescription = Nothing
            Me.txtVatNumber.FieldName = Nothing
            Me.txtVatNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVatNumber.FindEnabled = True
            Me.txtVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
            Me.txtVatNumber.LinkedLabel = Me.lblVatNumber
            Me.txtVatNumber.Location = New System.Drawing.Point(821, 140)
            Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MaxLength = 15
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.OverrideMaxLength = 0
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatNumber.Size = New System.Drawing.Size(162, 26)
            Me.txtVatNumber.TabIndex = 10
            Me.txtVatNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtVatNumber.Translatable = False
            Me.txtVatNumber.ValueIsMandatory = True
            Me.txtVatNumber.ValueIsNumeric = True
            '
            'lblNotes
            '
            Me.lblNotes.BackColor = System.Drawing.Color.Transparent
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(21, 172)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(193, 28)
            Me.lblNotes.TabIndex = 161
            Me.lblNotes.Text = "Description/Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(216, 172)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(771, 56)
            Me.txtNotes.TabIndex = 11
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.lblVatAmount)
            Me.CFlowLayout2.Controls.Add(Me.txtVatAmount)
            Me.CFlowLayout2.Controls.Add(Me.CLabel2)
            Me.CFlowLayout2.Controls.Add(Me.dtpSettlementDueDate)
            Me.CFlowLayout2.Controls.Add(Me.CLabel5)
            Me.CFlowLayout2.Controls.Add(Me.txtSettlementDiscount)
            Me.CFlowLayout2.Controls.Add(Me.lblPercent)
            Me.CFlowLayout2.Controls.Add(Me.chkCancelled)
            Me.CFlowLayout2.Controls.Add(Me.chkApproved)
            Me.CFlowLayout2.Controls.Add(Me.chkPosted)
            Me.CFlowLayout2.Controls.Add(Me.lblDateAdded)
            Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
            Me.CFlowLayout2.Location = New System.Drawing.Point(1023, 4)
            Me.CFlowLayout2.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Padding = New System.Windows.Forms.Padding(20, 18, 20, 18)
            Me.CFlowLayout2.Size = New System.Drawing.Size(345, 251)
            Me.CFlowLayout2.TabIndex = 1
            '
            'lblVatAmount
            '
            Me.lblVatAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblVatAmount.DisplayOnly = True
            Me.lblVatAmount.EditingMode = False
            Me.lblVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatAmount.Location = New System.Drawing.Point(21, 19)
            Me.lblVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatAmount.Name = "lblVatAmount"
            Me.lblVatAmount.Size = New System.Drawing.Size(129, 28)
            Me.lblVatAmount.TabIndex = 2
            Me.lblVatAmount.Text = "Vat Amount"
            Me.lblVatAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblVatAmount.Translatable = True
            '
            'txtVatAmount
            '
            Me.txtVatAmount.BackColor = System.Drawing.Color.White
            Me.txtVatAmount.BegFindValue = Nothing
            Me.txtVatAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVatAmount.ComputedValue = False
            Me.txtVatAmount.CustomFormat = Nothing
            Me.txtVatAmount.DataBoundControl = True
            Me.txtVatAmount.EditingMode = False
            Me.txtVatAmount.EndFindValue = Nothing
            Me.txtVatAmount.FieldDescription = Nothing
            Me.txtVatAmount.FieldName = Nothing
            Me.txtVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVatAmount.FindEnabled = True
            Me.CFlowLayout2.SetFlowBreak(Me.txtVatAmount, True)
            Me.txtVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
            Me.txtVatAmount.LinkedLabel = Me.lblAmount
            Me.txtVatAmount.Location = New System.Drawing.Point(152, 19)
            Me.txtVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatAmount.MaximumValue = Nothing
            Me.txtVatAmount.MinimumValue = Nothing
            Me.txtVatAmount.Name = "txtVatAmount"
            Me.txtVatAmount.OldValue = Nothing
            Me.txtVatAmount.OverrideMaxLength = 0
            Me.txtVatAmount.ReadOnly = True
            Me.txtVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatAmount.Size = New System.Drawing.Size(162, 26)
            Me.txtVatAmount.TabIndex = 2
            Me.txtVatAmount.TabStop = False
            Me.txtVatAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtVatAmount.Translatable = False
            Me.txtVatAmount.ValueIsMandatory = True
            Me.txtVatAmount.ValueIsNumeric = True
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CFlowLayout2.SetFlowBreak(Me.CLabel2, True)
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel2.Location = New System.Drawing.Point(21, 49)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(276, 28)
            Me.CLabel2.TabIndex = 279
            Me.CLabel2.Text = "Early Settlement Date/Rate:"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
            '
            'dtpSettlementDueDate
            '
            Me.dtpSettlementDueDate.AutoSize = True
            Me.dtpSettlementDueDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpSettlementDueDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpSettlementDueDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpSettlementDueDate.DefaultValue = Nothing
            Me.dtpSettlementDueDate.DisplayOnly = False
            Me.dtpSettlementDueDate.DtpDefaultValue = Nothing
            Me.dtpSettlementDueDate.EditingMode = False
            Me.dtpSettlementDueDate.EditsAllowed = False
            Me.dtpSettlementDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpSettlementDueDate.ForeColor = System.Drawing.Color.Black
            Me.dtpSettlementDueDate.LinkedLabel = Nothing
            Me.dtpSettlementDueDate.Location = New System.Drawing.Point(20, 78)
            Me.dtpSettlementDueDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpSettlementDueDate.Name = "dtpSettlementDueDate"
            Me.dtpSettlementDueDate.ReadOnlyDp = False
            Me.dtpSettlementDueDate.SecurityKey = Nothing
            Me.dtpSettlementDueDate.ShowLongDate = False
            Me.dtpSettlementDueDate.ShowTime = False
            Me.dtpSettlementDueDate.Size = New System.Drawing.Size(124, 27)
            Me.dtpSettlementDueDate.TabIndex = 3
            Me.dtpSettlementDueDate.TabStop = False
            Me.dtpSettlementDueDate.TargetCalendar = CType(resources.GetObject("dtpSettlementDueDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpSettlementDueDate.Translatable = False
            Me.dtpSettlementDueDate.Value = Nothing
            Me.dtpSettlementDueDate.ValueIsMandatory = False
            Me.dtpSettlementDueDate.ValueIsNullable = False
            '
            'CLabel5
            '
            Me.CLabel5.BackColor = System.Drawing.Color.Transparent
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel5.Location = New System.Drawing.Point(144, 78)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(0)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(31, 28)
            Me.CLabel5.TabIndex = 277
            Me.CLabel5.Text = " - "
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel5.Translatable = True
            '
            'txtSettlementDiscount
            '
            Me.txtSettlementDiscount.BackColor = System.Drawing.Color.White
            Me.txtSettlementDiscount.BegFindValue = Nothing
            Me.txtSettlementDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSettlementDiscount.ComputedValue = False
            Me.txtSettlementDiscount.CustomFormat = Nothing
            Me.txtSettlementDiscount.DataBoundControl = True
            Me.txtSettlementDiscount.EditingMode = False
            Me.txtSettlementDiscount.EndFindValue = Nothing
            Me.txtSettlementDiscount.FieldDescription = Nothing
            Me.txtSettlementDiscount.FieldName = Nothing
            Me.txtSettlementDiscount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSettlementDiscount.FindEnabled = True
            Me.txtSettlementDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSettlementDiscount.ForeColor = System.Drawing.Color.Black
            Me.txtSettlementDiscount.LinkedLabel = Nothing
            Me.txtSettlementDiscount.Location = New System.Drawing.Point(176, 79)
            Me.txtSettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSettlementDiscount.MaximumValue = Nothing
            Me.txtSettlementDiscount.MinimumValue = Nothing
            Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
            Me.txtSettlementDiscount.OldValue = Nothing
            Me.txtSettlementDiscount.OverrideMaxLength = 0
            Me.txtSettlementDiscount.ReadOnly = True
            Me.txtSettlementDiscount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSettlementDiscount.Size = New System.Drawing.Size(58, 26)
            Me.txtSettlementDiscount.TabIndex = 4
            Me.txtSettlementDiscount.TabStop = False
            Me.txtSettlementDiscount.Translatable = False
            Me.txtSettlementDiscount.ValueIsMandatory = True
            '
            'lblPercent
            '
            Me.lblPercent.BackColor = System.Drawing.Color.Transparent
            Me.lblPercent.DisplayOnly = True
            Me.lblPercent.EditingMode = False
            Me.CFlowLayout2.SetFlowBreak(Me.lblPercent, True)
            Me.lblPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPercent.Location = New System.Drawing.Point(235, 78)
            Me.lblPercent.Margin = New System.Windows.Forms.Padding(0)
            Me.lblPercent.Name = "lblPercent"
            Me.lblPercent.Size = New System.Drawing.Size(21, 28)
            Me.lblPercent.TabIndex = 269
            Me.lblPercent.Text = "%"
            Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblPercent.Translatable = True
            '
            'chkCancelled
            '
            Me.chkCancelled.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
            Me.CFlowLayout2.SetFlowBreak(Me.chkCancelled, True)
            Me.chkCancelled.IgnoreCase = False
            Me.chkCancelled.LinkedLabel = Nothing
            Me.chkCancelled.Location = New System.Drawing.Point(25, 111)
            Me.chkCancelled.Margin = New System.Windows.Forms.Padding(5)
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkCancelled.Size = New System.Drawing.Size(148, 28)
            Me.chkCancelled.TabIndex = 294
            Me.chkCancelled.Text = "Cancelled?"
            Me.chkCancelled.Translatable = True
            '
            'chkApproved
            '
            Me.chkApproved.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.chkApproved.BackColor = System.Drawing.Color.Transparent
            Me.chkApproved.BegFindValue = Nothing
            Me.chkApproved.Checked = False
            Me.chkApproved.EditingMode = False
            Me.chkApproved.EndFindValue = Nothing
            Me.chkApproved.FieldDescription = Nothing
            Me.chkApproved.FieldName = Nothing
            Me.chkApproved.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkApproved.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.chkApproved, True)
            Me.chkApproved.IgnoreCase = False
            Me.chkApproved.LinkedLabel = Nothing
            Me.chkApproved.Location = New System.Drawing.Point(25, 149)
            Me.chkApproved.Margin = New System.Windows.Forms.Padding(5)
            Me.chkApproved.Name = "chkApproved"
            Me.chkApproved.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkApproved.Size = New System.Drawing.Size(148, 26)
            Me.chkApproved.TabIndex = 293
            Me.chkApproved.Text = "Approved?"
            Me.chkApproved.Translatable = True
            '
            'chkPosted
            '
            Me.chkPosted.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
            Me.CFlowLayout2.SetFlowBreak(Me.chkPosted, True)
            Me.chkPosted.IgnoreCase = False
            Me.chkPosted.LinkedLabel = Nothing
            Me.chkPosted.Location = New System.Drawing.Point(25, 185)
            Me.chkPosted.Margin = New System.Windows.Forms.Padding(5)
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkPosted.Size = New System.Drawing.Size(148, 26)
            Me.chkPosted.TabIndex = 295
            Me.chkPosted.Text = "Posted?"
            Me.chkPosted.Translatable = True
            '
            'lblDateAdded
            '
            Me.lblDateAdded.BackColor = System.Drawing.Color.Transparent
            Me.lblDateAdded.DisplayOnly = True
            Me.lblDateAdded.EditingMode = False
            Me.lblDateAdded.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateAdded.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateAdded.Location = New System.Drawing.Point(20, 216)
            Me.lblDateAdded.Margin = New System.Windows.Forms.Padding(0)
            Me.lblDateAdded.Name = "lblDateAdded"
            Me.lblDateAdded.Size = New System.Drawing.Size(116, 32)
            Me.lblDateAdded.TabIndex = 8
            Me.lblDateAdded.Text = "Date Added:"
            Me.lblDateAdded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDateAdded.Translatable = True
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BegFindValue = Nothing
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDateCreated.ComputedValue = False
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.EditingMode = True
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = False
            Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Nothing
            Me.txtDateCreated.Location = New System.Drawing.Point(137, 217)
            Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.OverrideMaxLength = 0
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Size = New System.Drawing.Size(178, 26)
            Me.txtDateCreated.TabIndex = 288
            Me.txtDateCreated.TabStop = False
            Me.txtDateCreated.Translatable = False
            '
            'floFullEntryArea
            '
            Me.floFullEntryArea.BackColor = System.Drawing.Color.Transparent
            Me.floFullEntryArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floFullEntryArea.Controls.Add(Me.floApJournalHeader)
            Me.floFullEntryArea.Controls.Add(Me.floApJournalItems)
            Me.floFullEntryArea.Dock = System.Windows.Forms.DockStyle.Top
            Me.floFullEntryArea.Location = New System.Drawing.Point(0, 55)
            Me.floFullEntryArea.Margin = New System.Windows.Forms.Padding(4)
            Me.floFullEntryArea.MinimumSize = New System.Drawing.Size(1389, 629)
            Me.floFullEntryArea.Name = "floFullEntryArea"
            Me.floFullEntryArea.Size = New System.Drawing.Size(1392, 645)
            Me.floFullEntryArea.TabIndex = 0
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
            Me.txtTotalCredits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTotalCredits.ForeColor = System.Drawing.Color.Black
            Me.txtTotalCredits.LinkedLabel = Nothing
            Me.txtTotalCredits.Location = New System.Drawing.Point(163, 708)
            Me.txtTotalCredits.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTotalCredits.MaximumValue = Nothing
            Me.txtTotalCredits.MinimumValue = Nothing
            Me.txtTotalCredits.Name = "txtTotalCredits"
            Me.txtTotalCredits.OldValue = Nothing
            Me.txtTotalCredits.OverrideMaxLength = 0
            Me.txtTotalCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalCredits.Size = New System.Drawing.Size(133, 26)
            Me.txtTotalCredits.TabIndex = 250
            Me.txtTotalCredits.Translatable = False
            Me.txtTotalCredits.Visible = False
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
            Me.txtTotalDebits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTotalDebits.ForeColor = System.Drawing.Color.Black
            Me.txtTotalDebits.LinkedLabel = Nothing
            Me.txtTotalDebits.Location = New System.Drawing.Point(5, 705)
            Me.txtTotalDebits.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTotalDebits.MaximumValue = Nothing
            Me.txtTotalDebits.MinimumValue = Nothing
            Me.txtTotalDebits.Name = "txtTotalDebits"
            Me.txtTotalDebits.OldValue = Nothing
            Me.txtTotalDebits.OverrideMaxLength = 0
            Me.txtTotalDebits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalDebits.Size = New System.Drawing.Size(133, 26)
            Me.txtTotalDebits.TabIndex = 249
            Me.txtTotalDebits.Translatable = False
            Me.txtTotalDebits.Visible = False
            '
            'ApJournalEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.ClientSize = New System.Drawing.Size(1392, 737)
            Me.Controls.Add(Me.txtTotalCredits)
            Me.Controls.Add(Me.txtTotalDebits)
            Me.Controls.Add(Me.floFullEntryArea)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.MinimumSize = New System.Drawing.Size(1406, 703)
            Me.Name = "ApJournalEntry"
            Me.Text = "Accounts Payable Journal Entry"
            Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
            Me.Controls.SetChildIndex(Me.txtTotalDebits, 0)
            Me.Controls.SetChildIndex(Me.txtTotalCredits, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floApJournalItems.ResumeLayout(False)
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floApJournalHeader.ResumeLayout(False)
            Me.CFlowLayout3.ResumeLayout(False)
            Me.CFlowLayout3.PerformLayout()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.floFullEntryArea.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents floApJournalItems As CFlowLayout
        Friend WithEvents DataGridViewJournalItems As CtDataGridView
        Friend WithEvents floApJournalHeader As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents txtJournalCode As CTextBox
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents floFullEntryArea As CFlowLayout
        Friend WithEvents lblInvoiceNo As CLabel
        Friend WithEvents txtInvoiceNo As CTextBox
        Friend WithEvents dtpSettlementDueDate As CCustomDateTimePicker
        Friend WithEvents lblInvoiceDate As CLabel
        Friend WithEvents dtpInvoiceDate As CCustomDateTimePicker
        Friend WithEvents txtSettlementDiscount As CTextBox
        Friend WithEvents lblDueDate As CLabel
        Friend WithEvents dtpDueDate As CCustomDateTimePicker
        Friend WithEvents lblSupplierIdNo As CLabel
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents lblDateAdded As CLabel
        Friend WithEvents lblPercent As CLabel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents lblVatNumber As CLabel
        Friend WithEvents txtVatNumber As CTextBox
        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblVatAmount As CLabel
        Friend WithEvents cboAccountIdNo As CdtComboBox
        Friend WithEvents lblTransactionType As CLabel
        Friend WithEvents cboTransactionType As CdtComboBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents BalanceDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents cboSupplierIdNo As CdtComboBox
        Friend WithEvents txtDateCreated As CTextBox
        Friend WithEvents chkApproved As UcCheckBox
        Friend WithEvents chkCancelled As UcCheckBox
        Friend WithEvents chkPosted As UcCheckBox
        Friend WithEvents txtTotalCredits As CTextBox
        Friend WithEvents txtTotalDebits As CTextBox
        Friend WithEvents txtVatAmount As CTextBox
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvAccountIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvMoneyColumn
        Friend WithEvents dgvCredit As CdgvMoneyColumn
        Friend WithEvents dgvRevCostCenterIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvNotes As CDgvTextColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents JournalIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OriginalAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayeeTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvPaidAmount As DataGridViewTextBoxColumn
        Friend WithEvents dgvDiscountTaken As DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvSpecialAccount As DataGridViewTextBoxColumn
        Friend WithEvents ItemVatAmount As DataGridViewTextBoxColumn
    End Class
End NameSpace