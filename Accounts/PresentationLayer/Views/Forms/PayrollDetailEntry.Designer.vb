Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayrollDetailEntry
        Inherits AATM.PresentationLayer.Forms.CFormEntryTvNew

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
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayrollDetailEntry))
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.tbcPayroll = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tpgEarnings = New System.Windows.Forms.TabPage()
            Me.DataGridViewEarnings = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvEarningIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvEarningAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.bsEarnings = New System.Windows.Forms.BindingSource(Me.components)
            Me.tpgDeductions = New System.Windows.Forms.TabPage()
            Me.DataGridViewDeductions = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.dgvDeductionIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvDeductionAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.bsDeductions = New System.Windows.Forms.BindingSource(Me.components)
            Me.txtPayrollIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpStartDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.lblEndDate = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPayPeriodDescription = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEmployeeName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel9 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtTotalEarnings = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dtpEndDate = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
            Me.txtTotalDeductions = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtNetPay = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.tbcPayroll.SuspendLayout()
            Me.tpgEarnings.SuspendLayout()
            CType(Me.DataGridViewEarnings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsEarnings, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgDeductions.SuspendLayout()
            CType(Me.DataGridViewDeductions, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsDeductions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpStartDate, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEndDate, 4, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPayPeriodDescription, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEmployeeName, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel9, 3, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.txtTotalEarnings, 5, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel10, 4, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.dtpEndDate, 5, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtTotalDeductions, 5, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.txtNetPay, 5, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel11, 3, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.cboEmployeeIdNo, 1, 2)
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
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(666, 513)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'txtIdNo
            '
            Me.txtIdNo.BackColor = System.Drawing.Color.White
            Me.txtIdNo.BegFindValue = Nothing
            Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdNo.ComputedValue = False
            Me.txtIdNo.CustomFormat = Nothing
            Me.txtIdNo.DataBoundControl = True
            Me.txtIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtIdNo.EditingMode = True
            Me.txtIdNo.EndFindValue = Nothing
            Me.txtIdNo.FieldDescription = Nothing
            Me.txtIdNo.FieldName = Nothing
            Me.txtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtIdNo.FindEnabled = True
            Me.txtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtIdNo.Translatable = False
            Me.txtIdNo.Visible = False
            '
            'txtEmployeeCode
            '
            Me.txtEmployeeCode.BackColor = System.Drawing.Color.White
            Me.txtEmployeeCode.BegFindValue = Nothing
            Me.txtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeCode.ComputedValue = False
            Me.txtEmployeeCode.CustomFormat = Nothing
            Me.txtEmployeeCode.DataBoundControl = True
            Me.txtEmployeeCode.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtEmployeeCode.EditingMode = True
            Me.txtEmployeeCode.EndFindValue = Nothing
            Me.txtEmployeeCode.FieldDescription = Nothing
            Me.txtEmployeeCode.FieldName = Nothing
            Me.txtEmployeeCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtEmployeeCode.FindEnabled = True
            Me.txtEmployeeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
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
            Me.txtEmployeeCode.Translatable = False
            Me.txtEmployeeCode.Visible = False
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
            Me.tbcPayroll.Size = New System.Drawing.Size(644, 348)
            Me.tbcPayroll.TabIndex = 34
            '
            'tpgEarnings
            '
            Me.tpgEarnings.Controls.Add(Me.DataGridViewEarnings)
            Me.tpgEarnings.Location = New System.Drawing.Point(4, 22)
            Me.tpgEarnings.Name = "tpgEarnings"
            Me.tpgEarnings.Padding = New System.Windows.Forms.Padding(3)
            Me.tpgEarnings.Size = New System.Drawing.Size(636, 322)
            Me.tpgEarnings.TabIndex = 0
            Me.tpgEarnings.Text = "Earnings"
            Me.tpgEarnings.UseVisualStyleBackColor = True
            '
            'DataGridViewEarnings
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewEarnings.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewEarnings.AutoGenerateColumns = False
            Me.DataGridViewEarnings.BegFindValue = Nothing
            Me.DataGridViewEarnings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewEarnings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvEarningIdNo, Me.dgvEarningAmount})
            Me.DataGridViewEarnings.DataSource = Me.bsEarnings
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewEarnings.DefaultCellStyle = DataGridViewCellStyle4
            Me.DataGridViewEarnings.DgvFooter = Nothing
            Me.DataGridViewEarnings.DisplayOnly = False
            Me.DataGridViewEarnings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewEarnings.Ea = Nothing
            Me.DataGridViewEarnings.EditingMode = False
            Me.DataGridViewEarnings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewEarnings.EndFindValue = Nothing
            Me.DataGridViewEarnings.FieldDescription = Nothing
            Me.DataGridViewEarnings.FieldName = Nothing
            Me.DataGridViewEarnings.FieldsDictionary = Nothing
            Me.DataGridViewEarnings.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewEarnings.FindEnabled = False
            Me.DataGridViewEarnings.FirstRowDeletionEnabled = True
            Me.DataGridViewEarnings.FirstRowInsertionEnabled = True
            Me.DataGridViewEarnings.IgnoreCase = False
            Me.DataGridViewEarnings.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewEarnings.Name = "DataGridViewEarnings"
            Me.DataGridViewEarnings.ReadOnly = True
            Me.DataGridViewEarnings.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewEarnings.SequenceColumn = "dgvSequence"
            Me.DataGridViewEarnings.SequenceFieldName = "Sequence"
            Me.DataGridViewEarnings.ShowFooter = False
            Me.DataGridViewEarnings.ShowInsertColumnWhenEditing = True
            Me.DataGridViewEarnings.Size = New System.Drawing.Size(630, 316)
            Me.DataGridViewEarnings.TabIndex = 0
            Me.DataGridViewEarnings.Translatable = True
            '
            'dgvEarningIdNo
            '
            Me.dgvEarningIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvEarningIdNo.DataPropertyName = "PayElementIdNo"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvEarningIdNo.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvEarningIdNo.EditingMode = False
            Me.dgvEarningIdNo.HeaderText = "Earning Name - Code"
            Me.dgvEarningIdNo.Name = "dgvEarningIdNo"
            Me.dgvEarningIdNo.ReadOnly = True
            Me.dgvEarningIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEarningIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvEarningIdNo.Translatable = False
            '
            'dgvEarningAmount
            '
            Me.dgvEarningAmount.BegFindValue = Nothing
            Me.dgvEarningAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle3.Format = "###,##0.00"
            Me.dgvEarningAmount.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvEarningAmount.EditingMode = False
            Me.dgvEarningAmount.EndFindValue = Nothing
            Me.dgvEarningAmount.FieldDescription = Nothing
            Me.dgvEarningAmount.FieldName = Nothing
            Me.dgvEarningAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvEarningAmount.FindEnabled = False
            Me.dgvEarningAmount.HeaderText = "Amount"
            Me.dgvEarningAmount.Name = "dgvEarningAmount"
            Me.dgvEarningAmount.ReadOnly = True
            Me.dgvEarningAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEarningAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvEarningAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvEarningAmount.Translatable = False
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
            Me.tpgDeductions.Size = New System.Drawing.Size(636, 322)
            Me.tpgDeductions.TabIndex = 2
            Me.tpgDeductions.Text = "Deductions"
            Me.tpgDeductions.UseVisualStyleBackColor = True
            '
            'DataGridViewDeductions
            '
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDeductions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
            Me.DataGridViewDeductions.AutoGenerateColumns = False
            Me.DataGridViewDeductions.BegFindValue = Nothing
            Me.DataGridViewDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDeductions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvDeductionIdNo, Me.dgvDeductionAmount})
            Me.DataGridViewDeductions.DataSource = Me.bsDeductions
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDeductions.DefaultCellStyle = DataGridViewCellStyle8
            Me.DataGridViewDeductions.DgvFooter = Nothing
            Me.DataGridViewDeductions.DisplayOnly = False
            Me.DataGridViewDeductions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewDeductions.Ea = Nothing
            Me.DataGridViewDeductions.EditingMode = False
            Me.DataGridViewDeductions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewDeductions.EndFindValue = Nothing
            Me.DataGridViewDeductions.FieldDescription = Nothing
            Me.DataGridViewDeductions.FieldName = Nothing
            Me.DataGridViewDeductions.FieldsDictionary = Nothing
            Me.DataGridViewDeductions.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewDeductions.FindEnabled = False
            Me.DataGridViewDeductions.FirstRowDeletionEnabled = True
            Me.DataGridViewDeductions.FirstRowInsertionEnabled = True
            Me.DataGridViewDeductions.IgnoreCase = False
            Me.DataGridViewDeductions.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewDeductions.Name = "DataGridViewDeductions"
            Me.DataGridViewDeductions.ReadOnly = True
            Me.DataGridViewDeductions.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewDeductions.SequenceColumn = "dgvSequence"
            Me.DataGridViewDeductions.SequenceFieldName = "Sequence"
            Me.DataGridViewDeductions.ShowFooter = False
            Me.DataGridViewDeductions.ShowInsertColumnWhenEditing = True
            Me.DataGridViewDeductions.Size = New System.Drawing.Size(630, 316)
            Me.DataGridViewDeductions.TabIndex = 0
            Me.DataGridViewDeductions.Translatable = True
            '
            'dgvDeductionIdNo
            '
            Me.dgvDeductionIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvDeductionIdNo.DataPropertyName = "PayElementIdNo"
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            Me.dgvDeductionIdNo.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvDeductionIdNo.EditingMode = False
            Me.dgvDeductionIdNo.HeaderText = "Deduction Name - Code"
            Me.dgvDeductionIdNo.Name = "dgvDeductionIdNo"
            Me.dgvDeductionIdNo.ReadOnly = True
            Me.dgvDeductionIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDeductionIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDeductionIdNo.Translatable = False
            '
            'dgvDeductionAmount
            '
            Me.dgvDeductionAmount.BegFindValue = Nothing
            Me.dgvDeductionAmount.DataPropertyName = "Amount"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.Format = "###,##0.00"
            Me.dgvDeductionAmount.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvDeductionAmount.EditingMode = False
            Me.dgvDeductionAmount.EndFindValue = Nothing
            Me.dgvDeductionAmount.FieldDescription = Nothing
            Me.dgvDeductionAmount.FieldName = Nothing
            Me.dgvDeductionAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDeductionAmount.FindEnabled = False
            Me.dgvDeductionAmount.HeaderText = "Amount"
            Me.dgvDeductionAmount.Name = "dgvDeductionAmount"
            Me.dgvDeductionAmount.ReadOnly = True
            Me.dgvDeductionAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDeductionAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDeductionAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDeductionAmount.Translatable = False
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
            Me.txtPayrollIdNo.ComputedValue = False
            Me.txtPayrollIdNo.CustomFormat = Nothing
            Me.txtPayrollIdNo.DataBoundControl = True
            Me.txtPayrollIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayrollIdNo.EditingMode = True
            Me.txtPayrollIdNo.EndFindValue = Nothing
            Me.txtPayrollIdNo.FieldDescription = Nothing
            Me.txtPayrollIdNo.FieldName = Nothing
            Me.txtPayrollIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayrollIdNo.FindEnabled = False
            Me.txtPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayrollIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollIdNo.LinkedLabel = Nothing
            Me.txtPayrollIdNo.Location = New System.Drawing.Point(114, 1)
            Me.txtPayrollIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollIdNo.MaximumValue = Nothing
            Me.txtPayrollIdNo.MinimumValue = Nothing
            Me.txtPayrollIdNo.Name = "txtPayrollIdNo"
            Me.txtPayrollIdNo.OldValue = Nothing
            Me.txtPayrollIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayrollIdNo.Size = New System.Drawing.Size(122, 23)
            Me.txtPayrollIdNo.TabIndex = 0
            Me.txtPayrollIdNo.TabStop = False
            Me.txtPayrollIdNo.Translatable = False
            '
            'CLabel1
            '
            Me.CLabel1.AutoSize = True
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(238, 1)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(72, 17)
            Me.CLabel1.TabIndex = 6
            Me.CLabel1.Text = "Start Date"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpStartDate.DefaultValue = Nothing
            Me.dtpStartDate.DisplayOnly = True
            Me.dtpStartDate.DtpDefaultValue = Nothing
            Me.dtpStartDate.EditingMode = True
            Me.dtpStartDate.EditsAllowed = False
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Nothing
            Me.dtpStartDate.Location = New System.Drawing.Point(312, 1)
            Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.Size = New System.Drawing.Size(115, 23)
            Me.dtpStartDate.TabIndex = 1
            Me.dtpStartDate.TabStop = False
            Me.dtpStartDate.TargetCalendar = CType(resources.GetObject("dtpStartDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpStartDate.Translatable = False
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
            Me.lblEndDate.Location = New System.Drawing.Point(429, 1)
            Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(67, 17)
            Me.lblEndDate.TabIndex = 7
            Me.lblEndDate.Text = "End Date"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEndDate.Translatable = True
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
            Me.CLabel3.Translatable = True
            '
            'txtPayPeriodDescription
            '
            Me.txtPayPeriodDescription.BackColor = System.Drawing.Color.White
            Me.txtPayPeriodDescription.BegFindValue = Nothing
            Me.txtPayPeriodDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayPeriodDescription, 5)
            Me.txtPayPeriodDescription.ComputedValue = False
            Me.txtPayPeriodDescription.CustomFormat = Nothing
            Me.txtPayPeriodDescription.DataBoundControl = True
            Me.txtPayPeriodDescription.DisplayOnly = True
            Me.txtPayPeriodDescription.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayPeriodDescription.EditingMode = True
            Me.txtPayPeriodDescription.EndFindValue = Nothing
            Me.txtPayPeriodDescription.FieldDescription = Nothing
            Me.txtPayPeriodDescription.FieldName = Nothing
            Me.txtPayPeriodDescription.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayPeriodDescription.FindEnabled = False
            Me.txtPayPeriodDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayPeriodDescription.ForeColor = System.Drawing.Color.Black
            Me.txtPayPeriodDescription.LinkedLabel = Nothing
            Me.txtPayPeriodDescription.Location = New System.Drawing.Point(114, 26)
            Me.txtPayPeriodDescription.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayPeriodDescription.MaximumValue = Nothing
            Me.txtPayPeriodDescription.MinimumValue = Nothing
            Me.txtPayPeriodDescription.Name = "txtPayPeriodDescription"
            Me.txtPayPeriodDescription.OldValue = Nothing
            Me.txtPayPeriodDescription.ReadOnly = True
            Me.txtPayPeriodDescription.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayPeriodDescription.Size = New System.Drawing.Size(535, 23)
            Me.txtPayPeriodDescription.TabIndex = 3
            Me.txtPayPeriodDescription.TabStop = False
            Me.txtPayPeriodDescription.Translatable = False
            Me.txtPayPeriodDescription.ValueIsMandatory = True
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
            Me.lblEmployeeName.Translatable = True
            '
            'CLabel9
            '
            Me.CLabel9.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel9, 2)
            Me.CLabel9.DisplayOnly = True
            Me.CLabel9.Dock = System.Windows.Forms.DockStyle.Right
            Me.CLabel9.EditingMode = False
            Me.CLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel9.Location = New System.Drawing.Point(396, 431)
            Me.CLabel9.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel9.Name = "CLabel9"
            Me.CLabel9.Size = New System.Drawing.Size(100, 23)
            Me.CLabel9.TabIndex = 27
            Me.CLabel9.Text = "Total Earnings"
            Me.CLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel9.Translatable = True
            '
            'txtTotalEarnings
            '
            Me.txtTotalEarnings.BackColor = System.Drawing.Color.White
            Me.txtTotalEarnings.BegFindValue = Nothing
            Me.txtTotalEarnings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalEarnings.ComputedValue = False
            Me.txtTotalEarnings.CustomFormat = "N2"
            Me.txtTotalEarnings.DataBoundControl = True
            Me.txtTotalEarnings.DisplayOnly = True
            Me.txtTotalEarnings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtTotalEarnings.EditingMode = True
            Me.txtTotalEarnings.EndFindValue = Nothing
            Me.txtTotalEarnings.FieldDescription = Nothing
            Me.txtTotalEarnings.FieldName = Nothing
            Me.txtTotalEarnings.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalEarnings.FindEnabled = False
            Me.txtTotalEarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTotalEarnings.ForeColor = System.Drawing.Color.Black
            Me.txtTotalEarnings.LinkedLabel = Nothing
            Me.txtTotalEarnings.Location = New System.Drawing.Point(498, 431)
            Me.txtTotalEarnings.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTotalEarnings.MaximumValue = Nothing
            Me.txtTotalEarnings.MinimumValue = Nothing
            Me.txtTotalEarnings.Name = "txtTotalEarnings"
            Me.txtTotalEarnings.OldValue = Nothing
            Me.txtTotalEarnings.ReadOnly = True
            Me.txtTotalEarnings.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalEarnings.Size = New System.Drawing.Size(151, 23)
            Me.txtTotalEarnings.TabIndex = 5
            Me.txtTotalEarnings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtTotalEarnings.Translatable = False
            Me.txtTotalEarnings.ValueIsNumeric = True
            '
            'CLabel10
            '
            Me.CLabel10.AutoSize = True
            Me.CLabel10.DisplayOnly = True
            Me.CLabel10.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel10.EditingMode = False
            Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel10.Location = New System.Drawing.Point(429, 481)
            Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel10.Name = "CLabel10"
            Me.CLabel10.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.CLabel10.Size = New System.Drawing.Size(67, 31)
            Me.CLabel10.TabIndex = 29
            Me.CLabel10.Text = "Net Pay"
            Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel10.Translatable = True
            '
            'dtpEndDate
            '
            Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndDate.DefaultValue = Nothing
            Me.dtpEndDate.DisplayOnly = True
            Me.dtpEndDate.DtpDefaultValue = Nothing
            Me.dtpEndDate.EditingMode = True
            Me.dtpEndDate.EditsAllowed = False
            Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndDate.LinkedLabel = Nothing
            Me.dtpEndDate.Location = New System.Drawing.Point(498, 1)
            Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.ReadOnlyDp = False
            Me.dtpEndDate.SecurityKey = Nothing
            Me.dtpEndDate.ShowLongDate = False
            Me.dtpEndDate.ShowTime = False
            Me.dtpEndDate.Size = New System.Drawing.Size(115, 23)
            Me.dtpEndDate.TabIndex = 2
            Me.dtpEndDate.TabStop = False
            Me.dtpEndDate.TargetCalendar = CType(resources.GetObject("dtpEndDate.TargetCalendar"), System.Globalization.Calendar)
            Me.dtpEndDate.Translatable = False
            Me.dtpEndDate.Value = Nothing
            Me.dtpEndDate.ValueIsMandatory = False
            Me.dtpEndDate.ValueIsNullable = False
            '
            'txtTotalDeductions
            '
            Me.txtTotalDeductions.BackColor = System.Drawing.Color.White
            Me.txtTotalDeductions.BegFindValue = Nothing
            Me.txtTotalDeductions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTotalDeductions.ComputedValue = False
            Me.txtTotalDeductions.CustomFormat = "N2"
            Me.txtTotalDeductions.DataBoundControl = True
            Me.txtTotalDeductions.DisplayOnly = True
            Me.txtTotalDeductions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtTotalDeductions.EditingMode = True
            Me.txtTotalDeductions.EndFindValue = Nothing
            Me.txtTotalDeductions.FieldDescription = Nothing
            Me.txtTotalDeductions.FieldName = Nothing
            Me.txtTotalDeductions.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalDeductions.FindEnabled = False
            Me.txtTotalDeductions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTotalDeductions.ForeColor = System.Drawing.Color.Black
            Me.txtTotalDeductions.LinkedLabel = Nothing
            Me.txtTotalDeductions.Location = New System.Drawing.Point(498, 456)
            Me.txtTotalDeductions.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTotalDeductions.MaximumValue = Nothing
            Me.txtTotalDeductions.MinimumValue = Nothing
            Me.txtTotalDeductions.Name = "txtTotalDeductions"
            Me.txtTotalDeductions.OldValue = Nothing
            Me.txtTotalDeductions.ReadOnly = True
            Me.txtTotalDeductions.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalDeductions.Size = New System.Drawing.Size(151, 23)
            Me.txtTotalDeductions.TabIndex = 6
            Me.txtTotalDeductions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtTotalDeductions.Translatable = False
            Me.txtTotalDeductions.ValueIsNumeric = True
            '
            'txtNetPay
            '
            Me.txtNetPay.BackColor = System.Drawing.Color.White
            Me.txtNetPay.BegFindValue = Nothing
            Me.txtNetPay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNetPay.ComputedValue = False
            Me.txtNetPay.CustomFormat = "N2"
            Me.txtNetPay.DataBoundControl = True
            Me.txtNetPay.DisplayOnly = True
            Me.txtNetPay.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtNetPay.EditingMode = True
            Me.txtNetPay.EndFindValue = Nothing
            Me.txtNetPay.FieldDescription = Nothing
            Me.txtNetPay.FieldName = Nothing
            Me.txtNetPay.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNetPay.FindEnabled = False
            Me.txtNetPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNetPay.ForeColor = System.Drawing.Color.Black
            Me.txtNetPay.LinkedLabel = Nothing
            Me.txtNetPay.Location = New System.Drawing.Point(498, 481)
            Me.txtNetPay.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNetPay.MaximumValue = Nothing
            Me.txtNetPay.MinimumValue = Nothing
            Me.txtNetPay.Name = "txtNetPay"
            Me.txtNetPay.OldValue = Nothing
            Me.txtNetPay.ReadOnly = True
            Me.txtNetPay.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNetPay.Size = New System.Drawing.Size(151, 23)
            Me.txtNetPay.TabIndex = 7
            Me.txtNetPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtNetPay.Translatable = False
            Me.txtNetPay.ValueIsNumeric = True
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
            Me.lblNotes.Translatable = True
            '
            'CLabel11
            '
            Me.CLabel11.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel11, 2)
            Me.CLabel11.DisplayOnly = True
            Me.CLabel11.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel11.EditingMode = False
            Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel11.Location = New System.Drawing.Point(312, 456)
            Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel11.Name = "CLabel11"
            Me.CLabel11.Size = New System.Drawing.Size(184, 23)
            Me.CLabel11.TabIndex = 32
            Me.CLabel11.Text = "Total Deductions"
            Me.CLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel11.Translatable = True
            '
            'cboEmployeeIdNo
            '
            Me.cboEmployeeIdNo.BackColor = System.Drawing.Color.White
            Me.cboEmployeeIdNo.BegFindValue = Nothing
            Me.cboEmployeeIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboEmployeeIdNo, 5)
            Me.cboEmployeeIdNo.CurrentSearchTerm = ""
            Me.cboEmployeeIdNo.DefaultValue = Nothing
            Me.cboEmployeeIdNo.DisplayMember = "Name"
            Me.cboEmployeeIdNo.DisplayOnly = True
            Me.cboEmployeeIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboEmployeeIdNo.DropDownHeight = 21
            Me.cboEmployeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboEmployeeIdNo.EditingMode = True
            Me.cboEmployeeIdNo.EndFindValue = Nothing
            Me.cboEmployeeIdNo.FieldDescription = Nothing
            Me.cboEmployeeIdNo.FieldName = Nothing
            Me.cboEmployeeIdNo.FilterRule = Nothing
            Me.cboEmployeeIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboEmployeeIdNo.FindEnabled = False
            Me.cboEmployeeIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboEmployeeIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboEmployeeIdNo.FormattingEnabled = True
            Me.cboEmployeeIdNo.HideWhenNotEditingOrAdding = False
            Me.cboEmployeeIdNo.IgnoreCase = False
            Me.cboEmployeeIdNo.IntegralHeight = False
            Me.cboEmployeeIdNo.LinkedLabel = Nothing
            Me.cboEmployeeIdNo.Location = New System.Drawing.Point(114, 51)
            Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboEmployeeIdNo.MaxDropDownItems = 1
            Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
            Me.cboEmployeeIdNo.OldValue = 0
            Me.cboEmployeeIdNo.OriginalDataSource = Nothing
            Me.cboEmployeeIdNo.OriginalList = Nothing
            Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
            Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
            Me.cboEmployeeIdNo.PropertySelector = Nothing
            Me.cboEmployeeIdNo.ReadOnlyCombo = True
            Me.cboEmployeeIdNo.Size = New System.Drawing.Size(535, 24)
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
            Me.cboEmployeeIdNo.SuggestListOrderRule = Nothing
            Me.cboEmployeeIdNo.TabIndex = 4
            Me.cboEmployeeIdNo.TabStop = False
            Me.cboEmployeeIdNo.TextToSearch = Nothing
            Me.cboEmployeeIdNo.Translatable = False
            Me.cboEmployeeIdNo.ValueIsMandatory = False
            Me.cboEmployeeIdNo.ValueIsNullable = False
            Me.cboEmployeeIdNo.ValueIsNumeric = False
            Me.cboEmployeeIdNo.ValueMember = "IdNo"
            '
            'PayrollDetailEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1036, 581)
            Me.Name = "PayrollDetailEntry"
            Me.Text = " "
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.tbcPayroll.ResumeLayout(False)
            Me.tpgEarnings.ResumeLayout(False)
            CType(Me.DataGridViewEarnings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsEarnings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgDeductions.ResumeLayout(False)
            CType(Me.DataGridViewDeductions, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsDeductions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents lblEmployeeName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dtpStartDate As CCustomDateTimePicker
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblEndDate As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
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
        Friend WithEvents dgvEarningIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvEarningAmount As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
        Friend WithEvents DataGridViewDeductions As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents dgvDeductionIdNo As Libraries.CBaseControlsLibrary.CDgvComboBoxColumn
        Friend WithEvents dgvDeductionAmount As Libraries.CBaseControlsLibrary.CdgvMoneyColumn
    End Class
End Namespace