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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DisbursementJournalEntry))
            Me.tlpDisbursement = New System.Windows.Forms.TableLayoutPanel()
            Me.chkPcClosed = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.cboPayType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPaymentType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
            Me.dtpCheckDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPaymentType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboPayeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblVatNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCdJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCdJournalIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCheckDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkApproved = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPayType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnAutoApply = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnPrintCheck = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.btnPrintPcReplenishment = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.txtTotalCredits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtTotalDebits = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDateCreated = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tlpDisbursement.SuspendLayout()
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewDjOiItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsDjOiItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'tlpDisbursement
            '
            Me.tlpDisbursement.AutoSize = True
            Me.tlpDisbursement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.tlpDisbursement.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.ColumnCount = 12
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
            Me.tlpDisbursement.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.tlpDisbursement.Controls.Add(Me.txtDateCreated, 10, 5)
            Me.tlpDisbursement.Controls.Add(Me.chkPcClosed, 10, 6)
            Me.tlpDisbursement.Controls.Add(Me.chkPosted, 9, 6)
            Me.tlpDisbursement.Controls.Add(Me.cboPayType, 6, 1)
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
            Me.tlpDisbursement.Controls.Add(Me.txtNotes, 1, 6)
            Me.tlpDisbursement.Controls.Add(Me.txtVatAmount, 11, 0)
            Me.tlpDisbursement.Controls.Add(Me.txtApplied, 11, 1)
            Me.tlpDisbursement.Controls.Add(Me.txtUnapplied, 11, 2)
            Me.tlpDisbursement.Controls.Add(Me.txtDiscountTaken, 11, 3)
            Me.tlpDisbursement.Controls.Add(Me.lblDiscountTaken, 9, 3)
            Me.tlpDisbursement.Controls.Add(Me.DataGridViewDjOiItems, 0, 9)
            Me.tlpDisbursement.Controls.Add(Me.dtpCheckDate, 8, 5)
            Me.tlpDisbursement.Controls.Add(Me.txtVatNumber, 5, 4)
            Me.tlpDisbursement.Controls.Add(Me.txtCheckNumber, 8, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblApplied, 9, 1)
            Me.tlpDisbursement.Controls.Add(Me.lblVatAmount, 9, 0)
            Me.tlpDisbursement.Controls.Add(Me.cboPaymentType, 1, 1)
            Me.tlpDisbursement.Controls.Add(Me.TxtIdNo, 2, 0)
            Me.tlpDisbursement.Controls.Add(Me.cboPayeeIdNo, 1, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblVatNo, 3, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblReferenceNo, 3, 0)
            Me.tlpDisbursement.Controls.Add(Me.lblSupplierIdNo, 0, 2)
            Me.tlpDisbursement.Controls.Add(Me.CLabel2, 9, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblDateCreated, 9, 5)
            Me.tlpDisbursement.Controls.Add(Me.lblCdJournalIdNo, 9, 4)
            Me.tlpDisbursement.Controls.Add(Me.txtCdJournalIdNo, 11, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblCheckNumber, 6, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblCheckDate, 6, 5)
            Me.tlpDisbursement.Controls.Add(Me.chkApproved, 8, 6)
            Me.tlpDisbursement.Controls.Add(Me.chkCancelled, 11, 6)
            Me.tlpDisbursement.Controls.Add(Me.txtPayeeName, 6, 2)
            Me.tlpDisbursement.Controls.Add(Me.txtReferenceNo, 5, 0)
            Me.tlpDisbursement.Controls.Add(Me.lblAmount, 6, 3)
            Me.tlpDisbursement.Controls.Add(Me.lblPayType, 5, 1)
            Me.tlpDisbursement.Controls.Add(Me.lblTransactionDate, 6, 0)
            Me.tlpDisbursement.Controls.Add(Me.dtpTransactionDate, 8, 0)
            Me.tlpDisbursement.Location = New System.Drawing.Point(0, 65)
            Me.tlpDisbursement.Margin = New System.Windows.Forms.Padding(4)
            Me.tlpDisbursement.Name = "tlpDisbursement"
            Me.tlpDisbursement.Padding = New System.Windows.Forms.Padding(13, 12, 13, 12)
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
            Me.tlpDisbursement.Size = New System.Drawing.Size(1142, 1137)
            Me.tlpDisbursement.TabIndex = 5
            '
            'chkPcClosed
            '
            Me.chkPcClosed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.chkPcClosed.BackColor = System.Drawing.Color.Transparent
            Me.chkPcClosed.BegFindValue = Nothing
            Me.chkPcClosed.Checked = False
            Me.chkPcClosed.DisplayOnly = True
            Me.chkPcClosed.EditingMode = False
            Me.chkPcClosed.EndFindValue = Nothing
            Me.chkPcClosed.FieldDescription = Nothing
            Me.chkPcClosed.FieldName = Nothing
            Me.chkPcClosed.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkPcClosed.FindEnabled = True
            Me.chkPcClosed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPcClosed.IgnoreCase = False
            Me.chkPcClosed.LinkedLabel = Nothing
            Me.chkPcClosed.Location = New System.Drawing.Point(918, 216)
            Me.chkPcClosed.Margin = New System.Windows.Forms.Padding(5)
            Me.chkPcClosed.Name = "chkPcClosed"
            Me.chkPcClosed.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkPcClosed.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkPcClosed.Size = New System.Drawing.Size(89, 26)
            Me.chkPcClosed.TabIndex = 300
            Me.chkPcClosed.Text = "Closed?"
            Me.chkPcClosed.Translatable = True
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
            Me.chkPosted.FindEnabled = True
            Me.chkPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPosted.IgnoreCase = False
            Me.chkPosted.LinkedLabel = Nothing
            Me.chkPosted.Location = New System.Drawing.Point(820, 216)
            Me.chkPosted.Margin = New System.Windows.Forms.Padding(5)
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkPosted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkPosted.Size = New System.Drawing.Size(88, 26)
            Me.chkPosted.TabIndex = 299
            Me.chkPosted.Text = "Posted?"
            Me.chkPosted.Translatable = True
            '
            'cboPayType
            '
            Me.cboPayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPayType.BackColor = System.Drawing.Color.White
            Me.cboPayType.BegFindValue = Nothing
            Me.cboPayType.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPayType, 3)
            Me.cboPayType.CurrentSearchTerm = ""
            Me.cboPayType.DataValue = Nothing
            Me.cboPayType.DefaultValue = "0"
            Me.cboPayType.DisplayMember = "Name"
            Me.cboPayType.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPayType.DropDownHeight = 24
            Me.cboPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPayType.Editable = True
            Me.cboPayType.EditingMode = False
            Me.cboPayType.EndFindValue = Nothing
            Me.cboPayType.FieldDescription = Nothing
            Me.cboPayType.FieldName = Nothing
            Me.cboPayType.FilterRule = Nothing
            Me.cboPayType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayType.FindEnabled = False
            Me.cboPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayType.ForeColor = System.Drawing.Color.Black
            Me.cboPayType.HideWhenNotEditingOrAdding = False
            Me.cboPayType.IgnoreCase = False
            Me.cboPayType.IntegralHeight = False
            Me.cboPayType.LimitToList = False
            Me.cboPayType.LinkedLabel = Me.lblPaymentType
            Me.cboPayType.Location = New System.Drawing.Point(563, 46)
            Me.cboPayType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayType.MaxDropDownItems = 1
            Me.cboPayType.Name = "cboPayType"
            Me.cboPayType.OldValue = 0
            Me.cboPayType.OriginalDataSource = Nothing
            Me.cboPayType.OriginalList = Nothing
            Me.cboPayType.OverrideDropDownStyleList = False
            Me.cboPayType.PreviousSearchTerm = Nothing
            Me.cboPayType.PropertySelector = Nothing
            Me.cboPayType.ReadOnlyCombo = False
            Me.cboPayType.Size = New System.Drawing.Size(251, 31)
            Me.cboPayType.SuggestBoxHeight = 200
            Me.cboPayType.SuggestListOrderRule = Nothing
            Me.cboPayType.TabIndex = 4
            Me.cboPayType.TextToSearch = Nothing
            Me.cboPayType.Translatable = False
            Me.cboPayType.ValueIsMandatory = False
            Me.cboPayType.ValueIsNullable = False
            Me.cboPayType.ValueIsNumeric = False
            Me.cboPayType.ValueMember = "Code"
            '
            'lblPaymentType
            '
            Me.lblPaymentType.BackColor = System.Drawing.Color.Transparent
            Me.lblPaymentType.DisplayOnly = True
            Me.lblPaymentType.EditingMode = False
            Me.lblPaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPaymentType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPaymentType.Location = New System.Drawing.Point(14, 46)
            Me.lblPaymentType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPaymentType.Name = "lblPaymentType"
            Me.lblPaymentType.Size = New System.Drawing.Size(153, 28)
            Me.lblPaymentType.TabIndex = 257
            Me.lblPaymentType.Text = "Payee Type:"
            Me.lblPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPaymentType.Translatable = True
            '
            'DataGridViewJournalItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewJournalItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewJournalItems.AutoGenerateColumns = False
            Me.DataGridViewJournalItems.BegFindValue = Nothing
            Me.DataGridViewJournalItems.Cached = False
            Me.DataGridViewJournalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewJournalItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvAccountIdNo, Me.dgvDebit, Me.dgvCredit, Me.dgvRevCostCenterIdNo, Me.dgvNotes, Me.DiscountTakenDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.JournalIdNoDataGridViewTextBoxColumn, Me.OpenInvoiceIdNoDataGridViewTextBoxColumn, Me.OriginalAmountDataGridViewTextBoxColumn, Me.PaidAmountDataGridViewTextBoxColumn, Me.dgvVatAmount, Me.dgvPayeeType, Me.dgvSpecialAccount, Me.AccountNameDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn})
            Me.tlpDisbursement.SetColumnSpan(Me.DataGridViewJournalItems, 12)
            Me.DataGridViewJournalItems.DataFilter = Nothing
            Me.DataGridViewJournalItems.DataSource = Me.bsJournalItems
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewJournalItems.DefaultCellStyle = DataGridViewCellStyle10
            Me.DataGridViewJournalItems.DgvFooter = Nothing
            Me.DataGridViewJournalItems.DisplayOnly = False
            Me.DataGridViewJournalItems.Dock = System.Windows.Forms.DockStyle.Fill
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
            Me.DataGridViewJournalItems.Location = New System.Drawing.Point(17, 251)
            Me.DataGridViewJournalItems.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewJournalItems.Name = "DataGridViewJournalItems"
            Me.DataGridViewJournalItems.ReadOnly = True
            Me.DataGridViewJournalItems.RowHeadersWidth = 51
            Me.DataGridViewJournalItems.Searchable = True
            Me.DataGridViewJournalItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewJournalItems.SecurityKey = ""
            Me.DataGridViewJournalItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewJournalItems.SequenceFieldName = "Sequence"
            Me.DataGridViewJournalItems.ShowFooter = False
            Me.DataGridViewJournalItems.Size = New System.Drawing.Size(1108, 418)
            Me.DataGridViewJournalItems.TabIndex = 21
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
            Me.dgvSequence.MinimumWidth = 6
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
            Me.dgvAccountIdNo.AutoComplete = False
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
            Me.dgvRevCostCenterIdNo.AutoComplete = False
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
            Me.DiscountTakenDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.DiscountTakenDataGridViewTextBoxColumn.Name = "DiscountTakenDataGridViewTextBoxColumn"
            Me.DiscountTakenDataGridViewTextBoxColumn.ReadOnly = True
            Me.DiscountTakenDataGridViewTextBoxColumn.Visible = False
            Me.DiscountTakenDataGridViewTextBoxColumn.Width = 125
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn.Visible = False
            Me.IdNoDataGridViewTextBoxColumn.Width = 125
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
            'OpenInvoiceIdNoDataGridViewTextBoxColumn
            '
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.DataPropertyName = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.HeaderText = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.Name = "OpenInvoiceIdNoDataGridViewTextBoxColumn"
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.Visible = False
            Me.OpenInvoiceIdNoDataGridViewTextBoxColumn.Width = 125
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
            'PaidAmountDataGridViewTextBoxColumn
            '
            Me.PaidAmountDataGridViewTextBoxColumn.DataPropertyName = "PaidAmount"
            Me.PaidAmountDataGridViewTextBoxColumn.HeaderText = "PaidAmount"
            Me.PaidAmountDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.PaidAmountDataGridViewTextBoxColumn.Name = "PaidAmountDataGridViewTextBoxColumn"
            Me.PaidAmountDataGridViewTextBoxColumn.ReadOnly = True
            Me.PaidAmountDataGridViewTextBoxColumn.Visible = False
            Me.PaidAmountDataGridViewTextBoxColumn.Width = 125
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
            Me.dgvVatAmount.MinimumWidth = 6
            Me.dgvVatAmount.Name = "dgvVatAmount"
            Me.dgvVatAmount.ReadOnly = True
            Me.dgvVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvVatAmount.Translatable = False
            Me.dgvVatAmount.Visible = False
            Me.dgvVatAmount.Width = 125
            '
            'dgvPayeeType
            '
            Me.dgvPayeeType.DataPropertyName = "PayeeType"
            Me.dgvPayeeType.HeaderText = "PayeeType"
            Me.dgvPayeeType.MinimumWidth = 6
            Me.dgvPayeeType.Name = "dgvPayeeType"
            Me.dgvPayeeType.ReadOnly = True
            Me.dgvPayeeType.Visible = False
            Me.dgvPayeeType.Width = 125
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
            Me.dgvSpecialAccount.MinimumWidth = 6
            Me.dgvSpecialAccount.Name = "dgvSpecialAccount"
            Me.dgvSpecialAccount.ReadOnly = True
            Me.dgvSpecialAccount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSpecialAccount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSpecialAccount.Translatable = False
            Me.dgvSpecialAccount.Visible = False
            Me.dgvSpecialAccount.Width = 125
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
            'bsJournalItems
            '
            Me.bsJournalItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.JournalItemModel)
            '
            'lblDiscountAccountIdNo
            '
            Me.lblDiscountAccountIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblDiscountAccountIdNo.DisplayOnly = True
            Me.lblDiscountAccountIdNo.EditingMode = False
            Me.lblDiscountAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDiscountAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDiscountAccountIdNo.Location = New System.Drawing.Point(14, 179)
            Me.lblDiscountAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDiscountAccountIdNo.Name = "lblDiscountAccountIdNo"
            Me.lblDiscountAccountIdNo.Size = New System.Drawing.Size(153, 30)
            Me.lblDiscountAccountIdNo.TabIndex = 281
            Me.lblDiscountAccountIdNo.Text = "Discount Acct."
            Me.lblDiscountAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDiscountAccountIdNo.Translatable = True
            '
            'lblNotes
            '
            Me.lblNotes.BackColor = System.Drawing.Color.Transparent
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(14, 212)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(153, 28)
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
            Me.tlpDisbursement.SetColumnSpan(Me.cboAccountIdNo, 5)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DataValue = Nothing
            Me.cboAccountIdNo.DefaultValue = ""
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboAccountIdNo.DropDownHeight = 24
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboAccountIdNo.Editable = True
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
            Me.cboAccountIdNo.LimitToList = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
            Me.cboAccountIdNo.Location = New System.Drawing.Point(169, 112)
            Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboAccountIdNo.MaxDropDownItems = 1
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.Size = New System.Drawing.Size(392, 30)
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
            Me.lblAccountIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAccountIdNo.Location = New System.Drawing.Point(14, 112)
            Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Size = New System.Drawing.Size(153, 22)
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
            Me.txtJournalCode.Location = New System.Drawing.Point(169, 13)
            Me.txtJournalCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtJournalCode.MaximumValue = Nothing
            Me.txtJournalCode.MinimumValue = Nothing
            Me.txtJournalCode.Name = "txtJournalCode"
            Me.txtJournalCode.OldValue = Nothing
            Me.txtJournalCode.OverrideMaxLength = 0
            Me.txtJournalCode.ReadOnly = True
            Me.txtJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalCode.Size = New System.Drawing.Size(37, 26)
            Me.txtJournalCode.TabIndex = 0
            Me.txtJournalCode.TabStop = False
            Me.txtJournalCode.Text = "PC"
            Me.txtJournalCode.Translatable = False
            Me.txtJournalCode.ValueIsMandatory = True
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(14, 13)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(153, 28)
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
            Me.tlpDisbursement.SetColumnSpan(Me.cboDiscountAccountIdNo, 5)
            Me.cboDiscountAccountIdNo.CurrentSearchTerm = ""
            Me.cboDiscountAccountIdNo.DataValue = Nothing
            Me.cboDiscountAccountIdNo.DefaultValue = Nothing
            Me.cboDiscountAccountIdNo.DisplayMember = "Name"
            Me.cboDiscountAccountIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboDiscountAccountIdNo.DropDownHeight = 24
            Me.cboDiscountAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboDiscountAccountIdNo.Editable = True
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
            Me.cboDiscountAccountIdNo.ItemHeight = 20
            Me.cboDiscountAccountIdNo.LimitToList = False
            Me.cboDiscountAccountIdNo.LinkedLabel = Nothing
            Me.cboDiscountAccountIdNo.Location = New System.Drawing.Point(169, 179)
            Me.cboDiscountAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDiscountAccountIdNo.MaxDropDownItems = 1
            Me.cboDiscountAccountIdNo.Name = "cboDiscountAccountIdNo"
            Me.cboDiscountAccountIdNo.OldValue = 0
            Me.cboDiscountAccountIdNo.OriginalDataSource = Nothing
            Me.cboDiscountAccountIdNo.OriginalList = Nothing
            Me.cboDiscountAccountIdNo.OverrideDropDownStyleList = False
            Me.cboDiscountAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboDiscountAccountIdNo.PropertySelector = Nothing
            Me.cboDiscountAccountIdNo.ReadOnlyCombo = False
            Me.cboDiscountAccountIdNo.Size = New System.Drawing.Size(392, 31)
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
            Me.lblInvoiceNo.BackColor = System.Drawing.Color.Transparent
            Me.lblInvoiceNo.DisplayOnly = True
            Me.lblInvoiceNo.EditingMode = False
            Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceNo.Location = New System.Drawing.Point(14, 144)
            Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            Me.lblInvoiceNo.Size = New System.Drawing.Size(125, 22)
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
            Me.txtORNumber.EditingMode = False
            Me.txtORNumber.EndFindValue = Nothing
            Me.txtORNumber.FieldDescription = Nothing
            Me.txtORNumber.FieldName = Nothing
            Me.txtORNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtORNumber.FindEnabled = True
            Me.txtORNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtORNumber.ForeColor = System.Drawing.Color.Black
            Me.txtORNumber.LinkedLabel = Me.lblInvoiceNo
            Me.txtORNumber.Location = New System.Drawing.Point(169, 144)
            Me.txtORNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtORNumber.MaximumValue = Nothing
            Me.txtORNumber.MinimumValue = Nothing
            Me.txtORNumber.Name = "txtORNumber"
            Me.txtORNumber.OldValue = Nothing
            Me.txtORNumber.OverrideMaxLength = 0
            Me.txtORNumber.ReadOnly = True
            Me.txtORNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtORNumber.Size = New System.Drawing.Size(126, 26)
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
            Me.txtAmount.Location = New System.Drawing.Point(695, 112)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.OverrideMaxLength = 0
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.Size = New System.Drawing.Size(119, 26)
            Me.txtAmount.TabIndex = 8
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.Translatable = False
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblAmount
            '
            Me.lblAmount.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.lblAmount, 2)
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(563, 112)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(130, 30)
            Me.lblAmount.TabIndex = 264
            Me.lblAmount.Text = "Amount:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblAmount.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtNotes, 7)
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
            Me.txtNotes.Location = New System.Drawing.Point(169, 212)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(524, 34)
            Me.txtNotes.TabIndex = 14
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'txtVatAmount
            '
            Me.txtVatAmount.BackColor = System.Drawing.Color.White
            Me.txtVatAmount.BegFindValue = Nothing
            Me.txtVatAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVatAmount.ComputedValue = False
            Me.txtVatAmount.CustomFormat = "N2"
            Me.txtVatAmount.DataBoundControl = True
            Me.txtVatAmount.DisplayOnly = True
            Me.txtVatAmount.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtVatAmount.EditingMode = True
            Me.txtVatAmount.EndFindValue = Nothing
            Me.txtVatAmount.FieldDescription = Nothing
            Me.txtVatAmount.FieldName = Nothing
            Me.txtVatAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVatAmount.FindEnabled = True
            Me.txtVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
            Me.txtVatAmount.LinkedLabel = Me.lblApplied
            Me.txtVatAmount.Location = New System.Drawing.Point(1013, 13)
            Me.txtVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatAmount.MaximumValue = Nothing
            Me.txtVatAmount.MinimumValue = Nothing
            Me.txtVatAmount.Name = "txtVatAmount"
            Me.txtVatAmount.OldValue = Nothing
            Me.txtVatAmount.OverrideMaxLength = 0
            Me.txtVatAmount.ReadOnly = True
            Me.txtVatAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatAmount.Size = New System.Drawing.Size(115, 26)
            Me.txtVatAmount.TabIndex = 15
            Me.txtVatAmount.TabStop = False
            Me.txtVatAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtVatAmount.Translatable = False
            Me.txtVatAmount.ValueIsMandatory = True
            Me.txtVatAmount.ValueIsNumeric = True
            '
            'lblApplied
            '
            Me.lblApplied.AutoSize = True
            Me.lblApplied.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.lblApplied, 2)
            Me.lblApplied.DisplayOnly = True
            Me.lblApplied.EditingMode = False
            Me.lblApplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblApplied.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblApplied.Location = New System.Drawing.Point(816, 46)
            Me.lblApplied.Margin = New System.Windows.Forms.Padding(1)
            Me.lblApplied.Name = "lblApplied"
            Me.lblApplied.Size = New System.Drawing.Size(126, 20)
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
            Me.txtApplied.ComputedValue = False
            Me.txtApplied.CustomFormat = "N2"
            Me.txtApplied.DataBoundControl = True
            Me.txtApplied.DisplayOnly = True
            Me.txtApplied.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtApplied.EditingMode = True
            Me.txtApplied.EndFindValue = Nothing
            Me.txtApplied.FieldDescription = Nothing
            Me.txtApplied.FieldName = Nothing
            Me.txtApplied.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtApplied.FindEnabled = True
            Me.txtApplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtApplied.ForeColor = System.Drawing.Color.Black
            Me.txtApplied.LinkedLabel = Me.lblApplied
            Me.txtApplied.Location = New System.Drawing.Point(1013, 46)
            Me.txtApplied.Margin = New System.Windows.Forms.Padding(1)
            Me.txtApplied.MaximumValue = Nothing
            Me.txtApplied.MinimumValue = Nothing
            Me.txtApplied.Name = "txtApplied"
            Me.txtApplied.OldValue = Nothing
            Me.txtApplied.OverrideMaxLength = 0
            Me.txtApplied.ReadOnly = True
            Me.txtApplied.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtApplied.Size = New System.Drawing.Size(115, 26)
            Me.txtApplied.TabIndex = 16
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
            Me.txtUnapplied.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtUnapplied.EditingMode = True
            Me.txtUnapplied.EndFindValue = Nothing
            Me.txtUnapplied.FieldDescription = Nothing
            Me.txtUnapplied.FieldName = Nothing
            Me.txtUnapplied.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtUnapplied.FindEnabled = True
            Me.txtUnapplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtUnapplied.ForeColor = System.Drawing.Color.Black
            Me.txtUnapplied.LinkedLabel = Me.CLabel2
            Me.txtUnapplied.Location = New System.Drawing.Point(1013, 79)
            Me.txtUnapplied.Margin = New System.Windows.Forms.Padding(1)
            Me.txtUnapplied.MaximumValue = Nothing
            Me.txtUnapplied.MinimumValue = Nothing
            Me.txtUnapplied.Name = "txtUnapplied"
            Me.txtUnapplied.OldValue = Nothing
            Me.txtUnapplied.OverrideMaxLength = 0
            Me.txtUnapplied.ReadOnly = True
            Me.txtUnapplied.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtUnapplied.Size = New System.Drawing.Size(115, 26)
            Me.txtUnapplied.TabIndex = 17
            Me.txtUnapplied.TabStop = False
            Me.txtUnapplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtUnapplied.Translatable = False
            Me.txtUnapplied.ValueIsMandatory = True
            Me.txtUnapplied.ValueIsNumeric = True
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.CLabel2, 2)
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel2.Location = New System.Drawing.Point(816, 79)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(145, 20)
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
            Me.txtDiscountTaken.ComputedValue = False
            Me.txtDiscountTaken.CustomFormat = "N2"
            Me.txtDiscountTaken.DataBoundControl = True
            Me.txtDiscountTaken.DisplayOnly = True
            Me.txtDiscountTaken.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDiscountTaken.EditingMode = True
            Me.txtDiscountTaken.EndFindValue = Nothing
            Me.txtDiscountTaken.FieldDescription = Nothing
            Me.txtDiscountTaken.FieldName = Nothing
            Me.txtDiscountTaken.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDiscountTaken.FindEnabled = True
            Me.txtDiscountTaken.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDiscountTaken.ForeColor = System.Drawing.Color.Black
            Me.txtDiscountTaken.LinkedLabel = Me.lblDiscountTaken
            Me.txtDiscountTaken.Location = New System.Drawing.Point(1013, 112)
            Me.txtDiscountTaken.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDiscountTaken.MaximumValue = Nothing
            Me.txtDiscountTaken.MinimumValue = Nothing
            Me.txtDiscountTaken.Name = "txtDiscountTaken"
            Me.txtDiscountTaken.OldValue = Nothing
            Me.txtDiscountTaken.OverrideMaxLength = 0
            Me.txtDiscountTaken.ReadOnly = True
            Me.txtDiscountTaken.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDiscountTaken.Size = New System.Drawing.Size(115, 26)
            Me.txtDiscountTaken.TabIndex = 18
            Me.txtDiscountTaken.TabStop = False
            Me.txtDiscountTaken.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtDiscountTaken.Translatable = False
            Me.txtDiscountTaken.ValueIsMandatory = True
            Me.txtDiscountTaken.ValueIsNumeric = True
            '
            'lblDiscountTaken
            '
            Me.lblDiscountTaken.AutoSize = True
            Me.lblDiscountTaken.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.lblDiscountTaken, 2)
            Me.lblDiscountTaken.DisplayOnly = True
            Me.lblDiscountTaken.EditingMode = False
            Me.lblDiscountTaken.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDiscountTaken.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDiscountTaken.Location = New System.Drawing.Point(816, 112)
            Me.lblDiscountTaken.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDiscountTaken.Name = "lblDiscountTaken"
            Me.lblDiscountTaken.Size = New System.Drawing.Size(126, 20)
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
            Me.DataGridViewDjOiItems.Cached = False
            Me.DataGridViewDjOiItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDjOiItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceDjOi, Me.dgvInvoiceNo, Me.DgvTransactionDate, Me.dgvJournalCode, Me.dgvJournalIdNoAp, Me.dgvPreviousBalance, Me.dgvAmount, Me.dgvDiscountTaken, Me.dgvBalance, Me.DataGridViewTextBoxColumn6})
            Me.tlpDisbursement.SetColumnSpan(Me.DataGridViewDjOiItems, 12)
            Me.DataGridViewDjOiItems.DataFilter = Nothing
            Me.DataGridViewDjOiItems.DataSource = Me.bsDjOiItems
            DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle21.BackColor = System.Drawing.Color.Black
            DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDjOiItems.DefaultCellStyle = DataGridViewCellStyle21
            Me.DataGridViewDjOiItems.DgvFooter = Nothing
            Me.DataGridViewDjOiItems.DisplayOnly = False
            Me.DataGridViewDjOiItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewDjOiItems.Ea = EventAggregator2
            Me.DataGridViewDjOiItems.EditingMode = False
            Me.DataGridViewDjOiItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewDjOiItems.EndFindValue = Nothing
            Me.DataGridViewDjOiItems.FieldDescription = Nothing
            Me.DataGridViewDjOiItems.FieldName = Nothing
            Me.DataGridViewDjOiItems.FieldsDictionary = Nothing
            Me.DataGridViewDjOiItems.FindColumnNo = CType(0, Short)
            Me.DataGridViewDjOiItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewDjOiItems.FindEnabled = False
            Me.DataGridViewDjOiItems.FirstRowDeletionEnabled = False
            Me.DataGridViewDjOiItems.FirstRowInsertionEnabled = False
            Me.DataGridViewDjOiItems.IgnoreCase = False
            Me.DataGridViewDjOiItems.IsDirty = False
            Me.DataGridViewDjOiItems.Location = New System.Drawing.Point(17, 677)
            Me.DataGridViewDjOiItems.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewDjOiItems.MinimumSize = New System.Drawing.Size(0, 412)
            Me.DataGridViewDjOiItems.Name = "DataGridViewDjOiItems"
            Me.DataGridViewDjOiItems.ReadOnly = True
            Me.DataGridViewDjOiItems.RowHeadersWidth = 51
            Me.DataGridViewDjOiItems.Searchable = True
            Me.DataGridViewDjOiItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewDjOiItems.SecurityKey = ""
            Me.DataGridViewDjOiItems.SequenceColumn = "dgvSequencePcsOi"
            Me.DataGridViewDjOiItems.SequenceFieldName = "Sequence"
            Me.DataGridViewDjOiItems.ShowFooter = False
            Me.DataGridViewDjOiItems.Size = New System.Drawing.Size(1108, 444)
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
            Me.dgvSequenceDjOi.MinimumWidth = 6
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
            Me.dgvInvoiceNo.MinimumWidth = 6
            Me.dgvInvoiceNo.Name = "dgvInvoiceNo"
            Me.dgvInvoiceNo.ReadOnly = True
            Me.dgvInvoiceNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvInvoiceNo.Translatable = False
            Me.dgvInvoiceNo.Width = 125
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
            Me.DgvTransactionDate.MinimumWidth = 6
            Me.DgvTransactionDate.Name = "DgvTransactionDate"
            Me.DgvTransactionDate.ReadOnly = True
            Me.DgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DgvTransactionDate.Translatable = False
            Me.DgvTransactionDate.Width = 125
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
            Me.dgvJournalCode.MinimumWidth = 6
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
            Me.dgvJournalIdNoAp.MinimumWidth = 6
            Me.dgvJournalIdNoAp.Name = "dgvJournalIdNoAp"
            Me.dgvJournalIdNoAp.ReadOnly = True
            Me.dgvJournalIdNoAp.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvJournalIdNoAp.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvJournalIdNoAp.Translatable = False
            Me.dgvJournalIdNoAp.Width = 125
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
            Me.dgvPreviousBalance.MinimumWidth = 6
            Me.dgvPreviousBalance.Name = "dgvPreviousBalance"
            Me.dgvPreviousBalance.ReadOnly = True
            Me.dgvPreviousBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPreviousBalance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPreviousBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvPreviousBalance.Translatable = False
            Me.dgvPreviousBalance.Width = 125
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
            Me.dgvAmount.MinimumWidth = 6
            Me.dgvAmount.Name = "dgvAmount"
            Me.dgvAmount.ReadOnly = True
            Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvAmount.Translatable = False
            Me.dgvAmount.Width = 125
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
            Me.dgvDiscountTaken.MinimumWidth = 6
            Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
            Me.dgvDiscountTaken.ReadOnly = True
            Me.dgvDiscountTaken.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDiscountTaken.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDiscountTaken.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDiscountTaken.Translatable = False
            Me.dgvDiscountTaken.Width = 125
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
            Me.dgvBalance.MinimumWidth = 6
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
            Me.DataGridViewTextBoxColumn6.MinimumWidth = 6
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            Me.DataGridViewTextBoxColumn6.Visible = False
            Me.DataGridViewTextBoxColumn6.Width = 125
            '
            'bsDjOiItems
            '
            Me.bsDjOiItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DjOiItemModel)
            '
            'dtpCheckDate
            '
            Me.dtpCheckDate.AutoSize = True
            Me.dtpCheckDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpCheckDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpCheckDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpCheckDate.DefaultValue = Nothing
            Me.dtpCheckDate.DisplayOnly = False
            Me.dtpCheckDate.DtpDefaultValue = Nothing
            Me.dtpCheckDate.EditingMode = False
            Me.dtpCheckDate.EditsAllowed = False
            Me.dtpCheckDate.ForeColor = System.Drawing.Color.Black
            Me.dtpCheckDate.LinkedLabel = Nothing
            Me.dtpCheckDate.Location = New System.Drawing.Point(695, 179)
            Me.dtpCheckDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpCheckDate.Name = "dtpCheckDate"
            Me.dtpCheckDate.ReadOnlyDp = False
            Me.dtpCheckDate.SecurityKey = Nothing
            Me.dtpCheckDate.ShowLongDate = False
            Me.dtpCheckDate.ShowTime = False
            Me.dtpCheckDate.Size = New System.Drawing.Size(119, 27)
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
            Me.txtVatNumber.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtVatNumber.EditingMode = False
            Me.txtVatNumber.EndFindValue = Nothing
            Me.txtVatNumber.FieldDescription = Nothing
            Me.txtVatNumber.FieldName = Nothing
            Me.txtVatNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVatNumber.FindEnabled = True
            Me.txtVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
            Me.txtVatNumber.LinkedLabel = Me.lblApplied
            Me.txtVatNumber.Location = New System.Drawing.Point(420, 144)
            Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MaxLength = 15
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.OverrideMaxLength = 0
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVatNumber.Size = New System.Drawing.Size(141, 26)
            Me.txtVatNumber.TabIndex = 10
            Me.txtVatNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
            Me.txtCheckNumber.Location = New System.Drawing.Point(695, 144)
            Me.txtCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCheckNumber.MaximumValue = Nothing
            Me.txtCheckNumber.MinimumValue = Nothing
            Me.txtCheckNumber.Name = "txtCheckNumber"
            Me.txtCheckNumber.OldValue = Nothing
            Me.txtCheckNumber.OverrideMaxLength = 0
            Me.txtCheckNumber.ReadOnly = True
            Me.txtCheckNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCheckNumber.Size = New System.Drawing.Size(119, 26)
            Me.txtCheckNumber.TabIndex = 11
            Me.txtCheckNumber.Translatable = False
            Me.txtCheckNumber.ValueIsMandatory = True
            '
            'lblVatAmount
            '
            Me.lblVatAmount.AutoSize = True
            Me.lblVatAmount.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.lblVatAmount, 2)
            Me.lblVatAmount.DisplayOnly = True
            Me.lblVatAmount.EditingMode = False
            Me.lblVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatAmount.Location = New System.Drawing.Point(816, 13)
            Me.lblVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatAmount.Name = "lblVatAmount"
            Me.lblVatAmount.Size = New System.Drawing.Size(96, 20)
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
            Me.tlpDisbursement.SetColumnSpan(Me.cboPaymentType, 4)
            Me.cboPaymentType.CurrentSearchTerm = ""
            Me.cboPaymentType.DataValue = Nothing
            Me.cboPaymentType.DefaultValue = "0"
            Me.cboPaymentType.DisplayMember = "Name"
            Me.cboPaymentType.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPaymentType.DropDownHeight = 24
            Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPaymentType.Editable = True
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
            Me.cboPaymentType.LimitToList = False
            Me.cboPaymentType.LinkedLabel = Me.lblPaymentType
            Me.cboPaymentType.Location = New System.Drawing.Point(169, 46)
            Me.cboPaymentType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPaymentType.MaxDropDownItems = 1
            Me.cboPaymentType.Name = "cboPaymentType"
            Me.cboPaymentType.OldValue = 0
            Me.cboPaymentType.OriginalDataSource = Nothing
            Me.cboPaymentType.OriginalList = Nothing
            Me.cboPaymentType.OverrideDropDownStyleList = False
            Me.cboPaymentType.PreviousSearchTerm = Nothing
            Me.cboPaymentType.PropertySelector = Nothing
            Me.cboPaymentType.ReadOnlyCombo = False
            Me.cboPaymentType.Size = New System.Drawing.Size(249, 31)
            Me.cboPaymentType.SuggestBoxHeight = 200
            Me.cboPaymentType.SuggestListOrderRule = Nothing
            Me.cboPaymentType.TabIndex = 3
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
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(208, 13)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = ""
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(87, 26)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'cboPayeeIdNo
            '
            Me.cboPayeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayeeIdNo.BegFindValue = Nothing
            Me.cboPayeeIdNo.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPayeeIdNo, 5)
            Me.cboPayeeIdNo.CurrentSearchTerm = ""
            Me.cboPayeeIdNo.DataValue = Nothing
            Me.cboPayeeIdNo.DefaultValue = Nothing
            Me.cboPayeeIdNo.DisplayMember = "Name"
            Me.cboPayeeIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPayeeIdNo.DropDownHeight = 24
            Me.cboPayeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPayeeIdNo.Editable = True
            Me.cboPayeeIdNo.EditingMode = False
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
            Me.cboPayeeIdNo.LimitToList = True
            Me.cboPayeeIdNo.LinkedLabel = Nothing
            Me.cboPayeeIdNo.Location = New System.Drawing.Point(169, 79)
            Me.cboPayeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayeeIdNo.MaxDropDownItems = 1
            Me.cboPayeeIdNo.Name = "cboPayeeIdNo"
            Me.cboPayeeIdNo.OldValue = 0
            Me.cboPayeeIdNo.OriginalDataSource = Nothing
            Me.cboPayeeIdNo.OriginalList = Nothing
            Me.cboPayeeIdNo.OverrideDropDownStyleList = False
            Me.cboPayeeIdNo.PreviousSearchTerm = Nothing
            Me.cboPayeeIdNo.PropertySelector = Nothing
            Me.cboPayeeIdNo.Size = New System.Drawing.Size(392, 31)
            Me.cboPayeeIdNo.SuggestBoxHeight = 200
            Me.cboPayeeIdNo.SuggestCharCount = 0
            Me.cboPayeeIdNo.SuggestListOrderRule = Nothing
            Me.cboPayeeIdNo.TabIndex = 5
            Me.cboPayeeIdNo.TextToSearch = Nothing
            Me.cboPayeeIdNo.Translatable = False
            Me.cboPayeeIdNo.ValueIsMandatory = False
            Me.cboPayeeIdNo.ValueIsNullable = False
            Me.cboPayeeIdNo.ValueIsNumeric = False
            Me.cboPayeeIdNo.ValueMember = "IdNo"
            '
            'lblVatNo
            '
            Me.lblVatNo.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.lblVatNo, 2)
            Me.lblVatNo.DisplayOnly = True
            Me.lblVatNo.EditingMode = False
            Me.lblVatNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatNo.Location = New System.Drawing.Point(297, 144)
            Me.lblVatNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatNo.Name = "lblVatNo"
            Me.lblVatNo.Size = New System.Drawing.Size(106, 33)
            Me.lblVatNo.TabIndex = 2
            Me.lblVatNo.Text = "Vat Number"
            Me.lblVatNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblVatNo.Translatable = True
            '
            'lblReferenceNo
            '
            Me.lblReferenceNo.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.lblReferenceNo, 2)
            Me.lblReferenceNo.DisplayOnly = True
            Me.lblReferenceNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblReferenceNo.EditingMode = False
            Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReferenceNo.Location = New System.Drawing.Point(297, 13)
            Me.lblReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReferenceNo.Name = "lblReferenceNo"
            Me.lblReferenceNo.Size = New System.Drawing.Size(121, 31)
            Me.lblReferenceNo.TabIndex = 2
            Me.lblReferenceNo.Text = "Reference No.:"
            Me.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblReferenceNo.Translatable = True
            '
            'lblSupplierIdNo
            '
            Me.lblSupplierIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierIdNo.DisplayOnly = True
            Me.lblSupplierIdNo.EditingMode = False
            Me.lblSupplierIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblSupplierIdNo.Location = New System.Drawing.Point(14, 79)
            Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            Me.lblSupplierIdNo.Size = New System.Drawing.Size(153, 31)
            Me.lblSupplierIdNo.TabIndex = 7
            Me.lblSupplierIdNo.Text = "Payee:"
            Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierIdNo.Translatable = True
            '
            'lblDateCreated
            '
            Me.lblDateCreated.BackColor = System.Drawing.Color.Transparent
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            Me.lblDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.lblDateCreated.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateCreated.Location = New System.Drawing.Point(816, 179)
            Me.lblDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDateCreated.Name = "lblDateCreated"
            Me.lblDateCreated.Size = New System.Drawing.Size(92, 31)
            Me.lblDateCreated.TabIndex = 268
            Me.lblDateCreated.Text = "Date Added:"
            Me.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDateCreated.Translatable = True
            '
            'lblCdJournalIdNo
            '
            Me.lblCdJournalIdNo.AutoSize = True
            Me.lblCdJournalIdNo.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.lblCdJournalIdNo, 2)
            Me.lblCdJournalIdNo.DisplayOnly = True
            Me.lblCdJournalIdNo.EditingMode = False
            Me.lblCdJournalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCdJournalIdNo.Location = New System.Drawing.Point(816, 144)
            Me.lblCdJournalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCdJournalIdNo.Name = "lblCdJournalIdNo"
            Me.lblCdJournalIdNo.Size = New System.Drawing.Size(144, 20)
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
            Me.txtCdJournalIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtCdJournalIdNo.EditingMode = True
            Me.txtCdJournalIdNo.EndFindValue = Nothing
            Me.txtCdJournalIdNo.FieldDescription = Nothing
            Me.txtCdJournalIdNo.FieldName = Nothing
            Me.txtCdJournalIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCdJournalIdNo.FindEnabled = True
            Me.txtCdJournalIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCdJournalIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtCdJournalIdNo.LinkedLabel = Nothing
            Me.txtCdJournalIdNo.Location = New System.Drawing.Point(1013, 144)
            Me.txtCdJournalIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCdJournalIdNo.MaximumValue = Nothing
            Me.txtCdJournalIdNo.MinimumValue = Nothing
            Me.txtCdJournalIdNo.Name = "txtCdJournalIdNo"
            Me.txtCdJournalIdNo.OldValue = Nothing
            Me.txtCdJournalIdNo.OverrideMaxLength = 0
            Me.txtCdJournalIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCdJournalIdNo.Size = New System.Drawing.Size(115, 26)
            Me.txtCdJournalIdNo.TabIndex = 19
            Me.txtCdJournalIdNo.TabStop = False
            Me.txtCdJournalIdNo.Translatable = False
            '
            'lblCheckNumber
            '
            Me.lblCheckNumber.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.lblCheckNumber, 2)
            Me.lblCheckNumber.DisplayOnly = True
            Me.lblCheckNumber.EditingMode = False
            Me.lblCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCheckNumber.Location = New System.Drawing.Point(563, 144)
            Me.lblCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckNumber.Name = "lblCheckNumber"
            Me.lblCheckNumber.Size = New System.Drawing.Size(130, 33)
            Me.lblCheckNumber.TabIndex = 290
            Me.lblCheckNumber.Text = "Check Number"
            Me.lblCheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblCheckNumber.Translatable = True
            '
            'lblCheckDate
            '
            Me.lblCheckDate.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.lblCheckDate, 2)
            Me.lblCheckDate.DisplayOnly = True
            Me.lblCheckDate.EditingMode = False
            Me.lblCheckDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCheckDate.Location = New System.Drawing.Point(563, 179)
            Me.lblCheckDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckDate.Name = "lblCheckDate"
            Me.lblCheckDate.Size = New System.Drawing.Size(130, 31)
            Me.lblCheckDate.TabIndex = 284
            Me.lblCheckDate.Text = "Check Date"
            Me.lblCheckDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblCheckDate.Translatable = True
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
            Me.chkApproved.FindEnabled = True
            Me.chkApproved.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkApproved.IgnoreCase = False
            Me.chkApproved.LinkedLabel = Nothing
            Me.chkApproved.Location = New System.Drawing.Point(699, 216)
            Me.chkApproved.Margin = New System.Windows.Forms.Padding(5)
            Me.chkApproved.Name = "chkApproved"
            Me.chkApproved.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkApproved.Size = New System.Drawing.Size(103, 26)
            Me.chkApproved.TabIndex = 298
            Me.chkApproved.Text = "Approved?"
            Me.chkApproved.Translatable = True
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
            Me.chkCancelled.FindEnabled = True
            Me.chkCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCancelled.IgnoreCase = False
            Me.chkCancelled.LinkedLabel = Nothing
            Me.chkCancelled.Location = New System.Drawing.Point(1017, 216)
            Me.chkCancelled.Margin = New System.Windows.Forms.Padding(5)
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkCancelled.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkCancelled.Size = New System.Drawing.Size(107, 26)
            Me.chkCancelled.TabIndex = 301
            Me.chkCancelled.Text = "Cancelled?"
            Me.chkCancelled.Translatable = True
            '
            'txtPayeeName
            '
            Me.txtPayeeName.BackColor = System.Drawing.Color.White
            Me.txtPayeeName.BegFindValue = Nothing
            Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtPayeeName, 3)
            Me.txtPayeeName.ComputedValue = False
            Me.txtPayeeName.CustomFormat = Nothing
            Me.txtPayeeName.DataBoundControl = True
            Me.txtPayeeName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayeeName.EditingMode = False
            Me.txtPayeeName.EndFindValue = Nothing
            Me.txtPayeeName.FieldDescription = Nothing
            Me.txtPayeeName.FieldName = Nothing
            Me.txtPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayeeName.FindEnabled = False
            Me.txtPayeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
            Me.txtPayeeName.LinkedLabel = Me.lblAmount
            Me.txtPayeeName.Location = New System.Drawing.Point(563, 79)
            Me.txtPayeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayeeName.MaximumValue = Nothing
            Me.txtPayeeName.MinimumValue = Nothing
            Me.txtPayeeName.Name = "txtPayeeName"
            Me.txtPayeeName.OldValue = Nothing
            Me.txtPayeeName.OverrideMaxLength = 0
            Me.txtPayeeName.ReadOnly = True
            Me.txtPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayeeName.Size = New System.Drawing.Size(251, 26)
            Me.txtPayeeName.TabIndex = 6
            Me.txtPayeeName.Translatable = False
            Me.txtPayeeName.ValueIsMandatory = True
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
            Me.txtReferenceNo.Location = New System.Drawing.Point(420, 13)
            Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.OverrideMaxLength = 0
            Me.txtReferenceNo.ReadOnly = True
            Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReferenceNo.Size = New System.Drawing.Size(141, 26)
            Me.txtReferenceNo.TabIndex = 1
            Me.txtReferenceNo.Translatable = False
            Me.txtReferenceNo.ValueIsMandatory = True
            '
            'lblPayType
            '
            Me.lblPayType.BackColor = System.Drawing.Color.Transparent
            Me.lblPayType.DisplayOnly = True
            Me.lblPayType.EditingMode = False
            Me.lblPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPayType.Location = New System.Drawing.Point(420, 46)
            Me.lblPayType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayType.Name = "lblPayType"
            Me.lblPayType.Size = New System.Drawing.Size(141, 31)
            Me.lblPayType.TabIndex = 292
            Me.lblPayType.Text = "Pay Type:"
            Me.lblPayType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblPayType.Translatable = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.BackColor = System.Drawing.Color.Transparent
            Me.tlpDisbursement.SetColumnSpan(Me.lblTransactionDate, 2)
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionDate.Location = New System.Drawing.Point(563, 13)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(130, 31)
            Me.lblTransactionDate.TabIndex = 4
            Me.lblTransactionDate.Text = "Date:"
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
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Location = New System.Drawing.Point(695, 13)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpTransactionDate.TabIndex = 2
            Me.dtpTransactionDate.TargetCalendar = Nothing
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'btnViewGL
            '
            Me.btnViewGL.DesignerSelected = False
            Me.btnViewGL.Font = New System.Drawing.Font("Tahoma", 8.0!)
            Me.btnViewGL.ImageIndex = 0
            Me.btnViewGL.Location = New System.Drawing.Point(4, 4)
            Me.btnViewGL.Margin = New System.Windows.Forms.Padding(4)
            Me.btnViewGL.Name = "btnViewGL"
            Me.btnViewGL.OriginalImageName = Nothing
            Me.btnViewGL.SecurityKey = ""
            Me.btnViewGL.Size = New System.Drawing.Size(141, 31)
            Me.btnViewGL.TabIndex = 24
            Me.btnViewGL.TabStop = False
            Me.btnViewGL.Text = "View Journal Entry"
            '
            'btnAutoApply
            '
            Me.btnAutoApply.DesignerSelected = False
            Me.btnAutoApply.Font = New System.Drawing.Font("Tahoma", 8.0!)
            Me.btnAutoApply.ImageIndex = 0
            Me.btnAutoApply.Location = New System.Drawing.Point(153, 4)
            Me.btnAutoApply.Margin = New System.Windows.Forms.Padding(4)
            Me.btnAutoApply.Name = "btnAutoApply"
            Me.btnAutoApply.OriginalImageName = Nothing
            Me.btnAutoApply.SecurityKey = ""
            Me.btnAutoApply.Size = New System.Drawing.Size(142, 31)
            Me.btnAutoApply.TabIndex = 25
            Me.btnAutoApply.TabStop = False
            Me.btnAutoApply.Text = "Auto Apply Invoices"
            '
            'btnPrintCheck
            '
            Me.btnPrintCheck.DesignerSelected = False
            Me.btnPrintCheck.ImageIndex = 0
            Me.btnPrintCheck.Location = New System.Drawing.Point(303, 4)
            Me.btnPrintCheck.Margin = New System.Windows.Forms.Padding(4)
            Me.btnPrintCheck.Name = "btnPrintCheck"
            Me.btnPrintCheck.OriginalImageName = Nothing
            Me.btnPrintCheck.SecurityKey = ""
            Me.btnPrintCheck.Size = New System.Drawing.Size(167, 31)
            Me.btnPrintCheck.TabIndex = 291
            Me.btnPrintCheck.TabStop = False
            Me.btnPrintCheck.Text = "Print Check"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.btnViewGL)
            Me.CFlowLayout1.Controls.Add(Me.btnAutoApply)
            Me.CFlowLayout1.Controls.Add(Me.btnPrintCheck)
            Me.CFlowLayout1.Controls.Add(Me.btnPrintPcReplenishment)
            Me.CFlowLayout1.Controls.Add(Me.txtTotalCredits)
            Me.CFlowLayout1.Controls.Add(Me.txtTotalDebits)
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.CFlowLayout1.Location = New System.Drawing.Point(0, 801)
            Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(1132, 37)
            Me.CFlowLayout1.TabIndex = 6
            '
            'btnPrintPcReplenishment
            '
            Me.btnPrintPcReplenishment.DesignerSelected = False
            Me.btnPrintPcReplenishment.ImageIndex = 0
            Me.btnPrintPcReplenishment.Location = New System.Drawing.Point(478, 4)
            Me.btnPrintPcReplenishment.Margin = New System.Windows.Forms.Padding(4)
            Me.btnPrintPcReplenishment.Name = "btnPrintPcReplenishment"
            Me.btnPrintPcReplenishment.OriginalImageName = Nothing
            Me.btnPrintPcReplenishment.SecurityKey = ""
            Me.btnPrintPcReplenishment.Size = New System.Drawing.Size(434, 31)
            Me.btnPrintPcReplenishment.TabIndex = 292
            Me.btnPrintPcReplenishment.Text = "Print Petty Cash Replenishment Report"
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
            Me.txtTotalCredits.Location = New System.Drawing.Point(917, 1)
            Me.txtTotalCredits.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTotalCredits.MaximumValue = Nothing
            Me.txtTotalCredits.MinimumValue = Nothing
            Me.txtTotalCredits.Name = "txtTotalCredits"
            Me.txtTotalCredits.OldValue = Nothing
            Me.txtTotalCredits.OverrideMaxLength = 0
            Me.txtTotalCredits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalCredits.Size = New System.Drawing.Size(95, 26)
            Me.txtTotalCredits.TabIndex = 0
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
            Me.txtTotalDebits.Location = New System.Drawing.Point(1014, 1)
            Me.txtTotalDebits.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTotalDebits.MaximumValue = Nothing
            Me.txtTotalDebits.MinimumValue = Nothing
            Me.txtTotalDebits.Name = "txtTotalDebits"
            Me.txtTotalDebits.OldValue = Nothing
            Me.txtTotalDebits.OverrideMaxLength = 0
            Me.txtTotalDebits.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalDebits.Size = New System.Drawing.Size(103, 26)
            Me.txtTotalDebits.TabIndex = 1
            Me.txtTotalDebits.Translatable = False
            Me.txtTotalDebits.Visible = False
            '
            'txtDateCreated
            '
            Me.txtDateCreated.BackColor = System.Drawing.Color.White
            Me.txtDateCreated.BegFindValue = Nothing
            Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtDateCreated, 2)
            Me.txtDateCreated.ComputedValue = False
            Me.txtDateCreated.CustomFormat = Nothing
            Me.txtDateCreated.DataBoundControl = True
            Me.txtDateCreated.DisplayOnly = True
            Me.txtDateCreated.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDateCreated.EditingMode = True
            Me.txtDateCreated.EndFindValue = Nothing
            Me.txtDateCreated.FieldDescription = Nothing
            Me.txtDateCreated.FieldName = Nothing
            Me.txtDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDateCreated.FindEnabled = True
            Me.txtDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
            Me.txtDateCreated.LinkedLabel = Nothing
            Me.txtDateCreated.Location = New System.Drawing.Point(914, 179)
            Me.txtDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDateCreated.MaximumValue = Nothing
            Me.txtDateCreated.MinimumValue = Nothing
            Me.txtDateCreated.Name = "txtDateCreated"
            Me.txtDateCreated.OldValue = Nothing
            Me.txtDateCreated.OverrideMaxLength = 0
            Me.txtDateCreated.ReadOnly = True
            Me.txtDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDateCreated.Size = New System.Drawing.Size(214, 26)
            Me.txtDateCreated.TabIndex = 20
            Me.txtDateCreated.TabStop = False
            Me.txtDateCreated.Translatable = False
            '
            'DisbursementJournalEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoSize = True
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(1132, 838)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.tlpDisbursement)
            Me.DefaultFormBackColor = System.Drawing.Color.Transparent
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.MinimumSize = New System.Drawing.Size(1000, 860)
            Me.Name = "DisbursementJournalEntry"
            Me.Text = "Petty Cash Journal "
            Me.Controls.SetChildIndex(Me.tlpDisbursement, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tlpDisbursement.ResumeLayout(False)
            Me.tlpDisbursement.PerformLayout()
            CType(Me.DataGridViewJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewDjOiItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsDjOiItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
        Friend WithEvents cboPayeeIdNo As CtComboBox
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
        Friend WithEvents txtDateCreated As CTextBox
    End Class
End Namespace