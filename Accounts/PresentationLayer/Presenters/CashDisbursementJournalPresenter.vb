Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class CashDisbursementJournalPresenter
        Inherits AccountsPresenter(Of ICashDisbursementJournalView, CashDisbursementJournalModel)

        Protected DtCadOiInsertTable As New DataTable
        Protected DtCadOiUpdateTable As New DataTable
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable

        'Private ReadOnly _apJournalItemModel As New ModelAccounts("ApJournalItem")
        Private ReadOnly _apOpenInvoiceModel As New ModelAccounts("ApOpenInvoice")

        Private ReadOnly _advancesToSupplierAccountIdNo As Integer
        Private _oldCadOiItem As List(Of CadOiItemModel)

        'Private _apOpenInvoiceBo As New ModelAccounts("ApOpenInvoice")
        Public Sub New(view As ICashDisbursementJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("CashDisbursementJournal")
            TableName = "CashDisbursementJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New CashDisbursementJournalModel()
            DataModel = New CashDisbursementJournalModel
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
            DtUpdateTable.Columns.Add("IDNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))

            DtCadOiInsertTable.Columns.Add("Amount", GetType(Decimal))
            DtCadOiInsertTable.Columns.Add("cadIdNo", GetType(Int32))
            DtCadOiInsertTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtCadOiInsertTable.Columns.Add("JournalItemIdNo", GetType(Int32))
            DtCadOiInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtCadOiUpdateTable.Columns.Add("Amount", GetType(Decimal))
            DtCadOiUpdateTable.Columns.Add("cadIdNo", GetType(Int32))
            DtCadOiUpdateTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtCadOiUpdateTable.Columns.Add("IDNo", GetType(Int32))
            DtCadOiUpdateTable.Columns.Add("JournalItemIdNo", GetType(Int32))
            DtCadOiUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

        'Public Property JournalItemsPresenter As CashDisbursementJournalItemsPresenter
        'Public Property CadOiItemsPresenter As CadOiItemsPresenter

        'Public Overrides Function ChangesMade() As Boolean
        '    Dim cashDisbursementJournalChangesMade As Boolean
        '    If ObjectsCompare(OriginalModel, View) Then
        '        If JournalItemsPresenter.ChangesMadeInJournalItem Then
        '            cashDisbursementJournalChangesMade = True
        '        ElseIf CadOiItemsPresenter.ChangesMadeInCadOiItem Then
        '            cashDisbursementJournalChangesMade = True
        '        Else
        '            cashDisbursementJournalChangesMade = False
        '        End If
        '    Else
        '        cashDisbursementJournalChangesMade = True
        '    End If
        '    Return cashDisbursementJournalChangesMade
        'End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Sub AddSupplierOpenInvoices()
            If DataModel.PayeeIdNo <> 0 Then
                Dim unpaidInvoices = GetSupplierOpenInvoices(DataModel.PayeeIdNo)
                'Dim newItem As New CadOiItemModel
                Dim nSeq As Integer
                If AddMode Then
                    DataModel.cadOiItems.Clear()
                End If
                If DataModel.CadOiItems IsNot Nothing Then
                    nSeq = DataModel.CadOiItems.Count()
                Else
                    nSeq = 0
                End If
                For Each unpaidInvoice In unpaidInvoices
                    Dim itemFound = False
                    If DataModel.CadOiItems IsNot Nothing Then
                        For Each item In DataModel.CadOiItems
                            If item.JournalItemIdNo = unpaidInvoice.JournalItemIdNo And item.JournalCode = unpaidInvoice.JournalCode Then
                                itemFound = True
                            End If
                        Next
                    End If
                    If Not itemFound Then

                        If unpaidInvoice.JournalCode = "CD" And unpaidInvoice.JournalIdNo = DataModel.IdNo Then
                            ' ignore advance payments if applied to this entry.
                        Else
                            nSeq = nSeq + 1
                            Dim item As New CadOiItemModel With {
                                    .AccountIdNo = unpaidInvoice.AccountIdNo,
                                    .Amount = unpaidInvoice.Amount,
                                    .Balance = unpaidInvoice.Balance,
                                    .DiscountTaken = unpaidInvoice.DiscountTaken,
                                    .InvoiceNo = unpaidInvoice.InvoiceNo,
                                    .JournalCode = unpaidInvoice.JournalCode,
                                    .JournalIdNo = unpaidInvoice.JournalIdNo,
                                    .JournalItemIdNo = unpaidInvoice.JournalItemIdNo,
                                    .OpenInvoiceIdNo = unpaidInvoice.OpenInvoiceIdNo,
                                    .PreviousBalance = unpaidInvoice.Balance,
                                    .Sequence = nSeq,
                                    .TransactionDate = unpaidInvoice.TransactionDate
                                    }
                            DataModel.CadOiItems.Add(item)
                        End If
                    End If
                Next
            End If
        End Sub

        Public Function GetAdvancePaymentOpenIdNo(ByRef idNo As Integer) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, "CD", "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetPaymentType(ByRef idNo As Integer) As String
            Dim retVal As String
            retVal = Model.GetRecordFieldWithKey(idNo, "CashDisbursementJournal", "IdNo", "PaymentType")
            Return retVal
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Integer) As List(Of CadOiItemModel)
            Return ModelPresenter.GetSupplierOpenInvoices(Of CadOiItemModel)(supplierIdNo)
        End Function

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            If IsEmpty(DataModel.ReferenceNo) Then
                UpdateGlReferenceNumber()
            End If
        End Sub

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            DataModel.TransactionDate = Date.Now()
            DataModel.JournalItems.Clear()
            Dim item As New JournalItemModel With {
                    .JournalIdNo = DataModel.IdNo,
                    .Sequence = 1,
                    .AccountIdNo = Nothing,
                    .Credit = DataModel.Amount,
                    .Debit = 0,
                    .ProfitCenterIdNo = 0,
                    .Notes = ""
                    }
            DataModel.JournalItems.Add(item)
            DataModel.CadOiItems.Clear()
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If PaymentTypeToEnum(DataModel.PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                If DataModel.JournalItems Is Nothing OrElse DataModel.JournalItems.Count() = 0 Then
                    If MessageBox.Show(AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal_Ask_To_Save,
                                       AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal,
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        CancelSave = True
                    End If
                End If
            Else
                'If AddMode Then
                '    CallByName(DataModel, IdFieldName, CallType.Set, passedValue)
                'End If
                If DtInsertTable IsNot Nothing Then
                    DtInsertTable.Clear()
                End If
                If DtUpdateTable IsNot Nothing Then
                    DtUpdateTable.Clear()
                End If
                Dim nRowCount As Integer = 1
                For Each ji In DataModel.JournalItems
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
                        workRow("JournalIdNo") = DataModel.IdNo
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
                If DtCadOiInsertTable IsNot Nothing Then
                    DtCadOiInsertTable.Clear()
                End If
                If DtCadOiUpdateTable IsNot Nothing Then
                    DtCadOiUpdateTable.Clear()
                End If
                If PaymentTypeToEnum(DataModel.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    ' if AP Entry generate paid open invoices
                    nRowCount = 1
                    For Each ji In DataModel.CadOiItems
                        If ji.Amount <> 0 Or ji.DiscountTaken <> 0 Then
                            Dim workRow As DataRow
                            If ji.IdNo <= 0 Then
                                workRow = DtCadOiInsertTable.NewRow()
                            Else
                                workRow = DtCadOiUpdateTable.NewRow()
                                workRow("IdNo") = ji.IdNo
                            End If
                            workRow("cadIdNo") = DataModel.IdNo
                            workRow("Sequence") = nRowCount
                            workRow("Amount") = ji.Amount
                            workRow("DiscountTaken") = ji.DiscountTaken
                            workRow("JournalItemIdNo") = ji.JournalItemIdNo
                            If ji.IdNo <= 0 Then
                                DtCadOiInsertTable.Rows.Add(workRow)
                            Else
                                DtCadOiUpdateTable.Rows.Add(workRow)
                            End If
                            nRowCount += 1
                        End If
                    Next
                End If
                MakeJournalItem()
            End If
        End Sub

        Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) Handles MyBase.ParentRecordUpdatedSuccessfully, MyBase.ParentRecordAddedSuccessfully
            Dim retVal As Integer
            ' save journal entries
            If Not AddMode Then
                _oldCadOiItem = GetCadOiItems(DataModel.IdNo)
            Else
                _oldCadOiItem = Nothing
            End If
            retVal = SaveJournalItems()
            If retVal > 0 Then
                retVal = SaveCadOiItems()
                If retVal >= 0 Then
                    SaveOpenInvoices()
                End If
            End If
        End Sub

        Private Function SaveCadOiItems() As Integer
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal As Integer
            updateReturnValue = Model.DelUpdateTvp(DtUpdateTable, DataModel.IdNo)
            If updateReturnValue >= 0 AndAlso DtInsertTable.Rows.Count > 0 Then
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
            If PaymentTypeToEnum(DataModel.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                ' save the generated open invoices
                ' after saving open invoices apply the paid amount
                UpdateOpenInvoices()
            Else
                If _oldCadOiItem IsNot Nothing Then
                    For Each Item In _oldCadOiItem
                        If Item.Amount <> 0 Or Item.DiscountTaken <> 0 Then
                            RemoveInvoicePayment(Item.OpenInvoiceIdNo, Item.Amount, Item.DiscountTaken)
                        End If
                    Next
                End If
            End If
        End Sub

        Private Sub UpdateOpenInvoices()
            Dim newCadOiItem As List(Of CadOiItemModel)
            If AddMode Then
                ' add Mode so just add the payment
                newCadOiItem = GetCadOiItems(DataModel.IdNo)
                For Each item In newCadOiItem
                    If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                        AddInvoicePayment(item.OpenInvoiceIdNo, item.Amount, item.DiscountTaken)
                    End If
                Next
                If DataModel.UnApplied > 0 Then
                    ' with advance payment
                    Dim items As List(Of JournalItemModel)
                    items = GetJournalItems(DataModel.IdNo)
                    Dim ji As New JournalItemModel
                    For Each item In items
                        If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.OriginalAmount > 0 Then
                            ji.IdNo = item.IdNo
                            ji.AccountIdNo = item.AccountIdNo
                            ji.JournalIdNo = DataModel.IdNo
                            AddApOpenInvoice(ji, "CK")
                            Exit For
                        End If
                    Next
                Else
                    ' no advance payment
                End If
            Else
                Dim oldCadOiItem As List(Of CadOiItemModel)
                If Not AddMode Then
                    oldCadOiItem = GetCadOiItems(DataModel.IdNo)
                Else
                    oldCadOiItem = Nothing
                End If
                ' editing mode save the new paid invoices entry
                ' newCadOiItem = GetCadOiItems(DataModel.IdNo)
                ' un-apply the old payments
                For Each Item In oldCadOiItem
                    ' if new
                    If Item.Amount <> 0 Or Item.DiscountTaken <> 0 Then
                        ' remove old payments
                        RemoveInvoicePayment(Item.OpenInvoiceIdNo, Item.Amount, Item.DiscountTaken)
                    End If
                Next
                ' re-apply the new payments
                For Each Item In DataModel.cadOiItems
                    If Item.Amount <> 0 Or Item.DiscountTaken <> 0 Then
                        ' add new payments
                        AddInvoicePayment(Item.OpenInvoiceIdNo, Item.Amount, Item.DiscountTaken)
                    End If
                Next
                If DataModel.UnApplied > 0 Then
                    ' with advance payment
                    ' get the journalItemIdNo
                    Dim ji As New JournalItemModel
                    Dim jiItems As List(Of JournalItemModel)
                    jiItems = GetJournalItems(DataModel.IdNo)
                    ' get the item.IdNo of the last matching advancesToSupplierAccountIdNo if more than one found
                    For Each item In jiItems
                        If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.OriginalAmount > 0 Then
                            ' if more items found overwrite the old value found and use this one
                            ji.IdNo = item.IdNo
                            ji.AccountIdNo = item.AccountIdNo
                            ji.JournalIdNo = DataModel.IdNo
                            Exit For
                        End If
                    Next
                    Dim lOpenInvIdNo As Integer
                    ' check if the AdvancePayment OpenInvoice already created
                    lOpenInvIdNo = CInt(DataModel.GetAdvancePaymentOpenInvoice(ji.IdNo))
                    If lOpenInvIdNo = 0 Then
                        ' no previous entry
                        ' add the open invoice
                        DataModel.AddApOpenInvoice(ji, "CK")
                    Else
                        ' already added, nothing to do
                    End If
                Else
                    ' get the OpenInvoice IdNo
                    ' check if the AdvancePayment OpenInvoice already created
                    Dim lOpenInvoiceIdNo As Integer
                    lOpenInvoiceIdNo = CInt(GetAdvancePaymentOpenIdNo(DataModel.IdNo))
                    DeleteApOpenInvoice(lOpenInvoiceIdNo)
                End If
            End If
        End Sub

        Private Function SaveJournalItems() As Integer ' ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable, journalIdNo As Integer) As Integer
            Dim retVal As Integer
            Dim insertReturnValue
            Dim updateReturnValue
            Dim parentIdNo As Integer
            If AddMode Then
                parentIdNo = retVal
                CallByName(DataModel, IdFieldName, CallType.Set, retVal)
            Else
                parentIdNo = CallByName(DataModel, IdFieldName, CallType.Get)
            End If
            updateReturnValue = Model.DelUpdateTvp(DtUpdateTable, parentIdNo)
            If updateReturnValue >= 0 AndAlso DtInsertTable.Rows.Count > 0 Then
                For Each row As DataRow In DtInsertTable.Rows
                    row.Item("JournalIdNo") = parentIdNo
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

        Public Function GetJournalItems(journalIdNo As Integer) As List(Of JournalItemModel)
            Return Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function UpdateGlReferenceNumber() As String
            GlobalVariables.Mapper.Map(View, DataModel)
            Return ModelPresenter.UpdateGlReferenceNumber(DataModel)
        End Function

        Protected Overrides Function DataIsValid() As Boolean
            Dim retValue = False
            If MyBase.DataIsValid() Then
                'Dim cPayeeType As String
                Dim cashAccount As String = EnumToSpecialAccount(SpecialAccountSelection.Bank) + "|" + EnumToSpecialAccount(SpecialAccountSelection.Cash) + "|" + EnumToSpecialAccount(SpecialAccountSelection.PettyCashAccount)
                'Dim specialAccount As String
                'Dim chart As ChartModel
                'retValue = True
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("Cash Disbursement", "LastPosting", "TransactionName", "LastPostingDate")
                If Messaging.IsDateRangeValid("Cash Disbursement", DataModel.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                Else
                    If PaymentTypeToEnum(DataModel.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                        Dim totalBalance As Decimal
                        For Each item In DataModel.CadOiItems
                            totalBalance += item.Balance
                        Next
                        If CadOiItemDataIsValid() Then
                            retValue = True
                        Else
                            Dim index As Int16 = 0
                            For Each item In DataModel.CadOiItems
                                If item.Errors IsNot Nothing Then
                                    DataModel.CadOiItems.ErrorText = String.Join(",", DataModel.CadOiItems(index).Errors)
                                Else
                                    DataModel.CadOiItems.ErrorText = ""
                                End If
                                index += 1
                            Next
                        End If
                    End If
                    If retValue Then
                        retValue = JournalItemDataIsValid(cashAccount, retValue)
                        If retValue Then
                            retValue = JournalItemDataIsValid(cashAccount, retValue)
                        End If
                    End If
                End If
            End If
            Return retValue
        End Function

        Private Function JournalItemDataIsValid(cashAccount As String, retValue As Boolean) As Boolean
            Dim chart As ChartModel
            Dim specialAccount As String
            Dim cPayeeType As String

            For Each item In DataModel.JournalItems
                chart = GetChart(item.AccountIdNo)
                specialAccount = chart.SpecialAccount
                If item.AccountIdNo = 0 AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                    MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                    retValue = False
                    Exit For
                ElseIf specialAccount IsNot Nothing AndAlso cashAccount.Contains(specialAccount) Then
                    Dim lineNumber As String = item.Sequence.ToString()
                    Dim caption = "Invalid Entry!"
                    Dim message = Messaging.GetMessage(True, "MsgCashAccountsNotAllowed", "Error on line <{lineNumber}>. Cash accounts not allowed for this transaction.", "Invalid Entry")
                    message = message.Interpolate(Function(x) lineNumber)
                    Messaging.Show(message, caption)
                    retValue = False
                Else
                    cPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                    If Not String.IsNullOrEmpty(cPayeeType) AndAlso PayeeTypeToEnum(cPayeeType) <> PayeeTypeSelection.Supplier Then
                        Dim lineNumber = Format(item.Sequence, "0")
                        Dim entryNames = Messaging.TranslateCaption("Accounts Receivables/Employee Loans")
                        Dim caption = "Invalid Entry"
                        Dim variables As String() = {"lineNumber", lineNumber, "entryNames", entryNames}
                        Dim message = Messaging.GetMessage(True, "MsgAccountsNotAllowed", "Error on line {lineNumber}. Sorry {entryNames} not allowed for this transaction!", caption)
                        caption = Messaging.TranslateCaption(caption)
                        Messaging.Show(message, caption, variables, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        retValue = False
                    End If
                End If
            Next
            Return retValue
        End Function

        Public Function CadOiItemDataIsValid() As Boolean
            'ByRef cadOiItems As BindingSource, ByVal appliedAmount As Decimal, ByVal unAppliedAmount As Decimal, ByVal totalBalance As Decimal)
            Dim retVal = True
            Dim index As Int16 = 0
            For Each item In DataModel.CadOiItems
                If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                    If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
                       (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
                        Dim errorMsg = String.Format("Error in line {0:N0}. Applied amount and discount exceeds balance.", item.Sequence.ToString())
                        MessageBox.Show(errorMsg)
                        DataModel.cadOiItems(index).errors.Add(errorMsg)
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
                        retVal = False
                        Exit For
                    Else
                        ' clear error message
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = ""
                        If DataModel.CadOiItems(index).Errors IsNot Nothing Then
                            DataModel.CadOiItems(index).errors.Clear()
                        End If
                    End If
                End If
                index += 1
            Next
            If retVal Then
                If DataModel.UnAppliedAmount <> 0 Then
                    Dim totalBalance As Decimal = 0
                    For Each item In DataModel.CadOiItems
                        totalBalance += item.Balance
                    Next
                    If totalBalance > 0 Then
                        If DataModel.unAppliedAmount > 0 Then
                            MessageBox.Show($"Payment not yet fully applied. Cannot save entry unless amount is fully applied.")
                            retVal = False
                        Else
                            MessageBox.Show($"Payment is over applied. Cannot save entry please reduce the applied payment.")
                            retVal = False
                        End If
                    Else
                        If MessageBox.Show($"Amount not yet fully applied or no more unpaid invoices for this supplier. Do you want to make the excess payment as an advance payment?", $"Save Advance Payment",
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

        Private Sub MakeJournalItem()
            If PaymentTypeToEnum(DataModel.PaymentType) = PaymentTypeSelection.AccountsPayable Then
                Dim aAccountIdNo As Integer() = {}
                Dim aAmount() As Decimal = {}
                Dim aAdded() As Boolean = {}
                Dim aDiscountTaken() As Decimal = {}
                Dim nSize As Integer = 0
                Dim nIndex As Integer
                ' summarize paid invoices per account
                For Each item In DataModel.CadOiItems
                    Dim nAccountIdNo As Integer
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
                For Each item In DataModel.JournalItems
                    If nCounter = 0 Then
                        item.JournalIdNo = DataModel.IdNo
                        item.Sequence = 1
                        item.AccountIdNo = DataModel.AccountIdNo
                        item.Credit = If(DataModel.Amount < 0, 0, DataModel.Amount)
                        item.Debit = If(DataModel.Amount < 0, DataModel.Amount * -1, 0)
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
                If DataModel.JournalItems Is Nothing Or DataModel.JournalItems.Count = 0 Then
                    Dim item As New JournalItemModel With {
                            .JournalIdNo = DataModel.IdNo,
                            .Sequence = 1,
                            .AccountIdNo = DataModel.AccountIdNo,
                            .Credit = If(DataModel.Amount < 0, 0, DataModel.Amount),
                            .Debit = If(DataModel.Amount < 0, DataModel.Amount * -1, 0),
                            .ProfitCenterIdNo = 0,
                            .Notes = ""
                            }
                    DataModel.JournalItems.Add(item)
                End If
                ' apply now the invoice payment summarized above for each existing AP account
                For i = 0 To aAccountIdNo.Count() - 1
                    For Each ji In DataModel.JournalItems
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
                For Each ji In DataModel.JournalItems
                    ' ignore the first line entry (this is for the check account)
                    If ji.Sequence <> 1 Then
                        If ji.AccountIdNo = DataModel.DiscountAccountIdNo Then
                            ji.Debit = If(DataModel.DiscountTaken < 0, DataModel.DiscountTaken * -1, 0)
                            ji.Credit = If(DataModel.DiscountTaken < 0, 0, DataModel.DiscountTaken)
                            found = True
                        End If
                    End If
                Next
                If Not found Then
                    ' if discount account is not found add a Discount Account Journal Entry and
                    ' add the discount taken amount.
                    If DataModel.DiscountTaken <> 0 Then
                        Dim item As New JournalItemModel With {
                                .JournalIdNo = DataModel.IdNo,
                                .Sequence = 0,
                                .AccountIdNo = DataModel.DiscountAccountIdNo,
                                .Credit = If(DataModel.DiscountTaken < 0, 0, DataModel.DiscountTaken),
                                .Debit = If(DataModel.DiscountTaken < 0, DataModel.DiscountTaken * -1, 0),
                                .ProfitCenterIdNo = 0,
                                .Notes = ""
                                }
                        DataModel.JournalItems.Add(item)
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
                        Dim ji As New JournalItemModel With {
                                .JournalIdNo = DataModel.IdNo,
                                .Sequence = 0,
                                .AccountIdNo = aAccountIdNo(nCounter),
                                .Credit = If(nAmount < 0, nAmount * -1, 0),
                                .Debit = If(nAmount < 0, 0, nAmount),
                                .ProfitCenterIdNo = 0,
                                .Notes = ""
                                }
                        DataModel.JournalItems.Add(ji)
                    End If
                    nCounter = nCounter + 1
                Next
                If DataModel.UnApplied > 0 Then
                    ' if invoice not yet fully applied, then save the
                    ' unApplied amount to the "Advances to Supplier" account
                    ' check existing entries for the "Advances to Supplier" account
                    Dim unAppliedSwitch As Int16 = 0
                    For Each item In DataModel.JournalItems
                        ' get the last matching idno for accounts with advancestosupplierAccountIdNo
                        If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.Debit = 0 And item.Credit = 0 And item.OriginalAmount > 0 Then
                            ' debit and credit must be zero otherwise that account has already been used above
                            item.Credit = 0
                            item.Debit = DataModel.UnApplied
                            unAppliedSwitch = 1
                            Exit For
                        End If
                    Next
                    If unAppliedSwitch = 0 Then
                        ' advance payment journal entry not yet created
                        Dim jiModel As New JournalItemModel With {
                            .JournalIdNo = DataModel.IdNo,
                            .Sequence = 0,
                            .AccountIdNo = _advancesToSupplierAccountIdNo,
                            .Credit = 0,
                            .Debit = DataModel.UnApplied,
                            .ProfitCenterIdNo = 0,
                            .Notes = ""
                            }
                        DataModel.JournalItems.Add(jiModel)
                    End If
                Else
                    ' no advance payment so no advances to Supplier Account
                End If
            Else
                DataModel.cadOiItems.Clear()
            End If
            'UpdateTotals()
        End Sub

        Public Function GetCadOiItems(cadOiIdNo As Integer) As List(Of CadOiItemModel)
            Return Model.GetRecordsWithIdNo(Of CadOiItemModel)(cadOiIdNo, "Sequence")
        End Function

        'Public Sub OnAfterRecordRetrieval(modelData As CashDisbursementJournalModel) Handles MyBase.AfterRecordRetrieval
        '    'modelData.JournalItems = GetJournalItems(modelData.IdNo)
        '    'modelData.CadOiItems = GetCadOiItems(modelData.IdNo)
        '    'For Each item In modelData.JournalItems
        '    '    modelData.TotalDebits += item.Debit
        '    '    modelData.TotalCredits += item.Credit
        '    'Next
        '    Dim jiDao = New CashDisbursementJournalItemDao
        '    Dim oiDao = New CadOiItemDao
        '    Dim ji = jiDao.GetRecordsWithIdNo(modelData.IdNo, "sequence")
        '    Dim oi = oiDao.GetRecordsWithIdNo(modelData.IdNo, "sequence")
        '    GlobalVariables.Mapper.Map(ji, modelData.JournalItems)
        '    GlobalVariables.Mapper.Map(oi, modelData.CadOiItems)
        'End Sub

    End Class

End Namespace