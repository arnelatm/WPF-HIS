Imports System.ComponentModel
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace PresentationLayer.Views.Forms

    <DesignerGenerated()>
    Partial Class MessagesTableManager
        Inherits BfMainNew

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
            Me.DataGrid1 = New DataGridView()
            Me.txtOriginal = New TextBox()
            Me.txtTranslation = New TextBox()
            Me.cmdGridEdit = New Button()
            Me.cmdEdit = New Button()
            Me.cmdSave = New Button()
            Me.cmdDelete = New Button()
            Me.cmdCancel = New Button()
            Me.cmbLanguage = New ComboBox()
            Me.Label1 = New Label()
            Me.cmbLanguagePicker = New ComboBox()
            Me.CLabel2 = New CLabel()
            Me.Label2 = New Label()
            Me.TextBox1 = New TextBox()
            Me.TextBox2 = New TextBox()
            CType(Me.MyErrorProvider, ISupportInitialize).BeginInit()
            CType(Me.DataGrid1, ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGrid1
            '
            Me.DataGrid1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                                          Or AnchorStyles.Left) _
                                         Or AnchorStyles.Right), AnchorStyles)
            Me.DataGrid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGrid1.Location = New Point(90, 39)
            Me.DataGrid1.MultiSelect = False
            Me.DataGrid1.Name = "DataGrid1"
            Me.DataGrid1.Size = New Size(878, 533)
            Me.DataGrid1.TabIndex = 9
            '
            'txtOriginal
            '
            Me.txtOriginal.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
            Me.txtOriginal.Enabled = False
            Me.txtOriginal.Location = New Point(376, 578)
            Me.txtOriginal.Multiline = True
            Me.txtOriginal.Name = "txtOriginal"
            Me.txtOriginal.Size = New Size(280, 100)
            Me.txtOriginal.TabIndex = 10
            Me.txtOriginal.Text = "Translation"
            '
            'txtTranslation
            '
            Me.txtTranslation.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
            Me.txtTranslation.Location = New Point(90, 578)
            Me.txtTranslation.Multiline = True
            Me.txtTranslation.Name = "txtTranslation"
            Me.txtTranslation.Size = New Size(280, 100)
            Me.txtTranslation.TabIndex = 11
            Me.txtTranslation.Text = "Message"
            '
            'cmdGridEdit
            '
            Me.cmdGridEdit.Location = New Point(9, 251)
            Me.cmdGridEdit.Name = "cmdGridEdit"
            Me.cmdGridEdit.Size = New Size(75, 64)
            Me.cmdGridEdit.TabIndex = 25
            Me.cmdGridEdit.Text = "Full Edit on Grid with Auto Save"
            Me.cmdGridEdit.UseVisualStyleBackColor = True
            '
            'cmdEdit
            '
            Me.cmdEdit.Location = New Point(9, 320)
            Me.cmdEdit.Name = "cmdEdit"
            Me.cmdEdit.Size = New Size(75, 37)
            Me.cmdEdit.TabIndex = 26
            Me.cmdEdit.Text = "&Edit a single cell"
            Me.cmdEdit.UseVisualStyleBackColor = True
            '
            'cmdSave
            '
            Me.cmdSave.Location = New Point(9, 363)
            Me.cmdSave.Name = "cmdSave"
            Me.cmdSave.Size = New Size(75, 23)
            Me.cmdSave.TabIndex = 27
            Me.cmdSave.Text = "Save"
            Me.cmdSave.UseVisualStyleBackColor = True
            '
            'cmdDelete
            '
            Me.cmdDelete.Location = New Point(9, 392)
            Me.cmdDelete.Name = "cmdDelete"
            Me.cmdDelete.Size = New Size(75, 23)
            Me.cmdDelete.TabIndex = 28
            Me.cmdDelete.Text = "&Delete"
            Me.cmdDelete.UseVisualStyleBackColor = True
            '
            'cmdCancel
            '
            Me.cmdCancel.Location = New Point(9, 421)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New Size(75, 23)
            Me.cmdCancel.TabIndex = 29
            Me.cmdCancel.Text = "&Cancel"
            Me.cmdCancel.UseVisualStyleBackColor = True
            '
            'cmbLanguage
            '
            Me.cmbLanguage.FormattingEnabled = True
            Me.cmbLanguage.Location = New Point(136, 12)
            Me.cmbLanguage.Name = "cmbLanguage"
            Me.cmbLanguage.Size = New Size(221, 21)
            Me.cmbLanguage.TabIndex = 32
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New Point(12, 17)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New Size(118, 13)
            Me.Label1.TabIndex = 35
            Me.Label1.Text = "Language To Translate"
            '
            'cmbLanguagePicker
            '
            Me.cmbLanguagePicker.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.cmbLanguagePicker.FormattingEnabled = True
            Me.cmbLanguagePicker.Location = New Point(704, 12)
            Me.cmbLanguagePicker.Name = "cmbLanguagePicker"
            Me.cmbLanguagePicker.Size = New Size(270, 21)
            Me.cmbLanguagePicker.TabIndex = 36
            '
            'CLabel2
            '
            Me.CLabel2.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.CLabel2.AutoSize = True
            Me.CLabel2.Font = New Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New Point(802, 12)
            Me.CLabel2.Margin = New Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New Size(0, 17)
            Me.CLabel2.TabIndex = 24
            Me.CLabel2.TextAlign = ContentAlignment.MiddleLeft
            '
            'Label2
            '
            Me.Label2.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.Label2.AutoSize = True
            Me.Label2.Location = New Point(549, 14)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New Size(149, 13)
            Me.Label2.TabIndex = 37
            Me.Label2.Text = "Language to Use for this Form"
            '
            'TextBox1
            '
            Me.TextBox1.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
            Me.TextBox1.Location = New Point(662, 578)
            Me.TextBox1.Multiline = True
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New Size(150, 100)
            Me.TextBox1.TabIndex = 39
            Me.TextBox1.Text = "Caption"
            '
            'TextBox2
            '
            Me.TextBox2.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
            Me.TextBox2.Enabled = False
            Me.TextBox2.Location = New Point(818, 578)
            Me.TextBox2.Multiline = True
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New Size(150, 100)
            Me.TextBox2.TabIndex = 38
            Me.TextBox2.Text = "Translation"
            '
            'MessagesTableManager
            '
            Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.ClientSize = New Size(984, 681)
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
            CType(Me.MyErrorProvider, ISupportInitialize).EndInit()
            CType(Me.DataGrid1, ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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