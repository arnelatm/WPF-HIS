Imports System.Globalization
Imports System.Security.Cryptography
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

        Private ReadOnly _oiItemService
        Private ReadOnly _journalItemService

        Public Sub New(view As ICashReceiptJournalView)
            MyBase.New(view)
            Dim djArgs = {"CashReceiptJournalItem_View", "UpdateCashReceiptJournalItemTVP", "InsertCashReceiptJournalItemTVP"}
            WithTreeView = False
            SortOrderKey = "IdNo"
            ReportName = "Cash Receipt Journal.Rpt"
            Service = New AccountsService("CashReceiptJournal")
            TableName = "CashReceiptJournal"
            _journalItemService = New AccountsService("JournalItem", Nothing, djArgs)
            _oiItemService = New AccountsService("CsrOiItem")
            _advancesToCustomerAccountIdNo = GetCustomerAdvancesAccountIdNo()

            CreateDataTable(DtInsertTable, {{"AccountIdNo", GetType(Int16)},
                                            {"ContactIdNo", GetType(Int32)},
                                            {"Credit", GetType(Decimal)},
                                            {"Debit", GetType(Decimal)},
                                            {"JournalIdNo", GetType(Int32)},
                                            {"Notes", GetType(String)},
                                            {"RevCostCenterIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}})

            CreateDataTable(DtUpdateTable, {{"AccountIdNo", GetType(Int16)},
                                            {"ContactIdNo", GetType(Int32)},
                                            {"Credit", GetType(Decimal)},
                                            {"Debit", GetType(Decimal)},
                                            {"IdNo", GetType(Int32)},
                                            {"JournalIdNo", GetType(Int32)},
                                            {"Notes", GetType(String)},
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

            AddHandler view.AutoApplyAmountRequested, AddressOf OnAutoApplyAmountRequested
            AddHandler view.AddCustomerOpenInvoices, AddressOf OnAddCustomerOpenInvoices
            AddHandler view.ReceiptTypeChanged, AddressOf OnReceiptTypeChanged
            AddHandler view.JiAccountIdNoChanged, AddressOf OnAccountIdNoChanged
            AddHandler view.DebitAmountChanged, AddressOf OnDebitAmountChanged
            AddHandler view.CreditAmountChanged, AddressOf OnCreditAmountChanged
            AddHandler view.ContactIdNoChanged, AddressOf OnContactIdNoChanged
            AddHandler view.ReceiptAmountChanged, AddressOf OnReceiptAmountChanged
            AddHandler view.DebitAccountIdNoChanged, AddressOf OnDebitAccountIdNoChanged

            view.CashReceiptAccountCount = GetCrAccountCount()
        End Sub

        Private Sub OnDebitAccountIdNoChanged(bs As BindingSource)
            UpdateFirstJournalItemEntry(bs)
        End Sub

        Private Sub OnReceiptAmountChanged(bsJournalItem As BindingSource, bsCsrOiItem As BindingSource)
            If View.OpenInvoiceMode Then
                View.UnApplied = View.Amount - View.Applied
            Else
                UpdateFirstJournalItemEntry(bsJournalItem)
            End If
        End Sub

        Public Property JournalCode As String = "CR"

        Protected Overrides Sub CreateDataSources()
            View.ContactDataSource = GetDataLookupTable({"Contact_View", "IdNo,ContactName,ContactCode,CSECode"})
            MakeVarDataSources({New Object() {"Account", "AccountsByCode", Nothing, Nothing},
            New Object() {"RevCostCenter", "RevCostCentersByCode", Nothing, Nothing}})
            'New Object() {"Employee", "EmployeesByName", Nothing, Nothing},
            'New Object() {"Customer", "CustomersByName", Nothing, Nothing},
            'New Object() {"Supplier", "SuppliersByName", Nothing, Nothing}})
            'New Object() {"Contact_View", "ContactByName", "IdNo,ContactName,ContactCode", Nothing, Nothing},
            CreateEnumDataSource(Of ReceiptTypeSelection)("PayorType")
            CreateSpecialAccountDataSource("AccountIdNo", {EnumToCode(SpecialAccountSelection.Bank), EnumToCode(SpecialAccountSelection.Cash), EnumToCode(SpecialAccountSelection.CheckingAccount)})
            CreateSpecialAccountDataSource("DiscountAccountIdNo", {EnumToCode(SpecialAccountSelection.AccountsReceivableDiscount)})
        End Sub

        Public Sub CrLanguageChanged() Handles MyBase.LanguageChanged
            UpdateJournalCodeDisplay()
        End Sub

        Private Sub UpdateJournalCodeDisplay()
            If GlobalVariables.RightToLeftLayout Then
                View.JournalCodeDisplay = GetLocalizedPrefix(JournalCode)
            Else
                View.JournalCodeDisplay = JournalCode
            End If
        End Sub

        Public Function GetCustomerAdvancesAccountIdNo()
            Return GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.CustomerAdvances), "Account", "SpecialAccount", "IdNo")
        End Function

        Private Function GetCrAccountCount() As Int16
            Dim retVal As Int16
            Dim specialAccountList As String = EnumToCode(SpecialAccountSelection.Bank) + "," + EnumToCode(SpecialAccountSelection.Cash) +
                                               "," + EnumToCode(SpecialAccountSelection.CheckingAccount)
            Dim filter As String = ConvertSpecialAccountsToFilter(specialAccountList)
            retVal = Service.GetRecordCount("Account", filter)
            Return retVal
        End Function


        Private ReadOnly Property DefaultCashReceiptAccount As Int16
            Get
                Dim retVal As String = Nothing
                If View.AccountIdNo = 0 Then
                    If View.CashReceiptAccountCount >= 1 Then
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


        Public Sub SaveChildren(ByRef retVal As Integer) _
            Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_journalItemService, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_oiItemService, DtOiUpdateTable, DtOiInsertTable, passedValue, "CsrIdNo")
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

        Private Sub UpdateFirstJournalItemEntry(bs As BindingSource)
            If View.JournalItems IsNot Nothing Then
                If bs.Count() = 0 Then
                    CreateFirstJournalItem(bs)
                Else
                    bs.MoveFirst()
                End If
                With bs.Current
                    .JournalIdNo = View.IdNo
                    .Sequence = 1
                    .AccountIdNo = View.AccountIdNo
                    .Credit = 0
                    .Debit = View.Amount
                    .RevCostCenterIdNo = 0
                    MakePayTypeAndSpecialAccount(bs, View.AccountIdNo)
                End With
            End If
        End Sub

        Private Function CreateFirstJournalItem(bs As BindingSource)
            bs.AddNew()
            bs.Current.JournaldNo = View.IdNo
            'Dim item As New JournalItemView With {
            '        .JournalIdNo = View.IdNo
            '        }
            'Return item
        End Function

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



        Public Overrides Sub GoPrintRecordWithArgs(Optional formCulture As Object = Nothing)
            Dim totalCreditAmount As String
            Dim currencies As New List(Of CurrencyInfo)()
            Dim languageCode As String = GetCultureLanguageCode(formCulture)
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            Dim transactionAmount As String
            Dim curCulture = CultureInfo.CurrentCulture
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            If languageCode = "ar" Then
                transactionAmount = New ToWord(View.Amount, currencies(0)).ConvertToArabic()
            Else
                transactionAmount = New ToWord(View.Amount, currencies(0)).ConvertToEnglish()
            End If
            If languageCode = "ar" Then
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            ShowReportToScreen(ReportName,
                               {View.IdNo, "CashReceiptJournalIdNo",
                               transactionAmount, "CreditAmountInWords",
                               totalCreditAmount, "TotalLineAmountInWords",
                               languageCode, "Language"})
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
            Return _oiItemService.GetRecordsWithGroupIdNo(Of CsrOiItemModel)(csrOiIdNo, "Sequence")
        End Function

        Public Function GetJournalItems(journalIdNo As Int32) As List(Of JournalItemModel)
            Return _journalItemService.GetRecordsWithGroupIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

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
        '    Dim unpaidInvoices = Service.GetOpenInvoices(Of CsrOiItemModel)(View.PayorIdNo)
        '    AddOpenInvoices(False, unpaidInvoices, dModel, nSeq)
        '    GlobalVariables.Mapper.Map(dModel, dView)
        '    Return dView
        'End Function

        Public Function GetCustomerOpenInvoices(ByRef customerIdNo As Int32?) As List(Of CsrOiItemModel)
            If customerIdNo Is Nothing Then
                Return New List(Of CsrOiItemModel)
            Else
                Return Service.GetOpenInvoices(Of CsrOiItemModel)(customerIdNo)
            End If
        End Function

        Private Sub JournalItemFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("AccountIdNo") = itemDataView.AccountIdNo
            workRow("ContactIdNo") = View.ContactIdNo
            workRow("Credit") = itemDataView.Credit
            workRow("Debit") = itemDataView.Debit
            workRow("JournalIdNo") = View.IdNo
            workRow("Notes") = itemDataView.Notes
            workRow("RevCostCenterIdNo") = itemDataView.RevCostCenterIdNo
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
            Dim cseIdNo As Int32? = GetCSEIdNo(View.ContactIdNo)
            If cseIdNo <> 0 Then
                Dim unpaidInvoices = GetCustomerOpenInvoices(cseIdNo)
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

        'Private Sub OnBeforeMappingData(dataModel As Object) Handles MyBase.BeforeMappingData
        '    ' need to do this because the Mapping source part of this program maps the PayeeIdNo first before
        '    ' the PayorType so in order to override this part we need to retrieve the PayroType first
        '    ' because when assigning the cboPayorIdNo the datasource must be correct that is why
        '    ' we need to set the DataSource part of the cboPayorIdNo before we can assign the PayorIdNo
        '    View.PayorType = dataModel.PayorType
        '    MakePayorIdNoDataSource(dataModel.PayorType)
        '    'CallByName(View, "SetPayorDataSource", CallType.Method, View.PayorType)
        '    View.ContactIdNo = dataModel.ContactIdNo
        'End Sub

        'Private Sub OnOpenInvoiceDataRequested(bs As BindingSource)
        '    bs.DataSource = GetCustomerOpenInvoices(View.CsrOiItems)
        'End Sub

        Private Sub OnAfterMappingData(dataModel As Object) Handles MyBase.AfterMappingData
            View.OpenInvoiceMode = GetOpenInvoiceMode()
        End Sub

        Private Sub OnAutoApplyAmountRequested(bsCsrOiItems As BindingSource)
            Dim amountToApply = View.Amount
            For Each item As CsrOiItemView In bsCsrOiItems
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
            bsCsrOiItems.ResetBindings(False)
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                If CodeToEnum(Of ReceiptTypeSelection)(View.PayorType) <> ReceiptTypeSelection.AccountsReceivable Then
                    CustomObjToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf JournalItemFillData,
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
                    CustomObjToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf JournalItemFillData,
                                     AddressOf JournalItemFilter)
                    CustomObjToDataTables(View.CsrOiItems, DtOiInsertTable, DtOiUpdateTable, AddressOf CsrOiFillData,
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


        Private Sub OnUserDeletedRow(sender)
            Dim payorTypeEnum As ReceiptTypeSelection = CodeToEnum(Of ReceiptTypeSelection)(View.PayorType)
            If payorTypeEnum = ReceiptTypeSelection.AccountsReceivable Or payorTypeEnum = ReceiptTypeSelection.Customer Then
                UpdateOutputVatAmount(View.JournalItems)
            ElseIf payorTypeEnum = ReceiptTypeSelection.SupplierRefund Then
                UpdateInputVatAmount(View.JournalItems)
            End If
        End Sub


        Private Sub OnSuccessfulDelete(idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.CsrOiItems IsNot Nothing And View.CsrOiItems.Count() > 0 Then
                DtOiUpdateTable.Clear()
                _oiItemService.DelUpdateTvp(DtOiUpdateTable, idNo)
            End If
            ' ReSharper disable once VBUseMethodAny.1
            If View.JournalItems IsNot Nothing And View.JournalItems.Count() > 0 Then
                DtUpdateTable.Clear()
                _journalItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

        Private Sub OnAutoApplyAmount(bsCsrOiItems As BindingSource)
            Dim amountToApply = View.Amount
            'apply the negative values first
            For Each item In bsCsrOiItems
                If item.PreviousBalance <= 0 Then
                    amountToApply += item.PreviousBalance * -1
                    item.Amount = item.PreviousBalance
                    item.DiscountTaken = 0D
                    item.Balance = 0D
                Else
                    item.Amount = 0D
                    item.DiscountTaken = 0D
                    item.Balance = item.PreviousBalance
                End If
            Next item
            For Each item In bsCsrOiItems
                If item.Balance > 0D Then
                    If item.Balance <= amountToApply Then
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

        Private Sub OnAddCustomerOpenInvoices(bs As BindingSource)
            CreateOpenInvoiceData(bs)
        End Sub

        Private Sub CreateOpenInvoiceData(bs As BindingSource)
            Dim cseIdNo As Int32? = GetCSEIdNo(View.ContactIdNo)
            If cseIdNo IsNot Nothing AndAlso cseIdNo <> 0 Then
                Dim unpaidInvoices = GetCustomerOpenInvoices(cseIdNo)
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
                        itemFound = IsUnpaidInvoiceFound(unpaidInvoice)
                    End If
                    If itemFound Then
                        ' ignore unpaidInvoice - already present in the View.CsrOiItems
                    Else
                        If unpaidInvoice.JournalCode = JournalCode And unpaidInvoice.JournalIdNo = View.IdNo Then
                            ' ignore advance payments if applied to this entry.
                        Else
                            bs.AddNew()
                            nSeq += 1
                            AssignUnpaidInvoiceToModel(bs, nSeq, unpaidInvoice)
                        End If
                    End If
                Next
            End If
        End Sub

        Private Sub AssignUnpaidInvoiceToModel(bs As BindingSource, nSeq As Integer, unpaidInvoice As CsrOiItemModel)
            With bs.Current
                .AccountIdNo = unpaidInvoice.AccountIdNo
                .Amount = unpaidInvoice.Amount
                .ArOpenInvoiceIdNo = unpaidInvoice.ArOpenInvoiceIdNo
                .Balance = unpaidInvoice.Balance
                .DiscountTaken = unpaidInvoice.DiscountTaken
                .InvoiceNo = unpaidInvoice.InvoiceNo
                .JournalCode = unpaidInvoice.JournalCode
                .JournalIdNo = unpaidInvoice.JournalIdNo
                .PreviousBalance = unpaidInvoice.Balance
                .Sequence = nSeq
                .TransactionDate = unpaidInvoice.TransactionDate
            End With
        End Sub

        Private Function IsUnpaidInvoiceFound(unpaidInvoice As CsrOiItemModel) As Boolean
            Dim itemFound As Boolean = False
            For Each item In View.CsrOiItems
                If item.ArOpenInvoiceIdNo = unpaidInvoice.IdNo Then
                    itemFound = True
                    Exit For
                End If
            Next
            Return itemFound
        End Function

        Private Sub OnReceiptTypeChanged(payorType As String, bsJournalItem As BindingSource, bsCsrOiItems As BindingSource)
            View.OpenInvoiceMode = GetOpenInvoiceMode()
            UpdateContactDataSource(payorType)
            If View.OpenInvoiceMode Then
                If View.ContactIdNo IsNot Nothing AndAlso View.ContactIdNo > 0 Then
                    If CodeToEnum(Of ReceiptTypeSelection)(payorType) = ReceiptTypeSelection.AccountsReceivable Then
                        CreateOpenInvoiceData(bsCsrOiItems)
                    Else
                        DeleteBindingSourceData(bsCsrOiItems)
                    End If
                Else
                    DeleteBindingSourceData(bsCsrOiItems)
                End If
            Else
                UpdateFirstJournalItemEntry(bsJournalItem)
                DeleteBindingSourceData(bsCsrOiItems)
            End If
        End Sub

        Private Shared Sub DeleteBindingSourceData(bs As BindingSource)
            For Each item As DataRowView In bs
                bs.Remove(item)
            Next
        End Sub

        Private Sub UpdateContactDataSource(payorType As String)
            Dim filter As String = View.ContactDataSource.DefaultView.RowFilter
            Dim receiptTypeEnum As ReceiptTypeSelection = CodeToEnum(Of ReceiptTypeSelection)(payorType)
            Dim oldContactIdNo As Int32? = View.ContactIdNo
            Select Case receiptTypeEnum
                Case ReceiptTypeSelection.AccountsReceivable, ReceiptTypeSelection.Customer
                    If filter <> "CSECode = 'C'" Then
                        View.ContactDataSource.DefaultView.RowFilter = "CSECode = 'C'"
                    End If
                Case ReceiptTypeSelection.Employee
                    If filter <> "CSECode = 'E'" Then
                        View.ContactDataSource.DefaultView.RowFilter = "CSECode = 'E'"
                    End If
                Case ReceiptTypeSelection.SupplierRefund
                    If filter <> "CSECode = 'S'" Then
                        View.ContactDataSource.DefaultView.RowFilter = "CSECode = 'S'"
                    End If
                Case Else
                    View.ContactDataSource.DefaultView.RowFilter = Nothing
            End Select
            'restore the old value
            View.ContactIdNo = oldContactIdNo
            ' check if value was assigned
            If View.ContactIdNo <> oldContactIdNo Then
                ' value assigned (y) not found in DataSource, so force a non existing value to force contactIdNo set to nothing
                View.ContactIdNo = Nothing
            End If
        End Sub




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


        Private Sub OnAccountIdNoChanged(sender As Object, e As DataGridViewCellEventArgs)
            Dim bs As BindingSource = DirectCast(sender.DataSource, BindingSource)
            Dim accountIdNo = bs.Current.AccountIdNo
            If accountIdNo IsNot Nothing Then
                Dim ji As JournalItemView = DirectCast(bs.Current, JournalItemView)
                MakePayTypeAndSpecialAccount(ji, accountIdNo)
                UpdateInputVatAmount(View.JournalItems)
            End If
        End Sub

        Private Sub OnCreditAmountChanged(sender As Object, e As DataGridViewCellEventArgs)
            Dim bs As BindingSource = DirectCast(sender.DataSource, BindingSource)
            MakeDebitAmount(View.JournalItems(e.RowIndex), bs.Current.Debit)
            View.VatAmount = UpdateInputVatAmount(View.JournalItems)
        End Sub

        Private Sub OnDebitAmountChanged(sender As Object, e As DataGridViewCellEventArgs)
            Dim bs As BindingSource = DirectCast(sender.DataSource, BindingSource)
            MakeCreditAmount(View.JournalItems(e.RowIndex), bs.Current.Credit)
            View.VatAmount = UpdateInputVatAmount(View.JournalItems)
        End Sub

        Private Sub OnContactIdNoChanged(bs As BindingSource)
            Dim dModel As New List(Of CsrOiItemModel)
            Dim dView As New List(Of CsrOiItemView)
            Dim dOriginalModel As New List(Of CsrOiItemModel)
            Dim nSeq As Integer
            If View.PayorType IsNot Nothing AndAlso View.PayorType = EnumToCode(ReceiptTypeSelection.AccountsReceivable) Then
                GlobalVariables.Mapper.Map(dView, dModel)
                Dim cseIdNo As Int32? = GetCSEIdNo(View.ContactIdNo)
                nSeq = dView.Count()
                If View.ContactIdNo = OriginalModel.ContactIdNo AndAlso View.PayorType = OriginalModel.PayorType Then
                    ' need to add the original items because if items are already paid in the original data they will not be added if there is already a full or partial payment
                    AddOpenInvoices(True, OriginalModel.CsrOiItems, dModel, nSeq)
                    nSeq = dModel.Count()
                End If

                Dim unpaidInvoices = GetCustomerOpenInvoices(cseIdNo)
                AddOpenInvoices(False, unpaidInvoices, dModel, nSeq)
                GlobalVariables.Mapper.Map(dModel, dView)
                bs.DataSource = GetCustomerOpenInvoices(cseIdNo)
                View.VatAmount = UpdateInputVatAmount(View.JournalItems)
            Else
                GlobalVariables.Mapper.Map(dModel, dView)
            End If
        End Sub


        Public Function GetCustomerOpenInvoices(dView As List(Of CsrOiItemView)) As List(Of CsrOiItemView)
            Dim dModel As New List(Of CsrOiItemModel)
            Dim dOriginalModel As New List(Of CsrOiItemModel)
            Dim nSeq As Integer
            Dim cseIdNo As Int32? = GetCSEIdNo(View.ContactIdNo)
            GlobalVariables.Mapper.Map(dView, dModel)
            nSeq = dView.Count()
            If EditMode Then
                If View.ContactIdNo = OriginalModel.ContactIdNo AndAlso View.PayorType = OriginalModel.PayorType Then
                    ' need to add the original items because if items are already paid in the original data they will not be added if there is already a full or partial payment
                    AddOpenInvoices(True, OriginalModel.CsrOiItems, dModel, nSeq)
                    nSeq = dModel.Count()
                End If
            End If
            Dim unpaidInvoices = GetCustomerOpenInvoices(cseIdNo)
            AddOpenInvoices(False, unpaidInvoices, dModel, nSeq)
            GlobalVariables.Mapper.Map(dModel, dView)
            Return dView
        End Function

        'Private Function GetPayorIdNo(contactIdNo As Int32?, payorType As String) As Int32
        '    Return Service.GetField(Of Int32, Int32)(contactIdNo, "Contact", "IdNo", "PayorIdNo")
        'End Function

        Private Sub OnBeforeEdit() Handles MyBase.BeforeEdit
            UpdateContactDataSource(View.PayorType)
        End Sub

        'Private Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
        '    View.OpenInvoiceMode = GetOpenInvoiceMode()
        'End Sub

        'Private Sub SetOpenInvoiceMode()
        '    Dim receiptTypeEnum = CodeToEnum(Of ReceiptTypeSelection)(View.PayorType)
        '    If receiptTypeEnum = ReceiptTypeSelection.AccountsReceivable Then
        '        View.OpenInvoiceMode = True
        '    Else
        '        View.OpenInvoiceMode = False
        '    End If
        'End Sub

        Private Function GetOpenInvoiceMode() As Boolean
            Dim receiptTypeEnum = CodeToEnum(Of ReceiptTypeSelection)(View.PayorType)
            If receiptTypeEnum = ReceiptTypeSelection.AccountsReceivable Then
                Return True
            Else
                Return False
            End If
        End Function


        'bsJournalItems.AddNew()
        'JournalItems(nIndex).AccountIdNo = accountId
        '' adding a new row to the bindingsource adds a new empty row at the end with null values
        '' therefore there is a need to remove that row because it causes errors when moving to that empty row
        'bsJournalItems.RemoveAt(bsJournalItems.Count - 1)

        'End If

        '    Dim accountId = DirectCast(DataGridViewJournalItems.CurrentCell, CDgvComboBoxCell).CellEditingControl.GetValue()
        '    If DataGridViewJournalItems.CurrentRow.Index = DataGridViewJournalItems.NewRowIndex Then
        '        bsJournalItems.AddNew()
        '        JournalItems(nIndex).AccountIdNo = accountId
        '        ' adding a new row to the bindingsource adds a new empty row at the end with null values
        '        ' therefore there is a need to remove that row because it causes errors when moving to that empty row
        '        bsJournalItems.RemoveAt(bsJournalItems.Count - 1)
        '    End If
        '    Presenter.MakePayTypeAndSpecialAccount(JournalItems(nIndex), accountId)
        '    UpdateInputVatAmount()
        '    bsJournalItems.ResetItem(nIndex)
        '    DataGridViewJournalItems.Refresh()
        'Case $"dgvdebit"
        '    Presenter.MakeDebitAmount(JournalItems(nIndex), .CurrentCell.Value)
        '    UpdateJiTotals()
        '    UpdateInputVatAmount()
        '    bsJournalItems.ResetItem(nIndex)
        '    SendKeys.Send("{TAB}")
        'Case $"dgvcredit"
        '    Presenter.MakeCreditAmount(JournalItems(nIndex), .CurrentCell.Value)
        '    UpdateJiTotals()
        '    UpdateInputVatAmount()
        '    bsJournalItems.ResetItem(nIndex)
        'Case $"dgvnotes"
        '    SendKeys.Send("{DOWN}")
        'End Select
        'End If
        'End If


    End Class

End Namespace