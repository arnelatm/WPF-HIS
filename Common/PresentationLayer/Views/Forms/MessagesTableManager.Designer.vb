Imports System.ComponentModel
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace PresentationLayer.Views.Forms

    <DesignerGenerated()>
    Partial Class MessagesTableManager
        Inherits BFMain

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
        Me.txtOriginal = New System.Windows.Forms.TextBox()
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGrid1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TranslatorDAC
        '
        Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
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
        Me.DataGrid1.Size = New System.Drawing.Size(878, 533)
        Me.DataGrid1.TabIndex = 9
        '
        'txtOriginal
        '
        Me.txtOriginal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.txtOriginal.Enabled = false
        Me.txtOriginal.Location = New System.Drawing.Point(376, 578)
        Me.txtOriginal.Multiline = true
        Me.txtOriginal.Name = "txtOriginal"
        Me.txtOriginal.Size = New System.Drawing.Size(280, 100)
        Me.txtOriginal.TabIndex = 10
        Me.txtOriginal.Text = "Translation"
        '
        'txtTranslation
        '
        Me.txtTranslation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtTranslation.Location = New System.Drawing.Point(90, 578)
        Me.txtTranslation.Multiline = true
        Me.txtTranslation.Name = "txtTranslation"
        Me.txtTranslation.Size = New System.Drawing.Size(280, 100)
        Me.txtTranslation.TabIndex = 11
        Me.txtTranslation.Text = "Message"
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
        Me.cmbLanguage.Enabled = false
        Me.cmbLanguage.FormattingEnabled = true
        Me.cmbLanguage.Location = New System.Drawing.Point(136, 12)
        Me.cmbLanguage.Name = "cmbLanguage"
        Me.cmbLanguage.Size = New System.Drawing.Size(10, 21)
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
        Me.cmbLanguagePicker.Enabled = false
        Me.cmbLanguagePicker.FormattingEnabled = true
        Me.cmbLanguagePicker.Location = New System.Drawing.Point(704, 12)
        Me.cmbLanguagePicker.Name = "cmbLanguagePicker"
        Me.cmbLanguagePicker.Size = New System.Drawing.Size(19, 21)
        Me.cmbLanguagePicker.TabIndex = 36
        '
        'CLabel2
        '
        Me.CLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.CLabel2.AutoSize = true
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(802, 12)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(0, 17)
        Me.CLabel2.TabIndex = 24
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel2.Translatable = true
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(549, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Language to Use for this Form"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(662, 578)
        Me.TextBox1.Multiline = true
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(150, 100)
        Me.TextBox1.TabIndex = 39
        Me.TextBox1.Text = "Caption"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Enabled = false
        Me.TextBox2.Location = New System.Drawing.Point(818, 578)
        Me.TextBox2.Multiline = true
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(150, 100)
        Me.TextBox2.TabIndex = 38
        Me.TextBox2.Text = "Translation"
        '
        'MessagesTableManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 681)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
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
        Me.Controls.Add(Me.txtOriginal)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "MessagesTableManager"
        Me.Text = "Translation Table Manager"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGrid1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents DataGrid1 As DataGridView
        Friend WithEvents txtOriginal As TextBox
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
        Friend WithEvents TextBox1 As TextBox
        Friend WithEvents TextBox2 As TextBox
    End Class
End NameSpace