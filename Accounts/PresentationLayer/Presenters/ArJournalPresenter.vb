Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class ArJournalPresenter
        Inherits AccountsPresenter(Of IArJournalView, ArJournalModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _arJournalItemModel As New ModelAccounts("ArJournalItem")
        Private ReadOnly _arOpenInvoiceModel As New ModelAccounts("ArOpenInvoice")

        Public Sub New(view As IArJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("ArJournal")
            TableName = "ArJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New ArJournalModel()
            DataModel = New ArJournalModel
            GlobalVariables.EventAggregator.SubscribeEvent(Me)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

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
                    workRow("RevCostCenterIdNo") = ji.RevCostCenterIdNo
                    workRow("Notes") = If(ji.Notes, "")
                    If ji.IdNo <= 0 Then
                        DtInsertTable.Rows.Add(workRow)
                    Else
                        DtUpdateTable.Rows.Add(workRow)
                    End If
                    nRowCount += 1
                End If
            Next
        End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            UpdateTotals()
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_arJournalItemModel, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 Then
                Dim newJournalItem As List(Of JournalItemModel)
                newJournalItem = _arJournalItemModel.GetRecordsWithIdNo(Of JournalItemModel)(View.IdNo, "Sequence")
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
                        NewJournalItem()
                    }
                End If
                For Each item In View.JournalItems
                    item.JournalIdNo = View.IdNo
                    item.Sequence = 1
                    item.AccountIdNo = View.AccountIdNo
                    Dim tranType As String = CodeToEnum(Of TransactionTypeSelection)(View.TransactionType)
                    If tranType = TransactionTypeSelection.Invoice Or tranType = TransactionTypeSelection.Credit Then
                        If item.Debit = 0 Then
                            item.Debit = View.Amount
                            item.Credit = 0
                        End If
                    Else
                        If item.Debit = 0 Then
                            item.Debit = 0
                            item.Credit = View.Amount
                        End If
                    End If
                    item.RevCostCenterIdNo = 0
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
                Dim cashAccount As String = EnumToCode(SpecialAccountSelection.Bank) + "|" + EnumToCode(SpecialAccountSelection.Cash) + "|" + EnumToCode(SpecialAccountSelection.PettyCashAccount)
                Dim specialAccount As String
                Dim account As AccountModel
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("AR Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If IsDateRangeValid("Accounts Receivable", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                Else
                    Dim nTotalAr As Decimal = 0
                    For Each item In View.JournalItems
                        account = IIf(item.AccountIdNo Is Nothing, Nothing, GetAccount(item.AccountIdNo))
                        specialAccount = IIf(account Is Nothing, Nothing, account.SpecialAccount)
                        If specialAccount = EnumToCode(SpecialAccountSelection.AccountsReceivable) Then
                            If View.TransactionType = "I" Or View.TransactionType = "D" Then
                                nTotalAr = nTotalAr + item.Debit - item.Credit
                            Else
                                nTotalAr = nTotalAr + item.Credit - item.Debit
                            End If
                        End If
                        If item.AccountIdNo = 0 AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Messaging.ShowParametrizedMessage(True, "MsgCannotSaveBlankAccountID", {lineNumber, "lineNumber"})

                            MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                            retValue = False
                            Exit For
                        ElseIf specialAccount IsNot Nothing AndAlso cashAccount.Contains(specialAccount) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Messaging.ShowParametrizedMessage(True, "MsgCashAccountsNotAllowed", {"lineNumber", lineNumber})
                            retValue = False
                        Else
                            cPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Account", "IdNo", "PayeeType")
                            If Not String.IsNullOrEmpty(cPayeeType) AndAlso CodeToEnum(Of PayeeTypeSelection)(cPayeeType) <> PayeeTypeSelection.Customer Then
                                Dim lineNumber = Format(item.Sequence, "0")
                                Dim entryNames = Messaging.TranslateCaption("Accounts Payables/Employee Loans")
                                Messaging.ShowParametrizedMessage(True, "MsgAccountsNotAllowed", {"lineNumber", lineNumber, "entryNames", entryNames})
                                retValue = False
                            End If
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

        Private Function NewJournalItem()
            Dim item As New JournalItemView With {
                    .JournalIdNo = View.IdNo,
                    .Sequence = 0,
                    .AccountIdNo = Nothing,
                    .Debit = View.Amount,
                    .Credit = 0,
                    .RevCostCenterIdNo = 0,
                    .Notes = ""
                    }
            Return item
        End Function

        Public Overrides Sub GoPrintRecord()
            Dim transactionAmount As String
            Dim totalCreditAmount As String
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
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
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            Dim cForm As New ReportForm("Accounts Receivable Journal.Rpt", View.IdNo, "ArJournalIdNo", transactionAmount, "TotalCreditAmountInWords", totalCreditAmount, "TotalLineAmountInWords", language, "Language")
            cForm.Show()
        End Sub

    End Class

End Namespace