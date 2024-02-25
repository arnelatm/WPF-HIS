Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ReportSelectorForm2
        Inherits CFormBase

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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSelectorForm2))
            Me.DataGridViewReportList = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.ReportName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.bsReportList = New System.Windows.Forms.BindingSource(Me.components)
            Me.CTabControl1 = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.CListBox1 = New AATM.Libraries.CBaseControlsLibrary.CListBox()
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblReportName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CCustomDateTimePicker1 = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CCustomDateTimePicker2 = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel6 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CtCombobox1 = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
            Me.CtCombobox2 = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewReportList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsReportList, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CTabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'DataGridViewReportList
            '
            Me.DataGridViewReportList.AllowUserToAddRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewReportList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewReportList.AutoGenerateColumns = False
            Me.DataGridViewReportList.BegFindValue = Nothing
            Me.DataGridViewReportList.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.DataGridViewReportList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
            Me.DataGridViewReportList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewReportList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReportName, Me.dgvIdNo})
            Me.DataGridViewReportList.DataSource = Me.bsReportList
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewReportList.DefaultCellStyle = DataGridViewCellStyle3
            Me.DataGridViewReportList.DgvFooter = Nothing
            Me.DataGridViewReportList.DisplayOnly = True
            Me.DataGridViewReportList.Ea = Nothing
            Me.DataGridViewReportList.EditingMode = False
            Me.DataGridViewReportList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewReportList.EndFindValue = Nothing
            Me.DataGridViewReportList.FieldDescription = Nothing
            Me.DataGridViewReportList.FieldName = Nothing
            Me.DataGridViewReportList.FieldsDictionary = Nothing
            Me.DataGridViewReportList.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewReportList.FindEnabled = False
            Me.DataGridViewReportList.FirstRowDeletionEnabled = True
            Me.DataGridViewReportList.FirstRowInsertionEnabled = True
            Me.DataGridViewReportList.IgnoreCase = False
            Me.DataGridViewReportList.IsDirty = False
            Me.DataGridViewReportList.Location = New System.Drawing.Point(367, 13)
            Me.DataGridViewReportList.Name = "DataGridViewReportList"
            Me.DataGridViewReportList.ReadOnly = True
            Me.DataGridViewReportList.RowHeadersVisible = False
            Me.DataGridViewReportList.RowHeadersWidth = 4
            Me.DataGridViewReportList.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewReportList.SecurityKey = ""
            Me.DataGridViewReportList.SequenceColumn = "dgvSequence"
            Me.DataGridViewReportList.SequenceFieldName = "Sequence"
            Me.DataGridViewReportList.ShowFooter = False
            Me.DataGridViewReportList.Size = New System.Drawing.Size(362, 475)
            Me.DataGridViewReportList.TabIndex = 11
            Me.DataGridViewReportList.Translatable = True
            '
            'ReportName
            '
            Me.ReportName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.ReportName.DataPropertyName = "ReportName"
            Me.ReportName.HeaderText = "Report Name"
            Me.ReportName.Name = "ReportName"
            Me.ReportName.ReadOnly = True
            '
            'dgvIdNo
            '
            Me.dgvIdNo.BegFindValue = Nothing
            Me.dgvIdNo.DataPropertyName = "IdNo"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvIdNo.EditingMode = False
            Me.dgvIdNo.EndFindValue = Nothing
            Me.dgvIdNo.FieldDescription = Nothing
            Me.dgvIdNo.FieldName = Nothing
            Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvIdNo.FindEnabled = False
            Me.dgvIdNo.HeaderText = "IdNo"
            Me.dgvIdNo.IgnoreCase = False
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvIdNo.Translatable = False
            Me.dgvIdNo.Visible = False
            Me.dgvIdNo.Width = 50
            '
            'bsReportList
            '
            Me.bsReportList.DataSource = GetType(ReportModel)
            '
            'CTabControl1
            '
            Me.CTabControl1.Controls.Add(Me.TabPage1)
            Me.CTabControl1.Controls.Add(Me.TabPage2)
            Me.CTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CTabControl1.Location = New System.Drawing.Point(0, 53)
            Me.CTabControl1.Name = "CTabControl1"
            Me.CTabControl1.SelectedIndex = 0
            Me.CTabControl1.Size = New System.Drawing.Size(984, 510)
            Me.CTabControl1.TabIndex = 12
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.DataGridViewReportList)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(976, 484)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "TabPage1"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.SplitContainer1)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(976, 484)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "TabPage2"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.CListBox1)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.LightSkyBlue
            Me.SplitContainer1.Panel2.Controls.Add(Me.FlowLayoutPanel1)
            Me.SplitContainer1.Size = New System.Drawing.Size(970, 478)
            Me.SplitContainer1.SplitterDistance = 469
            Me.SplitContainer1.TabIndex = 0
            '
            'CListBox1
            '
            Me.CListBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CListBox1.FormattingEnabled = True
            Me.CListBox1.Location = New System.Drawing.Point(0, 0)
            Me.CListBox1.Name = "CListBox1"
            Me.CListBox1.Size = New System.Drawing.Size(469, 478)
            Me.CListBox1.TabIndex = 0
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.Controls.Add(Me.TableLayoutPanel1)
            Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(497, 478)
            Me.FlowLayoutPanel1.TabIndex = 0
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel6, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblReportName, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CCustomDateTimePicker1, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CCustomDateTimePicker2, 3, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.CtCombobox1, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.CtCombobox2, 1, 6)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 7
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(491, 365)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'CLabel1
            '
            Me.CLabel1.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel1, 4)
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel1.Location = New System.Drawing.Point(1, 1)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(489, 32)
            Me.CLabel1.TabIndex = 0
            Me.CLabel1.Text = "RECEPTION REPORTS"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel1.Translatable = True
            '
            'CLabel2
            '
            Me.CLabel2.AutoSize = True
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(1, 35)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(114, 17)
            Me.CLabel2.TabIndex = 1
            Me.CLabel2.Text = "Selected Report:"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'lblReportName
            '
            Me.lblReportName.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblReportName, 4)
            Me.lblReportName.DisplayOnly = True
            Me.lblReportName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblReportName.EditingMode = False
            Me.lblReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblReportName.Location = New System.Drawing.Point(1, 54)
            Me.lblReportName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblReportName.Name = "lblReportName"
            Me.lblReportName.Size = New System.Drawing.Size(489, 17)
            Me.lblReportName.TabIndex = 2
            Me.lblReportName.Text = "Report Name"
            Me.lblReportName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblReportName.Translatable = True
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(1, 73)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(76, 17)
            Me.CLabel3.TabIndex = 3
            Me.CLabel3.Text = "Start Date:"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'CLabel4
            '
            Me.CLabel4.AutoSize = True
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel4.Location = New System.Drawing.Point(245, 73)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(71, 17)
            Me.CLabel4.TabIndex = 4
            Me.CLabel4.Text = "End Date:"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel4.Translatable = True
            '
            'CCustomDateTimePicker1
            '
            Me.CCustomDateTimePicker1.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.CCustomDateTimePicker1.DefaultValue = Nothing
            Me.CCustomDateTimePicker1.DisplayOnly = False
            Me.CCustomDateTimePicker1.DtpDefaultValue = Nothing
            Me.CCustomDateTimePicker1.EditingMode = True
            Me.CCustomDateTimePicker1.EditsAllowed = False
            Me.CCustomDateTimePicker1.ForeColor = System.Drawing.Color.Black
            Me.CCustomDateTimePicker1.LinkedLabel = Nothing
            Me.CCustomDateTimePicker1.Location = New System.Drawing.Point(123, 73)
            Me.CCustomDateTimePicker1.Margin = New System.Windows.Forms.Padding(1)
            Me.CCustomDateTimePicker1.Name = "CCustomDateTimePicker1"
            Me.CCustomDateTimePicker1.ReadOnlyDp = False
            Me.CCustomDateTimePicker1.SecurityKey = Nothing
            Me.CCustomDateTimePicker1.ShowLongDate = False
            Me.CCustomDateTimePicker1.ShowTime = False
            Me.CCustomDateTimePicker1.Size = New System.Drawing.Size(109, 23)
            Me.CCustomDateTimePicker1.TabIndex = 5
            Me.CCustomDateTimePicker1.TargetCalendar = CType(resources.GetObject("CCustomDateTimePicker1.TargetCalendar"), System.Globalization.Calendar)
            Me.CCustomDateTimePicker1.Translatable = False
            Me.CCustomDateTimePicker1.Value = Nothing
            Me.CCustomDateTimePicker1.ValueIsMandatory = False
            Me.CCustomDateTimePicker1.ValueIsNullable = False
            '
            'CCustomDateTimePicker2
            '
            Me.CCustomDateTimePicker2.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.CCustomDateTimePicker2.DefaultValue = Nothing
            Me.CCustomDateTimePicker2.DisplayOnly = False
            Me.CCustomDateTimePicker2.DtpDefaultValue = Nothing
            Me.CCustomDateTimePicker2.EditingMode = True
            Me.CCustomDateTimePicker2.EditsAllowed = False
            Me.CCustomDateTimePicker2.ForeColor = System.Drawing.Color.Black
            Me.CCustomDateTimePicker2.LinkedLabel = Nothing
            Me.CCustomDateTimePicker2.Location = New System.Drawing.Point(367, 73)
            Me.CCustomDateTimePicker2.Margin = New System.Windows.Forms.Padding(1)
            Me.CCustomDateTimePicker2.Name = "CCustomDateTimePicker2"
            Me.CCustomDateTimePicker2.ReadOnlyDp = False
            Me.CCustomDateTimePicker2.SecurityKey = Nothing
            Me.CCustomDateTimePicker2.ShowLongDate = False
            Me.CCustomDateTimePicker2.ShowTime = False
            Me.CCustomDateTimePicker2.Size = New System.Drawing.Size(111, 23)
            Me.CCustomDateTimePicker2.TabIndex = 6
            Me.CCustomDateTimePicker2.TargetCalendar = CType(resources.GetObject("CCustomDateTimePicker2.TargetCalendar"), System.Globalization.Calendar)
            Me.CCustomDateTimePicker2.Translatable = False
            Me.CCustomDateTimePicker2.Value = Nothing
            Me.CCustomDateTimePicker2.ValueIsMandatory = False
            Me.CCustomDateTimePicker2.ValueIsNullable = False
            '
            'CLabel5
            '
            Me.CLabel5.AutoSize = True
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.Location = New System.Drawing.Point(1, 98)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(54, 17)
            Me.CLabel5.TabIndex = 7
            Me.CLabel5.Text = "Doctor:"
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
            '
            'CLabel6
            '
            Me.CLabel6.AutoSize = True
            Me.CLabel6.DisplayOnly = True
            Me.CLabel6.EditingMode = False
            Me.CLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel6.Location = New System.Drawing.Point(1, 121)
            Me.CLabel6.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel6.Name = "CLabel6"
            Me.CLabel6.Size = New System.Drawing.Size(71, 17)
            Me.CLabel6.TabIndex = 8
            Me.CLabel6.Text = "Company:"
            Me.CLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel6.Translatable = True
            '
            'CtCombobox1
            '
            Me.CtCombobox1.BackColor = System.Drawing.SystemColors.ControlLight
            Me.CtCombobox1.BegFindValue = Nothing
            Me.CtCombobox1.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.CtCombobox1, 3)
            Me.CtCombobox1.CurrentSearchTerm = ""
            Me.CtCombobox1.DataValue = Nothing
            Me.CtCombobox1.DefaultValue = Nothing
            Me.CtCombobox1.DisplayMember = "Name"
            Me.CtCombobox1.EditingMode = True
            Me.CtCombobox1.EndFindValue = Nothing
            Me.CtCombobox1.FieldDescription = Nothing
            Me.CtCombobox1.FieldName = Nothing
            Me.CtCombobox1.FilterRule = Nothing
            Me.CtCombobox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CtCombobox1.FindEnabled = False
            Me.CtCombobox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CtCombobox1.FormattingEnabled = True
            Me.CtCombobox1.HideWhenNotEditingOrAdding = False
            Me.CtCombobox1.IgnoreCase = False
            Me.CtCombobox1.LinkedLabel = Nothing
            Me.CtCombobox1.Location = New System.Drawing.Point(123, 98)
            Me.CtCombobox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CtCombobox1.Name = "CtCombobox1"
            Me.CtCombobox1.OldValue = 0
            Me.CtCombobox1.OriginalDataSource = Nothing
            Me.CtCombobox1.OriginalList = Nothing
            Me.CtCombobox1.OverrideDropDownStyleList = False
            Me.CtCombobox1.PreviousSearchTerm = Nothing
            Me.CtCombobox1.PropertySelector = Nothing
            Me.CtCombobox1.Size = New System.Drawing.Size(367, 24)
            Me.CtCombobox1.SuggestBoxHeight = 200
            Me.CtCombobox1.SuggestListOrderRule = Nothing
            Me.CtCombobox1.TabIndex = 9
            Me.CtCombobox1.TextToSearch = Nothing
            Me.CtCombobox1.Translatable = False
            Me.CtCombobox1.ValueIsMandatory = False
            Me.CtCombobox1.ValueIsNullable = False
            Me.CtCombobox1.ValueIsNumeric = False
            Me.CtCombobox1.ValueMember = "IdNo"
            '
            'CtCombobox2
            '
            Me.CtCombobox2.BackColor = System.Drawing.Color.White
            Me.CtCombobox2.BegFindValue = Nothing
            Me.CtCombobox2.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.CtCombobox2, 3)
            Me.CtCombobox2.CurrentSearchTerm = ""
            Me.CtCombobox2.DataValue = Nothing
            Me.CtCombobox2.DefaultValue = Nothing
            Me.CtCombobox2.DisplayMember = "Name"
            Me.CtCombobox2.EditingMode = True
            Me.CtCombobox2.EndFindValue = Nothing
            Me.CtCombobox2.FieldDescription = Nothing
            Me.CtCombobox2.FieldName = Nothing
            Me.CtCombobox2.FilterRule = Nothing
            Me.CtCombobox2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CtCombobox2.FindEnabled = False
            Me.CtCombobox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CtCombobox2.FormattingEnabled = True
            Me.CtCombobox2.HideWhenNotEditingOrAdding = False
            Me.CtCombobox2.IgnoreCase = False
            Me.CtCombobox2.LinkedLabel = Nothing
            Me.CtCombobox2.Location = New System.Drawing.Point(123, 121)
            Me.CtCombobox2.Margin = New System.Windows.Forms.Padding(1)
            Me.CtCombobox2.Name = "CtCombobox2"
            Me.CtCombobox2.OldValue = 0
            Me.CtCombobox2.OriginalDataSource = Nothing
            Me.CtCombobox2.OriginalList = Nothing
            Me.CtCombobox2.OverrideDropDownStyleList = False
            Me.CtCombobox2.PreviousSearchTerm = Nothing
            Me.CtCombobox2.PropertySelector = Nothing
            Me.CtCombobox2.Size = New System.Drawing.Size(367, 24)
            Me.CtCombobox2.SuggestBoxHeight = 200
            Me.CtCombobox2.SuggestListOrderRule = Nothing
            Me.CtCombobox2.TabIndex = 10
            Me.CtCombobox2.TextToSearch = Nothing
            Me.CtCombobox2.Translatable = False
            Me.CtCombobox2.ValueIsMandatory = False
            Me.CtCombobox2.ValueIsNullable = False
            Me.CtCombobox2.ValueIsNumeric = False
            Me.CtCombobox2.ValueMember = "IdNo"
            '
            'ReportSelectorForm2
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(984, 563)
            Me.Controls.Add(Me.CTabControl1)
            Me.MinimumSize = New System.Drawing.Size(300, 590)
            Me.Name = "ReportSelectorForm2"
            Me.Text = "Report Selector"
            Me.Controls.SetChildIndex(Me.CTabControl1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewReportList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsReportList, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CTabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.FlowLayoutPanel1.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsReportList As Windows.Forms.BindingSource
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents EmployeeNameDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents NationalIdNoDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents PictureDataGridViewImageColumn As DataGridViewImageColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
        Friend WithEvents DataGridViewReportList As CtDataGridView
        Friend WithEvents ReportName As DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As CDgvTextColumn
        Friend WithEvents CTabControl1 As CTabControl
        Friend WithEvents TabPage1 As TabPage
        Friend WithEvents TabPage2 As TabPage
        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents CListBox1 As CListBox
        Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents lblReportName As CLabel
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents CCustomDateTimePicker1 As CCustomDateTimePicker
        Friend WithEvents CCustomDateTimePicker2 As CCustomDateTimePicker
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents CLabel6 As CLabel
        Friend WithEvents CtCombobox1 As CtCombobox
        Friend WithEvents CtCombobox2 As CtCombobox
    End Class
End Namespace