Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class ApJournalPresenterNew(Of TM As New)
        Inherits TransactionsPresenterNew(Of IApJournalView, TM)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _apJournalItemService As New AccountsService("JournalItem", Nothing, {"GeneralJournalItem_View", "UpdateGeneralJournalItemTVP", "InsertGeneralJournalItemTVP"})
        Private ReadOnly _apOpenInvoiceService As New AccountsService("ApOpenInvoice")

        Public Sub New(view As IApJournalView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("ApJournal")
            SortOrderKey = "IdNo"
            TableName = "APJournal"
            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Credit", GetType(Decimal))
            DtInsertTable.Columns.Add("Debit", GetType(Decimal))
            DtInsertTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Notes", GetType(String))
            DtInsertTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Credit", GetType(Decimal))
            DtUpdateTable.Columns.Add("Debit", GetType(Decimal))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))

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
            workRow("RevCostCenterIdNo") = itemDataView.RevCostCenterIdNo
            workRow("Notes") = If(itemDataView.Notes, "")
        End Sub

        Public Function JournalItemFilter(ByVal obj As Object) As Boolean
            If (obj.AccountIdNo Is Nothing Or obj.AccountIdNo = 0) AndAlso obj.Debit = 0 AndAlso obj.Credit = 0 Then
                Return False
            End If
            Return True
        End Function

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            UpdateTotals()
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_apJournalItemService, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 Then
                Dim newJournalItem As List(Of JournalItemModel)
                newJournalItem = _apJournalItemService.GetRecordsWithGroupIdNo(Of JournalItemModel)(View.IdNo, "Sequence")
                If AddMode Then
                    For Each item In newJournalItem
                        If IsAccountsPayableAccount(item.AccountIdNo) Then
                            retVal = AddApOpenInvoice(item, "AP")
                            If retVal < 0 Then
                                Exit For
                            End If
                        End If
                    Next
                Else
                    retVal = RemoveDeletedApOpenInvoices(retVal, newJournalItem)
                    If retVal >= 0 Then
                        retVal = AddNewApOpenInvoices(retVal, newJournalItem)
                    End If
                End If
            End If
            If retVal >= 0 Then
                If IsEmpty(View.ReferenceNo) Then
                    retVal = UpdateGlReferenceNumber()
                End If
            End If
            If retVal >= 0 AndAlso Not IsEmpty(View.VatNumber) Then
                Service.UpdateVatNumber(View.VatNumber, View.SupplierIdNo)
            End If
        End Sub

        Public Function IsAccountsPayableAccount(ByVal accountIdNo As Int16)
            Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = EnumToCode(SpecialAccountSelection.AccountsPayable)
        End Function

        Private Function RemoveDeletedApOpenInvoices(retVal As Integer, newJournalItem As List(Of JournalItemModel)) As Integer
            Dim deletedRecord As Boolean
            Dim oldJournalItem As List(Of JournalItemModel)
            If Not AddMode Then
                oldJournalItem = OriginalModel.Journalitems
            Else
                oldJournalItem = Nothing
            End If
            For Each oldItem In oldJournalItem
                ' deletion of paid A.P. entries not allowed (see UserDeletingRow - sub  below) therefore all entries here are unpaid
                ' so no problem on deletion of related ApOpenInvoice and Payment invoices ('CkOiItem','CdOiItem','PcOiItem')
                If IsAccountsPayableAccount(oldItem.AccountIdNo) Then
                    deletedRecord = IsNothing(newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo))
                    If deletedRecord Then
                        ' delete marker ArOpenInvoice (since no payment exist) as paid invoices cannot be deleted (not allowed in the system) see (userdeletingrow) in ArJournalEntry.vb
                        retVal = DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
                    Else
                        ' don't delete
                    End If
                End If
            Next
            Return retVal
        End Function

        Public Function DeleteApOpenInvoice(ByRef idNo As Int32)
            Dim retVal As Integer = 0
            If idNo <> 0 Then
                Dim modelApOpenInvoice As New ModelAccounts("ApOpenInvoice")
                retVal = modelApOpenInvoice.DeleteRecord(idNo, "ApOpenInvoice")
            End If
            Return retVal
        End Function

        Private Function AddNewApOpenInvoices(retVal As Integer, newJournalItem As List(Of JournalItemModel)) As Integer
            Dim newlyAdded
            Dim oldJournalItem As List(Of JournalItemModel)
            oldJournalItem = OriginalModel.Journalitems
            For Each newItem In newJournalItem
                If IsAccountsPayableAccount(newItem.AccountIdNo) Then
                    newlyAdded = IsNothing(oldJournalItem.Find(Function(c) c.IdNo = newItem.IdNo))
                    If newlyAdded Then
                        retVal = AddApOpenInvoice(newItem, "AP")
                    End If
                End If
            Next
            Return retVal
        End Function

        Public Sub UpdateFirstLine()
            If EditMode Or AddMode Then
                If View.JournalItems.Count() = 0 Then
                    View.JournalItems = New List(Of IJournalItemView) From {
                        FirstJournalItem()
                    }
                End If
                For Each item In View.JournalItems
                    MakePayTypeAndSpecialAccount(item, View.AccountIdNo)
                    item.Sequence = 1
                    item.AccountIdNo = View.AccountIdNo
                    Dim tranType As String = CodeToEnum(Of TransactionTypeSelection)(View.TransactionType)
                    If tranType = TransactionTypeSelection.Invoice Or tranType = TransactionTypeSelection.Credit Then
                        If item.Credit = 0 Or CountApItems() <= 1 Then
                            item.Credit = View.Amount
                            item.Debit = 0
                        End If
                    Else
                        If item.Debit = 0 Or CountApItems() <= 1 Then
                            item.Credit = 0
                            item.Debit = View.Amount
                        End If
                    End If
                    ' AP accounts are liabilities accounts so no revenue cost centers
                    item.RevCostCenterIdNo = 0
                    Exit For
                Next
            End If
        End Sub

        Public Function CountApItems()
            Dim nCount = 0
            For Each item In View.JournalItems
                If item.SpecialAccount = EnumToCode(SpecialAccountSelection.AccountsPayable) Then
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
                Dim cashAccounts As String = EnumToCode(SpecialAccountSelection.Bank) + "|" + EnumToCode(SpecialAccountSelection.Cash) + "|" + EnumToCode(SpecialAccountSelection.PettyCashAccount) + "|" + EnumToCode(SpecialAccountSelection.CheckingAccount)
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Service.GetRecordFieldWithKeyG(Of DateTime?)("AP Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If IsDateRangeValid("Accounts Payable", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                Else
                    Dim nTotalAp As Decimal = 0
                    For Each item In View.JournalItems
                        If item.SpecialAccount = EnumToCode(SpecialAccountSelection.AccountsPayable) Then
                            If View.TransactionType = "I" Or View.TransactionType = "C" Then
                                nTotalAp = nTotalAp + item.Credit - item.Debit
                            Else
                                nTotalAp = nTotalAp + item.Debit - item.Credit
                            End If
                        End If
                        If item.AccountIdNo = 0 AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Messaging.ShowParametrizedMessage(True, "MsgBlankAccountIdNotAllowed", {"lineNumber", lineNumber})
                            retValue = False
                            Exit For
                        ElseIf item.SpecialAccount IsNot Nothing AndAlso cashAccounts.Contains(item.SpecialAccount) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Messaging.ShowParametrizedMessage(True, "MsgCashAccountsNotAllowed", {"lineNumber", lineNumber})
                            retValue = False
                        Else
                            If Not String.IsNullOrEmpty(item.PayeeType) AndAlso CodeToEnum(Of PayeeTypeSelection)(item.PayeeType) <> PayeeTypeSelection.Supplier Then
                                Dim lineNumber = Format(item.Sequence, "0")
                                Dim entryNames = Messaging.TranslateCaption("Accounts Receivables/Employee Loans")
                                Messaging.ShowParametrizedMessage(True, "MsgAccountsNotAllowed", {"lineNumber", lineNumber, "entryNames", entryNames})
                                retValue = False
                            End If
                        End If
                    Next
                    If nTotalAp <> View.Amount Then
                        Messaging.Show(True, "MsgTotalApMismatch")
                        retValue = False
                    End If
                End If
            End If
            Return retValue
        End Function

        Private Function FirstJournalItem()
            Dim item As New JournalItemView With {
                    .JournalIdNo = View.IdNo,
                    .Sequence = 1,
                    .AccountIdNo = View.AccountIdNo,
                    .Credit = View.Amount,
                    .Debit = 0,
                    .RevCostCenterIdNo = 0,
                    .Notes = "",
                    .SpecialAccount = Nothing,
                    .PayeeType = Nothing
                    }
            Return item
        End Function

        Public Overrides Sub GoPrintRecord()
            Dim transactionAmount As String
            Dim totalApAmount As String
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
            View.TotalCredits = 0
            For Each item In View.JournalItems
                View.TotalCredits = View.TotalCredits + item.Credit
            Next
            If language = "ar" Then
                totalApAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalApAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            Dim cForm As New ReportForm("Accounts Payable Journal.Rpt", View.IdNo, "ApJournalIdNo", transactionAmount, "ApAmountInWords", totalApAmount, "TotalLineAmountInWords", language, "Language")
            cForm.Show()
        End Sub

        Public Sub UpdateDueDate()
            If View.SupplierIdNo IsNot Nothing Then
                Dim supplierPaymentDueDays = GetSupplierPaymentDueDays(View.SupplierIdNo)
                View.DueDate = DateAdd("d", supplierPaymentDueDays, View.TransactionDate)
            Else
                View.DueDate = Nothing
            End If
        End Sub

        Public Function GetSupplierPaymentDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "PaymentDueDays")
        End Function

        Public Sub UpdateEarlySettlementValues()
            If View.SupplierIdNo IsNot Nothing Then
                Dim supplierSettlementDueDays As Integer
                Dim supplierSettlementDiscount As Decimal
                supplierSettlementDueDays = GetSupplierSettlementDueDays(View.SupplierIdNo)
                supplierSettlementDiscount = GetSupplierSettlementDiscount(View.SupplierIdNo)
                View.SettlementDueDate = DateAdd("d", supplierSettlementDueDays, View.TransactionDate)
                View.SettlementDiscount = supplierSettlementDiscount
            Else
                View.SettlementDueDate = Nothing
                View.SettlementDiscount = 0
            End If
        End Sub

        Public Function GetSupplierSettlementDueDays(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "SettlementDueDays")
        End Function

        Public Function GetSupplierSettlementDiscount(idNo As String)
            Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "SettlementDiscount")
        End Function

        Public Sub UpdateSupplierDate()
            If View.TransactionDate IsNot Nothing Then
                If View.InvoiceDate Is Nothing Then
                    View.InvoiceDate = View.TransactionDate
                End If
            Else
                View.InvoiceDate = Nothing
            End If
        End Sub

        'Public Overrides Function IsOkToEditRecord() As Boolean
        '    Dim retVal As Boolean = True
        '    If MyBase.IsOkToEditRecord() Then
        '        If CallByName(View, "chkApproved.DisplayOnly", CallType.Get) Then
        '            retVal = False
        '        End If
        '        Return retVal
        '    End If
        '    Return retVal
        'End Function

    End Class

End Namespace