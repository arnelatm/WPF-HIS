Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ReportSelectorForm2
        Inherits CFormBase

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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSelectorForm))
        Me.DataGridViewReportList = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.ReportName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.bsReportList = New System.Windows.Forms.BindingSource(Me.components)
        Me.CTabControl1 = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CListBox1 = New AATM.Libraries.CBaseControlsLibrary.CListBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblReportName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CCustomDateTimePicker1 = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CCustomDateTimePicker2 = New AATM.Libraries.CBaseControlsLibrary.CCustomDateTimePicker()
        Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewReportList,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsReportList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CTabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        Me.FlowLayoutPanel1.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
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
        'DataGridViewReportList
        '
        Me.DataGridViewReportList.AllowUserToAddRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewReportList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewReportList.AutoGenerateColumns = false
        Me.DataGridViewReportList.BegFindValue = Nothing
        Me.DataGridViewReportList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewReportList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridViewReportList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewReportList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReportName, Me.dgvIdNo})
        Me.DataGridViewReportList.DataSource = Me.bsReportList
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewReportList.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewReportList.DgvFooter = Nothing
        Me.DataGridViewReportList.DisplayOnly = true
        Me.DataGridViewReportList.Ea = Nothing
        Me.DataGridViewReportList.EditingMode = false
        Me.DataGridViewReportList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewReportList.EndFindValue = Nothing
        Me.DataGridViewReportList.FieldDescription = Nothing
        Me.DataGridViewReportList.FieldName = Nothing
        Me.DataGridViewReportList.FieldsDictionary = Nothing
        Me.DataGridViewReportList.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewReportList.FindEnabled = false
        Me.DataGridViewReportList.FirstRowDeletionEnabled = true
        Me.DataGridViewReportList.FirstRowInsertionEnabled = true
        Me.DataGridViewReportList.IgnoreCase = false
        Me.DataGridViewReportList.IsDirty = false
        Me.DataGridViewReportList.Location = New System.Drawing.Point(367, 13)
        Me.DataGridViewReportList.Name = "DataGridViewReportList"
        Me.DataGridViewReportList.ReadOnly = true
        Me.DataGridViewReportList.RowHeadersVisible = false
        Me.DataGridViewReportList.RowHeadersWidth = 4
        Me.DataGridViewReportList.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewReportList.SecurityKey = ""
        Me.DataGridViewReportList.SequenceColumn = "dgvSequence"
        Me.DataGridViewReportList.SequenceFieldName = "Sequence"
        Me.DataGridViewReportList.ShowFooter = false
        Me.DataGridViewReportList.ShowInsertColumnWhenEditing = false
        Me.DataGridViewReportList.Size = New System.Drawing.Size(362, 475)
        Me.DataGridViewReportList.TabIndex = 11
        Me.DataGridViewReportList.Translatable = true
        '
        'ReportName
        '
        Me.ReportName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ReportName.DataPropertyName = "ReportName"
        Me.ReportName.HeaderText = "Report Name"
        Me.ReportName.Name = "ReportName"
        Me.ReportName.ReadOnly = true
        '
        'dgvIdNo
        '
        Me.dgvIdNo.BegFindValue = Nothing
        Me.dgvIdNo.DataPropertyName = "IdNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIdNo.EditingMode = false
        Me.dgvIdNo.EndFindValue = Nothing
        Me.dgvIdNo.FieldDescription = Nothing
        Me.dgvIdNo.FieldName = Nothing
        Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.dgvIdNo.FindEnabled = false
        Me.dgvIdNo.HeaderText = "IdNo"
        Me.dgvIdNo.IgnoreCase = false
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = true
        Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.dgvIdNo.Translatable = false
        Me.dgvIdNo.Visible = false
        Me.dgvIdNo.Width = 50
        '
        'bsReportList
        '
        Me.bsReportList.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.ReportModel)
        '
        'CTabControl1
        '
        Me.CTabControl1.Controls.Add(Me.TabPage1)
        Me.CTabControl1.Controls.Add(Me.TabPage2)
        Me.CTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTabControl1.Location = New System.Drawing.Point(0, 53)
        Me.CTabControl1.Name = "CTabControl1"
        Me.CTabControl1.SelectedIndex = 0
        Me.CTabControl1.Size = New System.Drawing.Size(984, 510)
        Me.CTabControl1.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridViewReportList)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(976, 484)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(976, 484)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.CListBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.SplitContainer1.Panel2.Controls.Add(Me.FlowLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(970, 478)
        Me.SplitContainer1.SplitterDistance = 469
        Me.SplitContainer1.TabIndex = 0
        '
        'CListBox1
        '
        Me.CListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CListBox1.FormattingEnabled = true
        Me.CListBox1.Location = New System.Drawing.Point(0, 0)
        Me.CListBox1.Name = "CListBox1"
        Me.CListBox1.Size = New System.Drawing.Size(469, 478)
        Me.CListBox1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.TableLayoutPanel1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(497, 478)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = true
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblReportName, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CCustomDateTimePicker1, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CCustomDateTimePicker2, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 0, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(464, 137)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.CLabel1, 4)
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.CLabel1.Location = New System.Drawing.Point(1, 1)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(462, 32)
        Me.CLabel1.TabIndex = 0
        Me.CLabel1.Text = "RECEPTION REPORTS"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CLabel1.Translatable = true
        '
        'CLabel2
        '
        Me.CLabel2.AutoSize = true
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(1, 35)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(114, 17)
        Me.CLabel2.TabIndex = 1
        Me.CLabel2.Text = "Selected Report:"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = true
        '
        'lblReportName
        '
        Me.lblReportName.AutoSize = true
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblReportName, 4)
        Me.lblReportName.DisplayOnly = true
        Me.lblReportName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblReportName.EditingMode = false
        Me.lblReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblReportName.Location = New System.Drawing.Point(1, 54)
        Me.lblReportName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblReportName.Name = "lblReportName"
        Me.lblReportName.Size = New System.Drawing.Size(462, 17)
        Me.lblReportName.TabIndex = 2
        Me.lblReportName.Text = "Report Name"
        Me.lblReportName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblReportName.Translatable = true
        '
        'CLabel3
        '
        Me.CLabel3.AutoSize = true
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(1, 73)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(76, 17)
        Me.CLabel3.TabIndex = 3
        Me.CLabel3.Text = "Start Date:"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel3.Translatable = true
        '
        'CLabel4
        '
        Me.CLabel4.AutoSize = true
        Me.CLabel4.DisplayOnly = true
        Me.CLabel4.EditingMode = false
        Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel4.Location = New System.Drawing.Point(233, 73)
        Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel4.Name = "CLabel4"
        Me.CLabel4.Size = New System.Drawing.Size(71, 17)
        Me.CLabel4.TabIndex = 4
        Me.CLabel4.Text = "End Date:"
        Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel4.Translatable = true
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
        Me.CCustomDateTimePicker1.Location = New System.Drawing.Point(117, 73)
        Me.CCustomDateTimePicker1.Margin = New System.Windows.Forms.Padding(1)
        Me.CCustomDateTimePicker1.Name = "CCustomDateTimePicker1"
        Me.CCustomDateTimePicker1.ReadOnlyDp = false
        Me.CCustomDateTimePicker1.SecurityKey = Nothing
        Me.CCustomDateTimePicker1.ShowLongDate = false
        Me.CCustomDateTimePicker1.ShowTime = false
        Me.CCustomDateTimePicker1.Size = New System.Drawing.Size(109, 23)
        Me.CCustomDateTimePicker1.TabIndex = 5
        Me.CCustomDateTimePicker1.TargetCalendar = CType(resources.GetObject("CCustomDateTimePicker1.TargetCalendar"),System.Globalization.Calendar)
        Me.CCustomDateTimePicker1.Translatable = false
        Me.CCustomDateTimePicker1.Value = Nothing
        Me.CCustomDateTimePicker1.ValueIsMandatory = false
        Me.CCustomDateTimePicker1.ValueIsNullable = false
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
        Me.CCustomDateTimePicker2.Location = New System.Drawing.Point(349, 73)
        Me.CCustomDateTimePicker2.Margin = New System.Windows.Forms.Padding(1)
        Me.CCustomDateTimePicker2.Name = "CCustomDateTimePicker2"
        Me.CCustomDateTimePicker2.ReadOnlyDp = false
        Me.CCustomDateTimePicker2.SecurityKey = Nothing
        Me.CCustomDateTimePicker2.ShowLongDate = false
        Me.CCustomDateTimePicker2.ShowTime = false
        Me.CCustomDateTimePicker2.Size = New System.Drawing.Size(111, 23)
        Me.CCustomDateTimePicker2.TabIndex = 6
        Me.CCustomDateTimePicker2.TargetCalendar = CType(resources.GetObject("CCustomDateTimePicker2.TargetCalendar"),System.Globalization.Calendar)
        Me.CCustomDateTimePicker2.Translatable = false
        Me.CCustomDateTimePicker2.Value = Nothing
        Me.CCustomDateTimePicker2.ValueIsMandatory = false
        Me.CCustomDateTimePicker2.ValueIsNullable = false
        '
        'CLabel5
        '
        Me.CLabel5.AutoSize = true
        Me.CLabel5.DisplayOnly = true
        Me.CLabel5.EditingMode = false
        Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel5.Location = New System.Drawing.Point(1, 98)
        Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel5.Name = "CLabel5"
        Me.CLabel5.Size = New System.Drawing.Size(54, 17)
        Me.CLabel5.TabIndex = 7
        Me.CLabel5.Text = "Doctor:"
        Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel5.Translatable = true
        '
        'ReportSelectorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
        Me.ClientSize = New System.Drawing.Size(984, 563)
        Me.Controls.Add(Me.CTabControl1)
        Me.MinimumSize = New System.Drawing.Size(300, 590)
        Me.Name = "ReportSelectorForm"
        Me.Text = "Report Selector"
        Me.Controls.SetChildIndex(Me.CTabControl1, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewReportList,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsReportList,System.ComponentModel.ISupportInitialize).EndInit
        Me.CTabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage2.ResumeLayout(false)
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.FlowLayoutPanel1.ResumeLayout(false)
        Me.FlowLayoutPanel1.PerformLayout
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents bsReportList As Windows.Forms.BindingSource
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents EmployeeNameDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents NationalIdNoDataGridViewTextBoxColumn As CDgvTextColumn
        Friend WithEvents PictureDataGridViewImageColumn As DataGridViewImageColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
        Friend WithEvents DataGridViewReportList As CDataGridView
        Friend WithEvents ReportName As DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As CDgvTextColumn
        Friend WithEvents CTabControl1 As CTabControl
        Friend WithEvents TabPage1 As TabPage
        Friend WithEvents TabPage2 As TabPage
        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents CListBox1 As CListBox
        Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents lblReportName As CLabel
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents CCustomDateTimePicker1 As CCustomDateTimePicker
        Friend WithEvents CCustomDateTimePicker2 As CCustomDateTimePicker
        Friend WithEvents CLabel5 As CLabel
    End Class
End Namespace