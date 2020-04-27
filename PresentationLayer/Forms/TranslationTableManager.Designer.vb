Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports Microsoft.VisualBasic.CompilerServices


<DesignerGenerated()>
Partial Class TranslationTableManager
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
        Me.DataGrid1 = New System.Windows.Forms.DataGridView()
        Me.txtCaption = New System.Windows.Forms.TextBox()
        Me.txtTranslation = New System.Windows.Forms.TextBox()
        Me.cmdGridEdit = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmbLanguage = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbLanguagePicker = New System.Windows.Forms.ComboBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGrid1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                                      Or System.Windows.Forms.AnchorStyles.Left)  _
                                     Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid1.Location = New System.Drawing.Point(90, 39)
        Me.DataGrid1.MultiSelect = false
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(908, 358)
        Me.DataGrid1.TabIndex = 9
        '
        'txtCaption
        '
        Me.txtCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.txtCaption.Enabled = false
        Me.txtCaption.Location = New System.Drawing.Point(90, 403)
        Me.txtCaption.Multiline = true
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(450, 52)
        Me.txtCaption.TabIndex = 10
        Me.txtCaption.Text = "Original Message"
        '
        'txtTranslation
        '
        Me.txtTranslation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtTranslation.Location = New System.Drawing.Point(546, 403)
        Me.txtTranslation.Multiline = true
        Me.txtTranslation.Name = "txtTranslation"
        Me.txtTranslation.Size = New System.Drawing.Size(450, 52)
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
        Me.cmdGridEdit.UseVisualStyleBackColor = true
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(9, 320)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(75, 37)
        Me.cmdEdit.TabIndex = 26
        Me.cmdEdit.Text = "&Edit a single cell"
        Me.cmdEdit.UseVisualStyleBackColor = true
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(9, 363)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 27
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = true
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(9, 392)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 28
        Me.cmdDelete.Text = "&Delete"
        Me.cmdDelete.UseVisualStyleBackColor = true
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(9, 421)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 29
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = true
        '
        'cmbLanguage
        '
        Me.cmbLanguage.FormattingEnabled = true
        Me.cmbLanguage.Location = New System.Drawing.Point(136, 12)
        Me.cmbLanguage.Name = "cmbLanguage"
        Me.cmbLanguage.Size = New System.Drawing.Size(221, 21)
        Me.cmbLanguage.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Language To Translate"
        '
        'cmbLanguagePicker
        '
        Me.cmbLanguagePicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cmbLanguagePicker.FormattingEnabled = true
        Me.cmbLanguagePicker.Location = New System.Drawing.Point(728, 12)
        Me.cmbLanguagePicker.Name = "cmbLanguagePicker"
        Me.cmbLanguagePicker.Size = New System.Drawing.Size(270, 21)
        Me.cmbLanguagePicker.TabIndex = 36
        '
        'CLabel2
        '
        Me.CLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.CLabel2.AutoSize = true
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(826, 12)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(0, 17)
        Me.CLabel2.TabIndex = 24
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(573, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Language to Use for this Form"
        '
        'TranslationTableManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 461)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbLanguagePicker)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbLanguage)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdGridEdit)
        Me.Controls.Add(Me.CLabel2)
        Me.Controls.Add(Me.txtTranslation)
        Me.Controls.Add(Me.txtCaption)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "TranslationTableManager"
        Me.Text = "Translation Table Manager"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGrid1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

    End Sub
    Friend WithEvents DataGrid1 As DataGridView
    Friend WithEvents txtCaption As TextBox
    Friend WithEvents txtTranslation As TextBox
    Friend WithEvents cmdGridEdit As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmbLanguage As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbLanguagePicker As ComboBox
    Friend WithEvents CLabel2 As CLabel
    Friend WithEvents Label2 As Label
End Class