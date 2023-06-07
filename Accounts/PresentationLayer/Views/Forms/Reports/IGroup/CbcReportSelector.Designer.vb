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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewReportFiles = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.InvoiceNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RunTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SequenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.DataGridViewReportFiles,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'DataGridViewReportFiles
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewReportFiles.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewReportFiles.BegFindValue = Nothing
        Me.DataGridViewReportFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewReportFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumber, Me.RunTime, Me.SequenceNo})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewReportFiles.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewReportFiles.DgvFooter = Nothing
        Me.DataGridViewReportFiles.DisplayOnly = false
        Me.DataGridViewReportFiles.Ea = Nothing
        Me.DataGridViewReportFiles.EditingMode = false
        Me.DataGridViewReportFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewReportFiles.EndFindValue = Nothing
        Me.DataGridViewReportFiles.FieldDescription = Nothing
        Me.DataGridViewReportFiles.FieldName = Nothing
        Me.DataGridViewReportFiles.FieldsDictionary = Nothing
        Me.DataGridViewReportFiles.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewReportFiles.FindEnabled = false
        Me.DataGridViewReportFiles.FirstRowDeletionEnabled = true
        Me.DataGridViewReportFiles.FirstRowInsertionEnabled = true
        Me.DataGridViewReportFiles.IgnoreCase = false
        Me.DataGridViewReportFiles.IsDirty = false
        Me.DataGridViewReportFiles.Location = New System.Drawing.Point(12, 31)
        Me.DataGridViewReportFiles.Name = "DataGridViewReportFiles"
        Me.DataGridViewReportFiles.ReadOnly = true
        Me.DataGridViewReportFiles.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewReportFiles.SecurityKey = ""
        Me.DataGridViewReportFiles.SequenceColumn = "dgvSequence"
        Me.DataGridViewReportFiles.SequenceFieldName = "Sequence"
        Me.DataGridViewReportFiles.ShowFooter = False
        Me.DataGridViewReportFiles.Size = New System.Drawing.Size(444, 332)
        Me.DataGridViewReportFiles.TabIndex = 0
        Me.DataGridViewReportFiles.Translatable = true
        '
        'InvoiceNumber
        '
        Me.InvoiceNumber.HeaderText = "Invoice Number"
        Me.InvoiceNumber.Name = "InvoiceNumber"
        Me.InvoiceNumber.ReadOnly = true
        '
        'RunTime
        '
        Me.RunTime.HeaderText = "Run Date & Time"
        Me.RunTime.Name = "RunTime"
        Me.RunTime.ReadOnly = true
        Me.RunTime.Width = 200
        '
        'SequenceNo
        '
        Me.SequenceNo.HeaderText = "Sequence No."
        Me.SequenceNo.Name = "SequenceNo"
        Me.SequenceNo.ReadOnly = true
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(10, 10)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(295, 17)
        Me.CLabel1.TabIndex = 1
        Me.CLabel1.Text = "Please select the result you want to generate!"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = true
        '
        'btnOk
        '
        Me.btnOk.DesignerSelected = false
        Me.btnOk.ImageIndex = 0
        Me.btnOk.Location = New System.Drawing.Point(109, 382)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.OriginalImageName = Nothing
        Me.btnOk.SecurityKey = ""
        Me.btnOk.Size = New System.Drawing.Size(90, 25)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DesignerSelected = true
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.Location = New System.Drawing.Point(241, 382)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.OriginalImageName = Nothing
        Me.btnCancel.SecurityKey = ""
        Me.btnCancel.Size = New System.Drawing.Size(90, 25)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'CbcReportSelector
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(470, 419)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.DataGridViewReportFiles)
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
    Friend WithEvents InvoiceNumber As DataGridViewTextBoxColumn
    Friend WithEvents RunTime As DataGridViewTextBoxColumn
    Friend WithEvents SequenceNo As DataGridViewTextBoxColumn
End Class
