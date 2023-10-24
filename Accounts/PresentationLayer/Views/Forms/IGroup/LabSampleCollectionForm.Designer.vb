Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class IbLabSampleForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IbLabSampleForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.btnRefresh = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.imgList = New System.Windows.Forms.ImageList(Me.components)
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.DataGridViewIbLabSample = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvFileType = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvTransKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TakenDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TakenTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TakenByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UrineDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.StoolDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.RbsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsLabSampleDetail = New System.Windows.Forms.BindingSource(Me.components)
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpTransactionDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.txtDoctorCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.DataGridViewIbLabSample, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsLabSampleDetail, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout2.Location = New System.Drawing.Point(0, 55)
            Me.CFlowLayout2.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(1053, 626)
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
            Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewIbLabSample, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpTransactionDate, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.btnRefresh, 3, 1)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(1044, 577)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'DataGridViewIbLabSample
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewIbLabSample.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewIbLabSample.AutoGenerateColumns = False
            Me.DataGridViewIbLabSample.BegFindValue = Nothing
            Me.DataGridViewIbLabSample.Cached = False
            Me.DataGridViewIbLabSample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewIbLabSample.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvFileType, Me.dgvTime, Me.dgvTransKey, Me.IdNoDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn1, Me.TakenDateDataGridViewTextBoxColumn, Me.TakenTimeDataGridViewTextBoxColumn, Me.TakenByDataGridViewTextBoxColumn, Me.UrineDataGridViewCheckBoxColumn, Me.StoolDataGridViewCheckBoxColumn, Me.RbsDataGridViewTextBoxColumn})
            Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridViewIbLabSample, 4)
            Me.DataGridViewIbLabSample.DataFilter = Nothing
            Me.DataGridViewIbLabSample.DataSource = Me.bsLabSampleDetail
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewIbLabSample.DefaultCellStyle = DataGridViewCellStyle4
            Me.DataGridViewIbLabSample.DgvFooter = Nothing
            Me.DataGridViewIbLabSample.DisplayOnly = True
            Me.DataGridViewIbLabSample.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewIbLabSample.Ea = Nothing
            Me.DataGridViewIbLabSample.EditingMode = False
            Me.DataGridViewIbLabSample.EndFindValue = Nothing
            Me.DataGridViewIbLabSample.FieldDescription = Nothing
            Me.DataGridViewIbLabSample.FieldName = Nothing
            Me.DataGridViewIbLabSample.FieldsDictionary = Nothing
            Me.DataGridViewIbLabSample.FindColumnNo = CType(0, Short)
            Me.DataGridViewIbLabSample.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewIbLabSample.FindEnabled = False
            Me.DataGridViewIbLabSample.FirstRowDeletionEnabled = True
            Me.DataGridViewIbLabSample.FirstRowInsertionEnabled = True
            Me.DataGridViewIbLabSample.IgnoreCase = False
            Me.DataGridViewIbLabSample.IsDirty = False
            Me.DataGridViewIbLabSample.Location = New System.Drawing.Point(4, 43)
            Me.DataGridViewIbLabSample.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewIbLabSample.Name = "DataGridViewIbLabSample"
            Me.DataGridViewIbLabSample.ReadOnly = True
            Me.DataGridViewIbLabSample.RowHeadersWidth = 51
            Me.DataGridViewIbLabSample.Searchable = True
            Me.DataGridViewIbLabSample.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewIbLabSample.SecurityKey = ""
            Me.DataGridViewIbLabSample.SequenceColumn = "dgvSequence"
            Me.DataGridViewIbLabSample.SequenceFieldName = "Sequence"
            Me.DataGridViewIbLabSample.ShowFooter = False
            Me.DataGridViewIbLabSample.Size = New System.Drawing.Size(1036, 530)
            Me.DataGridViewIbLabSample.TabIndex = 11
            Me.DataGridViewIbLabSample.Translatable = True
            '
            'dgvFileType
            '
            Me.dgvFileType.BegFindValue = Nothing
            Me.dgvFileType.DataPropertyName = "InvType"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvFileType.DefaultCellStyle = DataGridViewCellStyle2
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
            'dgvTime
            '
            Me.dgvTime.DataPropertyName = "InvTime"
            DataGridViewCellStyle3.Format = "hh:mm tt"
            DataGridViewCellStyle3.NullValue = Nothing
            Me.dgvTime.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvTime.HeaderText = "Time"
            Me.dgvTime.MinimumWidth = 6
            Me.dgvTime.Name = "dgvTime"
            Me.dgvTime.ReadOnly = True
            Me.dgvTime.Width = 125
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
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn.Width = 125
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "TransKey"
            Me.DataGridViewTextBoxColumn1.HeaderText = "TransKey"
            Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.Width = 125
            '
            'TakenDateDataGridViewTextBoxColumn
            '
            Me.TakenDateDataGridViewTextBoxColumn.DataPropertyName = "TakenDate"
            Me.TakenDateDataGridViewTextBoxColumn.HeaderText = "TakenDate"
            Me.TakenDateDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.TakenDateDataGridViewTextBoxColumn.Name = "TakenDateDataGridViewTextBoxColumn"
            Me.TakenDateDataGridViewTextBoxColumn.ReadOnly = True
            Me.TakenDateDataGridViewTextBoxColumn.Width = 125
            '
            'TakenTimeDataGridViewTextBoxColumn
            '
            Me.TakenTimeDataGridViewTextBoxColumn.DataPropertyName = "TakenTime"
            Me.TakenTimeDataGridViewTextBoxColumn.HeaderText = "TakenTime"
            Me.TakenTimeDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.TakenTimeDataGridViewTextBoxColumn.Name = "TakenTimeDataGridViewTextBoxColumn"
            Me.TakenTimeDataGridViewTextBoxColumn.ReadOnly = True
            Me.TakenTimeDataGridViewTextBoxColumn.Width = 125
            '
            'TakenByDataGridViewTextBoxColumn
            '
            Me.TakenByDataGridViewTextBoxColumn.DataPropertyName = "TakenBy"
            Me.TakenByDataGridViewTextBoxColumn.HeaderText = "TakenBy"
            Me.TakenByDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.TakenByDataGridViewTextBoxColumn.Name = "TakenByDataGridViewTextBoxColumn"
            Me.TakenByDataGridViewTextBoxColumn.ReadOnly = True
            Me.TakenByDataGridViewTextBoxColumn.Width = 125
            '
            'UrineDataGridViewCheckBoxColumn
            '
            Me.UrineDataGridViewCheckBoxColumn.DataPropertyName = "Urine"
            Me.UrineDataGridViewCheckBoxColumn.HeaderText = "Urine"
            Me.UrineDataGridViewCheckBoxColumn.MinimumWidth = 6
            Me.UrineDataGridViewCheckBoxColumn.Name = "UrineDataGridViewCheckBoxColumn"
            Me.UrineDataGridViewCheckBoxColumn.ReadOnly = True
            Me.UrineDataGridViewCheckBoxColumn.Width = 125
            '
            'StoolDataGridViewCheckBoxColumn
            '
            Me.StoolDataGridViewCheckBoxColumn.DataPropertyName = "Stool"
            Me.StoolDataGridViewCheckBoxColumn.HeaderText = "Stool"
            Me.StoolDataGridViewCheckBoxColumn.MinimumWidth = 6
            Me.StoolDataGridViewCheckBoxColumn.Name = "StoolDataGridViewCheckBoxColumn"
            Me.StoolDataGridViewCheckBoxColumn.ReadOnly = True
            Me.StoolDataGridViewCheckBoxColumn.Width = 125
            '
            'RbsDataGridViewTextBoxColumn
            '
            Me.RbsDataGridViewTextBoxColumn.DataPropertyName = "Rbs"
            Me.RbsDataGridViewTextBoxColumn.HeaderText = "Rbs"
            Me.RbsDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.RbsDataGridViewTextBoxColumn.Name = "RbsDataGridViewTextBoxColumn"
            Me.RbsDataGridViewTextBoxColumn.ReadOnly = True
            Me.RbsDataGridViewTextBoxColumn.Width = 125
            '
            'bsLabSampleDetail
            '
            Me.bsLabSampleDetail.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.IbLabSampleDetailModel)
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
            Me.dtpTransactionDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpTransactionDate.TabIndex = 12
            Me.dtpTransactionDate.TargetCalendar = CType(resources.GetObject("dtpTransactionDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpTransactionDate.Translatable = False
            Me.dtpTransactionDate.Value = Nothing
            Me.dtpTransactionDate.ValueIsMandatory = False
            Me.dtpTransactionDate.ValueIsNullable = False
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
            'IbLabSampleForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(1053, 681)
            Me.Controls.Add(Me.CFlowLayout2)
            Me.Controls.Add(Me.txtDoctorCode)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.Name = "IbLabSampleForm"
            Me.Text = "Diagnostic Sample Entry Form"
            Me.Controls.SetChildIndex(Me.txtDoctorCode, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout2, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout2.ResumeLayout(False)
            Me.CFlowLayout2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.DataGridViewIbLabSample, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsLabSampleDetail, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsLabSampleDetail As BindingSource
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
        Friend WithEvents DataGridViewIbLabSample As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents CreateDateDataGridViewTextBoxColumn As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpTransactionDate As Libraries.CBaseControlsLibrary.CCustomDateTimePicker
        Friend WithEvents dgvFileType As Libraries.CBaseControlsLibrary.CDgvTextColumn
        Friend WithEvents dgvTime As DataGridViewTextBoxColumn
        Friend WithEvents dgvTransKey As DataGridViewTextBoxColumn
        Friend WithEvents txtDoctorCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents TakenDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TakenTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TakenByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UrineDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents StoolDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents RbsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace