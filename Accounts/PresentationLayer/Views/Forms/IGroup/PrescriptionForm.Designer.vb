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
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtGender = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtSeries = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtTransKey = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblTransKey = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDoctorName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDoctorName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblGender = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAgeYMD = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtAge = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.DataGridViewPrescriptionItems = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvRowNbr = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvItemCode = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvItemName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvGenericName = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvDosage = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.DurationDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvTransKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvLabelPrinted = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.dgvPrintLabel = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.bsPrescriptionDetails = New System.Windows.Forms.BindingSource(Me.components)
            Me.lblTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPatientName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.txtPatientName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtFileNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblSeries = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDob = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.btnPrintDosageLabels = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewPrescriptionItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.CFlowLayout2.Controls.Add(Me.btnPrintDosageLabels)
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 55)
            Me.CFlowLayout2.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(1311, 624)
            Me.CFlowLayout2.TabIndex = 5
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.ColumnCount = 6
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
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
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPrescriptionItems, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.lblTransactionDate, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPatientName, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpTransDate, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFileNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblSeries, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDob, 3, 2)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(1293, 566)
            Me.TableLayoutPanel1.TabIndex = 17
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
            Me.txtGender.FindEnabled = True
            Me.txtGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGender.ForeColor = System.Drawing.Color.Black
            Me.txtGender.LinkedLabel = Nothing
            Me.txtGender.Location = New System.Drawing.Point(1159, 65)
            Me.txtGender.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGender.MaximumValue = Nothing
            Me.txtGender.MinimumValue = Nothing
            Me.txtGender.Name = "txtGender"
            Me.txtGender.OldValue = Nothing
            Me.txtGender.OverrideMaxLength = 0
            Me.txtGender.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGender.Size = New System.Drawing.Size(130, 26)
            Me.txtGender.TabIndex = 30
            Me.txtGender.Translatable = False
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
            Me.txtSeries.FindEnabled = True
            Me.txtSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSeries.ForeColor = System.Drawing.Color.Black
            Me.txtSeries.LinkedLabel = Nothing
            Me.txtSeries.Location = New System.Drawing.Point(1159, 1)
            Me.txtSeries.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSeries.MaximumValue = Nothing
            Me.txtSeries.MinimumValue = Nothing
            Me.txtSeries.Name = "txtSeries"
            Me.txtSeries.OldValue = Nothing
            Me.txtSeries.OverrideMaxLength = 0
            Me.txtSeries.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSeries.Size = New System.Drawing.Size(130, 26)
            Me.txtSeries.TabIndex = 29
            Me.txtSeries.Translatable = False
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
            Me.txtTransKey.FindEnabled = True
            Me.txtTransKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTransKey.ForeColor = System.Drawing.Color.Black
            Me.txtTransKey.LinkedLabel = Me.lblTransKey
            Me.txtTransKey.Location = New System.Drawing.Point(1159, 31)
            Me.txtTransKey.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTransKey.MaximumValue = Nothing
            Me.txtTransKey.MinimumValue = Nothing
            Me.txtTransKey.Name = "txtTransKey"
            Me.txtTransKey.OldValue = Nothing
            Me.txtTransKey.OverrideMaxLength = 0
            Me.txtTransKey.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTransKey.Size = New System.Drawing.Size(133, 26)
            Me.txtTransKey.TabIndex = 28
            Me.txtTransKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtTransKey.Translatable = False
            '
            'lblTransKey
            '
            Me.lblTransKey.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblTransKey, 2)
            Me.lblTransKey.DisplayOnly = True
            Me.lblTransKey.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblTransKey.EditingMode = False
            Me.lblTransKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransKey.Location = New System.Drawing.Point(499, 31)
            Me.lblTransKey.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransKey.Name = "lblTransKey"
            Me.lblTransKey.Size = New System.Drawing.Size(658, 32)
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
            Me.txtDoctorName.FindEnabled = True
            Me.txtDoctorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDoctorName.ForeColor = System.Drawing.Color.Black
            Me.txtDoctorName.LinkedLabel = Nothing
            Me.txtDoctorName.Location = New System.Drawing.Point(247, 100)
            Me.txtDoctorName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDoctorName.MaximumValue = Nothing
            Me.txtDoctorName.MinimumValue = Nothing
            Me.txtDoctorName.Name = "txtDoctorName"
            Me.txtDoctorName.OldValue = Nothing
            Me.txtDoctorName.OverrideMaxLength = 0
            Me.txtDoctorName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorName.Size = New System.Drawing.Size(803, 26)
            Me.txtDoctorName.TabIndex = 26
            Me.txtDoctorName.Translatable = False
            '
            'lblDoctorName
            '
            Me.lblDoctorName.BackColor = System.Drawing.Color.Transparent
            Me.lblDoctorName.DisplayOnly = True
            Me.lblDoctorName.EditingMode = False
            Me.lblDoctorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblDoctorName.Location = New System.Drawing.Point(1, 100)
            Me.lblDoctorName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDoctorName.Name = "lblDoctorName"
            Me.lblDoctorName.Size = New System.Drawing.Size(208, 22)
            Me.lblDoctorName.TabIndex = 25
            Me.lblDoctorName.Text = "Doctor Name"
            Me.lblDoctorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDoctorName.Translatable = True
            '
            'lblGender
            '
            Me.lblGender.BackColor = System.Drawing.Color.Transparent
            Me.lblGender.DisplayOnly = True
            Me.lblGender.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblGender.EditingMode = False
            Me.lblGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGender.Location = New System.Drawing.Point(1052, 65)
            Me.lblGender.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGender.Name = "lblGender"
            Me.lblGender.Size = New System.Drawing.Size(105, 33)
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
            Me.txtAgeYMD.FindEnabled = True
            Me.txtAgeYMD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAgeYMD.ForeColor = System.Drawing.Color.Black
            Me.txtAgeYMD.LinkedLabel = Nothing
            Me.txtAgeYMD.Location = New System.Drawing.Point(382, 31)
            Me.txtAgeYMD.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAgeYMD.MaximumValue = Nothing
            Me.txtAgeYMD.MinimumValue = Nothing
            Me.txtAgeYMD.Name = "txtAgeYMD"
            Me.txtAgeYMD.OldValue = Nothing
            Me.txtAgeYMD.OverrideMaxLength = 0
            Me.txtAgeYMD.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAgeYMD.Size = New System.Drawing.Size(115, 26)
            Me.txtAgeYMD.TabIndex = 20
            Me.txtAgeYMD.Translatable = False
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(1, 31)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(208, 28)
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
            Me.txtAge.FindEnabled = True
            Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtAge.ForeColor = System.Drawing.Color.Black
            Me.txtAge.LinkedLabel = Nothing
            Me.txtAge.Location = New System.Drawing.Point(247, 31)
            Me.txtAge.Margin = New System.Windows.Forms.Padding(1)
            Me.txtAge.MaximumValue = Nothing
            Me.txtAge.MinimumValue = Nothing
            Me.txtAge.Name = "txtAge"
            Me.txtAge.OldValue = Nothing
            Me.txtAge.OverrideMaxLength = 0
            Me.txtAge.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtAge.Size = New System.Drawing.Size(133, 26)
            Me.txtAge.TabIndex = 17
            Me.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtAge.Translatable = False
            '
            'DataGridViewPrescriptionItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPrescriptionItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPrescriptionItems.AutoGenerateColumns = False
            Me.DataGridViewPrescriptionItems.BegFindValue = Nothing
            Me.DataGridViewPrescriptionItems.Cached = False
            Me.DataGridViewPrescriptionItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPrescriptionItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvRowNbr, Me.dgvItemCode, Me.dgvItemName, Me.dgvGenericName, Me.dgvDosage, Me.DurationDataGridViewTextBoxColumn, Me.dgvTransKey, Me.dgvLabelPrinted, Me.dgvPrintLabel})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPrescriptionItems, 6)
            Me.DataGridViewPrescriptionItems.DataFilter = Nothing
            Me.DataGridViewPrescriptionItems.DataSource = Me.bsPrescriptionDetails
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPrescriptionItems.DefaultCellStyle = DataGridViewCellStyle10
            Me.DataGridViewPrescriptionItems.DgvFooter = Nothing
            Me.DataGridViewPrescriptionItems.DisplayOnly = False
            Me.DataGridViewPrescriptionItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPrescriptionItems.Ea = Nothing
            Me.DataGridViewPrescriptionItems.EditingMode = False
            Me.DataGridViewPrescriptionItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPrescriptionItems.EndFindValue = Nothing
            Me.DataGridViewPrescriptionItems.FieldDescription = Nothing
            Me.DataGridViewPrescriptionItems.FieldName = Nothing
            Me.DataGridViewPrescriptionItems.FieldsDictionary = Nothing
            Me.DataGridViewPrescriptionItems.FindColumnNo = CType(0, Short)
            Me.DataGridViewPrescriptionItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPrescriptionItems.FindEnabled = False
            Me.DataGridViewPrescriptionItems.FirstRowDeletionEnabled = True
            Me.DataGridViewPrescriptionItems.FirstRowInsertionEnabled = True
            Me.DataGridViewPrescriptionItems.IgnoreCase = False
            Me.DataGridViewPrescriptionItems.IsDirty = False
            Me.DataGridViewPrescriptionItems.Location = New System.Drawing.Point(4, 131)
            Me.DataGridViewPrescriptionItems.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPrescriptionItems.Name = "DataGridViewPrescriptionItems"
            Me.DataGridViewPrescriptionItems.OldCellValue = Nothing
            Me.DataGridViewPrescriptionItems.ReadOnly = True
            Me.DataGridViewPrescriptionItems.RowHeadersWidth = 51
            Me.DataGridViewPrescriptionItems.Searchable = True
            Me.DataGridViewPrescriptionItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPrescriptionItems.SecurityKey = ""
            Me.DataGridViewPrescriptionItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewPrescriptionItems.SequenceFieldName = "Sequence"
            Me.DataGridViewPrescriptionItems.ShowFooter = False
            Me.DataGridViewPrescriptionItems.Size = New System.Drawing.Size(1285, 431)
            Me.DataGridViewPrescriptionItems.TabIndex = 11
            Me.DataGridViewPrescriptionItems.Translatable = True
            '
            'dgvRowNbr
            '
            Me.dgvRowNbr.BegFindValue = Nothing
            Me.dgvRowNbr.DataPropertyName = "RowNbr"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvRowNbr.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvRowNbr.EditingMode = False
            Me.dgvRowNbr.EndFindValue = Nothing
            Me.dgvRowNbr.FieldDescription = Nothing
            Me.dgvRowNbr.FieldName = Nothing
            Me.dgvRowNbr.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvRowNbr.FindEnabled = False
            Me.dgvRowNbr.HeaderText = "No."
            Me.dgvRowNbr.IgnoreCase = False
            Me.dgvRowNbr.MinimumWidth = 6
            Me.dgvRowNbr.Name = "dgvRowNbr"
            Me.dgvRowNbr.ReadOnly = True
            Me.dgvRowNbr.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvRowNbr.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvRowNbr.Translatable = False
            Me.dgvRowNbr.Width = 40
            '
            'dgvItemCode
            '
            Me.dgvItemCode.BegFindValue = Nothing
            Me.dgvItemCode.DataPropertyName = "ItemCode"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvItemCode.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvItemCode.EditingMode = False
            Me.dgvItemCode.EndFindValue = Nothing
            Me.dgvItemCode.FieldDescription = Nothing
            Me.dgvItemCode.FieldName = Nothing
            Me.dgvItemCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvItemCode.FindEnabled = False
            Me.dgvItemCode.HeaderText = "Item Code"
            Me.dgvItemCode.IgnoreCase = False
            Me.dgvItemCode.MinimumWidth = 6
            Me.dgvItemCode.Name = "dgvItemCode"
            Me.dgvItemCode.ReadOnly = True
            Me.dgvItemCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvItemCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvItemCode.Translatable = False
            Me.dgvItemCode.Width = 60
            '
            'dgvItemName
            '
            Me.dgvItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvItemName.BegFindValue = Nothing
            Me.dgvItemName.DataPropertyName = "ItemName"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvItemName.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvItemName.EditingMode = False
            Me.dgvItemName.EndFindValue = Nothing
            Me.dgvItemName.FieldDescription = Nothing
            Me.dgvItemName.FieldName = Nothing
            Me.dgvItemName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvItemName.FindEnabled = False
            Me.dgvItemName.HeaderText = "Medicine Name"
            Me.dgvItemName.IgnoreCase = False
            Me.dgvItemName.MinimumWidth = 6
            Me.dgvItemName.Name = "dgvItemName"
            Me.dgvItemName.ReadOnly = True
            Me.dgvItemName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvItemName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvItemName.Translatable = False
            '
            'dgvGenericName
            '
            Me.dgvGenericName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvGenericName.BegFindValue = Nothing
            Me.dgvGenericName.DataPropertyName = "GenericName"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvGenericName.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvGenericName.EditingMode = False
            Me.dgvGenericName.EndFindValue = Nothing
            Me.dgvGenericName.FieldDescription = Nothing
            Me.dgvGenericName.FieldName = Nothing
            Me.dgvGenericName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvGenericName.FindEnabled = False
            Me.dgvGenericName.HeaderText = "Generic Name"
            Me.dgvGenericName.IgnoreCase = False
            Me.dgvGenericName.MinimumWidth = 6
            Me.dgvGenericName.Name = "dgvGenericName"
            Me.dgvGenericName.ReadOnly = True
            Me.dgvGenericName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvGenericName.Translatable = False
            '
            'dgvDosage
            '
            Me.dgvDosage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvDosage.BegFindValue = Nothing
            Me.dgvDosage.DataPropertyName = "Dosage"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvDosage.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvDosage.EditingMode = False
            Me.dgvDosage.EndFindValue = Nothing
            Me.dgvDosage.FieldDescription = Nothing
            Me.dgvDosage.FieldName = Nothing
            Me.dgvDosage.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDosage.FindEnabled = False
            Me.dgvDosage.HeaderText = "Dosage"
            Me.dgvDosage.IgnoreCase = False
            Me.dgvDosage.MinimumWidth = 6
            Me.dgvDosage.Name = "dgvDosage"
            Me.dgvDosage.ReadOnly = True
            Me.dgvDosage.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDosage.Translatable = False
            '
            'DurationDataGridViewTextBoxColumn
            '
            Me.DurationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.DurationDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.DurationDataGridViewTextBoxColumn.DataPropertyName = "Duration"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.DurationDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
            Me.DurationDataGridViewTextBoxColumn.EditingMode = False
            Me.DurationDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.DurationDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.DurationDataGridViewTextBoxColumn.FieldName = Nothing
            Me.DurationDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DurationDataGridViewTextBoxColumn.FindEnabled = False
            Me.DurationDataGridViewTextBoxColumn.HeaderText = "Duration"
            Me.DurationDataGridViewTextBoxColumn.IgnoreCase = False
            Me.DurationDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.DurationDataGridViewTextBoxColumn.Name = "DurationDataGridViewTextBoxColumn"
            Me.DurationDataGridViewTextBoxColumn.ReadOnly = True
            Me.DurationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DurationDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DurationDataGridViewTextBoxColumn.Translatable = False
            Me.DurationDataGridViewTextBoxColumn.Width = 86
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
            'dgvLabelPrinted
            '
            Me.dgvLabelPrinted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvLabelPrinted.BegFindValue = Nothing
            Me.dgvLabelPrinted.DataPropertyName = "LabelPrinted"
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.NullValue = False
            Me.dgvLabelPrinted.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvLabelPrinted.EditingMode = False
            Me.dgvLabelPrinted.EndFindValue = Nothing
            Me.dgvLabelPrinted.FieldDescription = Nothing
            Me.dgvLabelPrinted.FieldName = Nothing
            Me.dgvLabelPrinted.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvLabelPrinted.FindEnabled = False
            Me.dgvLabelPrinted.HeaderText = "Label Printed"
            Me.dgvLabelPrinted.IgnoreCase = False
            Me.dgvLabelPrinted.MinimumWidth = 6
            Me.dgvLabelPrinted.Name = "dgvLabelPrinted"
            Me.dgvLabelPrinted.ReadOnly = True
            Me.dgvLabelPrinted.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvLabelPrinted.Translatable = False
            Me.dgvLabelPrinted.Visible = False
            Me.dgvLabelPrinted.Width = 125
            '
            'dgvPrintLabel
            '
            Me.dgvPrintLabel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvPrintLabel.BegFindValue = Nothing
            Me.dgvPrintLabel.DataPropertyName = "PrintLabel"
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.NullValue = False
            Me.dgvPrintLabel.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvPrintLabel.EditingMode = False
            Me.dgvPrintLabel.EndFindValue = Nothing
            Me.dgvPrintLabel.FieldDescription = Nothing
            Me.dgvPrintLabel.FieldName = Nothing
            Me.dgvPrintLabel.FillWeight = 40.0!
            Me.dgvPrintLabel.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPrintLabel.FindEnabled = False
            Me.dgvPrintLabel.HeaderText = "Print Label"
            Me.dgvPrintLabel.IgnoreCase = False
            Me.dgvPrintLabel.MinimumWidth = 6
            Me.dgvPrintLabel.Name = "dgvPrintLabel"
            Me.dgvPrintLabel.ReadOnly = True
            Me.dgvPrintLabel.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPrintLabel.Translatable = False
            Me.dgvPrintLabel.Width = 69
            '
            'bsPrescriptionDetails
            '
            Me.bsPrescriptionDetails.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PrescriptionItemModel)
            '
            'lblTransactionDate
            '
            Me.lblTransactionDate.BackColor = System.Drawing.Color.Transparent
            Me.lblTransactionDate.DisplayOnly = True
            Me.lblTransactionDate.EditingMode = False
            Me.lblTransactionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblTransactionDate.Location = New System.Drawing.Point(1, 65)
            Me.lblTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblTransactionDate.Name = "lblTransactionDate"
            Me.lblTransactionDate.Size = New System.Drawing.Size(177, 28)
            Me.lblTransactionDate.TabIndex = 13
            Me.lblTransactionDate.Text = "Transaction Date:"
            Me.lblTransactionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblTransactionDate.Translatable = True
            '
            'lblPatientName
            '
            Me.lblPatientName.BackColor = System.Drawing.Color.Transparent
            Me.lblPatientName.DisplayOnly = True
            Me.lblPatientName.EditingMode = False
            Me.lblPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPatientName.Location = New System.Drawing.Point(1, 1)
            Me.lblPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPatientName.Name = "lblPatientName"
            Me.lblPatientName.Size = New System.Drawing.Size(244, 28)
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
            Me.dtpTransDate.Location = New System.Drawing.Point(247, 65)
            Me.dtpTransDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransDate.Name = "dtpTransDate"
            Me.dtpTransDate.ReadOnlyDp = False
            Me.dtpTransDate.SecurityKey = Nothing
            Me.dtpTransDate.ShowLongDate = False
            Me.dtpTransDate.ShowTime = False
            Me.dtpTransDate.Size = New System.Drawing.Size(119, 27)
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
            Me.txtPatientName.FindEnabled = True
            Me.txtPatientName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPatientName.ForeColor = System.Drawing.Color.Black
            Me.txtPatientName.LinkedLabel = Nothing
            Me.txtPatientName.Location = New System.Drawing.Point(382, 1)
            Me.txtPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientName.MaximumValue = Nothing
            Me.txtPatientName.MinimumValue = Nothing
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.OldValue = Nothing
            Me.txtPatientName.OverrideMaxLength = 0
            Me.txtPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientName.Size = New System.Drawing.Size(668, 26)
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
            Me.txtFileNo.FindEnabled = True
            Me.txtFileNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtFileNo.ForeColor = System.Drawing.Color.Black
            Me.txtFileNo.LinkedLabel = Nothing
            Me.txtFileNo.Location = New System.Drawing.Point(247, 1)
            Me.txtFileNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtFileNo.MaximumValue = Nothing
            Me.txtFileNo.MinimumValue = Nothing
            Me.txtFileNo.Name = "txtFileNo"
            Me.txtFileNo.OldValue = Nothing
            Me.txtFileNo.OverrideMaxLength = 0
            Me.txtFileNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtFileNo.Size = New System.Drawing.Size(133, 26)
            Me.txtFileNo.TabIndex = 16
            Me.txtFileNo.Translatable = False
            '
            'lblSeries
            '
            Me.lblSeries.AutoSize = True
            Me.lblSeries.BackColor = System.Drawing.Color.Transparent
            Me.lblSeries.DisplayOnly = True
            Me.lblSeries.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblSeries.EditingMode = False
            Me.lblSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSeries.Location = New System.Drawing.Point(1052, 1)
            Me.lblSeries.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSeries.Name = "lblSeries"
            Me.lblSeries.Size = New System.Drawing.Size(105, 28)
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
            Me.txtDob.FindEnabled = True
            Me.txtDob.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDob.ForeColor = System.Drawing.Color.Black
            Me.txtDob.LinkedLabel = Nothing
            Me.txtDob.Location = New System.Drawing.Point(499, 65)
            Me.txtDob.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDob.MaximumValue = Nothing
            Me.txtDob.MinimumValue = Nothing
            Me.txtDob.Name = "txtDob"
            Me.txtDob.OldValue = Nothing
            Me.txtDob.OverrideMaxLength = 0
            Me.txtDob.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDob.Size = New System.Drawing.Size(133, 26)
            Me.txtDob.TabIndex = 18
            Me.txtDob.Translatable = False
            Me.txtDob.Visible = False
            '
            'btnPrintDosageLabels
            '
            Me.btnPrintDosageLabels.DesignerSelected = False
            Me.btnPrintDosageLabels.ImageIndex = 0
            Me.btnPrintDosageLabels.Location = New System.Drawing.Point(4, 578)
            Me.btnPrintDosageLabels.Margin = New System.Windows.Forms.Padding(4)
            Me.btnPrintDosageLabels.Name = "btnPrintDosageLabels"
            Me.btnPrintDosageLabels.OriginalImageName = Nothing
            Me.btnPrintDosageLabels.SecurityKey = ""
            Me.btnPrintDosageLabels.Size = New System.Drawing.Size(301, 31)
            Me.btnPrintDosageLabels.TabIndex = 18
            Me.btnPrintDosageLabels.Text = "Print Medicine Dosage Labels"
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
            'PrescriptionForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(1311, 679)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.Name = "PrescriptionForm"
            Me.Text = "Patient Prescription"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewPrescriptionItems, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents DataGridViewPrescriptionItems As Libraries.CBaseControlsLibrary.CtDataGridView
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
        Friend WithEvents txtDoctorName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblDoctorName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtTransKey As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblTransKey As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtGender As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtSeries As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents btnPrintDosageLabels As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents dgvRowNbr As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvItemCode As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvItemName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvGenericName As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvDosage As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents DurationDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvTransKey As DataGridViewTextBoxColumn
        Friend WithEvents dgvLabelPrinted As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents dgvPrintLabel As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
    End Class
End Namespace