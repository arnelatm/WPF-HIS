Imports AATM.Libraries.CBaseControlsLibrary


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TranslationTableManager
    Inherits BaseForm

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
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cmdEdit = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.cmdDelete = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.cmdAddLanguage = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.cmdDeleteLanguage = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.cmbLanguage = New AATM.Libraries.CBaseControlsLibrary.CComboBox()
        Me.DataGrid1 = New System.Windows.Forms.DataGridView()
        Me.txtOriginal = New System.Windows.Forms.TextBox()
        Me.txtTranslation = New System.Windows.Forms.TextBox()
        Me.txtNewLanguage = New System.Windows.Forms.TextBox()
        Me.cmdSave = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.cmdCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.cmdGridEdit = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.DataGrid1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(13, 13)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(72, 17)
        Me.CLabel1.TabIndex = 1
        Me.CLabel1.Text = "Language"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEdit
        '
        Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.cmdEdit.BackColor = System.Drawing.Color.Transparent
        Me.cmdEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdEdit.FlatAppearance.BorderSize = 0
        Me.cmdEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdEdit.Location = New System.Drawing.Point(9, 321)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 36)
        Me.cmdEdit.TabIndex = 2
        Me.cmdEdit.Text = "&Edit a single cell"
        Me.cmdEdit.UseVisualStyleBackColor = false
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.BackColor = System.Drawing.Color.Transparent
        Me.cmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdDelete.FlatAppearance.BorderSize = 0
        Me.cmdDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdDelete.Location = New System.Drawing.Point(9, 392)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 3
        Me.cmdDelete.Text = "&Delete"
        Me.cmdDelete.UseVisualStyleBackColor = false
        '
        'cmdAddLanguage
        '
        Me.cmdAddLanguage.BackColor = System.Drawing.Color.Transparent
        Me.cmdAddLanguage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdAddLanguage.FlatAppearance.BorderSize = 0
        Me.cmdAddLanguage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdAddLanguage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdAddLanguage.Location = New System.Drawing.Point(215, 12)
        Me.cmdAddLanguage.Name = "cmdAddLanguage"
        Me.cmdAddLanguage.Size = New System.Drawing.Size(106, 23)
        Me.cmdAddLanguage.TabIndex = 5
        Me.cmdAddLanguage.Text = "&Add Language"
        Me.cmdAddLanguage.UseVisualStyleBackColor = false
        '
        'cmdDeleteLanguage
        '
        Me.cmdDeleteLanguage.BackColor = System.Drawing.Color.Transparent
        Me.cmdDeleteLanguage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdDeleteLanguage.FlatAppearance.BorderSize = 0
        Me.cmdDeleteLanguage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdDeleteLanguage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdDeleteLanguage.Location = New System.Drawing.Point(215, 41)
        Me.cmdDeleteLanguage.Name = "cmdDeleteLanguage"
        Me.cmdDeleteLanguage.Size = New System.Drawing.Size(106, 23)
        Me.cmdDeleteLanguage.TabIndex = 6
        Me.cmdDeleteLanguage.Text = "Delete Language"
        Me.cmdDeleteLanguage.UseVisualStyleBackColor = false
        '
        'cmbLanguage
        '
        Me.cmbLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbLanguage.BackColor = System.Drawing.Color.White
        Me.cmbLanguage.DefaultValue = Nothing
        Me.cmbLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbLanguage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cmbLanguage.ForeColor = System.Drawing.Color.Black
        Me.cmbLanguage.FormattingEnabled = true
        Me.cmbLanguage.HideWhenNotEditingOrAdding = false
        Me.cmbLanguage.LinkedLabel = Nothing
        Me.cmbLanguage.Location = New System.Drawing.Point(90, 12)
        Me.cmbLanguage.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbLanguage.Name = "cmbLanguage"
        Me.cmbLanguage.OriginalDataSource = Nothing
        Me.cmbLanguage.OriginalDropDownStyle = 1
        Me.cmbLanguage.OriginalList = Nothing
        Me.cmbLanguage.PreviousSelectedIndex = -1
        Me.cmbLanguage.ReadOnlyCombo = false
        Me.cmbLanguage.ReadOnlyMode = false
        Me.cmbLanguage.Size = New System.Drawing.Size(121, 24)
        Me.cmbLanguage.TabIndex = 8
        Me.cmbLanguage.ValueIsMandatory = false
        Me.cmbLanguage.ValueIsNullable = false
        Me.cmbLanguage.ValueIsNumeric = false
        Me.cmbLanguage.ValueIsReadOnly = false
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid1.Location = New System.Drawing.Point(90, 70)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(700, 316)
        Me.DataGrid1.TabIndex = 9
        '
        'txtOriginal
        '
        Me.txtOriginal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.txtOriginal.Enabled = false
        Me.txtOriginal.Location = New System.Drawing.Point(90, 392)
        Me.txtOriginal.Multiline = true
        Me.txtOriginal.Name = "txtOriginal"
        Me.txtOriginal.Size = New System.Drawing.Size(361, 52)
        Me.txtOriginal.TabIndex = 10
        Me.txtOriginal.Text = "Original"
        '
        'txtTranslation
        '
        Me.txtTranslation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtTranslation.Location = New System.Drawing.Point(457, 392)
        Me.txtTranslation.Multiline = true
        Me.txtTranslation.Name = "txtTranslation"
        Me.txtTranslation.Size = New System.Drawing.Size(331, 52)
        Me.txtTranslation.TabIndex = 11
        Me.txtTranslation.Text = "Translation"
        '
        'txtNewLanguage
        '
        Me.txtNewLanguage.Location = New System.Drawing.Point(338, 13)
        Me.txtNewLanguage.Name = "txtNewLanguage"
        Me.txtNewLanguage.Size = New System.Drawing.Size(118, 20)
        Me.txtNewLanguage.TabIndex = 12
        Me.txtNewLanguage.Text = "Original"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.cmdSave.BackColor = System.Drawing.Color.Transparent
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdSave.Location = New System.Drawing.Point(9, 363)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 14
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = false
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCancel.FlatAppearance.BorderSize = 0
        Me.cmdCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdCancel.Location = New System.Drawing.Point(9, 421)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 15
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = false
        '
        'cmdGridEdit
        '
        Me.cmdGridEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.cmdGridEdit.BackColor = System.Drawing.Color.Transparent
        Me.cmdGridEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdGridEdit.FlatAppearance.BorderSize = 0
        Me.cmdGridEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdGridEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdGridEdit.Location = New System.Drawing.Point(9, 244)
        Me.cmdGridEdit.Name = "cmdGridEdit"
        Me.cmdGridEdit.Size = New System.Drawing.Size(75, 71)
        Me.cmdGridEdit.TabIndex = 16
        Me.cmdGridEdit.Text = "Full Edit on Grid with Auto Save"
        Me.cmdGridEdit.UseVisualStyleBackColor = false
        '
        'TranslationTableManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmdGridEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.txtNewLanguage)
        Me.Controls.Add(Me.txtTranslation)
        Me.Controls.Add(Me.txtOriginal)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.cmbLanguage)
        Me.Controls.Add(Me.cmdDeleteLanguage)
        Me.Controls.Add(Me.cmdAddLanguage)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.CLabel1)
        Me.Name = "TranslationTableManager"
        Me.Text = "TranslationTableManager"
        Me.Controls.SetChildIndex(Me.CLabel1, 0)
        Me.Controls.SetChildIndex(Me.cmdEdit, 0)
        Me.Controls.SetChildIndex(Me.cmdDelete, 0)
        Me.Controls.SetChildIndex(Me.cmdAddLanguage, 0)
        Me.Controls.SetChildIndex(Me.cmdDeleteLanguage, 0)
        Me.Controls.SetChildIndex(Me.cmbLanguage, 0)
        Me.Controls.SetChildIndex(Me.DataGrid1, 0)
        Me.Controls.SetChildIndex(Me.txtOriginal, 0)
        Me.Controls.SetChildIndex(Me.txtTranslation, 0)
        Me.Controls.SetChildIndex(Me.txtNewLanguage, 0)
        Me.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.Controls.SetChildIndex(Me.cmdCancel, 0)
        Me.Controls.SetChildIndex(Me.cmdGridEdit, 0)
        CType(Me.DataGrid1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub


    Friend WithEvents CLabel1 As CBaseControlsLibrary.CLabel
    Friend WithEvents cmdEdit As CBaseControlsLibrary.CButton
    Friend WithEvents cmdDelete As CBaseControlsLibrary.CButton
    Friend WithEvents cmdAddLanguage As CBaseControlsLibrary.CButton
    Friend WithEvents cmdDeleteLanguage As CBaseControlsLibrary.CButton
    Friend WithEvents cmbLanguage As CBaseControlsLibrary.CComboBox
    Friend WithEvents DataGrid1 As Windows.Forms.DataGridView
    Friend WithEvents txtOriginal As Windows.Forms.TextBox
    Friend WithEvents txtTranslation As Windows.Forms.TextBox
    Friend WithEvents txtNewLanguage As Windows.Forms.TextBox
    Friend WithEvents cmdSave As CBaseControlsLibrary.CButton
    Friend WithEvents cmdCancel As CBaseControlsLibrary.CButton
    Friend WithEvents cmdGridEdit As CBaseControlsLibrary.CButton
End Class