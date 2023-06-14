Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PatientPrescription

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PatientPrescription))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.DataGridViewPmrPatientDisplay = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.TokenDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.StatusDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.FileNoDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.NameDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvFileType = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.InvTypeDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvTransKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPmrPatientDisplay = New System.Windows.Forms.BindingSource(Me.components)
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPatientName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.txtPatientName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtFileNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CTextBox2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CTextBox3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboGender = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewPmrPatientDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPmrPatientDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.CFlowLayout2.Size = New System.Drawing.Size(970, 500)
            Me.CFlowLayout2.TabIndex = 5
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.ColumnCount = 5
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 3, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CTextBox3, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CTextBox2, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.CTextBox1, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewPmrPatientDisplay, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPatientName, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpTransactionDate, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPatientName, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtFileNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboGender, 5, 1)
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
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(797, 553)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'DataGridViewPmrPatientDisplay
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPmrPatientDisplay.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPmrPatientDisplay.AutoGenerateColumns = False
            Me.DataGridViewPmrPatientDisplay.BegFindValue = Nothing
            Me.DataGridViewPmrPatientDisplay.Cached = False
            Me.DataGridViewPmrPatientDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPmrPatientDisplay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TokenDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.FileNoDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.dgvFileType, Me.InvTypeDataGridViewTextBoxColumn, Me.dgvTime, Me.dgvTransKey})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewPmrPatientDisplay, 5)
            Me.DataGridViewPmrPatientDisplay.DataFilter = Nothing
            Me.DataGridViewPmrPatientDisplay.DataSource = Me.bsPmrPatientDisplay
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPmrPatientDisplay.DefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewPmrPatientDisplay.DgSearch = CType(resources.GetObject("DataGridViewPmrPatientDisplay.DgSearch"), System.Collections.Generic.List(Of AATM.Libraries.CBaseControlsLibrary.CDataGridView.DataGridSearch))
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
            Me.DataGridViewPmrPatientDisplay.Location = New System.Drawing.Point(3, 79)
            Me.DataGridViewPmrPatientDisplay.Name = "DataGridViewPmrPatientDisplay"
            Me.DataGridViewPmrPatientDisplay.ReadOnly = True
            Me.DataGridViewPmrPatientDisplay.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPmrPatientDisplay.SecurityKey = ""
            Me.DataGridViewPmrPatientDisplay.SequenceColumn = "dgvSequence"
            Me.DataGridViewPmrPatientDisplay.SequenceFieldName = "Sequence"
            Me.DataGridViewPmrPatientDisplay.ShowFooter = False
            Me.DataGridViewPmrPatientDisplay.Size = New System.Drawing.Size(791, 431)
            Me.DataGridViewPmrPatientDisplay.TabIndex = 11
            Me.DataGridViewPmrPatientDisplay.Translatable = True
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
            'bsPmrPatientDisplay
            '
            Me.bsPmrPatientDisplay.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PmrPatientDisplayModel)
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(1, 52)
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
            Me.dtpTransactionDate.Location = New System.Drawing.Point(186, 52)
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
            Me.txtPatientName.Location = New System.Drawing.Point(266, 1)
            Me.txtPatientName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPatientName.MaximumValue = Nothing
            Me.txtPatientName.MinimumValue = Nothing
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.OldValue = Nothing
            Me.txtPatientName.OverrideMaxLength = 0
            Me.txtPatientName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPatientName.Size = New System.Drawing.Size(530, 23)
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
            Me.txtFileNo.Size = New System.Drawing.Size(78, 23)
            Me.txtFileNo.TabIndex = 16
            Me.txtFileNo.Translatable = False
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
            'CTextBox1
            '
            Me.CTextBox1.BackColor = System.Drawing.Color.White
            Me.CTextBox1.BegFindValue = Nothing
            Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox1.ComputedValue = False
            Me.CTextBox1.CustomFormat = Nothing
            Me.CTextBox1.DataBoundControl = True
            Me.CTextBox1.EditingMode = True
            Me.CTextBox1.EndFindValue = Nothing
            Me.CTextBox1.FieldDescription = Nothing
            Me.CTextBox1.FieldName = Nothing
            Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBox1.FindEnabled = False
            Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox1.ForeColor = System.Drawing.Color.Black
            Me.CTextBox1.LinkedLabel = Nothing
            Me.CTextBox1.Location = New System.Drawing.Point(186, 26)
            Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox1.MaximumValue = Nothing
            Me.CTextBox1.MinimumValue = Nothing
            Me.CTextBox1.Name = "CTextBox1"
            Me.CTextBox1.OldValue = Nothing
            Me.CTextBox1.OverrideMaxLength = 0
            Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBox1.Size = New System.Drawing.Size(78, 23)
            Me.CTextBox1.TabIndex = 17
            Me.CTextBox1.Translatable = False
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
            Me.CTextBox2.Location = New System.Drawing.Point(1, 514)
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
            'CTextBox3
            '
            Me.CTextBox3.BackColor = System.Drawing.Color.White
            Me.CTextBox3.BegFindValue = Nothing
            Me.CTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox3.ComputedValue = False
            Me.CTextBox3.CustomFormat = Nothing
            Me.CTextBox3.DataBoundControl = True
            Me.CTextBox3.EditingMode = True
            Me.CTextBox3.EndFindValue = Nothing
            Me.CTextBox3.FieldDescription = Nothing
            Me.CTextBox3.FieldName = Nothing
            Me.CTextBox3.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBox3.FindEnabled = False
            Me.CTextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox3.ForeColor = System.Drawing.Color.Black
            Me.CTextBox3.LinkedLabel = Nothing
            Me.CTextBox3.Location = New System.Drawing.Point(266, 26)
            Me.CTextBox3.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox3.MaximumValue = Nothing
            Me.CTextBox3.MinimumValue = Nothing
            Me.CTextBox3.Name = "CTextBox3"
            Me.CTextBox3.OldValue = Nothing
            Me.CTextBox3.OverrideMaxLength = 0
            Me.CTextBox3.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBox3.Size = New System.Drawing.Size(43, 23)
            Me.CTextBox3.TabIndex = 20
            Me.CTextBox3.Translatable = False
            '
            'CLabel3
            '
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(311, 26)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(395, 24)
            Me.CLabel3.TabIndex = 21
            Me.CLabel3.Text = "Gender"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel3.Translatable = True
            '
            'cboGender
            '
            Me.cboGender.AlwaysEditable = False
            Me.cboGender.BackColor = System.Drawing.SystemColors.ControlLight
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
            Me.cboGender.FormattingEnabled = True
            Me.cboGender.HideWhenNotEditingOrAdding = False
            Me.cboGender.IgnoreCase = False
            Me.cboGender.LimitToList = False
            Me.cboGender.LinkedLabel = Nothing
            Me.cboGender.Location = New System.Drawing.Point(708, 26)
            Me.cboGender.Margin = New System.Windows.Forms.Padding(1)
            Me.cboGender.Name = "cboGender"
            Me.cboGender.OldValue = 0
            Me.cboGender.OriginalDataSource = Nothing
            Me.cboGender.OriginalList = Nothing
            Me.cboGender.OverrideDropDownStyleList = False
            Me.cboGender.PreviousSearchTerm = Nothing
            Me.cboGender.PropertySelector = Nothing
            Me.cboGender.ReadOnlyCombo = False
            Me.cboGender.Size = New System.Drawing.Size(88, 24)
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
            'PatientPrescription
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(970, 553)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Name = "PatientPrescription"
            Me.Text = "Patient Prescription"
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
        Friend WithEvents TypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents imgList As ImageList
        Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents DataGridViewPmrPatientDisplay As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPatientName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpTransactionDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents TokenDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents StatusDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents FileNoDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents NameDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvFileType As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents InvTypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvTime As DataGridViewTextBoxColumn
        Friend WithEvents dgvTransKey As DataGridViewTextBoxColumn
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtPatientName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtFileNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTextBox3 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTextBox2 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents cboGender As Libraries.CBaseControlsLibrary.CaComboBox
    End Class
End Namespace