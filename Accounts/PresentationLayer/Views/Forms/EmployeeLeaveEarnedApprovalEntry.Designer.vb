<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeLeaveEarnedApprovalEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeLeaveEarnedApprovalEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEnteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboApprovedBy = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateCreated = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.DataGridViewEmployeeLeave = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
        Me.dgvEmployeeLeaveEarnedIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.DaysEarned = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvDateCreated = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvStartDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvEndDate = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvLeaveIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvReason = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvApproved = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvDisapproved = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvApprovalNote = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.enteredByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupervisorIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.bsEmployeeLeaveEarnedApprovalItem = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CFlowLayout1.SuspendLayout()
        CType(Me.DataGridViewEmployeeLeave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsEmployeeLeaveEarnedApprovalItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.CFlowLayout1.Location = New System.Drawing.Point(5, 86)
        Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(1307, 667)
        Me.CFlowLayout1.TabIndex = 5
        '
        'lblIdNo
        '
        Me.lblIdNo.AutoSize = True
        Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
        Me.lblIdNo.DisplayOnly = True
        Me.lblIdNo.EditingMode = False
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(56, 20)
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
        Me.txtIdNo.Location = New System.Drawing.Point(59, 1)
        Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIdNo.MaximumValue = Nothing
        Me.txtIdNo.MinimumValue = Nothing
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.OldValue = ""
        Me.txtIdNo.OverrideMaxLength = 0
        Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtIdNo.Size = New System.Drawing.Size(133, 23)
        Me.txtIdNo.TabIndex = 0
        Me.txtIdNo.Translatable = False
        '
        'lblEnteredBy
        '
        Me.lblEnteredBy.BackColor = System.Drawing.Color.Transparent
        Me.lblEnteredBy.DisplayOnly = True
        Me.lblEnteredBy.EditingMode = False
        Me.lblEnteredBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblEnteredBy.Location = New System.Drawing.Point(185, 1)
        Me.lblEnteredBy.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEnteredBy.Name = "lblEnteredBy"
        Me.lblEnteredBy.Size = New System.Drawing.Size(180, 30)
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
        Me.cboApprovedBy.DisplayOnly = True
        Me.cboApprovedBy.DropDownHeight = 24
        Me.cboApprovedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboApprovedBy.Editable = True
        Me.cboApprovedBy.EditingMode = False
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
        Me.cboApprovedBy.Location = New System.Drawing.Point(367, 1)
        Me.cboApprovedBy.Margin = New System.Windows.Forms.Padding(1)
        Me.cboApprovedBy.MaxDropDownItems = 1
        Me.cboApprovedBy.Name = "cboApprovedBy"
        Me.cboApprovedBy.OldValue = 0
        Me.cboApprovedBy.OriginalDataSource = Nothing
        Me.cboApprovedBy.OriginalList = Nothing
        Me.cboApprovedBy.OverrideDropDownStyleList = False
        Me.cboApprovedBy.PreviousSearchTerm = Nothing
        Me.cboApprovedBy.PropertySelector = Nothing
        Me.cboApprovedBy.Size = New System.Drawing.Size(339, 29)
        Me.cboApprovedBy.SuggestBoxHeight = 200
        Me.cboApprovedBy.SuggestCharCount = 0
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
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = True
        Me.CLabel1.EditingMode = False
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel1.Location = New System.Drawing.Point(708, 1)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(267, 30)
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
        Me.dtpDateCreated.Location = New System.Drawing.Point(977, 1)
        Me.dtpDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpDateCreated.Name = "dtpDateCreated"
        Me.dtpDateCreated.ReadOnlyDp = False
        Me.dtpDateCreated.SecurityKey = Nothing
        Me.dtpDateCreated.ShowLongDate = False
        Me.dtpDateCreated.ShowTime = True
        Me.dtpDateCreated.Size = New System.Drawing.Size(196, 23)
        Me.dtpDateCreated.TabIndex = 2
        Me.dtpDateCreated.TargetCalendar = CType(resources.GetObject("dtpDateCreated.TargetCalendar"), System.Globalization.Calendar)
        Me.dtpDateCreated.Translatable = False
        Me.dtpDateCreated.Value = Nothing
        Me.dtpDateCreated.ValueIsMandatory = False
        Me.dtpDateCreated.ValueIsNullable = False
        '
        'DataGridViewEmployeeLeave
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewEmployeeLeave.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewEmployeeLeave.AutoGenerateColumns = False
        Me.DataGridViewEmployeeLeave.BegFindValue = Nothing
        Me.DataGridViewEmployeeLeave.Cached = False
        Me.DataGridViewEmployeeLeave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewEmployeeLeave.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvEmployeeLeaveEarnedIdNo, Me.DaysEarned, Me.dgvDateCreated, Me.dgvEmployeeIdNo, Me.dgvStartDate, Me.dgvEndDate, Me.dgvLeaveIdNo, Me.dgvReason, Me.dgvApproved, Me.dgvDisapproved, Me.dgvApprovalNote, Me.enteredByDataGridViewTextBoxColumn, Me.SupervisorIdNoDataGridViewTextBoxColumn, Me.dgvIdNo})
        Me.DataGridViewEmployeeLeave.DataFilter = Nothing
        Me.DataGridViewEmployeeLeave.DataSource = Me.bsEmployeeLeaveEarnedApprovalItem
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewEmployeeLeave.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewEmployeeLeave.DgvFooter = Nothing
        Me.DataGridViewEmployeeLeave.DisplayOnly = False
        Me.DataGridViewEmployeeLeave.Ea = Nothing
        Me.DataGridViewEmployeeLeave.EditingMode = False
        Me.DataGridViewEmployeeLeave.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewEmployeeLeave.EndFindValue = Nothing
        Me.DataGridViewEmployeeLeave.FieldDescription = Nothing
        Me.DataGridViewEmployeeLeave.FieldName = Nothing
        Me.DataGridViewEmployeeLeave.FieldsDictionary = Nothing
        Me.DataGridViewEmployeeLeave.FindColumnNo = CType(0, Short)
        Me.DataGridViewEmployeeLeave.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewEmployeeLeave.FindEnabled = False
        Me.DataGridViewEmployeeLeave.FirstRowDeletionEnabled = True
        Me.DataGridViewEmployeeLeave.FirstRowInsertionEnabled = True
        Me.DataGridViewEmployeeLeave.IgnoreCase = False
        Me.DataGridViewEmployeeLeave.IsDirty = False
        Me.DataGridViewEmployeeLeave.Location = New System.Drawing.Point(4, 36)
        Me.DataGridViewEmployeeLeave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridViewEmployeeLeave.Name = "DataGridViewEmployeeLeave"
        Me.DataGridViewEmployeeLeave.OldCellValue = Nothing
        Me.DataGridViewEmployeeLeave.ReadOnly = True
        Me.DataGridViewEmployeeLeave.RowHeadersWidth = 51
        Me.DataGridViewEmployeeLeave.Searchable = True
        Me.DataGridViewEmployeeLeave.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewEmployeeLeave.SecurityKey = ""
        Me.DataGridViewEmployeeLeave.SequenceColumn = "dgvSequence"
        Me.DataGridViewEmployeeLeave.SequenceFieldName = "Sequence"
        Me.DataGridViewEmployeeLeave.ShowFooter = False
        Me.DataGridViewEmployeeLeave.Size = New System.Drawing.Size(1287, 593)
        Me.DataGridViewEmployeeLeave.TabIndex = 3
        Me.DataGridViewEmployeeLeave.Translatable = True
        '
        'dgvEmployeeLeaveEarnedIdNo
        '
        Me.dgvEmployeeLeaveEarnedIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvEmployeeLeaveEarnedIdNo.BegFindValue = Nothing
        Me.dgvEmployeeLeaveEarnedIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvEmployeeLeaveEarnedIdNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEmployeeLeaveEarnedIdNo.EditingMode = False
        Me.dgvEmployeeLeaveEarnedIdNo.EndFindValue = Nothing
        Me.dgvEmployeeLeaveEarnedIdNo.FieldDescription = Nothing
        Me.dgvEmployeeLeaveEarnedIdNo.FieldName = Nothing
        Me.dgvEmployeeLeaveEarnedIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvEmployeeLeaveEarnedIdNo.FindEnabled = False
        Me.dgvEmployeeLeaveEarnedIdNo.HeaderText = "Id No."
        Me.dgvEmployeeLeaveEarnedIdNo.IgnoreCase = False
        Me.dgvEmployeeLeaveEarnedIdNo.MinimumWidth = 6
        Me.dgvEmployeeLeaveEarnedIdNo.Name = "dgvEmployeeLeaveEarnedIdNo"
        Me.dgvEmployeeLeaveEarnedIdNo.ReadOnly = True
        Me.dgvEmployeeLeaveEarnedIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmployeeLeaveEarnedIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvEmployeeLeaveEarnedIdNo.Translatable = False
        Me.dgvEmployeeLeaveEarnedIdNo.Width = 35
        '
        'DaysEarned
        '
        Me.DaysEarned.BegFindValue = Nothing
        Me.DaysEarned.DataPropertyName = "DaysEarned"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.DaysEarned.DefaultCellStyle = DataGridViewCellStyle3
        Me.DaysEarned.EditingMode = False
        Me.DaysEarned.EndFindValue = Nothing
        Me.DaysEarned.FieldDescription = Nothing
        Me.DaysEarned.FieldName = Nothing
        Me.DaysEarned.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DaysEarned.FindEnabled = False
        Me.DaysEarned.HeaderText = "Days Earned"
        Me.DaysEarned.IgnoreCase = False
        Me.DaysEarned.MinimumWidth = 6
        Me.DaysEarned.Name = "DaysEarned"
        Me.DaysEarned.ReadOnly = True
        Me.DaysEarned.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DaysEarned.Translatable = False
        Me.DaysEarned.Width = 50
        '
        'dgvDateCreated
        '
        Me.dgvDateCreated.BegFindValue = Nothing
        Me.dgvDateCreated.DataPropertyName = "DateCreated"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvDateCreated.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDateCreated.EditingMode = False
        Me.dgvDateCreated.EndFindValue = Nothing
        Me.dgvDateCreated.FieldDescription = Nothing
        Me.dgvDateCreated.FieldName = Nothing
        Me.dgvDateCreated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDateCreated.FindEnabled = False
        Me.dgvDateCreated.HeaderText = "Date Added"
        Me.dgvDateCreated.IgnoreCase = False
        Me.dgvDateCreated.MinimumWidth = 6
        Me.dgvDateCreated.Name = "dgvDateCreated"
        Me.dgvDateCreated.ReadOnly = True
        Me.dgvDateCreated.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDateCreated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDateCreated.Translatable = False
        Me.dgvDateCreated.Width = 80
        '
        'dgvEmployeeIdNo
        '
        Me.dgvEmployeeIdNo.AutoComplete = False
        Me.dgvEmployeeIdNo.DataPropertyName = "EmployeeIdNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvEmployeeIdNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEmployeeIdNo.DisplayStyleForCurrentCellOnly = True
        Me.dgvEmployeeIdNo.EditingMode = False
        Me.dgvEmployeeIdNo.HeaderText = "Employee Name"
        Me.dgvEmployeeIdNo.MinimumWidth = 6
        Me.dgvEmployeeIdNo.Name = "dgvEmployeeIdNo"
        Me.dgvEmployeeIdNo.ReadOnly = True
        Me.dgvEmployeeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmployeeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvEmployeeIdNo.SuggestCharCount = 0
        Me.dgvEmployeeIdNo.Translatable = False
        Me.dgvEmployeeIdNo.Width = 175
        '
        'dgvStartDate
        '
        Me.dgvStartDate.BegFindValue = Nothing
        Me.dgvStartDate.DataPropertyName = "StartDate"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvStartDate.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvStartDate.EditingMode = False
        Me.dgvStartDate.EndFindValue = Nothing
        Me.dgvStartDate.FieldDescription = Nothing
        Me.dgvStartDate.FieldName = Nothing
        Me.dgvStartDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvStartDate.FindEnabled = False
        Me.dgvStartDate.HeaderText = "Start Date"
        Me.dgvStartDate.IgnoreCase = False
        Me.dgvStartDate.MinimumWidth = 6
        Me.dgvStartDate.Name = "dgvStartDate"
        Me.dgvStartDate.ReadOnly = True
        Me.dgvStartDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStartDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvStartDate.Translatable = False
        Me.dgvStartDate.Width = 70
        '
        'dgvEndDate
        '
        Me.dgvEndDate.BegFindValue = Nothing
        Me.dgvEndDate.DataPropertyName = "EndDate"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.dgvEndDate.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvEndDate.EditingMode = False
        Me.dgvEndDate.EndFindValue = Nothing
        Me.dgvEndDate.FieldDescription = Nothing
        Me.dgvEndDate.FieldName = Nothing
        Me.dgvEndDate.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvEndDate.FindEnabled = False
        Me.dgvEndDate.HeaderText = "End Date"
        Me.dgvEndDate.IgnoreCase = False
        Me.dgvEndDate.MinimumWidth = 6
        Me.dgvEndDate.Name = "dgvEndDate"
        Me.dgvEndDate.ReadOnly = True
        Me.dgvEndDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEndDate.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvEndDate.Translatable = False
        Me.dgvEndDate.Width = 70
        '
        'dgvLeaveIdNo
        '
        Me.dgvLeaveIdNo.AutoComplete = False
        Me.dgvLeaveIdNo.DataPropertyName = "LeaveIdNo"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.dgvLeaveIdNo.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvLeaveIdNo.DisplayStyleForCurrentCellOnly = True
        Me.dgvLeaveIdNo.EditingMode = False
        Me.dgvLeaveIdNo.HeaderText = "Leave Name"
        Me.dgvLeaveIdNo.MinimumWidth = 6
        Me.dgvLeaveIdNo.Name = "dgvLeaveIdNo"
        Me.dgvLeaveIdNo.ReadOnly = True
        Me.dgvLeaveIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLeaveIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvLeaveIdNo.SuggestCharCount = 0
        Me.dgvLeaveIdNo.Translatable = False
        Me.dgvLeaveIdNo.Width = 120
        '
        'dgvReason
        '
        Me.dgvReason.BegFindValue = Nothing
        Me.dgvReason.DataPropertyName = "Reason"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.dgvReason.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvReason.EditingMode = False
        Me.dgvReason.EndFindValue = Nothing
        Me.dgvReason.FieldDescription = Nothing
        Me.dgvReason.FieldName = Nothing
        Me.dgvReason.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvReason.FindEnabled = False
        Me.dgvReason.HeaderText = "Reason"
        Me.dgvReason.IgnoreCase = False
        Me.dgvReason.MinimumWidth = 6
        Me.dgvReason.Name = "dgvReason"
        Me.dgvReason.ReadOnly = True
        Me.dgvReason.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvReason.Translatable = False
        Me.dgvReason.Width = 125
        '
        'dgvApproved
        '
        Me.dgvApproved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvApproved.BegFindValue = Nothing
        Me.dgvApproved.DataPropertyName = "Approved"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.NullValue = False
        Me.dgvApproved.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvApproved.EditingMode = False
        Me.dgvApproved.EndFindValue = Nothing
        Me.dgvApproved.FieldDescription = Nothing
        Me.dgvApproved.FieldName = Nothing
        Me.dgvApproved.FillWeight = 5.0!
        Me.dgvApproved.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvApproved.FindEnabled = False
        Me.dgvApproved.HeaderText = "Approved"
        Me.dgvApproved.IgnoreCase = False
        Me.dgvApproved.MinimumWidth = 6
        Me.dgvApproved.Name = "dgvApproved"
        Me.dgvApproved.ReadOnly = True
        Me.dgvApproved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvApproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvApproved.Translatable = False
        Me.dgvApproved.Width = 73
        '
        'dgvDisapproved
        '
        Me.dgvDisapproved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvDisapproved.BegFindValue = Nothing
        Me.dgvDisapproved.DataPropertyName = "Disapproved"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.NullValue = False
        Me.dgvDisapproved.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDisapproved.EditingMode = False
        Me.dgvDisapproved.EndFindValue = Nothing
        Me.dgvDisapproved.FieldDescription = Nothing
        Me.dgvDisapproved.FieldName = Nothing
        Me.dgvDisapproved.FillWeight = 5.0!
        Me.dgvDisapproved.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDisapproved.FindEnabled = False
        Me.dgvDisapproved.HeaderText = "Disap -proved"
        Me.dgvDisapproved.IgnoreCase = False
        Me.dgvDisapproved.MinimumWidth = 6
        Me.dgvDisapproved.Name = "dgvDisapproved"
        Me.dgvDisapproved.ReadOnly = True
        Me.dgvDisapproved.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDisapproved.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDisapproved.Translatable = False
        Me.dgvDisapproved.Width = 89
        '
        'dgvApprovalNote
        '
        Me.dgvApprovalNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvApprovalNote.BegFindValue = Nothing
        Me.dgvApprovalNote.DataPropertyName = "ApprovalNote"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.dgvApprovalNote.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvApprovalNote.EditingMode = False
        Me.dgvApprovalNote.EndFindValue = Nothing
        Me.dgvApprovalNote.FieldDescription = Nothing
        Me.dgvApprovalNote.FieldName = Nothing
        Me.dgvApprovalNote.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvApprovalNote.FindEnabled = False
        Me.dgvApprovalNote.HeaderText = "Approval / Disapproval Note"
        Me.dgvApprovalNote.IgnoreCase = False
        Me.dgvApprovalNote.MinimumWidth = 6
        Me.dgvApprovalNote.Name = "dgvApprovalNote"
        Me.dgvApprovalNote.ReadOnly = True
        Me.dgvApprovalNote.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApprovalNote.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvApprovalNote.Translatable = False
        '
        'enteredByDataGridViewTextBoxColumn
        '
        Me.enteredByDataGridViewTextBoxColumn.DataPropertyName = "EnteredBy"
        Me.enteredByDataGridViewTextBoxColumn.HeaderText = "EnteredBy"
        Me.enteredByDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.enteredByDataGridViewTextBoxColumn.Name = "enteredByDataGridViewTextBoxColumn"
        Me.enteredByDataGridViewTextBoxColumn.ReadOnly = True
        Me.enteredByDataGridViewTextBoxColumn.Visible = False
        Me.enteredByDataGridViewTextBoxColumn.Width = 125
        '
        'SupervisorIdNoDataGridViewTextBoxColumn
        '
        Me.SupervisorIdNoDataGridViewTextBoxColumn.DataPropertyName = "SupervisorIdNo"
        Me.SupervisorIdNoDataGridViewTextBoxColumn.HeaderText = "SupervisorIdNo"
        Me.SupervisorIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.SupervisorIdNoDataGridViewTextBoxColumn.Name = "SupervisorIdNoDataGridViewTextBoxColumn"
        Me.SupervisorIdNoDataGridViewTextBoxColumn.ReadOnly = True
        Me.SupervisorIdNoDataGridViewTextBoxColumn.Visible = False
        Me.SupervisorIdNoDataGridViewTextBoxColumn.Width = 125
        '
        'dgvIdNo
        '
        Me.dgvIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.dgvIdNo.BegFindValue = Nothing
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvIdNo.DisplayOnly = True
        Me.dgvIdNo.EditingMode = False
        Me.dgvIdNo.EndFindValue = Nothing
        Me.dgvIdNo.FieldDescription = Nothing
        Me.dgvIdNo.FieldName = Nothing
        Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvIdNo.FindEnabled = False
        Me.dgvIdNo.HeaderText = "Leave ID No."
        Me.dgvIdNo.IgnoreCase = False
        Me.dgvIdNo.MinimumWidth = 6
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = True
        Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvIdNo.Translatable = False
        Me.dgvIdNo.Visible = False
        Me.dgvIdNo.Width = 40
        '
        'bsEmployeeLeaveEarnedApprovalItem
        '
        Me.bsEmployeeLeaveEarnedApprovalItem.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.EmployeeLeaveEarnedApprovalItemModel)
        '
        'EmployeeLeaveEarnedApprovalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(1312, 757)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "EmployeeLeaveEarnedApprovalEntry"
        Me.Text = "Employee Leave Earned Approval"
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CFlowLayout1.ResumeLayout(False)
        Me.CFlowLayout1.PerformLayout()
        CType(Me.DataGridViewEmployeeLeave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsEmployeeLeaveEarnedApprovalItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bsEmployeeLeaveEarnedApprovalItem As BindingSource
    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtIdNo As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents lblEnteredBy As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents cboApprovedBy As Libraries.CBaseControlsLibrary.CtComboBox
    Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents dtpDateCreated As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    Friend WithEvents DataGridViewEmployeeLeave As Libraries.CBaseControlsLibrary.CtDataGridView
    Friend WithEvents dgvEmployeeLeaveEarnedIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents DaysEarned As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvDateCreated As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvEmployeeIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
    Friend WithEvents dgvStartDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvEndDate As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvLeaveIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
    Friend WithEvents dgvReason As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents dgvApproved As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    Friend WithEvents dgvDisapproved As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    Friend WithEvents dgvApprovalNote As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents enteredByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SupervisorIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents dgvIdNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
End Class
