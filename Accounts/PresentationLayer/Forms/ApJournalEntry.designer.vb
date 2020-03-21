Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ApJournalEntry
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
        Dim LocalizableContent1 As AATM.Libraries.LocalizationUtilities.LocalizableContent
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApJournalEntry))
        Dim SecurityPresenter1 As AATM.PresentationLayer.Presenters.SecurityPresenter = New AATM.PresentationLayer.Presenters.SecurityPresenter()
        Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTotals = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floApJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvProfitCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CancelledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JournalIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OriginalAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayeeTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvPaidAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDiscountTaken = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemVatAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenInvoiceIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource()
        Me.lblCancelled = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.floApJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpTransactionDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblTransactionType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboTransactionType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpInvoiceDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblDueDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDueDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblVatNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpSettlementDueDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPercent = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floFullEntryArea = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        LocalizableContent1 = New AATM.Libraries.LocalizationUtilities.LocalizableContent()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floApJournalItems.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floApJournalHeader.SuspendLayout
        Me.CFlowLayout3.SuspendLayout
        Me.CFlowLayout2.SuspendLayout
        Me.floFullEntryArea.SuspendLayout
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'txtTotalCredits
        '
        Me.txtTotalCredits.BackColor = System.Drawing.Color.White
        Me.txtTotalCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCredits.ComputedValue = true
        Me.txtTotalCredits.CustomFormat = Nothing
        Me.txtTotalCredits.DataBoundControl = true
        Me.txtTotalCredits.DisplayOnly = true
        Me.txtTotalCredits.EditingMode = true
        Me.txtTotalCredits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtTotalCredits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCredits.LinkedLabel = Me.lblTotals
        Me.txtTotalCredits.Location = New System.Drawing.Point(391, 1)
        Me.txtTotalCredits.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTotalCredits.Name = "txtTotalCredits"
        Me.txtTotalCredits.OldValue = Nothing
        Me.txtTotalCredits.ReadOnly = true
        Me.txtTotalCredits.Size = New System.Drawing.Size(90, 23)
        Me.txtTotalCredits.TabIndex = 2
        Me.txtTotalCredits.TabStop = false
        Me.txtTotalCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalCredits.ValueIsMandatory = true
        '
        'lblTotals
        '
        Me.lblTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTotals.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotals.Location = New System.Drawing.Point(1, 1)
        Me.lblTotals.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTotals.Name = "lblTotals"
        Me.lblTotals.Size = New System.Drawing.Size(296, 23)
        Me.lblTotals.TabIndex = 0
        Me.lblTotals.Text = "Totals:"
        Me.lblTotals.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalDebits
        '
        Me.txtTotalDebits.BackColor = System.Drawing.Color.White
        Me.txtTotalDebits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDebits.ComputedValue = true
        Me.txtTotalDebits.CustomFormat = Nothing
        Me.txtTotalDebits.DataBoundControl = true
        Me.txtTotalDebits.DisplayOnly = true
        Me.txtTotalDebits.EditingMode = true
        Me.txtTotalDebits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtTotalDebits.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDebits.LinkedLabel = Me.lblTotals
        Me.txtTotalDebits.Location = New System.Drawing.Point(299, 1)
        Me.txtTotalDebits.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTotalDebits.Name = "txtTotalDebits"
        Me.txtTotalDebits.OldValue = Nothing
        Me.txtTotalDebits.ReadOnly = true
        Me.txtTotalDebits.Size = New System.Drawing.Size(90, 23)
        Me.txtTotalDebits.TabIndex = 1
        Me.txtTotalDebits.TabStop = false
        Me.txtTotalDebits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDebits.ValueIsMandatory = true
        '
        'floApJournalItems
        '
        Me.floApJournalItems.BackColor = System.Drawing.Color.Transparent
        Me.floApJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floApJournalItems.Controls.Add(Me.DataGridViewJournalItems)
        Me.floFullEntryArea.SetFlowBreak(Me.floApJournalItems, true)
        Me.floApJournalItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.floApJournalItems.Location = New System.Drawing.Point(3, 213)
        Me.floApJournalItems.Name = "floApJournalItems"
        Me.floApJournalItems.Size = New System.Drawing.Size(1020, 263)
        Me.floApJournalItems.TabIndex = 1
        '
        'DataGridViewJournalItems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewJournalItems.AutoGenerateColumns = false
        Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvProfitCenterIdNo, Me.dgvNotes, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PayeeTypeDataGridViewTextBoxColumn, Me.dgvPaidAmount, Me.dgvDiscountTaken, Me.ItemVatAmount, Me.OpenInvoiceIdNo})
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
        Me.DataGridViewJournalItems.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataGridViewJournalItems.EditingMode = false
        Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewJournalItems.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
        Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewJournalItems.Size = New System.Drawing.Size(1015, 250)
        Me.DataGridViewJournalItems.StartTrackingChanges = false
        Me.DataGridViewJournalItems.TabIndex = 0
        '
        'dgvSequence
        '
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSequence.EditingMode = false
        Me.dgvSequence.HeaderText = "Seq."
        Me.dgvSequence.MinimumWidth = 50
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.Width = 50
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        Me.dgvAccountIdNo.HeaderText = "AccountIdNo"
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvAccountIdNo.Width = 200
        '
        'dgvDebit
        '
        Me.dgvDebit.DataPropertyName = "Debit"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Format = "###,##0.00"
        Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDebit.EditingMode = false
        Me.dgvDebit.FillWeight = 90!
        Me.dgvDebit.HeaderText = "Debit"
        Me.dgvDebit.Name = "dgvDebit"
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
        Me.dgvCredit.EditingMode = false
        Me.dgvCredit.HeaderText = "Credit"
        Me.dgvCredit.Name = "dgvCredit"
        Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvCredit.Width = 90
        '
        'dgvProfitCenterIdNo
        '
        Me.dgvProfitCenterIdNo.DataPropertyName = "ProfitCenterIdNo"
        Me.dgvProfitCenterIdNo.HeaderText = "ProfitCenterIdNo"
        Me.dgvProfitCenterIdNo.Name = "dgvProfitCenterIdNo"
        Me.dgvProfitCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProfitCenterIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvProfitCenterIdNo.Width = 200
        '
        'dgvNotes
        '
        Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvNotes.EditingMode = false
        Me.dgvNotes.HeaderText = "Notes"
        Me.dgvNotes.Name = "dgvNotes"
        Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'AccountNameDataGridViewTextBoxColumn
        '
        Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
        Me.AccountNameDataGridViewTextBoxColumn.HeaderText = "AccountName"
        Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
        Me.AccountNameDataGridViewTextBoxColumn.Visible = false
        '
        'CancelledDataGridViewCheckBoxColumn
        '
        Me.CancelledDataGridViewCheckBoxColumn.DataPropertyName = "Cancelled"
        Me.CancelledDataGridViewCheckBoxColumn.HeaderText = "Cancelled"
        Me.CancelledDataGridViewCheckBoxColumn.Name = "CancelledDataGridViewCheckBoxColumn"
        Me.CancelledDataGridViewCheckBoxColumn.Visible = false
        '
        'IdNoDataGridViewTextBoxColumn
        '
        Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
        Me.IdNoDataGridViewTextBoxColumn.Visible = false
        '
        'JournalIdNoDataGridViewTextBoxColumn
        '
        Me.JournalIdNoDataGridViewTextBoxColumn.DataPropertyName = "JournalIdNo"
        Me.JournalIdNoDataGridViewTextBoxColumn.HeaderText = "JournalIdNo"
        Me.JournalIdNoDataGridViewTextBoxColumn.Name = "JournalIdNoDataGridViewTextBoxColumn"
        Me.JournalIdNoDataGridViewTextBoxColumn.Visible = false
        '
        'OriginalAmountDataGridViewTextBoxColumn
        '
        Me.OriginalAmountDataGridViewTextBoxColumn.DataPropertyName = "OriginalAmount"
        Me.OriginalAmountDataGridViewTextBoxColumn.HeaderText = "OriginalAmount"
        Me.OriginalAmountDataGridViewTextBoxColumn.Name = "OriginalAmountDataGridViewTextBoxColumn"
        Me.OriginalAmountDataGridViewTextBoxColumn.Visible = false
        '
        'PayeeTypeDataGridViewTextBoxColumn
        '
        Me.PayeeTypeDataGridViewTextBoxColumn.DataPropertyName = "PayeeType"
        Me.PayeeTypeDataGridViewTextBoxColumn.HeaderText = "PayeeType"
        Me.PayeeTypeDataGridViewTextBoxColumn.Name = "PayeeTypeDataGridViewTextBoxColumn"
        Me.PayeeTypeDataGridViewTextBoxColumn.Visible = false
        '
        'dgvPaidAmount
        '
        Me.dgvPaidAmount.DataPropertyName = "PaidAmount"
        Me.dgvPaidAmount.HeaderText = "PaidAmount"
        Me.dgvPaidAmount.Name = "dgvPaidAmount"
        Me.dgvPaidAmount.Visible = false
        '
        'dgvDiscountTaken
        '
        Me.dgvDiscountTaken.DataPropertyName = "DiscountTaken"
        Me.dgvDiscountTaken.HeaderText = "DiscountTaken"
        Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
        Me.dgvDiscountTaken.Visible = false
        '
        'ItemVatAmount
        '
        Me.ItemVatAmount.HeaderText = "ItemVatAmount"
        Me.ItemVatAmount.Name = "ItemVatAmount"
        Me.ItemVatAmount.Visible = false
        '
        'OpenInvoiceIdNo
        '
        Me.OpenInvoiceIdNo.DataPropertyName = "OpenInvoiceIdNo"
        Me.OpenInvoiceIdNo.HeaderText = "OpenInvoiceIdNo"
        Me.OpenInvoiceIdNo.Name = "OpenInvoiceIdNo"
        Me.OpenInvoiceIdNo.Visible = false
        '
        'bsJournalItems
        '
        Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
        '
        'lblCancelled
        '
        Me.lblCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCancelled.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelled.Location = New System.Drawing.Point(1, 101)
        Me.lblCancelled.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCancelled.Name = "lblCancelled"
        Me.lblCancelled.Size = New System.Drawing.Size(97, 23)
        Me.lblCancelled.TabIndex = 4
        Me.lblCancelled.Text = "Cancelled?"
        Me.lblCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkPosted
        '
        Me.chkPosted.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkPosted.AutoCheck = false
        Me.chkPosted.BackColor = System.Drawing.Color.White
        Me.chkPosted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPosted.DisplayOnly = true
        Me.chkPosted.EditingMode = true
        Me.chkPosted.Enabled = false
        Me.chkPosted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout2.SetFlowBreak(Me.chkPosted, true)
        Me.chkPosted.ForeColor = System.Drawing.Color.Black
        Me.chkPosted.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkPosted.LinkedLabel = Me.lblPosted
        Me.chkPosted.Location = New System.Drawing.Point(100, 126)
        Me.chkPosted.Margin = New System.Windows.Forms.Padding(1)
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.Size = New System.Drawing.Size(23, 21)
        Me.chkPosted.TabIndex = 6
        Me.chkPosted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPosted.UseVisualStyleBackColor = false
        '
        'lblPosted
        '
        Me.lblPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPosted.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPosted.Location = New System.Drawing.Point(1, 126)
        Me.lblPosted.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPosted.Name = "lblPosted"
        Me.lblPosted.Size = New System.Drawing.Size(97, 23)
        Me.lblPosted.TabIndex = 6
        Me.lblPosted.Text = "Posted?"
        Me.lblPosted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.floApJournalHeader.Size = New System.Drawing.Size(1020, 204)
        Me.floApJournalHeader.TabIndex = 0
        '
        'CFlowLayout3
        '
        Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout3.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout3.Controls.Add(Me.txtJournalCode)
        Me.CFlowLayout3.Controls.Add(Me.TxtIDNo)
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
        Me.CFlowLayout3.Controls.Add(Me.lblNotes)
        Me.CFlowLayout3.Controls.Add(Me.txtNotes)
        Me.CFlowLayout3.Location = New System.Drawing.Point(3, 3)
        Me.CFlowLayout3.Name = "CFlowLayout3"
        Me.CFlowLayout3.Padding = New System.Windows.Forms.Padding(10)
        Me.CFlowLayout3.Size = New System.Drawing.Size(763, 193)
        Me.CFlowLayout3.TabIndex = 0
        '
        'lblIdNo
        '
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(145, 23)
        Me.lblIdNo.TabIndex = 160
        Me.lblIdNo.Text = "Transaction No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtJournalCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
        Me.txtJournalCode.LinkedLabel = Nothing
        Me.txtJournalCode.Location = New System.Drawing.Point(158, 11)
        Me.txtJournalCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtJournalCode.Name = "txtJournalCode"
        Me.txtJournalCode.OldValue = Nothing
        Me.txtJournalCode.ReadOnly = true
        Me.txtJournalCode.Size = New System.Drawing.Size(25, 23)
        Me.txtJournalCode.TabIndex = 163
        Me.txtJournalCode.TabStop = false
        Me.txtJournalCode.Text = "AP"
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
        Me.TxtIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Me.lblIdNo
        Me.TxtIDNo.Location = New System.Drawing.Point(185, 11)
        Me.TxtIDNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.OldValue = Nothing
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.Size = New System.Drawing.Size(63, 23)
        Me.TxtIDNo.TabIndex = 0
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReferenceNo.Location = New System.Drawing.Point(250, 11)
        Me.lblReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(128, 23)
        Me.lblReferenceNo.TabIndex = 158
        Me.lblReferenceNo.Text = "Reference No.:"
        Me.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.BackColor = System.Drawing.Color.White
        Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNo.ComputedValue = false
        Me.txtReferenceNo.CustomFormat = Nothing
        Me.txtReferenceNo.DataBoundControl = true
        Me.txtReferenceNo.EditingMode = false
        Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
        Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
        Me.txtReferenceNo.Location = New System.Drawing.Point(380, 11)
        Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.OldValue = Nothing
        Me.txtReferenceNo.Size = New System.Drawing.Size(90, 23)
        Me.txtReferenceNo.TabIndex = 1
        Me.txtReferenceNo.ValueIsMandatory = true
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransactionDate.Location = New System.Drawing.Point(472, 11)
        Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(141, 23)
        Me.lblTransactionDate.TabIndex = 5
        Me.lblTransactionDate.Text = "Transaction Date:"
        Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.dtpTransactionDate.Value = Nothing
        Me.dtpTransactionDate.ValueIsMandatory = false
        Me.dtpTransactionDate.ValueIsNullable = false
        '
        'lblSupplierIdNo
        '
        Me.lblSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblSupplierIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSupplierIdNo.Location = New System.Drawing.Point(11, 36)
        Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
        Me.lblSupplierIdNo.Size = New System.Drawing.Size(145, 23)
        Me.lblSupplierIdNo.TabIndex = 254
        Me.lblSupplierIdNo.Text = "Supplier Code/Name"
        Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSupplierIdNo
        '
        Me.cboSupplierIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSupplierIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSupplierIdNo.BackColor = System.Drawing.Color.White
        Me.cboSupplierIdNo.ChangingSearchValueOnly = false
        Me.cboSupplierIdNo.CurrentSearchTerm = ""
        Me.cboSupplierIdNo.DefaultValue = Nothing
        Me.cboSupplierIdNo.DisplayMember = "Name"
        Me.cboSupplierIdNo.DropDownHeight = 200
        Me.cboSupplierIdNo.EditingMode = false
        Me.cboSupplierIdNo.FilterRule = Nothing
        Me.cboSupplierIdNo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CFlowLayout3.SetFlowBreak(Me.cboSupplierIdNo, true)
        Me.cboSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboSupplierIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboSupplierIdNo.FormattingEnabled = true
        Me.cboSupplierIdNo.HideWhenNotEditingOrAdding = false
        Me.cboSupplierIdNo.LinkedLabel = Nothing
        Me.cboSupplierIdNo.Location = New System.Drawing.Point(158, 36)
        Me.cboSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboSupplierIdNo.Name = "cboSupplierIdNo"
        Me.cboSupplierIdNo.OldValue = 0
        Me.cboSupplierIdNo.OriginalDataSource = Nothing
        Me.cboSupplierIdNo.OriginalList = Nothing
        Me.cboSupplierIdNo.OverrideDropDownStyleList = false
        Me.cboSupplierIdNo.PreviousSearchTerm = Nothing
        Me.cboSupplierIdNo.PreviousSelectedIndex = -1
        Me.cboSupplierIdNo.PropertySelector = Nothing
        Me.cboSupplierIdNo.ReadOnlyCombo = false
        Me.cboSupplierIdNo.SearchAnywhere = false
        Me.cboSupplierIdNo.Size = New System.Drawing.Size(579, 24)
        Me.cboSupplierIdNo.SuggestBoxHeight = 200
        Me.cboSupplierIdNo.SuggestListOrderRule = Nothing
        Me.cboSupplierIdNo.TabIndex = 3
        Me.cboSupplierIdNo.TextToSearch = Nothing
        Me.cboSupplierIdNo.ValueIsMandatory = false
        Me.cboSupplierIdNo.ValueIsNullable = false
        Me.cboSupplierIdNo.ValueIsNumeric = false
        Me.cboSupplierIdNo.ValueMember = "IdNo"
        '
        'lblTransactionType
        '
        Me.lblTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTransactionType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransactionType.Location = New System.Drawing.Point(11, 62)
        Me.lblTransactionType.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTransactionType.Name = "lblTransactionType"
        Me.lblTransactionType.Size = New System.Drawing.Size(145, 23)
        Me.lblTransactionType.TabIndex = 267
        Me.lblTransactionType.Text = "Transaction Type:"
        Me.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTransactionType
        '
        Me.cboTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTransactionType.BackColor = System.Drawing.Color.White
        Me.cboTransactionType.ChangingSearchValueOnly = false
        Me.cboTransactionType.CurrentSearchTerm = ""
        Me.cboTransactionType.DefaultValue = "0"
        Me.cboTransactionType.DisplayMember = "Name"
        Me.cboTransactionType.DropDownHeight = 200
        Me.cboTransactionType.EditingMode = false
        Me.cboTransactionType.FilterRule = Nothing
        Me.cboTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboTransactionType.ForeColor = System.Drawing.Color.Black
        Me.cboTransactionType.HideWhenNotEditingOrAdding = false
        Me.cboTransactionType.LinkedLabel = Nothing
        Me.cboTransactionType.Location = New System.Drawing.Point(158, 62)
        Me.cboTransactionType.Margin = New System.Windows.Forms.Padding(1)
        Me.cboTransactionType.Name = "cboTransactionType"
        Me.cboTransactionType.OldValue = 0
        Me.cboTransactionType.OriginalDataSource = Nothing
        Me.cboTransactionType.OriginalList = Nothing
        Me.cboTransactionType.OverrideDropDownStyleList = false
        Me.cboTransactionType.PreviousSearchTerm = Nothing
        Me.cboTransactionType.PreviousSelectedIndex = 0
        Me.cboTransactionType.PropertySelector = Nothing
        Me.cboTransactionType.ReadOnlyCombo = false
        Me.cboTransactionType.SearchAnywhere = false
        Me.cboTransactionType.Size = New System.Drawing.Size(122, 24)
        Me.cboTransactionType.SuggestBoxHeight = 200
        Me.cboTransactionType.SuggestListOrderRule = Nothing
        Me.cboTransactionType.TabIndex = 4
        Me.cboTransactionType.TextToSearch = Nothing
        Me.cboTransactionType.ValueIsMandatory = false
        Me.cboTransactionType.ValueIsNullable = false
        Me.cboTransactionType.ValueIsNumeric = false
        Me.cboTransactionType.ValueMember = "Code"
        '
        'lblAmount
        '
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAmount.Location = New System.Drawing.Point(282, 62)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(96, 23)
        Me.lblAmount.TabIndex = 264
        Me.lblAmount.Text = "Amount:"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.ComputedValue = false
        Me.txtAmount.CustomFormat = Nothing
        Me.txtAmount.DataBoundControl = true
        Me.txtAmount.EditingMode = false
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.LinkedLabel = Me.lblAmount
        Me.txtAmount.Location = New System.Drawing.Point(380, 62)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OldValue = Nothing
        Me.txtAmount.Size = New System.Drawing.Size(90, 23)
        Me.txtAmount.TabIndex = 5
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmount.ValueIsMandatory = true
        Me.txtAmount.ValueIsNumeric = true
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblInvoiceDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInvoiceDate.Location = New System.Drawing.Point(472, 62)
        Me.lblInvoiceDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(141, 23)
        Me.lblInvoiceDate.TabIndex = 257
        Me.lblInvoiceDate.Text = "Supplier Doc. Date:"
        Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(614, 61)
        Me.dtpInvoiceDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.ReadOnlyDp = false
        Me.dtpInvoiceDate.SecurityKey = Nothing
        Me.dtpInvoiceDate.ShowLongDate = false
        Me.dtpInvoiceDate.ShowTime = false
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(123, 24)
        Me.dtpInvoiceDate.TabIndex = 6
        Me.dtpInvoiceDate.TargetCalendar = CType(resources.GetObject("dtpInvoiceDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpInvoiceDate.Value = Nothing
        Me.dtpInvoiceDate.ValueIsMandatory = false
        Me.dtpInvoiceDate.ValueIsNullable = false
        '
        'lblDueDate
        '
        Me.lblDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDueDate.Location = New System.Drawing.Point(11, 88)
        Me.lblDueDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Size = New System.Drawing.Size(145, 23)
        Me.lblDueDate.TabIndex = 259
        Me.lblDueDate.Text = "Due Date:"
        Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.dtpDueDate.Location = New System.Drawing.Point(157, 87)
        Me.dtpDueDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.ReadOnlyDp = false
        Me.dtpDueDate.SecurityKey = Nothing
        Me.dtpDueDate.ShowLongDate = false
        Me.dtpDueDate.ShowTime = false
        Me.dtpDueDate.Size = New System.Drawing.Size(123, 24)
        Me.dtpDueDate.TabIndex = 7
        Me.dtpDueDate.TargetCalendar = CType(resources.GetObject("dtpDueDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpDueDate.Value = Nothing
        Me.dtpDueDate.ValueIsMandatory = false
        Me.dtpDueDate.ValueIsNullable = false
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInvoiceNo.Location = New System.Drawing.Point(281, 88)
        Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(332, 23)
        Me.lblInvoiceNo.TabIndex = 254
        Me.lblInvoiceNo.Text = "Supplier Invoice/Reference No.:"
        Me.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.BackColor = System.Drawing.Color.White
        Me.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNo.ComputedValue = false
        Me.txtInvoiceNo.CustomFormat = Nothing
        Me.txtInvoiceNo.DataBoundControl = true
        Me.txtInvoiceNo.EditingMode = false
        Me.CFlowLayout3.SetFlowBreak(Me.txtInvoiceNo, true)
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtInvoiceNo.ForeColor = System.Drawing.Color.Black
        Me.txtInvoiceNo.LinkedLabel = Me.lblInvoiceNo
        Me.txtInvoiceNo.Location = New System.Drawing.Point(615, 88)
        Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.OldValue = Nothing
        Me.txtInvoiceNo.Size = New System.Drawing.Size(122, 23)
        Me.txtInvoiceNo.TabIndex = 8
        Me.txtInvoiceNo.ValueIsMandatory = true
        '
        'lblAccountIdNo
        '
        Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAccountIdNo.Location = New System.Drawing.Point(11, 113)
        Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAccountIdNo.Name = "lblAccountIdNo"
        Me.lblAccountIdNo.Size = New System.Drawing.Size(145, 24)
        Me.lblAccountIdNo.TabIndex = 266
        Me.lblAccountIdNo.Text = "Acct. to Credit:"
        Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.DefaultValue = ""
        Me.cboAccountIdNo.DisplayMember = "Name"
        Me.cboAccountIdNo.DropDownHeight = 200
        Me.cboAccountIdNo.EditingMode = false
        Me.cboAccountIdNo.FilterRule = Nothing
        Me.CFlowLayout3.SetFlowBreak(Me.cboAccountIdNo, true)
        Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
        Me.cboAccountIdNo.Location = New System.Drawing.Point(158, 113)
        Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
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
        Me.cboAccountIdNo.Size = New System.Drawing.Size(579, 24)
        Me.cboAccountIdNo.SuggestBoxHeight = 200
        Me.cboAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboAccountIdNo.TabIndex = 9
        Me.cboAccountIdNo.TextToSearch = Nothing
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        Me.cboAccountIdNo.ValueMember = "IdNo"
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(11, 139)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(145, 23)
        Me.lblNotes.TabIndex = 161
        Me.lblNotes.Text = "Description/Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.EditingMode = false
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(158, 139)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.Size = New System.Drawing.Size(579, 46)
        Me.txtNotes.TabIndex = 10
        Me.txtNotes.ValueIsMandatory = true
        '
        'CFlowLayout2
        '
        Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout2.Controls.Add(Me.lblVatNumber)
        Me.CFlowLayout2.Controls.Add(Me.txtVatNumber)
        Me.CFlowLayout2.Controls.Add(Me.lblVatAmount)
        Me.CFlowLayout2.Controls.Add(Me.txtVatAmount)
        Me.CFlowLayout2.Controls.Add(Me.CLabel2)
        Me.CFlowLayout2.Controls.Add(Me.CLabel1)
        Me.CFlowLayout2.Controls.Add(Me.dtpSettlementDueDate)
        Me.CFlowLayout2.Controls.Add(Me.CLabel5)
        Me.CFlowLayout2.Controls.Add(Me.txtSettlementDiscount)
        Me.CFlowLayout2.Controls.Add(Me.lblPercent)
        Me.CFlowLayout2.Controls.Add(Me.lblCancelled)
        Me.CFlowLayout2.Controls.Add(Me.chkCancelled)
        Me.CFlowLayout2.Controls.Add(Me.lblPosted)
        Me.CFlowLayout2.Controls.Add(Me.chkPosted)
        Me.CFlowLayout2.Controls.Add(Me.lblDateAdded)
        Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
        Me.CFlowLayout2.Location = New System.Drawing.Point(772, 3)
        Me.CFlowLayout2.Name = "CFlowLayout2"
        Me.CFlowLayout2.Size = New System.Drawing.Size(241, 184)
        Me.CFlowLayout2.TabIndex = 1
        '
        'lblVatNumber
        '
        Me.lblVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblVatNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVatNumber.Location = New System.Drawing.Point(1, 1)
        Me.lblVatNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVatNumber.Name = "lblVatNumber"
        Me.lblVatNumber.Size = New System.Drawing.Size(97, 23)
        Me.lblVatNumber.TabIndex = 0
        Me.lblVatNumber.Text = "Vat Number:"
        Me.lblVatNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVatNumber
        '
        Me.txtVatNumber.BackColor = System.Drawing.Color.White
        Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatNumber.ComputedValue = false
        Me.txtVatNumber.CustomFormat = Nothing
        Me.txtVatNumber.DataBoundControl = true
        Me.txtVatNumber.EditingMode = false
        Me.txtVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
        Me.txtVatNumber.LinkedLabel = Me.lblVatNumber
        Me.txtVatNumber.Location = New System.Drawing.Point(100, 1)
        Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtVatNumber.MaxLength = 15
        Me.txtVatNumber.Name = "txtVatNumber"
        Me.txtVatNumber.OldValue = Nothing
        Me.txtVatNumber.Size = New System.Drawing.Size(122, 23)
        Me.txtVatNumber.TabIndex = 1
        Me.txtVatNumber.ValueIsMandatory = true
        Me.txtVatNumber.ValueIsNumeric = true
        '
        'lblVatAmount
        '
        Me.lblVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblVatAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVatAmount.Location = New System.Drawing.Point(1, 26)
        Me.lblVatAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVatAmount.Name = "lblVatAmount"
        Me.lblVatAmount.Size = New System.Drawing.Size(97, 23)
        Me.lblVatAmount.TabIndex = 2
        Me.lblVatAmount.Text = "Vat Amount"
        Me.lblVatAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVatAmount
        '
        Me.txtVatAmount.BackColor = System.Drawing.Color.White
        Me.txtVatAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVatAmount.ComputedValue = false
        Me.txtVatAmount.CustomFormat = Nothing
        Me.txtVatAmount.DataBoundControl = true
        Me.txtVatAmount.DisplayOnly = true
        Me.txtVatAmount.EditingMode = true
        Me.txtVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
        Me.txtVatAmount.LinkedLabel = Me.lblVatAmount
        Me.txtVatAmount.Location = New System.Drawing.Point(100, 26)
        Me.txtVatAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtVatAmount.Name = "txtVatAmount"
        Me.txtVatAmount.OldValue = Nothing
        Me.txtVatAmount.ReadOnly = true
        Me.txtVatAmount.Size = New System.Drawing.Size(122, 20)
        Me.txtVatAmount.TabIndex = 2
        Me.txtVatAmount.ValueIsMandatory = true
        '
        'CLabel2
        '
        Me.CFlowLayout2.SetFlowBreak(Me.CLabel2, true)
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel2.Location = New System.Drawing.Point(1, 51)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(238, 23)
        Me.CLabel2.TabIndex = 279
        Me.CLabel2.Text = "Early Settlement Date/Rate:"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLabel1
        '
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel1.Location = New System.Drawing.Point(0, 75)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(17, 23)
        Me.CLabel1.TabIndex = 278
        Me.CLabel1.Text = " "
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.dtpSettlementDueDate.Location = New System.Drawing.Point(17, 75)
        Me.dtpSettlementDueDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpSettlementDueDate.Name = "dtpSettlementDueDate"
        Me.dtpSettlementDueDate.ReadOnlyDp = false
        Me.dtpSettlementDueDate.SecurityKey = Nothing
        Me.dtpSettlementDueDate.ShowLongDate = false
        Me.dtpSettlementDueDate.ShowTime = false
        Me.dtpSettlementDueDate.Size = New System.Drawing.Size(123, 24)
        Me.dtpSettlementDueDate.TabIndex = 3
        Me.dtpSettlementDueDate.TargetCalendar = CType(resources.GetObject("dtpSettlementDueDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpSettlementDueDate.Value = Nothing
        Me.dtpSettlementDueDate.ValueIsMandatory = false
        Me.dtpSettlementDueDate.ValueIsNullable = false
        '
        'CLabel5
        '
        Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel5.Location = New System.Drawing.Point(140, 75)
        Me.CLabel5.Margin = New System.Windows.Forms.Padding(0)
        Me.CLabel5.Name = "CLabel5"
        Me.CLabel5.Size = New System.Drawing.Size(23, 23)
        Me.CLabel5.TabIndex = 277
        Me.CLabel5.Text = " - "
        Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSettlementDiscount
        '
        Me.txtSettlementDiscount.BackColor = System.Drawing.Color.White
        Me.txtSettlementDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSettlementDiscount.ComputedValue = false
        Me.txtSettlementDiscount.CustomFormat = Nothing
        Me.txtSettlementDiscount.DataBoundControl = true
        Me.txtSettlementDiscount.EditingMode = false
        Me.txtSettlementDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtSettlementDiscount.ForeColor = System.Drawing.Color.Black
        Me.txtSettlementDiscount.LinkedLabel = Nothing
        Me.txtSettlementDiscount.Location = New System.Drawing.Point(164, 76)
        Me.txtSettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
        Me.txtSettlementDiscount.OldValue = Nothing
        Me.txtSettlementDiscount.Size = New System.Drawing.Size(44, 23)
        Me.txtSettlementDiscount.TabIndex = 4
        Me.txtSettlementDiscount.ValueIsMandatory = true
        '
        'lblPercent
        '
        Me.CFlowLayout2.SetFlowBreak(Me.lblPercent, true)
        Me.lblPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPercent.Location = New System.Drawing.Point(209, 75)
        Me.lblPercent.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(16, 23)
        Me.lblPercent.TabIndex = 269
        Me.lblPercent.Text = "%"
        Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkCancelled
        '
        Me.chkCancelled.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkCancelled.AutoCheck = false
        Me.chkCancelled.BackColor = System.Drawing.Color.White
        Me.chkCancelled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCancelled.DisplayOnly = true
        Me.chkCancelled.EditingMode = true
        Me.chkCancelled.Enabled = false
        Me.chkCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CFlowLayout2.SetFlowBreak(Me.chkCancelled, true)
        Me.chkCancelled.ForeColor = System.Drawing.Color.Black
        Me.chkCancelled.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkCancelled.LinkedLabel = Me.lblCancelled
        Me.chkCancelled.Location = New System.Drawing.Point(100, 101)
        Me.chkCancelled.Margin = New System.Windows.Forms.Padding(1)
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.Size = New System.Drawing.Size(23, 21)
        Me.chkCancelled.TabIndex = 5
        Me.chkCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCancelled.UseVisualStyleBackColor = false
        '
        'lblDateAdded
        '
        Me.lblDateAdded.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDateAdded.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDateAdded.Location = New System.Drawing.Point(1, 151)
        Me.lblDateAdded.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDateAdded.Name = "lblDateAdded"
        Me.lblDateAdded.Size = New System.Drawing.Size(69, 23)
        Me.lblDateAdded.TabIndex = 8
        Me.lblDateAdded.Text = "Date Added:"
        Me.lblDateAdded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.Color.White
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.ComputedValue = false
        Me.txtDateCreated.CustomFormat = Nothing
        Me.txtDateCreated.DataBoundControl = true
        Me.txtDateCreated.EditingMode = false
        Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.LinkedLabel = Me.lblInvoiceNo
        Me.txtDateCreated.Location = New System.Drawing.Point(72, 151)
        Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.Size = New System.Drawing.Size(150, 20)
        Me.txtDateCreated.TabIndex = 7
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'floFullEntryArea
        '
        Me.floFullEntryArea.BackColor = System.Drawing.Color.Transparent
        Me.floFullEntryArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floFullEntryArea.Controls.Add(Me.floApJournalHeader)
        Me.floFullEntryArea.Controls.Add(Me.floApJournalItems)
        Me.floFullEntryArea.Controls.Add(Me.CFlowLayout1)
        Me.floFullEntryArea.Location = New System.Drawing.Point(6, 12)
        Me.floFullEntryArea.Name = "floFullEntryArea"
        Me.floFullEntryArea.Size = New System.Drawing.Size(1028, 512)
        Me.floFullEntryArea.TabIndex = 0
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblTotals)
        Me.CFlowLayout1.Controls.Add(Me.txtTotalDebits)
        Me.CFlowLayout1.Controls.Add(Me.txtTotalCredits)
        Me.CFlowLayout1.Location = New System.Drawing.Point(3, 482)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(1013, 30)
        Me.CFlowLayout1.TabIndex = 0
        '
        'ApJournalEntry
        '
        Me.ClientSize = New System.Drawing.Size(1043, 607)
        Me.Controls.Add(Me.floFullEntryArea)
        Me.MinimumSize = New System.Drawing.Size(1059, 646)
        Me.Name = "ApJournalEntry"
        Me.SecurityPresenterObj = SecurityPresenter1
        Me.Text = "Ap Journal Entry"
        Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
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
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents txtTotalCredits As CTextBox
        Friend WithEvents txtTotalDebits As CTextBox
        Friend WithEvents floApJournalItems As CFlowLayout
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents floApJournalHeader As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents txtJournalCode As CTextBox
        Friend WithEvents TxtIDNo As CTextBox
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblTotals As CLabel
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
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents lblDateAdded As CLabel
        Friend WithEvents txtDateCreated As CTextBox
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents chkCancelled As CCheckBox
        Friend WithEvents lblPercent As CLabel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboSupplierIdNo As CaComboBox
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents lblVatNumber As CLabel
        Friend WithEvents txtVatNumber As CTextBox
        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents CFlowLayout2 As CFlowLayout
        Friend WithEvents lblVatAmount As CLabel
        Friend WithEvents txtVatAmount As CTextBox
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblTransactionType As CLabel
        Friend WithEvents cboTransactionType As CaComboBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents BalanceDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvColumnMoney
        Friend WithEvents dgvCredit As CdgvColumnMoney
        Friend WithEvents dgvProfitCenterIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvNotes As CdgvColumnText
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents JournalIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OriginalAmountDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PayeeTypeDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvPaidAmount As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvDiscountTaken As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ItemVatAmount As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNo As Windows.Forms.DataGridViewTextBoxColumn
    End Class
End NameSpace