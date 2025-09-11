Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Presentation.Forms
Imports Microsoft.VisualBasic.CompilerServices


<DesignerGenerated()>
Partial Class DosageTableManager
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtOriginal = New System.Windows.Forms.TextBox()
        Me.txtTranslation = New System.Windows.Forms.TextBox()
        Me.btnGridEdit = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewDosageMaster = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
        Me.dgvDosageCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDosageName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDosageNameArabic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIdNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsDosageMaster = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtDosageCode = New System.Windows.Forms.TextBox()
        Me.txtIdNo = New System.Windows.Forms.TextBox()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewDosageMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsDosageMaster, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'btnGridEdit
        '
        Me.btnGridEdit.Location = New System.Drawing.Point(12, 208)
        Me.btnGridEdit.Name = "btnGridEdit"
        Me.btnGridEdit.Size = New System.Drawing.Size(75, 64)
        Me.btnGridEdit.TabIndex = 25
        Me.btnGridEdit.Text = "Full Edit on Grid with Auto Save"
        Me.btnGridEdit.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(12, 277)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 37)
        Me.btnEdit.TabIndex = 26
        Me.btnEdit.Text = "&Edit a single cell"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 320)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(12, 349)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 28
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(12, 378)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
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
        'DataGridViewDosageMaster
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewDosageMaster.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewDosageMaster.AutoGenerateColumns = False
        Me.DataGridViewDosageMaster.BegFindValue = Nothing
        Me.DataGridViewDosageMaster.Cached = False
        Me.DataGridViewDosageMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDosageMaster.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvDosageCode, Me.dgvDosageName, Me.dgvDosageNameArabic, Me.dgvIdNo})
        Me.DataGridViewDosageMaster.DataFilter = Nothing
        Me.DataGridViewDosageMaster.DataSource = Me.bsDosageMaster
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDosageMaster.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewDosageMaster.DgvFooter = Nothing
        Me.DataGridViewDosageMaster.DisplayOnly = False
        Me.DataGridViewDosageMaster.Ea = Nothing
        Me.DataGridViewDosageMaster.EditingMode = False
        Me.DataGridViewDosageMaster.EndFindValue = Nothing
        Me.DataGridViewDosageMaster.FieldDescription = Nothing
        Me.DataGridViewDosageMaster.FieldName = Nothing
        Me.DataGridViewDosageMaster.FieldsDictionary = Nothing
        Me.DataGridViewDosageMaster.FindColumnNo = CType(0, Short)
        Me.DataGridViewDosageMaster.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewDosageMaster.FindEnabled = False
        Me.DataGridViewDosageMaster.FirstRowDeletionEnabled = True
        Me.DataGridViewDosageMaster.FirstRowInsertionEnabled = True
        Me.DataGridViewDosageMaster.IgnoreCase = False
        Me.DataGridViewDosageMaster.IsDirty = False
        Me.DataGridViewDosageMaster.Location = New System.Drawing.Point(90, 12)
        Me.DataGridViewDosageMaster.Name = "DataGridViewDosageMaster"
        Me.DataGridViewDosageMaster.Searchable = True
        Me.DataGridViewDosageMaster.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewDosageMaster.SecurityKey = ""
        Me.DataGridViewDosageMaster.SequenceColumn = "dgvSequence"
        Me.DataGridViewDosageMaster.SequenceFieldName = "Sequence"
        Me.DataGridViewDosageMaster.ShowFooter = False
        Me.DataGridViewDosageMaster.Size = New System.Drawing.Size(895, 385)
        Me.DataGridViewDosageMaster.TabIndex = 30
        Me.DataGridViewDosageMaster.Translatable = True
        '
        'dgvDosageCode
        '
        Me.dgvDosageCode.DataPropertyName = "DosageMasterCode"
        Me.dgvDosageCode.HeaderText = "Dosage Code"
        Me.dgvDosageCode.Name = "dgvDosageCode"
        Me.dgvDosageCode.ReadOnly = True
        Me.dgvDosageCode.Width = 45
        '
        'dgvDosageName
        '
        Me.dgvDosageName.DataPropertyName = "DosageMasterName"
        Me.dgvDosageName.HeaderText = "Dosage Name"
        Me.dgvDosageName.Name = "dgvDosageName"
        Me.dgvDosageName.ReadOnly = True
        Me.dgvDosageName.Width = 375
        '
        'dgvDosageNameArabic
        '
        Me.dgvDosageNameArabic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvDosageNameArabic.DataPropertyName = "DosageMasterNameARa"
        Me.dgvDosageNameArabic.HeaderText = "Dosage Name Arabic"
        Me.dgvDosageNameArabic.Name = "dgvDosageNameArabic"
        Me.dgvDosageNameArabic.ReadOnly = True
        '
        'dgvIdNo
        '
        Me.dgvIdNo.DataPropertyName = "IdNo"
        Me.dgvIdNo.HeaderText = "IdNo"
        Me.dgvIdNo.Name = "dgvIdNo"
        Me.dgvIdNo.ReadOnly = True
        Me.dgvIdNo.Visible = False
        '
        'bsDosageMaster
        '
        Me.bsDosageMaster.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DosageMasterModel)
        '
        'txtDosageCode
        '
        Me.txtDosageCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDosageCode.Enabled = False
        Me.txtDosageCode.Location = New System.Drawing.Point(133, 403)
        Me.txtDosageCode.Multiline = True
        Me.txtDosageCode.Name = "txtDosageCode"
        Me.txtDosageCode.Size = New System.Drawing.Size(40, 52)
        Me.txtDosageCode.TabIndex = 31
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
        'DosageTableManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 461)
        Me.Controls.Add(Me.txtIdNo)
        Me.Controls.Add(Me.txtDosageCode)
        Me.Controls.Add(Me.DataGridViewDosageMaster)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnGridEdit)
        Me.Controls.Add(Me.CLabel2)
        Me.Controls.Add(Me.txtTranslation)
        Me.Controls.Add(Me.txtOriginal)
        Me.Name = "DosageTableManager"
        Me.Text = "Dosage Translation Manager"
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewDosageMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsDosageMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOriginal As TextBox
    Friend WithEvents txtTranslation As TextBox
    Friend WithEvents btnGridEdit As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents CLabel2 As CLabel
    Friend WithEvents ISPDATADataSet As ISPDATADataSet
    Friend WithEvents DosageMasterNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DosageMasterNameARaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewDosageMaster As CtDataGridView
    Friend WithEvents bsDosageMaster As BindingSource
    Friend WithEvents txtDosageCode As TextBox
    Friend WithEvents txtIdNo As TextBox
    Friend WithEvents dgvDosageCode As DataGridViewTextBoxColumn
    Friend WithEvents dgvDosageName As DataGridViewTextBoxColumn
    Friend WithEvents dgvDosageNameArabic As DataGridViewTextBoxColumn
    Friend WithEvents dgvIdNo As DataGridViewTextBoxColumn
End Class