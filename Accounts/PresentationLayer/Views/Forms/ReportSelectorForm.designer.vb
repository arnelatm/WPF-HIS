Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ReportSelectorForm
        Inherits DFormBasic

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
            Me.dgvReportGroupIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
            Me.DataGridViewReportList.Location = New System.Drawing.Point(12, 296)
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
            Me.DataGridViewReportList.Size = New System.Drawing.Size(476, 234)
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
            Me.DataGridViewReportGroupList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvReportGroupIdNo, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11})
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
            Me.DataGridViewReportGroupList.Location = New System.Drawing.Point(12, 56)
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
            Me.DataGridViewReportGroupList.Size = New System.Drawing.Size(476, 234)
            Me.DataGridViewReportGroupList.TabIndex = 12
            Me.DataGridViewReportGroupList.Translatable = True
            '
            'bsReportGroupList
            '
            Me.bsReportGroupList.DataSource = GetType(AATM.Common.PresentationLayer.Models.ReportGroupModel)
            '
            'dgvReportGroupIdNo
            '
            Me.dgvReportGroupIdNo.DataPropertyName = "IdNo"
            Me.dgvReportGroupIdNo.HeaderText = "IdNo"
            Me.dgvReportGroupIdNo.MinimumWidth = 6
            Me.dgvReportGroupIdNo.Name = "dgvReportGroupIdNo"
            Me.dgvReportGroupIdNo.ReadOnly = True
            Me.dgvReportGroupIdNo.Visible = False
            Me.dgvReportGroupIdNo.Width = 125
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.DataPropertyName = "ReportGroupCode"
            Me.DataGridViewTextBoxColumn9.HeaderText = "Report Group Code"
            Me.DataGridViewTextBoxColumn9.MinimumWidth = 6
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            Me.DataGridViewTextBoxColumn9.ReadOnly = True
            Me.DataGridViewTextBoxColumn9.Visible = False
            Me.DataGridViewTextBoxColumn9.Width = 125
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn10.DataPropertyName = "ReportGroupName"
            Me.DataGridViewTextBoxColumn10.HeaderText = "Report Group Name"
            Me.DataGridViewTextBoxColumn10.MinimumWidth = 6
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            Me.DataGridViewTextBoxColumn10.ReadOnly = True
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.DataPropertyName = "ReportGroupNameAra"
            Me.DataGridViewTextBoxColumn11.HeaderText = "Report Group Name Arabic"
            Me.DataGridViewTextBoxColumn11.MinimumWidth = 6
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            Me.DataGridViewTextBoxColumn11.ReadOnly = True
            Me.DataGridViewTextBoxColumn11.Visible = False
            Me.DataGridViewTextBoxColumn11.Width = 125
            '
            'ReportSelectorForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(504, 549)
            Me.Controls.Add(Me.DataGridViewReportGroupList)
            Me.Controls.Add(Me.DataGridViewReportList)
            Me.FormCulture = New System.Globalization.CultureInfo("en-GB")
            Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.MinimumSize = New System.Drawing.Size(300, 588)
            Me.Name = "ReportSelectorForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.RightToLeftDisplay = "False"
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
        Friend WithEvents ReportGroupCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportGroupNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReportGroupNameAraDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents dgvReportGroupIdNo As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    End Class
End Namespace