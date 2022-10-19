Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PmrInvestigationRequestForm

        Inherits AATM.PresentationLayer.Forms.CFormBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PmrInvestigationRequestForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.DataGridViewPmrPatientDisplay = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvFileType = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvTransKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.cboDoctorName = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TokenDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.StatusDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.FileNoDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.NameDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.InvTypeDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.bsPmrPatientDisplay = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewPmrPatientDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPmrPatientDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnRefresh
            '
            Me.btnRefresh.DesignerSelected = False
            Me.btnRefresh.ImageIndex = 0
            Me.btnRefresh.Location = New System.Drawing.Point(687, 3)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.OriginalImageName = Nothing
            Me.btnRefresh.SecurityKey = ""
            Me.btnRefresh.Size = New System.Drawing.Size(90, 25)
            Me.btnRefresh.TabIndex = 11
            Me.btnRefresh.Text = "Refresh"
            '
            'imgList
            '
            Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imgList.TransparentColor = System.Drawing.Color.Transparent
            Me.imgList.Images.SetKeyName(0, "btnPrint.png")
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 53)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(790, 500)
            Me.CFlowLayout2.TabIndex = 5
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPmrPatientDisplay, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.btnRefresh, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpTransactionDate, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboDoctorName, 1, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(783, 493)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'DataGridViewPmrPatientDisplay
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPmrPatientDisplay.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPmrPatientDisplay.AutoGenerateColumns = False
            Me.DataGridViewPmrPatientDisplay.BegFindValue = Nothing
            Me.DataGridViewPmrPatientDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPmrPatientDisplay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TokenDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.FileNoDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.dgvFileType, Me.InvTypeDataGridViewTextBoxColumn, Me.dgvTime, Me.dgvTransKey})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPmrPatientDisplay, 4)
            Me.DataGridViewPmrPatientDisplay.DataSource = Me.bsPmrPatientDisplay
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPmrPatientDisplay.DefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewPmrPatientDisplay.DgvFooter = Nothing
            Me.DataGridViewPmrPatientDisplay.DisplayOnly = True
            Me.DataGridViewPmrPatientDisplay.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPmrPatientDisplay.Ea = Nothing
            Me.DataGridViewPmrPatientDisplay.EditingMode = False
            Me.DataGridViewPmrPatientDisplay.EndFindValue = Nothing
            Me.DataGridViewPmrPatientDisplay.FieldDescription = Nothing
            Me.DataGridViewPmrPatientDisplay.FieldName = Nothing
            Me.DataGridViewPmrPatientDisplay.FieldsDictionary = Nothing
            Me.DataGridViewPmrPatientDisplay.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPmrPatientDisplay.FindEnabled = False
            Me.DataGridViewPmrPatientDisplay.FirstRowDeletionEnabled = True
            Me.DataGridViewPmrPatientDisplay.FirstRowInsertionEnabled = True
            Me.DataGridViewPmrPatientDisplay.IgnoreCase = False
            Me.DataGridViewPmrPatientDisplay.IsDirty = False
            Me.DataGridViewPmrPatientDisplay.Location = New System.Drawing.Point(3, 59)
            Me.DataGridViewPmrPatientDisplay.Name = "DataGridViewPmrPatientDisplay"
            Me.DataGridViewPmrPatientDisplay.ReadOnly = True
            Me.DataGridViewPmrPatientDisplay.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPmrPatientDisplay.SecurityKey = ""
            Me.DataGridViewPmrPatientDisplay.SequenceColumn = "dgvSequence"
            Me.DataGridViewPmrPatientDisplay.SequenceFieldName = "Sequence"
            Me.DataGridViewPmrPatientDisplay.ShowFooter = False
            Me.DataGridViewPmrPatientDisplay.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPmrPatientDisplay.Size = New System.Drawing.Size(777, 431)
            Me.DataGridViewPmrPatientDisplay.TabIndex = 11
            Me.DataGridViewPmrPatientDisplay.Translatable = True
            '
            'dgvFileType
            '
            Me.dgvFileType.BegFindValue = Nothing
            Me.dgvFileType.DataPropertyName = "InvType"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvFileType.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvFileType.EditingMode = False
            Me.dgvFileType.EndFindValue = Nothing
            Me.dgvFileType.FieldDescription = Nothing
            Me.dgvFileType.FieldName = Nothing
            Me.dgvFileType.FillWeight = 60.0!
            Me.dgvFileType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvFileType.FindEnabled = False
            Me.dgvFileType.HeaderText = "Patient Type"
            Me.dgvFileType.IgnoreCase = False
            Me.dgvFileType.Name = "dgvFileType"
            Me.dgvFileType.ReadOnly = True
            Me.dgvFileType.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvFileType.Translatable = False
            Me.dgvFileType.Width = 60
            '
            'dgvTime
            '
            Me.dgvTime.DataPropertyName = "InvTime"
            DataGridViewCellStyle8.Format = "hh:mm tt"
            DataGridViewCellStyle8.NullValue = Nothing
            Me.dgvTime.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvTime.HeaderText = "Time"
            Me.dgvTime.Name = "dgvTime"
            Me.dgvTime.ReadOnly = True
            '
            'dgvTransKey
            '
            Me.dgvTransKey.DataPropertyName = "TransKey"
            Me.dgvTransKey.HeaderText = "TransKey"
            Me.dgvTransKey.Name = "dgvTransKey"
            Me.dgvTransKey.ReadOnly = True
            Me.dgvTransKey.Visible = False
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 32)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(156, 23)
            Me.CLabel1.TabIndex = 13
            Me.CLabel1.Text = "Transaction Date:"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(171, 23)
            Me.CLabel2.TabIndex = 14
            Me.CLabel2.Text = "Doctors Code - Name:"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'dtpTransactionDate
            '
            Me.dtpTransactionDate.AutoSize = True
            Me.dtpTransactionDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpTransactionDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.TableLayoutPanel1.SetColumnSpan(Me.dtpTransactionDate, 2)
            Me.dtpTransactionDate.DefaultValue = Nothing
            Me.dtpTransactionDate.DisplayOnly = False
            Me.dtpTransactionDate.DtpDefaultValue = Nothing
            Me.dtpTransactionDate.EditingMode = True
            Me.dtpTransactionDate.EditsAllowed = False
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Location = New System.Drawing.Point(174, 32)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpTransactionDate.TabIndex = 12
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'cboDoctorName
            '
            Me.cboDoctorName.BackColor = System.Drawing.Color.White
            Me.cboDoctorName.BegFindValue = Nothing
            Me.cboDoctorName.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboDoctorName, 2)
            Me.cboDoctorName.CurrentSearchTerm = ""
            Me.cboDoctorName.DataValue = Nothing
            Me.cboDoctorName.DefaultValue = Nothing
            Me.cboDoctorName.DisplayMember = "Name"
            Me.cboDoctorName.EditingMode = True
            Me.cboDoctorName.EndFindValue = Nothing
            Me.cboDoctorName.FieldDescription = Nothing
            Me.cboDoctorName.FieldName = Nothing
            Me.cboDoctorName.FilterRule = Nothing
            Me.cboDoctorName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDoctorName.FindEnabled = False
            Me.cboDoctorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDoctorName.ForeColor = System.Drawing.Color.Black
            Me.cboDoctorName.FormattingEnabled = True
            Me.cboDoctorName.HideWhenNotEditingOrAdding = False
            Me.cboDoctorName.IgnoreCase = False
            Me.cboDoctorName.IntegralHeight = False
            Me.cboDoctorName.LinkedLabel = Nothing
            Me.cboDoctorName.Location = New System.Drawing.Point(174, 1)
            Me.cboDoctorName.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDoctorName.Name = "cboDoctorName"
            Me.cboDoctorName.OldValue = 0
            Me.cboDoctorName.OriginalDataSource = Nothing
            Me.cboDoctorName.OriginalList = Nothing
            Me.cboDoctorName.OverrideDropDownStyleList = False
            Me.cboDoctorName.PreviousSearchTerm = Nothing
            Me.cboDoctorName.PropertySelector = Nothing
            Me.cboDoctorName.ReadOnlyCombo = False
            Me.cboDoctorName.Size = New System.Drawing.Size(509, 24)
            Me.cboDoctorName.SuggestBoxHeight = 200
            Me.cboDoctorName.SuggestListOrderRule = Nothing
            Me.cboDoctorName.TabIndex = 15
            Me.cboDoctorName.TextToSearch = Nothing
            Me.cboDoctorName.Translatable = False
            Me.cboDoctorName.ValueIsMandatory = False
            Me.cboDoctorName.ValueIsNullable = False
            Me.cboDoctorName.ValueIsNumeric = False
            Me.cboDoctorName.ValueMember = "Code"
            '
            'txtDoctorCode
            '
            Me.txtDoctorCode.BackColor = System.Drawing.Color.White
            Me.txtDoctorCode.BegFindValue = Nothing
            Me.txtDoctorCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDoctorCode.ComputedValue = False
            Me.txtDoctorCode.CustomFormat = Nothing
            Me.txtDoctorCode.DataBoundControl = True
            Me.txtDoctorCode.EditingMode = True
            Me.txtDoctorCode.EndFindValue = Nothing
            Me.txtDoctorCode.FieldDescription = Nothing
            Me.txtDoctorCode.FieldName = Nothing
            Me.txtDoctorCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDoctorCode.FindEnabled = False
            Me.txtDoctorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDoctorCode.ForeColor = System.Drawing.Color.Black
            Me.txtDoctorCode.LinkedLabel = Nothing
            Me.txtDoctorCode.Location = New System.Drawing.Point(693, 89)
            Me.txtDoctorCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDoctorCode.MaximumValue = Nothing
            Me.txtDoctorCode.MinimumValue = Nothing
            Me.txtDoctorCode.Name = "txtDoctorCode"
            Me.txtDoctorCode.OldValue = Nothing
            Me.txtDoctorCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorCode.Size = New System.Drawing.Size(80, 23)
            Me.txtDoctorCode.TabIndex = 16
            Me.txtDoctorCode.Translatable = False
            Me.txtDoctorCode.Visible = False
            '
            'TokenDataGridViewTextBoxColumn
            '
            Me.TokenDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.TokenDataGridViewTextBoxColumn.DataPropertyName = "Token"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.TokenDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
            Me.TokenDataGridViewTextBoxColumn.EditingMode = False
            Me.TokenDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.TokenDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.TokenDataGridViewTextBoxColumn.FieldName = Nothing
            Me.TokenDataGridViewTextBoxColumn.FillWeight = 40.0!
            Me.TokenDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TokenDataGridViewTextBoxColumn.FindEnabled = False
            Me.TokenDataGridViewTextBoxColumn.HeaderText = "Token"
            Me.TokenDataGridViewTextBoxColumn.IgnoreCase = False
            Me.TokenDataGridViewTextBoxColumn.Name = "TokenDataGridViewTextBoxColumn"
            Me.TokenDataGridViewTextBoxColumn.ReadOnly = True
            Me.TokenDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.TokenDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TokenDataGridViewTextBoxColumn.Translatable = False
            Me.TokenDataGridViewTextBoxColumn.Width = 40
            '
            'StatusDataGridViewTextBoxColumn
            '
            Me.StatusDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Orange
            DataGridViewCellStyle3.NullValue = False
            Me.StatusDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
            Me.StatusDataGridViewTextBoxColumn.EditingMode = False
            Me.StatusDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.StatusDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.StatusDataGridViewTextBoxColumn.FieldName = Nothing
            Me.StatusDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.StatusDataGridViewTextBoxColumn.FindEnabled = False
            Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
            Me.StatusDataGridViewTextBoxColumn.IgnoreCase = False
            Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
            Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
            Me.StatusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.StatusDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.StatusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.StatusDataGridViewTextBoxColumn.Translatable = False
            Me.StatusDataGridViewTextBoxColumn.Width = 40
            '
            'FileNoDataGridViewTextBoxColumn
            '
            Me.FileNoDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.FileNoDataGridViewTextBoxColumn.DataPropertyName = "FileNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.FileNoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
            Me.FileNoDataGridViewTextBoxColumn.EditingMode = False
            Me.FileNoDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.FileNoDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.FileNoDataGridViewTextBoxColumn.FieldName = Nothing
            Me.FileNoDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.FileNoDataGridViewTextBoxColumn.FindEnabled = False
            Me.FileNoDataGridViewTextBoxColumn.HeaderText = "FileNo"
            Me.FileNoDataGridViewTextBoxColumn.IgnoreCase = False
            Me.FileNoDataGridViewTextBoxColumn.Name = "FileNoDataGridViewTextBoxColumn"
            Me.FileNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.FileNoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.FileNoDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.FileNoDataGridViewTextBoxColumn.Translatable = False
            Me.FileNoDataGridViewTextBoxColumn.Width = 80
            '
            'NameDataGridViewTextBoxColumn
            '
            Me.NameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.NameDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.NameDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
            Me.NameDataGridViewTextBoxColumn.EditingMode = False
            Me.NameDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.NameDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.NameDataGridViewTextBoxColumn.FieldName = Nothing
            Me.NameDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.NameDataGridViewTextBoxColumn.FindEnabled = False
            Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
            Me.NameDataGridViewTextBoxColumn.IgnoreCase = False
            Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
            Me.NameDataGridViewTextBoxColumn.ReadOnly = True
            Me.NameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.NameDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.NameDataGridViewTextBoxColumn.Translatable = False
            '
            'InvTypeDataGridViewTextBoxColumn
            '
            Me.InvTypeDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.InvTypeDataGridViewTextBoxColumn.DataPropertyName = "InvType"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.InvTypeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
            Me.InvTypeDataGridViewTextBoxColumn.EditingMode = False
            Me.InvTypeDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.InvTypeDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.InvTypeDataGridViewTextBoxColumn.FieldName = Nothing
            Me.InvTypeDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.InvTypeDataGridViewTextBoxColumn.FindEnabled = False
            Me.InvTypeDataGridViewTextBoxColumn.HeaderText = "Invoice Type"
            Me.InvTypeDataGridViewTextBoxColumn.IgnoreCase = False
            Me.InvTypeDataGridViewTextBoxColumn.Name = "InvTypeDataGridViewTextBoxColumn"
            Me.InvTypeDataGridViewTextBoxColumn.ReadOnly = True
            Me.InvTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.InvTypeDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.InvTypeDataGridViewTextBoxColumn.Translatable = False
            Me.InvTypeDataGridViewTextBoxColumn.Width = 70
            '
            'bsPmrPatientDisplay
            '
            Me.bsPmrPatientDisplay.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PmrPatientDisplayModel)
            '
            'PmrInvestigationRequestForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(790, 553)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Name = "PmrInvestigationRequestForm"
            Me.Text = "PMR Request Form"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewPmrPatientDisplay, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPmrPatientDisplay, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsPmrPatientDisplay As BindingSource
        Friend WithEvents TransKeyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents RegistrationNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PatientNameEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SeriesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SexDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DoctorIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TransDateEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents btnRefresh As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents TypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents imgList As ImageList
        Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents DataGridViewPmrPatientDisplay As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpTransactionDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents TokenDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents StatusDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents FileNoDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents NameDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvFileType As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents InvTypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvTime As DataGridViewTextBoxColumn
        Friend WithEvents dgvTransKey As DataGridViewTextBoxColumn
        Friend WithEvents cboDoctorName As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace