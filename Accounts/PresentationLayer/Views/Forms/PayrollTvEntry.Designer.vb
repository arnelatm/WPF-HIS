Imports AATM.PresentationLayer.Forms.PresentationLayer.Views.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayrollTvEntry
        Inherits CFormTvEntry

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
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node0")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayrollTvEntry))
        Me.trvPayroll = New System.Windows.Forms.TreeView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.trvPayPeriods = New System.Windows.Forms.TreeView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.CTextBox4 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CTextBox5 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CTextBox6 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel6 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CaComboBox1 = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel8 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel12 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel13 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CCustomDateTimePicker2 = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.CLabel14 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel15 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel16 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CaComboBox2 = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CTextBox8 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel17 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CTabControl1 = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer2.Panel1.SuspendLayout
        Me.SplitContainer2.Panel2.SuspendLayout
        Me.SplitContainer2.SuspendLayout
        Me.TableLayoutPanel2.SuspendLayout
        Me.CTabControl1.SuspendLayout
        Me.SuspendLayout
            '
            'trvTreeView
            '
            Me.trvTreeView.LineColor = System.Drawing.Color.Black
            Me.trvTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No
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
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 53)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer2.Panel1.Controls.Add(Me.trvPayPeriods)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer2.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer2.Size = New System.Drawing.Size(867, 528)
        Me.SplitContainer2.SplitterDistance = 289
        Me.SplitContainer2.TabIndex = 4
        '
        'trvPayPeriods
        '
        Me.trvPayPeriods.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvPayPeriods.Location = New System.Drawing.Point(0, 0)
        Me.trvPayPeriods.Name = "trvPayPeriods"
        TreeNode2.Name = "Node0"
        TreeNode2.Text = "Node0"
        Me.trvPayPeriods.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.trvPayPeriods.Size = New System.Drawing.Size(289, 528)
        Me.trvPayPeriods.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.49078!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.37752!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.06585!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.06585!))
        Me.TableLayoutPanel2.Controls.Add(Me.CTextBox4, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CTextBox5, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel5, 2, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.CTextBox6, 3, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel6, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.CaComboBox1, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel7, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel8, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel12, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtIdNo, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel13, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CCustomDateTimePicker2, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel14, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel15, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel16, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CaComboBox2, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.CTextBox8, 2, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.CLabel17, 1, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.CTabControl1, 0, 4)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 7
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(574, 528)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'CTextBox4
        '
        Me.CTextBox4.BackColor = System.Drawing.Color.White
        Me.CTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel2.SetColumnSpan(Me.CTextBox4, 3)
        Me.CTextBox4.ComputedValue = false
        Me.CTextBox4.CustomFormat = Nothing
        Me.CTextBox4.DataBoundControl = true
        Me.CTextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTextBox4.EditingMode = false
        Me.CTextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox4.ForeColor = System.Drawing.Color.Black
        Me.CTextBox4.LinkedLabel = Nothing
        Me.CTextBox4.Location = New System.Drawing.Point(112, 51)
        Me.CTextBox4.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox4.MaximumValue = Nothing
        Me.CTextBox4.MinimumValue = Nothing
        Me.CTextBox4.Name = "CTextBox4"
        Me.CTextBox4.OldValue = Nothing
        Me.CTextBox4.ReadOnly = true
        Me.CTextBox4.Size = New System.Drawing.Size(461, 23)
        Me.CTextBox4.TabIndex = 35
        Me.CTextBox4.ValueIsMandatory = true
        '
        'CTextBox5
        '
        Me.CTextBox5.BackColor = System.Drawing.Color.White
        Me.CTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox5.ComputedValue = false
        Me.CTextBox5.CustomFormat = Nothing
        Me.CTextBox5.DataBoundControl = true
        Me.CTextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTextBox5.EditingMode = true
        Me.CTextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox5.ForeColor = System.Drawing.Color.Black
        Me.CTextBox5.LinkedLabel = Nothing
        Me.CTextBox5.Location = New System.Drawing.Point(112, 469)
        Me.CTextBox5.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox5.MaximumValue = Nothing
        Me.CTextBox5.MinimumValue = Nothing
        Me.CTextBox5.Name = "CTextBox5"
        Me.CTextBox5.OldValue = Nothing
        Me.CTextBox5.Size = New System.Drawing.Size(172, 23)
        Me.CTextBox5.TabIndex = 33
        '
        'CLabel5
        '
        Me.CLabel5.AutoSize = true
        Me.CLabel5.DisplayOnly = true
        Me.CLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel5.EditingMode = false
        Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel5.Location = New System.Drawing.Point(286, 469)
        Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel5.Name = "CLabel5"
        Me.CLabel5.Size = New System.Drawing.Size(141, 28)
        Me.CLabel5.TabIndex = 32
        Me.CLabel5.Text = "Total Deductions"
        Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CTextBox6
        '
        Me.CTextBox6.BackColor = System.Drawing.Color.White
        Me.CTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox6.ComputedValue = false
        Me.CTextBox6.CustomFormat = Nothing
        Me.CTextBox6.DataBoundControl = true
        Me.CTextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTextBox6.EditingMode = true
        Me.CTextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox6.ForeColor = System.Drawing.Color.Black
        Me.CTextBox6.LinkedLabel = Nothing
        Me.CTextBox6.Location = New System.Drawing.Point(429, 469)
        Me.CTextBox6.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox6.MaximumValue = Nothing
        Me.CTextBox6.MinimumValue = Nothing
        Me.CTextBox6.Name = "CTextBox6"
        Me.CTextBox6.OldValue = Nothing
        Me.CTextBox6.Size = New System.Drawing.Size(144, 23)
        Me.CTextBox6.TabIndex = 31
        '
        'CLabel6
        '
        Me.CLabel6.AutoSize = true
        Me.CLabel6.DisplayOnly = true
        Me.CLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel6.EditingMode = false
        Me.CLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel6.Location = New System.Drawing.Point(1, 469)
        Me.CLabel6.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel6.Name = "CLabel6"
        Me.CLabel6.Size = New System.Drawing.Size(109, 28)
        Me.CLabel6.TabIndex = 27
        Me.CLabel6.Text = "Total Earnings"
        Me.CLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CaComboBox1
        '
        Me.CaComboBox1.BackColor = System.Drawing.Color.White
        Me.CaComboBox1.ChangingSearchValueOnly = false
        Me.TableLayoutPanel2.SetColumnSpan(Me.CaComboBox1, 3)
        Me.CaComboBox1.CurrentSearchTerm = ""
        Me.CaComboBox1.DefaultValue = Nothing
        Me.CaComboBox1.DisplayMember = "Name"
        Me.CaComboBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CaComboBox1.DropDownHeight = 200
        Me.CaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CaComboBox1.EditingMode = true
        Me.CaComboBox1.FilterRule = Nothing
        Me.CaComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CaComboBox1.ForeColor = System.Drawing.Color.Black
        Me.CaComboBox1.FormattingEnabled = true
        Me.CaComboBox1.HideWhenNotEditingOrAdding = false
        Me.CaComboBox1.LinkedLabel = Nothing
        Me.CaComboBox1.Location = New System.Drawing.Point(112, 76)
        Me.CaComboBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CaComboBox1.Name = "CaComboBox1"
        Me.CaComboBox1.OldValue = 0
        Me.CaComboBox1.OriginalDataSource = Nothing
        Me.CaComboBox1.OriginalList = Nothing
        Me.CaComboBox1.OverrideDropDownStyleList = false
        Me.CaComboBox1.PreviousSearchTerm = Nothing
        Me.CaComboBox1.PreviousSelectedIndex = -1
        Me.CaComboBox1.PropertySelector = Nothing
        Me.CaComboBox1.ReadOnlyCombo = false
        Me.CaComboBox1.SearchAnywhere = false
        Me.CaComboBox1.Size = New System.Drawing.Size(461, 24)
        Me.CaComboBox1.SuggestBoxHeight = 200
        Me.CaComboBox1.SuggestListOrderRule = Nothing
        Me.CaComboBox1.TabIndex = 12
        Me.CaComboBox1.TextToSearch = Nothing
        Me.CaComboBox1.ValueIsMandatory = false
        Me.CaComboBox1.ValueIsNullable = false
        Me.CaComboBox1.ValueIsNumeric = false
        Me.CaComboBox1.ValueMember = "IdNo"
        '
        'CLabel7
        '
        Me.CLabel7.AutoSize = true
        Me.CLabel7.DisplayOnly = true
        Me.CLabel7.EditingMode = false
        Me.CLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel7.Location = New System.Drawing.Point(1, 76)
        Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel7.Name = "CLabel7"
        Me.CLabel7.Size = New System.Drawing.Size(60, 17)
        Me.CLabel7.TabIndex = 11
        Me.CLabel7.Text = "CLabel7"
        Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel8
        '
        Me.CLabel8.AutoSize = true
        Me.CLabel8.DisplayOnly = true
        Me.CLabel8.EditingMode = false
        Me.CLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel8.Location = New System.Drawing.Point(1, 26)
        Me.CLabel8.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel8.Name = "CLabel8"
        Me.CLabel8.Size = New System.Drawing.Size(70, 17)
        Me.CLabel8.TabIndex = 4
        Me.CLabel8.Text = "Pay Cycle"
        Me.CLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel12
        '
        Me.CLabel12.AutoSize = true
        Me.CLabel12.DisplayOnly = true
        Me.CLabel12.EditingMode = false
        Me.CLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel12.Location = New System.Drawing.Point(286, 1)
        Me.CLabel12.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel12.Name = "CLabel12"
        Me.CLabel12.Size = New System.Drawing.Size(85, 17)
        Me.CLabel12.TabIndex = 2
        Me.CLabel12.Text = "Payroll Date"
        Me.CLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIdNo
        '
        Me.txtIdNo.BackColor = System.Drawing.Color.White
        Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdNo.ComputedValue = false
        Me.txtIdNo.CustomFormat = Nothing
        Me.txtIdNo.DataBoundControl = true
        Me.txtIdNo.EditingMode = true
        Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtIdNo.LinkedLabel = Nothing
        Me.txtIdNo.Location = New System.Drawing.Point(112, 1)
        Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIdNo.MaximumValue = Nothing
        Me.txtIdNo.MinimumValue = Nothing
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.OldValue = Nothing
        Me.txtIdNo.Size = New System.Drawing.Size(100, 23)
        Me.txtIdNo.TabIndex = 0
        '
        'CLabel13
        '
        Me.CLabel13.AutoSize = true
        Me.CLabel13.DisplayOnly = true
        Me.CLabel13.EditingMode = false
        Me.CLabel13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel13.Location = New System.Drawing.Point(1, 1)
        Me.CLabel13.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel13.Name = "CLabel13"
        Me.CLabel13.Size = New System.Drawing.Size(77, 17)
        Me.CLabel13.TabIndex = 1
        Me.CLabel13.Text = "Payroll No."
        Me.CLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CCustomDateTimePicker2
        '
        Me.CCustomDateTimePicker2.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.CCustomDateTimePicker2.DefaultValue = Nothing
        Me.CCustomDateTimePicker2.DisplayOnly = false
        Me.CCustomDateTimePicker2.DtpDefaultValue = Nothing
        Me.CCustomDateTimePicker2.EditingMode = true
        Me.CCustomDateTimePicker2.EditsAllowed = false
        Me.CCustomDateTimePicker2.ForeColor = System.Drawing.Color.Black
        Me.CCustomDateTimePicker2.LinkedLabel = Nothing
        Me.CCustomDateTimePicker2.Location = New System.Drawing.Point(429, 1)
        Me.CCustomDateTimePicker2.Margin = New System.Windows.Forms.Padding(1)
        Me.CCustomDateTimePicker2.Name = "CCustomDateTimePicker2"
        Me.CCustomDateTimePicker2.ReadOnlyDp = false
        Me.CCustomDateTimePicker2.SecurityKey = Nothing
        Me.CCustomDateTimePicker2.ShowLongDate = false
        Me.CCustomDateTimePicker2.ShowTime = false
        Me.CCustomDateTimePicker2.Size = New System.Drawing.Size(107, 23)
        Me.CCustomDateTimePicker2.TabIndex = 3
        Me.CCustomDateTimePicker2.TargetCalendar = CType(resources.GetObject("CCustomDateTimePicker2.TargetCalendar"),System.Globalization.Calendar)
        Me.CCustomDateTimePicker2.Value = Nothing
        Me.CCustomDateTimePicker2.ValueIsMandatory = false
        Me.CCustomDateTimePicker2.ValueIsNullable = false
        '
        'CLabel14
        '
        Me.CLabel14.AutoSize = true
        Me.CLabel14.DisplayOnly = true
        Me.CLabel14.EditingMode = false
        Me.CLabel14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel14.Location = New System.Drawing.Point(286, 26)
        Me.CLabel14.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel14.Name = "CLabel14"
        Me.CLabel14.Size = New System.Drawing.Size(68, 17)
        Me.CLabel14.TabIndex = 6
        Me.CLabel14.Text = "CLabel14"
        Me.CLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel15
        '
        Me.CLabel15.AutoSize = true
        Me.CLabel15.DisplayOnly = true
        Me.CLabel15.EditingMode = false
        Me.CLabel15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel15.Location = New System.Drawing.Point(429, 26)
        Me.CLabel15.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel15.Name = "CLabel15"
        Me.CLabel15.Size = New System.Drawing.Size(68, 17)
        Me.CLabel15.TabIndex = 7
        Me.CLabel15.Text = "CLabel15"
        Me.CLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel16
        '
        Me.CLabel16.AutoSize = true
        Me.CLabel16.DisplayOnly = true
        Me.CLabel16.EditingMode = false
        Me.CLabel16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel16.Location = New System.Drawing.Point(1, 51)
        Me.CLabel16.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel16.Name = "CLabel16"
        Me.CLabel16.Size = New System.Drawing.Size(68, 17)
        Me.CLabel16.TabIndex = 8
        Me.CLabel16.Text = "CLabel16"
        Me.CLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CaComboBox2
        '
        Me.CaComboBox2.BackColor = System.Drawing.Color.White
        Me.CaComboBox2.ChangingSearchValueOnly = false
        Me.CaComboBox2.CurrentSearchTerm = ""
        Me.CaComboBox2.DefaultValue = Nothing
        Me.CaComboBox2.DisplayMember = "Name"
        Me.CaComboBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CaComboBox2.DropDownHeight = 200
        Me.CaComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CaComboBox2.EditingMode = true
        Me.CaComboBox2.FilterRule = Nothing
        Me.CaComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CaComboBox2.ForeColor = System.Drawing.Color.Black
        Me.CaComboBox2.FormattingEnabled = true
        Me.CaComboBox2.HideWhenNotEditingOrAdding = false
        Me.CaComboBox2.LinkedLabel = Nothing
        Me.CaComboBox2.Location = New System.Drawing.Point(112, 26)
        Me.CaComboBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.CaComboBox2.Name = "CaComboBox2"
        Me.CaComboBox2.OldValue = 0
        Me.CaComboBox2.OriginalDataSource = Nothing
        Me.CaComboBox2.OriginalList = Nothing
        Me.CaComboBox2.OverrideDropDownStyleList = false
        Me.CaComboBox2.PreviousSearchTerm = Nothing
        Me.CaComboBox2.PreviousSelectedIndex = -1
        Me.CaComboBox2.PropertySelector = Nothing
        Me.CaComboBox2.ReadOnlyCombo = false
        Me.CaComboBox2.SearchAnywhere = false
        Me.CaComboBox2.Size = New System.Drawing.Size(172, 24)
        Me.CaComboBox2.SuggestBoxHeight = 200
        Me.CaComboBox2.SuggestListOrderRule = Nothing
        Me.CaComboBox2.TabIndex = 10
        Me.CaComboBox2.TextToSearch = Nothing
        Me.CaComboBox2.ValueIsMandatory = false
        Me.CaComboBox2.ValueIsNullable = false
        Me.CaComboBox2.ValueIsNumeric = false
        Me.CaComboBox2.ValueMember = "IdNo"
        '
        'CTextBox8
        '
        Me.CTextBox8.BackColor = System.Drawing.Color.White
        Me.CTextBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox8.ComputedValue = false
        Me.CTextBox8.CustomFormat = Nothing
        Me.CTextBox8.DataBoundControl = true
        Me.CTextBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTextBox8.EditingMode = true
        Me.CTextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CTextBox8.ForeColor = System.Drawing.Color.Black
        Me.CTextBox8.LinkedLabel = Nothing
        Me.CTextBox8.Location = New System.Drawing.Point(286, 499)
        Me.CTextBox8.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox8.MaximumValue = Nothing
        Me.CTextBox8.MinimumValue = Nothing
        Me.CTextBox8.Name = "CTextBox8"
        Me.CTextBox8.OldValue = Nothing
        Me.CTextBox8.Size = New System.Drawing.Size(141, 23)
        Me.CTextBox8.TabIndex = 28
        '
        'CLabel17
        '
        Me.CLabel17.AutoSize = true
        Me.CLabel17.DisplayOnly = true
        Me.CLabel17.EditingMode = false
        Me.CLabel17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel17.Location = New System.Drawing.Point(112, 499)
        Me.CLabel17.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel17.Name = "CLabel17"
        Me.CLabel17.Size = New System.Drawing.Size(58, 17)
        Me.CLabel17.TabIndex = 29
        Me.CLabel17.Text = "Net Pay"
        Me.CLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CTabControl1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.CTabControl1, 4)
        Me.CTabControl1.Controls.Add(Me.TabPage1)
        Me.CTabControl1.Controls.Add(Me.TabPage2)
        Me.CTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTabControl1.Location = New System.Drawing.Point(3, 104)
        Me.CTabControl1.Name = "CTabControl1"
        Me.CTabControl1.SelectedIndex = 0
        Me.CTabControl1.Size = New System.Drawing.Size(568, 361)
        Me.CTabControl1.TabIndex = 34
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(560, 335)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Earnings"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(560, 334)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "Deductions"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'PayrollTvEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(867, 581)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Name = "PayrollTvEntry"
        Me.Controls.SetChildIndex(Me.SplitContainer2, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer2.Panel1.ResumeLayout(false)
        Me.SplitContainer2.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer2.ResumeLayout(false)
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        Me.CTabControl1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents trvPayroll As TreeView
        Friend WithEvents SplitContainer2 As SplitContainer
        Friend WithEvents trvPayPeriods As TreeView
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents CTextBox4 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CTextBox5 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTextBox6 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel6 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CaComboBox1 As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents CLabel7 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel8 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel12 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel13 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CCustomDateTimePicker2 As Libraries.CustomControlsLibrary.CCustomDateTimePicker
        Friend WithEvents CLabel14 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel15 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel16 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CaComboBox2 As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents CTextBox8 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel17 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CTabControl1 As Libraries.CBaseControlsLibrary.CTabControl
        Friend WithEvents TabPage1 As TabPage
        Friend WithEvents TabPage2 As TabPage
    End Class
End Namespace