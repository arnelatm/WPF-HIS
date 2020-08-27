Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class CashReceiptJournalPresenter
        Inherits AccountsPresenter(Of ICashReceiptJournalView, CashReceiptJournalModel)

        Protected DtCsrOiInsertTable As New DataTable
        Protected DtCsrOiUpdateTable As New DataTable
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Private ReadOnly _advancesToCustomerAccountIdNo As Int32

        Private ReadOnly _csrOiItemModel As New ModelAccounts("CsrOiItem")
        Private _oldCsrOiItem As List(Of CsrOiItemModel)

        Public Sub New(view As ICashReceiptJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("CashReceiptJournal")
            TableName = "CashReceiptJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New CashReceiptJournalModel()
            DataModel = New CashReceiptJournalModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            _advancesToCustomerAccountIdNo = GetCustomerAdvancesAccountIdNo()

            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Credit", GetType(Decimal))
            DtInsertTable.Columns.Add("Debit", GetType(Decimal))
            DtInsertTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Notes", GetType(String))
            DtInsertTable.Columns.Add("RevCostCenterIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Credit", GetType(Decimal))
            DtUpdateTable.Columns.Add("Debit", GetType(Decimal))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("RevCostCenterIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))

            DtCsrOiInsertTable.Columns.Add("Amount", GetType(Decimal))
            DtCsrOiInsertTable.Columns.Add("ArOpenInvoiceIdNo", GetType(Int32))
            DtCsrOiInsertTable.Columns.Add("CsrIdNo", GetType(Int32))
            DtCsrOiInsertTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtCsrOiInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtCsrOiUpdateTable.Columns.Add("Amount", GetType(Decimal))
            DtCsrOiUpdateTable.Columns.Add("ArOpenInvoiceIdNo", GetType(Int32))
            DtCsrOiUpdateTable.Columns.Add("CsrIdNo", GetType(Int32))
            DtCsrOiUpdateTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtCsrOiUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtCsrOiUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

        'Public Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
        '    Return _arOpenInvoiceModel.AddInvoicePayment(idNo, amount, discountTaken)
        'End Function

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
                            End If
                        Next
                    End If
                    If Not itemFound Then

                        If unpaidInvoice.JournalCode = "CR" And unpaidInvoice.JournalIdNo = View.IdNo Then
                            ' ignore advance payments if applied to this entry.
                        Else
                            nSeq = nSeq + 1
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

        Public Function CsrOiItemDataIsValid()
            Dim retVal = True
            Dim index As Int16 = 0
            For Each item In View.CsrOiItems
                If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                    If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
                       (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
                        Dim lineNumber = item.Sequence.ToString()
                        Dim variables = {"lineNumber", lineNumber}
                        Dim message = Messaging.GetMessage(True, "MsgAppliedAmtExceedsBalance", "Error in line {lineNumber}. Applied amount and discount exceeds balance.", "Invalid Payment")
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
                    Dim totalBalance As Decimal = 0D
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

        Public Function GetAdvanceCollectionOpenIdNo(ByRef idNo As Int32) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, "CR", "ArOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetCsrOiItems(csrOiIdNo As Int32) As List(Of CsrOiItemModel)
            Return _csrOiItemModel.GetRecordsWithIdNo(Of CsrOiItemModel)(csrOiIdNo, "Sequence")
        End Function

        Public Function GetJournalItems(journalIdNo As Int32) As List(Of JournalItemModel)
            Return Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetReceiptType(ByRef idNo As Int32) As String
            Dim retVal As String
            retVal = Model.GetRecordFieldWithKey(idNo, "CashReceiptJournal", "IdNo", "PayorType")
            Return retVal
        End Function

        Public Function GetCustomerOpenInvoices(ByRef customerIdNo As Int32) As List(Of CsrOiItemModel)
            Return ModelPresenter.GetCustomerOpenInvoices(Of CsrOiItemModel)(customerIdNo)
        End Function

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
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If ReceiptTypeToEnum(View.PayorType) <> ReceiptTypeSelection.AccountsReceivable Then
                SetAsideJournalItems()
            Else
                MakeJournalItem()
                SetAsideJournalItems()
                Dim nRowCount As Integer
                If ReceiptTypeToEnum(View.PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                    ' if AR Entry generate paid open invoices
                    nRowCount = 1
                    View.TotalDebits = 0
                    View.TotalCredits = 0
                    For Each ji In View.CsrOiItems
                        If ji.Amount <> 0 Or ji.DiscountTaken <> 0 Then
                            Dim workRow As DataRow
                            If ji.IdNo <= 0 Then
                                workRow = DtCsrOiInsertTable.NewRow()
                            Else
                                workRow = DtCsrOiUpdateTable.NewRow()
                                workRow("IdNo") = ji.IdNo
                            End If
                            workRow("Amount") = ji.Amount
                            workRow("ArOpenInvoiceIdNo") = ji.ArOpenInvoiceIdNo
                            workRow("CsrIdNo") = View.IdNo
                            workRow("DiscountTaken") = ji.DiscountTaken
                            workRow("Sequence") = nRowCount
                            If ji.IdNo <= 0 Then
                                DtCsrOiInsertTable.Rows.Add(workRow)
                            Else
                                DtCsrOiUpdateTable.Rows.Add(workRow)
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
            If PaymentTypeToEnum(View.PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                View.TotalDebits = 0
                View.TotalCredits = 0
                For Each ji In View.CsrOiItems
                    View.TotalDebits += ji.Amount + ji.DiscountTaken
                Next
                View.TotalCredits = View.TotalDebits
            End If
            View.UnApplied = View.Amount - View.Applied
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
            ' save journal entries
            Dim parentIdNo As Integer = retVal
            If Not AddMode Then
                _oldCsrOiItem = GetCsrOiItems(View.IdNo)
            Else
                _oldCsrOiItem = Nothing
            End If
            retVal = SaveJournalItems(parentIdNo)
            If retVal >= 0 Then
                retVal = SaveCsrOiItems(parentIdNo)
                If retVal >= 0 Then
                    retVal = SaveOpenInvoices()
                End If
            End If
            If retVal >= 0 And IsEmpty(View.ReferenceNo) Then
                GlobalVariables.Mapper.Map(View, DataModel)
                retVal = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("Cash Receipt", "LastPosting", "TransactionName", "LastPostingDate")
                If Messaging.IsDateRangeValid("Cash Disbursement", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                ElseIf ReceiptTypeToEnum(View.PayorType) <> ReceiptTypeSelection.AccountsReceivable Then
                    If View.JournalItems Is Nothing OrElse View.JournalItems.Count() = 0 Then
                        Messaging.Show(True, "MsgCannotSaveAnEmptyTransaction", "Sorry, cannot save an empty transaction!", "Error")
                        retValue = True
                    End If
                ElseIf ReceiptTypeToEnum(View.PayorType) = ReceiptTypeSelection.AccountsReceivable Then
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
                If retValue Then
                    retValue = JournalItemDataIsValid()
                    'If retValue Then
                    '    'retValue = OpenInvoicePaymentsIsValid(cashAccount, retValue)
                    'End If
                End If
            End If
            Return retValue
        End Function

        Public Overloads Function JournalItemDataIsValid() As Boolean
            Dim retValue = True
            Dim chart As ChartModel
            Dim specialAccount As String
            For Each item In View.JournalItems
                If PaymentTypeToEnum(View.PayorType) <> ReceiptTypeSelection.AccountsReceivable Then
                    If item.AccountIdNo IsNot Nothing OrElse item.AccountIdNo <> 0 Then
                        chart = GetChart(item.AccountIdNo)
                        specialAccount = chart.SpecialAccount
                    End If
                    If (item.AccountIdNo Is Nothing OrElse item.AccountIdNo = 0) AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                        MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                        retValue = False
                        Exit For
                    End If
                    If PaymentTypeToEnum(View.PayorType) = ReceiptTypeSelection.Employee Then
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
                    ElseIf PaymentTypeToEnum(View.PayorType) = ReceiptTypeSelection.SupplierRefund Then
                        If specialAccount IsNot Nothing AndAlso "AR|EL".Contains(specialAccount) Then
                            Dim lineNumber = Format(item.Sequence, "0")
                            Dim entryNames = Messaging.TranslateCaption("Accounts Receivables/Employee")
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
            If ReceiptTypeToEnum(View.PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                Dim aAccountIdNo As Int32() = {}
                Dim aAmount() As Decimal = {}
                Dim aAdded() As Boolean = {}
                Dim aDiscountTaken() As Decimal = {}
                Dim nSize As Integer = 0
                Dim nIndex As Integer
                ' summarize paid invoices per account
                For Each item In View.CsrOiItems
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
                    nCounter = nCounter + 1
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
                Dim found As Boolean = False
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
                    nCounter = nCounter + 1
                Next
                If View.UnApplied > 0 Then
                    ' if invoice not yet fully applied, then save the
                    ' unApplied amount to the "Advances to Customer" account
                    ' check existing entries for the "Advances to Customer" account
                    Dim unAppliedSwitch As Int16 = 0
                    For Each item In View.JournalItems
                        ' get the last matching idno for accounts with advancestoCustomerAccountIdNo
                        If item.AccountIdNo = _advancesToCustomerAccountIdNo And item.Debit = 0 And item.Credit = 0 And item.OriginalAmount > 0 Then
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

        Private Function SaveCsrOiItems(passedValue As Integer) As Integer
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
            updateReturnValue = _csrOiItemModel.DelUpdateTvp(DtCsrOiUpdateTable, headerIdNo)
            If updateReturnValue >= 0 AndAlso DtCsrOiInsertTable.Rows.Count > 0 Then
                For Each row As DataRow In DtCsrOiInsertTable.Rows
                    row.Item("CsrIdNo") = headerIdNo
                Next
                insertReturnValue = _csrOiItemModel.InsertTvp(DtCsrOiInsertTable)
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

        Private Function SaveOpenInvoices()
            Dim retVal As Integer = 0
            If ReceiptTypeToEnum(View.PayorType) = ReceiptTypeSelection.AccountsReceivable Then
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
            If DtCsrOiInsertTable IsNot Nothing Then
                DtCsrOiInsertTable.Clear()
            End If
            If DtCsrOiUpdateTable IsNot Nothing Then
                DtCsrOiUpdateTable.Clear()
            End If
        End Sub

        Private Function UpdateOpenInvoices() As Integer
            ' after saving open invoices apply the paid amount
            Dim retVal As Integer = 0
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
                    lOpenInvIdNo = CInt(GetAdvanceCollectionCrOpenInvoice(ji.IdNo))
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
                    lOpenInvoiceIdNo = CInt(GetAdvanceCollectionOpenIdNo(View.IdNo))
                    If lOpenInvoiceIdNo > 0 Then
                        retVal = DeleteAdvancePaymentOpenInvoice(lOpenInvoiceIdNo)
                    End If
                End If
            End If
            Return retVal
        End Function

        Private Function DeleteAdvancePaymentOpenInvoice(ByRef idNo As Int32) As String
            Dim modelArOpenInvoice As New ModelAccounts("ArOpenInvoice")
            If Model.CountRecordWithKey(idNo, "ArOpenInvoice", "IdNo") > 0 Then
                Return modelArOpenInvoice.DeleteRecord(idNo, "ArOpenInvoice")
            End If
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
            View.TotalCredits = 0
            For Each item In View.JournalItems
                View.TotalCredits = View.TotalCredits + item.Credit
            Next
            If language = "ar" Then
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            Dim cForm As New ReportForm("Cash Receipt Journal.Rpt", View.IdNo, "CashReceiptJournalIdNo", transactionAmount, "CreditAmountInWords", totalCreditAmount, "TotalLineAmountInWords", language, "Language")
            cForm.Show()
        End Sub

    End Class

End Namespace