Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class ArJournalPresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IArJournalView, TM)
        Implements ISubscriber(Of DgvItemsChanged)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _arJournalItemService As New AccountsService("JournalItem", Nothing, {"ArJournalItem_View", "dbo.UpdateArJournalItemTVP", "dbo.InsertArJournalItemTVP"})

        Public Sub New(view As IArJournalView)
            MyBase.New(view)
            TableName = "ArJournal"
            WithTreeView = False
            Service = New AccountsService("ArJournal")
            SortOrderKey = "IdNo"
            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Credit", GetType(Decimal))
            DtInsertTable.Columns.Add("Debit", GetType(Decimal))
            DtInsertTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Notes", GetType(String))
            DtInsertTable.Columns.Add("PayIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Credit", GetType(Decimal))
            DtUpdateTable.Columns.Add("Debit", GetType(Decimal))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("PayIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))

        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateLookupData("Account", "AccountsByCode", "DetailAccount=1")
            CreateLookupData("RevCostCenter", "RevCostCentersByCode")
            CreateDataSource("Customer", "CustomerIdNo")
            CreateEnumDataSource(Of TransactionTypeSelection)("TransactionType")
            CreateSpecialAccountDataSource("AccountIdNo", {EnumToCode(SpecialAccountSelection.AccountsReceivable)})
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf JournalItemFilter)
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("JournalIdNo") = View.IdNo
            workRow("AccountIdNo") = itemDataView.AccountIdNo
            workRow("Debit") = itemDataView.Debit
            workRow("Credit") = itemDataView.Credit
            workRow("PayIdNo") = itemDataView.PayIdNo
            workRow("RevCostCenterIdNo") = itemDataView.RevCostCenterIdNo
            workRow("Notes") = If(itemDataView.Notes, "")
        End Sub

        Public Function JournalItemFilter(ByVal obj As Object) As Boolean
            If (obj.AccountIdNo Is Nothing Or obj.AccountIdNo = 0) AndAlso obj.Debit = 0 AndAlso obj.Credit = 0 Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_arJournalItemService, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 Then
                Dim newJournalItem As List(Of JournalItemModel)
                newJournalItem = _arJournalItemService.GetRecordsWithGroupIdNo(Of JournalItemModel)(View.IdNo, "Sequence")
                If AddMode Then
                    For Each item In newJournalItem
                        If IsAccountsReceivableAccount(item.AccountIdNo) Then
                            retVal = AddArOpenInvoice(item, "AR")
                            If retVal < 0 Then
                                Exit For
                            End If
                        End If
                    Next
                Else
                    retVal = RemoveDeletedArOpenInvoices(retVal, newJournalItem)
                    If retVal >= 0 Then
                        retVal = AddNewArOpenInvoices(retVal, newJournalItem)
                    End If
                End If
            End If
            If retVal >= 0 Then
                If IsEmpty(View.ReferenceNo) Then
                    retVal = UpdateGlReferenceNumber()
                End If
            End If
        End Sub

        Private Function RemoveDeletedArOpenInvoices(retVal As Integer, newJournalItem As List(Of JournalItemModel)) As Integer
            Dim deletedRecord As Boolean
            Dim oldJournalItem As List(Of JournalItemModel)
            If Not AddMode Then
                oldJournalItem = OriginalModel.Journalitems
            Else
                oldJournalItem = Nothing
            End If
            For Each oldItem In oldJournalItem
                ' deletion of paid A.R. entries not allowed (see UserDeletingRow - sub  below) therefore all entries here are unpaid
                ' so no problem on deletion of related ArOpenInvoice and Payment invoices ('CsrOiItem')
                If IsAccountsReceivableAccount(oldItem.AccountIdNo) Then
                    deletedRecord = IsNothing(newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo))
                    If deletedRecord Then
                        ' delete marker ArOpenInvoice (since no payment exist) as paid invoices cannot be deleted (not allowed in the system) see (userdeletingrow) in ArJournalEntry.vb
                        retVal = DeleteArOpenInvoice(oldItem.OpenInvoiceIdNo)
                    Else
                        ' don't delete
                    End If
                End If
            Next
            Return retVal
        End Function

        Public Function DeleteArOpenInvoice(ByRef idNo As Int32) As String
            Dim retVal As Integer = 0
            If idNo <> 0 Then
                Dim arOpenInvoiceService As New AccountsService("ArOpenInvoice")
                If arOpenInvoiceService.CountRecordWithKey(Of Integer)("CsrOiItem", "ArOpenInvoiceIdNo", idNo) = 0 Then
                    retVal = arOpenInvoiceService.DeleteRecord(idNo, "ArOpenInvoice")
                End If
            End If
            Return retVal
        End Function

        Private Function AddNewArOpenInvoices(retVal As Integer, newJournalItem As List(Of JournalItemModel)) As Integer
            Dim newlyAdded
            Dim oldJournalItem As List(Of JournalItemModel)
            oldJournalItem = OriginalModel.Journalitems
            For Each newItem In newJournalItem
                If IsAccountsReceivableAccount(newItem.AccountIdNo) Then
                    newlyAdded = IsNothing(oldJournalItem.Find(Function(c) c.IdNo = newItem.IdNo))
                    If newlyAdded Then
                        retVal = AddArOpenInvoice(newItem, "AR")
                    End If
                End If
            Next
            Return retVal
        End Function

        Public Sub UpdateFirstLine()
            If EditMode Or AddMode Then
                If View.JournalItems.Count() = 0 Then
                    View.JournalItems = New List(Of JournalItemView) From {
                        FirstJournalItem()
                    }
                End If
                For Each item In View.JournalItems
                    MakePayTypeAndSpecialAccount(item, View.AccountIdNo)
                    item.Sequence = 1
                    item.AccountIdNo = View.AccountIdNo
                    Dim tranType As String = CodeToEnum(Of TransactionTypeSelection)(View.TransactionType)
                    If tranType = TransactionTypeSelection.Invoice Or tranType = TransactionTypeSelection.Debit Then
                        If item.Debit = 0 Or CountArItems() <= 1 Then
                            item.Debit = View.Amount
                            item.Credit = 0
                        End If
                    Else
                        If item.Credit = 0 Or CountArItems() <= 1 Then
                            item.Debit = 0
                            item.Credit = View.Amount
                        End If
                    End If
                    ' AR accounts are asset accounts so no revenue cost centers
                    item.RevCostCenterIdNo = 0
                    Exit For
                Next
            End If
        End Sub

        Public Function CountArItems()
            Dim nCount = 0
            For Each item In View.JournalItems
                If item.SpecialAccount = EnumToCode(SpecialAccountSelection.AccountsReceivable) Then
                    nCount = nCount + 1
                End If
            Next
            Return nCount
        End Function

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            Dim dataModel As New TM
            GlobalVariables.Mapper.Map(View, dataModel)
            retValue = Service.UpdateGlReferenceNumber(dataModel)
            Return retValue
        End Function

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                Dim cashAccount As String = EnumToCode(SpecialAccountSelection.Bank) + "|" + EnumToCode(SpecialAccountSelection.Cash) + "|" + EnumToCode(SpecialAccountSelection.PettyCashAccount)
                Dim invalidAccounts As String = EnumToCode(SpecialAccountSelection.EmployeeLoan) + "|" + EnumToCode(SpecialAccountSelection.AccountsPayable) + "|" +
                                                EnumToCode(SpecialAccountSelection.AccountsPayableDiscount) + "|" + EnumToCode(SpecialAccountSelection.AccountsReceivableDiscount) + "|" +
                                                EnumToCode(SpecialAccountSelection.AdvancesToSupplier) + "|"
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Service.GetRecordFieldWithKeyG(Of DateTime?)("AR Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If IsDateRangeValid("Accounts Receivable", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                Else
                    Dim nTotalAr As Decimal = 0
                    For Each item In View.JournalItems
                        If item.SpecialAccount = EnumToCode(SpecialAccountSelection.AccountsReceivable) Then
                            If View.TransactionType = "I" Or View.TransactionType = "D" Then
                                nTotalAr = nTotalAr + item.Debit - item.Credit
                            Else
                                nTotalAr = nTotalAr + item.Credit - item.Debit
                            End If
                        End If
                        If item.AccountIdNo Is Nothing Or item.AccountIdNo = 0 AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Messaging.ShowPmMessage(True, "MsgBlankAccountIdNotAllowed", {"lineNumber", lineNumber})
                            retValue = False
                            Exit For
                        ElseIf item.SpecialAccount IsNot Nothing AndAlso cashAccount.Contains(item.SpecialAccount) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Messaging.ShowPmMessage(True, "MsgCashAccountsNotAllowed", {"lineNumber", lineNumber})
                            retValue = False
                        ElseIf item.SpecialAccount IsNot Nothing AndAlso invalidAccounts.Contains(item.SpecialAccount) Then
                            Dim lineNumber = Format(item.Sequence, "0")
                            Dim entryNames = Messaging.TranslateCaption("Accounts Payables/Employee Loans")
                            Messaging.ShowPmMessage(True, "MsgAccountsNotAllowed", {"lineNumber", lineNumber, "entryNames", entryNames})
                            retValue = False
                        End If
                    Next
                    If nTotalAr <> View.Amount Then
                        Messaging.Show(True, "MsgTotalArMismatch")
                        retValue = False
                    End If
                End If
            End If
            Return retValue
        End Function

        Private Function FirstJournalItem()
            Dim item As New JournalItemView With {
                    .JournalIdNo = View.IdNo,
                    .Sequence = 0,
                    .AccountIdNo = View.AccountIdNo,
                    .Debit = View.Amount,
                    .Credit = 0,
                    .RevCostCenterIdNo = 0,
                    .Notes = "",
                    .SpecialAccount = Nothing,
                    .PayeeType = Nothing
                    }
            Return item
        End Function

        Public Overrides Sub GoPrintRecord()
            Dim transactionAmount As String
            Dim totalArAmount As String
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            language = Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            If language = "ar" Then
                transactionAmount = New ToWord(View.Amount, currencies(0)).ConvertToArabic()
            Else
                transactionAmount = New ToWord(View.Amount, currencies(0)).ConvertToEnglish()
            End If
            If language = "ar" Then
                totalArAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalArAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            Dim cForm As New ReportForm("Accounts Receivable Journal.Rpt", View.IdNo, "ArJournalIdNo", transactionAmount, "TotalArAmountInWords", totalArAmount, "TotalLineAmountInWords", language, "Language")
            cForm.Show()
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.JournalItems IsNot Nothing And View.JournalItems.Count() > 0 Then
                DtUpdateTable.Clear()
                _arJournalItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

        Public Sub UpdateDueDate()
            If View.CustomerIdNo IsNot Nothing Then
                Dim customerPaymentDueDays = GetCustomerPaymentDueDays(View.CustomerIdNo)
                View.DueDate = DateAdd("d", customerPaymentDueDays, View.TransactionDate)
            Else
                View.DueDate = Nothing
            End If
        End Sub

        Public Function GetCustomerPaymentDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Customer", "IdNo", "PaymentDueDays")
        End Function

        Public Sub UpdateEarlySettlementValues()
            If View.CustomerIdNo IsNot Nothing Then
                Dim customerSettlementDueDays As Integer
                Dim customerSettlementDiscount As Decimal
                customerSettlementDueDays = GetCustomerSettlementDueDays(View.CustomerIdNo)
                customerSettlementDiscount = GetCustomerSettlementDiscount(View.CustomerIdNo)
                View.SettlementDueDate = DateAdd("d", customerSettlementDueDays, View.TransactionDate)
                View.SettlementDiscount = customerSettlementDiscount
            Else
                View.SettlementDueDate = Nothing
                View.SettlementDiscount = 0
            End If
        End Sub

        Public Function GetCustomerSettlementDiscount(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Customer", "IdNo", "SettlementDiscount")
        End Function

        Public Function GetCustomerSettlementDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Customer", "IdNo", "SettlementDueDays")
        End Function

        Public Function ArCollectionExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
            Dim arOpenInvoiceIdNo As Integer
            arOpenInvoiceIdNo = Service.GetRecordFieldWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode",
                                                             "JournalItemIdNo", "IdNo")
            Return Service.CountRecordWithKey(Of Integer)("CsrOiItem", "ArOpenInvoiceIdNo", arOpenInvoiceIdNo) > 0
        End Function

        Public Sub OnApJournaldgvItemsChangedEventHandler(ByRef eventType As DgvItemsChanged) Implements ISubscriber(Of DgvItemsChanged).OnEventHandler
            With eventType.BindingSource
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    Dim accountId = eventType.BindingSource.Current.AccountIdNo
                    Select Case eventType.PropertyName
                        Case $"AccountIdNo"
                            MakePayTypeAndSpecialAccount(eventType.BindingSource.Current, accountId)
                            View.VatAmount = UpdateOutputVatAmount(View.JournalItems)
                            eventType.BindingSource.ResetItem(eventType.Row)
                        Case $"Debit"
                            MakeDebitAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Debit)
                            eventType.BindingSource.ResetItem(eventType.Row)
                            View.VatAmount = UpdateOutputVatAmount(View.JournalItems)
                        Case $"Credit"
                            MakeCreditAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Credit)
                            eventType.BindingSource.ResetItem(eventType.Row)
                            View.VatAmount = UpdateOutputVatAmount(View.JournalItems)
                    End Select
                End If
            End With
        End Sub

        Public Overrides Function IsOkToEditRecord() As Boolean
            If Not MyBase.IsOkToEditRecord() Then
                Return False
            End If
            Dim result As Boolean = True
            If ReconciledEntriesExist(View.JournalItems, "AR") Then
                result = False
            Else
                If DependentRecordExist() Then
                    result = False
                End If
            End If
            Return result
        End Function

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim retValue As Boolean = True
            If MyBase.IsOkToDeleteRecord Then
                If ReconciledEntriesExist(View.JournalItems, "AR") Then
                    retValue = False
                End If
            End If
            Return retValue
        End Function

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            For Each item In View.JournalItems
                If IsAccountsReceivableAccount(item.AccountIdNo) Then
                    Dim arOpenInvoiceNumber As Int32 = GetArOpenInvoiceNumber(item.IdNo)
                    If CheckDependentRecords(Of Int32)(arOpenInvoiceNumber, "CsrOiItem", "ArOpenInvoiceIdNo") Then
                        Return True
                    End If
                End If
            Next
            Return False
        End Function

    End Class

End Namespace