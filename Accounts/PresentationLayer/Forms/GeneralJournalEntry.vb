Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Forms

    Public Class GeneralJournalEntry
        Implements IGeneralJournalView, ISubscriber(Of InsertDgvLine)

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode
        Private _footer As DgvFooter
        Private _journalItems As List(Of JournalItemView)
        Private _revCostCenterByCode
        Private ReadOnly _closingEntry As Boolean
        Private ReadOnly _dgvEa As EventAggregator

        Public Sub New(ByVal closingEntry As Boolean)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            _closingEntry = closingEntry
            ClosingJournal = _closingEntry
            If Not closingEntry Then
                Text = "General Journal Entry"
                MainTableName = "GeneralJournalNormal_View"
            Else
                Text = "Closing Entry"
                MainTableName = "GeneralJournalClosing_View"
            End If

            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New GeneralJournalPresenter(Me, _closingEntry)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
            _dgvEa = DataGridViewJournalItems.Ea
            _dgvEa.SubscribeEvent(Me)

        End Sub

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
                If String.IsNullOrEmpty(txtDateCreated.Text) Then
                    Return Now()
                End If
                Return Convert.ToDateTime(txtDateCreated.Text)
            End Get
            Set(value As DateTime?)
                If value Is Nothing Then
                    txtDateCreated.Text = Nothing
                Else
                    txtDateCreated.Text = String.Format(CultureInfo.CurrentCulture, "{0:g}", value)
                End If
            End Set
        End Property

        Public Property GeneralJournalItemsDataSource As List(Of JournalItemModel)

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

        Public Property TotalCredits As Decimal Implements IGeneralJournalView.TotalCredits
            Get
                Return TxtTotalCredits
            End Get
            Set(value As Decimal)
                TxtTotalCredits = value
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements IGeneralJournalView.TotalDebits
            Get
                Return TxtTotalDebits
            End Get
            Set(value As Decimal)
                TxtTotalDebits = value
            End Set
        End Property

        'Public TotalCredits As Decimal Implements IGeneralJournalView.TotalCredits
        '    Get
        '        Return _footer.Value("dgvCredit")
        '    End Get
        'End Property

        'Public ReadOnly TotalDebits As Decimal Implements IGeneralJournalView.TotalDebits
        '    Get
        '        Return _footer.Value("dgvDebit")
        '    End Get
        'End Property

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

#End Region

#Region "Methods"

        Public Sub OnEventHandler(ByRef eventType As InsertDgvLine) Implements ISubscriber(Of InsertDgvLine).OnEventHandler
            bsJournalItems.Insert(eventType.BsRow, New JournalItemView)
        End Sub

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
            _revCostCenterByCode = PresenterObj.GetRevCostCenterListByCode()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"Cancelled", chkCancelled},
         {"DateCreated", txtDateCreated},
         {"IdNo", TxtIdNo},
         {"Notes", txtNotes},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"TransactionDate", dtpTransactionDate}
        }
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            UpdateTotals()
        End Sub

        Private Sub BindJournalItem()
            SuspendLayout()
            bsJournalItems.DataSource = Nothing
            DataGridViewJournalItems.Refresh()
            bsJournalItems.DataSource = JournalItems
            bsJournalItems.AllowNew = True
            With DataGridViewJournalItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsJournalItems
                .Refresh()
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
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
            ResumeLayout()
        End Sub


        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            UpdateTotals()
        End Sub

        Private Overloads Sub Dispose()
            _footer.Dispose()
        End Sub

        Private Sub GeneralJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _footer = New DgvFooter(DataGridViewJournalItems)
            _footer.AutoCalc = True
            _footer.ColumnToSum("dgvDebit") = True
            _footer.ColumnToSum("dgvCredit") = True
            _footer.SetAlignment("dgvDebit", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvCredit", ContentAlignment.MiddleRight)
            _footer.SetText("DgvAccountIdNo", "Totals ->")
        End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
                    Handles DataGridViewJournalItems.CellEndEdit
            With DataGridViewJournalItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
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
                DataGridViewJournalItems.Refresh()
            End With
        End Sub

        Protected Overrides Sub InputsTurnedOff()
            DataGridViewJournalItems.RemoveInsertColumn()
        End Sub

        Protected Overrides Sub InputsTurnedOn()
            DataGridViewJournalItems.AddInsertColumn()
            chkClosingJournal.Checked = _closingEntry
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If DataGridViewJournalItems IsNot Nothing Then
                DataGridViewJournalItems.Focus()
            End If
        End Sub

        Private Sub UpdateTotals()
            If _footer IsNot Nothing Then
                _footer.SumAllColumns()
                TotalDebits = _footer.Value("dgvDebit")
                TotalCredits = _footer.Value("dgvCredit")
            End If
        End Sub

#End Region

    End Class

End Namespace