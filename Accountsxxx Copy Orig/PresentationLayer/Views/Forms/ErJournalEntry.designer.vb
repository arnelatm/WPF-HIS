Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ErJournalEntry
        Inherits CFormEntry

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ErJournalEntry))
        Me.floErJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvPaidAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDiscountTaken = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CancelledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JournalIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OriginalAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayeeTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecialAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.floErJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblCustomerIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblTransactionType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboTransactionType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.chkApproved = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateCreated = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.floFullEntryArea = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        LocalizableContent1 = New AATM.Libraries.LocalizationUtilities.LocalizableContent()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floErJournalItems.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floErJournalHeader.SuspendLayout
        Me.CFlowLayout3.SuspendLayout
        Me.CFlowLayout2.SuspendLayout
        Me.floFullEntryArea.SuspendLayout
        Me.SuspendLayout
        '
        'floErJournalItems
        '
        Me.floErJournalItems.BackColor = System.Drawing.Color.Transparent
        Me.floErJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floErJournalItems.Controls.Add(Me.DataGridViewJournalItems)
        Me.floFullEntryArea.SetFlowBreak(Me.floErJournalItems, true)
        Me.floErJournalItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.floErJournalItems.Location = New System.Drawing.Point(3, 184)
        Me.floErJournalItems.Name = "floErJournalItems"
        Me.floErJournalItems.Size = New System.Drawing.Size(1026, 289)
        Me.floErJournalItems.TabIndex = 1
        '
        'DataGridViewJournalItems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewJournalItems.AutoGenerateColumns = false
        Me.DataGridViewJournalItems.BegFindValue = Nothing
        Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.dgvPaidAmount, Me.dgvDiscountTaken, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn, Me.dgvIdNo, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OpenInvoiceIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PayeeTypeDataGridViewTextBoxColumn, Me.SpecialAccountDataGridViewTextBoxColumn})
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
        Me.DataGridViewJournalItems.IsDirty = false
        Me.DataGridViewJournalItems.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
        Me.DataGridViewJournalItems.ReadOnly = true
        Me.DataGridViewJournalItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewJournalItems.SecurityKey = ""
        Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
        Me.DataGridViewJournalItems.ShowFooter = false
        Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = true
        Me.DataGridViewJournalItems.Size = New System.Drawing.Size(1015, 280)
        Me.DataGridViewJournalItems.TabIndex = 0
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
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSequence.Translatable = false
        Me.dgvSequence.Width = 40
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAccountIdNo.DisplayStyleForCurrentCellOnly = true
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
        '
        'dgvRevCostCenterIdNo
        '
        Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = true
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
        'dgvIdNo
        '
        Me.dgvIdNo.DataPropertyName = "IdNo"
        Me.dgvIdNo.HeaderText = "IdNo"
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
        Me.dgvIdNo.Visible = false
        '
        'JournalIdNoDataGridViewTextBoxColumn
        '
        Me.JournalIdNoDataGridViewTextBoxColumn.DataPropertyName = "JournalIdNo"
        Me.JournalIdNoDataGridViewTextBoxColumn.HeaderText = "JournalIdNo"
        Me.JournalIdNoDataGridViewTextBoxColumn.Name = "JournalIdNoDataGridViewTextBoxColumn"
        Me.JournalIdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.JournalIdNoDataGridViewTextBoxColumn.Visible = false
        '
        'OpenInvoiceIdNoDataGridViewTextBoxColumn
        '
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.DataPropertyName = "OpenInvoiceIdNo"
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.HeaderText = "OpenInvoiceIdNo"
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.Name = "OpenInvoiceIdNoDataGridViewTextBoxColumn"
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.Visible = false
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
        'SpecialAccountDataGridViewTextBoxColumn
        '
        Me.SpecialAccountDataGridViewTextBoxColumn.DataPropertyName = "SpecialAccount"
        Me.SpecialAccountDataGridViewTextBoxColumn.HeaderText = "SpecialAccount"
        Me.SpecialAccountDataGridViewTextBoxColumn.Name = "SpecialAccountDataGridViewTextBoxColumn"
        Me.SpecialAccountDataGridViewTextBoxColumn.ReadOnly = true
        Me.SpecialAccountDataGridViewTextBoxColumn.Visible = false
        '
        'bsJournalItems
        '
        Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
        '
        'floErJournalHeader
        '
        Me.floErJournalHeader.BackColor = System.Drawing.Color.Transparent
        Me.floErJournalHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floErJournalHeader.Controls.Add(Me.CFlowLayout3)
        Me.floErJournalHeader.Controls.Add(Me.CFlowLayout2)
        Me.floFullEntryArea.SetFlowBreak(Me.floErJournalHeader, true)
        Me.floErJournalHeader.Location = New System.Drawing.Point(3, 3)
        Me.floErJournalHeader.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.floErJournalHeader.Name = "floErJournalHeader"
        Me.floErJournalHeader.Size = New System.Drawing.Size(1026, 175)
        Me.floErJournalHeader.TabIndex = 0
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
        Me.CFlowLayout3.Controls.Add(Me.lblCustomerIdNo)
        Me.CFlowLayout3.Controls.Add(Me.cboEmployeeIdNo)
        Me.CFlowLayout3.Controls.Add(Me.lblTransactionType)
        Me.CFlowLayout3.Controls.Add(Me.cboTransactionType)
        Me.CFlowLayout3.Controls.Add(Me.lblAmount)
        Me.CFlowLayout3.Controls.Add(Me.txtAmount)
        Me.CFlowLayout3.Controls.Add(Me.lblAccountIdNo)
        Me.CFlowLayout3.Controls.Add(Me.cboAccountIdNo)
        Me.CFlowLayout3.Controls.Add(Me.lblNotes)
        Me.CFlowLayout3.Controls.Add(Me.txtNotes)
        Me.CFlowLayout3.Location = New System.Drawing.Point(3, 3)
        Me.CFlowLayout3.Name = "CFlowLayout3"
        Me.CFlowLayout3.Padding = New System.Windows.Forms.Padding(10)
        Me.CFlowLayout3.Size = New System.Drawing.Size(753, 166)
        Me.CFlowLayout3.TabIndex = 0
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
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
        Me.txtJournalCode.Location = New System.Drawing.Point(158, 11)
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
        Me.txtJournalCode.Text = "ER"
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
        Me.TxtIdNo.Location = New System.Drawing.Point(185, 11)
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
        Me.lblReferenceNo.Location = New System.Drawing.Point(250, 11)
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
        Me.txtReferenceNo.Location = New System.Drawing.Point(380, 11)
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
        Me.lblTransactionDate.Location = New System.Drawing.Point(472, 11)
        Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(141, 23)
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
        Me.dtpTransactionDate.Location = New System.Drawing.Point(614, 10)
        Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ReadOnlyDp = false
        Me.dtpTransactionDate.SecurityKey = Nothing
        Me.dtpTransactionDate.ShowLongDate = false
        Me.dtpTransactionDate.ShowTime = false
        Me.dtpTransactionDate.Size = New System.Drawing.Size(123, 24)
        Me.dtpTransactionDate.TabIndex = 2
        Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpTransactionDate.Translatable = false
        Me.dtpTransactionDate.Value = Nothing
        Me.dtpTransactionDate.ValueIsMandatory = false
        Me.dtpTransactionDate.ValueIsNullable = false
        '
        'lblCustomerIdNo
        '
        Me.lblCustomerIdNo.DisplayOnly = true
        Me.lblCustomerIdNo.EditingMode = false
        Me.lblCustomerIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCustomerIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCustomerIdNo.Location = New System.Drawing.Point(11, 36)
        Me.lblCustomerIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCustomerIdNo.Name = "lblCustomerIdNo"
        Me.lblCustomerIdNo.Size = New System.Drawing.Size(145, 23)
        Me.lblCustomerIdNo.TabIndex = 254
        Me.lblCustomerIdNo.Text = "Employee Code/Name"
        Me.lblCustomerIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCustomerIdNo.Translatable = true
        '
        'cboEmployeeIdNo
        '
        Me.cboEmployeeIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboEmployeeIdNo.BegFindValue = Nothing
        Me.cboEmployeeIdNo.ChangingSearchValueOnly = false
        Me.cboEmployeeIdNo.CurrentSearchTerm = ""
        Me.cboEmployeeIdNo.DefaultValue = Nothing
        Me.cboEmployeeIdNo.DisplayMember = "Name"
        Me.cboEmployeeIdNo.EditingMode = false
        Me.cboEmployeeIdNo.EndFindValue = Nothing
        Me.cboEmployeeIdNo.FieldDescription = Nothing
        Me.cboEmployeeIdNo.FieldName = Nothing
        Me.cboEmployeeIdNo.FilterRule = Nothing
        Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboEmployeeIdNo.FindEnabled = false
        Me.cboEmployeeIdNo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CFlowLayout3.SetFlowBreak(Me.cboEmployeeIdNo, true)
        Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEmployeeIdNo.FormattingEnabled = true
        Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cboEmployeeIdNo.IgnoreCase = false
        Me.cboEmployeeIdNo.IntegralHeight = false
        Me.cboEmployeeIdNo.LinkedLabel = Nothing
        Me.cboEmployeeIdNo.Location = New System.Drawing.Point(158, 36)
        Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = false
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cboEmployeeIdNo.PropertySelector = Nothing
        Me.cboEmployeeIdNo.ReadOnlyCombo = false
        Me.cboEmployeeIdNo.Size = New System.Drawing.Size(579, 24)
        Me.cboEmployeeIdNo.SuggestBoxHeight = 200
        Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cboEmployeeIdNo.TabIndex = 3
        Me.cboEmployeeIdNo.TextToSearch = Nothing
        Me.cboEmployeeIdNo.Translatable = false
        Me.cboEmployeeIdNo.ValueIsMandatory = false
        Me.cboEmployeeIdNo.ValueIsNullable = false
        Me.cboEmployeeIdNo.ValueIsNumeric = false
        Me.cboEmployeeIdNo.ValueMember = "IdNo"
        '
        'lblTransactionType
        '
        Me.lblTransactionType.DisplayOnly = true
        Me.lblTransactionType.EditingMode = false
        Me.lblTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTransactionType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransactionType.Location = New System.Drawing.Point(11, 62)
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
        Me.cboTransactionType.Location = New System.Drawing.Point(158, 62)
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
        Me.lblAmount.Location = New System.Drawing.Point(282, 62)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(331, 23)
        Me.lblAmount.TabIndex = 264
        Me.lblAmount.Text = "Amount:"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.CFlowLayout3.SetFlowBreak(Me.txtAmount, true)
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.LinkedLabel = Me.lblAmount
        Me.txtAmount.Location = New System.Drawing.Point(615, 62)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAmount.MaximumValue = Nothing
        Me.txtAmount.MinimumValue = Nothing
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OldValue = Nothing
        Me.txtAmount.ReadOnly = true
        Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtAmount.Size = New System.Drawing.Size(122, 23)
        Me.txtAmount.TabIndex = 5
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmount.Translatable = false
        Me.txtAmount.ValueIsMandatory = true
        Me.txtAmount.ValueIsNumeric = true
        '
        'lblAccountIdNo
        '
        Me.lblAccountIdNo.DisplayOnly = true
        Me.lblAccountIdNo.EditingMode = false
        Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAccountIdNo.Location = New System.Drawing.Point(11, 88)
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
        Me.CFlowLayout3.SetFlowBreak(Me.cboAccountIdNo, true)
        Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.IgnoreCase = false
        Me.cboAccountIdNo.IntegralHeight = false
        Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
        Me.cboAccountIdNo.Location = New System.Drawing.Point(158, 88)
        Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.OverrideDropDownStyleList = false
        Me.cboAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboAccountIdNo.PropertySelector = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.Size = New System.Drawing.Size(579, 24)
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
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(11, 114)
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
        Me.txtNotes.Location = New System.Drawing.Point(158, 114)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Size = New System.Drawing.Size(579, 46)
        Me.txtNotes.TabIndex = 10
        Me.txtNotes.Translatable = false
        Me.txtNotes.ValueIsMandatory = true
        '
        'CFlowLayout2
        '
        Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout2.Controls.Add(Me.chkCancelled)
        Me.CFlowLayout2.Controls.Add(Me.chkPosted)
        Me.CFlowLayout2.Controls.Add(Me.chkApproved)
        Me.CFlowLayout2.Controls.Add(Me.lblDateAdded)
        Me.CFlowLayout2.Controls.Add(Me.dtpDateCreated)
        Me.CFlowLayout2.Location = New System.Drawing.Point(762, 3)
        Me.CFlowLayout2.Name = "CFlowLayout2"
        Me.CFlowLayout2.Padding = New System.Windows.Forms.Padding(10)
        Me.CFlowLayout2.Size = New System.Drawing.Size(256, 166)
        Me.CFlowLayout2.TabIndex = 1
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
        Me.chkCancelled.FindEnabled = true
        Me.chkCancelled.IgnoreCase = false
        Me.chkCancelled.LinkedLabel = Nothing
        Me.chkCancelled.Location = New System.Drawing.Point(13, 13)
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
        Me.chkCancelled.Size = New System.Drawing.Size(117, 21)
        Me.chkCancelled.TabIndex = 286
        Me.chkCancelled.Text = "Cancelled?"
        Me.chkCancelled.Translatable = true
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
        Me.chkPosted.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.chkPosted, true)
        Me.chkPosted.IgnoreCase = false
        Me.chkPosted.LinkedLabel = Nothing
        Me.chkPosted.Location = New System.Drawing.Point(136, 13)
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkPosted.Size = New System.Drawing.Size(85, 21)
        Me.chkPosted.TabIndex = 288
        Me.chkPosted.Text = "Posted?"
        Me.chkPosted.Translatable = true
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
        Me.chkApproved.FindEnabled = true
        Me.CFlowLayout2.SetFlowBreak(Me.chkApproved, true)
        Me.chkApproved.IgnoreCase = false
        Me.chkApproved.LinkedLabel = Nothing
        Me.chkApproved.Location = New System.Drawing.Point(13, 40)
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkApproved.Size = New System.Drawing.Size(85, 21)
        Me.chkApproved.TabIndex = 287
        Me.chkApproved.Text = "Approved?"
        Me.chkApproved.Translatable = true
        '
        'lblDateAdded
        '
        Me.lblDateAdded.DisplayOnly = true
        Me.lblDateAdded.EditingMode = false
        Me.lblDateAdded.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDateAdded.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDateAdded.Location = New System.Drawing.Point(10, 64)
        Me.lblDateAdded.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDateAdded.Name = "lblDateAdded"
        Me.lblDateAdded.Size = New System.Drawing.Size(68, 26)
        Me.lblDateAdded.TabIndex = 8
        Me.lblDateAdded.Text = "Date Added:"
        Me.lblDateAdded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDateAdded.Translatable = true
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
        Me.dtpDateCreated.Location = New System.Drawing.Point(79, 65)
        Me.dtpDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpDateCreated.Name = "dtpDateCreated"
        Me.dtpDateCreated.ReadOnlyDp = true
        Me.dtpDateCreated.SecurityKey = Nothing
        Me.dtpDateCreated.ShowLongDate = false
        Me.dtpDateCreated.ShowTime = true
        Me.dtpDateCreated.Size = New System.Drawing.Size(157, 25)
        Me.dtpDateCreated.TabIndex = 285
        Me.dtpDateCreated.TargetCalendar = Nothing
        Me.dtpDateCreated.Translatable = false
        Me.dtpDateCreated.Value = Nothing
        Me.dtpDateCreated.ValueIsMandatory = false
        Me.dtpDateCreated.ValueIsNullable = false
        '
        'floFullEntryArea
        '
        Me.floFullEntryArea.BackColor = System.Drawing.Color.Transparent
        Me.floFullEntryArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floFullEntryArea.Controls.Add(Me.floErJournalHeader)
        Me.floFullEntryArea.Controls.Add(Me.floErJournalItems)
        Me.floFullEntryArea.Dock = System.Windows.Forms.DockStyle.Top
        Me.floFullEntryArea.Location = New System.Drawing.Point(0, 53)
        Me.floFullEntryArea.Name = "floFullEntryArea"
        Me.floFullEntryArea.Size = New System.Drawing.Size(1043, 478)
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
        Me.txtTotalCredits.Location = New System.Drawing.Point(118, 537)
        Me.txtTotalCredits.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTotalCredits.MaximumValue = Nothing
        Me.txtTotalCredits.MinimumValue = Nothing
        Me.txtTotalCredits.Name = "txtTotalCredits"
        Me.txtTotalCredits.OldValue = Nothing
        Me.txtTotalCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalCredits.Size = New System.Drawing.Size(100, 23)
        Me.txtTotalCredits.TabIndex = 254
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
        Me.txtTotalDebits.Location = New System.Drawing.Point(0, 535)
        Me.txtTotalDebits.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTotalDebits.MaximumValue = Nothing
        Me.txtTotalDebits.MinimumValue = Nothing
        Me.txtTotalDebits.Name = "txtTotalDebits"
        Me.txtTotalDebits.OldValue = Nothing
        Me.txtTotalDebits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalDebits.Size = New System.Drawing.Size(100, 23)
        Me.txtTotalDebits.TabIndex = 253
        Me.txtTotalDebits.Translatable = false
        Me.txtTotalDebits.Visible = false
        '
        'ErJournalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(1043, 551)
        Me.Controls.Add(Me.txtTotalCredits)
        Me.Controls.Add(Me.txtTotalDebits)
        Me.Controls.Add(Me.floFullEntryArea)
        Me.MinimumSize = New System.Drawing.Size(1059, 579)
        Me.Name = "ErJournalEntry"
        Me.Text = "Employe Receivable Journal Entry"
        Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
        Me.Controls.SetChildIndex(Me.txtTotalDebits, 0)
        Me.Controls.SetChildIndex(Me.txtTotalCredits, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floErJournalItems.ResumeLayout(false)
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.floErJournalHeader.ResumeLayout(false)
        Me.CFlowLayout3.ResumeLayout(false)
        Me.CFlowLayout3.PerformLayout
        Me.CFlowLayout2.ResumeLayout(false)
        Me.floFullEntryArea.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents floErJournalItems As CFlowLayout
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents floErJournalHeader As CFlowLayout
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
        Friend WithEvents lblCustomerIdNo As CLabel
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents lblDateAdded As CLabel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboEmployeeIdNo As CaComboBox
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblTransactionType As CLabel
        Friend WithEvents cboTransactionType As CaComboBox
        Friend WithEvents BalanceDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvAccountIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvMoneyColumn
        Friend WithEvents dgvCredit As CdgvMoneyColumn
        Friend WithEvents dgvRevCostCenterIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvNotes As CDgvTextColumn
        Friend WithEvents dgvPaidAmount As DataGridViewTextBoxColumn
        Friend WithEvents dgvDiscountTaken As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
        Friend WithEvents JournalIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OriginalAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayeeTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SpecialAccountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dtpDateCreated As CCustomDateTimePicker
        Friend WithEvents chkCancelled As UcCheckBox
        Friend WithEvents chkPosted As UcCheckBox
        Friend WithEvents chkApproved As UcCheckBox
        Friend WithEvents txtTotalCredits As CTextBox
        Friend WithEvents txtTotalDebits As CTextBox
    End Class
End NameSpace