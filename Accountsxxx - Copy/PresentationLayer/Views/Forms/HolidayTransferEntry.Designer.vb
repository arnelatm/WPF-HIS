Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class HolidayTransferEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HolidayTransferEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateCreated = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblEnteredBy = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboHolidayIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblHolidayDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateStart = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpDateEnd = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboenteredBy = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.DataGridViewHolidayTransferitems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.HolidayTransferIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvTransfer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bsHolidayTransferItems = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        CType(Me.DataGridViewHolidayTransferitems,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsHolidayTransferItems,System.ComponentModel.ISupportInitialize).BeginInit
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
        Me.CFlowLayout1.Controls.Add(Me.CLabel1)
        Me.CFlowLayout1.Controls.Add(Me.dtpDateCreated)
        Me.CFlowLayout1.Controls.Add(Me.lblEnteredBy)
        Me.CFlowLayout1.Controls.Add(Me.cboHolidayIdNo)
        Me.CFlowLayout1.Controls.Add(Me.lblHolidayDate)
        Me.CFlowLayout1.Controls.Add(Me.dtpDateStart)
        Me.CFlowLayout1.Controls.Add(Me.CLabel3)
        Me.CFlowLayout1.Controls.Add(Me.dtpDateEnd)
        Me.CFlowLayout1.Controls.Add(Me.CLabel2)
        Me.CFlowLayout1.Controls.Add(Me.cboenteredBy)
        Me.CFlowLayout1.Controls.Add(Me.DataGridViewHolidayTransferitems)
        Me.CFlowLayout1.Location = New System.Drawing.Point(4, 70)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(577, 533)
        Me.CFlowLayout1.TabIndex = 5
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(131, 23)
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
        Me.txtIdNo.Location = New System.Drawing.Point(134, 1)
        Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIdNo.MaximumValue = Nothing
        Me.txtIdNo.MinimumValue = Nothing
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.OldValue = Nothing
        Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtIdNo.Size = New System.Drawing.Size(100, 23)
        Me.txtIdNo.TabIndex = 0
        Me.txtIdNo.Translatable = false
        '
        'CLabel1
        '
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(236, 1)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(136, 24)
        Me.CLabel1.TabIndex = 11
        Me.CLabel1.Text = "Date/Time Entry"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.CFlowLayout1.SetFlowBreak(Me.dtpDateCreated, true)
        Me.dtpDateCreated.ForeColor = System.Drawing.Color.Black
        Me.dtpDateCreated.LinkedLabel = Nothing
        Me.dtpDateCreated.Location = New System.Drawing.Point(374, 1)
        Me.dtpDateCreated.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpDateCreated.Name = "dtpDateCreated"
        Me.dtpDateCreated.ReadOnlyDp = false
        Me.dtpDateCreated.SecurityKey = Nothing
        Me.dtpDateCreated.ShowLongDate = false
        Me.dtpDateCreated.ShowTime = true
        Me.dtpDateCreated.Size = New System.Drawing.Size(191, 23)
        Me.dtpDateCreated.TabIndex = 1
        Me.dtpDateCreated.TargetCalendar = CType(resources.GetObject("dtpDateCreated.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpDateCreated.Translatable = false
        Me.dtpDateCreated.Value = Nothing
        Me.dtpDateCreated.ValueIsMandatory = false
        Me.dtpDateCreated.ValueIsNullable = false
        '
        'lblEnteredBy
        '
        Me.lblEnteredBy.DisplayOnly = true
        Me.lblEnteredBy.EditingMode = false
        Me.lblEnteredBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEnteredBy.Location = New System.Drawing.Point(1, 27)
        Me.lblEnteredBy.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEnteredBy.Name = "lblEnteredBy"
        Me.lblEnteredBy.Size = New System.Drawing.Size(131, 24)
        Me.lblEnteredBy.TabIndex = 8
        Me.lblEnteredBy.Text = "Holiday ID/Name"
        Me.lblEnteredBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEnteredBy.Translatable = true
        '
        'cboHolidayIdNo
        '
        Me.cboHolidayIdNo.BackColor = System.Drawing.Color.White
        Me.cboHolidayIdNo.BegFindValue = Nothing
        Me.cboHolidayIdNo.ChangingSearchValueOnly = false
        Me.cboHolidayIdNo.CurrentSearchTerm = ""
        Me.cboHolidayIdNo.DefaultValue = Nothing
        Me.cboHolidayIdNo.DisplayMember = "Name"
        Me.cboHolidayIdNo.EditingMode = true
        Me.cboHolidayIdNo.EndFindValue = Nothing
        Me.cboHolidayIdNo.FieldDescription = Nothing
        Me.cboHolidayIdNo.FieldName = Nothing
        Me.cboHolidayIdNo.FilterRule = Nothing
        Me.cboHolidayIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboHolidayIdNo.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.cboHolidayIdNo, true)
        Me.cboHolidayIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboHolidayIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboHolidayIdNo.FormattingEnabled = true
        Me.cboHolidayIdNo.HideWhenNotEditingOrAdding = false
        Me.cboHolidayIdNo.IgnoreCase = false
        Me.cboHolidayIdNo.IntegralHeight = false
        Me.cboHolidayIdNo.LinkedLabel = Nothing
        Me.cboHolidayIdNo.Location = New System.Drawing.Point(134, 27)
        Me.cboHolidayIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboHolidayIdNo.Name = "cboHolidayIdNo"
        Me.cboHolidayIdNo.OldValue = 0
        Me.cboHolidayIdNo.OriginalDataSource = Nothing
        Me.cboHolidayIdNo.OriginalList = Nothing
        Me.cboHolidayIdNo.OverrideDropDownStyleList = false
        Me.cboHolidayIdNo.PreviousSearchTerm = Nothing
        Me.cboHolidayIdNo.PropertySelector = Nothing
        Me.cboHolidayIdNo.ReadOnlyCombo = false
        Me.cboHolidayIdNo.Size = New System.Drawing.Size(431, 24)
        Me.cboHolidayIdNo.SuggestBoxHeight = 200
        Me.cboHolidayIdNo.SuggestListOrderRule = Nothing
        Me.cboHolidayIdNo.TabIndex = 2
        Me.cboHolidayIdNo.TextToSearch = Nothing
        Me.cboHolidayIdNo.Translatable = false
        Me.cboHolidayIdNo.ValueIsMandatory = false
        Me.cboHolidayIdNo.ValueIsNullable = false
        Me.cboHolidayIdNo.ValueIsNumeric = false
        Me.cboHolidayIdNo.ValueMember = "IdNo"
        '
        'lblHolidayDate
        '
        Me.lblHolidayDate.DisplayOnly = true
        Me.lblHolidayDate.EditingMode = false
        Me.lblHolidayDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblHolidayDate.Location = New System.Drawing.Point(1, 53)
        Me.lblHolidayDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblHolidayDate.Name = "lblHolidayDate"
        Me.lblHolidayDate.Size = New System.Drawing.Size(131, 24)
        Me.lblHolidayDate.TabIndex = 15
        Me.lblHolidayDate.Text = "Holiday Date"
        Me.lblHolidayDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblHolidayDate.Translatable = true
        '
        'dtpDateStart
        '
        Me.dtpDateStart.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateStart.DefaultValue = Nothing
        Me.dtpDateStart.DisplayOnly = false
        Me.dtpDateStart.DtpDefaultValue = Nothing
        Me.dtpDateStart.EditingMode = true
        Me.dtpDateStart.EditsAllowed = false
        Me.dtpDateStart.ForeColor = System.Drawing.Color.Black
        Me.dtpDateStart.LinkedLabel = Nothing
        Me.dtpDateStart.Location = New System.Drawing.Point(134, 53)
        Me.dtpDateStart.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.ReadOnlyDp = false
        Me.dtpDateStart.SecurityKey = Nothing
        Me.dtpDateStart.ShowLongDate = false
        Me.dtpDateStart.ShowTime = false
        Me.dtpDateStart.Size = New System.Drawing.Size(113, 23)
        Me.dtpDateStart.TabIndex = 3
        Me.dtpDateStart.TargetCalendar = CType(resources.GetObject("dtpDateStart.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpDateStart.Translatable = false
        Me.dtpDateStart.Value = Nothing
        Me.dtpDateStart.ValueIsMandatory = false
        Me.dtpDateStart.ValueIsNullable = false
        '
        'CLabel3
        '
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(249, 53)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(36, 24)
        Me.CLabel3.TabIndex = 17
        Me.CLabel3.Text = " to "
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLabel3.Translatable = true
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpDateEnd.DefaultValue = Nothing
        Me.dtpDateEnd.DisplayOnly = false
        Me.dtpDateEnd.DtpDefaultValue = Nothing
        Me.dtpDateEnd.EditingMode = true
        Me.dtpDateEnd.EditsAllowed = false
        Me.CFlowLayout1.SetFlowBreak(Me.dtpDateEnd, true)
        Me.dtpDateEnd.ForeColor = System.Drawing.Color.Black
        Me.dtpDateEnd.LinkedLabel = Nothing
        Me.dtpDateEnd.Location = New System.Drawing.Point(287, 53)
        Me.dtpDateEnd.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.ReadOnlyDp = false
        Me.dtpDateEnd.SecurityKey = Nothing
        Me.dtpDateEnd.ShowLongDate = false
        Me.dtpDateEnd.ShowTime = false
        Me.dtpDateEnd.Size = New System.Drawing.Size(113, 23)
        Me.dtpDateEnd.TabIndex = 16
        Me.dtpDateEnd.TargetCalendar = CType(resources.GetObject("dtpDateEnd.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpDateEnd.Translatable = false
        Me.dtpDateEnd.Value = Nothing
        Me.dtpDateEnd.ValueIsMandatory = false
        Me.dtpDateEnd.ValueIsNullable = false
        '
        'CLabel2
        '
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(1, 79)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(131, 24)
        Me.CLabel2.TabIndex = 13
        Me.CLabel2.Text = "Entered By:"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = true
        '
        'cboenteredBy
        '
        Me.cboenteredBy.BackColor = System.Drawing.Color.White
        Me.cboenteredBy.BegFindValue = Nothing
        Me.cboenteredBy.ChangingSearchValueOnly = false
        Me.cboenteredBy.CurrentSearchTerm = ""
        Me.cboenteredBy.DefaultValue = Nothing
        Me.cboenteredBy.DisplayMember = "Name"
        Me.cboenteredBy.EditingMode = true
        Me.cboenteredBy.EndFindValue = Nothing
        Me.cboenteredBy.FieldDescription = Nothing
        Me.cboenteredBy.FieldName = Nothing
        Me.cboenteredBy.FilterRule = Nothing
        Me.cboenteredBy.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboenteredBy.FindEnabled = false
        Me.CFlowLayout1.SetFlowBreak(Me.cboenteredBy, true)
        Me.cboenteredBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboenteredBy.ForeColor = System.Drawing.Color.Black
        Me.cboenteredBy.FormattingEnabled = true
        Me.cboenteredBy.HideWhenNotEditingOrAdding = false
        Me.cboenteredBy.IgnoreCase = false
        Me.cboenteredBy.IntegralHeight = false
        Me.cboenteredBy.LinkedLabel = Nothing
        Me.cboenteredBy.Location = New System.Drawing.Point(134, 79)
        Me.cboenteredBy.Margin = New System.Windows.Forms.Padding(1)
        Me.cboenteredBy.Name = "cboenteredBy"
        Me.cboenteredBy.OldValue = 0
        Me.cboenteredBy.OriginalDataSource = Nothing
        Me.cboenteredBy.OriginalList = Nothing
        Me.cboenteredBy.OverrideDropDownStyleList = false
        Me.cboenteredBy.PreviousSearchTerm = Nothing
        Me.cboenteredBy.PropertySelector = Nothing
        Me.cboenteredBy.ReadOnlyCombo = false
        Me.cboenteredBy.Size = New System.Drawing.Size(431, 24)
        Me.cboenteredBy.SuggestBoxHeight = 200
        Me.cboenteredBy.SuggestListOrderRule = Nothing
        Me.cboenteredBy.TabIndex = 4
        Me.cboenteredBy.TextToSearch = Nothing
        Me.cboenteredBy.Translatable = false
        Me.cboenteredBy.ValueIsMandatory = false
        Me.cboenteredBy.ValueIsNullable = false
        Me.cboenteredBy.ValueIsNumeric = false
        Me.cboenteredBy.ValueMember = "IdNo"
        '
        'DataGridViewHolidayTransferitems
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewHolidayTransferitems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewHolidayTransferitems.AutoGenerateColumns = false
        Me.DataGridViewHolidayTransferitems.BegFindValue = Nothing
        Me.DataGridViewHolidayTransferitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewHolidayTransferitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvEmployeeIdNo, Me.HolidayTransferIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.dgvTransfer})
        Me.DataGridViewHolidayTransferitems.DataSource = Me.bsHolidayTransferItems
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewHolidayTransferitems.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewHolidayTransferitems.DgvFooter = Nothing
        Me.DataGridViewHolidayTransferitems.DisplayOnly = false
        Me.DataGridViewHolidayTransferitems.Ea = Nothing
        Me.DataGridViewHolidayTransferitems.EditingMode = false
        Me.DataGridViewHolidayTransferitems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewHolidayTransferitems.EndFindValue = Nothing
        Me.DataGridViewHolidayTransferitems.FieldDescription = Nothing
        Me.DataGridViewHolidayTransferitems.FieldName = Nothing
        Me.DataGridViewHolidayTransferitems.FieldsDictionary = Nothing
        Me.DataGridViewHolidayTransferitems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewHolidayTransferitems.FindEnabled = false
        Me.DataGridViewHolidayTransferitems.FirstRowDeletionEnabled = true
        Me.DataGridViewHolidayTransferitems.FirstRowInsertionEnabled = true
        Me.DataGridViewHolidayTransferitems.IgnoreCase = false
        Me.DataGridViewHolidayTransferitems.IsDirty = false
        Me.DataGridViewHolidayTransferitems.Location = New System.Drawing.Point(3, 107)
        Me.DataGridViewHolidayTransferitems.Name = "DataGridViewHolidayTransferitems"
        Me.DataGridViewHolidayTransferitems.ReadOnly = true
        Me.DataGridViewHolidayTransferitems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewHolidayTransferitems.SecurityKey = ""
        Me.DataGridViewHolidayTransferitems.SequenceColumn = ""
        Me.DataGridViewHolidayTransferitems.SequenceFieldName = ""
        Me.DataGridViewHolidayTransferitems.ShowFooter = false
        Me.DataGridViewHolidayTransferitems.ShowInsertColumnWhenEditing = true
        Me.DataGridViewHolidayTransferitems.Size = New System.Drawing.Size(562, 452)
        Me.DataGridViewHolidayTransferitems.TabIndex = 5
        Me.DataGridViewHolidayTransferitems.Translatable = true
        '
        'dgvEmployeeIdNo
        '
        Me.dgvEmployeeIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvEmployeeIdNo.DataPropertyName = "EmployeeIdNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvEmployeeIdNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEmployeeIdNo.EditingMode = false
        Me.dgvEmployeeIdNo.HeaderText = "EmployeeIdNo"
        Me.dgvEmployeeIdNo.Name = "dgvEmployeeIdNo"
        Me.dgvEmployeeIdNo.ReadOnly = true
        Me.dgvEmployeeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmployeeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvEmployeeIdNo.Translatable = false
        '
        'HolidayTransferIdNoDataGridViewTextBoxColumn
        '
        Me.HolidayTransferIdNoDataGridViewTextBoxColumn.DataPropertyName = "HolidayTransferIdNo"
        Me.HolidayTransferIdNoDataGridViewTextBoxColumn.HeaderText = "HolidayTransferIdNo"
        Me.HolidayTransferIdNoDataGridViewTextBoxColumn.Name = "HolidayTransferIdNoDataGridViewTextBoxColumn"
        Me.HolidayTransferIdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.HolidayTransferIdNoDataGridViewTextBoxColumn.Visible = false
        '
        'IdNoDataGridViewTextBoxColumn
        '
        Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
        Me.IdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.IdNoDataGridViewTextBoxColumn.Visible = false
        '
        'dgvTransfer
        '
        Me.dgvTransfer.DataPropertyName = "Transfer"
        Me.dgvTransfer.HeaderText = "Transfer"
        Me.dgvTransfer.Name = "dgvTransfer"
        Me.dgvTransfer.ReadOnly = true
        Me.dgvTransfer.Width = 60
        '
        'bsHolidayTransferItems
        '
        Me.bsHolidayTransferItems.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.HolidayTransferItemModel)
        '
        'HolidayTransferEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(581, 615)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "HolidayTransferEntry"
        Me.Text = "Bulk Employee Holiday Transfer"
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        CType(Me.DataGridViewHolidayTransferitems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsHolidayTransferItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsHolidayTransferItems As BindingSource
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblEnteredBy As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents DataGridViewHolidayTransferitems As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents cboenteredBy As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpDateCreated As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboHolidayIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents dgvEmployeeIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents HolidayTransferIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvTransfer As DataGridViewCheckBoxColumn
        Friend WithEvents lblHolidayDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpDateStart As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpDateEnd As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
    End Class
End Namespace