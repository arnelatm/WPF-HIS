Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PettyCashClosing
        Inherits CFormEntry

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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PettyCashClosing))
            Me.bsPcJournal = New System.Windows.Forms.BindingSource(Me.components)
            Me.CDataGridView1 = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.PcClosedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.TransactionDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReferenceNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PaymentTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayeeNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayeeNameAra = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.NotesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPcJournal, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'bsPcJournal
            '
            Me.bsPcJournal.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PcJournalModel)
            '
            'CDataGridView1
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.CDataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.CDataGridView1.AutoGenerateColumns = False
            Me.CDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.CDataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PcClosedDataGridViewCheckBoxColumn, Me.TransactionDateDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.ReferenceNoDataGridViewTextBoxColumn, Me.PaymentTypeDataGridViewTextBoxColumn, Me.PayeeNameDataGridViewTextBoxColumn, Me.PayeeNameAra, Me.AmountDataGridViewTextBoxColumn, Me.NotesDataGridViewTextBoxColumn})
            Me.CDataGridView1.DataSource = Me.bsPcJournal
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.CDataGridView1.DefaultCellStyle = DataGridViewCellStyle2
            Me.CDataGridView1.DgvFooter = Nothing
            Me.CDataGridView1.DisplayOnly = False
            Me.CDataGridView1.Ea = Nothing
            Me.CDataGridView1.EditingMode = False
            Me.CDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.CDataGridView1.FirstRowDeletionEnabled = True
            Me.CDataGridView1.FirstRowInsertionEnabled = True
            Me.CDataGridView1.Location = New System.Drawing.Point(12, 83)
            Me.CDataGridView1.Name = "CDataGridView1"
            Me.CDataGridView1.ReadOnly = True
            Me.CDataGridView1.SequenceColumn = "dgvSequence"
            Me.CDataGridView1.SequenceFieldName = "Sequence"
            Me.CDataGridView1.ShowFooter = False
            Me.CDataGridView1.ShowInsertColumnWhenEditing = True
            Me.CDataGridView1.Size = New System.Drawing.Size(937, 489)
            Me.CDataGridView1.TabIndex = 4
            '
            'PcClosedDataGridViewCheckBoxColumn
            '
            Me.PcClosedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.PcClosedDataGridViewCheckBoxColumn.DataPropertyName = "PcClosed"
            Me.PcClosedDataGridViewCheckBoxColumn.HeaderText = "Close?"
            Me.PcClosedDataGridViewCheckBoxColumn.MinimumWidth = 50
            Me.PcClosedDataGridViewCheckBoxColumn.Name = "PcClosedDataGridViewCheckBoxColumn"
            Me.PcClosedDataGridViewCheckBoxColumn.ReadOnly = True
            Me.PcClosedDataGridViewCheckBoxColumn.Width = 50
            '
            'TransactionDateDataGridViewTextBoxColumn
            '
            Me.TransactionDateDataGridViewTextBoxColumn.DataPropertyName = "TransactionDate"
            Me.TransactionDateDataGridViewTextBoxColumn.HeaderText = "Date"
            Me.TransactionDateDataGridViewTextBoxColumn.Name = "TransactionDateDataGridViewTextBoxColumn"
            Me.TransactionDateDataGridViewTextBoxColumn.ReadOnly = True
            Me.TransactionDateDataGridViewTextBoxColumn.Width = 80
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.IdNoDataGridViewTextBoxColumn.Width = 50
            '
            'ReferenceNoDataGridViewTextBoxColumn
            '
            Me.ReferenceNoDataGridViewTextBoxColumn.DataPropertyName = "ReferenceNo"
            Me.ReferenceNoDataGridViewTextBoxColumn.HeaderText = "Reference No"
            Me.ReferenceNoDataGridViewTextBoxColumn.Name = "ReferenceNoDataGridViewTextBoxColumn"
            Me.ReferenceNoDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReferenceNoDataGridViewTextBoxColumn.Width = 80
            '
            'PaymentTypeDataGridViewTextBoxColumn
            '
            Me.PaymentTypeDataGridViewTextBoxColumn.DataPropertyName = "PaymentType"
            Me.PaymentTypeDataGridViewTextBoxColumn.HeaderText = "Payee Type"
            Me.PaymentTypeDataGridViewTextBoxColumn.Name = "PaymentTypeDataGridViewTextBoxColumn"
            Me.PaymentTypeDataGridViewTextBoxColumn.ReadOnly = True
            Me.PaymentTypeDataGridViewTextBoxColumn.Width = 40
            '
            'PayeeNameDataGridViewTextBoxColumn
            '
            Me.PayeeNameDataGridViewTextBoxColumn.DataPropertyName = "PayeeName"
            Me.PayeeNameDataGridViewTextBoxColumn.HeaderText = "PayeeName"
            Me.PayeeNameDataGridViewTextBoxColumn.Name = "PayeeNameDataGridViewTextBoxColumn"
            Me.PayeeNameDataGridViewTextBoxColumn.ReadOnly = True
            Me.PayeeNameDataGridViewTextBoxColumn.Width = 150
            '
            'PayeeNameAra
            '
            Me.PayeeNameAra.DataPropertyName = "PayeeNameAra"
            Me.PayeeNameAra.HeaderText = "PayeeNameAra"
            Me.PayeeNameAra.Name = "PayeeNameAra"
            Me.PayeeNameAra.ReadOnly = True
            Me.PayeeNameAra.Visible = False
            Me.PayeeNameAra.Width = 150
            '
            'AmountDataGridViewTextBoxColumn
            '
            Me.AmountDataGridViewTextBoxColumn.DataPropertyName = "Amount"
            Me.AmountDataGridViewTextBoxColumn.HeaderText = "Amount"
            Me.AmountDataGridViewTextBoxColumn.Name = "AmountDataGridViewTextBoxColumn"
            Me.AmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'NotesDataGridViewTextBoxColumn
            '
            Me.NotesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.NotesDataGridViewTextBoxColumn.DataPropertyName = "Notes"
            Me.NotesDataGridViewTextBoxColumn.HeaderText = "Notes"
            Me.NotesDataGridViewTextBoxColumn.Name = "NotesDataGridViewTextBoxColumn"
            Me.NotesDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PettyCashClosing
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile
            Me.ClientSize = New System.Drawing.Size(988, 645)
            Me.Controls.Add(Me.CDataGridView1)
            Me.MinimumSize = New System.Drawing.Size(945, 590)
            Me.Name = "PettyCashClosing"
            Me.Text = "Petty Cash Closing"
            Me.Controls.SetChildIndex(Me.CDataGridView1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPcJournal, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsPcJournal As Windows.Forms.BindingSource
        Friend WithEvents dgvIdNocadOi As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvJournalItemIdNo As CdgvColumnText
        Friend WithEvents dgvcadIdNo As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CkdIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents JournalItemIdNoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents OpenInvoiceIdNoDataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents dgvSequenceCad As CdgvColumnText
        Friend WithEvents DataGridViewTextBoxColumn4 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewCheckBoxColumn1 As Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents PcsIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CDataGridView1 As CDataGridView
        Friend WithEvents PcClosedDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents TransactionDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents ReferenceNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PaymentTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayeeNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayeeNameAra As DataGridViewTextBoxColumn
        Friend WithEvents AmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents NotesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace