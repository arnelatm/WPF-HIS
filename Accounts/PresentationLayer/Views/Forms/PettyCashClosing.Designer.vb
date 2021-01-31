Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PettyCashClosing
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
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PettyCashClosing))
            Me.DataGridViewPcJournals = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.PcClosedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvTransactionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvReference = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPayeeType = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPayeeName = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvPayeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnMoney()
            Me.dgvNotes = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.bsPcJournals = New System.Windows.Forms.BindingSource(Me.components)
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtReferenceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCheckNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblAmount = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAmount = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPayee = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewPcJournals, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPcJournals, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
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
            'DataGridViewPcJournals
            '
            Me.DataGridViewPcJournals.AllowUserToAddRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPcJournals.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPcJournals.AutoGenerateColumns = False
            Me.DataGridViewPcJournals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPcJournals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PcClosedDataGridViewCheckBoxColumn, Me.dgvTransactionDate, Me.dgvIdNo, Me.dgvReference, Me.dgvPayeeType, Me.dgvPayeeName, Me.dgvPayeeNameAra, Me.dgvAmount, Me.dgvNotes})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPcJournals, 8)
            Me.DataGridViewPcJournals.DataSource = Me.bsPcJournals
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPcJournals.DefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewPcJournals.DgvFooter = Nothing
            Me.DataGridViewPcJournals.DisplayOnly = False
            Me.DataGridViewPcJournals.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPcJournals.Ea = Nothing
            Me.DataGridViewPcJournals.EditingMode = False
            Me.DataGridViewPcJournals.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPcJournals.FirstRowDeletionEnabled = True
            Me.DataGridViewPcJournals.FirstRowInsertionEnabled = True
            Me.DataGridViewPcJournals.Location = New System.Drawing.Point(3, 106)
            Me.DataGridViewPcJournals.Name = "DataGridViewPcJournals"
            Me.DataGridViewPcJournals.ReadOnly = True
            Me.DataGridViewPcJournals.SequenceColumn = "dgvSequence"
            Me.DataGridViewPcJournals.SequenceFieldName = "Sequence"
            Me.DataGridViewPcJournals.ShowFooter = False
            Me.DataGridViewPcJournals.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPcJournals.Size = New System.Drawing.Size(977, 476)
            Me.DataGridViewPcJournals.TabIndex = 4
            '
            'PcClosedDataGridViewCheckBoxColumn
            '
            Me.PcClosedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.PcClosedDataGridViewCheckBoxColumn.DataPropertyName = "PcClosed"
            Me.PcClosedDataGridViewCheckBoxColumn.HeaderText = "Close?"
            Me.PcClosedDataGridViewCheckBoxColumn.MinimumWidth = 50
            Me.PcClosedDataGridViewCheckBoxColumn.Name = "PcClosedDataGridViewCheckBoxColumn"
            Me.PcClosedDataGridViewCheckBoxColumn.ReadOnly = True
            Me.PcClosedDataGridViewCheckBoxColumn.Width = 50
            '
            'dgvTransactionDate
            '
            Me.dgvTransactionDate.DataPropertyName = "TransactionDate"
            Me.dgvTransactionDate.HeaderText = "Date"
            Me.dgvTransactionDate.Name = "dgvTransactionDate"
            Me.dgvTransactionDate.ReadOnly = True
            Me.dgvTransactionDate.Width = 80
            '
            'dgvIdNo
            '
            Me.dgvIdNo.DataPropertyName = "IdNo"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvIdNo.EditingMode = False
            Me.dgvIdNo.HeaderText = "IdNo"
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvIdNo.Width = 50
            '
            'dgvReference
            '
            Me.dgvReference.DataPropertyName = "ReferenceNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvReference.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvReference.EditingMode = False
            Me.dgvReference.HeaderText = "Reference No"
            Me.dgvReference.Name = "dgvReference"
            Me.dgvReference.ReadOnly = True
            Me.dgvReference.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvReference.Width = 80
            '
            'dgvPayeeType
            '
            Me.dgvPayeeType.DataPropertyName = "PaymentType"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvPayeeType.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvPayeeType.EditingMode = False
            Me.dgvPayeeType.HeaderText = "Payee Type"
            Me.dgvPayeeType.Name = "dgvPayeeType"
            Me.dgvPayeeType.ReadOnly = True
            Me.dgvPayeeType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPayeeType.Width = 40
            '
            'dgvPayeeName
            '
            Me.dgvPayeeName.DataPropertyName = "PayeeName"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvPayeeName.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvPayeeName.EditingMode = False
            Me.dgvPayeeName.HeaderText = "PayeeName"
            Me.dgvPayeeName.Name = "dgvPayeeName"
            Me.dgvPayeeName.ReadOnly = True
            Me.dgvPayeeName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPayeeName.Width = 150
            '
            'dgvPayeeNameAra
            '
            Me.dgvPayeeNameAra.DataPropertyName = "PayeeNameAra"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvPayeeNameAra.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvPayeeNameAra.EditingMode = False
            Me.dgvPayeeNameAra.HeaderText = "PayeeNameAra"
            Me.dgvPayeeNameAra.Name = "dgvPayeeNameAra"
            Me.dgvPayeeNameAra.ReadOnly = True
            Me.dgvPayeeNameAra.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPayeeNameAra.Visible = False
            Me.dgvPayeeNameAra.Width = 150
            '
            'dgvAmount
            '
            Me.dgvAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.Format = "###,##0.00"
            Me.dgvAmount.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvAmount.EditingMode = False
            Me.dgvAmount.HeaderText = "Amount"
            Me.dgvAmount.Name = "dgvAmount"
            Me.dgvAmount.ReadOnly = True
            Me.dgvAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvNotes
            '
            Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvNotes.DataPropertyName = "Notes"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvNotes.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvNotes.EditingMode = False
            Me.dgvNotes.HeaderText = "Notes"
            Me.dgvNotes.Name = "dgvNotes"
            Me.dgvNotes.ReadOnly = True
            Me.dgvNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'bsPcJournals
            '
            Me.bsPcJournals.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PcJournalModel)
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
            Me.TableLayoutPanel1.Controls.Add(Me.txtPayeeName, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPayee, 0, 3)
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
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 58)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 6
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(983, 575)
            Me.TableLayoutPanel1.TabIndex = 5
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
            '
            'dtpTransactionDate
            '
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
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(112, 25)
            Me.dtpTransactionDate.TabIndex = 2
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
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
            Me.lblAccountIdNo.Location = New System.Drawing.Point(1, 28)
            Me.lblAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Size = New System.Drawing.Size(109, 17)
            Me.lblAccountIdNo.TabIndex = 1
            Me.lblAccountIdNo.Text = "Closing Account"
            Me.lblAccountIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboAccountIdNo, 7)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            Me.cboAccountIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboAccountIdNo.DropDownHeight = 200
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAccountIdNo.EditingMode = True
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.LinkedLabel = Nothing
            Me.cboAccountIdNo.Location = New System.Drawing.Point(120, 28)
            Me.cboAccountIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PreviousSelectedIndex = -1
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.SearchAnywhere = False
            Me.cboAccountIdNo.Size = New System.Drawing.Size(862, 24)
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TabIndex = 5
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 7)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtNotes.EditingMode = True
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(120, 79)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.Size = New System.Drawing.Size(862, 23)
            Me.txtNotes.TabIndex = 0
            '
            'CLabel1
            '
            Me.CLabel1.AutoSize = True
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 79)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(45, 17)
            Me.CLabel1.TabIndex = 4
            Me.CLabel1.Text = "Notes"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(234, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(100, 17)
            Me.CLabel2.TabIndex = 6
            Me.CLabel2.Text = "Reference No."
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtReferenceNo
            '
            Me.txtReferenceNo.BackColor = System.Drawing.Color.White
            Me.txtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReferenceNo.ComputedValue = False
            Me.txtReferenceNo.CustomFormat = Nothing
            Me.txtReferenceNo.DataBoundControl = True
            Me.txtReferenceNo.EditingMode = True
            Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtReferenceNo.ForeColor = System.Drawing.Color.Black
            Me.txtReferenceNo.LinkedLabel = Nothing
            Me.txtReferenceNo.Location = New System.Drawing.Point(336, 1)
            Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtReferenceNo.MaximumValue = Nothing
            Me.txtReferenceNo.MinimumValue = Nothing
            Me.txtReferenceNo.Name = "txtReferenceNo"
            Me.txtReferenceNo.OldValue = Nothing
            Me.txtReferenceNo.Size = New System.Drawing.Size(86, 23)
            Me.txtReferenceNo.TabIndex = 7
            '
            'lblCheckNumber
            '
            Me.lblCheckNumber.AutoSize = True
            Me.lblCheckNumber.DisplayOnly = True
            Me.lblCheckNumber.EditingMode = False
            Me.lblCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCheckNumber.Location = New System.Drawing.Point(424, 1)
            Me.lblCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCheckNumber.Name = "lblCheckNumber"
            Me.lblCheckNumber.Size = New System.Drawing.Size(101, 17)
            Me.lblCheckNumber.TabIndex = 9
            Me.lblCheckNumber.Text = "Check Number"
            Me.lblCheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtCheckNumber
            '
            Me.txtCheckNumber.BackColor = System.Drawing.Color.White
            Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCheckNumber.ComputedValue = False
            Me.txtCheckNumber.CustomFormat = Nothing
            Me.txtCheckNumber.DataBoundControl = True
            Me.txtCheckNumber.EditingMode = True
            Me.txtCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCheckNumber.ForeColor = System.Drawing.Color.Black
            Me.txtCheckNumber.LinkedLabel = Nothing
            Me.txtCheckNumber.Location = New System.Drawing.Point(527, 1)
            Me.txtCheckNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCheckNumber.MaximumValue = Nothing
            Me.txtCheckNumber.MinimumValue = Nothing
            Me.txtCheckNumber.Name = "txtCheckNumber"
            Me.txtCheckNumber.OldValue = Nothing
            Me.txtCheckNumber.Size = New System.Drawing.Size(112, 23)
            Me.txtCheckNumber.TabIndex = 8
            '
            'lblAmount
            '
            Me.lblAmount.AutoSize = True
            Me.lblAmount.DisplayOnly = True
            Me.lblAmount.EditingMode = False
            Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblAmount.Location = New System.Drawing.Point(641, 1)
            Me.lblAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.lblAmount.Name = "lblAmount"
            Me.lblAmount.Size = New System.Drawing.Size(56, 17)
            Me.lblAmount.TabIndex = 10
            Me.lblAmount.Text = "Amount"
            Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtAmount
            '
            Me.txtAmount.BackColor = System.Drawing.Color.White
            Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAmount.ComputedValue = False
            Me.txtAmount.CustomFormat = Nothing
            Me.txtAmount.DataBoundControl = True
            Me.txtAmount.EditingMode = True
            Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAmount.ForeColor = System.Drawing.Color.Black
            Me.txtAmount.LinkedLabel = Nothing
            Me.txtAmount.Location = New System.Drawing.Point(699, 1)
            Me.txtAmount.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAmount.MaximumValue = Nothing
            Me.txtAmount.MinimumValue = Nothing
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.OldValue = Nothing
            Me.txtAmount.Size = New System.Drawing.Size(112, 23)
            Me.txtAmount.TabIndex = 11
            '
            'lblPayee
            '
            Me.lblPayee.AutoSize = True
            Me.lblPayee.DisplayOnly = True
            Me.lblPayee.EditingMode = False
            Me.lblPayee.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayee.Location = New System.Drawing.Point(1, 54)
            Me.lblPayee.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayee.Name = "lblPayee"
            Me.lblPayee.Size = New System.Drawing.Size(48, 17)
            Me.lblPayee.TabIndex = 12
            Me.lblPayee.Text = "Payee"
            Me.lblPayee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPayeeName
            '
            Me.txtPayeeName.BackColor = System.Drawing.Color.White
            Me.txtPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayeeName, 7)
            Me.txtPayeeName.ComputedValue = False
            Me.txtPayeeName.CustomFormat = Nothing
            Me.txtPayeeName.DataBoundControl = True
            Me.txtPayeeName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayeeName.EditingMode = True
            Me.txtPayeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayeeName.ForeColor = System.Drawing.Color.Black
            Me.txtPayeeName.LinkedLabel = Nothing
            Me.txtPayeeName.Location = New System.Drawing.Point(120, 54)
            Me.txtPayeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayeeName.MaximumValue = Nothing
            Me.txtPayeeName.MinimumValue = Nothing
            Me.txtPayeeName.Name = "txtPayeeName"
            Me.txtPayeeName.OldValue = Nothing
            Me.txtPayeeName.Size = New System.Drawing.Size(862, 23)
            Me.txtPayeeName.TabIndex = 13
            '
            'PettyCashClosing
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(1004, 645)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.MinimumSize = New System.Drawing.Size(945, 590)
            Me.Name = "PettyCashClosing"
            Me.Text = "Petty Cash Closing"
            Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewPcJournals, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPcJournals, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsPcJournals As Windows.Forms.BindingSource
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
        Friend WithEvents PcClosedDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents dgvTransactionDate As DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As CdgvColumnText
        Friend WithEvents dgvReference As CdgvColumnText
        Friend WithEvents dgvPayeeType As CdgvColumnText
        Friend WithEvents dgvPayeeName As CdgvColumnText
        Friend WithEvents dgvPayeeNameAra As CdgvColumnText
        Friend WithEvents dgvAmount As CdgvColumnMoney
        Friend WithEvents dgvNotes As CdgvColumnText
        Friend WithEvents lblAmount As CLabel
        Friend WithEvents txtAmount As CTextBox
        Friend WithEvents txtPayeeName As CTextBox
        Friend WithEvents lblPayee As CLabel
    End Class
End Namespace