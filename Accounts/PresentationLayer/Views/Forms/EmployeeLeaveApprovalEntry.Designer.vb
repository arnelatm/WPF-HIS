<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeLeaveApprovalEntry
    Inherits AATM.PresentationLayer.Forms.CFormBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeLeaveApprovalEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEnteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboApprovedBy = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateCreated = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.DataGridViewEmployeeLeave = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvApprove = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvDisapprove = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvApprovalNote = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvFullDay = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvStartDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvEndDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvLeaveIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvLeaveReason = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvLeaveStatus = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.enteredByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCreatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupervisorIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsEmployeeLeave = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        CType(Me.DataGridViewEmployeeLeave,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsEmployeeLeave,System.ComponentModel.ISupportInitialize).BeginInit
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
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
        Me.CFlowLayout1.Controls.Add(Me.txtIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblEnteredBy)
        Me.CFlowLayout1.Controls.Add(Me.cboApprovedBy)
        Me.CFlowLayout1.Controls.Add(Me.CLabel1)
        Me.CFlowLayout1.Controls.Add(Me.dtpDateCreated)
        Me.CFlowLayout1.Controls.Add(Me.DataGridViewEmployeeLeave)
        Me.CFlowLayout1.Location = New System.Drawing.Point(4, 70)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(1067, 542)
        Me.CFlowLayout1.TabIndex = 5
        '
        'lblIdNo
        '
        Me.lblIdNo.AutoSize = true
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(47, 17)
        Me.lblIdNo.TabIndex = 7
        Me.lblIdNo.Text = "ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIdNo.Translatable = true
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
        Me.txtIdNo.Location = New System.Drawing.Point(50, 1)
        Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIdNo.MaximumValue = Nothing
        Me.txtIdNo.MinimumValue = Nothing
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.OldValue = Nothing
        Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtIdNo.Size = New System.Drawing.Size(100, 23)
        Me.txtIdNo.TabIndex = 6
        Me.txtIdNo.Translatable = false
        '
        'lblEnteredBy
        '
        Me.lblEnteredBy.DisplayOnly = true
        Me.lblEnteredBy.EditingMode = false
        Me.lblEnteredBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEnteredBy.Location = New System.Drawing.Point(152, 1)
        Me.lblEnteredBy.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEnteredBy.Name = "lblEnteredBy"
        Me.lblEnteredBy.Size = New System.Drawing.Size(135, 24)
        Me.lblEnteredBy.TabIndex = 8
        Me.lblEnteredBy.Text = "Approved by:"
        Me.lblEnteredBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblEnteredBy.Translatable = true
        '
        'cboApprovedBy
        '
        Me.cboApprovedBy.BackColor = System.Drawing.Color.White
        Me.cboApprovedBy.BegFindValue = Nothing
        Me.cboApprovedBy.ChangingSearchValueOnly = false
        Me.cboApprovedBy.CurrentSearchTerm = ""
        Me.cboApprovedBy.DefaultValue = Nothing
        Me.cboApprovedBy.DisplayMember = "Name"
        Me.cboApprovedBy.EditingMode = true
        Me.cboApprovedBy.EndFindValue = Nothing
        Me.cboApprovedBy.FieldDescription = Nothing
        Me.cboApprovedBy.FieldName = Nothing
        Me.cboApprovedBy.FilterRule = Nothing
        Me.cboApprovedBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboApprovedBy.FindEnabled = false
        Me.cboApprovedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboApprovedBy.ForeColor = System.Drawing.Color.Black
        Me.cboApprovedBy.FormattingEnabled = true
        Me.cboApprovedBy.HideWhenNotEditingOrAdding = false
        Me.cboApprovedBy.IgnoreCase = false
        Me.cboApprovedBy.IntegralHeight = false
        Me.cboApprovedBy.LinkedLabel = Nothing
        Me.cboApprovedBy.Location = New System.Drawing.Point(289, 1)
        Me.cboApprovedBy.Margin = New System.Windows.Forms.Padding(1)
        Me.cboApprovedBy.Name = "cboApprovedBy"
        Me.cboApprovedBy.OldValue = 0
        Me.cboApprovedBy.OriginalDataSource = Nothing
        Me.cboApprovedBy.OriginalList = Nothing
        Me.cboApprovedBy.OverrideDropDownStyleList = false
        Me.cboApprovedBy.PreviousSearchTerm = Nothing
        Me.cboApprovedBy.PropertySelector = Nothing
        Me.cboApprovedBy.ReadOnlyCombo = false
        Me.cboApprovedBy.Size = New System.Drawing.Size(350, 24)
        Me.cboApprovedBy.SuggestBoxHeight = 200
        Me.cboApprovedBy.SuggestListOrderRule = Nothing
        Me.cboApprovedBy.TabIndex = 10
        Me.cboApprovedBy.TextToSearch = Nothing
        Me.cboApprovedBy.Translatable = false
        Me.cboApprovedBy.ValueIsMandatory = false
        Me.cboApprovedBy.ValueIsNullable = false
        Me.cboApprovedBy.ValueIsNumeric = false
        Me.cboApprovedBy.ValueMember = "IdNo"
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(641, 1)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(211, 24)
        Me.CLabel1.TabIndex = 11
        Me.CLabel1.Text = "Date/Time Approved"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CLabel1.Translatable = true
        '
        'dtpDateCreated
        '
        Me.dtpDateCreated.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateCreated.DefaultValue = Nothing
        Me.dtpDateCreated.DisplayOnly = false
        Me.dtpDateCreated.DtpDefaultValue = Nothing
        Me.dtpDateCreated.EditingMode = true
        Me.dtpDateCreated.EditsAllowed = false
        Me.dtpDateCreated.ForeColor = System.Drawing.Color.Black
        Me.dtpDateCreated.LinkedLabel = Nothing
        Me.dtpDateCreated.Location = New System.Drawing.Point(854, 1)
        Me.dtpDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpDateCreated.Name = "dtpDateCreated"
        Me.dtpDateCreated.ReadOnlyDp = false
        Me.dtpDateCreated.SecurityKey = Nothing
        Me.dtpDateCreated.ShowLongDate = false
        Me.dtpDateCreated.ShowTime = true
        Me.dtpDateCreated.Size = New System.Drawing.Size(191, 23)
        Me.dtpDateCreated.TabIndex = 12
        Me.dtpDateCreated.TargetCalendar = CType(resources.GetObject("dtpDateCreated.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpDateCreated.Translatable = false
        Me.dtpDateCreated.Value = Nothing
        Me.dtpDateCreated.ValueIsMandatory = false
        Me.dtpDateCreated.ValueIsNullable = false
        '
        'DataGridViewEmployeeLeave
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewEmployeeLeave.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewEmployeeLeave.AutoGenerateColumns = false
        Me.DataGridViewEmployeeLeave.BegFindValue = Nothing
        Me.DataGridViewEmployeeLeave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewEmployeeLeave.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvIdNo, Me.dgvEmployeeIdNo, Me.dgvFullDay, Me.dgvStartDate, Me.dgvEndDate, Me.dgvLeaveIdNo, Me.dgvLeaveReason, Me.dgvLeaveStatus, Me.dgvApprove, Me.dgvDisapprove, Me.dgvApprovalNote, Me.enteredByDataGridViewTextBoxColumn, Me.DateCreatedDataGridViewTextBoxColumn, Me.SupervisorIdNoDataGridViewTextBoxColumn})
        Me.DataGridViewEmployeeLeave.DataSource = Me.bsEmployeeLeave
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewEmployeeLeave.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewEmployeeLeave.DgvFooter = Nothing
        Me.DataGridViewEmployeeLeave.DisplayOnly = false
        Me.DataGridViewEmployeeLeave.Ea = Nothing
        Me.DataGridViewEmployeeLeave.EditingMode = false
        Me.DataGridViewEmployeeLeave.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewEmployeeLeave.EndFindValue = Nothing
        Me.DataGridViewEmployeeLeave.FieldDescription = Nothing
        Me.DataGridViewEmployeeLeave.FieldName = Nothing
        Me.DataGridViewEmployeeLeave.FieldsDictionary = Nothing
        Me.DataGridViewEmployeeLeave.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewEmployeeLeave.FindEnabled = false
        Me.DataGridViewEmployeeLeave.FirstRowDeletionEnabled = true
        Me.DataGridViewEmployeeLeave.FirstRowInsertionEnabled = true
        Me.DataGridViewEmployeeLeave.IgnoreCase = false
        Me.DataGridViewEmployeeLeave.IsDirty = false
        Me.DataGridViewEmployeeLeave.Location = New System.Drawing.Point(3, 29)
        Me.DataGridViewEmployeeLeave.Name = "DataGridViewEmployeeLeave"
        Me.DataGridViewEmployeeLeave.ReadOnly = true
        Me.DataGridViewEmployeeLeave.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewEmployeeLeave.SecurityKey = ""
        Me.DataGridViewEmployeeLeave.SequenceColumn = "dgvSequence"
        Me.DataGridViewEmployeeLeave.SequenceFieldName = "Sequence"
        Me.DataGridViewEmployeeLeave.ShowFooter = false
        Me.DataGridViewEmployeeLeave.ShowInsertColumnWhenEditing = true
        Me.DataGridViewEmployeeLeave.Size = New System.Drawing.Size(1055, 482)
        Me.DataGridViewEmployeeLeave.TabIndex = 5
        Me.DataGridViewEmployeeLeave.Translatable = true
        '
        'dgvApprove
        '
        Me.dgvApprove.BegFindValue = Nothing
        Me.dgvApprove.DataPropertyName = "Approve"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Orange
        DataGridViewCellStyle10.NullValue = false
        Me.dgvApprove.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvApprove.EditingMode = false
        Me.dgvApprove.EndFindValue = Nothing
        Me.dgvApprove.FieldDescription = Nothing
        Me.dgvApprove.FieldName = Nothing
        Me.dgvApprove.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvApprove.FindEnabled = false
        Me.dgvApprove.HeaderText = "Approve"
        Me.dgvApprove.IgnoreCase = false
        Me.dgvApprove.Name = "dgvApprove"
        Me.dgvApprove.ReadOnly = true
        Me.dgvApprove.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApprove.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvApprove.Translatable = false
        Me.dgvApprove.Width = 50
        '
        'dgvDisapprove
        '
        Me.dgvDisapprove.BegFindValue = Nothing
        Me.dgvDisapprove.DataPropertyName = "Disapprove"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Orange
        DataGridViewCellStyle11.NullValue = false
        Me.dgvDisapprove.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDisapprove.EditingMode = false
        Me.dgvDisapprove.EndFindValue = Nothing
        Me.dgvDisapprove.FieldDescription = Nothing
        Me.dgvDisapprove.FieldName = Nothing
        Me.dgvDisapprove.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDisapprove.FindEnabled = false
        Me.dgvDisapprove.HeaderText = "Disapprove"
        Me.dgvDisapprove.IgnoreCase = false
        Me.dgvDisapprove.Name = "dgvDisapprove"
        Me.dgvDisapprove.ReadOnly = true
        Me.dgvDisapprove.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDisapprove.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDisapprove.Translatable = false
        Me.dgvDisapprove.Width = 65
        '
        'dgvApprovalNote
        '
        Me.dgvApprovalNote.BegFindValue = Nothing
        Me.dgvApprovalNote.DataPropertyName = "ApprovalNote"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.dgvApprovalNote.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvApprovalNote.EditingMode = false
        Me.dgvApprovalNote.EndFindValue = Nothing
        Me.dgvApprovalNote.FieldDescription = Nothing
        Me.dgvApprovalNote.FieldName = Nothing
        Me.dgvApprovalNote.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvApprovalNote.FindEnabled = false
        Me.dgvApprovalNote.HeaderText = "ApprovalNote"
        Me.dgvApprovalNote.IgnoreCase = false
        Me.dgvApprovalNote.Name = "dgvApprovalNote"
        Me.dgvApprovalNote.ReadOnly = true
        Me.dgvApprovalNote.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApprovalNote.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvApprovalNote.Translatable = false
        '
        'dgvIdNo
        '
        Me.dgvIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvIdNo.BegFindValue = Nothing
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIdNo.DisplayOnly = true
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
        Me.dgvIdNo.Width = 55
        '
        'dgvEmployeeIdNo
        '
        Me.dgvEmployeeIdNo.DataPropertyName = "EmployeeIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvEmployeeIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEmployeeIdNo.EditingMode = false
        Me.dgvEmployeeIdNo.HeaderText = "Employee Name"
        Me.dgvEmployeeIdNo.Name = "dgvEmployeeIdNo"
        Me.dgvEmployeeIdNo.ReadOnly = true
        Me.dgvEmployeeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmployeeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvEmployeeIdNo.Translatable = false
        Me.dgvEmployeeIdNo.Width = 175
        '
        'dgvFullDay
        '
        Me.dgvFullDay.BegFindValue = Nothing
        Me.dgvFullDay.DataPropertyName = "FullDay"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Orange
        DataGridViewCellStyle4.NullValue = false
        Me.dgvFullDay.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvFullDay.EditingMode = false
        Me.dgvFullDay.EndFindValue = Nothing
        Me.dgvFullDay.FieldDescription = Nothing
        Me.dgvFullDay.FieldName = Nothing
        Me.dgvFullDay.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvFullDay.FindEnabled = false
        Me.dgvFullDay.HeaderText = "Full Day"
        Me.dgvFullDay.IgnoreCase = false
        Me.dgvFullDay.Name = "dgvFullDay"
        Me.dgvFullDay.ReadOnly = true
        Me.dgvFullDay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFullDay.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvFullDay.Translatable = false
        Me.dgvFullDay.Width = 30
        '
        'dgvStartDate
        '
        Me.dgvStartDate.BegFindValue = Nothing
        Me.dgvStartDate.DataPropertyName = "StartDate"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvStartDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvStartDate.EditingMode = false
        Me.dgvStartDate.EndFindValue = Nothing
        Me.dgvStartDate.FieldDescription = Nothing
        Me.dgvStartDate.FieldName = Nothing
        Me.dgvStartDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvStartDate.FindEnabled = false
        Me.dgvStartDate.HeaderText = "Start Date"
        Me.dgvStartDate.IgnoreCase = false
        Me.dgvStartDate.Name = "dgvStartDate"
        Me.dgvStartDate.ReadOnly = true
        Me.dgvStartDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStartDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvStartDate.Translatable = false
        Me.dgvStartDate.Width = 70
        '
        'dgvEndDate
        '
        Me.dgvEndDate.BegFindValue = Nothing
        Me.dgvEndDate.DataPropertyName = "EndDate"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvEndDate.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEndDate.EditingMode = false
        Me.dgvEndDate.EndFindValue = Nothing
        Me.dgvEndDate.FieldDescription = Nothing
        Me.dgvEndDate.FieldName = Nothing
        Me.dgvEndDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvEndDate.FindEnabled = false
        Me.dgvEndDate.HeaderText = "End Date"
        Me.dgvEndDate.IgnoreCase = false
        Me.dgvEndDate.Name = "dgvEndDate"
        Me.dgvEndDate.ReadOnly = true
        Me.dgvEndDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEndDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvEndDate.Translatable = false
        Me.dgvEndDate.Width = 70
        '
        'dgvLeaveIdNo
        '
        Me.dgvLeaveIdNo.DataPropertyName = "LeaveIdNo"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.dgvLeaveIdNo.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvLeaveIdNo.EditingMode = false
        Me.dgvLeaveIdNo.HeaderText = "Leave Name"
        Me.dgvLeaveIdNo.Name = "dgvLeaveIdNo"
        Me.dgvLeaveIdNo.ReadOnly = true
        Me.dgvLeaveIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLeaveIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvLeaveIdNo.Translatable = false
        Me.dgvLeaveIdNo.Width = 150
        '
        'dgvLeaveReason
        '
        Me.dgvLeaveReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvLeaveReason.BegFindValue = Nothing
        Me.dgvLeaveReason.DataPropertyName = "LeaveReason"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.dgvLeaveReason.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvLeaveReason.EditingMode = false
        Me.dgvLeaveReason.EndFindValue = Nothing
        Me.dgvLeaveReason.FieldDescription = Nothing
        Me.dgvLeaveReason.FieldName = Nothing
        Me.dgvLeaveReason.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvLeaveReason.FindEnabled = false
        Me.dgvLeaveReason.HeaderText = "Leave Reason"
        Me.dgvLeaveReason.IgnoreCase = false
        Me.dgvLeaveReason.MinimumWidth = 120
        Me.dgvLeaveReason.Name = "dgvLeaveReason"
        Me.dgvLeaveReason.ReadOnly = true
        Me.dgvLeaveReason.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLeaveReason.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvLeaveReason.Translatable = false
        '
        'dgvLeaveStatus
        '
        Me.dgvLeaveStatus.DataPropertyName = "LeaveStatus"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.dgvLeaveStatus.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvLeaveStatus.EditingMode = false
        Me.dgvLeaveStatus.HeaderText = "Leave Status"
        Me.dgvLeaveStatus.Name = "dgvLeaveStatus"
        Me.dgvLeaveStatus.ReadOnly = true
        Me.dgvLeaveStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLeaveStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvLeaveStatus.Translatable = false
        '
        'enteredByDataGridViewTextBoxColumn
        '
        Me.enteredByDataGridViewTextBoxColumn.DataPropertyName = "EnteredBy"
        Me.enteredByDataGridViewTextBoxColumn.HeaderText = "EnteredBy"
        Me.enteredByDataGridViewTextBoxColumn.Name = "enteredByDataGridViewTextBoxColumn"
        Me.enteredByDataGridViewTextBoxColumn.ReadOnly = true
        Me.enteredByDataGridViewTextBoxColumn.Visible = false
        '
        'DateCreatedDataGridViewTextBoxColumn
        '
        Me.DateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated"
        Me.DateCreatedDataGridViewTextBoxColumn.HeaderText = "DateCreated"
        Me.DateCreatedDataGridViewTextBoxColumn.Name = "DateCreatedDataGridViewTextBoxColumn"
        Me.DateCreatedDataGridViewTextBoxColumn.ReadOnly = true
        Me.DateCreatedDataGridViewTextBoxColumn.Visible = false
        '
        'SupervisorIdNoDataGridViewTextBoxColumn
        '
        Me.SupervisorIdNoDataGridViewTextBoxColumn.DataPropertyName = "SupervisorIdNo"
        Me.SupervisorIdNoDataGridViewTextBoxColumn.HeaderText = "SupervisorIdNo"
        Me.SupervisorIdNoDataGridViewTextBoxColumn.Name = "SupervisorIdNoDataGridViewTextBoxColumn"
        Me.SupervisorIdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.SupervisorIdNoDataGridViewTextBoxColumn.Visible = false
        '
        'bsEmployeeLeave
        '
        Me.bsEmployeeLeave.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeeLeaveModel)
        '
        'EmployeeLeaveApprovalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(1073, 615)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "EmployeeLeaveApprovalEntry"
        Me.Text = "Employee Leave Approval"
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        CType(Me.DataGridViewEmployeeLeave,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsEmployeeLeave,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents bsEmployeeLeave As BindingSource
    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtIdNo As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblEnteredBy As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents DataGridViewEmployeeLeave As Libraries.CBaseControlsLibrary.CDataGridView
    Friend WithEvents cboApprovedBy As Libraries.CBaseControlsLibrary.CaComboBox
    Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents dtpDateCreated As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    Friend WithEvents dgvIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvEmployeeIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
    Friend WithEvents dgvFullDay As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    Friend WithEvents dgvStartDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvEndDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvLeaveIdNo As Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn
    Friend WithEvents dgvLeaveReason As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvLeaveStatus As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
    Friend WithEvents dgvApprove As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    Friend WithEvents dgvDisapprove As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    Friend WithEvents dgvApprovalNote As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents enteredByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateCreatedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SupervisorIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
