Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports System.ComponentModel
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Forms

    Public Class ArJournalEntry
        Implements IArJournalView

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode
        Private _footer As DgvFooter
        Private _journalItems As List(Of JournalItemView)
        Private _revCostCenterByCode

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "ArJournal"
            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New ArJournalPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Fields"

        Public Property AccountIdNo As Int32? Implements IArJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Amount As Decimal Implements IArJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Cancelled As Boolean Implements IArJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property CustomerIdNo As Int32? Implements IArJournalView.CustomerIdNo
            Get
                Return cboCustomerIdNo.GetValue()
            End Get
            Set
                cboCustomerIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IArJournalView.DateCreated
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

        Public Property DueDate As Date? Implements IArJournalView.DueDate
            Get
                Return dtpDueDate.Value
            End Get
            Set
                'If Value.HasValue Then
                '    dtpDueDate.Value = Date.Now()
                'Else
                dtpDueDate.Value = Value
                'End If
            End Set
        End Property

        Public Property IdNo As Int32 Implements IArJournalView.IdNo
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

        Public Property InvoiceNo As String Implements IArJournalView.InvoiceNo
            Get
                Return txtInvoiceNo.Text
            End Get
            Set
                txtInvoiceNo.Text = Value
            End Set
        End Property

        Public Property JournalItems As List(Of JournalItemView) Implements IArJournalView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
                BindJournalItem()
            End Set
        End Property

        Public Property Notes As String Implements IArJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property Posted As Boolean Implements IArJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set(value As Boolean)
                chkPosted.Checked = value
            End Set
        End Property

        Public Property ReferenceNo As String Implements IArJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property SettlementDiscount As Decimal Implements IArJournalView.SettlementDiscount
            Get
                If txtSettlementDiscount.Text <> "" Then
                    Return Convert.ToDecimal(txtSettlementDiscount.Text)
                Else
                    Return 0D
                End If
            End Get
            Set
                txtSettlementDiscount.Text = Value
            End Set
        End Property

        Public Property SettlementDueDate As Date? Implements IArJournalView.SettlementDueDate
            Get
                Return dtpSettlementDueDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpSettlementDueDate.Value = Date.Now()
                Else
                    dtpSettlementDueDate.Value = Value
                End If
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements IArJournalView.TotalCredits
            Get
                Return TxtTotalCredits
            End Get
            Set(value As Decimal)
                TxtTotalCredits = value
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements IArJournalView.TotalDebits
            Get
                Return TxtTotalDebits
            End Get
            Set(value As Decimal)
                TxtTotalDebits = value
            End Set
        End Property

        Public Property TransactionDate As Date? Implements IArJournalView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpTransactionDate.Value = Date.Now()
                Else
                    dtpTransactionDate.Value = Value
                End If
                UpdateDueDate()
            End Set
        End Property

        Public Property TransactionType As String Implements IArJournalView.TransactionType
            Get
                Return cboTransactionType.GetValue()
            End Get
            Set
                cboTransactionType.SetValue(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
            _revCostCenterByCode = PresenterObj.GetRevCostCenterListByCode()
            cboCustomerIdNo.BeginUpdate()
            cboCustomerIdNo.DataSource = PresenterObj.GetCustomerListByCode()
            cboCustomerIdNo.EndUpdate()
            cboTransactionType.BeginUpdate()
            cboTransactionType.DataSource = PresenterObj.MakeEnumComboList(Of TransactionTypeSelection)
            cboTransactionType.EndUpdate()
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList(EnumToSpecialAccount(SpecialAccountSelection.AccountsReceivable))
            cboAccountIdNo.EndUpdate()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Amount", txtAmount},
         {"Cancelled", chkCancelled},
         {"CustomerIdNo", cboCustomerIdNo},
         {"DateCreated", txtDateCreated},
         {"DueDate", dtpDueDate},
         {"IdNo", TxtIdNo},
         {"InvoiceNo", txtInvoiceNo},
         {"Notes", txtNotes},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"SettlementDiscount", txtSettlementDiscount},
         {"SettlementDueDate", dtpSettlementDueDate},
         {"TransactionDate", dtpTransactionDate},
         {"TransactionType", cboTransactionType}
        }
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            UpdateTotals()
        End Sub

        Private Sub ArJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _footer = New DgvFooter(DataGridViewJournalItems)
            _footer.AutoCalc = True
            _footer.ColumnToSum("dgvDebit") = True
            _footer.ColumnToSum("dgvCredit") = True
            _footer.SetAlignment("dgvDebit", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvCredit", ContentAlignment.MiddleRight)
            _footer.SetText("DgvAccountIdNo", "Totals ->")
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

        Private Sub cboAccountIdNo_Validating(sender As Object, e As CancelEventArgs) Handles cboAccountIdNo.Validating
            If PaymentOrDiscountMade() Then
                ' revert to previous value
                cboAccountIdNo.RevertValue()
            End If
        End Sub

        Private Sub cboCustomerIdNo_Validated(sender As Object, e As EventArgs) Handles cboCustomerIdNo.Validated
            UpdateDueDate()
            UpdateEarlySettlementValues()
        End Sub

        Private Sub cboCustomerIdNo_Validating(sender As Object, e As CancelEventArgs) Handles cboCustomerIdNo.Validating
            If PaymentOrDiscountMade() Then
                ' revert to previous value
                cboCustomerIdNo.RevertValue()
            End If
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
                            Handles DataGridViewJournalItems.CellClick
            With DataGridViewJournalItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvinsertcolumn"
                        If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
                            If .RowIndex() = 0 Then
                                Messaging.Show(True, "MsgInvalidInsertOnFirstRow", "Sorry, insertion on first row not allowed for {transactionName}.",
                                               "Invalid Insertion", {"transactionName", "A.P. Journal Entry"})
                            Else
                                Dim newRow As New JournalItemView
                                bsJournalItems.Insert(.RowIndex(), newRow)
                                ReSequenceDgvAfterInsert()
                                SendKeys.Send("{UP}")
                            End If
                        Else
                            Messaging.Show(True, "MsgInvalidInsertOnViewMode", "Row insertion not allowed while in view mode. Press edit button to enable insertion.",
                                           "Invalid Insertion")
                        End If
                End Select
            End With
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            ReSequenceDgvAfterDelete()
            UpdateTotals()

        End Sub

        Private Overloads Sub Dispose()
            _footer.Dispose()
        End Sub

        Private Sub NeedUpdateFirstLine(sender As Object, e As EventArgs) Handles cboAccountIdNo.Validated, cboTransactionType.Validated, txtAmount.Validated
            PresenterObj.UpdateFirstLine()
            BindJournalItem()
            UpdateTotals()
            DataGridViewJournalItems.Refresh()
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) _
            Handles DataGridViewJournalItems.CellBeginEdit
            If DataGridViewJournalItems.CurrentCell.RowIndex() = 0 Then
                With DataGridViewJournalItems.CurrentCell
                    Dim cColumnName = .OwningColumn.Name.ToLower()
                    If cColumnName = $"dgvaccountidno" Or cColumnName = $"dgvdebit" Or cColumnName = $"dgvcredit" Then
                        Beep()
                        e.Cancel = True
                        DataGridViewJournalItems.EndEdit()
                    End If
                End With
            ElseIf (DataGridViewJournalItems.CurrentRow.Cells("dgvPaidAmount").Value <> 0 Or DataGridViewJournalItems.CurrentRow.Cells("dgvDiscountTaken").Value <> 0) _
                   And DataGridViewJournalItems.CurrentCell.OwningColumn.Name.ToLower() = $"dgvaccountidno" Then
                Beep()
                e.Cancel = True
                DataGridViewJournalItems.EndEdit()
                Messaging.Show(True, "MsgPaymentCollExistChangeNotAllowed")
            End If
        End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
            Handles DataGridViewJournalItems.CellEndEdit
            With DataGridViewJournalItems
                Select Case .CurrentCell.OwningColumn.Name.ToLower()
                    Case $"dgvaccountidno"
                        Dim nIndex = DataGridViewJournalItems.CurrentRow.Index
                        Dim newValue = DirectCast(DataGridViewJournalItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
                        If nIndex + 1 <= DataGridViewJournalItems.RowCount() Then
                            If nIndex < JournalItems.Count() Then
                                JournalItems(nIndex).AccountIdNo = newValue
                                BindJournalItem()
                            End If
                        End If
                    Case $"dgvdebit"
                        UpdateTotals()
                        SendKeys.Send("{TAB}")
                    Case $"dgvcredit"
                        UpdateTotals()
                    Case $"dgvnotes"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Protected Overrides Sub InputsTurnedOff()
            DataGridViewJournalItems.RemoveInsertColumn()
        End Sub

        Protected Overrides Sub InputsTurnedOn()
            DataGridViewJournalItems.AddInsertColumn()
        End Sub

        Private Sub OnTransactionDateValueChanged(sender As Object, e As EventArgs) Handles dtpTransactionDate.ValueChanged
            UpdateDueDate()
            UpdateEarlySettlementValues()
        End Sub

        Private Function PaymentOrDiscountMade()
            Dim retVal As Boolean = False
            If (DataGridViewJournalItems.Rows(0).Cells("dgvPaidAmount").Value <> 0 Or DataGridViewJournalItems.Rows(0).Cells("dgvDiscountTaken").Value <> 0) Then
                Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
                retVal = True
            End If
            Return retVal
        End Function

        Private Sub ReSequenceDgvAfterDelete()
            Dim i = DataGridViewJournalItems.CurrentCell.RowIndex()
            For Each item In bsJournalItems
                If item.Sequence > i + 1 Then
                    item.Sequence = item.Sequence - 1
                End If
            Next
        End Sub

        Private Sub ReSequenceDgvAfterInsert()
            Dim i = DataGridViewJournalItems.CurrentCell.RowIndex()
            For Each item In bsJournalItems
                If item.Sequence = 0 Then
                    item.Sequence = i
                ElseIf item.Sequence >= i Then
                    item.Sequence = item.Sequence + 1
                End If
            Next
        End Sub

        Private Sub txtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If DataGridViewJournalItems IsNot Nothing Then
                DataGridViewJournalItems.Focus()
            End If
        End Sub

        Private Sub UpdateDueDate()
            If cboCustomerIdNo.Text IsNot Nothing Then
                Dim customerPaymentDueDays =
                        PresenterObj.GetCustomerPaymentDueDays(cboCustomerIdNo.SelectedValue)
                DueDate = DateAdd("d", customerPaymentDueDays, TransactionDate)
            Else
                dtpDueDate.Value = TransactionDate
            End If
        End Sub

        Private Sub UpdateEarlySettlementValues()
            If cboCustomerIdNo.Text IsNot Nothing Then
                Dim customerSettlementDueDays =
                        PresenterObj.GetCustomerSettlementDueDays(cboCustomerIdNo.SelectedValue)
                Dim customerSettlementDiscount As Decimal
                customerSettlementDiscount = PresenterObj.GetCustomerSettlementDiscount(cboCustomerIdNo.SelectedValue)
                SettlementDueDate = DateAdd("d", customerSettlementDueDays, TransactionDate)
                txtSettlementDiscount.Text = customerSettlementDiscount
            Else
                dtpSettlementDueDate.Value = TransactionDate
                txtSettlementDiscount.Text = 0
            End If
        End Sub

        Private Sub UpdateTotals()
            If _footer IsNot Nothing Then
                _footer.SumAllColumns()
                'TotalDebits = _footer.Value("dgvDebit")
                'TotalCredits = _footer.Value("dgvCredit")
            End If
        End Sub

        Private Sub UserDeletingRow(ByVal sender As Object,
                                            ByVal e As DataGridViewRowCancelEventArgs) _
            Handles DataGridViewJournalItems.UserDeletingRow
            ' Check if the starting balance row is included in the selected rows
            Dim arJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)

            ' Check if the starting balance row is included in the selected rows
            If DataGridViewJournalItems.SelectedRows.Contains(arJournalRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            ElseIf PresenterObj.EditMode Then
                Dim jiIdNo As Integer
                jiIdNo = DataGridViewJournalItems.CurrentRow.Cells("dgvIdNo").Value
                If PresenterObj.ArCollectionExists("AR", jiIdNo) Then
                    ' Do not allow the user to delete items with existing payments/discounts (prevent orphaned records)
                    Messaging.Show(True, "MsgDeleteCollEntryNotAllowed")
                    ' Cancel the deletion
                    e.Cancel = True
                End If
            End If
        End Sub

    End Class

End Namespace