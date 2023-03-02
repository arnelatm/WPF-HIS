Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
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

    Public Class DisbursementJournalPresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IDisbursementJournalView, TM)
        Implements ISubscriber(Of DataChanged)

        Private ReadOnly _advancesToSupplierAccountIdNo As Int16
        Protected DtInsertTable As New DataTable
        Protected DtOiInsertTable As New DataTable
        Protected DtOiUpdateTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Private _oiItemService
        Private _journalItemService

        Public Sub New(view As IDisbursementJournalView, ByVal tableOrViewName As String)
            MyBase.New(view)
            WithTreeView = False
            Dim args As Object
            Dim djArgs As Object
            Dim oiArgs As Object
            SortOrderKey = "IdNo"
            If tableOrViewName = "CdJournal" Then
                djArgs = {"CdJournalItem_View", "UpdateCdJournalItemTVP", "InsertCdJournalItemTVP"}
                oiArgs = {"CdOiItem_View", "UpdateCdOiItemTVP", "InsertCdOiItemTVP"}
                args = {"CdJournal", "CD", djArgs, oiArgs}
                JournalCode = "CD"
            Else
                djArgs = {"PcJournalItem_View", "UpdatePcJournalItemTVP", "InsertPcJournalItemTVP"}
                oiArgs = {"PcOiItem_View", "UpdatePcOiItemTVP", "InsertPcOiItemTVP"}
                args = {"PcJournal", "PC", djArgs, oiArgs}
                JournalCode = "PC"
            End If
            _journalItemService = New AccountsService("JournalItem", Nothing, djArgs)
            _oiItemService = New AccountsService("DjOiItem", Nothing, oiArgs)
            Service = New AccountsService("DisbursementJournal", JournalCode, args)
            TableName = tableOrViewName

            _advancesToSupplierAccountIdNo = GetAdvancesToSupplierAccountIdNo()

            CreateDataTable(DtInsertTable, {{"AccountIdNo", GetType(Int16)},
                                            {"Credit", GetType(Decimal)},
                                            {"Debit", GetType(Decimal)},
                                            {"JournalIdNo", GetType(Int32)},
                                            {"Notes", GetType(String)},
                                            {"PayIdNo", GetType(Int32)},
                                            {"RevCostCenterIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}
                                            })

            CreateDataTable(DtUpdateTable, {{"AccountIdNo", GetType(Int16)},
                                            {"Credit", GetType(Decimal)},
                                            {"Debit", GetType(Decimal)},
                                            {"IdNo", GetType(Int32)},
                                            {"JournalIdNo", GetType(Int32)},
                                            {"Notes", GetType(String)},
                                            {"PayIdNo", GetType(Int32)},
                                            {"RevCostCenterIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}
                                            })

            CreateDataTable(DtOiInsertTable, {{"Amount", GetType(Decimal)},
                                             {"ApOpenInvoiceIdNo", GetType(Int32)},
                                             {"DiscountTaken", GetType(Decimal)},
                                             {"DjIdNo", GetType(Int32)},
                                             {"Sequence", GetType(Int16)}
                                             })

            CreateDataTable(DtOiUpdateTable, {{"Amount", GetType(Decimal)},
                                             {"ApOpenInvoiceIdNo", GetType(Int32)},
                                             {"DiscountTaken", GetType(Decimal)},
                                             {"DjIdNo", GetType(Int32)},
                                             {"IdNo", GetType(Int32)},
                                             {"Sequence", GetType(Int16)}
                                             })

            AddHandler view.PrintCheck, AddressOf OnPrintCheck
            AddHandler view.AutoApplyAmount, AddressOf OnAutoApplyAmount
            AddHandler view.AddSupplierOpenInvoices, AddressOf OnAddSupplierOpenInvoices
            AddHandler view.UserDeletedRow, AddressOf OnUserDeletedRow
            AddHandler view.PrintPcReplenishment, AddressOf OnPrintPcReplenishment
            AddHandler view.FirstLineUpdateNeeded, AddressOf OnFirstLineUpdateNeeded
            AddHandler view.SetSupplierVatNumber, AddressOf SetSupplierVatNumber
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateLookupData("Account", "AccountsByCode")
            CreateLookupData("RevCostCenter", "RevCostCentersByCode")
            CreateLookupData("Employee", "EmployeesByName")
            CreateLookupData("Customer", "CustomersByName")
            CreateLookupData("Supplier", "SuppliersByName")
            CreateEnumDataSource(Of PaymentTypeSelection)("PaymentType")
            CreateEnumDataSource(Of PayTypeSelection)("PayType")
            If TableName = "CdJournal" Then
                If View.BankTransfer Then
                    CreateSpecialAccountDataSource("AccountIdNo", {EnumToCode(SpecialAccountSelection.Bank), EnumToCode(SpecialAccountSelection.CheckingAccount)})
                Else
                    CreateSpecialAccountDataSource("AccountIdNo", {EnumToCode(SpecialAccountSelection.Bank), EnumToCode(SpecialAccountSelection.Cash), EnumToCode(SpecialAccountSelection.CheckingAccount)})
                End If
            ElseIf TableName = "PcJournal" Then
                CreateSpecialAccountDataSource("AccountIdNo", {EnumToCode(SpecialAccountSelection.PettyCashAccount)})
            Else
                CreateSpecialAccountDataSource("AccountIdNo", {EnumToCode(SpecialAccountSelection.CheckingAccount)})
            End If
            CreateSpecialAccountDataSource("DiscountAccountIdNo", {EnumToCode(SpecialAccountSelection.PurchaseDiscount)})
        End Sub

        Private Function GetAdvancesToSupplierAccountIdNo()
            Return GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.AdvancesToSupplier), "Account", "SpecialAccount", "IdNo")
        End Function

        Public Property JournalCode As String

        Public ReadOnly Property CdAccountCount As Int16
            Get
                Dim specialAccount As String
                If JournalCode = "PC" Then
                    specialAccount = EnumToCode(SpecialAccountSelection.PettyCashAccount)
                ElseIf JournalCode = "CK" Then
                    specialAccount = EnumToCode(SpecialAccountSelection.CheckingAccount)
                Else
                    Dim accounts = EnumToCode(SpecialAccountSelection.Bank) + "," + EnumToCode(SpecialAccountSelection.Cash) + "," + EnumToCode(SpecialAccountSelection.CheckingAccount)
                    Dim cdAccounts = GetAccountTypesList(accounts)
                    Return cdAccounts.Count()
                End If
                Return Service.CountRecordWithKey(Of String)("Account", "SpecialAccount", specialAccount)
            End Get
        End Property

        Public ReadOnly Property DefaultDisbursementAccount As Int16
            Get
                Dim retVal As String = Nothing
                If View.AccountIdNo Is Nothing Or View.AccountIdNo <= 0 Then
                    If CdAccountCount >= 1 Then
                        If JournalCode = "PC" Then
                            retVal = GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.PettyCashAccount), "Account", "SpecialAccount", "IdNo")
                        ElseIf JournalCode = "CK" Then
                            retVal = GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.CheckingAccount), "Account", "SpecialAccount", "IdNo")
                        Else
                            retVal = GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.Bank), "Account", "SpecialAccount", "IdNo")
                            If retVal Is Nothing Then
                                GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.Cash), "Account", "SpecialAccount", "IdNo")
                            End If
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
                If CodeToEnum(Of PaymentTypeSelection)(View.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                    ViewToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf JournalItemFillData, AddressOf JournalItemFilter)
                    View.UnApplied = 0
                    View.Applied = View.Amount
                    If DtOiInsertTable IsNot Nothing Then
                        DtOiInsertTable.Clear()
                    End If
                    If DtOiUpdateTable IsNot Nothing Then
                        DtOiUpdateTable.Clear()
                    End If
                Else
                    'View.TotalDebits = 0
                    MakeJournalItem()
                    ViewToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf JournalItemFillData, AddressOf JournalItemFilter)
                    ViewToDataTables(View.DjOiItems, DtOiInsertTable, DtOiUpdateTable, AddressOf DjOiFillData, AddressOf DjOiItemFilter)
                    'View.TotalCredits = View.TotalDebits
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

        'Private Sub OnBeforeEdit() Handles MyBase.BeforeEdit
        '    Dim type As Type = View.GetType
        '    Dim cPcClosed = CallByName(View, "PcClosed", CallType.Get)
        '    If cPcClosed Then
        '        Messaging.Show(True, "MsgEditingOfClosedPcRecordNotAllowed")
        '        CancelEdit = True
        '    Else
        '        Dim reconciledDao = New ReconciledDao
        '        For Each item In View.JournalItems
        '            'Dim reconciledData As Reconciled = reconciledDao.GetReconciledItem(JournalCode, item.IdNo)
        '            if reconciledDao.IsItemReconciled(JournalCode, item.IdNo) THEN
        '                cancelEdit = True
        '                exit For
        '            End If
        '        Next
        '        If cancelEdit Then
        '            Messaging.Show(True, "MsgEditingOfReconciledItemsNotAllowed")
        '            CancelEdit = True
        '        End If
        '    End If
        'End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            'If CodeToEnum(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
            '    View.TotalDebits = 0
            '    View.TotalCredits = 0
            '    For Each ji In View.DjOiItems
            '        View.TotalDebits += ji.Amount + ji.DiscountTaken
            '    Next
            '    View.TotalCredits = View.TotalDebits
            'End If
            View.UnApplied = View.Amount - View.Applied
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_journalItemService, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_oiItemService, DtOiUpdateTable, DtOiInsertTable, passedValue, "DjIdNo")
                If retVal >= 0 Then
                    retVal = SaveOpenInvoices()
                End If
            End If
            If retVal >= 0 And IsEmpty(View.ReferenceNo) Then
                retVal = UpdateGlReferenceNumber()
            End If
            If retVal >= 0 AndAlso (View.PaymentType = EnumToCode(PaymentTypeSelection.AccountsPayable) Or View.PaymentType = EnumToCode(PaymentTypeSelection.Supplier)) _
                           AndAlso Not IsEmpty(View.VatNumber) Then
                Service.UpdateVatNumber(View.VatNumber, View.PayeeIdNo)
            End If
        End Sub

        Private Sub OnFirstLineUpdateNeeded()
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
                    item.Credit = View.Amount
                    item.Debit = 0
                    item.RevCostCenterIdNo = 0
                    MakePayTypeAndSpecialAccount(item, View.AccountIdNo)
                    Exit For
                Next
            End If
        End Sub

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
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Service.GetRecordFieldWithKeyG(Of DateTime?)("Petty Cash Disbursement", "LastPosting", "TransactionName", "LastPostingDate")
                Dim dateFieldName = Messaging.TranslateCaption("Transaction Date")
                If IsDateRangeValid(dateFieldName, View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                ElseIf CodeToEnum(Of PaymentTypeSelection)(View.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                    If View.JournalItems Is Nothing OrElse View.JournalItems.Count() = 0 Then
                        Messaging.Show(True, "MsgCannotSaveAnEmptyTransaction", "Sorry, cannot save an empty transaction!", "Error")
                        retValue = False
                    End If
                    If retValue Then
                        retValue = JournalItemDataIsValid()
                    End If
                ElseIf CodeToEnum(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    If OiItemDataIsValid() Then
                        retValue = True
                    Else
                        retValue = False
                        Dim index As Int16 = 0
                        For Each item In View.DjOiItems
                            If item.Errors IsNot Nothing Then
                                View.DjOiItems(index).Errors = item.Errors
                            Else
                                If View.DjOiItems(index).Errors IsNot Nothing Then
                                    View.DjOiItems(index).Errors.Clear()
                                End If
                            End If
                            index += 1
                        Next
                    End If
                End If
                If retValue >= 0 Then
                    For Each item In View.JournalItems
                        If item.AccountIdNo Is Nothing Or item.AccountIdNo = 0 AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Messaging.ShowPmMessage(True, "MsgBlankAccountIdNotAllowed", {"lineNumber", lineNumber})
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
            Dim transactionAmountInWords As String
            Dim totalLineAmountInWords As String
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            language = Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            If language = "ar" Then
                transactionAmountInWords = New ToWord(View.Amount, currencies(0)).ConvertToArabic()
            Else
                transactionAmountInWords = New ToWord(View.Amount, currencies(0)).ConvertToEnglish()
            End If
            'View.TotalCredits = 0
            'For Each item In View.JournalItems
            '    View.TotalCredits = View.TotalCredits + item.Credit
            'Next
            If language = "ar" Then
                totalLineAmountInWords = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalLineAmountInWords = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            Dim reportName As String
            If TableName = "PcJournal" Then
                reportName = "Petty Cash Disbursement Journal.Rpt"
            Else
                If View.PayType = EnumToCode(PayTypeSelection.BankTransfer) Then
                    reportName = "Bank Transfer Journal.Rpt"
                ElseIf View.PayType = EnumToCode(PayTypeSelection.CheckPayment) Then
                    reportName = "Check Disbursement Journal.Rpt"
                Else
                    reportName = "Cash Disbursement Journal.Rpt"
                End If
            End If
            Dim cForm As New ReportForm(reportName, View.IdNo, "JournalIdNo", transactionAmountInWords, "transactionAmountInWords", totalLineAmountInWords, "TotalLineAmountInWords", language, "Language")
            cForm.Show()
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.DjOiItems IsNot Nothing And View.DjOiItems.Count() > 0 Then
                DtOiUpdateTable.Clear()
                _oiItemService.DelUpdateTvp(DtOiUpdateTable, idNo)
            End If
            ' ReSharper disable once VBUseMethodAny.1
            If View.JournalItems IsNot Nothing And View.JournalItems.Count() > 0 Then
                DtUpdateTable.Clear()
                _journalItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

        Private Sub OnAutoApplyAmount(bsDjOiItems As BindingSource)
            Dim amountToApply = View.Amount
            'apply the negative values first
            For Each item In bsDjOiItems
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
            For Each item In bsDjOiItems
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

        Private Sub MakeJournalItem()
            If CodeToEnum(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                Dim aAccountIdNo As Int16() = {}
                Dim aAmount() As Decimal = {}
                Dim aAdded() As Boolean = {}
                Dim aDiscountTaken() As Decimal = {}
                Dim nSize As Integer = 0
                Dim nIndex As Integer
                ' summarize paid invoices per account
                For Each item In View.DjOiItems
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
                Dim nCounter As Integer = 0
                ' apply the payment to the disbursement account (the first entry) and zero out the rest of the existing
                ' journal item entries if there are existing journal entries.
                For Each item In View.JournalItems
                    If nCounter = 0 Then
                        item.JournalIdNo = View.IdNo
                        item.Sequence = 1
                        item.AccountIdNo = View.AccountIdNo
                        item.Credit = If(View.Amount < 0, 0, View.Amount)
                        item.Debit = If(View.Amount < 0, View.Amount * -1, 0)
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
                ' if no existing journal entries, create one for the checking account payment.
                If View.JournalItems Is Nothing Or View.JournalItems.Count = 0 Then
                    Dim item As New JournalItemView With {
                            .JournalIdNo = View.IdNo,
                            .Sequence = 1,
                            .AccountIdNo = View.AccountIdNo,
                            .Credit = If(View.Amount < 0, 0, View.Amount),
                            .Debit = If(View.Amount < 0, View.Amount * -1, 0),
                            .RevCostCenterIdNo = 0,
                            .Notes = ""
                            }
                    View.JournalItems.Add(item)
                End If
                ' apply now the invoice payment summarized above for each existing AP account
                For i = 0 To aAccountIdNo.Count() - 1
                    For Each ji In View.JournalItems
                        ' if account matches then add the payment and discount
                        If ji.AccountIdNo = aAccountIdNo(i) Then
                            Dim nAmount = aAmount(i) + aDiscountTaken(i)
                            ji.Debit = If(nAmount < 0, 0, nAmount)
                            ji.Credit = If(nAmount < 0, nAmount * -1, 0)
                            aAdded(i) = True
                            Exit For
                        End If
                    Next
                Next
                ' find if the discount taken account exist in the old entries, if found save the discountTaken account
                Dim found As Boolean = False
                For Each ji In View.JournalItems
                    ' ignore the first line entry (this is for the disbursement account)
                    If ji.Sequence <> 1 Then
                        If ji.AccountIdNo = View.DiscountAccountIdNo Then
                            ji.Debit = If(View.DiscountTaken < 0, View.DiscountTaken * -1, 0)
                            ji.Credit = If(View.DiscountTaken < 0, 0, View.DiscountTaken)
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
                                .Credit = If(View.DiscountTaken < 0, 0, View.DiscountTaken),
                                .Debit = If(View.DiscountTaken < 0, View.DiscountTaken * -1, 0),
                                .RevCostCenterIdNo = 0,
                                .Notes = ""
                                }
                        View.JournalItems.Add(item)
                    End If
                End If
                ' find and add AP entries not yet added
                nCounter = 0
                For Each item In aAdded
                    If Not item Then
                        ' if the account is not yet added create a AP journal entry for
                        ' the account
                        Dim nAmount As Decimal
                        nAmount = aAmount(nCounter) + aDiscountTaken(nCounter)
                        Dim ji As New JournalItemView With {
                                .JournalIdNo = View.IdNo,
                                .Sequence = 0,
                                .AccountIdNo = aAccountIdNo(nCounter),
                                .Credit = If(nAmount < 0, nAmount * -1, 0),
                                .Debit = If(nAmount < 0, 0, nAmount),
                                .RevCostCenterIdNo = 0,
                                .Notes = ""
                                }
                        View.JournalItems.Add(ji)
                    End If
                    nCounter += 1
                Next
                If View.UnApplied > 0 Then
                    ' if invoice not yet fully applied, then save the
                    ' unApplied amount to the "Advances to Supplier" account
                    ' check existing entries for the "Advances to Supplier" account
                    Dim unAppliedSwitch As Int16 = 0
                    For Each item In View.JournalItems
                        ' get the last matching idNo for accounts with advancesToSupplierAccountIdNo
                        If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.Debit = 0 And item.Credit = 0 And item.OriginalAmount > 0 Then
                            ' debit and credit must be zero otherwise that account has already been used above
                            item.Credit = 0
                            item.Debit = View.UnApplied
                            unAppliedSwitch = 1
                            Exit For
                        End If
                    Next
                    If unAppliedSwitch = 0 Then
                        ' advance payment journal entry not yet created
                        Dim jiModel As New JournalItemView With {
                            .JournalIdNo = View.IdNo,
                            .Sequence = 0,
                            .AccountIdNo = _advancesToSupplierAccountIdNo,
                            .Credit = 0,
                            .Debit = View.UnApplied,
                            .RevCostCenterIdNo = 0,
                            .Notes = ""
                            }
                        View.JournalItems.Add(jiModel)
                    End If
                Else
                    ' no advance payment so no advances to Supplier Account
                End If
            Else
                View.DjOiItems.Clear()
            End If
        End Sub

        Private Function SaveOpenInvoices()
            Dim retVal As Integer = 0
            If CodeToEnum(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                ' save the generated open invoices
                retVal = UpdateOpenInvoices()
            End If
            Return retVal
        End Function

        Private Function UpdateOpenInvoices() As Integer
            Dim retVal As Integer = 0
            If AddMode Then
                If View.UnApplied > 0 Then
                    ' with advance payment
                    Dim items As List(Of JournalItemModel)
                    items = GetJournalItems(View.IdNo)
                    Dim ji As New JournalItemModel
                    For Each item In items
                        If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.OriginalAmount > 0 Then
                            ji.IdNo = item.IdNo
                            ji.AccountIdNo = item.AccountIdNo
                            ji.JournalIdNo = View.IdNo
                            retVal = AddApOpenInvoice(ji, "CD")
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
                    ' get the item.IdNo of the last matching advancesToSupplierAccountIdNo if more than one found
                    For Each item In jiItems
                        If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.OriginalAmount > 0 Then
                            ' if more items found overwrite the old value found and use this one
                            ji.IdNo = item.IdNo
                            ji.AccountIdNo = item.AccountIdNo
                            ji.JournalIdNo = View.IdNo
                            Exit For
                        End If
                    Next
                    Dim lOpenInvIdNo As Int32
                    ' check if the AdvancePayment OpenInvoice already created
                    lOpenInvIdNo = CInt(GetAdvancePaymentOpenInvoice(JournalCode, ji.IdNo))
                    If lOpenInvIdNo = 0 Then
                        ' no previous entry
                        ' add the open invoice
                        retVal = AddApOpenInvoice(ji, JournalCode)
                    Else
                        ' already added, nothing to do
                    End If
                Else
                    ' get the OpenInvoice IdNo
                    ' check if the AdvancePayment OpenInvoice already created
                    Dim lOpenInvoiceIdNo As Int32
                    lOpenInvoiceIdNo = CInt(GetAdvancePaymentOpenIdNo(JournalCode, View.IdNo))
                    If lOpenInvoiceIdNo > 0 Then
                        retVal = DeleteAdvancePaymentOpenInvoice(lOpenInvoiceIdNo)
                    End If
                End If
            End If
            Return retVal
        End Function

        Public Function GetAdvancePaymentOpenInvoice(ByVal journalCode As String, ByVal idNo As Int32)
            Return Service.GetRecordFieldWith2Key(idNo, journalCode, "ApOpenInvoice", "JournalItemIdNo", "JournalCode", "IdNo")
        End Function

        Private Function DeleteAdvancePaymentOpenInvoice(ByRef idNo As Int32) As String
            Dim arOpenInvoiceService As New AccountsService("ApOpenInvoice")
            If Service.CountRecordWithKey(Of Integer)("ApOpenInvoice", "IdNo", idNo) > 0 Then
                Return arOpenInvoiceService.DeleteRecord(idNo, "ApOpenInvoice")
            End If
            Return 0
        End Function

        Private Function JournalItemDataIsValid() As Boolean
            Dim retValue As Boolean = True
            For Each item In View.JournalItems
                If CodeToEnum(Of PaymentTypeSelection)(View.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                    If (item.AccountIdNo Is Nothing OrElse item.AccountIdNo = 0) AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                        MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                        retValue = False
                        Exit For
                    End If
                    If CodeToEnum(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.Employee Then
                        If CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) = SpecialAccountSelection.AccountsPayable Or
                           CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) = SpecialAccountSelection.AccountsReceivable Then
                            Dim lineNumber = Format(item.Sequence, "0")
                            Dim entryNames = Messaging.TranslateCaption("Accounts Receivables/Accounts Payables")
                            Dim caption = "Invalid Entry"
                            Dim variables As String() = {"lineNumber", lineNumber, "entryNames", entryNames}
                            Dim message = Messaging.GetMessage(True, "MsgAccountsNotAllowed", "Error on line {lineNumber}. Sorry {entryNames} accounts not allowed for this transaction!", caption)
                            caption = Messaging.TranslateCaption(caption)
                            Messaging.Show(message, caption, variables, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            retValue = False
                            Exit For
                        End If
                    ElseIf CodeToEnum(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.CustomerRefund Then
                        If CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) = SpecialAccountSelection.AccountsPayable Or
                           CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) = SpecialAccountSelection.EmployeeLoan Then
                            Dim lineNumber = Format(item.Sequence, "0")
                            Dim entryNames = Messaging.TranslateCaption("Accounts Payables/Employee")
                            Dim caption = "Invalid Entry"
                            Dim variables As String() = {"lineNumber", lineNumber, "entryNames", entryNames}
                            Dim message = Messaging.GetMessage(True, "MsgAccountsNotAllowed")
                            caption = Messaging.TranslateCaption(caption)
                            Messaging.Show(message, caption, variables, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            retValue = False
                            Exit For
                        End If
                    Else
                        If CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) = SpecialAccountSelection.AccountsPayable Or
                           CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) = SpecialAccountSelection.AccountsReceivable Or
                           CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) = SpecialAccountSelection.EmployeeLoan Then
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

        Public Function OiItemDataIsValid() As Boolean
            Dim retVal = True
            Dim index As Int16 = 0
            For Each item In View.DjOiItems
                If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                    If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
                       (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
                        Dim lineNumber = item.Sequence.ToString()
                        Dim variables = {"lineNumber", lineNumber}
                        Dim message = Messaging.GetMessage(True, "MsgAppliedAmtExceedsBalance", "Error in line {lineNumber}. Applied amount and discount exceeds balance.", "Invalid Payment")
                        Dim caption = Messaging.TranslateCaption("Invalid Payment")
                        message = Messaging.ReplaceValues(message, variables)
                        Messaging.Show(message, caption)
                        If View.DjOiItems(index).Errors Is Nothing Then
                            View.DjOiItems(index).Errors = New List(Of String)
                        End If
                        View.DjOiItems(index).Errors.Add(message)
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
                        retVal = False
                        Exit For
                    Else
                        ' clear error message
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = ""
                        If View.DjOiItems(index).Errors IsNot Nothing Then
                            View.DjOiItems(index).Errors.Clear()
                        End If
                    End If
                End If
                index += 1
            Next
            If retVal Then
                If View.UnApplied <> 0 Then
                    Dim totalBalance As Decimal = 0D
                    For Each item In View.DjOiItems
                        totalBalance += item.Balance
                    Next
                    If totalBalance > 0 Then
                        If View.UnApplied > 0 Then
                            Messaging.Show(True, "MsgPaymentNotFullyApplied")
                            retVal = False
                        Else
                            Messaging.Show(True, "MsgPaymentIsOverApplied")
                            retVal = False
                        End If
                    Else
                        If Messaging.Show(True, "AskMakeExcessPaymentAdvance",
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

        Public Function GetAdvancePaymentOpenIdNo(ByVal pJournalCode As String, ByVal idNo As Int32) As Integer
            Dim retVal As String
            retVal = Service.GetRecordFieldWith2Key(idNo, pJournalCode, "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetDjOiItems(djOiIdNo As Int32) As List(Of DjOiItemModel)
            Return _oiItemService.GetRecordsWithGroupIdNo(Of DjOiItemModel)(djOiIdNo, "Sequence")
        End Function

        Public Function GetJournalItems(journalIdNo As Int32) As List(Of JournalItemModel)
            Return _journalItemService.GetRecordsWithGroupIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetSupplierOpenInvoices(dView As List(Of DjOiItemView)) As List(Of DjOiItemView)
            Dim dModel As New List(Of DjOiItemModel)
            Dim dOriginalModel As New List(Of DjOiItemModel)
            Dim nSeq As Integer
            GlobalVariables.Mapper.Map(dView, dModel)
            nSeq = dView.Count()
            If EditMode Then
                If View.PayeeIdNo = OriginalModel.PayeeIdNo AndAlso View.PaymentType = OriginalModel.PaymentType Then
                    ' need to add the original items because if items are already paid in the original data they will not be added if there is already a full or partial payment
                    AddOpenInvoices(True, OriginalModel.DjOiItems, dModel, nSeq)
                    nSeq = dModel.Count()
                End If
            End If
            Dim unpaidInvoices = Service.GetOpenInvoices(Of DjOiItemModel)(View.PayeeIdNo)
            AddOpenInvoices(False, unpaidInvoices, dModel, nSeq)
            GlobalVariables.Mapper.Map(dModel, dView)
            Return dView
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Int32?) As List(Of DjOiItemModel)
            If supplierIdNo Is Nothing Then
                Return New List(Of DjOiItemModel)
            Else
                Return Service.GetOpenInvoices(Of DjOiItemModel)(supplierIdNo)
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
                    .Credit = View.Amount,
                    .Debit = 0,
                    .RevCostCenterIdNo = 0,
                    .Notes = ""
                    }
            View.JournalItems.Add(item)
            If View.DjOiItems IsNot Nothing Then
                View.DjOiItems.Clear()
            Else
                View.DjOiItems = New List(Of DjOiItemView)
            End If
            If View.AccountIdNo Is Nothing Or View.AccountIdNo <= 0 Then
                View.AccountIdNo = DefaultDisbursementAccount
            End If

        End Sub

        Private Sub JournalItemFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("AccountIdNo") = itemDataView.AccountIdNo
            workRow("Credit") = itemDataView.Credit
            workRow("Debit") = itemDataView.Debit
            workRow("JournalIdNo") = View.IdNo
            workRow("Notes") = itemDataView.Notes
            workRow("PayIdNo") = itemDataView.PayIdNo
            workRow("RevCostCenteridNo") = itemDataView.RevCostCenterIdNo
        End Sub

        Public Function JournalItemFilter(ByVal obj As Object) As Boolean
            If (obj.Debit = 0 AndAlso obj.Credit = 0 AndAlso obj.Sequence <> 1) Then
                Return False
            End If
            Return True
        End Function

        Private Sub DjOiFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("Amount") = itemDataView.Amount
            workRow("ApOpenInvoiceIdNo") = itemDataView.ApOpenInvoiceIdNo
            workRow("DjIdNo") = View.IdNo
            workRow("DiscountTaken") = itemDataView.DiscountTaken
            'View.TotalDebits += itemDataView.Amount + itemDataView.DiscountTaken
        End Sub

        Public Function DjOiItemFilter(ByVal obj As Object) As Boolean
            If (obj.Amount = 0 AndAlso obj.DiscountTaken = 0) Then
                Return False
            End If
            Return True
        End Function

        Private Sub OnAddSupplierOpenInvoices()
            If View.PayeeIdNo <> 0 Then
                Dim unpaidInvoices = GetSupplierOpenInvoices(View.PayeeIdNo)
                Dim nSeq As Integer
                If AddMode Then
                    View.DjOiItems.Clear()
                End If
                If View.DjOiItems IsNot Nothing Then
                    nSeq = View.DjOiItems.Count()
                Else
                    nSeq = 0
                End If
                For Each unpaidInvoice In unpaidInvoices
                    Dim itemFound = False
                    If View.DjOiItems IsNot Nothing Then
                        For Each item In View.DjOiItems
                            If item.ApOpenInvoiceIdNo = unpaidInvoice.IdNo Then
                                itemFound = True
                                Exit For
                            End If
                        Next
                    End If
                    If Not itemFound Then

                        If unpaidInvoice.JournalCode = JournalCode And unpaidInvoice.JournalIdNo = View.IdNo Then
                            ' ignore advance payments if applied to this entry.
                        Else
                            nSeq += 1
                            Dim item As New DjOiItemView With {
                                    .AccountIdNo = unpaidInvoice.AccountIdNo,
                                    .Amount = unpaidInvoice.Amount,
                                    .ApOpenInvoiceIdNo = unpaidInvoice.ApOpenInvoiceIdNo,
                                    .Balance = unpaidInvoice.Balance,
                                    .DiscountTaken = unpaidInvoice.DiscountTaken,
                                    .InvoiceNo = unpaidInvoice.InvoiceNo,
                                    .JournalCode = unpaidInvoice.JournalCode,
                                    .JournalIdNo = unpaidInvoice.JournalIdNo,
                                    .PreviousBalance = unpaidInvoice.Balance,
                                    .Sequence = nSeq,
                                    .TransactionDate = unpaidInvoice.TransactionDate
                                    }
                            If View.DjOiItems Is Nothing Then
                                View.DjOiItems = New List(Of DjOiItemView)
                            End If
                            View.DjOiItems.Add(item)
                        End If
                    End If
                Next
            End If
        End Sub

        Private Function AddOpenInvoices(original As Boolean, source As List(Of DjOiItemModel), target As List(Of DjOiItemModel), nSeq As Integer) As Integer
            For Each invoice In source
                Dim itemFound = False
                For Each item In target
                    If item.ApOpenInvoiceIdNo = invoice.ApOpenInvoiceIdNo Then
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

        Private Function GetOpenInvoice(original As Boolean, nSeq As Integer, invoice As Object) As DjOiItemModel
            Dim item As DjOiItemModel
            item = New DjOiItemModel With {
                .AccountIdNo = invoice.AccountIdNo,
                .Amount = invoice.Amount,
                .ApOpenInvoiceIdNo = invoice.ApOpenInvoiceIdNo,
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

        Private Sub OnPrintCheck()
            Dim checkAmountInWords As String
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            Dim language As String
            language = Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            If language = "ar" Then
                checkAmountInWords = New ToWord(View.Amount, currencies(0)).ConvertToArabic()
            Else
                checkAmountInWords = New ToWord(View.Amount, currencies(0)).ConvertToEnglish()
            End If
            Dim reportFileName As String
            reportFileName = "Check Printing" & View.AccountIdNo.ToString() & ".Rpt"
            Dim cForm As New ReportForm(reportFileName, checkAmountInWords, "CheckAmountInWords", GetPayeeName(View.PayeeIdNo), "PayeeName", View.CheckDate, "CheckDate", Convert.ToDecimal(View.Amount), "CheckAmount", language, "Language", View.Notes, "Notes")
            cForm.Show()
        End Sub

        Private Sub OnPrintPcReplenishment()
            Dim transactionAmountInWords As String
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            language = Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            If language = "ar" Then
                transactionAmountInWords = New ToWord(View.Amount, currencies(0)).ConvertToArabic()
            Else
                transactionAmountInWords = New ToWord(View.Amount, currencies(0)).ConvertToEnglish()
            End If
            Dim cForm As New ReportForm("Petty Cash Replenishment Report.Rpt", transactionAmountInWords, "TransactionAmountInWords", View.IdNo, "JournalIdNo", language, "Language")
            cForm.Show()
        End Sub

        Private Function GetPayeeName(ByVal payeeIdNo? As Int32)
            Dim payee As String
            Dim curCulture = CultureInfo.CurrentCulture
            Dim language As String
            language = Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(View.PaymentType)
            If paymentTypeEnum = PaymentTypeSelection.AccountsPayable OrElse paymentTypeEnum = PaymentTypeSelection.Supplier Then
                If language = "ar" Then
                    payee = GetFieldWithIdNo(payeeIdNo, "Supplier", "SupplierNameAra")
                Else
                    payee = GetFieldWithIdNo(payeeIdNo, "Supplier", "SupplierName")
                End If
            ElseIf paymentTypeEnum = PaymentTypeSelection.Employee Then
                If language = "ar" Then
                    payee = GetFieldWithIdNo(payeeIdNo, "Employee", "EmployeeNameAra")
                Else
                    payee = GetFieldWithIdNo(payeeIdNo, "Employee", "EmployeeName")
                End If
            ElseIf paymentTypeEnum = PaymentTypeSelection.CustomerRefund Then
                If language = "ar" Then
                    payee = GetFieldWithIdNo(payeeIdNo, "Customer", "CustomerNameAra")
                Else
                    payee = GetFieldWithIdNo(payeeIdNo, "Customer", "CustomerName")
                End If
            Else
                payee = View.PayeeName
            End If
            Return payee
        End Function

        Private Sub OnBeforeMappingData(ByVal dataModel As Object) Handles MyBase.BeforeMappingData
            ' need to do this because the Mapping source part of this program maps the PayeeIdNo first before
            ' the DepositType so in order to override this part we need to retrieve the DepositType first
            ' because when assigning the cboPayeeIdNo the dataSource must be correct that is why
            ' we need to set the DataSource part of the cboPayeeIdNo before we can assign the PayeeIdNo
            View.PaymentType = dataModel.PaymentType
            CallByName(View, "setPayeeDataSource", CallType.Method, View.PaymentType)
        End Sub

        Private Sub OnDisbursementJournalChangedEventHandler(ByRef eventType As DataChanged) Implements ISubscriber(Of DataChanged).OnEventHandler
            With eventType.BindingSource
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    'Dim nIndex = eventType.BindingSource.Current.Index
                    Select Case eventType.PropertyName
                        Case $"AccountIdNo"
                            Dim accountId = eventType.BindingSource.Current.AccountIdNo
                            MakePayTypeAndSpecialAccount(eventType.BindingSource.Current, accountId)
                            UpdateVatAmount(eventType.BindingSource.DataSource)
                        Case $"Debit"
                            MakeDebitAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Debit)
                            CallByName(View, "UpdateJiTotals", CallType.Method)
                            UpdateVatAmount(eventType.BindingSource.DataSource)
                            SendKeys.Send("{TAB}")
                        Case $"Credit"
                            MakeCreditAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Credit)
                            CallByName(View, "UpdateJiTotals", CallType.Method)
                            UpdateVatAmount(eventType.BindingSource.DataSource)
                        Case $"Notes"
                            SendKeys.Send("{DOWN}")
                        Case $"Amount"
                            eventType.BindingSource.Current.Balance = eventType.BindingSource.Current.PreviousBalance - eventType.BindingSource.Current.Amount - eventType.BindingSource.Current.DiscountTaken
                            CallByName(View, "UpdateOiTotals", CallType.Method)
                        Case $"DiscountTaken"
                            eventType.BindingSource.Current.Balance = eventType.BindingSource.Current.PreviousBalance - eventType.BindingSource.Current.Amount - eventType.BindingSource.Current.DiscountTaken
                            CallByName(View, "UpdateOiTotals", CallType.Method)
                        Case $"Balance"
                            SendKeys.Send("{DOWN}")
                    End Select
                End If
            End With
        End Sub

        Private Sub OnUserDeletedRow()
            Dim payeeTypeEnum = CodeToEnum(Of PaymentTypeSelection)(View.PaymentType)
            UpdateVatAmount(View.JournalItems)
        End Sub

        Private Sub UpdateVatAmount(data As List(Of JournalItemView))
            View.VatAmount = UpdateInputVatAmount(data)
        End Sub

        Public Overrides Function IsOkToEditRecord() As Boolean
            If Not MyBase.IsOkToEditRecord() Then
                Return False
            End If
            Dim result As Boolean = True
            Dim type As Type = View.GetType
            Dim cPcClosed = CallByName(View, "PcClosed", CallType.Get)
            If cPcClosed Then
                Messaging.Show(True, "MsgEditingOfClosedPcRecordNotAllowed")
                result = False
            Else
                If ReconciledEntriesExist(View.JournalItems, JournalCode) Then
                    result = False
                End If
                'Dim reconciledDao = New ReconciledDao
                'For Each item In View.JournalItems
                '    'Dim reconciledData As Reconciled = reconciledDao.GetReconciledItem(JournalCode, item.IdNo)
                '    If reconciledDao.IsItemReconciled(JournalCode, item.IdNo) Then
                '        Messaging.Show(True, "MsgEditingOfReconciledNotAllowed")
                '        result = False
                '        Exit For
                '    End If
                'Next
            End If
            Return result
        End Function

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim type As Type = View.GetType
            Dim retVal As Boolean = True
            If MyBase.IsOkToDeleteRecord() Then
                If type.GetProperty("PcClosed") IsNot Nothing Then
                    Dim cPosted = CallByName(View, "PcClosed", CallType.Get)
                    If cPosted Then
                        Dim description As String = ""
                        description = Messaging.TranslateCaption("Petty Cash Replenishment")
                        Messaging.ShowPmMessage(True, "MsgDeleteEntryNotAllowed", {"description", description})
                        retVal = False
                    End If
                End If
                If retVal Then
                    If ReconciledEntriesExist(View.JournalItems, JournalCode) Then
                        retVal = False
                    End If
                End If
            Else
                retVal = False
            End If
            Return retVal
        End Function

    End Class

End Namespace