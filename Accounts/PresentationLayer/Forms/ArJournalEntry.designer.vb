Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ArJournalEntry
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArJournalEntry))
            Me.floArJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
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
            Me.lblCancelled = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.floArJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblCustomerIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboCustomerIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblTransactionType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboTransactionType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDueDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpDueDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
            Me.floArJournalItems.SuspendLayout()
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floArJournalHeader.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            Me.CFlowLayout2.SuspendLayout()
            Me.floFullEntryArea.SuspendLayout()
            Me.SuspendLayout()
            '
            'floArJournalItems
            '
            Me.floArJournalItems.BackColor = System.Drawing.Color.Transparent
            Me.floArJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floArJournalItems.Controls.Add(Me.DataGridViewJournalItems)
            Me.floFullEntryArea.SetFlowBreak(Me.floArJournalItems, True)
            Me.floArJournalItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
            Me.floArJournalItems.Location = New System.Drawing.Point(3, 212)
            Me.floArJournalItems.Name = "floArJournalItems"
            Me.floArJournalItems.Size = New System.Drawing.Size(1026, 300)
            Me.floArJournalItems.TabIndex = 1
            '
            'DataGridViewJournalItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewJournalItems.AutoGenerateColumns = False
            Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.dgvPaidAmount, Me.dgvDiscountTaken, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn, Me.dgvIdNo, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OpenInvoiceIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PayeeTypeDataGridViewTextBoxColumn, Me.SpecialAccountDataGridViewTextBoxColumn})
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
            Me.DataGridViewJournalItems.Size = New System.Drawing.Size(1015, 280)
            Me.DataGridViewJournalItems.StartTrackingChanges = False
            Me.DataGridViewJournalItems.TabIndex = 0
            '
            'dgvSequence
            '
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.HeaderText = "Seq."
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.Width = 40
            '
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            Me.dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
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
            '
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = True
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
            'dgvIdNo
            '
            Me.dgvIdNo.DataPropertyName = "IdNo"
            Me.dgvIdNo.HeaderText = "IdNo"
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Visible = False
            '
            'JournalIdNoDataGridViewTextBoxColumn
            '
            Me.JournalIdNoDataGridViewTextBoxColumn.DataPropertyName = "JournalIdNo"
            Me.JournalIdNoDataGridViewTextBoxColumn.HeaderText = "JournalIdNo"
            Me.JournalIdNoDataGridViewTextBoxColumn.Name = "JournalIdNoDataGridViewTextBoxColumn"
            Me.JournalIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.JournalIdNoDataGridViewTextBoxColumn.Visible = False
            '
            'OpenInvoiceIdNoDataGridViewTextBoxColumn
            '
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.DataPropertyName = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.HeaderText = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.Name = "OpenInvoiceIdNoDataGridViewTextBoxColumn"
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.Visible = False
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
            'SpecialAccountDataGridViewTextBoxColumn
            '
            Me.SpecialAccountDataGridViewTextBoxColumn.DataPropertyName = "SpecialAccount"
            Me.SpecialAccountDataGridViewTextBoxColumn.HeaderText = "SpecialAccount"
            Me.SpecialAccountDataGridViewTextBoxColumn.Name = "SpecialAccountDataGridViewTextBoxColumn"
            Me.SpecialAccountDataGridViewTextBoxColumn.ReadOnly = True
            Me.SpecialAccountDataGridViewTextBoxColumn.Visible = False
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
            Me.lblCancelled.Location = New System.Drawing.Point(11, 61)
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
            Me.chkPosted.Location = New System.Drawing.Point(110, 86)
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
            Me.lblPosted.Location = New System.Drawing.Point(11, 86)
            Me.lblPosted.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPosted.Name = "lblPosted"
            Me.lblPosted.Size = New System.Drawing.Size(97, 23)
            Me.lblPosted.TabIndex = 6
            Me.lblPosted.Text = "Posted?"
            Me.lblPosted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'floArJournalHeader
            '
            Me.floArJournalHeader.BackColor = System.Drawing.Color.Transparent
            Me.floArJournalHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floArJournalHeader.Controls.Add(Me.CFlowLayout3)
            Me.floArJournalHeader.Controls.Add(Me.CFlowLayout2)
            Me.floFullEntryArea.SetFlowBreak(Me.floArJournalHeader, True)
            Me.floArJournalHeader.Location = New System.Drawing.Point(3, 3)
            Me.floArJournalHeader.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
            Me.floArJournalHeader.Name = "floArJournalHeader"
            Me.floArJournalHeader.Size = New System.Drawing.Size(1026, 203)
            Me.floArJournalHeader.TabIndex = 0
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
            Me.CFlowLayout3.Controls.Add(Me.cboCustomerIdNo)
            Me.CFlowLayout3.Controls.Add(Me.lblTransactionType)
            Me.CFlowLayout3.Controls.Add(Me.cboTransactionType)
            Me.CFlowLayout3.Controls.Add(Me.lblAmount)
            Me.CFlowLayout3.Controls.Add(Me.txtAmount)
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
            Me.CFlowLayout3.Size = New System.Drawing.Size(763, 192)
            Me.CFlowLayout3.TabIndex = 0
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtJournalCode.ComputedValue = True
            Me.txtJournalCode.CustomFormat = Nothing
            Me.txtJournalCode.DataBoundControl = True
            Me.txtJournalCode.DisplayOnly = True
            Me.txtJournalCode.EditingMode = True
            Me.txtJournalCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
            Me.txtJournalCode.LinkedLabel = Nothing
            Me.txtJournalCode.Location = New System.Drawing.Point(158, 11)
            Me.txtJournalCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtJournalCode.MaximumValue = Nothing
            Me.txtJournalCode.MinimumValue = Nothing
            Me.txtJournalCode.Name = "txtJournalCode"
            Me.txtJournalCode.OldValue = Nothing
            Me.txtJournalCode.ReadOnly = True
            Me.txtJournalCode.Size = New System.Drawing.Size(25, 23)
            Me.txtJournalCode.TabIndex = 163
            Me.txtJournalCode.TabStop = False
            Me.txtJournalCode.Text = "AR"
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
            Me.TxtIdNo.Location = New System.Drawing.Point(185, 11)
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
            Me.txtReferenceNo.ComputedValue = False
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            Me.txtReferenceNo.EditingMode = False
            Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
            Me.txtReferenceNo.Location = New System.Drawing.Point(380, 11)
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
            Me.dtpTransactionDate.DisplayOnly = False
            Me.dtpTransactionDate.DtpDefaultValue = Nothing
            Me.dtpTransactionDate.EditingMode = False
            Me.dtpTransactionDate.EditsAllowed = False
            Me.CFlowLayout3.SetFlowBreak(Me.dtpTransactionDate, True)
            Me.dtpTransactionDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Location = New System.Drawing.Point(614, 10)
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
            'lblCustomerIdNo
            '
            Me.lblCustomerIdNo.DisplayOnly = True
            Me.lblCustomerIdNo.EditingMode = False
            Me.lblCustomerIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCustomerIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCustomerIdNo.Location = New System.Drawing.Point(11, 36)
            Me.lblCustomerIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCustomerIdNo.Name = "lblCustomerIdNo"
            Me.lblCustomerIdNo.Size = New System.Drawing.Size(145, 23)
            Me.lblCustomerIdNo.TabIndex = 254
            Me.lblCustomerIdNo.Text = "Customer Code/Name"
            Me.lblCustomerIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboCustomerIdNo
            '
            Me.cboCustomerIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboCustomerIdNo.BackColor = System.Drawing.Color.White
            Me.cboCustomerIdNo.ChangingSearchValueOnly = False
            Me.cboCustomerIdNo.CurrentSearchTerm = ""
            Me.cboCustomerIdNo.DefaultValue = Nothing
            Me.cboCustomerIdNo.DisplayMember = "Name"
            Me.cboCustomerIdNo.DropDownHeight = 1
            Me.cboCustomerIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboCustomerIdNo.EditingMode = False
            Me.cboCustomerIdNo.FilterRule = Nothing
            Me.cboCustomerIdNo.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.CFlowLayout3.SetFlowBreak(Me.cboCustomerIdNo, True)
            Me.cboCustomerIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboCustomerIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboCustomerIdNo.FormattingEnabled = True
            Me.cboCustomerIdNo.HideWhenNotEditingOrAdding = False
            Me.cboCustomerIdNo.IntegralHeight = False
            Me.cboCustomerIdNo.LinkedLabel = Nothing
            Me.cboCustomerIdNo.Location = New System.Drawing.Point(158, 36)
            Me.cboCustomerIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboCustomerIdNo.Name = "cboCustomerIdNo"
            Me.cboCustomerIdNo.OldValue = 0
            Me.cboCustomerIdNo.OriginalDataSource = Nothing
            Me.cboCustomerIdNo.OriginalList = Nothing
            Me.cboCustomerIdNo.OverrideDropDownStyleList = False
            Me.cboCustomerIdNo.PreviousSearchTerm = Nothing
            Me.cboCustomerIdNo.PreviousSelectedIndex = -1
            Me.cboCustomerIdNo.PropertySelector = Nothing
            Me.cboCustomerIdNo.ReadOnlyCombo = False
            Me.cboCustomerIdNo.SearchAnywhere = False
            Me.cboCustomerIdNo.Size = New System.Drawing.Size(579, 24)
            Me.cboCustomerIdNo.SuggestBoxHeight = 200
            Me.cboCustomerIdNo.SuggestListOrderRule = Nothing
            Me.cboCustomerIdNo.TabIndex = 3
            Me.cboCustomerIdNo.TextToSearch = Nothing
            Me.cboCustomerIdNo.ValueIsMandatory = False
            Me.cboCustomerIdNo.ValueIsNullable = False
            Me.cboCustomerIdNo.ValueIsNumeric = False
            Me.cboCustomerIdNo.ValueMember = "IdNo"
            '
            'lblTransactionType
            '
            Me.lblTransactionType.DisplayOnly = True
            Me.lblTransactionType.EditingMode = False
            Me.lblTransactionType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.cboTransactionType.Location = New System.Drawing.Point(158, 62)
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
            Me.lblAmount.Location = New System.Drawing.Point(282, 62)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(331, 23)
            Me.lblAmount.TabIndex = 264
            Me.lblAmount.Text = "Amount:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = Nothing
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = False
            Me.CFlowLayout3.SetFlowBreak(Me.txtAmount, True)
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.Location = New System.Drawing.Point(615, 62)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.Size = New System.Drawing.Size(122, 23)
            Me.txtAmount.TabIndex = 5
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblDueDate
            '
            Me.lblDueDate.DisplayOnly = True
            Me.lblDueDate.EditingMode = False
            Me.lblDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.dtpDueDate.DisplayOnly = False
            Me.dtpDueDate.DtpDefaultValue = Nothing
            Me.dtpDueDate.EditingMode = False
            Me.dtpDueDate.EditsAllowed = False
            Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpDueDate.ForeColor = System.Drawing.Color.Black
            Me.dtpDueDate.LinkedLabel = Nothing
            Me.dtpDueDate.Location = New System.Drawing.Point(157, 87)
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
            Me.lblInvoiceNo.Location = New System.Drawing.Point(281, 88)
            Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            Me.lblInvoiceNo.Size = New System.Drawing.Size(332, 23)
            Me.lblInvoiceNo.TabIndex = 254
            Me.lblInvoiceNo.Text = "Customer Invoice/Reference No.:"
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
            Me.txtInvoiceNo.Location = New System.Drawing.Point(615, 88)
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
            Me.cboAccountIdNo.Location = New System.Drawing.Point(158, 113)
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
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(158, 139)
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
            Me.CFlowLayout2.Controls.Add(Me.dtpDateCreated)
            Me.CFlowLayout2.Location = New System.Drawing.Point(772, 3)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Padding = New System.Windows.Forms.Padding(10)
            Me.CFlowLayout2.Size = New System.Drawing.Size(246, 192)
            Me.CFlowLayout2.TabIndex = 1
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CFlowLayout2.SetFlowBreak(Me.CLabel2, True)
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel2.Location = New System.Drawing.Point(11, 11)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(224, 23)
            Me.CLabel2.TabIndex = 279
            Me.CLabel2.Text = "Early Settlement Date/Rate:"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(10, 35)
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
            Me.dtpSettlementDueDate.DisplayOnly = False
            Me.dtpSettlementDueDate.DtpDefaultValue = Nothing
            Me.dtpSettlementDueDate.EditingMode = False
            Me.dtpSettlementDueDate.EditsAllowed = False
            Me.dtpSettlementDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
            Me.dtpSettlementDueDate.ForeColor = System.Drawing.Color.Black
            Me.dtpSettlementDueDate.LinkedLabel = Nothing
            Me.dtpSettlementDueDate.Location = New System.Drawing.Point(27, 35)
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
            Me.CLabel5.Location = New System.Drawing.Point(150, 35)
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
            Me.txtSettlementDiscount.Location = New System.Drawing.Point(174, 36)
            Me.txtSettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSettlementDiscount.MaximumValue = Nothing
            Me.txtSettlementDiscount.MinimumValue = Nothing
            Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
            Me.txtSettlementDiscount.OldValue = Nothing
            Me.txtSettlementDiscount.ReadOnly = True
            Me.txtSettlementDiscount.Size = New System.Drawing.Size(44, 23)
            Me.txtSettlementDiscount.TabIndex = 4
            Me.txtSettlementDiscount.ValueIsMandatory = True
            Me.txtSettlementDiscount.ValueIsNumeric = True
            '
            'lblPercent
            '
            Me.lblPercent.DisplayOnly = True
            Me.lblPercent.EditingMode = False
            Me.CFlowLayout2.SetFlowBreak(Me.lblPercent, True)
            Me.lblPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPercent.Location = New System.Drawing.Point(219, 35)
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
            Me.chkCancelled.Location = New System.Drawing.Point(110, 61)
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
            Me.lblDateAdded.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateAdded.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateAdded.Location = New System.Drawing.Point(11, 111)
            Me.lblDateAdded.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDateAdded.Name = "lblDateAdded"
            Me.lblDateAdded.Size = New System.Drawing.Size(40, 26)
            Me.lblDateAdded.TabIndex = 8
            Me.lblDateAdded.Text = "Date Added:"
            Me.lblDateAdded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
            Me.dtpDateCreated.Location = New System.Drawing.Point(53, 111)
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
            Me.floFullEntryArea.Controls.Add(Me.floArJournalHeader)
            Me.floFullEntryArea.Controls.Add(Me.floArJournalItems)
            Me.floFullEntryArea.Dock = System.Windows.Forms.DockStyle.Top
            Me.floFullEntryArea.Location = New System.Drawing.Point(0, 53)
            Me.floFullEntryArea.Name = "floFullEntryArea"
            Me.floFullEntryArea.Size = New System.Drawing.Size(1045, 514)
            Me.floFullEntryArea.TabIndex = 0
            '
            'ArJournalEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1045, 572)
            Me.Controls.Add(Me.floFullEntryArea)
            Me.MinimumSize = New System.Drawing.Size(1059, 611)
            Me.Name = "ArJournalEntry"
            Me.Text = "Accounts Receivable Journal Entry"
            Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floArJournalItems.ResumeLayout(False)
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floArJournalHeader.ResumeLayout(False)
            Me.CFlowLayout3.ResumeLayout(False)
            Me.CFlowLayout3.PerformLayout()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.floFullEntryArea.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents floArJournalItems As CFlowLayout
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents floArJournalHeader As CFlowLayout
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
        Friend WithEvents txtSettlementDiscount As CTextBox
        Friend WithEvents lblDueDate As CLabel
        Friend WithEvents dtpDueDate As CCustomDateTimePicker
        Friend WithEvents lblCustomerIdNo As CLabel
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents lblDateAdded As CLabel
        Friend WithEvents chkCancelled As CCheckBox
        Friend WithEvents lblPercent As CLabel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboCustomerIdNo As CaComboBox
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents CFlowLayout3 As CFlowLayout
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents CFlowLayout2 As CFlowLayout
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
        Friend WithEvents dgvRevCostCenterIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvNotes As CdgvColumnText
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
    End Class
End NameSpace