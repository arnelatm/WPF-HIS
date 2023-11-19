<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CbcReportSelector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewReportFiles = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.InvoiceNumber = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.RunTime = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        Me.SequenceNo = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
        CType(Me.DataGridViewReportFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewReportFiles
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DataGridViewReportFiles.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewReportFiles.BegFindValue = Nothing
        Me.DataGridViewReportFiles.Cached = False
        Me.DataGridViewReportFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewReportFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumber, Me.RunTime, Me.SequenceNo})
        Me.DataGridViewReportFiles.DataFilter = Nothing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewReportFiles.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewReportFiles.DgvFooter = Nothing
        Me.DataGridViewReportFiles.DisplayOnly = False
        Me.DataGridViewReportFiles.Ea = Nothing
        Me.DataGridViewReportFiles.EditingMode = False
        Me.DataGridViewReportFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewReportFiles.EndFindValue = Nothing
        Me.DataGridViewReportFiles.FieldDescription = Nothing
        Me.DataGridViewReportFiles.FieldName = Nothing
        Me.DataGridViewReportFiles.FieldsDictionary = Nothing
        Me.DataGridViewReportFiles.FindColumnNo = CType(0, Short)
        Me.DataGridViewReportFiles.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewReportFiles.FindEnabled = False
        Me.DataGridViewReportFiles.FirstRowDeletionEnabled = True
        Me.DataGridViewReportFiles.FirstRowInsertionEnabled = True
        Me.DataGridViewReportFiles.IgnoreCase = False
        Me.DataGridViewReportFiles.IsDirty = False
        Me.DataGridViewReportFiles.Location = New System.Drawing.Point(16, 38)
        Me.DataGridViewReportFiles.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewReportFiles.Name = "DataGridViewReportFiles"
        Me.DataGridViewReportFiles.ReadOnly = True
        Me.DataGridViewReportFiles.RowHeadersWidth = 51
        Me.DataGridViewReportFiles.Searchable = True
        Me.DataGridViewReportFiles.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewReportFiles.SecurityKey = ""
        Me.DataGridViewReportFiles.SequenceColumn = "dgvSequence"
        Me.DataGridViewReportFiles.SequenceFieldName = "Sequence"
        Me.DataGridViewReportFiles.ShowFooter = False
        Me.DataGridViewReportFiles.Size = New System.Drawing.Size(592, 409)
        Me.DataGridViewReportFiles.TabIndex = 0
        Me.DataGridViewReportFiles.Translatable = True
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = True
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = True
        Me.CLabel1.EditingMode = False
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel1.Location = New System.Drawing.Point(13, 12)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(350, 20)
        Me.CLabel1.TabIndex = 1
        Me.CLabel1.Text = "Please select the result you want to generate!"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = True
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = False
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(145, 470)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(120, 31)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(321, 470)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(120, 31)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'InvoiceNumber
        '
        Me.InvoiceNumber.BegFindValue = Nothing
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.InvoiceNumber.DefaultCellStyle = DataGridViewCellStyle2
        Me.InvoiceNumber.EditingMode = False
        Me.InvoiceNumber.EndFindValue = Nothing
        Me.InvoiceNumber.FieldDescription = Nothing
        Me.InvoiceNumber.FieldName = Nothing
        Me.InvoiceNumber.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.InvoiceNumber.FindEnabled = False
        Me.InvoiceNumber.HeaderText = "Invoice Number"
        Me.InvoiceNumber.IgnoreCase = False
        Me.InvoiceNumber.MinimumWidth = 6
        Me.InvoiceNumber.Name = "InvoiceNumber"
        Me.InvoiceNumber.ReadOnly = True
        Me.InvoiceNumber.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InvoiceNumber.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.InvoiceNumber.Translatable = False
        Me.InvoiceNumber.Width = 125
        '
        'RunTime
        '
        Me.RunTime.BegFindValue = Nothing
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.RunTime.DefaultCellStyle = DataGridViewCellStyle3
        Me.RunTime.EditingMode = False
        Me.RunTime.EndFindValue = Nothing
        Me.RunTime.FieldDescription = Nothing
        Me.RunTime.FieldName = Nothing
        Me.RunTime.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.RunTime.FindEnabled = False
        Me.RunTime.HeaderText = "Run Date & Time"
        Me.RunTime.IgnoreCase = False
        Me.RunTime.MinimumWidth = 6
        Me.RunTime.Name = "RunTime"
        Me.RunTime.ReadOnly = True
        Me.RunTime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RunTime.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.RunTime.Translatable = False
        Me.RunTime.Width = 200
        '
        'SequenceNo
        '
        Me.SequenceNo.BegFindValue = Nothing
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.SequenceNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.SequenceNo.EditingMode = False
        Me.SequenceNo.EndFindValue = Nothing
        Me.SequenceNo.FieldDescription = Nothing
        Me.SequenceNo.FieldName = Nothing
        Me.SequenceNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.SequenceNo.FindEnabled = False
        Me.SequenceNo.HeaderText = "Sequence No."
        Me.SequenceNo.IgnoreCase = False
        Me.SequenceNo.MinimumWidth = 6
        Me.SequenceNo.Name = "SequenceNo"
        Me.SequenceNo.ReadOnly = True
        Me.SequenceNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SequenceNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.SequenceNo.Translatable = False
        Me.SequenceNo.Width = 125
        '
        'CbcReportSelector
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(627, 516)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.DataGridViewReportFiles)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CbcReportSelector"
        Me.Text = "Cbc Report Selector"
        CType(Me.DataGridViewReportFiles,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents DataGridViewReportFiles As Libraries.CBaseControlsLibrary.CDataGridView
    Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
    Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
    Friend WithEvents InvoiceNumber As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents RunTime As Libraries.CBaseControlsLibrary.CDgvTextColumn
    Friend WithEvents SequenceNo As Libraries.CBaseControlsLibrary.CDgvTextColumn
End Class
