Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class ApJournalPresenter
        Inherits AccountsPresenter(Of IApJournalView, ApJournalModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _apJournalItemModel As New ModelAccounts("ApJournalItem")
        Private ReadOnly _apOpenInvoiceModel As New ModelAccounts("ApOpenInvoice")

        Public Sub New(view As IApJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("ApJournal")
            TableName = "ApJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New ApJournalModel()
            DataModel = New ApJournalModel
            GlobalVariables.EventAggregator.SubscribeEvent(Me)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Credit", GetType(Decimal))
            DtInsertTable.Columns.Add("Debit", GetType(Decimal))
            DtInsertTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Notes", GetType(String))
            DtInsertTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Credit", GetType(Decimal))
            DtUpdateTable.Columns.Add("Debit", GetType(Decimal))
            DtUpdateTable.Columns.Add("IDNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            If IsEmpty(View.ReferenceNo) Then
                UpdateGlReferenceNumber()
            End If
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            Dim nRowCount = 1
            For Each ji In View.JournalItems
                If ji.AccountIdNo = 0 AndAlso ji.Debit = 0 AndAlso ji.Credit = 0 Then
                    ' ignore these records (no amount no account)
                Else
                    Dim workRow As DataRow
                    If ji.IdNo <= 0 Then
                        workRow = DtInsertTable.NewRow()
                    Else
                        workRow = DtUpdateTable.NewRow()
                        workRow("IdNo") = ji.IdNo
                    End If
                    workRow("JournalIdNo") = View.IdNo
                    workRow("Sequence") = nRowCount
                    workRow("AccountIdNo") = ji.AccountIdNo
                    workRow("Debit") = ji.Debit
                    workRow("Credit") = ji.Credit
                    workRow("ProfitCenterIdNo") = ji.ProfitCenterIdNo
                    workRow("Notes") = If(ji.Notes, "")
                    If ji.IdNo <= 0 Then
                        DtInsertTable.Rows.Add(workRow)
                    Else
                        DtUpdateTable.Rows.Add(workRow)
                    End If
                    nRowCount = nRowCount + 1
                End If
            Next
        End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            UpdateTotals()
        End Sub

        Public Function SaveChildren(ByRef retVal As Integer) Handles MyBase.ParentRecordAddedSuccessfully, MyBase.ParentRecordUpdatedSuccessfully
            Dim insertReturnValue
            Dim updateReturnValue
            Dim headerIdNo As Int32
            If AddMode Then
                headerIdNo = retVal
                CallByName(View, IdFieldName, CallType.Set, retVal)
            Else
                headerIdNo = CallByName(View, IdFieldName, CallType.Get)
            End If
            updateReturnValue = ModelPresenter.DelUpdateTvp(DtUpdateTable, headerIdNo)
            If updateReturnValue >= 0 AndAlso DtInsertTable.Rows.Count > 0 Then
                For Each row As DataRow In DtInsertTable.Rows
                    row.Item("JournalIdNo") = headerIdNo
                Next
                insertReturnValue = Model.InsertTvp(DtInsertTable)
                If insertReturnValue >= 0 Then
                    retVal = updateReturnValue + insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Dim newJournalItem As List(Of JournalItemModel)
            If AddMode Then
                newJournalItem = ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(View.IdNo, "Sequence")
                For Each item In newJournalItem
                    If IsAccountsPayableAccount(item.AccountIdNo) Then
                        AddApOpenInvoice(item, "AP")
                    End If
                Next
            Else
                newJournalItem = ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(View.IdNo, "Sequence")
                Dim newItem
                Dim oldItem
                Dim newIsAp
                Dim oldIsAp
                Dim oldJournalItem As List(Of JournalItemModel)
                If Not AddMode Then
                    oldJournalItem = OriginalModel.Journalitems
                Else
                    oldJournalItem = Nothing
                End If
                For Each oldItem In oldJournalItem
                    ' deletion of paid A.P. entries not allowed (see UserDeletingRow - sub  below) therefore all entries here are unpaid
                    ' so no problem on deletion
                    oldIsAp = IsAccountsPayableAccount(oldItem.AccountIdNo)
                    If oldIsAp Then
                        ' this item is AP
                        newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
                        If newItem Is Nothing Then
                            ' item was deleted
                            DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
                        Else
                            ' item is found
                            newIsAp = IsAccountsPayableAccount(newItem.AccountIdNo)
                            If newIsAp Then
                                ' nothing to do
                            Else
                                ' new is changed from AP to non-AP
                                DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
                            End If
                        End If
                    Else
                        ' this item is Non-AP
                        newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
                        If newItem Is Nothing Then
                            ' item is deleted just ignore Non-AP
                        Else
                            ' old item still in new
                            newIsAp = IsAccountsPayableAccount(newItem.AccountIdNo)
                            If newIsAp Then
                                AddApOpenInvoice(newItem, "AP")
                            Else
                                ' new is also Non-AP
                                ' nothing to do
                            End If
                        End If
                    End If
                Next
                For Each newItem In newJournalItem
                    newIsAp = IsAccountsPayableAccount(newItem.AccountIdNo)
                    oldItem = Nothing
                    For Each item In OriginalModel.JournalItems
                        If newItem.IdNo = item.IdNo Then
                            ' meaning it is the same record
                            oldItem = item
                            Exit For
                        End If
                    Next
                    'oldItem = OriginalModel.JournalItems.Find(Function(c) c.IdNo = x)
                    If oldItem Is Nothing Then
                        ' this item is new
                        If newIsAp Then
                            ' this new item is an AP
                            AddApOpenInvoice(newItem, "AP")
                        Else
                            ' non - AP nothing to do
                        End If
                    Else
                        ' old item, already taken off in first (oldItem) for-loop
                    End If
                Next
            End If
            If retVal > 0 Then
                If IsEmpty(View.ReferenceNo) Then
                    UpdateGlReferenceNumber()
                End If
            End If
            Return retVal
        End Function

        Public Sub UpdateFirstLine()
            If EditMode Or AddMode Then
                If View.JournalItems.Count() = 0 Then
                    View.JournalItems = New List(Of JournalItemView)
                    View.JournalItems.Add(NewJournalItem)
                End If
                For Each item In View.JournalItems
                    item.JournalIdNo = View.IdNo
                    item.Sequence = 1
                    item.AccountIdNo = View.AccountIdNo
                    Dim tranType As String = TransactionTypeToEnum(View.TransactionType)
                    If tranType = TransactionTypeSelection.Invoice Or tranType = TransactionTypeSelection.Credit Then
                        item.Credit = View.Amount
                        item.Debit = 0
                    Else
                        item.Credit = 0
                        item.Debit = View.Amount
                    End If
                    item.ProfitCenterIdNo = 0
                    Exit For
                Next
            End If
        End Sub

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public Function UpdateOpenInvoice(ByRef journalItem As JournalItemModel, ByVal addBalance As Decimal) As String
            Dim retValue As String
            Dim openInvoiceModel As New ApOpenInvoiceModel
            openInvoiceModel.DiscountTaken = journalItem.DiscountTaken
            openInvoiceModel.PaidAmount = journalItem.PaidAmount
            openInvoiceModel.IdNo = journalItem.IdNo
            openInvoiceModel.JournalItemIdNo = journalItem.IdNo
            retValue = _apOpenInvoiceModel.UpdateRecord(Of ApOpenInvoiceModel)(openInvoiceModel)
            Return retValue
        End Function

        Public Sub UpdateTotals()
            View.TotalDebits = 0
            View.TotalCredits = 0
            For Each item In View.JournalItems
                View.TotalDebits += item.Debit
                View.TotalCredits += item.Credit
            Next
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                Dim cPayeeType As String
                Dim cashAccount As String = EnumToSpecialAccount(SpecialAccountSelection.Bank) + "|" + EnumToSpecialAccount(SpecialAccountSelection.Cash) + "|" + EnumToSpecialAccount(SpecialAccountSelection.PettyCashAccount)
                Dim specialAccount As String
                Dim chart As ChartModel
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("AP Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If Messaging.IsDateRangeValid("Accounts Payable", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                Else
                    For Each item In View.JournalItems
                        chart = GetChart(item.AccountIdNo)
                        specialAccount = chart.SpecialAccount
                        If item.AccountIdNo = 0 AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                            MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                            retValue = False
                            Exit For
                        ElseIf specialAccount IsNot Nothing AndAlso cashAccount.Contains(specialAccount) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Dim caption = "Invalid Entry!"
                            Dim message = Messaging.GetMessage(True, "MsgCashAccountsNotAllowed", "Error on line <{lineNumber}>. Cash accounts not allowed for this transaction.", "Invalid Entry")
                            message = message.Interpolate(Function(x) lineNumber)
                            Messaging.Show(message, caption)
                            retValue = False
                        Else
                            cPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                            If Not String.IsNullOrEmpty(cPayeeType) AndAlso PayeeTypeToEnum(cPayeeType) <> PayeeTypeSelection.Supplier Then
                                Dim lineNumber = Format(item.Sequence, "0")
                                Dim entryNames = Messaging.TranslateCaption("Accounts Receivables/Employee Loans")
                                Dim caption = "Invalid Entry"
                                Dim variables As String() = {"lineNumber", lineNumber, "entryNames", entryNames}
                                Dim message = Messaging.GetMessage(True, "MsgAccountsNotAllowed", "Error on line {lineNumber}. Sorry {entryNames} not allowed for this transaction!", caption)
                                caption = Messaging.TranslateCaption(caption)
                                Messaging.Show(message, caption, variables, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                retValue = False
                            End If
                        End If
                    Next
                End If
            End If
            Return retValue
        End Function

        Private Function NewJournalItem()
            Dim item As New JournalItemView With {
                    .JournalIdNo = View.IdNo,
                    .Sequence = 0,
                    .AccountIdNo = Nothing,
                    .Credit = View.Amount,
                    .Debit = 0,
                    .ProfitCenterIdNo = 0,
                    .Notes = ""
                    }
            Return item
        End Function

    End Class

End Namespace