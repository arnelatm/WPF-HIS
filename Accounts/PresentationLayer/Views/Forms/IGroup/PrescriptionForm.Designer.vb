Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PrescriptionForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrescriptionForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtTransKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransKey = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDoctorName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDoctorName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblGender = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAgeYMD = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAge = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.DataGridViewPrescriptionDetails = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvTransKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPatientName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.txtPatientName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtFileNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSeries = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDob = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.DurationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPrescriptionDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.txtSeries = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtGender = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
            Me.CFlowLayout2.Size = New System.Drawing.Size(808, 583)
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
            Me.TableLayoutPanel1.Controls.Add(Me.txtGender, 6, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtSeries, 6, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtTransKey, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblTransKey, 3, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDoctorName, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblDoctorName, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblGender, 4, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAgeYMD, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAge, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPrescriptionDetails, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.lblTransactionDate, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPatientName, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpTransDate, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFileNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSeries, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDob, 3, 2)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(797, 538)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'txtTransKey
            '
            Me.txtTransKey.BackColor = System.Drawing.Color.White
            Me.txtTransKey.BegFindValue = Nothing
            Me.txtTransKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTransKey.ComputedValue = False
            Me.txtTransKey.CustomFormat = Nothing
            Me.txtTransKey.DataBoundControl = True
            Me.txtTransKey.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtTransKey.EditingMode = True
            Me.txtTransKey.EndFindValue = Nothing
            Me.txtTransKey.FieldDescription = Nothing
            Me.txtTransKey.FieldName = Nothing
            Me.txtTransKey.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTransKey.FindEnabled = False
            Me.txtTransKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTransKey.ForeColor = System.Drawing.Color.Black
            Me.txtTransKey.LinkedLabel = Me.lblTransKey
            Me.txtTransKey.Location = New System.Drawing.Point(698, 26)
            Me.txtTransKey.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTransKey.MaximumValue = Nothing
            Me.txtTransKey.MinimumValue = Nothing
            Me.txtTransKey.Name = "txtTransKey"
            Me.txtTransKey.OldValue = Nothing
            Me.txtTransKey.OverrideMaxLength = 0
            Me.txtTransKey.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTransKey.Size = New System.Drawing.Size(98, 23)
            Me.txtTransKey.TabIndex = 28
            Me.txtTransKey.Translatable = False
            '
            'lblTransKey
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblTransKey, 2)
            Me.lblTransKey.DisplayOnly = True
            Me.lblTransKey.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTransKey.EditingMode = False
            Me.lblTransKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransKey.Location = New System.Drawing.Point(331, 26)
            Me.lblTransKey.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransKey.Name = "lblTransKey"
            Me.lblTransKey.Size = New System.Drawing.Size(365, 23)
            Me.lblTransKey.TabIndex = 27
            Me.lblTransKey.Text = "Prescription No."
            Me.lblTransKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblTransKey.Translatable = True
            '
            'txtDoctorName
            '
            Me.txtDoctorName.BackColor = System.Drawing.Color.White
            Me.txtDoctorName.BegFindValue = Nothing
            Me.txtDoctorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtDoctorName, 3)
            Me.txtDoctorName.ComputedValue = False
            Me.txtDoctorName.CustomFormat = Nothing
            Me.txtDoctorName.DataBoundControl = True
            Me.txtDoctorName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDoctorName.EditingMode = True
            Me.txtDoctorName.EndFindValue = Nothing
            Me.txtDoctorName.FieldDescription = Nothing
            Me.txtDoctorName.FieldName = Nothing
            Me.txtDoctorName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDoctorName.FindEnabled = False
            Me.txtDoctorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDoctorName.ForeColor = System.Drawing.Color.Black
            Me.txtDoctorName.LinkedLabel = Nothing
            Me.txtDoctorName.Location = New System.Drawing.Point(186, 77)
            Me.txtDoctorName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDoctorName.MaximumValue = Nothing
            Me.txtDoctorName.MinimumValue = Nothing
            Me.txtDoctorName.Name = "txtDoctorName"
            Me.txtDoctorName.OldValue = Nothing
            Me.txtDoctorName.OverrideMaxLength = 0
            Me.txtDoctorName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorName.Size = New System.Drawing.Size(418, 23)
            Me.txtDoctorName.TabIndex = 26
            Me.txtDoctorName.Translatable = False
            '
            'lblDoctorName
            '
            Me.lblDoctorName.DisplayOnly = True
            Me.lblDoctorName.EditingMode = False
            Me.lblDoctorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDoctorName.Location = New System.Drawing.Point(1, 77)
            Me.lblDoctorName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDoctorName.Name = "lblDoctorName"
            Me.lblDoctorName.Size = New System.Drawing.Size(156, 18)
            Me.lblDoctorName.TabIndex = 25
            Me.lblDoctorName.Text = "Doctor Name"
            Me.lblDoctorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDoctorName.Translatable = True
            '
            'lblGender
            '
            Me.lblGender.DisplayOnly = True
            Me.lblGender.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblGender.EditingMode = False
            Me.lblGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGender.Location = New System.Drawing.Point(606, 51)
            Me.lblGender.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGender.Name = "lblGender"
            Me.lblGender.Size = New System.Drawing.Size(90, 24)
            Me.lblGender.TabIndex = 21
            Me.lblGender.Text = "Gender"
            Me.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblGender.Translatable = True
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
            Me.txtAgeYMD.Location = New System.Drawing.Point(288, 26)
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
            Me.CLabel2.Location = New System.Drawing.Point(1, 26)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(156, 23)
            Me.CLabel2.TabIndex = 19
            Me.CLabel2.Text = "Age"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
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
            Me.txtAge.Location = New System.Drawing.Point(186, 26)
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
            Me.DataGridViewPrescriptionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DurationDataGridViewTextBoxColumn, Me.dgvTransKey})
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
            Me.DataGridViewPrescriptionDetails.Location = New System.Drawing.Point(3, 104)
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
            'lblTransactionDate
            '
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.Location = New System.Drawing.Point(1, 51)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(133, 23)
            Me.lblTransactionDate.TabIndex = 13
            Me.lblTransactionDate.Text = "Transaction Date:"
            Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblTransactionDate.Translatable = True
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
            'dtpTransDate
            '
            Me.dtpTransDate.AutoSize = True
            Me.dtpTransDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpTransDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpTransDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.TableLayoutPanel1.SetColumnSpan(Me.dtpTransDate, 2)
            Me.dtpTransDate.DefaultValue = Nothing
            Me.dtpTransDate.DisplayOnly = False
            Me.dtpTransDate.DtpDefaultValue = Nothing
            Me.dtpTransDate.EditingMode = True
            Me.dtpTransDate.EditsAllowed = False
            Me.dtpTransDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransDate.LinkedLabel = Nothing
            Me.dtpTransDate.Location = New System.Drawing.Point(186, 51)
            Me.dtpTransDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransDate.Name = "dtpTransDate"
            Me.dtpTransDate.ReadOnlyDp = False
            Me.dtpTransDate.SecurityKey = Nothing
            Me.dtpTransDate.ShowLongDate = False
            Me.dtpTransDate.ShowTime = False
            Me.dtpTransDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpTransDate.TabIndex = 12
            Me.dtpTransDate.TargetCalendar = CType(resources.GetObject("dtpTransDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransDate.Translatable = False
            Me.dtpTransDate.Value = Nothing
            Me.dtpTransDate.ValueIsMandatory = False
            Me.dtpTransDate.ValueIsNullable = False
            '
            'txtPatientName
            '
            Me.txtPatientName.BackColor = System.Drawing.Color.White
            Me.txtPatientName.BegFindValue = Nothing
            Me.txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPatientName, 2)
            Me.txtPatientName.ComputedValue = False
            Me.txtPatientName.CustomFormat = Nothing
            Me.txtPatientName.DataBoundControl = True
            Me.txtPatientName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPatientName.EditingMode = True
            Me.txtPatientName.EndFindValue = Nothing
            Me.txtPatientName.FieldDescription = Nothing
            Me.txtPatientName.FieldName = Nothing
            Me.txtPatientName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPatientName.FindEnabled = False
            Me.txtPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPatientName.ForeColor = System.Drawing.Color.Black
            Me.txtPatientName.LinkedLabel = Nothing
            Me.txtPatientName.Location = New System.Drawing.Point(288, 1)
            Me.txtPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientName.MaximumValue = Nothing
            Me.txtPatientName.MinimumValue = Nothing
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.OldValue = Nothing
            Me.txtPatientName.OverrideMaxLength = 0
            Me.txtPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientName.Size = New System.Drawing.Size(316, 23)
            Me.txtPatientName.TabIndex = 15
            Me.txtPatientName.Translatable = False
            '
            'txtFileNo
            '
            Me.txtFileNo.BackColor = System.Drawing.Color.White
            Me.txtFileNo.BegFindValue = Nothing
            Me.txtFileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFileNo.ComputedValue = False
            Me.txtFileNo.CustomFormat = Nothing
            Me.txtFileNo.DataBoundControl = True
            Me.txtFileNo.EditingMode = True
            Me.txtFileNo.EndFindValue = Nothing
            Me.txtFileNo.FieldDescription = Nothing
            Me.txtFileNo.FieldName = Nothing
            Me.txtFileNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtFileNo.FindEnabled = False
            Me.txtFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtFileNo.ForeColor = System.Drawing.Color.Black
            Me.txtFileNo.LinkedLabel = Nothing
            Me.txtFileNo.Location = New System.Drawing.Point(186, 1)
            Me.txtFileNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtFileNo.MaximumValue = Nothing
            Me.txtFileNo.MinimumValue = Nothing
            Me.txtFileNo.Name = "txtFileNo"
            Me.txtFileNo.OldValue = Nothing
            Me.txtFileNo.OverrideMaxLength = 0
            Me.txtFileNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtFileNo.Size = New System.Drawing.Size(100, 23)
            Me.txtFileNo.TabIndex = 16
            Me.txtFileNo.Translatable = False
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
            Me.lblSeries.Size = New System.Drawing.Size(90, 23)
            Me.lblSeries.TabIndex = 23
            Me.lblSeries.Text = "Series"
            Me.lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblSeries.Translatable = True
            '
            'txtDob
            '
            Me.txtDob.BackColor = System.Drawing.Color.White
            Me.txtDob.BegFindValue = Nothing
            Me.txtDob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDob.ComputedValue = False
            Me.txtDob.CustomFormat = Nothing
            Me.txtDob.DataBoundControl = True
            Me.txtDob.EditingMode = True
            Me.txtDob.EndFindValue = Nothing
            Me.txtDob.FieldDescription = Nothing
            Me.txtDob.FieldName = Nothing
            Me.txtDob.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDob.FindEnabled = False
            Me.txtDob.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDob.ForeColor = System.Drawing.Color.Black
            Me.txtDob.LinkedLabel = Nothing
            Me.txtDob.Location = New System.Drawing.Point(331, 51)
            Me.txtDob.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDob.MaximumValue = Nothing
            Me.txtDob.MinimumValue = Nothing
            Me.txtDob.Name = "txtDob"
            Me.txtDob.OldValue = Nothing
            Me.txtDob.OverrideMaxLength = 0
            Me.txtDob.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDob.Size = New System.Drawing.Size(100, 23)
            Me.txtDob.TabIndex = 18
            Me.txtDob.Translatable = False
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
            'txtSeries
            '
            Me.txtSeries.BackColor = System.Drawing.Color.White
            Me.txtSeries.BegFindValue = Nothing
            Me.txtSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSeries.ComputedValue = False
            Me.txtSeries.CustomFormat = Nothing
            Me.txtSeries.DataBoundControl = True
            Me.txtSeries.EditingMode = True
            Me.txtSeries.EndFindValue = Nothing
            Me.txtSeries.FieldDescription = Nothing
            Me.txtSeries.FieldName = Nothing
            Me.txtSeries.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSeries.FindEnabled = False
            Me.txtSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSeries.ForeColor = System.Drawing.Color.Black
            Me.txtSeries.LinkedLabel = Nothing
            Me.txtSeries.Location = New System.Drawing.Point(698, 1)
            Me.txtSeries.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSeries.MaximumValue = Nothing
            Me.txtSeries.MinimumValue = Nothing
            Me.txtSeries.Name = "txtSeries"
            Me.txtSeries.OldValue = Nothing
            Me.txtSeries.OverrideMaxLength = 0
            Me.txtSeries.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSeries.Size = New System.Drawing.Size(98, 23)
            Me.txtSeries.TabIndex = 29
            Me.txtSeries.Translatable = False
            '
            'txtGender
            '
            Me.txtGender.BackColor = System.Drawing.Color.White
            Me.txtGender.BegFindValue = Nothing
            Me.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGender.ComputedValue = False
            Me.txtGender.CustomFormat = Nothing
            Me.txtGender.DataBoundControl = True
            Me.txtGender.EditingMode = True
            Me.txtGender.EndFindValue = Nothing
            Me.txtGender.FieldDescription = Nothing
            Me.txtGender.FieldName = Nothing
            Me.txtGender.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGender.FindEnabled = False
            Me.txtGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGender.ForeColor = System.Drawing.Color.Black
            Me.txtGender.LinkedLabel = Nothing
            Me.txtGender.Location = New System.Drawing.Point(698, 51)
            Me.txtGender.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGender.MaximumValue = Nothing
            Me.txtGender.MinimumValue = Nothing
            Me.txtGender.Name = "txtGender"
            Me.txtGender.OldValue = Nothing
            Me.txtGender.OverrideMaxLength = 0
            Me.txtGender.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGender.Size = New System.Drawing.Size(98, 23)
            Me.txtGender.TabIndex = 30
            Me.txtGender.Translatable = False
            '
            'PrescriptionForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(808, 636)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Name = "PrescriptionForm"
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
        Friend WithEvents lblTransactionDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPatientName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpTransDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents TokenDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents StatusDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents FileNoDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents NameDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents InvTypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtPatientName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtFileNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblGender As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtAgeYMD As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDob As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtAge As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblSeries As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents ItemNameEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DosageEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DurationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvTransKey As DataGridViewTextBoxColumn
        Friend WithEvents txtDoctorName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblDoctorName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtTransKey As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblTransKey As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtGender As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtSeries As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace