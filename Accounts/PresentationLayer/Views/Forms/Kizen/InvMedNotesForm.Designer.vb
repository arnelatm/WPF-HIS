Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InvMedNotesForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvMedNotesForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtDoctorName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtGender = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtAge = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpInvoiceDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPatientName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtInvoiceNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel6 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.DataGridViewInvMedNotesDetails = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SeqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ItemCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ItemNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.NotesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsInvMedNotesDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewInvMedNotesDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsInvMedNotesDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnRefresh
            '
            Me.btnRefresh.DesignerSelected = False
            Me.btnRefresh.ImageIndex = 0
            Me.btnRefresh.Location = New System.Drawing.Point(508, 78)
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
            Me.CFlowLayout2.Size = New System.Drawing.Size(754, 323)
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
            Me.TableLayoutPanel1.Controls.Add(Me.txtGender, 3, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtAge, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpInvoiceDate, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtInvoiceNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel6, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewInvMedNotesDetails, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel7, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CTextBox1, 5, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.btnRefresh, 5, 3)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 6
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(748, 305)
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
            Me.txtDoctorName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorName.Size = New System.Drawing.Size(634, 23)
            Me.txtDoctorName.TabIndex = 24
            Me.txtDoctorName.Translatable = False
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
            Me.txtGender.Location = New System.Drawing.Point(348, 26)
            Me.txtGender.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGender.MaximumValue = Nothing
            Me.txtGender.MinimumValue = Nothing
            Me.txtGender.Name = "txtGender"
            Me.txtGender.OldValue = Nothing
            Me.txtGender.OverrideMaxLength = 0
            Me.txtGender.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGender.Size = New System.Drawing.Size(76, 23)
            Me.txtGender.TabIndex = 22
            Me.txtGender.Translatable = False
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
            Me.txtAge.Location = New System.Drawing.Point(113, 26)
            Me.txtAge.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAge.MaximumValue = Nothing
            Me.txtAge.MinimumValue = Nothing
            Me.txtAge.Name = "txtAge"
            Me.txtAge.OldValue = Nothing
            Me.txtAge.OverrideMaxLength = 0
            Me.txtAge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAge.Size = New System.Drawing.Size(138, 23)
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
            'dtpInvoiceDate
            '
            Me.dtpInvoiceDate.AutoSize = True
            Me.dtpInvoiceDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpInvoiceDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpInvoiceDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.TableLayoutPanel1.SetColumnSpan(Me.dtpInvoiceDate, 2)
            Me.dtpInvoiceDate.DefaultValue = Nothing
            Me.dtpInvoiceDate.DisplayOnly = False
            Me.dtpInvoiceDate.DtpDefaultValue = Nothing
            Me.dtpInvoiceDate.EditingMode = True
            Me.dtpInvoiceDate.EditsAllowed = False
            Me.dtpInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.dtpInvoiceDate.LinkedLabel = Nothing
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(113, 76)
            Me.dtpInvoiceDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
            Me.dtpInvoiceDate.ReadOnlyDp = False
            Me.dtpInvoiceDate.SecurityKey = Nothing
            Me.dtpInvoiceDate.ShowLongDate = False
            Me.dtpInvoiceDate.ShowTime = False
            Me.dtpInvoiceDate.Size = New System.Drawing.Size(118, 23)
            Me.dtpInvoiceDate.TabIndex = 12
            Me.dtpInvoiceDate.TargetCalendar = CType(resources.GetObject("dtpInvoiceDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpInvoiceDate.Translatable = False
            Me.dtpInvoiceDate.Value = Nothing
            Me.dtpInvoiceDate.ValueIsMandatory = False
            Me.dtpInvoiceDate.ValueIsNullable = False
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
            'CLabel5
            '
            Me.CLabel5.AutoSize = True
            Me.CLabel5.BackColor = System.Drawing.Color.Transparent
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.Location = New System.Drawing.Point(253, 26)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(60, 17)
            Me.CLabel5.TabIndex = 20
            Me.CLabel5.Text = "Gender:"
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(253, 1)
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
            Me.txtPatientName.Location = New System.Drawing.Point(348, 1)
            Me.txtPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientName.MaximumValue = Nothing
            Me.txtPatientName.MinimumValue = Nothing
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.OldValue = Nothing
            Me.txtPatientName.OverrideMaxLength = 0
            Me.txtPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientName.Size = New System.Drawing.Size(399, 23)
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
            Me.txtInvoiceNo.Size = New System.Drawing.Size(138, 23)
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
            'DataGridViewInvMedNotesDetails
            '
            Me.DataGridViewInvMedNotesDetails.AllowUserToAddRows = False
            Me.DataGridViewInvMedNotesDetails.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite
            Me.DataGridViewInvMedNotesDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewInvMedNotesDetails.AutoGenerateColumns = False
            Me.DataGridViewInvMedNotesDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
            Me.DataGridViewInvMedNotesDetails.BegFindValue = Nothing
            Me.DataGridViewInvMedNotesDetails.Cached = False
            Me.DataGridViewInvMedNotesDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewInvMedNotesDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.SeqDataGridViewTextBoxColumn, Me.ItemCodeDataGridViewTextBoxColumn, Me.ItemNameDataGridViewTextBoxColumn, Me.NotesDataGridViewTextBoxColumn})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewInvMedNotesDetails, 6)
            Me.DataGridViewInvMedNotesDetails.DataFilter = Nothing
            Me.DataGridViewInvMedNotesDetails.DataSource = Me.bsInvMedNotesDetails
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewInvMedNotesDetails.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewInvMedNotesDetails.DgvFooter = Nothing
            Me.DataGridViewInvMedNotesDetails.DisplayOnly = False
            Me.DataGridViewInvMedNotesDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewInvMedNotesDetails.Ea = Nothing
            Me.DataGridViewInvMedNotesDetails.EditingMode = False
            Me.DataGridViewInvMedNotesDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewInvMedNotesDetails.EndFindValue = Nothing
            Me.DataGridViewInvMedNotesDetails.FieldDescription = Nothing
            Me.DataGridViewInvMedNotesDetails.FieldName = Nothing
            Me.DataGridViewInvMedNotesDetails.FieldsDictionary = Nothing
            Me.DataGridViewInvMedNotesDetails.FindColumnNo = CType(0, Short)
            Me.DataGridViewInvMedNotesDetails.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewInvMedNotesDetails.FindEnabled = False
            Me.DataGridViewInvMedNotesDetails.FirstRowDeletionEnabled = True
            Me.DataGridViewInvMedNotesDetails.FirstRowInsertionEnabled = True
            Me.DataGridViewInvMedNotesDetails.IgnoreCase = False
            Me.DataGridViewInvMedNotesDetails.IsDirty = False
            Me.DataGridViewInvMedNotesDetails.Location = New System.Drawing.Point(3, 105)
            Me.DataGridViewInvMedNotesDetails.Name = "DataGridViewInvMedNotesDetails"
            Me.DataGridViewInvMedNotesDetails.OldCellValue = Nothing
            Me.DataGridViewInvMedNotesDetails.ReadOnly = True
            Me.DataGridViewInvMedNotesDetails.RowHeadersWidth = 12
            Me.DataGridViewInvMedNotesDetails.Searchable = True
            Me.DataGridViewInvMedNotesDetails.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewInvMedNotesDetails.SecurityKey = ""
            Me.DataGridViewInvMedNotesDetails.SequenceColumn = "dgvSequence"
            Me.DataGridViewInvMedNotesDetails.SequenceFieldName = "Sequence"
            Me.DataGridViewInvMedNotesDetails.ShowFooter = False
            Me.DataGridViewInvMedNotesDetails.Size = New System.Drawing.Size(742, 200)
            Me.DataGridViewInvMedNotesDetails.TabIndex = 14
            Me.DataGridViewInvMedNotesDetails.Translatable = True
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "IdNo"
            Me.DataGridViewTextBoxColumn2.HeaderText = "IdNo"
            Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            Me.DataGridViewTextBoxColumn2.Visible = False
            Me.DataGridViewTextBoxColumn2.Width = 36
            '
            'SeqDataGridViewTextBoxColumn
            '
            Me.SeqDataGridViewTextBoxColumn.DataPropertyName = "Seq"
            Me.SeqDataGridViewTextBoxColumn.HeaderText = "Seq"
            Me.SeqDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.SeqDataGridViewTextBoxColumn.Name = "SeqDataGridViewTextBoxColumn"
            Me.SeqDataGridViewTextBoxColumn.ReadOnly = True
            Me.SeqDataGridViewTextBoxColumn.Width = 51
            '
            'ItemCodeDataGridViewTextBoxColumn
            '
            Me.ItemCodeDataGridViewTextBoxColumn.DataPropertyName = "ItemCode"
            Me.ItemCodeDataGridViewTextBoxColumn.HeaderText = "ItemCode"
            Me.ItemCodeDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.ItemCodeDataGridViewTextBoxColumn.Name = "ItemCodeDataGridViewTextBoxColumn"
            Me.ItemCodeDataGridViewTextBoxColumn.ReadOnly = True
            Me.ItemCodeDataGridViewTextBoxColumn.Width = 77
            '
            'ItemNameDataGridViewTextBoxColumn
            '
            Me.ItemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName"
            Me.ItemNameDataGridViewTextBoxColumn.HeaderText = "ItemName"
            Me.ItemNameDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.ItemNameDataGridViewTextBoxColumn.Name = "ItemNameDataGridViewTextBoxColumn"
            Me.ItemNameDataGridViewTextBoxColumn.ReadOnly = True
            Me.ItemNameDataGridViewTextBoxColumn.Width = 80
            '
            'NotesDataGridViewTextBoxColumn
            '
            Me.NotesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.NotesDataGridViewTextBoxColumn.DataPropertyName = "Notes"
            Me.NotesDataGridViewTextBoxColumn.HeaderText = "Notes"
            Me.NotesDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.NotesDataGridViewTextBoxColumn.Name = "NotesDataGridViewTextBoxColumn"
            Me.NotesDataGridViewTextBoxColumn.ReadOnly = True
            '
            'bsInvMedNotesDetails
            '
            Me.bsInvMedNotesDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.InvMedNotesDetailModel)
            '
            'CLabel7
            '
            Me.CLabel7.AutoSize = True
            Me.CLabel7.BackColor = System.Drawing.Color.Transparent
            Me.CLabel7.DisplayOnly = True
            Me.CLabel7.EditingMode = False
            Me.CLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel7.Location = New System.Drawing.Point(426, 26)
            Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel7.Name = "CLabel7"
            Me.CLabel7.Size = New System.Drawing.Size(78, 17)
            Me.CLabel7.TabIndex = 25
            Me.CLabel7.Text = "Nationality:"
            Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel7.Translatable = True
            '
            'CTextBox1
            '
            Me.CTextBox1.BackColor = System.Drawing.Color.White
            Me.CTextBox1.BegFindValue = Nothing
            Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox1.ComputedValue = False
            Me.CTextBox1.CustomFormat = Nothing
            Me.CTextBox1.DataBoundControl = True
            Me.CTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CTextBox1.EditingMode = True
            Me.CTextBox1.EndFindValue = Nothing
            Me.CTextBox1.FieldDescription = Nothing
            Me.CTextBox1.FieldName = Nothing
            Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBox1.FindEnabled = False
            Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox1.ForeColor = System.Drawing.Color.Black
            Me.CTextBox1.LinkedLabel = Nothing
            Me.CTextBox1.Location = New System.Drawing.Point(506, 26)
            Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox1.MaximumValue = Nothing
            Me.CTextBox1.MinimumValue = Nothing
            Me.CTextBox1.Name = "CTextBox1"
            Me.CTextBox1.OldValue = Nothing
            Me.CTextBox1.OverrideMaxLength = 0
            Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBox1.Size = New System.Drawing.Size(241, 23)
            Me.CTextBox1.TabIndex = 26
            Me.CTextBox1.Translatable = False
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
            'InvMedNotesForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(754, 378)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Name = "InvMedNotesForm"
            Me.Text = "Diagnostic Result Entry Form"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewInvMedNotesDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsInvMedNotesDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsInvMedNotesDetails As BindingSource
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
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpInvoiceDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewInvMedNotesDetails As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents TakenTimeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents LabNoDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents PatientNameDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents IqamaNoDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents NationalityDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents StoolDataGridViewCheckBoxColumn As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents UrineDataGridViewCheckBoxColumn As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents RbsDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents TakenByDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvUrine As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents dgvStool As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents dgvRBS As Libraries.CBaseControlsLibrary.CDgvDecimalColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvLabNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvPatientName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvNationality As Libraries.CBaseControlsLibrary.CDgvTextColumn
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
        Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
        Friend WithEvents SeqDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ItemCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ItemNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents NotesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CLabel7 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace