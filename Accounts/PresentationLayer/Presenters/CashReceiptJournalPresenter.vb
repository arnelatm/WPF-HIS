Imports System.Globalization
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class CashReceiptJournalPresenter(Of TM As New)
        Inherits TransactionsPresenter(Of ICashReceiptJournalView, TM)

        Private ReadOnly _advancesToCustomerAccountIdNo As Int16
        Protected DtInsertTable As New DataTable
        Protected DtOiInsertTable As New DataTable
        Protected DtOiUpdateTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Protected ReportName As String

        Private ReadOnly _
            _djArgs =
                {"CashReceiptJournalItem_View", "UpdateCashReceiptJournalItemTVP", "InsertCashReceiptJournalItemTVP"}

        Private ReadOnly _openInvItemService As New AccountsService("CsrOiItem")
        Private ReadOnly _journalItemService As New AccountsService("JournalItem", Nothing, _djArgs)

        Public Sub New(view As ICashReceiptJournalView)
            MyBase.New(view)
            WithTreeView = False
            SortOrderKey = "IdNo"
            ReportName = "Cash Receipt Journal.Rpt"
            Service = New AccountsService("CashReceiptJournal")
            TableName = "CashReceiptJournal"

            _advancesToCustomerAccountIdNo = GetCustomerAdvancesAccountIdNo()

            CreateDataTable(DtInsertTable, {{"AccountIdNo", GetType(Int16)},
                                            {"Credit", GetType(Decimal)},
                                            {"Debit", GetType(Decimal)},
                                            {"JournalIdNo", GetType(Int32)},
                                            {"Notes", GetType(String)},
                                            {"PayIdNo", GetType(Int32)},
                                            {"RevCostCenterIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}})

            CreateDataTable(DtUpdateTable, {{"AccountIdNo", GetType(Int16)},
                                            {"Credit", GetType(Decimal)},
                                            {"Debit", GetType(Decimal)},
                                            {"IdNo", GetType(Int32)},
                                            {"JournalIdNo", GetType(Int32)},
                                            {"Notes", GetType(String)},
                                            {"PayIdNo", GetType(Int32)},
                                            {"RevCostCenterIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}})

            CreateDataTable(DtOiInsertTable, {{"Amount", GetType(Decimal)},
                                              {"ArOpenInvoiceIdNo", GetType(Int32)},
                                              {"CsrIdNo", GetType(Int32)},
                                              {"DiscountTaken", GetType(Decimal)},
                                              {"Sequence", GetType(Int16)}})

            CreateDataTable(DtOiUpdateTable, {{"Amount", GetType(Decimal)},
                                              {"ArOpenInvoiceIdNo", GetType(Int32)},
                                              {"CsrIdNo", GetType(Int32)},
                                              {"DiscountTaken", GetType(Decimal)},
                                              {"IdNo", GetType(Int32)},
                                              {"Sequence", GetType(Int16)}})
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateLookupData("Account", "AccountsByCode")
            CreateLookupData("RevCostCenter", "RevCostCentersByCode")
            CreateLookupData("Employee", "EmployeesByName")
            CreateLookupData("Customer", "CustomersByName")
            CreateLookupData("Supplier", "SuppliersByName")
            CreateEnumDataSource(Of ReceiptTypeSelection)("PayorType")
            CreateSpecialAccountDataSource("AccountIdNo", {EnumToCode(SpecialAccountSelection.Bank), EnumToCode(SpecialAccountSelection.Cash), EnumToCode(SpecialAccountSelection.CheckingAccount)})
            CreateSpecialAccountDataSource("DiscountAccountIdNo", {EnumToCode(SpecialAccountSelection.AccountsReceivableDiscount)})
        End Sub

        Public Function GetCustomerAdvancesAccountIdNo()
            Return GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.CustomerAdvances), "Account", "SpecialAccount", "IdNo")
        End Function

        Public Property JournalCode As String

        Public ReadOnly Property CrAccountCount As Int16
            Get
                Dim accounts = EnumToCode(SpecialAccountSelection.Bank) + "," + EnumToCode(SpecialAccountSelection.Cash) +
                               "," + EnumToCode(SpecialAccountSelection.CheckingAccount)
                Dim cdAccounts = GetAccountTypesList(accounts)
                Return cdAccounts.Count()
            End Get
        End Property

        Public ReadOnly Property DefaultCashReceiptAccount As Int16
            Get
                Dim retVal As String = Nothing
                If View.AccountIdNo = 0 Then
                    If CrAccountCount >= 1 Then
                        retVal = GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.Bank), "Account",
                                                       "SpecialAccount", "IdNo")
                        If retVal Is Nothing Then
                            GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.Cash), "Account", "SpecialAccount",
                                                  "IdNo")
                        End If
                    Else
                        Return 0
                    End If
                End If
                If retVal Is Nothing Then
                    Return 0
                End If
                Return CInt(retVal)
            End Get
        End Property

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                If CodeToEnum(Of ReceiptTypeSelection)(View.PayorType) <> ReceiptTypeSelection.AccountsReceivable Then
                    ViewToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf JournalItemFillData,
                                     AddressOf JournalItemFilter)
                    View.UnApplied = 0
                    View.Applied = View.Amount
                    If DtOiInsertTable IsNot Nothing Then
                        DtOiInsertTable.Clear()
                    End If
                    If DtOiUpdateTable IsNot Nothing Then
                        DtOiUpdateTable.Clear()
                    End If
                Else
                    MakeJournalItem()
                    ViewToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf JournalItemFillData,
                                     AddressOf JournalItemFilter)
                    ViewToDataTables(View.CsrOiItems, DtOiInsertTable, DtOiUpdateTable, AddressOf CsrOiFillData,
                                     AddressOf CsrOiItemFilter)
                End If
                For Each item In View.JournalItems
                    If item.Equals(DBNull.Value) Then
                        item.Notes = ""
                    End If
                    If item.Notes Is Nothing Then
                        item.Notes = ""
                    End If
                Next
            End If
        End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            'If CodeToEnum(Of ReceiptTypeSelection)(View.PayorType) = ReceiptTypeSelection.AccountsReceivable Then
            '    View.TotalDebits = 0
            '    View.TotalCredits = 0
            '    For Each ji In View.CsrOiItems
            '        View.TotalDebits += ji.Amount + ji.DiscountTaken
            '    Next
            '    View.TotalCredits = View.TotalDebits
            'End If
            View.UnApplied = View.Amount - View.Applied
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) _
            Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_journalItemService, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_openInvItemService, DtOiUpdateTable, DtOiInsertTable, passedValue, "CsrIdNo")
                If retVal >= 0 Then
                    retVal = SaveOpenInvoices()
                End If
            End If
            If retVal >= 0 And IsEmpty(View.ReferenceNo) Then
                Dim dataModel = New TM
                GlobalVariables.Mapper.Map(View, dataModel)
                retVal = Service.UpdateGlReferenceNumber(dataModel)
            End If
        End Sub

        Public Sub UpdateFirstLine()
            If EditMode Or AddMode Then
                If View.JournalItems.Count() = 0 Then
                    View.JournalItems = New List(Of JournalItemView) From {
                        FirstJournalItem()
                        }
                End If
                For Each item In View.JournalItems
                    item.JournalIdNo = View.IdNo
                    item.Sequence = 1
                    item.AccountIdNo = View.AccountIdNo
                    item.Credit = 0
                    item.Debit = View.Amount
                    item.RevCostCenterIdNo = 0
                    MakePayTypeAndSpecialAccount(item, View.AccountIdNo)
                    Exit For
                Next
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Service.GetRecordFieldWithKeyG(Of DateTime?)("Cash Receipt",
                                                                                                 "LastPosting",
                                                                                                 "TransactionName",
                                                                                                 "LastPostingDate")
                Dim dateFieldName = Messaging.TranslateCaption("Transacton Date")
                If IsDateRangeValid(dateFieldName, View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No _
                    Then
                    retValue = False
                ElseIf CodeToEnum(Of ReceiptTypeSelection)(View.PayorType) <> ReceiptTypeSelection.AccountsReceivable _
                    Then
                    If View.JournalItems Is Nothing OrElse View.JournalItems.Count() = 0 Then
                        Messaging.Show(True, "MsgCannotSaveAnEmptyTransaction",
                                       "Sorry, cannot save an empty transaction!", "Error")
                        retValue = False
                    End If
                    If retValue Then
                        retValue = JournalItemDataIsValid()
                    End If
                ElseIf CodeToEnum(Of ReceiptTypeSelection)(View.PayorType) = ReceiptTypeSelection.AccountsReceivable _
                    Then
                    If CsrOiItemDataIsValid() Then
                        retValue = True
                    Else
                        retValue = False
                        Dim index As Int16 = 0
                        For Each item In View.CsrOiItems
                            If item.Errors IsNot Nothing Then
                                View.CsrOiItems(index).Errors = item.Errors
                            Else
                                If View.CsrOiItems(index).Errors IsNot Nothing Then
                                    View.CsrOiItems(index).Errors.Clear()
                                End If
                            End If
                            index += 1
                        Next
                    End If
                End If
                If retValue >= 0 Then
                    For Each item In View.JournalItems
                        If item.AccountIdNo = 0 AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Messaging.ShowPmMessage(True, "MsgBlankAccountIdNotAllowed",
                                                              {"lineNumber", lineNumber})
                            retValue = False
                            Exit For
                        End If
                    Next
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
                    .SpecialAccount = Nothing,
                    .PayeeType = Nothing,
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
            language = Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            If language = "ar" Then
                transactionAmount = New ToWord(View.Amount, currencies(0)).ConvertToArabic()
            Else
                transactionAmount = New ToWord(View.Amount, currencies(0)).ConvertToEnglish()
            End If
            'View.TotalCredits = 0
            'For Each item In View.JournalItems
            '    View.TotalCredits = View.TotalCredits + item.Credit
            'Next
            If language = "ar" Then
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            Dim _
                cForm As _
                    New ReportForm(ReportName, View.IdNo, "CashReceiptJournalIdNo", transactionAmount,
                                   "CreditAmountInWords", totalCreditAmount, "TotalLineAmountInWords", language,
                                   "Language")
            cForm.Show()
        End Sub

        Private Sub OnSuccessfulDelete(idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.CsrOiItems IsNot Nothing And View.CsrOiItems.Count() > 0 Then
                DtOiUpdateTable.Clear()
                _openInvItemService.DelUpdateTvp(DtOiUpdateTable, idNo)
            End If
            ' ReSharper disable once VBUseMethodAny.1
            If View.JournalItems IsNot Nothing And View.JournalItems.Count() > 0 Then
                DtUpdateTable.Clear()
                _journalItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

        Public Sub AutoApplyAmount()
            Dim amountToApply = View.Amount
            'Dim appliedAmount As Decimal = 0D
            For Each item In View.CsrOiItems
                If amountToApply = 0D Then
                    item.Amount = 0D
                    item.DiscountTaken = 0D
                    item.Balance = item.PreviousBalance
                Else
                    If item.PreviousBalance <= amountToApply Then
                        amountToApply -= item.PreviousBalance
                        item.Amount = item.PreviousBalance
                        item.DiscountTaken = 0D
                        item.Balance = 0D
                    Else
                        item.Amount = amountToApply
                        item.DiscountTaken = 0D
                        item.Balance = item.PreviousBalance - amountToApply
                        amountToApply = 0D
                    End If
                End If
            Next item
        End Sub

        Private Sub MakeJournalItem()
            If CodeToEnum(Of ReceiptTypeSelection)(View.PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                Dim aAccountIdNo As Int16() = {}
                Dim aAmount() As Decimal = {}
                Dim aAdded() As Boolean = {}
                Dim aDiscountTaken() As Decimal = {}
                Dim nSize = 0
                Dim nIndex As Integer
                ' summarize paid invoices per account
                For Each item In View.CsrOiItems
                    Dim nAccountIdNo As Int16?
                    nAccountIdNo = item.AccountIdNo
                    If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                        nIndex = Array.IndexOf(aAccountIdNo, nAccountIdNo)
                        If nIndex < 0 Then
                            ReDim Preserve aAccountIdNo(nSize)
                            ReDim Preserve aDiscountTaken(nSize)
                            ReDim Preserve aAmount(nSize)
                            ReDim Preserve aAdded(nSize)
                            aAccountIdNo(nSize) = nAccountIdNo
                            aAmount(nSize) = item.Amount
                            aDiscountTaken(nSize) = item.DiscountTaken
                            nSize += 1
                        Else
                            aAmount(nIndex) = aAmount(nIndex) + item.Amount
                            aDiscountTaken(nIndex) = aDiscountTaken(nIndex) + item.DiscountTaken
                        End If
                    End If
                Next
                Dim nCounter = 0
                ' apply the payment to the cash account (the first entry) and zero out the rest of the existing
                ' journal item entries if there are existing journal entries.
                For Each item In View.JournalItems
                    If nCounter = 0 Then
                        item.JournalIdNo = View.IdNo
                        item.Sequence = 1
                        item.AccountIdNo = View.AccountIdNo
                        item.Debit = If(View.Amount < 0, 0, View.Amount)
                        item.Credit = If(View.Amount < 0, View.Amount * -1, 0)
                        item.RevCostCenterIdNo = 0
                        item.Notes = ""
                    Else
                        item.Credit = 0
                        item.Debit = 0
                        item.RevCostCenterIdNo = 0
                        item.Notes = ""
                    End If
                    nCounter += 1
                Next
                ' if no existing journal entries, create one for the Cash/Checking account payment.
                If View.JournalItems Is Nothing Or View.JournalItems.Count = 0 Then
                    Dim item As New JournalItemView With {
                            .JournalIdNo = View.IdNo,
                            .Sequence = 1,
                            .AccountIdNo = View.AccountIdNo,
                            .Debit = If(View.Amount < 0, 0, View.Amount),
                            .Credit = If(View.Amount < 0, View.Amount * -1, 0),
                            .RevCostCenterIdNo = 0,
                            .Notes = ""
                            }
                    View.JournalItems.Add(item)
                End If
                ' apply now the invoice payment summarized above for each existing AR account
                For i = 0 To aAccountIdNo.Count() - 1
                    For Each ji In View.JournalItems
                        ' if account matches then add the payment and discount
                        If ji.AccountIdNo = aAccountIdNo(i) Then
                            Dim nAmount = aAmount(i) + aDiscountTaken(i)
                            ji.Credit = If(nAmount < 0, 0, nAmount)
                            ji.Debit = If(nAmount < 0, nAmount * -1, 0)
                            aAdded(i) = True
                            Exit For
                        End If
                    Next
                Next
                ' find if the discount taken account exist in the old entries, if found save the discountTaken account
                Dim found = False
                For Each ji In View.JournalItems
                    ' ignore the first line entry (this is for the cash receipt account)
                    If ji.Sequence <> 1 Then
                        If ji.AccountIdNo = View.DiscountAccountIdNo Then
                            ji.Credit = If(View.DiscountTaken < 0, View.DiscountTaken * -1, 0)
                            ji.Debit = If(View.DiscountTaken < 0, 0, View.DiscountTaken)
                            found = True
                        End If
                    End If
                Next
                If Not found Then
                    ' if discount account is not found add a Discount Account Journal Entry and
                    ' add the discount taken amount.
                    If View.DiscountTaken <> 0 Then
                        Dim item As New JournalItemView With {
                                .JournalIdNo = View.IdNo,
                                .Sequence = 0,
                                .AccountIdNo = View.DiscountAccountIdNo,
                                .Debit = If(View.DiscountTaken < 0, 0, View.DiscountTaken),
                                .Credit = If(View.DiscountTaken < 0, View.DiscountTaken * -1, 0),
                                .RevCostCenterIdNo = 0,
                                .Notes = ""
                                }
                        View.JournalItems.Add(item)
                    End If
                End If
                ' find and add AR entries not yet added
                nCounter = 0
                For Each item In aAdded
                    If Not item Then
                        ' if the account is not yet added create a AR journal entry for
                        ' the account
                        Dim nAmount As Decimal
                        nAmount = aAmount(nCounter) + aDiscountTaken(nCounter)
                        Dim ji As New JournalItemView With {
                                .JournalIdNo = View.IdNo,
                                .Sequence = 0,
                                .AccountIdNo = aAccountIdNo(nCounter),
                                .Debit = If(nAmount < 0, nAmount * -1, 0),
                                .Credit = If(nAmount < 0, 0, nAmount),
                                .RevCostCenterIdNo = 0,
                                .Notes = ""
                                }
                        View.JournalItems.Add(ji)
                    End If
                    nCounter += 1
                Next
                If View.UnApplied > 0 Then
                    ' if invoice not yet fully applied, then save the
                    ' unApplied amount to the "Advances to Customer" account
                    ' check existing entries for the "Advances to Customer" account
                    Dim unAppliedSwitch As Int16 = 0
                    For Each item In View.JournalItems
                        ' get the last matching idno for accounts with advancestoCustomerAccountIdNo
                        If _
                            item.AccountIdNo = _advancesToCustomerAccountIdNo And item.Debit = 0 And item.Credit = 0 And
                            item.OriginalAmount > 0 Then
                            ' debit and credit must be zero otherwise that account has already been used above
                            item.Debit = 0
                            item.Credit = View.UnApplied
                            unAppliedSwitch = 1
                            Exit For
                        End If
                    Next
                    If unAppliedSwitch = 0 Then
                        ' advance payment journal entry not yet created
                        Dim jiModel As New JournalItemView With {
                                .JournalIdNo = View.IdNo,
                                .Sequence = 0,
                                .AccountIdNo = _advancesToCustomerAccountIdNo,
                                .Debit = 0,
                                .Credit = View.UnApplied,
                                .RevCostCenterIdNo = 0,
                                .Notes = ""
                                }
                        View.JournalItems.Add(jiModel)
                    End If
                Else
                    ' no advance payment so no advances to Customer Account
                End If
            Else
                View.CsrOiItems.Clear()
            End If
        End Sub

        Private Function SaveOpenInvoices()
            Dim retVal = 0
            If CodeToEnum(Of ReceiptTypeSelection)(View.PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                ' save the generated open invoices
                retVal = UpdateOpenInvoices()
            End If
            Return retVal
        End Function

        Private Function UpdateOpenInvoices() As Integer
            ' after saving open invoices apply the paid amount
            Dim retVal = 0
            If AddMode Then
                If View.UnApplied > 0 Then
                    ' with advance payment
                    Dim items As List(Of JournalItemModel)
                    items = GetJournalItems(View.IdNo)
                    Dim ji As New JournalItemModel
                    For Each item In items
                        If item.AccountIdNo = _advancesToCustomerAccountIdNo And item.OriginalAmount > 0 Then
                            ji.IdNo = item.IdNo
                            ji.AccountIdNo = item.AccountIdNo
                            ji.JournalIdNo = View.IdNo
                            retVal = AddArOpenInvoice(ji, "CR")
                            Exit For
                        End If
                    Next
                Else
                    ' no advance payment
                End If
            Else
                If View.UnApplied > 0 Then
                    ' with advance payment
                    ' get the journalItemIdNo
                    Dim ji As New JournalItemModel
                    Dim jiItems As List(Of JournalItemModel)
                    jiItems = GetJournalItems(View.IdNo)
                    ' get the item.IdNo of the last matching advancesToCustomerAccountIdNo if more than one found
                    For Each item In jiItems
                        If item.AccountIdNo = _advancesToCustomerAccountIdNo And item.OriginalAmount > 0 Then
                            ' if more items found overwrite the old value found and use this one
                            ji.IdNo = item.IdNo
                            ji.AccountIdNo = item.AccountIdNo
                            ji.JournalIdNo = View.IdNo
                            Exit For
                        End If
                    Next
                    Dim lOpenInvIdNo As Int32
                    ' check if the AdvancePayment OpenInvoice already created
                    lOpenInvIdNo = CInt(GetAdvanceCollectionOpenInvoice("CR", ji.IdNo))
                    If lOpenInvIdNo = 0 Then
                        ' no previous entry
                        ' add the open invoice
                        retVal = AddArOpenInvoice(ji, "CR")
                    Else
                        ' already added, nothing to do
                    End If
                Else
                    ' get the OpenInvoice IdNo
                    ' check if the AdvancePayment OpenInvoice already created
                    Dim lOpenInvoiceIdNo As Int32
                    lOpenInvoiceIdNo = CInt(GetAdvanceCollectionOpenIdNo("CR", View.IdNo))
                    If lOpenInvoiceIdNo > 0 Then
                        retVal = DeleteAdvanceCollectionOpenInvoice(lOpenInvoiceIdNo)
                    End If
                End If
            End If
            Return retVal
        End Function

        Public Function GetAdvanceCollectionOpenInvoice(journalCode As String, idNo As Int32)
            Return _
                Service.GetRecordFieldWith2Key(idNo, journalCode, "ArOpenInvoice", "JournalItemIdNo", "JournalCode",
                                               "IdNo")
        End Function

        Private Function DeleteAdvanceCollectionOpenInvoice(ByRef idNo As Int32) As String
            Dim arOpenInvoiceService As New AccountsService("ArOpenInvoice")
            If Service.CountRecordWithKey(Of Integer)("ArOpenInvoice", "IdNo", idNo) > 0 Then
                Return arOpenInvoiceService.DeleteRecord(idNo, "ArOpenInvoice")
            End If
            Return 0
        End Function

        Private Function JournalItemDataIsValid() As Boolean
            Dim retValue = True
            For Each item In View.JournalItems
                If CodeToEnum(Of PaymentTypeSelection)(View.PayorType) <> ReceiptTypeSelection.AccountsReceivable Then
                    If _
                        (item.AccountIdNo Is Nothing OrElse item.AccountIdNo = 0) AndAlso
                        (item.Debit <> 0 Or item.Credit <> 0) Then
                        MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.",
                                                      item.Sequence.ToString()))
                        retValue = False
                        Exit For
                    End If
                    If CodeToEnum(Of ReceiptTypeSelection)(View.PayorType) = ReceiptTypeSelection.Employee Then
                        If _
                            CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) =
                            SpecialAccountSelection.AccountsPayable Or
                            CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) =
                            SpecialAccountSelection.AccountsReceivable Then
                            Dim lineNumber = Format(item.Sequence, "0")
                            Dim entryNames = Messaging.TranslateCaption("Accounts Receivables/Accounts Payables")
                            Dim caption = "Invalid Entry"
                            Dim variables As String() = {"lineNumber", lineNumber, "entryNames", entryNames}
                            Dim message = Messaging.GetMessage(True, "MsgAccountsNotAllowed",
                                                               "Error on line {lineNumber}. Sorry {entryNames} accounts not allowed for this transaction!",
                                                               caption)
                            caption = Messaging.TranslateCaption(caption)
                            Messaging.Show(message, caption, variables, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            retValue = False
                            Exit For
                        End If
                    ElseIf CodeToEnum(Of ReceiptTypeSelection)(View.PayorType) = ReceiptTypeSelection.SupplierRefund _
                        Then
                        If _
                            CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) =
                            SpecialAccountSelection.AccountsReceivable Or
                            CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) =
                            SpecialAccountSelection.EmployeeLoan Then
                            Dim lineNumber = Format(item.Sequence, "0")
                            Dim entryNames = Messaging.TranslateCaption("Accounts Receivable/Employee")
                            Dim caption = "Invalid Entry"
                            Dim variables As String() = {"lineNumber", lineNumber, "entryNames", entryNames}
                            Dim message = Messaging.GetMessage(True, "MsgAccountsNotAllowed")
                            caption = Messaging.TranslateCaption(caption)
                            Messaging.Show(message, caption, variables, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            retValue = False
                            Exit For
                        End If
                    Else
                        If _
                            CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) =
                            SpecialAccountSelection.AccountsPayable Or
                            CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) =
                            SpecialAccountSelection.AccountsReceivable Or
                            CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) =
                            SpecialAccountSelection.EmployeeLoan Then
                            Dim lineNumber = Format(item.Sequence, "0")
                            Dim entryNames = Messaging.TranslateCaption("Accounts Payables/Accounts Receivables/Employee")
                            Dim caption = "Invalid Entry"
                            Dim variables As String() = {"lineNumber", lineNumber, "entryNames", entryNames}
                            Dim message = Messaging.GetMessage(True, "MsgAccountsNotAllowed")
                            caption = Messaging.TranslateCaption(caption)
                            Messaging.Show(message, caption, variables, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            retValue = False
                            Exit For
                        End If
                    End If
                End If
            Next
            Return retValue
        End Function

        Public Function CsrOiItemDataIsValid() As Boolean
            Dim retVal = True
            Dim index As Int16 = 0
            For Each item In View.CsrOiItems
                If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                    If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
                       (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
                        Dim lineNumber = item.Sequence.ToString()
                        Dim variables = {"lineNumber", lineNumber}
                        Dim message = Messaging.GetMessage(True, "MsgAppliedAmtExceedsBalance",
                                                           "Error in line {lineNumber}. Applied amount and discount exceeds balance.",
                                                           "Invalid Payment")
                        Dim caption = Messaging.TranslateCaption("Invalid Payment")
                        message = Messaging.ReplaceValues(message, variables)
                        Messaging.Show(message, caption)
                        If View.CsrOiItems(index).Errors Is Nothing Then
                            View.CsrOiItems(index).Errors = New List(Of String)
                        End If
                        View.CsrOiItems(index).Errors.Add(message)
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
                        retVal = False
                        Exit For
                    Else
                        ' clear error message
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = ""
                        If View.CsrOiItems(index).Errors IsNot Nothing Then
                            View.CsrOiItems(index).Errors.Clear()
                        End If
                    End If
                End If
                index += 1
            Next
            If retVal Then
                If View.UnApplied <> 0 Then
                    Dim totalBalance = 0D
                    For Each item In View.CsrOiItems
                        totalBalance += item.Balance
                    Next
                    If totalBalance > 0 Then
                        If View.UnApplied > 0 Then
                            Messaging.Show(True, "MsgCollectionNotFullyApplied")
                            retVal = False
                        Else
                            Messaging.Show(True, "MsgCollectionIsOverApplied")
                            retVal = False
                        End If
                    Else
                        If Messaging.Show(True, "AskMakeExcessCollectionAdvance",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning,
                                          MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            retVal = True
                        Else
                            retVal = False
                        End If
                    End If
                Else
                    retVal = True
                End If
            End If
            Return retVal
        End Function

        Public Function GetAdvanceCollectionOpenIdNo(pJournalCode As String, idNo As Int32) As Integer
            Dim retVal As String
            retVal = Service.GetRecordFieldWith2Key(idNo, pJournalCode, "ArOpenInvoice", "JournalIdNo", "JournalCode",
                                                    "IdNo")
            Return retVal
        End Function

        Public Function GetCsrOiItems(csrOiIdNo As Int32) As List(Of CsrOiItemModel)
            Return _openInvItemService.GetRecordsWithGroupIdNo(Of CsrOiItemModel)(csrOiIdNo, "Sequence")
        End Function

        Public Function GetJournalItems(journalIdNo As Int32) As List(Of JournalItemModel)
            Return _journalItemService.GetRecordsWithGroupIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetCustomerOpenInvoices(dView As List(Of CsrOiItemView)) As List(Of CsrOiItemView)
            Dim dModel As New List(Of CsrOiItemModel)
            Dim dOriginalModel As New List(Of CsrOiItemModel)
            Dim nSeq As Integer
            GlobalVariables.Mapper.Map(dView, dModel)
            nSeq = dView.Count()
            If EditMode Then
                If View.PayorIdNo = OriginalModel.PayorIdNo AndAlso View.PayorType = OriginalModel.PayorType Then
                    ' need to add the original items because if items are already paid in the original data they will not be added if there is already a full or partial payment
                    AddOpenInvoices(True, OriginalModel.CsrOiItems, dModel, nSeq)
                    nSeq = dModel.Count()
                End If
            End If
            Dim unpaidInvoices = Service.GetOpenInvoices(Of CsrOiItemModel)(View.PayorIdNo)
            AddOpenInvoices(False, unpaidInvoices, dModel, nSeq)
            GlobalVariables.Mapper.Map(dModel, dView)
            Return dView
        End Function

        Public Function GetCustomerOpenInvoices(ByRef customerIdNo As Int32?) As List(Of CsrOiItemModel)
            If customerIdNo Is Nothing Then
                Return New List(Of CsrOiItemModel)
            Else
                Return Service.GetOpenInvoices(Of CsrOiItemModel)(customerIdNo)
            End If
        End Function

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.TransactionDate = Date.Now()
            If View.JournalItems IsNot Nothing Then
                View.JournalItems.Clear()
            Else
                View.JournalItems = New List(Of JournalItemView)
            End If
            Dim item As New JournalItemView With {
                    .JournalIdNo = View.IdNo,
                    .Sequence = 1,
                    .AccountIdNo = Nothing,
                    .Credit = 0,
                    .Debit = View.Amount,
                    .RevCostCenterIdNo = 0,
                    .Notes = ""
                    }
            View.JournalItems.Add(item)
            If View.CsrOiItems IsNot Nothing Then
                View.CsrOiItems.Clear()
            Else
                View.CsrOiItems = New List(Of CsrOiItemView)
            End If
            If View.AccountIdNo <= 0 Then
                View.AccountIdNo = DefaultCashReceiptAccount
            End If
        End Sub

        Private Sub JournalItemFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("AccountIdNo") = itemDataView.AccountIdNo
            workRow("Credit") = itemDataView.Credit
            workRow("Debit") = itemDataView.Debit
            workRow("JournalIdNo") = View.IdNo
            workRow("PayIdNo") = itemDataView.PayIdNo
            workRow("Notes") = itemDataView.Notes
            workRow("RevCostCenteridNo") = itemDataView.RevCostCenterIdNo
        End Sub

        Public Function JournalItemFilter(obj As Object) As Boolean
            If (obj.Debit = 0 AndAlso obj.Credit = 0 AndAlso obj.Sequence <> 1) Then
                Return False
            End If
            Return True
        End Function

        Private Sub CsrOiFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("Amount") = itemDataView.Amount
            workRow("ArOpenInvoiceIdNo") = itemDataView.ArOpenInvoiceIdNo
            workRow("CsrIdNo") = View.IdNo
            workRow("DiscountTaken") = itemDataView.DiscountTaken
            'View.TotalCredits += itemDataView.Amount + itemDataView.DiscountTaken
        End Sub

        Public Function CsrOiItemFilter(obj As Object) As Boolean
            If (obj.Amount = 0 AndAlso obj.DiscountTaken = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Sub AddCustomerOpenInvoices()
            If View.PayorIdNo <> 0 Then
                Dim unpaidInvoices = GetCustomerOpenInvoices(View.PayorIdNo)
                Dim nSeq As Integer
                If AddMode Then
                    View.CsrOiItems.Clear()
                End If
                If View.CsrOiItems IsNot Nothing Then
                    nSeq = View.CsrOiItems.Count()
                Else
                    nSeq = 0
                End If
                For Each unpaidInvoice In unpaidInvoices
                    Dim itemFound = False
                    If View.CsrOiItems IsNot Nothing Then
                        For Each item In View.CsrOiItems
                            If item.ArOpenInvoiceIdNo = unpaidInvoice.IdNo Then
                                itemFound = True
                                Exit For
                            End If
                        Next
                    End If
                    If Not itemFound Then

                        If unpaidInvoice.JournalCode = "CR" And unpaidInvoice.JournalIdNo = View.IdNo Then
                            ' ignore advance payments if applied to this entry.
                        Else
                            nSeq += 1
                            Dim item As New CsrOiItemView With {
                                    .AccountIdNo = unpaidInvoice.AccountIdNo,
                                    .Amount = unpaidInvoice.Amount,
                                    .ArOpenInvoiceIdNo = unpaidInvoice.IdNo,
                                    .Balance = unpaidInvoice.Balance,
                                    .DiscountTaken = unpaidInvoice.DiscountTaken,
                                    .InvoiceNo = unpaidInvoice.InvoiceNo,
                                    .JournalCode = unpaidInvoice.JournalCode,
                                    .JournalIdNo = unpaidInvoice.JournalIdNo,
                                    .PreviousBalance = unpaidInvoice.Balance,
                                    .Sequence = nSeq,
                                    .TransactionDate = unpaidInvoice.TransactionDate
                                    }
                            If View.CsrOiItems Is Nothing Then
                                View.CsrOiItems = New List(Of CsrOiItemView)
                            End If
                            View.CsrOiItems.Add(item)
                        End If
                    End If
                Next
            End If
        End Sub

        Private Function AddOpenInvoices(original As Boolean, source As List(Of CsrOiItemModel),
                                         target As List(Of CsrOiItemModel), nSeq As Integer) As Integer
            For Each invoice In source
                Dim itemFound = False
                For Each item In target
                    If item.ArOpenInvoiceIdNo = invoice.ArOpenInvoiceIdNo Then
                        itemFound = True
                        Exit For
                    End If
                Next
                If Not itemFound Then
                    If invoice.JournalCode = JournalCode And invoice.JournalIdNo = View.IdNo Then
                        ' ignore advance payments if applied to this entry.
                    Else
                        nSeq += 1
                        target.Add(GetOpenInvoice(original, nSeq, invoice))
                    End If
                End If
            Next
            Return nSeq
        End Function

        Private Function GetOpenInvoice(original As Boolean, nSeq As Integer, invoice As Object) As CsrOiItemModel
            Dim item As CsrOiItemModel
            item = New CsrOiItemModel With {
                .AccountIdNo = invoice.AccountIdNo,
                .Amount = invoice.Amount,
                .ArOpenInvoiceIdNo = invoice.ArOpenInvoiceIdNo,
                .Balance = invoice.Balance,
                .DiscountTaken = invoice.DiscountTaken,
                .InvoiceNo = invoice.InvoiceNo,
                .JournalCode = invoice.JournalCode,
                .JournalIdNo = invoice.JournalIdNo,
                .PreviousBalance = IIf(original, invoice.PreviousBalance, invoice.Balance),
                .Sequence = nSeq,
                .TransactionDate = invoice.TransactionDate
                }
            Return item
        End Function

        Private Sub OnBeforeMappingData(dataModel As Object) Handles MyBase.BeforeMappingData
            ' need to do this because the Mapping source part of this program maps the PayeeIdNo first before
            ' the ReceiptType so in order to override this part we need to retrieve the ReceiptType first
            ' because when assigning the cboPayorIdNo the datasource must be correct that is why
            ' we need to set the DataSource part of the cboPayorIdNo before we can assign the PayorIdNo
            View.PayorType = dataModel.PayorType
            CallByName(View, "SetPayorDataSource", CallType.Method, View.PayorType)
            View.PayorIdNo = dataModel.PayorIdNo
        End Sub

        'Public Function GetCustomerOpenInvoices(dView As List(Of CsrOiItemView)) As List(Of CsrOiItemView)
        '    Dim dModel As New List(Of CsrOiItemModel)
        '    Dim dOriginalModel As New List(Of CsrOiItemModel)
        '    Dim nSeq As Integer
        '    GlobalVariables.Mapper.Map(dView, dModel)
        '    nSeq = dView.Count()
        '    If EditMode Then
        '        If View.PayorIdNo = OriginalModel.PayorIdNo AndAlso View.PayorType = OriginalModel.PayorType Then
        '            ' need to add the original items because if items are already paid in the original data they will not be added if there is already a full or partial payment
        '            AddOpenInvoices(True, OriginalModel.CsrOiItems, dModel, nSeq)
        '            nSeq = dModel.Count()
        '        End If
        '    End If
        '    Dim unpaidInvoices = GetCustomerOpenInvoices(View.PayorIdNo)
        '    AddOpenInvoices(False, unpaidInvoices, dModel, nSeq)
        '    GlobalVariables.Mapper.Map(dModel, dView)
        '    Return dView
        'End Function

        'Public Overrides Function IsOkToEditRecord() As Boolean
        '    Dim result As Boolean = True
        '    Dim reconciledDao = New ReconciledDao
        '    For Each item In View.JournalItems
        '        If reconciledDao.IsItemReconciled("CR", item.IdNo) Then
        '            Messaging.Show(True, "MsgEditingOfReconciledNotAllowed")
        '            result = False
        '            Exit For
        '        End If
        '    Next
        '    Return result
        'End Function

        Public Overrides Function IsOkToEditRecord() As Boolean
            If Not MyBase.IsOkToEditRecord() Then
                Return False
            End If
            Dim result As Boolean = True
            If ReconciledEntriesExist(View.JournalItems, "CR") Then
                result = False
                'Else
                '    If DependentRecordExist() Then
                '        result = False
                '    End If
            End If
            Return result
        End Function

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim retValue As Boolean = True
            If MyBase.IsOkToDeleteRecord Then
                If ReconciledEntriesExist(View.JournalItems, "CR") Then
                    retValue = False
                End If
            End If
            Return retValue
        End Function

        'Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
        '    Dim returnValue As Boolean = False
        '    For Each item In View.JournalItems
        '        If IsAccountsReceivableAccount(item.AccountIdNo) Then
        '            Dim apOpenInvoiceNumber As Int32 = GetApOpenInvoiceNumber(item.IdNo)
        '            If CheckDependentRecords(Of Int32)(apOpenInvoiceNumber, "CdOiItem", "ApOpenInvoiceIdNo") Then
        '                Return True
        '            End If
        '        End If
        '        If IsAccountsPayableAccount(View.AccountIdNo) Then
        '            Dim apOpenInvoiceNumber As Int32 = GetApOpenInvoiceNumber(item.IdNo)
        '            If CheckDependentRecords(Of Int32)(apOpenInvoiceNumber, "CdOiItem", "ApOpenInvoiceIdNo") Then
        '                Return True
        '            End If
        '        End If
        '    Next
        '    Return False
        'End Function

    End Class

End Namespace