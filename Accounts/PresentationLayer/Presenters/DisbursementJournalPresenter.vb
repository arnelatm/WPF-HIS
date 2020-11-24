Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public MustInherit Class DisbursementJournalPresenter(Of T As IView, TM As New)
        Inherits AccountsPresenter(Of T, TM)

        Private ReadOnly _advancesToSupplierAccountIdNo As Int16
        Private ReadOnly _cdAccountCount As Int16 = 0
        Protected CashIdNo As String
        Protected DtInsertTable As New DataTable
        Protected DtOiInsertTable As New DataTable
        Protected DtOiUpdateTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Protected ReportName As String

        Protected OiItemModel
        Protected DjItemModel

        Private ReadOnly _defaultPettyCashAccount As Int16
        Private ReadOnly _myView

        Public Sub New(view As IView)
            MyBase.New(view)
            _myView = view
            SortOrderKey = "IdNo"
            OriginalModel = New DisbursementJournalModel()
            DataModel = New DisbursementJournalModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            _advancesToSupplierAccountIdNo = GetAdvancesToSupplierAccountIdNo()

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

            DtOiInsertTable.Columns.Add("Amount", GetType(Decimal))
            DtOiInsertTable.Columns.Add("ApOpenInvoiceIdNo", GetType(Int32))
            DtOiInsertTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtOiInsertTable.Columns.Add("DjIdNo", GetType(Int32))
            DtOiInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtOiUpdateTable.Columns.Add("Amount", GetType(Decimal))
            DtOiUpdateTable.Columns.Add("ApOpenInvoiceIdNo", GetType(Int32))
            DtOiUpdateTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtOiUpdateTable.Columns.Add("DjIdNo", GetType(Int32))
            DtOiUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtOiUpdateTable.Columns.Add("Sequence", GetType(Int16))

        End Sub

        Public Property JournalCode As String

        Public ReadOnly Property CdAccountCount As Int16
            Get
                Dim specialAccount As String
                If JournalCode = "PC" Then
                    specialAccount = "PC"
                Else
                    specialAccount = ""
                End If
                Return ModelPresenter.CountRecordWithKey(specialAccount, "Account", "SpecialAccount")
            End Get
        End Property

        Public Sub AddSupplierOpenInvoices()
            If _myView.PayeeIdNo <> 0 Then
                Dim unpaidInvoices = GetSupplierOpenInvoices(_myView.PayeeIdNo)
                Dim nSeq As Integer
                If AddMode Then
                    _myView.DjOiItems.Clear()
                End If
                If _myView.DjOiItems IsNot Nothing Then
                    nSeq = _myView.DjOiItems.Count()
                Else
                    nSeq = 0
                End If
                For Each unpaidInvoice In unpaidInvoices
                    Dim itemFound = False
                    If _myView.DjOiItems IsNot Nothing Then
                        For Each item In _myView.DjOiItems
                            If item.ApOpenInvoiceIdNo = unpaidInvoice.IdNo Then
                                itemFound = True
                            End If
                        Next
                    End If
                    If Not itemFound Then

                        If unpaidInvoice.JournalCode = JournalCode And unpaidInvoice.JournalIdNo = _myView.IdNo Then
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
                            If _myView.DjOiItems Is Nothing Then
                                _myView.DjOiItems = New List(Of DjOiItemView)
                            End If
                            _myView.DjOiItems.Add(item)
                        End If
                    End If
                Next
            End If
        End Sub

        Protected Property CashCount As Int16

        Public ReadOnly Property DefaultPettyCashAccount As Int16
            Get
                Return GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.PettyCashAccount), "Account", "SpecialAccount", "IdNo")
            End Get
        End Property

        Public Function OiItemDataIsValid() As Boolean
            Dim retVal = True
            Dim index As Int16 = 0
            For Each item In _myView.DjOiItems
                If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                    If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
                       (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
                        Dim lineNumber = item.Sequence.ToString()
                        Dim variables = {"lineNumber", lineNumber}
                        Dim message = Messaging.GetMessage(True, "MsgAppliedAmtExceedsBalance", "Error in line {lineNumber}. Applied amount and discount exceeds balance.", "Invalid Payment")
                        Dim caption = Messaging.TranslateCaption("Invalid Payment")
                        message = Messaging.ReplaceValues(message, variables)
                        Messaging.Show(message, caption)
                        If _myView.DjOiItems(index).Errors Is Nothing Then
                            _myView.DjOiItems(index).Errors = New List(Of String)
                        End If
                        _myView.DjOiItems(index).Errors.Add(message)
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
                        retVal = False
                        Exit For
                    Else
                        ' clear error message
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = ""
                        If _myView.DjOiItems(index).Errors IsNot Nothing Then
                            _myView.DjOiItems(index).Errors.Clear()
                        End If
                    End If
                End If
                index += 1
            Next
            If retVal Then
                If _myView.UnApplied <> 0 Then
                    Dim totalBalance As Decimal = 0D
                    For Each item In _myView.DjOiItems
                        totalBalance += item.Balance
                    Next
                    If totalBalance > 0 Then
                        If _myView.UnApplied > 0 Then
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
            retVal = Model.GetRecordFieldWith2Key(idNo, pJournalCode, "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetDjOiItems(djOiIdNo As Int32) As List(Of DjOiItemModel)
            Return OiItemModel.GetRecordsWithIdNo(Of DjOiItemModel)(djOiIdNo, "Sequence")
        End Function

        Public Function GetJournalItems(journalIdNo As Int32) As List(Of JournalItemModel)
            Return DjItemModel.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetPaymentType(ByRef idNo As Int32) As String
            Dim retVal As String
            retVal = Model.GetRecordFieldWithKey(idNo, "PcJournal", "IdNo", "PaymentType")
            Return retVal
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Int32) As List(Of DjOiItemModel)
            Return ModelPresenter.GetSupplierOpenInvoices(Of DjOiItemModel)(supplierIdNo)
        End Function

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            _myView.TransactionDate = Date.Now()
            If _myView.JournalItems IsNot Nothing Then
                _myView.JournalItems.Clear()
            Else
                _myView.JournalItems = New List(Of JournalItemView)
            End If
            Dim item As New JournalItemView With {
                    .JournalIdNo = _myView.IdNo,
                    .Sequence = 1,
                    .AccountIdNo = Nothing,
                    .Credit = _myView.Amount,
                    .Debit = 0,
                    .RevCostCenterIdNo = 0,
                    .Notes = ""
                    }
            _myView.JournalItems.Add(item)
            If _myView.DjOiItems IsNot Nothing Then
                _myView.DjOiItems.Clear()
            Else
                _myView.DjOiItems = New List(Of DjOiItemView)
            End If

        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If CodeToEnum(Of PaymentTypeSelection)(_myView.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                SetAsideJournalItems()
                _myView.UnApplied = 0
                _myView.Applied = _myView.Amount
            Else
                MakeJournalItem()
                SetAsideJournalItems()
                Dim nRowCount As Integer
                If CodeToEnum(Of PaymentTypeSelection)(_myView.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    ' if AP Entry generate paid open invoices
                    nRowCount = 1
                    _myView.TotalDebits = 0
                    _myView.TotalCredits = 0
                    For Each ji In _myView.DjOiItems
                        If ji.Amount <> 0 Or ji.DiscountTaken <> 0 Then
                            Dim workRow As DataRow
                            If ji.IdNo <= 0 Then
                                workRow = DtOiInsertTable.NewRow()
                            Else
                                workRow = DtOiUpdateTable.NewRow()
                                workRow("IdNo") = ji.IdNo
                            End If
                            workRow("Amount") = ji.Amount
                            workRow("ApOpenInvoiceIdNo") = ji.ApOpenInvoiceIdNo
                            workRow("DjIdNo") = _myView.IdNo
                            workRow("DiscountTaken") = ji.DiscountTaken
                            workRow("Sequence") = nRowCount
                            If ji.IdNo <= 0 Then
                                DtOiInsertTable.Rows.Add(workRow)
                            Else
                                DtOiUpdateTable.Rows.Add(workRow)
                            End If
                            nRowCount += 1
                        End If
                        _myView.TotalDebits += ji.Amount
                    Next
                    _myView.TotalCredits = _myView.TotalDebits
                End If
            End If
        End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            If CodeToEnum(Of PaymentTypeSelection)(_myView.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                _myView.TotalDebits = 0
                _myView.TotalCredits = 0
                For Each ji In _myView.DjOiItems
                    _myView.TotalDebits += ji.Amount + ji.DiscountTaken
                Next
                _myView.TotalCredits = _myView.TotalDebits
            End If
            _myView.UnApplied = _myView.Amount - _myView.Applied
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(DjItemModel, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(OiItemModel, DtOiUpdateTable, DtOiInsertTable, passedValue, "DjIdNo")
                If retVal >= 0 Then
                    retVal = SaveOpenInvoices()
                End If
            End If
            If retVal >= 0 And IsEmpty(_myView.ReferenceNo) Then
                GlobalVariables.Mapper.Map(_myView, DataModel)
                retVal = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("Petty Cash Disbursement", "LastPosting", "TransactionName", "LastPostingDate")
                If IsDateRangeValid("Petty Cash Disbursement", _myView.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                ElseIf CodeToEnum(Of PaymentTypeSelection)(_myView.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                    If _myView.JournalItems Is Nothing OrElse _myView.JournalItems.Count() = 0 Then
                        Messaging.Show(True, "MsgCannotSaveAnEmptyTransaction", "Sorry, cannot save an empty transaction!", "Error")
                        retValue = False
                    End If
                    If retValue Then
                        retValue = JournalItemDataIsValid()
                    End If
                ElseIf CodeToEnum(Of PaymentTypeSelection)(_myView.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    If OiItemDataIsValid() Then
                        retValue = True
                    Else
                        retValue = False
                        Dim index As Int16 = 0
                        For Each item In _myView.DjOiItems
                            If item.Errors IsNot Nothing Then
                                _myView.DjOiItems(index).Errors = item.Errors
                            Else
                                If _myView.DjOiItems(index).Errors IsNot Nothing Then
                                    _myView.DjOiItems(index).Errors.Clear()
                                End If
                            End If
                            index += 1
                        Next
                    End If
                End If
            End If
            Return retValue
        End Function

        Private Function JournalItemDataIsValid() As Boolean
            Dim retValue As Boolean = True
            Dim account As AccountModel
            Dim specialAccount As String = ""
            For Each item In _myView.JournalItems
                If CodeToEnum(Of PaymentTypeSelection)(_myView.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                    If item.AccountIdNo IsNot Nothing OrElse item.AccountIdNo <> 0 Then
                        account = GetAccount(item.AccountIdNo)
                        specialAccount = account.SpecialAccount
                    End If
                    If (item.AccountIdNo Is Nothing OrElse item.AccountIdNo = 0) AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                        MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                        retValue = False
                        Exit For
                    End If
                    If CodeToEnum(Of PaymentTypeSelection)(_myView.PaymentType) = PaymentTypeSelection.Employee Then
                        If specialAccount IsNot Nothing AndAlso "AP|AR".Contains(specialAccount) Then
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
                    ElseIf CodeToEnum(Of PaymentTypeSelection)(_myView.PaymentType) = PaymentTypeSelection.CustomerRefund Then
                        If specialAccount IsNot Nothing AndAlso "AP|EL".Contains(specialAccount) Then
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
                        If specialAccount IsNot Nothing AndAlso "AP|EL|AR".Contains(specialAccount) Then
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

        Private Sub MakeJournalItem()
            If CodeToEnum(Of PaymentTypeSelection)(_myView.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                Dim aAccountIdNo As Int16() = {}
                Dim aAmount() As Decimal = {}
                Dim aAdded() As Boolean = {}
                Dim aDiscountTaken() As Decimal = {}
                Dim nSize As Integer = 0
                Dim nIndex As Integer
                ' summarize paid invoices per account
                For Each item In _myView.DjOiItems
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
                ' apply the payment to the checking account (the first entry) and zero out the rest of the existing
                ' journal item entries if there are existing journal entries.
                For Each item In _myView.JournalItems
                    If nCounter = 0 Then
                        item.JournalIdNo = _myView.IdNo
                        item.Sequence = 1
                        item.AccountIdNo = _myView.AccountIdNo
                        item.Credit = If(_myView.Amount < 0, 0, _myView.Amount)
                        item.Debit = If(_myView.Amount < 0, _myView.Amount * -1, 0)
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
                If _myView.JournalItems Is Nothing Or _myView.JournalItems.Count = 0 Then
                    Dim item As New JournalItemView With {
                            .JournalIdNo = _myView.IdNo,
                            .Sequence = 1,
                            .AccountIdNo = _myView.AccountIdNo,
                            .Credit = If(_myView.Amount < 0, 0, _myView.Amount),
                            .Debit = If(_myView.Amount < 0, _myView.Amount * -1, 0),
                            .RevCostCenterIdNo = 0,
                            .Notes = ""
                            }
                    _myView.JournalItems.Add(item)
                End If
                ' apply now the invoice payment summarized above for each existing AP account
                For i = 0 To aAccountIdNo.Count() - 1
                    For Each ji In _myView.JournalItems
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
                For Each ji In _myView.JournalItems
                    ' ignore the first line entry (this is for the check account)
                    If ji.Sequence <> 1 Then
                        If ji.AccountIdNo = _myView.DiscountAccountIdNo Then
                            ji.Debit = If(_myView.DiscountTaken < 0, _myView.DiscountTaken * -1, 0)
                            ji.Credit = If(_myView.DiscountTaken < 0, 0, _myView.DiscountTaken)
                            found = True
                        End If
                    End If
                Next
                If Not found Then
                    ' if discount account is not found add a Discount Account Journal Entry and
                    ' add the discount taken amount.
                    If _myView.DiscountTaken <> 0 Then
                        Dim item As New JournalItemView With {
                                .JournalIdNo = _myView.IdNo,
                                .Sequence = 0,
                                .AccountIdNo = _myView.DiscountAccountIdNo,
                                .Credit = If(_myView.DiscountTaken < 0, 0, _myView.DiscountTaken),
                                .Debit = If(_myView.DiscountTaken < 0, _myView.DiscountTaken * -1, 0),
                                .RevCostCenterIdNo = 0,
                                .Notes = ""
                                }
                        _myView.JournalItems.Add(item)
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
                                .JournalIdNo = _myView.IdNo,
                                .Sequence = 0,
                                .AccountIdNo = aAccountIdNo(nCounter),
                                .Credit = If(nAmount < 0, nAmount * -1, 0),
                                .Debit = If(nAmount < 0, 0, nAmount),
                                .RevCostCenterIdNo = 0,
                                .Notes = ""
                                }
                        _myView.JournalItems.Add(ji)
                    End If
                    nCounter += 1
                Next
                If _myView.UnApplied > 0 Then
                    ' if invoice not yet fully applied, then save the
                    ' unApplied amount to the "Advances to Supplier" account
                    ' check existing entries for the "Advances to Supplier" account
                    Dim unAppliedSwitch As Int16 = 0
                    For Each item In _myView.JournalItems
                        ' get the last matching idNo for accounts with advancesToSupplierAccountIdNo
                        If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.Debit = 0 And item.Credit = 0 And item.OriginalAmount > 0 Then
                            ' debit and credit must be zero otherwise that account has already been used above
                            item.Credit = 0
                            item.Debit = _myView.UnApplied
                            unAppliedSwitch = 1
                            Exit For
                        End If
                    Next
                    If unAppliedSwitch = 0 Then
                        ' advance payment journal entry not yet created
                        Dim jiModel As New JournalItemView With {
                            .JournalIdNo = _myView.IdNo,
                            .Sequence = 0,
                            .AccountIdNo = _advancesToSupplierAccountIdNo,
                            .Credit = 0,
                            .Debit = _myView.UnApplied,
                            .RevCostCenterIdNo = 0,
                            .Notes = ""
                            }
                        _myView.JournalItems.Add(jiModel)
                    End If
                Else
                    ' no advance payment so no advances to Supplier Account
                End If
            Else
                _myView.DjOiItems.Clear()
            End If
        End Sub

        Private Function SaveOpenInvoices()
            Dim retVal As Integer = 0
            If CodeToEnum(Of PaymentTypeSelection)(_myView.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                ' save the generated open invoices
                retVal = UpdateOpenInvoices()
            End If
            Return retVal
        End Function

        Private Sub SetAsideJournalItems()
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            Dim nRowCount As Integer = 1
            For Each ji In _myView.JournalItems
                ' loop through the journal entries but ignore zero values (except for first row)
                If ji.Debit = 0 And ji.Credit = 0 And nRowCount <> 1 Then
                    ' ignore zero entries except for the first entry (which is the payment entry)
                    ' allow zero cash amount in cases where adjustments are being made
                Else
                    Dim workRow As DataRow
                    If ji.IdNo <= 0 Then
                        workRow = DtInsertTable.NewRow()
                    Else
                        workRow = DtUpdateTable.NewRow()
                        workRow("IdNo") = ji.IdNo
                    End If
                    workRow("JournalIdNo") = _myView.IdNo
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
            If DtOiInsertTable IsNot Nothing Then
                DtOiInsertTable.Clear()
            End If
            If DtOiUpdateTable IsNot Nothing Then
                DtOiUpdateTable.Clear()
            End If
        End Sub

        Private Function UpdateOpenInvoices()
            Dim retVal As Integer = 0
            If AddMode Then
                If _myView.UnApplied > 0 Then
                    ' with advance payment
                    Dim items As List(Of JournalItemModel)
                    items = GetJournalItems(_myView.IdNo)
                    Dim ji As New JournalItemModel
                    For Each item In items
                        If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.OriginalAmount > 0 Then
                            ji.IdNo = item.IdNo
                            ji.AccountIdNo = item.AccountIdNo
                            ji.JournalIdNo = _myView.IdNo
                            retVal = AddApOpenInvoice(ji, "CD")
                            Exit For
                        End If
                    Next
                Else
                    ' no advance payment
                End If
            Else
                If _myView.UnApplied > 0 Then
                    ' with advance payment
                    ' get the journalItemIdNo
                    Dim ji As New JournalItemModel
                    Dim jiItems As List(Of JournalItemModel)
                    jiItems = GetJournalItems(_myView.IdNo)
                    ' get the item.IdNo of the last matching advancesToSupplierAccountIdNo if more than one found
                    For Each item In jiItems
                        If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.OriginalAmount > 0 Then
                            ' if more items found overwrite the old value found and use this one
                            ji.IdNo = item.IdNo
                            ji.AccountIdNo = item.AccountIdNo
                            ji.JournalIdNo = _myView.IdNo
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
                    lOpenInvoiceIdNo = CInt(GetAdvancePaymentOpenIdNo(JournalCode, _myView.IdNo))
                    If lOpenInvoiceIdNo > 0 Then
                        retVal = DeleteAdvancePaymentOpenInvoice(lOpenInvoiceIdNo)
                    End If
                End If
            End If
            Return retVal
        End Function

        Private Function DeleteAdvancePaymentOpenInvoice(ByRef idNo As Int32) As String
            Dim modelArOpenInvoice As New ModelAccounts("ApOpenInvoice")
            If Model.CountRecordWithKey(idNo, "ApOpenInvoice", "IdNo") > 0 Then
                Return modelArOpenInvoice.DeleteRecord(idNo, "ApOpenInvoice")
            End If
            Return 0
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
                transactionAmountInWords = New ToWord(_myView.Amount, currencies(0)).ConvertToArabic()
            Else
                transactionAmountInWords = New ToWord(_myView.Amount, currencies(0)).ConvertToEnglish()
            End If
            _myView.TotalCredits = 0
            For Each item In _myView.JournalItems
                _myView.TotalCredits = _myView.TotalCredits + item.Credit
            Next
            If language = "ar" Then
                totalLineAmountInWords = New ToWord(_myView.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalLineAmountInWords = New ToWord(_myView.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            Dim cForm As New ReportForm(ReportName, _myView.IdNo, "PCJournalIdNo", transactionAmountInWords, "transactionAmountInWords", totalLineAmountInWords, "TotalLineAmountInWords", language, "Language")
            cForm.Show()
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            If _myView.DjOiItems IsNot Nothing And _myView.DjOiItems.Any() Then
                DtOiUpdateTable.Clear()
                OiItemModel.DelUpdateTvp(DtOiUpdateTable, idNo)
            End If
            If _myView.JournalItems IsNot Nothing And _myView.JournalItems.Any() Then
                DtUpdateTable.Clear()
                DjItemModel.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

        Public Sub AutoApplyAmount()
            Dim amountToApply = _myView.Amount
            'Dim appliedAmount As Decimal = 0D
            For Each item In _myView.DjOiItems
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

    End Class

End Namespace