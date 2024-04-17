Imports AATM.Common.PresentationLayer.Models
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
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSelectorForm2))
            Me.DataGridViewReportList = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.ReportName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.dgvIdNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.bsReportList = New System.Windows.Forms.BindingSource(Me.components)
            Me.CtDataGridView1 = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.bsReportGroupList = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewReportList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsReportList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CtDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.DataGridViewReportList.Location = New System.Drawing.Point(20, 227)
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
            Me.DataGridViewReportList.Size = New System.Drawing.Size(585, 324)
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
            'CtDataGridView1
            '
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.NavajoWhite
            Me.CtDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
            Me.CtDataGridView1.BegFindValue = Nothing
            Me.CtDataGridView1.Cached = False
            Me.CtDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.CtDataGridView1.DataFilter = Nothing
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.6!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.CtDataGridView1.DefaultCellStyle = DataGridViewCellStyle5
            Me.CtDataGridView1.DgvFooter = Nothing
            Me.CtDataGridView1.DisplayOnly = False
            Me.CtDataGridView1.Ea = Nothing
            Me.CtDataGridView1.EditingMode = False
            Me.CtDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.CtDataGridView1.EndFindValue = Nothing
            Me.CtDataGridView1.FieldDescription = Nothing
            Me.CtDataGridView1.FieldName = Nothing
            Me.CtDataGridView1.FieldsDictionary = Nothing
            Me.CtDataGridView1.FindColumnNo = CType(0, Short)
            Me.CtDataGridView1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CtDataGridView1.FindEnabled = False
            Me.CtDataGridView1.FirstRowDeletionEnabled = True
            Me.CtDataGridView1.FirstRowInsertionEnabled = True
            Me.CtDataGridView1.IgnoreCase = False
            Me.CtDataGridView1.IsDirty = False
            Me.CtDataGridView1.Location = New System.Drawing.Point(20, 60)
            Me.CtDataGridView1.Name = "CtDataGridView1"
            Me.CtDataGridView1.OldCellValue = Nothing
            Me.CtDataGridView1.RowHeadersWidth = 51
            Me.CtDataGridView1.Searchable = True
            Me.CtDataGridView1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CtDataGridView1.SecurityKey = ""
            Me.CtDataGridView1.SequenceColumn = "dgvSequence"
            Me.CtDataGridView1.SequenceFieldName = "Sequence"
            Me.CtDataGridView1.ShowFooter = False
            Me.CtDataGridView1.Size = New System.Drawing.Size(585, 150)
            Me.CtDataGridView1.TabIndex = 12
            Me.CtDataGridView1.Translatable = True
            '
            'bsReportGroupList
            '
            Me.bsReportGroupList.DataSource = GetType(AATM.Common.PresentationLayer.Models.ReportModel)
            '
            'ReportSelectorForm2
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(619, 563)
            Me.Controls.Add(Me.CtDataGridView1)
            Me.Controls.Add(Me.DataGridViewReportList)
            Me.MinimumSize = New System.Drawing.Size(300, 590)
            Me.Name = "ReportSelectorForm2"
            Me.Text = "Report Selector"
            Me.Controls.SetChildIndex(Me.DataGridViewReportList, 0)
            Me.Controls.SetChildIndex(Me.CtDataGridView1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridViewReportList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsReportList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CtDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents DataGridViewReportList As CtDataGridView
        Friend WithEvents ReportName As DataGridViewTextBoxColumn
        Friend WithEvents dgvIdNo As CDgvTextColumn
        Friend WithEvents CtDataGridView1 As CtDataGridView
        Friend WithEvents bsReportGroupList As BindingSource
    End Class
End Namespace