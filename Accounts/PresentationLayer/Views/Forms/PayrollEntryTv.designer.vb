Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayrollEntryTv
        Inherits CFormEntryTv

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayrollEntryTv))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtPayrollName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.lblPayrollNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayrollName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.tbcPayroll = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
        Me.tbpAttendance = New System.Windows.Forms.TabPage()
        Me.DataGridViewPayrollAttendance = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.bsPayrollAttendance = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbpOvertime = New System.Windows.Forms.TabPage()
        Me.DataGridViewPayrollOvertime = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.dgvSequenceOvertime = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvEmployeeIdNoOt = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.OvertimeRegularDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CdgvDecimalColumn()
        Me.OvertimeHolidayDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CdgvDecimalColumn()
        Me.OvertimeSpecialDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CdgvDecimalColumn()
        Me.PayrollIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsPayrollOvertime = New System.Windows.Forms.BindingSource(Me.components)
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnInitializeOvertime = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnInitializeAttendance = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CButton2 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CButton3 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.dgvEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaDgvComboBoxColumn()
        Me.dgvDaysAbsentWoPay = New AATM.Libraries.CBaseControlsLibrary.CdgvDecimalColumn()
        Me.dgvDaysAbsentWithPay = New AATM.Libraries.CBaseControlsLibrary.CdgvDecimalColumn()
        Me.dgvDaysOff = New AATM.Libraries.CBaseControlsLibrary.CdgvDecimalColumn()
        Me.dgvDaysPresent = New AATM.Libraries.CBaseControlsLibrary.CdgvDecimalColumn()
        Me.dgvDaysTotal = New AATM.Libraries.CBaseControlsLibrary.CdgvDecimalColumn()
        Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.tbcPayroll.SuspendLayout
        Me.tbpAttendance.SuspendLayout
        CType(Me.DataGridViewPayrollAttendance,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPayrollAttendance,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tbpOvertime.SuspendLayout
        CType(Me.DataGridViewPayrollOvertime,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsPayrollOvertime,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.MinimumSize = New System.Drawing.Size(300, 258)
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 624)
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.Location = New System.Drawing.Point(194, 27)
        Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.Size = New System.Drawing.Size(72, 23)
        Me.TxtIdNo.TabIndex = 0
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'txtPayrollName
        '
        Me.txtPayrollName.BackColor = System.Drawing.Color.White
        Me.txtPayrollName.BegFindValue = Nothing
        Me.txtPayrollName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayrollName, 3)
        Me.txtPayrollName.ComputedValue = false
        Me.txtPayrollName.CustomFormat = Nothing
        Me.txtPayrollName.DataBoundControl = true
        Me.txtPayrollName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayrollName.EditingMode = false
        Me.txtPayrollName.EndFindValue = Nothing
        Me.txtPayrollName.FieldDescription = Nothing
        Me.txtPayrollName.FieldName = Nothing
        Me.txtPayrollName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollName.FindEnabled = true
        Me.txtPayrollName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayrollName.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollName.LinkedLabel = Nothing
        Me.txtPayrollName.Location = New System.Drawing.Point(194, 52)
        Me.txtPayrollName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayrollName.MaximumValue = Nothing
        Me.txtPayrollName.MinimumValue = Nothing
        Me.txtPayrollName.Name = "txtPayrollName"
        Me.txtPayrollName.OldValue = Nothing
        Me.txtPayrollName.ReadOnly = true
        Me.txtPayrollName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollName.Size = New System.Drawing.Size(579, 23)
        Me.txtPayrollName.TabIndex = 3
        Me.txtPayrollName.ValueIsMandatory = true
        '
        'floDataDisplay
        '
        Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.TableLayoutPanel1)
        Me.floDataDisplay.Controls.Add(Me.CFlowLayout1)
        Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
        Me.floDataDisplay.Location = New System.Drawing.Point(300, 53)
        Me.floDataDisplay.MinimumSize = New System.Drawing.Size(804, 624)
        Me.floDataDisplay.Name = "floDataDisplay"
        Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.floDataDisplay.Size = New System.Drawing.Size(804, 624)
        Me.floDataDisplay.TabIndex = 147
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.Controls.Add(Me.dtpStartDate, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStartDate, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayrollNameAra, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayrollNameAra, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayrollName, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEndDate, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayrollCode, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayrollCode, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPayCycleIdNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayCycleIdNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayrollName, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbcPayroll, 0, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(774, 524)
        Me.TableLayoutPanel1.TabIndex = 169
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpStartDate.DefaultValue = Nothing
        Me.dtpStartDate.DisplayOnly = false
        Me.dtpStartDate.DtpDefaultValue = Nothing
        Me.dtpStartDate.EditingMode = true
        Me.dtpStartDate.EditsAllowed = false
        Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
        Me.dtpStartDate.LinkedLabel = Nothing
        Me.dtpStartDate.Location = New System.Drawing.Point(194, 102)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ReadOnlyDp = false
        Me.dtpStartDate.SecurityKey = Nothing
        Me.dtpStartDate.ShowLongDate = false
        Me.dtpStartDate.ShowTime = false
        Me.dtpStartDate.Size = New System.Drawing.Size(113, 25)
        Me.dtpStartDate.TabIndex = 5
        Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpStartDate.Value = Nothing
        Me.dtpStartDate.ValueIsMandatory = false
        Me.dtpStartDate.ValueIsNullable = false
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndDate.DefaultValue = Nothing
        Me.dtpEndDate.DisplayOnly = false
        Me.dtpEndDate.DtpDefaultValue = Nothing
        Me.dtpEndDate.EditingMode = true
        Me.dtpEndDate.EditsAllowed = false
        Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndDate.LinkedLabel = Nothing
        Me.dtpEndDate.Location = New System.Drawing.Point(580, 102)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ReadOnlyDp = false
        Me.dtpEndDate.SecurityKey = Nothing
        Me.dtpEndDate.ShowLongDate = false
        Me.dtpEndDate.ShowTime = false
        Me.dtpEndDate.Size = New System.Drawing.Size(114, 25)
        Me.dtpEndDate.TabIndex = 6
        Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpEndDate.Value = Nothing
        Me.dtpEndDate.ValueIsMandatory = false
        Me.dtpEndDate.ValueIsNullable = false
        '
        'lblStartDate
        '
        Me.lblStartDate.DisplayOnly = true
        Me.lblStartDate.EditingMode = false
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblStartDate.Location = New System.Drawing.Point(1, 102)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(142, 23)
        Me.lblStartDate.TabIndex = 157
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayrollNameAra
        '
        Me.txtPayrollNameAra.BackColor = System.Drawing.Color.White
        Me.txtPayrollNameAra.BegFindValue = Nothing
        Me.txtPayrollNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayrollNameAra, 3)
        Me.txtPayrollNameAra.ComputedValue = false
        Me.txtPayrollNameAra.CustomFormat = Nothing
        Me.txtPayrollNameAra.DataBoundControl = true
        Me.txtPayrollNameAra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayrollNameAra.EditingMode = false
        Me.txtPayrollNameAra.EndFindValue = Nothing
        Me.txtPayrollNameAra.EnglishControl = Me.txtPayrollName
        Me.txtPayrollNameAra.FieldDescription = Nothing
        Me.txtPayrollNameAra.FieldName = Nothing
        Me.txtPayrollNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollNameAra.FindEnabled = true
        Me.txtPayrollNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayrollNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollNameAra.LinkedLabel = Nothing
        Me.txtPayrollNameAra.Location = New System.Drawing.Point(194, 77)
        Me.txtPayrollNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayrollNameAra.MaximumValue = Nothing
        Me.txtPayrollNameAra.MinimumValue = Nothing
        Me.txtPayrollNameAra.Name = "txtPayrollNameAra"
        Me.txtPayrollNameAra.OldValue = Nothing
        Me.txtPayrollNameAra.ReadOnly = true
        Me.txtPayrollNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPayrollNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollNameAra.Size = New System.Drawing.Size(579, 23)
        Me.txtPayrollNameAra.TabIndex = 4
        '
        'lblPayrollNameAra
        '
        Me.lblPayrollNameAra.DisplayOnly = true
        Me.lblPayrollNameAra.EditingMode = false
        Me.lblPayrollNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayrollNameAra.Location = New System.Drawing.Point(1, 77)
        Me.lblPayrollNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayrollNameAra.Name = "lblPayrollNameAra"
        Me.lblPayrollNameAra.Size = New System.Drawing.Size(142, 23)
        Me.lblPayrollNameAra.TabIndex = 167
        Me.lblPayrollNameAra.Text = "Name (Arabic)"
        Me.lblPayrollNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayrollName
        '
        Me.lblPayrollName.DisplayOnly = true
        Me.lblPayrollName.EditingMode = false
        Me.lblPayrollName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayrollName.Location = New System.Drawing.Point(1, 52)
        Me.lblPayrollName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayrollName.Name = "lblPayrollName"
        Me.lblPayrollName.Size = New System.Drawing.Size(142, 23)
        Me.lblPayrollName.TabIndex = 164
        Me.lblPayrollName.Text = "Name"
        Me.lblPayrollName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndDate
        '
        Me.lblEndDate.DisplayOnly = true
        Me.lblEndDate.EditingMode = false
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEndDate.Location = New System.Drawing.Point(387, 102)
        Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(142, 23)
        Me.lblEndDate.TabIndex = 161
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayrollCode
        '
        Me.txtPayrollCode.BackColor = System.Drawing.Color.White
        Me.txtPayrollCode.BegFindValue = Nothing
        Me.txtPayrollCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollCode.ComputedValue = false
        Me.txtPayrollCode.CustomFormat = Nothing
        Me.txtPayrollCode.DataBoundControl = true
        Me.txtPayrollCode.EditingMode = false
        Me.txtPayrollCode.EndFindValue = Nothing
        Me.txtPayrollCode.FieldDescription = Nothing
        Me.txtPayrollCode.FieldName = Nothing
        Me.txtPayrollCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollCode.FindEnabled = true
        Me.txtPayrollCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayrollCode.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollCode.LinkedLabel = Nothing
        Me.txtPayrollCode.Location = New System.Drawing.Point(580, 27)
        Me.txtPayrollCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayrollCode.MaximumValue = Nothing
        Me.txtPayrollCode.MinimumValue = Nothing
        Me.txtPayrollCode.Name = "txtPayrollCode"
        Me.txtPayrollCode.OldValue = Nothing
        Me.txtPayrollCode.ReadOnly = true
        Me.txtPayrollCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollCode.Size = New System.Drawing.Size(72, 23)
        Me.txtPayrollCode.TabIndex = 2
        Me.txtPayrollCode.ValueIsMandatory = true
        '
        'lblPayrollCode
        '
        Me.lblPayrollCode.DisplayOnly = true
        Me.lblPayrollCode.EditingMode = false
        Me.lblPayrollCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayrollCode.Location = New System.Drawing.Point(387, 27)
        Me.lblPayrollCode.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayrollCode.Name = "lblPayrollCode"
        Me.lblPayrollCode.Size = New System.Drawing.Size(78, 23)
        Me.lblPayrollCode.TabIndex = 168
        Me.lblPayrollCode.Text = "Code"
        Me.lblPayrollCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPayCycleIdNo
        '
        Me.cboPayCycleIdNo.BackColor = System.Drawing.Color.White
        Me.cboPayCycleIdNo.BegFindValue = Nothing
        Me.cboPayCycleIdNo.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboPayCycleIdNo, 3)
        Me.cboPayCycleIdNo.CurrentSearchTerm = ""
        Me.cboPayCycleIdNo.DefaultValue = Nothing
        Me.cboPayCycleIdNo.DisplayMember = "Name"
        Me.cboPayCycleIdNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPayCycleIdNo.EditingMode = true
        Me.cboPayCycleIdNo.EndFindValue = Nothing
        Me.cboPayCycleIdNo.FieldDescription = Nothing
        Me.cboPayCycleIdNo.FieldName = Nothing
        Me.cboPayCycleIdNo.FilterRule = Nothing
        Me.cboPayCycleIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboPayCycleIdNo.FindEnabled = false
        Me.cboPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPayCycleIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboPayCycleIdNo.FormattingEnabled = true
        Me.cboPayCycleIdNo.HideWhenNotEditingOrAdding = false
        Me.cboPayCycleIdNo.IgnoreCase = false
        Me.cboPayCycleIdNo.IntegralHeight = false
        Me.cboPayCycleIdNo.LinkedLabel = Nothing
        Me.cboPayCycleIdNo.Location = New System.Drawing.Point(194, 1)
        Me.cboPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPayCycleIdNo.Name = "cboPayCycleIdNo"
        Me.cboPayCycleIdNo.OldValue = 0
        Me.cboPayCycleIdNo.OriginalDataSource = Nothing
        Me.cboPayCycleIdNo.OriginalList = Nothing
        Me.cboPayCycleIdNo.OverrideDropDownStyleList = false
        Me.cboPayCycleIdNo.PreviousSearchTerm = Nothing
        Me.cboPayCycleIdNo.PropertySelector = Nothing
        Me.cboPayCycleIdNo.ReadOnlyCombo = false
        Me.cboPayCycleIdNo.Size = New System.Drawing.Size(579, 24)
        Me.cboPayCycleIdNo.SuggestBoxHeight = 200
        Me.cboPayCycleIdNo.SuggestListOrderRule = Nothing
        Me.cboPayCycleIdNo.TabIndex = 1
        Me.cboPayCycleIdNo.TextToSearch = Nothing
        Me.cboPayCycleIdNo.ValueIsMandatory = false
        Me.cboPayCycleIdNo.ValueIsNullable = false
        Me.cboPayCycleIdNo.ValueIsNumeric = false
        Me.cboPayCycleIdNo.ValueMember = "IdNo"
        '
        'lblPayCycleIdNo
        '
        Me.lblPayCycleIdNo.DisplayOnly = true
        Me.lblPayCycleIdNo.EditingMode = false
        Me.lblPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayCycleIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayCycleIdNo.Name = "lblPayCycleIdNo"
        Me.lblPayCycleIdNo.Size = New System.Drawing.Size(142, 23)
        Me.lblPayCycleIdNo.TabIndex = 156
        Me.lblPayCycleIdNo.Text = "Pay Cycle "
        Me.lblPayCycleIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdNo
        '
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.Location = New System.Drawing.Point(1, 27)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(142, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbcPayroll
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.tbcPayroll, 4)
        Me.tbcPayroll.Controls.Add(Me.tbpAttendance)
        Me.tbcPayroll.Controls.Add(Me.tbpOvertime)
        Me.tbcPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcPayroll.Location = New System.Drawing.Point(3, 131)
        Me.tbcPayroll.Name = "tbcPayroll"
        Me.tbcPayroll.SelectedIndex = 0
        Me.tbcPayroll.Size = New System.Drawing.Size(768, 390)
        Me.tbcPayroll.TabIndex = 172
        '
        'tbpAttendance
        '
        Me.tbpAttendance.Controls.Add(Me.DataGridViewPayrollAttendance)
        Me.tbpAttendance.Location = New System.Drawing.Point(4, 22)
        Me.tbpAttendance.Name = "tbpAttendance"
        Me.tbpAttendance.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAttendance.Size = New System.Drawing.Size(760, 364)
        Me.tbpAttendance.TabIndex = 0
        Me.tbpAttendance.Text = "Attendance"
        Me.tbpAttendance.UseVisualStyleBackColor = true
        '
        'DataGridViewPayrollAttendance
        '
        Me.DataGridViewPayrollAttendance.AllowUserToAddRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPayrollAttendance.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewPayrollAttendance.AutoGenerateColumns = false
        Me.DataGridViewPayrollAttendance.BegFindValue = Nothing
        Me.DataGridViewPayrollAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPayrollAttendance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvEmployeeIdNo, Me.dgvDaysAbsentWoPay, Me.dgvDaysAbsentWithPay, Me.dgvDaysOff, Me.dgvDaysPresent, Me.dgvDaysTotal, Me.IdNoDataGridViewTextBoxColumn})
        Me.DataGridViewPayrollAttendance.DataSource = Me.bsPayrollAttendance
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPayrollAttendance.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewPayrollAttendance.DgvFooter = Nothing
        Me.DataGridViewPayrollAttendance.DisplayOnly = false
        Me.DataGridViewPayrollAttendance.Ea = Nothing
        Me.DataGridViewPayrollAttendance.EditingMode = false
        Me.DataGridViewPayrollAttendance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPayrollAttendance.EndFindValue = Nothing
        Me.DataGridViewPayrollAttendance.FieldDescription = Nothing
        Me.DataGridViewPayrollAttendance.FieldName = Nothing
        Me.DataGridViewPayrollAttendance.FieldsDictionary = Nothing
        Me.DataGridViewPayrollAttendance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewPayrollAttendance.FindEnabled = false
        Me.DataGridViewPayrollAttendance.FirstRowDeletionEnabled = true
        Me.DataGridViewPayrollAttendance.FirstRowInsertionEnabled = true
        Me.DataGridViewPayrollAttendance.IgnoreCase = false
        Me.DataGridViewPayrollAttendance.Location = New System.Drawing.Point(6, 6)
        Me.DataGridViewPayrollAttendance.Name = "DataGridViewPayrollAttendance"
        Me.DataGridViewPayrollAttendance.ReadOnly = true
        Me.DataGridViewPayrollAttendance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewPayrollAttendance.SequenceColumn = "dgvSequence"
        Me.DataGridViewPayrollAttendance.SequenceFieldName = "Sequence"
        Me.DataGridViewPayrollAttendance.ShowFooter = false
        Me.DataGridViewPayrollAttendance.ShowInsertColumnWhenEditing = false
        Me.DataGridViewPayrollAttendance.Size = New System.Drawing.Size(745, 346)
        Me.DataGridViewPayrollAttendance.TabIndex = 171
        '
        'bsPayrollAttendance
        '
        Me.bsPayrollAttendance.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.AttendanceItemModel)
        '
        'tbpOvertime
        '
        Me.tbpOvertime.Controls.Add(Me.DataGridViewPayrollOvertime)
        Me.tbpOvertime.Location = New System.Drawing.Point(4, 22)
        Me.tbpOvertime.Name = "tbpOvertime"
        Me.tbpOvertime.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOvertime.Size = New System.Drawing.Size(760, 364)
        Me.tbpOvertime.TabIndex = 1
        Me.tbpOvertime.Text = "Overtime"
        Me.tbpOvertime.UseVisualStyleBackColor = true
        '
        'DataGridViewPayrollOvertime
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewPayrollOvertime.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewPayrollOvertime.AutoGenerateColumns = false
        Me.DataGridViewPayrollOvertime.BegFindValue = Nothing
        Me.DataGridViewPayrollOvertime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPayrollOvertime.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceOvertime, Me.dgvEmployeeIdNoOt, Me.OvertimeRegularDataGridViewTextBoxColumn, Me.OvertimeHolidayDataGridViewTextBoxColumn, Me.OvertimeSpecialDataGridViewTextBoxColumn, Me.PayrollIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn1})
        Me.DataGridViewPayrollOvertime.DataSource = Me.bsPayrollOvertime
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewPayrollOvertime.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewPayrollOvertime.DgvFooter = Nothing
        Me.DataGridViewPayrollOvertime.DisplayOnly = false
        Me.DataGridViewPayrollOvertime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewPayrollOvertime.Ea = Nothing
        Me.DataGridViewPayrollOvertime.EditingMode = false
        Me.DataGridViewPayrollOvertime.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewPayrollOvertime.EndFindValue = Nothing
        Me.DataGridViewPayrollOvertime.FieldDescription = Nothing
        Me.DataGridViewPayrollOvertime.FieldName = Nothing
        Me.DataGridViewPayrollOvertime.FieldsDictionary = Nothing
        Me.DataGridViewPayrollOvertime.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewPayrollOvertime.FindEnabled = false
        Me.DataGridViewPayrollOvertime.FirstRowDeletionEnabled = true
        Me.DataGridViewPayrollOvertime.FirstRowInsertionEnabled = true
        Me.DataGridViewPayrollOvertime.IgnoreCase = false
        Me.DataGridViewPayrollOvertime.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewPayrollOvertime.Name = "DataGridViewPayrollOvertime"
        Me.DataGridViewPayrollOvertime.ReadOnly = true
        Me.DataGridViewPayrollOvertime.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewPayrollOvertime.SequenceColumn = "dgvSequence"
        Me.DataGridViewPayrollOvertime.SequenceFieldName = "Sequence"
        Me.DataGridViewPayrollOvertime.ShowFooter = false
        Me.DataGridViewPayrollOvertime.ShowInsertColumnWhenEditing = true
        Me.DataGridViewPayrollOvertime.Size = New System.Drawing.Size(754, 358)
        Me.DataGridViewPayrollOvertime.TabIndex = 0
        '
        'dgvSequenceOvertime
        '
        Me.dgvSequenceOvertime.BegFindValue = Nothing
        Me.dgvSequenceOvertime.DataPropertyName = "Sequence"
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        Me.dgvSequenceOvertime.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvSequenceOvertime.EditingMode = false
        Me.dgvSequenceOvertime.EndFindValue = Nothing
        Me.dgvSequenceOvertime.FieldDescription = Nothing
        Me.dgvSequenceOvertime.FieldName = Nothing
        Me.dgvSequenceOvertime.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequenceOvertime.FindEnabled = false
        Me.dgvSequenceOvertime.HeaderText = "Seq"
        Me.dgvSequenceOvertime.IgnoreCase = false
        Me.dgvSequenceOvertime.Name = "dgvSequenceOvertime"
        Me.dgvSequenceOvertime.ReadOnly = true
        Me.dgvSequenceOvertime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequenceOvertime.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        '
        'dgvEmployeeIdNoOt
        '
        Me.dgvEmployeeIdNoOt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvEmployeeIdNoOt.DataPropertyName = "EmployeeIdNo"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.dgvEmployeeIdNoOt.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvEmployeeIdNoOt.EditingMode = false
        Me.dgvEmployeeIdNoOt.HeaderText = "Employee Name"
        Me.dgvEmployeeIdNoOt.Name = "dgvEmployeeIdNoOt"
        Me.dgvEmployeeIdNoOt.ReadOnly = true
        Me.dgvEmployeeIdNoOt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmployeeIdNoOt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'OvertimeRegularDataGridViewTextBoxColumn
        '
        Me.OvertimeRegularDataGridViewTextBoxColumn.DataPropertyName = "OvertimeRegular"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        Me.OvertimeRegularDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle13
        Me.OvertimeRegularDataGridViewTextBoxColumn.EditingMode = false
        Me.OvertimeRegularDataGridViewTextBoxColumn.HeaderText = "Regular Overtime"
        Me.OvertimeRegularDataGridViewTextBoxColumn.Name = "OvertimeRegularDataGridViewTextBoxColumn"
        Me.OvertimeRegularDataGridViewTextBoxColumn.ReadOnly = true
        Me.OvertimeRegularDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OvertimeRegularDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'OvertimeHolidayDataGridViewTextBoxColumn
        '
        Me.OvertimeHolidayDataGridViewTextBoxColumn.DataPropertyName = "OvertimeHoliday"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        Me.OvertimeHolidayDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle14
        Me.OvertimeHolidayDataGridViewTextBoxColumn.EditingMode = false
        Me.OvertimeHolidayDataGridViewTextBoxColumn.HeaderText = "Holiday Overtime"
        Me.OvertimeHolidayDataGridViewTextBoxColumn.Name = "OvertimeHolidayDataGridViewTextBoxColumn"
        Me.OvertimeHolidayDataGridViewTextBoxColumn.ReadOnly = true
        Me.OvertimeHolidayDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OvertimeHolidayDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'OvertimeSpecialDataGridViewTextBoxColumn
        '
        Me.OvertimeSpecialDataGridViewTextBoxColumn.DataPropertyName = "OvertimeSpecial"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        Me.OvertimeSpecialDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle15
        Me.OvertimeSpecialDataGridViewTextBoxColumn.EditingMode = false
        Me.OvertimeSpecialDataGridViewTextBoxColumn.HeaderText = "Special Overtime"
        Me.OvertimeSpecialDataGridViewTextBoxColumn.Name = "OvertimeSpecialDataGridViewTextBoxColumn"
        Me.OvertimeSpecialDataGridViewTextBoxColumn.ReadOnly = true
        Me.OvertimeSpecialDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OvertimeSpecialDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'PayrollIdNoDataGridViewTextBoxColumn
        '
        Me.PayrollIdNoDataGridViewTextBoxColumn.DataPropertyName = "PayrollIdNo"
        Me.PayrollIdNoDataGridViewTextBoxColumn.HeaderText = "PayrollIdNo"
        Me.PayrollIdNoDataGridViewTextBoxColumn.Name = "PayrollIdNoDataGridViewTextBoxColumn"
        Me.PayrollIdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.PayrollIdNoDataGridViewTextBoxColumn.Visible = false
        '
        'IdNoDataGridViewTextBoxColumn1
        '
        Me.IdNoDataGridViewTextBoxColumn1.DataPropertyName = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn1.HeaderText = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn1.Name = "IdNoDataGridViewTextBoxColumn1"
        Me.IdNoDataGridViewTextBoxColumn1.ReadOnly = true
        Me.IdNoDataGridViewTextBoxColumn1.Visible = false
        '
        'bsPayrollOvertime
        '
        Me.bsPayrollOvertime.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.OtWorkHourModel)
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.btnInitializeOvertime)
        Me.CFlowLayout1.Controls.Add(Me.btnInitializeAttendance)
        Me.CFlowLayout1.Controls.Add(Me.CButton1)
        Me.CFlowLayout1.Controls.Add(Me.CButton2)
        Me.CFlowLayout1.Controls.Add(Me.CButton3)
        Me.CFlowLayout1.Controls.Add(Me.ProgressBar)
        Me.CFlowLayout1.Location = New System.Drawing.Point(13, 543)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(773, 75)
        Me.CFlowLayout1.TabIndex = 175
        '
        'btnInitializeOvertime
        '
        Me.btnInitializeOvertime.DesignerSelected = false
        Me.btnInitializeOvertime.DisplayOnly = true
        Me.btnInitializeOvertime.ImageIndex = 0
        Me.btnInitializeOvertime.Location = New System.Drawing.Point(3, 3)
        Me.btnInitializeOvertime.Name = "btnInitializeOvertime"
        Me.btnInitializeOvertime.OriginalImageName = Nothing
        Me.btnInitializeOvertime.SecurityKey = ""
        Me.btnInitializeOvertime.Size = New System.Drawing.Size(90, 40)
        Me.btnInitializeOvertime.TabIndex = 169
        Me.btnInitializeOvertime.Text = "Initialize Overtime"
        '
        'btnInitializeAttendance
        '
        Me.btnInitializeAttendance.DesignerSelected = false
        Me.btnInitializeAttendance.DisplayOnly = true
        Me.btnInitializeAttendance.ImageIndex = 0
        Me.btnInitializeAttendance.Location = New System.Drawing.Point(99, 3)
        Me.btnInitializeAttendance.Name = "btnInitializeAttendance"
        Me.btnInitializeAttendance.OriginalImageName = Nothing
        Me.btnInitializeAttendance.SecurityKey = ""
        Me.btnInitializeAttendance.Size = New System.Drawing.Size(95, 40)
        Me.btnInitializeAttendance.TabIndex = 173
        Me.btnInitializeAttendance.Text = "Initialize Attendance"
        '
        'CButton1
        '
        Me.CButton1.DesignerSelected = false
        Me.CButton1.DisplayOnly = true
        Me.CButton1.ImageIndex = 0
        Me.CButton1.Location = New System.Drawing.Point(200, 3)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.OriginalImageName = Nothing
        Me.CButton1.SecurityKey = ""
        Me.CButton1.Size = New System.Drawing.Size(154, 40)
        Me.CButton1.TabIndex = 174
        Me.CButton1.Text = "Generate Employee Earnings/Deductions"
        '
        'CButton2
        '
        Me.CButton2.DesignerSelected = false
        Me.CButton2.DisplayOnly = true
        Me.CButton2.ImageIndex = 0
        Me.CButton2.Location = New System.Drawing.Point(360, 3)
        Me.CButton2.Name = "CButton2"
        Me.CButton2.OriginalImageName = Nothing
        Me.CButton2.SecurityKey = ""
        Me.CButton2.Size = New System.Drawing.Size(190, 40)
        Me.CButton2.TabIndex = 170
        Me.CButton2.Text = "Enter Manual  Payments/ Deductions"
        '
        'CButton3
        '
        Me.CButton3.DesignerSelected = false
        Me.CButton3.DisplayOnly = true
        Me.CButton3.ImageIndex = 0
        Me.CButton3.Location = New System.Drawing.Point(556, 3)
        Me.CButton3.Name = "CButton3"
        Me.CButton3.OriginalImageName = Nothing
        Me.CButton3.SecurityKey = ""
        Me.CButton3.Size = New System.Drawing.Size(189, 40)
        Me.CButton3.TabIndex = 171
        Me.CButton3.Text = "View Payroll Report"
        '
        'ProgressBar
        '
        Me.ProgressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ProgressBar.Location = New System.Drawing.Point(3, 49)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(764, 23)
        Me.ProgressBar.TabIndex = 148
        Me.ProgressBar.Visible = false
        '
        'dgvSequence
        '
        Me.dgvSequence.BegFindValue = Nothing
        Me.dgvSequence.DataPropertyName = "Sequence"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSequence.DisplayOnly = true
        Me.dgvSequence.EditingMode = true
        Me.dgvSequence.EndFindValue = Nothing
        Me.dgvSequence.FieldDescription = Nothing
        Me.dgvSequence.FieldName = Nothing
        Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvSequence.FindEnabled = false
        Me.dgvSequence.HeaderText = "Seq"
        Me.dgvSequence.IgnoreCase = false
        Me.dgvSequence.Name = "dgvSequence"
        Me.dgvSequence.ReadOnly = true
        Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvSequence.Width = 30
        '
        'dgvEmployeeIdNo
        '
        Me.dgvEmployeeIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvEmployeeIdNo.DataPropertyName = "EmployeeIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvEmployeeIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEmployeeIdNo.EditingMode = false
        Me.dgvEmployeeIdNo.HeaderText = "EmployeeIdNo"
        Me.dgvEmployeeIdNo.Name = "dgvEmployeeIdNo"
        Me.dgvEmployeeIdNo.ReadOnly = true
        Me.dgvEmployeeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmployeeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgvDaysAbsentWoPay
        '
        Me.dgvDaysAbsentWoPay.DataPropertyName = "DaysAbsentWithoutPay"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dgvDaysAbsentWoPay.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDaysAbsentWoPay.EditingMode = false
        Me.dgvDaysAbsentWoPay.HeaderText = "Days Leave w/o Pay"
        Me.dgvDaysAbsentWoPay.Name = "dgvDaysAbsentWoPay"
        Me.dgvDaysAbsentWoPay.ReadOnly = true
        Me.dgvDaysAbsentWoPay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDaysAbsentWoPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDaysAbsentWoPay.Width = 60
        '
        'dgvDaysAbsentWithPay
        '
        Me.dgvDaysAbsentWithPay.DataPropertyName = "DaysAbsentWithPay"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dgvDaysAbsentWithPay.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDaysAbsentWithPay.EditingMode = false
        Me.dgvDaysAbsentWithPay.HeaderText = "Days Leave with Pay"
        Me.dgvDaysAbsentWithPay.Name = "dgvDaysAbsentWithPay"
        Me.dgvDaysAbsentWithPay.ReadOnly = true
        Me.dgvDaysAbsentWithPay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDaysAbsentWithPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDaysAbsentWithPay.Width = 60
        '
        'dgvDaysOff
        '
        Me.dgvDaysOff.DataPropertyName = "DaysOff"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvDaysOff.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDaysOff.EditingMode = false
        Me.dgvDaysOff.HeaderText = "Days Off"
        Me.dgvDaysOff.Name = "dgvDaysOff"
        Me.dgvDaysOff.ReadOnly = true
        Me.dgvDaysOff.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDaysOff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDaysOff.Width = 60
        '
        'dgvDaysPresent
        '
        Me.dgvDaysPresent.DataPropertyName = "DaysPresent"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.Format = "#####0.00"
        Me.dgvDaysPresent.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDaysPresent.EditingMode = false
        Me.dgvDaysPresent.HeaderText = "Days Present"
        Me.dgvDaysPresent.Name = "dgvDaysPresent"
        Me.dgvDaysPresent.ReadOnly = true
        Me.dgvDaysPresent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDaysPresent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDaysPresent.Width = 60
        '
        'dgvDaysTotal
        '
        Me.dgvDaysTotal.DataPropertyName = "DaysTotal"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.dgvDaysTotal.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDaysTotal.EditingMode = false
        Me.dgvDaysTotal.HeaderText = "Days Total"
        Me.dgvDaysTotal.Name = "dgvDaysTotal"
        Me.dgvDaysTotal.ReadOnly = true
        Me.dgvDaysTotal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDaysTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDaysTotal.Width = 60
        '
        'IdNoDataGridViewTextBoxColumn
        '
        Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
        Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
        Me.IdNoDataGridViewTextBoxColumn.ReadOnly = true
        Me.IdNoDataGridViewTextBoxColumn.Visible = false
        '
        'PayrollEntryTv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(1106, 677)
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "PayrollEntryTv"
        Me.Text = "Payroll Maintenance Form"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.tbcPayroll.ResumeLayout(false)
        Me.tbpAttendance.ResumeLayout(false)
        CType(Me.DataGridViewPayrollAttendance,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsPayrollAttendance,System.ComponentModel.ISupportInitialize).EndInit
        Me.tbpOvertime.ResumeLayout(false)
        CType(Me.DataGridViewPayrollOvertime,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsPayrollOvertime,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtPayrollName As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblPayCycleIdNo As CLabel
        Friend WithEvents lblStartDate As CLabel
        Friend WithEvents lblEndDate As CLabel
        Friend WithEvents _MBPayrollCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents lblPayrollName As CLabel
        Friend WithEvents cboPayCycleIdNo As CaComboBox
        Friend WithEvents dtpStartDate As CCustomDateTimePicker
        Friend WithEvents dtpEndDate As CCustomDateTimePicker
        Friend WithEvents lblPayrollNameAra As CLabel
        Friend WithEvents txtPayrollNameAra As CTextBoxArabic
        Friend WithEvents lblPayrollCode As CLabel
        Friend WithEvents txtPayrollCode As CTextBox
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents btnInitializeOvertime As CButton
        Friend WithEvents CButton2 As CButton
        Friend WithEvents CButton3 As CButton
        Friend WithEvents bsPayrollAttendance As BindingSource
        Friend WithEvents tbcPayroll As CTabControl
        Friend WithEvents tbpAttendance As TabPage
        Friend WithEvents tbpOvertime As TabPage
        Friend WithEvents DataGridViewPayrollAttendance As CDataGridView
        Friend WithEvents DataGridViewPayrollOvertime As CDataGridView
        Friend WithEvents btnInitializeAttendance As CButton
        Friend WithEvents bsPayrollOvertime As BindingSource
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents CButton1 As CButton
        Friend WithEvents ProgressBar As ProgressBar
        Friend WithEvents dgvSequenceOvertime As CDgvTextColumn
        Friend WithEvents dgvEmployeeIdNoOt As CaDgvComboBoxColumn
        Friend WithEvents OvertimeRegularDataGridViewTextBoxColumn As CdgvDecimalColumn
        Friend WithEvents OvertimeHolidayDataGridViewTextBoxColumn As CdgvDecimalColumn
        Friend WithEvents OvertimeSpecialDataGridViewTextBoxColumn As CdgvDecimalColumn
        Friend WithEvents PayrollIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvEmployeeIdNo As CaDgvComboBoxColumn
        Friend WithEvents dgvDaysAbsentWoPay As CdgvDecimalColumn
        Friend WithEvents dgvDaysAbsentWithPay As CdgvDecimalColumn
        Friend WithEvents dgvDaysOff As CdgvDecimalColumn
        Friend WithEvents dgvDaysPresent As CdgvDecimalColumn
        Friend WithEvents dgvDaysTotal As CdgvDecimalColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace