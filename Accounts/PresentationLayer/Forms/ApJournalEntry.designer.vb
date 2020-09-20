Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
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
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApJournalEntry))
            Me.floApJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CancelledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.JournalIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OriginalAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayeeTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvPaidAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvDiscountTaken = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ItemVatAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OpenInvoiceIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.lblCancelled = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.floApJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
            Me.dtpSettlementDueDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtSettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPercent = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpDateCreated = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.floFullEntryArea = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
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
            Me.floApJournalItems.Location = New System.Drawing.Point(3, 226)
            Me.floApJournalItems.Name = "floApJournalItems"
            Me.floApJournalItems.Size = New System.Drawing.Size(1034, 284)
            Me.floApJournalItems.TabIndex = 1
            '
            'DataGridViewJournalItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewJournalItems.AutoGenerateColumns = False
            Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.dgvIdNo, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PayeeTypeDataGridViewTextBoxColumn, Me.dgvPaidAmount, Me.dgvDiscountTaken, Me.ItemVatAmount, Me.OpenInvoiceIdNo})
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
            Me.DataGridViewJournalItems.Dock = System.Windows.Forms.DockStyle.Left
            Me.DataGridViewJournalItems.Ea = EventAggregator1
            Me.DataGridViewJournalItems.EditingMode = False
            Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewJournalItems.FirstRowDeletionEnabled = False
            Me.DataGridViewJournalItems.FirstRowInsertionEnabled = False
            Me.DataGridViewJournalItems.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
            Me.DataGridViewJournalItems.ReadOnly = True
            Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = True
            Me.DataGridViewJournalItems.Size = New System.Drawing.Size(1023, 275)
            Me.DataGridViewJournalItems.StartTrackingChanges = False
            Me.DataGridViewJournalItems.TabIndex = 0
            '
            'dgvSequence
            '
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.HeaderText = "Seq."
            Me.dgvSequence.MinimumWidth = 50
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.Width = 50
            '
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            Me.dgvAccountIdNo.HeaderText = "Account Code-Name"
            Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
            Me.dgvAccountIdNo.ReadOnly = True
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
            Me.dgvDebit.EditingMode = False
            Me.dgvDebit.FillWeight = 90.0!
            Me.dgvDebit.HeaderText = "Debit"
            Me.dgvDebit.Name = "dgvDebit"
            Me.dgvDebit.ReadOnly = True
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
            Me.dgvCredit.EditingMode = False
            Me.dgvCredit.HeaderText = "Credit"
            Me.dgvCredit.Name = "dgvCredit"
            Me.dgvCredit.ReadOnly = True
            Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvCredit.Width = 90
            '
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.HeaderText = "Revenue/Cost Center Code-Name"
            Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.ReadOnly = True
            Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvRevCostCenterIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvRevCostCenterIdNo.Width = 200
            '
            'dgvNotes
            '
            Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvNotes.DataPropertyName = "Notes"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvNotes.EditingMode = False
            Me.dgvNotes.HeaderText = "Notes"
            Me.dgvNotes.Name = "dgvNotes"
            Me.dgvNotes.ReadOnly = True
            Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvIdNo
            '
            Me.dgvIdNo.DataPropertyName = "IdNo"
            Me.dgvIdNo.HeaderText = "IdNo"
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Visible = False
            '
            'AccountNameDataGridViewTextBoxColumn
            '
            Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
            Me.AccountNameDataGridViewTextBoxColumn.HeaderText = "AccountName"
            Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
            Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = True
            Me.AccountNameDataGridViewTextBoxColumn.Visible = False
            '
            'CancelledDataGridViewCheckBoxColumn
            '
            Me.CancelledDataGridViewCheckBoxColumn.DataPropertyName = "Cancelled"
            Me.CancelledDataGridViewCheckBoxColumn.HeaderText = "Cancelled"
            Me.CancelledDataGridViewCheckBoxColumn.Name = "CancelledDataGridViewCheckBoxColumn"
            Me.CancelledDataGridViewCheckBoxColumn.ReadOnly = True
            Me.CancelledDataGridViewCheckBoxColumn.Visible = False
            '
            'JournalIdNoDataGridViewTextBoxColumn
            '
            Me.JournalIdNoDataGridViewTextBoxColumn.DataPropertyName = "JournalIdNo"
            Me.JournalIdNoDataGridViewTextBoxColumn.HeaderText = "JournalIdNo"
            Me.JournalIdNoDataGridViewTextBoxColumn.Name = "JournalIdNoDataGridViewTextBoxColumn"
            Me.JournalIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.JournalIdNoDataGridViewTextBoxColumn.Visible = False
            '
            'OriginalAmountDataGridViewTextBoxColumn
            '
            Me.OriginalAmountDataGridViewTextBoxColumn.DataPropertyName = "OriginalAmount"
            Me.OriginalAmountDataGridViewTextBoxColumn.HeaderText = "OriginalAmount"
            Me.OriginalAmountDataGridViewTextBoxColumn.Name = "OriginalAmountDataGridViewTextBoxColumn"
            Me.OriginalAmountDataGridViewTextBoxColumn.ReadOnly = True
            Me.OriginalAmountDataGridViewTextBoxColumn.Visible = False
            '
            'PayeeTypeDataGridViewTextBoxColumn
            '
            Me.PayeeTypeDataGridViewTextBoxColumn.DataPropertyName = "PayeeType"
            Me.PayeeTypeDataGridViewTextBoxColumn.HeaderText = "PayeeType"
            Me.PayeeTypeDataGridViewTextBoxColumn.Name = "PayeeTypeDataGridViewTextBoxColumn"
            Me.PayeeTypeDataGridViewTextBoxColumn.ReadOnly = True
            Me.PayeeTypeDataGridViewTextBoxColumn.Visible = False
            '
            'dgvPaidAmount
            '
            Me.dgvPaidAmount.DataPropertyName = "PaidAmount"
            Me.dgvPaidAmount.HeaderText = "PaidAmount"
            Me.dgvPaidAmount.Name = "dgvPaidAmount"
            Me.dgvPaidAmount.ReadOnly = True
            Me.dgvPaidAmount.Visible = False
            '
            'dgvDiscountTaken
            '
            Me.dgvDiscountTaken.DataPropertyName = "DiscountTaken"
            Me.dgvDiscountTaken.HeaderText = "DiscountTaken"
            Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
            Me.dgvDiscountTaken.ReadOnly = True
            Me.dgvDiscountTaken.Visible = False
            '
            'ItemVatAmount
            '
            Me.ItemVatAmount.HeaderText = "ItemVatAmount"
            Me.ItemVatAmount.Name = "ItemVatAmount"
            Me.ItemVatAmount.ReadOnly = True
            Me.ItemVatAmount.Visible = False
            '
            'OpenInvoiceIdNo
            '
            Me.OpenInvoiceIdNo.DataPropertyName = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNo.HeaderText = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNo.Name = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNo.ReadOnly = True
            Me.OpenInvoiceIdNo.Visible = False
            '
            'bsJournalItems
            '
            Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
            '
            'lblCancelled
            '
            Me.lblCancelled.DisplayOnly = True
            Me.lblCancelled.EditingMode = False
            Me.lblCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCancelled.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCancelled.Location = New System.Drawing.Point(16, 116)
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
            Me.chkPosted.AutoCheck = False
            Me.chkPosted.BackColor = System.Drawing.Color.White
            Me.chkPosted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkPosted.DisplayOnly = True
            Me.chkPosted.EditingMode = True
            Me.chkPosted.Enabled = False
            Me.chkPosted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout2.SetFlowBreak(Me.chkPosted, True)
            Me.chkPosted.ForeColor = System.Drawing.Color.Black
            Me.chkPosted.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkPosted.LinkedLabel = Me.lblPosted
            Me.chkPosted.Location = New System.Drawing.Point(115, 141)
            Me.chkPosted.Margin = New System.Windows.Forms.Padding(1)
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.OldValue = Nothing
            Me.chkPosted.Size = New System.Drawing.Size(23, 21)
            Me.chkPosted.TabIndex = 6
            Me.chkPosted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkPosted.UseVisualStyleBackColor = False
            '
            'lblPosted
            '
            Me.lblPosted.DisplayOnly = True
            Me.lblPosted.EditingMode = False
            Me.lblPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPosted.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPosted.Location = New System.Drawing.Point(16, 141)
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
            Me.floFullEntryArea.SetFlowBreak(Me.floApJournalHeader, True)
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
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(16, 16)
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
            Me.txtJournalCode.ComputedValue = True
            Me.txtJournalCode.CustomFormat = Nothing
            Me.txtJournalCode.DataBoundControl = True
            Me.txtJournalCode.DisplayOnly = True
            Me.txtJournalCode.EditingMode = True
            Me.txtJournalCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
            Me.txtJournalCode.LinkedLabel = Nothing
            Me.txtJournalCode.Location = New System.Drawing.Point(163, 16)
            Me.txtJournalCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtJournalCode.MaximumValue = Nothing
            Me.txtJournalCode.MinimumValue = Nothing
            Me.txtJournalCode.Name = "txtJournalCode"
            Me.txtJournalCode.OldValue = Nothing
            Me.txtJournalCode.ReadOnly = True
            Me.txtJournalCode.Size = New System.Drawing.Size(25, 23)
            Me.txtJournalCode.TabIndex = 163
            Me.txtJournalCode.TabStop = False
            Me.txtJournalCode.Text = "AP"
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
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(190, 16)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.Size = New System.Drawing.Size(63, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblReferenceNo
            '
            Me.lblReferenceNo.DisplayOnly = True
            Me.lblReferenceNo.EditingMode = False
            Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReferenceNo.Location = New System.Drawing.Point(255, 16)
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
            Me.txtReferenceNo.ComputedValue = False
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            Me.txtReferenceNo.EditingMode = False
            Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
            Me.txtReferenceNo.Location = New System.Drawing.Point(385, 16)
            Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.ReadOnly = True
            Me.txtReferenceNo.Size = New System.Drawing.Size(90, 23)
            Me.txtReferenceNo.TabIndex = 1
            Me.txtReferenceNo.ValueIsMandatory = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionDate.Location = New System.Drawing.Point(477, 16)
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
            Me.dtpTransactionDate.DisplayOnly = False
            Me.dtpTransactionDate.DtpDefaultValue = Nothing
            Me.dtpTransactionDate.EditingMode = False
            Me.dtpTransactionDate.EditsAllowed = False
            Me.CFlowLayout3.SetFlowBreak(Me.dtpTransactionDate, True)
            Me.dtpTransactionDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Location = New System.Drawing.Point(619, 15)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(123, 24)
            Me.dtpTransactionDate.TabIndex = 2
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'lblSupplierIdNo
            '
            Me.lblSupplierIdNo.DisplayOnly = True
            Me.lblSupplierIdNo.EditingMode = False
            Me.lblSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSupplierIdNo.Location = New System.Drawing.Point(16, 41)
            Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            Me.lblSupplierIdNo.Size = New System.Drawing.Size(145, 23)
            Me.lblSupplierIdNo.TabIndex = 254
            Me.lblSupplierIdNo.Text = "Supplier Code/Name"
            Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboSupplierIdNo
            '
            Me.cboSupplierIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboSupplierIdNo.BackColor = System.Drawing.Color.White
            Me.cboSupplierIdNo.ChangingSearchValueOnly = False
            Me.cboSupplierIdNo.CurrentSearchTerm = ""
            Me.cboSupplierIdNo.DefaultValue = Nothing
            Me.cboSupplierIdNo.DisplayMember = "Name"
            Me.cboSupplierIdNo.DropDownHeight = 1
            Me.cboSupplierIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSupplierIdNo.EditingMode = False
            Me.cboSupplierIdNo.FilterRule = Nothing
            Me.cboSupplierIdNo.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.CFlowLayout3.SetFlowBreak(Me.cboSupplierIdNo, True)
            Me.cboSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboSupplierIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboSupplierIdNo.FormattingEnabled = True
            Me.cboSupplierIdNo.HideWhenNotEditingOrAdding = False
            Me.cboSupplierIdNo.IntegralHeight = False
            Me.cboSupplierIdNo.LinkedLabel = Nothing
            Me.cboSupplierIdNo.Location = New System.Drawing.Point(163, 41)
            Me.cboSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboSupplierIdNo.Name = "cboSupplierIdNo"
            Me.cboSupplierIdNo.OldValue = 0
            Me.cboSupplierIdNo.OriginalDataSource = Nothing
            Me.cboSupplierIdNo.OriginalList = Nothing
            Me.cboSupplierIdNo.OverrideDropDownStyleList = False
            Me.cboSupplierIdNo.PreviousSearchTerm = Nothing
            Me.cboSupplierIdNo.PreviousSelectedIndex = -1
            Me.cboSupplierIdNo.PropertySelector = Nothing
            Me.cboSupplierIdNo.ReadOnlyCombo = False
            Me.cboSupplierIdNo.SearchAnywhere = False
            Me.cboSupplierIdNo.Size = New System.Drawing.Size(579, 24)
            Me.cboSupplierIdNo.SuggestBoxHeight = 200
            Me.cboSupplierIdNo.SuggestListOrderRule = Nothing
            Me.cboSupplierIdNo.TabIndex = 3
            Me.cboSupplierIdNo.TextToSearch = Nothing
            Me.cboSupplierIdNo.ValueIsMandatory = False
            Me.cboSupplierIdNo.ValueIsNullable = False
            Me.cboSupplierIdNo.ValueIsNumeric = False
            Me.cboSupplierIdNo.ValueMember = "IdNo"
            '
            'lblTransactionType
            '
            Me.lblTransactionType.DisplayOnly = True
            Me.lblTransactionType.EditingMode = False
            Me.lblTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionType.Location = New System.Drawing.Point(16, 67)
            Me.lblTransactionType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionType.Name = "lblTransactionType"
            Me.lblTransactionType.Size = New System.Drawing.Size(145, 23)
            Me.lblTransactionType.TabIndex = 267
            Me.lblTransactionType.Text = "Transaction Type:"
            Me.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboTransactionType
            '
            Me.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboTransactionType.BackColor = System.Drawing.Color.White
            Me.cboTransactionType.ChangingSearchValueOnly = False
            Me.cboTransactionType.CurrentSearchTerm = ""
            Me.cboTransactionType.DefaultValue = "0"
            Me.cboTransactionType.DisplayMember = "Name"
            Me.cboTransactionType.DropDownHeight = 1
            Me.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTransactionType.EditingMode = False
            Me.cboTransactionType.FilterRule = Nothing
            Me.cboTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboTransactionType.ForeColor = System.Drawing.Color.Black
            Me.cboTransactionType.HideWhenNotEditingOrAdding = False
            Me.cboTransactionType.IntegralHeight = False
            Me.cboTransactionType.LinkedLabel = Nothing
            Me.cboTransactionType.Location = New System.Drawing.Point(163, 67)
            Me.cboTransactionType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboTransactionType.Name = "cboTransactionType"
            Me.cboTransactionType.OldValue = 0
            Me.cboTransactionType.OriginalDataSource = Nothing
            Me.cboTransactionType.OriginalList = Nothing
            Me.cboTransactionType.OverrideDropDownStyleList = False
            Me.cboTransactionType.PreviousSearchTerm = Nothing
            Me.cboTransactionType.PreviousSelectedIndex = 0
            Me.cboTransactionType.PropertySelector = Nothing
            Me.cboTransactionType.ReadOnlyCombo = False
            Me.cboTransactionType.SearchAnywhere = False
            Me.cboTransactionType.Size = New System.Drawing.Size(122, 24)
            Me.cboTransactionType.SuggestBoxHeight = 200
            Me.cboTransactionType.SuggestListOrderRule = Nothing
            Me.cboTransactionType.TabIndex = 4
            Me.cboTransactionType.TextToSearch = Nothing
            Me.cboTransactionType.ValueIsMandatory = False
            Me.cboTransactionType.ValueIsNullable = False
            Me.cboTransactionType.ValueIsNumeric = False
            Me.cboTransactionType.ValueMember = "Code"
            '
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(287, 67)
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
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = Nothing
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = False
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.Location = New System.Drawing.Point(385, 67)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.Size = New System.Drawing.Size(90, 23)
            Me.txtAmount.TabIndex = 5
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblInvoiceDate
            '
            Me.lblInvoiceDate.DisplayOnly = True
            Me.lblInvoiceDate.EditingMode = False
            Me.lblInvoiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceDate.Location = New System.Drawing.Point(477, 67)
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
            Me.dtpInvoiceDate.DisplayOnly = False
            Me.dtpInvoiceDate.DtpDefaultValue = Nothing
            Me.dtpInvoiceDate.EditingMode = False
            Me.dtpInvoiceDate.EditsAllowed = False
            Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.dtpInvoiceDate.LinkedLabel = Nothing
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(619, 66)
            Me.dtpInvoiceDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
            Me.dtpInvoiceDate.ReadOnlyDp = False
            Me.dtpInvoiceDate.SecurityKey = Nothing
            Me.dtpInvoiceDate.ShowLongDate = False
            Me.dtpInvoiceDate.ShowTime = False
            Me.dtpInvoiceDate.Size = New System.Drawing.Size(123, 24)
            Me.dtpInvoiceDate.TabIndex = 6
            Me.dtpInvoiceDate.TargetCalendar = CType(resources.GetObject("dtpInvoiceDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpInvoiceDate.Value = Nothing
            Me.dtpInvoiceDate.ValueIsMandatory = False
            Me.dtpInvoiceDate.ValueIsNullable = False
            '
            'lblDueDate
            '
            Me.lblDueDate.DisplayOnly = True
            Me.lblDueDate.EditingMode = False
            Me.lblDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDueDate.Location = New System.Drawing.Point(16, 93)
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
            Me.dtpDueDate.DisplayOnly = False
            Me.dtpDueDate.DtpDefaultValue = Nothing
            Me.dtpDueDate.EditingMode = False
            Me.dtpDueDate.EditsAllowed = False
            Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpDueDate.ForeColor = System.Drawing.Color.Black
            Me.dtpDueDate.LinkedLabel = Nothing
            Me.dtpDueDate.Location = New System.Drawing.Point(162, 92)
            Me.dtpDueDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.ReadOnlyDp = False
            Me.dtpDueDate.SecurityKey = Nothing
            Me.dtpDueDate.ShowLongDate = False
            Me.dtpDueDate.ShowTime = False
            Me.dtpDueDate.Size = New System.Drawing.Size(123, 24)
            Me.dtpDueDate.TabIndex = 7
            Me.dtpDueDate.TargetCalendar = CType(resources.GetObject("dtpDueDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpDueDate.Value = Nothing
            Me.dtpDueDate.ValueIsMandatory = False
            Me.dtpDueDate.ValueIsNullable = False
            '
            'lblInvoiceNo
            '
            Me.lblInvoiceNo.DisplayOnly = True
            Me.lblInvoiceNo.EditingMode = False
            Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceNo.Location = New System.Drawing.Point(286, 93)
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
            Me.txtInvoiceNo.ComputedValue = False
            Me.txtInvoiceNo.CustomFormat = Nothing
            Me.txtInvoiceNo.DataBoundControl = True
            Me.txtInvoiceNo.EditingMode = False
            Me.CFlowLayout3.SetFlowBreak(Me.txtInvoiceNo, True)
            Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtInvoiceNo.ForeColor = System.Drawing.Color.Black
            Me.txtInvoiceNo.LinkedLabel = Me.lblInvoiceNo
            Me.txtInvoiceNo.Location = New System.Drawing.Point(620, 93)
            Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtInvoiceNo.MaximumValue = Nothing
            Me.txtInvoiceNo.MinimumValue = Nothing
            Me.txtInvoiceNo.Name = "txtInvoiceNo"
            Me.txtInvoiceNo.OldValue = Nothing
            Me.txtInvoiceNo.ReadOnly = True
            Me.txtInvoiceNo.Size = New System.Drawing.Size(122, 23)
            Me.txtInvoiceNo.TabIndex = 8
            Me.txtInvoiceNo.ValueIsMandatory = True
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAccountIdNo.Location = New System.Drawing.Point(16, 118)
            Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Size = New System.Drawing.Size(145, 24)
            Me.lblAccountIdNo.TabIndex = 266
            Me.lblAccountIdNo.Text = "Acct. to Credit:"
            Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = ""
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.DropDownHeight = 1
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.CFlowLayout3.SetFlowBreak(Me.cboAccountIdNo, True)
            Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IntegralHeight = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
            Me.cboAccountIdNo.Location = New System.Drawing.Point(163, 118)
            Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
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
            Me.cboAccountIdNo.Size = New System.Drawing.Size(579, 24)
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TabIndex = 9
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
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(16, 144)
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
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(163, 144)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.Size = New System.Drawing.Size(579, 46)
            Me.txtNotes.TabIndex = 10
            Me.txtNotes.ValueIsMandatory = True
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.lblVatNumber)
            Me.CFlowLayout2.Controls.Add(Me.txtVatNumber)
            Me.CFlowLayout2.Controls.Add(Me.lblVatAmount)
            Me.CFlowLayout2.Controls.Add(Me.txtVatAmount)
            Me.CFlowLayout2.Controls.Add(Me.CLabel2)
            Me.CFlowLayout2.Controls.Add(Me.dtpSettlementDueDate)
            Me.CFlowLayout2.Controls.Add(Me.CLabel5)
            Me.CFlowLayout2.Controls.Add(Me.txtSettlementDiscount)
            Me.CFlowLayout2.Controls.Add(Me.lblPercent)
            Me.CFlowLayout2.Controls.Add(Me.lblCancelled)
            Me.CFlowLayout2.Controls.Add(Me.chkCancelled)
            Me.CFlowLayout2.Controls.Add(Me.lblPosted)
            Me.CFlowLayout2.Controls.Add(Me.chkPosted)
            Me.CFlowLayout2.Controls.Add(Me.lblDateAdded)
            Me.CFlowLayout2.Controls.Add(Me.dtpDateCreated)
            Me.CFlowLayout2.Location = New System.Drawing.Point(767, 3)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Padding = New System.Windows.Forms.Padding(15)
            Me.CFlowLayout2.Size = New System.Drawing.Size(259, 204)
            Me.CFlowLayout2.TabIndex = 1
            '
            'lblVatNumber
            '
            Me.lblVatNumber.DisplayOnly = True
            Me.lblVatNumber.EditingMode = False
            Me.lblVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatNumber.Location = New System.Drawing.Point(16, 16)
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
            Me.txtVatNumber.ComputedValue = False
            Me.txtVatNumber.CustomFormat = Nothing
            Me.txtVatNumber.DataBoundControl = True
            Me.txtVatNumber.EditingMode = False
            Me.txtVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
            Me.txtVatNumber.LinkedLabel = Me.lblVatNumber
            Me.txtVatNumber.Location = New System.Drawing.Point(115, 16)
            Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MaxLength = 15
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.Size = New System.Drawing.Size(122, 23)
            Me.txtVatNumber.TabIndex = 1
            Me.txtVatNumber.ValueIsMandatory = True
            Me.txtVatNumber.ValueIsNumeric = True
            '
            'lblVatAmount
            '
            Me.lblVatAmount.DisplayOnly = True
            Me.lblVatAmount.EditingMode = False
            Me.lblVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatAmount.Location = New System.Drawing.Point(16, 41)
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
            Me.txtVatAmount.ComputedValue = False
            Me.txtVatAmount.CustomFormat = Nothing
            Me.txtVatAmount.DataBoundControl = True
            Me.txtVatAmount.DisplayOnly = True
            Me.txtVatAmount.EditingMode = True
            Me.txtVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
            Me.txtVatAmount.LinkedLabel = Me.lblVatAmount
            Me.txtVatAmount.Location = New System.Drawing.Point(115, 41)
            Me.txtVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatAmount.MaximumValue = Nothing
            Me.txtVatAmount.MinimumValue = Nothing
            Me.txtVatAmount.Name = "txtVatAmount"
            Me.txtVatAmount.OldValue = Nothing
            Me.txtVatAmount.ReadOnly = True
            Me.txtVatAmount.Size = New System.Drawing.Size(122, 20)
            Me.txtVatAmount.TabIndex = 2
            Me.txtVatAmount.ValueIsMandatory = True
            Me.txtVatAmount.ValueIsNumeric = True
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CFlowLayout2.SetFlowBreak(Me.CLabel2, True)
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel2.Location = New System.Drawing.Point(16, 66)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(207, 23)
            Me.CLabel2.TabIndex = 279
            Me.CLabel2.Text = "Early Settlement Date/Rate:"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'dtpSettlementDueDate
            '
            Me.dtpSettlementDueDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpSettlementDueDate.DefaultValue = Nothing
            Me.dtpSettlementDueDate.DisplayOnly = False
            Me.dtpSettlementDueDate.DtpDefaultValue = Nothing
            Me.dtpSettlementDueDate.EditingMode = False
            Me.dtpSettlementDueDate.EditsAllowed = False
            Me.dtpSettlementDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpSettlementDueDate.ForeColor = System.Drawing.Color.Black
            Me.dtpSettlementDueDate.LinkedLabel = Nothing
            Me.dtpSettlementDueDate.Location = New System.Drawing.Point(15, 90)
            Me.dtpSettlementDueDate.Margin = New System.Windows.Forms.Padding(0)
            Me.dtpSettlementDueDate.Name = "dtpSettlementDueDate"
            Me.dtpSettlementDueDate.ReadOnlyDp = False
            Me.dtpSettlementDueDate.SecurityKey = Nothing
            Me.dtpSettlementDueDate.ShowLongDate = False
            Me.dtpSettlementDueDate.ShowTime = False
            Me.dtpSettlementDueDate.Size = New System.Drawing.Size(123, 24)
            Me.dtpSettlementDueDate.TabIndex = 3
            Me.dtpSettlementDueDate.TargetCalendar = CType(resources.GetObject("dtpSettlementDueDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpSettlementDueDate.Value = Nothing
            Me.dtpSettlementDueDate.ValueIsMandatory = False
            Me.dtpSettlementDueDate.ValueIsNullable = False
            '
            'CLabel5
            '
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel5.Location = New System.Drawing.Point(138, 90)
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
            Me.txtSettlementDiscount.ComputedValue = False
            Me.txtSettlementDiscount.CustomFormat = Nothing
            Me.txtSettlementDiscount.DataBoundControl = True
            Me.txtSettlementDiscount.EditingMode = False
            Me.txtSettlementDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSettlementDiscount.ForeColor = System.Drawing.Color.Black
            Me.txtSettlementDiscount.LinkedLabel = Nothing
            Me.txtSettlementDiscount.Location = New System.Drawing.Point(162, 91)
            Me.txtSettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSettlementDiscount.MaximumValue = Nothing
            Me.txtSettlementDiscount.MinimumValue = Nothing
            Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
            Me.txtSettlementDiscount.OldValue = Nothing
            Me.txtSettlementDiscount.ReadOnly = True
            Me.txtSettlementDiscount.Size = New System.Drawing.Size(44, 23)
            Me.txtSettlementDiscount.TabIndex = 4
            Me.txtSettlementDiscount.ValueIsMandatory = True
            '
            'lblPercent
            '
            Me.lblPercent.DisplayOnly = True
            Me.lblPercent.EditingMode = False
            Me.CFlowLayout2.SetFlowBreak(Me.lblPercent, True)
            Me.lblPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPercent.Location = New System.Drawing.Point(207, 90)
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
            Me.chkCancelled.AutoCheck = False
            Me.chkCancelled.BackColor = System.Drawing.Color.White
            Me.chkCancelled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkCancelled.DisplayOnly = True
            Me.chkCancelled.EditingMode = True
            Me.chkCancelled.Enabled = False
            Me.chkCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout2.SetFlowBreak(Me.chkCancelled, True)
            Me.chkCancelled.ForeColor = System.Drawing.Color.Black
            Me.chkCancelled.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCancelled.LinkedLabel = Me.lblCancelled
            Me.chkCancelled.Location = New System.Drawing.Point(115, 116)
            Me.chkCancelled.Margin = New System.Windows.Forms.Padding(1)
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.OldValue = Nothing
            Me.chkCancelled.Size = New System.Drawing.Size(23, 21)
            Me.chkCancelled.TabIndex = 5
            Me.chkCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkCancelled.UseVisualStyleBackColor = False
            '
            'lblDateAdded
            '
            Me.lblDateAdded.DisplayOnly = True
            Me.lblDateAdded.EditingMode = False
            Me.lblDateAdded.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateAdded.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateAdded.Location = New System.Drawing.Point(15, 165)
            Me.lblDateAdded.Margin = New System.Windows.Forms.Padding(0)
            Me.lblDateAdded.Name = "lblDateAdded"
            Me.lblDateAdded.Size = New System.Drawing.Size(46, 38)
            Me.lblDateAdded.TabIndex = 8
            Me.lblDateAdded.Text = "Date Added:"
            Me.lblDateAdded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.dtpDateCreated.Location = New System.Drawing.Point(62, 166)
            Me.dtpDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpDateCreated.Name = "dtpDateCreated"
            Me.dtpDateCreated.ReadOnlyDp = True
            Me.dtpDateCreated.SecurityKey = Nothing
            Me.dtpDateCreated.ShowLongDate = False
            Me.dtpDateCreated.ShowTime = True
            Me.dtpDateCreated.Size = New System.Drawing.Size(177, 25)
            Me.dtpDateCreated.TabIndex = 285
            Me.dtpDateCreated.TargetCalendar = Nothing
            Me.dtpDateCreated.Value = Nothing
            Me.dtpDateCreated.ValueIsMandatory = False
            Me.dtpDateCreated.ValueIsNullable = False
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
            'ApJournalEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1047, 586)
            Me.Controls.Add(Me.floFullEntryArea)
            Me.MinimumSize = New System.Drawing.Size(1059, 580)
            Me.Name = "ApJournalEntry"
            Me.Text = "Accounts Payable Journal Entry"
            Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
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
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents chkPosted As CCheckBox
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
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents lblDateAdded As CLabel
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
        Friend WithEvents BalanceDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvColumnMoney
        Friend WithEvents dgvCredit As CdgvColumnMoney
        Friend WithEvents dgvRevCostCenterIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvNotes As CdgvColumnText
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
        Friend WithEvents dtpDateCreated As CCustomDateTimePicker
    End Class
End NameSpace