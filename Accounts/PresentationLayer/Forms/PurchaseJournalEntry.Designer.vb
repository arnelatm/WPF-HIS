Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PurchaseJournalEntry
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseJournalEntry))
            Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTotals = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floPurchaseJournalItems = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvJournalIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
        Me.dgvProfitCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemVatAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblCancelled = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.floPurchaseJournalHeader = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
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
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDueDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDueDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpInvoiceDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.lblEarlySettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpSettlementDueDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtSettlementDiscount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPercent = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblVatNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblDateAdded = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floFullEntryArea = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        LocalizableContent1 = New AATM.Libraries.LocalizationUtilities.LocalizableContent()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floPurchaseJournalItems.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floPurchaseJournalHeader.SuspendLayout
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
        Me.txtTotalCredits.Location = New System.Drawing.Point(374, 1)
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
        Me.lblTotals.DisplayOnly = true
        Me.lblTotals.EditingMode = false
        Me.lblTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTotals.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotals.Location = New System.Drawing.Point(1, 1)
        Me.lblTotals.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTotals.Name = "lblTotals"
        Me.lblTotals.Size = New System.Drawing.Size(279, 23)
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
        Me.txtTotalDebits.Location = New System.Drawing.Point(282, 1)
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
        'floPurchaseJournalItems
        '
        Me.floPurchaseJournalItems.BackColor = System.Drawing.Color.Transparent
        Me.floPurchaseJournalItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floPurchaseJournalItems.Controls.Add(Me.DataGridViewJournalItems)
        Me.floFullEntryArea.SetFlowBreak(Me.floPurchaseJournalItems, true)
        Me.floPurchaseJournalItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.floPurchaseJournalItems.Location = New System.Drawing.Point(3, 203)
        Me.floPurchaseJournalItems.Name = "floPurchaseJournalItems"
        Me.floPurchaseJournalItems.Size = New System.Drawing.Size(1020, 263)
        Me.floPurchaseJournalItems.TabIndex = 1
        '
        'DataGridViewJournalItems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewJournalItems.AutoGenerateColumns = false
        Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvIdNo, Me.dgvJournalIdNo, Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvProfitCenterIdNo, Me.dgvNotes, Me.ItemVatAmount})
        Me.DataGridViewJournalItems.DataInGridChanged = false
        Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
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
        'dgvIdNo
        '
        Me.dgvIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIdNo.EditingMode = false
        Me.dgvIdNo.HeaderText = "IdNo"
        Me.dgvIdNo.MinimumWidth = 40
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIdNo.Visible = false
        Me.dgvIdNo.Width = 50
        '
        'dgvJournalIdNo
        '
        Me.dgvJournalIdNo.DataPropertyName = "JournalIdNo"
        Me.dgvJournalIdNo.HeaderText = "GeneralJournal Id No."
        Me.dgvJournalIdNo.Name = "dgvJournalIdNo"
        Me.dgvJournalIdNo.Visible = false
        '
        'dgvSequence
        '
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSequence.EditingMode = false
        Me.dgvSequence.HeaderText = "Seq"
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.Width = 30
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        Me.dgvAccountIdNo.FillWeight = 1!
        Me.dgvAccountIdNo.HeaderText = "Account Code-Name"
        Me.dgvAccountIdNo.MinimumWidth = 200
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountIdNo.Width = 200
        '
        'dgvDebit
        '
        Me.dgvDebit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvDebit.DataPropertyName = "Debit"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Format = "N2"
        Me.dgvDebit.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDebit.EditingMode = false
        Me.dgvDebit.HeaderText = "Debit"
        Me.dgvDebit.MinimumWidth = 90
        Me.dgvDebit.Name = "dgvDebit"
        Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDebit.Width = 90
        '
        'dgvCredit
        '
        Me.dgvCredit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvCredit.DataPropertyName = "Credit"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Format = "N2"
        Me.dgvCredit.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCredit.EditingMode = false
        Me.dgvCredit.HeaderText = "Credit"
        Me.dgvCredit.MinimumWidth = 90
        Me.dgvCredit.Name = "dgvCredit"
        Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvCredit.Width = 90
        '
        'dgvProfitCenterIdNo
        '
        Me.dgvProfitCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dgvProfitCenterIdNo.DataPropertyName = "ProfitCenterIdNo"
        Me.dgvProfitCenterIdNo.HeaderText = "Cost Center Code-Name"
        Me.dgvProfitCenterIdNo.MinimumWidth = 120
        Me.dgvProfitCenterIdNo.Name = "dgvProfitCenterIdNo"
        Me.dgvProfitCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProfitCenterIdNo.Width = 120
        '
        'dgvNotes
        '
        Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNotes.DataPropertyName = "Notes"
        Me.dgvNotes.HeaderText = "Notes / Description"
        Me.dgvNotes.Name = "dgvNotes"
        '
        'ItemVatAmount
        '
        Me.ItemVatAmount.HeaderText = "ItemVatAmount"
        Me.ItemVatAmount.Name = "ItemVatAmount"
        Me.ItemVatAmount.Visible = false
        '
        'lblCancelled
        '
        Me.lblCancelled.DisplayOnly = true
        Me.lblCancelled.EditingMode = false
        Me.lblCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCancelled.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelled.Location = New System.Drawing.Point(1, 51)
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
        Me.chkPosted.Location = New System.Drawing.Point(100, 76)
        Me.chkPosted.Margin = New System.Windows.Forms.Padding(1)
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.Size = New System.Drawing.Size(23, 21)
        Me.chkPosted.TabIndex = 7
        Me.chkPosted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPosted.UseVisualStyleBackColor = false
        '
        'lblPosted
        '
        Me.lblPosted.DisplayOnly = true
        Me.lblPosted.EditingMode = false
        Me.lblPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPosted.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPosted.Location = New System.Drawing.Point(1, 76)
        Me.lblPosted.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPosted.Name = "lblPosted"
        Me.lblPosted.Size = New System.Drawing.Size(97, 23)
        Me.lblPosted.TabIndex = 6
        Me.lblPosted.Text = "Posted?"
        Me.lblPosted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'floPurchaseJournalHeader
        '
        Me.floPurchaseJournalHeader.BackColor = System.Drawing.Color.Transparent
        Me.floPurchaseJournalHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floPurchaseJournalHeader.Controls.Add(Me.CFlowLayout3)
        Me.floPurchaseJournalHeader.Controls.Add(Me.CFlowLayout2)
        Me.floFullEntryArea.SetFlowBreak(Me.floPurchaseJournalHeader, true)
        Me.floPurchaseJournalHeader.Location = New System.Drawing.Point(3, 3)
        Me.floPurchaseJournalHeader.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.floPurchaseJournalHeader.Name = "floPurchaseJournalHeader"
        Me.floPurchaseJournalHeader.Size = New System.Drawing.Size(1020, 194)
        Me.floPurchaseJournalHeader.TabIndex = 0
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
        Me.CFlowLayout3.Controls.Add(Me.lblAmount)
        Me.CFlowLayout3.Controls.Add(Me.txtAmount)
        Me.CFlowLayout3.Controls.Add(Me.lblInvoiceNo)
        Me.CFlowLayout3.Controls.Add(Me.txtInvoiceNo)
        Me.CFlowLayout3.Controls.Add(Me.lblDueDate)
        Me.CFlowLayout3.Controls.Add(Me.dtpDueDate)
        Me.CFlowLayout3.Controls.Add(Me.lblInvoiceDate)
        Me.CFlowLayout3.Controls.Add(Me.dtpInvoiceDate)
        Me.CFlowLayout3.Controls.Add(Me.lblEarlySettlementDiscount)
        Me.CFlowLayout3.Controls.Add(Me.dtpSettlementDueDate)
        Me.CFlowLayout3.Controls.Add(Me.CLabel5)
        Me.CFlowLayout3.Controls.Add(Me.txtSettlementDiscount)
        Me.CFlowLayout3.Controls.Add(Me.lblPercent)
        Me.CFlowLayout3.Controls.Add(Me.lblAccountIdNo)
        Me.CFlowLayout3.Controls.Add(Me.cboAccountIdNo)
        Me.CFlowLayout3.Controls.Add(Me.lblNotes)
        Me.CFlowLayout3.Controls.Add(Me.txtNotes)
        Me.CFlowLayout3.Location = New System.Drawing.Point(3, 3)
        Me.CFlowLayout3.Name = "CFlowLayout3"
        Me.CFlowLayout3.Padding = New System.Windows.Forms.Padding(10)
        Me.CFlowLayout3.Size = New System.Drawing.Size(763, 188)
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
        Me.txtJournalCode.Text = "PJ"
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
        Me.lblReferenceNo.DisplayOnly = true
        Me.lblReferenceNo.EditingMode = false
        Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReferenceNo.Location = New System.Drawing.Point(250, 11)
        Me.lblReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(136, 23)
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
        Me.txtReferenceNo.Location = New System.Drawing.Point(388, 11)
        Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.OldValue = Nothing
        Me.txtReferenceNo.Size = New System.Drawing.Size(90, 23)
        Me.txtReferenceNo.TabIndex = 1
        Me.txtReferenceNo.ValueIsMandatory = true
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.DisplayOnly = true
        Me.lblTransactionDate.EditingMode = false
        Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransactionDate.Location = New System.Drawing.Point(480, 11)
        Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(133, 23)
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
        Me.lblSupplierIdNo.DisplayOnly = true
        Me.lblSupplierIdNo.EditingMode = false
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
        Me.cboSupplierIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSupplierIdNo.BackColor = System.Drawing.Color.White
        Me.cboSupplierIdNo.ChangingSearchValueOnly = false
        Me.cboSupplierIdNo.CurrentSearchTerm = ""
        Me.cboSupplierIdNo.DefaultValue = Nothing
        Me.cboSupplierIdNo.DisplayMember = "Name"
        Me.cboSupplierIdNo.DropDownHeight = 200
        Me.cboSupplierIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
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
        'lblAmount
        '
        Me.lblAmount.DisplayOnly = true
        Me.lblAmount.EditingMode = false
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAmount.Location = New System.Drawing.Point(11, 62)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(145, 23)
        Me.lblAmount.TabIndex = 264
        Me.lblAmount.Text = "Invoice Amount:"
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
        Me.txtAmount.Location = New System.Drawing.Point(158, 62)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OldValue = Nothing
        Me.txtAmount.Size = New System.Drawing.Size(122, 23)
        Me.txtAmount.TabIndex = 4
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmount.ValueIsMandatory = true
        Me.txtAmount.ValueIsNumeric = true
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.DisplayOnly = true
        Me.lblInvoiceNo.EditingMode = false
        Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInvoiceNo.Location = New System.Drawing.Point(282, 62)
        Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(104, 23)
        Me.lblInvoiceNo.TabIndex = 254
        Me.lblInvoiceNo.Text = "Invoice No.:"
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
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtInvoiceNo.ForeColor = System.Drawing.Color.Black
        Me.txtInvoiceNo.LinkedLabel = Me.lblInvoiceNo
        Me.txtInvoiceNo.Location = New System.Drawing.Point(388, 62)
        Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.OldValue = Nothing
        Me.txtInvoiceNo.Size = New System.Drawing.Size(122, 23)
        Me.txtInvoiceNo.TabIndex = 5
        Me.txtInvoiceNo.ValueIsMandatory = true
        '
        'lblDueDate
        '
        Me.lblDueDate.DisplayOnly = true
        Me.lblDueDate.EditingMode = false
        Me.lblDueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDueDate.Location = New System.Drawing.Point(512, 62)
        Me.lblDueDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Size = New System.Drawing.Size(101, 23)
        Me.lblDueDate.TabIndex = 259
        Me.lblDueDate.Text = "Due Date:"
        Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpDueDate
        '
        Me.dtpDueDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDueDate.DefaultValue = Nothing
        Me.dtpDueDate.DisplayOnly = false
        Me.dtpDueDate.DtpDefaultValue = Nothing
        Me.dtpDueDate.EditingMode = false
        Me.dtpDueDate.EditsAllowed = false
        Me.CFlowLayout3.SetFlowBreak(Me.dtpDueDate, true)
        Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dtpDueDate.ForeColor = System.Drawing.Color.Black
        Me.dtpDueDate.LinkedLabel = Nothing
        Me.dtpDueDate.Location = New System.Drawing.Point(614, 61)
        Me.dtpDueDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.ReadOnlyDp = false
        Me.dtpDueDate.SecurityKey = Nothing
        Me.dtpDueDate.ShowLongDate = false
        Me.dtpDueDate.ShowTime = false
        Me.dtpDueDate.Size = New System.Drawing.Size(123, 24)
        Me.dtpDueDate.TabIndex = 6
        Me.dtpDueDate.TargetCalendar = CType(resources.GetObject("dtpDueDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpDueDate.Value = Nothing
        Me.dtpDueDate.ValueIsMandatory = false
        Me.dtpDueDate.ValueIsNullable = false
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.DisplayOnly = true
        Me.lblInvoiceDate.EditingMode = false
        Me.lblInvoiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblInvoiceDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInvoiceDate.Location = New System.Drawing.Point(11, 87)
        Me.lblInvoiceDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(145, 23)
        Me.lblInvoiceDate.TabIndex = 257
        Me.lblInvoiceDate.Text = "Invoice Date:"
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
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(157, 86)
        Me.dtpInvoiceDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.ReadOnlyDp = false
        Me.dtpInvoiceDate.SecurityKey = Nothing
        Me.dtpInvoiceDate.ShowLongDate = false
        Me.dtpInvoiceDate.ShowTime = false
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(123, 24)
        Me.dtpInvoiceDate.TabIndex = 7
        Me.dtpInvoiceDate.TargetCalendar = CType(resources.GetObject("dtpInvoiceDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpInvoiceDate.Value = Nothing
        Me.dtpInvoiceDate.ValueIsMandatory = false
        Me.dtpInvoiceDate.ValueIsNullable = false
        '
        'lblEarlySettlementDiscount
        '
        Me.lblEarlySettlementDiscount.DisplayOnly = true
        Me.lblEarlySettlementDiscount.EditingMode = false
        Me.lblEarlySettlementDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEarlySettlementDiscount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEarlySettlementDiscount.Location = New System.Drawing.Point(281, 87)
        Me.lblEarlySettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEarlySettlementDiscount.Name = "lblEarlySettlementDiscount"
        Me.lblEarlySettlementDiscount.Size = New System.Drawing.Size(252, 23)
        Me.lblEarlySettlementDiscount.TabIndex = 262
        Me.lblEarlySettlementDiscount.Text = "Early Settlement Date/Rate:"
        Me.lblEarlySettlementDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.dtpSettlementDueDate.Location = New System.Drawing.Point(534, 86)
        Me.dtpSettlementDueDate.Margin = New System.Windows.Forms.Padding(0)
        Me.dtpSettlementDueDate.Name = "dtpSettlementDueDate"
        Me.dtpSettlementDueDate.ReadOnlyDp = false
        Me.dtpSettlementDueDate.SecurityKey = Nothing
        Me.dtpSettlementDueDate.ShowLongDate = false
        Me.dtpSettlementDueDate.ShowTime = false
        Me.dtpSettlementDueDate.Size = New System.Drawing.Size(123, 24)
        Me.dtpSettlementDueDate.TabIndex = 8
        Me.dtpSettlementDueDate.TargetCalendar = CType(resources.GetObject("dtpSettlementDueDate.TargetCalendar"),System.Globalization.Calendar)
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
        Me.CLabel5.Location = New System.Drawing.Point(657, 86)
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
        Me.txtSettlementDiscount.LinkedLabel = Me.lblEarlySettlementDiscount
        Me.txtSettlementDiscount.Location = New System.Drawing.Point(681, 87)
        Me.txtSettlementDiscount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtSettlementDiscount.Name = "txtSettlementDiscount"
        Me.txtSettlementDiscount.OldValue = Nothing
        Me.txtSettlementDiscount.Size = New System.Drawing.Size(44, 23)
        Me.txtSettlementDiscount.TabIndex = 9
        Me.txtSettlementDiscount.ValueIsMandatory = true
        '
        'lblPercent
        '
        Me.lblPercent.DisplayOnly = true
        Me.lblPercent.EditingMode = false
        Me.CFlowLayout3.SetFlowBreak(Me.lblPercent, true)
        Me.lblPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPercent.Location = New System.Drawing.Point(726, 86)
        Me.lblPercent.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(16, 23)
        Me.lblPercent.TabIndex = 269
        Me.lblPercent.Text = "%"
        Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAccountIdNo
        '
        Me.lblAccountIdNo.DisplayOnly = true
        Me.lblAccountIdNo.EditingMode = false
        Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAccountIdNo.Location = New System.Drawing.Point(11, 112)
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
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.DefaultValue = ""
        Me.cboAccountIdNo.DisplayMember = "Name"
        Me.cboAccountIdNo.DropDownHeight = 200
        Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountIdNo.EditingMode = false
        Me.cboAccountIdNo.FilterRule = Nothing
        Me.CFlowLayout3.SetFlowBreak(Me.cboAccountIdNo, true)
        Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
        Me.cboAccountIdNo.Location = New System.Drawing.Point(158, 112)
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
        Me.cboAccountIdNo.TabIndex = 10
        Me.cboAccountIdNo.TextToSearch = Nothing
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
        Me.lblNotes.Location = New System.Drawing.Point(11, 138)
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
        Me.txtNotes.Location = New System.Drawing.Point(158, 138)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.Size = New System.Drawing.Size(579, 46)
        Me.txtNotes.TabIndex = 11
        Me.txtNotes.ValueIsMandatory = true
        '
        'CFlowLayout2
        '
        Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout2.Controls.Add(Me.lblVatNumber)
        Me.CFlowLayout2.Controls.Add(Me.txtVatNumber)
        Me.CFlowLayout2.Controls.Add(Me.lblVatAmount)
        Me.CFlowLayout2.Controls.Add(Me.txtVatAmount)
        Me.CFlowLayout2.Controls.Add(Me.lblCancelled)
        Me.CFlowLayout2.Controls.Add(Me.chkCancelled)
        Me.CFlowLayout2.Controls.Add(Me.lblPosted)
        Me.CFlowLayout2.Controls.Add(Me.chkPosted)
        Me.CFlowLayout2.Controls.Add(Me.lblDateAdded)
        Me.CFlowLayout2.Controls.Add(Me.txtDateCreated)
        Me.CFlowLayout2.Location = New System.Drawing.Point(772, 3)
        Me.CFlowLayout2.Name = "CFlowLayout2"
        Me.CFlowLayout2.Size = New System.Drawing.Size(241, 133)
        Me.CFlowLayout2.TabIndex = 1
        '
        'lblVatNumber
        '
        Me.lblVatNumber.DisplayOnly = true
        Me.lblVatNumber.EditingMode = false
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
        Me.lblVatAmount.DisplayOnly = true
        Me.lblVatAmount.EditingMode = false
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
        Me.txtVatAmount.TabIndex = 3
        Me.txtVatAmount.ValueIsMandatory = true
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
        Me.chkCancelled.Location = New System.Drawing.Point(100, 51)
        Me.chkCancelled.Margin = New System.Windows.Forms.Padding(1)
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.Size = New System.Drawing.Size(23, 21)
        Me.chkCancelled.TabIndex = 5
        Me.chkCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCancelled.UseVisualStyleBackColor = false
        '
        'lblDateAdded
        '
        Me.lblDateAdded.DisplayOnly = true
        Me.lblDateAdded.EditingMode = false
        Me.lblDateAdded.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDateAdded.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDateAdded.Location = New System.Drawing.Point(1, 101)
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
        Me.txtDateCreated.Location = New System.Drawing.Point(72, 101)
        Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.OldValue = Nothing
        Me.txtDateCreated.Size = New System.Drawing.Size(150, 20)
        Me.txtDateCreated.TabIndex = 9
        Me.txtDateCreated.ValueIsMandatory = true
        '
        'floFullEntryArea
        '
        Me.floFullEntryArea.BackColor = System.Drawing.Color.Transparent
        Me.floFullEntryArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.floFullEntryArea.Controls.Add(Me.floPurchaseJournalHeader)
        Me.floFullEntryArea.Controls.Add(Me.floPurchaseJournalItems)
        Me.floFullEntryArea.Controls.Add(Me.CFlowLayout1)
        Me.floFullEntryArea.Dock = System.Windows.Forms.DockStyle.Top
        Me.floFullEntryArea.Location = New System.Drawing.Point(0, 57)
        Me.floFullEntryArea.Name = "floFullEntryArea"
        Me.floFullEntryArea.Size = New System.Drawing.Size(1034, 509)
        Me.floFullEntryArea.TabIndex = 0
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblTotals)
        Me.CFlowLayout1.Controls.Add(Me.txtTotalDebits)
        Me.CFlowLayout1.Controls.Add(Me.txtTotalCredits)
        Me.CFlowLayout1.Location = New System.Drawing.Point(3, 472)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(1013, 30)
        Me.CFlowLayout1.TabIndex = 0
        '
        'PurchaseJournalEntry
        '
        Me.ClientSize = New System.Drawing.Size(1034, 539)
        Me.Controls.Add(Me.floFullEntryArea)
        Me.MaximumSize = New System.Drawing.Size(1050, 578)
        Me.Name = "PurchaseJournalEntry"
            Me.Text = "Purchase Journal Entry"
            Me.Controls.SetChildIndex(Me.floFullEntryArea, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floPurchaseJournalItems.ResumeLayout(false)
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.floPurchaseJournalHeader.ResumeLayout(false)
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
        Friend WithEvents floPurchaseJournalItems As CFlowLayout
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents floPurchaseJournalHeader As CFlowLayout
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
        Friend WithEvents lblEarlySettlementDiscount As CLabel
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
        Friend WithEvents dgvIdNo As CdgvColumnText
        Friend WithEvents dgvJournalIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvColumnMoney
        Friend WithEvents dgvCredit As CdgvColumnMoney
        Friend WithEvents dgvProfitCenterIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvNotes As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ItemVatAmount As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents cboAccountIdNo As CaComboBox
    End Class
End NameSpace