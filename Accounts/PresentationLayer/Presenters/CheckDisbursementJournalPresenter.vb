Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class CheckDisbursementJournalPresenter
        Inherits AccountsPresenter(Of ICheckDisbursementJournalView, CheckDisbursementJournalModel)

        Protected DtCkdOiInsertTable As New DataTable
        Protected DtCkdOiUpdateTable As New DataTable
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Private ReadOnly _advancesToSupplierAccountIdNo As Int16

        Private ReadOnly _ckdOiItemModel As New ModelAccounts("CkdOiItem")
        Private ReadOnly _ckdJournalItemModel As New ModelAccounts("CheckDisbursementJournalItem")

        Public Sub New(view As ICheckDisbursementJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("CheckDisbursementJournal")
            TableName = "CheckDisbursementJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New CheckDisbursementJournalModel()
            DataModel = New CheckDisbursementJournalModel
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

            DtCkdOiInsertTable.Columns.Add("Amount", GetType(Decimal))
            DtCkdOiInsertTable.Columns.Add("ApOpenInvoiceIdNo", GetType(Int32))
            DtCkdOiInsertTable.Columns.Add("CkdIdNo", GetType(Int32))
            DtCkdOiInsertTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtCkdOiInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtCkdOiUpdateTable.Columns.Add("Amount", GetType(Decimal))
            DtCkdOiUpdateTable.Columns.Add("ApOpenInvoiceIdNo", GetType(Int32))
            DtCkdOiUpdateTable.Columns.Add("CkdIdNo", GetType(Int32))
            DtCkdOiUpdateTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtCkdOiUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtCkdOiUpdateTable.Columns.Add("Sequence", GetType(Int16))

        End Sub

        Public Sub AddSupplierOpenInvoices()
            If View.PayeeIdNo <> 0 Then
                Dim unpaidInvoices = GetSupplierOpenInvoices(View.PayeeIdNo)
                Dim nSeq As Integer
                If AddMode Then
                    View.CkdOiItems.Clear()
                End If
                If View.CkdOiItems IsNot Nothing Then
                    nSeq = View.CkdOiItems.Count()
                Else
                    nSeq = 0
                End If
                For Each unpaidInvoice In unpaidInvoices
                    Dim itemFound = False
                    If View.CkdOiItems IsNot Nothing Then
                        For Each item In View.CkdOiItems
                            If item.ApOpenInvoiceIdNo = unpaidInvoice.IdNo Then
                                itemFound = True
                            End If
                        Next
                    End If
                    If Not itemFound Then

                        If unpaidInvoice.JournalCode = "CK" And unpaidInvoice.JournalIdNo = View.IdNo Then
                            ' ignore advance payments if applied to this entry.
                        Else
                            nSeq += 1
                            Dim item As New CkdOiItemView With {
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
                            If View.CkdOiItems Is Nothing Then
                                View.CkdOiItems = New List(Of CkdOiItemView)
                            End If
                            View.CkdOiItems.Add(item)
                        End If
                    End If
                Next
            End If
        End Sub

        Public Function CKdOiItemDataIsValid() As Boolean
            Dim retVal = True
            Dim index As Int16 = 0
            For Each item In View.CkdOiItems
                If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                    If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
                       (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
                        Dim lineNumber = item.Sequence.ToString()
                        Dim variables = {"lineNumber", lineNumber}
                        Dim message = Messaging.GetMessage(True, "MsgAppliedAmtExceedsBalance", "Error in line {lineNumber}. Applied amount and discount exceeds balance.", "Invalid Payment")
                        Dim caption = Messaging.TranslateCaption("Invalid Payment")
                        message = Messaging.ReplaceValues(message, variables)
                        Messaging.Show(message, caption)
                        If View.CkdOiItems(index).Errors Is Nothing Then
                            View.CkdOiItems(index).Errors = New List(Of String)
                        End If
                        View.CkdOiItems(index).Errors.Add(message)
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
                        retVal = False
                        Exit For
                    Else
                        ' clear error message
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = ""
                        If View.CkdOiItems(index).Errors IsNot Nothing Then
                            View.CkdOiItems(index).Errors.Clear()
                        End If
                    End If
                End If
                index += 1
            Next
            If retVal Then
                If View.UnApplied <> 0 Then
                    Dim totalBalance As Decimal = 0D
                    For Each item In View.CkdOiItems
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

        Public Function GetAdvancePaymentOpenIdNo(ByVal journalCode As String, ByVal idNo As Int32) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, journalCode, "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetCKdOiItems(ckdOiIdNo As Int32) As List(Of CkdOiItemModel)
            Return _ckdOiItemModel.GetRecordsWithIdNo(Of CkdOiItemModel)(ckdOiIdNo, "Sequence")
        End Function

        Public Function GetJournalItems(journalIdNo As Int32) As List(Of JournalItemModel)
            Return _ckdJournalItemModel.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetPaymentType(ByRef idNo As Int32) As String
            Dim retVal As String
            retVal = Model.GetRecordFieldWithKey(idNo, "CheckDisbursementJournal", "IdNo", "PaymentType")
            Return retVal
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Int32) As List(Of CkdOiItemModel)
            Return ModelPresenter.GetSupplierOpenInvoices(Of CkdOiItemModel)(supplierIdNo)
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
                    .Credit = View.Amount,
                    .Debit = 0,
                    .RevCostCenterIdNo = 0,
                    .Notes = ""
                    }
            View.JournalItems.Add(item)
            If View.CkdOiItems IsNot Nothing Then
                View.CkdOiItems.Clear()
            Else
                View.CkdOiItems = New List(Of CkdOiItemView)
            End If
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If GetEnumCodeValue(Of PaymentTypeSelection)(View.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                SetAsideJournalItems()
                View.UnApplied = 0
                View.Applied = View.Amount
            Else
                MakeJournalItem()
                SetAsideJournalItems()
                Dim nRowCount As Integer
                If GetEnumCodeValue(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    ' if AP Entry generate paid open invoices
                    nRowCount = 1
                    View.TotalDebits = 0
                    View.TotalCredits = 0
                    For Each ji In View.CkdOiItems
                        If ji.Amount <> 0 Or ji.DiscountTaken <> 0 Then
                            Dim workRow As DataRow
                            If ji.IdNo <= 0 Then
                                workRow = DtCkdOiInsertTable.NewRow()
                            Else
                                workRow = DtCkdOiUpdateTable.NewRow()
                                workRow("IdNo") = ji.IdNo
                            End If
                            workRow("Amount") = ji.Amount
                            workRow("ApOpenInvoiceIdNo") = ji.ApOpenInvoiceIdNo
                            workRow("ckdIdNo") = View.IdNo
                            workRow("DiscountTaken") = ji.DiscountTaken
                            workRow("Sequence") = nRowCount
                            If ji.IdNo <= 0 Then
                                DtCkdOiInsertTable.Rows.Add(workRow)
                            Else
                                DtCkdOiUpdateTable.Rows.Add(workRow)
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
            If GetEnumCodeValue(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                View.TotalDebits = 0
                View.TotalCredits = 0
                For Each ji In View.CkdOiItems
                    View.TotalDebits += ji.Amount + ji.DiscountTaken
                Next
                View.TotalCredits = View.TotalDebits
            End If
            View.UnApplied = View.Amount - View.Applied
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_ckdJournalItemModel, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_ckdOiItemModel, DtCkdOiUpdateTable, DtCkdOiInsertTable, passedValue, "PcsIdNo")
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
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("Check Disbursement", "LastPosting", "TransactionName", "LastPostingDate")
                If IsDateRangeValid("Check Disbursement", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                ElseIf GetEnumCodeValue(Of PaymentTypeSelection)(View.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                    If View.JournalItems Is Nothing OrElse View.JournalItems.Count() = 0 Then
                        Messaging.Show(True, "MsgCannotSaveAnEmptyTransaction", "Sorry, cannot save an empty transaction!", "Error")
                        retValue = False
                    End If
                    If retValue Then
                        retValue = JournalItemDataIsValid()
                    End If
                ElseIf GetEnumCodeValue(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    If CKdOiItemDataIsValid() Then
                        retValue = True
                    Else
                        retValue = False
                        Dim index As Int16 = 0
                        For Each item In View.CkdOiItems
                            If item.Errors IsNot Nothing Then
                                View.CkdOiItems(index).Errors = item.Errors
                            Else
                                If View.CkdOiItems(index).Errors IsNot Nothing Then
                                    View.CkdOiItems(index).Errors.Clear()
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
            For Each item In View.JournalItems
                If item.AccountIdNo IsNot Nothing OrElse item.AccountIdNo <> 0 Then
                    account = GetAccount(item.AccountIdNo)
                    specialAccount = account.SpecialAccount
                End If
                If (item.AccountIdNo Is Nothing OrElse item.AccountIdNo = 0) AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                    MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                    retValue = False
                    Exit For
                End If
                If GetEnumCodeValue(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.Employee Then
                    If specialAccount IsNot Nothing AndAlso "AP|AR".Contains(specialAccount) Then
                        Dim lineNumber = Format(item.Sequence, "0")
                        Dim entryNames = Messaging.TranslateCaption("Accounts Receivables/Accounts Payables")
                        Messaging.ShowParametrizedMessage(True, "MsgAccountsNotAllowed", {"lineNumber", lineNumber, "entryNames", entryNames})
                        retValue = False
                        Exit For
                    End If
                ElseIf GetEnumCodeValue(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.CustomerRefund Then
                    If specialAccount IsNot Nothing AndAlso "AP|EL".Contains(specialAccount) Then
                        Dim lineNumber = Format(item.Sequence, "0")
                        Dim entryNames = Messaging.TranslateCaption("Accounts Payables/Employee")
                        Messaging.ShowParametrizedMessage(True, "MsgAccountsNotAllowed", {"lineNumber", lineNumber, "entryNames", entryNames})
                        retValue = False
                        Exit For
                    End If
                Else
                    If specialAccount IsNot Nothing AndAlso "AP|EL|AR".Contains(specialAccount) Then
                        Dim lineNumber = Format(item.Sequence, "0")
                        Dim entryNames = Messaging.TranslateCaption("Accounts Payables/Accounts Receivables/Employee")
                        Messaging.ShowParametrizedMessage(True, "MsgAccountsNotAllowed", {"lineNumber", lineNumber, "entryNames", entryNames})
                        retValue = False
                        Exit For
                    End If
                End If
            Next
            Return retValue
        End Function

        Private Sub MakeJournalItem()
            If GetEnumCodeValue(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                Dim aAccountIdNo As Int16() = {}
                Dim aAmount() As Decimal = {}
                Dim aAdded() As Boolean = {}
                Dim aDiscountTaken() As Decimal = {}
                Dim nSize As Integer = 0
                Dim nIndex As Integer
                ' summarize paid invoices per account
                For Each item In View.CkdOiItems
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
                View.CkdOiItems.Clear()
            End If
        End Sub

        Private Function SaveOpenInvoices()
            Dim retVal As Integer = 0
            If GetEnumCodeValue(Of PaymentTypeSelection)(View.PaymentType) = PaymentTypeSelection.AccountsPayable Then
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
            If DtCkdOiInsertTable IsNot Nothing Then
                DtCkdOiInsertTable.Clear()
            End If
            If DtCkdOiUpdateTable IsNot Nothing Then
                DtCkdOiUpdateTable.Clear()
            End If
        End Sub

        Private Function UpdateOpenInvoices()
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
                    lOpenInvIdNo = CInt(GetAdvancePaymentOpenInvoice("CK", ji.IdNo))
                    If lOpenInvIdNo = 0 Then
                        ' no previous entry
                        ' add the open invoice
                        retVal = AddApOpenInvoice(ji, "CK")
                    Else
                        ' already added, nothing to do
                    End If
                Else
                    ' get the OpenInvoice IdNo
                    ' check if the AdvancePayment OpenInvoice already created
                    Dim lOpenInvoiceIdNo As Int32
                    lOpenInvoiceIdNo = CInt(GetAdvancePaymentOpenIdNo("CK", View.IdNo))
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
                transactionAmountInWords = New ToWord(View.Amount, currencies(0)).ConvertToArabic()
            Else
                transactionAmountInWords = New ToWord(View.Amount, currencies(0)).ConvertToEnglish()
            End If
            View.TotalCredits = 0
            For Each item In View.JournalItems
                View.TotalCredits = View.TotalCredits + item.Credit
            Next
            If language = "ar" Then
                totalLineAmountInWords = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalLineAmountInWords = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            Dim cForm As New ReportForm("Check Disbursement Journal.Rpt", View.IdNo, "CheckDisbursementJournalIdNo", transactionAmountInWords, "transactionAmountInWords", totalLineAmountInWords, "TotalLineAmountInWords", language, "Language")
            cForm.Show()
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            If View.CkdOiItems IsNot Nothing And View.CkdOiItems.Any() Then
                DtCkdOiUpdateTable.Clear()
                _ckdOiItemModel.DelUpdateTvp(DtCkdOiUpdateTable, idNo)
            End If
            If View.JournalItems IsNot Nothing And View.JournalItems.Any() Then
                DtUpdateTable.Clear()
                _ckdJournalItemModel.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

    End Class

End Namespace