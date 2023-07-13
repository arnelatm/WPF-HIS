Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports Microsoft.VisualBasic.CompilerServices


<DesignerGenerated()>
Partial Class DurationTableManager
    Inherits BfMain

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtOriginal = New System.Windows.Forms.TextBox()
        Me.txtTranslation = New System.Windows.Forms.TextBox()
        Me.cmdGridEdit = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewDuration = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.txtDurationCode = New System.Windows.Forms.TextBox()
        Me.txtIdNo = New System.Windows.Forms.TextBox()
        Me.dgvDurationCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDurationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDurationNameArabic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsDuration = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtOriginal
        '
        Me.txtOriginal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtOriginal.Enabled = False
        Me.txtOriginal.Location = New System.Drawing.Point(176, 403)
        Me.txtOriginal.Multiline = True
        Me.txtOriginal.Name = "txtOriginal"
        Me.txtOriginal.Size = New System.Drawing.Size(375, 52)
        Me.txtOriginal.TabIndex = 10
        Me.txtOriginal.Text = "Dose in English"
        '
        'txtTranslation
        '
        Me.txtTranslation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTranslation.Location = New System.Drawing.Point(557, 403)
        Me.txtTranslation.Multiline = True
        Me.txtTranslation.Name = "txtTranslation"
        Me.txtTranslation.Size = New System.Drawing.Size(428, 52)
        Me.txtTranslation.TabIndex = 11
        Me.txtTranslation.Text = "Arabic Translation"
        '
        'cmdGridEdit
        '
        Me.cmdGridEdit.Location = New System.Drawing.Point(12, 208)
        Me.cmdGridEdit.Name = "cmdGridEdit"
        Me.cmdGridEdit.Size = New System.Drawing.Size(75, 64)
        Me.cmdGridEdit.TabIndex = 25
        Me.cmdGridEdit.Text = "Full Edit on Grid with Auto Save"
        Me.cmdGridEdit.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(12, 277)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 37)
        Me.cmdEdit.TabIndex = 26
        Me.cmdEdit.Text = "&Edit a single cell"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 320)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 27
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Location = New System.Drawing.Point(12, 349)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 28
        Me.cmdDelete.Text = "&Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(12, 378)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 29
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'CLabel2
        '
        Me.CLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CLabel2.AutoSize = True
        Me.CLabel2.DisplayOnly = True
        Me.CLabel2.EditingMode = False
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel2.Location = New System.Drawing.Point(813, 12)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(0, 17)
        Me.CLabel2.TabIndex = 24
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = True
        '
        'DataGridViewDuration
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewDuration.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewDuration.AutoGenerateColumns = False
        Me.DataGridViewDuration.BegFindValue = Nothing
        Me.DataGridViewDuration.Cached = False
        Me.DataGridViewDuration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDuration.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvDurationCode, Me.dgvDurationName, Me.dgvDurationNameArabic, Me.dgvIdNo})
        Me.DataGridViewDuration.DataFilter = Nothing
        Me.DataGridViewDuration.DataSource = Me.bsDuration
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDuration.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewDuration.DgvFooter = Nothing
        Me.DataGridViewDuration.DisplayOnly = False
        Me.DataGridViewDuration.Ea = Nothing
        Me.DataGridViewDuration.EditingMode = False
        Me.DataGridViewDuration.EndFindValue = Nothing
        Me.DataGridViewDuration.FieldDescription = Nothing
        Me.DataGridViewDuration.FieldName = Nothing
        Me.DataGridViewDuration.FieldsDictionary = Nothing
        Me.DataGridViewDuration.FindColumnNo = CType(0, Short)
        Me.DataGridViewDuration.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewDuration.FindEnabled = False
        Me.DataGridViewDuration.FirstRowDeletionEnabled = True
        Me.DataGridViewDuration.FirstRowInsertionEnabled = True
        Me.DataGridViewDuration.IgnoreCase = False
        Me.DataGridViewDuration.IsDirty = False
        Me.DataGridViewDuration.Location = New System.Drawing.Point(90, 12)
        Me.DataGridViewDuration.Name = "DataGridViewDuration"
        Me.DataGridViewDuration.Searchable = True
        Me.DataGridViewDuration.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewDuration.SecurityKey = ""
        Me.DataGridViewDuration.SequenceColumn = "dgvSequence"
        Me.DataGridViewDuration.SequenceFieldName = "Sequence"
        Me.DataGridViewDuration.ShowFooter = False
        Me.DataGridViewDuration.Size = New System.Drawing.Size(895, 385)
        Me.DataGridViewDuration.TabIndex = 30
        Me.DataGridViewDuration.Translatable = True
        '
        'txtDurationCode
        '
        Me.txtDurationCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDurationCode.Enabled = False
        Me.txtDurationCode.Location = New System.Drawing.Point(133, 403)
        Me.txtDurationCode.Multiline = True
        Me.txtDurationCode.Name = "txtDurationCode"
        Me.txtDurationCode.Size = New System.Drawing.Size(40, 52)
        Me.txtDurationCode.TabIndex = 31
        '
        'txtIdNo
        '
        Me.txtIdNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtIdNo.Enabled = False
        Me.txtIdNo.Location = New System.Drawing.Point(90, 403)
        Me.txtIdNo.Multiline = True
        Me.txtIdNo.Name = "txtIdNo"
        Me.txtIdNo.Size = New System.Drawing.Size(38, 52)
        Me.txtIdNo.TabIndex = 32
        '
        'dgvDurationCode
        '
        Me.dgvDurationCode.DataPropertyName = "DurationCode"
        Me.dgvDurationCode.HeaderText = "Duration Code"
        Me.dgvDurationCode.Name = "dgvDurationCode"
        Me.dgvDurationCode.ReadOnly = True
        Me.dgvDurationCode.Width = 45
        '
        'dgvDurationName
        '
        Me.dgvDurationName.DataPropertyName = "DurationName"
        Me.dgvDurationName.HeaderText = "Duration Name"
        Me.dgvDurationName.Name = "dgvDurationName"
        Me.dgvDurationName.ReadOnly = True
        Me.dgvDurationName.Width = 375
        '
        'dgvDurationNameArabic
        '
        Me.dgvDurationNameArabic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvDurationNameArabic.DataPropertyName = "DurationNameARa"
        Me.dgvDurationNameArabic.HeaderText = "Duration Name Arabic"
        Me.dgvDurationNameArabic.Name = "dgvDurationNameArabic"
        Me.dgvDurationNameArabic.ReadOnly = True
        '
        'dgvIdNo
        '
        Me.dgvIdNo.DataPropertyName = "IdNo"
        Me.dgvIdNo.HeaderText = "IdNo"
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = True
        Me.dgvIdNo.Visible = False
        '
        'bsDuration
        '
        Me.bsDuration.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DurationModel)
        '
        'DurationTableManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 461)
        Me.Controls.Add(Me.txtIdNo)
        Me.Controls.Add(Me.txtDurationCode)
        Me.Controls.Add(Me.DataGridViewDuration)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdGridEdit)
        Me.Controls.Add(Me.CLabel2)
        Me.Controls.Add(Me.txtTranslation)
        Me.Controls.Add(Me.txtOriginal)
        Me.Name = "DurationTableManager"
        Me.Text = "Translation Table Manager"
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewDuration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsDuration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOriginal As TextBox
    Friend WithEvents txtTranslation As TextBox
    Friend WithEvents cmdGridEdit As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents CLabel2 As CLabel
    Friend WithEvents ISPDATADataSet As ISPDATADataSet
    Friend WithEvents DurationNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DurationNameARaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewDuration As CDataGridView
    Friend WithEvents bsDuration As BindingSource
    Friend WithEvents txtDurationCode As TextBox
    Friend WithEvents txtIdNo As TextBox
    Friend WithEvents dgvDurationCode As DataGridViewTextBoxColumn
    Friend WithEvents dgvDurationName As DataGridViewTextBoxColumn
    Friend WithEvents dgvDurationNameArabic As DataGridViewTextBoxColumn
    Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
End Class