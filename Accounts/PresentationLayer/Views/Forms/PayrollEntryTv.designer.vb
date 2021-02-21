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
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtPayrollName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.dtpStartDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.dtpEndDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
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
            Me.btnInitialize = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CButton2 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CButton3 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.tbcPayroll = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpAttendance = New System.Windows.Forms.TabPage()
            Me.DataGridViewPayrollAttendance = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvEmployeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvOvertime = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnDecimal()
            Me.dgvDaysPresent = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnDecimal()
            Me.dgvDaysAbsentWithPay = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnDecimal()
            Me.dgvDaysAbsentWoPay = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnDecimal()
            Me.dgvDaysOff = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnDecimal()
            Me.dgvDaysTotal = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnDecimal()
            Me.EmployeeIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPayrollAttendance = New System.Windows.Forms.BindingSource(Me.components)
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.tbcPayroll.SuspendLayout()
            Me.tbpAttendance.SuspendLayout()
            CType(Me.DataGridViewPayrollAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayrollAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            Me.TreeViewTableName.MinimumSize = New System.Drawing.Size(300, 258)
            Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.TreeViewTableName.Size = New System.Drawing.Size(300, 610)
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
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.Editable = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(194, 27)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.Size = New System.Drawing.Size(72, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtPayrollName
            '
            Me.txtPayrollName.BackColor = System.Drawing.Color.White
            Me.txtPayrollName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayrollName, 3)
            Me.txtPayrollName.ComputedValue = False
            Me.txtPayrollName.CustomFormat = Nothing
            Me.txtPayrollName.DataBoundControl = True
            Me.txtPayrollName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayrollName.EditingMode = False
            Me.txtPayrollName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayrollName.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollName.LinkedLabel = Nothing
            Me.txtPayrollName.Location = New System.Drawing.Point(194, 52)
            Me.txtPayrollName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollName.MaximumValue = Nothing
            Me.txtPayrollName.MinimumValue = Nothing
            Me.txtPayrollName.Name = "txtPayrollName"
            Me.txtPayrollName.OldValue = Nothing
            Me.txtPayrollName.ReadOnly = True
            Me.txtPayrollName.Size = New System.Drawing.Size(579, 23)
            Me.txtPayrollName.TabIndex = 3
            Me.txtPayrollName.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.TableLayoutPanel1)
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
            Me.floDataDisplay.Location = New System.Drawing.Point(300, 53)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(430, 180)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(804, 610)
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
            Me.TableLayoutPanel1.Controls.Add(Me.btnInitialize, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CButton2, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CButton3, 2, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.tbcPayroll, 0, 7)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 13)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 8
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(774, 568)
            Me.TableLayoutPanel1.TabIndex = 169
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpStartDate.DefaultValue = Nothing
            Me.dtpStartDate.DisplayOnly = False
            Me.dtpStartDate.DtpDefaultValue = Nothing
            Me.dtpStartDate.EditingMode = True
            Me.dtpStartDate.EditsAllowed = False
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Nothing
            Me.dtpStartDate.Location = New System.Drawing.Point(194, 102)
            Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.Size = New System.Drawing.Size(107, 25)
            Me.dtpStartDate.TabIndex = 5
            Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpStartDate.Value = Nothing
            Me.dtpStartDate.ValueIsMandatory = False
            Me.dtpStartDate.ValueIsNullable = False
            '
            'dtpEndDate
            '
            Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndDate.DefaultValue = Nothing
            Me.dtpEndDate.DisplayOnly = False
            Me.dtpEndDate.DtpDefaultValue = Nothing
            Me.dtpEndDate.EditingMode = True
            Me.dtpEndDate.EditsAllowed = False
            Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndDate.LinkedLabel = Nothing
            Me.dtpEndDate.Location = New System.Drawing.Point(580, 102)
            Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.ReadOnlyDp = False
            Me.dtpEndDate.SecurityKey = Nothing
            Me.dtpEndDate.ShowLongDate = False
            Me.dtpEndDate.ShowTime = False
            Me.dtpEndDate.Size = New System.Drawing.Size(114, 25)
            Me.dtpEndDate.TabIndex = 6
            Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndDate.Value = Nothing
            Me.dtpEndDate.ValueIsMandatory = False
            Me.dtpEndDate.ValueIsNullable = False
            '
            'lblStartDate
            '
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtPayrollNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayrollNameAra, 3)
            Me.txtPayrollNameAra.ComputedValue = False
            Me.txtPayrollNameAra.CustomFormat = Nothing
            Me.txtPayrollNameAra.DataBoundControl = True
            Me.txtPayrollNameAra.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayrollNameAra.EditingMode = False
            Me.txtPayrollNameAra.EnglishControl = Me.txtPayrollName
            Me.txtPayrollNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayrollNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollNameAra.LinkedLabel = Nothing
            Me.txtPayrollNameAra.Location = New System.Drawing.Point(194, 77)
            Me.txtPayrollNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollNameAra.MaximumValue = Nothing
            Me.txtPayrollNameAra.MinimumValue = Nothing
            Me.txtPayrollNameAra.Name = "txtPayrollNameAra"
            Me.txtPayrollNameAra.OldValue = Nothing
            Me.txtPayrollNameAra.ReadOnly = True
            Me.txtPayrollNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtPayrollNameAra.Size = New System.Drawing.Size(579, 23)
            Me.txtPayrollNameAra.TabIndex = 4
            '
            'lblPayrollNameAra
            '
            Me.lblPayrollNameAra.DisplayOnly = True
            Me.lblPayrollNameAra.EditingMode = False
            Me.lblPayrollNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.lblPayrollName.DisplayOnly = True
            Me.lblPayrollName.EditingMode = False
            Me.lblPayrollName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtPayrollCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayrollCode.ComputedValue = False
            Me.txtPayrollCode.CustomFormat = Nothing
            Me.txtPayrollCode.DataBoundControl = True
            Me.txtPayrollCode.EditingMode = False
            Me.txtPayrollCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayrollCode.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollCode.LinkedLabel = Nothing
            Me.txtPayrollCode.Location = New System.Drawing.Point(580, 27)
            Me.txtPayrollCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollCode.MaximumValue = Nothing
            Me.txtPayrollCode.MinimumValue = Nothing
            Me.txtPayrollCode.Name = "txtPayrollCode"
            Me.txtPayrollCode.OldValue = Nothing
            Me.txtPayrollCode.ReadOnly = True
            Me.txtPayrollCode.Size = New System.Drawing.Size(72, 23)
            Me.txtPayrollCode.TabIndex = 2
            Me.txtPayrollCode.ValueIsMandatory = True
            '
            'lblPayrollCode
            '
            Me.lblPayrollCode.DisplayOnly = True
            Me.lblPayrollCode.EditingMode = False
            Me.lblPayrollCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.cboPayCycleIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboPayCycleIdNo, 3)
            Me.cboPayCycleIdNo.CurrentSearchTerm = ""
            Me.cboPayCycleIdNo.DefaultValue = Nothing
            Me.cboPayCycleIdNo.DisplayMember = "Name"
            Me.cboPayCycleIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboPayCycleIdNo.DropDownHeight = 200
            Me.cboPayCycleIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPayCycleIdNo.EditingMode = True
            Me.cboPayCycleIdNo.FilterRule = Nothing
            Me.cboPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboPayCycleIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayCycleIdNo.FormattingEnabled = True
            Me.cboPayCycleIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayCycleIdNo.LinkedLabel = Nothing
            Me.cboPayCycleIdNo.Location = New System.Drawing.Point(194, 1)
            Me.cboPayCycleIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPayCycleIdNo.Name = "cboPayCycleIdNo"
            Me.cboPayCycleIdNo.OldValue = 0
            Me.cboPayCycleIdNo.OriginalDataSource = Nothing
            Me.cboPayCycleIdNo.OriginalList = Nothing
            Me.cboPayCycleIdNo.OverrideDropDownStyleList = False
            Me.cboPayCycleIdNo.PreviousSearchTerm = Nothing
            Me.cboPayCycleIdNo.PreviousSelectedIndex = -1
            Me.cboPayCycleIdNo.PropertySelector = Nothing
            Me.cboPayCycleIdNo.ReadOnlyCombo = False
            Me.cboPayCycleIdNo.SearchAnywhere = False
            Me.cboPayCycleIdNo.Size = New System.Drawing.Size(579, 24)
            Me.cboPayCycleIdNo.SuggestBoxHeight = 200
            Me.cboPayCycleIdNo.SuggestListOrderRule = Nothing
            Me.cboPayCycleIdNo.TabIndex = 1
            Me.cboPayCycleIdNo.TextToSearch = Nothing
            Me.cboPayCycleIdNo.ValueIsMandatory = False
            Me.cboPayCycleIdNo.ValueIsNullable = False
            Me.cboPayCycleIdNo.ValueIsNumeric = False
            Me.cboPayCycleIdNo.ValueMember = "IdNo"
            '
            'lblPayCycleIdNo
            '
            Me.lblPayCycleIdNo.DisplayOnly = True
            Me.lblPayCycleIdNo.EditingMode = False
            Me.lblPayCycleIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(1, 27)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(142, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnInitialize
            '
            Me.btnInitialize.DesignerSelected = False
            Me.btnInitialize.DisplayOnly = True
            Me.btnInitialize.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnInitialize.ImageIndex = 0
            Me.btnInitialize.Location = New System.Drawing.Point(3, 131)
            Me.btnInitialize.Name = "btnInitialize"
            Me.btnInitialize.OriginalImageName = Nothing
            Me.btnInitialize.SecurityKey = ""
            Me.btnInitialize.Size = New System.Drawing.Size(187, 40)
            Me.btnInitialize.TabIndex = 169
            Me.btnInitialize.Text = "Initialize Attendance"
            '
            'CButton2
            '
            Me.CButton2.DesignerSelected = True
            Me.CButton2.DisplayOnly = True
            Me.CButton2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CButton2.ImageIndex = 0
            Me.CButton2.Location = New System.Drawing.Point(196, 131)
            Me.CButton2.Name = "CButton2"
            Me.CButton2.OriginalImageName = Nothing
            Me.CButton2.SecurityKey = ""
            Me.CButton2.Size = New System.Drawing.Size(187, 40)
            Me.CButton2.TabIndex = 170
            Me.CButton2.Text = "Enter Payments/ Deductions"
            '
            'CButton3
            '
            Me.CButton3.DesignerSelected = False
            Me.CButton3.DisplayOnly = True
            Me.CButton3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CButton3.ImageIndex = 0
            Me.CButton3.Location = New System.Drawing.Point(389, 131)
            Me.CButton3.Name = "CButton3"
            Me.CButton3.OriginalImageName = Nothing
            Me.CButton3.SecurityKey = ""
            Me.CButton3.Size = New System.Drawing.Size(187, 40)
            Me.CButton3.TabIndex = 171
            Me.CButton3.Text = "View Payroll Report"
            '
            'tbcPayroll
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.tbcPayroll, 4)
            Me.tbcPayroll.Controls.Add(Me.tbpAttendance)
            Me.tbcPayroll.Controls.Add(Me.TabPage2)
            Me.tbcPayroll.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbcPayroll.Location = New System.Drawing.Point(3, 177)
            Me.tbcPayroll.Name = "tbcPayroll"
            Me.tbcPayroll.SelectedIndex = 0
            Me.tbcPayroll.Size = New System.Drawing.Size(768, 388)
            Me.tbcPayroll.TabIndex = 172
            '
            'tbpAttendance
            '
            Me.tbpAttendance.Controls.Add(Me.DataGridViewPayrollAttendance)
            Me.tbpAttendance.Location = New System.Drawing.Point(4, 22)
            Me.tbpAttendance.Name = "tbpAttendance"
            Me.tbpAttendance.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpAttendance.Size = New System.Drawing.Size(760, 362)
            Me.tbpAttendance.TabIndex = 0
            Me.tbpAttendance.Text = "Attendance"
            Me.tbpAttendance.UseVisualStyleBackColor = True
            '
            'DataGridViewPayrollAttendance
            '
            Me.DataGridViewPayrollAttendance.AllowUserToAddRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayrollAttendance.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPayrollAttendance.AutoGenerateColumns = False
            Me.DataGridViewPayrollAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayrollAttendance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvEmployeeName, Me.dgvEmployeeNameAra, Me.dgvOvertime, Me.dgvDaysPresent, Me.dgvDaysAbsentWithPay, Me.dgvDaysAbsentWoPay, Me.dgvDaysOff, Me.dgvDaysTotal, Me.EmployeeIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn})
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
            Me.DataGridViewPayrollAttendance.FirstRowDeletionEnabled = True
            Me.DataGridViewPayrollAttendance.FirstRowInsertionEnabled = True
            Me.DataGridViewPayrollAttendance.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewPayrollAttendance.Name = "DataGridViewPayrollAttendance"
            Me.DataGridViewPayrollAttendance.ReadOnly = True
            Me.DataGridViewPayrollAttendance.SequenceColumn = "dgvSequence"
            Me.DataGridViewPayrollAttendance.SequenceFieldName = "Sequence"
            Me.DataGridViewPayrollAttendance.ShowFooter = False
            Me.DataGridViewPayrollAttendance.ShowInsertColumnWhenEditing = False
            Me.DataGridViewPayrollAttendance.Size = New System.Drawing.Size(745, 346)
            Me.DataGridViewPayrollAttendance.TabIndex = 171
            '
            'dgvSequence
            '
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.HeaderText = "Seq"
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.Width = 30
            '
            'dgvEmployeeName
            '
            Me.dgvEmployeeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvEmployeeName.DataPropertyName = "EmployeeName"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvEmployeeName.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvEmployeeName.EditingMode = False
            Me.dgvEmployeeName.HeaderText = "Employee Name"
            Me.dgvEmployeeName.Name = "dgvEmployeeName"
            Me.dgvEmployeeName.ReadOnly = True
            Me.dgvEmployeeName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvEmployeeNameAra
            '
            Me.dgvEmployeeNameAra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvEmployeeNameAra.DataPropertyName = "EmployeeNameAra"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvEmployeeNameAra.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvEmployeeNameAra.EditingMode = False
            Me.dgvEmployeeNameAra.HeaderText = "Employee Name"
            Me.dgvEmployeeNameAra.Name = "dgvEmployeeNameAra"
            Me.dgvEmployeeNameAra.ReadOnly = True
            Me.dgvEmployeeNameAra.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEmployeeNameAra.Visible = False
            '
            'dgvOvertime
            '
            Me.dgvOvertime.DataPropertyName = "Overtime"
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvOvertime.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvOvertime.EditingMode = False
            Me.dgvOvertime.HeaderText = "Overtime Hours"
            Me.dgvOvertime.Name = "dgvOvertime"
            Me.dgvOvertime.ReadOnly = True
            Me.dgvOvertime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvOvertime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'dgvDaysPresent
            '
            Me.dgvDaysPresent.DataPropertyName = "DaysPresent"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle6.Format = "#####0.00"
            Me.dgvDaysPresent.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvDaysPresent.EditingMode = False
            Me.dgvDaysPresent.HeaderText = "Days Present"
            Me.dgvDaysPresent.Name = "dgvDaysPresent"
            Me.dgvDaysPresent.ReadOnly = True
            Me.dgvDaysPresent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDaysPresent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDaysPresent.Width = 75
            '
            'dgvDaysAbsentWithPay
            '
            Me.dgvDaysAbsentWithPay.DataPropertyName = "DaysAbsentWithPay"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysAbsentWithPay.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvDaysAbsentWithPay.EditingMode = False
            Me.dgvDaysAbsentWithPay.HeaderText = "Days Absent With Pay"
            Me.dgvDaysAbsentWithPay.Name = "dgvDaysAbsentWithPay"
            Me.dgvDaysAbsentWithPay.ReadOnly = True
            Me.dgvDaysAbsentWithPay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDaysAbsentWithPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDaysAbsentWithPay.Width = 75
            '
            'dgvDaysAbsentWoPay
            '
            Me.dgvDaysAbsentWoPay.DataPropertyName = "DaysAbsentWithoutPay"
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysAbsentWoPay.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvDaysAbsentWoPay.EditingMode = False
            Me.dgvDaysAbsentWoPay.HeaderText = "Days Absent Without Pay"
            Me.dgvDaysAbsentWoPay.Name = "dgvDaysAbsentWoPay"
            Me.dgvDaysAbsentWoPay.ReadOnly = True
            Me.dgvDaysAbsentWoPay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDaysAbsentWoPay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDaysAbsentWoPay.Width = 75
            '
            'dgvDaysOff
            '
            Me.dgvDaysOff.DataPropertyName = "DaysOff"
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysOff.DefaultCellStyle = DataGridViewCellStyle9
            Me.dgvDaysOff.EditingMode = False
            Me.dgvDaysOff.HeaderText = "Days Off"
            Me.dgvDaysOff.Name = "dgvDaysOff"
            Me.dgvDaysOff.ReadOnly = True
            Me.dgvDaysOff.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDaysOff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDaysOff.Width = 75
            '
            'dgvDaysTotal
            '
            Me.dgvDaysTotal.DataPropertyName = "DaysTotal"
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysTotal.DefaultCellStyle = DataGridViewCellStyle10
            Me.dgvDaysTotal.EditingMode = False
            Me.dgvDaysTotal.HeaderText = "Days Total"
            Me.dgvDaysTotal.Name = "dgvDaysTotal"
            Me.dgvDaysTotal.ReadOnly = True
            Me.dgvDaysTotal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDaysTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDaysTotal.Width = 75
            '
            'EmployeeIdNoDataGridViewTextBoxColumn
            '
            Me.EmployeeIdNoDataGridViewTextBoxColumn.DataPropertyName = "EmployeeIdNo"
            Me.EmployeeIdNoDataGridViewTextBoxColumn.HeaderText = "EmployeeIdNo"
            Me.EmployeeIdNoDataGridViewTextBoxColumn.Name = "EmployeeIdNoDataGridViewTextBoxColumn"
            Me.EmployeeIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.EmployeeIdNoDataGridViewTextBoxColumn.Visible = False
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn.Visible = False
            '
            'bsPayrollAttendance
            '
            Me.bsPayrollAttendance.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.AttendanceItemModel)
            '
            'TabPage2
            '
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(760, 361)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "TabPage2"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'PayrollEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1106, 663)
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "PayrollEntryTv"
            Me.Text = "Payroll Maintenance Form"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.tbcPayroll.ResumeLayout(False)
            Me.tbpAttendance.ResumeLayout(False)
            CType(Me.DataGridViewPayrollAttendance, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPayrollAttendance, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
        Friend WithEvents dtpStartDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents dtpEndDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblPayrollNameAra As CLabel
        Friend WithEvents txtPayrollNameAra As CTextBoxArabic
        Friend WithEvents lblPayrollCode As CLabel
        Friend WithEvents txtPayrollCode As CTextBox
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents btnInitialize As CButton
        Friend WithEvents CButton2 As CButton
        Friend WithEvents CButton3 As CButton
        Friend WithEvents bsPayrollAttendance As BindingSource
        Friend WithEvents tbcPayroll As CTabControl
        Friend WithEvents tbpAttendance As TabPage
        Friend WithEvents TabPage2 As TabPage
        Friend WithEvents DataGridViewPayrollAttendance As CDataGridView
        Friend WithEvents dgvSequence As CdgvColumnText
        Friend WithEvents dgvEmployeeName As CdgvColumnText
        Friend WithEvents dgvEmployeeNameAra As CdgvColumnText
        Friend WithEvents dgvOvertime As CdgvColumnDecimal
        Friend WithEvents dgvDaysPresent As CdgvColumnDecimal
        Friend WithEvents dgvDaysAbsentWithPay As CdgvColumnDecimal
        Friend WithEvents dgvDaysAbsentWoPay As CdgvColumnDecimal
        Friend WithEvents dgvDaysOff As CdgvColumnDecimal
        Friend WithEvents dgvDaysTotal As CdgvColumnDecimal
        Friend WithEvents EmployeeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace