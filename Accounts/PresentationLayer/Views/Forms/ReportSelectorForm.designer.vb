Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ReportSelectorForm
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
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSelectorForm))
            Me.DataGridViewReportList = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.ReportName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.bsReportList = New System.Windows.Forms.BindingSource(Me.components)
            Me.DataGridViewReportGroupList = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.bsReportGroupList = New System.Windows.Forms.BindingSource(Me.components)
            Me.ActiveDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.BranchIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DatabaseNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DateCreatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PrintJobIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.QueryFormDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.QueryFormParametersDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.QueryParametersDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReportCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReportFileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReportGroupIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReportNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReportNameAraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReportTitleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReportTitleAraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewReportList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsReportList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewReportGroupList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsReportGroupList, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridViewReportList
            '
            Me.DataGridViewReportList.AllowUserToAddRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewReportList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewReportList.AutoGenerateColumns = False
            Me.DataGridViewReportList.BegFindValue = Nothing
            Me.DataGridViewReportList.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.DataGridViewReportList.Cached = False
            Me.DataGridViewReportList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
            Me.DataGridViewReportList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewReportList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReportName, Me.dgvIdNo})
            Me.DataGridViewReportList.DataFilter = Nothing
            Me.DataGridViewReportList.DataSource = Me.bsReportList
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.6!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewReportList.DefaultCellStyle = DataGridViewCellStyle3
            Me.DataGridViewReportList.DgvFooter = Nothing
            Me.DataGridViewReportList.DisplayOnly = True
            Me.DataGridViewReportList.Ea = Nothing
            Me.DataGridViewReportList.EditingMode = False
            Me.DataGridViewReportList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewReportList.EndFindValue = Nothing
            Me.DataGridViewReportList.FieldDescription = Nothing
            Me.DataGridViewReportList.FieldName = Nothing
            Me.DataGridViewReportList.FieldsDictionary = Nothing
            Me.DataGridViewReportList.FindColumnNo = CType(0, Short)
            Me.DataGridViewReportList.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewReportList.FindEnabled = False
            Me.DataGridViewReportList.FirstRowDeletionEnabled = True
            Me.DataGridViewReportList.FirstRowInsertionEnabled = True
            Me.DataGridViewReportList.IgnoreCase = False
            Me.DataGridViewReportList.IsDirty = False
            Me.DataGridViewReportList.Location = New System.Drawing.Point(16, 364)
            Me.DataGridViewReportList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.DataGridViewReportList.Name = "DataGridViewReportList"
            Me.DataGridViewReportList.OldCellValue = Nothing
            Me.DataGridViewReportList.ReadOnly = True
            Me.DataGridViewReportList.RowHeadersVisible = False
            Me.DataGridViewReportList.RowHeadersWidth = 4
            Me.DataGridViewReportList.Searchable = True
            Me.DataGridViewReportList.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewReportList.SecurityKey = ""
            Me.DataGridViewReportList.SequenceColumn = "dgvSequence"
            Me.DataGridViewReportList.SequenceFieldName = "Sequence"
            Me.DataGridViewReportList.ShowFooter = False
            Me.DataGridViewReportList.Size = New System.Drawing.Size(635, 288)
            Me.DataGridViewReportList.TabIndex = 11
            Me.DataGridViewReportList.Translatable = True
            '
            'ReportName
            '
            Me.ReportName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.ReportName.DataPropertyName = "ReportName"
            Me.ReportName.HeaderText = "Report Name"
            Me.ReportName.MinimumWidth = 6
            Me.ReportName.Name = "ReportName"
            Me.ReportName.ReadOnly = True
            '
            'dgvIdNo
            '
            Me.dgvIdNo.BegFindValue = Nothing
            Me.dgvIdNo.DataPropertyName = "IdNo"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvIdNo.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvIdNo.EditingMode = False
            Me.dgvIdNo.EndFindValue = Nothing
            Me.dgvIdNo.FieldDescription = Nothing
            Me.dgvIdNo.FieldName = Nothing
            Me.dgvIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvIdNo.FindEnabled = False
            Me.dgvIdNo.HeaderText = "IdNo"
            Me.dgvIdNo.IgnoreCase = False
            Me.dgvIdNo.MinimumWidth = 6
            Me.dgvIdNo.Name = "dgvIdNo"
            Me.dgvIdNo.ReadOnly = True
            Me.dgvIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvIdNo.Translatable = False
            Me.dgvIdNo.Visible = False
            Me.dgvIdNo.Width = 50
            '
            'bsReportList
            '
            Me.bsReportList.DataSource = GetType(AATM.Common.PresentationLayer.Models.ReportModel)
            '
            'DataGridViewReportGroupList
            '
            Me.DataGridViewReportGroupList.AllowUserToAddRows = False
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewReportGroupList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
            Me.DataGridViewReportGroupList.AutoGenerateColumns = False
            Me.DataGridViewReportGroupList.BegFindValue = Nothing
            Me.DataGridViewReportGroupList.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.DataGridViewReportGroupList.Cached = False
            Me.DataGridViewReportGroupList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
            Me.DataGridViewReportGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewReportGroupList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ActiveDataGridViewCheckBoxColumn, Me.BranchIdNoDataGridViewTextBoxColumn, Me.DatabaseNameDataGridViewTextBoxColumn, Me.DateCreatedDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.PrintJobIdNoDataGridViewTextBoxColumn, Me.QueryFormDataGridViewTextBoxColumn, Me.QueryFormParametersDataGridViewTextBoxColumn, Me.QueryParametersDataGridViewTextBoxColumn, Me.ReportCodeDataGridViewTextBoxColumn, Me.ReportFileNameDataGridViewTextBoxColumn, Me.ReportGroupIdNoDataGridViewTextBoxColumn, Me.ReportNameDataGridViewTextBoxColumn, Me.ReportNameAraDataGridViewTextBoxColumn, Me.ReportTitleDataGridViewTextBoxColumn, Me.ReportTitleAraDataGridViewTextBoxColumn})
            Me.DataGridViewReportGroupList.DataFilter = Nothing
            Me.DataGridViewReportGroupList.DataSource = Me.bsReportGroupList
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.6!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewReportGroupList.DefaultCellStyle = DataGridViewCellStyle5
            Me.DataGridViewReportGroupList.DgvFooter = Nothing
            Me.DataGridViewReportGroupList.DisplayOnly = True
            Me.DataGridViewReportGroupList.Ea = Nothing
            Me.DataGridViewReportGroupList.EditingMode = False
            Me.DataGridViewReportGroupList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewReportGroupList.EndFindValue = Nothing
            Me.DataGridViewReportGroupList.FieldDescription = Nothing
            Me.DataGridViewReportGroupList.FieldName = Nothing
            Me.DataGridViewReportGroupList.FieldsDictionary = Nothing
            Me.DataGridViewReportGroupList.FindColumnNo = CType(0, Short)
            Me.DataGridViewReportGroupList.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewReportGroupList.FindEnabled = False
            Me.DataGridViewReportGroupList.FirstRowDeletionEnabled = True
            Me.DataGridViewReportGroupList.FirstRowInsertionEnabled = True
            Me.DataGridViewReportGroupList.IgnoreCase = False
            Me.DataGridViewReportGroupList.IsDirty = False
            Me.DataGridViewReportGroupList.Location = New System.Drawing.Point(16, 69)
            Me.DataGridViewReportGroupList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.DataGridViewReportGroupList.Name = "DataGridViewReportGroupList"
            Me.DataGridViewReportGroupList.OldCellValue = Nothing
            Me.DataGridViewReportGroupList.ReadOnly = True
            Me.DataGridViewReportGroupList.RowHeadersVisible = False
            Me.DataGridViewReportGroupList.RowHeadersWidth = 4
            Me.DataGridViewReportGroupList.Searchable = True
            Me.DataGridViewReportGroupList.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewReportGroupList.SecurityKey = ""
            Me.DataGridViewReportGroupList.SequenceColumn = "dgvSequence"
            Me.DataGridViewReportGroupList.SequenceFieldName = "Sequence"
            Me.DataGridViewReportGroupList.ShowFooter = False
            Me.DataGridViewReportGroupList.Size = New System.Drawing.Size(635, 288)
            Me.DataGridViewReportGroupList.TabIndex = 12
            Me.DataGridViewReportGroupList.Translatable = True
            '
            'bsReportGroupList
            '
            Me.bsReportGroupList.DataSource = Me.bsReportList
            '
            'ActiveDataGridViewCheckBoxColumn
            '
            Me.ActiveDataGridViewCheckBoxColumn.DataPropertyName = "Active"
            Me.ActiveDataGridViewCheckBoxColumn.HeaderText = "Active"
            Me.ActiveDataGridViewCheckBoxColumn.MinimumWidth = 6
            Me.ActiveDataGridViewCheckBoxColumn.Name = "ActiveDataGridViewCheckBoxColumn"
            Me.ActiveDataGridViewCheckBoxColumn.ReadOnly = True
            Me.ActiveDataGridViewCheckBoxColumn.Width = 125
            '
            'BranchIdNoDataGridViewTextBoxColumn
            '
            Me.BranchIdNoDataGridViewTextBoxColumn.DataPropertyName = "BranchIdNo"
            Me.BranchIdNoDataGridViewTextBoxColumn.HeaderText = "BranchIdNo"
            Me.BranchIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.BranchIdNoDataGridViewTextBoxColumn.Name = "BranchIdNoDataGridViewTextBoxColumn"
            Me.BranchIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.BranchIdNoDataGridViewTextBoxColumn.Width = 125
            '
            'DatabaseNameDataGridViewTextBoxColumn
            '
            Me.DatabaseNameDataGridViewTextBoxColumn.DataPropertyName = "DatabaseName"
            Me.DatabaseNameDataGridViewTextBoxColumn.HeaderText = "DatabaseName"
            Me.DatabaseNameDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.DatabaseNameDataGridViewTextBoxColumn.Name = "DatabaseNameDataGridViewTextBoxColumn"
            Me.DatabaseNameDataGridViewTextBoxColumn.ReadOnly = True
            Me.DatabaseNameDataGridViewTextBoxColumn.Width = 125
            '
            'DateCreatedDataGridViewTextBoxColumn
            '
            Me.DateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated"
            Me.DateCreatedDataGridViewTextBoxColumn.HeaderText = "DateCreated"
            Me.DateCreatedDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.DateCreatedDataGridViewTextBoxColumn.Name = "DateCreatedDataGridViewTextBoxColumn"
            Me.DateCreatedDataGridViewTextBoxColumn.ReadOnly = True
            Me.DateCreatedDataGridViewTextBoxColumn.Width = 125
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn.Width = 125
            '
            'PrintJobIdNoDataGridViewTextBoxColumn
            '
            Me.PrintJobIdNoDataGridViewTextBoxColumn.DataPropertyName = "PrintJobIdNo"
            Me.PrintJobIdNoDataGridViewTextBoxColumn.HeaderText = "PrintJobIdNo"
            Me.PrintJobIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.PrintJobIdNoDataGridViewTextBoxColumn.Name = "PrintJobIdNoDataGridViewTextBoxColumn"
            Me.PrintJobIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.PrintJobIdNoDataGridViewTextBoxColumn.Width = 125
            '
            'QueryFormDataGridViewTextBoxColumn
            '
            Me.QueryFormDataGridViewTextBoxColumn.DataPropertyName = "QueryForm"
            Me.QueryFormDataGridViewTextBoxColumn.HeaderText = "QueryForm"
            Me.QueryFormDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.QueryFormDataGridViewTextBoxColumn.Name = "QueryFormDataGridViewTextBoxColumn"
            Me.QueryFormDataGridViewTextBoxColumn.ReadOnly = True
            Me.QueryFormDataGridViewTextBoxColumn.Width = 125
            '
            'QueryFormParametersDataGridViewTextBoxColumn
            '
            Me.QueryFormParametersDataGridViewTextBoxColumn.DataPropertyName = "QueryFormParameters"
            Me.QueryFormParametersDataGridViewTextBoxColumn.HeaderText = "QueryFormParameters"
            Me.QueryFormParametersDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.QueryFormParametersDataGridViewTextBoxColumn.Name = "QueryFormParametersDataGridViewTextBoxColumn"
            Me.QueryFormParametersDataGridViewTextBoxColumn.ReadOnly = True
            Me.QueryFormParametersDataGridViewTextBoxColumn.Width = 125
            '
            'QueryParametersDataGridViewTextBoxColumn
            '
            Me.QueryParametersDataGridViewTextBoxColumn.DataPropertyName = "QueryParameters"
            Me.QueryParametersDataGridViewTextBoxColumn.HeaderText = "QueryParameters"
            Me.QueryParametersDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.QueryParametersDataGridViewTextBoxColumn.Name = "QueryParametersDataGridViewTextBoxColumn"
            Me.QueryParametersDataGridViewTextBoxColumn.ReadOnly = True
            Me.QueryParametersDataGridViewTextBoxColumn.Width = 125
            '
            'ReportCodeDataGridViewTextBoxColumn
            '
            Me.ReportCodeDataGridViewTextBoxColumn.DataPropertyName = "ReportCode"
            Me.ReportCodeDataGridViewTextBoxColumn.HeaderText = "ReportCode"
            Me.ReportCodeDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.ReportCodeDataGridViewTextBoxColumn.Name = "ReportCodeDataGridViewTextBoxColumn"
            Me.ReportCodeDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReportCodeDataGridViewTextBoxColumn.Width = 125
            '
            'ReportFileNameDataGridViewTextBoxColumn
            '
            Me.ReportFileNameDataGridViewTextBoxColumn.DataPropertyName = "ReportFileName"
            Me.ReportFileNameDataGridViewTextBoxColumn.HeaderText = "ReportFileName"
            Me.ReportFileNameDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.ReportFileNameDataGridViewTextBoxColumn.Name = "ReportFileNameDataGridViewTextBoxColumn"
            Me.ReportFileNameDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReportFileNameDataGridViewTextBoxColumn.Width = 125
            '
            'ReportGroupIdNoDataGridViewTextBoxColumn
            '
            Me.ReportGroupIdNoDataGridViewTextBoxColumn.DataPropertyName = "ReportGroupIdNo"
            Me.ReportGroupIdNoDataGridViewTextBoxColumn.HeaderText = "ReportGroupIdNo"
            Me.ReportGroupIdNoDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.ReportGroupIdNoDataGridViewTextBoxColumn.Name = "ReportGroupIdNoDataGridViewTextBoxColumn"
            Me.ReportGroupIdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReportGroupIdNoDataGridViewTextBoxColumn.Width = 125
            '
            'ReportNameDataGridViewTextBoxColumn
            '
            Me.ReportNameDataGridViewTextBoxColumn.DataPropertyName = "ReportName"
            Me.ReportNameDataGridViewTextBoxColumn.HeaderText = "ReportName"
            Me.ReportNameDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.ReportNameDataGridViewTextBoxColumn.Name = "ReportNameDataGridViewTextBoxColumn"
            Me.ReportNameDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReportNameDataGridViewTextBoxColumn.Width = 125
            '
            'ReportNameAraDataGridViewTextBoxColumn
            '
            Me.ReportNameAraDataGridViewTextBoxColumn.DataPropertyName = "ReportNameAra"
            Me.ReportNameAraDataGridViewTextBoxColumn.HeaderText = "ReportNameAra"
            Me.ReportNameAraDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.ReportNameAraDataGridViewTextBoxColumn.Name = "ReportNameAraDataGridViewTextBoxColumn"
            Me.ReportNameAraDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReportNameAraDataGridViewTextBoxColumn.Width = 125
            '
            'ReportTitleDataGridViewTextBoxColumn
            '
            Me.ReportTitleDataGridViewTextBoxColumn.DataPropertyName = "ReportTitle"
            Me.ReportTitleDataGridViewTextBoxColumn.HeaderText = "ReportTitle"
            Me.ReportTitleDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.ReportTitleDataGridViewTextBoxColumn.Name = "ReportTitleDataGridViewTextBoxColumn"
            Me.ReportTitleDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReportTitleDataGridViewTextBoxColumn.Width = 125
            '
            'ReportTitleAraDataGridViewTextBoxColumn
            '
            Me.ReportTitleAraDataGridViewTextBoxColumn.DataPropertyName = "ReportTitleAra"
            Me.ReportTitleAraDataGridViewTextBoxColumn.HeaderText = "ReportTitleAra"
            Me.ReportTitleAraDataGridViewTextBoxColumn.MinimumWidth = 6
            Me.ReportTitleAraDataGridViewTextBoxColumn.Name = "ReportTitleAraDataGridViewTextBoxColumn"
            Me.ReportTitleAraDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReportTitleAraDataGridViewTextBoxColumn.Width = 125
            '
            'ReportSelectorForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(672, 668)
            Me.Controls.Add(Me.DataGridViewReportGroupList)
            Me.Controls.Add(Me.DataGridViewReportList)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.MinimumSize = New System.Drawing.Size(394, 715)
            Me.Name = "ReportSelectorForm"
            Me.Text = "Report Selector"
            Me.Controls.SetChildIndex(Me.DataGridViewReportList, 0)
            Me.Controls.SetChildIndex(Me.DataGridViewReportGroupList, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewReportList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsReportList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewReportGroupList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsReportGroupList, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsReportList As Windows.Forms.BindingSource
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CDgvTextColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
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
        Friend WithEvents DataGridViewReportList As CtDataGridView
        Friend WithEvents ReportName As DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As CDgvTextColumn
        Friend WithEvents DataGridViewReportGroupList As CtDataGridView
        Friend WithEvents bsReportGroupList As BindingSource
        Friend WithEvents dgvReportGroupIdNo As DataGridViewTextBoxColumn
        Friend WithEvents ReportGroupCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportGroupNameAraDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ActiveDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents BranchIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DatabaseNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DateCreatedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PrintJobIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents QueryFormDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents QueryFormParametersDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents QueryParametersDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportFileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportGroupIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportNameAraDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportTitleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportTitleAraDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace