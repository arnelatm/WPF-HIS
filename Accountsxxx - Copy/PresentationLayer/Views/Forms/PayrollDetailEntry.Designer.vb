Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayrollDetailEntry
        Inherits AATM.PresentationLayer.Forms.CFormEntryTv

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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayrollDetailEntry))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.tbcPayroll = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
        Me.tpgEarnings = New System.Windows.Forms.TabPage()
        Me.DataGridViewEarnings = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.bsEarnings = New System.Windows.Forms.BindingSource(Me.components)
        Me.tpgDeductions = New System.Windows.Forms.TabPage()
        Me.DataGridViewDeductions = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.bsDeductions = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblStartDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblPayDescription = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayPeriodDescription = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel9 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtTotalEarnings = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.txtTotalDeductions = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.txtNetPay = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.lblBankTransfer = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkBankTransfer = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.dgvEarningGenerated = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvEarningIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvEarningAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        Me.dgvDeductionGenerated = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
        Me.dgvDeductionIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
        Me.dgvDeductionAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.tbcPayroll.SuspendLayout
        Me.tpgEarnings.SuspendLayout
        CType(Me.DataGridViewEarnings,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsEarnings,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tpgDeductions.SuspendLayout
        CType(Me.DataGridViewDeductions,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsDeductions,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.CFlowLayout1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1036, 528)
        Me.SplitContainer1.SplitterDistance = 351
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.Size = New System.Drawing.Size(351, 528)
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
        Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.TableLayoutPanel1)
        Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CFlowLayout1.Location = New System.Drawing.Point(0, 0)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(675, 528)
        Me.CFlowLayout1.TabIndex = 4
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
        Me.TableLayoutPanel1.Controls.Add(Me.txtEmployeeCode, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.tbcPayroll, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayrollIdNo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStartDate, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpStartDate, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEndDate, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayDescription, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayPeriodDescription, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEmployeeName, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel9, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTotalEarnings, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 4, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTotalDeductions, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNetPay, 5, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayrollIdNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.cboEmployeeIdNo, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBankTransfer, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.chkBankTransfer, 5, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(666, 513)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtIdNo
        '
        Me.txtIdNo.BackColor = System.Drawing.Color.White
        Me.txtIdNo.BegFindValue = Nothing
        Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdNo.ComputedValue = false
        Me.txtIdNo.CustomFormat = Nothing
        Me.txtIdNo.DataBoundControl = true
        Me.txtIdNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdNo.EditingMode = true
        Me.txtIdNo.EndFindValue = Nothing
        Me.txtIdNo.FieldDescription = Nothing
        Me.txtIdNo.FieldName = Nothing
        Me.txtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtIdNo.FindEnabled = true
        Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtIdNo.LinkedLabel = Nothing
        Me.txtIdNo.Location = New System.Drawing.Point(114, 456)
        Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIdNo.MaximumValue = Nothing
        Me.txtIdNo.MinimumValue = Nothing
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.OldValue = Nothing
        Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtIdNo.Size = New System.Drawing.Size(122, 23)
        Me.txtIdNo.TabIndex = 43
        Me.txtIdNo.Translatable = false
        Me.txtIdNo.Visible = false
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.BackColor = System.Drawing.Color.White
        Me.txtEmployeeCode.BegFindValue = Nothing
        Me.txtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeCode.ComputedValue = false
        Me.txtEmployeeCode.CustomFormat = Nothing
        Me.txtEmployeeCode.DataBoundControl = true
        Me.txtEmployeeCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmployeeCode.EditingMode = true
        Me.txtEmployeeCode.EndFindValue = Nothing
        Me.txtEmployeeCode.FieldDescription = Nothing
        Me.txtEmployeeCode.FieldName = Nothing
        Me.txtEmployeeCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtEmployeeCode.FindEnabled = true
        Me.txtEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtEmployeeCode.ForeColor = System.Drawing.Color.Black
        Me.txtEmployeeCode.LinkedLabel = Nothing
        Me.txtEmployeeCode.Location = New System.Drawing.Point(1, 456)
        Me.txtEmployeeCode.Margin = New System.Windows.Forms.Padding(1)
        Me.txtEmployeeCode.MaximumValue = Nothing
        Me.txtEmployeeCode.MinimumValue = Nothing
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.OldValue = Nothing
        Me.txtEmployeeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtEmployeeCode.Size = New System.Drawing.Size(111, 23)
        Me.txtEmployeeCode.TabIndex = 40
        Me.txtEmployeeCode.Translatable = false
        Me.txtEmployeeCode.Visible = false
        '
        'tbcPayroll
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.tbcPayroll, 6)
        Me.tbcPayroll.Controls.Add(Me.tpgEarnings)
        Me.tbcPayroll.Controls.Add(Me.tpgDeductions)
        Me.tbcPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcPayroll.Location = New System.Drawing.Point(3, 79)
        Me.tbcPayroll.Name = "tbcPayroll"
        Me.tbcPayroll.SelectedIndex = 0
        Me.tbcPayroll.Size = New System.Drawing.Size(647, 348)
        Me.tbcPayroll.TabIndex = 34
        '
        'tpgEarnings
        '
        Me.tpgEarnings.Controls.Add(Me.DataGridViewEarnings)
        Me.tpgEarnings.Location = New System.Drawing.Point(4, 22)
        Me.tpgEarnings.Name = "tpgEarnings"
        Me.tpgEarnings.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgEarnings.Size = New System.Drawing.Size(639, 322)
        Me.tpgEarnings.TabIndex = 0
        Me.tpgEarnings.Text = "Earnings"
        Me.tpgEarnings.UseVisualStyleBackColor = true
        '
        'DataGridViewEarnings
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewEarnings.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewEarnings.AutoGenerateColumns = false
        Me.DataGridViewEarnings.BegFindValue = Nothing
        Me.DataGridViewEarnings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewEarnings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvEarningGenerated, Me.dgvEarningIdNo, Me.dgvEarningAmount})
        Me.DataGridViewEarnings.DataSource = Me.bsEarnings
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewEarnings.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewEarnings.DgvFooter = Nothing
        Me.DataGridViewEarnings.DisplayOnly = false
        Me.DataGridViewEarnings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewEarnings.Ea = Nothing
        Me.DataGridViewEarnings.EditingMode = false
        Me.DataGridViewEarnings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewEarnings.EndFindValue = Nothing
        Me.DataGridViewEarnings.FieldDescription = Nothing
        Me.DataGridViewEarnings.FieldName = Nothing
        Me.DataGridViewEarnings.FieldsDictionary = Nothing
        Me.DataGridViewEarnings.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewEarnings.FindEnabled = false
        Me.DataGridViewEarnings.FirstRowDeletionEnabled = true
        Me.DataGridViewEarnings.FirstRowInsertionEnabled = true
        Me.DataGridViewEarnings.IgnoreCase = false
        Me.DataGridViewEarnings.IsDirty = false
        Me.DataGridViewEarnings.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewEarnings.Name = "DataGridViewEarnings"
        Me.DataGridViewEarnings.ReadOnly = true
        Me.DataGridViewEarnings.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewEarnings.SecurityKey = ""
        Me.DataGridViewEarnings.SequenceColumn = "dgvSequence"
        Me.DataGridViewEarnings.SequenceFieldName = "Sequence"
        Me.DataGridViewEarnings.ShowFooter = false
        Me.DataGridViewEarnings.ShowInsertColumnWhenEditing = true
        Me.DataGridViewEarnings.Size = New System.Drawing.Size(633, 316)
        Me.DataGridViewEarnings.TabIndex = 0
        Me.DataGridViewEarnings.Translatable = true
        '
        'bsEarnings
        '
        Me.bsEarnings.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayrollPayElementModel)
        '
        'tpgDeductions
        '
        Me.tpgDeductions.Controls.Add(Me.DataGridViewDeductions)
        Me.tpgDeductions.Location = New System.Drawing.Point(4, 22)
        Me.tpgDeductions.Name = "tpgDeductions"
        Me.tpgDeductions.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgDeductions.Size = New System.Drawing.Size(639, 322)
        Me.tpgDeductions.TabIndex = 2
        Me.tpgDeductions.Text = "Deductions"
        Me.tpgDeductions.UseVisualStyleBackColor = true
        '
        'DataGridViewDeductions
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewDeductions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewDeductions.AutoGenerateColumns = false
        Me.DataGridViewDeductions.BegFindValue = Nothing
        Me.DataGridViewDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDeductions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvDeductionGenerated, Me.dgvDeductionIdNo, Me.dgvDeductionAmount})
        Me.DataGridViewDeductions.DataSource = Me.bsDeductions
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDeductions.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewDeductions.DgvFooter = Nothing
        Me.DataGridViewDeductions.DisplayOnly = false
        Me.DataGridViewDeductions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewDeductions.Ea = Nothing
        Me.DataGridViewDeductions.EditingMode = false
        Me.DataGridViewDeductions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewDeductions.EndFindValue = Nothing
        Me.DataGridViewDeductions.FieldDescription = Nothing
        Me.DataGridViewDeductions.FieldName = Nothing
        Me.DataGridViewDeductions.FieldsDictionary = Nothing
        Me.DataGridViewDeductions.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewDeductions.FindEnabled = false
        Me.DataGridViewDeductions.FirstRowDeletionEnabled = true
        Me.DataGridViewDeductions.FirstRowInsertionEnabled = true
        Me.DataGridViewDeductions.IgnoreCase = false
        Me.DataGridViewDeductions.IsDirty = false
        Me.DataGridViewDeductions.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewDeductions.Name = "DataGridViewDeductions"
        Me.DataGridViewDeductions.ReadOnly = true
        Me.DataGridViewDeductions.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewDeductions.SecurityKey = ""
        Me.DataGridViewDeductions.SequenceColumn = "dgvSequence"
        Me.DataGridViewDeductions.SequenceFieldName = "Sequence"
        Me.DataGridViewDeductions.ShowFooter = false
        Me.DataGridViewDeductions.ShowInsertColumnWhenEditing = true
        Me.DataGridViewDeductions.Size = New System.Drawing.Size(633, 316)
        Me.DataGridViewDeductions.TabIndex = 0
        Me.DataGridViewDeductions.Translatable = true
        '
        'bsDeductions
        '
        Me.bsDeductions.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayrollPayElementModel)
        '
        'txtPayrollIdNo
        '
        Me.txtPayrollIdNo.BackColor = System.Drawing.Color.White
        Me.txtPayrollIdNo.BegFindValue = Nothing
        Me.txtPayrollIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayrollIdNo.ComputedValue = false
        Me.txtPayrollIdNo.CustomFormat = Nothing
        Me.txtPayrollIdNo.DataBoundControl = true
        Me.txtPayrollIdNo.DisplayOnly = true
        Me.txtPayrollIdNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayrollIdNo.EditingMode = true
        Me.txtPayrollIdNo.EndFindValue = Nothing
        Me.txtPayrollIdNo.FieldDescription = Nothing
        Me.txtPayrollIdNo.FieldName = Nothing
        Me.txtPayrollIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayrollIdNo.FindEnabled = false
        Me.txtPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayrollIdNo.ForeColor = System.Drawing.Color.Black
        Me.txtPayrollIdNo.LinkedLabel = Me.lblPayrollIdNo
        Me.txtPayrollIdNo.Location = New System.Drawing.Point(114, 1)
        Me.txtPayrollIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayrollIdNo.MaximumValue = Nothing
        Me.txtPayrollIdNo.MinimumValue = Nothing
        Me.txtPayrollIdNo.Name = "txtPayrollIdNo"
        Me.txtPayrollIdNo.OldValue = Nothing
        Me.txtPayrollIdNo.ReadOnly = true
        Me.txtPayrollIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayrollIdNo.Size = New System.Drawing.Size(122, 23)
        Me.txtPayrollIdNo.TabIndex = 0
        Me.txtPayrollIdNo.TabStop = false
        Me.txtPayrollIdNo.Translatable = false
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
        Me.lblPayrollIdNo.Size = New System.Drawing.Size(105, 17)
        Me.lblPayrollIdNo.TabIndex = 4
        Me.lblPayrollIdNo.Text = "Payroll Number"
        Me.lblPayrollIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPayrollIdNo.Translatable = true
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = true
        Me.lblStartDate.DisplayOnly = true
        Me.lblStartDate.EditingMode = false
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblStartDate.Location = New System.Drawing.Point(238, 1)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(72, 17)
        Me.lblStartDate.TabIndex = 6
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStartDate.Translatable = true
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpStartDate.DefaultValue = Nothing
        Me.dtpStartDate.DisplayOnly = true
        Me.dtpStartDate.DtpDefaultValue = Nothing
        Me.dtpStartDate.EditingMode = true
        Me.dtpStartDate.EditsAllowed = false
        Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
        Me.dtpStartDate.LinkedLabel = Me.lblStartDate
        Me.dtpStartDate.Location = New System.Drawing.Point(312, 1)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ReadOnlyDp = false
        Me.dtpStartDate.SecurityKey = Nothing
        Me.dtpStartDate.ShowLongDate = false
        Me.dtpStartDate.ShowTime = false
        Me.dtpStartDate.Size = New System.Drawing.Size(115, 23)
        Me.dtpStartDate.TabIndex = 1
        Me.dtpStartDate.TabStop = false
        Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpStartDate.Translatable = false
        Me.dtpStartDate.Value = Nothing
        Me.dtpStartDate.ValueIsMandatory = false
        Me.dtpStartDate.ValueIsNullable = false
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = true
        Me.lblEndDate.DisplayOnly = true
        Me.lblEndDate.EditingMode = false
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEndDate.Location = New System.Drawing.Point(429, 1)
        Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(67, 17)
        Me.lblEndDate.TabIndex = 7
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEndDate.Translatable = true
        '
        'lblPayDescription
        '
        Me.lblPayDescription.AutoSize = true
        Me.lblPayDescription.DisplayOnly = true
        Me.lblPayDescription.EditingMode = false
        Me.lblPayDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblPayDescription.Location = New System.Drawing.Point(1, 26)
        Me.lblPayDescription.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPayDescription.Name = "lblPayDescription"
        Me.lblPayDescription.Size = New System.Drawing.Size(107, 17)
        Me.lblPayDescription.TabIndex = 8
        Me.lblPayDescription.Text = "Pay Description"
        Me.lblPayDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPayDescription.Translatable = true
        '
        'txtPayPeriodDescription
        '
        Me.txtPayPeriodDescription.BackColor = System.Drawing.Color.White
        Me.txtPayPeriodDescription.BegFindValue = Nothing
        Me.txtPayPeriodDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayPeriodDescription, 5)
        Me.txtPayPeriodDescription.ComputedValue = false
        Me.txtPayPeriodDescription.CustomFormat = Nothing
        Me.txtPayPeriodDescription.DataBoundControl = true
        Me.txtPayPeriodDescription.DisplayOnly = true
        Me.txtPayPeriodDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPayPeriodDescription.EditingMode = true
        Me.txtPayPeriodDescription.EndFindValue = Nothing
        Me.txtPayPeriodDescription.FieldDescription = Nothing
        Me.txtPayPeriodDescription.FieldName = Nothing
        Me.txtPayPeriodDescription.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPayPeriodDescription.FindEnabled = false
        Me.txtPayPeriodDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtPayPeriodDescription.ForeColor = System.Drawing.Color.Black
        Me.txtPayPeriodDescription.LinkedLabel = Me.lblPayDescription
        Me.txtPayPeriodDescription.Location = New System.Drawing.Point(114, 26)
        Me.txtPayPeriodDescription.Margin = New System.Windows.Forms.Padding(1)
        Me.txtPayPeriodDescription.MaximumValue = Nothing
        Me.txtPayPeriodDescription.MinimumValue = Nothing
        Me.txtPayPeriodDescription.Name = "txtPayPeriodDescription"
        Me.txtPayPeriodDescription.OldValue = Nothing
        Me.txtPayPeriodDescription.ReadOnly = true
        Me.txtPayPeriodDescription.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPayPeriodDescription.Size = New System.Drawing.Size(538, 23)
        Me.txtPayPeriodDescription.TabIndex = 3
        Me.txtPayPeriodDescription.TabStop = false
        Me.txtPayPeriodDescription.Translatable = false
        Me.txtPayPeriodDescription.ValueIsMandatory = true
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.AutoSize = true
        Me.lblEmployeeName.DisplayOnly = true
        Me.lblEmployeeName.EditingMode = false
        Me.lblEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblEmployeeName.Location = New System.Drawing.Point(1, 51)
        Me.lblEmployeeName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Size = New System.Drawing.Size(111, 17)
        Me.lblEmployeeName.TabIndex = 11
        Me.lblEmployeeName.Text = "Employee Name"
        Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEmployeeName.Translatable = true
        '
        'CLabel9
        '
        Me.CLabel9.AutoSize = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel9, 2)
        Me.CLabel9.DisplayOnly = true
        Me.CLabel9.Dock = System.Windows.Forms.DockStyle.Right
        Me.CLabel9.EditingMode = false
        Me.CLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel9.Location = New System.Drawing.Point(435, 431)
        Me.CLabel9.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel9.Name = "CLabel9"
        Me.CLabel9.Size = New System.Drawing.Size(100, 23)
        Me.CLabel9.TabIndex = 27
        Me.CLabel9.Text = "Total Earnings"
        Me.CLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel9.Translatable = true
        '
        'txtTotalEarnings
        '
        Me.txtTotalEarnings.BackColor = System.Drawing.Color.White
        Me.txtTotalEarnings.BegFindValue = Nothing
        Me.txtTotalEarnings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalEarnings.ComputedValue = false
        Me.txtTotalEarnings.CustomFormat = "N2"
        Me.txtTotalEarnings.DataBoundControl = true
        Me.txtTotalEarnings.DisplayOnly = true
        Me.txtTotalEarnings.EditingMode = true
        Me.txtTotalEarnings.EndFindValue = Nothing
        Me.txtTotalEarnings.FieldDescription = Nothing
        Me.txtTotalEarnings.FieldName = Nothing
        Me.txtTotalEarnings.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalEarnings.FindEnabled = false
        Me.txtTotalEarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtTotalEarnings.ForeColor = System.Drawing.Color.Black
        Me.txtTotalEarnings.LinkedLabel = Nothing
        Me.txtTotalEarnings.Location = New System.Drawing.Point(537, 431)
        Me.txtTotalEarnings.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTotalEarnings.MaximumValue = Nothing
        Me.txtTotalEarnings.MinimumValue = Nothing
        Me.txtTotalEarnings.Name = "txtTotalEarnings"
        Me.txtTotalEarnings.OldValue = Nothing
        Me.txtTotalEarnings.ReadOnly = true
        Me.txtTotalEarnings.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalEarnings.Size = New System.Drawing.Size(115, 23)
        Me.txtTotalEarnings.TabIndex = 6
        Me.txtTotalEarnings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalEarnings.Translatable = false
        Me.txtTotalEarnings.ValueIsNumeric = true
        '
        'CLabel10
        '
        Me.CLabel10.AutoSize = true
        Me.CLabel10.DisplayOnly = true
        Me.CLabel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel10.EditingMode = false
        Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel10.Location = New System.Drawing.Point(429, 481)
        Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel10.Name = "CLabel10"
        Me.CLabel10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CLabel10.Size = New System.Drawing.Size(106, 31)
        Me.CLabel10.TabIndex = 29
        Me.CLabel10.Text = "Net Pay"
        Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CLabel10.Translatable = true
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
        Me.dtpEndDate.DefaultValue = Nothing
        Me.dtpEndDate.DisplayOnly = true
        Me.dtpEndDate.DtpDefaultValue = Nothing
        Me.dtpEndDate.EditingMode = true
        Me.dtpEndDate.EditsAllowed = false
        Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
        Me.dtpEndDate.LinkedLabel = Me.lblEndDate
        Me.dtpEndDate.Location = New System.Drawing.Point(537, 1)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ReadOnlyDp = false
        Me.dtpEndDate.SecurityKey = Nothing
        Me.dtpEndDate.ShowLongDate = false
        Me.dtpEndDate.ShowTime = false
        Me.dtpEndDate.Size = New System.Drawing.Size(115, 23)
        Me.dtpEndDate.TabIndex = 2
        Me.dtpEndDate.TabStop = false
        Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"),System.Globalization.Calendar)
        Me.dtpEndDate.Translatable = false
        Me.dtpEndDate.Value = Nothing
        Me.dtpEndDate.ValueIsMandatory = false
        Me.dtpEndDate.ValueIsNullable = false
        '
        'txtTotalDeductions
        '
        Me.txtTotalDeductions.BackColor = System.Drawing.Color.White
        Me.txtTotalDeductions.BegFindValue = Nothing
        Me.txtTotalDeductions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDeductions.ComputedValue = false
        Me.txtTotalDeductions.CustomFormat = "N2"
        Me.txtTotalDeductions.DataBoundControl = true
        Me.txtTotalDeductions.DisplayOnly = true
        Me.txtTotalDeductions.EditingMode = true
        Me.txtTotalDeductions.EndFindValue = Nothing
        Me.txtTotalDeductions.FieldDescription = Nothing
        Me.txtTotalDeductions.FieldName = Nothing
        Me.txtTotalDeductions.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtTotalDeductions.FindEnabled = false
        Me.txtTotalDeductions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtTotalDeductions.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDeductions.LinkedLabel = Nothing
        Me.txtTotalDeductions.Location = New System.Drawing.Point(537, 456)
        Me.txtTotalDeductions.Margin = New System.Windows.Forms.Padding(1)
        Me.txtTotalDeductions.MaximumValue = Nothing
        Me.txtTotalDeductions.MinimumValue = Nothing
        Me.txtTotalDeductions.Name = "txtTotalDeductions"
        Me.txtTotalDeductions.OldValue = Nothing
        Me.txtTotalDeductions.ReadOnly = true
        Me.txtTotalDeductions.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtTotalDeductions.Size = New System.Drawing.Size(115, 23)
        Me.txtTotalDeductions.TabIndex = 7
        Me.txtTotalDeductions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDeductions.Translatable = false
        Me.txtTotalDeductions.ValueIsNumeric = true
        '
        'txtNetPay
        '
        Me.txtNetPay.BackColor = System.Drawing.Color.White
        Me.txtNetPay.BegFindValue = Nothing
        Me.txtNetPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNetPay.ComputedValue = false
        Me.txtNetPay.CustomFormat = "N2"
        Me.txtNetPay.DataBoundControl = true
        Me.txtNetPay.DisplayOnly = true
        Me.txtNetPay.EditingMode = true
        Me.txtNetPay.EndFindValue = Nothing
        Me.txtNetPay.FieldDescription = Nothing
        Me.txtNetPay.FieldName = Nothing
        Me.txtNetPay.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNetPay.FindEnabled = false
        Me.txtNetPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNetPay.ForeColor = System.Drawing.Color.Black
        Me.txtNetPay.LinkedLabel = Nothing
        Me.txtNetPay.Location = New System.Drawing.Point(537, 481)
        Me.txtNetPay.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNetPay.MaximumValue = Nothing
        Me.txtNetPay.MinimumValue = Nothing
        Me.txtNetPay.Name = "txtNetPay"
        Me.txtNetPay.OldValue = Nothing
        Me.txtNetPay.ReadOnly = true
        Me.txtNetPay.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNetPay.Size = New System.Drawing.Size(115, 23)
        Me.txtNetPay.TabIndex = 8
        Me.txtNetPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNetPay.Translatable = false
        Me.txtNetPay.ValueIsNumeric = true
        '
        'CLabel11
        '
        Me.CLabel11.AutoSize = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel11, 2)
        Me.CLabel11.DisplayOnly = true
        Me.CLabel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel11.EditingMode = false
        Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel11.Location = New System.Drawing.Point(312, 456)
        Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel11.Name = "CLabel11"
        Me.CLabel11.Size = New System.Drawing.Size(223, 23)
        Me.CLabel11.TabIndex = 32
        Me.CLabel11.Text = "Total Deductions"
        Me.CLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CLabel11.Translatable = true
        '
        'cboEmployeeIdNo
        '
        Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
        Me.cboEmployeeIdNo.BegFindValue = Nothing
        Me.cboEmployeeIdNo.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboEmployeeIdNo, 3)
        Me.cboEmployeeIdNo.CurrentSearchTerm = ""
        Me.cboEmployeeIdNo.DataValue = Nothing
        Me.cboEmployeeIdNo.DefaultValue = Nothing
        Me.cboEmployeeIdNo.DisplayMember = "Name"
        Me.cboEmployeeIdNo.DisplayOnly = true
        Me.cboEmployeeIdNo.DropDownHeight = 21
        Me.cboEmployeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboEmployeeIdNo.EditingMode = true
        Me.cboEmployeeIdNo.EndFindValue = Nothing
        Me.cboEmployeeIdNo.FieldDescription = Nothing
        Me.cboEmployeeIdNo.FieldName = Nothing
        Me.cboEmployeeIdNo.FilterRule = Nothing
        Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboEmployeeIdNo.FindEnabled = false
        Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboEmployeeIdNo.FormattingEnabled = true
        Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = false
        Me.cboEmployeeIdNo.IgnoreCase = false
        Me.cboEmployeeIdNo.IntegralHeight = false
        Me.cboEmployeeIdNo.LinkedLabel = Nothing
        Me.cboEmployeeIdNo.Location = New System.Drawing.Point(114, 51)
        Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.cboEmployeeIdNo.MaxDropDownItems = 1
        Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
        Me.cboEmployeeIdNo.OldValue = 0
        Me.cboEmployeeIdNo.OriginalDataSource = Nothing
        Me.cboEmployeeIdNo.OriginalList = Nothing
        Me.cboEmployeeIdNo.OverrideDropDownStyleList = false
        Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
        Me.cboEmployeeIdNo.PropertySelector = Nothing
        Me.cboEmployeeIdNo.ReadOnlyCombo = true
        Me.cboEmployeeIdNo.Size = New System.Drawing.Size(313, 24)
        Me.cboEmployeeIdNo.SuggestBoxHeight = 200
        Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
        Me.cboEmployeeIdNo.TabIndex = 4
        Me.cboEmployeeIdNo.TabStop = false
        Me.cboEmployeeIdNo.TextToSearch = Nothing
        Me.cboEmployeeIdNo.Translatable = false
        Me.cboEmployeeIdNo.ValueIsMandatory = false
        Me.cboEmployeeIdNo.ValueIsNullable = false
        Me.cboEmployeeIdNo.ValueIsNumeric = false
        Me.cboEmployeeIdNo.ValueMember = "IdNo"
        '
        'lblBankTransfer
        '
        Me.lblBankTransfer.AutoSize = true
        Me.lblBankTransfer.DisplayOnly = true
        Me.lblBankTransfer.EditingMode = false
        Me.lblBankTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblBankTransfer.Location = New System.Drawing.Point(429, 51)
        Me.lblBankTransfer.Margin = New System.Windows.Forms.Padding(1)
        Me.lblBankTransfer.Name = "lblBankTransfer"
        Me.lblBankTransfer.Size = New System.Drawing.Size(106, 17)
        Me.lblBankTransfer.TabIndex = 44
        Me.lblBankTransfer.Text = "Bank Transfer?"
        Me.lblBankTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBankTransfer.Translatable = true
        '
        'chkBankTransfer
        '
        Me.chkBankTransfer.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkBankTransfer.AutoCheck = false
        Me.chkBankTransfer.BackColor = System.Drawing.Color.White
        Me.chkBankTransfer.BegFindValue = Nothing
        Me.chkBankTransfer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBankTransfer.DisplayOnly = false
        Me.chkBankTransfer.EditingMode = false
        Me.chkBankTransfer.EndFindValue = Nothing
        Me.chkBankTransfer.FieldDescription = Nothing
        Me.chkBankTransfer.FieldName = Nothing
        Me.chkBankTransfer.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkBankTransfer.FindEnabled = true
        Me.chkBankTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBankTransfer.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.chkBankTransfer.ForeColor = System.Drawing.Color.Black
        Me.chkBankTransfer.IFindableControl_FindEnabled = false
        Me.chkBankTransfer.IgnoreCase = false
        Me.chkBankTransfer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkBankTransfer.LinkedLabel = Nothing
        Me.chkBankTransfer.Location = New System.Drawing.Point(537, 51)
        Me.chkBankTransfer.Margin = New System.Windows.Forms.Padding(1)
        Me.chkBankTransfer.Name = "chkBankTransfer"
        Me.chkBankTransfer.NoLabel = false
        Me.chkBankTransfer.OldValue = ""
        Me.chkBankTransfer.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkBankTransfer.Size = New System.Drawing.Size(13, 13)
        Me.chkBankTransfer.TabIndex = 5
        Me.chkBankTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBankTransfer.Translatable = false
        Me.chkBankTransfer.UseVisualStyleBackColor = false
        '
        'dgvEarningGenerated
        '
        Me.dgvEarningGenerated.BegFindValue = Nothing
        Me.dgvEarningGenerated.DataPropertyName = "Generated"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Orange
        DataGridViewCellStyle2.NullValue = false
        Me.dgvEarningGenerated.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEarningGenerated.EditingMode = false
        Me.dgvEarningGenerated.EndFindValue = Nothing
        Me.dgvEarningGenerated.FieldDescription = Nothing
        Me.dgvEarningGenerated.FieldName = Nothing
        Me.dgvEarningGenerated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvEarningGenerated.FindEnabled = false
        Me.dgvEarningGenerated.HeaderText = "Generated"
        Me.dgvEarningGenerated.IgnoreCase = false
        Me.dgvEarningGenerated.Name = "dgvEarningGenerated"
        Me.dgvEarningGenerated.ReadOnly = true
        Me.dgvEarningGenerated.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEarningGenerated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvEarningGenerated.Translatable = false
        Me.dgvEarningGenerated.Width = 60
        '
        'dgvEarningIdNo
        '
        Me.dgvEarningIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvEarningIdNo.DataPropertyName = "PayElementIdNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvEarningIdNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEarningIdNo.EditingMode = false
        Me.dgvEarningIdNo.HeaderText = "Earning Name - Code"
        Me.dgvEarningIdNo.Name = "dgvEarningIdNo"
        Me.dgvEarningIdNo.ReadOnly = true
        Me.dgvEarningIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEarningIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvEarningIdNo.Translatable = false
        '
        'dgvEarningAmount
        '
        Me.dgvEarningAmount.BegFindValue = Nothing
        Me.dgvEarningAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Format = "###,##0.00"
        Me.dgvEarningAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEarningAmount.EditingMode = false
        Me.dgvEarningAmount.EndFindValue = Nothing
        Me.dgvEarningAmount.FieldDescription = Nothing
        Me.dgvEarningAmount.FieldName = Nothing
        Me.dgvEarningAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvEarningAmount.FindEnabled = false
        Me.dgvEarningAmount.HeaderText = "Amount"
        Me.dgvEarningAmount.Name = "dgvEarningAmount"
        Me.dgvEarningAmount.ReadOnly = true
        Me.dgvEarningAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEarningAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvEarningAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvEarningAmount.Translatable = false
        '
        'dgvDeductionGenerated
        '
        Me.dgvDeductionGenerated.BegFindValue = Nothing
        Me.dgvDeductionGenerated.DataPropertyName = "Generated"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Orange
        DataGridViewCellStyle7.NullValue = false
        Me.dgvDeductionGenerated.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDeductionGenerated.EditingMode = false
        Me.dgvDeductionGenerated.EndFindValue = Nothing
        Me.dgvDeductionGenerated.FieldDescription = Nothing
        Me.dgvDeductionGenerated.FieldName = Nothing
        Me.dgvDeductionGenerated.FillWeight = 60!
        Me.dgvDeductionGenerated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDeductionGenerated.FindEnabled = false
        Me.dgvDeductionGenerated.HeaderText = "Generated"
        Me.dgvDeductionGenerated.IgnoreCase = false
        Me.dgvDeductionGenerated.Name = "dgvDeductionGenerated"
        Me.dgvDeductionGenerated.ReadOnly = true
        Me.dgvDeductionGenerated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDeductionGenerated.Translatable = false
        Me.dgvDeductionGenerated.Width = 60
        '
        'dgvDeductionIdNo
        '
        Me.dgvDeductionIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvDeductionIdNo.DataPropertyName = "PayElementIdNo"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        Me.dgvDeductionIdNo.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDeductionIdNo.EditingMode = false
        Me.dgvDeductionIdNo.HeaderText = "Deduction Name - Code"
        Me.dgvDeductionIdNo.Name = "dgvDeductionIdNo"
        Me.dgvDeductionIdNo.ReadOnly = true
        Me.dgvDeductionIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDeductionIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDeductionIdNo.Translatable = false
        '
        'dgvDeductionAmount
        '
        Me.dgvDeductionAmount.BegFindValue = Nothing
        Me.dgvDeductionAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.Format = "###,##0.00"
        Me.dgvDeductionAmount.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDeductionAmount.EditingMode = false
        Me.dgvDeductionAmount.EndFindValue = Nothing
        Me.dgvDeductionAmount.FieldDescription = Nothing
        Me.dgvDeductionAmount.FieldName = Nothing
        Me.dgvDeductionAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvDeductionAmount.FindEnabled = false
        Me.dgvDeductionAmount.HeaderText = "Amount"
        Me.dgvDeductionAmount.Name = "dgvDeductionAmount"
        Me.dgvDeductionAmount.ReadOnly = true
        Me.dgvDeductionAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDeductionAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvDeductionAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvDeductionAmount.Translatable = false
        '
        'PayrollDetailEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.ClientSize = New System.Drawing.Size(1036, 581)
        Me.Name = "PayrollDetailEntry"
        Me.Text = " "
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.CFlowLayout1.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.tbcPayroll.ResumeLayout(false)
        Me.tpgEarnings.ResumeLayout(false)
        CType(Me.DataGridViewEarnings,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsEarnings,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpgDeductions.ResumeLayout(false)
        CType(Me.DataGridViewDeductions,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsDeductions,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents lblEmployeeName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPayrollIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpStartDate As CCustomDateTimePicker
        Friend WithEvents lblStartDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblEndDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblPayDescription As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel9 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNetPay As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtTotalEarnings As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel11 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtTotalDeductions As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel10 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents tbcPayroll As Libraries.CBaseControlsLibrary.CTabControl
        Friend WithEvents tpgEarnings As TabPage
        Friend WithEvents tpgDeductions As TabPage
        Friend WithEvents txtPayPeriodDescription As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtPayrollIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents dtpEndDate As CCustomDateTimePicker
        Friend WithEvents txtEmployeeCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents DataGridViewEarnings As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents bsEarnings As BindingSource
        Friend WithEvents bsDeductions As BindingSource
        Friend WithEvents DataGridViewDeductions As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents lblBankTransfer As CLabel
        Friend WithEvents chkBankTransfer As CCheckBox
        Friend WithEvents dgvEarningGenerated As CDgvCheckBoxColumn
        Friend WithEvents dgvEarningIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvEarningAmount As CdgvMoneyColumn
        Friend WithEvents dgvDeductionGenerated As CDgvCheckBoxColumn
        Friend WithEvents dgvDeductionIdNo As CDgvComboBoxColumn
        Friend WithEvents dgvDeductionAmount As CdgvMoneyColumn
    End Class
End Namespace