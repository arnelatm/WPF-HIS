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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PettyCashClosingEntry))
        Me.DataGridViewPcJournals = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvPcClosed = New System.Windows.Forms.DataGridViewCheckBoxColumn()
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
        Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayee = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
        Me.cboPayType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPcAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewPcJournals,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPcJournals,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel1.SuspendLayout
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
        'DataGridViewPcJournals
        '
        Me.DataGridViewPcJournals.AllowUserToAddRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPcJournals.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewPcJournals.AutoGenerateColumns = false
        Me.DataGridViewPcJournals.BegFindValue = Nothing
        Me.DataGridViewPcJournals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPcJournals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvPcClosed, Me.dgvTransactionDate, Me.dgvIdNo, Me.dgvReference, Me.dgvPayeeType, Me.dgvPayeeName, Me.dgvAmount, Me.dgvNotes, Me.dgvPayeeNameAra})
        Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPcJournals, 8)
        Me.DataGridViewPcJournals.DataSource = Me.bsPcJournals
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPcJournals.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewPcJournals.DgvFooter = Nothing
        Me.DataGridViewPcJournals.DisplayOnly = false
        Me.DataGridViewPcJournals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewPcJournals.Ea = Nothing
        Me.DataGridViewPcJournals.EditingMode = false
        Me.DataGridViewPcJournals.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPcJournals.EndFindValue = Nothing
        Me.DataGridViewPcJournals.FieldDescription = Nothing
        Me.DataGridViewPcJournals.FieldName = Nothing
        Me.DataGridViewPcJournals.FieldsDictionary = Nothing
        Me.DataGridViewPcJournals.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewPcJournals.FindEnabled = false
        Me.DataGridViewPcJournals.FirstRowDeletionEnabled = true
        Me.DataGridViewPcJournals.FirstRowInsertionEnabled = true
        Me.DataGridViewPcJournals.IgnoreCase = false
        Me.DataGridViewPcJournals.Location = New System.Drawing.Point(3, 107)
        Me.DataGridViewPcJournals.Name = "DataGridViewPcJournals"
        Me.DataGridViewPcJournals.ReadOnly = true
        Me.DataGridViewPcJournals.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewPcJournals.SequenceColumn = "dgvSequence"
        Me.DataGridViewPcJournals.SequenceFieldName = "Sequence"
        Me.DataGridViewPcJournals.ShowFooter = false
        Me.DataGridViewPcJournals.ShowInsertColumnWhenEditing = false
        Me.DataGridViewPcJournals.Size = New System.Drawing.Size(977, 450)
        Me.DataGridViewPcJournals.TabIndex = 10
        Me.DataGridViewPcJournals.Translatable = true
        '
        'dgvPcClosed
        '
        Me.dgvPcClosed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvPcClosed.DataPropertyName = "PcClosed"
        Me.dgvPcClosed.HeaderText = "Close?"
        Me.dgvPcClosed.MinimumWidth = 50
        Me.dgvPcClosed.Name = "dgvPcClosed"
        Me.dgvPcClosed.ReadOnly = true
        Me.dgvPcClosed.Width = 50
        '
        'dgvTransactionDate
        '
        Me.dgvTransactionDate.BegFindValue = Nothing
        Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvTransactionDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTransactionDate.DisplayOnly = true
        Me.dgvTransactionDate.EditingMode = false
        Me.dgvTransactionDate.EndFindValue = Nothing
        Me.dgvTransactionDate.FieldDescription = Nothing
        Me.dgvTransactionDate.FieldName = Nothing
        Me.dgvTransactionDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvTransactionDate.FindEnabled = false
        Me.dgvTransactionDate.HeaderText = "Date"
        Me.dgvTransactionDate.IgnoreCase = false
        Me.dgvTransactionDate.Name = "dgvTransactionDate"
        Me.dgvTransactionDate.ReadOnly = true
        Me.dgvTransactionDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransactionDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvTransactionDate.Translatable = false
        Me.dgvTransactionDate.Width = 80
        '
        'dgvIdNo
        '
        Me.dgvIdNo.BegFindValue = Nothing
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvIdNo.EditingMode = false
        Me.dgvIdNo.EndFindValue = Nothing
        Me.dgvIdNo.FieldDescription = Nothing
        Me.dgvIdNo.FieldName = Nothing
        Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvIdNo.FindEnabled = false
        Me.dgvIdNo.HeaderText = "IdNo"
        Me.dgvIdNo.IgnoreCase = false
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
        Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvIdNo.Translatable = false
        Me.dgvIdNo.Width = 50
        '
        'dgvReference
        '
        Me.dgvReference.BegFindValue = Nothing
        Me.dgvReference.DataPropertyName = "ReferenceNo"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvReference.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReference.EditingMode = false
        Me.dgvReference.EndFindValue = Nothing
        Me.dgvReference.FieldDescription = Nothing
        Me.dgvReference.FieldName = Nothing
        Me.dgvReference.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvReference.FindEnabled = false
        Me.dgvReference.HeaderText = "Reference No"
        Me.dgvReference.IgnoreCase = false
        Me.dgvReference.Name = "dgvReference"
        Me.dgvReference.ReadOnly = true
        Me.dgvReference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReference.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvReference.Translatable = false
        Me.dgvReference.Width = 80
        '
        'dgvPayeeType
        '
        Me.dgvPayeeType.BegFindValue = Nothing
        Me.dgvPayeeType.DataPropertyName = "PaymentType"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvPayeeType.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPayeeType.EditingMode = false
        Me.dgvPayeeType.EndFindValue = Nothing
        Me.dgvPayeeType.FieldDescription = Nothing
        Me.dgvPayeeType.FieldName = Nothing
        Me.dgvPayeeType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvPayeeType.FindEnabled = false
        Me.dgvPayeeType.HeaderText = "Payee Type"
        Me.dgvPayeeType.IgnoreCase = false
        Me.dgvPayeeType.Name = "dgvPayeeType"
        Me.dgvPayeeType.ReadOnly = true
        Me.dgvPayeeType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPayeeType.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvPayeeType.Translatable = false
        Me.dgvPayeeType.Width = 40
        '
        'dgvPayeeName
        '
        Me.dgvPayeeName.BegFindValue = Nothing
        Me.dgvPayeeName.DataPropertyName = "PayeeName"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvPayeeName.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPayeeName.EditingMode = false
        Me.dgvPayeeName.EndFindValue = Nothing
        Me.dgvPayeeName.FieldDescription = Nothing
        Me.dgvPayeeName.FieldName = Nothing
        Me.dgvPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvPayeeName.FindEnabled = false
        Me.dgvPayeeName.HeaderText = "PayeeName"
        Me.dgvPayeeName.IgnoreCase = false
        Me.dgvPayeeName.Name = "dgvPayeeName"
        Me.dgvPayeeName.ReadOnly = true
        Me.dgvPayeeName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvPayeeName.Translatable = false
        Me.dgvPayeeName.Width = 150
        '
        'dgvAmount
        '
        Me.dgvAmount.BegFindValue = Nothing
        Me.dgvAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.Format = "###,##0.00"
        Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle7
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
        'dgvNotes
        '
        Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNotes.BegFindValue = Nothing
        Me.dgvNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvNotes.EditingMode = false
        Me.dgvNotes.EndFindValue = Nothing
        Me.dgvNotes.FieldDescription = Nothing
        Me.dgvNotes.FieldName = Nothing
        Me.dgvNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvNotes.FindEnabled = false
        Me.dgvNotes.HeaderText = "Notes"
        Me.dgvNotes.IgnoreCase = false
        Me.dgvNotes.Name = "dgvNotes"
        Me.dgvNotes.ReadOnly = true
        Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvNotes.Translatable = false
        '
        'dgvPayeeNameAra
        '
        Me.dgvPayeeNameAra.BegFindValue = Nothing
        Me.dgvPayeeNameAra.DataPropertyName = "PayeeNameAra"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.dgvPayeeNameAra.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPayeeNameAra.EditingMode = false
        Me.dgvPayeeNameAra.EndFindValue = Nothing
        Me.dgvPayeeNameAra.FieldDescription = Nothing
        Me.dgvPayeeNameAra.FieldName = Nothing
        Me.dgvPayeeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvPayeeNameAra.FindEnabled = false
        Me.dgvPayeeNameAra.HeaderText = "PayeeNameAra"
        Me.dgvPayeeNameAra.IgnoreCase = false
        Me.dgvPayeeNameAra.Name = "dgvPayeeNameAra"
        Me.dgvPayeeNameAra.ReadOnly = true
        Me.dgvPayeeNameAra.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPayeeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvPayeeNameAra.Translatable = false
        Me.dgvPayeeNameAra.Visible = false
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
        Me.TableLayoutPanel1.Controls.Add(Me.CButton1, 1, 6)
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(983, 589)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'CButton1
        '
        Me.CButton1.DesignerSelected = false
        Me.CButton1.DisplayOnly = true
        Me.CButton1.ImageIndex = 0
        Me.CButton1.Location = New System.Drawing.Point(122, 563)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.OriginalImageName = Nothing
        Me.CButton1.SecurityKey = ""
        Me.CButton1.Size = New System.Drawing.Size(90, 23)
        Me.CButton1.TabIndex = 15
        Me.CButton1.Text = "Unselect All"
        '
        'txtPayeeName
        '
        Me.txtPayeeName.BackColor = System.Drawing.Color.White
        Me.txtPayeeName.BegFindValue = Nothing
        Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayeeName, 2)
        Me.txtPayeeName.ComputedValue = false
        Me.txtPayeeName.CustomFormat = Nothing
        Me.txtPayeeName.DataBoundControl = true
        Me.txtPayeeName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayeeName.EditingMode = true
        Me.txtPayeeName.EndFindValue = Nothing
        Me.txtPayeeName.FieldDescription = Nothing
        Me.txtPayeeName.FieldName = Nothing
        Me.txtPayeeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayeeName.FindEnabled = true
        Me.txtPayeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
        Me.txtPayeeName.LinkedLabel = Nothing
        Me.txtPayeeName.Location = New System.Drawing.Point(641, 54)
        Me.txtPayeeName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayeeName.MaximumValue = Nothing
        Me.txtPayeeName.MinimumValue = Nothing
        Me.txtPayeeName.Name = "txtPayeeName"
        Me.txtPayeeName.OldValue = Nothing
        Me.txtPayeeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayeeName.Size = New System.Drawing.Size(341, 23)
        Me.txtPayeeName.TabIndex = 8
        Me.txtPayeeName.Translatable = false
        '
        'lblPayee
        '
        Me.lblPayee.AutoSize = true
        Me.lblPayee.DisplayOnly = true
        Me.lblPayee.EditingMode = false
        Me.lblPayee.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayee.Location = New System.Drawing.Point(527, 54)
        Me.lblPayee.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayee.Name = "lblPayee"
        Me.lblPayee.Size = New System.Drawing.Size(48, 17)
        Me.lblPayee.TabIndex = 12
        Me.lblPayee.Text = "Payee"
        Me.lblPayee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPayee.Translatable = true
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.AutoSize = true
        Me.lblTransactionDate.DisplayOnly = true
        Me.lblTransactionDate.EditingMode = false
        Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblTransactionDate.Location = New System.Drawing.Point(1, 1)
        Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(117, 17)
        Me.lblTransactionDate.TabIndex = 3
        Me.lblTransactionDate.Text = "Transaction Date"
        Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTransactionDate.Translatable = true
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpTransactionDate.DefaultValue = Nothing
        Me.dtpTransactionDate.DisplayOnly = false
        Me.dtpTransactionDate.DtpDefaultValue = Nothing
        Me.dtpTransactionDate.EditingMode = true
        Me.dtpTransactionDate.EditsAllowed = false
        Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
        Me.dtpTransactionDate.LinkedLabel = Nothing
        Me.dtpTransactionDate.Location = New System.Drawing.Point(120, 1)
        Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ReadOnlyDp = false
        Me.dtpTransactionDate.SecurityKey = Nothing
        Me.dtpTransactionDate.ShowLongDate = false
        Me.dtpTransactionDate.ShowTime = false
        Me.dtpTransactionDate.Size = New System.Drawing.Size(112, 25)
        Me.dtpTransactionDate.TabIndex = 0
        Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpTransactionDate.Translatable = false
        Me.dtpTransactionDate.Value = Nothing
        Me.dtpTransactionDate.ValueIsMandatory = false
        Me.dtpTransactionDate.ValueIsNullable = false
        '
        'lblAccountIdNo
        '
        Me.lblAccountIdNo.AutoSize = true
        Me.lblAccountIdNo.DisplayOnly = true
        Me.lblAccountIdNo.EditingMode = false
        Me.lblAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAccountIdNo.Location = New System.Drawing.Point(1, 28)
        Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAccountIdNo.Name = "lblAccountIdNo"
        Me.lblAccountIdNo.Size = New System.Drawing.Size(109, 17)
        Me.lblAccountIdNo.TabIndex = 1
        Me.lblAccountIdNo.Text = "Closing Account"
        Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAccountIdNo.Translatable = true
        '
        'cboAccountIdNo
        '
        Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboAccountIdNo.BegFindValue = Nothing
        Me.cboAccountIdNo.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboAccountIdNo, 4)
        Me.cboAccountIdNo.CurrentSearchTerm = ""
        Me.cboAccountIdNo.DefaultValue = Nothing
        Me.cboAccountIdNo.DisplayMember = "Name"
        Me.cboAccountIdNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboAccountIdNo.EditingMode = true
        Me.cboAccountIdNo.EndFindValue = Nothing
        Me.cboAccountIdNo.FieldDescription = Nothing
        Me.cboAccountIdNo.FieldName = Nothing
        Me.cboAccountIdNo.FilterRule = Nothing
        Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboAccountIdNo.FindEnabled = false
        Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboAccountIdNo.FormattingEnabled = true
        Me.cboAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboAccountIdNo.IgnoreCase = false
        Me.cboAccountIdNo.IntegralHeight = false
        Me.cboAccountIdNo.LinkedLabel = Nothing
        Me.cboAccountIdNo.Location = New System.Drawing.Point(120, 28)
        Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboAccountIdNo.Name = "cboAccountIdNo"
        Me.cboAccountIdNo.OldValue = 0
        Me.cboAccountIdNo.OriginalDataSource = Nothing
        Me.cboAccountIdNo.OriginalList = Nothing
        Me.cboAccountIdNo.OverrideDropDownStyleList = false
        Me.cboAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboAccountIdNo.PropertySelector = Nothing
        Me.cboAccountIdNo.ReadOnlyCombo = false
        Me.cboAccountIdNo.Size = New System.Drawing.Size(405, 24)
        Me.cboAccountIdNo.SuggestBoxHeight = 200
        Me.cboAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboAccountIdNo.TabIndex = 5
        Me.cboAccountIdNo.TextToSearch = Nothing
        Me.cboAccountIdNo.Translatable = false
        Me.cboAccountIdNo.ValueIsMandatory = false
        Me.cboAccountIdNo.ValueIsNullable = false
        Me.cboAccountIdNo.ValueIsNumeric = false
        Me.cboAccountIdNo.ValueMember = "IdNo"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 7)
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.EditingMode = true
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(120, 80)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Size = New System.Drawing.Size(862, 23)
        Me.txtNotes.TabIndex = 9
        Me.txtNotes.Translatable = false
        '
        'CLabel2
        '
        Me.CLabel2.AutoSize = true
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(234, 1)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(100, 17)
        Me.CLabel2.TabIndex = 6
        Me.CLabel2.Text = "Reference No."
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = true
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.BackColor = System.Drawing.Color.White
        Me.txtReferenceNo.BegFindValue = Nothing
        Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNo.ComputedValue = false
        Me.txtReferenceNo.CustomFormat = Nothing
        Me.txtReferenceNo.DataBoundControl = true
        Me.txtReferenceNo.EditingMode = true
        Me.txtReferenceNo.EndFindValue = Nothing
        Me.txtReferenceNo.FieldDescription = Nothing
        Me.txtReferenceNo.FieldName = Nothing
        Me.txtReferenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtReferenceNo.FindEnabled = true
        Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
        Me.txtReferenceNo.LinkedLabel = Nothing
        Me.txtReferenceNo.Location = New System.Drawing.Point(336, 1)
        Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtReferenceNo.MaximumValue = Nothing
        Me.txtReferenceNo.MinimumValue = Nothing
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.OldValue = Nothing
        Me.txtReferenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtReferenceNo.Size = New System.Drawing.Size(86, 23)
        Me.txtReferenceNo.TabIndex = 1
        Me.txtReferenceNo.Translatable = false
        '
        'lblCheckNumber
        '
        Me.lblCheckNumber.AutoSize = true
        Me.lblCheckNumber.DisplayOnly = true
        Me.lblCheckNumber.EditingMode = false
        Me.lblCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblCheckNumber.Location = New System.Drawing.Point(424, 1)
        Me.lblCheckNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCheckNumber.Name = "lblCheckNumber"
        Me.lblCheckNumber.Size = New System.Drawing.Size(101, 17)
        Me.lblCheckNumber.TabIndex = 9
        Me.lblCheckNumber.Text = "Check Number"
        Me.lblCheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCheckNumber.Translatable = true
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BackColor = System.Drawing.Color.White
        Me.txtCheckNumber.BegFindValue = Nothing
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.ComputedValue = false
        Me.txtCheckNumber.CustomFormat = Nothing
        Me.txtCheckNumber.DataBoundControl = true
        Me.txtCheckNumber.EditingMode = true
        Me.txtCheckNumber.EndFindValue = Nothing
        Me.txtCheckNumber.FieldDescription = Nothing
        Me.txtCheckNumber.FieldName = Nothing
        Me.txtCheckNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtCheckNumber.FindEnabled = true
        Me.txtCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
        Me.txtCheckNumber.LinkedLabel = Nothing
        Me.txtCheckNumber.Location = New System.Drawing.Point(527, 1)
        Me.txtCheckNumber.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCheckNumber.MaximumValue = Nothing
        Me.txtCheckNumber.MinimumValue = Nothing
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.OldValue = Nothing
        Me.txtCheckNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtCheckNumber.Size = New System.Drawing.Size(112, 23)
        Me.txtCheckNumber.TabIndex = 2
        Me.txtCheckNumber.Translatable = false
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = true
        Me.lblAmount.DisplayOnly = true
        Me.lblAmount.EditingMode = false
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblAmount.Location = New System.Drawing.Point(641, 1)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(56, 17)
        Me.lblAmount.TabIndex = 10
        Me.lblAmount.Text = "Amount"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAmount.Translatable = true
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BegFindValue = Nothing
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.ComputedValue = false
        Me.txtAmount.CustomFormat = Nothing
        Me.txtAmount.DataBoundControl = true
        Me.txtAmount.DisplayOnly = true
        Me.txtAmount.EditingMode = true
        Me.txtAmount.EndFindValue = Nothing
        Me.txtAmount.FieldDescription = Nothing
        Me.txtAmount.FieldName = Nothing
        Me.txtAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtAmount.FindEnabled = true
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.LinkedLabel = Nothing
        Me.txtAmount.Location = New System.Drawing.Point(699, 1)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
        Me.txtAmount.MaximumValue = Nothing
        Me.txtAmount.MinimumValue = Nothing
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.OldValue = Nothing
        Me.txtAmount.ReadOnly = true
        Me.txtAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtAmount.Size = New System.Drawing.Size(112, 23)
        Me.txtAmount.TabIndex = 3
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmount.Translatable = false
        Me.txtAmount.ValueIsNumeric = true
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(1, 80)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(45, 17)
        Me.CLabel1.TabIndex = 4
        Me.CLabel1.Text = "Notes"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'btnSelectAll
        '
        Me.btnSelectAll.DesignerSelected = false
        Me.btnSelectAll.DisplayOnly = true
        Me.btnSelectAll.ImageIndex = 0
        Me.btnSelectAll.Location = New System.Drawing.Point(3, 563)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.OriginalImageName = Nothing
        Me.btnSelectAll.SecurityKey = ""
        Me.btnSelectAll.Size = New System.Drawing.Size(90, 23)
        Me.btnSelectAll.TabIndex = 14
        Me.btnSelectAll.Text = "Select All"
        '
        'CLabel3
        '
        Me.CLabel3.AutoSize = true
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(527, 28)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(68, 17)
        Me.CLabel3.TabIndex = 16
        Me.CLabel3.Text = "Pay Type"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = true
        '
        'cboPayType
        '
        Me.cboPayType.BackColor = System.Drawing.Color.White
        Me.cboPayType.BegFindValue = Nothing
        Me.cboPayType.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboPayType, 2)
        Me.cboPayType.CurrentSearchTerm = ""
        Me.cboPayType.DefaultValue = Nothing
        Me.cboPayType.DisplayMember = "Name"
        Me.cboPayType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPayType.EditingMode = true
        Me.cboPayType.EndFindValue = Nothing
        Me.cboPayType.FieldDescription = Nothing
        Me.cboPayType.FieldName = Nothing
        Me.cboPayType.FilterRule = Nothing
        Me.cboPayType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPayType.FindEnabled = false
        Me.cboPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPayType.ForeColor = System.Drawing.Color.Black
        Me.cboPayType.FormattingEnabled = true
        Me.cboPayType.HideWhenNotEditingOrAdding = false
        Me.cboPayType.IgnoreCase = false
        Me.cboPayType.IntegralHeight = false
        Me.cboPayType.LinkedLabel = Nothing
        Me.cboPayType.Location = New System.Drawing.Point(641, 28)
        Me.cboPayType.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPayType.Name = "cboPayType"
        Me.cboPayType.OldValue = 0
        Me.cboPayType.OriginalDataSource = Nothing
        Me.cboPayType.OriginalList = Nothing
        Me.cboPayType.OverrideDropDownStyleList = false
        Me.cboPayType.PreviousSearchTerm = Nothing
        Me.cboPayType.PropertySelector = Nothing
        Me.cboPayType.ReadOnlyCombo = false
        Me.cboPayType.Size = New System.Drawing.Size(341, 24)
        Me.cboPayType.SuggestBoxHeight = 200
        Me.cboPayType.SuggestListOrderRule = Nothing
        Me.cboPayType.TabIndex = 6
        Me.cboPayType.TextToSearch = Nothing
        Me.cboPayType.Translatable = false
        Me.cboPayType.ValueIsMandatory = false
        Me.cboPayType.ValueIsNullable = false
        Me.cboPayType.ValueIsNumeric = false
        Me.cboPayType.ValueMember = "IdNo"
        '
        'CLabel4
        '
        Me.CLabel4.AutoSize = true
        Me.CLabel4.DisplayOnly = true
        Me.CLabel4.EditingMode = false
        Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel4.Location = New System.Drawing.Point(1, 54)
        Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel4.Name = "CLabel4"
        Me.CLabel4.Size = New System.Drawing.Size(111, 17)
        Me.CLabel4.TabIndex = 18
        Me.CLabel4.Text = "Petty Cash Acct."
        Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel4.Translatable = true
        '
        'cboPcAccountIdNo
        '
        Me.cboPcAccountIdNo.BackColor = System.Drawing.Color.White
        Me.cboPcAccountIdNo.BegFindValue = Nothing
        Me.cboPcAccountIdNo.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboPcAccountIdNo, 4)
        Me.cboPcAccountIdNo.CurrentSearchTerm = ""
        Me.cboPcAccountIdNo.DefaultValue = Nothing
        Me.cboPcAccountIdNo.DisplayMember = "Name"
        Me.cboPcAccountIdNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPcAccountIdNo.EditingMode = true
        Me.cboPcAccountIdNo.EndFindValue = Nothing
        Me.cboPcAccountIdNo.FieldDescription = Nothing
        Me.cboPcAccountIdNo.FieldName = Nothing
        Me.cboPcAccountIdNo.FilterRule = Nothing
        Me.cboPcAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPcAccountIdNo.FindEnabled = false
        Me.cboPcAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPcAccountIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPcAccountIdNo.FormattingEnabled = true
        Me.cboPcAccountIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPcAccountIdNo.IgnoreCase = false
        Me.cboPcAccountIdNo.IntegralHeight = false
        Me.cboPcAccountIdNo.LinkedLabel = Nothing
        Me.cboPcAccountIdNo.Location = New System.Drawing.Point(120, 54)
        Me.cboPcAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPcAccountIdNo.Name = "cboPcAccountIdNo"
        Me.cboPcAccountIdNo.OldValue = 0
        Me.cboPcAccountIdNo.OriginalDataSource = Nothing
        Me.cboPcAccountIdNo.OriginalList = Nothing
        Me.cboPcAccountIdNo.OverrideDropDownStyleList = false
        Me.cboPcAccountIdNo.PreviousSearchTerm = Nothing
        Me.cboPcAccountIdNo.PropertySelector = Nothing
        Me.cboPcAccountIdNo.ReadOnlyCombo = false
        Me.cboPcAccountIdNo.Size = New System.Drawing.Size(405, 24)
        Me.cboPcAccountIdNo.SuggestBoxHeight = 200
        Me.cboPcAccountIdNo.SuggestListOrderRule = Nothing
        Me.cboPcAccountIdNo.TabIndex = 7
        Me.cboPcAccountIdNo.TextToSearch = Nothing
        Me.cboPcAccountIdNo.Translatable = false
        Me.cboPcAccountIdNo.ValueIsMandatory = false
        Me.cboPcAccountIdNo.ValueIsNullable = false
        Me.cboPcAccountIdNo.ValueIsNumeric = false
        Me.cboPcAccountIdNo.ValueMember = "IdNo"
        '
        'txtIdNo
        '
        Me.txtIdNo.BackColor = System.Drawing.Color.White
        Me.txtIdNo.BegFindValue = Nothing
        Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdNo.ComputedValue = false
        Me.txtIdNo.CustomFormat = Nothing
        Me.txtIdNo.DataBoundControl = true
        Me.txtIdNo.EditingMode = true
        Me.txtIdNo.EndFindValue = Nothing
        Me.txtIdNo.FieldDescription = Nothing
        Me.txtIdNo.FieldName = Nothing
        Me.txtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtIdNo.FindEnabled = false
        Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtIdNo.LinkedLabel = Nothing
        Me.txtIdNo.Location = New System.Drawing.Point(424, 561)
        Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIdNo.MaximumValue = Nothing
        Me.txtIdNo.MinimumValue = Nothing
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.OldValue = Nothing
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
        Friend WithEvents DataGridViewPcJournals As CDataGridView
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents lblTransactionDate As CLabel
        Friend WithEvents dtpTransactionDate As CCustomDateTimePicker
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As CaComboBox
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
        Friend WithEvents CButton1 As CButton
        Friend WithEvents btnSelectAll As CButton
        Friend WithEvents dgvPcClosed As DataGridViewCheckBoxColumn
        Friend WithEvents dgvTransactionDate As CDgvTextColumn
        Friend WithEvents dgvIdNo As CDgvTextColumn
        Friend WithEvents dgvReference As CDgvTextColumn
        Friend WithEvents dgvPayeeType As CDgvTextColumn
        Friend WithEvents dgvPayeeName As CDgvTextColumn
        Friend WithEvents dgvAmount As CdgvMoneyColumn
        Friend WithEvents dgvNotes As CDgvTextColumn
        Friend WithEvents dgvPayeeNameAra As CDgvTextColumn
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents cboPayType As CaComboBox
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents cboPcAccountIdNo As CaComboBox
        Friend WithEvents txtIdNo As CTextBox
    End Class
End Namespace