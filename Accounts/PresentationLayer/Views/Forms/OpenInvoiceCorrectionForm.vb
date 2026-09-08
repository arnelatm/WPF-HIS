Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters

Namespace PresentationLayer.Views.Forms

    Public Class OpenInvoiceCorrectionForm
        Inherits Form

        Private ReadOnly _ledgerCombo As New ComboBox()
        Private ReadOnly _contactCombo As New ComboBox()
        Private ReadOnly _correctionDatePicker As New DateTimePicker()
        Private ReadOnly _notesTextBox As New TextBox()
        Private ReadOnly _invoiceGrid As New DataGridView()
        Private ReadOnly _summaryLabel As New Label()
        Private ReadOnly _statusLabel As New Label()
        Private ReadOnly _autoApplyButton As New Button()
        Private ReadOnly _previewButton As New Button()
        Private ReadOnly _postButton As New Button()
        Private _suppressEvents As Boolean

        Public Property Presenter As OpenInvoiceCorrectionPresenter

        Public Sub New()
            InitializeUi()
        End Sub

        Public ReadOnly Property LedgerCode As String
            Get
                Dim ledger = TryCast(_ledgerCombo.SelectedItem, OpenInvoiceCorrectionLedger)
                Return If(ledger Is Nothing, String.Empty, ledger.Code)
            End Get
        End Property

        Public ReadOnly Property SelectedContact As OpenInvoiceCorrectionContact
            Get
                Return TryCast(_contactCombo.SelectedItem, OpenInvoiceCorrectionContact)
            End Get
        End Property

        Public ReadOnly Property SelectedContactIdNo As Int32
            Get
                Dim contact = SelectedContact
                Return If(contact Is Nothing, 0, contact.IdNo)
            End Get
        End Property

        Public ReadOnly Property SelectedContactName As String
            Get
                Dim contact = SelectedContact
                Return If(contact Is Nothing, String.Empty, contact.DisplayName)
            End Get
        End Property

        Public ReadOnly Property CorrectionDate As Date
            Get
                Return _correctionDatePicker.Value.Date
            End Get
        End Property

        Public ReadOnly Property Notes As String
            Get
                Return _notesTextBox.Text
            End Get
        End Property

        Public Sub SetContacts(contacts As List(Of OpenInvoiceCorrectionContact))
            _suppressEvents = True
            Try
                _contactCombo.DataSource = Nothing
                _contactCombo.DisplayMember = "DisplayName"
                _contactCombo.ValueMember = "IdNo"
                _contactCombo.DataSource = If(contacts, New List(Of OpenInvoiceCorrectionContact))
            Finally
                _suppressEvents = False
            End Try
        End Sub

        Public Sub SetItems(items As List(Of OpenInvoiceCorrectionItem))
            _invoiceGrid.DataSource = Nothing
            _invoiceGrid.DataSource = If(items, New List(Of OpenInvoiceCorrectionItem))
        End Sub

        Public Sub SetSummary(negativeTotal As Decimal,
                              positiveUsed As Decimal,
                              remainingNegative As Decimal,
                              canPost As Boolean)
            _summaryLabel.Text = String.Format("Negative balances: {0:N2}    Positive amount used: {1:N2}    Remaining negative: {2:N2}",
                                                negativeTotal,
                                                positiveUsed,
                                                remainingNegative)
            _postButton.Enabled = canPost
        End Sub

        Public Sub SetStatus(status As String)
            _statusLabel.Text = status
        End Sub

        Public Function Confirm(message As String) As DialogResult
            Return MessageBox.Show(Me,
                                   message,
                                   "Open Invoice Correction",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning,
                                   MessageBoxDefaultButton.Button2)
        End Function

        Public Sub ShowError(message As String, title As String)
            MessageBox.Show(Me, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub

        Public Sub ShowInformation(message As String, title As String)
            MessageBox.Show(Me, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub InitializeUi()
            SuspendLayout()
            Text = "Open Invoice Reconciliation / Offset"
            StartPosition = FormStartPosition.CenterParent
            MinimumSize = New Size(950, 560)
            Size = New Size(1220, 720)

            Dim selectionPanel As New Panel With {
                .Dock = DockStyle.Top,
                .Height = 116,
                .Padding = New Padding(10)
            }

            Dim ledgerLabel As New Label With {.AutoSize = True, .Location = New Point(10, 14), .Text = "Ledger:"}
            _ledgerCombo.DropDownStyle = ComboBoxStyle.DropDownList
            _ledgerCombo.Location = New Point(70, 10)
            _ledgerCombo.Width = 190
            _ledgerCombo.DataSource = New List(Of OpenInvoiceCorrectionLedger) From {
                New OpenInvoiceCorrectionLedger With {.Code = "AR", .DisplayName = "Accounts Receivable"},
                New OpenInvoiceCorrectionLedger With {.Code = "AP", .DisplayName = "Accounts Payable"}
            }
            _ledgerCombo.DisplayMember = "DisplayName"
            _ledgerCombo.ValueMember = "Code"

            Dim contactLabel As New Label With {.AutoSize = True, .Location = New Point(280, 14), .Text = "Customer / Supplier:"}
            _contactCombo.DropDownStyle = ComboBoxStyle.DropDownList
            _contactCombo.Location = New Point(405, 10)
            _contactCombo.Width = 390

            Dim dateLabel As New Label With {.AutoSize = True, .Location = New Point(815, 14), .Text = "Correction date:"}
            _correctionDatePicker.Format = DateTimePickerFormat.Short
            _correctionDatePicker.Value = Date.Today
            _correctionDatePicker.Location = New Point(915, 10)
            _correctionDatePicker.Width = 120

            Dim notesLabel As New Label With {.AutoSize = True, .Location = New Point(10, 51), .Text = "Notes:"}
            _notesTextBox.Location = New Point(70, 47)
            _notesTextBox.Multiline = True
            _notesTextBox.ScrollBars = ScrollBars.Vertical
            _notesTextBox.Size = New Size(965, 52)
            _notesTextBox.Text = "Open invoice offset correction"

            Dim explanationLabel As New Label With {
                .AutoSize = False,
                .ForeColor = Color.DarkRed,
                .Location = New Point(10, 100),
                .Size = New Size(1120, 16),
                .Text = "Preview only until posted. Negative balances are applied oldest first up to the available positive amount; positive balances are consumed oldest transaction date first."
            }

            selectionPanel.Controls.AddRange(New Control() {ledgerLabel,
                                                             _ledgerCombo,
                                                             contactLabel,
                                                             _contactCombo,
                                                             dateLabel,
                                                             _correctionDatePicker,
                                                             notesLabel,
                                                             _notesTextBox,
                                                             explanationLabel})

            ConfigureInvoiceGrid()

            Dim bottomPanel As New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 86,
                .Padding = New Padding(10)
            }
            _summaryLabel.AutoSize = False
            _summaryLabel.Dock = DockStyle.Top
            _summaryLabel.Height = 24
            _summaryLabel.Font = New Font(Font, FontStyle.Bold)

            _statusLabel.AutoSize = False
            _statusLabel.Dock = DockStyle.Bottom
            _statusLabel.Height = 22
            _statusLabel.ForeColor = Color.DarkBlue

            _autoApplyButton.Text = "Auto Apply Negative First"
            _autoApplyButton.Size = New Size(190, 28)
            _autoApplyButton.Location = New Point(10, 29)

            _previewButton.Text = "Preview"
            _previewButton.Size = New Size(95, 28)
            _previewButton.Location = New Point(210, 29)

            _postButton.Text = "Post Correction"
            _postButton.Size = New Size(135, 28)
            _postButton.Location = New Point(315, 29)
            _postButton.Enabled = False

            bottomPanel.Controls.AddRange(New Control() {_summaryLabel,
                                                         _autoApplyButton,
                                                         _previewButton,
                                                         _postButton,
                                                         _statusLabel})

            Controls.Add(_invoiceGrid)
            Controls.Add(bottomPanel)
            Controls.Add(selectionPanel)

            AddHandler _ledgerCombo.SelectedIndexChanged, AddressOf LedgerComboSelectedIndexChanged
            AddHandler _contactCombo.SelectedIndexChanged, AddressOf ContactComboSelectedIndexChanged
            AddHandler _autoApplyButton.Click, AddressOf AutoApplyButtonClick
            AddHandler _previewButton.Click, AddressOf PreviewButtonClick
            AddHandler _postButton.Click, AddressOf PostButtonClick
            AddHandler MyBase.Load, AddressOf FormLoaded
            ResumeLayout(False)
        End Sub

        Private Sub ConfigureInvoiceGrid()
            _invoiceGrid.Dock = DockStyle.Fill
            _invoiceGrid.AllowUserToAddRows = False
            _invoiceGrid.AllowUserToDeleteRows = False
            _invoiceGrid.AutoGenerateColumns = False
            _invoiceGrid.ReadOnly = True
            _invoiceGrid.RowHeadersVisible = False
            _invoiceGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            _invoiceGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

            AddGridColumn("Invoice", "InvoiceNo", 150)
            AddGridColumn("Source journal", "JournalCode", 110)
            AddGridColumn("Journal ID", "JournalIdNo", 80)
            AddGridColumn("Transaction date", "TransactionDate", 115, "d")
            AddGridColumn("Account", "AccountIdNo", 75)
            AddGridColumn("Current balance", "CurrentBalance", 125, "N2")
            AddGridColumn("Proposed amount", "ProposedAmount", 125, "N2")
            AddGridColumn("Projected balance", "ProjectedBalance", 125, "N2")
        End Sub

        Private Sub AddGridColumn(headerText As String,
                                  propertyName As String,
                                  width As Int32,
                                  Optional format As String = Nothing)
            Dim column As New DataGridViewTextBoxColumn With {
                .HeaderText = headerText,
                .DataPropertyName = propertyName,
                .Width = width,
                .SortMode = DataGridViewColumnSortMode.NotSortable
            }
            If format IsNot Nothing Then column.DefaultCellStyle.Format = format
            _invoiceGrid.Columns.Add(column)
        End Sub

        Private Sub FormLoaded(sender As Object, e As EventArgs)
            If Presenter IsNot Nothing Then Presenter.Initialize()
        End Sub

        Private Sub LedgerComboSelectedIndexChanged(sender As Object, e As EventArgs)
            If Not _suppressEvents AndAlso Presenter IsNot Nothing Then Presenter.LedgerChanged()
        End Sub

        Private Sub ContactComboSelectedIndexChanged(sender As Object, e As EventArgs)
            If Not _suppressEvents AndAlso Presenter IsNot Nothing Then Presenter.ContactChanged()
        End Sub

        Private Sub AutoApplyButtonClick(sender As Object, e As EventArgs)
            If Presenter IsNot Nothing Then Presenter.AutoApply()
        End Sub

        Private Sub PreviewButtonClick(sender As Object, e As EventArgs)
            If Presenter IsNot Nothing Then Presenter.Preview()
        End Sub

        Private Sub PostButtonClick(sender As Object, e As EventArgs)
            If Presenter IsNot Nothing Then Presenter.PostCorrection()
        End Sub

    End Class

End Namespace
