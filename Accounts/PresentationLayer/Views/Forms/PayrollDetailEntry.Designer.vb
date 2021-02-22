Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayrollDetailEntry
        Inherits AATM.PresentationLayer.Forms.CFormEntryNew

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayrollDetailEntry))
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEmployeeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.tbcPayroll = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tpgEarnings = New System.Windows.Forms.TabPage()
            Me.tpgDeductions = New System.Windows.Forms.TabPage()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpStartDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayPeriodName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel9 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CTextBox3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpEndDate = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
            Me.CTextBox2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.tbcPayroll.SuspendLayout()
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
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.SplitContainer1)
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout1.Location = New System.Drawing.Point(300, 53)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(795, 521)
            Me.CFlowLayout1.TabIndex = 4
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
            Me.SplitContainer1.Size = New System.Drawing.Size(1091, 503)
            Me.SplitContainer1.SplitterDistance = 363
            Me.SplitContainer1.TabIndex = 0
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 7
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.txtIdNo, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.txtEmployeeNameAra, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.txtEmployeeName, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.txtEmployeeCode, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.tbcPayroll, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPayrollIdNo, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpStartDate, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEndDate, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPayPeriodName, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEmployeeName, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel9, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CTextBox3, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.cboEmployeeIdNo, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 4, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 4, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 5, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CTextBox2, 5, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CTextBox1, 5, 7)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 8
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(724, 503)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'txtIdNo
            '
            Me.txtIdNo.BackColor = System.Drawing.Color.White
            Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdNo.ComputedValue = False
            Me.txtIdNo.CustomFormat = Nothing
            Me.txtIdNo.DataBoundControl = True
            Me.txtIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtIdNo.EditingMode = True
            Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtIdNo.LinkedLabel = Nothing
            Me.txtIdNo.Location = New System.Drawing.Point(249, 455)
            Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIdNo.MaximumValue = Nothing
            Me.txtIdNo.MinimumValue = Nothing
            Me.txtIdNo.Name = "txtIdNo"
            Me.txtIdNo.OldValue = Nothing
            Me.txtIdNo.Size = New System.Drawing.Size(122, 23)
            Me.txtIdNo.TabIndex = 43
            Me.txtIdNo.Visible = False
            '
            'txtEmployeeNameAra
            '
            Me.txtEmployeeNameAra.BackColor = System.Drawing.Color.White
            Me.txtEmployeeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeNameAra.ComputedValue = False
            Me.txtEmployeeNameAra.CustomFormat = Nothing
            Me.txtEmployeeNameAra.DataBoundControl = True
            Me.txtEmployeeNameAra.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtEmployeeNameAra.EditingMode = True
            Me.txtEmployeeNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeNameAra.LinkedLabel = Nothing
            Me.txtEmployeeNameAra.Location = New System.Drawing.Point(1, 455)
            Me.txtEmployeeNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeNameAra.MaximumValue = Nothing
            Me.txtEmployeeNameAra.MinimumValue = Nothing
            Me.txtEmployeeNameAra.Name = "txtEmployeeNameAra"
            Me.txtEmployeeNameAra.OldValue = Nothing
            Me.txtEmployeeNameAra.Size = New System.Drawing.Size(122, 23)
            Me.txtEmployeeNameAra.TabIndex = 42
            Me.txtEmployeeNameAra.Visible = False
            '
            'txtEmployeeName
            '
            Me.txtEmployeeName.BackColor = System.Drawing.Color.White
            Me.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeName.ComputedValue = False
            Me.txtEmployeeName.CustomFormat = Nothing
            Me.txtEmployeeName.DataBoundControl = True
            Me.txtEmployeeName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtEmployeeName.EditingMode = True
            Me.txtEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeName.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeName.LinkedLabel = Nothing
            Me.txtEmployeeName.Location = New System.Drawing.Point(125, 455)
            Me.txtEmployeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeName.MaximumValue = Nothing
            Me.txtEmployeeName.MinimumValue = Nothing
            Me.txtEmployeeName.Name = "txtEmployeeName"
            Me.txtEmployeeName.OldValue = Nothing
            Me.txtEmployeeName.Size = New System.Drawing.Size(122, 23)
            Me.txtEmployeeName.TabIndex = 41
            Me.txtEmployeeName.Visible = False
            '
            'txtEmployeeCode
            '
            Me.txtEmployeeCode.BackColor = System.Drawing.Color.White
            Me.txtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeCode.ComputedValue = False
            Me.txtEmployeeCode.CustomFormat = Nothing
            Me.txtEmployeeCode.DataBoundControl = True
            Me.txtEmployeeCode.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtEmployeeCode.EditingMode = True
            Me.txtEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeCode.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeCode.LinkedLabel = Nothing
            Me.txtEmployeeCode.Location = New System.Drawing.Point(373, 455)
            Me.txtEmployeeCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeCode.MaximumValue = Nothing
            Me.txtEmployeeCode.MinimumValue = Nothing
            Me.txtEmployeeCode.Name = "txtEmployeeCode"
            Me.txtEmployeeCode.OldValue = Nothing
            Me.txtEmployeeCode.Size = New System.Drawing.Size(122, 23)
            Me.txtEmployeeCode.TabIndex = 40
            Me.txtEmployeeCode.Visible = False
            '
            'tbcPayroll
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.tbcPayroll, 6)
            Me.tbcPayroll.Controls.Add(Me.tpgEarnings)
            Me.tbcPayroll.Controls.Add(Me.tpgDeductions)
            Me.tbcPayroll.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbcPayroll.Location = New System.Drawing.Point(3, 78)
            Me.tbcPayroll.Name = "tbcPayroll"
            Me.tbcPayroll.SelectedIndex = 0
            Me.tbcPayroll.Size = New System.Drawing.Size(768, 348)
            Me.tbcPayroll.TabIndex = 34
            '
            'tpgEarnings
            '
            Me.tpgEarnings.Location = New System.Drawing.Point(4, 22)
            Me.tpgEarnings.Name = "tpgEarnings"
            Me.tpgEarnings.Padding = New System.Windows.Forms.Padding(3)
            Me.tpgEarnings.Size = New System.Drawing.Size(760, 322)
            Me.tpgEarnings.TabIndex = 0
            Me.tpgEarnings.Text = "Earnings"
            Me.tpgEarnings.UseVisualStyleBackColor = True
            '
            'tpgDeductions
            '
            Me.tpgDeductions.Location = New System.Drawing.Point(4, 22)
            Me.tpgDeductions.Name = "tpgDeductions"
            Me.tpgDeductions.Padding = New System.Windows.Forms.Padding(3)
            Me.tpgDeductions.Size = New System.Drawing.Size(760, 322)
            Me.tpgDeductions.TabIndex = 2
            Me.tpgDeductions.Text = "Deductions"
            Me.tpgDeductions.UseVisualStyleBackColor = True
            '
            'lblNotes
            '
            Me.lblNotes.AutoSize = True
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.Location = New System.Drawing.Point(1, 1)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(105, 17)
            Me.lblNotes.TabIndex = 4
            Me.lblNotes.Text = "Payroll Number"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPayrollIdNo
            '
            Me.txtPayrollIdNo.BackColor = System.Drawing.Color.White
            Me.txtPayrollIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPayrollIdNo.ComputedValue = False
            Me.txtPayrollIdNo.CustomFormat = Nothing
            Me.txtPayrollIdNo.DataBoundControl = True
            Me.txtPayrollIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayrollIdNo.EditingMode = True
            Me.txtPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayrollIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollIdNo.LinkedLabel = Nothing
            Me.txtPayrollIdNo.Location = New System.Drawing.Point(125, 1)
            Me.txtPayrollIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollIdNo.MaximumValue = Nothing
            Me.txtPayrollIdNo.MinimumValue = Nothing
            Me.txtPayrollIdNo.Name = "txtPayrollIdNo"
            Me.txtPayrollIdNo.OldValue = Nothing
            Me.txtPayrollIdNo.Size = New System.Drawing.Size(122, 23)
            Me.txtPayrollIdNo.TabIndex = 36
            '
            'CLabel1
            '
            Me.CLabel1.AutoSize = True
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(249, 1)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(72, 17)
            Me.CLabel1.TabIndex = 6
            Me.CLabel1.Text = "Start Date"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.dtpStartDate.Location = New System.Drawing.Point(373, 1)
            Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.Size = New System.Drawing.Size(115, 23)
            Me.dtpStartDate.TabIndex = 3
            Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpStartDate.Value = Nothing
            Me.dtpStartDate.ValueIsMandatory = False
            Me.dtpStartDate.ValueIsNullable = False
            '
            'lblEndDate
            '
            Me.lblEndDate.AutoSize = True
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndDate.Location = New System.Drawing.Point(497, 1)
            Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(67, 17)
            Me.lblEndDate.TabIndex = 7
            Me.lblEndDate.Text = "End Date"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(1, 26)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(107, 17)
            Me.CLabel3.TabIndex = 8
            Me.CLabel3.Text = "Pay Description"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPayPeriodName
            '
            Me.txtPayPeriodName.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayPeriodName, 5)
            Me.txtPayPeriodName.ComputedValue = False
            Me.txtPayPeriodName.CustomFormat = Nothing
            Me.txtPayPeriodName.DataBoundControl = True
            Me.txtPayPeriodName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayPeriodName.EditingMode = False
            Me.txtPayPeriodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayPeriodName.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodName.LinkedLabel = Nothing
            Me.txtPayPeriodName.Location = New System.Drawing.Point(125, 26)
            Me.txtPayPeriodName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayPeriodName.MaximumValue = Nothing
            Me.txtPayPeriodName.MinimumValue = Nothing
            Me.txtPayPeriodName.Name = "txtPayPeriodName"
            Me.txtPayPeriodName.OldValue = Nothing
            Me.txtPayPeriodName.ReadOnly = True
            Me.txtPayPeriodName.Size = New System.Drawing.Size(648, 23)
            Me.txtPayPeriodName.TabIndex = 35
            Me.txtPayPeriodName.ValueIsMandatory = True
            '
            'lblEmployeeName
            '
            Me.lblEmployeeName.AutoSize = True
            Me.lblEmployeeName.DisplayOnly = True
            Me.lblEmployeeName.EditingMode = False
            Me.lblEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEmployeeName.Location = New System.Drawing.Point(1, 51)
            Me.lblEmployeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmployeeName.Name = "lblEmployeeName"
            Me.lblEmployeeName.Size = New System.Drawing.Size(111, 17)
            Me.lblEmployeeName.TabIndex = 11
            Me.lblEmployeeName.Text = "Employee Name"
            Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'CLabel9
            '
            Me.CLabel9.AutoSize = True
            Me.CLabel9.DisplayOnly = True
            Me.CLabel9.EditingMode = False
            Me.CLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel9.Location = New System.Drawing.Point(1, 430)
            Me.CLabel9.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel9.Name = "CLabel9"
            Me.CLabel9.Size = New System.Drawing.Size(100, 17)
            Me.CLabel9.TabIndex = 27
            Me.CLabel9.Text = "Total Earnings"
            Me.CLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'CTextBox3
            '
            Me.CTextBox3.BackColor = System.Drawing.Color.White
            Me.CTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox3.ComputedValue = False
            Me.CTextBox3.CustomFormat = Nothing
            Me.CTextBox3.DataBoundControl = True
            Me.CTextBox3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CTextBox3.EditingMode = True
            Me.CTextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox3.ForeColor = System.Drawing.Color.Black
            Me.CTextBox3.LinkedLabel = Nothing
            Me.CTextBox3.Location = New System.Drawing.Point(125, 430)
            Me.CTextBox3.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox3.MaximumValue = Nothing
            Me.CTextBox3.MinimumValue = Nothing
            Me.CTextBox3.Name = "CTextBox3"
            Me.CTextBox3.OldValue = Nothing
            Me.CTextBox3.Size = New System.Drawing.Size(122, 23)
            Me.CTextBox3.TabIndex = 33
            '
            'cboEmployeeIdNo
            '
            Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboEmployeeIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboEmployeeIdNo, 5)
            Me.cboEmployeeIdNo.ComputedValue = False
            Me.cboEmployeeIdNo.CustomFormat = Nothing
            Me.cboEmployeeIdNo.DataBoundControl = True
            Me.cboEmployeeIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboEmployeeIdNo.EditingMode = False
            Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEmployeeIdNo.LinkedLabel = Nothing
            Me.cboEmployeeIdNo.Location = New System.Drawing.Point(125, 51)
            Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboEmployeeIdNo.MaximumValue = Nothing
            Me.cboEmployeeIdNo.MinimumValue = Nothing
            Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
            Me.cboEmployeeIdNo.OldValue = Nothing
            Me.cboEmployeeIdNo.ReadOnly = True
            Me.cboEmployeeIdNo.Size = New System.Drawing.Size(648, 23)
            Me.cboEmployeeIdNo.TabIndex = 39
            Me.cboEmployeeIdNo.ValueIsMandatory = True
            '
            'CLabel11
            '
            Me.CLabel11.AutoSize = True
            Me.CLabel11.DisplayOnly = True
            Me.CLabel11.EditingMode = False
            Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel11.Location = New System.Drawing.Point(497, 430)
            Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel11.Name = "CLabel11"
            Me.CLabel11.Size = New System.Drawing.Size(115, 17)
            Me.CLabel11.TabIndex = 32
            Me.CLabel11.Text = "Total Deductions"
            Me.CLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CLabel10
            '
            Me.CLabel10.AutoSize = True
            Me.CLabel10.DisplayOnly = True
            Me.CLabel10.EditingMode = False
            Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel10.Location = New System.Drawing.Point(497, 455)
            Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel10.Name = "CLabel10"
            Me.CLabel10.Size = New System.Drawing.Size(58, 17)
            Me.CLabel10.TabIndex = 29
            Me.CLabel10.Text = "Net Pay"
            Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.dtpEndDate.Location = New System.Drawing.Point(614, 1)
            Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.ReadOnlyDp = False
            Me.dtpEndDate.SecurityKey = Nothing
            Me.dtpEndDate.ShowLongDate = False
            Me.dtpEndDate.ShowTime = False
            Me.dtpEndDate.Size = New System.Drawing.Size(115, 23)
            Me.dtpEndDate.TabIndex = 37
            Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndDate.Value = Nothing
            Me.dtpEndDate.ValueIsMandatory = False
            Me.dtpEndDate.ValueIsNullable = False
            '
            'CTextBox2
            '
            Me.CTextBox2.BackColor = System.Drawing.Color.White
            Me.CTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox2.ComputedValue = False
            Me.CTextBox2.CustomFormat = Nothing
            Me.CTextBox2.DataBoundControl = True
            Me.CTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CTextBox2.EditingMode = True
            Me.CTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox2.ForeColor = System.Drawing.Color.Black
            Me.CTextBox2.LinkedLabel = Nothing
            Me.CTextBox2.Location = New System.Drawing.Point(614, 430)
            Me.CTextBox2.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox2.MaximumValue = Nothing
            Me.CTextBox2.MinimumValue = Nothing
            Me.CTextBox2.Name = "CTextBox2"
            Me.CTextBox2.OldValue = Nothing
            Me.CTextBox2.Size = New System.Drawing.Size(159, 23)
            Me.CTextBox2.TabIndex = 31
            '
            'CTextBox1
            '
            Me.CTextBox1.BackColor = System.Drawing.Color.White
            Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBox1.ComputedValue = False
            Me.CTextBox1.CustomFormat = Nothing
            Me.CTextBox1.DataBoundControl = True
            Me.CTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CTextBox1.EditingMode = True
            Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBox1.ForeColor = System.Drawing.Color.Black
            Me.CTextBox1.LinkedLabel = Nothing
            Me.CTextBox1.Location = New System.Drawing.Point(614, 455)
            Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBox1.MaximumValue = Nothing
            Me.CTextBox1.MinimumValue = Nothing
            Me.CTextBox1.Name = "CTextBox1"
            Me.CTextBox1.OldValue = Nothing
            Me.CTextBox1.Size = New System.Drawing.Size(159, 23)
            Me.CTextBox1.TabIndex = 28
            '
            'PayrollDetailEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1095, 574)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Name = "PayrollDetailEntry"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.tbcPayroll.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents lblEmployeeName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpStartDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblEndDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel9 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CTextBox3 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel11 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTextBox2 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel10 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents tbcPayroll As Libraries.CBaseControlsLibrary.CTabControl
        Friend WithEvents tpgEarnings As TabPage
        Friend WithEvents tpgDeductions As TabPage
        Friend WithEvents txtPayPeriodName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtPayrollIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents dtpEndDate As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtEmployeeNameAra As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtEmployeeName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtEmployeeCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtIdNo As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace