Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DisbursementJournalEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DisbursementJournalEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator2 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.bsDjOiItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.tlpDisbursement = New System.Windows.Forms.TableLayoutPanel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
            Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.DiscountTakenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.JournalIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OriginalAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PaidAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayeeTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SpecialAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CancelledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpDateCreated = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblCancelled = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDiscountAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPaymentType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPaymentType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDiscountAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtORNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblApplied = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtApplied = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtUnapplied = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.btnAutoApply = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.DataGridViewDjOiItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequenceDjOi = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.DgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvJournalCode = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvJournalIdNoAp = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPreviousBalance = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvBalance = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.JournalItemIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OpenInvoiceIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.dtpCheckDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblCheckDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblVatNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsDjOiItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tlpDisbursement.SuspendLayout()
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewDjOiItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
            'bsJournalItems
            '
            Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
            '
            'bsDjOiItems
            '
            Me.bsDjOiItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DjOiItemModel)
            '
            'tlpDisbursement
            '
            Me.tlpDisbursement.BackColor = System.Drawing.Color.Transparent
            resources.ApplyResources(Me.tlpDisbursement, "tlpDisbursement")
            Me.tlpDisbursement.Controls.Add(Me.CLabel1, 0, 8)
            Me.tlpDisbursement.Controls.Add(Me.btnViewGL, 0, 8)
            Me.tlpDisbursement.Controls.Add(Me.DataGridViewJournalItems, 0, 7)
            Me.tlpDisbursement.Controls.Add(Me.lblDateCreated, 9, 6)
            Me.tlpDisbursement.Controls.Add(Me.chkPosted, 11, 5)
            Me.tlpDisbursement.Controls.Add(Me.dtpDateCreated, 10, 6)
            Me.tlpDisbursement.Controls.Add(Me.lblPosted, 9, 5)
            Me.tlpDisbursement.Controls.Add(Me.chkCancelled, 11, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblCancelled, 9, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblDiscountAccountIdNo, 0, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblNotes, 0, 5)
            Me.tlpDisbursement.Controls.Add(Me.cboPaymentType, 1, 1)
            Me.tlpDisbursement.Controls.Add(Me.cboAccountIdNo, 1, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblAccountIdNo, 0, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblPaymentType, 0, 1)
            Me.tlpDisbursement.Controls.Add(Me.TxtIdNo, 2, 0)
            Me.tlpDisbursement.Controls.Add(Me.txtJournalCode, 1, 0)
            Me.tlpDisbursement.Controls.Add(Me.lblIdNo, 0, 0)
            Me.tlpDisbursement.Controls.Add(Me.lblReferenceNo, 3, 0)
            Me.tlpDisbursement.Controls.Add(Me.cboDiscountAccountIdNo, 1, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblInvoiceNo, 0, 3)
            Me.tlpDisbursement.Controls.Add(Me.txtORNumber, 1, 3)
            Me.tlpDisbursement.Controls.Add(Me.txtReferenceNo, 5, 0)
            Me.tlpDisbursement.Controls.Add(Me.lblSupplierIdNo, 4, 1)
            Me.tlpDisbursement.Controls.Add(Me.dtpTransactionDate, 8, 0)
            Me.tlpDisbursement.Controls.Add(Me.txtAmount, 8, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblAmount, 7, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblTransactionDate, 7, 0)
            Me.tlpDisbursement.Controls.Add(Me.txtNotes, 1, 5)
            Me.tlpDisbursement.Controls.Add(Me.txtVatAmount, 11, 0)
            Me.tlpDisbursement.Controls.Add(Me.txtApplied, 11, 1)
            Me.tlpDisbursement.Controls.Add(Me.txtUnapplied, 11, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblVatAmount, 9, 0)
            Me.tlpDisbursement.Controls.Add(Me.lblApplied, 9, 1)
            Me.tlpDisbursement.Controls.Add(Me.CLabel2, 9, 2)
            Me.tlpDisbursement.Controls.Add(Me.txtDiscountTaken, 11, 3)
            Me.tlpDisbursement.Controls.Add(Me.lblDiscountTaken, 9, 3)
            Me.tlpDisbursement.Controls.Add(Me.cboPayeeIdNo, 5, 1)
            Me.tlpDisbursement.Controls.Add(Me.btnAutoApply, 2, 8)
            Me.tlpDisbursement.Controls.Add(Me.DataGridViewDjOiItems, 12, 7)
            Me.tlpDisbursement.Controls.Add(Me.txtPayeeName, 6, 8)
            Me.tlpDisbursement.Controls.Add(Me.dtpCheckDate, 8, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblCheckDate, 7, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblVatNo, 3, 3)
            Me.tlpDisbursement.Controls.Add(Me.txtVatNumber, 5, 3)
            Me.tlpDisbursement.Controls.Add(Me.txtCheckNumber, 8, 3)
            Me.tlpDisbursement.Controls.Add(Me.lblCheckNumber, 7, 3)
            Me.tlpDisbursement.Name = "tlpDisbursement"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            '
            'btnViewGL
            '
            Me.tlpDisbursement.SetColumnSpan(Me.btnViewGL, 2)
            Me.btnViewGL.DesignerSelected = False
            Me.btnViewGL.DisplayOnly = True
            resources.ApplyResources(Me.btnViewGL, "btnViewGL")
            Me.btnViewGL.ImageIndex = 0
            Me.btnViewGL.Name = "btnViewGL"
            Me.btnViewGL.OriginalImageName = Nothing
            Me.btnViewGL.SecurityKey = ""
            '
            'DataGridViewJournalItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewJournalItems.AutoGenerateColumns = False
            Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.DiscountTakenDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OpenInvoiceIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PaidAmountDataGridViewTextBoxColumn, Me.PayeeTypeDataGridViewTextBoxColumn, Me.SpecialAccountDataGridViewTextBoxColumn, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn})
            Me.tlpDisbursement.SetColumnSpan(Me.DataGridViewJournalItems, 12)
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
            Me.DataGridViewJournalItems.DgvFooter = Nothing
            Me.DataGridViewJournalItems.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewJournalItems, "DataGridViewJournalItems")
            Me.DataGridViewJournalItems.Ea = EventAggregator1
            Me.DataGridViewJournalItems.EditingMode = False
            Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewJournalItems.FirstRowDeletionEnabled = False
            Me.DataGridViewJournalItems.FirstRowInsertionEnabled = False
            Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
            Me.DataGridViewJournalItems.ReadOnly = True
            Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
            Me.DataGridViewJournalItems.ShowFooter = False
            Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = True
            Me.DataGridViewJournalItems.StartTrackingChanges = False
            '
            'dgvSequence
            '
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.Frozen = True
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            Me.dgvAccountIdNo.Frozen = True
            resources.ApplyResources(Me.dgvAccountIdNo, "dgvAccountIdNo")
            Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
            Me.dgvAccountIdNo.ReadOnly = True
            Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
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
            Me.dgvDebit.Frozen = True
            resources.ApplyResources(Me.dgvDebit, "dgvDebit")
            Me.dgvDebit.Name = "dgvDebit"
            Me.dgvDebit.ReadOnly = True
            Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
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
            Me.dgvCredit.Frozen = True
            resources.ApplyResources(Me.dgvCredit, "dgvCredit")
            Me.dgvCredit.Name = "dgvCredit"
            Me.dgvCredit.ReadOnly = True
            Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
            resources.ApplyResources(Me.dgvRevCostCenterIdNo, "dgvRevCostCenterIdNo")
            Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.ReadOnly = True
            Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvNotes
            '
            Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvNotes.DataPropertyName = "Notes"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvNotes.EditingMode = False
            resources.ApplyResources(Me.dgvNotes, "dgvNotes")
            Me.dgvNotes.Name = "dgvNotes"
            Me.dgvNotes.ReadOnly = True
            Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNotes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            'DiscountTakenDataGridViewTextBoxColumn
            '
            Me.DiscountTakenDataGridViewTextBoxColumn.DataPropertyName = "DiscountTaken"
            resources.ApplyResources(Me.DiscountTakenDataGridViewTextBoxColumn, "DiscountTakenDataGridViewTextBoxColumn")
            Me.DiscountTakenDataGridViewTextBoxColumn.Name = "DiscountTakenDataGridViewTextBoxColumn"
            Me.DiscountTakenDataGridViewTextBoxColumn.ReadOnly = True
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn, "IdNoDataGridViewTextBoxColumn")
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'JournalIdNoDataGridViewTextBoxColumn
            '
            Me.JournalIdNoDataGridViewTextBoxColumn.DataPropertyName = "JournalIdNo"
            resources.ApplyResources(Me.JournalIdNoDataGridViewTextBoxColumn, "JournalIdNoDataGridViewTextBoxColumn")
            Me.JournalIdNoDataGridViewTextBoxColumn.Name = "JournalIdNoDataGridViewTextBoxColumn"
            Me.JournalIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'OpenInvoiceIdNoDataGridViewTextBoxColumn
            '
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.DataPropertyName = "OpenInvoiceIdNo"
            resources.ApplyResources(Me.OpenInvoiceIdNoDataGridViewTextBoxColumn, "OpenInvoiceIdNoDataGridViewTextBoxColumn")
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.Name = "OpenInvoiceIdNoDataGridViewTextBoxColumn"
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'OriginalAmountDataGridViewTextBoxColumn
            '
            Me.OriginalAmountDataGridViewTextBoxColumn.DataPropertyName = "OriginalAmount"
            resources.ApplyResources(Me.OriginalAmountDataGridViewTextBoxColumn, "OriginalAmountDataGridViewTextBoxColumn")
            Me.OriginalAmountDataGridViewTextBoxColumn.Name = "OriginalAmountDataGridViewTextBoxColumn"
            Me.OriginalAmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PaidAmountDataGridViewTextBoxColumn
            '
            Me.PaidAmountDataGridViewTextBoxColumn.DataPropertyName = "PaidAmount"
            resources.ApplyResources(Me.PaidAmountDataGridViewTextBoxColumn, "PaidAmountDataGridViewTextBoxColumn")
            Me.PaidAmountDataGridViewTextBoxColumn.Name = "PaidAmountDataGridViewTextBoxColumn"
            Me.PaidAmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PayeeTypeDataGridViewTextBoxColumn
            '
            Me.PayeeTypeDataGridViewTextBoxColumn.DataPropertyName = "PayeeType"
            resources.ApplyResources(Me.PayeeTypeDataGridViewTextBoxColumn, "PayeeTypeDataGridViewTextBoxColumn")
            Me.PayeeTypeDataGridViewTextBoxColumn.Name = "PayeeTypeDataGridViewTextBoxColumn"
            Me.PayeeTypeDataGridViewTextBoxColumn.ReadOnly = True
            '
            'SpecialAccountDataGridViewTextBoxColumn
            '
            Me.SpecialAccountDataGridViewTextBoxColumn.DataPropertyName = "SpecialAccount"
            resources.ApplyResources(Me.SpecialAccountDataGridViewTextBoxColumn, "SpecialAccountDataGridViewTextBoxColumn")
            Me.SpecialAccountDataGridViewTextBoxColumn.Name = "SpecialAccountDataGridViewTextBoxColumn"
            Me.SpecialAccountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'AccountNameDataGridViewTextBoxColumn
            '
            Me.AccountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName"
            resources.ApplyResources(Me.AccountNameDataGridViewTextBoxColumn, "AccountNameDataGridViewTextBoxColumn")
            Me.AccountNameDataGridViewTextBoxColumn.Name = "AccountNameDataGridViewTextBoxColumn"
            Me.AccountNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CancelledDataGridViewCheckBoxColumn
            '
            Me.CancelledDataGridViewCheckBoxColumn.DataPropertyName = "Cancelled"
            resources.ApplyResources(Me.CancelledDataGridViewCheckBoxColumn, "CancelledDataGridViewCheckBoxColumn")
            Me.CancelledDataGridViewCheckBoxColumn.Name = "CancelledDataGridViewCheckBoxColumn"
            Me.CancelledDataGridViewCheckBoxColumn.ReadOnly = True
            '
            'lblDateCreated
            '
            Me.lblDateCreated.DisplayOnly = True
            resources.ApplyResources(Me.lblDateCreated, "lblDateCreated")
            Me.lblDateCreated.EditingMode = False
            Me.lblDateCreated.Name = "lblDateCreated"
            '
            'chkPosted
            '
            resources.ApplyResources(Me.chkPosted, "chkPosted")
            Me.chkPosted.AutoCheck = False
            Me.chkPosted.BackColor = System.Drawing.Color.White
            Me.chkPosted.DisplayOnly = True
            Me.chkPosted.EditingMode = True
            Me.chkPosted.ForeColor = System.Drawing.Color.Black
            Me.chkPosted.LinkedLabel = Me.lblPosted
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.NoLabel = True
            Me.chkPosted.OldValue = Nothing
            Me.chkPosted.TabStop = False
            Me.chkPosted.UseVisualStyleBackColor = False
            '
            'lblPosted
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblPosted, 2)
            Me.lblPosted.DisplayOnly = True
            resources.ApplyResources(Me.lblPosted, "lblPosted")
            Me.lblPosted.EditingMode = False
            Me.lblPosted.Name = "lblPosted"
            '
            'dtpDateCreated
            '
            Me.dtpDateCreated.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.tlpDisbursement.SetColumnSpan(Me.dtpDateCreated, 2)
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
            Me.dtpDateCreated.TabStop = False
            Me.dtpDateCreated.TargetCalendar = Nothing
            Me.dtpDateCreated.Value = Nothing
            Me.dtpDateCreated.ValueIsMandatory = False
            Me.dtpDateCreated.ValueIsNullable = False
            '
            'chkCancelled
            '
            resources.ApplyResources(Me.chkCancelled, "chkCancelled")
            Me.chkCancelled.AutoCheck = False
            Me.chkCancelled.BackColor = System.Drawing.Color.White
            Me.chkCancelled.DisplayOnly = True
            Me.chkCancelled.EditingMode = True
            Me.chkCancelled.ForeColor = System.Drawing.Color.Black
            Me.chkCancelled.LinkedLabel = Me.lblCancelled
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.NoLabel = True
            Me.chkCancelled.OldValue = Nothing
            Me.chkCancelled.TabStop = False
            Me.chkCancelled.UseVisualStyleBackColor = False
            '
            'lblCancelled
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblCancelled, 2)
            Me.lblCancelled.DisplayOnly = True
            resources.ApplyResources(Me.lblCancelled, "lblCancelled")
            Me.lblCancelled.EditingMode = False
            Me.lblCancelled.Name = "lblCancelled"
            '
            'lblDiscountAccountIdNo
            '
            Me.lblDiscountAccountIdNo.DisplayOnly = True
            Me.lblDiscountAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblDiscountAccountIdNo, "lblDiscountAccountIdNo")
            Me.lblDiscountAccountIdNo.Name = "lblDiscountAccountIdNo"
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'cboPaymentType
            '
            Me.cboPaymentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPaymentType.BackColor = System.Drawing.Color.White
            Me.cboPaymentType.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPaymentType, 3)
            Me.cboPaymentType.CurrentSearchTerm = ""
            Me.cboPaymentType.DefaultValue = "0"
            Me.cboPaymentType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboPaymentType, "cboPaymentType")
            Me.cboPaymentType.DropDownHeight = 1
            Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPaymentType.EditingMode = False
            Me.cboPaymentType.FilterRule = Nothing
            Me.cboPaymentType.ForeColor = System.Drawing.Color.Black
            Me.cboPaymentType.HideWhenNotEditingOrAdding = False
            Me.cboPaymentType.LinkedLabel = Me.lblPaymentType
            Me.cboPaymentType.Name = "cboPaymentType"
            Me.cboPaymentType.OldValue = 0
            Me.cboPaymentType.OriginalDataSource = Nothing
            Me.cboPaymentType.OriginalList = Nothing
            Me.cboPaymentType.OverrideDropDownStyleList = False
            Me.cboPaymentType.PreviousSearchTerm = Nothing
            Me.cboPaymentType.PreviousSelectedIndex = 0
            Me.cboPaymentType.PropertySelector = Nothing
            Me.cboPaymentType.ReadOnlyCombo = False
            Me.cboPaymentType.SearchAnywhere = False
            Me.cboPaymentType.SuggestBoxHeight = 200
            Me.cboPaymentType.SuggestListOrderRule = Nothing
            Me.cboPaymentType.TextToSearch = Nothing
            Me.cboPaymentType.ValueIsMandatory = False
            Me.cboPaymentType.ValueIsNullable = False
            Me.cboPaymentType.ValueIsNumeric = False
            Me.cboPaymentType.ValueMember = "Code"
            '
            'lblPaymentType
            '
            Me.lblPaymentType.DisplayOnly = True
            Me.lblPaymentType.EditingMode = False
            resources.ApplyResources(Me.lblPaymentType, "lblPaymentType")
            Me.lblPaymentType.Name = "lblPaymentType"
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboAccountIdNo, 6)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = ""
            Me.cboAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.DropDownHeight = 1
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
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
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = True
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.ValueIsNumeric = True
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
            resources.ApplyResources(Me.txtJournalCode, "txtJournalCode")
            Me.txtJournalCode.EditingMode = True
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
            'lblReferenceNo
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblReferenceNo, 2)
            Me.lblReferenceNo.DisplayOnly = True
            resources.ApplyResources(Me.lblReferenceNo, "lblReferenceNo")
            Me.lblReferenceNo.EditingMode = False
            Me.lblReferenceNo.Name = "lblReferenceNo"
            '
            'cboDiscountAccountIdNo
            '
            Me.cboDiscountAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboDiscountAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboDiscountAccountIdNo.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboDiscountAccountIdNo, 6)
            Me.cboDiscountAccountIdNo.CurrentSearchTerm = ""
            Me.cboDiscountAccountIdNo.DefaultValue = Nothing
            Me.cboDiscountAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboDiscountAccountIdNo, "cboDiscountAccountIdNo")
            Me.cboDiscountAccountIdNo.DropDownHeight = 1
            Me.cboDiscountAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboDiscountAccountIdNo.EditingMode = False
            Me.cboDiscountAccountIdNo.FilterRule = Nothing
            Me.cboDiscountAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboDiscountAccountIdNo.FormattingEnabled = True
            Me.cboDiscountAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboDiscountAccountIdNo.LinkedLabel = Nothing
            Me.cboDiscountAccountIdNo.Name = "cboDiscountAccountIdNo"
            Me.cboDiscountAccountIdNo.OldValue = 0
            Me.cboDiscountAccountIdNo.OriginalDataSource = Nothing
            Me.cboDiscountAccountIdNo.OriginalList = Nothing
            Me.cboDiscountAccountIdNo.OverrideDropDownStyleList = False
            Me.cboDiscountAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboDiscountAccountIdNo.PreviousSelectedIndex = 0
            Me.cboDiscountAccountIdNo.PropertySelector = Nothing
            Me.cboDiscountAccountIdNo.ReadOnlyCombo = False
            Me.cboDiscountAccountIdNo.SearchAnywhere = False
            Me.cboDiscountAccountIdNo.SuggestBoxHeight = 200
            Me.cboDiscountAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboDiscountAccountIdNo.TextToSearch = Nothing
            Me.cboDiscountAccountIdNo.ValueIsMandatory = False
            Me.cboDiscountAccountIdNo.ValueIsNullable = False
            Me.cboDiscountAccountIdNo.ValueIsNumeric = False
            Me.cboDiscountAccountIdNo.ValueMember = "IdNo"
            '
            'lblInvoiceNo
            '
            Me.lblInvoiceNo.DisplayOnly = True
            Me.lblInvoiceNo.EditingMode = False
            resources.ApplyResources(Me.lblInvoiceNo, "lblInvoiceNo")
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            '
            'txtORNumber
            '
            Me.txtORNumber.BackColor = System.Drawing.Color.White
            Me.txtORNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtORNumber, 2)
            Me.txtORNumber.ComputedValue = False
            Me.txtORNumber.CustomFormat = Nothing
            Me.txtORNumber.DataBoundControl = True
            resources.ApplyResources(Me.txtORNumber, "txtORNumber")
            Me.txtORNumber.EditingMode = False
            Me.txtORNumber.ForeColor = System.Drawing.Color.Black
            Me.txtORNumber.LinkedLabel = Me.lblInvoiceNo
            Me.txtORNumber.MaximumValue = Nothing
            Me.txtORNumber.MinimumValue = Nothing
            Me.txtORNumber.Name = "txtORNumber"
            Me.txtORNumber.OldValue = Nothing
            Me.txtORNumber.ReadOnly = True
            Me.txtORNumber.ValueIsMandatory = True
            '
            'txtReferenceNo
            '
            Me.txtReferenceNo.BackColor = System.Drawing.Color.White
            Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtReferenceNo, 2)
            Me.txtReferenceNo.ComputedValue = False
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            resources.ApplyResources(Me.txtReferenceNo, "txtReferenceNo")
            Me.txtReferenceNo.EditingMode = False
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.ReadOnly = True
            Me.txtReferenceNo.ValueIsMandatory = True
            '
            'lblSupplierIdNo
            '
            Me.lblSupplierIdNo.DisplayOnly = True
            resources.ApplyResources(Me.lblSupplierIdNo, "lblSupplierIdNo")
            Me.lblSupplierIdNo.EditingMode = False
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
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
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = "N2"
            Me.txtAmount.DataBoundControl = True
            resources.ApplyResources(Me.txtAmount, "txtAmount")
            Me.txtAmount.EditingMode = False
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            resources.ApplyResources(Me.lblAmount, "lblAmount")
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Name = "lblAmount"
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.DisplayOnly = True
            resources.ApplyResources(Me.lblTransactionDate, "lblTransactionDate")
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Name = "lblTransactionDate"
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtNotes, 8)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.EditingMode = False
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.tlpDisbursement.SetRowSpan(Me.txtNotes, 2)
            Me.txtNotes.ValueIsMandatory = True
            '
            'txtVatAmount
            '
            Me.txtVatAmount.BackColor = System.Drawing.Color.White
            Me.txtVatAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVatAmount.ComputedValue = False
            Me.txtVatAmount.CustomFormat = "N2"
            Me.txtVatAmount.DataBoundControl = True
            Me.txtVatAmount.DisplayOnly = True
            Me.txtVatAmount.EditingMode = True
            resources.ApplyResources(Me.txtVatAmount, "txtVatAmount")
            Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
            Me.txtVatAmount.LinkedLabel = Me.lblApplied
            Me.txtVatAmount.MaximumValue = Nothing
            Me.txtVatAmount.MinimumValue = Nothing
            Me.txtVatAmount.Name = "txtVatAmount"
            Me.txtVatAmount.OldValue = Nothing
            Me.txtVatAmount.ReadOnly = True
            Me.txtVatAmount.TabStop = False
            Me.txtVatAmount.ValueIsMandatory = True
            Me.txtVatAmount.ValueIsNumeric = True
            '
            'lblApplied
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblApplied, 2)
            Me.lblApplied.DisplayOnly = True
            resources.ApplyResources(Me.lblApplied, "lblApplied")
            Me.lblApplied.EditingMode = False
            Me.lblApplied.Name = "lblApplied"
            '
            'txtApplied
            '
            Me.txtApplied.BackColor = System.Drawing.Color.White
            Me.txtApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtApplied.ComputedValue = False
            Me.txtApplied.CustomFormat = "N2"
            Me.txtApplied.DataBoundControl = True
            Me.txtApplied.DisplayOnly = True
            Me.txtApplied.EditingMode = True
            resources.ApplyResources(Me.txtApplied, "txtApplied")
            Me.txtApplied.ForeColor = System.Drawing.Color.Black
            Me.txtApplied.LinkedLabel = Me.lblApplied
            Me.txtApplied.MaximumValue = Nothing
            Me.txtApplied.MinimumValue = Nothing
            Me.txtApplied.Name = "txtApplied"
            Me.txtApplied.OldValue = Nothing
            Me.txtApplied.ReadOnly = True
            Me.txtApplied.TabStop = False
            Me.txtApplied.ValueIsMandatory = True
            Me.txtApplied.ValueIsNumeric = True
            '
            'txtUnapplied
            '
            Me.txtUnapplied.BackColor = System.Drawing.Color.White
            Me.txtUnapplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnapplied.ComputedValue = False
            Me.txtUnapplied.CustomFormat = "N2"
            Me.txtUnapplied.DataBoundControl = True
            Me.txtUnapplied.DisplayOnly = True
            Me.txtUnapplied.EditingMode = True
            resources.ApplyResources(Me.txtUnapplied, "txtUnapplied")
            Me.txtUnapplied.ForeColor = System.Drawing.Color.Black
            Me.txtUnapplied.LinkedLabel = Me.CLabel2
            Me.txtUnapplied.MaximumValue = Nothing
            Me.txtUnapplied.MinimumValue = Nothing
            Me.txtUnapplied.Name = "txtUnapplied"
            Me.txtUnapplied.OldValue = Nothing
            Me.txtUnapplied.ReadOnly = True
            Me.txtUnapplied.TabStop = False
            Me.txtUnapplied.ValueIsMandatory = True
            Me.txtUnapplied.ValueIsNumeric = True
            '
            'CLabel2
            '
            Me.tlpDisbursement.SetColumnSpan(Me.CLabel2, 2)
            Me.CLabel2.DisplayOnly = True
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Name = "CLabel2"
            '
            'lblVatAmount
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblVatAmount, 2)
            Me.lblVatAmount.DisplayOnly = True
            resources.ApplyResources(Me.lblVatAmount, "lblVatAmount")
            Me.lblVatAmount.EditingMode = False
            Me.lblVatAmount.Name = "lblVatAmount"
            '
            'txtDiscountTaken
            '
            Me.txtDiscountTaken.BackColor = System.Drawing.Color.White
            Me.txtDiscountTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDiscountTaken.ComputedValue = False
            Me.txtDiscountTaken.CustomFormat = "N2"
            Me.txtDiscountTaken.DataBoundControl = True
            Me.txtDiscountTaken.DisplayOnly = True
            Me.txtDiscountTaken.EditingMode = True
            resources.ApplyResources(Me.txtDiscountTaken, "txtDiscountTaken")
            Me.txtDiscountTaken.ForeColor = System.Drawing.Color.Black
            Me.txtDiscountTaken.LinkedLabel = Me.lblDiscountTaken
            Me.txtDiscountTaken.MaximumValue = Nothing
            Me.txtDiscountTaken.MinimumValue = Nothing
            Me.txtDiscountTaken.Name = "txtDiscountTaken"
            Me.txtDiscountTaken.OldValue = Nothing
            Me.txtDiscountTaken.ReadOnly = True
            Me.txtDiscountTaken.TabStop = False
            Me.txtDiscountTaken.ValueIsMandatory = True
            Me.txtDiscountTaken.ValueIsNumeric = True
            '
            'lblDiscountTaken
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblDiscountTaken, 2)
            Me.lblDiscountTaken.DisplayOnly = True
            resources.ApplyResources(Me.lblDiscountTaken, "lblDiscountTaken")
            Me.lblDiscountTaken.EditingMode = False
            Me.lblDiscountTaken.Name = "lblDiscountTaken"
            '
            'cboPayeeIdNo
            '
            Me.cboPayeeIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPayeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayeeIdNo.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPayeeIdNo, 4)
            Me.cboPayeeIdNo.CurrentSearchTerm = ""
            Me.cboPayeeIdNo.DefaultValue = Nothing
            Me.cboPayeeIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboPayeeIdNo, "cboPayeeIdNo")
            Me.cboPayeeIdNo.DropDownHeight = 1
            Me.cboPayeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPayeeIdNo.EditingMode = False
            Me.cboPayeeIdNo.FilterRule = Nothing
            Me.cboPayeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayeeIdNo.FormattingEnabled = True
            Me.cboPayeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayeeIdNo.LinkedLabel = Nothing
            Me.cboPayeeIdNo.Name = "cboPayeeIdNo"
            Me.cboPayeeIdNo.OldValue = 0
            Me.cboPayeeIdNo.OriginalDataSource = Nothing
            Me.cboPayeeIdNo.OriginalList = Nothing
            Me.cboPayeeIdNo.OverrideDropDownStyleList = False
            Me.cboPayeeIdNo.PreviousSearchTerm = Nothing
            Me.cboPayeeIdNo.PreviousSelectedIndex = -1
            Me.cboPayeeIdNo.PropertySelector = Nothing
            Me.cboPayeeIdNo.ReadOnlyCombo = False
            Me.cboPayeeIdNo.SearchAnywhere = False
            Me.cboPayeeIdNo.SuggestBoxHeight = 200
            Me.cboPayeeIdNo.SuggestListOrderRule = Nothing
            Me.cboPayeeIdNo.TextToSearch = Nothing
            Me.cboPayeeIdNo.ValueIsMandatory = False
            Me.cboPayeeIdNo.ValueIsNullable = False
            Me.cboPayeeIdNo.ValueIsNumeric = False
            Me.cboPayeeIdNo.ValueMember = "IdNo"
            '
            'btnAutoApply
            '
            Me.tlpDisbursement.SetColumnSpan(Me.btnAutoApply, 3)
            Me.btnAutoApply.DesignerSelected = False
            Me.btnAutoApply.DisplayOnly = True
            resources.ApplyResources(Me.btnAutoApply, "btnAutoApply")
            Me.btnAutoApply.ImageIndex = 0
            Me.btnAutoApply.Name = "btnAutoApply"
            Me.btnAutoApply.OriginalImageName = Nothing
            Me.btnAutoApply.SecurityKey = ""
            '
            'DataGridViewDjOiItems
            '
            Me.DataGridViewDjOiItems.AllowUserToAddRows = False
            Me.DataGridViewDjOiItems.AllowUserToDeleteRows = False
            Me.DataGridViewDjOiItems.AllowUserToResizeRows = False
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDjOiItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridViewDjOiItems.AutoGenerateColumns = False
            Me.DataGridViewDjOiItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDjOiItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceDjOi, Me.dgvInvoiceNo, Me.DgvTransactionDate, Me.dgvJournalCode, Me.dgvJournalIdNoAp, Me.dgvPreviousBalance, Me.dgvAmount, Me.dgvDiscountTaken, Me.dgvBalance, Me.DataGridViewTextBoxColumn6, Me.JournalItemIdNo, Me.OpenInvoiceIdNo})
            Me.DataGridViewDjOiItems.DataInGridChanged = False
            Me.DataGridViewDjOiItems.DataSource = Me.bsDjOiItems
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDjOiItems.DefaultCellStyle = DataGridViewCellStyle17
            Me.DataGridViewDjOiItems.DgvFooter = Nothing
            Me.DataGridViewDjOiItems.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewDjOiItems, "DataGridViewDjOiItems")
            Me.DataGridViewDjOiItems.Ea = EventAggregator2
            Me.DataGridViewDjOiItems.EditingMode = False
            Me.DataGridViewDjOiItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewDjOiItems.FirstRowDeletionEnabled = False
            Me.DataGridViewDjOiItems.FirstRowInsertionEnabled = False
            Me.DataGridViewDjOiItems.Name = "DataGridViewDjOiItems"
            Me.DataGridViewDjOiItems.ReadOnly = True
            Me.DataGridViewDjOiItems.SequenceColumn = "dgvSequencePcsOi"
            Me.DataGridViewDjOiItems.SequenceFieldName = "Sequence"
            Me.DataGridViewDjOiItems.ShowFooter = False
            Me.DataGridViewDjOiItems.ShowInsertColumnWhenEditing = False
            Me.DataGridViewDjOiItems.StartTrackingChanges = False
            '
            'dgvSequenceDjOi
            '
            Me.dgvSequenceDjOi.DataPropertyName = "Sequence"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceDjOi.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvSequenceDjOi.DisplayOnly = True
            Me.dgvSequenceDjOi.EditingMode = False
            resources.ApplyResources(Me.dgvSequenceDjOi, "dgvSequenceDjOi")
            Me.dgvSequenceDjOi.Name = "dgvSequenceDjOi"
            Me.dgvSequenceDjOi.ReadOnly = True
            '
            'dgvInvoiceNo
            '
            Me.dgvInvoiceNo.DataPropertyName = "InvoiceNo"
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvInvoiceNo.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvInvoiceNo.EditingMode = False
            resources.ApplyResources(Me.dgvInvoiceNo, "dgvInvoiceNo")
            Me.dgvInvoiceNo.Name = "dgvInvoiceNo"
            Me.dgvInvoiceNo.ReadOnly = True
            Me.dgvInvoiceNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'DgvTransactionDate
            '
            Me.DgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.DgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle10
            Me.DgvTransactionDate.EditingMode = False
            resources.ApplyResources(Me.DgvTransactionDate, "DgvTransactionDate")
            Me.DgvTransactionDate.Name = "DgvTransactionDate"
            Me.DgvTransactionDate.ReadOnly = True
            Me.DgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvJournalCode
            '
            Me.dgvJournalCode.DataPropertyName = "JournalCode"
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalCode.DefaultCellStyle = DataGridViewCellStyle11
            Me.dgvJournalCode.EditingMode = False
            resources.ApplyResources(Me.dgvJournalCode, "dgvJournalCode")
            Me.dgvJournalCode.Name = "dgvJournalCode"
            Me.dgvJournalCode.ReadOnly = True
            Me.dgvJournalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvJournalIdNoAp
            '
            Me.dgvJournalIdNoAp.DataPropertyName = "JournalIdNo"
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalIdNoAp.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvJournalIdNoAp.EditingMode = False
            resources.ApplyResources(Me.dgvJournalIdNoAp, "dgvJournalIdNoAp")
            Me.dgvJournalIdNoAp.Name = "dgvJournalIdNoAp"
            Me.dgvJournalIdNoAp.ReadOnly = True
            Me.dgvJournalIdNoAp.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvPreviousBalance
            '
            Me.dgvPreviousBalance.DataPropertyName = "PreviousBalance"
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.Format = "###,##0.00"
            Me.dgvPreviousBalance.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvPreviousBalance.EditingMode = False
            resources.ApplyResources(Me.dgvPreviousBalance, "dgvPreviousBalance")
            Me.dgvPreviousBalance.Name = "dgvPreviousBalance"
            Me.dgvPreviousBalance.ReadOnly = True
            Me.dgvPreviousBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPreviousBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvAmount
            '
            Me.dgvAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle14.Format = "###,##0.00"
            Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle14
            Me.dgvAmount.EditingMode = False
            resources.ApplyResources(Me.dgvAmount, "dgvAmount")
            Me.dgvAmount.Name = "dgvAmount"
            Me.dgvAmount.ReadOnly = True
            Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvDiscountTaken
            '
            Me.dgvDiscountTaken.DataPropertyName = "DiscountTaken"
            DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle15.Format = "###,##0.00"
            Me.dgvDiscountTaken.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgvDiscountTaken.EditingMode = False
            resources.ApplyResources(Me.dgvDiscountTaken, "dgvDiscountTaken")
            Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
            Me.dgvDiscountTaken.ReadOnly = True
            Me.dgvDiscountTaken.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDiscountTaken.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvBalance
            '
            Me.dgvBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvBalance.DataPropertyName = "Balance"
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle16.Format = "###,##0.00"
            Me.dgvBalance.DefaultCellStyle = DataGridViewCellStyle16
            Me.dgvBalance.EditingMode = False
            resources.ApplyResources(Me.dgvBalance, "dgvBalance")
            Me.dgvBalance.Name = "dgvBalance"
            Me.dgvBalance.ReadOnly = True
            Me.dgvBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "AccountIdNo"
            resources.ApplyResources(Me.DataGridViewTextBoxColumn6, "DataGridViewTextBoxColumn6")
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            '
            'JournalItemIdNo
            '
            Me.JournalItemIdNo.DataPropertyName = "JournalItemIdNo"
            resources.ApplyResources(Me.JournalItemIdNo, "JournalItemIdNo")
            Me.JournalItemIdNo.Name = "JournalItemIdNo"
            Me.JournalItemIdNo.ReadOnly = True
            '
            'OpenInvoiceIdNo
            '
            Me.OpenInvoiceIdNo.DataPropertyName = "OpenInvoiceIdNo"
            resources.ApplyResources(Me.OpenInvoiceIdNo, "OpenInvoiceIdNo")
            Me.OpenInvoiceIdNo.Name = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNo.ReadOnly = True
            '
            'txtPayeeName
            '
            Me.txtPayeeName.BackColor = System.Drawing.Color.White
            Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtPayeeName, 4)
            Me.txtPayeeName.ComputedValue = False
            Me.txtPayeeName.CustomFormat = Nothing
            Me.txtPayeeName.DataBoundControl = True
            Me.txtPayeeName.EditingMode = False
            resources.ApplyResources(Me.txtPayeeName, "txtPayeeName")
            Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
            Me.txtPayeeName.LinkedLabel = Me.lblAmount
            Me.txtPayeeName.MaximumValue = Nothing
            Me.txtPayeeName.MinimumValue = Nothing
            Me.txtPayeeName.Name = "txtPayeeName"
            Me.txtPayeeName.OldValue = Nothing
            Me.txtPayeeName.ReadOnly = True
            Me.txtPayeeName.ValueIsMandatory = True
            '
            'dtpCheckDate
            '
            Me.dtpCheckDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpCheckDate.DefaultValue = Nothing
            Me.dtpCheckDate.DisplayOnly = False
            Me.dtpCheckDate.DtpDefaultValue = Nothing
            Me.dtpCheckDate.EditingMode = False
            Me.dtpCheckDate.EditsAllowed = False
            Me.dtpCheckDate.ForeColor = System.Drawing.Color.Black
            Me.dtpCheckDate.LinkedLabel = Nothing
            resources.ApplyResources(Me.dtpCheckDate, "dtpCheckDate")
            Me.dtpCheckDate.Name = "dtpCheckDate"
            Me.dtpCheckDate.ReadOnlyDp = False
            Me.dtpCheckDate.SecurityKey = Nothing
            Me.dtpCheckDate.ShowLongDate = False
            Me.dtpCheckDate.ShowTime = False
            Me.dtpCheckDate.TargetCalendar = Nothing
            Me.dtpCheckDate.Value = Nothing
            Me.dtpCheckDate.ValueIsMandatory = False
            Me.dtpCheckDate.ValueIsNullable = False
            '
            'lblCheckDate
            '
            Me.lblCheckDate.DisplayOnly = True
            resources.ApplyResources(Me.lblCheckDate, "lblCheckDate")
            Me.lblCheckDate.EditingMode = False
            Me.lblCheckDate.Name = "lblCheckDate"
            '
            'lblVatNo
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblVatNo, 2)
            Me.lblVatNo.DisplayOnly = True
            resources.ApplyResources(Me.lblVatNo, "lblVatNo")
            Me.lblVatNo.EditingMode = False
            Me.lblVatNo.Name = "lblVatNo"
            '
            'txtVatNumber
            '
            Me.txtVatNumber.BackColor = System.Drawing.Color.White
            Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtVatNumber, 2)
            Me.txtVatNumber.ComputedValue = False
            Me.txtVatNumber.CustomFormat = Nothing
            Me.txtVatNumber.DataBoundControl = True
            resources.ApplyResources(Me.txtVatNumber, "txtVatNumber")
            Me.txtVatNumber.EditingMode = False
            Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
            Me.txtVatNumber.LinkedLabel = Me.lblApplied
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.ValueIsMandatory = True
            Me.txtVatNumber.ValueIsNumeric = True
            '
            'txtCheckNumber
            '
            Me.txtCheckNumber.BackColor = System.Drawing.Color.White
            Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCheckNumber.ComputedValue = False
            Me.txtCheckNumber.CustomFormat = Nothing
            Me.txtCheckNumber.DataBoundControl = True
            resources.ApplyResources(Me.txtCheckNumber, "txtCheckNumber")
            Me.txtCheckNumber.EditingMode = False
            Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
            Me.txtCheckNumber.LinkedLabel = Me.lblInvoiceNo
            Me.txtCheckNumber.MaximumValue = Nothing
            Me.txtCheckNumber.MinimumValue = Nothing
            Me.txtCheckNumber.Name = "txtCheckNumber"
            Me.txtCheckNumber.OldValue = Nothing
            Me.txtCheckNumber.ReadOnly = True
            Me.txtCheckNumber.ValueIsMandatory = True
            '
            'lblCheckNumber
            '
            Me.lblCheckNumber.DisplayOnly = True
            resources.ApplyResources(Me.lblCheckNumber, "lblCheckNumber")
            Me.lblCheckNumber.EditingMode = False
            Me.lblCheckNumber.Name = "lblCheckNumber"
            '
            'DisbursementJournalEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.tlpDisbursement)
            Me.Name = "DisbursementJournalEntry"
            Me.Controls.SetChildIndex(Me.tlpDisbursement, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsDjOiItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tlpDisbursement.ResumeLayout(False)
            Me.tlpDisbursement.PerformLayout()
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewDjOiItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout

End Sub
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents bsDjOiItems As Windows.Forms.BindingSource
        Friend WithEvents dgvIdNocadOi As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvJournalItemIdNo As CdgvColumnText
        Friend WithEvents dgvcadIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CkdIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CdgvColumnText
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents tlpDisbursement As TableLayoutPanel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents btnViewGL As CButton
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvColumnMoney
        Friend WithEvents dgvCredit As CdgvColumnMoney
        Friend WithEvents dgvRevCostCenterIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvNotes As CdgvColumnText
        Friend WithEvents DiscountTakenDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents JournalIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OriginalAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PaidAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayeeTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SpecialAccountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents dtpDateCreated As CCustomDateTimePicker
        Friend WithEvents chkCancelled As CCheckBox
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents lblDiscountAccountIdNo As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents cboPaymentType As CaComboBox
        Friend WithEvents lblPaymentType As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents txtJournalCode As CTextBox
        Friend WithEvents lblReferenceNo As CLabel
        Friend WithEvents cboDiscountAccountIdNo As CaComboBox
        Friend WithEvents lblInvoiceNo As CLabel
        Friend WithEvents txtORNumber As CTextBox
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblSupplierIdNo As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents txtVatAmount As CTextBox
        Friend WithEvents lblApplied As CLabel
        Friend WithEvents txtApplied As CTextBox
        Friend WithEvents txtUnapplied As CTextBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents lblVatAmount As CLabel
        Friend WithEvents txtDiscountTaken As CTextBox
        Friend WithEvents lblDiscountTaken As CLabel
        Friend WithEvents cboPayeeIdNo As CaComboBox
        Friend WithEvents btnAutoApply As CButton
        Friend WithEvents DataGridViewDjOiItems As CDataGridView
        Friend WithEvents dgvSequenceDjOi As CdgvColumnText
        Friend WithEvents dgvInvoiceNo As CdgvColumnText
        Friend WithEvents DgvTransactionDate As CdgvColumnText
        Friend WithEvents dgvJournalCode As CdgvColumnText
        Friend WithEvents dgvJournalIdNoAp As CdgvColumnText
        Friend WithEvents dgvPreviousBalance As CdgvColumnMoney
        Friend WithEvents dgvAmount As CdgvColumnMoney
        Friend WithEvents dgvDiscountTaken As CdgvColumnMoney
        Friend WithEvents dgvBalance As CdgvColumnMoney
        Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
        Friend WithEvents JournalItemIdNo As DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNo As DataGridViewTextBoxColumn
        Friend WithEvents txtPayeeName As CTextBox
        Friend WithEvents dtpCheckDate As CCustomDateTimePicker
        Friend WithEvents lblCheckDate As CLabel
        Friend WithEvents lblVatNo As CLabel
        Friend WithEvents txtVatNumber As CTextBox
        Friend WithEvents txtCheckNumber As CTextBox
        Friend WithEvents lblCheckNumber As CLabel
    End Class
End Namespace