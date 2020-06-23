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

        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue As Boolean = False
            If MyBase.IsBizDataValid() Then
                Dim cashAccount As String = EnumToSpecialAccount(SpecialAccountSelection.AccountsPayable) + "|" + EnumToSpecialAccount(SpecialAccountSelection.AccountsReceivable) +
                                            "|" + EnumToSpecialAccount(SpecialAccountSelection.CustomerAdvances) + "|" + EnumToSpecialAccount(SpecialAccountSelection.AccountsPayableDiscount) +
                                            "|" + EnumToSpecialAccount(SpecialAccountSelection.AccountsReceivableDiscount) + "|" + EnumToSpecialAccount(SpecialAccountSelection.AdvancesToSupplier) +
                                            "|" + EnumToSpecialAccount(SpecialAccountSelection.CustomerAdvances) + "|" + EnumToSpecialAccount(SpecialAccountSelection.EmployeeLoan)
                Dim specialAccount As String
                Dim chart As ChartModel
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("General Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If Messaging.IsDateRangeValid("Cash Disbursement", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
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
                            Dim entryNames As String = Messaging.TranslateCaption("Accounts Payable") + "/" + Messaging.TranslateCaption("Accounts Receivable") + "/" + Messaging.TranslateCaption("Employee Accounts")
                            Dim variables = {"lineNumber", lineNumber, "entryNames", entryNames}
                            Dim message = Messaging.Show(True, "MsgAccountsNotAllowed", variables)
                            retValue = False
                        End If
                    Next
                End If
            End If
            Return retValue
        End Function

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If View.JournalItems Is Nothing OrElse View.JournalItems.Count() = 0 Then
                If MessageBox.Show(AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal_Ask_To_Save,
                                   AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    CancelSave = True
                End If
            End If
            If Not CancelSave Then
                'If AddMode Then
                '    View.IdNo = passedValue
                'End If
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
                        workRow("ProfitCenterIdNo") = ji.ProfitCenterIdNo
                        workRow("Notes") = If(ji.Notes, "")
                        If ji.IdNo <= 0 Then
                            DtInsertTable.Rows.Add(workRow)
                        Else
                            DtUpdateTable.Rows.Add(workRow)
                        End If
                        nRowCount = nRowCount + 1
                    End If
                Next
            End If
        End Sub

        Public Function SaveChildren(ByRef retVal As Integer) Handles MyBase.ParentRecordAddedSuccessfully, MyBase.ParentRecordUpdatedSuccessfully
            Dim insertReturnValue
            Dim updateReturnValue
            Dim headerIdNo As Int32
            If AddMode Then
                headerIdNo = retVal
                CallByName(View, IdFieldName, CallType.Set, retVal)
            Else
                headerIdNo = CallByName(View, IdFieldName, CallType.Get)
            End If
            updateReturnValue = ModelPresenter.DelUpdateTvp(DtUpdateTable, headerIdNo)
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
            If retVal > 0 Then
                If IsEmpty(View.ReferenceNo) Then
                    UpdateGlReferenceNumber()
                End If
            End If
            Return retVal
        End Function

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public Overrides Sub GoPrintRecord()
            Dim totalCreditAmount As String
            Dim currencies As New List(Of CurrencyInfo)()
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            View.TotalCredits = 0
            For Each item In View.JournalItems
                View.TotalCredits = View.TotalCredits + item.Credit
            Next
            totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Dim cForm As New ReportForm("General Journal.Rpt", View.IdNo, "GeneralJournalIdNo", totalCreditAmount, "TotalLineAmountInWords")

            cForm.Show()
        End Sub


    End Class

End Namespace