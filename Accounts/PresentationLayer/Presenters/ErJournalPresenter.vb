Imports System.Globalization
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

    Public Class ErJournalPresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IErJournalView, TM)
        Implements ISubscriber(Of DataChanged)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _erJournalItemService As New AccountsService("JournalItem", Nothing, {"ErJournalItem_View", "dbo.UpdateErJournalItemTVP", "dbo.InsertErJournalItemTVP"})

        Public Sub New(view As IErJournalView)
            MyBase.New(view)
            TableName = "ErJournal"
            WithTreeView = False
            Service = New AccountsService("ErJournal")
            SortOrderKey = "IdNo"
            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Credit", GetType(Decimal))
            DtInsertTable.Columns.Add("Debit", GetType(Decimal))
            DtInsertTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Notes", GetType(String))
            DtInsertTable.Columns.Add("PayIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Credit", GetType(Decimal))
            DtUpdateTable.Columns.Add("Debit", GetType(Decimal))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("PayIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))

        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateLookupData("Account", "AccountsByCode", "DetailAccount=1")
            CreateLookupData("RevCostCenter", "RevCostCentersByCode")
            CreateDataSource("Employee", "EmployeeIdNo")
            CreateEnumDataSource(Of TransactionTypeSelection)("TransactionType")
            CreateSpecialAccountDataSource("AccountIdNo", {EnumToCode(SpecialAccountSelection.EmployeeLoan)})
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf JournalItemFilter)
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("JournalIdNo") = View.IdNo
            workRow("AccountIdNo") = itemDataView.AccountIdNo
            workRow("Debit") = itemDataView.Debit
            workRow("Credit") = itemDataView.Credit
            workRow("PayIdNo") = itemDataView.PayIdNo
            workRow("RevCostCenterIdNo") = itemDataView.RevCostCenterIdNo
            workRow("Notes") = If(itemDataView.Notes, "")
        End Sub

        Public Function JournalItemFilter(ByVal obj As Object) As Boolean
            If (obj.AccountIdNo Is Nothing Or obj.AccountIdNo = 0) AndAlso obj.Debit = 0 AndAlso obj.Credit = 0 Then
                Return False
            End If
            Return True
        End Function

        Public Function SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_erJournalItemService, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 Then
                If IsEmpty(View.ReferenceNo) Then
                    retVal = UpdateGlReferenceNumber()
                End If
            End If
            Return retVal
        End Function

        Public Sub UpdateFirstLine()
            If EditMode Or AddMode Then
                If View.JournalItems.Count() = 0 Then
                    View.JournalItems = New List(Of JournalItemView) From {
                        FirstJournalItem()
                    }
                End If
                For Each item In View.JournalItems
                    MakePayTypeAndSpecialAccount(item, View.AccountIdNo)
                    item.Sequence = 1
                    item.AccountIdNo = View.AccountIdNo
                    Dim tranType As String = CodeToEnum(Of TransactionTypeSelection)(View.TransactionType)
                    If tranType = TransactionTypeSelection.Invoice Or tranType = TransactionTypeSelection.Debit Then
                        If item.Debit = 0 Or CountErItems() <= 1 Then
                            item.Debit = View.Amount
                            item.Credit = 0
                        End If
                    Else
                        If item.Credit = 0 Or CountErItems() <= 1 Then
                            item.Debit = 0
                            item.Credit = View.Amount
                        End If
                    End If
                    ' ER accounts are asset accounts so no revenue cost centers
                    item.RevCostCenterIdNo = 0
                    Exit For
                Next
            End If
        End Sub

        Public Function CountErItems()
            Dim nCount = 0
            For Each item In View.JournalItems
                If item.SpecialAccount = EnumToCode(SpecialAccountSelection.EmployeeLoan) Then
                    nCount = nCount + 1
                End If
            Next
            Return nCount
        End Function

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
                Dim cashAccount As String = EnumToCode(SpecialAccountSelection.Bank) + "|" + EnumToCode(SpecialAccountSelection.CheckingAccount) + "|" + EnumToCode(SpecialAccountSelection.Cash) + "|" + EnumToCode(SpecialAccountSelection.PettyCashAccount)
                Dim invalidAccounts As String = EnumToCode(SpecialAccountSelection.AccountsReceivable) + "|" + EnumToCode(SpecialAccountSelection.AccountsPayable) + "|" +
                                                EnumToCode(SpecialAccountSelection.AdvancesToSupplier) + "|" + EnumToCode(SpecialAccountSelection.CustomerAdvances) + "|" +
                                                EnumToCode(SpecialAccountSelection.AccountsPayableDiscount) + "|" + EnumToCode(SpecialAccountSelection.AccountsReceivableDiscount) + "|"
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Service.GetRecordFieldWithKeyG(Of DateTime?)("ER Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If IsDateRangeValid("Employee Receivable", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                Else
                    Dim nTotalEr As Decimal = 0
                    For Each item In View.JournalItems
                        If item.SpecialAccount = EnumToCode(SpecialAccountSelection.EmployeeLoan) Then
                            If View.TransactionType = "I" Or View.TransactionType = "D" Then
                                nTotalEr = nTotalEr + item.Debit - item.Credit
                            Else
                                nTotalEr = nTotalEr + item.Credit - item.Debit
                            End If
                        End If
                        If item.AccountIdNo Is Nothing Or item.AccountIdNo = 0 AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Messaging.ShowPmMessage(True, "MsgBlankAccountIdNotAllowed", {"lineNumber", lineNumber})
                            retValue = False
                            Exit For
                        ElseIf item.SpecialAccount IsNot Nothing AndAlso cashAccount.Contains(item.SpecialAccount) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Messaging.ShowPmMessage(True, "MsgCashAccountsNotAllowed", {"lineNumber", lineNumber})
                            retValue = False
                        ElseIf item.SpecialAccount IsNot Nothing AndAlso invalidAccounts.Contains(item.SpecialAccount) Then
                            Dim lineNumber = Format(item.Sequence, "0")
                            Dim entryNames = Messaging.TranslateCaption("Accounts Payables/Accounts Receivable")
                            Messaging.ShowPmMessage(True, "MsgAccountsNotAllowed", {"lineNumber", lineNumber, "entryNames", entryNames})
                            retValue = False
                        End If
                    Next
                    If nTotalEr <> View.Amount Then
                        Messaging.Show(True, "MsgTotalErMismatch")
                        retValue = False
                    End If
                End If
            End If
            Return retValue
        End Function

        Private Function FirstJournalItem()
            Dim item As New JournalItemView With {
                    .JournalIdNo = View.IdNo,
                    .Sequence = 0,
                    .AccountIdNo = View.AccountIdNo,
                    .Debit = View.Amount,
                    .Credit = 0,
                    .RevCostCenterIdNo = 0,
                    .Notes = "",
                    .SpecialAccount = Nothing,
                    .PayeeType = Nothing
                    }
            Return item
        End Function

        Public Overrides Sub GoPrintRecord()
            Dim transactionAmount As String
            Dim totalErAmount As String
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
            If language = "ar" Then
                totalErAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalErAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            Dim cForm As New ReportForm("Employee Receivable Journal.Rpt", View.IdNo, "ErJournalIdNo", transactionAmount, "ERAmountInWords", totalErAmount, "TotalLineAmountInWords", language, "Language")
            cForm.Show()
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.JournalItems IsNot Nothing And View.JournalItems.Count() > 0 Then
                DtUpdateTable.Clear()
                _erJournalItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub
        Public Sub OnApJournalDataChangedEventHandler(ByRef eventType As DataChanged) Implements ISubscriber(Of DataChanged).OnEventHandler
            With eventType.BindingSource
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    Dim accountId = eventType.BindingSource.Current.AccountIdNo
                    Select Case eventType.PropertyName
                        Case $"AccountIdNo"
                            MakePayTypeAndSpecialAccount(eventType.BindingSource.Current, accountId)
                            eventType.BindingSource.ResetItem(eventType.Row)
                        Case $"Debit"
                            MakeDebitAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Debit)
                            eventType.BindingSource.ResetItem(eventType.Row)
                        Case $"Credit"
                            MakeCreditAmount(eventType.BindingSource.Current, eventType.BindingSource.Current.Credit)
                            eventType.BindingSource.ResetItem(eventType.Row)
                    End Select
                End If
            End With
        End Sub

    End Class

End Namespace