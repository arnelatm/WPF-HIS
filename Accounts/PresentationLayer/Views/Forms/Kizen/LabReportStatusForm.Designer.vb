Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class LabReportStatusForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LabReportStatusForm))
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtDoctorName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtAge = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPatientName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel6 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNationality = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtGender = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel8 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtMRN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.dtpInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnRefresh
            '
            Me.btnRefresh.DesignerSelected = False
            Me.btnRefresh.ImageIndex = 0
            Me.btnRefresh.Location = New System.Drawing.Point(549, 78)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.OriginalImageName = Nothing
            Me.btnRefresh.SecurityKey = ""
            Me.btnRefresh.Size = New System.Drawing.Size(90, 21)
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
            Me.CFlowLayout2.AutoSize = True
            Me.CFlowLayout2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 55)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(767, 318)
            Me.CFlowLayout2.TabIndex = 5
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.ColumnCount = 6
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.txtDoctorName, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.btnRefresh, 5, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAge, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtInvoiceNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel6, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel7, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtNationality, 5, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtGender, 3, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel8, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtMRN, 3, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpInvoiceDate, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 2, 3)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 6
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(755, 305)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'txtDoctorName
            '
            Me.txtDoctorName.BackColor = System.Drawing.Color.White
            Me.txtDoctorName.BegFindValue = Nothing
            Me.txtDoctorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtDoctorName, 5)
            Me.txtDoctorName.ComputedValue = False
            Me.txtDoctorName.CustomFormat = Nothing
            Me.txtDoctorName.DataBoundControl = True
            Me.txtDoctorName.DisplayOnly = True
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
            Me.txtDoctorName.Location = New System.Drawing.Point(113, 51)
            Me.txtDoctorName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDoctorName.MaximumValue = Nothing
            Me.txtDoctorName.MinimumValue = Nothing
            Me.txtDoctorName.Name = "txtDoctorName"
            Me.txtDoctorName.OldValue = Nothing
            Me.txtDoctorName.OverrideMaxLength = 0
            Me.txtDoctorName.ReadOnly = True
            Me.txtDoctorName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorName.Size = New System.Drawing.Size(643, 23)
            Me.txtDoctorName.TabIndex = 24
            Me.txtDoctorName.Translatable = False
            '
            'txtAge
            '
            Me.txtAge.BackColor = System.Drawing.Color.White
            Me.txtAge.BegFindValue = Nothing
            Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAge.ComputedValue = False
            Me.txtAge.CustomFormat = Nothing
            Me.txtAge.DataBoundControl = True
            Me.txtAge.DisplayOnly = True
            Me.txtAge.EditingMode = True
            Me.txtAge.EndFindValue = Nothing
            Me.txtAge.FieldDescription = Nothing
            Me.txtAge.FieldName = Nothing
            Me.txtAge.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtAge.FindEnabled = False
            Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAge.ForeColor = System.Drawing.Color.Black
            Me.txtAge.LinkedLabel = Nothing
            Me.txtAge.Location = New System.Drawing.Point(113, 26)
            Me.txtAge.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAge.MaximumValue = Nothing
            Me.txtAge.MinimumValue = Nothing
            Me.txtAge.Name = "txtAge"
            Me.txtAge.OldValue = Nothing
            Me.txtAge.OverrideMaxLength = 0
            Me.txtAge.ReadOnly = True
            Me.txtAge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAge.Size = New System.Drawing.Size(162, 23)
            Me.txtAge.TabIndex = 21
            Me.txtAge.Translatable = False
            '
            'CLabel4
            '
            Me.CLabel4.AutoSize = True
            Me.CLabel4.BackColor = System.Drawing.Color.Transparent
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel4.Location = New System.Drawing.Point(1, 1)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(110, 17)
            Me.CLabel4.TabIndex = 19
            Me.CLabel4.Text = "Invoice Number:"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel4.Translatable = True
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(1, 26)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(37, 17)
            Me.CLabel2.TabIndex = 15
            Me.CLabel2.Text = "Age:"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(277, 1)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(93, 17)
            Me.CLabel3.TabIndex = 16
            Me.CLabel3.Text = "Patient Name"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'txtPatientName
            '
            Me.txtPatientName.BackColor = System.Drawing.Color.White
            Me.txtPatientName.BegFindValue = Nothing
            Me.txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPatientName, 3)
            Me.txtPatientName.ComputedValue = False
            Me.txtPatientName.CustomFormat = Nothing
            Me.txtPatientName.DataBoundControl = True
            Me.txtPatientName.DisplayOnly = True
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
            Me.txtPatientName.Location = New System.Drawing.Point(372, 1)
            Me.txtPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientName.MaximumValue = Nothing
            Me.txtPatientName.MinimumValue = Nothing
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.OldValue = Nothing
            Me.txtPatientName.OverrideMaxLength = 0
            Me.txtPatientName.ReadOnly = True
            Me.txtPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientName.Size = New System.Drawing.Size(384, 23)
            Me.txtPatientName.TabIndex = 18
            Me.txtPatientName.Translatable = False
            '
            'txtInvoiceNo
            '
            Me.txtInvoiceNo.BackColor = System.Drawing.Color.White
            Me.txtInvoiceNo.BegFindValue = Nothing
            Me.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInvoiceNo.ComputedValue = False
            Me.txtInvoiceNo.CustomFormat = Nothing
            Me.txtInvoiceNo.DataBoundControl = True
            Me.txtInvoiceNo.EditingMode = True
            Me.txtInvoiceNo.EndFindValue = Nothing
            Me.txtInvoiceNo.FieldDescription = Nothing
            Me.txtInvoiceNo.FieldName = Nothing
            Me.txtInvoiceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtInvoiceNo.FindEnabled = False
            Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtInvoiceNo.ForeColor = System.Drawing.Color.Black
            Me.txtInvoiceNo.LinkedLabel = Nothing
            Me.txtInvoiceNo.Location = New System.Drawing.Point(113, 1)
            Me.txtInvoiceNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtInvoiceNo.MaximumValue = Nothing
            Me.txtInvoiceNo.MinimumValue = Nothing
            Me.txtInvoiceNo.Name = "txtInvoiceNo"
            Me.txtInvoiceNo.OldValue = Nothing
            Me.txtInvoiceNo.OverrideMaxLength = 0
            Me.txtInvoiceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtInvoiceNo.Size = New System.Drawing.Size(162, 23)
            Me.txtInvoiceNo.TabIndex = 17
            Me.txtInvoiceNo.Translatable = False
            '
            'CLabel1
            '
            Me.CLabel1.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 77)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(110, 23)
            Me.CLabel1.TabIndex = 13
            Me.CLabel1.Text = "Invoice Date:"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'CLabel6
            '
            Me.CLabel6.AutoSize = True
            Me.CLabel6.BackColor = System.Drawing.Color.Transparent
            Me.CLabel6.DisplayOnly = True
            Me.CLabel6.EditingMode = False
            Me.CLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel6.Location = New System.Drawing.Point(1, 51)
            Me.CLabel6.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel6.Name = "CLabel6"
            Me.CLabel6.Size = New System.Drawing.Size(95, 17)
            Me.CLabel6.TabIndex = 23
            Me.CLabel6.Text = "Doctor Name:"
            Me.CLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel6.Translatable = True
            '
            'CLabel7
            '
            Me.CLabel7.AutoSize = True
            Me.CLabel7.BackColor = System.Drawing.Color.Transparent
            Me.CLabel7.DisplayOnly = True
            Me.CLabel7.EditingMode = False
            Me.CLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel7.Location = New System.Drawing.Point(467, 26)
            Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel7.Name = "CLabel7"
            Me.CLabel7.Size = New System.Drawing.Size(78, 17)
            Me.CLabel7.TabIndex = 25
            Me.CLabel7.Text = "Nationality:"
            Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel7.Translatable = True
            '
            'txtNationality
            '
            Me.txtNationality.BackColor = System.Drawing.Color.White
            Me.txtNationality.BegFindValue = Nothing
            Me.txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNationality.ComputedValue = False
            Me.txtNationality.CustomFormat = Nothing
            Me.txtNationality.DataBoundControl = True
            Me.txtNationality.DisplayOnly = True
            Me.txtNationality.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtNationality.EditingMode = True
            Me.txtNationality.EndFindValue = Nothing
            Me.txtNationality.FieldDescription = Nothing
            Me.txtNationality.FieldName = Nothing
            Me.txtNationality.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNationality.FindEnabled = False
            Me.txtNationality.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNationality.ForeColor = System.Drawing.Color.Black
            Me.txtNationality.LinkedLabel = Nothing
            Me.txtNationality.Location = New System.Drawing.Point(547, 26)
            Me.txtNationality.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNationality.MaximumValue = Nothing
            Me.txtNationality.MinimumValue = Nothing
            Me.txtNationality.Name = "txtNationality"
            Me.txtNationality.OldValue = Nothing
            Me.txtNationality.OverrideMaxLength = 0
            Me.txtNationality.ReadOnly = True
            Me.txtNationality.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNationality.Size = New System.Drawing.Size(209, 23)
            Me.txtNationality.TabIndex = 26
            Me.txtNationality.Translatable = False
            '
            'txtGender
            '
            Me.txtGender.BackColor = System.Drawing.Color.White
            Me.txtGender.BegFindValue = Nothing
            Me.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGender.ComputedValue = False
            Me.txtGender.CustomFormat = Nothing
            Me.txtGender.DataBoundControl = True
            Me.txtGender.DisplayOnly = True
            Me.txtGender.EditingMode = True
            Me.txtGender.EndFindValue = Nothing
            Me.txtGender.FieldDescription = Nothing
            Me.txtGender.FieldName = Nothing
            Me.txtGender.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGender.FindEnabled = False
            Me.txtGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGender.ForeColor = System.Drawing.Color.Black
            Me.txtGender.LinkedLabel = Nothing
            Me.txtGender.Location = New System.Drawing.Point(372, 76)
            Me.txtGender.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGender.MaximumValue = Nothing
            Me.txtGender.MinimumValue = Nothing
            Me.txtGender.Name = "txtGender"
            Me.txtGender.OldValue = Nothing
            Me.txtGender.OverrideMaxLength = 0
            Me.txtGender.ReadOnly = True
            Me.txtGender.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGender.Size = New System.Drawing.Size(93, 23)
            Me.txtGender.TabIndex = 22
            Me.txtGender.Translatable = False
            '
            'CLabel8
            '
            Me.CLabel8.AutoSize = True
            Me.CLabel8.BackColor = System.Drawing.Color.Transparent
            Me.CLabel8.DisplayOnly = True
            Me.CLabel8.EditingMode = False
            Me.CLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel8.Location = New System.Drawing.Point(277, 26)
            Me.CLabel8.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel8.Name = "CLabel8"
            Me.CLabel8.Size = New System.Drawing.Size(39, 17)
            Me.CLabel8.TabIndex = 27
            Me.CLabel8.Text = "MRN"
            Me.CLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel8.Translatable = True
            '
            'txtMRN
            '
            Me.txtMRN.BackColor = System.Drawing.Color.White
            Me.txtMRN.BegFindValue = Nothing
            Me.txtMRN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMRN.ComputedValue = False
            Me.txtMRN.CustomFormat = Nothing
            Me.txtMRN.DataBoundControl = True
            Me.txtMRN.DisplayOnly = True
            Me.txtMRN.EditingMode = True
            Me.txtMRN.EndFindValue = Nothing
            Me.txtMRN.FieldDescription = Nothing
            Me.txtMRN.FieldName = Nothing
            Me.txtMRN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtMRN.FindEnabled = False
            Me.txtMRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtMRN.ForeColor = System.Drawing.Color.Black
            Me.txtMRN.LinkedLabel = Nothing
            Me.txtMRN.Location = New System.Drawing.Point(372, 26)
            Me.txtMRN.Margin = New System.Windows.Forms.Padding(1)
            Me.txtMRN.MaximumValue = Nothing
            Me.txtMRN.MinimumValue = Nothing
            Me.txtMRN.Name = "txtMRN"
            Me.txtMRN.OldValue = Nothing
            Me.txtMRN.OverrideMaxLength = 0
            Me.txtMRN.ReadOnly = True
            Me.txtMRN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMRN.Size = New System.Drawing.Size(93, 23)
            Me.txtMRN.TabIndex = 28
            Me.txtMRN.Translatable = False
            '
            'dtpInvoiceDate
            '
            Me.dtpInvoiceDate.AutoSize = True
            Me.dtpInvoiceDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpInvoiceDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpInvoiceDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpInvoiceDate.DefaultValue = Nothing
            Me.dtpInvoiceDate.DisplayOnly = True
            Me.dtpInvoiceDate.DtpDefaultValue = Nothing
            Me.dtpInvoiceDate.EditingMode = True
            Me.dtpInvoiceDate.EditsAllowed = False
            Me.dtpInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.dtpInvoiceDate.LinkedLabel = Nothing
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(113, 76)
            Me.dtpInvoiceDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
            Me.dtpInvoiceDate.ReadOnlyDp = True
            Me.dtpInvoiceDate.SecurityKey = Nothing
            Me.dtpInvoiceDate.ShowLongDate = False
            Me.dtpInvoiceDate.ShowTime = False
            Me.dtpInvoiceDate.Size = New System.Drawing.Size(97, 23)
            Me.dtpInvoiceDate.TabIndex = 12
            Me.dtpInvoiceDate.TargetCalendar = CType(resources.GetObject("dtpInvoiceDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpInvoiceDate.Translatable = False
            Me.dtpInvoiceDate.Value = Nothing
            Me.dtpInvoiceDate.ValueIsMandatory = False
            Me.dtpInvoiceDate.ValueIsNullable = False
            '
            'CLabel5
            '
            Me.CLabel5.AutoSize = True
            Me.CLabel5.BackColor = System.Drawing.Color.Transparent
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.Location = New System.Drawing.Point(277, 76)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(60, 17)
            Me.CLabel5.TabIndex = 20
            Me.CLabel5.Text = "Gender:"
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
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
            'LabReportStatusForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(767, 373)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Name = "LabReportStatusForm"
            Me.Text = "Invoice Notes Editor"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents btnRefresh As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents imgList As ImageList
        Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpInvoiceDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel4 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtInvoiceNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtPatientName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtGender As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtAge As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDoctorName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel6 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel7 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNationality As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel8 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtMRN As Libraries.CBaseControlsLibrary.CTextBox

    End Class
End Namespace