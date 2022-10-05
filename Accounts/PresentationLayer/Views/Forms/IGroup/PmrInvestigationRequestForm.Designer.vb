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
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDoctorId = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtDoctorName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.DataGridViewPmrPatientDisplay = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.bsPmrPatientDisplay = New System.Windows.Forms.BindingSource(Me.components)
            Me.TokenDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.StatusDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.FileNoDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.NameDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvPType = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.InvTypeDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.CreateDateDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            CType(Me.DataGridViewPmrPatientDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPmrPatientDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.txtDoctorId)
            Me.CFlowLayout1.Controls.Add(Me.txtDoctorName)
            Me.CFlowLayout1.Controls.Add(Me.btnRefresh)
            Me.CFlowLayout1.Controls.Add(Me.CLabel1)
            Me.CFlowLayout1.Controls.Add(Me.dtpTransactionDate)
            Me.CFlowLayout1.Controls.Add(Me.DataGridViewPmrPatientDisplay)
            Me.CFlowLayout1.Controls.Add(Me.CTextBox1)
            Me.CFlowLayout1.Location = New System.Drawing.Point(13, 71)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(791, 349)
            Me.CFlowLayout1.TabIndex = 4
            '
            'CLabel2
            '
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(156, 23)
            Me.CLabel2.TabIndex = 7
            Me.CLabel2.Text = "Doctors Code - Name:"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'txtDoctorId
            '
            Me.txtDoctorId.BackColor = System.Drawing.Color.White
            Me.txtDoctorId.BegFindValue = Nothing
            Me.txtDoctorId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDoctorId.ComputedValue = False
            Me.txtDoctorId.CustomFormat = Nothing
            Me.txtDoctorId.DataBoundControl = True
            Me.txtDoctorId.EditingMode = True
            Me.txtDoctorId.EndFindValue = Nothing
            Me.txtDoctorId.FieldDescription = Nothing
            Me.txtDoctorId.FieldName = Nothing
            Me.txtDoctorId.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDoctorId.FindEnabled = False
            Me.txtDoctorId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDoctorId.ForeColor = System.Drawing.Color.Black
            Me.txtDoctorId.LinkedLabel = Nothing
            Me.txtDoctorId.Location = New System.Drawing.Point(159, 1)
            Me.txtDoctorId.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDoctorId.MaximumValue = Nothing
            Me.txtDoctorId.MinimumValue = Nothing
            Me.txtDoctorId.Name = "txtDoctorId"
            Me.txtDoctorId.OldValue = Nothing
            Me.txtDoctorId.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorId.Size = New System.Drawing.Size(42, 23)
            Me.txtDoctorId.TabIndex = 10
            Me.txtDoctorId.Translatable = False
            '
            'txtDoctorName
            '
            Me.txtDoctorName.BackColor = System.Drawing.Color.White
            Me.txtDoctorName.BegFindValue = Nothing
            Me.txtDoctorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDoctorName.ComputedValue = False
            Me.txtDoctorName.CustomFormat = Nothing
            Me.txtDoctorName.DataBoundControl = True
            Me.txtDoctorName.EditingMode = True
            Me.txtDoctorName.EndFindValue = Nothing
            Me.txtDoctorName.FieldDescription = Nothing
            Me.txtDoctorName.FieldName = Nothing
            Me.txtDoctorName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDoctorName.FindEnabled = False
            Me.txtDoctorName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtDoctorName.ForeColor = System.Drawing.Color.Black
            Me.txtDoctorName.LinkedLabel = Nothing
            Me.txtDoctorName.Location = New System.Drawing.Point(203, 1)
            Me.txtDoctorName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDoctorName.MaximumValue = Nothing
            Me.txtDoctorName.MinimumValue = Nothing
            Me.txtDoctorName.Name = "txtDoctorName"
            Me.txtDoctorName.OldValue = Nothing
            Me.txtDoctorName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDoctorName.Size = New System.Drawing.Size(460, 23)
            Me.txtDoctorName.TabIndex = 8
            Me.txtDoctorName.Translatable = False
            '
            'btnRefresh
            '
            Me.btnRefresh.DesignerSelected = False
            Me.btnRefresh.ImageIndex = 0
            Me.btnRefresh.Location = New System.Drawing.Point(667, 3)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.OriginalImageName = Nothing
            Me.btnRefresh.SecurityKey = ""
            Me.btnRefresh.Size = New System.Drawing.Size(90, 25)
            Me.btnRefresh.TabIndex = 11
            Me.btnRefresh.Text = "Refresh"
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
            Me.CLabel1.TabIndex = 6
            Me.CLabel1.Text = "Transaction Date:"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'dtpTransactionDate
            '
            Me.dtpTransactionDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpTransactionDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpTransactionDate.DefaultValue = Nothing
            Me.dtpTransactionDate.DisplayOnly = False
            Me.dtpTransactionDate.DtpDefaultValue = Nothing
            Me.dtpTransactionDate.EditingMode = True
            Me.dtpTransactionDate.EditsAllowed = False
            Me.CFlowLayout1.SetFlowBreak(Me.dtpTransactionDate, True)
            Me.dtpTransactionDate.ForeColor = System.Drawing.Color.Black
            Me.dtpTransactionDate.LinkedLabel = Nothing
            Me.dtpTransactionDate.Location = New System.Drawing.Point(159, 32)
            Me.dtpTransactionDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpTransactionDate.Name = "dtpTransactionDate"
            Me.dtpTransactionDate.ReadOnlyDp = False
            Me.dtpTransactionDate.SecurityKey = Nothing
            Me.dtpTransactionDate.ShowLongDate = False
            Me.dtpTransactionDate.ShowTime = False
            Me.dtpTransactionDate.Size = New System.Drawing.Size(119, 23)
            Me.dtpTransactionDate.TabIndex = 1
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
            '
            'DataGridViewPmrPatientDisplay
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPmrPatientDisplay.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPmrPatientDisplay.AutoGenerateColumns = False
            Me.DataGridViewPmrPatientDisplay.BegFindValue = Nothing
            Me.DataGridViewPmrPatientDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPmrPatientDisplay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TokenDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.FileNoDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.dgvPType, Me.InvTypeDataGridViewTextBoxColumn, Me.CreateDateDataGridViewTextBoxColumn})
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
            Me.DataGridViewPmrPatientDisplay.DisplayOnly = False
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
            Me.DataGridViewPmrPatientDisplay.Size = New System.Drawing.Size(779, 296)
            Me.DataGridViewPmrPatientDisplay.TabIndex = 0
            Me.DataGridViewPmrPatientDisplay.Translatable = True
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
            Me.CFlowLayout1.SetFlowBreak(Me.CTextBox1, True)
            Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox1.ForeColor = System.Drawing.Color.Black
            Me.CTextBox1.LinkedLabel = Nothing
            Me.CTextBox1.Location = New System.Drawing.Point(1, 359)
            Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox1.MaximumValue = Nothing
            Me.CTextBox1.MinimumValue = Nothing
            Me.CTextBox1.Name = "CTextBox1"
            Me.CTextBox1.OldValue = Nothing
            Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBox1.Size = New System.Drawing.Size(483, 23)
            Me.CTextBox1.TabIndex = 9
            Me.CTextBox1.Translatable = False
            '
            'imgList
            '
            Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imgList.TransparentColor = System.Drawing.Color.Transparent
            Me.imgList.Images.SetKeyName(0, "btnPrint.png")
            '
            'bsPmrPatientDisplay
            '
            Me.bsPmrPatientDisplay.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PmrPatientDisplayModel)
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
            'dgvPType
            '
            Me.dgvPType.BegFindValue = Nothing
            Me.dgvPType.DataPropertyName = "PType"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvPType.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvPType.EditingMode = False
            Me.dgvPType.EndFindValue = Nothing
            Me.dgvPType.FieldDescription = Nothing
            Me.dgvPType.FieldName = Nothing
            Me.dgvPType.FillWeight = 60.0!
            Me.dgvPType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvPType.FindEnabled = False
            Me.dgvPType.HeaderText = "Patient Type"
            Me.dgvPType.IgnoreCase = False
            Me.dgvPType.Name = "dgvPType"
            Me.dgvPType.ReadOnly = True
            Me.dgvPType.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvPType.Translatable = False
            Me.dgvPType.Width = 60
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
            'CreateDateDataGridViewTextBoxColumn
            '
            Me.CreateDateDataGridViewTextBoxColumn.BegFindValue = Nothing
            Me.CreateDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.Format = "hh:mm tt"
            Me.CreateDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
            Me.CreateDateDataGridViewTextBoxColumn.EditingMode = False
            Me.CreateDateDataGridViewTextBoxColumn.EndFindValue = Nothing
            Me.CreateDateDataGridViewTextBoxColumn.FieldDescription = Nothing
            Me.CreateDateDataGridViewTextBoxColumn.FieldName = Nothing
            Me.CreateDateDataGridViewTextBoxColumn.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CreateDateDataGridViewTextBoxColumn.FindEnabled = False
            Me.CreateDateDataGridViewTextBoxColumn.HeaderText = "Time"
            Me.CreateDateDataGridViewTextBoxColumn.IgnoreCase = False
            Me.CreateDateDataGridViewTextBoxColumn.Name = "CreateDateDataGridViewTextBoxColumn"
            Me.CreateDateDataGridViewTextBoxColumn.ReadOnly = True
            Me.CreateDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CreateDateDataGridViewTextBoxColumn.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CreateDateDataGridViewTextBoxColumn.Translatable = False
            Me.CreateDateDataGridViewTextBoxColumn.Width = 80
            '
            'PmrInvestigationRequestForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(812, 433)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Name = "PmrInvestigationRequestForm"
            Me.Text = "PMR Request Form"
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            CType(Me.DataGridViewPmrPatientDisplay, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPmrPatientDisplay, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDoctorName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpTransactionDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents DataGridViewPmrPatientDisplay As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents bsPmrPatientDisplay As BindingSource
        Friend WithEvents TransKeyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents RegistrationNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PatientNameEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SeriesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents SexDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DoctorIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TransDateEnglishDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents txtDoctorId As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents btnRefresh As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents TypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents imgList As ImageList
        Friend WithEvents TokenDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents StatusDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn
        Friend WithEvents FileNoDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents NameDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvPType As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents InvTypeDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
    End Class
End Namespace