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
        Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
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
        Me.cboSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblTransactionType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboTransactionType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblDueDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDueDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floApJournalItems.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floApJournalHeader.SuspendLayout
        Me.CFlowLayout3.SuspendLayout
        Me.CFlowLayout2.SuspendLayout
        Me.floFullEntryArea.SuspendLayout
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
        'floApJournalItems
        '
        Me.floApJournalItems.BackColor = System.Drawing.Color.Transparent
        Me.floApJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floApJournalItems.Controls.Add(Me.DataGridViewJournalItems)
        Me.floFullEntryArea.SetFlowBreak(Me.floApJournalItems, true)
        Me.floApJournalItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.floApJournalItems.Location = New System.Drawing.Point(3, 226)
        Me.floApJournalItems.Name = "floApJournalItems"
        Me.floApJournalItems.Size = New System.Drawing.Size(1034, 284)
        Me.floApJournalItems.TabIndex = 1
        '
        'DataGridViewJournalItems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewJournalItems.AutoGenerateColumns = false
        Me.DataGridViewJournalItems.BegFindValue = Nothing
        Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.dgvIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PayeeTypeDataGridViewTextBoxColumn, Me.dgvPaidAmount, Me.dgvDiscountTaken, Me.OpenInvoiceIdNo, Me.dgvSpecialAccount, Me.ItemVatAmount})
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
        Me.DataGridViewJournalItems.Dock = System.Windows.Forms.DockStyle.Left
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
        Me.DataGridViewJournalItems.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
        Me.DataGridViewJournalItems.ReadOnly = true
        Me.DataGridViewJournalItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewJournalItems.SecurityKey = ""
        Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
        Me.DataGridViewJournalItems.ShowFooter = false
        Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = true
        Me.DataGridViewJournalItems.Size = New System.Drawing.Size(1023, 275)
        Me.DataGridViewJournalItems.TabIndex = 12
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
        Me.dgvSequence.HeaderText = "Seq."
        Me.dgvSequence.IgnoreCase = false
        Me.dgvSequence.MinimumWidth = 50
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSequence.Translatable = false
        Me.dgvSequence.Width = 50
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAccountIdNo.EditingMode = false
        Me.dgvAccountIdNo.HeaderText = "Account Code-Name"
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.ReadOnly = true
        Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvAccountIdNo.Translatable = false
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
        Me.dgvDebit.EditingMode = false
        Me.dgvDebit.EndFindValue = Nothing
        Me.dgvDebit.FieldDescription = Nothing
        Me.dgvDebit.FieldName = Nothing
        Me.dgvDebit.FillWeight = 90!
        Me.dgvDebit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDebit.FindEnabled = false
        Me.dgvDebit.HeaderText = "Debit"
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
        Me.dgvCredit.HeaderText = "Credit"
        Me.dgvCredit.Name = "dgvCredit"
        Me.dgvCredit.ReadOnly = true
        Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCredit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvCredit.Translatable = false
        Me.dgvCredit.Width = 90
        '
        'dgvRevCostCenterIdNo
        '
        Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRevCostCenterIdNo.EditingMode = false
        Me.dgvRevCostCenterIdNo.HeaderText = "Revenue/Cost Center Code-Name"
        Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
        Me.dgvRevCostCenterIdNo.ReadOnly = true
        Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRevCostCenterIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvRevCostCenterIdNo.Translatable = false
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
        Me.dgvNotes.EditingMode = false
        Me.dgvNotes.EndFindValue = Nothing
        Me.dgvNotes.FieldDescription = Nothing
        Me.dgvNotes.FieldName = Nothing
        Me.dgvNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvNotes.FindEnabled = false
        Me.dgvNotes.HeaderText = "Notes"
        Me.dgvNotes.IgnoreCase = false
        Me.dgvNotes.Name = "dgvNotes"
        Me.dgvNotes.ReadOnly = true
        Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvNotes.Translatable = false
        '
        'dgvIdNo
        '
        Me.dgvIdNo.DataPropertyName = "IdNo"
        Me.dgvIdNo.HeaderText = "IdNo"
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
        Me.dgvIdNo.Visible = false
        '
        'AccountNameDataGridViewTextBoxColumn
        '
        Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
        Me.AccountNameDataGridViewTextBoxColumn.HeaderText = "AccountName"
        Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
        Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = true
        Me.AccountNameDataGridViewTextBoxColumn.Visible = false
        '
        'CancelledDataGridViewCheckBoxColumn
        '
        Me.CancelledDataGridViewCheckBoxColumn.DataPropertyName = "Cancelled"
        Me.CancelledDataGridViewCheckBoxColumn.HeaderText = "Cancelled"
        Me.CancelledDataGridViewCheckBoxColumn.Name = "CancelledDataGridViewCheckBoxColumn"
        Me.CancelledDataGridViewCheckBoxColumn.ReadOnly = true
        Me.CancelledDataGridViewCheckBoxColumn.Visible = false
        '
        'JournalIdNoDataGridViewTextBoxColumn
        '
        Me.JournalIdNoDataGridViewTextBoxColumn.DataPropertyName = "JournalIdNo"
        Me.JournalIdNoDataGridViewTextBoxColumn.HeaderText = "JournalIdNo"
        Me.JournalIdNoDataGridViewTextBoxColumn.Name = "JournalIdNoDataGridViewTextBoxColumn"
        Me.JournalIdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.JournalIdNoDataGridViewTextBoxColumn.Visible = false
        '
        'OriginalAmountDataGridViewTextBoxColumn
        '
        Me.OriginalAmountDataGridViewTextBoxColumn.DataPropertyName = "OriginalAmount"
        Me.OriginalAmountDataGridViewTextBoxColumn.HeaderText = "OriginalAmount"
        Me.OriginalAmountDataGridViewTextBoxColumn.Name = "OriginalAmountDataGridViewTextBoxColumn"
        Me.OriginalAmountDataGridViewTextBoxColumn.ReadOnly = true
        Me.OriginalAmountDataGridViewTextBoxColumn.Visible = false
        '
        'PayeeTypeDataGridViewTextBoxColumn
        '
        Me.PayeeTypeDataGridViewTextBoxColumn.DataPropertyName = "PayeeType"
        Me.PayeeTypeDataGridViewTextBoxColumn.HeaderText = "PayeeType"
        Me.PayeeTypeDataGridViewTextBoxColumn.Name = "PayeeTypeDataGridViewTextBoxColumn"
        Me.PayeeTypeDataGridViewTextBoxColumn.ReadOnly = true
        Me.PayeeTypeDataGridViewTextBoxColumn.Visible = false
        '
        'dgvPaidAmount
        '
        Me.dgvPaidAmount.DataPropertyName = "PaidAmount"
        Me.dgvPaidAmount.HeaderText = "PaidAmount"
        Me.dgvPaidAmount.Name = "dgvPaidAmount"
        Me.dgvPaidAmount.ReadOnly = true
        Me.dgvPaidAmount.Visible = false
        '
        'dgvDiscountTaken
        '
        Me.dgvDiscountTaken.DataPropertyName = "DiscountTaken"
        Me.dgvDiscountTaken.HeaderText = "DiscountTaken"
        Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
        Me.dgvDiscountTaken.ReadOnly = true
        Me.dgvDiscountTaken.Visible = false
        '
        'OpenInvoiceIdNo
        '
        Me.OpenInvoiceIdNo.DataPropertyName = "OpenInvoiceIdNo"
        Me.OpenInvoiceIdNo.HeaderText = "OpenInvoiceIdNo"
        Me.OpenInvoiceIdNo.Name = "OpenInvoiceIdNo"
        Me.OpenInvoiceIdNo.ReadOnly = true
        Me.OpenInvoiceIdNo.Visible = false
        '
        'dgvSpecialAccount
        '
        Me.dgvSpecialAccount.DataPropertyName = "SpecialAccount"
        Me.dgvSpecialAccount.HeaderText = "SpecialAccount"
        Me.dgvSpecialAccount.Name = "dgvSpecialAccount"
        Me.dgvSpecialAccount.ReadOnly = true
        Me.dgvSpecialAccount.Visible = false
        '
        'ItemVatAmount
        '
        Me.ItemVatAmount.HeaderText = "ItemVatAmount"
        Me.ItemVatAmount.Name = "ItemVatAmount"
        Me.ItemVatAmount.ReadOnly = true
        Me.ItemVatAmount.Visible = false
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
        Me.floFullEntryArea.SetFlowBreak(Me.floApJournalHeader, true)
        Me.floApJournalHeader.Location = New System.Drawing.Point(3, 3)
        Me.floApJournalHeader.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.floApJournalHeader.Name = "floApJournalHeader"
        Me.floApJournalHeader.Size = New System.Drawing.Size(1034, 217)
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
        Me.CFlowLayout3.Location = New System.Drawing.Point(3, 3)
        Me.CFlowLayout3.Name = "CFlowLayout3"
        Me.CFlowLayout3.Padding = New System.Windows.Forms.Padding(15)
        Me.CFlowLayout3.Size = New System.Drawing.Size(758, 204)
        Me.CFlowLayout3.TabIndex = 0
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(16, 16)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(145, 23)
        Me.lblIdNo.TabIndex = 160
        Me.lblIdNo.Text = "Transaction No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtJournalCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
        Me.txtJournalCode.LinkedLabel = Nothing
        Me.txtJournalCode.Location = New System.Drawing.Point(163, 16)
        Me.txtJournalCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtJournalCode.MaximumValue = Nothing
        Me.txtJournalCode.MinimumValue = Nothing
        Me.txtJournalCode.Name = "txtJournalCode"
        Me.txtJournalCode.OldValue = Nothing
        Me.txtJournalCode.ReadOnly = true
        Me.txtJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtJournalCode.Size = New System.Drawing.Size(25, 23)
        Me.txtJournalCode.TabIndex = 163
        Me.txtJournalCode.TabStop = false
        Me.txtJournalCode.Text = "AP"
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
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.Location = New System.Drawing.Point(190, 16)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(63, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.DisplayOnly = true
        Me.lblReferenceNo.EditingMode = false
        Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReferenceNo.Location = New System.Drawing.Point(255, 16)
        Me.lblReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(128, 23)
        Me.lblReferenceNo.TabIndex = 158
        Me.lblReferenceNo.Text = "Reference No.:"
        Me.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
        Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
        Me.txtReferenceNo.Location = New System.Drawing.Point(385, 16)
        Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReferenceNo.MaximumValue = Nothing
        Me.txtReferenceNo.MinimumValue = Nothing
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.OldValue = Nothing
        Me.txtReferenceNo.ReadOnly = true
        Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtReferenceNo.Size = New System.Drawing.Size(90, 23)
        Me.txtReferenceNo.TabIndex = 1
        Me.txtReferenceNo.Translatable = false
        Me.txtReferenceNo.ValueIsMandatory = true
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.DisplayOnly = true
        Me.lblTransactionDate.EditingMode = false
        Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransactionDate.Location = New System.Drawing.Point(477, 16)
        Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(130, 23)
        Me.lblTransactionDate.TabIndex = 5
        Me.lblTransactionDate.Text = "Transaction Date:"
        Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.CFlowLayout3.SetFlowBreak(Me.dtpTransactionDate, true)
        Me.dtpTransactionDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
        Me.dtpTransactionDate.LinkedLabel = Nothing
        Me.dtpTransactionDate.Location = New System.Drawing.Point(608, 15)
        Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ReadOnlyDp = false
        Me.dtpTransactionDate.SecurityKey = Nothing
        Me.dtpTransactionDate.ShowLongDate = false
        Me.dtpTransactionDate.ShowTime = false
        Me.dtpTransactionDate.Size = New System.Drawing.Size(130, 24)
        Me.dtpTransactionDate.TabIndex = 2
        Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpTransactionDate.Translatable = false
        Me.dtpTransactionDate.Value = Nothing
        Me.dtpTransactionDate.ValueIsMandatory = false
        Me.dtpTransactionDate.ValueIsNullable = false
        '
        'lblSupplierIdNo
        '
        Me.lblSupplierIdNo.DisplayOnly = true
        Me.lblSupplierIdNo.EditingMode = false
        Me.lblSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSupplierIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSupplierIdNo.Location = New System.Drawing.Point(16, 41)
        Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
        Me.lblSupplierIdNo.Size = New System.Drawing.Size(145, 23)
        Me.lblSupplierIdNo.TabIndex = 254
        Me.lblSupplierIdNo.Text = "Supplier Code/Name"
        Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSupplierIdNo.Translatable = true
        '
        'cboSupplierIdNo
        '
        Me.cboSupplierIdNo.BackColor = System.Drawing.Color.White
        Me.cboSupplierIdNo.BegFindValue = Nothing
        Me.cboSupplierIdNo.ChangingSearchValueOnly = false
        Me.cboSupplierIdNo.CurrentSearchTerm = ""
        Me.cboSupplierIdNo.DefaultValue = Nothing
        Me.cboSupplierIdNo.DisplayMember = "Name"
        Me.cboSupplierIdNo.EditingMode = true
        Me.cboSupplierIdNo.EndFindValue = Nothing
        Me.cboSupplierIdNo.FieldDescription = Nothing
        Me.cboSupplierIdNo.FieldName = Nothing
        Me.cboSupplierIdNo.FilterRule = Nothing
        Me.cboSupplierIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboSupplierIdNo.FindEnabled = false
        Me.cboSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboSupplierIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboSupplierIdNo.FormattingEnabled = true
        Me.cboSupplierIdNo.HideWhenNotEditingOrAdding = false
        Me.cboSupplierIdNo.IgnoreCase = false
        Me.cboSupplierIdNo.IntegralHeight = false
        Me.cboSupplierIdNo.LinkedLabel = Me.lblSupplierIdNo
        Me.cboSupplierIdNo.Location = New System.Drawing.Point(163, 41)
        Me.cboSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboSupplierIdNo.Name = "cboSupplierIdNo"
        Me.cboSupplierIdNo.OldValue = 0
        Me.cboSupplierIdNo.OriginalDataSource = Nothing
        Me.cboSupplierIdNo.OriginalList = Nothing
        Me.cboSupplierIdNo.OverrideDropDownStyleList = false
        Me.cboSupplierIdNo.PreviousSearchTerm = Nothing
        Me.cboSupplierIdNo.PropertySelector = Nothing
        Me.cboSupplierIdNo.ReadOnlyCombo = false
        Me.cboSupplierIdNo.Size = New System.Drawing.Size(575, 24)
        Me.cboSupplierIdNo.SuggestBoxHeight = 200
        Me.cboSupplierIdNo.SuggestListOrderRule = Nothing
        Me.cboSupplierIdNo.TabIndex = 3
        Me.cboSupplierIdNo.TextToSearch = Nothing
        Me.cboSupplierIdNo.Translatable = false
        Me.cboSupplierIdNo.ValueIsMandatory = false
        Me.cboSupplierIdNo.ValueIsNullable = false
        Me.cboSupplierIdNo.ValueIsNumeric = false
        Me.cboSupplierIdNo.ValueMember = "IdNo"
        '
        'lblTransactionType
        '
        Me.lblTransactionType.DisplayOnly = true
        Me.lblTransactionType.EditingMode = false
        Me.lblTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTransactionType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransactionType.Location = New System.Drawing.Point(16, 67)
        Me.lblTransactionType.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTransactionType.Name = "lblTransactionType"
        Me.lblTransactionType.Size = New System.Drawing.Size(145, 23)
        Me.lblTransactionType.TabIndex = 267
        Me.lblTransactionType.Text = "Transaction Type:"
        Me.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTransactionType.Translatable = true
        '
        'cboTransactionType
        '
        Me.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTransactionType.BackColor = System.Drawing.Color.White
        Me.cboTransactionType.BegFindValue = Nothing
        Me.cboTransactionType.ChangingSearchValueOnly = false
        Me.cboTransactionType.CurrentSearchTerm = ""
        Me.cboTransactionType.DefaultValue = "0"
        Me.cboTransactionType.DisplayMember = "Name"
        Me.cboTransactionType.EditingMode = false
        Me.cboTransactionType.EndFindValue = Nothing
        Me.cboTransactionType.FieldDescription = Nothing
        Me.cboTransactionType.FieldName = Nothing
        Me.cboTransactionType.FilterRule = Nothing
        Me.cboTransactionType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboTransactionType.FindEnabled = false
        Me.cboTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboTransactionType.ForeColor = System.Drawing.Color.Black
        Me.cboTransactionType.HideWhenNotEditingOrAdding = false
        Me.cboTransactionType.IgnoreCase = false
        Me.cboTransactionType.IntegralHeight = false
        Me.cboTransactionType.LinkedLabel = Nothing
        Me.cboTransactionType.Location = New System.Drawing.Point(163, 67)
        Me.cboTransactionType.Margin = New System.Windows.Forms.Padding(1)
        Me.cboTransactionType.Name = "cboTransactionType"
        Me.cboTransactionType.OldValue = 0
        Me.cboTransactionType.OriginalDataSource = Nothing
        Me.cboTransactionType.OriginalList = Nothing
        Me.cboTransactionType.OverrideDropDownStyleList = false
        Me.cboTransactionType.PreviousSearchTerm = Nothing
        Me.cboTransactionType.PropertySelector = Nothing
        Me.cboTransactionType.ReadOnlyCombo = false
        Me.cboTransactionType.Size = New System.Drawing.Size(122, 24)
        Me.cboTransactionType.SuggestBoxHeight = 200
        Me.cboTransactionType.SuggestListOrderRule = Nothing
        Me.cboTransactionType.TabIndex = 4
        Me.cboTransactionType.TextToSearch = Nothing
        Me.cboTransactionType.Translatable = false
        Me.cboTransactionType.ValueIsMandatory = false
        Me.cboTransactionType.ValueIsNullable = false
        Me.cboTransactionType.ValueIsNumeric = false
        Me.cboTransactionType.ValueMember = "Code"
        '
        'lblAmount
        '
        Me.lblAmount.DisplayOnly = true
        Me.lblAmount.EditingMode = false
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAmount.Location = New System.Drawing.Point(287, 67)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(96, 23)
        Me.lblAmount.TabIndex = 264
        Me.lblAmount.Text = "Amount:"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAmount.Translatable = true
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BegFindValue = Nothing
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.ComputedValue = false
        Me.txtAmount.CustomFormat = Nothing
        Me.txtAmount.DataBoundControl = true
        Me.txtAmount.EditingMode = false
        Me.txtAmount.EndFindValue = Nothing
        Me.txtAmount.FieldDescription = Nothing
        Me.txtAmount.FieldName = Nothing
        Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtAmount.FindEnabled = true
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.LinkedLabel = Me.lblAmount
        Me.txtAmount.Location = New System.Drawing.Point(385, 67)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAmount.MaximumValue = Nothing
        Me.txtAmount.MinimumValue = Nothing
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OldValue = Nothing
        Me.txtAmount.ReadOnly = true
        Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtAmount.Size = New System.Drawing.Size(90, 23)
        Me.txtAmount.TabIndex = 5
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmount.Translatable = false
        Me.txtAmount.ValueIsMandatory = true
        Me.txtAmount.ValueIsNumeric = true
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.DisplayOnly = true
        Me.lblInvoiceDate.EditingMode = false
        Me.lblInvoiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblInvoiceDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInvoiceDate.Location = New System.Drawing.Point(477, 67)
        Me.lblInvoiceDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(130, 23)
        Me.lblInvoiceDate.TabIndex = 257
        Me.lblInvoiceDate.Text = "Supplier Doc. Date:"
        Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInvoiceDate.Translatable = true
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpInvoiceDate.DefaultValue = Nothing
        Me.dtpInvoiceDate.DisplayOnly = false
        Me.dtpInvoiceDate.DtpDefaultValue = Nothing
        Me.dtpInvoiceDate.EditingMode = false
        Me.dtpInvoiceDate.EditsAllowed = false
        Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpInvoiceDate.ForeColor = System.Drawing.Color.Black
        Me.dtpInvoiceDate.LinkedLabel = Nothing
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(608, 66)
        Me.dtpInvoiceDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.ReadOnlyDp = false
        Me.dtpInvoiceDate.SecurityKey = Nothing
        Me.dtpInvoiceDate.ShowLongDate = false
        Me.dtpInvoiceDate.ShowTime = false
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(130, 24)
        Me.dtpInvoiceDate.TabIndex = 6
        Me.dtpInvoiceDate.TargetCalendar = CType(resources.GetObject("dtpInvoiceDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpInvoiceDate.Translatable = false
        Me.dtpInvoiceDate.Value = Nothing
        Me.dtpInvoiceDate.ValueIsMandatory = false
        Me.dtpInvoiceDate.ValueIsNullable = false
        '
        'lblDueDate
        '
        Me.lblDueDate.DisplayOnly = true
        Me.lblDueDate.EditingMode = false
        Me.lblDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDueDate.Location = New System.Drawing.Point(16, 93)
        Me.lblDueDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Size = New System.Drawing.Size(145, 23)
        Me.lblDueDate.TabIndex = 259
        Me.lblDueDate.Text = "Due Date:"
        Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDueDate.Translatable = true
        '
        'dtpDueDate
        '
        Me.dtpDueDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDueDate.DefaultValue = Nothing
        Me.dtpDueDate.DisplayOnly = false
        Me.dtpDueDate.DtpDefaultValue = Nothing
        Me.dtpDueDate.EditingMode = false
        Me.dtpDueDate.EditsAllowed = false
        Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpDueDate.ForeColor = System.Drawing.Color.Black
        Me.dtpDueDate.LinkedLabel = Nothing
        Me.dtpDueDate.Location = New System.Drawing.Point(162, 92)
        Me.dtpDueDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.ReadOnlyDp = false
        Me.dtpDueDate.SecurityKey = Nothing
        Me.dtpDueDate.ShowLongDate = false
        Me.dtpDueDate.ShowTime = false
        Me.dtpDueDate.Size = New System.Drawing.Size(130, 24)
        Me.dtpDueDate.TabIndex = 7
        Me.dtpDueDate.TargetCalendar = CType(resources.GetObject("dtpDueDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpDueDate.Translatable = false
        Me.dtpDueDate.Value = Nothing
        Me.dtpDueDate.ValueIsMandatory = false
        Me.dtpDueDate.ValueIsNullable = false
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.DisplayOnly = true
        Me.lblInvoiceNo.EditingMode = false
        Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInvoiceNo.Location = New System.Drawing.Point(293, 93)
        Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(325, 23)
        Me.lblInvoiceNo.TabIndex = 254
        Me.lblInvoiceNo.Text = "Supplier Invoice/Reference No.:"
        Me.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblInvoiceNo.Translatable = true
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.BackColor = System.Drawing.Color.White
        Me.txtInvoiceNo.BegFindValue = Nothing
        Me.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNo.ComputedValue = false
        Me.txtInvoiceNo.CustomFormat = Nothing
        Me.txtInvoiceNo.DataBoundControl = true
        Me.txtInvoiceNo.EditingMode = false
        Me.txtInvoiceNo.EndFindValue = Nothing
        Me.txtInvoiceNo.FieldDescription = Nothing
        Me.txtInvoiceNo.FieldName = Nothing
        Me.txtInvoiceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtInvoiceNo.FindEnabled = true
        Me.CFlowLayout3.SetFlowBreak(Me.txtInvoiceNo, true)
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtInvoiceNo.ForeColor = System.Drawing.Color.Black
        Me.txtInvoiceNo.LinkedLabel = Me.lblInvoiceNo
        Me.txtInvoiceNo.Location = New System.Drawing.Point(620, 93)
        Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtInvoiceNo.MaximumValue = Nothing
        Me.txtInvoiceNo.MinimumValue = Nothing
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.OldValue = Nothing
        Me.txtInvoiceNo.ReadOnly = true
        Me.txtInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtInvoiceNo.Size = New System.Drawing.Size(122, 23)
        Me.txtInvoiceNo.TabIndex = 8
        Me.txtInvoiceNo.Translatable = false
        Me.txtInvoiceNo.ValueIsMandatory = true
        '
        'lblAccountIdNo
        '
        Me.lblAccountIdNo.DisplayOnly = true
        Me.lblAccountIdNo.EditingMode = false
        Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAccountIdNo.Location = New System.Drawing.Point(16, 118)
        Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAccountIdNo.Name = "lblAccountIdNo"
        Me.lblAccountIdNo.Size = New System.Drawing.Size(145, 24)
        Me.lblAccountIdNo.TabIndex = 266
        Me.lblAccountIdNo.Text = "Acct. to Credit:"
        Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAccountIdNo.Translatable = true
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
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
        Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.IgnoreCase = false
        Me.cboAccountIdNo.IntegralHeight = false
        Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
        Me.cboAccountIdNo.Location = New System.Drawing.Point(163, 118)
        Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.OverrideDropDownStyleList = false
        Me.cboAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboAccountIdNo.PropertySelector = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.Size = New System.Drawing.Size(355, 24)
        Me.cboAccountIdNo.SuggestBoxHeight = 200
        Me.cboAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboAccountIdNo.TabIndex = 9
        Me.cboAccountIdNo.TextToSearch = Nothing
        Me.cboAccountIdNo.Translatable = false
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        Me.cboAccountIdNo.ValueMember = "IdNo"
        '
        'lblVatNumber
        '
        Me.lblVatNumber.DisplayOnly = true
        Me.lblVatNumber.EditingMode = false
        Me.lblVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblVatNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVatNumber.Location = New System.Drawing.Point(520, 118)
        Me.lblVatNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVatNumber.Name = "lblVatNumber"
        Me.lblVatNumber.Size = New System.Drawing.Size(97, 23)
        Me.lblVatNumber.TabIndex = 0
        Me.lblVatNumber.Text = "Vat Number:"
        Me.lblVatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVatNumber.Translatable = true
        '
        'txtVatNumber
        '
        Me.txtVatNumber.BackColor = System.Drawing.Color.White
        Me.txtVatNumber.BegFindValue = Nothing
        Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatNumber.ComputedValue = false
        Me.txtVatNumber.CustomFormat = Nothing
        Me.txtVatNumber.DataBoundControl = true
        Me.txtVatNumber.EditingMode = false
        Me.txtVatNumber.EndFindValue = Nothing
        Me.txtVatNumber.FieldDescription = Nothing
        Me.txtVatNumber.FieldName = Nothing
        Me.txtVatNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtVatNumber.FindEnabled = true
        Me.txtVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
        Me.txtVatNumber.LinkedLabel = Me.lblVatNumber
        Me.txtVatNumber.Location = New System.Drawing.Point(619, 118)
        Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtVatNumber.MaximumValue = Nothing
        Me.txtVatNumber.MaxLength = 15
        Me.txtVatNumber.MinimumValue = Nothing
        Me.txtVatNumber.Name = "txtVatNumber"
        Me.txtVatNumber.OldValue = Nothing
        Me.txtVatNumber.ReadOnly = true
        Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtVatNumber.Size = New System.Drawing.Size(122, 23)
        Me.txtVatNumber.TabIndex = 10
        Me.txtVatNumber.Translatable = false
        Me.txtVatNumber.ValueIsMandatory = true
        Me.txtVatNumber.ValueIsNumeric = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(16, 144)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(145, 23)
        Me.lblNotes.TabIndex = 161
        Me.lblNotes.Text = "Description/Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(163, 144)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Size = New System.Drawing.Size(579, 46)
        Me.txtNotes.TabIndex = 11
        Me.txtNotes.Translatable = false
        Me.txtNotes.ValueIsMandatory = true
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
        Me.CFlowLayout2.Location = New System.Drawing.Point(767, 3)
        Me.CFlowLayout2.Name = "CFlowLayout2"
        Me.CFlowLayout2.Padding = New System.Windows.Forms.Padding(15)
        Me.CFlowLayout2.Size = New System.Drawing.Size(259, 204)
        Me.CFlowLayout2.TabIndex = 1
        '
        'lblVatAmount
        '
        Me.lblVatAmount.DisplayOnly = true
        Me.lblVatAmount.EditingMode = false
        Me.lblVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblVatAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVatAmount.Location = New System.Drawing.Point(16, 16)
        Me.lblVatAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVatAmount.Name = "lblVatAmount"
        Me.lblVatAmount.Size = New System.Drawing.Size(97, 23)
        Me.lblVatAmount.TabIndex = 2
        Me.lblVatAmount.Text = "Vat Amount"
        Me.lblVatAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVatAmount.Translatable = true
        '
        'txtVatAmount
        '
        Me.txtVatAmount.BackColor = System.Drawing.Color.White
        Me.txtVatAmount.BegFindValue = Nothing
        Me.txtVatAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatAmount.ComputedValue = false
        Me.txtVatAmount.CustomFormat = Nothing
        Me.txtVatAmount.DataBoundControl = true
        Me.txtVatAmount.EditingMode = false
        Me.txtVatAmount.EndFindValue = Nothing
        Me.txtVatAmount.FieldDescription = Nothing
        Me.txtVatAmount.FieldName = Nothing
        Me.txtVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtVatAmount.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.txtVatAmount, true)
        Me.txtVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
        Me.txtVatAmount.LinkedLabel = Me.lblAmount
        Me.txtVatAmount.Location = New System.Drawing.Point(115, 16)
        Me.txtVatAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtVatAmount.MaximumValue = Nothing
        Me.txtVatAmount.MinimumValue = Nothing
        Me.txtVatAmount.Name = "txtVatAmount"
        Me.txtVatAmount.OldValue = Nothing
        Me.txtVatAmount.ReadOnly = true
        Me.txtVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtVatAmount.Size = New System.Drawing.Size(122, 23)
        Me.txtVatAmount.TabIndex = 2
        Me.txtVatAmount.TabStop = false
        Me.txtVatAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtVatAmount.Translatable = false
        Me.txtVatAmount.ValueIsMandatory = true
        Me.txtVatAmount.ValueIsNumeric = true
        '
        'CLabel2
        '
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CFlowLayout2.SetFlowBreak(Me.CLabel2, true)
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel2.Location = New System.Drawing.Point(16, 41)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(207, 23)
        Me.CLabel2.TabIndex = 279
        Me.CLabel2.Text = "Early Settlement Date/Rate:"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLabel2.Translatable = true
        '
        'dtpSettlementDueDate
        '
        Me.dtpSettlementDueDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpSettlementDueDate.DefaultValue = Nothing
        Me.dtpSettlementDueDate.DisplayOnly = false
        Me.dtpSettlementDueDate.DtpDefaultValue = Nothing
        Me.dtpSettlementDueDate.EditingMode = false
        Me.dtpSettlementDueDate.EditsAllowed = false
        Me.dtpSettlementDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpSettlementDueDate.ForeColor = System.Drawing.Color.Black
        Me.dtpSettlementDueDate.LinkedLabel = Nothing
        Me.dtpSettlementDueDate.Location = New System.Drawing.Point(15, 65)
        Me.dtpSettlementDueDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpSettlementDueDate.Name = "dtpSettlementDueDate"
        Me.dtpSettlementDueDate.ReadOnlyDp = false
        Me.dtpSettlementDueDate.SecurityKey = Nothing
        Me.dtpSettlementDueDate.ShowLongDate = false
        Me.dtpSettlementDueDate.ShowTime = false
        Me.dtpSettlementDueDate.Size = New System.Drawing.Size(130, 24)
        Me.dtpSettlementDueDate.TabIndex = 3
        Me.dtpSettlementDueDate.TabStop = false
        Me.dtpSettlementDueDate.TargetCalendar = CType(resources.GetObject("dtpSettlementDueDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpSettlementDueDate.Translatable = false
        Me.dtpSettlementDueDate.Value = Nothing
        Me.dtpSettlementDueDate.ValueIsMandatory = false
        Me.dtpSettlementDueDate.ValueIsNullable = false
        '
        'CLabel5
        '
        Me.CLabel5.DisplayOnly = true
        Me.CLabel5.EditingMode = false
        Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel5.Location = New System.Drawing.Point(145, 65)
        Me.CLabel5.Margin = New System.Windows.Forms.Padding(0)
        Me.CLabel5.Name = "CLabel5"
        Me.CLabel5.Size = New System.Drawing.Size(23, 23)
        Me.CLabel5.TabIndex = 277
        Me.CLabel5.Text = " - "
        Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CLabel5.Translatable = true
        '
        'txtSettlementDiscount
        '
        Me.txtSettlementDiscount.BackColor = System.Drawing.Color.White
        Me.txtSettlementDiscount.BegFindValue = Nothing
        Me.txtSettlementDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSettlementDiscount.ComputedValue = false
        Me.txtSettlementDiscount.CustomFormat = Nothing
        Me.txtSettlementDiscount.DataBoundControl = true
        Me.txtSettlementDiscount.EditingMode = false
        Me.txtSettlementDiscount.EndFindValue = Nothing
        Me.txtSettlementDiscount.FieldDescription = Nothing
        Me.txtSettlementDiscount.FieldName = Nothing
        Me.txtSettlementDiscount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtSettlementDiscount.FindEnabled = true
        Me.txtSettlementDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSettlementDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtSettlementDiscount.LinkedLabel = Nothing
        Me.txtSettlementDiscount.Location = New System.Drawing.Point(169, 66)
        Me.txtSettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSettlementDiscount.MaximumValue = Nothing
        Me.txtSettlementDiscount.MinimumValue = Nothing
        Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
        Me.txtSettlementDiscount.OldValue = Nothing
        Me.txtSettlementDiscount.ReadOnly = true
        Me.txtSettlementDiscount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtSettlementDiscount.Size = New System.Drawing.Size(44, 23)
        Me.txtSettlementDiscount.TabIndex = 4
        Me.txtSettlementDiscount.TabStop = false
        Me.txtSettlementDiscount.Translatable = false
        Me.txtSettlementDiscount.ValueIsMandatory = true
        '
        'lblPercent
        '
        Me.lblPercent.DisplayOnly = true
        Me.lblPercent.EditingMode = false
        Me.CFlowLayout2.SetFlowBreak(Me.lblPercent, true)
        Me.lblPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPercent.Location = New System.Drawing.Point(214, 65)
        Me.lblPercent.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(16, 23)
        Me.lblPercent.TabIndex = 269
        Me.lblPercent.Text = "%"
        Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPercent.Translatable = true
        '
        'chkCancelled
        '
        Me.chkCancelled.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.CFlowLayout2.SetFlowBreak(Me.chkCancelled, true)
        Me.chkCancelled.IgnoreCase = false
        Me.chkCancelled.LinkedLabel = Nothing
        Me.chkCancelled.Location = New System.Drawing.Point(18, 93)
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkCancelled.Size = New System.Drawing.Size(111, 23)
        Me.chkCancelled.TabIndex = 294
        Me.chkCancelled.Text = "Cancelled?"
        Me.chkCancelled.Translatable = true
        '
        'chkApproved
        '
        Me.chkApproved.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.chkApproved.BackColor = System.Drawing.Color.Transparent
        Me.chkApproved.BegFindValue = Nothing
        Me.chkApproved.Checked = false
        Me.chkApproved.EditingMode = false
        Me.chkApproved.EndFindValue = Nothing
        Me.chkApproved.FieldDescription = Nothing
        Me.chkApproved.FieldName = Nothing
        Me.chkApproved.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkApproved.FindEnabled = false
        Me.CFlowLayout2.SetFlowBreak(Me.chkApproved, true)
        Me.chkApproved.IgnoreCase = false
        Me.chkApproved.LinkedLabel = Nothing
        Me.chkApproved.Location = New System.Drawing.Point(18, 122)
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkApproved.Size = New System.Drawing.Size(111, 21)
        Me.chkApproved.TabIndex = 293
        Me.chkApproved.Text = "Approved?"
        Me.chkApproved.Translatable = true
        '
        'chkPosted
        '
        Me.chkPosted.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.CFlowLayout2.SetFlowBreak(Me.chkPosted, true)
        Me.chkPosted.IgnoreCase = false
        Me.chkPosted.LinkedLabel = Nothing
        Me.chkPosted.Location = New System.Drawing.Point(18, 149)
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkPosted.Size = New System.Drawing.Size(111, 21)
        Me.chkPosted.TabIndex = 295
        Me.chkPosted.Text = "Posted?"
        Me.chkPosted.Translatable = true
        '
        'lblDateAdded
        '
        Me.lblDateAdded.DisplayOnly = true
        Me.lblDateAdded.EditingMode = false
        Me.lblDateAdded.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDateAdded.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDateAdded.Location = New System.Drawing.Point(15, 173)
        Me.lblDateAdded.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDateAdded.Name = "lblDateAdded"
        Me.lblDateAdded.Size = New System.Drawing.Size(87, 26)
        Me.lblDateAdded.TabIndex = 8
        Me.lblDateAdded.Text = "Date Added:"
        Me.lblDateAdded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDateAdded.Translatable = true
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BegFindValue = Nothing
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = false
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = true
        Me.txtDateCreated.EditingMode = true
        Me.txtDateCreated.EndFindValue = Nothing
        Me.txtDateCreated.FieldDescription = Nothing
        Me.txtDateCreated.FieldName = Nothing
        Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDateCreated.FindEnabled = false
        Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Nothing
        Me.txtDateCreated.Location = New System.Drawing.Point(103, 174)
        Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDateCreated.MaximumValue = Nothing
        Me.txtDateCreated.MinimumValue = Nothing
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.ReadOnly = true
        Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDateCreated.Size = New System.Drawing.Size(134, 23)
        Me.txtDateCreated.TabIndex = 288
        Me.txtDateCreated.TabStop = false
        Me.txtDateCreated.Translatable = false
        '
        'floFullEntryArea
        '
        Me.floFullEntryArea.BackColor = System.Drawing.Color.Transparent
        Me.floFullEntryArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floFullEntryArea.Controls.Add(Me.floApJournalHeader)
        Me.floFullEntryArea.Controls.Add(Me.floApJournalItems)
        Me.floFullEntryArea.Dock = System.Windows.Forms.DockStyle.Top
        Me.floFullEntryArea.Location = New System.Drawing.Point(0, 53)
        Me.floFullEntryArea.MinimumSize = New System.Drawing.Size(1043, 512)
        Me.floFullEntryArea.Name = "floFullEntryArea"
        Me.floFullEntryArea.Size = New System.Drawing.Size(1047, 516)
        Me.floFullEntryArea.TabIndex = 0
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
        Me.txtTotalCredits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtTotalCredits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCredits.LinkedLabel = Nothing
        Me.txtTotalCredits.Location = New System.Drawing.Point(122, 575)
        Me.txtTotalCredits.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTotalCredits.MaximumValue = Nothing
        Me.txtTotalCredits.MinimumValue = Nothing
        Me.txtTotalCredits.Name = "txtTotalCredits"
        Me.txtTotalCredits.OldValue = Nothing
        Me.txtTotalCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalCredits.Size = New System.Drawing.Size(100, 23)
        Me.txtTotalCredits.TabIndex = 250
        Me.txtTotalCredits.Translatable = false
        Me.txtTotalCredits.Visible = false
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
        Me.txtTotalDebits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtTotalDebits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDebits.LinkedLabel = Nothing
        Me.txtTotalDebits.Location = New System.Drawing.Point(4, 573)
        Me.txtTotalDebits.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTotalDebits.MaximumValue = Nothing
        Me.txtTotalDebits.MinimumValue = Nothing
        Me.txtTotalDebits.Name = "txtTotalDebits"
        Me.txtTotalDebits.OldValue = Nothing
        Me.txtTotalDebits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalDebits.Size = New System.Drawing.Size(100, 23)
        Me.txtTotalDebits.TabIndex = 249
        Me.txtTotalDebits.Translatable = false
        Me.txtTotalDebits.Visible = false
        '
        'ApJournalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(1047, 586)
        Me.Controls.Add(Me.txtTotalCredits)
        Me.Controls.Add(Me.txtTotalDebits)
        Me.Controls.Add(Me.floFullEntryArea)
        Me.MinimumSize = New System.Drawing.Size(1059, 580)
        Me.Name = "ApJournalEntry"
        Me.Text = "Accounts Payable Journal Entry"
        Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
        Me.Controls.SetChildIndex(Me.txtTotalDebits, 0)
        Me.Controls.SetChildIndex(Me.txtTotalCredits, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floApJournalItems.ResumeLayout(false)
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.floApJournalHeader.ResumeLayout(false)
        Me.CFlowLayout3.ResumeLayout(false)
        Me.CFlowLayout3.PerformLayout
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        Me.floFullEntryArea.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents floApJournalItems As CFlowLayout
        Friend WithEvents DataGridViewJournalItems As CDataGridView
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
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblTransactionType As CLabel
        Friend WithEvents cboTransactionType As CaComboBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents BalanceDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
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
        Friend WithEvents ItemVatAmount As DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvSpecialAccount As DataGridViewTextBoxColumn
        Friend WithEvents cboSupplierIdNo As CaComboBox
        Friend WithEvents txtDateCreated As CTextBox
        Friend WithEvents chkApproved As UcCheckBox
        Friend WithEvents chkCancelled As UcCheckBox
        Friend WithEvents chkPosted As UcCheckBox
        Friend WithEvents txtTotalCredits As CTextBox
        Friend WithEvents txtTotalDebits As CTextBox
        Friend WithEvents txtVatAmount As CTextBox
    End Class
End NameSpace