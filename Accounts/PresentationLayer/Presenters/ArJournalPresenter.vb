Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Forms
Imports AATM.Accounts.PresentationLayer.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
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

        End Sub

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            If IsEmpty(View.ReferenceNo) Then
                UpdateGlReferenceNumber()
            End If
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
                    nRowCount = nRowCount + 1
                End If
            Next
        End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            UpdateTotals()
        End Sub

        Public Function SaveChildren(ByRef retVal As Integer) Handles MyBase.ParentRecordAddedSuccessfully, MyBase.ParentRecordUpdatedSuccessfully
            Dim insertReturnValue
            Dim updateReturnValue
            Dim parentIdNo As Int32
            If AddMode Then
                parentIdNo = retVal
                CallByName(View, IdFieldName, CallType.Set, retVal)
            Else
                parentIdNo = CallByName(View, IdFieldName, CallType.Get)
            End If
            updateReturnValue = ModelPresenter.DelUpdateTvp(DtUpdateTable, parentIdNo)
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
            Dim newJournalItem As List(Of JournalItemModel)
            If AddMode Then
                newJournalItem = ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(View.IdNo, "Sequence")
                For Each item In newJournalItem
                    If IsAccountsReceivableAccount(item.AccountIdNo) Then
                        AddArOpenInvoice(item, "AR")
                    End If
                Next
            Else
                newJournalItem = ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(View.IdNo, "Sequence")
                Dim newItem
                Dim oldItem
                Dim newIsAr
                Dim oldIsAr
                Dim oldJournalItem As List(Of JournalItemModel)
                If Not AddMode Then
                    oldJournalItem = OriginalModel.Journalitems
                Else
                    oldJournalItem = Nothing
                End If
                For Each oldItem In oldJournalItem
                    ' deletion of paid A.P. entries not allowed (see UserDeletingRow - sub  below) therefore all entries here are unpaid
                    ' so no problem on deletion
                    oldIsAr = IsAccountsReceivableAccount(oldItem.AccountIdNo)
                    If oldIsAr Then
                        ' this item is AR
                        newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
                        If newItem Is Nothing Then
                            ' item was deleted
                            DeleteArOpenInvoice(oldItem.OpenInvoiceIdNo)
                        Else
                            ' item is found
                            newIsAr = IsAccountsReceivableAccount(newItem.AccountIdNo)
                            If newIsAr Then
                                ' nothing to do
                            Else
                                ' new is changed from AR to non-AR
                                DeleteArOpenInvoice(oldItem.OpenInvoiceIdNo)
                            End If
                        End If
                    Else
                        ' this item is Non-AR
                        newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
                        If newItem Is Nothing Then
                            ' item is deleted just ignore Non-AR
                        Else
                            ' old item still in new
                            newIsAr = IsAccountsReceivableAccount(newItem.AccountIdNo)
                            If newIsAr Then
                                AddArOpenInvoice(newItem, "AR")
                            Else
                                ' new is also Non-AR
                                ' nothing to do
                            End If
                        End If
                    End If
                Next
                For Each newItem In newJournalItem
                    newIsAr = IsAccountsReceivableAccount(newItem.AccountIdNo)
                    oldItem = Nothing
                    For Each item In OriginalModel.JournalItems
                        If newItem.IdNo = item.IdNo Then
                            ' meaning it is the same record
                            oldItem = item
                            Exit For
                        End If
                    Next
                    'oldItem = OriginalModel.JournalItems.Find(Function(c) c.IdNo = x)
                    If oldItem Is Nothing Then
                        ' this item is new
                        If newIsAr Then
                            ' this new item is an AR
                            AddArOpenInvoice(newItem, "AR")
                        Else
                            ' non - AR nothing to do
                        End If
                    Else
                        ' old item, already taken off in first (oldItem) for-loop
                    End If
                Next
            End If
            If retVal > 0 Then
                If IsEmpty(View.ReferenceNo) Then
                    UpdateGlReferenceNumber()
                End If
            End If
            Return retVal
        End Function

        Public Sub UpdateFirstLine()
            If EditMode Or AddMode Then
                If View.JournalItems.Count() = 0 Then
                    View.JournalItems = New List(Of JournalItemView)
                    View.JournalItems.Add(NewJournalItem)
                End If
                For Each item In View.JournalItems
                    item.JournalIdNo = View.IdNo
                    item.Sequence = 1
                    item.AccountIdNo = View.AccountIdNo
                    Dim tranType As String = TransactionTypeToEnum(View.TransactionType)
                    If tranType = TransactionTypeSelection.Invoice Or tranType = TransactionTypeSelection.Credit Then
                        item.Debit = View.Amount
                        item.Credit = 0
                    Else
                        item.Debit = 0
                        item.Credit = View.Amount
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
                Dim cashAccount As String = EnumToSpecialAccount(SpecialAccountSelection.Bank) + "|" + EnumToSpecialAccount(SpecialAccountSelection.Cash) + "|" + EnumToSpecialAccount(SpecialAccountSelection.PettyCashAccount)
                Dim specialAccount As String
                Dim chart As ChartModel
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("AR Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If Messaging.IsDateRangeValid("Accounts Receivable", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                Else
                    For Each item In View.JournalItems
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
                            If Not String.IsNullOrEmpty(cPayeeType) AndAlso PayeeTypeToEnum(cPayeeType) <> PayeeTypeSelection.Customer Then
                                Dim lineNumber = Format(item.Sequence, "0")
                                Dim entryNames = Messaging.TranslateCaption("Accounts Payables/Employee Loans")
                                Dim caption = "Invalid Entry"
                                Dim variables As String() = {"lineNumber", lineNumber, "entryNames", entryNames}
                                Dim message = Messaging.GetMessage(True, "MsgAccountsNotAllowed", "Error on line {lineNumber}. Sorry {entryNames} not allowed for this transaction!", caption)
                                caption = Messaging.TranslateCaption(caption)
                                Messaging.Show(message, caption, variables, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                retValue = False
                            End If
                        End If
                    Next
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
            language = Strings.Left(curCulture.Name,curculture.name.Indexof("-"))
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))

            transactionAmount = New ToWord(View.Amount, currencies(0)).ConvertToArabic()
            View.TotalCredits = 0
            For Each item In View.JournalItems
                View.TotalCredits = View.TotalCredits + item.Credit
            Next
            totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Dim cForm As New ReportForm("Accounts Receivable Journal.Rpt", View.IdNo, "ArJournalIdNo", transactionAmount, "TotalCreditAmountInWords", totalCreditAmount, "TotalLineAmountInWords",language,"Language")
            cForm.Show()
        End Sub


    End Class

End Namespace