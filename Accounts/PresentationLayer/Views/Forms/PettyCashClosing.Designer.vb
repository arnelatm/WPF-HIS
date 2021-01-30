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
            Me.AccountIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AppliedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CancelledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.DateCreatedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DiscountAccountIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DiscountTakenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.NotesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.OrNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayeeIdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PayeeNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PaymentTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PcClosedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.PostedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.ReferenceNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TotalCreditsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TotalDebitsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.TransactionDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.UnAppliedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VatAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VatNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
            Me.CDataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AccountIdNoDataGridViewTextBoxColumn, Me.AmountDataGridViewTextBoxColumn, Me.AppliedDataGridViewTextBoxColumn, Me.CancelledDataGridViewCheckBoxColumn, Me.DateCreatedDataGridViewTextBoxColumn, Me.PayTypeDataGridViewTextBoxColumn, Me.DiscountAccountIdNoDataGridViewTextBoxColumn, Me.DiscountTakenDataGridViewTextBoxColumn, Me.IdNoDataGridViewTextBoxColumn, Me.NotesDataGridViewTextBoxColumn, Me.OrNumberDataGridViewTextBoxColumn, Me.PayeeIdNoDataGridViewTextBoxColumn, Me.PayeeNameDataGridViewTextBoxColumn, Me.PaymentTypeDataGridViewTextBoxColumn, Me.PcClosedDataGridViewCheckBoxColumn, Me.PostedDataGridViewCheckBoxColumn, Me.ReferenceNoDataGridViewTextBoxColumn, Me.TotalCreditsDataGridViewTextBoxColumn, Me.TotalDebitsDataGridViewTextBoxColumn, Me.TransactionDateDataGridViewTextBoxColumn, Me.UnAppliedDataGridViewTextBoxColumn, Me.VatAmountDataGridViewTextBoxColumn, Me.VatNumberDataGridViewTextBoxColumn})
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
            Me.CDataGridView1.Location = New System.Drawing.Point(12, 93)
            Me.CDataGridView1.Name = "CDataGridView1"
            Me.CDataGridView1.ReadOnly = True
            Me.CDataGridView1.SequenceColumn = "dgvSequence"
            Me.CDataGridView1.SequenceFieldName = "Sequence"
            Me.CDataGridView1.ShowFooter = False
            Me.CDataGridView1.ShowInsertColumnWhenEditing = True
            Me.CDataGridView1.Size = New System.Drawing.Size(937, 479)
            Me.CDataGridView1.TabIndex = 4
            '
            'AccountIdNoDataGridViewTextBoxColumn
            '
            Me.AccountIdNoDataGridViewTextBoxColumn.DataPropertyName = "AccountIdNo"
            Me.AccountIdNoDataGridViewTextBoxColumn.HeaderText = "AccountIdNo"
            Me.AccountIdNoDataGridViewTextBoxColumn.Name = "AccountIdNoDataGridViewTextBoxColumn"
            Me.AccountIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'AmountDataGridViewTextBoxColumn
            '
            Me.AmountDataGridViewTextBoxColumn.DataPropertyName = "Amount"
            Me.AmountDataGridViewTextBoxColumn.HeaderText = "Amount"
            Me.AmountDataGridViewTextBoxColumn.Name = "AmountDataGridViewTextBoxColumn"
            Me.AmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'AppliedDataGridViewTextBoxColumn
            '
            Me.AppliedDataGridViewTextBoxColumn.DataPropertyName = "Applied"
            Me.AppliedDataGridViewTextBoxColumn.HeaderText = "Applied"
            Me.AppliedDataGridViewTextBoxColumn.Name = "AppliedDataGridViewTextBoxColumn"
            Me.AppliedDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CancelledDataGridViewCheckBoxColumn
            '
            Me.CancelledDataGridViewCheckBoxColumn.DataPropertyName = "Cancelled"
            Me.CancelledDataGridViewCheckBoxColumn.HeaderText = "Cancelled"
            Me.CancelledDataGridViewCheckBoxColumn.Name = "CancelledDataGridViewCheckBoxColumn"
            Me.CancelledDataGridViewCheckBoxColumn.ReadOnly = True
            '
            'DateCreatedDataGridViewTextBoxColumn
            '
            Me.DateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated"
            Me.DateCreatedDataGridViewTextBoxColumn.HeaderText = "DateCreated"
            Me.DateCreatedDataGridViewTextBoxColumn.Name = "DateCreatedDataGridViewTextBoxColumn"
            Me.DateCreatedDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PayTypeDataGridViewTextBoxColumn
            '
            Me.PayTypeDataGridViewTextBoxColumn.DataPropertyName = "PayType"
            Me.PayTypeDataGridViewTextBoxColumn.HeaderText = "PayType"
            Me.PayTypeDataGridViewTextBoxColumn.Name = "PayTypeDataGridViewTextBoxColumn"
            Me.PayTypeDataGridViewTextBoxColumn.ReadOnly = True
            '
            'DiscountAccountIdNoDataGridViewTextBoxColumn
            '
            Me.DiscountAccountIdNoDataGridViewTextBoxColumn.DataPropertyName = "DiscountAccountIdNo"
            Me.DiscountAccountIdNoDataGridViewTextBoxColumn.HeaderText = "DiscountAccountIdNo"
            Me.DiscountAccountIdNoDataGridViewTextBoxColumn.Name = "DiscountAccountIdNoDataGridViewTextBoxColumn"
            Me.DiscountAccountIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'DiscountTakenDataGridViewTextBoxColumn
            '
            Me.DiscountTakenDataGridViewTextBoxColumn.DataPropertyName = "DiscountTaken"
            Me.DiscountTakenDataGridViewTextBoxColumn.HeaderText = "DiscountTaken"
            Me.DiscountTakenDataGridViewTextBoxColumn.Name = "DiscountTakenDataGridViewTextBoxColumn"
            Me.DiscountTakenDataGridViewTextBoxColumn.ReadOnly = True
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.HeaderText = "IdNo"
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'NotesDataGridViewTextBoxColumn
            '
            Me.NotesDataGridViewTextBoxColumn.DataPropertyName = "Notes"
            Me.NotesDataGridViewTextBoxColumn.HeaderText = "Notes"
            Me.NotesDataGridViewTextBoxColumn.Name = "NotesDataGridViewTextBoxColumn"
            Me.NotesDataGridViewTextBoxColumn.ReadOnly = True
            '
            'OrNumberDataGridViewTextBoxColumn
            '
            Me.OrNumberDataGridViewTextBoxColumn.DataPropertyName = "OrNumber"
            Me.OrNumberDataGridViewTextBoxColumn.HeaderText = "OrNumber"
            Me.OrNumberDataGridViewTextBoxColumn.Name = "OrNumberDataGridViewTextBoxColumn"
            Me.OrNumberDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PayeeIdNoDataGridViewTextBoxColumn
            '
            Me.PayeeIdNoDataGridViewTextBoxColumn.DataPropertyName = "PayeeIdNo"
            Me.PayeeIdNoDataGridViewTextBoxColumn.HeaderText = "PayeeIdNo"
            Me.PayeeIdNoDataGridViewTextBoxColumn.Name = "PayeeIdNoDataGridViewTextBoxColumn"
            Me.PayeeIdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PayeeNameDataGridViewTextBoxColumn
            '
            Me.PayeeNameDataGridViewTextBoxColumn.DataPropertyName = "PayeeName"
            Me.PayeeNameDataGridViewTextBoxColumn.HeaderText = "PayeeName"
            Me.PayeeNameDataGridViewTextBoxColumn.Name = "PayeeNameDataGridViewTextBoxColumn"
            Me.PayeeNameDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PaymentTypeDataGridViewTextBoxColumn
            '
            Me.PaymentTypeDataGridViewTextBoxColumn.DataPropertyName = "PaymentType"
            Me.PaymentTypeDataGridViewTextBoxColumn.HeaderText = "PaymentType"
            Me.PaymentTypeDataGridViewTextBoxColumn.Name = "PaymentTypeDataGridViewTextBoxColumn"
            Me.PaymentTypeDataGridViewTextBoxColumn.ReadOnly = True
            '
            'PcClosedDataGridViewCheckBoxColumn
            '
            Me.PcClosedDataGridViewCheckBoxColumn.DataPropertyName = "PcClosed"
            Me.PcClosedDataGridViewCheckBoxColumn.HeaderText = "PcClosed"
            Me.PcClosedDataGridViewCheckBoxColumn.Name = "PcClosedDataGridViewCheckBoxColumn"
            Me.PcClosedDataGridViewCheckBoxColumn.ReadOnly = True
            '
            'PostedDataGridViewCheckBoxColumn
            '
            Me.PostedDataGridViewCheckBoxColumn.DataPropertyName = "Posted"
            Me.PostedDataGridViewCheckBoxColumn.HeaderText = "Posted"
            Me.PostedDataGridViewCheckBoxColumn.Name = "PostedDataGridViewCheckBoxColumn"
            Me.PostedDataGridViewCheckBoxColumn.ReadOnly = True
            '
            'ReferenceNoDataGridViewTextBoxColumn
            '
            Me.ReferenceNoDataGridViewTextBoxColumn.DataPropertyName = "ReferenceNo"
            Me.ReferenceNoDataGridViewTextBoxColumn.HeaderText = "ReferenceNo"
            Me.ReferenceNoDataGridViewTextBoxColumn.Name = "ReferenceNoDataGridViewTextBoxColumn"
            Me.ReferenceNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'TotalCreditsDataGridViewTextBoxColumn
            '
            Me.TotalCreditsDataGridViewTextBoxColumn.DataPropertyName = "TotalCredits"
            Me.TotalCreditsDataGridViewTextBoxColumn.HeaderText = "TotalCredits"
            Me.TotalCreditsDataGridViewTextBoxColumn.Name = "TotalCreditsDataGridViewTextBoxColumn"
            Me.TotalCreditsDataGridViewTextBoxColumn.ReadOnly = True
            '
            'TotalDebitsDataGridViewTextBoxColumn
            '
            Me.TotalDebitsDataGridViewTextBoxColumn.DataPropertyName = "TotalDebits"
            Me.TotalDebitsDataGridViewTextBoxColumn.HeaderText = "TotalDebits"
            Me.TotalDebitsDataGridViewTextBoxColumn.Name = "TotalDebitsDataGridViewTextBoxColumn"
            Me.TotalDebitsDataGridViewTextBoxColumn.ReadOnly = True
            '
            'TransactionDateDataGridViewTextBoxColumn
            '
            Me.TransactionDateDataGridViewTextBoxColumn.DataPropertyName = "TransactionDate"
            Me.TransactionDateDataGridViewTextBoxColumn.HeaderText = "TransactionDate"
            Me.TransactionDateDataGridViewTextBoxColumn.Name = "TransactionDateDataGridViewTextBoxColumn"
            Me.TransactionDateDataGridViewTextBoxColumn.ReadOnly = True
            '
            'UnAppliedDataGridViewTextBoxColumn
            '
            Me.UnAppliedDataGridViewTextBoxColumn.DataPropertyName = "UnApplied"
            Me.UnAppliedDataGridViewTextBoxColumn.HeaderText = "UnApplied"
            Me.UnAppliedDataGridViewTextBoxColumn.Name = "UnAppliedDataGridViewTextBoxColumn"
            Me.UnAppliedDataGridViewTextBoxColumn.ReadOnly = True
            '
            'VatAmountDataGridViewTextBoxColumn
            '
            Me.VatAmountDataGridViewTextBoxColumn.DataPropertyName = "VatAmount"
            Me.VatAmountDataGridViewTextBoxColumn.HeaderText = "VatAmount"
            Me.VatAmountDataGridViewTextBoxColumn.Name = "VatAmountDataGridViewTextBoxColumn"
            Me.VatAmountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'VatNumberDataGridViewTextBoxColumn
            '
            Me.VatNumberDataGridViewTextBoxColumn.DataPropertyName = "VatNumber"
            Me.VatNumberDataGridViewTextBoxColumn.HeaderText = "VatNumber"
            Me.VatNumberDataGridViewTextBoxColumn.Name = "VatNumberDataGridViewTextBoxColumn"
            Me.VatNumberDataGridViewTextBoxColumn.ReadOnly = True
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
        Friend WithEvents AccountIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents AmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents AppliedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents CancelledDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents DateCreatedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DiscountAccountIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents DiscountTakenDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents NotesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents OrNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayeeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PayeeNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PaymentTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents PcClosedDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents PostedDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
        Friend WithEvents ReferenceNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TotalCreditsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TotalDebitsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents TransactionDateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents UnAppliedDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents VatAmountDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents VatNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace