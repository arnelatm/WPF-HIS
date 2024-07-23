Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PettyCashClosingEntry
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PettyCashClosingEntry))
        Me.DataGridViewPcJournals = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
        Me.dgvPcClosed = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvReference = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvPayeeType = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvPayeeName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvPayeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.bsPcJournals = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnUnselectAll = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayee = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnSelectAll = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayType = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPcAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewPcJournals,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPcJournals,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'DataGridViewPcJournals
            '
            Me.DataGridViewPcJournals.AllowUserToAddRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPcJournals.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPcJournals.AutoGenerateColumns = False
            Me.DataGridViewPcJournals.BegFindValue = Nothing
            Me.DataGridViewPcJournals.Cached = False
            Me.DataGridViewPcJournals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPcJournals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvPcClosed, Me.dgvTransactionDate, Me.dgvIdNo, Me.dgvReference, Me.dgvPayeeType, Me.dgvPayeeName, Me.dgvAmount, Me.dgvNotes, Me.dgvPayeeNameAra})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPcJournals, 8)
            Me.DataGridViewPcJournals.DataFilter = Nothing
            Me.DataGridViewPcJournals.DataSource = Me.bsPcJournals
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPcJournals.DefaultCellStyle = DataGridViewCellStyle11
            Me.DataGridViewPcJournals.DgvFooter = Nothing
            Me.DataGridViewPcJournals.DisplayOnly = False
            Me.DataGridViewPcJournals.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPcJournals.Ea = Nothing
            Me.DataGridViewPcJournals.EditingMode = False
            Me.DataGridViewPcJournals.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPcJournals.EndFindValue = Nothing
            Me.DataGridViewPcJournals.FieldDescription = Nothing
            Me.DataGridViewPcJournals.FieldName = Nothing
            Me.DataGridViewPcJournals.FieldsDictionary = Nothing
            Me.DataGridViewPcJournals.FindColumnNo = CType(0, Short)
            Me.DataGridViewPcJournals.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPcJournals.FindEnabled = False
            Me.DataGridViewPcJournals.FirstRowDeletionEnabled = True
            Me.DataGridViewPcJournals.FirstRowInsertionEnabled = True
            Me.DataGridViewPcJournals.IgnoreCase = False
            Me.DataGridViewPcJournals.IsDirty = False
            Me.DataGridViewPcJournals.Location = New System.Drawing.Point(3, 107)
            Me.DataGridViewPcJournals.Name = "DataGridViewPcJournals"
            Me.DataGridViewPcJournals.ReadOnly = True
            Me.DataGridViewPcJournals.Searchable = True
            Me.DataGridViewPcJournals.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPcJournals.SecurityKey = "ClosePettyCash"
            Me.DataGridViewPcJournals.SequenceColumn = "dgvSequence"
            Me.DataGridViewPcJournals.SequenceFieldName = "Sequence"
            Me.DataGridViewPcJournals.ShowFooter = False
            Me.DataGridViewPcJournals.Size = New System.Drawing.Size(983, 450)
            Me.DataGridViewPcJournals.TabIndex = 10
            Me.DataGridViewPcJournals.Translatable = True
            '
            'dgvPcClosed
            '
            Me.dgvPcClosed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvPcClosed.BegFindValue = Nothing
            Me.dgvPcClosed.DataPropertyName = "PcClosed"
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Orange
            DataGridViewCellStyle2.NullValue = False
            Me.dgvPcClosed.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvPcClosed.EditingMode = False
            Me.dgvPcClosed.EndFindValue = Nothing
            Me.dgvPcClosed.FieldDescription = Nothing
            Me.dgvPcClosed.FieldName = Nothing
            Me.dgvPcClosed.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPcClosed.FindEnabled = False
            Me.dgvPcClosed.HeaderText = "Close?"
            Me.dgvPcClosed.IgnoreCase = False
            Me.dgvPcClosed.MinimumWidth = 50
            Me.dgvPcClosed.Name = "dgvPcClosed"
            Me.dgvPcClosed.ReadOnly = True
            Me.dgvPcClosed.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPcClosed.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPcClosed.Translatable = False
            Me.dgvPcClosed.Width = 50
            '
            'dgvTransactionDate
            '
            Me.dgvTransactionDate.BegFindValue = Nothing
            Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvTransactionDate.DisplayOnly = True
            Me.dgvTransactionDate.EditingMode = False
            Me.dgvTransactionDate.EndFindValue = Nothing
            Me.dgvTransactionDate.FieldDescription = Nothing
            Me.dgvTransactionDate.FieldName = Nothing
            Me.dgvTransactionDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvTransactionDate.FindEnabled = False
            Me.dgvTransactionDate.HeaderText = "Date"
            Me.dgvTransactionDate.IgnoreCase = False
            Me.dgvTransactionDate.Name = "dgvTransactionDate"
            Me.dgvTransactionDate.ReadOnly = True
            Me.dgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvTransactionDate.Translatable = False
            Me.dgvTransactionDate.Width = 80
            '
            'dgvIdNo
            '
            Me.dgvIdNo.BegFindValue = Nothing
            Me.dgvIdNo.DataPropertyName = "IdNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvIdNo.EditingMode = False
            Me.dgvIdNo.EndFindValue = Nothing
            Me.dgvIdNo.FieldDescription = Nothing
            Me.dgvIdNo.FieldName = Nothing
            Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvIdNo.FindEnabled = False
            Me.dgvIdNo.HeaderText = "IdNo"
            Me.dgvIdNo.IgnoreCase = False
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvIdNo.Translatable = False
            Me.dgvIdNo.Width = 50
            '
            'dgvReference
            '
            Me.dgvReference.BegFindValue = Nothing
            Me.dgvReference.DataPropertyName = "ReferenceNo"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvReference.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvReference.EditingMode = False
            Me.dgvReference.EndFindValue = Nothing
            Me.dgvReference.FieldDescription = Nothing
            Me.dgvReference.FieldName = Nothing
            Me.dgvReference.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvReference.FindEnabled = False
            Me.dgvReference.HeaderText = "Reference No"
            Me.dgvReference.IgnoreCase = False
            Me.dgvReference.Name = "dgvReference"
            Me.dgvReference.ReadOnly = True
            Me.dgvReference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvReference.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvReference.Translatable = False
            Me.dgvReference.Width = 80
            '
            'dgvPayeeType
            '
            Me.dgvPayeeType.BegFindValue = Nothing
            Me.dgvPayeeType.DataPropertyName = "PaymentType"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvPayeeType.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvPayeeType.EditingMode = False
            Me.dgvPayeeType.EndFindValue = Nothing
            Me.dgvPayeeType.FieldDescription = Nothing
            Me.dgvPayeeType.FieldName = Nothing
            Me.dgvPayeeType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPayeeType.FindEnabled = False
            Me.dgvPayeeType.HeaderText = "Payee Type"
            Me.dgvPayeeType.IgnoreCase = False
            Me.dgvPayeeType.Name = "dgvPayeeType"
            Me.dgvPayeeType.ReadOnly = True
            Me.dgvPayeeType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPayeeType.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPayeeType.Translatable = False
            Me.dgvPayeeType.Width = 40
            '
            'dgvPayeeName
            '
            Me.dgvPayeeName.BegFindValue = Nothing
            Me.dgvPayeeName.DataPropertyName = "PayeeName"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvPayeeName.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvPayeeName.EditingMode = False
            Me.dgvPayeeName.EndFindValue = Nothing
            Me.dgvPayeeName.FieldDescription = Nothing
            Me.dgvPayeeName.FieldName = Nothing
            Me.dgvPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPayeeName.FindEnabled = False
            Me.dgvPayeeName.HeaderText = "PayeeName"
            Me.dgvPayeeName.IgnoreCase = False
            Me.dgvPayeeName.Name = "dgvPayeeName"
            Me.dgvPayeeName.ReadOnly = True
            Me.dgvPayeeName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPayeeName.Translatable = False
            Me.dgvPayeeName.Width = 150
            '
            'dgvAmount
            '
            Me.dgvAmount.BegFindValue = Nothing
            Me.dgvAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.Format = "###,##0.00"
            Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle8
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
            'dgvNotes
            '
            Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvNotes.BegFindValue = Nothing
            Me.dgvNotes.DataPropertyName = "Notes"
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvNotes.EditingMode = False
            Me.dgvNotes.EndFindValue = Nothing
            Me.dgvNotes.FieldDescription = Nothing
            Me.dgvNotes.FieldName = Nothing
            Me.dgvNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvNotes.FindEnabled = False
            Me.dgvNotes.HeaderText = "Notes"
            Me.dgvNotes.IgnoreCase = False
            Me.dgvNotes.Name = "dgvNotes"
            Me.dgvNotes.ReadOnly = True
            Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvNotes.Translatable = False
            '
            'dgvPayeeNameAra
            '
            Me.dgvPayeeNameAra.BegFindValue = Nothing
            Me.dgvPayeeNameAra.DataPropertyName = "PayeeNameAra"
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvPayeeNameAra.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvPayeeNameAra.EditingMode = False
            Me.dgvPayeeNameAra.EndFindValue = Nothing
            Me.dgvPayeeNameAra.FieldDescription = Nothing
            Me.dgvPayeeNameAra.FieldName = Nothing
            Me.dgvPayeeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPayeeNameAra.FindEnabled = False
            Me.dgvPayeeNameAra.HeaderText = "PayeeNameAra"
            Me.dgvPayeeNameAra.IgnoreCase = False
            Me.dgvPayeeNameAra.Name = "dgvPayeeNameAra"
            Me.dgvPayeeNameAra.ReadOnly = True
            Me.dgvPayeeNameAra.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPayeeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPayeeNameAra.Translatable = False
            Me.dgvPayeeNameAra.Visible = False
            Me.dgvPayeeNameAra.Width = 150
            '
            'bsPcJournals
            '
            Me.bsPcJournals.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PcClosingJournalModel)
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 8
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.btnUnselectAll, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPayeeName, 6, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPayee, 5, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblTransactionDate, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpTransactionDate, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblAccountIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboAccountIdNo, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPcJournals, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtReferenceNo, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblCheckNumber, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtCheckNumber, 5, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblAmount, 6, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAmount, 7, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.btnSelectAll, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 5, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboPayType, 6, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.cboPcAccountIdNo, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.txtIdNo, 4, 6)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 58)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 7
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(983, 589)
            Me.TableLayoutPanel1.TabIndex = 5
            '
            'btnUnselectAll
            '
            Me.btnUnselectAll.DesignerSelected = False
            Me.btnUnselectAll.ImageIndex = 0
            Me.btnUnselectAll.Location = New System.Drawing.Point(122, 563)
            Me.btnUnselectAll.Name = "btnUnselectAll"
            Me.btnUnselectAll.OriginalImageName = Nothing
            Me.btnUnselectAll.SecurityKey = "ClosePettyCash"
            Me.btnUnselectAll.Size = New System.Drawing.Size(90, 23)
            Me.btnUnselectAll.TabIndex = 15
            Me.btnUnselectAll.Text = "Unselect All"
            '
            'txtPayeeName
            '
            Me.txtPayeeName.BackColor = System.Drawing.Color.White
            Me.txtPayeeName.BegFindValue = Nothing
            Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayeeName, 2)
            Me.txtPayeeName.ComputedValue = False
            Me.txtPayeeName.CustomFormat = Nothing
            Me.txtPayeeName.DataBoundControl = True
            Me.txtPayeeName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayeeName.EditingMode = True
            Me.txtPayeeName.EndFindValue = Nothing
            Me.txtPayeeName.FieldDescription = Nothing
            Me.txtPayeeName.FieldName = Nothing
            Me.txtPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayeeName.FindEnabled = True
            Me.txtPayeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
            Me.txtPayeeName.LinkedLabel = Nothing
            Me.txtPayeeName.Location = New System.Drawing.Point(647, 53)
            Me.txtPayeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayeeName.MaximumValue = Nothing
            Me.txtPayeeName.MinimumValue = Nothing
            Me.txtPayeeName.Name = "txtPayeeName"
            Me.txtPayeeName.OldValue = Nothing
            Me.txtPayeeName.OverrideMaxLength = 0
            Me.txtPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayeeName.SecurityKey = "ClosePettyCash"
            Me.txtPayeeName.Size = New System.Drawing.Size(341, 23)
            Me.txtPayeeName.TabIndex = 8
            Me.txtPayeeName.Translatable = False
            '
            'lblPayee
            '
            Me.lblPayee.AutoSize = True
            Me.lblPayee.DisplayOnly = True
            Me.lblPayee.EditingMode = False
            Me.lblPayee.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayee.Location = New System.Drawing.Point(533, 53)
            Me.lblPayee.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayee.Name = "lblPayee"
            Me.lblPayee.Size = New System.Drawing.Size(48, 17)
            Me.lblPayee.TabIndex = 12
            Me.lblPayee.Text = "Payee"
            Me.lblPayee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayee.Translatable = True
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.AutoSize = True
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.Location = New System.Drawing.Point(1, 1)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(117, 17)
            Me.lblTransactionDate.TabIndex = 3
            Me.lblTransactionDate.Text = "Transaction Date"
            Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.dtpTransactionDate.EditingMode = True
            Me.dtpTransactionDate.EditsAllowed = False
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Location = New System.Drawing.Point(120, 1)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = "ClosePettyCash"
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpTransactionDate.TabIndex = 0
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.AutoSize = True
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAccountIdNo.Location = New System.Drawing.Point(1, 26)
            Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Size = New System.Drawing.Size(109, 17)
            Me.lblAccountIdNo.TabIndex = 1
            Me.lblAccountIdNo.Text = "Closing Account"
            Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAccountIdNo.Translatable = True
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.BegFindValue = Nothing
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboAccountIdNo, 4)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DataValue = Nothing
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboAccountIdNo.Editable = True
            Me.cboAccountIdNo.EditingMode = True
            Me.cboAccountIdNo.EndFindValue = Nothing
            Me.cboAccountIdNo.FieldDescription = Nothing
            Me.cboAccountIdNo.FieldName = Nothing
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAccountIdNo.FindEnabled = False
            Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IgnoreCase = False
            Me.cboAccountIdNo.IntegralHeight = False
            Me.cboAccountIdNo.LimitToList = False
            Me.cboAccountIdNo.LinkedLabel = Nothing
            Me.cboAccountIdNo.Location = New System.Drawing.Point(120, 26)
            Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.SecurityKey = "ClosePettyCash"
            Me.cboAccountIdNo.Size = New System.Drawing.Size(411, 24)
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TabIndex = 5
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.Translatable = False
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 7)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtNotes.EditingMode = True
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(120, 80)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.SecurityKey = "ClosePettyCash"
            Me.txtNotes.Size = New System.Drawing.Size(868, 23)
            Me.txtNotes.TabIndex = 9
            Me.txtNotes.Translatable = False
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(240, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(100, 17)
            Me.CLabel2.TabIndex = 6
            Me.CLabel2.Text = "Reference No."
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'txtReferenceNo
            '
            Me.txtReferenceNo.BackColor = System.Drawing.Color.White
            Me.txtReferenceNo.BegFindValue = Nothing
            Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReferenceNo.ComputedValue = False
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            Me.txtReferenceNo.EditingMode = True
            Me.txtReferenceNo.EndFindValue = Nothing
            Me.txtReferenceNo.FieldDescription = Nothing
            Me.txtReferenceNo.FieldName = Nothing
            Me.txtReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtReferenceNo.FindEnabled = True
            Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Nothing
            Me.txtReferenceNo.Location = New System.Drawing.Point(342, 1)
            Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.OverrideMaxLength = 0
            Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtReferenceNo.SecurityKey = "ClosePettyCash"
            Me.txtReferenceNo.Size = New System.Drawing.Size(86, 23)
            Me.txtReferenceNo.TabIndex = 1
            Me.txtReferenceNo.Translatable = False
            '
            'lblCheckNumber
            '
            Me.lblCheckNumber.AutoSize = True
            Me.lblCheckNumber.DisplayOnly = True
            Me.lblCheckNumber.EditingMode = False
            Me.lblCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckNumber.Location = New System.Drawing.Point(430, 1)
            Me.lblCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckNumber.Name = "lblCheckNumber"
            Me.lblCheckNumber.Size = New System.Drawing.Size(101, 17)
            Me.lblCheckNumber.TabIndex = 9
            Me.lblCheckNumber.Text = "Check Number"
            Me.lblCheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCheckNumber.Translatable = True
            '
            'txtCheckNumber
            '
            Me.txtCheckNumber.BackColor = System.Drawing.Color.White
            Me.txtCheckNumber.BegFindValue = Nothing
            Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCheckNumber.ComputedValue = False
            Me.txtCheckNumber.CustomFormat = Nothing
            Me.txtCheckNumber.DataBoundControl = True
            Me.txtCheckNumber.EditingMode = True
            Me.txtCheckNumber.EndFindValue = Nothing
            Me.txtCheckNumber.FieldDescription = Nothing
            Me.txtCheckNumber.FieldName = Nothing
            Me.txtCheckNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCheckNumber.FindEnabled = True
            Me.txtCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
            Me.txtCheckNumber.LinkedLabel = Nothing
            Me.txtCheckNumber.Location = New System.Drawing.Point(533, 1)
            Me.txtCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCheckNumber.MaximumValue = Nothing
            Me.txtCheckNumber.MinimumValue = Nothing
            Me.txtCheckNumber.Name = "txtCheckNumber"
            Me.txtCheckNumber.OldValue = Nothing
            Me.txtCheckNumber.OverrideMaxLength = 0
            Me.txtCheckNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCheckNumber.SecurityKey = "ClosePettyCash"
            Me.txtCheckNumber.Size = New System.Drawing.Size(112, 23)
            Me.txtCheckNumber.TabIndex = 2
            Me.txtCheckNumber.Translatable = False
            '
            'lblAmount
            '
            Me.lblAmount.AutoSize = True
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.Location = New System.Drawing.Point(647, 1)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(56, 17)
            Me.lblAmount.TabIndex = 10
            Me.lblAmount.Text = "Amount"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblAmount.Translatable = True
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BegFindValue = Nothing
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = Nothing
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.DisplayOnly = True
            Me.txtAmount.EditingMode = True
            Me.txtAmount.EndFindValue = Nothing
            Me.txtAmount.FieldDescription = Nothing
            Me.txtAmount.FieldName = Nothing
            Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAmount.FindEnabled = True
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Nothing
            Me.txtAmount.Location = New System.Drawing.Point(705, 1)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.OverrideMaxLength = 0
            Me.txtAmount.ReadOnly = True
            Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAmount.SecurityKey = "ClosePettyCash"
            Me.txtAmount.Size = New System.Drawing.Size(112, 23)
            Me.txtAmount.TabIndex = 3
            Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAmount.Translatable = False
            Me.txtAmount.ValueIsNumeric = True
            '
            'CLabel1
            '
            Me.CLabel1.AutoSize = True
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 80)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(45, 17)
            Me.CLabel1.TabIndex = 4
            Me.CLabel1.Text = "Notes"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'btnSelectAll
            '
            Me.btnSelectAll.DesignerSelected = False
            Me.btnSelectAll.ImageIndex = 0
            Me.btnSelectAll.Location = New System.Drawing.Point(3, 563)
            Me.btnSelectAll.Name = "btnSelectAll"
            Me.btnSelectAll.OriginalImageName = Nothing
            Me.btnSelectAll.SecurityKey = "ClosePettyCash"
            Me.btnSelectAll.Size = New System.Drawing.Size(90, 23)
            Me.btnSelectAll.TabIndex = 14
            Me.btnSelectAll.Text = "Select All"
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(533, 26)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(68, 17)
            Me.CLabel3.TabIndex = 16
            Me.CLabel3.Text = "Pay Type"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'cboPayType
            '
            Me.cboPayType.BackColor = System.Drawing.Color.White
            Me.cboPayType.BegFindValue = Nothing
            Me.cboPayType.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboPayType, 2)
            Me.cboPayType.CurrentSearchTerm = ""
            Me.cboPayType.DataValue = Nothing
            Me.cboPayType.DefaultValue = Nothing
            Me.cboPayType.DisplayMember = "Name"
            Me.cboPayType.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPayType.Editable = True
            Me.cboPayType.EditingMode = True
            Me.cboPayType.EndFindValue = Nothing
            Me.cboPayType.FieldDescription = Nothing
            Me.cboPayType.FieldName = Nothing
            Me.cboPayType.FilterRule = Nothing
            Me.cboPayType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayType.FindEnabled = False
            Me.cboPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayType.ForeColor = System.Drawing.Color.Black
            Me.cboPayType.FormattingEnabled = True
            Me.cboPayType.HideWhenNotEditingOrAdding = False
            Me.cboPayType.IgnoreCase = False
            Me.cboPayType.IntegralHeight = False
            Me.cboPayType.LimitToList = False
            Me.cboPayType.LinkedLabel = Nothing
            Me.cboPayType.Location = New System.Drawing.Point(647, 26)
            Me.cboPayType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayType.Name = "cboPayType"
            Me.cboPayType.OldValue = 0
            Me.cboPayType.OriginalDataSource = Nothing
            Me.cboPayType.OriginalList = Nothing
            Me.cboPayType.OverrideDropDownStyleList = False
            Me.cboPayType.PreviousSearchTerm = Nothing
            Me.cboPayType.PropertySelector = Nothing
            Me.cboPayType.SecurityKey = "ClosePettyCash"
            Me.cboPayType.Size = New System.Drawing.Size(341, 24)
            Me.cboPayType.SuggestBoxHeight = 200
            Me.cboPayType.SuggestListOrderRule = Nothing
            Me.cboPayType.TabIndex = 6
            Me.cboPayType.TextToSearch = Nothing
            Me.cboPayType.Translatable = False
            Me.cboPayType.ValueIsMandatory = False
            Me.cboPayType.ValueIsNullable = False
            Me.cboPayType.ValueIsNumeric = False
            Me.cboPayType.ValueMember = "IdNo"
            '
            'CLabel4
            '
            Me.CLabel4.AutoSize = True
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel4.Location = New System.Drawing.Point(1, 53)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(111, 17)
            Me.CLabel4.TabIndex = 18
            Me.CLabel4.Text = "Petty Cash Acct."
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel4.Translatable = True
            '
            'cboPcAccountIdNo
            '
            Me.cboPcAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboPcAccountIdNo.BegFindValue = Nothing
            Me.cboPcAccountIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboPcAccountIdNo, 4)
            Me.cboPcAccountIdNo.CurrentSearchTerm = ""
            Me.cboPcAccountIdNo.DataValue = Nothing
            Me.cboPcAccountIdNo.DefaultValue = Nothing
            Me.cboPcAccountIdNo.DisplayMember = "Name"
            Me.cboPcAccountIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPcAccountIdNo.Editable = True
            Me.cboPcAccountIdNo.EditingMode = True
            Me.cboPcAccountIdNo.EndFindValue = Nothing
            Me.cboPcAccountIdNo.FieldDescription = Nothing
            Me.cboPcAccountIdNo.FieldName = Nothing
            Me.cboPcAccountIdNo.FilterRule = Nothing
            Me.cboPcAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPcAccountIdNo.FindEnabled = False
            Me.cboPcAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPcAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPcAccountIdNo.FormattingEnabled = True
            Me.cboPcAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPcAccountIdNo.IgnoreCase = False
            Me.cboPcAccountIdNo.IntegralHeight = False
            Me.cboPcAccountIdNo.LimitToList = False
            Me.cboPcAccountIdNo.LinkedLabel = Nothing
            Me.cboPcAccountIdNo.Location = New System.Drawing.Point(120, 53)
            Me.cboPcAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPcAccountIdNo.Name = "cboPcAccountIdNo"
            Me.cboPcAccountIdNo.OldValue = 0
            Me.cboPcAccountIdNo.OriginalDataSource = Nothing
            Me.cboPcAccountIdNo.OriginalList = Nothing
            Me.cboPcAccountIdNo.OverrideDropDownStyleList = False
            Me.cboPcAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboPcAccountIdNo.PropertySelector = Nothing
            Me.cboPcAccountIdNo.SecurityKey = "ClosePettyCash"
            Me.cboPcAccountIdNo.Size = New System.Drawing.Size(411, 24)
            Me.cboPcAccountIdNo.SuggestBoxHeight = 200
            Me.cboPcAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboPcAccountIdNo.TabIndex = 7
            Me.cboPcAccountIdNo.TextToSearch = Nothing
            Me.cboPcAccountIdNo.Translatable = False
            Me.cboPcAccountIdNo.ValueIsMandatory = False
            Me.cboPcAccountIdNo.ValueIsNullable = False
            Me.cboPcAccountIdNo.ValueIsNumeric = False
            Me.cboPcAccountIdNo.ValueMember = "IdNo"
            '
            'txtIdNo
            '
            Me.txtIdNo.BackColor = System.Drawing.Color.White
            Me.txtIdNo.BegFindValue = Nothing
            Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdNo.ComputedValue = False
            Me.txtIdNo.CustomFormat = Nothing
            Me.txtIdNo.DataBoundControl = True
            Me.txtIdNo.EditingMode = True
            Me.txtIdNo.EndFindValue = Nothing
            Me.txtIdNo.FieldDescription = Nothing
            Me.txtIdNo.FieldName = Nothing
            Me.txtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtIdNo.FindEnabled = False
            Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtIdNo.LinkedLabel = Nothing
            Me.txtIdNo.Location = New System.Drawing.Point(430, 561)
            Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIdNo.MaximumValue = Nothing
            Me.txtIdNo.MinimumValue = Nothing
            Me.txtIdNo.Name = "txtIdNo"
            Me.txtIdNo.OldValue = Nothing
            Me.txtIdNo.OverrideMaxLength = 0
            Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIdNo.Size = New System.Drawing.Size(100, 23)
        Me.txtIdNo.TabIndex = 295
        Me.txtIdNo.Translatable = false
        Me.txtIdNo.Visible = false
        '
        'PettyCashClosingEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
        Me.ClientSize = New System.Drawing.Size(1008, 659)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(945, 590)
        Me.Name = "PettyCashClosingEntry"
        Me.Text = "Petty Cash Closing"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewPcJournals,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsPcJournals,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsPcJournals As Windows.Forms.BindingSource
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
        Friend WithEvents DataGridViewPcJournals As CtDataGridView
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As AtmComboBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents txtReferenceNo As CTextBox
        Friend WithEvents lblCheckNumber As CLabel
        Friend WithEvents txtCheckNumber As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents txtPayeeName As CTextBox
        Friend WithEvents lblPayee As CLabel
        Friend WithEvents btnUnselectAll As CButton
        Friend WithEvents btnSelectAll As CButton
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents cboPayType As AtmComboBox
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents cboPcAccountIdNo As AtmComboBox
        Friend WithEvents txtIdNo As CTextBox
        Friend WithEvents dgvPcClosed As CDgvCheckBoxColumn
        Friend WithEvents dgvTransactionDate As CDgvTextColumn
        Friend WithEvents dgvIdNo As CDgvTextColumn
        Friend WithEvents dgvReference As CDgvTextColumn
        Friend WithEvents dgvPayeeType As CDgvTextColumn
        Friend WithEvents dgvPayeeName As CDgvTextColumn
        Friend WithEvents dgvAmount As CdgvMoneyColumn
        Friend WithEvents dgvNotes As CDgvTextColumn
        Friend WithEvents dgvPayeeNameAra As CDgvTextColumn
    End Class
End Namespace