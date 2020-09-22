Imports System.Globalization
Imports System.Windows.Forms.VisualStyles
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class GeneralJournalPresenter
        Inherits AccountsPresenter(Of IGeneralJournalView, GeneralJournalModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _gjJournalItemModel As New ModelAccounts("GeneralJournalItem")
        Private _closingEntry As Boolean
        Public Sub New(view As IGeneralJournalView, closingEntry As Boolean)
            MyBase.New(view)
            _closingEntry = closingEntry
            ModelPresenter = New ModelAccounts("GeneralJournal")
            If Not view.ClosingJournal Then
                TableName = "GeneralJournalNormal_View"
            Else
                TableName = "GeneralJournalClosing_View"
            End If
            SortOrderKey = "IdNo"
            OriginalModel = New GeneralJournalModel()
            DataModel = New GeneralJournalModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

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

        End Sub

        Public Overrides Sub GoPrintRecord()
            Dim totalCreditAmount As String
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))

            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            View.TotalCredits = 0
            For Each item In View.JournalItems
                View.TotalCredits = View.TotalCredits + item.Credit
            Next
            If language = "ar" Then
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If

            Dim cForm As New ReportForm("General Journal.Rpt", View.IdNo, "GeneralJournalIdNo", totalCreditAmount, "TotalLineAmountInWords", language, "Language")

            cForm.Show()
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf JournalItemFilter)
            End If
        End Sub

        Private Sub FillData(ByRef item As Object, ByVal idNo As Integer, ByRef workRow As DataRow)
            workRow("JournalIdNo") = View.IdNo
            workRow("AccountIdNo") = item.AccountIdNo
            workRow("Debit") = item.Debit
            workRow("Credit") = item.Credit
            workRow("RevCostCenterIdNo") = item.RevCostCenterIdNo
            workRow("Notes") = If(item.Notes, "")
        End Sub

        Public Function JournalItemFilter(ByVal obj As Object) As Boolean
            If (obj.AccountIdNo Is Nothing Or obj.AccountIdNo = 0) AndAlso obj.Debit = 0 AndAlso obj.Credit = 0 Then
                Return True
            End If
            Return False
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_gjJournalItemModel, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 And IsEmpty(View.ReferenceNo) Then
                GlobalVariables.Mapper.Map(View, DataModel)
                retVal = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue As Boolean = False
            If MyBase.IsBizDataValid() Then
                Dim cashAccount As String = GetEnumCode(SpecialAccountSelection.AccountsPayable) + "|" + GetEnumCode(SpecialAccountSelection.AccountsReceivable) +
                                            "|" + GetEnumCode(SpecialAccountSelection.CustomerAdvances) + "|" + GetEnumCode(SpecialAccountSelection.AccountsPayableDiscount) +
                                            "|" + GetEnumCode(SpecialAccountSelection.AccountsReceivableDiscount) + "|" + GetEnumCode(SpecialAccountSelection.AdvancesToSupplier) +
                                            "|" + GetEnumCode(SpecialAccountSelection.CustomerAdvances) + "|" + GetEnumCode(SpecialAccountSelection.EmployeeLoan)
                Dim specialAccount As String
                Dim chart As ChartModel
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("General Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If View.JournalItems Is Nothing OrElse View.JournalItems.Count() = 0 Then
                    Messaging.Show(True, "MsgCannotSaveAnEmptyTransaction", "Sorry, cannot save an empty transaction!", "Error")
                    retValue = False
                ElseIf IsDateRangeValid("General Journal", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                Else
                    For Each item In View.JournalItems
                        If item.AccountIdNo Is Nothing OrElse item.AccountIdNo = 0 Then
                            specialAccount = Nothing
                        Else
                            chart = GetChart(item.AccountIdNo)
                            specialAccount = chart.SpecialAccount
                        End If
                        If item.AccountIdNo = 0 AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                            MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                            retValue = False
                            Exit For
                        ElseIf specialAccount IsNot Nothing AndAlso cashAccount.Contains(specialAccount) Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Dim entryNames As String = Messaging.TranslateCaption("Accounts Payable") + "/" + Messaging.TranslateCaption("Accounts Receivable") + "/" + Messaging.TranslateCaption("Employee Accounts")
                            Dim variables = {"lineNumber", lineNumber, "entryNames", entryNames}
                            Messaging.ShowParametrizedMessage(True, "MsgAccountsNotAllowed", variables)
                            retValue = False
                        End If
                    Next
                End If
            End If
            Return retValue
        End Function
    End Class

End Namespace