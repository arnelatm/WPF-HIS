Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayrollEntry
        Inherits AATM.PresentationLayer.Forms.CFormEntry

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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Payroll")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayrollEntry))
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.trvPayroll = New System.Windows.Forms.TreeView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtPayPeriodName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CTextBox3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CTextBox2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel9 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayrollDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CCustomDateTimePicker1 = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.tbcPayroll = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
        Me.tpgEarnings = New System.Windows.Forms.TabPage()
        Me.tpgDeductions = New System.Windows.Forms.TabPage()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.tbcPayroll.SuspendLayout
        Me.SuspendLayout
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
        Me.CFlowLayout1.Location = New System.Drawing.Point(0, 53)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(865, 518)
        Me.CFlowLayout1.TabIndex = 4
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.trvPayroll)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(862, 515)
        Me.SplitContainer1.SplitterDistance = 287
        Me.SplitContainer1.TabIndex = 0
        '
        'trvPayroll
        '
        Me.trvPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvPayroll.Location = New System.Drawing.Point(0, 0)
        Me.trvPayroll.Name = "trvPayroll"
        TreeNode1.Name = "Nodes()"
        TreeNode1.Text = "Payroll"
        Me.trvPayroll.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.trvPayroll.Size = New System.Drawing.Size(287, 515)
        Me.trvPayroll.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.49078!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.37752!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.06585!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.06585!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayPeriodName, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CTextBox3, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CTextBox2, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel9, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.cboEmployeeIdNo, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayrollDate, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayrollIdNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayrollIdNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CCustomDateTimePicker1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPayType, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CTextBox1, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.tbcPayroll, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(571, 515)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtPayPeriodName
        '
        Me.txtPayPeriodName.BackColor = System.Drawing.Color.White
        Me.txtPayPeriodName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayPeriodName, 3)
        Me.txtPayPeriodName.ComputedValue = false
        Me.txtPayPeriodName.CustomFormat = Nothing
        Me.txtPayPeriodName.DataBoundControl = true
        Me.txtPayPeriodName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayPeriodName.EditingMode = false
        Me.txtPayPeriodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayPeriodName.ForeColor = System.Drawing.Color.Black
        Me.txtPayPeriodName.LinkedLabel = Nothing
        Me.txtPayPeriodName.Location = New System.Drawing.Point(112, 51)
        Me.txtPayPeriodName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayPeriodName.MaximumValue = Nothing
        Me.txtPayPeriodName.MinimumValue = Nothing
        Me.txtPayPeriodName.Name = "txtPayPeriodName"
        Me.txtPayPeriodName.OldValue = Nothing
        Me.txtPayPeriodName.ReadOnly = true
        Me.txtPayPeriodName.Size = New System.Drawing.Size(458, 23)
        Me.txtPayPeriodName.TabIndex = 35
        Me.txtPayPeriodName.ValueIsMandatory = true
        '
        'CTextBox3
        '
        Me.CTextBox3.BackColor = System.Drawing.Color.White
        Me.CTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox3.ComputedValue = false
        Me.CTextBox3.CustomFormat = Nothing
        Me.CTextBox3.DataBoundControl = true
        Me.CTextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTextBox3.EditingMode = true
        Me.CTextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox3.ForeColor = System.Drawing.Color.Black
        Me.CTextBox3.LinkedLabel = Nothing
        Me.CTextBox3.Location = New System.Drawing.Point(112, 456)
        Me.CTextBox3.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox3.MaximumValue = Nothing
        Me.CTextBox3.MinimumValue = Nothing
        Me.CTextBox3.Name = "CTextBox3"
        Me.CTextBox3.OldValue = Nothing
        Me.CTextBox3.Size = New System.Drawing.Size(171, 23)
        Me.CTextBox3.TabIndex = 33
        '
        'CLabel11
        '
        Me.CLabel11.AutoSize = true
        Me.CLabel11.DisplayOnly = true
        Me.CLabel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel11.EditingMode = false
        Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel11.Location = New System.Drawing.Point(285, 456)
        Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel11.Name = "CLabel11"
        Me.CLabel11.Size = New System.Drawing.Size(141, 28)
        Me.CLabel11.TabIndex = 32
        Me.CLabel11.Text = "Total Deductions"
        Me.CLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CTextBox2
        '
        Me.CTextBox2.BackColor = System.Drawing.Color.White
        Me.CTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox2.ComputedValue = false
        Me.CTextBox2.CustomFormat = Nothing
        Me.CTextBox2.DataBoundControl = true
        Me.CTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTextBox2.EditingMode = true
        Me.CTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox2.ForeColor = System.Drawing.Color.Black
        Me.CTextBox2.LinkedLabel = Nothing
        Me.CTextBox2.Location = New System.Drawing.Point(428, 456)
        Me.CTextBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox2.MaximumValue = Nothing
        Me.CTextBox2.MinimumValue = Nothing
        Me.CTextBox2.Name = "CTextBox2"
        Me.CTextBox2.OldValue = Nothing
        Me.CTextBox2.Size = New System.Drawing.Size(142, 23)
        Me.CTextBox2.TabIndex = 31
        '
        'CLabel9
        '
        Me.CLabel9.AutoSize = true
        Me.CLabel9.DisplayOnly = true
        Me.CLabel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel9.EditingMode = false
        Me.CLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel9.Location = New System.Drawing.Point(1, 456)
        Me.CLabel9.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel9.Name = "CLabel9"
        Me.CLabel9.Size = New System.Drawing.Size(109, 28)
        Me.CLabel9.TabIndex = 27
        Me.CLabel9.Text = "Total Earnings"
        Me.CLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEmployeeIdNo
        '
        Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboEmployeeIdNo.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboEmployeeIdNo, 3)
        Me.cboEmployeeIdNo.CurrentSearchTerm = ""
        Me.cboEmployeeIdNo.DefaultValue = Nothing
        Me.cboEmployeeIdNo.DisplayMember = "Name"
        Me.cboEmployeeIdNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboEmployeeIdNo.DropDownHeight = 200
        Me.cboEmployeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployeeIdNo.EditingMode = true
        Me.cboEmployeeIdNo.FilterRule = Nothing
        Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEmployeeIdNo.FormattingEnabled = true
        Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cboEmployeeIdNo.LinkedLabel = Nothing
        Me.cboEmployeeIdNo.Location = New System.Drawing.Point(112, 76)
        Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = false
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cboEmployeeIdNo.PreviousSelectedIndex = -1
        Me.cboEmployeeIdNo.PropertySelector = Nothing
        Me.cboEmployeeIdNo.ReadOnlyCombo = false
        Me.cboEmployeeIdNo.SearchAnywhere = false
        Me.cboEmployeeIdNo.Size = New System.Drawing.Size(458, 24)
        Me.cboEmployeeIdNo.SuggestBoxHeight = 200
        Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cboEmployeeIdNo.TabIndex = 12
        Me.cboEmployeeIdNo.TextToSearch = Nothing
        Me.cboEmployeeIdNo.ValueIsMandatory = false
        Me.cboEmployeeIdNo.ValueIsNullable = false
        Me.cboEmployeeIdNo.ValueIsNumeric = false
        Me.cboEmployeeIdNo.ValueMember = "IdNo"
        '
        'CLabel4
        '
        Me.CLabel4.AutoSize = true
        Me.CLabel4.DisplayOnly = true
        Me.CLabel4.EditingMode = false
        Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel4.Location = New System.Drawing.Point(1, 76)
        Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel4.Name = "CLabel4"
        Me.CLabel4.Size = New System.Drawing.Size(60, 17)
        Me.CLabel4.TabIndex = 11
        Me.CLabel4.Text = "CLabel4"
        Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = true
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblNotes.Location = New System.Drawing.Point(1, 26)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(70, 17)
        Me.lblNotes.TabIndex = 4
        Me.lblNotes.Text = "Pay Cycle"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayrollDate
        '
        Me.lblPayrollDate.AutoSize = true
        Me.lblPayrollDate.DisplayOnly = true
        Me.lblPayrollDate.EditingMode = false
        Me.lblPayrollDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayrollDate.Location = New System.Drawing.Point(285, 1)
        Me.lblPayrollDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayrollDate.Name = "lblPayrollDate"
        Me.lblPayrollDate.Size = New System.Drawing.Size(85, 17)
        Me.lblPayrollDate.TabIndex = 2
        Me.lblPayrollDate.Text = "Payroll Date"
        Me.lblPayrollDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayrollIdNo
        '
        Me.txtPayrollIdNo.BackColor = System.Drawing.Color.White
        Me.txtPayrollIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollIdNo.ComputedValue = false
        Me.txtPayrollIdNo.CustomFormat = Nothing
        Me.txtPayrollIdNo.DataBoundControl = true
        Me.txtPayrollIdNo.EditingMode = true
        Me.txtPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayrollIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollIdNo.LinkedLabel = Nothing
        Me.txtPayrollIdNo.Location = New System.Drawing.Point(112, 1)
        Me.txtPayrollIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayrollIdNo.MaximumValue = Nothing
        Me.txtPayrollIdNo.MinimumValue = Nothing
        Me.txtPayrollIdNo.Name = "txtPayrollIdNo"
        Me.txtPayrollIdNo.OldValue = Nothing
        Me.txtPayrollIdNo.Size = New System.Drawing.Size(100, 23)
        Me.txtPayrollIdNo.TabIndex = 0
        '
        'lblPayrollIdNo
        '
        Me.lblPayrollIdNo.AutoSize = true
        Me.lblPayrollIdNo.DisplayOnly = true
        Me.lblPayrollIdNo.EditingMode = false
        Me.lblPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayrollIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblPayrollIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayrollIdNo.Name = "lblPayrollIdNo"
        Me.lblPayrollIdNo.Size = New System.Drawing.Size(77, 17)
        Me.lblPayrollIdNo.TabIndex = 1
        Me.lblPayrollIdNo.Text = "Payroll No."
        Me.lblPayrollIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CCustomDateTimePicker1
        '
        Me.CCustomDateTimePicker1.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.CCustomDateTimePicker1.DefaultValue = Nothing
        Me.CCustomDateTimePicker1.DisplayOnly = false
        Me.CCustomDateTimePicker1.DtpDefaultValue = Nothing
        Me.CCustomDateTimePicker1.EditingMode = true
        Me.CCustomDateTimePicker1.EditsAllowed = false
        Me.CCustomDateTimePicker1.ForeColor = System.Drawing.Color.Black
        Me.CCustomDateTimePicker1.LinkedLabel = Nothing
        Me.CCustomDateTimePicker1.Location = New System.Drawing.Point(428, 1)
        Me.CCustomDateTimePicker1.Margin = New System.Windows.Forms.Padding(1)
        Me.CCustomDateTimePicker1.Name = "CCustomDateTimePicker1"
        Me.CCustomDateTimePicker1.ReadOnlyDp = false
        Me.CCustomDateTimePicker1.SecurityKey = Nothing
        Me.CCustomDateTimePicker1.ShowLongDate = false
        Me.CCustomDateTimePicker1.ShowTime = false
        Me.CCustomDateTimePicker1.Size = New System.Drawing.Size(107, 23)
        Me.CCustomDateTimePicker1.TabIndex = 3
        Me.CCustomDateTimePicker1.TargetCalendar = CType(resources.GetObject("CCustomDateTimePicker1.TargetCalendar"),System.Globalization.Calendar)
        Me.CCustomDateTimePicker1.Value = Nothing
        Me.CCustomDateTimePicker1.ValueIsMandatory = false
        Me.CCustomDateTimePicker1.ValueIsNullable = false
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(285, 26)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(60, 17)
        Me.CLabel1.TabIndex = 6
        Me.CLabel1.Text = "CLabel1"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel2
        '
        Me.CLabel2.AutoSize = true
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(428, 26)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(60, 17)
        Me.CLabel2.TabIndex = 7
        Me.CLabel2.Text = "CLabel2"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel3
        '
        Me.CLabel3.AutoSize = true
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(1, 51)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(60, 17)
        Me.CLabel3.TabIndex = 8
        Me.CLabel3.Text = "CLabel3"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPayType
        '
        Me.cboPayType.BackColor = System.Drawing.Color.White
        Me.cboPayType.ChangingSearchValueOnly = false
        Me.cboPayType.CurrentSearchTerm = ""
        Me.cboPayType.DefaultValue = Nothing
        Me.cboPayType.DisplayMember = "Name"
        Me.cboPayType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPayType.DropDownHeight = 200
        Me.cboPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayType.EditingMode = true
        Me.cboPayType.FilterRule = Nothing
        Me.cboPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboPayType.ForeColor = System.Drawing.Color.Black
        Me.cboPayType.FormattingEnabled = true
        Me.cboPayType.HideWhenNotEditingOrAdding = false
        Me.cboPayType.LinkedLabel = Nothing
        Me.cboPayType.Location = New System.Drawing.Point(112, 26)
        Me.cboPayType.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPayType.Name = "cboPayType"
        Me.cboPayType.OldValue = 0
        Me.cboPayType.OriginalDataSource = Nothing
        Me.cboPayType.OriginalList = Nothing
        Me.cboPayType.OverrideDropDownStyleList = false
        Me.cboPayType.PreviousSearchTerm = Nothing
        Me.cboPayType.PreviousSelectedIndex = -1
        Me.cboPayType.PropertySelector = Nothing
        Me.cboPayType.ReadOnlyCombo = false
        Me.cboPayType.SearchAnywhere = false
        Me.cboPayType.Size = New System.Drawing.Size(171, 24)
        Me.cboPayType.SuggestBoxHeight = 200
        Me.cboPayType.SuggestListOrderRule = Nothing
        Me.cboPayType.TabIndex = 10
        Me.cboPayType.TextToSearch = Nothing
        Me.cboPayType.ValueIsMandatory = false
        Me.cboPayType.ValueIsNullable = false
        Me.cboPayType.ValueIsNumeric = false
        Me.cboPayType.ValueMember = "IdNo"
        '
        'CTextBox1
        '
        Me.CTextBox1.BackColor = System.Drawing.Color.White
        Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox1.ComputedValue = false
        Me.CTextBox1.CustomFormat = Nothing
        Me.CTextBox1.DataBoundControl = true
        Me.CTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTextBox1.EditingMode = true
        Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox1.ForeColor = System.Drawing.Color.Black
        Me.CTextBox1.LinkedLabel = Nothing
        Me.CTextBox1.Location = New System.Drawing.Point(285, 486)
        Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox1.MaximumValue = Nothing
        Me.CTextBox1.MinimumValue = Nothing
        Me.CTextBox1.Name = "CTextBox1"
        Me.CTextBox1.OldValue = Nothing
        Me.CTextBox1.Size = New System.Drawing.Size(141, 23)
        Me.CTextBox1.TabIndex = 28
        '
        'CLabel10
        '
        Me.CLabel10.AutoSize = true
        Me.CLabel10.DisplayOnly = true
        Me.CLabel10.EditingMode = false
        Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel10.Location = New System.Drawing.Point(112, 486)
        Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel10.Name = "CLabel10"
        Me.CLabel10.Size = New System.Drawing.Size(58, 17)
        Me.CLabel10.TabIndex = 29
        Me.CLabel10.Text = "Net Pay"
        Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbcPayroll
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.tbcPayroll, 4)
        Me.tbcPayroll.Controls.Add(Me.tpgEarnings)
        Me.tbcPayroll.Controls.Add(Me.tpgDeductions)
        Me.tbcPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcPayroll.Location = New System.Drawing.Point(3, 104)
        Me.tbcPayroll.Name = "tbcPayroll"
        Me.tbcPayroll.SelectedIndex = 0
        Me.tbcPayroll.Size = New System.Drawing.Size(565, 348)
        Me.tbcPayroll.TabIndex = 34
        '
        'tpgEarnings
        '
        Me.tpgEarnings.Location = New System.Drawing.Point(4, 22)
        Me.tpgEarnings.Name = "tpgEarnings"
        Me.tpgEarnings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgEarnings.Size = New System.Drawing.Size(557, 322)
        Me.tpgEarnings.TabIndex = 0
        Me.tpgEarnings.Text = "Earnings"
        Me.tpgEarnings.UseVisualStyleBackColor = true
        '
        'tpgDeductions
        '
        Me.tpgDeductions.Location = New System.Drawing.Point(4, 22)
        Me.tpgDeductions.Name = "tpgDeductions"
        Me.tpgDeductions.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgDeductions.Size = New System.Drawing.Size(557, 321)
        Me.tpgDeductions.TabIndex = 2
        Me.tpgDeductions.Text = "Deductions"
        Me.tpgDeductions.UseVisualStyleBackColor = true
        '
        'PayrollEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(867, 581)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "PayrollEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.tbcPayroll.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents CLabel4 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPayrollDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPayrollIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPayrollIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CCustomDateTimePicker1 As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPayType As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents CLabel9 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CTextBox3 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel11 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTextBox2 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel10 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents tbcPayroll As Libraries.CBaseControlsLibrary.CTabControl
        Friend WithEvents tpgEarnings As TabPage
        Friend WithEvents tpgDeductions As TabPage
        Friend WithEvents trvPayroll As TreeView
        Friend WithEvents txtPayPeriodName As Libraries.CBaseControlsLibrary.CTextBox
    End Class
End Namespace