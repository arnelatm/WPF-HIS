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
            Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
            Me.cboPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbcPayroll = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpAttendance = New System.Windows.Forms.TabPage()
            Me.DataGridViewPayrollAttendance = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvSelected = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.dgvEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvDaysAbsentWoPay = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvDaysAbsentWithPay = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvDaysVacationLeave = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvDaysOff = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvDaysPresent = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.dgvDaysTotal = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPayrollAttendance = New System.Windows.Forms.BindingSource(Me.components)
            Me.tbpOvertime = New System.Windows.Forms.TabPage()
            Me.DataGridViewPayrollOvertime = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvSequenceOvertime = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvEmployeeIdNoOt = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.OvertimeRegularDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.OvertimeHolidayDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.OvertimeSpecialDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CDgvDecimalColumn()
            Me.PayrollIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPayrollOvertime = New System.Windows.Forms.BindingSource(Me.components)
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.btnInitializeOvertime = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnInitializeAttendance = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnEmployeeAbsenceEntry = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnNonHolidayLeave = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnHolidayLeave = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnGenerateRegularPayElements = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnViewPayrollReport = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CButton2 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CButton3 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.ProgressBar = New System.Windows.Forms.ProgressBar()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.tbcPayroll.SuspendLayout()
            Me.tbpAttendance.SuspendLayout()
            CType(Me.DataGridViewPayrollAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayrollAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbpOvertime.SuspendLayout()
            CType(Me.DataGridViewPayrollOvertime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayrollOvertime, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(5)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
            Me.SplitContainer1.Size = New System.Drawing.Size(1401, 825)
            Me.SplitContainer1.SplitterDistance = 285
            Me.SplitContainer1.SplitterWidth = 17
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Margin = New System.Windows.Forms.Padding(5)
            Me.FormTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.FormTreeView.Size = New System.Drawing.Size(285, 825)
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = ""
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = ""
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(259, 31)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(95, 26)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtPayrollName
            '
            Me.txtPayrollName.BackColor = System.Drawing.Color.White
            Me.txtPayrollName.BegFindValue = Nothing
            Me.txtPayrollName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayrollName, 3)
            Me.txtPayrollName.ComputedValue = False
            Me.txtPayrollName.CustomFormat = Nothing
            Me.txtPayrollName.DataBoundControl = True
            Me.txtPayrollName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayrollName.EditingMode = False
            Me.txtPayrollName.EndFindValue = Nothing
            Me.txtPayrollName.FieldDescription = Nothing
            Me.txtPayrollName.FieldName = Nothing
            Me.txtPayrollName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayrollName.FindEnabled = True
            Me.txtPayrollName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayrollName.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollName.LinkedLabel = Nothing
            Me.txtPayrollName.Location = New System.Drawing.Point(259, 61)
            Me.txtPayrollName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollName.MaximumValue = Nothing
            Me.txtPayrollName.MinimumValue = Nothing
            Me.txtPayrollName.Name = "txtPayrollName"
            Me.txtPayrollName.OldValue = Nothing
            Me.txtPayrollName.OverrideMaxLength = 0
            Me.txtPayrollName.ReadOnly = True
            Me.txtPayrollName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayrollName.Size = New System.Drawing.Size(772, 26)
            Me.txtPayrollName.TabIndex = 3
            Me.txtPayrollName.Translatable = False
            Me.txtPayrollName.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.TableLayoutPanel1)
            Me.floDataDisplay.Controls.Add(Me.CFlowLayout1)
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floDataDisplay.Location = New System.Drawing.Point(0, 0)
            Me.floDataDisplay.Margin = New System.Windows.Forms.Padding(4)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(1072, 768)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(13, 12, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(1099, 825)
            Me.floDataDisplay.TabIndex = 147
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
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
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(17, 16)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 7
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(1032, 645)
            Me.TableLayoutPanel1.TabIndex = 169
            '
            'dtpStartDate
            '
            Me.dtpStartDate.AutoSize = True
            Me.dtpStartDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpStartDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpStartDate.DefaultValue = Nothing
            Me.dtpStartDate.DisplayOnly = False
            Me.dtpStartDate.DtpDefaultValue = Nothing
            Me.dtpStartDate.EditingMode = True
            Me.dtpStartDate.EditsAllowed = False
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Nothing
            Me.dtpStartDate.Location = New System.Drawing.Point(259, 121)
            Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpStartDate.TabIndex = 5
            Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpStartDate.Translatable = False
            Me.dtpStartDate.Value = Nothing
            Me.dtpStartDate.ValueIsMandatory = False
            Me.dtpStartDate.ValueIsNullable = False
            '
            'dtpEndDate
            '
            Me.dtpEndDate.AutoSize = True
            Me.dtpEndDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpEndDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndDate.DefaultValue = Nothing
            Me.dtpEndDate.DisplayOnly = False
            Me.dtpEndDate.DtpDefaultValue = Nothing
            Me.dtpEndDate.EditingMode = True
            Me.dtpEndDate.EditsAllowed = False
            Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndDate.LinkedLabel = Nothing
            Me.dtpEndDate.Location = New System.Drawing.Point(775, 121)
            Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.ReadOnlyDp = False
            Me.dtpEndDate.SecurityKey = Nothing
            Me.dtpEndDate.ShowLongDate = False
            Me.dtpEndDate.ShowTime = False
            Me.dtpEndDate.Size = New System.Drawing.Size(119, 27)
            Me.dtpEndDate.TabIndex = 6
            Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndDate.Translatable = False
            Me.dtpEndDate.Value = Nothing
            Me.dtpEndDate.ValueIsMandatory = False
            Me.dtpEndDate.ValueIsNullable = False
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblStartDate.Location = New System.Drawing.Point(1, 121)
            Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(189, 28)
            Me.lblStartDate.TabIndex = 157
            Me.lblStartDate.Text = "Start Date"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblStartDate.Translatable = True
            '
            'txtPayrollNameAra
            '
            Me.txtPayrollNameAra.BackColor = System.Drawing.Color.White
            Me.txtPayrollNameAra.BegFindValue = Nothing
            Me.txtPayrollNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayrollNameAra, 3)
            Me.txtPayrollNameAra.ComputedValue = False
            Me.txtPayrollNameAra.CustomFormat = Nothing
            Me.txtPayrollNameAra.DataBoundControl = True
            Me.txtPayrollNameAra.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayrollNameAra.EditingMode = False
            Me.txtPayrollNameAra.EndFindValue = Nothing
            Me.txtPayrollNameAra.EnglishControl = Me.txtPayrollName
            Me.txtPayrollNameAra.FieldDescription = Nothing
            Me.txtPayrollNameAra.FieldName = Nothing
            Me.txtPayrollNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayrollNameAra.FindEnabled = True
            Me.txtPayrollNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayrollNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollNameAra.LinkedLabel = Nothing
            Me.txtPayrollNameAra.Location = New System.Drawing.Point(259, 91)
            Me.txtPayrollNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollNameAra.MaximumValue = Nothing
            Me.txtPayrollNameAra.MinimumValue = Nothing
            Me.txtPayrollNameAra.Name = "txtPayrollNameAra"
            Me.txtPayrollNameAra.OldValue = Nothing
            Me.txtPayrollNameAra.OverrideMaxLength = 0
            Me.txtPayrollNameAra.ReadOnly = True
            Me.txtPayrollNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtPayrollNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayrollNameAra.Size = New System.Drawing.Size(772, 26)
            Me.txtPayrollNameAra.TabIndex = 4
            Me.txtPayrollNameAra.Translatable = False
            '
            'lblPayrollNameAra
            '
            Me.lblPayrollNameAra.BackColor = System.Drawing.Color.Transparent
            Me.lblPayrollNameAra.DisplayOnly = True
            Me.lblPayrollNameAra.EditingMode = False
            Me.lblPayrollNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayrollNameAra.Location = New System.Drawing.Point(1, 91)
            Me.lblPayrollNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayrollNameAra.Name = "lblPayrollNameAra"
            Me.lblPayrollNameAra.Size = New System.Drawing.Size(189, 28)
            Me.lblPayrollNameAra.TabIndex = 167
            Me.lblPayrollNameAra.Text = "Name (Arabic)"
            Me.lblPayrollNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayrollNameAra.Translatable = True
            '
            'lblPayrollName
            '
            Me.lblPayrollName.BackColor = System.Drawing.Color.Transparent
            Me.lblPayrollName.DisplayOnly = True
            Me.lblPayrollName.EditingMode = False
            Me.lblPayrollName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayrollName.Location = New System.Drawing.Point(1, 61)
            Me.lblPayrollName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayrollName.Name = "lblPayrollName"
            Me.lblPayrollName.Size = New System.Drawing.Size(189, 28)
            Me.lblPayrollName.TabIndex = 164
            Me.lblPayrollName.Text = "Name"
            Me.lblPayrollName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayrollName.Translatable = True
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblEndDate.Location = New System.Drawing.Point(517, 121)
            Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(189, 28)
            Me.lblEndDate.TabIndex = 161
            Me.lblEndDate.Text = "End Date"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEndDate.Translatable = True
            '
            'txtPayrollCode
            '
            Me.txtPayrollCode.BackColor = System.Drawing.Color.White
            Me.txtPayrollCode.BegFindValue = Nothing
            Me.txtPayrollCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayrollCode.ComputedValue = False
            Me.txtPayrollCode.CustomFormat = Nothing
            Me.txtPayrollCode.DataBoundControl = True
            Me.txtPayrollCode.EditingMode = False
            Me.txtPayrollCode.EndFindValue = Nothing
            Me.txtPayrollCode.FieldDescription = Nothing
            Me.txtPayrollCode.FieldName = Nothing
            Me.txtPayrollCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayrollCode.FindEnabled = True
            Me.txtPayrollCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayrollCode.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollCode.LinkedLabel = Nothing
            Me.txtPayrollCode.Location = New System.Drawing.Point(775, 31)
            Me.txtPayrollCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollCode.MaximumValue = Nothing
            Me.txtPayrollCode.MinimumValue = Nothing
            Me.txtPayrollCode.Name = "txtPayrollCode"
            Me.txtPayrollCode.OldValue = Nothing
            Me.txtPayrollCode.OverrideMaxLength = 0
            Me.txtPayrollCode.ReadOnly = True
            Me.txtPayrollCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayrollCode.Size = New System.Drawing.Size(95, 26)
            Me.txtPayrollCode.TabIndex = 2
            Me.txtPayrollCode.Translatable = False
            Me.txtPayrollCode.ValueIsMandatory = True
            '
            'lblPayrollCode
            '
            Me.lblPayrollCode.BackColor = System.Drawing.Color.Transparent
            Me.lblPayrollCode.DisplayOnly = True
            Me.lblPayrollCode.EditingMode = False
            Me.lblPayrollCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayrollCode.Location = New System.Drawing.Point(517, 31)
            Me.lblPayrollCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayrollCode.Name = "lblPayrollCode"
            Me.lblPayrollCode.Size = New System.Drawing.Size(104, 28)
            Me.lblPayrollCode.TabIndex = 168
            Me.lblPayrollCode.Text = "Code"
            Me.lblPayrollCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayrollCode.Translatable = True
            '
            'cboPayCycleIdNo
            '
            Me.cboPayCycleIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayCycleIdNo.BegFindValue = Nothing
            Me.cboPayCycleIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboPayCycleIdNo, 3)
            Me.cboPayCycleIdNo.CurrentSearchTerm = ""
            Me.cboPayCycleIdNo.DataValue = Nothing
            Me.cboPayCycleIdNo.DefaultValue = Nothing
            Me.cboPayCycleIdNo.DisplayMember = "Name"
            Me.cboPayCycleIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPayCycleIdNo.Editable = True
            Me.cboPayCycleIdNo.EditingMode = True
            Me.cboPayCycleIdNo.EndFindValue = Nothing
            Me.cboPayCycleIdNo.FieldDescription = Nothing
            Me.cboPayCycleIdNo.FieldName = Nothing
            Me.cboPayCycleIdNo.FilterRule = Nothing
            Me.cboPayCycleIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPayCycleIdNo.FindEnabled = False
            Me.cboPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayCycleIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayCycleIdNo.FormattingEnabled = True
            Me.cboPayCycleIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayCycleIdNo.IgnoreCase = False
            Me.cboPayCycleIdNo.IntegralHeight = False
            Me.cboPayCycleIdNo.LimitToList = False
            Me.cboPayCycleIdNo.LinkedLabel = Nothing
            Me.cboPayCycleIdNo.Location = New System.Drawing.Point(259, 1)
            Me.cboPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayCycleIdNo.Name = "cboPayCycleIdNo"
            Me.cboPayCycleIdNo.OldValue = 0
            Me.cboPayCycleIdNo.OriginalDataSource = Nothing
            Me.cboPayCycleIdNo.OriginalList = Nothing
            Me.cboPayCycleIdNo.OverrideDropDownStyleList = False
            Me.cboPayCycleIdNo.PreviousSearchTerm = Nothing
            Me.cboPayCycleIdNo.PropertySelector = Nothing
            Me.cboPayCycleIdNo.Size = New System.Drawing.Size(772, 28)
            Me.cboPayCycleIdNo.SuggestBoxHeight = 200
            Me.cboPayCycleIdNo.SuggestCharCount = 0
            Me.cboPayCycleIdNo.SuggestListOrderRule = Nothing
            Me.cboPayCycleIdNo.TabIndex = 1
            Me.cboPayCycleIdNo.TextToSearch = Nothing
            Me.cboPayCycleIdNo.Translatable = False
            Me.cboPayCycleIdNo.ValueIsMandatory = False
            Me.cboPayCycleIdNo.ValueIsNullable = False
            Me.cboPayCycleIdNo.ValueIsNumeric = False
            Me.cboPayCycleIdNo.ValueMember = "IdNo"
            '
            'lblPayCycleIdNo
            '
            Me.lblPayCycleIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblPayCycleIdNo.DisplayOnly = True
            Me.lblPayCycleIdNo.EditingMode = False
            Me.lblPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayCycleIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayCycleIdNo.Name = "lblPayCycleIdNo"
            Me.lblPayCycleIdNo.Size = New System.Drawing.Size(189, 28)
            Me.lblPayCycleIdNo.TabIndex = 156
            Me.lblPayCycleIdNo.Text = "Pay Cycle "
            Me.lblPayCycleIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayCycleIdNo.Translatable = True
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(1, 31)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(189, 28)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'tbcPayroll
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.tbcPayroll, 4)
            Me.tbcPayroll.Controls.Add(Me.tbpAttendance)
            Me.tbcPayroll.Controls.Add(Me.tbpOvertime)
            Me.tbcPayroll.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbcPayroll.Location = New System.Drawing.Point(4, 154)
            Me.tbcPayroll.Margin = New System.Windows.Forms.Padding(4)
            Me.tbcPayroll.Name = "tbcPayroll"
            Me.tbcPayroll.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.tbcPayroll.SelectedIndex = 0
            Me.tbcPayroll.Size = New System.Drawing.Size(1024, 487)
            Me.tbcPayroll.TabIndex = 172
            '
            'tbpAttendance
            '
            Me.tbpAttendance.Controls.Add(Me.DataGridViewPayrollAttendance)
            Me.tbpAttendance.Location = New System.Drawing.Point(4, 25)
            Me.tbpAttendance.Margin = New System.Windows.Forms.Padding(4)
            Me.tbpAttendance.Name = "tbpAttendance"
            Me.tbpAttendance.Padding = New System.Windows.Forms.Padding(4)
            Me.tbpAttendance.Size = New System.Drawing.Size(1016, 458)
            Me.tbpAttendance.TabIndex = 0
            Me.tbpAttendance.Text = "Attendance"
            Me.tbpAttendance.UseVisualStyleBackColor = True
            '
            'DataGridViewPayrollAttendance
            '
            Me.DataGridViewPayrollAttendance.AllowUserToAddRows = False
            Me.DataGridViewPayrollAttendance.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayrollAttendance.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPayrollAttendance.AutoGenerateColumns = False
            Me.DataGridViewPayrollAttendance.BegFindValue = Nothing
            Me.DataGridViewPayrollAttendance.Cached = False
            Me.DataGridViewPayrollAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayrollAttendance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvSelected, Me.dgvEmployeeIdNo, Me.dgvDaysAbsentWoPay, Me.dgvDaysAbsentWithPay, Me.dgvDaysVacationLeave, Me.dgvDaysOff, Me.dgvDaysPresent, Me.dgvDaysTotal, Me.IdNoDataGridViewTextBoxColumn})
            Me.DataGridViewPayrollAttendance.DataFilter = Nothing
            Me.DataGridViewPayrollAttendance.DataSource = Me.bsPayrollAttendance
            DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPayrollAttendance.DefaultCellStyle = DataGridViewCellStyle11
            Me.DataGridViewPayrollAttendance.DgvFooter = Nothing
            Me.DataGridViewPayrollAttendance.DisplayOnly = False
            Me.DataGridViewPayrollAttendance.Ea = Nothing
            Me.DataGridViewPayrollAttendance.EditingMode = False
            Me.DataGridViewPayrollAttendance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayrollAttendance.EndFindValue = Nothing
            Me.DataGridViewPayrollAttendance.FieldDescription = Nothing
            Me.DataGridViewPayrollAttendance.FieldName = Nothing
            Me.DataGridViewPayrollAttendance.FieldsDictionary = Nothing
            Me.DataGridViewPayrollAttendance.FindColumnNo = CType(0, Short)
            Me.DataGridViewPayrollAttendance.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPayrollAttendance.FindEnabled = False
            Me.DataGridViewPayrollAttendance.FirstRowDeletionEnabled = True
            Me.DataGridViewPayrollAttendance.FirstRowInsertionEnabled = True
            Me.DataGridViewPayrollAttendance.IgnoreCase = False
            Me.DataGridViewPayrollAttendance.IsDirty = False
            Me.DataGridViewPayrollAttendance.Location = New System.Drawing.Point(8, 7)
            Me.DataGridViewPayrollAttendance.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPayrollAttendance.Name = "DataGridViewPayrollAttendance"
            Me.DataGridViewPayrollAttendance.OldCellValue = Nothing
            Me.DataGridViewPayrollAttendance.ReadOnly = True
            Me.DataGridViewPayrollAttendance.RowHeadersWidth = 25
            Me.DataGridViewPayrollAttendance.Searchable = True
            Me.DataGridViewPayrollAttendance.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPayrollAttendance.SecurityKey = ""
            Me.DataGridViewPayrollAttendance.SequenceColumn = "dgvSequence"
            Me.DataGridViewPayrollAttendance.SequenceFieldName = "Sequence"
            Me.DataGridViewPayrollAttendance.ShowFooter = False
            Me.DataGridViewPayrollAttendance.Size = New System.Drawing.Size(993, 426)
            Me.DataGridViewPayrollAttendance.TabIndex = 171
            Me.DataGridViewPayrollAttendance.Translatable = True
            '
            'dgvSequence
            '
            Me.dgvSequence.BegFindValue = Nothing
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.EndFindValue = Nothing
            Me.dgvSequence.FieldDescription = Nothing
            Me.dgvSequence.FieldName = Nothing
            Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequence.FindEnabled = False
            Me.dgvSequence.HeaderText = "Seq"
            Me.dgvSequence.IgnoreCase = False
            Me.dgvSequence.MinimumWidth = 6
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequence.Translatable = False
            Me.dgvSequence.Width = 30
            '
            'dgvSelected
            '
            Me.dgvSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvSelected.BegFindValue = Nothing
            Me.dgvSelected.DataPropertyName = "Selected"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle3.NullValue = False
            Me.dgvSelected.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvSelected.EditingMode = False
            Me.dgvSelected.EndFindValue = Nothing
            Me.dgvSelected.FieldDescription = Nothing
            Me.dgvSelected.FieldName = Nothing
            Me.dgvSelected.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSelected.FindEnabled = False
            Me.dgvSelected.HeaderText = "Select"
            Me.dgvSelected.IgnoreCase = False
            Me.dgvSelected.MinimumWidth = 6
            Me.dgvSelected.Name = "dgvSelected"
            Me.dgvSelected.ReadOnly = True
            Me.dgvSelected.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSelected.Translatable = False
            Me.dgvSelected.Width = 51
            '
            'dgvEmployeeIdNo
            '
            Me.dgvEmployeeIdNo.AutoComplete = False
            Me.dgvEmployeeIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvEmployeeIdNo.DataPropertyName = "EmployeeIdNo"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvEmployeeIdNo.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvEmployeeIdNo.EditingMode = False
            Me.dgvEmployeeIdNo.HeaderText = "EmployeeIdNo"
            Me.dgvEmployeeIdNo.MinimumWidth = 6
            Me.dgvEmployeeIdNo.Name = "dgvEmployeeIdNo"
            Me.dgvEmployeeIdNo.ReadOnly = True
            Me.dgvEmployeeIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEmployeeIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvEmployeeIdNo.SuggestCharCount = 0
            Me.dgvEmployeeIdNo.Translatable = False
            '
            'dgvDaysAbsentWoPay
            '
            Me.dgvDaysAbsentWoPay.DataPropertyName = "DaysAbsentWithoutPay"
            Me.dgvDaysAbsentWoPay.DecimalPlaces = -1
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysAbsentWoPay.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvDaysAbsentWoPay.EditingMode = False
            Me.dgvDaysAbsentWoPay.HeaderText = "Days Leave w/o Pay"
            Me.dgvDaysAbsentWoPay.MinimumWidth = 6
            Me.dgvDaysAbsentWoPay.Name = "dgvDaysAbsentWoPay"
            Me.dgvDaysAbsentWoPay.ReadOnly = True
            Me.dgvDaysAbsentWoPay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDaysAbsentWoPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDaysAbsentWoPay.Translatable = False
            Me.dgvDaysAbsentWoPay.Width = 60
            '
            'dgvDaysAbsentWithPay
            '
            Me.dgvDaysAbsentWithPay.DataPropertyName = "DaysAbsentWithPay"
            Me.dgvDaysAbsentWithPay.DecimalPlaces = -1
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysAbsentWithPay.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvDaysAbsentWithPay.EditingMode = False
            Me.dgvDaysAbsentWithPay.HeaderText = "Days Leave with Pay"
            Me.dgvDaysAbsentWithPay.MinimumWidth = 6
            Me.dgvDaysAbsentWithPay.Name = "dgvDaysAbsentWithPay"
            Me.dgvDaysAbsentWithPay.ReadOnly = True
            Me.dgvDaysAbsentWithPay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDaysAbsentWithPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDaysAbsentWithPay.Translatable = False
            Me.dgvDaysAbsentWithPay.Width = 60
            '
            'dgvDaysVacationLeave
            '
            Me.dgvDaysVacationLeave.DataPropertyName = "DaysVacationLeave"
            Me.dgvDaysVacationLeave.DecimalPlaces = -1
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysVacationLeave.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvDaysVacationLeave.EditingMode = False
            Me.dgvDaysVacationLeave.HeaderText = "Days Vacation Leave"
            Me.dgvDaysVacationLeave.MinimumWidth = 6
            Me.dgvDaysVacationLeave.Name = "dgvDaysVacationLeave"
            Me.dgvDaysVacationLeave.ReadOnly = True
            Me.dgvDaysVacationLeave.Translatable = False
            Me.dgvDaysVacationLeave.Width = 60
            '
            'dgvDaysOff
            '
            Me.dgvDaysOff.DataPropertyName = "DaysOff"
            Me.dgvDaysOff.DecimalPlaces = -1
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysOff.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvDaysOff.EditingMode = False
            Me.dgvDaysOff.HeaderText = "Days Off"
            Me.dgvDaysOff.MinimumWidth = 6
            Me.dgvDaysOff.Name = "dgvDaysOff"
            Me.dgvDaysOff.ReadOnly = True
            Me.dgvDaysOff.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDaysOff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDaysOff.Translatable = False
            Me.dgvDaysOff.Width = 60
            '
            'dgvDaysPresent
            '
            Me.dgvDaysPresent.DataPropertyName = "DaysPresent"
            Me.dgvDaysPresent.DecimalPlaces = -1
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.Format = "#####0.00"
            Me.dgvDaysPresent.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvDaysPresent.EditingMode = False
            Me.dgvDaysPresent.HeaderText = "Days Present"
            Me.dgvDaysPresent.MinimumWidth = 6
            Me.dgvDaysPresent.Name = "dgvDaysPresent"
            Me.dgvDaysPresent.ReadOnly = True
            Me.dgvDaysPresent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDaysPresent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDaysPresent.Translatable = False
            Me.dgvDaysPresent.Width = 60
            '
            'dgvDaysTotal
            '
            Me.dgvDaysTotal.DataPropertyName = "DaysTotal"
            Me.dgvDaysTotal.DecimalPlaces = -1
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysTotal.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvDaysTotal.EditingMode = False
            Me.dgvDaysTotal.HeaderText = "Days Total"
            Me.dgvDaysTotal.MinimumWidth = 6
            Me.dgvDaysTotal.Name = "dgvDaysTotal"
            Me.dgvDaysTotal.ReadOnly = True
            Me.dgvDaysTotal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDaysTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDaysTotal.Translatable = False
            Me.dgvDaysTotal.Width = 60
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn.Visible = False
            Me.IdNoDataGridViewTextBoxColumn.Width = 125
            '
            'bsPayrollAttendance
            '
            Me.bsPayrollAttendance.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.AttendanceItemModel)
            '
            'tbpOvertime
            '
            Me.tbpOvertime.Controls.Add(Me.DataGridViewPayrollOvertime)
            Me.tbpOvertime.Location = New System.Drawing.Point(4, 25)
            Me.tbpOvertime.Margin = New System.Windows.Forms.Padding(4)
            Me.tbpOvertime.Name = "tbpOvertime"
            Me.tbpOvertime.Padding = New System.Windows.Forms.Padding(4)
            Me.tbpOvertime.Size = New System.Drawing.Size(1016, 458)
            Me.tbpOvertime.TabIndex = 1
            Me.tbpOvertime.Text = "Overtime"
            Me.tbpOvertime.UseVisualStyleBackColor = True
            '
            'DataGridViewPayrollOvertime
            '
            DataGridViewCellStyle12.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayrollOvertime.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
            Me.DataGridViewPayrollOvertime.AutoGenerateColumns = False
            Me.DataGridViewPayrollOvertime.BegFindValue = Nothing
            Me.DataGridViewPayrollOvertime.Cached = False
            Me.DataGridViewPayrollOvertime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayrollOvertime.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequenceOvertime, Me.dgvEmployeeIdNoOt, Me.OvertimeRegularDataGridViewTextBoxColumn, Me.OvertimeHolidayDataGridViewTextBoxColumn, Me.OvertimeSpecialDataGridViewTextBoxColumn, Me.PayrollIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn1})
            Me.DataGridViewPayrollOvertime.DataFilter = Nothing
            Me.DataGridViewPayrollOvertime.DataSource = Me.bsPayrollOvertime
            DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPayrollOvertime.DefaultCellStyle = DataGridViewCellStyle18
            Me.DataGridViewPayrollOvertime.DgvFooter = Nothing
            Me.DataGridViewPayrollOvertime.DisplayOnly = False
            Me.DataGridViewPayrollOvertime.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPayrollOvertime.Ea = Nothing
            Me.DataGridViewPayrollOvertime.EditingMode = False
            Me.DataGridViewPayrollOvertime.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayrollOvertime.EndFindValue = Nothing
            Me.DataGridViewPayrollOvertime.FieldDescription = Nothing
            Me.DataGridViewPayrollOvertime.FieldName = Nothing
            Me.DataGridViewPayrollOvertime.FieldsDictionary = Nothing
            Me.DataGridViewPayrollOvertime.FindColumnNo = CType(0, Short)
            Me.DataGridViewPayrollOvertime.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPayrollOvertime.FindEnabled = False
            Me.DataGridViewPayrollOvertime.FirstRowDeletionEnabled = True
            Me.DataGridViewPayrollOvertime.FirstRowInsertionEnabled = True
            Me.DataGridViewPayrollOvertime.IgnoreCase = False
            Me.DataGridViewPayrollOvertime.IsDirty = False
            Me.DataGridViewPayrollOvertime.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewPayrollOvertime.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPayrollOvertime.Name = "DataGridViewPayrollOvertime"
            Me.DataGridViewPayrollOvertime.OldCellValue = Nothing
            Me.DataGridViewPayrollOvertime.ReadOnly = True
            Me.DataGridViewPayrollOvertime.RowHeadersWidth = 25
            Me.DataGridViewPayrollOvertime.Searchable = True
            Me.DataGridViewPayrollOvertime.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPayrollOvertime.SecurityKey = ""
            Me.DataGridViewPayrollOvertime.SequenceColumn = "dgvSequence"
            Me.DataGridViewPayrollOvertime.SequenceFieldName = "Sequence"
            Me.DataGridViewPayrollOvertime.ShowFooter = False
            Me.DataGridViewPayrollOvertime.Size = New System.Drawing.Size(1008, 450)
            Me.DataGridViewPayrollOvertime.TabIndex = 0
            Me.DataGridViewPayrollOvertime.Translatable = True
            '
            'dgvSequenceOvertime
            '
            Me.dgvSequenceOvertime.BegFindValue = Nothing
            Me.dgvSequenceOvertime.DataPropertyName = "Sequence"
            DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
            Me.dgvSequenceOvertime.DefaultCellStyle = DataGridViewCellStyle13
            Me.dgvSequenceOvertime.EditingMode = False
            Me.dgvSequenceOvertime.EndFindValue = Nothing
            Me.dgvSequenceOvertime.FieldDescription = Nothing
            Me.dgvSequenceOvertime.FieldName = Nothing
            Me.dgvSequenceOvertime.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequenceOvertime.FindEnabled = False
            Me.dgvSequenceOvertime.HeaderText = "Seq"
            Me.dgvSequenceOvertime.IgnoreCase = False
            Me.dgvSequenceOvertime.MinimumWidth = 6
            Me.dgvSequenceOvertime.Name = "dgvSequenceOvertime"
            Me.dgvSequenceOvertime.ReadOnly = True
            Me.dgvSequenceOvertime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequenceOvertime.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequenceOvertime.Translatable = False
            Me.dgvSequenceOvertime.Width = 125
            '
            'dgvEmployeeIdNoOt
            '
            Me.dgvEmployeeIdNoOt.AutoComplete = False
            Me.dgvEmployeeIdNoOt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvEmployeeIdNoOt.DataPropertyName = "EmployeeIdNo"
            DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
            Me.dgvEmployeeIdNoOt.DefaultCellStyle = DataGridViewCellStyle14
            Me.dgvEmployeeIdNoOt.EditingMode = False
            Me.dgvEmployeeIdNoOt.HeaderText = "Employee Name"
            Me.dgvEmployeeIdNoOt.MinimumWidth = 6
            Me.dgvEmployeeIdNoOt.Name = "dgvEmployeeIdNoOt"
            Me.dgvEmployeeIdNoOt.ReadOnly = True
            Me.dgvEmployeeIdNoOt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEmployeeIdNoOt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvEmployeeIdNoOt.SuggestCharCount = 0
            Me.dgvEmployeeIdNoOt.Translatable = False
            '
            'OvertimeRegularDataGridViewTextBoxColumn
            '
            Me.OvertimeRegularDataGridViewTextBoxColumn.DataPropertyName = "OvertimeRegular"
            Me.OvertimeRegularDataGridViewTextBoxColumn.DecimalPlaces = -1
            DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
            Me.OvertimeRegularDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle15
            Me.OvertimeRegularDataGridViewTextBoxColumn.EditingMode = False
            Me.OvertimeRegularDataGridViewTextBoxColumn.HeaderText = "Regular Overtime"
            Me.OvertimeRegularDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.OvertimeRegularDataGridViewTextBoxColumn.Name = "OvertimeRegularDataGridViewTextBoxColumn"
            Me.OvertimeRegularDataGridViewTextBoxColumn.ReadOnly = True
            Me.OvertimeRegularDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.OvertimeRegularDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.OvertimeRegularDataGridViewTextBoxColumn.Translatable = False
            Me.OvertimeRegularDataGridViewTextBoxColumn.Width = 125
            '
            'OvertimeHolidayDataGridViewTextBoxColumn
            '
            Me.OvertimeHolidayDataGridViewTextBoxColumn.DataPropertyName = "OvertimeHoliday"
            Me.OvertimeHolidayDataGridViewTextBoxColumn.DecimalPlaces = -1
            DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
            Me.OvertimeHolidayDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle16
            Me.OvertimeHolidayDataGridViewTextBoxColumn.EditingMode = False
            Me.OvertimeHolidayDataGridViewTextBoxColumn.HeaderText = "Holiday Overtime"
            Me.OvertimeHolidayDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.OvertimeHolidayDataGridViewTextBoxColumn.Name = "OvertimeHolidayDataGridViewTextBoxColumn"
            Me.OvertimeHolidayDataGridViewTextBoxColumn.ReadOnly = True
            Me.OvertimeHolidayDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.OvertimeHolidayDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.OvertimeHolidayDataGridViewTextBoxColumn.Translatable = False
            Me.OvertimeHolidayDataGridViewTextBoxColumn.Width = 125
            '
            'OvertimeSpecialDataGridViewTextBoxColumn
            '
            Me.OvertimeSpecialDataGridViewTextBoxColumn.DataPropertyName = "OvertimeSpecial"
            Me.OvertimeSpecialDataGridViewTextBoxColumn.DecimalPlaces = -1
            DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
            Me.OvertimeSpecialDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle17
            Me.OvertimeSpecialDataGridViewTextBoxColumn.EditingMode = False
            Me.OvertimeSpecialDataGridViewTextBoxColumn.HeaderText = "Special Overtime"
            Me.OvertimeSpecialDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.OvertimeSpecialDataGridViewTextBoxColumn.Name = "OvertimeSpecialDataGridViewTextBoxColumn"
            Me.OvertimeSpecialDataGridViewTextBoxColumn.ReadOnly = True
            Me.OvertimeSpecialDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.OvertimeSpecialDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.OvertimeSpecialDataGridViewTextBoxColumn.Translatable = False
            Me.OvertimeSpecialDataGridViewTextBoxColumn.Width = 125
            '
            'PayrollIdNoDataGridViewTextBoxColumn
            '
            Me.PayrollIdNoDataGridViewTextBoxColumn.DataPropertyName = "PayrollIdNo"
            Me.PayrollIdNoDataGridViewTextBoxColumn.HeaderText = "PayrollIdNo"
            Me.PayrollIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.PayrollIdNoDataGridViewTextBoxColumn.Name = "PayrollIdNoDataGridViewTextBoxColumn"
            Me.PayrollIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.PayrollIdNoDataGridViewTextBoxColumn.Visible = False
            Me.PayrollIdNoDataGridViewTextBoxColumn.Width = 125
            '
            'IdNoDataGridViewTextBoxColumn1
            '
            Me.IdNoDataGridViewTextBoxColumn1.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn1.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn1.MinimumWidth = 6
            Me.IdNoDataGridViewTextBoxColumn1.Name = "IdNoDataGridViewTextBoxColumn1"
            Me.IdNoDataGridViewTextBoxColumn1.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn1.Visible = False
            Me.IdNoDataGridViewTextBoxColumn1.Width = 125
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
            Me.CFlowLayout1.Controls.Add(Me.btnEmployeeAbsenceEntry)
            Me.CFlowLayout1.Controls.Add(Me.btnNonHolidayLeave)
            Me.CFlowLayout1.Controls.Add(Me.btnHolidayLeave)
            Me.CFlowLayout1.Controls.Add(Me.btnGenerateRegularPayElements)
            Me.CFlowLayout1.Controls.Add(Me.btnViewPayrollReport)
            Me.CFlowLayout1.Controls.Add(Me.CButton1)
            Me.CFlowLayout1.Controls.Add(Me.CButton2)
            Me.CFlowLayout1.Controls.Add(Me.CButton3)
            Me.CFlowLayout1.Controls.Add(Me.ProgressBar)
            Me.CFlowLayout1.Location = New System.Drawing.Point(17, 669)
            Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(1031, 132)
            Me.CFlowLayout1.TabIndex = 175
            '
            'btnInitializeOvertime
            '
            Me.btnInitializeOvertime.DesignerSelected = False
            Me.btnInitializeOvertime.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnInitializeOvertime.ImageIndex = 0
            Me.btnInitializeOvertime.Location = New System.Drawing.Point(4, 4)
            Me.btnInitializeOvertime.Margin = New System.Windows.Forms.Padding(4)
            Me.btnInitializeOvertime.Name = "btnInitializeOvertime"
            Me.btnInitializeOvertime.OriginalImageName = Nothing
            Me.btnInitializeOvertime.SecurityKey = ""
            Me.btnInitializeOvertime.Size = New System.Drawing.Size(93, 49)
            Me.btnInitializeOvertime.TabIndex = 169
            Me.btnInitializeOvertime.Text = "Initialize Overtime"
            '
            'btnInitializeAttendance
            '
            Me.btnInitializeAttendance.DesignerSelected = False
            Me.btnInitializeAttendance.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnInitializeAttendance.ImageIndex = 0
            Me.btnInitializeAttendance.Location = New System.Drawing.Point(105, 4)
            Me.btnInitializeAttendance.Margin = New System.Windows.Forms.Padding(4)
            Me.btnInitializeAttendance.Name = "btnInitializeAttendance"
            Me.btnInitializeAttendance.OriginalImageName = Nothing
            Me.btnInitializeAttendance.SecurityKey = ""
            Me.btnInitializeAttendance.Size = New System.Drawing.Size(108, 49)
            Me.btnInitializeAttendance.TabIndex = 173
            Me.btnInitializeAttendance.Text = "Initialize Attendance"
            '
            'btnEmployeeAbsenceEntry
            '
            Me.btnEmployeeAbsenceEntry.DesignerSelected = False
            Me.btnEmployeeAbsenceEntry.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEmployeeAbsenceEntry.ImageIndex = 0
            Me.btnEmployeeAbsenceEntry.Location = New System.Drawing.Point(221, 4)
            Me.btnEmployeeAbsenceEntry.Margin = New System.Windows.Forms.Padding(4)
            Me.btnEmployeeAbsenceEntry.Name = "btnEmployeeAbsenceEntry"
            Me.btnEmployeeAbsenceEntry.OriginalImageName = Nothing
            Me.btnEmployeeAbsenceEntry.SecurityKey = ""
            Me.btnEmployeeAbsenceEntry.Size = New System.Drawing.Size(145, 49)
            Me.btnEmployeeAbsenceEntry.TabIndex = 175
            Me.btnEmployeeAbsenceEntry.Text = "Enter Employee Absences/ Lates"
            '
            'btnNonHolidayLeave
            '
            Me.btnNonHolidayLeave.DesignerSelected = False
            Me.btnNonHolidayLeave.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNonHolidayLeave.ImageIndex = 0
            Me.btnNonHolidayLeave.Location = New System.Drawing.Point(374, 4)
            Me.btnNonHolidayLeave.Margin = New System.Windows.Forms.Padding(4)
            Me.btnNonHolidayLeave.Name = "btnNonHolidayLeave"
            Me.btnNonHolidayLeave.OriginalImageName = Nothing
            Me.btnNonHolidayLeave.SecurityKey = ""
            Me.btnNonHolidayLeave.Size = New System.Drawing.Size(159, 49)
            Me.btnNonHolidayLeave.TabIndex = 176
            Me.btnNonHolidayLeave.Text = "Enter Employee Non Holiday Leaves"
            '
            'btnHolidayLeave
            '
            Me.btnHolidayLeave.DesignerSelected = False
            Me.btnHolidayLeave.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnHolidayLeave.ImageIndex = 0
            Me.btnHolidayLeave.Location = New System.Drawing.Point(541, 4)
            Me.btnHolidayLeave.Margin = New System.Windows.Forms.Padding(4)
            Me.btnHolidayLeave.Name = "btnHolidayLeave"
            Me.btnHolidayLeave.OriginalImageName = Nothing
            Me.btnHolidayLeave.SecurityKey = ""
            Me.btnHolidayLeave.Size = New System.Drawing.Size(116, 49)
            Me.btnHolidayLeave.TabIndex = 177
            Me.btnHolidayLeave.Text = "Enter Employee Holiday Leaves"
            '
            'btnGenerateRegularPayElements
            '
            Me.btnGenerateRegularPayElements.DesignerSelected = False
            Me.btnGenerateRegularPayElements.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGenerateRegularPayElements.ImageIndex = 0
            Me.btnGenerateRegularPayElements.Location = New System.Drawing.Point(665, 4)
            Me.btnGenerateRegularPayElements.Margin = New System.Windows.Forms.Padding(4)
            Me.btnGenerateRegularPayElements.Name = "btnGenerateRegularPayElements"
            Me.btnGenerateRegularPayElements.OriginalImageName = Nothing
            Me.btnGenerateRegularPayElements.SecurityKey = ""
            Me.btnGenerateRegularPayElements.Size = New System.Drawing.Size(161, 49)
            Me.btnGenerateRegularPayElements.TabIndex = 174
            Me.btnGenerateRegularPayElements.Text = "Generate Employee Earnings / Deductions"
            '
            'btnViewPayrollReport
            '
            Me.btnViewPayrollReport.DesignerSelected = False
            Me.CFlowLayout1.SetFlowBreak(Me.btnViewPayrollReport, True)
            Me.btnViewPayrollReport.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnViewPayrollReport.ImageIndex = 0
            Me.btnViewPayrollReport.Location = New System.Drawing.Point(834, 4)
            Me.btnViewPayrollReport.Margin = New System.Windows.Forms.Padding(4)
            Me.btnViewPayrollReport.Name = "btnViewPayrollReport"
            Me.btnViewPayrollReport.OriginalImageName = Nothing
            Me.btnViewPayrollReport.SecurityKey = ""
            Me.btnViewPayrollReport.Size = New System.Drawing.Size(128, 49)
            Me.btnViewPayrollReport.TabIndex = 171
            Me.btnViewPayrollReport.Text = "View/Edit Payroll Details"
            '
            'CButton1
            '
            Me.CButton1.DesignerSelected = False
            Me.CButton1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CButton1.ImageIndex = 0
            Me.CButton1.Location = New System.Drawing.Point(4, 61)
            Me.CButton1.Margin = New System.Windows.Forms.Padding(4)
            Me.CButton1.Name = "CButton1"
            Me.CButton1.OriginalImageName = Nothing
            Me.CButton1.SecurityKey = ""
            Me.CButton1.Size = New System.Drawing.Size(93, 28)
            Me.CButton1.TabIndex = 178
            Me.CButton1.Text = "Select All"
            '
            'CButton2
            '
            Me.CButton2.DesignerSelected = False
            Me.CButton2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CButton2.ImageIndex = 0
            Me.CButton2.Location = New System.Drawing.Point(105, 61)
            Me.CButton2.Margin = New System.Windows.Forms.Padding(4)
            Me.CButton2.Name = "CButton2"
            Me.CButton2.OriginalImageName = Nothing
            Me.CButton2.SecurityKey = ""
            Me.CButton2.Size = New System.Drawing.Size(108, 28)
            Me.CButton2.TabIndex = 179
            Me.CButton2.Text = "Unselect All"
            '
            'CButton3
            '
            Me.CButton3.DesignerSelected = False
            Me.CButton3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CButton3.ImageIndex = 0
            Me.CButton3.Location = New System.Drawing.Point(221, 61)
            Me.CButton3.Margin = New System.Windows.Forms.Padding(4)
            Me.CButton3.Name = "CButton3"
            Me.CButton3.OriginalImageName = Nothing
            Me.CButton3.SecurityKey = ""
            Me.CButton3.Size = New System.Drawing.Size(145, 28)
            Me.CButton3.TabIndex = 180
            Me.CButton3.Text = "Post Payroll"
            '
            'ProgressBar
            '
            Me.ProgressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.ProgressBar.Location = New System.Drawing.Point(4, 97)
            Me.ProgressBar.Margin = New System.Windows.Forms.Padding(4)
            Me.ProgressBar.Name = "ProgressBar"
            Me.ProgressBar.Size = New System.Drawing.Size(1019, 28)
            Me.ProgressBar.TabIndex = 148
            Me.ProgressBar.Visible = False
            '
            'PayrollEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.ClientSize = New System.Drawing.Size(1401, 880)
            Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
            Me.Name = "PayrollEntryTv"
            Me.Text = "Payroll Maintenance Form"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
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
        Friend WithEvents cboPayCycleIdNo As CtCombobox
        Friend WithEvents dtpStartDate As CCustomDateTimePicker
        Friend WithEvents dtpEndDate As CCustomDateTimePicker
        Friend WithEvents lblPayrollNameAra As CLabel
        Friend WithEvents txtPayrollNameAra As CTextBoxArabic
        Friend WithEvents lblPayrollCode As CLabel
        Friend WithEvents txtPayrollCode As CTextBox
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents btnInitializeOvertime As CButton
        Friend WithEvents btnViewPayrollReport As CButton
        Friend WithEvents bsPayrollAttendance As BindingSource
        Friend WithEvents tbcPayroll As CTabControl
        Friend WithEvents tbpAttendance As TabPage
        Friend WithEvents tbpOvertime As TabPage
        Friend WithEvents DataGridViewPayrollAttendance As CtDataGridView
        Friend WithEvents DataGridViewPayrollOvertime As CtDataGridView
        Friend WithEvents btnInitializeAttendance As CButton
        Friend WithEvents bsPayrollOvertime As BindingSource
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents btnGenerateRegularPayElements As CButton
        Friend WithEvents ProgressBar As ProgressBar
        Friend WithEvents dgvSequenceOvertime As CDgvTextColumn
        Friend WithEvents dgvEmployeeIdNoOt As CDgvComboBoxColumn
        Friend WithEvents OvertimeRegularDataGridViewTextBoxColumn As CdgvDecimalColumn
        Friend WithEvents OvertimeHolidayDataGridViewTextBoxColumn As CdgvDecimalColumn
        Friend WithEvents OvertimeSpecialDataGridViewTextBoxColumn As CdgvDecimalColumn
        Friend WithEvents PayrollIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents btnEmployeeAbsenceEntry As CButton
        Friend WithEvents btnNonHolidayLeave As CButton
        Friend WithEvents btnHolidayLeave As CButton
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvSelected As CDgvCheckBoxColumn
        Friend WithEvents dgvEmployeeIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvDaysAbsentWoPay As CDgvDecimalColumn
        Friend WithEvents dgvDaysAbsentWithPay As CDgvDecimalColumn
        Friend WithEvents dgvDaysVacationLeave As CDgvDecimalColumn
        Friend WithEvents dgvDaysOff As CDgvDecimalColumn
        Friend WithEvents dgvDaysPresent As CDgvDecimalColumn
        Friend WithEvents dgvDaysTotal As CDgvDecimalColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CButton1 As CButton
        Friend WithEvents CButton2 As CButton
        Friend WithEvents CButton3 As CButton
    End Class
End Namespace