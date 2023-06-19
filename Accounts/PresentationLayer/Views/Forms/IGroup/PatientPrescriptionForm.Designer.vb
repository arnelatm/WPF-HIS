Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PatientPrescriptionForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PatientPrescriptionForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.cboSeries = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAgeYMD = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CTextBox2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtAge = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.DataGridViewPrescriptionDetails = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvTransKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPatientName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.txtPatientNameEnglish = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtRegistrationNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboGender = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblSeries = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.ItemNameEnglishDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DosageEnglishDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DurationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPrescriptionDetails = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewPrescriptionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPrescriptionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            Me.CFlowLayout2.Size = New System.Drawing.Size(808, 500)
            Me.CFlowLayout2.TabIndex = 5
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.ColumnCount = 6
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.cboSeries, 5, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAgeYMD, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CTextBox2, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAge, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPrescriptionDetails, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPatientName, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpTransactionDate, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientNameEnglish, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtRegistrationNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboGender, 5, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSeries, 4, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 6
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(797, 554)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'cboSeries
            '
            Me.cboSeries.AlwaysEditable = False
            Me.cboSeries.BackColor = System.Drawing.Color.White
            Me.cboSeries.BegFindValue = Nothing
            Me.cboSeries.ChangingSearchValueOnly = False
            Me.cboSeries.CurrentSearchTerm = ""
            Me.cboSeries.DataValue = Nothing
            Me.cboSeries.DefaultValue = Nothing
            Me.cboSeries.DisplayMember = "Name"
            Me.cboSeries.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboSeries.EditingMode = True
            Me.cboSeries.EndFindValue = Nothing
            Me.cboSeries.FieldDescription = Nothing
            Me.cboSeries.FieldName = Nothing
            Me.cboSeries.FilterRule = Nothing
            Me.cboSeries.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboSeries.FindEnabled = False
            Me.cboSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboSeries.ForeColor = System.Drawing.Color.Black
            Me.cboSeries.FormattingEnabled = True
            Me.cboSeries.HideWhenNotEditingOrAdding = False
            Me.cboSeries.IgnoreCase = False
            Me.cboSeries.IntegralHeight = False
            Me.cboSeries.LimitToList = False
            Me.cboSeries.LinkedLabel = Nothing
            Me.cboSeries.Location = New System.Drawing.Point(698, 1)
            Me.cboSeries.Margin = New System.Windows.Forms.Padding(1)
            Me.cboSeries.Name = "cboSeries"
            Me.cboSeries.OldValue = 0
            Me.cboSeries.OriginalDataSource = Nothing
            Me.cboSeries.OriginalList = Nothing
            Me.cboSeries.OverrideDropDownStyleList = False
            Me.cboSeries.PreviousSearchTerm = Nothing
            Me.cboSeries.PropertySelector = Nothing
            Me.cboSeries.ReadOnlyCombo = False
            Me.cboSeries.Size = New System.Drawing.Size(98, 24)
            Me.cboSeries.SuggestBoxHeight = 200
            Me.cboSeries.SuggestListOrderRule = Nothing
            Me.cboSeries.TabIndex = 24
            Me.cboSeries.TextToSearch = Nothing
            Me.cboSeries.Translatable = False
            Me.cboSeries.ValueIsMandatory = False
            Me.cboSeries.ValueIsNullable = False
            Me.cboSeries.ValueIsNumeric = False
            Me.cboSeries.ValueMember = "IdNo"
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(606, 27)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(90, 24)
            Me.CLabel3.TabIndex = 21
            Me.CLabel3.Text = "Gender"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel3.Translatable = True
            '
            'txtAgeYMD
            '
            Me.txtAgeYMD.BackColor = System.Drawing.Color.White
            Me.txtAgeYMD.BegFindValue = Nothing
            Me.txtAgeYMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAgeYMD.ComputedValue = False
            Me.txtAgeYMD.CustomFormat = Nothing
            Me.txtAgeYMD.DataBoundControl = True
            Me.txtAgeYMD.EditingMode = True
            Me.txtAgeYMD.EndFindValue = Nothing
            Me.txtAgeYMD.FieldDescription = Nothing
            Me.txtAgeYMD.FieldName = Nothing
            Me.txtAgeYMD.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAgeYMD.FindEnabled = False
            Me.txtAgeYMD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAgeYMD.ForeColor = System.Drawing.Color.Black
            Me.txtAgeYMD.LinkedLabel = Nothing
            Me.txtAgeYMD.Location = New System.Drawing.Point(288, 27)
            Me.txtAgeYMD.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAgeYMD.MaximumValue = Nothing
            Me.txtAgeYMD.MinimumValue = Nothing
            Me.txtAgeYMD.Name = "txtAgeYMD"
            Me.txtAgeYMD.OldValue = Nothing
            Me.txtAgeYMD.OverrideMaxLength = 0
            Me.txtAgeYMD.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAgeYMD.Size = New System.Drawing.Size(41, 23)
            Me.txtAgeYMD.TabIndex = 20
            Me.txtAgeYMD.Translatable = False
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(1, 27)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(156, 23)
            Me.CLabel2.TabIndex = 19
            Me.CLabel2.Text = "Age"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'CTextBox2
            '
            Me.CTextBox2.BackColor = System.Drawing.Color.White
            Me.CTextBox2.BegFindValue = Nothing
            Me.CTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox2.ComputedValue = False
            Me.CTextBox2.CustomFormat = Nothing
            Me.CTextBox2.DataBoundControl = True
            Me.CTextBox2.EditingMode = True
            Me.CTextBox2.EndFindValue = Nothing
            Me.CTextBox2.FieldDescription = Nothing
            Me.CTextBox2.FieldName = Nothing
            Me.CTextBox2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBox2.FindEnabled = False
            Me.CTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox2.ForeColor = System.Drawing.Color.Black
            Me.CTextBox2.LinkedLabel = Nothing
            Me.CTextBox2.Location = New System.Drawing.Point(1, 515)
            Me.CTextBox2.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox2.MaximumValue = Nothing
            Me.CTextBox2.MinimumValue = Nothing
            Me.CTextBox2.Name = "CTextBox2"
            Me.CTextBox2.OldValue = Nothing
            Me.CTextBox2.OverrideMaxLength = 0
            Me.CTextBox2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBox2.Size = New System.Drawing.Size(100, 23)
            Me.CTextBox2.TabIndex = 18
            Me.CTextBox2.Translatable = False
            '
            'txtAge
            '
            Me.txtAge.BackColor = System.Drawing.Color.White
            Me.txtAge.BegFindValue = Nothing
            Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAge.ComputedValue = False
            Me.txtAge.CustomFormat = Nothing
            Me.txtAge.DataBoundControl = True
            Me.txtAge.EditingMode = True
            Me.txtAge.EndFindValue = Nothing
            Me.txtAge.FieldDescription = Nothing
            Me.txtAge.FieldName = Nothing
            Me.txtAge.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAge.FindEnabled = False
            Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAge.ForeColor = System.Drawing.Color.Black
            Me.txtAge.LinkedLabel = Nothing
            Me.txtAge.Location = New System.Drawing.Point(186, 27)
            Me.txtAge.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAge.MaximumValue = Nothing
            Me.txtAge.MinimumValue = Nothing
            Me.txtAge.Name = "txtAge"
            Me.txtAge.OldValue = Nothing
            Me.txtAge.OverrideMaxLength = 0
            Me.txtAge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAge.Size = New System.Drawing.Size(100, 23)
            Me.txtAge.TabIndex = 17
            Me.txtAge.Translatable = False
            '
            'DataGridViewPrescriptionDetails
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPrescriptionDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPrescriptionDetails.AutoGenerateColumns = False
            Me.DataGridViewPrescriptionDetails.BegFindValue = Nothing
            Me.DataGridViewPrescriptionDetails.Cached = False
            Me.DataGridViewPrescriptionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPrescriptionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemNameEnglishDataGridViewTextBoxColumn, Me.DosageEnglishDataGridViewTextBoxColumn, Me.DurationDataGridViewTextBoxColumn, Me.dgvTransKey})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPrescriptionDetails, 6)
            Me.DataGridViewPrescriptionDetails.DataFilter = Nothing
            Me.DataGridViewPrescriptionDetails.DataSource = Me.bsPrescriptionDetails
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPrescriptionDetails.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewPrescriptionDetails.DgSearch = CType(resources.GetObject("DataGridViewPrescriptionDetails.DgSearch"), System.Collections.Generic.List(Of AATM.Libraries.CBaseControlsLibrary.CDataGridView.DataGridSearch))
            Me.DataGridViewPrescriptionDetails.DgvFooter = Nothing
            Me.DataGridViewPrescriptionDetails.DisplayOnly = True
            Me.DataGridViewPrescriptionDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPrescriptionDetails.Ea = Nothing
            Me.DataGridViewPrescriptionDetails.EditingMode = False
            Me.DataGridViewPrescriptionDetails.EndFindValue = Nothing
            Me.DataGridViewPrescriptionDetails.FieldDescription = Nothing
            Me.DataGridViewPrescriptionDetails.FieldName = Nothing
            Me.DataGridViewPrescriptionDetails.FieldsDictionary = Nothing
            Me.DataGridViewPrescriptionDetails.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPrescriptionDetails.FindEnabled = False
            Me.DataGridViewPrescriptionDetails.FirstRowDeletionEnabled = True
            Me.DataGridViewPrescriptionDetails.FirstRowInsertionEnabled = True
            Me.DataGridViewPrescriptionDetails.IgnoreCase = False
            Me.DataGridViewPrescriptionDetails.IsDirty = False
            Me.DataGridViewPrescriptionDetails.Location = New System.Drawing.Point(3, 80)
            Me.DataGridViewPrescriptionDetails.Name = "DataGridViewPrescriptionDetails"
            Me.DataGridViewPrescriptionDetails.ReadOnly = True
            Me.DataGridViewPrescriptionDetails.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPrescriptionDetails.SecurityKey = ""
            Me.DataGridViewPrescriptionDetails.SequenceColumn = "dgvSequence"
            Me.DataGridViewPrescriptionDetails.SequenceFieldName = "Sequence"
            Me.DataGridViewPrescriptionDetails.ShowFooter = False
            Me.DataGridViewPrescriptionDetails.Size = New System.Drawing.Size(791, 431)
            Me.DataGridViewPrescriptionDetails.TabIndex = 11
            Me.DataGridViewPrescriptionDetails.Translatable = True
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
            Me.CLabel1.Location = New System.Drawing.Point(1, 53)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(133, 23)
            Me.CLabel1.TabIndex = 13
            Me.CLabel1.Text = "Transaction Date:"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'lblPatientName
            '
            Me.lblPatientName.DisplayOnly = True
            Me.lblPatientName.EditingMode = False
            Me.lblPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPatientName.Location = New System.Drawing.Point(1, 1)
            Me.lblPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPatientName.Name = "lblPatientName"
            Me.lblPatientName.Size = New System.Drawing.Size(183, 23)
            Me.lblPatientName.TabIndex = 14
            Me.lblPatientName.Text = "Patient File No./Name:"
            Me.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPatientName.Translatable = True
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(186, 53)
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
            'txtPatientNameEnglish
            '
            Me.txtPatientNameEnglish.BackColor = System.Drawing.Color.White
            Me.txtPatientNameEnglish.BegFindValue = Nothing
            Me.txtPatientNameEnglish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPatientNameEnglish, 2)
            Me.txtPatientNameEnglish.ComputedValue = False
            Me.txtPatientNameEnglish.CustomFormat = Nothing
            Me.txtPatientNameEnglish.DataBoundControl = True
            Me.txtPatientNameEnglish.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPatientNameEnglish.EditingMode = True
            Me.txtPatientNameEnglish.EndFindValue = Nothing
            Me.txtPatientNameEnglish.FieldDescription = Nothing
            Me.txtPatientNameEnglish.FieldName = Nothing
            Me.txtPatientNameEnglish.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPatientNameEnglish.FindEnabled = False
            Me.txtPatientNameEnglish.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPatientNameEnglish.ForeColor = System.Drawing.Color.Black
            Me.txtPatientNameEnglish.LinkedLabel = Nothing
            Me.txtPatientNameEnglish.Location = New System.Drawing.Point(288, 1)
            Me.txtPatientNameEnglish.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientNameEnglish.MaximumValue = Nothing
            Me.txtPatientNameEnglish.MinimumValue = Nothing
            Me.txtPatientNameEnglish.Name = "txtPatientNameEnglish"
            Me.txtPatientNameEnglish.OldValue = Nothing
            Me.txtPatientNameEnglish.OverrideMaxLength = 0
            Me.txtPatientNameEnglish.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientNameEnglish.Size = New System.Drawing.Size(316, 23)
            Me.txtPatientNameEnglish.TabIndex = 15
            Me.txtPatientNameEnglish.Translatable = False
            '
            'txtRegistrationNo
            '
            Me.txtRegistrationNo.BackColor = System.Drawing.Color.White
            Me.txtRegistrationNo.BegFindValue = Nothing
            Me.txtRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRegistrationNo.ComputedValue = False
            Me.txtRegistrationNo.CustomFormat = Nothing
            Me.txtRegistrationNo.DataBoundControl = True
            Me.txtRegistrationNo.EditingMode = True
            Me.txtRegistrationNo.EndFindValue = Nothing
            Me.txtRegistrationNo.FieldDescription = Nothing
            Me.txtRegistrationNo.FieldName = Nothing
            Me.txtRegistrationNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRegistrationNo.FindEnabled = False
            Me.txtRegistrationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtRegistrationNo.ForeColor = System.Drawing.Color.Black
            Me.txtRegistrationNo.LinkedLabel = Nothing
            Me.txtRegistrationNo.Location = New System.Drawing.Point(186, 1)
            Me.txtRegistrationNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRegistrationNo.MaximumValue = Nothing
            Me.txtRegistrationNo.MinimumValue = Nothing
            Me.txtRegistrationNo.Name = "txtRegistrationNo"
            Me.txtRegistrationNo.OldValue = Nothing
            Me.txtRegistrationNo.OverrideMaxLength = 0
            Me.txtRegistrationNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRegistrationNo.Size = New System.Drawing.Size(100, 23)
            Me.txtRegistrationNo.TabIndex = 16
            Me.txtRegistrationNo.Translatable = False
            '
            'cboGender
            '
            Me.cboGender.AlwaysEditable = False
            Me.cboGender.BackColor = System.Drawing.Color.White
            Me.cboGender.BegFindValue = Nothing
            Me.cboGender.ChangingSearchValueOnly = False
            Me.cboGender.CurrentSearchTerm = ""
            Me.cboGender.DataValue = Nothing
            Me.cboGender.DefaultValue = Nothing
            Me.cboGender.DisplayMember = "Name"
            Me.cboGender.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboGender.EditingMode = True
            Me.cboGender.EndFindValue = Nothing
            Me.cboGender.FieldDescription = Nothing
            Me.cboGender.FieldName = Nothing
            Me.cboGender.FilterRule = Nothing
            Me.cboGender.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboGender.FindEnabled = False
            Me.cboGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboGender.ForeColor = System.Drawing.Color.Black
            Me.cboGender.FormattingEnabled = True
            Me.cboGender.HideWhenNotEditingOrAdding = False
            Me.cboGender.IgnoreCase = False
            Me.cboGender.IntegralHeight = False
            Me.cboGender.LimitToList = False
            Me.cboGender.LinkedLabel = Nothing
            Me.cboGender.Location = New System.Drawing.Point(698, 27)
            Me.cboGender.Margin = New System.Windows.Forms.Padding(1)
            Me.cboGender.Name = "cboGender"
            Me.cboGender.OldValue = 0
            Me.cboGender.OriginalDataSource = Nothing
            Me.cboGender.OriginalList = Nothing
            Me.cboGender.OverrideDropDownStyleList = False
            Me.cboGender.PreviousSearchTerm = Nothing
            Me.cboGender.PropertySelector = Nothing
            Me.cboGender.ReadOnlyCombo = False
            Me.cboGender.Size = New System.Drawing.Size(98, 24)
            Me.cboGender.SuggestBoxHeight = 200
            Me.cboGender.SuggestListOrderRule = Nothing
            Me.cboGender.TabIndex = 22
            Me.cboGender.TextToSearch = Nothing
            Me.cboGender.Translatable = False
            Me.cboGender.ValueIsMandatory = False
            Me.cboGender.ValueIsNullable = False
            Me.cboGender.ValueIsNumeric = False
            Me.cboGender.ValueMember = "IdNo"
            '
            'lblSeries
            '
            Me.lblSeries.AutoSize = True
            Me.lblSeries.DisplayOnly = True
            Me.lblSeries.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSeries.EditingMode = False
            Me.lblSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSeries.Location = New System.Drawing.Point(606, 1)
            Me.lblSeries.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSeries.Name = "lblSeries"
            Me.lblSeries.Size = New System.Drawing.Size(90, 24)
            Me.lblSeries.TabIndex = 23
            Me.lblSeries.Text = "Series"
            Me.lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblSeries.Translatable = True
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
            Me.txtDoctorCode.OverrideMaxLength = 0
            Me.txtDoctorCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorCode.Size = New System.Drawing.Size(80, 23)
            Me.txtDoctorCode.TabIndex = 16
            Me.txtDoctorCode.Translatable = False
            Me.txtDoctorCode.Visible = False
            '
            'ItemNameEnglishDataGridViewTextBoxColumn
            '
            Me.ItemNameEnglishDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.ItemNameEnglishDataGridViewTextBoxColumn.DataPropertyName = "ItemNameEnglish"
            Me.ItemNameEnglishDataGridViewTextBoxColumn.HeaderText = "Medicine Name"
            Me.ItemNameEnglishDataGridViewTextBoxColumn.Name = "ItemNameEnglishDataGridViewTextBoxColumn"
            Me.ItemNameEnglishDataGridViewTextBoxColumn.ReadOnly = True
            '
            'DosageEnglishDataGridViewTextBoxColumn
            '
            Me.DosageEnglishDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DosageEnglishDataGridViewTextBoxColumn.DataPropertyName = "DosageEnglish"
            Me.DosageEnglishDataGridViewTextBoxColumn.HeaderText = "Dosage "
            Me.DosageEnglishDataGridViewTextBoxColumn.Name = "DosageEnglishDataGridViewTextBoxColumn"
            Me.DosageEnglishDataGridViewTextBoxColumn.ReadOnly = True
            Me.DosageEnglishDataGridViewTextBoxColumn.Width = 72
            '
            'DurationDataGridViewTextBoxColumn
            '
            Me.DurationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DurationDataGridViewTextBoxColumn.DataPropertyName = "Duration"
            Me.DurationDataGridViewTextBoxColumn.HeaderText = "Duration"
            Me.DurationDataGridViewTextBoxColumn.Name = "DurationDataGridViewTextBoxColumn"
            Me.DurationDataGridViewTextBoxColumn.ReadOnly = True
            Me.DurationDataGridViewTextBoxColumn.Width = 72
            '
            'bsPrescriptionDetails
            '
            Me.bsPrescriptionDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PrescriptionDetailModel)
            '
            'PatientPrescriptionForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(808, 553)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Name = "PatientPrescriptionForm"
            Me.Text = "Patient Prescription"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewPrescriptionDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPrescriptionDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsPrescriptionDetails As BindingSource
        Friend WithEvents TransKeyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents RegistrationNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PatientNameEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SeriesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SexDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DoctorIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TransDateEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents imgList As ImageList
        Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents DataGridViewPrescriptionDetails As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPatientName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpTransactionDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents TokenDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents StatusDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents FileNoDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents NameDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents InvTypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtPatientNameEnglish As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtRegistrationNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtAgeYMD As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTextBox2 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtAge As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents cboGender As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents cboSeries As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents lblSeries As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents ItemNameEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DosageEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DurationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvTransKey As DataGridViewTextBoxColumn
    End Class
End Namespace