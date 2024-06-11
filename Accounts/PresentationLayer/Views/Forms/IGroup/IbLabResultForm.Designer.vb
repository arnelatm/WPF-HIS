Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class IbLabResultForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IbLabResultForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.DataGridViewIbLabResultDetails = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkIndeterminate = New System.Windows.Forms.CheckBox()
            Me.chkNegative = New System.Windows.Forms.CheckBox()
            Me.CheckBox1 = New System.Windows.Forms.CheckBox()
            Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.bsIbLabResultDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.Sequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvLabNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvPatientName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvNationality = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvProfession = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvIqamaNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvPassportNumber = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvGender = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvClinical = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvXRay = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvTBSputum = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvHIVEliza = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvHOVEliza = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvHBSAgEliza = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvMalaria = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvVDRL = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvWidal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvPregnancy = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvBilharziasisUrine = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvBilharziasisStool = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvShigella = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.dgvCholera = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewIbLabResultDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            CType(Me.bsIbLabResultDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnRefresh
            '
            Me.btnRefresh.DesignerSelected = False
            Me.btnRefresh.ImageIndex = 0
            Me.btnRefresh.Location = New System.Drawing.Point(335, 4)
            Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
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
            Me.CFlowLayout2.AutoSize = True
            Me.CFlowLayout2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout2.Controls.Add(Me.CFlowLayout1)
            Me.CFlowLayout2.Controls.Add(Me.CButton1)
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 55)
            Me.CFlowLayout2.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(1370, 645)
            Me.CFlowLayout2.TabIndex = 5
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpTransactionDate, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.btnRefresh, 3, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewIbLabResultDetails, 1, 2)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 4
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(1431, 572)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 1)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(208, 28)
            Me.CLabel1.TabIndex = 13
            Me.CLabel1.Text = "Transaction Date:"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(211, 1)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(119, 23)
            Me.dtpTransactionDate.TabIndex = 12
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'DataGridViewIbLabResultDetails
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite
            Me.DataGridViewIbLabResultDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewIbLabResultDetails.AutoGenerateColumns = False
            Me.DataGridViewIbLabResultDetails.BegFindValue = Nothing
            Me.DataGridViewIbLabResultDetails.Cached = False
            Me.DataGridViewIbLabResultDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewIbLabResultDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sequence, Me.dgvLabNo, Me.dgvPatientName, Me.dgvNationality, Me.dgvProfession, Me.dgvIqamaNo, Me.dgvPassportNumber, Me.dgvGender, Me.dgvClinical, Me.dgvXRay, Me.dgvTBSputum, Me.dgvHIVEliza, Me.dgvHOVEliza, Me.dgvHBSAgEliza, Me.dgvMalaria, Me.dgvVDRL, Me.dgvWidal, Me.dgvPregnancy, Me.dgvBilharziasisUrine, Me.dgvBilharziasisStool, Me.dgvShigella, Me.dgvCholera})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewIbLabResultDetails, 4)
            Me.DataGridViewIbLabResultDetails.DataFilter = Nothing
            Me.DataGridViewIbLabResultDetails.DataSource = Me.bsIbLabResultDetails
            DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle24.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewIbLabResultDetails.DefaultCellStyle = DataGridViewCellStyle24
            Me.DataGridViewIbLabResultDetails.DgvFooter = Nothing
            Me.DataGridViewIbLabResultDetails.DisplayOnly = False
            Me.DataGridViewIbLabResultDetails.Ea = Nothing
            Me.DataGridViewIbLabResultDetails.EditingMode = False
            Me.DataGridViewIbLabResultDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewIbLabResultDetails.EndFindValue = Nothing
            Me.DataGridViewIbLabResultDetails.FieldDescription = Nothing
            Me.DataGridViewIbLabResultDetails.FieldName = Nothing
            Me.DataGridViewIbLabResultDetails.FieldsDictionary = Nothing
            Me.DataGridViewIbLabResultDetails.FindColumnNo = CType(0, Short)
            Me.DataGridViewIbLabResultDetails.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewIbLabResultDetails.FindEnabled = False
            Me.DataGridViewIbLabResultDetails.FirstRowDeletionEnabled = True
            Me.DataGridViewIbLabResultDetails.FirstRowInsertionEnabled = True
            Me.DataGridViewIbLabResultDetails.IgnoreCase = False
            Me.DataGridViewIbLabResultDetails.IsDirty = False
            Me.DataGridViewIbLabResultDetails.Location = New System.Drawing.Point(4, 43)
            Me.DataGridViewIbLabResultDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewIbLabResultDetails.Name = "DataGridViewIbLabResultDetails"
            Me.DataGridViewIbLabResultDetails.OldCellValue = Nothing
            Me.DataGridViewIbLabResultDetails.ReadOnly = True
            Me.DataGridViewIbLabResultDetails.RowHeadersWidth = 51
            Me.DataGridViewIbLabResultDetails.Searchable = True
            Me.DataGridViewIbLabResultDetails.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewIbLabResultDetails.SecurityKey = ""
            Me.DataGridViewIbLabResultDetails.SequenceColumn = "dgvSequence"
            Me.DataGridViewIbLabResultDetails.SequenceFieldName = "Sequence"
            Me.DataGridViewIbLabResultDetails.ShowFooter = False
            Me.DataGridViewIbLabResultDetails.Size = New System.Drawing.Size(1421, 518)
            Me.DataGridViewIbLabResultDetails.TabIndex = 14
            Me.DataGridViewIbLabResultDetails.Translatable = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.chkIndeterminate)
            Me.CFlowLayout1.Controls.Add(Me.chkNegative)
            Me.CFlowLayout1.Controls.Add(Me.CheckBox1)
            Me.CFlowLayout1.Location = New System.Drawing.Point(3, 582)
            Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(456, 58)
            Me.CFlowLayout1.TabIndex = 18
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CFlowLayout1.SetFlowBreak(Me.CLabel2, True)
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(67, 17)
            Me.CLabel2.TabIndex = 3
            Me.CLabel2.Tag = "Positive"
            Me.CLabel2.Text = "Legend:"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'chkIndeterminate
            '
            Me.chkIndeterminate.AutoCheck = False
            Me.chkIndeterminate.AutoSize = True
            Me.chkIndeterminate.Checked = True
            Me.chkIndeterminate.CheckState = System.Windows.Forms.CheckState.Indeterminate
            Me.chkIndeterminate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkIndeterminate.Location = New System.Drawing.Point(3, 23)
            Me.chkIndeterminate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.chkIndeterminate.Name = "chkIndeterminate"
            Me.chkIndeterminate.Size = New System.Drawing.Size(73, 17)
            Me.chkIndeterminate.TabIndex = 6
            Me.chkIndeterminate.Text = "No Data"
            Me.chkIndeterminate.UseVisualStyleBackColor = True
            '
            'chkNegative
            '
            Me.chkNegative.AutoCheck = False
            Me.chkNegative.AutoSize = True
            Me.chkNegative.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNegative.Location = New System.Drawing.Point(82, 23)
            Me.chkNegative.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.chkNegative.Name = "chkNegative"
            Me.chkNegative.Size = New System.Drawing.Size(124, 17)
            Me.chkNegative.TabIndex = 5
            Me.chkNegative.Text = "Negative/Passed"
            Me.chkNegative.UseVisualStyleBackColor = True
            '
            'CheckBox1
            '
            Me.CheckBox1.AutoCheck = False
            Me.CheckBox1.AutoSize = True
            Me.CheckBox1.Checked = True
            Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
            Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CheckBox1.Location = New System.Drawing.Point(212, 23)
            Me.CheckBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.CheckBox1.Name = "CheckBox1"
            Me.CheckBox1.Size = New System.Drawing.Size(111, 17)
            Me.CheckBox1.TabIndex = 4
            Me.CheckBox1.Text = "Positive/Failed"
            Me.CheckBox1.UseVisualStyleBackColor = True
            '
            'CButton1
            '
            Me.CButton1.DesignerSelected = False
            Me.CButton1.ImageIndex = 0
            Me.CButton1.Location = New System.Drawing.Point(466, 584)
            Me.CButton1.Margin = New System.Windows.Forms.Padding(4)
            Me.CButton1.Name = "CButton1"
            Me.CButton1.OriginalImageName = Nothing
            Me.CButton1.SecurityKey = ""
            Me.CButton1.Size = New System.Drawing.Size(285, 31)
            Me.CButton1.TabIndex = 15
            Me.CButton1.Text = "Auto Fillup unfilled Items"
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
            Me.txtDoctorCode.Size = New System.Drawing.Size(106, 23)
            Me.txtDoctorCode.TabIndex = 16
            Me.txtDoctorCode.Translatable = False
            Me.txtDoctorCode.Visible = False
            '
            'bsIbLabResultDetails
            '
            Me.bsIbLabResultDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.IbLabResultDetailModel)
            '
            'Sequence
            '
            Me.Sequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.Sequence.BegFindValue = Nothing
            Me.Sequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.Sequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.Sequence.DisplayOnly = True
            Me.Sequence.EditingMode = False
            Me.Sequence.EndFindValue = Nothing
            Me.Sequence.FieldDescription = Nothing
            Me.Sequence.FieldName = Nothing
            Me.Sequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.Sequence.FindEnabled = False
            Me.Sequence.Frozen = True
            Me.Sequence.HeaderText = "Seq"
            Me.Sequence.IgnoreCase = False
            Me.Sequence.MinimumWidth = 6
            Me.Sequence.Name = "Sequence"
            Me.Sequence.ReadOnly = True
            Me.Sequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Sequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.Sequence.Translatable = False
            Me.Sequence.Width = 30
            '
            'dgvLabNo
            '
            Me.dgvLabNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvLabNo.BegFindValue = Nothing
            Me.dgvLabNo.DataPropertyName = "LabNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvLabNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvLabNo.DisplayOnly = True
            Me.dgvLabNo.EditingMode = False
            Me.dgvLabNo.EndFindValue = Nothing
            Me.dgvLabNo.FieldDescription = Nothing
            Me.dgvLabNo.FieldName = Nothing
            Me.dgvLabNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvLabNo.FindEnabled = False
            Me.dgvLabNo.Frozen = True
            Me.dgvLabNo.HeaderText = "File No."
            Me.dgvLabNo.IgnoreCase = False
            Me.dgvLabNo.MinimumWidth = 6
            Me.dgvLabNo.Name = "dgvLabNo"
            Me.dgvLabNo.ReadOnly = True
            Me.dgvLabNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvLabNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvLabNo.Translatable = False
            Me.dgvLabNo.Width = 68
            '
            'dgvPatientName
            '
            Me.dgvPatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvPatientName.BegFindValue = Nothing
            Me.dgvPatientName.DataPropertyName = "PatientName"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvPatientName.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvPatientName.DisplayOnly = True
            Me.dgvPatientName.EditingMode = False
            Me.dgvPatientName.EndFindValue = Nothing
            Me.dgvPatientName.FieldDescription = Nothing
            Me.dgvPatientName.FieldName = Nothing
            Me.dgvPatientName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPatientName.FindEnabled = False
            Me.dgvPatientName.Frozen = True
            Me.dgvPatientName.HeaderText = "Patient Name"
            Me.dgvPatientName.IgnoreCase = False
            Me.dgvPatientName.MinimumWidth = 6
            Me.dgvPatientName.Name = "dgvPatientName"
            Me.dgvPatientName.ReadOnly = True
            Me.dgvPatientName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPatientName.Translatable = False
            Me.dgvPatientName.Width = 96
            '
            'dgvNationality
            '
            Me.dgvNationality.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvNationality.BegFindValue = Nothing
            Me.dgvNationality.DataPropertyName = "Nationality"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvNationality.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvNationality.DisplayOnly = True
            Me.dgvNationality.EditingMode = False
            Me.dgvNationality.EndFindValue = Nothing
            Me.dgvNationality.FieldDescription = Nothing
            Me.dgvNationality.FieldName = Nothing
            Me.dgvNationality.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvNationality.FindEnabled = False
            Me.dgvNationality.HeaderText = "Nationality"
            Me.dgvNationality.IgnoreCase = False
            Me.dgvNationality.MinimumWidth = 6
            Me.dgvNationality.Name = "dgvNationality"
            Me.dgvNationality.ReadOnly = True
            Me.dgvNationality.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvNationality.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvNationality.Translatable = False
            Me.dgvNationality.Width = 81
            '
            'dgvProfession
            '
            Me.dgvProfession.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvProfession.BegFindValue = Nothing
            Me.dgvProfession.DataPropertyName = "Profession"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvProfession.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvProfession.EditingMode = False
            Me.dgvProfession.EndFindValue = Nothing
            Me.dgvProfession.FieldDescription = Nothing
            Me.dgvProfession.FieldName = Nothing
            Me.dgvProfession.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvProfession.FindEnabled = False
            Me.dgvProfession.HeaderText = "Profession"
            Me.dgvProfession.IgnoreCase = False
            Me.dgvProfession.MinimumWidth = 40
            Me.dgvProfession.Name = "dgvProfession"
            Me.dgvProfession.ReadOnly = True
            Me.dgvProfession.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvProfession.Translatable = False
            Me.dgvProfession.Width = 40
            '
            'dgvIqamaNo
            '
            Me.dgvIqamaNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.dgvIqamaNo.BegFindValue = Nothing
            Me.dgvIqamaNo.DataPropertyName = "IqamaNo"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvIqamaNo.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvIqamaNo.DisplayOnly = True
            Me.dgvIqamaNo.EditingMode = False
            Me.dgvIqamaNo.EndFindValue = Nothing
            Me.dgvIqamaNo.FieldDescription = Nothing
            Me.dgvIqamaNo.FieldName = Nothing
            Me.dgvIqamaNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvIqamaNo.FindEnabled = False
            Me.dgvIqamaNo.HeaderText = "ID/Iqama/ Border No."
            Me.dgvIqamaNo.IgnoreCase = False
            Me.dgvIqamaNo.MinimumWidth = 6
            Me.dgvIqamaNo.Name = "dgvIqamaNo"
            Me.dgvIqamaNo.ReadOnly = True
            Me.dgvIqamaNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvIqamaNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvIqamaNo.Translatable = False
            Me.dgvIqamaNo.Width = 80
            '
            'dgvPassportNumber
            '
            Me.dgvPassportNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Me.dgvPassportNumber.BegFindValue = Nothing
            Me.dgvPassportNumber.DataPropertyName = "PassportNumber"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvPassportNumber.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvPassportNumber.EditingMode = False
            Me.dgvPassportNumber.EndFindValue = Nothing
            Me.dgvPassportNumber.FieldDescription = Nothing
            Me.dgvPassportNumber.FieldName = Nothing
            Me.dgvPassportNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPassportNumber.FindEnabled = False
            Me.dgvPassportNumber.HeaderText = "Passport Number"
            Me.dgvPassportNumber.IgnoreCase = False
            Me.dgvPassportNumber.MinimumWidth = 50
            Me.dgvPassportNumber.Name = "dgvPassportNumber"
            Me.dgvPassportNumber.ReadOnly = True
            Me.dgvPassportNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPassportNumber.Translatable = False
            Me.dgvPassportNumber.Width = 50
            '
            'dgvGender
            '
            Me.dgvGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvGender.BegFindValue = Nothing
            Me.dgvGender.DataPropertyName = "Gender"
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvGender.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvGender.EditingMode = False
            Me.dgvGender.EndFindValue = Nothing
            Me.dgvGender.FieldDescription = Nothing
            Me.dgvGender.FieldName = Nothing
            Me.dgvGender.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvGender.FindEnabled = False
            Me.dgvGender.HeaderText = "Sex"
            Me.dgvGender.IgnoreCase = False
            Me.dgvGender.MinimumWidth = 10
            Me.dgvGender.Name = "dgvGender"
            Me.dgvGender.ReadOnly = True
            Me.dgvGender.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvGender.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvGender.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.dgvGender.Translatable = False
            Me.dgvGender.Width = 31
            '
            'dgvClinical
            '
            Me.dgvClinical.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvClinical.DataPropertyName = "Clinical"
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvClinical.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvClinical.HeaderText = "Clinical"
            Me.dgvClinical.MinimumWidth = 35
            Me.dgvClinical.Name = "dgvClinical"
            Me.dgvClinical.ReadOnly = True
            Me.dgvClinical.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvClinical.ThreeState = True
            Me.dgvClinical.Width = 35
            '
            'dgvXRay
            '
            Me.dgvXRay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvXRay.DataPropertyName = "XRay"
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvXRay.DefaultCellStyle = DataGridViewCellStyle11
            Me.dgvXRay.HeaderText = "XRay TB"
            Me.dgvXRay.MinimumWidth = 35
            Me.dgvXRay.Name = "dgvXRay"
            Me.dgvXRay.ReadOnly = True
            Me.dgvXRay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvXRay.ThreeState = True
            Me.dgvXRay.Width = 35
            '
            'dgvTBSputum
            '
            Me.dgvTBSputum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvTBSputum.DataPropertyName = "TBSputum"
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle12.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvTBSputum.DefaultCellStyle = DataGridViewCellStyle12
            Me.dgvTBSputum.HeaderText = "Sputum TB "
            Me.dgvTBSputum.MinimumWidth = 35
            Me.dgvTBSputum.Name = "dgvTBSputum"
            Me.dgvTBSputum.ReadOnly = True
            Me.dgvTBSputum.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvTBSputum.ThreeState = True
            Me.dgvTBSputum.Visible = False
            Me.dgvTBSputum.Width = 35
            '
            'dgvHIVEliza
            '
            Me.dgvHIVEliza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvHIVEliza.DataPropertyName = "HIVEliza"
            DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle13.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvHIVEliza.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvHIVEliza.HeaderText = "HIV Eliza"
            Me.dgvHIVEliza.MinimumWidth = 35
            Me.dgvHIVEliza.Name = "dgvHIVEliza"
            Me.dgvHIVEliza.ReadOnly = True
            Me.dgvHIVEliza.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvHIVEliza.ThreeState = True
            Me.dgvHIVEliza.Width = 35
            '
            'dgvHOVEliza
            '
            Me.dgvHOVEliza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvHOVEliza.DataPropertyName = "HOVEliza"
            DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle14.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvHOVEliza.DefaultCellStyle = DataGridViewCellStyle14
            Me.dgvHOVEliza.HeaderText = "HCV Eliza"
            Me.dgvHOVEliza.MinimumWidth = 35
            Me.dgvHOVEliza.Name = "dgvHOVEliza"
            Me.dgvHOVEliza.ReadOnly = True
            Me.dgvHOVEliza.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvHOVEliza.ThreeState = True
            Me.dgvHOVEliza.Width = 35
            '
            'dgvHBSAgEliza
            '
            Me.dgvHBSAgEliza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvHBSAgEliza.DataPropertyName = "HBSAgEliza"
            DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle15.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvHBSAgEliza.DefaultCellStyle = DataGridViewCellStyle15
            Me.dgvHBSAgEliza.HeaderText = "HBSAg Eliza"
            Me.dgvHBSAgEliza.MinimumWidth = 35
            Me.dgvHBSAgEliza.Name = "dgvHBSAgEliza"
            Me.dgvHBSAgEliza.ReadOnly = True
            Me.dgvHBSAgEliza.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvHBSAgEliza.ThreeState = True
            Me.dgvHBSAgEliza.Width = 35
            '
            'dgvMalaria
            '
            Me.dgvMalaria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvMalaria.DataPropertyName = "Malaria"
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle16.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvMalaria.DefaultCellStyle = DataGridViewCellStyle16
            Me.dgvMalaria.HeaderText = "Malaria"
            Me.dgvMalaria.MinimumWidth = 35
            Me.dgvMalaria.Name = "dgvMalaria"
            Me.dgvMalaria.ReadOnly = True
            Me.dgvMalaria.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvMalaria.ThreeState = True
            Me.dgvMalaria.Width = 35
            '
            'dgvVDRL
            '
            Me.dgvVDRL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvVDRL.DataPropertyName = "VDRL"
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle17.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvVDRL.DefaultCellStyle = DataGridViewCellStyle17
            Me.dgvVDRL.HeaderText = "VDRL"
            Me.dgvVDRL.MinimumWidth = 35
            Me.dgvVDRL.Name = "dgvVDRL"
            Me.dgvVDRL.ReadOnly = True
            Me.dgvVDRL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvVDRL.ThreeState = True
            Me.dgvVDRL.Width = 35
            '
            'dgvWidal
            '
            Me.dgvWidal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvWidal.DataPropertyName = "Widal"
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle18.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvWidal.DefaultCellStyle = DataGridViewCellStyle18
            Me.dgvWidal.HeaderText = "Widal"
            Me.dgvWidal.MinimumWidth = 35
            Me.dgvWidal.Name = "dgvWidal"
            Me.dgvWidal.ReadOnly = True
            Me.dgvWidal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvWidal.ThreeState = True
            Me.dgvWidal.Visible = False
            Me.dgvWidal.Width = 35
            '
            'dgvPregnancy
            '
            Me.dgvPregnancy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvPregnancy.DataPropertyName = "Pregnancy"
            DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle19.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvPregnancy.DefaultCellStyle = DataGridViewCellStyle19
            Me.dgvPregnancy.HeaderText = "Preg- nancy"
            Me.dgvPregnancy.MinimumWidth = 35
            Me.dgvPregnancy.Name = "dgvPregnancy"
            Me.dgvPregnancy.ReadOnly = True
            Me.dgvPregnancy.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvPregnancy.ThreeState = True
            Me.dgvPregnancy.Width = 35
            '
            'dgvBilharziasisUrine
            '
            Me.dgvBilharziasisUrine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvBilharziasisUrine.DataPropertyName = "BilharziasisUrine"
            DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle20.Font = New System.Drawing.Font("Arial Unicode MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle20.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvBilharziasisUrine.DefaultCellStyle = DataGridViewCellStyle20
            Me.dgvBilharziasisUrine.FillWeight = 1.0!
            Me.dgvBilharziasisUrine.HeaderText = "Urine"
            Me.dgvBilharziasisUrine.MinimumWidth = 35
            Me.dgvBilharziasisUrine.Name = "dgvBilharziasisUrine"
            Me.dgvBilharziasisUrine.ReadOnly = True
            Me.dgvBilharziasisUrine.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvBilharziasisUrine.ThreeState = True
            Me.dgvBilharziasisUrine.Width = 35
            '
            'dgvBilharziasisStool
            '
            Me.dgvBilharziasisStool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvBilharziasisStool.DataPropertyName = "BilharziasisStool"
            DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial Unicode MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle21.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvBilharziasisStool.DefaultCellStyle = DataGridViewCellStyle21
            Me.dgvBilharziasisStool.FillWeight = 1.0!
            Me.dgvBilharziasisStool.HeaderText = "Stool"
            Me.dgvBilharziasisStool.MinimumWidth = 35
            Me.dgvBilharziasisStool.Name = "dgvBilharziasisStool"
            Me.dgvBilharziasisStool.ReadOnly = True
            Me.dgvBilharziasisStool.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dgvBilharziasisStool.ThreeState = True
            Me.dgvBilharziasisStool.Width = 35
            '
            'dgvShigella
            '
            Me.dgvShigella.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvShigella.DataPropertyName = "Shigella"
            DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle22.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle22.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvShigella.DefaultCellStyle = DataGridViewCellStyle22
            Me.dgvShigella.HeaderText = "Shigella Salmonella"
            Me.dgvShigella.MinimumWidth = 35
            Me.dgvShigella.Name = "dgvShigella"
            Me.dgvShigella.ReadOnly = True
            Me.dgvShigella.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvShigella.ThreeState = True
            Me.dgvShigella.Width = 35
            '
            'dgvCholera
            '
            Me.dgvCholera.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            Me.dgvCholera.DataPropertyName = "Cholera"
            DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle23.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle23.NullValue = System.Windows.Forms.CheckState.Indeterminate
            Me.dgvCholera.DefaultCellStyle = DataGridViewCellStyle23
            Me.dgvCholera.HeaderText = "Cholera"
            Me.dgvCholera.MinimumWidth = 35
            Me.dgvCholera.Name = "dgvCholera"
            Me.dgvCholera.ReadOnly = True
            Me.dgvCholera.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvCholera.ThreeState = True
            Me.dgvCholera.Width = 35
            '
            'IbLabResultForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(1370, 700)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.Name = "IbLabResultForm"
            Me.Text = "Diagnostic Result Entry Form"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewIbLabResultDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            CType(Me.bsIbLabResultDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsIbLabResultDetails As BindingSource
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
        Friend WithEvents dtpTransactionDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewIbLabResultDetails As Libraries.CBaseControlsLibrary.CtDataGridView
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
        Friend WithEvents CButton1 As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents chkIndeterminate As CheckBox
        Friend WithEvents chkNegative As CheckBox
        Friend WithEvents CheckBox1 As CheckBox
        Friend WithEvents Sequence As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvLabNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvPatientName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvNationality As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvProfession As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvIqamaNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvPassportNumber As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvGender As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvClinical As DataGridViewCheckBoxColumn
        Friend WithEvents dgvXRay As DataGridViewCheckBoxColumn
        Friend WithEvents dgvTBSputum As DataGridViewCheckBoxColumn
        Friend WithEvents dgvHIVEliza As DataGridViewCheckBoxColumn
        Friend WithEvents dgvHOVEliza As DataGridViewCheckBoxColumn
        Friend WithEvents dgvHBSAgEliza As DataGridViewCheckBoxColumn
        Friend WithEvents dgvMalaria As DataGridViewCheckBoxColumn
        Friend WithEvents dgvVDRL As DataGridViewCheckBoxColumn
        Friend WithEvents dgvWidal As DataGridViewCheckBoxColumn
        Friend WithEvents dgvPregnancy As DataGridViewCheckBoxColumn
        Friend WithEvents dgvBilharziasisUrine As DataGridViewCheckBoxColumn
        Friend WithEvents dgvBilharziasisStool As DataGridViewCheckBoxColumn
        Friend WithEvents dgvShigella As DataGridViewCheckBoxColumn
        Friend WithEvents dgvCholera As DataGridViewCheckBoxColumn
    End Class
End Namespace