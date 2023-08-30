<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockRequestApproval
    Inherits AATM.PresentationLayer.Forms.CFormEntry

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockRequestApproval))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEnteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboApprovedBy = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateCreated = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.DataGridViewStockRequest = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.ReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarehouseToIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Notes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvTransTypeIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvApprove = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvDisapprove = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvApprovalNote = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.bsStockRequest = New System.Windows.Forms.BindingSource(Me.components)
        Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CancelledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DateCreatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvTransTypeIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NotesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PostedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ReferenceNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarehouseIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarehouseToIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CFlowLayout1.SuspendLayout()
        CType(Me.DataGridViewStockRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsStockRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout1.Controls.Add(Me.txtIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblEnteredBy)
        Me.CFlowLayout1.Controls.Add(Me.cboApprovedBy)
        Me.CFlowLayout1.Controls.Add(Me.CLabel1)
        Me.CFlowLayout1.Controls.Add(Me.dtpDateCreated)
        Me.CFlowLayout1.Controls.Add(Me.DataGridViewStockRequest)
        Me.CFlowLayout1.Location = New System.Drawing.Point(4, 70)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(1067, 542)
        Me.CFlowLayout1.TabIndex = 5
        '
        'lblIdNo
        '
        Me.lblIdNo.AutoSize = True
        Me.lblIdNo.DisplayOnly = True
        Me.lblIdNo.EditingMode = False
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(47, 17)
        Me.lblIdNo.TabIndex = 7
        Me.lblIdNo.Text = "ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdNo.Translatable = True
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
        Me.txtIdNo.Location = New System.Drawing.Point(50, 1)
        Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIdNo.MaximumValue = Nothing
        Me.txtIdNo.MinimumValue = Nothing
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.OldValue = Nothing
        Me.txtIdNo.OverrideMaxLength = 0
        Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtIdNo.Size = New System.Drawing.Size(100, 23)
        Me.txtIdNo.TabIndex = 0
        Me.txtIdNo.Translatable = False
        '
        'lblEnteredBy
        '
        Me.lblEnteredBy.DisplayOnly = True
        Me.lblEnteredBy.EditingMode = False
        Me.lblEnteredBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblEnteredBy.Location = New System.Drawing.Point(152, 1)
        Me.lblEnteredBy.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEnteredBy.Name = "lblEnteredBy"
        Me.lblEnteredBy.Size = New System.Drawing.Size(135, 24)
        Me.lblEnteredBy.TabIndex = 8
        Me.lblEnteredBy.Text = "Approved by:"
        Me.lblEnteredBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblEnteredBy.Translatable = True
        '
        'cboApprovedBy
        '
        Me.cboApprovedBy.BackColor = System.Drawing.Color.White
        Me.cboApprovedBy.BegFindValue = Nothing
        Me.cboApprovedBy.ChangingSearchValueOnly = False
        Me.cboApprovedBy.CurrentSearchTerm = ""
        Me.cboApprovedBy.DataValue = Nothing
        Me.cboApprovedBy.DefaultValue = Nothing
        Me.cboApprovedBy.DisplayMember = "Name"
        Me.cboApprovedBy.Editable = True
        Me.cboApprovedBy.EditingMode = True
        Me.cboApprovedBy.EndFindValue = Nothing
        Me.cboApprovedBy.FieldDescription = Nothing
        Me.cboApprovedBy.FieldName = Nothing
        Me.cboApprovedBy.FilterRule = Nothing
        Me.cboApprovedBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboApprovedBy.FindEnabled = False
        Me.cboApprovedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboApprovedBy.ForeColor = System.Drawing.Color.Black
        Me.cboApprovedBy.FormattingEnabled = True
        Me.cboApprovedBy.HideWhenNotEditingOrAdding = False
        Me.cboApprovedBy.IgnoreCase = False
        Me.cboApprovedBy.IntegralHeight = False
        Me.cboApprovedBy.LimitToList = False
        Me.cboApprovedBy.LinkedLabel = Nothing
        Me.cboApprovedBy.Location = New System.Drawing.Point(289, 1)
        Me.cboApprovedBy.Margin = New System.Windows.Forms.Padding(1)
        Me.cboApprovedBy.Name = "cboApprovedBy"
        Me.cboApprovedBy.OldValue = 0
        Me.cboApprovedBy.OriginalDataSource = Nothing
        Me.cboApprovedBy.OriginalList = Nothing
        Me.cboApprovedBy.OverrideDropDownStyleList = False
        Me.cboApprovedBy.PreviousSearchTerm = Nothing
        Me.cboApprovedBy.PropertySelector = Nothing
        Me.cboApprovedBy.ReadOnlyCombo = False
        Me.cboApprovedBy.Size = New System.Drawing.Size(350, 24)
        Me.cboApprovedBy.SuggestBoxHeight = 200
        Me.cboApprovedBy.SuggestListOrderRule = Nothing
        Me.cboApprovedBy.TabIndex = 1
        Me.cboApprovedBy.TextToSearch = Nothing
        Me.cboApprovedBy.Translatable = False
        Me.cboApprovedBy.ValueIsMandatory = False
        Me.cboApprovedBy.ValueIsNullable = False
        Me.cboApprovedBy.ValueIsNumeric = False
        Me.cboApprovedBy.ValueMember = "IdNo"
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = True
        Me.CLabel1.EditingMode = False
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel1.Location = New System.Drawing.Point(641, 1)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(211, 24)
        Me.CLabel1.TabIndex = 11
        Me.CLabel1.Text = "Date/Time Approved"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CLabel1.Translatable = True
        '
        'dtpDateCreated
        '
        Me.dtpDateCreated.AutoSize = True
        Me.dtpDateCreated.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.dtpDateCreated.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
        Me.dtpDateCreated.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateCreated.DefaultValue = Nothing
        Me.dtpDateCreated.DisplayOnly = False
        Me.dtpDateCreated.DtpDefaultValue = Nothing
        Me.dtpDateCreated.EditingMode = True
        Me.dtpDateCreated.EditsAllowed = False
        Me.dtpDateCreated.ForeColor = System.Drawing.Color.Black
        Me.dtpDateCreated.LinkedLabel = Nothing
        Me.dtpDateCreated.Location = New System.Drawing.Point(854, 1)
        Me.dtpDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpDateCreated.Name = "dtpDateCreated"
        Me.dtpDateCreated.ReadOnlyDp = False
        Me.dtpDateCreated.SecurityKey = Nothing
        Me.dtpDateCreated.ShowLongDate = False
        Me.dtpDateCreated.ShowTime = True
        Me.dtpDateCreated.Size = New System.Drawing.Size(195, 23)
        Me.dtpDateCreated.TabIndex = 2
        Me.dtpDateCreated.TargetCalendar = CType(resources.GetObject("dtpDateCreated.TargetCalendar"), System.Globalization.Calendar)
        Me.dtpDateCreated.Translatable = False
        Me.dtpDateCreated.Value = Nothing
        Me.dtpDateCreated.ValueIsMandatory = False
        Me.dtpDateCreated.ValueIsNullable = False
        '
        'DataGridViewStockRequest
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewStockRequest.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewStockRequest.AutoGenerateColumns = False
        Me.DataGridViewStockRequest.BackgroundColor = System.Drawing.Color.Silver
        Me.DataGridViewStockRequest.BegFindValue = Nothing
        Me.DataGridViewStockRequest.Cached = False
        Me.DataGridViewStockRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewStockRequest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReferenceNo, Me.TransactionDate, Me.WarehouseToIdNo, Me.UserIdNo, Me.Notes, Me.InvTransTypeIdNo, Me.dgvApprove, Me.dgvDisapprove, Me.dgvApprovalNote, Me.AmountDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn, Me.DateCreatedDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.InvTransTypeIdNoDataGridViewTextBoxColumn, Me.NotesDataGridViewTextBoxColumn, Me.PostedDataGridViewCheckBoxColumn, Me.ReferenceNoDataGridViewTextBoxColumn, Me.TransactionDateDataGridViewTextBoxColumn, Me.UserIdNoDataGridViewTextBoxColumn, Me.WarehouseIdNoDataGridViewTextBoxColumn, Me.WarehouseToIdNoDataGridViewTextBoxColumn})
        Me.DataGridViewStockRequest.DataFilter = Nothing
        Me.DataGridViewStockRequest.DataSource = Me.bsStockRequest
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewStockRequest.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewStockRequest.DgvFooter = Nothing
        Me.DataGridViewStockRequest.DisplayOnly = False
        Me.DataGridViewStockRequest.Ea = Nothing
        Me.DataGridViewStockRequest.EditingMode = False
        Me.DataGridViewStockRequest.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewStockRequest.EndFindValue = Nothing
        Me.DataGridViewStockRequest.FieldDescription = Nothing
        Me.DataGridViewStockRequest.FieldName = Nothing
        Me.DataGridViewStockRequest.FieldsDictionary = Nothing
        Me.DataGridViewStockRequest.FindColumnNo = CType(0, Short)
        Me.DataGridViewStockRequest.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewStockRequest.FindEnabled = False
        Me.DataGridViewStockRequest.FirstRowDeletionEnabled = True
        Me.DataGridViewStockRequest.FirstRowInsertionEnabled = True
        Me.DataGridViewStockRequest.IgnoreCase = False
        Me.DataGridViewStockRequest.IsDirty = False
        Me.DataGridViewStockRequest.Location = New System.Drawing.Point(3, 29)
        Me.DataGridViewStockRequest.Name = "DataGridViewStockRequest"
        Me.DataGridViewStockRequest.ReadOnly = True
        Me.DataGridViewStockRequest.Searchable = True
        Me.DataGridViewStockRequest.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewStockRequest.SecurityKey = ""
        Me.DataGridViewStockRequest.SequenceColumn = "dgvSequence"
        Me.DataGridViewStockRequest.SequenceFieldName = "Sequence"
        Me.DataGridViewStockRequest.ShowFooter = False
        Me.DataGridViewStockRequest.Size = New System.Drawing.Size(1055, 482)
        Me.DataGridViewStockRequest.TabIndex = 3
        Me.DataGridViewStockRequest.Translatable = True
        '
        'ReferenceNo
        '
        Me.ReferenceNo.DataPropertyName = "ReferenceNo"
        Me.ReferenceNo.HeaderText = "ReferenceNo"
        Me.ReferenceNo.Name = "ReferenceNo"
        Me.ReferenceNo.ReadOnly = True
        '
        'TransactionDate
        '
        Me.TransactionDate.DataPropertyName = "TransactionDate"
        Me.TransactionDate.HeaderText = "TransactionDate"
        Me.TransactionDate.Name = "TransactionDate"
        Me.TransactionDate.ReadOnly = True
        '
        'WarehouseToIdNo
        '
        Me.WarehouseToIdNo.DataPropertyName = "WarehouseToIdNo"
        Me.WarehouseToIdNo.HeaderText = "WarehouseToIdNo"
        Me.WarehouseToIdNo.Name = "WarehouseToIdNo"
        Me.WarehouseToIdNo.ReadOnly = True
        '
        'UserIdNo
        '
        Me.UserIdNo.DataPropertyName = "UserIdNo"
        Me.UserIdNo.HeaderText = "UserIdNo"
        Me.UserIdNo.Name = "UserIdNo"
        Me.UserIdNo.ReadOnly = True
        '
        'Notes
        '
        Me.Notes.DataPropertyName = "Notes"
        Me.Notes.HeaderText = "Notes"
        Me.Notes.Name = "Notes"
        Me.Notes.ReadOnly = True
        '
        'InvTransTypeIdNo
        '
        Me.InvTransTypeIdNo.DataPropertyName = "InvTransTypeIdNo"
        Me.InvTransTypeIdNo.HeaderText = "InvTransTypeIdNo"
        Me.InvTransTypeIdNo.Name = "InvTransTypeIdNo"
        Me.InvTransTypeIdNo.ReadOnly = True
        '
        'dgvApprove
        '
        Me.dgvApprove.BegFindValue = Nothing
        Me.dgvApprove.DataPropertyName = "Approve"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Orange
        DataGridViewCellStyle2.NullValue = False
        Me.dgvApprove.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvApprove.EditingMode = False
        Me.dgvApprove.EndFindValue = Nothing
        Me.dgvApprove.FieldDescription = Nothing
        Me.dgvApprove.FieldName = Nothing
        Me.dgvApprove.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvApprove.FindEnabled = False
        Me.dgvApprove.HeaderText = "Approve"
        Me.dgvApprove.IgnoreCase = False
        Me.dgvApprove.Name = "dgvApprove"
        Me.dgvApprove.ReadOnly = True
        Me.dgvApprove.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApprove.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvApprove.Translatable = False
        Me.dgvApprove.Width = 50
        '
        'dgvDisapprove
        '
        Me.dgvDisapprove.BegFindValue = Nothing
        Me.dgvDisapprove.DataPropertyName = "Disapprove"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Orange
        DataGridViewCellStyle3.NullValue = False
        Me.dgvDisapprove.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDisapprove.EditingMode = False
        Me.dgvDisapprove.EndFindValue = Nothing
        Me.dgvDisapprove.FieldDescription = Nothing
        Me.dgvDisapprove.FieldName = Nothing
        Me.dgvDisapprove.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDisapprove.FindEnabled = False
        Me.dgvDisapprove.HeaderText = "Dis- approve"
        Me.dgvDisapprove.IgnoreCase = False
        Me.dgvDisapprove.Name = "dgvDisapprove"
        Me.dgvDisapprove.ReadOnly = True
        Me.dgvDisapprove.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDisapprove.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDisapprove.Translatable = False
        Me.dgvDisapprove.Width = 50
        '
        'dgvApprovalNote
        '
        Me.dgvApprovalNote.BegFindValue = Nothing
        Me.dgvApprovalNote.DataPropertyName = "ApprovalNote"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvApprovalNote.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvApprovalNote.EditingMode = False
        Me.dgvApprovalNote.EndFindValue = Nothing
        Me.dgvApprovalNote.FieldDescription = Nothing
        Me.dgvApprovalNote.FieldName = Nothing
        Me.dgvApprovalNote.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvApprovalNote.FindEnabled = False
        Me.dgvApprovalNote.HeaderText = "Approval / Disapproval Note"
        Me.dgvApprovalNote.IgnoreCase = False
        Me.dgvApprovalNote.Name = "dgvApprovalNote"
        Me.dgvApprovalNote.ReadOnly = True
        Me.dgvApprovalNote.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApprovalNote.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvApprovalNote.Translatable = False
        '
        'bsStockRequest
        '
        Me.bsStockRequest.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvTransactionModel)
        '
        'AmountDataGridViewTextBoxColumn
        '
        Me.AmountDataGridViewTextBoxColumn.DataPropertyName = "Amount"
        Me.AmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.AmountDataGridViewTextBoxColumn.Name = "AmountDataGridViewTextBoxColumn"
        Me.AmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CancelledDataGridViewCheckBoxColumn
        '
        Me.CancelledDataGridViewCheckBoxColumn.DataPropertyName = "Cancelled"
        Me.CancelledDataGridViewCheckBoxColumn.HeaderText = "Cancelled"
        Me.CancelledDataGridViewCheckBoxColumn.Name = "CancelledDataGridViewCheckBoxColumn"
        Me.CancelledDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'DateCreatedDataGridViewTextBoxColumn
        '
        Me.DateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated"
        Me.DateCreatedDataGridViewTextBoxColumn.HeaderText = "DateCreated"
        Me.DateCreatedDataGridViewTextBoxColumn.Name = "DateCreatedDataGridViewTextBoxColumn"
        Me.DateCreatedDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdNoDataGridViewTextBoxColumn
        '
        Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
        Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InvTransTypeIdNoDataGridViewTextBoxColumn
        '
        Me.InvTransTypeIdNoDataGridViewTextBoxColumn.DataPropertyName = "InvTransTypeIdNo"
        Me.InvTransTypeIdNoDataGridViewTextBoxColumn.HeaderText = "InvTransTypeIdNo"
        Me.InvTransTypeIdNoDataGridViewTextBoxColumn.Name = "InvTransTypeIdNoDataGridViewTextBoxColumn"
        Me.InvTransTypeIdNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NotesDataGridViewTextBoxColumn
        '
        Me.NotesDataGridViewTextBoxColumn.DataPropertyName = "Notes"
        Me.NotesDataGridViewTextBoxColumn.HeaderText = "Notes"
        Me.NotesDataGridViewTextBoxColumn.Name = "NotesDataGridViewTextBoxColumn"
        Me.NotesDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PostedDataGridViewCheckBoxColumn
        '
        Me.PostedDataGridViewCheckBoxColumn.DataPropertyName = "Posted"
        Me.PostedDataGridViewCheckBoxColumn.HeaderText = "Posted"
        Me.PostedDataGridViewCheckBoxColumn.Name = "PostedDataGridViewCheckBoxColumn"
        Me.PostedDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'ReferenceNoDataGridViewTextBoxColumn
        '
        Me.ReferenceNoDataGridViewTextBoxColumn.DataPropertyName = "ReferenceNo"
        Me.ReferenceNoDataGridViewTextBoxColumn.HeaderText = "ReferenceNo"
        Me.ReferenceNoDataGridViewTextBoxColumn.Name = "ReferenceNoDataGridViewTextBoxColumn"
        Me.ReferenceNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TransactionDateDataGridViewTextBoxColumn
        '
        Me.TransactionDateDataGridViewTextBoxColumn.DataPropertyName = "TransactionDate"
        Me.TransactionDateDataGridViewTextBoxColumn.HeaderText = "TransactionDate"
        Me.TransactionDateDataGridViewTextBoxColumn.Name = "TransactionDateDataGridViewTextBoxColumn"
        Me.TransactionDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UserIdNoDataGridViewTextBoxColumn
        '
        Me.UserIdNoDataGridViewTextBoxColumn.DataPropertyName = "UserIdNo"
        Me.UserIdNoDataGridViewTextBoxColumn.HeaderText = "UserIdNo"
        Me.UserIdNoDataGridViewTextBoxColumn.Name = "UserIdNoDataGridViewTextBoxColumn"
        Me.UserIdNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WarehouseIdNoDataGridViewTextBoxColumn
        '
        Me.WarehouseIdNoDataGridViewTextBoxColumn.DataPropertyName = "WarehouseIdNo"
        Me.WarehouseIdNoDataGridViewTextBoxColumn.HeaderText = "WarehouseIdNo"
        Me.WarehouseIdNoDataGridViewTextBoxColumn.Name = "WarehouseIdNoDataGridViewTextBoxColumn"
        Me.WarehouseIdNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'WarehouseToIdNoDataGridViewTextBoxColumn
        '
        Me.WarehouseToIdNoDataGridViewTextBoxColumn.DataPropertyName = "WarehouseToIdNo"
        Me.WarehouseToIdNoDataGridViewTextBoxColumn.HeaderText = "WarehouseToIdNo"
        Me.WarehouseToIdNoDataGridViewTextBoxColumn.Name = "WarehouseToIdNoDataGridViewTextBoxColumn"
        Me.WarehouseToIdNoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'StockRequestApproval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1073, 615)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "StockRequestApproval"
        Me.Text = "Employee Leave Approval"
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CFlowLayout1.ResumeLayout(False)
        Me.CFlowLayout1.PerformLayout()
        CType(Me.DataGridViewStockRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsStockRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bsStockRequest As BindingSource
    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtIdNo As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblEnteredBy As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents cboApprovedBy As Libraries.CBaseControlsLibrary.CaComboBox
    Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents dtpDateCreated As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    Friend WithEvents DataGridViewStockRequest As Libraries.CBaseControlsLibrary.CDataGridView
    Friend WithEvents dgvStockRequestIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvEmployeeIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
    Friend WithEvents dgvFullDay As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    Friend WithEvents dgvStartDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvEndDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvLeaveReason As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvLeaveStatus As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
    Friend WithEvents enteredByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SupervisorIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ReferenceNo As DataGridViewTextBoxColumn
    Friend WithEvents TransactionDate As DataGridViewTextBoxColumn
    Friend WithEvents WarehouseToIdNo As DataGridViewTextBoxColumn
    Friend WithEvents UserIdNo As DataGridViewTextBoxColumn
    Friend WithEvents Notes As DataGridViewTextBoxColumn
    Friend WithEvents InvTransTypeIdNo As DataGridViewTextBoxColumn
    Friend WithEvents dgvApprove As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    Friend WithEvents dgvDisapprove As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    Friend WithEvents dgvApprovalNote As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents IdNo As DataGridViewTextBoxColumn
    Friend WithEvents AmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CancelledDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents DateCreatedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InvTransTypeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NotesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PostedDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents ReferenceNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TransactionDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UserIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WarehouseIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WarehouseToIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
