Imports System.Data
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class OpenInvoiceCorrectionService

        Public Const AccountsReceivable As String = "AR"
        Public Const AccountsPayable As String = "AP"

        Private Const AmountTolerance As Decimal = 0.005D

        Public Function GetContacts(ledgerCode As String) As List(Of OpenInvoiceCorrectionContact)
            Dim tableName As String
            Dim nameField As String
            Dim codeField As String
            Dim controlAccountField As String

            If ledgerCode = AccountsReceivable Then
                tableName = "Customer"
                nameField = "CustomerName"
                codeField = "CustomerCode"
                controlAccountField = "ArAccountIdNo"
            ElseIf ledgerCode = AccountsPayable Then
                tableName = "Supplier"
                nameField = "SupplierName"
                codeField = "SupplierCode"
                controlAccountField = "ApAccountIdNo"
            Else
                Throw New ArgumentException("Unknown open invoice ledger.", NameOf(ledgerCode))
            End If

            Dim accountService As New ServiceLayer.ActionService.AccountsService(tableName)
            Dim data As DataTable = accountService.GetDataTable(tableName,
                                                                 nameField,
                                                                 "IdNo," + codeField + "," + nameField + "," + controlAccountField,
                                                                 Nothing)
            Dim contacts As New List(Of OpenInvoiceCorrectionContact)
            For Each row As DataRow In data.Rows
                contacts.Add(New OpenInvoiceCorrectionContact With {
                                 .IdNo = Convert.ToInt32(row("IdNo")),
                                 .Code = If(row.IsNull(codeField), String.Empty, Convert.ToString(row(codeField))),
                                 .Name = If(row.IsNull(nameField), String.Empty, Convert.ToString(row(nameField))),
                                 .ControlAccountIdNo = If(row.IsNull(controlAccountField),
                                                          CType(Nothing, Int16?),
                                                          CType(Convert.ToInt16(row(controlAccountField)), Int16?))
                             })
            Next
            Return contacts
        End Function

        Public Function GetOpenInvoices(ledgerCode As String, contactIdNo As Int32) As List(Of OpenInvoiceCorrectionItem)
            Dim items As New List(Of OpenInvoiceCorrectionItem)
            If ledgerCode = AccountsReceivable Then
                Dim sourceService As New ServiceLayer.ActionService.AccountsService("CsrOiItem")
                Dim sourceItems = sourceService.GetOpenInvoices(Of CsrOiItemModel)(contactIdNo)
                For Each sourceItem As CsrOiItemModel In sourceItems
                    items.Add(New OpenInvoiceCorrectionItem With {
                                  .OpenInvoiceIdNo = sourceItem.ArOpenInvoiceIdNo,
                                  .AccountIdNo = sourceItem.AccountIdNo,
                                  .InvoiceNo = sourceItem.InvoiceNo,
                                  .JournalCode = sourceItem.JournalCode,
                                  .JournalIdNo = sourceItem.JournalIdNo,
                                  .TransactionDate = sourceItem.TransactionDate,
                                  .CurrentBalance = sourceItem.Balance,
                                  .ProposedAmount = 0D,
                                  .ProjectedBalance = sourceItem.Balance
                              })
                Next
            ElseIf ledgerCode = AccountsPayable Then
                Dim sourceService As New ServiceLayer.ActionService.AccountsService("DjOiItem")
                Dim sourceItems = sourceService.GetSupplierOpenInvoices(Of DjOiItemModel)(contactIdNo)
                For Each sourceItem As DjOiItemModel In sourceItems
                    items.Add(New OpenInvoiceCorrectionItem With {
                                  .OpenInvoiceIdNo = sourceItem.ApOpenInvoiceIdNo,
                                  .AccountIdNo = sourceItem.AccountIdNo,
                                  .InvoiceNo = sourceItem.InvoiceNo,
                                  .JournalCode = sourceItem.JournalCode,
                                  .JournalIdNo = sourceItem.JournalIdNo,
                                  .TransactionDate = sourceItem.TransactionDate,
                                  .CurrentBalance = sourceItem.Balance,
                                  .ProposedAmount = 0D,
                                  .ProjectedBalance = sourceItem.Balance
                              })
                Next
            Else
                Throw New ArgumentException("Unknown open invoice ledger.", NameOf(ledgerCode))
            End If

            Return items
        End Function

        Public Function GetLastPostingDate(ledgerCode As String) As Date?
            Dim transactionName As String
            If ledgerCode = AccountsReceivable Then
                transactionName = "AR Journal"
            ElseIf ledgerCode = AccountsPayable Then
                transactionName = "AP Journal"
            Else
                Throw New ArgumentException("Unknown open invoice ledger.", NameOf(ledgerCode))
            End If

            Dim accountService As New ServiceLayer.ActionService.AccountsService("Customer")
            Return accountService.GetRecordFieldWithKeyG(Of Date?)(transactionName,
                                                                     "LastPosting",
                                                                     "TransactionName",
                                                                     "LastPostingDate")
        End Function

        Public Function ApplyNegativeFirst(items As List(Of OpenInvoiceCorrectionItem)) As Decimal
            If items Is Nothing Then Return 0D

            For Each item As OpenInvoiceCorrectionItem In items
                item.ProposedAmount = 0D
                item.ProjectedBalance = item.CurrentBalance
            Next

            Dim negativeItems = items.Where(Function(item) item.CurrentBalance < -AmountTolerance).
                OrderBy(Function(item) If(item.TransactionDate.HasValue, item.TransactionDate.Value, Date.MaxValue)).
                ThenBy(Function(item) item.OpenInvoiceIdNo).ToList()
            Dim positiveItems = items.Where(Function(item) item.CurrentBalance > AmountTolerance).
                OrderBy(Function(item) If(item.TransactionDate.HasValue, item.TransactionDate.Value, Date.MaxValue)).
                ThenBy(Function(item) item.OpenInvoiceIdNo).ToList()

            Dim negativeTotal As Decimal = Decimal.Round(negativeItems.Sum(Function(item) Math.Abs(item.CurrentBalance)), 2)
            Dim positiveCapacity As Decimal = Decimal.Round(positiveItems.Sum(Function(item) item.CurrentBalance), 2)
            Dim amountToApplyToNegatives As Decimal = Math.Min(negativeTotal, positiveCapacity)
            amountToApplyToNegatives = Decimal.Round(amountToApplyToNegatives, 2)

            'Apply only the negative amount that can be covered by the available
            'positive balances. The final negative invoice may therefore be partial.
            For Each item As OpenInvoiceCorrectionItem In negativeItems
                If amountToApplyToNegatives <= AmountTolerance Then Exit For

                Dim amountApplied = Decimal.Round(Math.Min(Math.Abs(item.CurrentBalance), amountToApplyToNegatives), 2)
                item.ProposedAmount = Decimal.Round(-amountApplied, 2)
                item.ProjectedBalance = Decimal.Round(item.CurrentBalance - item.ProposedAmount, 2)
                amountToApplyToNegatives = Decimal.Round(amountToApplyToNegatives - amountApplied, 2)
            Next

            Dim amountToOffset As Decimal = Decimal.Round(negativeItems.Sum(Function(item) Math.Abs(item.ProposedAmount)), 2)

            For Each item As OpenInvoiceCorrectionItem In positiveItems
                If amountToOffset <= AmountTolerance Then Exit For
                Dim amountApplied = Math.Min(item.CurrentBalance, amountToOffset)
                item.ProposedAmount = Decimal.Round(amountApplied, 2)
                item.ProjectedBalance = Decimal.Round(item.CurrentBalance - item.ProposedAmount, 2)
                amountToOffset = Decimal.Round(amountToOffset - item.ProposedAmount, 2)
            Next

            Return GetRemainingNegativeBalance(items)
        End Function

        Public Function GetRemainingNegativeBalance(items As IEnumerable(Of OpenInvoiceCorrectionItem)) As Decimal
            If items Is Nothing Then Return 0D
            Return Decimal.Round(items.Where(Function(item) item.ProjectedBalance < -AmountTolerance).
                                  Sum(Function(item) Math.Abs(item.ProjectedBalance)), 2)
        End Function

        Public Function GetNegativeBalanceTotal(items As IEnumerable(Of OpenInvoiceCorrectionItem)) As Decimal
            If items Is Nothing Then Return 0D
            Return Decimal.Round(items.Where(Function(item) item.CurrentBalance < -AmountTolerance).
                                  Sum(Function(item) Math.Abs(item.CurrentBalance)), 2)
        End Function

        Public Function GetPositiveAmountUsed(items As IEnumerable(Of OpenInvoiceCorrectionItem)) As Decimal
            If items Is Nothing Then Return 0D
            Return Decimal.Round(items.Where(Function(item) item.ProposedAmount > AmountTolerance).
                                  Sum(Function(item) item.ProposedAmount), 2)
        End Function

        Public Function SaveArCorrection(contact As OpenInvoiceCorrectionContact,
                                          correctionDate As Date,
                                          notes As String,
                                          items As IEnumerable(Of OpenInvoiceCorrectionItem)) As Int32
            Dim model As New CashReceiptJournalModel With {
                .TransactionDate = correctionDate.Date,
                .Amount = 0D,
                .Applied = 0D,
                .UnApplied = 0D,
                .AccountIdNo = contact.ControlAccountIdNo,
                .PayorType = "A",
                .PayorIdNo = contact.IdNo,
                .PayorName = LimitText(contact.Name, 50),
                .Notes = LimitText(notes, 300),
                .Posted = False,
                .Approved = False,
                .Cancelled = False,
                .CsrOiItems = CreateArOiItems(items),
                .JournalItems = CreateArJournalItems(items, contact.ControlAccountIdNo)
            }
            Return New CashReceiptJournalTransactionService().SaveNew(model)
        End Function

        Public Function SaveApCorrection(contact As OpenInvoiceCorrectionContact,
                                          correctionDate As Date,
                                          notes As String,
                                          items As IEnumerable(Of OpenInvoiceCorrectionItem)) As Int32
            Dim model As New DisbursementJournalModel With {
                .TransactionDate = correctionDate.Date,
                .Amount = 0D,
                .Applied = 0D,
                .UnApplied = 0D,
                .AccountIdNo = contact.ControlAccountIdNo,
                .PaymentType = "A",
                .PayType = "3",
                .PayeeIdNo = contact.IdNo,
                .PayeeName = LimitText(contact.Name, 100),
                .Notes = LimitText(notes, 300),
                .Posted = False,
                .Approved = False,
                .Cancelled = False,
                .DjOiItems = CreateApOiItems(items),
                .JournalItems = CreateApJournalItems(items, contact.ControlAccountIdNo)
            }
            Return New CashDisbursementJournalTransactionService().SaveNew(model)
        End Function

        Private Shared Function CreateArOiItems(items As IEnumerable(Of OpenInvoiceCorrectionItem)) As List(Of CsrOiItemModel)
            Dim result As New List(Of CsrOiItemModel)
            Dim sequence As Int16 = 0
            For Each item As OpenInvoiceCorrectionItem In items.Where(Function(sourceItem) Math.Abs(sourceItem.ProposedAmount) > AmountTolerance)
                result.Add(New CsrOiItemModel With {
                               .Amount = Decimal.Round(item.ProposedAmount, 2),
                               .ArOpenInvoiceIdNo = item.OpenInvoiceIdNo,
                               .DiscountTaken = 0D,
                               .Sequence = sequence
                           })
                sequence += 1
            Next
            Return result
        End Function

        Private Shared Function LimitText(value As String, maxLength As Int32) As String
            If value Is Nothing Then Return String.Empty
            If value.Length <= maxLength Then Return value
            Return value.Substring(0, maxLength)
        End Function

        Private Shared Function CreateApOiItems(items As IEnumerable(Of OpenInvoiceCorrectionItem)) As List(Of DjOiItemModel)
            Dim result As New List(Of DjOiItemModel)
            Dim sequence As Int16 = 0
            For Each item As OpenInvoiceCorrectionItem In items.Where(Function(sourceItem) Math.Abs(sourceItem.ProposedAmount) > AmountTolerance)
                result.Add(New DjOiItemModel With {
                               .Amount = Decimal.Round(item.ProposedAmount, 2),
                               .ApOpenInvoiceIdNo = item.OpenInvoiceIdNo,
                               .DiscountTaken = 0D,
                               .Sequence = sequence
                           })
                sequence += 1
            Next
            Return result
        End Function

        Private Shared Function CreateArJournalItems(items As IEnumerable(Of OpenInvoiceCorrectionItem), controlAccountIdNo As Int16?) As List(Of JournalItemModel)
            Return CreateJournalItems(items, controlAccountIdNo, False)
        End Function

        Private Shared Function CreateApJournalItems(items As IEnumerable(Of OpenInvoiceCorrectionItem), controlAccountIdNo As Int16?) As List(Of JournalItemModel)
            Return CreateJournalItems(items, controlAccountIdNo, True)
        End Function

        Private Shared Function CreateJournalItems(items As IEnumerable(Of OpenInvoiceCorrectionItem),
                                                   controlAccountIdNo As Int16?,
                                                   isAccountsPayable As Boolean) As List(Of JournalItemModel)
            Dim totalsByAccount As New Dictionary(Of Int16, Decimal)
            For Each item As OpenInvoiceCorrectionItem In items.Where(Function(sourceItem) Math.Abs(sourceItem.ProposedAmount) > AmountTolerance)
                If Not item.AccountIdNo.HasValue OrElse item.AccountIdNo.Value = 0 Then
                    Throw New InvalidOperationException("Every corrected open invoice must have an account.")
                End If
                If Not totalsByAccount.ContainsKey(item.AccountIdNo.Value) Then totalsByAccount.Add(item.AccountIdNo.Value, 0D)
                totalsByAccount(item.AccountIdNo.Value) += item.ProposedAmount
            Next

            Dim journalItems As New List(Of JournalItemModel)
            Dim sequence As Int16 = 0
            For Each accountTotal In totalsByAccount.OrderBy(Function(pair) pair.Key)
                Dim total = Decimal.Round(accountTotal.Value, 2)
                If Math.Abs(total) <= AmountTolerance Then Continue For

                Dim debit As Decimal = 0D
                Dim credit As Decimal = 0D
                If isAccountsPayable Then
                    If total > 0D Then
                        debit = total
                    Else
                        credit = Math.Abs(total)
                    End If
                ElseIf total > 0D Then
                    credit = total
                Else
                    debit = Math.Abs(total)
                End If

                journalItems.Add(New JournalItemModel With {
                                     .AccountIdNo = accountTotal.Key,
                                     .Debit = debit,
                                     .Credit = credit,
                                     .Notes = "Open invoice offset correction",
                                     .Sequence = sequence
                                 })
                sequence += 1
            Next

            If journalItems.Count = 0 Then
                If Not controlAccountIdNo.HasValue OrElse controlAccountIdNo.Value = 0 Then
                    Throw New InvalidOperationException("The selected contact has no AR/AP control account.")
                End If
                journalItems.Add(New JournalItemModel With {
                                     .AccountIdNo = controlAccountIdNo.Value,
                                     .Debit = 0D,
                                     .Credit = 0D,
                                     .Notes = "Open invoice offset correction",
                                     .Sequence = 0
                                 })
            End If

            Dim totalDebits = journalItems.Sum(Function(item) item.Debit)
            Dim totalCredits = journalItems.Sum(Function(item) item.Credit)
            If Math.Abs(totalDebits - totalCredits) > AmountTolerance Then
                Throw New InvalidOperationException("The correction journal is not balanced.")
            End If
            Return journalItems
        End Function

    End Class

End Namespace
