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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayrollEntry))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CTreeView1 = New AATM.Libraries.CBaseControlsLibrary.CTreeView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CTextBox3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CTextBox2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel9 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CDataGridView3 = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.CLabel8 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel6 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayrollDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CCustomDateTimePicker1 = New AATM.Libraries.CustomControlsLibrary.CCustomDateTimePicker()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboPayType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.CDataGridView1 = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.CDataGridView2 = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.CDataGridView4 = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CFlowLayout1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.CDataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.CTreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(862, 515)
        Me.SplitContainer1.SplitterDistance = 287
        Me.SplitContainer1.TabIndex = 0
        '
        'CTreeView1
        '
        Me.CTreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTreeView1.Location = New System.Drawing.Point(0, 0)
        Me.CTreeView1.Name = "CTreeView1"
        Me.CTreeView1.Size = New System.Drawing.Size(287, 515)
        Me.CTreeView1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.49078!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.37752!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.06585!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.06585!))
        Me.TableLayoutPanel1.Controls.Add(Me.CTextBox3, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.CTextBox2, 3, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel9, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.CDataGridView3, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel8, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel7, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel6, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cboEmployeeIdNo, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayrollDate, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayrollIdNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayrollIdNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CCustomDateTimePicker1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPayType, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CDataGridView1, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.CDataGridView2, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.CDataGridView4, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CTextBox1, 2, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 1, 9)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(571, 515)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.CTextBox3.Location = New System.Drawing.Point(112, 455)
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
        Me.CLabel11.AutoSize = True
        Me.CLabel11.DisplayOnly = True
        Me.CLabel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel11.EditingMode = False
        Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel11.Location = New System.Drawing.Point(285, 455)
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
        Me.CTextBox2.ComputedValue = False
        Me.CTextBox2.CustomFormat = Nothing
        Me.CTextBox2.DataBoundControl = True
        Me.CTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTextBox2.EditingMode = True
        Me.CTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CTextBox2.ForeColor = System.Drawing.Color.Black
        Me.CTextBox2.LinkedLabel = Nothing
        Me.CTextBox2.Location = New System.Drawing.Point(428, 455)
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
        Me.CLabel9.AutoSize = True
        Me.CLabel9.DisplayOnly = True
        Me.CLabel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel9.EditingMode = False
        Me.CLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel9.Location = New System.Drawing.Point(1, 455)
        Me.CLabel9.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel9.Name = "CLabel9"
        Me.CLabel9.Size = New System.Drawing.Size(109, 28)
        Me.CLabel9.TabIndex = 27
        Me.CLabel9.Text = "Total Earnings"
        Me.CLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CDataGridView3
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.CDataGridView3.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.CDataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.CDataGridView3, 2)
        Me.CDataGridView3.DataInGridChanged = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CDataGridView3.DefaultCellStyle = DataGridViewCellStyle2
        Me.CDataGridView3.DgvFooter = Nothing
        Me.CDataGridView3.DisplayOnly = False
        Me.CDataGridView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CDataGridView3.Ea = Nothing
        Me.CDataGridView3.EditingMode = False
        Me.CDataGridView3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.CDataGridView3.FirstRowDeletionEnabled = True
        Me.CDataGridView3.FirstRowInsertionEnabled = True
        Me.CDataGridView3.Location = New System.Drawing.Point(3, 133)
        Me.CDataGridView3.Name = "CDataGridView3"
        Me.CDataGridView3.ReadOnly = True
        Me.CDataGridView3.SequenceColumn = "dgvSequence"
        Me.CDataGridView3.SequenceFieldName = "Sequence"
        Me.CDataGridView3.ShowFooter = False
        Me.CDataGridView3.ShowInsertColumnWhenEditing = True
        Me.CDataGridView3.Size = New System.Drawing.Size(278, 146)
        Me.CDataGridView3.StartTrackingChanges = False
        Me.CDataGridView3.TabIndex = 25
        '
        'CLabel8
        '
        Me.CLabel8.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel8, 2)
        Me.CLabel8.DisplayOnly = True
        Me.CLabel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel8.EditingMode = False
        Me.CLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel8.Location = New System.Drawing.Point(1, 283)
        Me.CLabel8.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel8.Name = "CLabel8"
        Me.CLabel8.Size = New System.Drawing.Size(282, 18)
        Me.CLabel8.TabIndex = 22
        Me.CLabel8.Text = "Current Earnings"
        Me.CLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLabel7
        '
        Me.CLabel7.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel7, 2)
        Me.CLabel7.DisplayOnly = True
        Me.CLabel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel7.EditingMode = False
        Me.CLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel7.Location = New System.Drawing.Point(285, 283)
        Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel7.Name = "CLabel7"
        Me.CLabel7.Size = New System.Drawing.Size(285, 18)
        Me.CLabel7.TabIndex = 21
        Me.CLabel7.Text = "Current Deductions"
        Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLabel6
        '
        Me.CLabel6.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel6, 2)
        Me.CLabel6.DisplayOnly = True
        Me.CLabel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel6.EditingMode = False
        Me.CLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel6.Location = New System.Drawing.Point(285, 101)
        Me.CLabel6.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel6.Name = "CLabel6"
        Me.CLabel6.Size = New System.Drawing.Size(285, 28)
        Me.CLabel6.TabIndex = 19
        Me.CLabel6.Text = "Regular Deductions"
        Me.CLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLabel5
        '
        Me.CLabel5.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel5, 2)
        Me.CLabel5.DisplayOnly = True
        Me.CLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel5.EditingMode = False
        Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel5.Location = New System.Drawing.Point(1, 101)
        Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel5.Name = "CLabel5"
        Me.CLabel5.Size = New System.Drawing.Size(282, 28)
        Me.CLabel5.TabIndex = 18
        Me.CLabel5.Text = "Regular Earnings"
        Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboEmployeeIdNo
        '
        Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboEmployeeIdNo.ChangingSearchValueOnly = False
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboEmployeeIdNo, 3)
        Me.cboEmployeeIdNo.CurrentSearchTerm = ""
        Me.cboEmployeeIdNo.DefaultValue = Nothing
        Me.cboEmployeeIdNo.DisplayMember = "Name"
        Me.cboEmployeeIdNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboEmployeeIdNo.DropDownHeight = 200
        Me.cboEmployeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployeeIdNo.EditingMode = True
        Me.cboEmployeeIdNo.FilterRule = Nothing
        Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEmployeeIdNo.FormattingEnabled = True
        Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
        Me.cboEmployeeIdNo.LinkedLabel = Nothing
        Me.cboEmployeeIdNo.Location = New System.Drawing.Point(112, 76)
        Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cboEmployeeIdNo.PreviousSelectedIndex = -1
        Me.cboEmployeeIdNo.PropertySelector = Nothing
        Me.cboEmployeeIdNo.ReadOnlyCombo = False
        Me.cboEmployeeIdNo.SearchAnywhere = False
        Me.cboEmployeeIdNo.Size = New System.Drawing.Size(458, 24)
        Me.cboEmployeeIdNo.SuggestBoxHeight = 200
        Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cboEmployeeIdNo.TabIndex = 12
        Me.cboEmployeeIdNo.TextToSearch = Nothing
        Me.cboEmployeeIdNo.ValueIsMandatory = False
        Me.cboEmployeeIdNo.ValueIsNullable = False
        Me.cboEmployeeIdNo.ValueIsNumeric = False
        Me.cboEmployeeIdNo.ValueMember = "IdNo"
        '
        'CLabel4
        '
        Me.CLabel4.AutoSize = True
        Me.CLabel4.DisplayOnly = True
        Me.CLabel4.EditingMode = False
        Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel4.Location = New System.Drawing.Point(1, 76)
        Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel4.Name = "CLabel4"
        Me.CLabel4.Size = New System.Drawing.Size(60, 17)
        Me.CLabel4.TabIndex = 11
        Me.CLabel4.Text = "CLabel4"
        Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 3)
        Me.txtNotes.ComputedValue = False
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = True
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.EditingMode = True
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.Location = New System.Drawing.Point(112, 51)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.Size = New System.Drawing.Size(458, 23)
        Me.txtNotes.TabIndex = 9
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.DisplayOnly = True
        Me.lblNotes.EditingMode = False
        Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblNotes.Location = New System.Drawing.Point(1, 26)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(60, 17)
        Me.lblNotes.TabIndex = 4
        Me.lblNotes.Text = "CLabel1"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPayrollDate
        '
        Me.lblPayrollDate.AutoSize = True
        Me.lblPayrollDate.DisplayOnly = True
        Me.lblPayrollDate.EditingMode = False
        Me.lblPayrollDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
        Me.txtPayrollIdNo.ComputedValue = False
        Me.txtPayrollIdNo.CustomFormat = Nothing
        Me.txtPayrollIdNo.DataBoundControl = True
        Me.txtPayrollIdNo.EditingMode = True
        Me.txtPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
        Me.lblPayrollIdNo.AutoSize = True
        Me.lblPayrollIdNo.DisplayOnly = True
        Me.lblPayrollIdNo.EditingMode = False
        Me.lblPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
        Me.CCustomDateTimePicker1.DisplayOnly = False
        Me.CCustomDateTimePicker1.DtpDefaultValue = Nothing
        Me.CCustomDateTimePicker1.EditingMode = True
        Me.CCustomDateTimePicker1.EditsAllowed = False
        Me.CCustomDateTimePicker1.ForeColor = System.Drawing.Color.Black
        Me.CCustomDateTimePicker1.LinkedLabel = Nothing
        Me.CCustomDateTimePicker1.Location = New System.Drawing.Point(428, 1)
        Me.CCustomDateTimePicker1.Margin = New System.Windows.Forms.Padding(1)
        Me.CCustomDateTimePicker1.Name = "CCustomDateTimePicker1"
        Me.CCustomDateTimePicker1.ReadOnlyDp = False
        Me.CCustomDateTimePicker1.SecurityKey = Nothing
        Me.CCustomDateTimePicker1.ShowLongDate = False
        Me.CCustomDateTimePicker1.ShowTime = False
        Me.CCustomDateTimePicker1.Size = New System.Drawing.Size(107, 23)
        Me.CCustomDateTimePicker1.TabIndex = 3
        Me.CCustomDateTimePicker1.TargetCalendar = CType(resources.GetObject("CCustomDateTimePicker1.TargetCalendar"), System.Globalization.Calendar)
        Me.CCustomDateTimePicker1.Value = Nothing
        Me.CCustomDateTimePicker1.ValueIsMandatory = False
        Me.CCustomDateTimePicker1.ValueIsNullable = False
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = True
        Me.CLabel1.DisplayOnly = True
        Me.CLabel1.EditingMode = False
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
        Me.CLabel2.AutoSize = True
        Me.CLabel2.DisplayOnly = True
        Me.CLabel2.EditingMode = False
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
        Me.CLabel3.AutoSize = True
        Me.CLabel3.DisplayOnly = True
        Me.CLabel3.EditingMode = False
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
        Me.cboPayType.ChangingSearchValueOnly = False
        Me.cboPayType.CurrentSearchTerm = ""
        Me.cboPayType.DefaultValue = Nothing
        Me.cboPayType.DisplayMember = "Name"
        Me.cboPayType.DropDownHeight = 200
        Me.cboPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayType.EditingMode = True
        Me.cboPayType.FilterRule = Nothing
        Me.cboPayType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboPayType.ForeColor = System.Drawing.Color.Black
        Me.cboPayType.FormattingEnabled = True
        Me.cboPayType.HideWhenNotEditingOrAdding = False
        Me.cboPayType.LinkedLabel = Nothing
        Me.cboPayType.Location = New System.Drawing.Point(112, 26)
        Me.cboPayType.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPayType.Name = "cboPayType"
        Me.cboPayType.OldValue = 0
        Me.cboPayType.OriginalDataSource = Nothing
        Me.cboPayType.OriginalList = Nothing
        Me.cboPayType.OverrideDropDownStyleList = False
        Me.cboPayType.PreviousSearchTerm = Nothing
        Me.cboPayType.PreviousSelectedIndex = -1
        Me.cboPayType.PropertySelector = Nothing
        Me.cboPayType.ReadOnlyCombo = False
        Me.cboPayType.SearchAnywhere = False
        Me.cboPayType.Size = New System.Drawing.Size(121, 24)
        Me.cboPayType.SuggestBoxHeight = 200
        Me.cboPayType.SuggestListOrderRule = Nothing
        Me.cboPayType.TabIndex = 10
        Me.cboPayType.TextToSearch = Nothing
        Me.cboPayType.ValueIsMandatory = False
        Me.cboPayType.ValueIsNullable = False
        Me.cboPayType.ValueIsNumeric = False
        Me.cboPayType.ValueMember = "IdNo"
        '
        'CDataGridView1
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FloralWhite
        Me.CDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.CDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.CDataGridView1, 2)
        Me.CDataGridView1.DataInGridChanged = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CDataGridView1.DefaultCellStyle = DataGridViewCellStyle4
        Me.CDataGridView1.DgvFooter = Nothing
        Me.CDataGridView1.DisplayOnly = False
        Me.CDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CDataGridView1.Ea = Nothing
        Me.CDataGridView1.EditingMode = False
        Me.CDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.CDataGridView1.FirstRowDeletionEnabled = True
        Me.CDataGridView1.FirstRowInsertionEnabled = True
        Me.CDataGridView1.Location = New System.Drawing.Point(3, 305)
        Me.CDataGridView1.Name = "CDataGridView1"
        Me.CDataGridView1.ReadOnly = True
        Me.CDataGridView1.SequenceColumn = "dgvSequence"
        Me.CDataGridView1.SequenceFieldName = "Sequence"
        Me.CDataGridView1.ShowFooter = False
        Me.CDataGridView1.ShowInsertColumnWhenEditing = True
        Me.CDataGridView1.Size = New System.Drawing.Size(278, 146)
        Me.CDataGridView1.StartTrackingChanges = False
        Me.CDataGridView1.TabIndex = 23
        '
        'CDataGridView2
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FloralWhite
        Me.CDataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.CDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.CDataGridView2, 2)
        Me.CDataGridView2.DataInGridChanged = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CDataGridView2.DefaultCellStyle = DataGridViewCellStyle6
        Me.CDataGridView2.DgvFooter = Nothing
        Me.CDataGridView2.DisplayOnly = False
        Me.CDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CDataGridView2.Ea = Nothing
        Me.CDataGridView2.EditingMode = False
        Me.CDataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.CDataGridView2.FirstRowDeletionEnabled = True
        Me.CDataGridView2.FirstRowInsertionEnabled = True
        Me.CDataGridView2.Location = New System.Drawing.Point(287, 305)
        Me.CDataGridView2.Name = "CDataGridView2"
        Me.CDataGridView2.ReadOnly = True
        Me.CDataGridView2.SequenceColumn = "dgvSequence"
        Me.CDataGridView2.SequenceFieldName = "Sequence"
        Me.CDataGridView2.ShowFooter = False
        Me.CDataGridView2.ShowInsertColumnWhenEditing = True
        Me.CDataGridView2.Size = New System.Drawing.Size(281, 146)
        Me.CDataGridView2.StartTrackingChanges = False
        Me.CDataGridView2.TabIndex = 24
        '
        'CDataGridView4
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FloralWhite
        Me.CDataGridView4.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.CDataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.CDataGridView4, 2)
        Me.CDataGridView4.DataInGridChanged = False
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CDataGridView4.DefaultCellStyle = DataGridViewCellStyle8
        Me.CDataGridView4.DgvFooter = Nothing
        Me.CDataGridView4.DisplayOnly = False
        Me.CDataGridView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CDataGridView4.Ea = Nothing
        Me.CDataGridView4.EditingMode = False
        Me.CDataGridView4.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.CDataGridView4.FirstRowDeletionEnabled = True
        Me.CDataGridView4.FirstRowInsertionEnabled = True
        Me.CDataGridView4.Location = New System.Drawing.Point(287, 133)
        Me.CDataGridView4.Name = "CDataGridView4"
        Me.CDataGridView4.ReadOnly = True
        Me.CDataGridView4.SequenceColumn = "dgvSequence"
        Me.CDataGridView4.SequenceFieldName = "Sequence"
        Me.CDataGridView4.ShowFooter = False
        Me.CDataGridView4.ShowInsertColumnWhenEditing = True
        Me.CDataGridView4.Size = New System.Drawing.Size(281, 146)
        Me.CDataGridView4.StartTrackingChanges = False
        Me.CDataGridView4.TabIndex = 26
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
        Me.CTextBox1.Location = New System.Drawing.Point(285, 485)
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
        Me.CLabel10.AutoSize = True
        Me.CLabel10.DisplayOnly = True
        Me.CLabel10.EditingMode = False
        Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel10.Location = New System.Drawing.Point(112, 485)
        Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel10.Name = "CLabel10"
        Me.CLabel10.Size = New System.Drawing.Size(58, 17)
        Me.CLabel10.TabIndex = 29
        Me.CLabel10.Text = "Net Pay"
        Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PayrollEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(867, 581)
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "PayrollEntry"
        Me.Controls.SetChildIndex(Me.CFlowLayout1, 0)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CFlowLayout1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.CDataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents CTreeView1 As Libraries.CBaseControlsLibrary.CTreeView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents CLabel6 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.CaComboBox
    Friend WithEvents CLabel4 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
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
    Friend WithEvents CDataGridView3 As Libraries.CBaseControlsLibrary.CDataGridView
    Friend WithEvents CLabel8 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents CLabel7 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents CDataGridView1 As Libraries.CBaseControlsLibrary.CDataGridView
    Friend WithEvents CDataGridView2 As Libraries.CBaseControlsLibrary.CDataGridView
    Friend WithEvents CDataGridView4 As Libraries.CBaseControlsLibrary.CDataGridView
    Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents CTextBox3 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents CLabel11 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents CTextBox2 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents CLabel10 As Libraries.CBaseControlsLibrary.CLabel
End Class
