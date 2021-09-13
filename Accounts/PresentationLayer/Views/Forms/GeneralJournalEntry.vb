Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class GeneralJournalEntry
        Implements IGeneralJournalView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode
        Private _footer As DgvFooter
        Private _journalItems As List(Of JournalItemView)
        Private _revCostCenterByCode
        Private ReadOnly _closingEntry As Boolean

        Public Sub New(closingEntry As Boolean)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            _closingEntry = closingEntry
            ClosingJournal = _closingEntry
            FirstControl = txtReferenceNo
            _nfi.NumberDecimalDigits = 2
        End Sub

        ' This event handler provides custom item-creation behavior.
        Public ReadOnly Property ClosingEntry As Boolean
            Get
                Return _closingEntry
            End Get
        End Property

#Region "Fields"

        Public Property Cancelled As Boolean Implements IGeneralJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property ClosingJournal As Boolean Implements IGeneralJournalView.ClosingJournal
            Get
                Return chkClosingJournal.Checked
            End Get
            Set(value As Boolean)
                chkClosingJournal.Checked = value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IGeneralJournalView.DateCreated
            Get
                Return dtpDateCreated.Value
            End Get
            Set
                If Value.HasValue Then
                    dtpDateCreated.Value = Value
                Else
                    dtpDateCreated.Value = Date.Now()
                End If
            End Set
        End Property

        'Public Property GeneralJournalItemsDataSource As List(Of JournalItemModel)

        Public Property IdNo As Int32 Implements IGeneralJournalView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt16(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property JournalItems As List(Of JournalItemView) Implements IGeneralJournalView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
                BindJournalItem()
            End Set
        End Property

        Public Property Notes As String Implements IGeneralJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property Posted As Boolean Implements IGeneralJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set
                chkPosted.Checked = Value
            End Set
        End Property

        Public Property ReferenceNo As String Implements IGeneralJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public ReadOnly Property TotalDebits As Decimal Implements IGeneralJournalView.TotalDebits
            Get
                Return NumParser(Of Decimal)(txtTotalDebits.Text)
            End Get
        End Property

        Public ReadOnly Property TotalCredits As Decimal Implements IGeneralJournalView.TotalCredits
            Get
                Return NumParser(Of Decimal)(_footer.Value("dgvCredit"))
            End Get
        End Property

        Public Property TransactionDate As Date? Implements IGeneralJournalView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpTransactionDate.Value = Date.Now()
                Else
                    dtpTransactionDate.Value = Value
                End If
            End Set
        End Property

        Public Property Approved As Boolean Implements IGeneralJournalView.Approved
            Get
                Return chkApproved.Checked
            End Get
            Set
                chkApproved.Checked = Value
            End Set
        End Property

#End Region

#Region "Methods"

        Protected Overrides Sub CreateDataSources()
            CreateLookupData("Account", NameOf(_accountsByCode), "DetailAccount=1")
            CreateLookupData("RevCostCenter", NameOf(_revCostCenterByCode))
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"Cancelled", chkCancelled},
         {"DateCreated", dtpDateCreated},
         {"IdNo", TxtIdNo},
         {"Notes", txtNotes},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"TransactionDate", dtpTransactionDate},
         {"TotalDebits", txtTotalDebits},
         {"TotalCredits", txtTotalCredits}
         }
        End Sub

        Protected Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            UpdateTotals()
        End Sub

        Private Sub BindJournalItem()
            'SuspendLayout()
            bsJournalItems.DataSource = Nothing
            DataGridViewJournalItems.Refresh()
            bsJournalItems.DataSource = JournalItems
            bsJournalItems.AllowNew = True
            With DataGridViewJournalItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsJournalItems
                .Refresh()
            End With
            With DataGridViewJournalItems.Columns
                dgvSequence.DisplayOnly = True
                dgvAccountIdNo.DataSource = _accountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                dgvAccountIdNo.AutoComplete = True
                dgvRevCostCenterIdNo.DataSource = _revCostCenterByCode
                dgvRevCostCenterIdNo.DisplayMember = "Name"
                dgvRevCostCenterIdNo.ValueMember = "idNo"
                dgvRevCostCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            'ResumeLayout()
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            UpdateTotals()
        End Sub

        Private Overloads Sub Dispose()
            _footer.Dispose()
        End Sub

        Private Sub GeneralJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If GlobalVariables.RightToLeftLayout Then
                txtJournalCode.Text = Presenter.GetLocalizedPrefix("GJ")
            Else
                txtJournalCode.Text = "GJ"
            End If
            _footer = New DgvFooter(DataGridViewJournalItems) With {
                .AutoCalc = True
            }
            _footer.ColumnToSum("dgvDebit") = True
            _footer.ColumnToSum("dgvCredit") = True
            _footer.SetAlignment("dgvDebit", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvCredit", ContentAlignment.MiddleRight)
            _footer.SetText("DgvAccountIdNo", "Totals ->")
        End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewJournalItems.CellEndEdit
            With DataGridViewJournalItems
                If .CurrentRow IsNot Nothing Then
                    Select Case .CurrentCell.OwningColumn.Name.ToLower()
                        Case $"dgvaccountidno"
                        'SendKeys.Send("{TAB}")
                        Case $"dgvdebit"
                            UpdateTotals()
                            SendKeys.Send("{TAB}")
                        Case $"dgvcredit"
                            UpdateTotals()
                        Case $"dgvnotes"
                            SendKeys.Send("{DOWN}")
                    End Select
                    .Refresh()
                End If
            End With
        End Sub

        Private Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
            chkClosingJournal.Checked = _closingEntry
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If DataGridViewJournalItems IsNot Nothing Then
                DataGridViewJournalItems.Focus()
            End If
        End Sub

        Private Sub UpdateTotals()
            If _footer IsNot Nothing Then
                _footer.CalculateTotals()
                txtTotalDebits.Text = _footer.Value("dgvDebit")
                txtTotalCredits.Text = _footer.Value("dgvCredit")
            End If
        End Sub

#End Region

    End Class

End Namespace