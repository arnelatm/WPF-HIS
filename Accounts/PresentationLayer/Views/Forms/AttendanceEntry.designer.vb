Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AttendanceEntry
        Inherits CFormEntryNew

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AttendanceEntry))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.dtpStartDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.dtpEndDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayPeriodNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtPayPeriodName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPayPeriodNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPayPeriodName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayPeriodCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPayPeriodCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblPayCycleIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CDataGridView1 = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.AttendanceModelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.bsAttendance = New System.Windows.Forms.BindingSource(Me.components)
            Me.dgvEmployeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvEmployeeNameAra = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvDaysPresent = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvDaysAbsentWithPay = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvDaysAbsentWithoutPay = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.dgvDaysOff = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.TotalDays = New AATM.Libraries.CBaseControlsLibrary.CdgvColumnText()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            CType(Me.CDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AttendanceModelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
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
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
            Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CDataGridView1, 0, 1)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            '
            'TableLayoutPanel2
            '
            resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
            Me.TableLayoutPanel2.Controls.Add(Me.dtpStartDate, 1, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.dtpEndDate, 3, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.lblStartDate, 0, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPayPeriodNameAra, 1, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.lblPayPeriodNameAra, 0, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.lblPayPeriodName, 0, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.lblEndDate, 2, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPayPeriodCode, 3, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.lblPayPeriodCode, 2, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.cboPayCycleIdNo, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.lblPayCycleIdNo, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.lblIdNo, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.TxtIdNo, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.txtPayPeriodName, 1, 2)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
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
            resources.ApplyResources(Me.dtpStartDate, "dtpStartDate")
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
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
            resources.ApplyResources(Me.dtpEndDate, "dtpEndDate")
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.ReadOnlyDp = False
            Me.dtpEndDate.SecurityKey = Nothing
            Me.dtpEndDate.ShowLongDate = False
            Me.dtpEndDate.ShowTime = False
            Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndDate.Value = Nothing
            Me.dtpEndDate.ValueIsMandatory = False
            Me.dtpEndDate.ValueIsNullable = False
            '
            'lblStartDate
            '
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            resources.ApplyResources(Me.lblStartDate, "lblStartDate")
            Me.lblStartDate.Name = "lblStartDate"
            '
            'txtPayPeriodNameAra
            '
            Me.txtPayPeriodNameAra.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel2.SetColumnSpan(Me.txtPayPeriodNameAra, 3)
            Me.txtPayPeriodNameAra.ComputedValue = False
            Me.txtPayPeriodNameAra.CustomFormat = Nothing
            Me.txtPayPeriodNameAra.DataBoundControl = True
            resources.ApplyResources(Me.txtPayPeriodNameAra, "txtPayPeriodNameAra")
            Me.txtPayPeriodNameAra.EditingMode = False
            Me.txtPayPeriodNameAra.EnglishControl = Me.txtPayPeriodName
            Me.txtPayPeriodNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodNameAra.LinkedLabel = Nothing
            Me.txtPayPeriodNameAra.MaximumValue = Nothing
            Me.txtPayPeriodNameAra.MinimumValue = Nothing
            Me.txtPayPeriodNameAra.Name = "txtPayPeriodNameAra"
            Me.txtPayPeriodNameAra.OldValue = Nothing
            Me.txtPayPeriodNameAra.ReadOnly = True
            '
            'txtPayPeriodName
            '
            Me.txtPayPeriodName.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel2.SetColumnSpan(Me.txtPayPeriodName, 3)
            Me.txtPayPeriodName.ComputedValue = False
            Me.txtPayPeriodName.CustomFormat = Nothing
            Me.txtPayPeriodName.DataBoundControl = True
            resources.ApplyResources(Me.txtPayPeriodName, "txtPayPeriodName")
            Me.txtPayPeriodName.EditingMode = False
            Me.txtPayPeriodName.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodName.LinkedLabel = Nothing
            Me.txtPayPeriodName.MaximumValue = Nothing
            Me.txtPayPeriodName.MinimumValue = Nothing
            Me.txtPayPeriodName.Name = "txtPayPeriodName"
            Me.txtPayPeriodName.OldValue = Nothing
            Me.txtPayPeriodName.ReadOnly = True
            Me.txtPayPeriodName.ValueIsMandatory = True
            '
            'lblPayPeriodNameAra
            '
            Me.lblPayPeriodNameAra.DisplayOnly = True
            Me.lblPayPeriodNameAra.EditingMode = False
            resources.ApplyResources(Me.lblPayPeriodNameAra, "lblPayPeriodNameAra")
            Me.lblPayPeriodNameAra.Name = "lblPayPeriodNameAra"
            '
            'lblPayPeriodName
            '
            Me.lblPayPeriodName.DisplayOnly = True
            Me.lblPayPeriodName.EditingMode = False
            resources.ApplyResources(Me.lblPayPeriodName, "lblPayPeriodName")
            Me.lblPayPeriodName.Name = "lblPayPeriodName"
            '
            'lblEndDate
            '
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            resources.ApplyResources(Me.lblEndDate, "lblEndDate")
            Me.lblEndDate.Name = "lblEndDate"
            '
            'txtPayPeriodCode
            '
            Me.txtPayPeriodCode.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayPeriodCode.ComputedValue = False
            Me.txtPayPeriodCode.CustomFormat = Nothing
            Me.txtPayPeriodCode.DataBoundControl = True
            Me.txtPayPeriodCode.EditingMode = False
            resources.ApplyResources(Me.txtPayPeriodCode, "txtPayPeriodCode")
            Me.txtPayPeriodCode.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodCode.LinkedLabel = Nothing
            Me.txtPayPeriodCode.MaximumValue = Nothing
            Me.txtPayPeriodCode.MinimumValue = Nothing
            Me.txtPayPeriodCode.Name = "txtPayPeriodCode"
            Me.txtPayPeriodCode.OldValue = Nothing
            Me.txtPayPeriodCode.ReadOnly = True
            Me.txtPayPeriodCode.ValueIsMandatory = True
            '
            'lblPayPeriodCode
            '
            Me.lblPayPeriodCode.DisplayOnly = True
            Me.lblPayPeriodCode.EditingMode = False
            resources.ApplyResources(Me.lblPayPeriodCode, "lblPayPeriodCode")
            Me.lblPayPeriodCode.Name = "lblPayPeriodCode"
            '
            'cboPayCycleIdNo
            '
            Me.cboPayCycleIdNo.BackColor = System.Drawing.Color.White
            Me.cboPayCycleIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel2.SetColumnSpan(Me.cboPayCycleIdNo, 3)
            Me.cboPayCycleIdNo.CurrentSearchTerm = ""
            Me.cboPayCycleIdNo.DefaultValue = Nothing
            Me.cboPayCycleIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboPayCycleIdNo, "cboPayCycleIdNo")
            Me.cboPayCycleIdNo.DropDownHeight = 200
            Me.cboPayCycleIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboPayCycleIdNo.EditingMode = True
            Me.cboPayCycleIdNo.FilterRule = Nothing
            Me.cboPayCycleIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPayCycleIdNo.FormattingEnabled = True
            Me.cboPayCycleIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPayCycleIdNo.LinkedLabel = Nothing
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
            Me.cboPayCycleIdNo.SuggestBoxHeight = 200
            Me.cboPayCycleIdNo.SuggestListOrderRule = Nothing
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
            resources.ApplyResources(Me.lblPayCycleIdNo, "lblPayCycleIdNo")
            Me.lblPayCycleIdNo.Name = "lblPayCycleIdNo"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
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
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'CDataGridView1
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.CDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.CDataGridView1.AutoGenerateColumns = False
            Me.CDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.CDataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvEmployeeName, Me.dgvEmployeeNameAra, Me.dgvDaysPresent, Me.dgvDaysAbsentWithPay, Me.dgvDaysAbsentWithoutPay, Me.dgvDaysOff, Me.TotalDays, Me.IdNoDataGridViewTextBoxColumn})
            Me.CDataGridView1.DataInGridChanged = False
            Me.CDataGridView1.DataSource = Me.AttendanceModelBindingSource
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.CDataGridView1.DefaultCellStyle = DataGridViewCellStyle6
            Me.CDataGridView1.DgvFooter = Nothing
            Me.CDataGridView1.DisplayOnly = False
            Me.CDataGridView1.Ea = Nothing
            Me.CDataGridView1.EditingMode = False
            Me.CDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.CDataGridView1.FirstRowDeletionEnabled = True
            Me.CDataGridView1.FirstRowInsertionEnabled = True
            resources.ApplyResources(Me.CDataGridView1, "CDataGridView1")
            Me.CDataGridView1.Name = "CDataGridView1"
            Me.CDataGridView1.ReadOnly = True
            Me.CDataGridView1.SequenceColumn = "dgvSequence"
            Me.CDataGridView1.SequenceFieldName = "Sequence"
            Me.CDataGridView1.ShowFooter = False
            Me.CDataGridView1.ShowInsertColumnWhenEditing = True
            Me.CDataGridView1.StartTrackingChanges = False
            '
            'AttendanceModelBindingSource
            '
            Me.AttendanceModelBindingSource.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.AttendanceModel)
            '
            'dgvEmployeeName
            '
            Me.dgvEmployeeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvEmployeeName.DataPropertyName = "EmployeeName"
            resources.ApplyResources(Me.dgvEmployeeName, "dgvEmployeeName")
            Me.dgvEmployeeName.Name = "dgvEmployeeName"
            Me.dgvEmployeeName.ReadOnly = True
            '
            'dgvEmployeeNameAra
            '
            Me.dgvEmployeeNameAra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvEmployeeNameAra.DataPropertyName = "EmployeeNameAra"
            resources.ApplyResources(Me.dgvEmployeeNameAra, "dgvEmployeeNameAra")
            Me.dgvEmployeeNameAra.Name = "dgvEmployeeNameAra"
            Me.dgvEmployeeNameAra.ReadOnly = True
            '
            'dgvDaysPresent
            '
            Me.dgvDaysPresent.DataPropertyName = "DaysPresent"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysPresent.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvDaysPresent.EditingMode = False
            resources.ApplyResources(Me.dgvDaysPresent, "dgvDaysPresent")
            Me.dgvDaysPresent.Name = "dgvDaysPresent"
            Me.dgvDaysPresent.ReadOnly = True
            Me.dgvDaysPresent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvDaysAbsentWithPay
            '
            Me.dgvDaysAbsentWithPay.DataPropertyName = "DaysAbsentWithPay"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysAbsentWithPay.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvDaysAbsentWithPay.EditingMode = False
            resources.ApplyResources(Me.dgvDaysAbsentWithPay, "dgvDaysAbsentWithPay")
            Me.dgvDaysAbsentWithPay.Name = "dgvDaysAbsentWithPay"
            Me.dgvDaysAbsentWithPay.ReadOnly = True
            Me.dgvDaysAbsentWithPay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvDaysAbsentWithoutPay
            '
            Me.dgvDaysAbsentWithoutPay.DataPropertyName = "DaysAbsentWithoutPay"
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysAbsentWithoutPay.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvDaysAbsentWithoutPay.EditingMode = False
            resources.ApplyResources(Me.dgvDaysAbsentWithoutPay, "dgvDaysAbsentWithoutPay")
            Me.dgvDaysAbsentWithoutPay.Name = "dgvDaysAbsentWithoutPay"
            Me.dgvDaysAbsentWithoutPay.ReadOnly = True
            Me.dgvDaysAbsentWithoutPay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'dgvDaysOff
            '
            Me.dgvDaysOff.DataPropertyName = "DaysOff"
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            Me.dgvDaysOff.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvDaysOff.EditingMode = False
            resources.ApplyResources(Me.dgvDaysOff, "dgvDaysOff")
            Me.dgvDaysOff.Name = "dgvDaysOff"
            Me.dgvDaysOff.ReadOnly = True
            Me.dgvDaysOff.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'TotalDays
            '
            Me.TotalDays.EditingMode = False
            resources.ApplyResources(Me.TotalDays, "TotalDays")
            Me.TotalDays.Name = "TotalDays"
            Me.TotalDays.ReadOnly = True
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn, "IdNoDataGridViewTextBoxColumn")
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'AttendanceEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "AttendanceEntry"
            Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            CType(Me.CDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AttendanceModelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsAttendance, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents txtPayPeriodNameAra As CTextBoxArabic
        Friend WithEvents txtPayPeriodName As CTextBox
        Friend WithEvents lblPayPeriodNameAra As CLabel
        Friend WithEvents lblPayPeriodName As CLabel
        Friend WithEvents cboPayCycleIdNo As CaComboBox
        Friend WithEvents lblPayCycleIdNo As CLabel
        Friend WithEvents dtpStartDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents dtpEndDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents lblStartDate As CLabel
        Friend WithEvents lblEndDate As CLabel
        Friend WithEvents txtPayPeriodCode As CTextBox
        Friend WithEvents lblPayPeriodCode As CLabel
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents CDataGridView1 As CDataGridView
        Friend WithEvents bsAttendance As BindingSource
        Friend WithEvents AttendanceModelBindingSource As BindingSource
        Friend WithEvents dgvEmployeeName As DataGridViewTextBoxColumn
        Friend WithEvents dgvEmployeeNameAra As DataGridViewTextBoxColumn
        Friend WithEvents dgvDaysPresent As CdgvColumnText
        Friend WithEvents dgvDaysAbsentWithPay As CdgvColumnText
        Friend WithEvents dgvDaysAbsentWithoutPay As CdgvColumnText
        Friend WithEvents dgvDaysOff As CdgvColumnText
        Friend WithEvents TotalDays As CdgvColumnText
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace