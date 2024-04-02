Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DoctorsPrescriptionForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DoctorsPrescriptionForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.DataGridViewDoctorsPatient = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvFileNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvPatientName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvFileType = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.InvTypeDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvPatientIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvTransKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsDoctorsPatient = New System.Windows.Forms.BindingSource(Me.components)
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.cboDoctorName = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.CGroupBox1 = New AATM.Libraries.CBaseControlsLibrary.CGroupBox()
            Me.DataGridViewPrescriptionDetails = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.DurationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.chkPrint = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.bsPrescriptionDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.btnSelectAll = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnPrintLabels = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewDoctorsPatient, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsDoctorsPatient, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CGroupBox1.SuspendLayout()
            CType(Me.DataGridViewPrescriptionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPrescriptionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnRefresh
            '
            Me.btnRefresh.DesignerSelected = False
            Me.btnRefresh.ImageIndex = 0
            Me.btnRefresh.Location = New System.Drawing.Point(913, 4)
            Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.OriginalImageName = Nothing
            Me.btnRefresh.SecurityKey = ""
            Me.btnRefresh.Size = New System.Drawing.Size(120, 31)
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
            Me.CFlowLayout2.Controls.Add(Me.CGroupBox1)
            Me.CFlowLayout2.Controls.Add(Me.btnSelectAll)
            Me.CFlowLayout2.Controls.Add(Me.CButton1)
            Me.CFlowLayout2.Controls.Add(Me.btnPrintLabels)
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 59)
            Me.CFlowLayout2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(1063, 887)
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
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewDoctorsPatient, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.btnRefresh, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpTransactionDate, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboDoctorName, 1, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(1044, 508)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'DataGridViewDoctorsPatient
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDoctorsPatient.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewDoctorsPatient.AutoGenerateColumns = False
            Me.DataGridViewDoctorsPatient.BegFindValue = Nothing
            Me.DataGridViewDoctorsPatient.Cached = False
            Me.DataGridViewDoctorsPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDoctorsPatient.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvFileNo, Me.dgvPatientName, Me.dgvFileType, Me.InvTypeDataGridViewTextBoxColumn, Me.dgvTime, Me.dgvPatientIdNo, Me.dgvTransKey})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewDoctorsPatient, 4)
            Me.DataGridViewDoctorsPatient.DataFilter = Nothing
            Me.DataGridViewDoctorsPatient.DataSource = Me.bsDoctorsPatient
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDoctorsPatient.DefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridViewDoctorsPatient.DgvFooter = Nothing
            Me.DataGridViewDoctorsPatient.DisplayOnly = True
            Me.DataGridViewDoctorsPatient.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewDoctorsPatient.Ea = Nothing
            Me.DataGridViewDoctorsPatient.EditingMode = False
            Me.DataGridViewDoctorsPatient.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewDoctorsPatient.EndFindValue = Nothing
            Me.DataGridViewDoctorsPatient.FieldDescription = Nothing
            Me.DataGridViewDoctorsPatient.FieldName = Nothing
            Me.DataGridViewDoctorsPatient.FieldsDictionary = Nothing
            Me.DataGridViewDoctorsPatient.FindColumnNo = CType(0, Short)
            Me.DataGridViewDoctorsPatient.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewDoctorsPatient.FindEnabled = False
            Me.DataGridViewDoctorsPatient.FirstRowDeletionEnabled = True
            Me.DataGridViewDoctorsPatient.FirstRowInsertionEnabled = True
            Me.DataGridViewDoctorsPatient.IgnoreCase = False
            Me.DataGridViewDoctorsPatient.IsDirty = False
            Me.DataGridViewDoctorsPatient.Location = New System.Drawing.Point(4, 73)
            Me.DataGridViewDoctorsPatient.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.DataGridViewDoctorsPatient.Name = "DataGridViewDoctorsPatient"
            Me.DataGridViewDoctorsPatient.OldCellValue = Nothing
            Me.DataGridViewDoctorsPatient.ReadOnly = True
            Me.DataGridViewDoctorsPatient.RowHeadersWidth = 51
            Me.DataGridViewDoctorsPatient.Searchable = True
            Me.DataGridViewDoctorsPatient.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewDoctorsPatient.SecurityKey = ""
            Me.DataGridViewDoctorsPatient.SequenceColumn = "dgvSequence"
            Me.DataGridViewDoctorsPatient.SequenceFieldName = "Sequence"
            Me.DataGridViewDoctorsPatient.ShowFooter = False
            Me.DataGridViewDoctorsPatient.Size = New System.Drawing.Size(1036, 431)
            Me.DataGridViewDoctorsPatient.TabIndex = 11
            Me.DataGridViewDoctorsPatient.Translatable = True
            '
            'dgvFileNo
            '
            Me.dgvFileNo.BegFindValue = Nothing
            Me.dgvFileNo.DataPropertyName = "FileNo"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvFileNo.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvFileNo.EditingMode = False
            Me.dgvFileNo.EndFindValue = Nothing
            Me.dgvFileNo.FieldDescription = Nothing
            Me.dgvFileNo.FieldName = Nothing
            Me.dgvFileNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvFileNo.FindEnabled = False
            Me.dgvFileNo.HeaderText = "FileNo"
            Me.dgvFileNo.IgnoreCase = False
            Me.dgvFileNo.MinimumWidth = 6
            Me.dgvFileNo.Name = "dgvFileNo"
            Me.dgvFileNo.ReadOnly = True
            Me.dgvFileNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvFileNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvFileNo.Translatable = False
            Me.dgvFileNo.Width = 80
            '
            'dgvPatientName
            '
            Me.dgvPatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvPatientName.BegFindValue = Nothing
            Me.dgvPatientName.DataPropertyName = "Name"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvPatientName.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvPatientName.EditingMode = False
            Me.dgvPatientName.EndFindValue = Nothing
            Me.dgvPatientName.FieldDescription = Nothing
            Me.dgvPatientName.FieldName = Nothing
            Me.dgvPatientName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPatientName.FindEnabled = False
            Me.dgvPatientName.HeaderText = "Name"
            Me.dgvPatientName.IgnoreCase = False
            Me.dgvPatientName.MinimumWidth = 6
            Me.dgvPatientName.Name = "dgvPatientName"
            Me.dgvPatientName.ReadOnly = True
            Me.dgvPatientName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPatientName.Translatable = False
            '
            'dgvFileType
            '
            Me.dgvFileType.BegFindValue = Nothing
            Me.dgvFileType.DataPropertyName = "InvType"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvFileType.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvFileType.EditingMode = False
            Me.dgvFileType.EndFindValue = Nothing
            Me.dgvFileType.FieldDescription = Nothing
            Me.dgvFileType.FieldName = Nothing
            Me.dgvFileType.FillWeight = 60.0!
            Me.dgvFileType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvFileType.FindEnabled = False
            Me.dgvFileType.HeaderText = "Patient Type"
            Me.dgvFileType.IgnoreCase = False
            Me.dgvFileType.MinimumWidth = 6
            Me.dgvFileType.Name = "dgvFileType"
            Me.dgvFileType.ReadOnly = True
            Me.dgvFileType.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvFileType.Translatable = False
            Me.dgvFileType.Width = 60
            '
            'InvTypeDataGridViewTextBoxColumn
            '
            Me.InvTypeDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.InvTypeDataGridViewTextBoxColumn.DataPropertyName = "InvType"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.InvTypeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
            Me.InvTypeDataGridViewTextBoxColumn.EditingMode = False
            Me.InvTypeDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.InvTypeDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.InvTypeDataGridViewTextBoxColumn.FieldName = Nothing
            Me.InvTypeDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.InvTypeDataGridViewTextBoxColumn.FindEnabled = False
            Me.InvTypeDataGridViewTextBoxColumn.HeaderText = "Invoice Type"
            Me.InvTypeDataGridViewTextBoxColumn.IgnoreCase = False
            Me.InvTypeDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.InvTypeDataGridViewTextBoxColumn.Name = "InvTypeDataGridViewTextBoxColumn"
            Me.InvTypeDataGridViewTextBoxColumn.ReadOnly = True
            Me.InvTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.InvTypeDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.InvTypeDataGridViewTextBoxColumn.Translatable = False
            Me.InvTypeDataGridViewTextBoxColumn.Width = 70
            '
            'dgvTime
            '
            Me.dgvTime.DataPropertyName = "InvTime"
            DataGridViewCellStyle6.Format = "hh:mm tt"
            DataGridViewCellStyle6.NullValue = Nothing
            Me.dgvTime.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvTime.HeaderText = "Time"
            Me.dgvTime.MinimumWidth = 6
            Me.dgvTime.Name = "dgvTime"
            Me.dgvTime.ReadOnly = True
            Me.dgvTime.Width = 125
            '
            'dgvPatientIdNo
            '
            Me.dgvPatientIdNo.DataPropertyName = "PatientIdNo"
            Me.dgvPatientIdNo.HeaderText = "PatientIdNo"
            Me.dgvPatientIdNo.MinimumWidth = 6
            Me.dgvPatientIdNo.Name = "dgvPatientIdNo"
            Me.dgvPatientIdNo.ReadOnly = True
            Me.dgvPatientIdNo.Visible = False
            Me.dgvPatientIdNo.Width = 125
            '
            'dgvTransKey
            '
            Me.dgvTransKey.DataPropertyName = "TransKey"
            Me.dgvTransKey.HeaderText = "TransKey"
            Me.dgvTransKey.MinimumWidth = 6
            Me.dgvTransKey.Name = "dgvTransKey"
            Me.dgvTransKey.ReadOnly = True
            Me.dgvTransKey.Visible = False
            Me.dgvTransKey.Width = 125
            '
            'bsDoctorsPatient
            '
            Me.bsDoctorsPatient.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DoctorsPatientModel)
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 40)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(208, 28)
            Me.CLabel1.TabIndex = 13
            Me.CLabel1.Text = "Transaction Date:"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(228, 28)
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(231, 40)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(119, 27)
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
            Me.cboDoctorName.Editable = True
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
            Me.cboDoctorName.LimitToList = False
            Me.cboDoctorName.LinkedLabel = Nothing
            Me.cboDoctorName.Location = New System.Drawing.Point(231, 1)
            Me.cboDoctorName.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDoctorName.Name = "cboDoctorName"
            Me.cboDoctorName.OldValue = 0
            Me.cboDoctorName.OriginalDataSource = Nothing
            Me.cboDoctorName.OriginalList = Nothing
            Me.cboDoctorName.OverrideDropDownStyleList = False
            Me.cboDoctorName.PreviousSearchTerm = Nothing
            Me.cboDoctorName.PropertySelector = Nothing
            Me.cboDoctorName.Size = New System.Drawing.Size(677, 28)
            Me.cboDoctorName.SuggestBoxHeight = 200
            Me.cboDoctorName.SuggestCharCount = 0
            Me.cboDoctorName.SuggestListOrderRule = Nothing
            Me.cboDoctorName.TabIndex = 15
            Me.cboDoctorName.TextToSearch = Nothing
            Me.cboDoctorName.Translatable = False
            Me.cboDoctorName.ValueIsMandatory = False
            Me.cboDoctorName.ValueIsNullable = False
            Me.cboDoctorName.ValueIsNumeric = False
            Me.cboDoctorName.ValueMember = "Code"
            '
            'CGroupBox1
            '
            Me.CGroupBox1.AutoSize = True
            Me.CGroupBox1.BackColor = System.Drawing.Color.Transparent
            Me.CGroupBox1.Controls.Add(Me.DataGridViewPrescriptionDetails)
            Me.CGroupBox1.DisplayOnly = True
            Me.CGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CGroupBox1.Location = New System.Drawing.Point(4, 520)
            Me.CGroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.CGroupBox1.Name = "CGroupBox1"
            Me.CGroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.CGroupBox1.Size = New System.Drawing.Size(1044, 256)
            Me.CGroupBox1.TabIndex = 19
            Me.CGroupBox1.TabStop = False
            Me.CGroupBox1.Text = "Prescription for :"
            '
            'DataGridViewPrescriptionDetails
            '
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPrescriptionDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
            Me.DataGridViewPrescriptionDetails.AutoGenerateColumns = False
            Me.DataGridViewPrescriptionDetails.BegFindValue = Nothing
            Me.DataGridViewPrescriptionDetails.Cached = False
            Me.DataGridViewPrescriptionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPrescriptionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DurationDataGridViewTextBoxColumn, Me.chkPrint})
            Me.DataGridViewPrescriptionDetails.DataFilter = Nothing
            Me.DataGridViewPrescriptionDetails.DataSource = Me.bsPrescriptionDetails
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPrescriptionDetails.DefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewPrescriptionDetails.DgvFooter = Nothing
            Me.DataGridViewPrescriptionDetails.DisplayOnly = False
            Me.DataGridViewPrescriptionDetails.Ea = Nothing
            Me.DataGridViewPrescriptionDetails.EditingMode = False
            Me.DataGridViewPrescriptionDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPrescriptionDetails.EndFindValue = Nothing
            Me.DataGridViewPrescriptionDetails.FieldDescription = Nothing
            Me.DataGridViewPrescriptionDetails.FieldName = Nothing
            Me.DataGridViewPrescriptionDetails.FieldsDictionary = Nothing
            Me.DataGridViewPrescriptionDetails.FindColumnNo = CType(0, Short)
            Me.DataGridViewPrescriptionDetails.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPrescriptionDetails.FindEnabled = False
            Me.DataGridViewPrescriptionDetails.FirstRowDeletionEnabled = True
            Me.DataGridViewPrescriptionDetails.FirstRowInsertionEnabled = True
            Me.DataGridViewPrescriptionDetails.IgnoreCase = False
            Me.DataGridViewPrescriptionDetails.IsDirty = False
            Me.DataGridViewPrescriptionDetails.Location = New System.Drawing.Point(12, 23)
            Me.DataGridViewPrescriptionDetails.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.DataGridViewPrescriptionDetails.Name = "DataGridViewPrescriptionDetails"
            Me.DataGridViewPrescriptionDetails.OldCellValue = Nothing
            Me.DataGridViewPrescriptionDetails.RowHeadersWidth = 51
            Me.DataGridViewPrescriptionDetails.Searchable = True
            Me.DataGridViewPrescriptionDetails.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPrescriptionDetails.SecurityKey = ""
            Me.DataGridViewPrescriptionDetails.SequenceColumn = "dgvSequence"
            Me.DataGridViewPrescriptionDetails.SequenceFieldName = "Sequence"
            Me.DataGridViewPrescriptionDetails.ShowFooter = False
            Me.DataGridViewPrescriptionDetails.Size = New System.Drawing.Size(1024, 209)
            Me.DataGridViewPrescriptionDetails.TabIndex = 18
            Me.DataGridViewPrescriptionDetails.Translatable = True
            '
            'DurationDataGridViewTextBoxColumn
            '
            Me.DurationDataGridViewTextBoxColumn.DataPropertyName = "Duration"
            Me.DurationDataGridViewTextBoxColumn.HeaderText = "Duration"
            Me.DurationDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.DurationDataGridViewTextBoxColumn.Name = "DurationDataGridViewTextBoxColumn"
            Me.DurationDataGridViewTextBoxColumn.Width = 125
            '
            'chkPrint
            '
            Me.chkPrint.DataPropertyName = "Print"
            Me.chkPrint.HeaderText = "Print"
            Me.chkPrint.MinimumWidth = 6
            Me.chkPrint.Name = "chkPrint"
            Me.chkPrint.Width = 60
            '
            'bsPrescriptionDetails
            '
            Me.bsPrescriptionDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PrescriptionItemModel)
            '
            'btnSelectAll
            '
            Me.btnSelectAll.DesignerSelected = False
            Me.btnSelectAll.ImageIndex = 0
            Me.btnSelectAll.Location = New System.Drawing.Point(4, 784)
            Me.btnSelectAll.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.btnSelectAll.Name = "btnSelectAll"
            Me.btnSelectAll.OriginalImageName = Nothing
            Me.btnSelectAll.SecurityKey = ""
            Me.btnSelectAll.Size = New System.Drawing.Size(120, 31)
            Me.btnSelectAll.TabIndex = 20
            Me.btnSelectAll.Text = "Select All"
            '
            'CButton1
            '
            Me.CButton1.DesignerSelected = False
            Me.CButton1.ImageIndex = 0
            Me.CButton1.Location = New System.Drawing.Point(132, 784)
            Me.CButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.CButton1.Name = "CButton1"
            Me.CButton1.OriginalImageName = Nothing
            Me.CButton1.SecurityKey = ""
            Me.CButton1.Size = New System.Drawing.Size(141, 31)
            Me.CButton1.TabIndex = 22
            Me.CButton1.Text = "Unselect All"
            '
            'btnPrintLabels
            '
            Me.btnPrintLabels.DesignerSelected = False
            Me.btnPrintLabels.ImageIndex = 0
            Me.btnPrintLabels.Location = New System.Drawing.Point(281, 784)
            Me.btnPrintLabels.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.btnPrintLabels.Name = "btnPrintLabels"
            Me.btnPrintLabels.OriginalImageName = Nothing
            Me.btnPrintLabels.SecurityKey = ""
            Me.btnPrintLabels.Size = New System.Drawing.Size(424, 31)
            Me.btnPrintLabels.TabIndex = 21
            Me.btnPrintLabels.Text = "Print Dosage Labels for Selected Medicines"
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
            Me.txtDoctorCode.Location = New System.Drawing.Point(924, 110)
            Me.txtDoctorCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDoctorCode.MaximumValue = Nothing
            Me.txtDoctorCode.MinimumValue = Nothing
            Me.txtDoctorCode.Name = "txtDoctorCode"
            Me.txtDoctorCode.OldValue = Nothing
            Me.txtDoctorCode.OverrideMaxLength = 0
            Me.txtDoctorCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorCode.Size = New System.Drawing.Size(106, 26)
            Me.txtDoctorCode.TabIndex = 16
            Me.txtDoctorCode.Translatable = False
            Me.txtDoctorCode.Visible = False
            '
            'DoctorsPrescriptionForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(1063, 946)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.Name = "DoctorsPrescriptionForm"
            Me.Text = "Doctor's Patients Viewer"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewDoctorsPatient, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsDoctorsPatient, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CGroupBox1.ResumeLayout(False)
            CType(Me.DataGridViewPrescriptionDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPrescriptionDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsDoctorsPatient As BindingSource
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
        Friend WithEvents DataGridViewDoctorsPatient As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpTransactionDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents cboDoctorName As Libraries.CBaseControlsLibrary.CtCombobox
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents DataGridViewPrescriptionDetails As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents bsPrescriptionDetails As BindingSource
        Friend WithEvents CGroupBox1 As Libraries.CBaseControlsLibrary.CGroupBox
        Friend WithEvents dgvFileNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvPatientName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvFileType As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents InvTypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvTime As DataGridViewTextBoxColumn
        Friend WithEvents dgvPatientIdNo As DataGridViewTextBoxColumn
        Friend WithEvents dgvTransKey As DataGridViewTextBoxColumn
        Friend WithEvents btnSelectAll As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents CButton1 As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnPrintLabels As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents ItemNameEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DosageEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DurationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents chkPrint As DataGridViewCheckBoxColumn
    End Class
End Namespace