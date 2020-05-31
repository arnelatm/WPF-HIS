Imports AATM.Accounts.PresentationLayer.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class PettyCashJournalPresenter
        Inherits AccountsPresenter(Of IPettyCashJournalView, PettyCashJournalModel)

        Protected DtInsertTable As New DataTable
        Protected DtPcsOiInsertTable As New DataTable
        Protected DtPcsOiUpdateTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Private ReadOnly _advancesToSupplierAccountIdNo As Int32
        Private ReadOnly _apOpenInvoiceModel As New ModelAccounts("ApOpenInvoice")

        Private ReadOnly _pcsOiItemModel As New ModelAccounts("PcsOiItem")
        Private _oldPcsOiItem As List(Of PcsOiItemModel)

        Public Sub New(view As IPettyCashJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PettyCashJournal")
            TableName = "PettyCashJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New PettyCashJournalModel()
            DataModel = New PettyCashJournalModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            _advancesToSupplierAccountIdNo = GetAdvancesToSupplierAccountIdNo()

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
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))

            DtPcsOiInsertTable.Columns.Add("Amount", GetType(Decimal))
            DtPcsOiInsertTable.Columns.Add("ApOpenInvoiceIdNo", GetType(Int32))
            DtPcsOiInsertTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtPcsOiInsertTable.Columns.Add("PcsIdNo", GetType(Int32))
            DtPcsOiInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtPcsOiUpdateTable.Columns.Add("Amount", GetType(Decimal))
            DtPcsOiUpdateTable.Columns.Add("ApOpenInvoiceIdNo", GetType(Int32))
            DtPcsOiUpdateTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtPcsOiUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtPcsOiUpdateTable.Columns.Add("PcsIdNo", GetType(Int32))
            DtPcsOiUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

        Public Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Sub AddSupplierOpenInvoices()
            If View.PayeeIdNo <> 0 Then
                Dim unpaidInvoices = GetSupplierOpenInvoices(View.PayeeIdNo)
                Dim nSeq As Integer
                If AddMode Then
                    View.PcsOiItems.Clear()
                End If
                If View.PcsOiItems IsNot Nothing Then
                    nSeq = View.PcsOiItems.Count()
                Else
                    nSeq = 0
                End If
                For Each unpaidInvoice In unpaidInvoices
                    Dim itemFound = False
                    If View.PcsOiItems IsNot Nothing Then
                        For Each item In View.PcsOiItems
                            If item.ApOpenInvoiceIdNo = unpaidInvoice.IdNo Then
                                itemFound = True
                            End If
                        Next
                    End If
                    If Not itemFound Then

                        If unpaidInvoice.JournalCode = "CD" And unpaidInvoice.JournalIdNo = View.IdNo Then
                            ' ignore advance payments if applied to this entry.
                        Else
                            nSeq = nSeq + 1
                            Dim item As New PcsOiItemView With {
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
                            If View.PcsOiItems Is Nothing Then
                                View.PcsOiItems = New List(Of PcsOiItemView)
                            End If
                            View.PcsOiItems.Add(item)
                        End If
                    End If
                Next
            End If
        End Sub

        Public Function PcsOiItemDataIsValid() As Boolean
            Dim retVal = True
            Dim index As Int16 = 0
            For Each item In View.PcsOiItems
                If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                    If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
                       (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
                        Dim lineNumber = item.Sequence.ToString()
                        Dim variables = {"lineNumber", lineNumber}
                        Dim message = Messaging.GetMessage(True, "MsgAppliedAmtExceedsBalance", "Error in line {lineNumber}. Applied amount and discount exceeds balance.", "Invalid Payment")
                        Dim caption = Messaging.TranslateCaption("Invalid Payment")
                        message = Messaging.ReplaceValues(message, variables)
                        Messaging.Show(message, caption)
                        If View.PcsOiItems(index).Errors Is Nothing Then
                            View.PcsOiItems(index).Errors = New List(Of String)
                        End If
                        View.PcsOiItems(index).Errors.Add(message)
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
                        retVal = False
                        Exit For
                    Else
                        ' clear error message
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = ""
                        If View.PcsOiItems(index).Errors IsNot Nothing Then
                            View.PcsOiItems(index).Errors.Clear()
                        End If
                    End If
                End If
                index += 1
            Next
            If retVal Then
                If View.UnApplied <> 0 Then
                    Dim totalBalance As Decimal = 0D
                    For Each item In View.PcsOiItems
                        totalBalance += item.Balance
                    Next
                    If totalBalance > 0 Then
                        If View.UnApplied > 0 Then
                            Messaging.Show(True, "MsgPaymentNotFullyApplied", "Payment not yet fully applied. Cannot save entry unless amount is fully applied.", "Invalid Transaction")
                            retVal = False
                        Else
                            Messaging.Show(True, "MsgPaymentIsOverApplied", "Payment is over applied. Either increase the amount of payment or reduce applied payments.", "Invalid Transaction")
                            retVal = False
                        End If
                    Else
                        If Messaging.Show(True, "AskMakeExcessPaymentAdvance", "Amount not yet fully applied or no more unpaid invoices for this supplier. Do you want to make the excess payment as an advance payment?", $"Save Advance Payment",
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

        Public Function GetAdvancePaymentOpenIdNo(ByRef idNo As Int32) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, "PC", "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetPcsOiItems(pcsOiIdNo As Int32) As List(Of PcsOiItemModel)
            Return _pcsOiItemModel.GetRecordsWithIdNo(Of PcsOiItemModel)(pcsOiIdNo, "Sequence")
        End Function

        Public Function GetJournalItems(journalIdNo As Int32) As List(Of JournalItemModel)
            Return Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetPaymentType(ByRef idNo As Int32) As String
            Dim retVal As String
            retVal = Model.GetRecordFieldWithKey(idNo, "PettyCashJournal", "IdNo", "PaymentType")
            Return retVal
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Int32) As List(Of PcsOiItemModel)
            Return ModelPresenter.GetSupplierOpenInvoices(Of PcsOiItemModel)(supplierIdNo)
        End Function

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            If IsEmpty(View.ReferenceNo) Then
                UpdateGlReferenceNumber()
            End If
        End Sub

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
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
                    .ProfitCenterIdNo = 0,
                    .Notes = ""
                    }
            View.JournalItems.Add(item)
            If View.PcsOiItems IsNot Nothing Then
                View.PcsOiItems.Clear()
            Else
                View.PcsOiItems = New List(Of PcsOiItemView)
            End If
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If PaymentTypeToEnum(View.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                If View.JournalItems Is Nothing OrElse View.JournalItems.Count() = 0 Then
                    Messaging.Show(True, "MsgCannotSaveAnEmptyTransaction", "Sorry, cannot save an empty transaction!", "Error")
                    CancelSave = True
                Else
                    SetAsideJournalItems()
                End If
                View.UnApplied = 0
                View.Applied = View.Amount
            Else
                MakeJournalItem()
                SetAsideJournalItems()
                Dim nRowCount As Integer
                If PaymentTypeToEnum(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    ' if AP Entry generate paid open invoices
                    nRowCount = 1
                    View.TotalDebits = 0
                    View.TotalCredits = 0
                    For Each ji In View.PcsOiItems
                        If ji.Amount <> 0 Or ji.DiscountTaken <> 0 Then
                            Dim workRow As DataRow
                            If ji.IdNo <= 0 Then
                                workRow = DtPcsOiInsertTable.NewRow()
                            Else
                                workRow = DtPcsOiUpdateTable.NewRow()
                                workRow("IdNo") = ji.IdNo
                            End If
                            workRow("pcsIdNo") = View.IdNo
                            workRow("Sequence") = nRowCount
                            workRow("Amount") = ji.Amount
                            workRow("DiscountTaken") = ji.DiscountTaken
                            workRow("ApOpenInvoiceIdNo") = ji.ApOpenInvoiceIdNo
                            If ji.IdNo <= 0 Then
                                DtPcsOiInsertTable.Rows.Add(workRow)
                            Else
                                DtPcsOiUpdateTable.Rows.Add(workRow)
                            End If
                            nRowCount += 1
                        End If
                        View.TotalDebits += ji.Amount
                    Next
                    View.TotalCredits = View.TotalDebits
                End If
            End If
        End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            If PaymentTypeToEnum(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                View.TotalDebits = 0
                View.TotalCredits = 0
                For Each ji In View.PcsOiItems
                    View.TotalDebits += ji.Amount + ji.DiscountTaken
                Next
                View.TotalCredits = View.TotalDebits
            End If
        End Sub

        Public Function RemoveInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Sub SaveChildren(ByRef passedValue As Integer) Handles MyBase.ParentRecordUpdatedSuccessfully, MyBase.ParentRecordAddedSuccessfully
            Dim retVal As Integer
            ' save journal entries
            If Not AddMode Then
                _oldPcsOiItem = GetPcsOiItems(View.IdNo)
            Else
                _oldPcsOiItem = Nothing
            End If
            retVal = SaveJournalItems(passedValue)
            If retVal > 0 Then
                retVal = SavePcsOiItems(passedValue)
                If retVal >= 0 Then
                    SaveOpenInvoices()
                End If
            End If
        End Sub

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("Petty Cash Disbursement", "LastPosting", "TransactionName", "LastPostingDate")
                If Messaging.IsDateRangeValid("Petty Cash Disbursement", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                Else
                    If PaymentTypeToEnum(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                        If PcsOiItemDataIsValid() Then
                            retValue = True
                        Else
                            retValue = False
                            Dim index As Int16 = 0
                            For Each item In View.PcsOiItems
                                If item.Errors IsNot Nothing Then
                                    View.PcsOiItems(index).Errors = item.Errors
                                Else
                                    If View.PcsOiItems(index).Errors IsNot Nothing Then
                                        View.PcsOiItems(index).Errors.Clear()
                                    End If
                                End If
                                index += 1
                            Next
                        End If
                    End If
                    If retValue Then
                        retValue = JournalItemDataIsValid()
                        If retValue Then
                            'retValue = OpenInvoicePaymentsIsValid(cashAccount, retValue)
                        End If
                    End If
                End If
            End If
            Return retValue
        End Function

        Private Function JournalItemDataIsValid() As Boolean
            Dim retValue As Boolean = True
            Dim chart As ChartModel
            Dim specialAccount As String
            For Each item In View.JournalItems
                If (item.AccountIdNo Is Nothing OrElse item.AccountIdNo = 0) Then
                    If (item.Debit <> 0 Or item.Credit <> 0) Then
                        MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                        retValue = False
                        Exit For
                    End If
                ElseIf PaymentTypeToEnum(View.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                    chart = GetChart(item.AccountIdNo)
                    specialAccount = chart.SpecialAccount
                    If PaymentTypeToEnum(View.PaymentType) = PaymentTypeSelection.Employee Then
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
                    ElseIf PaymentTypeToEnum(View.PaymentType) = PaymentTypeSelection.CustomerRefund Then
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
            If PaymentTypeToEnum(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                Dim aAccountIdNo As Int32() = {}
                Dim aAmount() As Decimal = {}
                Dim aAdded() As Boolean = {}
                Dim aDiscountTaken() As Decimal = {}
                Dim nSize As Integer = 0
                Dim nIndex As Integer
                ' summarize paid invoices per account
                For Each item In View.PcsOiItems
                    Dim nAccountIdNo As Int32?
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
                            nSize = nSize + 1
                        Else
                            aAmount(nIndex) = aAmount(nIndex) + item.Amount
                            aDiscountTaken(nIndex) = aDiscountTaken(nIndex) + item.DiscountTaken
                        End If
                    End If
                Next
                Dim nCounter As Integer = 0
                ' apply the payment to the checking account (the first entry) and zero out the rest of the existing
                ' journal item entries if there are existing journal entries.
                For Each item In View.JournalItems
                    If nCounter = 0 Then
                        item.JournalIdNo = View.IdNo
                        item.Sequence = 1
                        item.AccountIdNo = View.AccountIdNo
                        item.Credit = If(View.Amount < 0, 0, View.Amount)
                        item.Debit = If(View.Amount < 0, View.Amount * -1, 0)
                        item.ProfitCenterIdNo = 0
                        item.Notes = ""
                    Else
                        item.Credit = 0
                        item.Debit = 0
                        item.ProfitCenterIdNo = 0
                        item.Notes = ""
                    End If
                    nCounter = nCounter + 1
                Next
                ' if no existing journal entries, create one for the checking account payment.
                If View.JournalItems Is Nothing Or View.JournalItems.Count = 0 Then
                    Dim item As New JournalItemView With {
                            .JournalIdNo = View.IdNo,
                            .Sequence = 1,
                            .AccountIdNo = View.AccountIdNo,
                            .Credit = If(View.Amount < 0, 0, View.Amount),
                            .Debit = If(View.Amount < 0, View.Amount * -1, 0),
                            .ProfitCenterIdNo = 0,
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
                    ' ignore the first line entry (this is for the check account)
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
                                .ProfitCenterIdNo = 0,
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
                                .ProfitCenterIdNo = 0,
                                .Notes = ""
                                }
                        View.JournalItems.Add(ji)
                    End If
                    nCounter = nCounter + 1
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
                            .ProfitCenterIdNo = 0,
                            .Notes = ""
                            }
                        View.JournalItems.Add(jiModel)
                    End If
                Else
                    ' no advance payment so no advances to Supplier Account
                End If
            Else
                View.PcsOiItems.Clear()
            End If
            'UpdateTotals()
        End Sub

        'Private Sub OnBeforeCompare() Handles MyBase.BeforeCompare
        '    If PaymentTypeToEnum(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
        '        View.TotalDebits = View.Applied + View.DiscountTaken
        '        View.TotalCredits = View.TotalDebits
        '    End If
        'End Sub

        Private Function SavePcsOiItems(passedValue As Integer) As Integer
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal As Integer
            Dim headerIdNo As Int32
            If AddMode Then
                headerIdNo = passedValue
                CallByName(View, IdFieldName, CallType.Set, headerIdNo)
            Else
                headerIdNo = CallByName(View, IdFieldName, CallType.Get)
            End If
	    updateReturnValue = _pcsOiItemModel.DelUpdateTvp(DtPcsOiUpdateTable, View.IdNo)
            If updateReturnValue >= 0 AndAlso DtPcsOiInsertTable.Rows.Count > 0 Then
                For Each row As DataRow In DtPcsOiInsertTable.Rows
                    row.Item("PcsIdNo") = headerIdNo
                Next
                insertReturnValue = _pcsOiItemModel.InsertTvp(DtPcsOiInsertTable)
                If insertReturnValue >= 0 Then
                    retVal = updateReturnValue + insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Return retVal
        End Function

        Private Function SaveJournalItems(passedValue As Integer) As Integer
            Dim retVal As Integer
            Dim insertReturnValue
            Dim updateReturnValue
            Dim headerIdNo As Int32
            If AddMode Then
                headerIdNo = passedValue
                CallByName(View, IdFieldName, CallType.Set, headerIdNo)
            Else
                headerIdNo = CallByName(View, IdFieldName, CallType.Get)
            End If
            updateReturnValue = Model.DelUpdateTvp(DtUpdateTable, headerIdNo)
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
            Return retVal
        End Function

        Private Sub SaveOpenInvoices()
            If PaymentTypeToEnum(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                ' save the generated open invoices
                ' after saving open invoices apply the paid amount
                UpdateOpenInvoices()
            Else
                If _oldPcsOiItem IsNot Nothing Then
                    For Each Item In _oldPcsOiItem
                        If Item.Amount <> 0 Or Item.DiscountTaken <> 0 Then
                            RemoveInvoicePayment(Item.ApOpenInvoiceIdNo, Item.Amount, Item.DiscountTaken)
                        End If
                    Next
                End If
            End If
        End Sub

        Private Sub SetAsideJournalItems()
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            Dim nRowCount As Integer = 1
            For Each ji In View.JournalItems
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
                    nRowCount += 1
                End If
            Next
            If DtPcsOiInsertTable IsNot Nothing Then
                DtPcsOiInsertTable.Clear()
            End If
            If DtPcsOiUpdateTable IsNot Nothing Then
                DtPcsOiUpdateTable.Clear()
            End If
        End Sub

        Private Sub UpdateOpenInvoices()
            Dim newPcsOiItem As List(Of PcsOiItemModel)
            If AddMode Then
                ' add Mode so just add the payment
                newPcsOiItem = GetPcsOiItems(View.IdNo)
                For Each item In newPcsOiItem
                    If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                        AddInvoicePayment(item.ApOpenInvoiceIdNo, item.Amount, item.DiscountTaken)
                    End If
                Next
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
                            AddApOpenInvoice(ji, "CD")
                            Exit For
                        End If
                    Next
                Else
                    ' no advance payment
                End If
            Else
                For Each Item In _oldPcsOiItem
                    ' if new
                    If Item.Amount <> 0 Or Item.DiscountTaken <> 0 Then
                        ' remove old payments
                        RemoveInvoicePayment(Item.ApOpenInvoiceIdNo, Item.Amount, Item.DiscountTaken)
                    End If
                Next
                ' re-apply the new payments
                For Each Item In View.PcsOiItems
                    If Item.Amount <> 0 Or Item.DiscountTaken <> 0 Then
                        ' add new payments
                        AddInvoicePayment(Item.ApOpenInvoiceIdNo, Item.Amount, Item.DiscountTaken)
                    End If
                Next
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
                    lOpenInvIdNo = GetAdvancePaymentCdOpenInvoice(ji.IdNo)
                    If lOpenInvIdNo = 0 Then
                        ' no previous entry
                        ' add the open invoice
                        AddApOpenInvoice(ji, "CD")
                    Else
                        ' already added, nothing to do
                    End If
                Else
                    ' get the OpenInvoice IdNo
                    ' check if the AdvancePayment OpenInvoice already created
                    Dim lOpenInvoiceIdNo As Int32
                    lOpenInvoiceIdNo = CInt(GetAdvancePaymentOpenIdNo(View.IdNo))
                    DeleteApOpenInvoice(lOpenInvoiceIdNo)
                End If
            End If
        End Sub

        Public Overrides Sub GoPrintRecord()
            Dim transactionAmount As String
            Dim totalCreditAmount As String
            Dim currencies As New List(Of CurrencyInfo)()
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            transactionAmount = New ToWord(View.Amount, currencies(0)).ConvertToArabic()
            View.TotalCredits = 0
            For Each item In View.JournalItems
                View.TotalCredits = View.TotalCredits + item.Credit
            Next
            totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Dim cForm As New ReportForm("Petty Cash Disbursement Journal.Rpt", View.IdNo, "PettyCashJournalIdNo", transactionAmount, "CreditAmountInWords", totalCreditAmount, "TotalLineAmountInWords")
            cForm.Show()
        End Sub

    End Class

End Namespace