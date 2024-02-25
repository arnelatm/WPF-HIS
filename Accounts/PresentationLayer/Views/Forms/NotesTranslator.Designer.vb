Imports System.ComponentModel
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace PresentationLayer.Views.Forms


    <DesignerGenerated()>
    Partial Class NotesTranslator
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtOriginalNote = New System.Windows.Forms.TextBox()
        Me.txtTranslation = New System.Windows.Forms.TextBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.DataGridViewTransactionNotes = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
        Me.dgvNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bsNotes = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnTranslateWord = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DataGridViewTransactionNotes,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.bsNotes,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'txtOriginalNote
        '
        Me.txtOriginalNote.Location = New System.Drawing.Point(117, 388)
        Me.txtOriginalNote.Multiline = true
        Me.txtOriginalNote.Name = "txtOriginalNote"
        Me.txtOriginalNote.Size = New System.Drawing.Size(450, 52)
        Me.txtOriginalNote.TabIndex = 10
        '
        'txtTranslation
        '
        Me.txtTranslation.Location = New System.Drawing.Point(116, 446)
        Me.txtTranslation.Multiline = true
        Me.txtTranslation.Name = "txtTranslation"
        Me.txtTranslation.Size = New System.Drawing.Size(450, 52)
        Me.txtTranslation.TabIndex = 11
        Me.txtTranslation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 519)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(143, 23)
        Me.cmdSave.TabIndex = 27
        Me.cmdSave.Text = "Translate Whole Note"
        Me.cmdSave.UseVisualStyleBackColor = true
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(492, 519)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 29
        Me.cmdCancel.Text = "&Quit"
        Me.cmdCancel.UseVisualStyleBackColor = true
        '
        'CLabel2
        '
        Me.CLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.CLabel2.AutoSize = true
        Me.CLabel2.DisplayOnly = true
        Me.CLabel2.EditingMode = false
        Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel2.Location = New System.Drawing.Point(405, 382)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.Size = New System.Drawing.Size(0, 17)
        Me.CLabel2.TabIndex = 24
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = true
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel1.Location = New System.Drawing.Point(13, 384)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(38, 17)
        Me.CLabel1.TabIndex = 30
        Me.CLabel1.Text = "Note"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CLabel3
        '
        Me.CLabel3.AutoSize = true
        Me.CLabel3.BackColor = System.Drawing.Color.Transparent
        Me.CLabel3.DisplayOnly = true
        Me.CLabel3.EditingMode = false
        Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.CLabel3.Location = New System.Drawing.Point(13, 442)
        Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel3.Name = "CLabel3"
        Me.CLabel3.Size = New System.Drawing.Size(79, 17)
        Me.CLabel3.TabIndex = 31
        Me.CLabel3.Text = "Translation"
        Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewTransactionNotes
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridViewTransactionNotes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTransactionNotes.AutoGenerateColumns = false
        Me.DataGridViewTransactionNotes.BegFindValue = Nothing
        Me.DataGridViewTransactionNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewTransactionNotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvNotes})
        Me.DataGridViewTransactionNotes.DataSource = Me.bsNotes
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTransactionNotes.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTransactionNotes.DgvFooter = Nothing
        Me.DataGridViewTransactionNotes.DisplayOnly = false
        Me.DataGridViewTransactionNotes.Ea = Nothing
        Me.DataGridViewTransactionNotes.EditingMode = false
        Me.DataGridViewTransactionNotes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DataGridViewTransactionNotes.EndFindValue = Nothing
        Me.DataGridViewTransactionNotes.FieldName = Nothing
        Me.DataGridViewTransactionNotes.FieldsDictionary = Nothing
        Me.DataGridViewTransactionNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.DataGridViewTransactionNotes.FindEnabled = false
        Me.DataGridViewTransactionNotes.FirstRowDeletionEnabled = true
        Me.DataGridViewTransactionNotes.FirstRowInsertionEnabled = true
        Me.DataGridViewTransactionNotes.Location = New System.Drawing.Point(16, 12)
        Me.DataGridViewTransactionNotes.Name = "DataGridViewTransactionNotes"
        Me.DataGridViewTransactionNotes.ReadOnly = true
        Me.DataGridViewTransactionNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.DataGridViewTransactionNotes.SequenceColumn = "dgvSequence"
        Me.DataGridViewTransactionNotes.SequenceFieldName = "Sequence"
        Me.DataGridViewTransactionNotes.ShowFooter = False
            Me.DataGridViewTransactionNotes.Size = New System.Drawing.Size(551, 366)
            Me.DataGridViewTransactionNotes.TabIndex = 32
        '
        'dgvNotes
        '
        Me.dgvNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dgvNotes.DataPropertyName = "Notes"
        Me.dgvNotes.HeaderText = "Notes"
        Me.dgvNotes.Name = "dgvNotes"
        Me.dgvNotes.ReadOnly = true
        '
        'bsNotes
        '
        Me.bsNotes.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.TransactionNotesModel)
        '
        'btnTranslateWord
        '
        Me.btnTranslateWord.Enabled = false
        Me.btnTranslateWord.Location = New System.Drawing.Point(161, 519)
        Me.btnTranslateWord.Name = "btnTranslateWord"
        Me.btnTranslateWord.Size = New System.Drawing.Size(146, 23)
        Me.btnTranslateWord.TabIndex = 33
        Me.btnTranslateWord.Text = "Translate Word"
        Me.btnTranslateWord.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(327, 519)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(146, 23)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Refresh Grid"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'NotesTranslator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 570)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnTranslateWord)
        Me.Controls.Add(Me.DataGridViewTransactionNotes)
        Me.Controls.Add(Me.CLabel3)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.CLabel2)
        Me.Controls.Add(Me.txtTranslation)
        Me.Controls.Add(Me.txtOriginalNote)
        Me.Name = "NotesTranslator"
        Me.Text = "Translation Table Manager"
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewTransactionNotes,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.bsNotes,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents txtOriginalNote As TextBox
        Friend WithEvents txtTranslation As TextBox
        Friend WithEvents cmdSave As Button
        Friend WithEvents cmdCancel As Button
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents DataGridViewTransactionNotes As CtDataGridView
        Friend WithEvents bsNotes As BindingSource
        Friend WithEvents dgvNotes As DataGridViewTextBoxColumn
        Friend WithEvents btnTranslateWord As Button
        Friend WithEvents Button1 As Button
    End Class
End NameSpace