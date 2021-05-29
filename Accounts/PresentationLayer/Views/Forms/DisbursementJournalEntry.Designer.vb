Imports AATM.Libraries.CBaseControlsLibrary
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim EventAggregator2 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlpDisbursement = New System.Windows.Forms.TableLayoutPanel()
        Me.cboPayType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPaymentType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.DiscountTakenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JournalIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenInvoiceIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OriginalAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaidAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvVatAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvPayeeType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSpecialAccount = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.AccountNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CancelledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblDiscountAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboDiscountAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtORNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtVatAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblApplied = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtApplied = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtUnapplied = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewDjOiItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequenceDjOi = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.DgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvJournalCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvJournalIdNoAp = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvPreviousBalance = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvDiscountTaken = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvBalance = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsDjOiItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.dtpCheckDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPaymentType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblVatNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        Me.chkPcClosed = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateCreated = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblCdJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCdJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCheckDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnAutoApply = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnPrintCheck = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnPrintPcReplenishment = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tlpDisbursement.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewDjOiItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsDjOiItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
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
        'tlpDisbursement
        '
        Me.tlpDisbursement.BackColor = System.Drawing.Color.Transparent
        Me.tlpDisbursement.ColumnCount = 13
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDisbursement.Controls.Add(Me.cboPayType, 7, 1)
        Me.tlpDisbursement.Controls.Add(Me.lblPayType, 6, 1)
        Me.tlpDisbursement.Controls.Add(Me.DataGridViewJournalItems, 0, 8)
        Me.tlpDisbursement.Controls.Add(Me.lblDiscountAccountIdNo, 0, 5)
        Me.tlpDisbursement.Controls.Add(Me.lblNotes, 0, 6)
        Me.tlpDisbursement.Controls.Add(Me.cboAccountIdNo, 1, 3)
        Me.tlpDisbursement.Controls.Add(Me.lblAccountIdNo, 0, 3)
        Me.tlpDisbursement.Controls.Add(Me.lblPaymentType, 0, 1)
        Me.tlpDisbursement.Controls.Add(Me.txtJournalCode, 1, 0)
        Me.tlpDisbursement.Controls.Add(Me.lblIdNo, 0, 0)
        Me.tlpDisbursement.Controls.Add(Me.cboDiscountAccountIdNo, 1, 5)
        Me.tlpDisbursement.Controls.Add(Me.lblInvoiceNo, 0, 4)
        Me.tlpDisbursement.Controls.Add(Me.txtORNumber, 1, 4)
        Me.tlpDisbursement.Controls.Add(Me.txtAmount, 8, 3)
        Me.tlpDisbursement.Controls.Add(Me.lblAmount, 7, 3)
        Me.tlpDisbursement.Controls.Add(Me.lblTransactionDate, 7, 0)
        Me.tlpDisbursement.Controls.Add(Me.txtNotes, 1, 6)
        Me.tlpDisbursement.Controls.Add(Me.txtVatAmount, 11, 0)
        Me.tlpDisbursement.Controls.Add(Me.txtApplied, 11, 1)
        Me.tlpDisbursement.Controls.Add(Me.txtUnapplied, 11, 2)
        Me.tlpDisbursement.Controls.Add(Me.txtDiscountTaken, 11, 3)
        Me.tlpDisbursement.Controls.Add(Me.lblDiscountTaken, 9, 3)
        Me.tlpDisbursement.Controls.Add(Me.DataGridViewDjOiItems, 0, 9)
        Me.tlpDisbursement.Controls.Add(Me.txtPayeeName, 1, 11)
        Me.tlpDisbursement.Controls.Add(Me.dtpCheckDate, 8, 5)
        Me.tlpDisbursement.Controls.Add(Me.txtVatNumber, 5, 4)
        Me.tlpDisbursement.Controls.Add(Me.txtCheckNumber, 8, 4)
        Me.tlpDisbursement.Controls.Add(Me.lblApplied, 9, 1)
        Me.tlpDisbursement.Controls.Add(Me.lblVatAmount, 9, 0)
        Me.tlpDisbursement.Controls.Add(Me.cboPaymentType, 1, 1)
        Me.tlpDisbursement.Controls.Add(Me.TxtIdNo, 2, 0)
        Me.tlpDisbursement.Controls.Add(Me.txtReferenceNo, 6, 0)
        Me.tlpDisbursement.Controls.Add(Me.cboPayeeIdNo, 1, 2)
        Me.tlpDisbursement.Controls.Add(Me.lblVatNo, 3, 4)
        Me.tlpDisbursement.Controls.Add(Me.lblReferenceNo, 3, 0)
        Me.tlpDisbursement.Controls.Add(Me.dtpTransactionDate, 8, 0)
        Me.tlpDisbursement.Controls.Add(Me.lblSupplierIdNo, 0, 2)
        Me.tlpDisbursement.Controls.Add(Me.CLabel2, 9, 2)
        Me.tlpDisbursement.Controls.Add(Me.chkPosted, 9, 6)
        Me.tlpDisbursement.Controls.Add(Me.chkCancelled, 10, 6)
        Me.tlpDisbursement.Controls.Add(Me.chkPcClosed, 11, 6)
        Me.tlpDisbursement.Controls.Add(Me.lblDateCreated, 9, 5)
        Me.tlpDisbursement.Controls.Add(Me.dtpDateCreated, 10, 5)
        Me.tlpDisbursement.Controls.Add(Me.lblCdJournalIdNo, 9, 4)
        Me.tlpDisbursement.Controls.Add(Me.txtCdJournalIdNo, 11, 4)
        Me.tlpDisbursement.Controls.Add(Me.lblCheckNumber, 6, 4)
        Me.tlpDisbursement.Controls.Add(Me.lblCheckDate, 7, 5)
        Me.tlpDisbursement.Location = New System.Drawing.Point(0, 53)
        Me.tlpDisbursement.Name = "tlpDisbursement"
        Me.tlpDisbursement.Padding = New System.Windows.Forms.Padding(10)
        Me.tlpDisbursement.RowCount = 11
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDisbursement.Size = New System.Drawing.Size(1020, 892)
        Me.tlpDisbursement.TabIndex = 5
        '
        'cboPayType
        '
        Me.cboPayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPayType.BackColor = System.Drawing.Color.White
        Me.cboPayType.BegFindValue = Nothing
        Me.cboPayType.ChangingSearchValueOnly = false
        Me.tlpDisbursement.SetColumnSpan(Me.cboPayType, 2)
        Me.cboPayType.CurrentSearchTerm = ""
        Me.cboPayType.DefaultValue = "0"
        Me.cboPayType.DisplayMember = "Name"
        Me.cboPayType.EditingMode = false
        Me.cboPayType.EndFindValue = Nothing
        Me.cboPayType.FieldDescription = Nothing
        Me.cboPayType.FieldName = Nothing
        Me.cboPayType.FilterRule = Nothing
        Me.cboPayType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPayType.FindEnabled = false
        Me.cboPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPayType.ForeColor = System.Drawing.Color.Black
            Me.cboPayType.HideWhenNotEditingOrAdding = False
            Me.cboPayType.IgnoreCase = False
            Me.cboPayType.IntegralHeight = False
            Me.cboPayType.LinkedLabel = Me.lblPaymentType
            Me.cboPayType.Location = New System.Drawing.Point(550, 38)
            Me.cboPayType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayType.Name = "cboPayType"
            Me.cboPayType.OldValue = 0
            Me.cboPayType.OriginalDataSource = Nothing
            Me.cboPayType.OriginalList = Nothing
            Me.cboPayType.OverrideDropDownStyleList = False
            Me.cboPayType.PreviousSearchTerm = Nothing
            Me.cboPayType.PropertySelector = Nothing
            Me.cboPayType.ReadOnlyCombo = False
            Me.cboPayType.Size = New System.Drawing.Size(215, 24)
            Me.cboPayType.SuggestBoxHeight = 200
            Me.cboPayType.SuggestListOrderRule = Nothing
            Me.cboPayType.TabIndex = 5
            Me.cboPayType.TextToSearch = Nothing
            Me.cboPayType.Translatable = False
            Me.cboPayType.ValueIsMandatory = False
            Me.cboPayType.ValueIsNullable = False
            Me.cboPayType.ValueIsNumeric = False
            Me.cboPayType.ValueMember = "Code"
            '
            'lblPaymentType
            '
            Me.lblPaymentType.DisplayOnly = True
            Me.lblPaymentType.EditingMode = False
            Me.lblPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPaymentType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPaymentType.Location = New System.Drawing.Point(11, 38)
            Me.lblPaymentType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPaymentType.Name = "lblPaymentType"
            Me.lblPaymentType.Size = New System.Drawing.Size(115, 23)
            Me.lblPaymentType.TabIndex = 257
            Me.lblPaymentType.Text = "Payee Type:"
            Me.lblPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPaymentType.Translatable = True
            '
            'lblPayType
            '
            Me.lblPayType.DisplayOnly = True
            Me.lblPayType.EditingMode = False
            Me.lblPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPayType.Location = New System.Drawing.Point(459, 38)
            Me.lblPayType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayType.Name = "lblPayType"
            Me.lblPayType.Size = New System.Drawing.Size(89, 25)
            Me.lblPayType.TabIndex = 292
            Me.lblPayType.Text = "Pay Type:"
            Me.lblPayType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayType.Translatable = True
            '
            'DataGridViewJournalItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewJournalItems.AutoGenerateColumns = False
            Me.DataGridViewJournalItems.BegFindValue = Nothing
            Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.DiscountTakenDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OpenInvoiceIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PaidAmountDataGridViewTextBoxColumn, Me.dgvVatAmount, Me.dgvPayeeType, Me.dgvSpecialAccount, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn})
            Me.tlpDisbursement.SetColumnSpan(Me.DataGridViewJournalItems, 12)
            Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewJournalItems.DefaultCellStyle = DataGridViewCellStyle10
            Me.DataGridViewJournalItems.DgvFooter = Nothing
            Me.DataGridViewJournalItems.DisplayOnly = False
            Me.DataGridViewJournalItems.Ea = EventAggregator1
            Me.DataGridViewJournalItems.EditingMode = False
            Me.DataGridViewJournalItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewJournalItems.EndFindValue = Nothing
            Me.DataGridViewJournalItems.FieldDescription = Nothing
            Me.DataGridViewJournalItems.FieldName = Nothing
            Me.DataGridViewJournalItems.FieldsDictionary = Nothing
            Me.DataGridViewJournalItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewJournalItems.FindEnabled = False
            Me.DataGridViewJournalItems.FirstRowDeletionEnabled = False
            Me.DataGridViewJournalItems.FirstRowInsertionEnabled = False
            Me.DataGridViewJournalItems.IgnoreCase = False
            Me.DataGridViewJournalItems.Location = New System.Drawing.Point(13, 203)
            Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
            Me.DataGridViewJournalItems.ReadOnly = True
            Me.DataGridViewJournalItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
            Me.DataGridViewJournalItems.ShowFooter = False
            Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = True
            Me.DataGridViewJournalItems.Size = New System.Drawing.Size(996, 325)
            Me.DataGridViewJournalItems.TabIndex = 15
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
            Me.dgvSequence.Frozen = True
            Me.dgvSequence.HeaderText = "Seq"
            Me.dgvSequence.IgnoreCase = False
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.dgvSequence.Translatable = False
            Me.dgvSequence.Width = 30
            '
            'dgvAccountIdNo
            '
            Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvAccountIdNo.EditingMode = False
            Me.dgvAccountIdNo.Frozen = True
            Me.dgvAccountIdNo.HeaderText = "Account Code-Name"
            Me.dgvAccountIdNo.MinimumWidth = 200
            Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
            Me.dgvAccountIdNo.ReadOnly = True
            Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAccountIdNo.Translatable = False
            Me.dgvAccountIdNo.Width = 220
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
            Me.dgvDebit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDebit.FindEnabled = False
            Me.dgvDebit.HeaderText = "Debit"
            Me.dgvDebit.MinimumWidth = 90
            Me.dgvDebit.Name = "dgvDebit"
            Me.dgvDebit.ReadOnly = True
            Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDebit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDebit.Translatable = False
            Me.dgvDebit.Width = 90
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
            Me.dgvCredit.MinimumWidth = 90
            Me.dgvCredit.Name = "dgvCredit"
            Me.dgvCredit.ReadOnly = True
            Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCredit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvCredit.Translatable = False
            Me.dgvCredit.Width = 90
            '
            'dgvRevCostCenterIdNo
            '
            Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvRevCostCenterIdNo.EditingMode = False
            Me.dgvRevCostCenterIdNo.HeaderText = "Revenue/Cost Center Code-Name"
            Me.dgvRevCostCenterIdNo.MinimumWidth = 150
            Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
            Me.dgvRevCostCenterIdNo.ReadOnly = True
            Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvRevCostCenterIdNo.Translatable = False
            Me.dgvRevCostCenterIdNo.Width = 150
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
            Me.dgvNotes.HeaderText = "Notes / Description"
            Me.dgvNotes.IgnoreCase = False
            Me.dgvNotes.MinimumWidth = 150
            Me.dgvNotes.Name = "dgvNotes"
            Me.dgvNotes.ReadOnly = True
            Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvNotes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.dgvNotes.Translatable = False
            '
            'DiscountTakenDataGridViewTextBoxColumn
            '
            Me.DiscountTakenDataGridViewTextBoxColumn.DataPropertyName = "DiscountTaken"
            Me.DiscountTakenDataGridViewTextBoxColumn.HeaderText = "DiscountTaken"
            Me.DiscountTakenDataGridViewTextBoxColumn.Name = "DiscountTakenDataGridViewTextBoxColumn"
            Me.DiscountTakenDataGridViewTextBoxColumn.ReadOnly = True
            Me.DiscountTakenDataGridViewTextBoxColumn.Visible = False
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn.Visible = False
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
            'PaidAmountDataGridViewTextBoxColumn
            '
            Me.PaidAmountDataGridViewTextBoxColumn.DataPropertyName = "PaidAmount"
            Me.PaidAmountDataGridViewTextBoxColumn.HeaderText = "PaidAmount"
            Me.PaidAmountDataGridViewTextBoxColumn.Name = "PaidAmountDataGridViewTextBoxColumn"
            Me.PaidAmountDataGridViewTextBoxColumn.ReadOnly = True
            Me.PaidAmountDataGridViewTextBoxColumn.Visible = False
            '
            'dgvVatAmount
            '
            Me.dgvVatAmount.BegFindValue = Nothing
            Me.dgvVatAmount.DataPropertyName = "AccountIdNo"
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.Format = "###,##0.00"
            Me.dgvVatAmount.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvVatAmount.EditingMode = False
            Me.dgvVatAmount.EndFindValue = Nothing
            Me.dgvVatAmount.FieldDescription = Nothing
            Me.dgvVatAmount.FieldName = Nothing
            Me.dgvVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvVatAmount.FindEnabled = False
            Me.dgvVatAmount.HeaderText = "Vat Amount"
            Me.dgvVatAmount.Name = "dgvVatAmount"
            Me.dgvVatAmount.ReadOnly = True
            Me.dgvVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvVatAmount.Translatable = False
            Me.dgvVatAmount.Visible = False
            '
            'dgvPayeeType
            '
            Me.dgvPayeeType.DataPropertyName = "PayeeType"
            Me.dgvPayeeType.HeaderText = "PayeeType"
            Me.dgvPayeeType.Name = "dgvPayeeType"
            Me.dgvPayeeType.ReadOnly = True
            Me.dgvPayeeType.Visible = False
            '
            'dgvSpecialAccount
            '
            Me.dgvSpecialAccount.BegFindValue = Nothing
            Me.dgvSpecialAccount.DataPropertyName = "SpecialAccount"
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvSpecialAccount.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvSpecialAccount.EditingMode = False
            Me.dgvSpecialAccount.EndFindValue = Nothing
            Me.dgvSpecialAccount.FieldDescription = Nothing
            Me.dgvSpecialAccount.FieldName = Nothing
            Me.dgvSpecialAccount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSpecialAccount.FindEnabled = False
            Me.dgvSpecialAccount.HeaderText = "SpecialAccount"
            Me.dgvSpecialAccount.IgnoreCase = False
            Me.dgvSpecialAccount.Name = "dgvSpecialAccount"
            Me.dgvSpecialAccount.ReadOnly = True
            Me.dgvSpecialAccount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSpecialAccount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSpecialAccount.Translatable = False
            Me.dgvSpecialAccount.Visible = False
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
            'bsJournalItems
            '
            Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
            '
            'lblDiscountAccountIdNo
            '
            Me.lblDiscountAccountIdNo.DisplayOnly = True
            Me.lblDiscountAccountIdNo.EditingMode = False
            Me.lblDiscountAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDiscountAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDiscountAccountIdNo.Location = New System.Drawing.Point(11, 147)
            Me.lblDiscountAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDiscountAccountIdNo.Name = "lblDiscountAccountIdNo"
            Me.lblDiscountAccountIdNo.Size = New System.Drawing.Size(115, 24)
            Me.lblDiscountAccountIdNo.TabIndex = 281
            Me.lblDiscountAccountIdNo.Text = "Discount Acct."
            Me.lblDiscountAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDiscountAccountIdNo.Translatable = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(11, 174)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(115, 23)
            Me.lblNotes.TabIndex = 161
            Me.lblNotes.Text = "Description/Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNotes.Translatable = True
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.BegFindValue = Nothing
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboAccountIdNo, 6)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = ""
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.EndFindValue = Nothing
            Me.cboAccountIdNo.FieldDescription = Nothing
            Me.cboAccountIdNo.FieldName = Nothing
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAccountIdNo.FindEnabled = False
            Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IgnoreCase = False
            Me.cboAccountIdNo.IntegralHeight = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
            Me.cboAccountIdNo.Location = New System.Drawing.Point(128, 92)
            Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.Size = New System.Drawing.Size(420, 24)
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TabIndex = 7
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.Translatable = False
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAccountIdNo.Location = New System.Drawing.Point(11, 92)
            Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Size = New System.Drawing.Size(115, 18)
            Me.lblAccountIdNo.TabIndex = 266
            Me.lblAccountIdNo.Text = "Acct. to Credit:"
            Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAccountIdNo.Translatable = True
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
            Me.txtJournalCode.Location = New System.Drawing.Point(128, 11)
            Me.txtJournalCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtJournalCode.MaximumValue = Nothing
            Me.txtJournalCode.MinimumValue = Nothing
            Me.txtJournalCode.Name = "txtJournalCode"
            Me.txtJournalCode.OldValue = Nothing
            Me.txtJournalCode.ReadOnly = True
            Me.txtJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalCode.Size = New System.Drawing.Size(28, 23)
            Me.txtJournalCode.TabIndex = 0
            Me.txtJournalCode.TabStop = False
            Me.txtJournalCode.Text = "PC"
            Me.txtJournalCode.Translatable = False
            Me.txtJournalCode.ValueIsMandatory = True
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
            Me.lblIdNo.Size = New System.Drawing.Size(115, 23)
            Me.lblIdNo.TabIndex = 17
            Me.lblIdNo.Text = "Transaction No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'cboDiscountAccountIdNo
            '
            Me.cboDiscountAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboDiscountAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboDiscountAccountIdNo.BegFindValue = Nothing
            Me.cboDiscountAccountIdNo.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboDiscountAccountIdNo, 6)
            Me.cboDiscountAccountIdNo.CurrentSearchTerm = ""
            Me.cboDiscountAccountIdNo.DefaultValue = Nothing
            Me.cboDiscountAccountIdNo.DisplayMember = "Name"
            Me.cboDiscountAccountIdNo.EditingMode = False
            Me.cboDiscountAccountIdNo.EndFindValue = Nothing
            Me.cboDiscountAccountIdNo.FieldDescription = Nothing
            Me.cboDiscountAccountIdNo.FieldName = Nothing
            Me.cboDiscountAccountIdNo.FilterRule = Nothing
            Me.cboDiscountAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDiscountAccountIdNo.FindEnabled = False
            Me.cboDiscountAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDiscountAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboDiscountAccountIdNo.FormattingEnabled = True
            Me.cboDiscountAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboDiscountAccountIdNo.IgnoreCase = False
            Me.cboDiscountAccountIdNo.IntegralHeight = False
            Me.cboDiscountAccountIdNo.ItemHeight = 16
            Me.cboDiscountAccountIdNo.LinkedLabel = Nothing
            Me.cboDiscountAccountIdNo.Location = New System.Drawing.Point(128, 147)
            Me.cboDiscountAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDiscountAccountIdNo.Name = "cboDiscountAccountIdNo"
            Me.cboDiscountAccountIdNo.OldValue = 0
            Me.cboDiscountAccountIdNo.OriginalDataSource = Nothing
            Me.cboDiscountAccountIdNo.OriginalList = Nothing
            Me.cboDiscountAccountIdNo.OverrideDropDownStyleList = False
            Me.cboDiscountAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboDiscountAccountIdNo.PropertySelector = Nothing
            Me.cboDiscountAccountIdNo.ReadOnlyCombo = False
            Me.cboDiscountAccountIdNo.Size = New System.Drawing.Size(420, 24)
            Me.cboDiscountAccountIdNo.SuggestBoxHeight = 200
            Me.cboDiscountAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboDiscountAccountIdNo.TabIndex = 12
            Me.cboDiscountAccountIdNo.TextToSearch = Nothing
            Me.cboDiscountAccountIdNo.Translatable = False
            Me.cboDiscountAccountIdNo.ValueIsMandatory = False
            Me.cboDiscountAccountIdNo.ValueIsNullable = False
            Me.cboDiscountAccountIdNo.ValueIsNumeric = False
            Me.cboDiscountAccountIdNo.ValueMember = "IdNo"
            '
            'lblInvoiceNo
            '
            Me.lblInvoiceNo.DisplayOnly = True
            Me.lblInvoiceNo.EditingMode = False
            Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceNo.Location = New System.Drawing.Point(11, 118)
            Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            Me.lblInvoiceNo.Size = New System.Drawing.Size(94, 18)
            Me.lblInvoiceNo.TabIndex = 254
            Me.lblInvoiceNo.Text = "Inv./O.R. No."
            Me.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblInvoiceNo.Translatable = True
            '
            'txtORNumber
            '
            Me.txtORNumber.BackColor = System.Drawing.Color.White
            Me.txtORNumber.BegFindValue = Nothing
            Me.txtORNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtORNumber, 2)
            Me.txtORNumber.ComputedValue = False
            Me.txtORNumber.CustomFormat = Nothing
            Me.txtORNumber.DataBoundControl = True
            Me.txtORNumber.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtORNumber.EditingMode = False
            Me.txtORNumber.EndFindValue = Nothing
            Me.txtORNumber.FieldDescription = Nothing
            Me.txtORNumber.FieldName = Nothing
            Me.txtORNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtORNumber.FindEnabled = True
            Me.txtORNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtORNumber.ForeColor = System.Drawing.Color.Black
            Me.txtORNumber.LinkedLabel = Me.lblInvoiceNo
            Me.txtORNumber.Location = New System.Drawing.Point(128, 118)
            Me.txtORNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtORNumber.MaximumValue = Nothing
            Me.txtORNumber.MinimumValue = Nothing
            Me.txtORNumber.Name = "txtORNumber"
            Me.txtORNumber.OldValue = Nothing
            Me.txtORNumber.ReadOnly = True
            Me.txtORNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtORNumber.Size = New System.Drawing.Size(120, 23)
            Me.txtORNumber.TabIndex = 9
            Me.txtORNumber.Translatable = False
            Me.txtORNumber.ValueIsMandatory = True
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BegFindValue = Nothing
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = "N2"
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
            Me.txtAmount.Location = New System.Drawing.Point(653, 92)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Size = New System.Drawing.Size(112, 23)
            Me.txtAmount.TabIndex = 8
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.Translatable = False
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(550, 92)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(101, 24)
            Me.lblAmount.TabIndex = 264
            Me.lblAmount.Text = "Amount:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblAmount.Translatable = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionDate.Location = New System.Drawing.Point(550, 11)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(101, 25)
            Me.lblTransactionDate.TabIndex = 4
            Me.lblTransactionDate.Text = "Date:"
            Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblTransactionDate.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtNotes, 8)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(128, 174)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(637, 25)
            Me.txtNotes.TabIndex = 14
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'txtVatAmount
            '
            Me.txtVatAmount.BackColor = System.Drawing.Color.White
            Me.txtVatAmount.BegFindValue = Nothing
            Me.txtVatAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtVatAmount, 2)
            Me.txtVatAmount.ComputedValue = False
            Me.txtVatAmount.CustomFormat = "N2"
            Me.txtVatAmount.DataBoundControl = True
            Me.txtVatAmount.DisplayOnly = True
            Me.txtVatAmount.EditingMode = True
            Me.txtVatAmount.EndFindValue = Nothing
            Me.txtVatAmount.FieldDescription = Nothing
            Me.txtVatAmount.FieldName = Nothing
            Me.txtVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVatAmount.FindEnabled = True
            Me.txtVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
            Me.txtVatAmount.LinkedLabel = Me.lblApplied
            Me.txtVatAmount.Location = New System.Drawing.Point(926, 11)
            Me.txtVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatAmount.MaximumValue = Nothing
            Me.txtVatAmount.MinimumValue = Nothing
            Me.txtVatAmount.Name = "txtVatAmount"
            Me.txtVatAmount.OldValue = Nothing
            Me.txtVatAmount.ReadOnly = True
            Me.txtVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatAmount.Size = New System.Drawing.Size(83, 23)
            Me.txtVatAmount.TabIndex = 17
            Me.txtVatAmount.TabStop = False
            Me.txtVatAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtVatAmount.Translatable = False
            Me.txtVatAmount.ValueIsMandatory = True
            Me.txtVatAmount.ValueIsNumeric = True
            '
            'lblApplied
            '
            Me.lblApplied.AutoSize = True
            Me.tlpDisbursement.SetColumnSpan(Me.lblApplied, 2)
            Me.lblApplied.DisplayOnly = True
            Me.lblApplied.EditingMode = False
            Me.lblApplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblApplied.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblApplied.Location = New System.Drawing.Point(767, 38)
            Me.lblApplied.Margin = New System.Windows.Forms.Padding(1)
            Me.lblApplied.Name = "lblApplied"
            Me.lblApplied.Size = New System.Drawing.Size(107, 17)
            Me.lblApplied.TabIndex = 277
            Me.lblApplied.Text = "Applied Amount"
            Me.lblApplied.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblApplied.Translatable = True
            '
            'txtApplied
            '
            Me.txtApplied.BackColor = System.Drawing.Color.White
            Me.txtApplied.BegFindValue = Nothing
            Me.txtApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtApplied, 2)
            Me.txtApplied.ComputedValue = False
            Me.txtApplied.CustomFormat = "N2"
            Me.txtApplied.DataBoundControl = True
            Me.txtApplied.DisplayOnly = True
            Me.txtApplied.EditingMode = True
            Me.txtApplied.EndFindValue = Nothing
            Me.txtApplied.FieldDescription = Nothing
            Me.txtApplied.FieldName = Nothing
            Me.txtApplied.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtApplied.FindEnabled = True
            Me.txtApplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtApplied.ForeColor = System.Drawing.Color.Black
            Me.txtApplied.LinkedLabel = Me.lblApplied
            Me.txtApplied.Location = New System.Drawing.Point(926, 38)
            Me.txtApplied.Margin = New System.Windows.Forms.Padding(1)
            Me.txtApplied.MaximumValue = Nothing
            Me.txtApplied.MinimumValue = Nothing
            Me.txtApplied.Name = "txtApplied"
            Me.txtApplied.OldValue = Nothing
            Me.txtApplied.ReadOnly = True
            Me.txtApplied.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtApplied.Size = New System.Drawing.Size(83, 23)
            Me.txtApplied.TabIndex = 18
            Me.txtApplied.TabStop = False
            Me.txtApplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtApplied.Translatable = False
            Me.txtApplied.ValueIsMandatory = True
            Me.txtApplied.ValueIsNumeric = True
            '
            'txtUnapplied
            '
            Me.txtUnapplied.BackColor = System.Drawing.Color.White
            Me.txtUnapplied.BegFindValue = Nothing
            Me.txtUnapplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUnapplied.ComputedValue = False
            Me.txtUnapplied.CustomFormat = "N2"
            Me.txtUnapplied.DataBoundControl = True
            Me.txtUnapplied.DisplayOnly = True
            Me.txtUnapplied.EditingMode = True
            Me.txtUnapplied.EndFindValue = Nothing
            Me.txtUnapplied.FieldDescription = Nothing
            Me.txtUnapplied.FieldName = Nothing
            Me.txtUnapplied.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtUnapplied.FindEnabled = True
            Me.txtUnapplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtUnapplied.ForeColor = System.Drawing.Color.Black
            Me.txtUnapplied.LinkedLabel = Me.CLabel2
            Me.txtUnapplied.Location = New System.Drawing.Point(926, 65)
            Me.txtUnapplied.Margin = New System.Windows.Forms.Padding(1)
            Me.txtUnapplied.MaximumValue = Nothing
            Me.txtUnapplied.MinimumValue = Nothing
            Me.txtUnapplied.Name = "txtUnapplied"
            Me.txtUnapplied.OldValue = Nothing
            Me.txtUnapplied.ReadOnly = True
            Me.txtUnapplied.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtUnapplied.Size = New System.Drawing.Size(83, 23)
            Me.txtUnapplied.TabIndex = 19
            Me.txtUnapplied.TabStop = False
            Me.txtUnapplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtUnapplied.Translatable = False
            Me.txtUnapplied.ValueIsMandatory = True
            Me.txtUnapplied.ValueIsNumeric = True
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.tlpDisbursement.SetColumnSpan(Me.CLabel2, 2)
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel2.Location = New System.Drawing.Point(767, 65)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(124, 17)
            Me.CLabel2.TabIndex = 279
            Me.CLabel2.Text = "Unapplied Amount"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'txtDiscountTaken
            '
            Me.txtDiscountTaken.BackColor = System.Drawing.Color.White
            Me.txtDiscountTaken.BegFindValue = Nothing
            Me.txtDiscountTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtDiscountTaken, 2)
            Me.txtDiscountTaken.ComputedValue = False
            Me.txtDiscountTaken.CustomFormat = "N2"
            Me.txtDiscountTaken.DataBoundControl = True
            Me.txtDiscountTaken.DisplayOnly = True
            Me.txtDiscountTaken.EditingMode = True
            Me.txtDiscountTaken.EndFindValue = Nothing
            Me.txtDiscountTaken.FieldDescription = Nothing
            Me.txtDiscountTaken.FieldName = Nothing
            Me.txtDiscountTaken.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDiscountTaken.FindEnabled = True
            Me.txtDiscountTaken.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDiscountTaken.ForeColor = System.Drawing.Color.Black
            Me.txtDiscountTaken.LinkedLabel = Me.lblDiscountTaken
            Me.txtDiscountTaken.Location = New System.Drawing.Point(926, 92)
            Me.txtDiscountTaken.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDiscountTaken.MaximumValue = Nothing
            Me.txtDiscountTaken.MinimumValue = Nothing
            Me.txtDiscountTaken.Name = "txtDiscountTaken"
            Me.txtDiscountTaken.OldValue = Nothing
            Me.txtDiscountTaken.ReadOnly = True
            Me.txtDiscountTaken.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDiscountTaken.Size = New System.Drawing.Size(83, 23)
            Me.txtDiscountTaken.TabIndex = 20
            Me.txtDiscountTaken.TabStop = False
            Me.txtDiscountTaken.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtDiscountTaken.Translatable = False
            Me.txtDiscountTaken.ValueIsMandatory = True
            Me.txtDiscountTaken.ValueIsNumeric = True
            '
            'lblDiscountTaken
            '
            Me.lblDiscountTaken.AutoSize = True
            Me.tlpDisbursement.SetColumnSpan(Me.lblDiscountTaken, 2)
            Me.lblDiscountTaken.DisplayOnly = True
            Me.lblDiscountTaken.EditingMode = False
            Me.lblDiscountTaken.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDiscountTaken.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDiscountTaken.Location = New System.Drawing.Point(767, 92)
            Me.lblDiscountTaken.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDiscountTaken.Name = "lblDiscountTaken"
            Me.lblDiscountTaken.Size = New System.Drawing.Size(107, 17)
            Me.lblDiscountTaken.TabIndex = 275
            Me.lblDiscountTaken.Text = "Discount Taken"
            Me.lblDiscountTaken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDiscountTaken.Translatable = True
            '
            'DataGridViewDjOiItems
            '
            Me.DataGridViewDjOiItems.AllowUserToAddRows = False
            Me.DataGridViewDjOiItems.AllowUserToDeleteRows = False
            Me.DataGridViewDjOiItems.AllowUserToResizeRows = False
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDjOiItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
            Me.DataGridViewDjOiItems.AutoGenerateColumns = False
            Me.DataGridViewDjOiItems.BegFindValue = Nothing
            Me.DataGridViewDjOiItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDjOiItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceDjOi, Me.dgvInvoiceNo, Me.DgvTransactionDate, Me.dgvJournalCode, Me.dgvJournalIdNoAp, Me.dgvPreviousBalance, Me.dgvAmount, Me.dgvDiscountTaken, Me.dgvBalance, Me.DataGridViewTextBoxColumn6})
            Me.tlpDisbursement.SetColumnSpan(Me.DataGridViewDjOiItems, 12)
            Me.DataGridViewDjOiItems.DataSource = Me.bsDjOiItems
            DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDjOiItems.DefaultCellStyle = DataGridViewCellStyle21
            Me.DataGridViewDjOiItems.DgvFooter = Nothing
            Me.DataGridViewDjOiItems.DisplayOnly = False
            Me.DataGridViewDjOiItems.Ea = EventAggregator2
            Me.DataGridViewDjOiItems.EditingMode = False
            Me.DataGridViewDjOiItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewDjOiItems.EndFindValue = Nothing
            Me.DataGridViewDjOiItems.FieldDescription = Nothing
            Me.DataGridViewDjOiItems.FieldName = Nothing
            Me.DataGridViewDjOiItems.FieldsDictionary = Nothing
            Me.DataGridViewDjOiItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewDjOiItems.FindEnabled = False
            Me.DataGridViewDjOiItems.FirstRowDeletionEnabled = False
            Me.DataGridViewDjOiItems.FirstRowInsertionEnabled = False
            Me.DataGridViewDjOiItems.IgnoreCase = False
            Me.DataGridViewDjOiItems.Location = New System.Drawing.Point(13, 534)
            Me.DataGridViewDjOiItems.MinimumSize = New System.Drawing.Size(996, 325)
            Me.DataGridViewDjOiItems.Name = "DataGridViewDjOiItems"
            Me.DataGridViewDjOiItems.ReadOnly = True
            Me.DataGridViewDjOiItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewDjOiItems.SequenceColumn = "dgvSequencePcsOi"
            Me.DataGridViewDjOiItems.SequenceFieldName = "Sequence"
            Me.DataGridViewDjOiItems.ShowFooter = False
            Me.DataGridViewDjOiItems.ShowInsertColumnWhenEditing = False
            Me.DataGridViewDjOiItems.Size = New System.Drawing.Size(996, 325)
            Me.DataGridViewDjOiItems.TabIndex = 16
            Me.DataGridViewDjOiItems.Translatable = True
            Me.DataGridViewDjOiItems.Visible = False
            '
            'dgvSequenceDjOi
            '
            Me.dgvSequenceDjOi.BegFindValue = Nothing
            Me.dgvSequenceDjOi.DataPropertyName = "Sequence"
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceDjOi.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvSequenceDjOi.DisplayOnly = True
            Me.dgvSequenceDjOi.EditingMode = False
            Me.dgvSequenceDjOi.EndFindValue = Nothing
            Me.dgvSequenceDjOi.FieldDescription = Nothing
            Me.dgvSequenceDjOi.FieldName = Nothing
            Me.dgvSequenceDjOi.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequenceDjOi.FindEnabled = False
            Me.dgvSequenceDjOi.HeaderText = "Seq"
            Me.dgvSequenceDjOi.IgnoreCase = False
            Me.dgvSequenceDjOi.Name = "dgvSequenceDjOi"
            Me.dgvSequenceDjOi.ReadOnly = True
            Me.dgvSequenceDjOi.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequenceDjOi.Translatable = False
            Me.dgvSequenceDjOi.Width = 40
            '
            'dgvInvoiceNo
            '
            Me.dgvInvoiceNo.BegFindValue = Nothing
            Me.dgvInvoiceNo.DataPropertyName = "InvoiceNo"
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            Me.dgvInvoiceNo.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvInvoiceNo.EditingMode = False
            Me.dgvInvoiceNo.EndFindValue = Nothing
            Me.dgvInvoiceNo.FieldDescription = Nothing
            Me.dgvInvoiceNo.FieldName = Nothing
            Me.dgvInvoiceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvInvoiceNo.FindEnabled = False
            Me.dgvInvoiceNo.HeaderText = "Invoice No."
            Me.dgvInvoiceNo.IgnoreCase = False
            Me.dgvInvoiceNo.Name = "dgvInvoiceNo"
            Me.dgvInvoiceNo.ReadOnly = True
            Me.dgvInvoiceNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvInvoiceNo.Translatable = False
            '
            'DgvTransactionDate
            '
            Me.DgvTransactionDate.BegFindValue = Nothing
            Me.DgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            Me.DgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle14
            Me.DgvTransactionDate.EditingMode = False
            Me.DgvTransactionDate.EndFindValue = Nothing
            Me.DgvTransactionDate.FieldDescription = Nothing
            Me.DgvTransactionDate.FieldName = Nothing
            Me.DgvTransactionDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DgvTransactionDate.FindEnabled = False
            Me.DgvTransactionDate.HeaderText = "Transaction Date"
            Me.DgvTransactionDate.IgnoreCase = False
            Me.DgvTransactionDate.Name = "DgvTransactionDate"
            Me.DgvTransactionDate.ReadOnly = True
            Me.DgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DgvTransactionDate.Translatable = False
            '
            'dgvJournalCode
            '
            Me.dgvJournalCode.BegFindValue = Nothing
            Me.dgvJournalCode.DataPropertyName = "JournalCode"
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalCode.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgvJournalCode.EditingMode = False
            Me.dgvJournalCode.EndFindValue = Nothing
            Me.dgvJournalCode.FieldDescription = Nothing
            Me.dgvJournalCode.FieldName = Nothing
            Me.dgvJournalCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvJournalCode.FindEnabled = False
            Me.dgvJournalCode.HeaderText = "Journal Code"
            Me.dgvJournalCode.IgnoreCase = False
            Me.dgvJournalCode.Name = "dgvJournalCode"
            Me.dgvJournalCode.ReadOnly = True
            Me.dgvJournalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvJournalCode.Translatable = False
            Me.dgvJournalCode.Width = 50
            '
            'dgvJournalIdNoAp
            '
            Me.dgvJournalIdNoAp.BegFindValue = Nothing
            Me.dgvJournalIdNoAp.DataPropertyName = "JournalIdNo"
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalIdNoAp.DefaultCellStyle = DataGridViewCellStyle16
            Me.dgvJournalIdNoAp.EditingMode = False
            Me.dgvJournalIdNoAp.EndFindValue = Nothing
            Me.dgvJournalIdNoAp.FieldDescription = Nothing
            Me.dgvJournalIdNoAp.FieldName = Nothing
            Me.dgvJournalIdNoAp.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvJournalIdNoAp.FindEnabled = False
            Me.dgvJournalIdNoAp.HeaderText = "Journal Id No"
            Me.dgvJournalIdNoAp.IgnoreCase = False
            Me.dgvJournalIdNoAp.Name = "dgvJournalIdNoAp"
            Me.dgvJournalIdNoAp.ReadOnly = True
            Me.dgvJournalIdNoAp.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvJournalIdNoAp.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvJournalIdNoAp.Translatable = False
            '
            'dgvPreviousBalance
            '
            Me.dgvPreviousBalance.BegFindValue = Nothing
            Me.dgvPreviousBalance.DataPropertyName = "PreviousBalance"
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle17.Format = "###,##0.00"
            Me.dgvPreviousBalance.DefaultCellStyle = DataGridViewCellStyle17
            Me.dgvPreviousBalance.EditingMode = False
            Me.dgvPreviousBalance.EndFindValue = Nothing
            Me.dgvPreviousBalance.FieldDescription = Nothing
            Me.dgvPreviousBalance.FieldName = Nothing
            Me.dgvPreviousBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPreviousBalance.FindEnabled = False
            Me.dgvPreviousBalance.HeaderText = "Previous Balance"
            Me.dgvPreviousBalance.Name = "dgvPreviousBalance"
            Me.dgvPreviousBalance.ReadOnly = True
            Me.dgvPreviousBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPreviousBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPreviousBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvPreviousBalance.Translatable = False
            '
            'dgvAmount
            '
            Me.dgvAmount.BegFindValue = Nothing
            Me.dgvAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle18.Format = "###,##0.00"
            Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle18
            Me.dgvAmount.EditingMode = False
            Me.dgvAmount.EndFindValue = Nothing
            Me.dgvAmount.FieldDescription = Nothing
            Me.dgvAmount.FieldName = Nothing
            Me.dgvAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvAmount.FindEnabled = False
            Me.dgvAmount.HeaderText = "Amount"
            Me.dgvAmount.Name = "dgvAmount"
            Me.dgvAmount.ReadOnly = True
            Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvAmount.Translatable = False
            '
            'dgvDiscountTaken
            '
            Me.dgvDiscountTaken.BegFindValue = Nothing
            Me.dgvDiscountTaken.DataPropertyName = "DiscountTaken"
            DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle19.Format = "###,##0.00"
            Me.dgvDiscountTaken.DefaultCellStyle = DataGridViewCellStyle19
            Me.dgvDiscountTaken.EditingMode = False
            Me.dgvDiscountTaken.EndFindValue = Nothing
            Me.dgvDiscountTaken.FieldDescription = Nothing
            Me.dgvDiscountTaken.FieldName = Nothing
            Me.dgvDiscountTaken.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDiscountTaken.FindEnabled = False
            Me.dgvDiscountTaken.HeaderText = "Discount Taken"
            Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
            Me.dgvDiscountTaken.ReadOnly = True
            Me.dgvDiscountTaken.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDiscountTaken.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDiscountTaken.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDiscountTaken.Translatable = False
            '
            'dgvBalance
            '
            Me.dgvBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvBalance.BegFindValue = Nothing
            Me.dgvBalance.DataPropertyName = "Balance"
            DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle20.Format = "###,##0.00"
            Me.dgvBalance.DefaultCellStyle = DataGridViewCellStyle20
            Me.dgvBalance.EditingMode = False
            Me.dgvBalance.EndFindValue = Nothing
            Me.dgvBalance.FieldDescription = Nothing
            Me.dgvBalance.FieldName = Nothing
            Me.dgvBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvBalance.FindEnabled = False
            Me.dgvBalance.HeaderText = "Balance"
            Me.dgvBalance.Name = "dgvBalance"
            Me.dgvBalance.ReadOnly = True
            Me.dgvBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvBalance.Translatable = False
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "AccountIdNo"
            Me.DataGridViewTextBoxColumn6.HeaderText = "AccountIdNo"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            Me.DataGridViewTextBoxColumn6.Visible = False
            '
            'bsDjOiItems
            '
            Me.bsDjOiItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DjOiItemModel)
            '
            'txtPayeeName
            '
            Me.txtPayeeName.BackColor = System.Drawing.Color.White
            Me.txtPayeeName.BegFindValue = Nothing
            Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtPayeeName, 8)
            Me.txtPayeeName.ComputedValue = False
            Me.txtPayeeName.CustomFormat = Nothing
            Me.txtPayeeName.DataBoundControl = True
            Me.txtPayeeName.EditingMode = False
            Me.txtPayeeName.EndFindValue = Nothing
            Me.txtPayeeName.FieldDescription = Nothing
            Me.txtPayeeName.FieldName = Nothing
            Me.txtPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayeeName.FindEnabled = False
            Me.txtPayeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
            Me.txtPayeeName.LinkedLabel = Me.lblAmount
            Me.txtPayeeName.Location = New System.Drawing.Point(128, 863)
            Me.txtPayeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayeeName.MaximumValue = Nothing
            Me.txtPayeeName.MinimumValue = Nothing
            Me.txtPayeeName.Name = "txtPayeeName"
            Me.txtPayeeName.OldValue = Nothing
            Me.txtPayeeName.ReadOnly = True
            Me.txtPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayeeName.Size = New System.Drawing.Size(637, 23)
            Me.txtPayeeName.TabIndex = 6
            Me.txtPayeeName.Translatable = False
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
            Me.dtpCheckDate.Location = New System.Drawing.Point(653, 147)
            Me.dtpCheckDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpCheckDate.Name = "dtpCheckDate"
            Me.dtpCheckDate.ReadOnlyDp = False
            Me.dtpCheckDate.SecurityKey = Nothing
            Me.dtpCheckDate.ShowLongDate = False
            Me.dtpCheckDate.ShowTime = False
            Me.dtpCheckDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpCheckDate.TabIndex = 13
            Me.dtpCheckDate.TargetCalendar = Nothing
            Me.dtpCheckDate.Translatable = False
            Me.dtpCheckDate.Value = Nothing
            Me.dtpCheckDate.ValueIsMandatory = False
            Me.dtpCheckDate.ValueIsNullable = False
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
            Me.txtVatNumber.LinkedLabel = Me.lblApplied
            Me.txtVatNumber.Location = New System.Drawing.Point(343, 118)
            Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MaxLength = 15
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatNumber.Size = New System.Drawing.Size(114, 23)
            Me.txtVatNumber.TabIndex = 10
            Me.txtVatNumber.Translatable = False
            Me.txtVatNumber.ValueIsMandatory = True
            Me.txtVatNumber.ValueIsNumeric = True
            '
            'txtCheckNumber
            '
            Me.txtCheckNumber.BackColor = System.Drawing.Color.White
            Me.txtCheckNumber.BegFindValue = Nothing
            Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCheckNumber.ComputedValue = False
            Me.txtCheckNumber.CustomFormat = Nothing
            Me.txtCheckNumber.DataBoundControl = True
            Me.txtCheckNumber.EditingMode = False
            Me.txtCheckNumber.EndFindValue = Nothing
            Me.txtCheckNumber.FieldDescription = Nothing
            Me.txtCheckNumber.FieldName = Nothing
            Me.txtCheckNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCheckNumber.FindEnabled = True
            Me.txtCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
            Me.txtCheckNumber.LinkedLabel = Me.lblInvoiceNo
            Me.txtCheckNumber.Location = New System.Drawing.Point(653, 118)
            Me.txtCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCheckNumber.MaximumValue = Nothing
            Me.txtCheckNumber.MinimumValue = Nothing
            Me.txtCheckNumber.Name = "txtCheckNumber"
            Me.txtCheckNumber.OldValue = Nothing
            Me.txtCheckNumber.ReadOnly = True
            Me.txtCheckNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCheckNumber.Size = New System.Drawing.Size(112, 23)
            Me.txtCheckNumber.TabIndex = 11
            Me.txtCheckNumber.Translatable = False
            Me.txtCheckNumber.ValueIsMandatory = True
            '
            'lblVatAmount
            '
            Me.lblVatAmount.AutoSize = True
            Me.tlpDisbursement.SetColumnSpan(Me.lblVatAmount, 2)
            Me.lblVatAmount.DisplayOnly = True
            Me.lblVatAmount.EditingMode = False
            Me.lblVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatAmount.Location = New System.Drawing.Point(767, 11)
            Me.lblVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatAmount.Name = "lblVatAmount"
            Me.lblVatAmount.Size = New System.Drawing.Size(81, 17)
            Me.lblVatAmount.TabIndex = 283
            Me.lblVatAmount.Text = "Vat Amount"
            Me.lblVatAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblVatAmount.Translatable = True
            '
            'cboPaymentType
            '
            Me.cboPaymentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPaymentType.BackColor = System.Drawing.Color.White
            Me.cboPaymentType.BegFindValue = Nothing
            Me.cboPaymentType.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPaymentType, 5)
            Me.cboPaymentType.CurrentSearchTerm = ""
            Me.cboPaymentType.DefaultValue = "0"
            Me.cboPaymentType.DisplayMember = "Name"
            Me.cboPaymentType.EditingMode = False
            Me.cboPaymentType.EndFindValue = Nothing
            Me.cboPaymentType.FieldDescription = Nothing
            Me.cboPaymentType.FieldName = Nothing
            Me.cboPaymentType.FilterRule = Nothing
            Me.cboPaymentType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPaymentType.FindEnabled = False
            Me.cboPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPaymentType.ForeColor = System.Drawing.Color.Black
            Me.cboPaymentType.HideWhenNotEditingOrAdding = False
            Me.cboPaymentType.IgnoreCase = False
            Me.cboPaymentType.IntegralHeight = False
            Me.cboPaymentType.LinkedLabel = Me.lblPaymentType
            Me.cboPaymentType.Location = New System.Drawing.Point(128, 38)
            Me.cboPaymentType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPaymentType.Name = "cboPaymentType"
            Me.cboPaymentType.OldValue = 0
            Me.cboPaymentType.OriginalDataSource = Nothing
            Me.cboPaymentType.OriginalList = Nothing
            Me.cboPaymentType.OverrideDropDownStyleList = False
            Me.cboPaymentType.PreviousSearchTerm = Nothing
            Me.cboPaymentType.PropertySelector = Nothing
            Me.cboPaymentType.ReadOnlyCombo = False
            Me.cboPaymentType.Size = New System.Drawing.Size(329, 24)
            Me.cboPaymentType.SuggestBoxHeight = 200
            Me.cboPaymentType.SuggestListOrderRule = Nothing
            Me.cboPaymentType.TabIndex = 4
            Me.cboPaymentType.TextToSearch = Nothing
            Me.cboPaymentType.Translatable = False
            Me.cboPaymentType.ValueIsMandatory = False
            Me.cboPaymentType.ValueIsNullable = False
            Me.cboPaymentType.ValueIsNumeric = False
            Me.cboPaymentType.ValueMember = "Code"
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
            Me.TxtIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(158, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(90, 23)
            Me.TxtIdNo.TabIndex = 1
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
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
            Me.txtReferenceNo.Location = New System.Drawing.Point(459, 11)
            Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.ReadOnly = True
            Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReferenceNo.Size = New System.Drawing.Size(89, 23)
            Me.txtReferenceNo.TabIndex = 2
            Me.txtReferenceNo.Translatable = False
            Me.txtReferenceNo.ValueIsMandatory = True
            '
            'lblReferenceNo
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblReferenceNo, 3)
            Me.lblReferenceNo.DisplayOnly = True
            Me.lblReferenceNo.EditingMode = False
            Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReferenceNo.Location = New System.Drawing.Point(250, 11)
            Me.lblReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReferenceNo.Name = "lblReferenceNo"
            Me.lblReferenceNo.Size = New System.Drawing.Size(207, 25)
            Me.lblReferenceNo.TabIndex = 2
            Me.lblReferenceNo.Text = "Reference No.:"
            Me.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblReferenceNo.Translatable = True
            '
            'cboPayeeIdNo
            '
            Me.cboPayeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayeeIdNo.BegFindValue = Nothing
            Me.cboPayeeIdNo.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPayeeIdNo, 8)
            Me.cboPayeeIdNo.CurrentSearchTerm = ""
            Me.cboPayeeIdNo.DefaultValue = Nothing
            Me.cboPayeeIdNo.DisplayMember = "Name"
            Me.cboPayeeIdNo.EditingMode = True
            Me.cboPayeeIdNo.EndFindValue = Nothing
            Me.cboPayeeIdNo.FieldDescription = Nothing
            Me.cboPayeeIdNo.FieldName = Nothing
            Me.cboPayeeIdNo.FilterRule = Nothing
            Me.cboPayeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayeeIdNo.FindEnabled = False
            Me.cboPayeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayeeIdNo.FormattingEnabled = True
            Me.cboPayeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayeeIdNo.IgnoreCase = False
            Me.cboPayeeIdNo.IntegralHeight = False
            Me.cboPayeeIdNo.LinkedLabel = Nothing
            Me.cboPayeeIdNo.Location = New System.Drawing.Point(128, 65)
            Me.cboPayeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayeeIdNo.Name = "cboPayeeIdNo"
            Me.cboPayeeIdNo.OldValue = 0
            Me.cboPayeeIdNo.OriginalDataSource = Nothing
            Me.cboPayeeIdNo.OriginalList = Nothing
            Me.cboPayeeIdNo.OverrideDropDownStyleList = False
            Me.cboPayeeIdNo.PreviousSearchTerm = Nothing
            Me.cboPayeeIdNo.PropertySelector = Nothing
            Me.cboPayeeIdNo.ReadOnlyCombo = False
            Me.cboPayeeIdNo.Size = New System.Drawing.Size(637, 24)
            Me.cboPayeeIdNo.SuggestBoxHeight = 200
            Me.cboPayeeIdNo.SuggestListOrderRule = Nothing
            Me.cboPayeeIdNo.TabIndex = 6
            Me.cboPayeeIdNo.TextToSearch = Nothing
            Me.cboPayeeIdNo.Translatable = False
            Me.cboPayeeIdNo.ValueIsMandatory = False
            Me.cboPayeeIdNo.ValueIsNullable = False
            Me.cboPayeeIdNo.ValueIsNumeric = False
            Me.cboPayeeIdNo.ValueMember = "IdNo"
            '
            'lblVatNo
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblVatNo, 2)
            Me.lblVatNo.DisplayOnly = True
            Me.lblVatNo.EditingMode = False
            Me.lblVatNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatNo.Location = New System.Drawing.Point(250, 118)
            Me.lblVatNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatNo.Name = "lblVatNo"
            Me.lblVatNo.Size = New System.Drawing.Size(91, 27)
            Me.lblVatNo.TabIndex = 2
            Me.lblVatNo.Text = "Vat Number"
            Me.lblVatNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblVatNo.Translatable = True
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(653, 11)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpTransactionDate.TabIndex = 3
            Me.dtpTransactionDate.TargetCalendar = Nothing
            Me.dtpTransactionDate.Translatable = False
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
            Me.lblSupplierIdNo.Location = New System.Drawing.Point(11, 65)
            Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            Me.lblSupplierIdNo.Size = New System.Drawing.Size(115, 25)
            Me.lblSupplierIdNo.TabIndex = 7
            Me.lblSupplierIdNo.Text = "Payee:"
            Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierIdNo.Translatable = True
            '
            'chkPosted
            '
            Me.chkPosted.AutoCheck = False
            Me.chkPosted.AutoSize = True
            Me.chkPosted.BackColor = System.Drawing.Color.Transparent
            Me.chkPosted.BegFindValue = Nothing
            Me.chkPosted.DisplayOnly = True
            Me.chkPosted.EditingMode = True
            Me.chkPosted.EndFindValue = Nothing
            Me.chkPosted.FieldDescription = Nothing
            Me.chkPosted.FieldName = Nothing
            Me.chkPosted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkPosted.FindEnabled = False
            Me.chkPosted.FlatAppearance.BorderSize = 0
            Me.chkPosted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.chkPosted.ForeColor = System.Drawing.Color.Black
            Me.chkPosted.IFindableControl_FindEnabled = False
            Me.chkPosted.IgnoreCase = False
            Me.chkPosted.LinkedLabel = Nothing
            Me.chkPosted.Location = New System.Drawing.Point(767, 174)
            Me.chkPosted.Margin = New System.Windows.Forms.Padding(1)
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.OldValue = Nothing
            Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkPosted.Size = New System.Drawing.Size(68, 21)
            Me.chkPosted.TabIndex = 293
            Me.chkPosted.TabStop = False
            Me.chkPosted.Text = "Posted"
            Me.chkPosted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkPosted.Translatable = True
            Me.chkPosted.UseVisualStyleBackColor = False
            '
            'chkCancelled
            '
            Me.chkCancelled.AutoCheck = False
            Me.chkCancelled.AutoSize = True
            Me.chkCancelled.BackColor = System.Drawing.Color.Transparent
            Me.chkCancelled.BegFindValue = Nothing
            Me.chkCancelled.DisplayOnly = True
            Me.chkCancelled.EditingMode = True
            Me.chkCancelled.EndFindValue = Nothing
            Me.chkCancelled.FieldDescription = Nothing
            Me.chkCancelled.FieldName = Nothing
            Me.chkCancelled.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkCancelled.FindEnabled = False
            Me.chkCancelled.FlatAppearance.BorderSize = 0
            Me.chkCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.chkCancelled.ForeColor = System.Drawing.Color.Black
            Me.chkCancelled.IFindableControl_FindEnabled = False
            Me.chkCancelled.IgnoreCase = False
            Me.chkCancelled.LinkedLabel = Nothing
            Me.chkCancelled.Location = New System.Drawing.Point(838, 174)
            Me.chkCancelled.Margin = New System.Windows.Forms.Padding(1)
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.OldValue = Nothing
            Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkCancelled.Size = New System.Drawing.Size(86, 21)
            Me.chkCancelled.TabIndex = 294
            Me.chkCancelled.TabStop = False
            Me.chkCancelled.Text = "Cancelled"
            Me.chkCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkCancelled.Translatable = True
            Me.chkCancelled.UseVisualStyleBackColor = False
            '
            'chkPcClosed
            '
            Me.chkPcClosed.AutoCheck = False
            Me.chkPcClosed.AutoSize = True
            Me.chkPcClosed.BackColor = System.Drawing.Color.Transparent
            Me.chkPcClosed.BegFindValue = Nothing
            Me.chkPcClosed.DisplayOnly = True
            Me.chkPcClosed.EditingMode = True
            Me.chkPcClosed.EndFindValue = Nothing
            Me.chkPcClosed.FieldDescription = Nothing
            Me.chkPcClosed.FieldName = Nothing
            Me.chkPcClosed.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkPcClosed.FindEnabled = False
            Me.chkPcClosed.FlatAppearance.BorderSize = 0
            Me.chkPcClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPcClosed.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.chkPcClosed.ForeColor = System.Drawing.Color.Black
            Me.chkPcClosed.IFindableControl_FindEnabled = False
            Me.chkPcClosed.IgnoreCase = False
            Me.chkPcClosed.LinkedLabel = Nothing
            Me.chkPcClosed.Location = New System.Drawing.Point(926, 174)
            Me.chkPcClosed.Margin = New System.Windows.Forms.Padding(1)
            Me.chkPcClosed.Name = "chkPcClosed"
            Me.chkPcClosed.OldValue = Nothing
            Me.chkPcClosed.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
            Me.chkPcClosed.Size = New System.Drawing.Size(75, 21)
            Me.chkPcClosed.TabIndex = 295
            Me.chkPcClosed.TabStop = False
            Me.chkPcClosed.Text = "Closed?"
            Me.chkPcClosed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkPcClosed.Translatable = True
            Me.chkPcClosed.UseVisualStyleBackColor = False
            '
            'lblDateCreated
            '
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            Me.lblDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.lblDateCreated.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateCreated.Location = New System.Drawing.Point(767, 147)
            Me.lblDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDateCreated.Name = "lblDateCreated"
            Me.lblDateCreated.Size = New System.Drawing.Size(69, 25)
            Me.lblDateCreated.TabIndex = 268
            Me.lblDateCreated.Text = "Date Added:"
            Me.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDateCreated.Translatable = True
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
            Me.dtpDateCreated.Location = New System.Drawing.Point(847, 147)
            Me.dtpDateCreated.Margin = New System.Windows.Forms.Padding(10, 1, 1, 1)
            Me.dtpDateCreated.Name = "dtpDateCreated"
            Me.dtpDateCreated.ReadOnlyDp = True
            Me.dtpDateCreated.SecurityKey = Nothing
            Me.dtpDateCreated.ShowLongDate = False
            Me.dtpDateCreated.ShowTime = True
            Me.dtpDateCreated.Size = New System.Drawing.Size(146, 25)
            Me.dtpDateCreated.TabIndex = 24
            Me.dtpDateCreated.TabStop = False
            Me.dtpDateCreated.TargetCalendar = Nothing
            Me.dtpDateCreated.Translatable = False
            Me.dtpDateCreated.Value = Nothing
            Me.dtpDateCreated.ValueIsMandatory = False
            Me.dtpDateCreated.ValueIsNullable = False
            '
            'lblCdJournalIdNo
            '
            Me.lblCdJournalIdNo.AutoSize = True
            Me.tlpDisbursement.SetColumnSpan(Me.lblCdJournalIdNo, 2)
            Me.lblCdJournalIdNo.DisplayOnly = True
            Me.lblCdJournalIdNo.EditingMode = False
            Me.lblCdJournalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCdJournalIdNo.Location = New System.Drawing.Point(767, 118)
            Me.lblCdJournalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCdJournalIdNo.Name = "lblCdJournalIdNo"
            Me.lblCdJournalIdNo.Size = New System.Drawing.Size(121, 17)
            Me.lblCdJournalIdNo.TabIndex = 296
            Me.lblCdJournalIdNo.Text = "Disbursement No."
            Me.lblCdJournalIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCdJournalIdNo.Translatable = True
            '
            'txtCdJournalIdNo
            '
            Me.txtCdJournalIdNo.BackColor = System.Drawing.Color.White
            Me.txtCdJournalIdNo.BegFindValue = Nothing
            Me.txtCdJournalIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCdJournalIdNo.ComputedValue = False
            Me.txtCdJournalIdNo.CustomFormat = Nothing
            Me.txtCdJournalIdNo.DataBoundControl = True
            Me.txtCdJournalIdNo.EditingMode = True
            Me.txtCdJournalIdNo.EndFindValue = Nothing
            Me.txtCdJournalIdNo.FieldDescription = Nothing
            Me.txtCdJournalIdNo.FieldName = Nothing
            Me.txtCdJournalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCdJournalIdNo.FindEnabled = True
            Me.txtCdJournalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCdJournalIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtCdJournalIdNo.LinkedLabel = Nothing
            Me.txtCdJournalIdNo.Location = New System.Drawing.Point(926, 118)
            Me.txtCdJournalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCdJournalIdNo.MaximumValue = Nothing
            Me.txtCdJournalIdNo.MinimumValue = Nothing
            Me.txtCdJournalIdNo.Name = "txtCdJournalIdNo"
            Me.txtCdJournalIdNo.OldValue = Nothing
            Me.txtCdJournalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCdJournalIdNo.Size = New System.Drawing.Size(83, 23)
            Me.txtCdJournalIdNo.TabIndex = 297
            Me.txtCdJournalIdNo.TabStop = False
            Me.txtCdJournalIdNo.Translatable = False
            '
            'lblCheckNumber
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblCheckNumber, 2)
            Me.lblCheckNumber.DisplayOnly = True
            Me.lblCheckNumber.EditingMode = False
            Me.lblCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCheckNumber.Location = New System.Drawing.Point(459, 118)
            Me.lblCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckNumber.Name = "lblCheckNumber"
            Me.lblCheckNumber.Size = New System.Drawing.Size(192, 27)
            Me.lblCheckNumber.TabIndex = 290
            Me.lblCheckNumber.Text = "Check Number"
            Me.lblCheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblCheckNumber.Translatable = True
            '
            'lblCheckDate
            '
            Me.lblCheckDate.DisplayOnly = True
            Me.lblCheckDate.EditingMode = False
            Me.lblCheckDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCheckDate.Location = New System.Drawing.Point(550, 147)
            Me.lblCheckDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckDate.Name = "lblCheckDate"
            Me.lblCheckDate.Size = New System.Drawing.Size(101, 25)
            Me.lblCheckDate.TabIndex = 284
            Me.lblCheckDate.Text = "Check Date"
            Me.lblCheckDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblCheckDate.Translatable = True
            '
            'btnViewGL
            '
            Me.btnViewGL.DesignerSelected = False
            Me.btnViewGL.DisplayOnly = True
            Me.btnViewGL.Font = New System.Drawing.Font("Tahoma", 8.0!)
            Me.btnViewGL.ImageIndex = 0
            Me.btnViewGL.Location = New System.Drawing.Point(3, 3)
            Me.btnViewGL.Name = "btnViewGL"
            Me.btnViewGL.OriginalImageName = Nothing
            Me.btnViewGL.SecurityKey = ""
            Me.btnViewGL.Size = New System.Drawing.Size(141, 25)
            Me.btnViewGL.TabIndex = 24
            Me.btnViewGL.TabStop = False
            Me.btnViewGL.Text = "View Journal Entry"
            '
            'btnAutoApply
            '
            Me.btnAutoApply.DesignerSelected = False
            Me.btnAutoApply.DisplayOnly = True
            Me.btnAutoApply.Font = New System.Drawing.Font("Tahoma", 8.0!)
            Me.btnAutoApply.ImageIndex = 0
            Me.btnAutoApply.Location = New System.Drawing.Point(150, 3)
            Me.btnAutoApply.Name = "btnAutoApply"
            Me.btnAutoApply.OriginalImageName = Nothing
            Me.btnAutoApply.SecurityKey = ""
            Me.btnAutoApply.Size = New System.Drawing.Size(132, 25)
            Me.btnAutoApply.TabIndex = 25
            Me.btnAutoApply.TabStop = False
            Me.btnAutoApply.Text = "Auto Apply Invoices"
            '
            'btnPrintCheck
            '
            Me.btnPrintCheck.DesignerSelected = False
            Me.btnPrintCheck.DisplayOnly = True
            Me.btnPrintCheck.ImageIndex = 0
            Me.btnPrintCheck.Location = New System.Drawing.Point(288, 3)
            Me.btnPrintCheck.Name = "btnPrintCheck"
            Me.btnPrintCheck.OriginalImageName = Nothing
            Me.btnPrintCheck.SecurityKey = ""
            Me.btnPrintCheck.Size = New System.Drawing.Size(151, 25)
            Me.btnPrintCheck.TabIndex = 291
            Me.btnPrintCheck.TabStop = False
            Me.btnPrintCheck.Text = "Print Check"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.btnViewGL)
            Me.CFlowLayout1.Controls.Add(Me.btnAutoApply)
            Me.CFlowLayout1.Controls.Add(Me.btnPrintCheck)
            Me.CFlowLayout1.Controls.Add(Me.btnPrintPcReplenishment)
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.CFlowLayout1.Location = New System.Drawing.Point(0, 943)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(1021, 27)
            Me.CFlowLayout1.TabIndex = 6
            '
            'btnPrintPcReplenishment
            '
            Me.btnPrintPcReplenishment.DesignerSelected = False
            Me.btnPrintPcReplenishment.DisplayOnly = True
            Me.btnPrintPcReplenishment.ImageIndex = 0
            Me.btnPrintPcReplenishment.Location = New System.Drawing.Point(445, 3)
            Me.btnPrintPcReplenishment.Name = "btnPrintPcReplenishment"
            Me.btnPrintPcReplenishment.OriginalImageName = Nothing
            Me.btnPrintPcReplenishment.SecurityKey = ""
            Me.btnPrintPcReplenishment.Size = New System.Drawing.Size(285, 25)
            Me.btnPrintPcReplenishment.TabIndex = 292
            Me.btnPrintPcReplenishment.Text = "Print Petty Cash Replenishment Report"
            '
            'DisbursementJournalEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(1021, 970)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.tlpDisbursement)
            Me.DefaultFormBackColor = System.Drawing.Color.Transparent
            Me.MinimumSize = New System.Drawing.Size(1037, 590)
            Me.Name = "DisbursementJournalEntry"
            Me.Text = "Petty Cash Journal "
        Me.Controls.SetChildIndex(Me.tlpDisbursement, 0)
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.tlpDisbursement.ResumeLayout(false)
        Me.tlpDisbursement.PerformLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewDjOiItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsDjOiItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsJournalItems As Windows.Forms.BindingSource
        Friend WithEvents bsDjOiItems As Windows.Forms.BindingSource
        Friend WithEvents dgvIdNocadOi As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvJournalItemIdNo As CDgvTextColumn
        Friend WithEvents dgvcadIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CkdIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents tlpDisbursement As TableLayoutPanel
        Friend WithEvents btnViewGL As CButton
        Friend WithEvents DataGridViewJournalItems As CDataGridView
        Friend WithEvents lblDateCreated As CLabel
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
        Friend WithEvents btnAutoApply As CButton
        Friend WithEvents DataGridViewDjOiItems As CDataGridView
        Friend WithEvents dgvSequenceDjOi As CDgvTextColumn
        Friend WithEvents dgvInvoiceNo As CDgvTextColumn
        Friend WithEvents DgvTransactionDate As CDgvTextColumn
        Friend WithEvents dgvJournalCode As CDgvTextColumn
        Friend WithEvents dgvJournalIdNoAp As CDgvTextColumn
        Friend WithEvents dgvPreviousBalance As CdgvMoneyColumn
        Friend WithEvents dgvAmount As CdgvMoneyColumn
        Friend WithEvents dgvDiscountTaken As CdgvMoneyColumn
        Friend WithEvents dgvBalance As CdgvMoneyColumn
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
        Friend WithEvents btnPrintCheck As CButton
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents cboPayeeIdNo As CaComboBox
        Friend WithEvents dtpDateCreated As CCustomDateTimePicker
        Friend WithEvents cboPayType As CaComboBox
        Friend WithEvents lblPayType As CLabel
        Friend WithEvents chkPosted As CCheckBoxNew
        Friend WithEvents chkCancelled As CCheckBoxNew
        Friend WithEvents chkPcClosed As CCheckBoxNew
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents lblCdJournalIdNo As CLabel
        Friend WithEvents txtCdJournalIdNo As CTextBox
        Friend WithEvents btnPrintPcReplenishment As CButton
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvAccountIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvMoneyColumn
        Friend WithEvents dgvCredit As CdgvMoneyColumn
        Friend WithEvents dgvRevCostCenterIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvNotes As CDgvTextColumn
        Friend WithEvents DiscountTakenDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents JournalIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OriginalAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PaidAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvVatAmount As CdgvMoneyColumn
        Friend WithEvents dgvPayeeType As DataGridViewTextBoxColumn
        Friend WithEvents dgvSpecialAccount As CDgvTextColumn
        Friend WithEvents AccountNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    End Class
End Namespace