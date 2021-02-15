Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayPeriodEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayPeriodEntryTv))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtPayPeriodName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.dtpStartDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.dtpEndDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayPeriodNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblPayPeriodNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayPeriodName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayPeriodCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPayPeriodCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnInitialize = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CButton2 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CButton3 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CTabControl1 = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbcPayroll = New System.Windows.Forms.TabPage()
            Me.DataGridViewPayPeriodAttendance = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.EmployeeNameDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.EmployeeNameAraDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.DaysPresentDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.DaysAbsentWithPayDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.DaysAbsentWithoutPayDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.DaysOffDataGridViewTextBoxColumn = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.DaysTotal = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.EmployeeIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.bsPayPeriodAttendance = New System.Windows.Forms.BindingSource(Me.components)
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.CTabControl1.SuspendLayout()
            Me.tbcPayroll.SuspendLayout()
            CType(Me.DataGridViewPayPeriodAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPayPeriodAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
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
            'txtPayPeriodName
            '
            Me.txtPayPeriodName.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayPeriodName, 3)
            Me.txtPayPeriodName.ComputedValue = False
            Me.txtPayPeriodName.CustomFormat = Nothing
            Me.txtPayPeriodName.DataBoundControl = True
            Me.txtPayPeriodName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayPeriodName.EditingMode = False
            Me.txtPayPeriodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayPeriodName.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodName.LinkedLabel = Nothing
            Me.txtPayPeriodName.Location = New System.Drawing.Point(194, 52)
            Me.txtPayPeriodName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayPeriodName.MaximumValue = Nothing
            Me.txtPayPeriodName.MinimumValue = Nothing
            Me.txtPayPeriodName.Name = "txtPayPeriodName"
            Me.txtPayPeriodName.OldValue = Nothing
            Me.txtPayPeriodName.ReadOnly = True
            Me.txtPayPeriodName.Size = New System.Drawing.Size(579, 23)
            Me.txtPayPeriodName.TabIndex = 3
            Me.txtPayPeriodName.ValueIsMandatory = True
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
            Me.TableLayoutPanel1.Controls.Add(Me.txtPayPeriodNameAra, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPayPeriodNameAra, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPayPeriodName, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEndDate, 2, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPayPeriodCode, 3, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPayPeriodCode, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.cboPayCycleIdNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPayCycleIdNo, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPayPeriodName, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.btnInitialize, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CButton2, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CButton3, 2, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CTabControl1, 0, 7)
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
            'txtPayPeriodNameAra
            '
            Me.txtPayPeriodNameAra.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayPeriodNameAra, 3)
            Me.txtPayPeriodNameAra.ComputedValue = False
            Me.txtPayPeriodNameAra.CustomFormat = Nothing
            Me.txtPayPeriodNameAra.DataBoundControl = True
            Me.txtPayPeriodNameAra.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayPeriodNameAra.EditingMode = False
            Me.txtPayPeriodNameAra.EnglishControl = Me.txtPayPeriodName
            Me.txtPayPeriodNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayPeriodNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodNameAra.LinkedLabel = Nothing
            Me.txtPayPeriodNameAra.Location = New System.Drawing.Point(194, 77)
            Me.txtPayPeriodNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayPeriodNameAra.MaximumValue = Nothing
            Me.txtPayPeriodNameAra.MinimumValue = Nothing
            Me.txtPayPeriodNameAra.Name = "txtPayPeriodNameAra"
            Me.txtPayPeriodNameAra.OldValue = Nothing
            Me.txtPayPeriodNameAra.ReadOnly = True
            Me.txtPayPeriodNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtPayPeriodNameAra.Size = New System.Drawing.Size(579, 23)
            Me.txtPayPeriodNameAra.TabIndex = 4
            '
            'lblPayPeriodNameAra
            '
            Me.lblPayPeriodNameAra.DisplayOnly = True
            Me.lblPayPeriodNameAra.EditingMode = False
            Me.lblPayPeriodNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayPeriodNameAra.Location = New System.Drawing.Point(1, 77)
            Me.lblPayPeriodNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayPeriodNameAra.Name = "lblPayPeriodNameAra"
            Me.lblPayPeriodNameAra.Size = New System.Drawing.Size(142, 23)
            Me.lblPayPeriodNameAra.TabIndex = 167
            Me.lblPayPeriodNameAra.Text = "Name (Arabic)"
            Me.lblPayPeriodNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPayPeriodName
            '
            Me.lblPayPeriodName.DisplayOnly = True
            Me.lblPayPeriodName.EditingMode = False
            Me.lblPayPeriodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayPeriodName.Location = New System.Drawing.Point(1, 52)
            Me.lblPayPeriodName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayPeriodName.Name = "lblPayPeriodName"
            Me.lblPayPeriodName.Size = New System.Drawing.Size(142, 23)
            Me.lblPayPeriodName.TabIndex = 164
            Me.lblPayPeriodName.Text = "Name"
            Me.lblPayPeriodName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            'txtPayPeriodCode
            '
            Me.txtPayPeriodCode.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayPeriodCode.ComputedValue = False
            Me.txtPayPeriodCode.CustomFormat = Nothing
            Me.txtPayPeriodCode.DataBoundControl = True
            Me.txtPayPeriodCode.EditingMode = False
            Me.txtPayPeriodCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayPeriodCode.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodCode.LinkedLabel = Nothing
            Me.txtPayPeriodCode.Location = New System.Drawing.Point(580, 27)
            Me.txtPayPeriodCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayPeriodCode.MaximumValue = Nothing
            Me.txtPayPeriodCode.MinimumValue = Nothing
            Me.txtPayPeriodCode.Name = "txtPayPeriodCode"
            Me.txtPayPeriodCode.OldValue = Nothing
            Me.txtPayPeriodCode.ReadOnly = True
            Me.txtPayPeriodCode.Size = New System.Drawing.Size(72, 23)
            Me.txtPayPeriodCode.TabIndex = 2
            Me.txtPayPeriodCode.ValueIsMandatory = True
            '
            'lblPayPeriodCode
            '
            Me.lblPayPeriodCode.DisplayOnly = True
            Me.lblPayPeriodCode.EditingMode = False
            Me.lblPayPeriodCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayPeriodCode.Location = New System.Drawing.Point(387, 27)
            Me.lblPayPeriodCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayPeriodCode.Name = "lblPayPeriodCode"
            Me.lblPayPeriodCode.Size = New System.Drawing.Size(78, 23)
            Me.lblPayPeriodCode.TabIndex = 168
            Me.lblPayPeriodCode.Text = "Code"
            Me.lblPayPeriodCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.btnInitialize.Text = "Initialize Payroll"
            '
            'CButton2
            '
            Me.CButton2.DesignerSelected = False
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
            'CTabControl1
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.CTabControl1, 4)
            Me.CTabControl1.Controls.Add(Me.tbcPayroll)
            Me.CTabControl1.Controls.Add(Me.TabPage2)
            Me.CTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CTabControl1.Location = New System.Drawing.Point(3, 177)
            Me.CTabControl1.Name = "CTabControl1"
            Me.CTabControl1.SelectedIndex = 0
            Me.CTabControl1.Size = New System.Drawing.Size(768, 388)
            Me.CTabControl1.TabIndex = 172
            '
            'tbcPayroll
            '
            Me.tbcPayroll.Controls.Add(Me.DataGridViewPayPeriodAttendance)
            Me.tbcPayroll.Location = New System.Drawing.Point(4, 22)
            Me.tbcPayroll.Name = "tbcPayroll"
            Me.tbcPayroll.Padding = New System.Windows.Forms.Padding(3)
            Me.tbcPayroll.Size = New System.Drawing.Size(760, 362)
            Me.tbcPayroll.TabIndex = 0
            Me.tbcPayroll.Text = "TabPage1"
            Me.tbcPayroll.UseVisualStyleBackColor = True
            '
            'DataGridViewPayPeriodAttendance
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPayPeriodAttendance.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPayPeriodAttendance.AutoGenerateColumns = False
            Me.DataGridViewPayPeriodAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPayPeriodAttendance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmployeeNameDataGridViewTextBoxColumn, Me.EmployeeNameAraDataGridViewTextBoxColumn, Me.DaysPresentDataGridViewTextBoxColumn, Me.DaysAbsentWithPayDataGridViewTextBoxColumn, Me.DaysAbsentWithoutPayDataGridViewTextBoxColumn, Me.DaysOffDataGridViewTextBoxColumn, Me.DaysTotal, Me.EmployeeIdNoDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn})
            Me.DataGridViewPayPeriodAttendance.DataSource = Me.bsPayPeriodAttendance
            DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPayPeriodAttendance.DefaultCellStyle = DataGridViewCellStyle9
            Me.DataGridViewPayPeriodAttendance.DgvFooter = Nothing
            Me.DataGridViewPayPeriodAttendance.DisplayOnly = False
            Me.DataGridViewPayPeriodAttendance.Ea = Nothing
            Me.DataGridViewPayPeriodAttendance.EditingMode = False
            Me.DataGridViewPayPeriodAttendance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPayPeriodAttendance.FirstRowDeletionEnabled = True
            Me.DataGridViewPayPeriodAttendance.FirstRowInsertionEnabled = True
            Me.DataGridViewPayPeriodAttendance.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewPayPeriodAttendance.Name = "DataGridViewPayPeriodAttendance"
            Me.DataGridViewPayPeriodAttendance.ReadOnly = True
            Me.DataGridViewPayPeriodAttendance.SequenceColumn = "dgvSequence"
            Me.DataGridViewPayPeriodAttendance.SequenceFieldName = "Sequence"
            Me.DataGridViewPayPeriodAttendance.ShowFooter = False
            Me.DataGridViewPayPeriodAttendance.ShowInsertColumnWhenEditing = True
            Me.DataGridViewPayPeriodAttendance.Size = New System.Drawing.Size(745, 346)
            Me.DataGridViewPayPeriodAttendance.TabIndex = 171
            '
            'EmployeeNameDataGridViewTextBoxColumn
            '
            Me.EmployeeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.EmployeeNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeName"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.EmployeeNameDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
            Me.EmployeeNameDataGridViewTextBoxColumn.EditingMode = False
            Me.EmployeeNameDataGridViewTextBoxColumn.HeaderText = "Employee Name"
            Me.EmployeeNameDataGridViewTextBoxColumn.Name = "EmployeeNameDataGridViewTextBoxColumn"
            Me.EmployeeNameDataGridViewTextBoxColumn.ReadOnly = True
            Me.EmployeeNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'EmployeeNameAraDataGridViewTextBoxColumn
            '
            Me.EmployeeNameAraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.EmployeeNameAraDataGridViewTextBoxColumn.DataPropertyName = "EmployeeNameAra"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.EmployeeNameAraDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
            Me.EmployeeNameAraDataGridViewTextBoxColumn.EditingMode = False
            Me.EmployeeNameAraDataGridViewTextBoxColumn.HeaderText = "Employee Name"
            Me.EmployeeNameAraDataGridViewTextBoxColumn.Name = "EmployeeNameAraDataGridViewTextBoxColumn"
            Me.EmployeeNameAraDataGridViewTextBoxColumn.ReadOnly = True
            Me.EmployeeNameAraDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.EmployeeNameAraDataGridViewTextBoxColumn.Visible = False
            '
            'DaysPresentDataGridViewTextBoxColumn
            '
            Me.DaysPresentDataGridViewTextBoxColumn.DataPropertyName = "DaysPresent"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.DaysPresentDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
            Me.DaysPresentDataGridViewTextBoxColumn.EditingMode = False
            Me.DaysPresentDataGridViewTextBoxColumn.HeaderText = "Days Present"
            Me.DaysPresentDataGridViewTextBoxColumn.Name = "DaysPresentDataGridViewTextBoxColumn"
            Me.DaysPresentDataGridViewTextBoxColumn.ReadOnly = True
            Me.DaysPresentDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DaysPresentDataGridViewTextBoxColumn.Width = 75
            '
            'DaysAbsentWithPayDataGridViewTextBoxColumn
            '
            Me.DaysAbsentWithPayDataGridViewTextBoxColumn.DataPropertyName = "DaysAbsentWithPay"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.DaysAbsentWithPayDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
            Me.DaysAbsentWithPayDataGridViewTextBoxColumn.EditingMode = False
            Me.DaysAbsentWithPayDataGridViewTextBoxColumn.HeaderText = "Days Absent With Pay"
            Me.DaysAbsentWithPayDataGridViewTextBoxColumn.Name = "DaysAbsentWithPayDataGridViewTextBoxColumn"
            Me.DaysAbsentWithPayDataGridViewTextBoxColumn.ReadOnly = True
            Me.DaysAbsentWithPayDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DaysAbsentWithPayDataGridViewTextBoxColumn.Width = 75
            '
            'DaysAbsentWithoutPayDataGridViewTextBoxColumn
            '
            Me.DaysAbsentWithoutPayDataGridViewTextBoxColumn.DataPropertyName = "DaysAbsentWithoutPay"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.DaysAbsentWithoutPayDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
            Me.DaysAbsentWithoutPayDataGridViewTextBoxColumn.EditingMode = False
            Me.DaysAbsentWithoutPayDataGridViewTextBoxColumn.HeaderText = "Days Absent Without Pay"
            Me.DaysAbsentWithoutPayDataGridViewTextBoxColumn.Name = "DaysAbsentWithoutPayDataGridViewTextBoxColumn"
            Me.DaysAbsentWithoutPayDataGridViewTextBoxColumn.ReadOnly = True
            Me.DaysAbsentWithoutPayDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DaysAbsentWithoutPayDataGridViewTextBoxColumn.Width = 75
            '
            'DaysOffDataGridViewTextBoxColumn
            '
            Me.DaysOffDataGridViewTextBoxColumn.DataPropertyName = "DaysOff"
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            Me.DaysOffDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
            Me.DaysOffDataGridViewTextBoxColumn.EditingMode = False
            Me.DaysOffDataGridViewTextBoxColumn.HeaderText = "Days Off"
            Me.DaysOffDataGridViewTextBoxColumn.Name = "DaysOffDataGridViewTextBoxColumn"
            Me.DaysOffDataGridViewTextBoxColumn.ReadOnly = True
            Me.DaysOffDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DaysOffDataGridViewTextBoxColumn.Width = 75
            '
            'DaysTotal
            '
            Me.DaysTotal.DataPropertyName = "DaysTotal"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.DaysTotal.DefaultCellStyle = DataGridViewCellStyle8
            Me.DaysTotal.EditingMode = False
            Me.DaysTotal.HeaderText = "Days Total"
            Me.DaysTotal.Name = "DaysTotal"
            Me.DaysTotal.ReadOnly = True
            Me.DaysTotal.Width = 75
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
            'bsPayPeriodAttendance
            '
            Me.bsPayPeriodAttendance.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.AttendanceItemModel)
            '
            'TabPage2
            '
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(760, 212)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "TabPage2"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'PayPeriodEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1106, 663)
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "PayPeriodEntryTv"
            Me.Text = "Pay Period Maintenance Form"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.CTabControl1.ResumeLayout(False)
            Me.tbcPayroll.ResumeLayout(False)
            CType(Me.DataGridViewPayPeriodAttendance, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPayPeriodAttendance, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtPayPeriodName As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblPayCycleIdNo As CLabel
        Friend WithEvents lblStartDate As CLabel
        Friend WithEvents lblEndDate As CLabel
        Friend WithEvents _MBPayPeriodCannotBeParentToItself As LocalizableMessageBox
        Friend WithEvents _MBParentWithChildrenChangedDisallowed As LocalizableMessageBox
        Friend WithEvents _MSGMandatoryFields As LocalizableMessage
        Friend WithEvents lblPayPeriodName As CLabel
        Friend WithEvents cboPayCycleIdNo As CaComboBox
        Friend WithEvents dtpStartDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents dtpEndDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblPayPeriodNameAra As CLabel
        Friend WithEvents txtPayPeriodNameAra As CTextBoxArabic
        Friend WithEvents lblPayPeriodCode As CLabel
        Friend WithEvents txtPayPeriodCode As CTextBox
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents btnInitialize As CButton
        Friend WithEvents CButton2 As CButton
        Friend WithEvents CButton3 As CButton
        Friend WithEvents bsPayPeriodAttendance As BindingSource
        Friend WithEvents CTabControl1 As CTabControl
        Friend WithEvents tbcPayroll As TabPage
        Friend WithEvents TabPage2 As TabPage
        Friend WithEvents DataGridViewPayPeriodAttendance As CDataGridView
        Friend WithEvents EmployeeNameDataGridViewTextBoxColumn As CdgvColumnText
        Friend WithEvents EmployeeNameAraDataGridViewTextBoxColumn As CdgvColumnText
        Friend WithEvents DaysPresentDataGridViewTextBoxColumn As CdgvColumnText
        Friend WithEvents DaysAbsentWithPayDataGridViewTextBoxColumn As CdgvColumnText
        Friend WithEvents DaysAbsentWithoutPayDataGridViewTextBoxColumn As CdgvColumnText
        Friend WithEvents DaysOffDataGridViewTextBoxColumn As CdgvColumnText
        Friend WithEvents DaysTotal As CdgvColumnText
        Friend WithEvents EmployeeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace