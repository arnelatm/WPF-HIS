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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlpDisbursement = New System.Windows.Forms.TableLayoutPanel()
        Me.chkPcClosed = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.cboPayType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPaymentType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewJournalItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
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
        Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateCreated = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblCdJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCdJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCheckDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkApproved = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
        Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnAutoApply = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnPrintCheck = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnPrintPcReplenishment = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.bsJournalItems = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvDebit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvCredit = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvRevCostCenterIdNo = New AATM.Libraries.CBaseControlsLibrary.CdDgvComboBoxColumn()
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
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tlpDisbursement.SuspendLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewDjOiItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsDjOiItems,System.ComponentModel.ISupportInitialize).BeginInit
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
        Me.tlpDisbursement.Controls.Add(Me.chkPcClosed, 10, 6)
        Me.tlpDisbursement.Controls.Add(Me.chkPosted, 9, 6)
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
        Me.tlpDisbursement.Controls.Add(Me.lblDateCreated, 9, 5)
        Me.tlpDisbursement.Controls.Add(Me.dtpDateCreated, 10, 5)
        Me.tlpDisbursement.Controls.Add(Me.lblCdJournalIdNo, 9, 4)
        Me.tlpDisbursement.Controls.Add(Me.txtCdJournalIdNo, 11, 4)
        Me.tlpDisbursement.Controls.Add(Me.lblCheckNumber, 6, 4)
        Me.tlpDisbursement.Controls.Add(Me.lblCheckDate, 7, 5)
        Me.tlpDisbursement.Controls.Add(Me.chkApproved, 8, 6)
        Me.tlpDisbursement.Controls.Add(Me.chkCancelled, 11, 6)
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
        Me.tlpDisbursement.Size = New System.Drawing.Size(1020, 1004)
        Me.tlpDisbursement.TabIndex = 5
        '
        'chkPcClosed
        '
        Me.chkPcClosed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.chkPcClosed.BackColor = System.Drawing.Color.Transparent
        Me.chkPcClosed.BegFindValue = Nothing
        Me.chkPcClosed.Checked = false
        Me.chkPcClosed.DisplayOnly = true
        Me.chkPcClosed.EditingMode = false
        Me.chkPcClosed.EndFindValue = Nothing
        Me.chkPcClosed.FieldDescription = Nothing
        Me.chkPcClosed.FieldName = Nothing
        Me.chkPcClosed.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkPcClosed.FindEnabled = true
        Me.chkPcClosed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkPcClosed.IgnoreCase = false
        Me.chkPcClosed.LinkedLabel = Nothing
        Me.chkPcClosed.Location = New System.Drawing.Point(856, 176)
        Me.chkPcClosed.Name = "chkPcClosed"
        Me.chkPcClosed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPcClosed.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkPcClosed.Size = New System.Drawing.Size(67, 21)
        Me.chkPcClosed.TabIndex = 300
        Me.chkPcClosed.Text = "Closed?"
        Me.chkPcClosed.Translatable = true
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
        Me.chkPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkPosted.IgnoreCase = false
        Me.chkPosted.LinkedLabel = Nothing
        Me.chkPosted.Location = New System.Drawing.Point(771, 176)
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkPosted.Size = New System.Drawing.Size(79, 21)
        Me.chkPosted.TabIndex = 299
        Me.chkPosted.Text = "Posted?"
        Me.chkPosted.Translatable = true
        '
        'cboPayType
        '
        Me.cboPayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPayType.BackColor = System.Drawing.Color.White
        Me.cboPayType.BegFindValue = Nothing
        Me.cboPayType.ChangingSearchValueOnly = false
        Me.tlpDisbursement.SetColumnSpan(Me.cboPayType, 2)
        Me.cboPayType.CurrentSearchTerm = ""
        Me.cboPayType.DataValue = Nothing
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
        Me.cboPayType.HideWhenNotEditingOrAdding = false
        Me.cboPayType.IgnoreCase = false
        Me.cboPayType.IntegralHeight = false
        Me.cboPayType.LinkedLabel = Me.lblPaymentType
        Me.cboPayType.Location = New System.Drawing.Point(550, 38)
        Me.cboPayType.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPayType.Name = "cboPayType"
        Me.cboPayType.OldValue = 0
        Me.cboPayType.OriginalDataSource = Nothing
        Me.cboPayType.OriginalList = Nothing
        Me.cboPayType.OverrideDropDownStyleList = false
        Me.cboPayType.PreviousSearchTerm = Nothing
        Me.cboPayType.PropertySelector = Nothing
        Me.cboPayType.ReadOnlyCombo = false
        Me.cboPayType.Size = New System.Drawing.Size(215, 24)
        Me.cboPayType.SuggestBoxHeight = 200
        Me.cboPayType.SuggestListOrderRule = Nothing
        Me.cboPayType.TabIndex = 5
        Me.cboPayType.TextToSearch = Nothing
        Me.cboPayType.Translatable = false
        Me.cboPayType.ValueIsMandatory = false
        Me.cboPayType.ValueIsNullable = false
        Me.cboPayType.ValueIsNumeric = false
        Me.cboPayType.ValueMember = "Code"
        '
        'lblPaymentType
        '
        Me.lblPaymentType.DisplayOnly = true
        Me.lblPaymentType.EditingMode = false
        Me.lblPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPaymentType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPaymentType.Location = New System.Drawing.Point(11, 38)
        Me.lblPaymentType.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPaymentType.Name = "lblPaymentType"
        Me.lblPaymentType.Size = New System.Drawing.Size(115, 23)
        Me.lblPaymentType.TabIndex = 257
        Me.lblPaymentType.Text = "Payee Type:"
        Me.lblPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPaymentType.Translatable = true
        '
        'lblPayType
        '
        Me.lblPayType.DisplayOnly = true
        Me.lblPayType.EditingMode = false
        Me.lblPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPayType.Location = New System.Drawing.Point(459, 38)
        Me.lblPayType.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayType.Name = "lblPayType"
        Me.lblPayType.Size = New System.Drawing.Size(89, 25)
        Me.lblPayType.TabIndex = 292
        Me.lblPayType.Text = "Pay Type:"
        Me.lblPayType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPayType.Translatable = true
        '
        'DataGridViewJournalItems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewJournalItems.AutoGenerateColumns = false
        Me.DataGridViewJournalItems.BegFindValue = Nothing
        Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.DiscountTakenDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OpenInvoiceIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PaidAmountDataGridViewTextBoxColumn, Me.dgvVatAmount, Me.dgvPayeeType, Me.dgvSpecialAccount, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn})
        Me.tlpDisbursement.SetColumnSpan(Me.DataGridViewJournalItems, 12)
        Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewJournalItems.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewJournalItems.DgvFooter = Nothing
        Me.DataGridViewJournalItems.DisplayOnly = false
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
        Me.DataGridViewJournalItems.Location = New System.Drawing.Point(13, 203)
        Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
        Me.DataGridViewJournalItems.ReadOnly = true
        Me.DataGridViewJournalItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewJournalItems.SecurityKey = ""
        Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
        Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
        Me.DataGridViewJournalItems.ShowFooter = false
        Me.DataGridViewJournalItems.ShowInsertColumnWhenEditing = true
        Me.DataGridViewJournalItems.Size = New System.Drawing.Size(996, 340)
        Me.DataGridViewJournalItems.TabIndex = 15
        Me.DataGridViewJournalItems.Translatable = true
        '
        'lblDiscountAccountIdNo
        '
        Me.lblDiscountAccountIdNo.DisplayOnly = true
        Me.lblDiscountAccountIdNo.EditingMode = false
        Me.lblDiscountAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDiscountAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDiscountAccountIdNo.Location = New System.Drawing.Point(11, 147)
        Me.lblDiscountAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDiscountAccountIdNo.Name = "lblDiscountAccountIdNo"
        Me.lblDiscountAccountIdNo.Size = New System.Drawing.Size(115, 24)
        Me.lblDiscountAccountIdNo.TabIndex = 281
        Me.lblDiscountAccountIdNo.Text = "Discount Acct."
        Me.lblDiscountAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDiscountAccountIdNo.Translatable = true
        '
        'lblNotes
        '
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNotes.Location = New System.Drawing.Point(11, 174)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(115, 23)
        Me.lblNotes.TabIndex = 161
        Me.lblNotes.Text = "Description/Notes"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNotes.Translatable = true
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.BegFindValue = Nothing
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.tlpDisbursement.SetColumnSpan(Me.cboAccountIdNo, 6)
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.DataValue = Nothing
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
        Me.cboAccountIdNo.Location = New System.Drawing.Point(128, 92)
        Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.OverrideDropDownStyleList = false
        Me.cboAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboAccountIdNo.PropertySelector = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.Size = New System.Drawing.Size(420, 24)
        Me.cboAccountIdNo.SuggestBoxHeight = 200
        Me.cboAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboAccountIdNo.TabIndex = 7
        Me.cboAccountIdNo.TextToSearch = Nothing
        Me.cboAccountIdNo.Translatable = false
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        Me.cboAccountIdNo.ValueMember = "IdNo"
        '
        'lblAccountIdNo
        '
        Me.lblAccountIdNo.DisplayOnly = true
        Me.lblAccountIdNo.EditingMode = false
        Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAccountIdNo.Location = New System.Drawing.Point(11, 92)
        Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAccountIdNo.Name = "lblAccountIdNo"
        Me.lblAccountIdNo.Size = New System.Drawing.Size(115, 18)
        Me.lblAccountIdNo.TabIndex = 266
        Me.lblAccountIdNo.Text = "Acct. to Credit:"
        Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAccountIdNo.Translatable = true
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
        Me.txtJournalCode.Location = New System.Drawing.Point(128, 11)
        Me.txtJournalCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtJournalCode.MaximumValue = Nothing
        Me.txtJournalCode.MinimumValue = Nothing
        Me.txtJournalCode.Name = "txtJournalCode"
        Me.txtJournalCode.OldValue = Nothing
        Me.txtJournalCode.ReadOnly = true
        Me.txtJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtJournalCode.Size = New System.Drawing.Size(28, 23)
        Me.txtJournalCode.TabIndex = 0
        Me.txtJournalCode.TabStop = false
        Me.txtJournalCode.Text = "PC"
        Me.txtJournalCode.Translatable = false
        Me.txtJournalCode.ValueIsMandatory = true
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
        Me.lblIdNo.Size = New System.Drawing.Size(115, 23)
        Me.lblIdNo.TabIndex = 17
        Me.lblIdNo.Text = "Transaction No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdNo.Translatable = true
        '
        'cboDiscountAccountIdNo
        '
        Me.cboDiscountAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDiscountAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboDiscountAccountIdNo.BegFindValue = Nothing
        Me.cboDiscountAccountIdNo.ChangingSearchValueOnly = false
        Me.tlpDisbursement.SetColumnSpan(Me.cboDiscountAccountIdNo, 6)
        Me.cboDiscountAccountIdNo.CurrentSearchTerm = ""
        Me.cboDiscountAccountIdNo.DataValue = Nothing
        Me.cboDiscountAccountIdNo.DefaultValue = Nothing
        Me.cboDiscountAccountIdNo.DisplayMember = "Name"
        Me.cboDiscountAccountIdNo.EditingMode = false
        Me.cboDiscountAccountIdNo.EndFindValue = Nothing
        Me.cboDiscountAccountIdNo.FieldDescription = Nothing
        Me.cboDiscountAccountIdNo.FieldName = Nothing
        Me.cboDiscountAccountIdNo.FilterRule = Nothing
        Me.cboDiscountAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboDiscountAccountIdNo.FindEnabled = false
        Me.cboDiscountAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboDiscountAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboDiscountAccountIdNo.FormattingEnabled = true
        Me.cboDiscountAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboDiscountAccountIdNo.IgnoreCase = false
        Me.cboDiscountAccountIdNo.IntegralHeight = false
        Me.cboDiscountAccountIdNo.ItemHeight = 16
        Me.cboDiscountAccountIdNo.LinkedLabel = Nothing
        Me.cboDiscountAccountIdNo.Location = New System.Drawing.Point(128, 147)
        Me.cboDiscountAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboDiscountAccountIdNo.Name = "cboDiscountAccountIdNo"
        Me.cboDiscountAccountIdNo.OldValue = 0
        Me.cboDiscountAccountIdNo.OriginalDataSource = Nothing
        Me.cboDiscountAccountIdNo.OriginalList = Nothing
        Me.cboDiscountAccountIdNo.OverrideDropDownStyleList = false
        Me.cboDiscountAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboDiscountAccountIdNo.PropertySelector = Nothing
        Me.cboDiscountAccountIdNo.ReadOnlyCombo = false
        Me.cboDiscountAccountIdNo.Size = New System.Drawing.Size(420, 24)
        Me.cboDiscountAccountIdNo.SuggestBoxHeight = 200
        Me.cboDiscountAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboDiscountAccountIdNo.TabIndex = 12
        Me.cboDiscountAccountIdNo.TextToSearch = Nothing
        Me.cboDiscountAccountIdNo.Translatable = false
        Me.cboDiscountAccountIdNo.ValueIsMandatory = false
        Me.cboDiscountAccountIdNo.ValueIsNullable = false
        Me.cboDiscountAccountIdNo.ValueIsNumeric = false
        Me.cboDiscountAccountIdNo.ValueMember = "IdNo"
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.DisplayOnly = true
        Me.lblInvoiceNo.EditingMode = false
        Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInvoiceNo.Location = New System.Drawing.Point(11, 118)
        Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(94, 18)
        Me.lblInvoiceNo.TabIndex = 254
        Me.lblInvoiceNo.Text = "Inv./O.R. No."
        Me.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInvoiceNo.Translatable = true
        '
        'txtORNumber
        '
        Me.txtORNumber.BackColor = System.Drawing.Color.White
        Me.txtORNumber.BegFindValue = Nothing
        Me.txtORNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpDisbursement.SetColumnSpan(Me.txtORNumber, 2)
        Me.txtORNumber.ComputedValue = false
        Me.txtORNumber.CustomFormat = Nothing
        Me.txtORNumber.DataBoundControl = true
        Me.txtORNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtORNumber.EditingMode = false
        Me.txtORNumber.EndFindValue = Nothing
        Me.txtORNumber.FieldDescription = Nothing
        Me.txtORNumber.FieldName = Nothing
        Me.txtORNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtORNumber.FindEnabled = true
        Me.txtORNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtORNumber.ForeColor = System.Drawing.Color.Black
        Me.txtORNumber.LinkedLabel = Me.lblInvoiceNo
        Me.txtORNumber.Location = New System.Drawing.Point(128, 118)
        Me.txtORNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtORNumber.MaximumValue = Nothing
        Me.txtORNumber.MinimumValue = Nothing
        Me.txtORNumber.Name = "txtORNumber"
        Me.txtORNumber.OldValue = Nothing
        Me.txtORNumber.ReadOnly = true
        Me.txtORNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtORNumber.Size = New System.Drawing.Size(120, 23)
        Me.txtORNumber.TabIndex = 9
        Me.txtORNumber.Translatable = false
        Me.txtORNumber.ValueIsMandatory = true
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BegFindValue = Nothing
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.ComputedValue = false
        Me.txtAmount.CustomFormat = "N2"
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
        Me.txtAmount.Location = New System.Drawing.Point(653, 92)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAmount.MaximumValue = Nothing
        Me.txtAmount.MinimumValue = Nothing
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OldValue = Nothing
        Me.txtAmount.ReadOnly = true
        Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtAmount.Size = New System.Drawing.Size(112, 23)
        Me.txtAmount.TabIndex = 8
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmount.Translatable = false
        Me.txtAmount.ValueIsMandatory = true
        Me.txtAmount.ValueIsNumeric = true
        '
        'lblAmount
        '
        Me.lblAmount.DisplayOnly = true
        Me.lblAmount.EditingMode = false
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAmount.Location = New System.Drawing.Point(550, 92)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(101, 24)
        Me.lblAmount.TabIndex = 264
        Me.lblAmount.Text = "Amount:"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblAmount.Translatable = true
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.DisplayOnly = true
        Me.lblTransactionDate.EditingMode = false
        Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransactionDate.Location = New System.Drawing.Point(550, 11)
        Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(101, 25)
        Me.lblTransactionDate.TabIndex = 4
        Me.lblTransactionDate.Text = "Date:"
        Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTransactionDate.Translatable = true
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpDisbursement.SetColumnSpan(Me.txtNotes, 7)
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(128, 174)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Multiline = true
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Size = New System.Drawing.Size(523, 25)
        Me.txtNotes.TabIndex = 14
        Me.txtNotes.Translatable = false
        Me.txtNotes.ValueIsMandatory = true
        '
        'txtVatAmount
        '
        Me.txtVatAmount.BackColor = System.Drawing.Color.White
        Me.txtVatAmount.BegFindValue = Nothing
        Me.txtVatAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpDisbursement.SetColumnSpan(Me.txtVatAmount, 2)
        Me.txtVatAmount.ComputedValue = false
        Me.txtVatAmount.CustomFormat = "N2"
        Me.txtVatAmount.DataBoundControl = true
        Me.txtVatAmount.DisplayOnly = true
        Me.txtVatAmount.EditingMode = true
        Me.txtVatAmount.EndFindValue = Nothing
        Me.txtVatAmount.FieldDescription = Nothing
        Me.txtVatAmount.FieldName = Nothing
        Me.txtVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtVatAmount.FindEnabled = true
        Me.txtVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
        Me.txtVatAmount.LinkedLabel = Me.lblApplied
        Me.txtVatAmount.Location = New System.Drawing.Point(927, 11)
        Me.txtVatAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtVatAmount.MaximumValue = Nothing
        Me.txtVatAmount.MinimumValue = Nothing
        Me.txtVatAmount.Name = "txtVatAmount"
        Me.txtVatAmount.OldValue = Nothing
        Me.txtVatAmount.ReadOnly = true
        Me.txtVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtVatAmount.Size = New System.Drawing.Size(83, 23)
        Me.txtVatAmount.TabIndex = 17
        Me.txtVatAmount.TabStop = false
        Me.txtVatAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtVatAmount.Translatable = false
        Me.txtVatAmount.ValueIsMandatory = true
        Me.txtVatAmount.ValueIsNumeric = true
        '
        'lblApplied
        '
        Me.lblApplied.AutoSize = true
        Me.tlpDisbursement.SetColumnSpan(Me.lblApplied, 2)
        Me.lblApplied.DisplayOnly = true
        Me.lblApplied.EditingMode = false
        Me.lblApplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblApplied.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblApplied.Location = New System.Drawing.Point(769, 38)
        Me.lblApplied.Margin = New System.Windows.Forms.Padding(1)
        Me.lblApplied.Name = "lblApplied"
        Me.lblApplied.Size = New System.Drawing.Size(107, 17)
        Me.lblApplied.TabIndex = 277
        Me.lblApplied.Text = "Applied Amount"
        Me.lblApplied.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblApplied.Translatable = true
        '
        'txtApplied
        '
        Me.txtApplied.BackColor = System.Drawing.Color.White
        Me.txtApplied.BegFindValue = Nothing
        Me.txtApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpDisbursement.SetColumnSpan(Me.txtApplied, 2)
        Me.txtApplied.ComputedValue = false
        Me.txtApplied.CustomFormat = "N2"
        Me.txtApplied.DataBoundControl = true
        Me.txtApplied.DisplayOnly = true
        Me.txtApplied.EditingMode = true
        Me.txtApplied.EndFindValue = Nothing
        Me.txtApplied.FieldDescription = Nothing
        Me.txtApplied.FieldName = Nothing
        Me.txtApplied.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtApplied.FindEnabled = true
        Me.txtApplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtApplied.ForeColor = System.Drawing.Color.Black
        Me.txtApplied.LinkedLabel = Me.lblApplied
        Me.txtApplied.Location = New System.Drawing.Point(927, 38)
        Me.txtApplied.Margin = New System.Windows.Forms.Padding(1)
        Me.txtApplied.MaximumValue = Nothing
        Me.txtApplied.MinimumValue = Nothing
        Me.txtApplied.Name = "txtApplied"
        Me.txtApplied.OldValue = Nothing
        Me.txtApplied.ReadOnly = true
        Me.txtApplied.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtApplied.Size = New System.Drawing.Size(83, 23)
        Me.txtApplied.TabIndex = 18
        Me.txtApplied.TabStop = false
        Me.txtApplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtApplied.Translatable = false
        Me.txtApplied.ValueIsMandatory = true
        Me.txtApplied.ValueIsNumeric = true
        '
        'txtUnapplied
        '
        Me.txtUnapplied.BackColor = System.Drawing.Color.White
        Me.txtUnapplied.BegFindValue = Nothing
        Me.txtUnapplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnapplied.ComputedValue = false
        Me.txtUnapplied.CustomFormat = "N2"
        Me.txtUnapplied.DataBoundControl = true
        Me.txtUnapplied.DisplayOnly = true
        Me.txtUnapplied.EditingMode = true
        Me.txtUnapplied.EndFindValue = Nothing
        Me.txtUnapplied.FieldDescription = Nothing
        Me.txtUnapplied.FieldName = Nothing
        Me.txtUnapplied.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtUnapplied.FindEnabled = true
        Me.txtUnapplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtUnapplied.ForeColor = System.Drawing.Color.Black
        Me.txtUnapplied.LinkedLabel = Me.CLabel2
        Me.txtUnapplied.Location = New System.Drawing.Point(927, 65)
        Me.txtUnapplied.Margin = New System.Windows.Forms.Padding(1)
        Me.txtUnapplied.MaximumValue = Nothing
        Me.txtUnapplied.MinimumValue = Nothing
        Me.txtUnapplied.Name = "txtUnapplied"
        Me.txtUnapplied.OldValue = Nothing
        Me.txtUnapplied.ReadOnly = true
        Me.txtUnapplied.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtUnapplied.Size = New System.Drawing.Size(83, 23)
        Me.txtUnapplied.TabIndex = 19
        Me.txtUnapplied.TabStop = false
        Me.txtUnapplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUnapplied.Translatable = false
        Me.txtUnapplied.ValueIsMandatory = true
        Me.txtUnapplied.ValueIsNumeric = true
        '
        'CLabel2
        '
        Me.CLabel2.AutoSize = true
        Me.tlpDisbursement.SetColumnSpan(Me.CLabel2, 2)
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CLabel2.Location = New System.Drawing.Point(769, 65)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(124, 17)
        Me.CLabel2.TabIndex = 279
        Me.CLabel2.Text = "Unapplied Amount"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = true
        '
        'txtDiscountTaken
        '
        Me.txtDiscountTaken.BackColor = System.Drawing.Color.White
        Me.txtDiscountTaken.BegFindValue = Nothing
        Me.txtDiscountTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpDisbursement.SetColumnSpan(Me.txtDiscountTaken, 2)
        Me.txtDiscountTaken.ComputedValue = false
        Me.txtDiscountTaken.CustomFormat = "N2"
        Me.txtDiscountTaken.DataBoundControl = true
        Me.txtDiscountTaken.DisplayOnly = true
        Me.txtDiscountTaken.EditingMode = true
        Me.txtDiscountTaken.EndFindValue = Nothing
        Me.txtDiscountTaken.FieldDescription = Nothing
        Me.txtDiscountTaken.FieldName = Nothing
        Me.txtDiscountTaken.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtDiscountTaken.FindEnabled = true
        Me.txtDiscountTaken.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtDiscountTaken.ForeColor = System.Drawing.Color.Black
        Me.txtDiscountTaken.LinkedLabel = Me.lblDiscountTaken
        Me.txtDiscountTaken.Location = New System.Drawing.Point(927, 92)
        Me.txtDiscountTaken.Margin = New System.Windows.Forms.Padding(1)
        Me.txtDiscountTaken.MaximumValue = Nothing
        Me.txtDiscountTaken.MinimumValue = Nothing
        Me.txtDiscountTaken.Name = "txtDiscountTaken"
        Me.txtDiscountTaken.OldValue = Nothing
        Me.txtDiscountTaken.ReadOnly = true
        Me.txtDiscountTaken.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtDiscountTaken.Size = New System.Drawing.Size(83, 23)
        Me.txtDiscountTaken.TabIndex = 20
        Me.txtDiscountTaken.TabStop = false
        Me.txtDiscountTaken.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDiscountTaken.Translatable = false
        Me.txtDiscountTaken.ValueIsMandatory = true
        Me.txtDiscountTaken.ValueIsNumeric = true
        '
        'lblDiscountTaken
        '
        Me.lblDiscountTaken.AutoSize = true
        Me.tlpDisbursement.SetColumnSpan(Me.lblDiscountTaken, 2)
        Me.lblDiscountTaken.DisplayOnly = true
        Me.lblDiscountTaken.EditingMode = false
        Me.lblDiscountTaken.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblDiscountTaken.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDiscountTaken.Location = New System.Drawing.Point(769, 92)
        Me.lblDiscountTaken.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDiscountTaken.Name = "lblDiscountTaken"
        Me.lblDiscountTaken.Size = New System.Drawing.Size(107, 17)
        Me.lblDiscountTaken.TabIndex = 275
        Me.lblDiscountTaken.Text = "Discount Taken"
        Me.lblDiscountTaken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDiscountTaken.Translatable = true
        '
        'DataGridViewDjOiItems
        '
        Me.DataGridViewDjOiItems.AllowUserToAddRows = false
        Me.DataGridViewDjOiItems.AllowUserToDeleteRows = false
        Me.DataGridViewDjOiItems.AllowUserToResizeRows = false
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewDjOiItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewDjOiItems.AutoGenerateColumns = false
        Me.DataGridViewDjOiItems.BegFindValue = Nothing
        Me.DataGridViewDjOiItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDjOiItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceDjOi, Me.dgvInvoiceNo, Me.DgvTransactionDate, Me.dgvJournalCode, Me.dgvJournalIdNoAp, Me.dgvPreviousBalance, Me.dgvAmount, Me.dgvDiscountTaken, Me.dgvBalance, Me.DataGridViewTextBoxColumn6})
        Me.tlpDisbursement.SetColumnSpan(Me.DataGridViewDjOiItems, 12)
        Me.DataGridViewDjOiItems.DataSource = Me.bsDjOiItems
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDjOiItems.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewDjOiItems.DgvFooter = Nothing
        Me.DataGridViewDjOiItems.DisplayOnly = false
        Me.DataGridViewDjOiItems.Ea = EventAggregator2
        Me.DataGridViewDjOiItems.EditingMode = false
        Me.DataGridViewDjOiItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewDjOiItems.EndFindValue = Nothing
        Me.DataGridViewDjOiItems.FieldDescription = Nothing
        Me.DataGridViewDjOiItems.FieldName = Nothing
        Me.DataGridViewDjOiItems.FieldsDictionary = Nothing
        Me.DataGridViewDjOiItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewDjOiItems.FindEnabled = false
        Me.DataGridViewDjOiItems.FirstRowDeletionEnabled = false
        Me.DataGridViewDjOiItems.FirstRowInsertionEnabled = false
        Me.DataGridViewDjOiItems.IgnoreCase = false
        Me.DataGridViewDjOiItems.IsDirty = false
        Me.DataGridViewDjOiItems.Location = New System.Drawing.Point(13, 549)
        Me.DataGridViewDjOiItems.MinimumSize = New System.Drawing.Size(996, 335)
        Me.DataGridViewDjOiItems.Name = "DataGridViewDjOiItems"
        Me.DataGridViewDjOiItems.ReadOnly = true
        Me.DataGridViewDjOiItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewDjOiItems.SecurityKey = ""
        Me.DataGridViewDjOiItems.SequenceColumn = "dgvSequencePcsOi"
        Me.DataGridViewDjOiItems.SequenceFieldName = "Sequence"
        Me.DataGridViewDjOiItems.ShowFooter = false
        Me.DataGridViewDjOiItems.ShowInsertColumnWhenEditing = false
        Me.DataGridViewDjOiItems.Size = New System.Drawing.Size(996, 340)
        Me.DataGridViewDjOiItems.TabIndex = 16
        Me.DataGridViewDjOiItems.Translatable = true
        Me.DataGridViewDjOiItems.Visible = false
        '
        'txtPayeeName
        '
        Me.txtPayeeName.BackColor = System.Drawing.Color.White
        Me.txtPayeeName.BegFindValue = Nothing
        Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpDisbursement.SetColumnSpan(Me.txtPayeeName, 8)
        Me.txtPayeeName.ComputedValue = false
        Me.txtPayeeName.CustomFormat = Nothing
        Me.txtPayeeName.DataBoundControl = true
        Me.txtPayeeName.EditingMode = false
        Me.txtPayeeName.EndFindValue = Nothing
        Me.txtPayeeName.FieldDescription = Nothing
        Me.txtPayeeName.FieldName = Nothing
        Me.txtPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayeeName.FindEnabled = false
        Me.txtPayeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
        Me.txtPayeeName.LinkedLabel = Me.lblAmount
        Me.txtPayeeName.Location = New System.Drawing.Point(128, 893)
        Me.txtPayeeName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayeeName.MaximumValue = Nothing
        Me.txtPayeeName.MinimumValue = Nothing
        Me.txtPayeeName.Name = "txtPayeeName"
        Me.txtPayeeName.OldValue = Nothing
        Me.txtPayeeName.ReadOnly = true
        Me.txtPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayeeName.Size = New System.Drawing.Size(637, 23)
        Me.txtPayeeName.TabIndex = 6
        Me.txtPayeeName.Translatable = false
        Me.txtPayeeName.ValueIsMandatory = true
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpCheckDate.DefaultValue = Nothing
        Me.dtpCheckDate.DisplayOnly = false
        Me.dtpCheckDate.DtpDefaultValue = Nothing
        Me.dtpCheckDate.EditingMode = false
        Me.dtpCheckDate.EditsAllowed = false
        Me.dtpCheckDate.ForeColor = System.Drawing.Color.Black
        Me.dtpCheckDate.LinkedLabel = Nothing
        Me.dtpCheckDate.Location = New System.Drawing.Point(653, 147)
        Me.dtpCheckDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpCheckDate.Name = "dtpCheckDate"
        Me.dtpCheckDate.ReadOnlyDp = false
        Me.dtpCheckDate.SecurityKey = Nothing
        Me.dtpCheckDate.ShowLongDate = false
        Me.dtpCheckDate.ShowTime = false
        Me.dtpCheckDate.Size = New System.Drawing.Size(112, 25)
        Me.dtpCheckDate.TabIndex = 13
        Me.dtpCheckDate.TargetCalendar = Nothing
        Me.dtpCheckDate.Translatable = false
        Me.dtpCheckDate.Value = Nothing
        Me.dtpCheckDate.ValueIsMandatory = false
        Me.dtpCheckDate.ValueIsNullable = false
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
        Me.txtVatNumber.LinkedLabel = Me.lblApplied
        Me.txtVatNumber.Location = New System.Drawing.Point(343, 118)
        Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtVatNumber.MaximumValue = Nothing
        Me.txtVatNumber.MaxLength = 15
        Me.txtVatNumber.MinimumValue = Nothing
        Me.txtVatNumber.Name = "txtVatNumber"
        Me.txtVatNumber.OldValue = Nothing
        Me.txtVatNumber.ReadOnly = true
        Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtVatNumber.Size = New System.Drawing.Size(114, 23)
        Me.txtVatNumber.TabIndex = 10
        Me.txtVatNumber.Translatable = false
        Me.txtVatNumber.ValueIsMandatory = true
        Me.txtVatNumber.ValueIsNumeric = true
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BackColor = System.Drawing.Color.White
        Me.txtCheckNumber.BegFindValue = Nothing
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.ComputedValue = false
        Me.txtCheckNumber.CustomFormat = Nothing
        Me.txtCheckNumber.DataBoundControl = true
        Me.txtCheckNumber.EditingMode = false
        Me.txtCheckNumber.EndFindValue = Nothing
        Me.txtCheckNumber.FieldDescription = Nothing
        Me.txtCheckNumber.FieldName = Nothing
        Me.txtCheckNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCheckNumber.FindEnabled = true
        Me.txtCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
        Me.txtCheckNumber.LinkedLabel = Me.lblInvoiceNo
        Me.txtCheckNumber.Location = New System.Drawing.Point(653, 118)
        Me.txtCheckNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCheckNumber.MaximumValue = Nothing
        Me.txtCheckNumber.MinimumValue = Nothing
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.OldValue = Nothing
        Me.txtCheckNumber.ReadOnly = true
        Me.txtCheckNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCheckNumber.Size = New System.Drawing.Size(112, 23)
        Me.txtCheckNumber.TabIndex = 11
        Me.txtCheckNumber.Translatable = false
        Me.txtCheckNumber.ValueIsMandatory = true
        '
        'lblVatAmount
        '
        Me.lblVatAmount.AutoSize = true
        Me.tlpDisbursement.SetColumnSpan(Me.lblVatAmount, 2)
        Me.lblVatAmount.DisplayOnly = true
        Me.lblVatAmount.EditingMode = false
        Me.lblVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblVatAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVatAmount.Location = New System.Drawing.Point(769, 11)
        Me.lblVatAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVatAmount.Name = "lblVatAmount"
        Me.lblVatAmount.Size = New System.Drawing.Size(81, 17)
        Me.lblVatAmount.TabIndex = 283
        Me.lblVatAmount.Text = "Vat Amount"
        Me.lblVatAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVatAmount.Translatable = true
        '
        'cboPaymentType
        '
        Me.cboPaymentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentType.BackColor = System.Drawing.Color.White
        Me.cboPaymentType.BegFindValue = Nothing
        Me.cboPaymentType.ChangingSearchValueOnly = false
        Me.tlpDisbursement.SetColumnSpan(Me.cboPaymentType, 5)
        Me.cboPaymentType.CurrentSearchTerm = ""
        Me.cboPaymentType.DataValue = Nothing
        Me.cboPaymentType.DefaultValue = "0"
        Me.cboPaymentType.DisplayMember = "Name"
        Me.cboPaymentType.EditingMode = false
        Me.cboPaymentType.EndFindValue = Nothing
        Me.cboPaymentType.FieldDescription = Nothing
        Me.cboPaymentType.FieldName = Nothing
        Me.cboPaymentType.FilterRule = Nothing
        Me.cboPaymentType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPaymentType.FindEnabled = false
        Me.cboPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPaymentType.ForeColor = System.Drawing.Color.Black
        Me.cboPaymentType.HideWhenNotEditingOrAdding = false
        Me.cboPaymentType.IgnoreCase = false
        Me.cboPaymentType.IntegralHeight = false
        Me.cboPaymentType.LinkedLabel = Me.lblPaymentType
        Me.cboPaymentType.Location = New System.Drawing.Point(128, 38)
        Me.cboPaymentType.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.OldValue = 0
        Me.cboPaymentType.OriginalDataSource = Nothing
        Me.cboPaymentType.OriginalList = Nothing
        Me.cboPaymentType.OverrideDropDownStyleList = false
        Me.cboPaymentType.PreviousSearchTerm = Nothing
        Me.cboPaymentType.PropertySelector = Nothing
        Me.cboPaymentType.ReadOnlyCombo = false
        Me.cboPaymentType.Size = New System.Drawing.Size(329, 24)
        Me.cboPaymentType.SuggestBoxHeight = 200
        Me.cboPaymentType.SuggestListOrderRule = Nothing
        Me.cboPaymentType.TabIndex = 4
        Me.cboPaymentType.TextToSearch = Nothing
        Me.cboPaymentType.Translatable = false
        Me.cboPaymentType.ValueIsMandatory = false
        Me.cboPaymentType.ValueIsNullable = false
        Me.cboPaymentType.ValueIsNumeric = false
        Me.cboPaymentType.ValueMember = "Code"
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
        Me.TxtIdNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Me.lblIdNo
        Me.TxtIdNo.Location = New System.Drawing.Point(158, 11)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(90, 23)
        Me.TxtIdNo.TabIndex = 1
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
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
        Me.txtReferenceNo.Location = New System.Drawing.Point(459, 11)
        Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReferenceNo.MaximumValue = Nothing
        Me.txtReferenceNo.MinimumValue = Nothing
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.OldValue = Nothing
        Me.txtReferenceNo.ReadOnly = true
        Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtReferenceNo.Size = New System.Drawing.Size(89, 23)
        Me.txtReferenceNo.TabIndex = 2
        Me.txtReferenceNo.Translatable = false
        Me.txtReferenceNo.ValueIsMandatory = true
        '
        'lblReferenceNo
        '
        Me.tlpDisbursement.SetColumnSpan(Me.lblReferenceNo, 3)
        Me.lblReferenceNo.DisplayOnly = true
        Me.lblReferenceNo.EditingMode = false
        Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReferenceNo.Location = New System.Drawing.Point(250, 11)
        Me.lblReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(207, 25)
        Me.lblReferenceNo.TabIndex = 2
        Me.lblReferenceNo.Text = "Reference No.:"
        Me.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblReferenceNo.Translatable = true
        '
        'cboPayeeIdNo
        '
        Me.cboPayeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboPayeeIdNo.BegFindValue = Nothing
        Me.cboPayeeIdNo.ChangingSearchValueOnly = false
        Me.tlpDisbursement.SetColumnSpan(Me.cboPayeeIdNo, 8)
        Me.cboPayeeIdNo.CurrentSearchTerm = ""
        Me.cboPayeeIdNo.DataValue = Nothing
        Me.cboPayeeIdNo.DefaultValue = Nothing
        Me.cboPayeeIdNo.DisplayMember = "Name"
        Me.cboPayeeIdNo.EditingMode = true
        Me.cboPayeeIdNo.EndFindValue = Nothing
        Me.cboPayeeIdNo.FieldDescription = Nothing
        Me.cboPayeeIdNo.FieldName = Nothing
        Me.cboPayeeIdNo.FilterRule = Nothing
        Me.cboPayeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPayeeIdNo.FindEnabled = false
        Me.cboPayeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPayeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPayeeIdNo.FormattingEnabled = true
        Me.cboPayeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPayeeIdNo.IgnoreCase = false
        Me.cboPayeeIdNo.IntegralHeight = false
        Me.cboPayeeIdNo.LinkedLabel = Nothing
        Me.cboPayeeIdNo.Location = New System.Drawing.Point(128, 65)
        Me.cboPayeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPayeeIdNo.Name = "cboPayeeIdNo"
        Me.cboPayeeIdNo.OldValue = 0
        Me.cboPayeeIdNo.OriginalDataSource = Nothing
        Me.cboPayeeIdNo.OriginalList = Nothing
        Me.cboPayeeIdNo.OverrideDropDownStyleList = false
        Me.cboPayeeIdNo.PreviousSearchTerm = Nothing
        Me.cboPayeeIdNo.PropertySelector = Nothing
        Me.cboPayeeIdNo.ReadOnlyCombo = false
        Me.cboPayeeIdNo.Size = New System.Drawing.Size(637, 24)
        Me.cboPayeeIdNo.SuggestBoxHeight = 200
        Me.cboPayeeIdNo.SuggestListOrderRule = Nothing
        Me.cboPayeeIdNo.TabIndex = 6
        Me.cboPayeeIdNo.TextToSearch = Nothing
        Me.cboPayeeIdNo.Translatable = false
        Me.cboPayeeIdNo.ValueIsMandatory = false
        Me.cboPayeeIdNo.ValueIsNullable = false
        Me.cboPayeeIdNo.ValueIsNumeric = false
        Me.cboPayeeIdNo.ValueMember = "IdNo"
        '
        'lblVatNo
        '
        Me.tlpDisbursement.SetColumnSpan(Me.lblVatNo, 2)
        Me.lblVatNo.DisplayOnly = true
        Me.lblVatNo.EditingMode = false
        Me.lblVatNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblVatNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVatNo.Location = New System.Drawing.Point(250, 118)
        Me.lblVatNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblVatNo.Name = "lblVatNo"
        Me.lblVatNo.Size = New System.Drawing.Size(91, 27)
        Me.lblVatNo.TabIndex = 2
        Me.lblVatNo.Text = "Vat Number"
        Me.lblVatNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblVatNo.Translatable = true
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpTransactionDate.DefaultValue = Nothing
        Me.dtpTransactionDate.DisplayOnly = false
        Me.dtpTransactionDate.DtpDefaultValue = Nothing
        Me.dtpTransactionDate.EditingMode = false
        Me.dtpTransactionDate.EditsAllowed = false
        Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
        Me.dtpTransactionDate.LinkedLabel = Nothing
        Me.dtpTransactionDate.Location = New System.Drawing.Point(653, 11)
        Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ReadOnlyDp = false
        Me.dtpTransactionDate.SecurityKey = Nothing
        Me.dtpTransactionDate.ShowLongDate = false
        Me.dtpTransactionDate.ShowTime = false
        Me.dtpTransactionDate.Size = New System.Drawing.Size(112, 25)
        Me.dtpTransactionDate.TabIndex = 3
        Me.dtpTransactionDate.TargetCalendar = Nothing
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
        Me.lblSupplierIdNo.Location = New System.Drawing.Point(11, 65)
        Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
        Me.lblSupplierIdNo.Size = New System.Drawing.Size(115, 25)
        Me.lblSupplierIdNo.TabIndex = 7
        Me.lblSupplierIdNo.Text = "Payee:"
        Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSupplierIdNo.Translatable = true
        '
        'lblDateCreated
        '
        Me.lblDateCreated.DisplayOnly = true
        Me.lblDateCreated.EditingMode = false
        Me.lblDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDateCreated.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDateCreated.Location = New System.Drawing.Point(769, 147)
        Me.lblDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Size = New System.Drawing.Size(69, 25)
        Me.lblDateCreated.TabIndex = 268
        Me.lblDateCreated.Text = "Date Added:"
        Me.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDateCreated.Translatable = true
        '
        'dtpDateCreated
        '
        Me.dtpDateCreated.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.tlpDisbursement.SetColumnSpan(Me.dtpDateCreated, 2)
        Me.dtpDateCreated.DefaultValue = Nothing
        Me.dtpDateCreated.DisplayOnly = true
        Me.dtpDateCreated.DtpDefaultValue = Nothing
        Me.dtpDateCreated.EditingMode = false
        Me.dtpDateCreated.EditsAllowed = false
        Me.dtpDateCreated.ForeColor = System.Drawing.Color.Black
        Me.dtpDateCreated.LinkedLabel = Nothing
        Me.dtpDateCreated.Location = New System.Drawing.Point(863, 147)
        Me.dtpDateCreated.Margin = New System.Windows.Forms.Padding(10, 1, 1, 1)
        Me.dtpDateCreated.Name = "dtpDateCreated"
        Me.dtpDateCreated.ReadOnlyDp = true
        Me.dtpDateCreated.SecurityKey = Nothing
        Me.dtpDateCreated.ShowLongDate = false
        Me.dtpDateCreated.ShowTime = true
        Me.dtpDateCreated.Size = New System.Drawing.Size(157, 25)
        Me.dtpDateCreated.TabIndex = 24
        Me.dtpDateCreated.TabStop = false
        Me.dtpDateCreated.TargetCalendar = Nothing
        Me.dtpDateCreated.Translatable = false
        Me.dtpDateCreated.Value = Nothing
        Me.dtpDateCreated.ValueIsMandatory = false
        Me.dtpDateCreated.ValueIsNullable = false
        '
        'lblCdJournalIdNo
        '
        Me.lblCdJournalIdNo.AutoSize = true
        Me.tlpDisbursement.SetColumnSpan(Me.lblCdJournalIdNo, 2)
        Me.lblCdJournalIdNo.DisplayOnly = true
        Me.lblCdJournalIdNo.EditingMode = false
        Me.lblCdJournalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCdJournalIdNo.Location = New System.Drawing.Point(769, 118)
        Me.lblCdJournalIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCdJournalIdNo.Name = "lblCdJournalIdNo"
        Me.lblCdJournalIdNo.Size = New System.Drawing.Size(121, 17)
        Me.lblCdJournalIdNo.TabIndex = 296
        Me.lblCdJournalIdNo.Text = "Disbursement No."
        Me.lblCdJournalIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCdJournalIdNo.Translatable = true
        '
        'txtCdJournalIdNo
        '
        Me.txtCdJournalIdNo.BackColor = System.Drawing.Color.White
        Me.txtCdJournalIdNo.BegFindValue = Nothing
        Me.txtCdJournalIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCdJournalIdNo.ComputedValue = false
        Me.txtCdJournalIdNo.CustomFormat = Nothing
        Me.txtCdJournalIdNo.DataBoundControl = true
        Me.txtCdJournalIdNo.EditingMode = true
        Me.txtCdJournalIdNo.EndFindValue = Nothing
        Me.txtCdJournalIdNo.FieldDescription = Nothing
        Me.txtCdJournalIdNo.FieldName = Nothing
        Me.txtCdJournalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCdJournalIdNo.FindEnabled = true
        Me.txtCdJournalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtCdJournalIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtCdJournalIdNo.LinkedLabel = Nothing
        Me.txtCdJournalIdNo.Location = New System.Drawing.Point(927, 118)
        Me.txtCdJournalIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCdJournalIdNo.MaximumValue = Nothing
        Me.txtCdJournalIdNo.MinimumValue = Nothing
        Me.txtCdJournalIdNo.Name = "txtCdJournalIdNo"
        Me.txtCdJournalIdNo.OldValue = Nothing
        Me.txtCdJournalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCdJournalIdNo.Size = New System.Drawing.Size(83, 23)
        Me.txtCdJournalIdNo.TabIndex = 297
        Me.txtCdJournalIdNo.TabStop = false
        Me.txtCdJournalIdNo.Translatable = false
        '
        'lblCheckNumber
        '
        Me.tlpDisbursement.SetColumnSpan(Me.lblCheckNumber, 2)
        Me.lblCheckNumber.DisplayOnly = true
        Me.lblCheckNumber.EditingMode = false
        Me.lblCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCheckNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCheckNumber.Location = New System.Drawing.Point(459, 118)
        Me.lblCheckNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCheckNumber.Name = "lblCheckNumber"
        Me.lblCheckNumber.Size = New System.Drawing.Size(192, 27)
        Me.lblCheckNumber.TabIndex = 290
        Me.lblCheckNumber.Text = "Check Number"
        Me.lblCheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCheckNumber.Translatable = true
        '
        'lblCheckDate
        '
        Me.lblCheckDate.DisplayOnly = true
        Me.lblCheckDate.EditingMode = false
        Me.lblCheckDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCheckDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCheckDate.Location = New System.Drawing.Point(550, 147)
        Me.lblCheckDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCheckDate.Name = "lblCheckDate"
        Me.lblCheckDate.Size = New System.Drawing.Size(101, 25)
        Me.lblCheckDate.TabIndex = 284
        Me.lblCheckDate.Text = "Check Date"
        Me.lblCheckDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCheckDate.Translatable = true
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
        Me.chkApproved.IgnoreCase = false
        Me.chkApproved.LinkedLabel = Nothing
        Me.chkApproved.Location = New System.Drawing.Point(655, 176)
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkApproved.Size = New System.Drawing.Size(110, 21)
        Me.chkApproved.TabIndex = 298
        Me.chkApproved.Text = "Approved?"
        Me.chkApproved.Translatable = true
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
        Me.chkCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkCancelled.IgnoreCase = false
        Me.chkCancelled.LinkedLabel = Nothing
        Me.chkCancelled.Location = New System.Drawing.Point(929, 176)
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkCancelled.Size = New System.Drawing.Size(80, 21)
        Me.chkCancelled.TabIndex = 301
        Me.chkCancelled.Text = "Cancelled?"
        Me.chkCancelled.Translatable = true
        '
        'btnViewGL
        '
        Me.btnViewGL.DesignerSelected = false
        Me.btnViewGL.Font = New System.Drawing.Font("Tahoma", 8!)
        Me.btnViewGL.ImageIndex = 0
        Me.btnViewGL.Location = New System.Drawing.Point(3, 3)
        Me.btnViewGL.Name = "btnViewGL"
        Me.btnViewGL.OriginalImageName = Nothing
        Me.btnViewGL.SecurityKey = ""
        Me.btnViewGL.Size = New System.Drawing.Size(141, 25)
        Me.btnViewGL.TabIndex = 24
        Me.btnViewGL.TabStop = false
        Me.btnViewGL.Text = "View Journal Entry"
        '
        'btnAutoApply
        '
        Me.btnAutoApply.DesignerSelected = false
        Me.btnAutoApply.Font = New System.Drawing.Font("Tahoma", 8!)
        Me.btnAutoApply.ImageIndex = 0
        Me.btnAutoApply.Location = New System.Drawing.Point(150, 3)
        Me.btnAutoApply.Name = "btnAutoApply"
        Me.btnAutoApply.OriginalImageName = Nothing
        Me.btnAutoApply.SecurityKey = ""
        Me.btnAutoApply.Size = New System.Drawing.Size(132, 25)
        Me.btnAutoApply.TabIndex = 25
        Me.btnAutoApply.TabStop = false
        Me.btnAutoApply.Text = "Auto Apply Invoices"
        '
        'btnPrintCheck
        '
        Me.btnPrintCheck.DesignerSelected = false
        Me.btnPrintCheck.ImageIndex = 0
        Me.btnPrintCheck.Location = New System.Drawing.Point(288, 3)
        Me.btnPrintCheck.Name = "btnPrintCheck"
        Me.btnPrintCheck.OriginalImageName = Nothing
        Me.btnPrintCheck.SecurityKey = ""
        Me.btnPrintCheck.Size = New System.Drawing.Size(151, 25)
        Me.btnPrintCheck.TabIndex = 291
        Me.btnPrintCheck.TabStop = false
        Me.btnPrintCheck.Text = "Print Check"
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.btnViewGL)
        Me.CFlowLayout1.Controls.Add(Me.btnAutoApply)
        Me.CFlowLayout1.Controls.Add(Me.btnPrintCheck)
        Me.CFlowLayout1.Controls.Add(Me.btnPrintPcReplenishment)
        Me.CFlowLayout1.Controls.Add(Me.txtTotalCredits)
        Me.CFlowLayout1.Controls.Add(Me.txtTotalDebits)
        Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CFlowLayout1.Location = New System.Drawing.Point(0, 951)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(1023, 30)
        Me.CFlowLayout1.TabIndex = 6
        '
        'btnPrintPcReplenishment
        '
        Me.btnPrintPcReplenishment.DesignerSelected = false
        Me.btnPrintPcReplenishment.ImageIndex = 0
        Me.btnPrintPcReplenishment.Location = New System.Drawing.Point(445, 3)
        Me.btnPrintPcReplenishment.Name = "btnPrintPcReplenishment"
        Me.btnPrintPcReplenishment.OriginalImageName = Nothing
        Me.btnPrintPcReplenishment.SecurityKey = ""
        Me.btnPrintPcReplenishment.Size = New System.Drawing.Size(285, 25)
        Me.btnPrintPcReplenishment.TabIndex = 292
        Me.btnPrintPcReplenishment.Text = "Print Petty Cash Replenishment Report"
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
        Me.txtTotalCredits.Location = New System.Drawing.Point(734, 1)
        Me.txtTotalCredits.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTotalCredits.MaximumValue = Nothing
        Me.txtTotalCredits.MinimumValue = Nothing
        Me.txtTotalCredits.Name = "txtTotalCredits"
        Me.txtTotalCredits.OldValue = Nothing
        Me.txtTotalCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalCredits.Size = New System.Drawing.Size(100, 23)
        Me.txtTotalCredits.TabIndex = 294
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
        Me.txtTotalDebits.Location = New System.Drawing.Point(836, 1)
        Me.txtTotalDebits.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTotalDebits.MaximumValue = Nothing
        Me.txtTotalDebits.MinimumValue = Nothing
        Me.txtTotalDebits.Name = "txtTotalDebits"
        Me.txtTotalDebits.OldValue = Nothing
        Me.txtTotalDebits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalDebits.Size = New System.Drawing.Size(100, 23)
        Me.txtTotalDebits.TabIndex = 293
        Me.txtTotalDebits.Translatable = false
        Me.txtTotalDebits.Visible = false
        '
        'bsJournalItems
        '
        Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
        '
        'dgvSequenceDjOi
        '
        Me.dgvSequenceDjOi.BegFindValue = Nothing
        Me.dgvSequenceDjOi.DataPropertyName = "Sequence"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.dgvSequenceDjOi.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvSequenceDjOi.DisplayOnly = true
        Me.dgvSequenceDjOi.EditingMode = false
        Me.dgvSequenceDjOi.EndFindValue = Nothing
        Me.dgvSequenceDjOi.FieldDescription = Nothing
        Me.dgvSequenceDjOi.FieldName = Nothing
        Me.dgvSequenceDjOi.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequenceDjOi.FindEnabled = false
        Me.dgvSequenceDjOi.HeaderText = "Seq"
        Me.dgvSequenceDjOi.IgnoreCase = false
        Me.dgvSequenceDjOi.Name = "dgvSequenceDjOi"
        Me.dgvSequenceDjOi.ReadOnly = true
        Me.dgvSequenceDjOi.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSequenceDjOi.Translatable = false
        Me.dgvSequenceDjOi.Width = 40
        '
        'dgvInvoiceNo
        '
        Me.dgvInvoiceNo.BegFindValue = Nothing
        Me.dgvInvoiceNo.DataPropertyName = "InvoiceNo"
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        Me.dgvInvoiceNo.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvInvoiceNo.EditingMode = false
        Me.dgvInvoiceNo.EndFindValue = Nothing
        Me.dgvInvoiceNo.FieldDescription = Nothing
        Me.dgvInvoiceNo.FieldName = Nothing
        Me.dgvInvoiceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvInvoiceNo.FindEnabled = false
        Me.dgvInvoiceNo.HeaderText = "Invoice No."
        Me.dgvInvoiceNo.IgnoreCase = false
        Me.dgvInvoiceNo.Name = "dgvInvoiceNo"
        Me.dgvInvoiceNo.ReadOnly = true
        Me.dgvInvoiceNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvInvoiceNo.Translatable = false
        '
        'DgvTransactionDate
        '
        Me.DgvTransactionDate.BegFindValue = Nothing
        Me.DgvTransactionDate.DataPropertyName = "TransactionDate"
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        Me.DgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle14
        Me.DgvTransactionDate.EditingMode = false
        Me.DgvTransactionDate.EndFindValue = Nothing
        Me.DgvTransactionDate.FieldDescription = Nothing
        Me.DgvTransactionDate.FieldName = Nothing
        Me.DgvTransactionDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DgvTransactionDate.FindEnabled = false
        Me.DgvTransactionDate.HeaderText = "Transaction Date"
        Me.DgvTransactionDate.IgnoreCase = false
        Me.DgvTransactionDate.Name = "DgvTransactionDate"
        Me.DgvTransactionDate.ReadOnly = true
        Me.DgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DgvTransactionDate.Translatable = false
        '
        'dgvJournalCode
        '
        Me.dgvJournalCode.BegFindValue = Nothing
        Me.dgvJournalCode.DataPropertyName = "JournalCode"
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        Me.dgvJournalCode.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvJournalCode.EditingMode = false
        Me.dgvJournalCode.EndFindValue = Nothing
        Me.dgvJournalCode.FieldDescription = Nothing
        Me.dgvJournalCode.FieldName = Nothing
        Me.dgvJournalCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvJournalCode.FindEnabled = false
        Me.dgvJournalCode.HeaderText = "Journal Code"
        Me.dgvJournalCode.IgnoreCase = false
        Me.dgvJournalCode.Name = "dgvJournalCode"
        Me.dgvJournalCode.ReadOnly = true
        Me.dgvJournalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvJournalCode.Translatable = false
        Me.dgvJournalCode.Width = 50
        '
        'dgvJournalIdNoAp
        '
        Me.dgvJournalIdNoAp.BegFindValue = Nothing
        Me.dgvJournalIdNoAp.DataPropertyName = "JournalIdNo"
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        Me.dgvJournalIdNoAp.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvJournalIdNoAp.EditingMode = false
        Me.dgvJournalIdNoAp.EndFindValue = Nothing
        Me.dgvJournalIdNoAp.FieldDescription = Nothing
        Me.dgvJournalIdNoAp.FieldName = Nothing
        Me.dgvJournalIdNoAp.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvJournalIdNoAp.FindEnabled = false
        Me.dgvJournalIdNoAp.HeaderText = "Journal Id No"
        Me.dgvJournalIdNoAp.IgnoreCase = false
        Me.dgvJournalIdNoAp.Name = "dgvJournalIdNoAp"
        Me.dgvJournalIdNoAp.ReadOnly = true
        Me.dgvJournalIdNoAp.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvJournalIdNoAp.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvJournalIdNoAp.Translatable = false
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
        Me.dgvPreviousBalance.EditingMode = false
        Me.dgvPreviousBalance.EndFindValue = Nothing
        Me.dgvPreviousBalance.FieldDescription = Nothing
        Me.dgvPreviousBalance.FieldName = Nothing
        Me.dgvPreviousBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvPreviousBalance.FindEnabled = false
        Me.dgvPreviousBalance.HeaderText = "Previous Balance"
        Me.dgvPreviousBalance.Name = "dgvPreviousBalance"
        Me.dgvPreviousBalance.ReadOnly = true
        Me.dgvPreviousBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPreviousBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvPreviousBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvPreviousBalance.Translatable = false
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
        Me.dgvAmount.EditingMode = false
        Me.dgvAmount.EndFindValue = Nothing
        Me.dgvAmount.FieldDescription = Nothing
        Me.dgvAmount.FieldName = Nothing
        Me.dgvAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvAmount.FindEnabled = false
        Me.dgvAmount.HeaderText = "Amount"
        Me.dgvAmount.Name = "dgvAmount"
        Me.dgvAmount.ReadOnly = true
        Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvAmount.Translatable = false
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
        Me.dgvDiscountTaken.EditingMode = false
        Me.dgvDiscountTaken.EndFindValue = Nothing
        Me.dgvDiscountTaken.FieldDescription = Nothing
        Me.dgvDiscountTaken.FieldName = Nothing
        Me.dgvDiscountTaken.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDiscountTaken.FindEnabled = false
        Me.dgvDiscountTaken.HeaderText = "Discount Taken"
        Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
        Me.dgvDiscountTaken.ReadOnly = true
        Me.dgvDiscountTaken.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiscountTaken.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDiscountTaken.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDiscountTaken.Translatable = false
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
        Me.dgvBalance.EditingMode = false
        Me.dgvBalance.EndFindValue = Nothing
        Me.dgvBalance.FieldDescription = Nothing
        Me.dgvBalance.FieldName = Nothing
        Me.dgvBalance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvBalance.FindEnabled = false
        Me.dgvBalance.HeaderText = "Balance"
        Me.dgvBalance.Name = "dgvBalance"
        Me.dgvBalance.ReadOnly = true
        Me.dgvBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvBalance.Translatable = false
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "AccountIdNo"
        Me.DataGridViewTextBoxColumn6.HeaderText = "AccountIdNo"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = true
        Me.DataGridViewTextBoxColumn6.Visible = false
        '
        'bsDjOiItems
        '
        Me.bsDjOiItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DjOiItemModel)
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
        Me.dgvSequence.Frozen = true
        Me.dgvSequence.HeaderText = "Seq"
        Me.dgvSequence.IgnoreCase = false
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSequence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgvSequence.Translatable = false
        Me.dgvSequence.Width = 30
        '
        'dgvAccountIdNo
        '
        Me.dgvAccountIdNo.AutoComplete = false
        Me.dgvAccountIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvAccountIdNo.DataPropertyName = "AccountIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvAccountIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAccountIdNo.EditingMode = false
        Me.dgvAccountIdNo.Frozen = true
        Me.dgvAccountIdNo.HeaderText = "Account Code-Name"
        Me.dgvAccountIdNo.MinimumWidth = 200
        Me.dgvAccountIdNo.Name = "dgvAccountIdNo"
        Me.dgvAccountIdNo.ReadOnly = true
        Me.dgvAccountIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountIdNo.Translatable = false
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
        Me.dgvDebit.EditingMode = false
        Me.dgvDebit.EndFindValue = Nothing
        Me.dgvDebit.FieldDescription = Nothing
        Me.dgvDebit.FieldName = Nothing
        Me.dgvDebit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDebit.FindEnabled = false
        Me.dgvDebit.HeaderText = "Debit"
        Me.dgvDebit.MinimumWidth = 90
        Me.dgvDebit.Name = "dgvDebit"
        Me.dgvDebit.ReadOnly = true
        Me.dgvDebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDebit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDebit.Translatable = false
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
        Me.dgvCredit.EditingMode = false
        Me.dgvCredit.EndFindValue = Nothing
        Me.dgvCredit.FieldDescription = Nothing
        Me.dgvCredit.FieldName = Nothing
        Me.dgvCredit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvCredit.FindEnabled = false
        Me.dgvCredit.HeaderText = "Credit"
        Me.dgvCredit.MinimumWidth = 90
        Me.dgvCredit.Name = "dgvCredit"
        Me.dgvCredit.ReadOnly = true
        Me.dgvCredit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCredit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvCredit.Translatable = false
        Me.dgvCredit.Width = 90
        '
        'dgvRevCostCenterIdNo
        '
        Me.dgvRevCostCenterIdNo.AutoComplete = false
        Me.dgvRevCostCenterIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvRevCostCenterIdNo.DataPropertyName = "RevCostCenterIdNo"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvRevCostCenterIdNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRevCostCenterIdNo.EditingMode = false
        Me.dgvRevCostCenterIdNo.HeaderText = "Revenue/Cost Center Code-Name"
        Me.dgvRevCostCenterIdNo.MinimumWidth = 150
        Me.dgvRevCostCenterIdNo.Name = "dgvRevCostCenterIdNo"
        Me.dgvRevCostCenterIdNo.ReadOnly = true
        Me.dgvRevCostCenterIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRevCostCenterIdNo.Translatable = false
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
        Me.dgvNotes.EditingMode = false
        Me.dgvNotes.EndFindValue = Nothing
        Me.dgvNotes.FieldDescription = Nothing
        Me.dgvNotes.FieldName = Nothing
        Me.dgvNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvNotes.FindEnabled = false
        Me.dgvNotes.HeaderText = "Notes / Description"
        Me.dgvNotes.IgnoreCase = false
        Me.dgvNotes.MinimumWidth = 150
        Me.dgvNotes.Name = "dgvNotes"
        Me.dgvNotes.ReadOnly = true
        Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvNotes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dgvNotes.Translatable = false
        '
        'DiscountTakenDataGridViewTextBoxColumn
        '
        Me.DiscountTakenDataGridViewTextBoxColumn.DataPropertyName = "DiscountTaken"
        Me.DiscountTakenDataGridViewTextBoxColumn.HeaderText = "DiscountTaken"
        Me.DiscountTakenDataGridViewTextBoxColumn.Name = "DiscountTakenDataGridViewTextBoxColumn"
        Me.DiscountTakenDataGridViewTextBoxColumn.ReadOnly = true
        Me.DiscountTakenDataGridViewTextBoxColumn.Visible = false
        '
        'IdNoDataGridViewTextBoxColumn
        '
        Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
        Me.IdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.IdNoDataGridViewTextBoxColumn.Visible = false
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
        'PaidAmountDataGridViewTextBoxColumn
        '
        Me.PaidAmountDataGridViewTextBoxColumn.DataPropertyName = "PaidAmount"
        Me.PaidAmountDataGridViewTextBoxColumn.HeaderText = "PaidAmount"
        Me.PaidAmountDataGridViewTextBoxColumn.Name = "PaidAmountDataGridViewTextBoxColumn"
        Me.PaidAmountDataGridViewTextBoxColumn.ReadOnly = true
        Me.PaidAmountDataGridViewTextBoxColumn.Visible = false
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
        Me.dgvVatAmount.EditingMode = false
        Me.dgvVatAmount.EndFindValue = Nothing
        Me.dgvVatAmount.FieldDescription = Nothing
        Me.dgvVatAmount.FieldName = Nothing
        Me.dgvVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvVatAmount.FindEnabled = false
        Me.dgvVatAmount.HeaderText = "Vat Amount"
        Me.dgvVatAmount.Name = "dgvVatAmount"
        Me.dgvVatAmount.ReadOnly = true
        Me.dgvVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvVatAmount.Translatable = false
        Me.dgvVatAmount.Visible = false
        '
        'dgvPayeeType
        '
        Me.dgvPayeeType.DataPropertyName = "PayeeType"
        Me.dgvPayeeType.HeaderText = "PayeeType"
        Me.dgvPayeeType.Name = "dgvPayeeType"
        Me.dgvPayeeType.ReadOnly = true
        Me.dgvPayeeType.Visible = false
        '
        'dgvSpecialAccount
        '
        Me.dgvSpecialAccount.BegFindValue = Nothing
        Me.dgvSpecialAccount.DataPropertyName = "SpecialAccount"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.dgvSpecialAccount.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvSpecialAccount.EditingMode = false
        Me.dgvSpecialAccount.EndFindValue = Nothing
        Me.dgvSpecialAccount.FieldDescription = Nothing
        Me.dgvSpecialAccount.FieldName = Nothing
        Me.dgvSpecialAccount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSpecialAccount.FindEnabled = false
        Me.dgvSpecialAccount.HeaderText = "SpecialAccount"
        Me.dgvSpecialAccount.IgnoreCase = false
        Me.dgvSpecialAccount.Name = "dgvSpecialAccount"
        Me.dgvSpecialAccount.ReadOnly = true
        Me.dgvSpecialAccount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSpecialAccount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSpecialAccount.Translatable = false
        Me.dgvSpecialAccount.Visible = false
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
        'DisbursementJournalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
        Me.ClientSize = New System.Drawing.Size(1023, 981)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Controls.Add(Me.tlpDisbursement)
        Me.DefaultFormBackColor = System.Drawing.Color.Transparent
        Me.MinimumSize = New System.Drawing.Size(1039, 590)
        Me.Name = "DisbursementJournalEntry"
        Me.Text = "Petty Cash Journal "
        Me.Controls.SetChildIndex(Me.tlpDisbursement, 0)
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.tlpDisbursement.ResumeLayout(false)
        Me.tlpDisbursement.PerformLayout
        CType(Me.DataGridViewJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewDjOiItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        CType(Me.bsJournalItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsDjOiItems,System.ComponentModel.ISupportInitialize).EndInit
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
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents lblCdJournalIdNo As CLabel
        Friend WithEvents txtCdJournalIdNo As CTextBox
        Friend WithEvents btnPrintPcReplenishment As CButton
        Friend WithEvents chkPcClosed As UcCheckBox
        Friend WithEvents chkPosted As UcCheckBox
        Friend WithEvents chkApproved As UcCheckBox
        Friend WithEvents chkCancelled As UcCheckBox
        Friend WithEvents txtTotalCredits As CTextBox
        Friend WithEvents txtTotalDebits As CTextBox
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
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvAccountIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvDebit As CdgvMoneyColumn
        Friend WithEvents dgvCredit As CdgvMoneyColumn
        Friend WithEvents dgvRevCostCenterIdNo As CdDgvComboBoxColumn
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