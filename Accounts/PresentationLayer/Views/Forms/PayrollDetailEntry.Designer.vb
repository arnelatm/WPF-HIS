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
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayrollDetailEntry))
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEmployeeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.tbcPayroll = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tpgEarnings = New System.Windows.Forms.TabPage()
            Me.DataGridViewEarnings = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvEarningGenerated = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.dgvEarningIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvEarningAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.bsEarnings = New System.Windows.Forms.BindingSource(Me.components)
            Me.tpgDeductions = New System.Windows.Forms.TabPage()
            Me.DataGridViewDeductions = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvDeductionGenerated = New AATM.Libraries.CBaseControlsLibrary.CDgvCheckBoxColumn()
            Me.dgvDeductionIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn()
            Me.dgvDeductionAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
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
            Me.cboEmployeeIdNo = New AATM.Libraries.CBaseControlsLibrary.AtmComboBox()
            Me.lblBankTransfer = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkBankTransfer = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
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
            Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(5)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.CFlowLayout1)
            Me.SplitContainer1.Size = New System.Drawing.Size(1381, 660)
            Me.SplitContainer1.SplitterDistance = 467
            Me.SplitContainer1.SplitterWidth = 17
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Margin = New System.Windows.Forms.Padding(5)
            Me.FormTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.FormTreeView.Size = New System.Drawing.Size(467, 660)
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
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.TableLayoutPanel1)
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout1.Location = New System.Drawing.Point(0, 0)
            Me.CFlowLayout1.Margin = New System.Windows.Forms.Padding(4)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(897, 660)
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
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
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
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(888, 631)
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
            Me.txtIdNo.Location = New System.Drawing.Point(177, 553)
            Me.txtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIdNo.MaximumValue = Nothing
            Me.txtIdNo.MinimumValue = Nothing
            Me.txtIdNo.Name = "txtIdNo"
            Me.txtIdNo.OldValue = Nothing
            Me.txtIdNo.OverrideMaxLength = 0
            Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIdNo.Size = New System.Drawing.Size(162, 26)
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
            Me.txtEmployeeCode.Location = New System.Drawing.Point(1, 553)
            Me.txtEmployeeCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeCode.MaximumValue = Nothing
            Me.txtEmployeeCode.MinimumValue = Nothing
            Me.txtEmployeeCode.Name = "txtEmployeeCode"
            Me.txtEmployeeCode.OldValue = Nothing
            Me.txtEmployeeCode.OverrideMaxLength = 0
            Me.txtEmployeeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtEmployeeCode.Size = New System.Drawing.Size(174, 26)
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
            Me.tbcPayroll.Location = New System.Drawing.Point(4, 92)
            Me.tbcPayroll.Margin = New System.Windows.Forms.Padding(4)
            Me.tbcPayroll.Name = "tbcPayroll"
            Me.tbcPayroll.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.tbcPayroll.SelectedIndex = 0
            Me.tbcPayroll.Size = New System.Drawing.Size(913, 428)
            Me.tbcPayroll.TabIndex = 34
            '
            'tpgEarnings
            '
            Me.tpgEarnings.Controls.Add(Me.DataGridViewEarnings)
            Me.tpgEarnings.Location = New System.Drawing.Point(4, 25)
            Me.tpgEarnings.Margin = New System.Windows.Forms.Padding(4)
            Me.tpgEarnings.Name = "tpgEarnings"
            Me.tpgEarnings.Padding = New System.Windows.Forms.Padding(4)
            Me.tpgEarnings.Size = New System.Drawing.Size(905, 399)
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
            Me.DataGridViewEarnings.Cached = False
            Me.DataGridViewEarnings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewEarnings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvEarningGenerated, Me.dgvEarningIdNo, Me.dgvEarningAmount})
            Me.DataGridViewEarnings.DataFilter = Nothing
            Me.DataGridViewEarnings.DataSource = Me.bsEarnings
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewEarnings.DefaultCellStyle = DataGridViewCellStyle5
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
            Me.DataGridViewEarnings.FindColumnNo = CType(0, Short)
            Me.DataGridViewEarnings.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewEarnings.FindEnabled = False
            Me.DataGridViewEarnings.FirstRowDeletionEnabled = True
            Me.DataGridViewEarnings.FirstRowInsertionEnabled = True
            Me.DataGridViewEarnings.IgnoreCase = False
            Me.DataGridViewEarnings.IsDirty = False
            Me.DataGridViewEarnings.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewEarnings.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewEarnings.Name = "DataGridViewEarnings"
            Me.DataGridViewEarnings.OldCellValue = Nothing
            Me.DataGridViewEarnings.ReadOnly = True
            Me.DataGridViewEarnings.RowHeadersWidth = 51
            Me.DataGridViewEarnings.Searchable = True
            Me.DataGridViewEarnings.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewEarnings.SecurityKey = ""
            Me.DataGridViewEarnings.SequenceColumn = "dgvSequence"
            Me.DataGridViewEarnings.SequenceFieldName = "Sequence"
            Me.DataGridViewEarnings.ShowFooter = False
            Me.DataGridViewEarnings.Size = New System.Drawing.Size(897, 391)
            Me.DataGridViewEarnings.TabIndex = 0
            Me.DataGridViewEarnings.Translatable = True
            '
            'dgvEarningGenerated
            '
            Me.dgvEarningGenerated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvEarningGenerated.BegFindValue = Nothing
            Me.dgvEarningGenerated.DataPropertyName = "Generated"
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.NullValue = False
            Me.dgvEarningGenerated.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvEarningGenerated.EditingMode = False
            Me.dgvEarningGenerated.EndFindValue = Nothing
            Me.dgvEarningGenerated.FieldDescription = Nothing
            Me.dgvEarningGenerated.FieldName = Nothing
            Me.dgvEarningGenerated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvEarningGenerated.FindEnabled = False
            Me.dgvEarningGenerated.HeaderText = "Generated"
            Me.dgvEarningGenerated.IgnoreCase = False
            Me.dgvEarningGenerated.MinimumWidth = 6
            Me.dgvEarningGenerated.Name = "dgvEarningGenerated"
            Me.dgvEarningGenerated.ReadOnly = True
            Me.dgvEarningGenerated.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEarningGenerated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvEarningGenerated.Translatable = False
            Me.dgvEarningGenerated.Width = 77
            '
            'dgvEarningIdNo
            '
            Me.dgvEarningIdNo.AutoComplete = False
            Me.dgvEarningIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvEarningIdNo.DataPropertyName = "PayElementIdNo"
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            Me.dgvEarningIdNo.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvEarningIdNo.EditingMode = False
            Me.dgvEarningIdNo.HeaderText = "Earning Name - Code"
            Me.dgvEarningIdNo.MinimumWidth = 6
            Me.dgvEarningIdNo.Name = "dgvEarningIdNo"
            Me.dgvEarningIdNo.ReadOnly = True
            Me.dgvEarningIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEarningIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvEarningIdNo.SuggestCharCount = 0
            Me.dgvEarningIdNo.Translatable = False
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
            Me.dgvEarningAmount.EditingMode = False
            Me.dgvEarningAmount.EndFindValue = Nothing
            Me.dgvEarningAmount.FieldDescription = Nothing
            Me.dgvEarningAmount.FieldName = Nothing
            Me.dgvEarningAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvEarningAmount.FindEnabled = False
            Me.dgvEarningAmount.HeaderText = "Amount"
            Me.dgvEarningAmount.MinimumWidth = 6
            Me.dgvEarningAmount.Name = "dgvEarningAmount"
            Me.dgvEarningAmount.ReadOnly = True
            Me.dgvEarningAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEarningAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvEarningAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvEarningAmount.Translatable = False
            Me.dgvEarningAmount.Width = 125
            '
            'bsEarnings
            '
            Me.bsEarnings.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PayrollPayElementModel)
            '
            'tpgDeductions
            '
            Me.tpgDeductions.Controls.Add(Me.DataGridViewDeductions)
            Me.tpgDeductions.Location = New System.Drawing.Point(4, 25)
            Me.tpgDeductions.Margin = New System.Windows.Forms.Padding(4)
            Me.tpgDeductions.Name = "tpgDeductions"
            Me.tpgDeductions.Padding = New System.Windows.Forms.Padding(4)
            Me.tpgDeductions.Size = New System.Drawing.Size(905, 399)
            Me.tpgDeductions.TabIndex = 2
            Me.tpgDeductions.Text = "Deductions"
            Me.tpgDeductions.UseVisualStyleBackColor = True
            '
            'DataGridViewDeductions
            '
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDeductions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
            Me.DataGridViewDeductions.AutoGenerateColumns = False
            Me.DataGridViewDeductions.BegFindValue = Nothing
            Me.DataGridViewDeductions.Cached = False
            Me.DataGridViewDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDeductions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvDeductionGenerated, Me.dgvDeductionIdNo, Me.dgvDeductionAmount})
            Me.DataGridViewDeductions.DataFilter = Nothing
            Me.DataGridViewDeductions.DataSource = Me.bsDeductions
            DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDeductions.DefaultCellStyle = DataGridViewCellStyle10
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
            Me.DataGridViewDeductions.FindColumnNo = CType(0, Short)
            Me.DataGridViewDeductions.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewDeductions.FindEnabled = False
            Me.DataGridViewDeductions.FirstRowDeletionEnabled = True
            Me.DataGridViewDeductions.FirstRowInsertionEnabled = True
            Me.DataGridViewDeductions.IgnoreCase = False
            Me.DataGridViewDeductions.IsDirty = False
            Me.DataGridViewDeductions.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewDeductions.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewDeductions.Name = "DataGridViewDeductions"
            Me.DataGridViewDeductions.OldCellValue = Nothing
            Me.DataGridViewDeductions.ReadOnly = True
            Me.DataGridViewDeductions.RowHeadersWidth = 51
            Me.DataGridViewDeductions.Searchable = True
            Me.DataGridViewDeductions.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewDeductions.SecurityKey = ""
            Me.DataGridViewDeductions.SequenceColumn = "dgvSequence"
            Me.DataGridViewDeductions.SequenceFieldName = "Sequence"
            Me.DataGridViewDeductions.ShowFooter = False
            Me.DataGridViewDeductions.Size = New System.Drawing.Size(897, 391)
            Me.DataGridViewDeductions.TabIndex = 0
            Me.DataGridViewDeductions.Translatable = True
            '
            'dgvDeductionGenerated
            '
            Me.dgvDeductionGenerated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
            Me.dgvDeductionGenerated.BegFindValue = Nothing
            Me.dgvDeductionGenerated.DataPropertyName = "Generated"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.NullValue = False
            Me.dgvDeductionGenerated.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvDeductionGenerated.EditingMode = False
            Me.dgvDeductionGenerated.EndFindValue = Nothing
            Me.dgvDeductionGenerated.FieldDescription = Nothing
            Me.dgvDeductionGenerated.FieldName = Nothing
            Me.dgvDeductionGenerated.FillWeight = 60.0!
            Me.dgvDeductionGenerated.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDeductionGenerated.FindEnabled = False
            Me.dgvDeductionGenerated.HeaderText = "Generated"
            Me.dgvDeductionGenerated.IgnoreCase = False
            Me.dgvDeductionGenerated.MinimumWidth = 6
            Me.dgvDeductionGenerated.Name = "dgvDeductionGenerated"
            Me.dgvDeductionGenerated.ReadOnly = True
            Me.dgvDeductionGenerated.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDeductionGenerated.Translatable = False
            Me.dgvDeductionGenerated.Width = 77
            '
            'dgvDeductionIdNo
            '
            Me.dgvDeductionIdNo.AutoComplete = False
            Me.dgvDeductionIdNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.dgvDeductionIdNo.DataPropertyName = "PayElementIdNo"
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            Me.dgvDeductionIdNo.DefaultCellStyle = DataGridViewCellStyle8
            Me.dgvDeductionIdNo.EditingMode = False
            Me.dgvDeductionIdNo.HeaderText = "Deduction Name - Code"
            Me.dgvDeductionIdNo.MinimumWidth = 6
            Me.dgvDeductionIdNo.Name = "dgvDeductionIdNo"
            Me.dgvDeductionIdNo.ReadOnly = True
            Me.dgvDeductionIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDeductionIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDeductionIdNo.SuggestCharCount = 0
            Me.dgvDeductionIdNo.Translatable = False
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
            Me.dgvDeductionAmount.EditingMode = False
            Me.dgvDeductionAmount.EndFindValue = Nothing
            Me.dgvDeductionAmount.FieldDescription = Nothing
            Me.dgvDeductionAmount.FieldName = Nothing
            Me.dgvDeductionAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvDeductionAmount.FindEnabled = False
            Me.dgvDeductionAmount.HeaderText = "Amount"
            Me.dgvDeductionAmount.MinimumWidth = 6
            Me.dgvDeductionAmount.Name = "dgvDeductionAmount"
            Me.dgvDeductionAmount.ReadOnly = True
            Me.dgvDeductionAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvDeductionAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvDeductionAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvDeductionAmount.Translatable = False
            Me.dgvDeductionAmount.Width = 125
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
            Me.txtPayrollIdNo.DisplayOnly = True
            Me.txtPayrollIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPayrollIdNo.EditingMode = True
            Me.txtPayrollIdNo.EndFindValue = Nothing
            Me.txtPayrollIdNo.FieldDescription = Nothing
            Me.txtPayrollIdNo.FieldName = Nothing
            Me.txtPayrollIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPayrollIdNo.FindEnabled = False
            Me.txtPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPayrollIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtPayrollIdNo.LinkedLabel = Me.lblPayrollIdNo
            Me.txtPayrollIdNo.Location = New System.Drawing.Point(177, 1)
            Me.txtPayrollIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayrollIdNo.MaximumValue = Nothing
            Me.txtPayrollIdNo.MinimumValue = Nothing
            Me.txtPayrollIdNo.Name = "txtPayrollIdNo"
            Me.txtPayrollIdNo.OldValue = Nothing
            Me.txtPayrollIdNo.OverrideMaxLength = 0
            Me.txtPayrollIdNo.ReadOnly = True
            Me.txtPayrollIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayrollIdNo.Size = New System.Drawing.Size(162, 26)
            Me.txtPayrollIdNo.TabIndex = 0
            Me.txtPayrollIdNo.TabStop = False
            Me.txtPayrollIdNo.Translatable = False
            '
            'lblPayrollIdNo
            '
            Me.lblPayrollIdNo.AutoSize = True
            Me.lblPayrollIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblPayrollIdNo.DisplayOnly = True
            Me.lblPayrollIdNo.EditingMode = False
            Me.lblPayrollIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayrollIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblPayrollIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayrollIdNo.Name = "lblPayrollIdNo"
            Me.lblPayrollIdNo.Size = New System.Drawing.Size(124, 20)
            Me.lblPayrollIdNo.TabIndex = 4
            Me.lblPayrollIdNo.Text = "Payroll Number"
            Me.lblPayrollIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayrollIdNo.Translatable = True
            '
            'lblStartDate
            '
            Me.lblStartDate.AutoSize = True
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.DisplayOnly = True
            Me.lblStartDate.EditingMode = False
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblStartDate.Location = New System.Drawing.Point(341, 1)
            Me.lblStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(86, 20)
            Me.lblStartDate.TabIndex = 6
            Me.lblStartDate.Text = "Start Date"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblStartDate.Translatable = True
            '
            'dtpStartDate
            '
            Me.dtpStartDate.AutoSize = True
            Me.dtpStartDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpStartDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpStartDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpStartDate.DefaultValue = Nothing
            Me.dtpStartDate.DisplayOnly = True
            Me.dtpStartDate.DtpDefaultValue = Nothing
            Me.dtpStartDate.EditingMode = True
            Me.dtpStartDate.EditsAllowed = False
            Me.dtpStartDate.ForeColor = System.Drawing.Color.Black
            Me.dtpStartDate.LinkedLabel = Me.lblStartDate
            Me.dtpStartDate.Location = New System.Drawing.Point(429, 1)
            Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.ReadOnlyDp = False
            Me.dtpStartDate.SecurityKey = Nothing
            Me.dtpStartDate.ShowLongDate = False
            Me.dtpStartDate.ShowTime = False
            Me.dtpStartDate.Size = New System.Drawing.Size(98, 27)
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
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.DisplayOnly = True
            Me.lblEndDate.EditingMode = False
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEndDate.Location = New System.Drawing.Point(595, 1)
            Me.lblEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(79, 20)
            Me.lblEndDate.TabIndex = 7
            Me.lblEndDate.Text = "End Date"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEndDate.Translatable = True
            '
            'lblPayDescription
            '
            Me.lblPayDescription.AutoSize = True
            Me.lblPayDescription.BackColor = System.Drawing.Color.Transparent
            Me.lblPayDescription.DisplayOnly = True
            Me.lblPayDescription.EditingMode = False
            Me.lblPayDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPayDescription.Location = New System.Drawing.Point(1, 30)
            Me.lblPayDescription.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPayDescription.Name = "lblPayDescription"
            Me.lblPayDescription.Size = New System.Drawing.Size(128, 20)
            Me.lblPayDescription.TabIndex = 8
            Me.lblPayDescription.Text = "Pay Description"
            Me.lblPayDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPayDescription.Translatable = True
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
            Me.txtPayPeriodDescription.LinkedLabel = Me.lblPayDescription
            Me.txtPayPeriodDescription.Location = New System.Drawing.Point(177, 30)
            Me.txtPayPeriodDescription.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPayPeriodDescription.MaximumValue = Nothing
            Me.txtPayPeriodDescription.MinimumValue = Nothing
            Me.txtPayPeriodDescription.Name = "txtPayPeriodDescription"
            Me.txtPayPeriodDescription.OldValue = Nothing
            Me.txtPayPeriodDescription.OverrideMaxLength = 0
            Me.txtPayPeriodDescription.ReadOnly = True
            Me.txtPayPeriodDescription.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPayPeriodDescription.Size = New System.Drawing.Size(743, 26)
            Me.txtPayPeriodDescription.TabIndex = 3
            Me.txtPayPeriodDescription.TabStop = False
            Me.txtPayPeriodDescription.Translatable = False
            Me.txtPayPeriodDescription.ValueIsMandatory = True
            '
            'lblEmployeeName
            '
            Me.lblEmployeeName.AutoSize = True
            Me.lblEmployeeName.BackColor = System.Drawing.Color.Transparent
            Me.lblEmployeeName.DisplayOnly = True
            Me.lblEmployeeName.EditingMode = False
            Me.lblEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEmployeeName.Location = New System.Drawing.Point(1, 58)
            Me.lblEmployeeName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEmployeeName.Name = "lblEmployeeName"
            Me.lblEmployeeName.Size = New System.Drawing.Size(131, 20)
            Me.lblEmployeeName.TabIndex = 11
            Me.lblEmployeeName.Text = "Employee Name"
            Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEmployeeName.Translatable = True
            '
            'CLabel9
            '
            Me.CLabel9.AutoSize = True
            Me.CLabel9.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel9, 2)
            Me.CLabel9.DisplayOnly = True
            Me.CLabel9.Dock = System.Windows.Forms.DockStyle.Right
            Me.CLabel9.EditingMode = False
            Me.CLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel9.Location = New System.Drawing.Point(602, 525)
            Me.CLabel9.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel9.Name = "CLabel9"
            Me.CLabel9.Size = New System.Drawing.Size(117, 26)
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
            Me.txtTotalEarnings.EditingMode = True
            Me.txtTotalEarnings.EndFindValue = Nothing
            Me.txtTotalEarnings.FieldDescription = Nothing
            Me.txtTotalEarnings.FieldName = Nothing
            Me.txtTotalEarnings.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalEarnings.FindEnabled = False
            Me.txtTotalEarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTotalEarnings.ForeColor = System.Drawing.Color.Black
            Me.txtTotalEarnings.LinkedLabel = Nothing
            Me.txtTotalEarnings.Location = New System.Drawing.Point(721, 525)
            Me.txtTotalEarnings.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTotalEarnings.MaximumValue = Nothing
            Me.txtTotalEarnings.MinimumValue = Nothing
            Me.txtTotalEarnings.Name = "txtTotalEarnings"
            Me.txtTotalEarnings.OldValue = Nothing
            Me.txtTotalEarnings.OverrideMaxLength = 0
            Me.txtTotalEarnings.ReadOnly = True
            Me.txtTotalEarnings.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalEarnings.Size = New System.Drawing.Size(153, 26)
            Me.txtTotalEarnings.TabIndex = 6
            Me.txtTotalEarnings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtTotalEarnings.Translatable = False
            Me.txtTotalEarnings.ValueIsNumeric = True
            '
            'CLabel10
            '
            Me.CLabel10.AutoSize = True
            Me.CLabel10.BackColor = System.Drawing.Color.Transparent
            Me.CLabel10.DisplayOnly = True
            Me.CLabel10.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel10.EditingMode = False
            Me.CLabel10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel10.Location = New System.Drawing.Point(595, 581)
            Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel10.Name = "CLabel10"
            Me.CLabel10.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.CLabel10.Size = New System.Drawing.Size(124, 49)
            Me.CLabel10.TabIndex = 29
            Me.CLabel10.Text = "Net Pay"
            Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CLabel10.Translatable = True
            '
            'dtpEndDate
            '
            Me.dtpEndDate.AutoSize = True
            Me.dtpEndDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.dtpEndDate.CalendarCulture = New System.Globalization.CultureInfo("en-GB")
            Me.dtpEndDate.CalendarType = AATM.Libraries.GlobalFuncNSub.GlobalSubs.CalendarToUse.Gregorian
            Me.dtpEndDate.DefaultValue = Nothing
            Me.dtpEndDate.DisplayOnly = True
            Me.dtpEndDate.DtpDefaultValue = Nothing
            Me.dtpEndDate.EditingMode = True
            Me.dtpEndDate.EditsAllowed = False
            Me.dtpEndDate.ForeColor = System.Drawing.Color.Black
            Me.dtpEndDate.LinkedLabel = Me.lblEndDate
            Me.dtpEndDate.Location = New System.Drawing.Point(721, 1)
            Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(1)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.ReadOnlyDp = False
            Me.dtpEndDate.SecurityKey = Nothing
            Me.dtpEndDate.ShowLongDate = False
            Me.dtpEndDate.ShowTime = False
            Me.dtpEndDate.Size = New System.Drawing.Size(98, 27)
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
            Me.txtTotalDeductions.EditingMode = True
            Me.txtTotalDeductions.EndFindValue = Nothing
            Me.txtTotalDeductions.FieldDescription = Nothing
            Me.txtTotalDeductions.FieldName = Nothing
            Me.txtTotalDeductions.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtTotalDeductions.FindEnabled = False
            Me.txtTotalDeductions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtTotalDeductions.ForeColor = System.Drawing.Color.Black
            Me.txtTotalDeductions.LinkedLabel = Nothing
            Me.txtTotalDeductions.Location = New System.Drawing.Point(721, 553)
            Me.txtTotalDeductions.Margin = New System.Windows.Forms.Padding(1)
            Me.txtTotalDeductions.MaximumValue = Nothing
            Me.txtTotalDeductions.MinimumValue = Nothing
            Me.txtTotalDeductions.Name = "txtTotalDeductions"
            Me.txtTotalDeductions.OldValue = Nothing
            Me.txtTotalDeductions.OverrideMaxLength = 0
            Me.txtTotalDeductions.ReadOnly = True
            Me.txtTotalDeductions.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtTotalDeductions.Size = New System.Drawing.Size(153, 26)
            Me.txtTotalDeductions.TabIndex = 7
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
            Me.txtNetPay.EditingMode = True
            Me.txtNetPay.EndFindValue = Nothing
            Me.txtNetPay.FieldDescription = Nothing
            Me.txtNetPay.FieldName = Nothing
            Me.txtNetPay.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNetPay.FindEnabled = False
            Me.txtNetPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNetPay.ForeColor = System.Drawing.Color.Black
            Me.txtNetPay.LinkedLabel = Nothing
            Me.txtNetPay.Location = New System.Drawing.Point(721, 581)
            Me.txtNetPay.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNetPay.MaximumValue = Nothing
            Me.txtNetPay.MinimumValue = Nothing
            Me.txtNetPay.Name = "txtNetPay"
            Me.txtNetPay.OldValue = Nothing
            Me.txtNetPay.OverrideMaxLength = 0
            Me.txtNetPay.ReadOnly = True
            Me.txtNetPay.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNetPay.Size = New System.Drawing.Size(153, 26)
            Me.txtNetPay.TabIndex = 8
            Me.txtNetPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtNetPay.Translatable = False
            Me.txtNetPay.ValueIsNumeric = True
            '
            'CLabel11
            '
            Me.CLabel11.AutoSize = True
            Me.CLabel11.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel11, 2)
            Me.CLabel11.DisplayOnly = True
            Me.CLabel11.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CLabel11.EditingMode = False
            Me.CLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel11.Location = New System.Drawing.Point(429, 553)
            Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel11.Name = "CLabel11"
            Me.CLabel11.Size = New System.Drawing.Size(290, 26)
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
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboEmployeeIdNo, 3)
            Me.cboEmployeeIdNo.CurrentSearchTerm = ""
            Me.cboEmployeeIdNo.DataValue = Nothing
            Me.cboEmployeeIdNo.DefaultValue = Nothing
            Me.cboEmployeeIdNo.DisplayMember = "Name"
            Me.cboEmployeeIdNo.DisplayOnly = True
            Me.cboEmployeeIdNo.DropDownHeight = 24
            Me.cboEmployeeIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboEmployeeIdNo.Editable = True
            Me.cboEmployeeIdNo.EditingMode = False
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
            Me.cboEmployeeIdNo.LimitToList = False
            Me.cboEmployeeIdNo.LinkedLabel = Nothing
            Me.cboEmployeeIdNo.Location = New System.Drawing.Point(177, 58)
            Me.cboEmployeeIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboEmployeeIdNo.MaxDropDownItems = 1
            Me.cboEmployeeIdNo.Name = "cboEmployeeIdNo"
            Me.cboEmployeeIdNo.OldValue = 0
            Me.cboEmployeeIdNo.OriginalDataSource = Nothing
            Me.cboEmployeeIdNo.OriginalList = Nothing
            Me.cboEmployeeIdNo.OverrideDropDownStyleList = False
            Me.cboEmployeeIdNo.PreviousSearchTerm = Nothing
            Me.cboEmployeeIdNo.PropertySelector = Nothing
            Me.cboEmployeeIdNo.Size = New System.Drawing.Size(416, 29)
            Me.cboEmployeeIdNo.SuggestBoxHeight = 200
            Me.cboEmployeeIdNo.SuggestCharCount = 0
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
            'lblBankTransfer
            '
            Me.lblBankTransfer.AutoSize = True
            Me.lblBankTransfer.BackColor = System.Drawing.Color.Transparent
            Me.lblBankTransfer.DisplayOnly = True
            Me.lblBankTransfer.EditingMode = False
            Me.lblBankTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblBankTransfer.Location = New System.Drawing.Point(595, 58)
            Me.lblBankTransfer.Margin = New System.Windows.Forms.Padding(1)
            Me.lblBankTransfer.Name = "lblBankTransfer"
            Me.lblBankTransfer.Size = New System.Drawing.Size(124, 20)
            Me.lblBankTransfer.TabIndex = 44
            Me.lblBankTransfer.Text = "Bank Transfer?"
            Me.lblBankTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblBankTransfer.Translatable = True
            '
            'chkBankTransfer
            '
            Me.chkBankTransfer.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkBankTransfer.AutoCheck = False
            Me.chkBankTransfer.BackColor = System.Drawing.Color.White
            Me.chkBankTransfer.BegFindValue = Nothing
            Me.chkBankTransfer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkBankTransfer.DisplayOnly = False
            Me.chkBankTransfer.EditingMode = False
            Me.chkBankTransfer.EndFindValue = Nothing
            Me.chkBankTransfer.FieldDescription = Nothing
            Me.chkBankTransfer.FieldName = Nothing
            Me.chkBankTransfer.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkBankTransfer.FindEnabled = True
            Me.chkBankTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkBankTransfer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.chkBankTransfer.ForeColor = System.Drawing.Color.Black
            Me.chkBankTransfer.IFindableControl_FindEnabled = False
            Me.chkBankTransfer.IgnoreCase = False
            Me.chkBankTransfer.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.chkBankTransfer.LinkedLabel = Nothing
            Me.chkBankTransfer.Location = New System.Drawing.Point(721, 58)
            Me.chkBankTransfer.Margin = New System.Windows.Forms.Padding(1)
            Me.chkBankTransfer.Name = "chkBankTransfer"
            Me.chkBankTransfer.NoLabel = False
            Me.chkBankTransfer.OldValue = ""
            Me.chkBankTransfer.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkBankTransfer.Size = New System.Drawing.Size(17, 16)
            Me.chkBankTransfer.TabIndex = 5
            Me.chkBankTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkBankTransfer.Translatable = False
            Me.chkBankTransfer.UseVisualStyleBackColor = False
            '
            'PayrollDetailEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.ClientSize = New System.Drawing.Size(1381, 715)
            Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
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
        Friend WithEvents cboEmployeeIdNo As Libraries.CBaseControlsLibrary.AtmComboBox
        Friend WithEvents DataGridViewEarnings As Libraries.CBaseControlsLibrary.CtDataGridView
        Friend WithEvents bsEarnings As BindingSource
        Friend WithEvents bsDeductions As BindingSource
        Friend WithEvents DataGridViewDeductions As Libraries.CBaseControlsLibrary.CtDataGridView
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