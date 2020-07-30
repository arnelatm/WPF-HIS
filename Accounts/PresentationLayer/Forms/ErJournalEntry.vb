Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports System.ComponentModel
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary

Namespace PresentationLayer.Forms

    Public Class ErJournalEntry
        Implements IErJournalView

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
            MainTableName = "ErJournal"
            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New ErJournalPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Fields"

        Public Property AccountIdNo As Int32? Implements IErJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Amount As Decimal Implements IErJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Cancelled As Boolean Implements IErJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property EmployeeIdNo As Int32? Implements IErJournalView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetValue()
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IErJournalView.DateCreated
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

        Public Property IdNo As Int32 Implements IErJournalView.IdNo
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

        Public Property JournalItems As List(Of JournalItemView) Implements IErJournalView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
                BindJournalItem()
            End Set
        End Property

        Public Property Notes As String Implements IErJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property Posted As Boolean Implements IErJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set(value As Boolean)
                chkPosted.Checked = value
            End Set
        End Property

        Public Property ReferenceNo As String Implements IErJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements IErJournalView.TotalCredits
            Get
                Return TxtTotalCredits
            End Get
            Set(value As Decimal)
                TxtTotalCredits = value
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements IErJournalView.TotalDebits
            Get
                Return TxtTotalDebits
            End Get
            Set(value As Decimal)
                TxtTotalDebits = value
            End Set
        End Property

        Public Property TransactionDate As Date? Implements IErJournalView.TransactionDate
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

        Public Property TransactionType As String Implements IErJournalView.TransactionType
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
            cboEmployeeIdNo.BeginUpdate()
            cboEmployeeIdNo.DataSource = PresenterObj.GetEmployeeListByCode()
            cboEmployeeIdNo.EndUpdate()
            cboTransactionType.BeginUpdate()
            cboTransactionType.DataSource = PresenterObj.MakeEnumComboList(Of TransactionTypeSelection)
            cboTransactionType.EndUpdate()
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList(EnumToSpecialAccount(SpecialAccountSelection.EmployeeLoan))
            cboAccountIdNo.EndUpdate()
        End Sub

        'Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) _
        '    Handles MyBase.ParentRecordUpdatedSuccessfully, MyBase.ParentRecordAddedSuccessfully
        '    If PresenterObj.AddMode Then
        '        IdNo = passedValue
        '    End If
        '    If DtInsertTable IsNot Nothing Then
        '        DtInsertTable.Clear()
        '    End If
        '    If DtUpdateTable IsNot Nothing Then
        '        DtUpdateTable.Clear()
        '    End If
        '    Dim oldJournalItem As List(Of JournalItemModel)
        '    If Not PresenterObj.AddMode Then
        '        'oldJournalItem = _journalItemsPresenter.GetRecordsWithIdNo(IdNo)
        '        oldJournalItem = _journalItemsPresenter.ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
        '    Else
        '        oldJournalItem = Nothing
        '    End If
        '    Dim nRowCount = 1
        '    For Each ji In bsJournalItems
        '        Dim workRow As DataRow
        '        If ji.IdNo <= 0 Then
        '            workRow = DtInsertTable.NewRow()
        '        Else
        '            workRow = DtUpdateTable.NewRow()
        '            workRow("IdNo") = ji.IdNo
        '        End If
        '        workRow("JournalIdNo") = IdNo
        '        workRow("Sequence") = nRowCount
        '        workRow("AccountIdNo") = ji.AccountIdNo
        '        workRow("Debit") = ji.Debit
        '        workRow("Credit") = ji.Credit
        '        workRow("RevCostCenterIdNo") = ji.RevCostCenterIdNo
        '        workRow("Notes") = If(ji.Notes, "")
        '        If ji.IdNo <= 0 Then
        '            DtInsertTable.Rows.Add(workRow)
        '        Else
        '            DtUpdateTable.Rows.Add(workRow)
        '        End If
        '        nRowCount = nRowCount + 1
        '    Next
        '    _journalItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
        '    Dim newJournalItem As List(Of JournalItemModel)
        '    If PresenterObj.AddMode Then
        '        newJournalItem = _journalItemsPresenter.ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
        '        For Each item In newJournalItem
        '            If _journalItemsPresenter.IsAccountsReceivableAccount(item.AccountIdNo) Then
        '                PresenterObj.AddArOpenInvoice(item, "ER")
        '            End If
        '        Next
        '    Else
        '        newJournalItem = _journalItemsPresenter.ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
        '        Dim newItem
        '        Dim oldItem
        '        Dim newIsAr
        '        Dim oldIsAr
        '        For Each oldItem In oldJournalItem
        '            ' deletion of paid A.R. entries not allowed (see UserDeletingRow - sub  below) therefore all entries here are unpaid
        '            ' so no problem on deletion
        '            oldIsAr = _journalItemsPresenter.IsAccountsReceivableAccount(oldItem.AccountIdNo)
        '            If oldIsAr Then
        '                ' this item is ER
        '                newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
        '                If newItem Is Nothing Then
        '                    ' item was deleted
        '                    PresenterObj.DeleteArOpenInvoice(oldItem.OpenInvoiceIdNo)
        '                Else
        '                    ' item is found
        '                    newIsAr = _journalItemsPresenter.IsAccountsReceivableAccount(newItem.AccountIdNo)
        '                    If newIsAr Then
        '                        ' nothing to do
        '                    Else
        '                        ' new is changed from ER to non-ER
        '                        PresenterObj.DeleteArOpenInvoice(oldItem.OpenInvoiceIdNo)
        '                    End If
        '                End If
        '            Else
        '                ' this item is Non-ER
        '                newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
        '                If newItem Is Nothing Then
        '                    ' item is deleted just ignore Non-ER
        '                Else
        '                    ' old item still in new
        '                    newIsAr = _journalItemsPresenter.IsAccountsReceivableAccount(newItem.AccountIdNo)
        '                    If newIsAr Then
        '                        PresenterObj.AddArOpenInvoice(newItem, "ER")
        '                    Else
        '                        ' new is also Non-ER
        '                        ' nothing to do
        '                    End If
        '                End If
        '            End If
        '        Next
        '        For Each newItem In newJournalItem
        '            newIsAr = _journalItemsPresenter.IsAccountsReceivableAccount(newItem.AccountIdNo)
        '            oldItem = oldJournalItem.Find(Function(c) c.IdNo = newItem.IdNo)
        '            If oldItem Is Nothing Then
        '                ' this item is new
        '                If newIsAr Then
        '                    ' this new item is an ER
        '                    PresenterObj.AddArOpenInvoice(newItem, "ER")
        '                Else
        '                    ' non - ER nothing to do
        '                End If
        '            Else
        '                ' old item, already taken off in first (oldItem) for-loop
        '            End If
        '        Next
        '    End If
        'End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Amount", txtAmount},
         {"Cancelled", chkCancelled},
         {"EmployeeIdNo", cboEmployeeIdNo},
         {"DateCreated", txtDateCreated},
         {"IdNo", TxtIdNo},
         {"Notes", txtNotes},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"TransactionDate", dtpTransactionDate},
         {"TransactionType", cboTransactionType}
        }
        End Sub

        Protected Overrides Sub RecordPositionChanged()
            MyBase.RecordPositionChanged()
            UpdateTotals()
        End Sub

        Private Sub ErJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Private Sub cboEmployeeIdNo_Validating(sender As Object, e As CancelEventArgs) Handles cboEmployeeIdNo.Validating
            If PaymentOrDiscountMade() Then
                ' revert to previous value
                cboEmployeeIdNo.RevertValue()
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
                                Dim newRow As New JournalItemModel
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
            UpdateFirstLine()
        End Sub

        'Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    If PresenterObj.AddMode Then
        '        txtJournalCode.Text = AccountStrings.ErJournalPrefix
        '    End If
        '    If bsJournalItems Is Nothing OrElse bsJournalItems.Count() = 0 Then
        '        If Messaging.Show(True, "AskIfSaveEmptyJournal",
        '                          "Journal Entry is Empty, do you still want to save this entry?",
        '                          "Empty Journal",
        '                          MessageBoxButtons.YesNo,
        '                          MessageBoxIcon.Question,
        '                          MessageBoxDefaultButton.Button2) = DialogResult.No Then
        '            PresenterObj.CancelSave = True
        '        End If
        '    End If

        'End Sub

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
                Messaging.Show(True, "MsgPaymentCollExistChangeNotAllowed", "Sorry, this account receivable has already been partially or fully collected/discounted, changing account/Employee not allowed. Value will revert to previous value.", "Modification Error")
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

        Private Sub OnInputsTurnedOff() Handles Me.InputsTurnedOff
            DataGridViewJournalItems.RemoveInsertColumn()
        End Sub

        Private Sub OnInputsTurnedOn() Handles Me.InputsTurnedOn
            DataGridViewJournalItems.AddInsertColumn()
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

        Private Sub UpdateFirstLine()
            PresenterObj.UpdateFirstLine()
            BindJournalItem()
            UpdateTotals()
            DataGridViewJournalItems.Refresh()
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
            Dim ErJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)

            ' Check if the starting balance row is included in the selected rows
            If DataGridViewJournalItems.SelectedRows.Contains(ErJournalRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            ElseIf DataGridViewJournalItems.CurrentRow.Cells("dgvPaidAmount").Value <> 0 Or
                   DataGridViewJournalItems.CurrentRow.Cells("dgvDiscountTaken").Value <> 0 Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgDeleteCollEntryNotAllowed", "You can't delete this row because this entry has an existing collection and/or discount!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub

    End Class

End Namespace