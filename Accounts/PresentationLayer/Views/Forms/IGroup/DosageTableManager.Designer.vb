Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtCaption = New System.Windows.Forms.TextBox()
        Me.txtTranslation = New System.Windows.Forms.TextBox()
        Me.cmdGridEdit = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewDosageMaster = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
        Me.DosageMasterCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsDosageMaster = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewDosageMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsDosageMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCaption
        '
        Me.txtCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCaption.Enabled = False
        Me.txtCaption.Location = New System.Drawing.Point(90, 403)
        Me.txtCaption.Multiline = True
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(450, 52)
        Me.txtCaption.TabIndex = 10
        Me.txtCaption.Text = "Original Message"
        '
        'txtTranslation
        '
        Me.txtTranslation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTranslation.Location = New System.Drawing.Point(546, 403)
        Me.txtTranslation.Multiline = True
        Me.txtTranslation.Name = "txtTranslation"
        Me.txtTranslation.Size = New System.Drawing.Size(439, 52)
        Me.txtTranslation.TabIndex = 11
        Me.txtTranslation.Text = "Translation"
        '
        'cmdGridEdit
        '
        Me.cmdGridEdit.Location = New System.Drawing.Point(9, 251)
        Me.cmdGridEdit.Name = "cmdGridEdit"
        Me.cmdGridEdit.Size = New System.Drawing.Size(75, 64)
        Me.cmdGridEdit.TabIndex = 25
        Me.cmdGridEdit.Text = "Full Edit on Grid with Auto Save"
        Me.cmdGridEdit.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(9, 320)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 37)
        Me.cmdEdit.TabIndex = 26
        Me.cmdEdit.Text = "&Edit a single cell"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(9, 363)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 27
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(9, 392)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 28
        Me.cmdDelete.Text = "&Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(9, 421)
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
        'DataGridViewDosageMaster
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewDosageMaster.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewDosageMaster.AutoGenerateColumns = False
        Me.DataGridViewDosageMaster.BegFindValue = Nothing
        Me.DataGridViewDosageMaster.Cached = False
        Me.DataGridViewDosageMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDosageMaster.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DosageMasterCodeDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.DataGridViewDosageMaster.DataFilter = Nothing
        Me.DataGridViewDosageMaster.DataSource = Me.bsDosageMaster
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDosageMaster.DefaultCellStyle = DataGridViewCellStyle2
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
        Me.DataGridViewDosageMaster.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewDosageMaster.Name = "DataGridViewDosageMaster"
        Me.DataGridViewDosageMaster.Searchable = True
        Me.DataGridViewDosageMaster.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewDosageMaster.SecurityKey = ""
        Me.DataGridViewDosageMaster.SequenceColumn = "dgvSequence"
        Me.DataGridViewDosageMaster.SequenceFieldName = "Sequence"
        Me.DataGridViewDosageMaster.ShowFooter = False
        Me.DataGridViewDosageMaster.Size = New System.Drawing.Size(911, 150)
        Me.DataGridViewDosageMaster.TabIndex = 30
        Me.DataGridViewDosageMaster.Translatable = True
        '
        'DosageMasterCodeDataGridViewTextBoxColumn
        '
        Me.DosageMasterCodeDataGridViewTextBoxColumn.DataPropertyName = "DosageMasterCode"
        Me.DosageMasterCodeDataGridViewTextBoxColumn.HeaderText = "DosageMasterCode"
        Me.DosageMasterCodeDataGridViewTextBoxColumn.Name = "DosageMasterCodeDataGridViewTextBoxColumn"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DosageMasterName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "DosageMasterName"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DosageMasterNameARa"
        Me.DataGridViewTextBoxColumn2.HeaderText = "DosageMasterNameARa"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "IdNo"
        Me.DataGridViewTextBoxColumn3.HeaderText = "IdNo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'bsDosageMaster
        '
        Me.bsDosageMaster.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.DosageMasterModel)
        '
        'DosageTableManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 461)
        Me.Controls.Add(Me.DataGridViewDosageMaster)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdGridEdit)
        Me.Controls.Add(Me.CLabel2)
        Me.Controls.Add(Me.txtTranslation)
        Me.Controls.Add(Me.txtCaption)
        Me.Name = "DosageTableManager"
        Me.Text = "Translation Table Manager"
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewDosageMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsDosageMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCaption As TextBox
    Friend WithEvents txtTranslation As TextBox
    Friend WithEvents cmdGridEdit As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents CLabel2 As CLabel
    Friend WithEvents ISPDATADataSet As ISPDATADataSet
    Friend WithEvents DosageMasterNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DosageMasterNameARaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewDosageMaster As CDataGridView
    Friend WithEvents bsDosageMaster As BindingSource
    Friend WithEvents DosageMasterCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
End Class