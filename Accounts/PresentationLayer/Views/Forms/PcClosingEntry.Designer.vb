Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PcClosingEntry
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
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PcClosingEntry))
            Me.tlpDisbursement = New System.Windows.Forms.TableLayoutPanel()
            Me.cboPayType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.btnViewGL = New AATM.Libraries.CBaseControlsLibrary.CButton()
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
            Me.bsDjOiItems = New System.Windows.Forms.BindingSource(Me.components)
            Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCheckDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtVatNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblVatAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnPrintCheck = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblVatNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCancelled = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkCancelled = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.dtpTransactionDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblSupplierIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblDateCreated = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpDateCreated = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblPosted = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkPosted = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblPcClosed = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkPcClosed = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblPayType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tlpDisbursement.SuspendLayout()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewDjOiItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsDjOiItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.tlpDisbursement.Controls.Add(Me.btnViewGL, 0, 9)
            Me.tlpDisbursement.Controls.Add(Me.lblDiscountAccountIdNo, 0, 5)
            Me.tlpDisbursement.Controls.Add(Me.lblNotes, 0, 6)
            Me.tlpDisbursement.Controls.Add(Me.cboAccountIdNo, 1, 3)
            Me.tlpDisbursement.Controls.Add(Me.lblAccountIdNo, 0, 3)
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
            Me.tlpDisbursement.Controls.Add(Me.btnAutoApply, 2, 9)
            Me.tlpDisbursement.Controls.Add(Me.DataGridViewDjOiItems, 12, 8)
            Me.tlpDisbursement.Controls.Add(Me.txtPayeeName, 6, 9)
            Me.tlpDisbursement.Controls.Add(Me.lblCheckDate, 7, 5)
            Me.tlpDisbursement.Controls.Add(Me.txtVatNumber, 5, 4)
            Me.tlpDisbursement.Controls.Add(Me.txtCheckNumber, 8, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblCheckNumber, 7, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblApplied, 9, 1)
            Me.tlpDisbursement.Controls.Add(Me.lblVatAmount, 9, 0)
            Me.tlpDisbursement.Controls.Add(Me.btnPrintCheck, 10, 9)
            Me.tlpDisbursement.Controls.Add(Me.TxtIdNo, 2, 0)
            Me.tlpDisbursement.Controls.Add(Me.txtReferenceNo, 6, 0)
            Me.tlpDisbursement.Controls.Add(Me.cboPayeeIdNo, 1, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblVatNo, 3, 4)
            Me.tlpDisbursement.Controls.Add(Me.lblReferenceNo, 3, 0)
            Me.tlpDisbursement.Controls.Add(Me.lblCancelled, 9, 4)
            Me.tlpDisbursement.Controls.Add(Me.chkCancelled, 11, 4)
            Me.tlpDisbursement.Controls.Add(Me.dtpTransactionDate, 8, 0)
            Me.tlpDisbursement.Controls.Add(Me.lblSupplierIdNo, 0, 2)
            Me.tlpDisbursement.Controls.Add(Me.CLabel2, 9, 2)
            Me.tlpDisbursement.Controls.Add(Me.lblDateCreated, 9, 7)
            Me.tlpDisbursement.Controls.Add(Me.dtpDateCreated, 10, 7)
            Me.tlpDisbursement.Controls.Add(Me.lblPosted, 9, 6)
            Me.tlpDisbursement.Controls.Add(Me.chkPosted, 11, 6)
            Me.tlpDisbursement.Controls.Add(Me.lblPcClosed, 9, 5)
            Me.tlpDisbursement.Controls.Add(Me.chkPcClosed, 11, 5)
            Me.tlpDisbursement.Dock = System.Windows.Forms.DockStyle.Left
            Me.tlpDisbursement.Location = New System.Drawing.Point(0, 0)
            Me.tlpDisbursement.Name = "tlpDisbursement"
            Me.tlpDisbursement.RowCount = 10
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.tlpDisbursement.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.tlpDisbursement.Size = New System.Drawing.Size(984, 645)
            Me.tlpDisbursement.TabIndex = 5
            '
            'cboPayType
            '
            Me.cboPayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPayType.BackColor = System.Drawing.Color.White
            Me.cboPayType.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPayType, 2)
            Me.cboPayType.CurrentSearchTerm = ""
            Me.cboPayType.DefaultValue = "0"
            Me.cboPayType.DisplayMember = "Name"
            Me.cboPayType.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPayType.DropDownHeight = 1
            Me.cboPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboPayType.EditingMode = False
            Me.cboPayType.FilterRule = Nothing
            Me.cboPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayType.ForeColor = System.Drawing.Color.Black
            Me.cboPayType.HideWhenNotEditingOrAdding = False
            Me.cboPayType.IntegralHeight = False
            Me.cboPayType.Location = New System.Drawing.Point(483, 28)
            Me.cboPayType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayType.Name = "cboPayType"
            Me.cboPayType.OldValue = 0
            Me.cboPayType.OriginalDataSource = Nothing
            Me.cboPayType.OriginalList = Nothing
            Me.cboPayType.OverrideDropDownStyleList = False
            Me.cboPayType.PreviousSearchTerm = Nothing
            Me.cboPayType.PreviousSelectedIndex = 0
            Me.cboPayType.PropertySelector = Nothing
            Me.cboPayType.ReadOnlyCombo = False
            Me.cboPayType.SearchAnywhere = False
            Me.cboPayType.Size = New System.Drawing.Size(224, 25)
            Me.cboPayType.SuggestBoxHeight = 200
            Me.cboPayType.SuggestListOrderRule = Nothing
            Me.cboPayType.TabIndex = 5
            Me.cboPayType.TextToSearch = Nothing
            Me.cboPayType.ValueIsMandatory = False
            Me.cboPayType.ValueIsNullable = False
            Me.cboPayType.ValueIsNumeric = False
            Me.cboPayType.ValueMember = "Code"
            '
            'btnViewGL
            '
            Me.tlpDisbursement.SetColumnSpan(Me.btnViewGL, 2)
            Me.btnViewGL.DesignerSelected = False
            Me.btnViewGL.DisplayOnly = True
            Me.btnViewGL.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnViewGL.Font = New System.Drawing.Font("Tahoma", 8.0!)
            Me.btnViewGL.ImageIndex = 0
            Me.btnViewGL.Location = New System.Drawing.Point(3, 549)
            Me.btnViewGL.Name = "btnViewGL"
            Me.btnViewGL.OriginalImageName = Nothing
            Me.btnViewGL.SecurityKey = ""
            Me.btnViewGL.Size = New System.Drawing.Size(141, 93)
            Me.btnViewGL.TabIndex = 24
            Me.btnViewGL.TabStop = False
            Me.btnViewGL.Text = "View Journal Entry"
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
            Me.lblDiscountAccountIdNo.Location = New System.Drawing.Point(1, 137)
            Me.lblDiscountAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDiscountAccountIdNo.Name = "lblDiscountAccountIdNo"
            Me.lblDiscountAccountIdNo.Size = New System.Drawing.Size(115, 24)
            Me.lblDiscountAccountIdNo.TabIndex = 281
            Me.lblDiscountAccountIdNo.Text = "Discount Acct."
            Me.lblDiscountAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(1, 164)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(115, 23)
            Me.lblNotes.TabIndex = 161
            Me.lblNotes.Text = "Description/Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cboAccountIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboAccountIdNo.DropDownHeight = 1
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IntegralHeight = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
            Me.cboAccountIdNo.Location = New System.Drawing.Point(118, 82)
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
            Me.cboAccountIdNo.Size = New System.Drawing.Size(363, 24)
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TabIndex = 7
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
            Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAccountIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAccountIdNo.Location = New System.Drawing.Point(1, 82)
            Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Size = New System.Drawing.Size(115, 18)
            Me.lblAccountIdNo.TabIndex = 266
            Me.lblAccountIdNo.Text = "Acct. to Credit:"
            Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.txtJournalCode.Location = New System.Drawing.Point(118, 1)
            Me.txtJournalCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtJournalCode.MaximumValue = Nothing
            Me.txtJournalCode.MinimumValue = Nothing
            Me.txtJournalCode.Name = "txtJournalCode"
            Me.txtJournalCode.OldValue = Nothing
            Me.txtJournalCode.ReadOnly = True
            Me.txtJournalCode.Size = New System.Drawing.Size(28, 23)
            Me.txtJournalCode.TabIndex = 0
            Me.txtJournalCode.TabStop = False
            Me.txtJournalCode.Text = "PC"
            Me.txtJournalCode.ValueIsMandatory = True
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(115, 23)
            Me.lblIdNo.TabIndex = 17
            Me.lblIdNo.Text = "Transaction No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cboDiscountAccountIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboDiscountAccountIdNo.DropDownHeight = 1
            Me.cboDiscountAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboDiscountAccountIdNo.EditingMode = False
            Me.cboDiscountAccountIdNo.FilterRule = Nothing
            Me.cboDiscountAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDiscountAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboDiscountAccountIdNo.FormattingEnabled = True
            Me.cboDiscountAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboDiscountAccountIdNo.IntegralHeight = False
            Me.cboDiscountAccountIdNo.ItemHeight = 16
            Me.cboDiscountAccountIdNo.LinkedLabel = Nothing
            Me.cboDiscountAccountIdNo.Location = New System.Drawing.Point(118, 137)
            Me.cboDiscountAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
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
            Me.cboDiscountAccountIdNo.Size = New System.Drawing.Size(363, 25)
            Me.cboDiscountAccountIdNo.SuggestBoxHeight = 200
            Me.cboDiscountAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboDiscountAccountIdNo.TabIndex = 12
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
            Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblInvoiceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblInvoiceNo.Location = New System.Drawing.Point(1, 108)
            Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            Me.lblInvoiceNo.Size = New System.Drawing.Size(94, 18)
            Me.lblInvoiceNo.TabIndex = 254
            Me.lblInvoiceNo.Text = "Inv./O.R. No."
            Me.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtORNumber
            '
            Me.txtORNumber.BackColor = System.Drawing.Color.White
            Me.txtORNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtORNumber, 2)
            Me.txtORNumber.ComputedValue = False
            Me.txtORNumber.CustomFormat = Nothing
            Me.txtORNumber.DataBoundControl = True
            Me.txtORNumber.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtORNumber.EditingMode = False
            Me.txtORNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtORNumber.ForeColor = System.Drawing.Color.Black
            Me.txtORNumber.LinkedLabel = Me.lblInvoiceNo
            Me.txtORNumber.Location = New System.Drawing.Point(118, 108)
            Me.txtORNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtORNumber.MaximumValue = Nothing
            Me.txtORNumber.MinimumValue = Nothing
            Me.txtORNumber.Name = "txtORNumber"
            Me.txtORNumber.OldValue = Nothing
            Me.txtORNumber.ReadOnly = True
            Me.txtORNumber.Size = New System.Drawing.Size(120, 23)
            Me.txtORNumber.TabIndex = 9
            Me.txtORNumber.ValueIsMandatory = True
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = "N2"
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = False
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Me.lblAmount
            Me.txtAmount.Location = New System.Drawing.Point(595, 82)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.Size = New System.Drawing.Size(112, 23)
            Me.txtAmount.TabIndex = 8
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.ValueIsMandatory = True
            Me.txtAmount.ValueIsNumeric = True
            '
            'lblAmount
            '
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblAmount.Location = New System.Drawing.Point(483, 82)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(101, 24)
            Me.lblAmount.TabIndex = 264
            Me.lblAmount.Text = "Amount:"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTransactionDate.Location = New System.Drawing.Point(483, 1)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(110, 25)
            Me.lblTransactionDate.TabIndex = 4
            Me.lblTransactionDate.Text = "Date:"
            Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtNotes, 8)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtNotes.EditingMode = False
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(118, 164)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.tlpDisbursement.SetRowSpan(Me.txtNotes, 2)
            Me.txtNotes.Size = New System.Drawing.Size(589, 50)
            Me.txtNotes.TabIndex = 14
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
            Me.txtVatAmount.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtVatAmount.EditingMode = True
            Me.txtVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatAmount.ForeColor = System.Drawing.Color.Black
            Me.txtVatAmount.LinkedLabel = Me.lblApplied
            Me.txtVatAmount.Location = New System.Drawing.Point(835, 1)
            Me.txtVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatAmount.MaximumValue = Nothing
            Me.txtVatAmount.MinimumValue = Nothing
            Me.txtVatAmount.Name = "txtVatAmount"
            Me.txtVatAmount.OldValue = Nothing
            Me.txtVatAmount.ReadOnly = True
            Me.txtVatAmount.Size = New System.Drawing.Size(165, 23)
            Me.txtVatAmount.TabIndex = 17
            Me.txtVatAmount.TabStop = False
            Me.txtVatAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
            Me.lblApplied.Location = New System.Drawing.Point(709, 28)
            Me.lblApplied.Margin = New System.Windows.Forms.Padding(1)
            Me.lblApplied.Name = "lblApplied"
            Me.lblApplied.Size = New System.Drawing.Size(107, 17)
            Me.lblApplied.TabIndex = 277
            Me.lblApplied.Text = "Applied Amount"
            Me.lblApplied.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtApplied
            '
            Me.txtApplied.BackColor = System.Drawing.Color.White
            Me.txtApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtApplied.ComputedValue = False
            Me.txtApplied.CustomFormat = "N2"
            Me.txtApplied.DataBoundControl = True
            Me.txtApplied.DisplayOnly = True
            Me.txtApplied.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtApplied.EditingMode = True
            Me.txtApplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtApplied.ForeColor = System.Drawing.Color.Black
            Me.txtApplied.LinkedLabel = Me.lblApplied
            Me.txtApplied.Location = New System.Drawing.Point(835, 28)
            Me.txtApplied.Margin = New System.Windows.Forms.Padding(1)
            Me.txtApplied.MaximumValue = Nothing
            Me.txtApplied.MinimumValue = Nothing
            Me.txtApplied.Name = "txtApplied"
            Me.txtApplied.OldValue = Nothing
            Me.txtApplied.ReadOnly = True
            Me.txtApplied.Size = New System.Drawing.Size(165, 23)
            Me.txtApplied.TabIndex = 18
            Me.txtApplied.TabStop = False
            Me.txtApplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
            Me.txtUnapplied.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtUnapplied.EditingMode = True
            Me.txtUnapplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtUnapplied.ForeColor = System.Drawing.Color.Black
            Me.txtUnapplied.LinkedLabel = Me.CLabel2
            Me.txtUnapplied.Location = New System.Drawing.Point(835, 55)
            Me.txtUnapplied.Margin = New System.Windows.Forms.Padding(1)
            Me.txtUnapplied.MaximumValue = Nothing
            Me.txtUnapplied.MinimumValue = Nothing
            Me.txtUnapplied.Name = "txtUnapplied"
            Me.txtUnapplied.OldValue = Nothing
            Me.txtUnapplied.ReadOnly = True
            Me.txtUnapplied.Size = New System.Drawing.Size(165, 23)
            Me.txtUnapplied.TabIndex = 19
            Me.txtUnapplied.TabStop = False
            Me.txtUnapplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
            Me.CLabel2.Location = New System.Drawing.Point(709, 55)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(124, 17)
            Me.CLabel2.TabIndex = 279
            Me.CLabel2.Text = "Unapplied Amount"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtDiscountTaken
            '
            Me.txtDiscountTaken.BackColor = System.Drawing.Color.White
            Me.txtDiscountTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDiscountTaken.ComputedValue = False
            Me.txtDiscountTaken.CustomFormat = "N2"
            Me.txtDiscountTaken.DataBoundControl = True
            Me.txtDiscountTaken.DisplayOnly = True
            Me.txtDiscountTaken.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDiscountTaken.EditingMode = True
            Me.txtDiscountTaken.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDiscountTaken.ForeColor = System.Drawing.Color.Black
            Me.txtDiscountTaken.LinkedLabel = Me.lblDiscountTaken
            Me.txtDiscountTaken.Location = New System.Drawing.Point(835, 82)
            Me.txtDiscountTaken.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDiscountTaken.MaximumValue = Nothing
            Me.txtDiscountTaken.MinimumValue = Nothing
            Me.txtDiscountTaken.Name = "txtDiscountTaken"
            Me.txtDiscountTaken.OldValue = Nothing
            Me.txtDiscountTaken.ReadOnly = True
            Me.txtDiscountTaken.Size = New System.Drawing.Size(165, 23)
            Me.txtDiscountTaken.TabIndex = 20
            Me.txtDiscountTaken.TabStop = False
            Me.txtDiscountTaken.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
            Me.lblDiscountTaken.Location = New System.Drawing.Point(709, 82)
            Me.lblDiscountTaken.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDiscountTaken.Name = "lblDiscountTaken"
            Me.lblDiscountTaken.Size = New System.Drawing.Size(107, 17)
            Me.lblDiscountTaken.TabIndex = 275
            Me.lblDiscountTaken.Text = "Discount Taken"
            Me.lblDiscountTaken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnAutoApply
            '
            Me.tlpDisbursement.SetColumnSpan(Me.btnAutoApply, 2)
            Me.btnAutoApply.DesignerSelected = False
            Me.btnAutoApply.DisplayOnly = True
            Me.btnAutoApply.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnAutoApply.Font = New System.Drawing.Font("Tahoma", 8.0!)
            Me.btnAutoApply.ImageIndex = 0
            Me.btnAutoApply.Location = New System.Drawing.Point(150, 549)
            Me.btnAutoApply.Name = "btnAutoApply"
            Me.btnAutoApply.OriginalImageName = Nothing
            Me.btnAutoApply.SecurityKey = ""
            Me.btnAutoApply.Size = New System.Drawing.Size(132, 93)
            Me.btnAutoApply.TabIndex = 25
            Me.btnAutoApply.TabStop = False
            Me.btnAutoApply.Text = "Auto Apply Invoices"
            '
            'DataGridViewDjOiItems
            '
            Me.DataGridViewDjOiItems.AllowUserToAddRows = False
            Me.DataGridViewDjOiItems.AllowUserToDeleteRows = False
            Me.DataGridViewDjOiItems.AllowUserToResizeRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDjOiItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewDjOiItems.AutoGenerateColumns = False
            Me.DataGridViewDjOiItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDjOiItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceDjOi, Me.dgvInvoiceNo, Me.DgvTransactionDate, Me.dgvJournalCode, Me.dgvJournalIdNoAp, Me.dgvPreviousBalance, Me.dgvAmount, Me.dgvDiscountTaken, Me.dgvBalance, Me.DataGridViewTextBoxColumn6, Me.JournalItemIdNo, Me.OpenInvoiceIdNo})
            Me.DataGridViewDjOiItems.DataSource = Me.bsDjOiItems
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.Font = New System.Drawing.Font("Andalus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDjOiItems.DefaultCellStyle = DataGridViewCellStyle11
            Me.DataGridViewDjOiItems.DgvFooter = Nothing
            Me.DataGridViewDjOiItems.DisplayOnly = False
            Me.DataGridViewDjOiItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewDjOiItems.Ea = EventAggregator1
            Me.DataGridViewDjOiItems.EditingMode = False
            Me.DataGridViewDjOiItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewDjOiItems.FirstRowDeletionEnabled = False
            Me.DataGridViewDjOiItems.FirstRowInsertionEnabled = False
            Me.DataGridViewDjOiItems.Location = New System.Drawing.Point(1004, 218)
            Me.DataGridViewDjOiItems.Name = "DataGridViewDjOiItems"
            Me.DataGridViewDjOiItems.ReadOnly = True
            Me.DataGridViewDjOiItems.SequenceColumn = "dgvSequencePcsOi"
            Me.DataGridViewDjOiItems.SequenceFieldName = "Sequence"
            Me.DataGridViewDjOiItems.ShowFooter = False
            Me.DataGridViewDjOiItems.ShowInsertColumnWhenEditing = False
            Me.DataGridViewDjOiItems.Size = New System.Drawing.Size(661, 325)
            Me.DataGridViewDjOiItems.TabIndex = 16
            Me.DataGridViewDjOiItems.Visible = False
            '
            'dgvSequenceDjOi
            '
            Me.dgvSequenceDjOi.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceDjOi.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequenceDjOi.DisplayOnly = True
            Me.dgvSequenceDjOi.EditingMode = False
            Me.dgvSequenceDjOi.HeaderText = "Seq"
            Me.dgvSequenceDjOi.Name = "dgvSequenceDjOi"
            Me.dgvSequenceDjOi.ReadOnly = True
            Me.dgvSequenceDjOi.Width = 40
            '
            'dgvInvoiceNo
            '
            Me.dgvInvoiceNo.DataPropertyName = "InvoiceNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvInvoiceNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvInvoiceNo.EditingMode = False
            Me.dgvInvoiceNo.HeaderText = "Invoice No."
            Me.dgvInvoiceNo.Name = "dgvInvoiceNo"
            Me.dgvInvoiceNo.ReadOnly = True
            Me.dgvInvoiceNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'DgvTransactionDate
            '
            Me.DgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.DgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle4
            Me.DgvTransactionDate.EditingMode = False
            Me.DgvTransactionDate.HeaderText = "Transaction Date"
            Me.DgvTransactionDate.Name = "DgvTransactionDate"
            Me.DgvTransactionDate.ReadOnly = True
            Me.DgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvJournalCode
            '
            Me.dgvJournalCode.DataPropertyName = "JournalCode"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalCode.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvJournalCode.EditingMode = False
            Me.dgvJournalCode.HeaderText = "Journal Code"
            Me.dgvJournalCode.Name = "dgvJournalCode"
            Me.dgvJournalCode.ReadOnly = True
            Me.dgvJournalCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvJournalCode.Width = 50
            '
            'dgvJournalIdNoAp
            '
            Me.dgvJournalIdNoAp.DataPropertyName = "JournalIdNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvJournalIdNoAp.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvJournalIdNoAp.EditingMode = False
            Me.dgvJournalIdNoAp.HeaderText = "Journal Id No"
            Me.dgvJournalIdNoAp.Name = "dgvJournalIdNoAp"
            Me.dgvJournalIdNoAp.ReadOnly = True
            Me.dgvJournalIdNoAp.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvPreviousBalance
            '
            Me.dgvPreviousBalance.DataPropertyName = "PreviousBalance"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.Format = "###,##0.00"
            Me.dgvPreviousBalance.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvPreviousBalance.EditingMode = False
            Me.dgvPreviousBalance.HeaderText = "Previous Balance"
            Me.dgvPreviousBalance.Name = "dgvPreviousBalance"
            Me.dgvPreviousBalance.ReadOnly = True
            Me.dgvPreviousBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPreviousBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvAmount
            '
            Me.dgvAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.Format = "###,##0.00"
            Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvAmount.EditingMode = False
            Me.dgvAmount.HeaderText = "Amount"
            Me.dgvAmount.Name = "dgvAmount"
            Me.dgvAmount.ReadOnly = True
            Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvDiscountTaken
            '
            Me.dgvDiscountTaken.DataPropertyName = "DiscountTaken"
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.Format = "###,##0.00"
            Me.dgvDiscountTaken.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvDiscountTaken.EditingMode = False
            Me.dgvDiscountTaken.HeaderText = "Discount Taken"
            Me.dgvDiscountTaken.Name = "dgvDiscountTaken"
            Me.dgvDiscountTaken.ReadOnly = True
            Me.dgvDiscountTaken.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDiscountTaken.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvBalance
            '
            Me.dgvBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvBalance.DataPropertyName = "Balance"
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.Format = "###,##0.00"
            Me.dgvBalance.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvBalance.EditingMode = False
            Me.dgvBalance.HeaderText = "Balance"
            Me.dgvBalance.Name = "dgvBalance"
            Me.dgvBalance.ReadOnly = True
            Me.dgvBalance.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "AccountIdNo"
            Me.DataGridViewTextBoxColumn6.HeaderText = "AccountIdNo"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            Me.DataGridViewTextBoxColumn6.Visible = False
            '
            'JournalItemIdNo
            '
            Me.JournalItemIdNo.DataPropertyName = "JournalItemIdNo"
            Me.JournalItemIdNo.HeaderText = "JournalItemIdNo"
            Me.JournalItemIdNo.Name = "JournalItemIdNo"
            Me.JournalItemIdNo.ReadOnly = True
            Me.JournalItemIdNo.Visible = False
            '
            'OpenInvoiceIdNo
            '
            Me.OpenInvoiceIdNo.DataPropertyName = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNo.HeaderText = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNo.Name = "OpenInvoiceIdNo"
            Me.OpenInvoiceIdNo.ReadOnly = True
            Me.OpenInvoiceIdNo.Visible = False
            '
            'bsDjOiItems
            '
            Me.bsDjOiItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DjOiItemModel)
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
            Me.txtPayeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
            Me.txtPayeeName.LinkedLabel = Me.lblAmount
            Me.txtPayeeName.Location = New System.Drawing.Point(360, 547)
            Me.txtPayeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayeeName.MaximumValue = Nothing
            Me.txtPayeeName.MinimumValue = Nothing
            Me.txtPayeeName.Name = "txtPayeeName"
            Me.txtPayeeName.OldValue = Nothing
            Me.txtPayeeName.ReadOnly = True
            Me.txtPayeeName.Size = New System.Drawing.Size(349, 23)
            Me.txtPayeeName.TabIndex = 6
            Me.txtPayeeName.ValueIsMandatory = True
            '
            'lblCheckDate
            '
            Me.lblCheckDate.DisplayOnly = True
            Me.lblCheckDate.EditingMode = False
            Me.lblCheckDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCheckDate.Location = New System.Drawing.Point(483, 137)
            Me.lblCheckDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckDate.Name = "lblCheckDate"
            Me.lblCheckDate.Size = New System.Drawing.Size(101, 25)
            Me.lblCheckDate.TabIndex = 284
            Me.lblCheckDate.Text = "Check Date"
            Me.lblCheckDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtVatNumber
            '
            Me.txtVatNumber.BackColor = System.Drawing.Color.White
            Me.txtVatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpDisbursement.SetColumnSpan(Me.txtVatNumber, 2)
            Me.txtVatNumber.ComputedValue = False
            Me.txtVatNumber.CustomFormat = Nothing
            Me.txtVatNumber.DataBoundControl = True
            Me.txtVatNumber.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtVatNumber.EditingMode = False
            Me.txtVatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtVatNumber.ForeColor = System.Drawing.Color.Black
            Me.txtVatNumber.LinkedLabel = Me.lblApplied
            Me.txtVatNumber.Location = New System.Drawing.Point(333, 108)
            Me.txtVatNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVatNumber.MaximumValue = Nothing
            Me.txtVatNumber.MaxLength = 15
            Me.txtVatNumber.MinimumValue = Nothing
            Me.txtVatNumber.Name = "txtVatNumber"
            Me.txtVatNumber.OldValue = Nothing
            Me.txtVatNumber.ReadOnly = True
            Me.txtVatNumber.Size = New System.Drawing.Size(148, 23)
            Me.txtVatNumber.TabIndex = 10
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
            Me.txtCheckNumber.EditingMode = False
            Me.txtCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
            Me.txtCheckNumber.LinkedLabel = Me.lblInvoiceNo
            Me.txtCheckNumber.Location = New System.Drawing.Point(595, 108)
            Me.txtCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCheckNumber.MaximumValue = Nothing
            Me.txtCheckNumber.MinimumValue = Nothing
            Me.txtCheckNumber.Name = "txtCheckNumber"
            Me.txtCheckNumber.OldValue = Nothing
            Me.txtCheckNumber.ReadOnly = True
            Me.txtCheckNumber.Size = New System.Drawing.Size(112, 23)
            Me.txtCheckNumber.TabIndex = 11
            Me.txtCheckNumber.ValueIsMandatory = True
            '
            'lblCheckNumber
            '
            Me.lblCheckNumber.DisplayOnly = True
            Me.lblCheckNumber.EditingMode = False
            Me.lblCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCheckNumber.Location = New System.Drawing.Point(483, 108)
            Me.lblCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckNumber.Name = "lblCheckNumber"
            Me.lblCheckNumber.Size = New System.Drawing.Size(101, 27)
            Me.lblCheckNumber.TabIndex = 290
            Me.lblCheckNumber.Text = "Check Number"
            Me.lblCheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblVatAmount
            '
            Me.lblVatAmount.AutoSize = True
            Me.tlpDisbursement.SetColumnSpan(Me.lblVatAmount, 2)
            Me.lblVatAmount.DisplayOnly = True
            Me.lblVatAmount.EditingMode = False
            Me.lblVatAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblVatAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblVatAmount.Location = New System.Drawing.Point(709, 1)
            Me.lblVatAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatAmount.Name = "lblVatAmount"
            Me.lblVatAmount.Size = New System.Drawing.Size(81, 17)
            Me.lblVatAmount.TabIndex = 283
            Me.lblVatAmount.Text = "Vat Amount"
            Me.lblVatAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnPrintCheck
            '
            Me.tlpDisbursement.SetColumnSpan(Me.btnPrintCheck, 2)
            Me.btnPrintCheck.DesignerSelected = False
            Me.btnPrintCheck.DisplayOnly = True
            Me.btnPrintCheck.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnPrintCheck.ImageIndex = 0
            Me.btnPrintCheck.Location = New System.Drawing.Point(791, 549)
            Me.btnPrintCheck.Name = "btnPrintCheck"
            Me.btnPrintCheck.OriginalImageName = Nothing
            Me.btnPrintCheck.SecurityKey = ""
            Me.btnPrintCheck.Size = New System.Drawing.Size(207, 93)
            Me.btnPrintCheck.TabIndex = 291
            Me.btnPrintCheck.TabStop = False
            Me.btnPrintCheck.Text = "Print Check"
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = True
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(148, 1)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.Size = New System.Drawing.Size(90, 23)
            Me.TxtIdNo.TabIndex = 1
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtReferenceNo
            '
            Me.txtReferenceNo.BackColor = System.Drawing.Color.White
            Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReferenceNo.ComputedValue = False
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            Me.txtReferenceNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtReferenceNo.EditingMode = False
            Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Me.lblReferenceNo
            Me.txtReferenceNo.Location = New System.Drawing.Point(360, 1)
            Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.ReadOnly = True
            Me.txtReferenceNo.Size = New System.Drawing.Size(121, 23)
            Me.txtReferenceNo.TabIndex = 2
            Me.txtReferenceNo.ValueIsMandatory = True
            '
            'lblReferenceNo
            '
            Me.tlpDisbursement.SetColumnSpan(Me.lblReferenceNo, 3)
            Me.lblReferenceNo.DisplayOnly = True
            Me.lblReferenceNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblReferenceNo.EditingMode = False
            Me.lblReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblReferenceNo.Location = New System.Drawing.Point(240, 1)
            Me.lblReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReferenceNo.Name = "lblReferenceNo"
            Me.lblReferenceNo.Size = New System.Drawing.Size(118, 25)
            Me.lblReferenceNo.TabIndex = 2
            Me.lblReferenceNo.Text = "Reference No.:"
            Me.lblReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboPayeeIdNo
            '
            Me.cboPayeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayeeIdNo.ChangingSearchValueOnly = False
            Me.tlpDisbursement.SetColumnSpan(Me.cboPayeeIdNo, 8)
            Me.cboPayeeIdNo.CurrentSearchTerm = ""
            Me.cboPayeeIdNo.DefaultValue = Nothing
            Me.cboPayeeIdNo.DisplayMember = "Name"
            Me.cboPayeeIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPayeeIdNo.DropDownHeight = 200
            Me.cboPayeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPayeeIdNo.EditingMode = True
            Me.cboPayeeIdNo.FilterRule = Nothing
            Me.cboPayeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayeeIdNo.FormattingEnabled = True
            Me.cboPayeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayeeIdNo.LinkedLabel = Nothing
            Me.cboPayeeIdNo.Location = New System.Drawing.Point(118, 55)
            Me.cboPayeeIdNo.Margin = New System.Windows.Forms.Padding(1)
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
            Me.cboPayeeIdNo.Size = New System.Drawing.Size(589, 24)
            Me.cboPayeeIdNo.SuggestBoxHeight = 200
            Me.cboPayeeIdNo.SuggestListOrderRule = Nothing
            Me.cboPayeeIdNo.TabIndex = 6
            Me.cboPayeeIdNo.TextToSearch = Nothing
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
            Me.lblVatNo.Location = New System.Drawing.Point(240, 108)
            Me.lblVatNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVatNo.Name = "lblVatNo"
            Me.lblVatNo.Size = New System.Drawing.Size(91, 27)
            Me.lblVatNo.TabIndex = 2
            Me.lblVatNo.Text = "Vat Number"
            Me.lblVatNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCancelled
            '
            Me.lblCancelled.AutoSize = True
            Me.lblCancelled.DisplayOnly = True
            Me.lblCancelled.EditingMode = False
            Me.lblCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCancelled.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCancelled.Location = New System.Drawing.Point(709, 108)
            Me.lblCancelled.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCancelled.Name = "lblCancelled"
            Me.lblCancelled.Size = New System.Drawing.Size(78, 17)
            Me.lblCancelled.TabIndex = 249
            Me.lblCancelled.Text = "Cancelled?"
            Me.lblCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.chkCancelled.ForeColor = System.Drawing.Color.Black
            Me.chkCancelled.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkCancelled.LinkedLabel = Me.lblCancelled
            Me.chkCancelled.Location = New System.Drawing.Point(835, 108)
            Me.chkCancelled.Margin = New System.Windows.Forms.Padding(1)
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.NoLabel = True
            Me.chkCancelled.OldValue = Nothing
            Me.chkCancelled.Size = New System.Drawing.Size(23, 21)
            Me.chkCancelled.TabIndex = 21
            Me.chkCancelled.TabStop = False
            Me.chkCancelled.Text = " "
            Me.chkCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkCancelled.UseVisualStyleBackColor = False
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(595, 1)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpTransactionDate.TabIndex = 3
            Me.dtpTransactionDate.TargetCalendar = Nothing
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
            Me.lblSupplierIdNo.Location = New System.Drawing.Point(1, 55)
            Me.lblSupplierIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierIdNo.Name = "lblSupplierIdNo"
            Me.lblSupplierIdNo.Size = New System.Drawing.Size(115, 25)
            Me.lblSupplierIdNo.TabIndex = 7
            Me.lblSupplierIdNo.Text = "Payee:"
            Me.lblSupplierIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDateCreated
            '
            Me.lblDateCreated.DisplayOnly = True
            Me.lblDateCreated.EditingMode = False
            Me.lblDateCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.lblDateCreated.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblDateCreated.Location = New System.Drawing.Point(709, 189)
            Me.lblDateCreated.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDateCreated.Name = "lblDateCreated"
            Me.lblDateCreated.Size = New System.Drawing.Size(69, 25)
            Me.lblDateCreated.TabIndex = 268
            Me.lblDateCreated.Text = "Date Added:"
            Me.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.dtpDateCreated.Location = New System.Drawing.Point(798, 189)
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
            Me.dtpDateCreated.Value = Nothing
            Me.dtpDateCreated.ValueIsMandatory = False
            Me.dtpDateCreated.ValueIsNullable = False
            '
            'lblPosted
            '
            Me.lblPosted.AutoSize = True
            Me.lblPosted.DisplayOnly = True
            Me.lblPosted.EditingMode = False
            Me.lblPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPosted.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPosted.Location = New System.Drawing.Point(709, 164)
            Me.lblPosted.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPosted.Name = "lblPosted"
            Me.lblPosted.Size = New System.Drawing.Size(60, 17)
            Me.lblPosted.TabIndex = 266
            Me.lblPosted.Text = "Posted?"
            Me.lblPosted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.chkPosted.ForeColor = System.Drawing.Color.Black
            Me.chkPosted.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkPosted.LinkedLabel = Me.lblPosted
            Me.chkPosted.Location = New System.Drawing.Point(835, 164)
            Me.chkPosted.Margin = New System.Windows.Forms.Padding(1)
            Me.chkPosted.Name = "chkPosted"
            Me.chkPosted.NoLabel = True
            Me.chkPosted.OldValue = Nothing
            Me.chkPosted.Size = New System.Drawing.Size(23, 21)
            Me.chkPosted.TabIndex = 23
            Me.chkPosted.TabStop = False
            Me.chkPosted.Text = " "
            Me.chkPosted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkPosted.UseVisualStyleBackColor = False
            '
            'lblPcClosed
            '
            Me.lblPcClosed.AutoSize = True
            Me.lblPcClosed.DisplayOnly = True
            Me.lblPcClosed.EditingMode = False
            Me.lblPcClosed.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPcClosed.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPcClosed.Location = New System.Drawing.Point(709, 137)
            Me.lblPcClosed.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPcClosed.Name = "lblPcClosed"
            Me.lblPcClosed.Size = New System.Drawing.Size(59, 17)
            Me.lblPcClosed.TabIndex = 293
            Me.lblPcClosed.Text = "Closed?"
            Me.lblPcClosed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkPcClosed
            '
            Me.chkPcClosed.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkPcClosed.AutoCheck = False
            Me.chkPcClosed.BackColor = System.Drawing.Color.White
            Me.chkPcClosed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkPcClosed.DisplayOnly = True
            Me.chkPcClosed.EditingMode = True
            Me.chkPcClosed.Enabled = False
            Me.chkPcClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPcClosed.ForeColor = System.Drawing.Color.Black
            Me.chkPcClosed.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkPcClosed.LinkedLabel = Me.lblPcClosed
            Me.chkPcClosed.Location = New System.Drawing.Point(835, 137)
            Me.chkPcClosed.Margin = New System.Windows.Forms.Padding(1)
            Me.chkPcClosed.Name = "chkPcClosed"
            Me.chkPcClosed.NoLabel = True
            Me.chkPcClosed.OldValue = Nothing
            Me.chkPcClosed.Size = New System.Drawing.Size(23, 21)
            Me.chkPcClosed.TabIndex = 22
            Me.chkPcClosed.TabStop = False
            Me.chkPcClosed.Text = " "
            Me.chkPcClosed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkPcClosed.UseVisualStyleBackColor = False
            '
            'lblPayType
            '
            Me.lblPayType.DisplayOnly = True
            Me.lblPayType.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblPayType.EditingMode = False
            Me.lblPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayType.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPayType.Location = New System.Drawing.Point(360, 28)
            Me.lblPayType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayType.Name = "lblPayType"
            Me.lblPayType.Size = New System.Drawing.Size(121, 25)
            Me.lblPayType.TabIndex = 292
            Me.lblPayType.Text = "Pay Type:"
            Me.lblPayType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'PcClosingEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Libraries.GlobalResources.My.Resources.Resources.EntryFormBackground
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(988, 645)
            Me.Controls.Add(Me.tlpDisbursement)
            Me.MinimumSize = New System.Drawing.Size(945, 590)
            Me.Name = "PcClosingEntry"
            Me.Text = "Petty Cash Journal "
            Me.Controls.SetChildIndex(Me.tlpDisbursement, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tlpDisbursement.ResumeLayout(False)
            Me.tlpDisbursement.PerformLayout()
            CType(Me.bsJournalItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewDjOiItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsDjOiItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
        Friend WithEvents btnViewGL As CButton
        Friend WithEvents lblDateCreated As CLabel
        Friend WithEvents chkPosted As CCheckBox
        Friend WithEvents lblPosted As CLabel
        Friend WithEvents chkCancelled As CCheckBox
        Friend WithEvents lblCancelled As CLabel
        Friend WithEvents lblDiscountAccountIdNo As CLabel
        Friend WithEvents lblNotes As CLabel
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
        Friend WithEvents lblPcClosed As CLabel
        Friend WithEvents chkPcClosed As CCheckBox
        Friend WithEvents lblPayType As CLabel
    End Class
End Namespace
