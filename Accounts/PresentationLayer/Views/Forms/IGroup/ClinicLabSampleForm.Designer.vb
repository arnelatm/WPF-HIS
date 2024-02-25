Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClinicLabSampleForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClinicLabSampleForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.DataGridViewClinicLabSampleDetails = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.bsClinicLabSampleDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.Sequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DataGridViewTextBoxColumn9 = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.Column1 = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.RegistrationNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DataGridViewTextBoxColumn4 = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DataGridViewTextBoxColumn6 = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.IqamaNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DataGridViewTextBoxColumn5 = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvAge = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.DataGridViewTextBoxColumn8 = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewClinicLabSampleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsClinicLabSampleDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnRefresh
            '
            Me.btnRefresh.DesignerSelected = False
            Me.btnRefresh.ImageIndex = 0
            Me.btnRefresh.Location = New System.Drawing.Point(281, 3)
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
            Me.CFlowLayout2.AutoSize = True
            Me.CFlowLayout2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 55)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(963, 480)
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
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewClinicLabSampleDetails, 1, 2)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(965, 465)
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
            Me.CLabel1.Size = New System.Drawing.Size(156, 23)
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(159, 1)
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
            'DataGridViewClinicLabSampleDetails
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite
            Me.DataGridViewClinicLabSampleDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewClinicLabSampleDetails.AutoGenerateColumns = False
            Me.DataGridViewClinicLabSampleDetails.BegFindValue = Nothing
            Me.DataGridViewClinicLabSampleDetails.Cached = False
            Me.DataGridViewClinicLabSampleDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewClinicLabSampleDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sequence, Me.DataGridViewTextBoxColumn9, Me.Column1, Me.RegistrationNo, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn6, Me.IqamaNo, Me.DataGridViewTextBoxColumn5, Me.dgvAge, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn2})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewClinicLabSampleDetails, 4)
            Me.DataGridViewClinicLabSampleDetails.DataFilter = Nothing
            Me.DataGridViewClinicLabSampleDetails.DataSource = Me.bsClinicLabSampleDetails
            DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.Black
            DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewClinicLabSampleDetails.DefaultCellStyle = DataGridViewCellStyle12
            Me.DataGridViewClinicLabSampleDetails.DgvFooter = Nothing
            Me.DataGridViewClinicLabSampleDetails.DisplayOnly = False
            Me.DataGridViewClinicLabSampleDetails.Ea = Nothing
            Me.DataGridViewClinicLabSampleDetails.EditingMode = False
            Me.DataGridViewClinicLabSampleDetails.EndFindValue = Nothing
            Me.DataGridViewClinicLabSampleDetails.FieldDescription = Nothing
            Me.DataGridViewClinicLabSampleDetails.FieldName = Nothing
            Me.DataGridViewClinicLabSampleDetails.FieldsDictionary = Nothing
            Me.DataGridViewClinicLabSampleDetails.FindColumnNo = CType(0, Short)
            Me.DataGridViewClinicLabSampleDetails.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewClinicLabSampleDetails.FindEnabled = False
            Me.DataGridViewClinicLabSampleDetails.FirstRowDeletionEnabled = True
            Me.DataGridViewClinicLabSampleDetails.FirstRowInsertionEnabled = True
            Me.DataGridViewClinicLabSampleDetails.IgnoreCase = False
            Me.DataGridViewClinicLabSampleDetails.IsDirty = False
            Me.DataGridViewClinicLabSampleDetails.Location = New System.Drawing.Point(3, 34)
            Me.DataGridViewClinicLabSampleDetails.Name = "DataGridViewClinicLabSampleDetails"
            Me.DataGridViewClinicLabSampleDetails.RowHeadersWidth = 51
            Me.DataGridViewClinicLabSampleDetails.Searchable = True
            Me.DataGridViewClinicLabSampleDetails.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewClinicLabSampleDetails.SecurityKey = ""
            Me.DataGridViewClinicLabSampleDetails.SequenceColumn = "dgvSequence"
            Me.DataGridViewClinicLabSampleDetails.SequenceFieldName = "Sequence"
            Me.DataGridViewClinicLabSampleDetails.ShowFooter = False
            Me.DataGridViewClinicLabSampleDetails.Size = New System.Drawing.Size(962, 421)
            Me.DataGridViewClinicLabSampleDetails.TabIndex = 14
            Me.DataGridViewClinicLabSampleDetails.Translatable = True
            '
            'bsClinicLabSampleDetails
            '
            Me.bsClinicLabSampleDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.ClinicLabSampleDetailModel)
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
            'Sequence
            '
            Me.Sequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
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
            Me.Sequence.HeaderText = "Seq"
            Me.Sequence.IgnoreCase = False
            Me.Sequence.MinimumWidth = 6
            Me.Sequence.Name = "Sequence"
            Me.Sequence.ReadOnly = True
            Me.Sequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.Sequence.Translatable = False
            Me.Sequence.Width = 51
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn9.BegFindValue = Nothing
            Me.DataGridViewTextBoxColumn9.DataPropertyName = "TakenTime"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle3
            Me.DataGridViewTextBoxColumn9.DisplayOnly = True
            Me.DataGridViewTextBoxColumn9.EditingMode = False
            Me.DataGridViewTextBoxColumn9.EndFindValue = Nothing
            Me.DataGridViewTextBoxColumn9.FieldDescription = Nothing
            Me.DataGridViewTextBoxColumn9.FieldName = Nothing
            Me.DataGridViewTextBoxColumn9.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewTextBoxColumn9.FindEnabled = False
            Me.DataGridViewTextBoxColumn9.HeaderText = "Time Taken"
            Me.DataGridViewTextBoxColumn9.IgnoreCase = False
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn9.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewTextBoxColumn9.Translatable = False
            Me.DataGridViewTextBoxColumn9.Width = 89
            '
            'Column1
            '
            Me.Column1.BegFindValue = Nothing
            Me.Column1.DataPropertyName = "LabNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.Column1.DefaultCellStyle = DataGridViewCellStyle4
            Me.Column1.EditingMode = False
            Me.Column1.EndFindValue = Nothing
            Me.Column1.FieldDescription = Nothing
            Me.Column1.FieldName = Nothing
            Me.Column1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.Column1.FindEnabled = False
            Me.Column1.HeaderText = "Sample No."
            Me.Column1.IgnoreCase = False
            Me.Column1.Name = "Column1"
            Me.Column1.ReadOnly = True
            Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.Column1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.Column1.Translatable = False
            '
            'RegistrationNo
            '
            Me.RegistrationNo.BegFindValue = Nothing
            Me.RegistrationNo.DataPropertyName = "RegistrationNo"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.RegistrationNo.DefaultCellStyle = DataGridViewCellStyle5
            Me.RegistrationNo.EditingMode = False
            Me.RegistrationNo.EndFindValue = Nothing
            Me.RegistrationNo.FieldDescription = Nothing
            Me.RegistrationNo.FieldName = Nothing
            Me.RegistrationNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.RegistrationNo.FindEnabled = False
            Me.RegistrationNo.HeaderText = "File No."
            Me.RegistrationNo.IgnoreCase = False
            Me.RegistrationNo.Name = "RegistrationNo"
            Me.RegistrationNo.ReadOnly = True
            Me.RegistrationNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.RegistrationNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.RegistrationNo.Translatable = False
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn4.BegFindValue = Nothing
            Me.DataGridViewTextBoxColumn4.DataPropertyName = "LabNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle6
            Me.DataGridViewTextBoxColumn4.DisplayOnly = True
            Me.DataGridViewTextBoxColumn4.EditingMode = False
            Me.DataGridViewTextBoxColumn4.EndFindValue = Nothing
            Me.DataGridViewTextBoxColumn4.FieldDescription = Nothing
            Me.DataGridViewTextBoxColumn4.FieldName = Nothing
            Me.DataGridViewTextBoxColumn4.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewTextBoxColumn4.FindEnabled = False
            Me.DataGridViewTextBoxColumn4.HeaderText = "Lab No."
            Me.DataGridViewTextBoxColumn4.IgnoreCase = False
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn4.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewTextBoxColumn4.Translatable = False
            Me.DataGridViewTextBoxColumn4.Width = 70
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn6.BegFindValue = Nothing
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "PatientName"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle7
            Me.DataGridViewTextBoxColumn6.DisplayOnly = True
            Me.DataGridViewTextBoxColumn6.EditingMode = False
            Me.DataGridViewTextBoxColumn6.EndFindValue = Nothing
            Me.DataGridViewTextBoxColumn6.FieldDescription = Nothing
            Me.DataGridViewTextBoxColumn6.FieldName = Nothing
            Me.DataGridViewTextBoxColumn6.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewTextBoxColumn6.FindEnabled = False
            Me.DataGridViewTextBoxColumn6.HeaderText = "Patient Name"
            Me.DataGridViewTextBoxColumn6.IgnoreCase = False
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.ReadOnly = True
            Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn6.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewTextBoxColumn6.Translatable = False
            '
            'IqamaNo
            '
            Me.IqamaNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.IqamaNo.BegFindValue = Nothing
            Me.IqamaNo.DataPropertyName = "IqamaNo"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.IqamaNo.DefaultCellStyle = DataGridViewCellStyle8
            Me.IqamaNo.DisplayOnly = True
            Me.IqamaNo.EditingMode = False
            Me.IqamaNo.EndFindValue = Nothing
            Me.IqamaNo.FieldDescription = Nothing
            Me.IqamaNo.FieldName = Nothing
            Me.IqamaNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.IqamaNo.FindEnabled = False
            Me.IqamaNo.HeaderText = "ID/Iqama/ Border No."
            Me.IqamaNo.IgnoreCase = False
            Me.IqamaNo.Name = "IqamaNo"
            Me.IqamaNo.ReadOnly = True
            Me.IqamaNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.IqamaNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.IqamaNo.Translatable = False
            Me.IqamaNo.Width = 109
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn5.BegFindValue = Nothing
            Me.DataGridViewTextBoxColumn5.DataPropertyName = "Nationality"
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewTextBoxColumn5.DisplayOnly = True
            Me.DataGridViewTextBoxColumn5.EditingMode = False
            Me.DataGridViewTextBoxColumn5.EndFindValue = Nothing
            Me.DataGridViewTextBoxColumn5.FieldDescription = Nothing
            Me.DataGridViewTextBoxColumn5.FieldName = Nothing
            Me.DataGridViewTextBoxColumn5.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewTextBoxColumn5.FindEnabled = False
            Me.DataGridViewTextBoxColumn5.HeaderText = "Nationality"
            Me.DataGridViewTextBoxColumn5.IgnoreCase = False
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn5.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewTextBoxColumn5.Translatable = False
            Me.DataGridViewTextBoxColumn5.Width = 81
            '
            'dgvAge
            '
            Me.dgvAge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvAge.DataPropertyName = "Age"
            Me.dgvAge.DecimalPlaces = -1
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvAge.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvAge.EditingMode = False
            Me.dgvAge.HeaderText = "Age"
            Me.dgvAge.Name = "dgvAge"
            Me.dgvAge.ReadOnly = True
            Me.dgvAge.Translatable = False
            Me.dgvAge.Width = 32
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DataGridViewTextBoxColumn8.BegFindValue = Nothing
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "TakenBy"
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle11
            Me.DataGridViewTextBoxColumn8.DisplayOnly = True
            Me.DataGridViewTextBoxColumn8.EditingMode = False
            Me.DataGridViewTextBoxColumn8.EndFindValue = Nothing
            Me.DataGridViewTextBoxColumn8.FieldDescription = Nothing
            Me.DataGridViewTextBoxColumn8.FieldName = Nothing
            Me.DataGridViewTextBoxColumn8.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewTextBoxColumn8.FindEnabled = False
            Me.DataGridViewTextBoxColumn8.HeaderText = "Taken By"
            Me.DataGridViewTextBoxColumn8.IgnoreCase = False
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.ReadOnly = True
            Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewTextBoxColumn8.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewTextBoxColumn8.Translatable = False
            Me.DataGridViewTextBoxColumn8.Width = 72
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "IdNo"
            Me.DataGridViewTextBoxColumn2.HeaderText = "IdNo"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.Visible = False
            '
            'ClinicLabSampleForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(963, 535)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Name = "ClinicLabSampleForm"
            Me.Text = "Diagnostic Sample Entry Form"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewClinicLabSampleDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsClinicLabSampleDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsClinicLabSampleDetails As BindingSource
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
        Friend WithEvents DataGridViewClinicLabSampleDetails As Libraries.CBaseControlsLibrary.CtDataGridView
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
        Friend WithEvents dgvUrine As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents dgvStool As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents dgvRBS As Libraries.CBaseControlsLibrary.CDgvDecimalColumn
        Friend WithEvents Sequence As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents Column1 As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents RegistrationNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents IqamaNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvAge As Libraries.CBaseControlsLibrary.CDgvDecimalColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    End Class
End Namespace