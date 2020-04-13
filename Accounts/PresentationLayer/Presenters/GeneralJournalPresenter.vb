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

        Public Sub New(view As IGeneralJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("GeneralJournal")
            TableName = "GeneralJournal"
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
            DtUpdateTable.Columns.Add("IDNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

        'Public Property JournalItemsPresenter As GeneralJournalItemsPresenter

        'Public Overrides Function ChangesMade() As Boolean
        '    Dim generalJournalChangesMade As Boolean
        '    If ObjectsCompare(OriginalModel, View) Then
        '        If JournalItemsPresenter.ChangesMadeInJournalItem Then
        '            generalJournalChangesMade = True
        '        Else
        '            generalJournalChangesMade = False
        '        End If
        '    Else
        '        generalJournalChangesMade = True
        '    End If
        '    Return generalJournalChangesMade
        'End Function

        Protected Overrides Function DataIsValid() As Boolean
            Dim retValue As Boolean = False
            If MyBase.DataIsValid() Then
                Dim cashAccount As String = EnumToSpecialAccount(SpecialAccountSelection.AccountsPayable) + "|" + EnumToSpecialAccount(SpecialAccountSelection.AccountsReceivable) +
                                            "|" + EnumToSpecialAccount(SpecialAccountSelection.CustomerAdvances) + "|" + EnumToSpecialAccount(SpecialAccountSelection.AccountsPayableDiscount) +
                                            "|" + EnumToSpecialAccount(SpecialAccountSelection.AccountsReceivableDiscount) + "|" + EnumToSpecialAccount(SpecialAccountSelection.AdvancesToSupplier) +
                                            "|" + EnumToSpecialAccount(SpecialAccountSelection.CustomerAdvances) + "|" + EnumToSpecialAccount(SpecialAccountSelection.EmployeeLoan)
                Dim specialAccount As String
                Dim chart As ChartModel
                retValue = True
                For Each item In DataModel.JournalItems
                    chart = GetChart(item.AccountIdNo)
                    specialAccount = chart.SpecialAccount
                    If item.AccountIdNo = 0 Then
                        MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                        retValue = False
                        Exit For
                    ElseIf specialAccount IsNot Nothing AndAlso cashAccount.Contains(specialAccount) Then
                        Dim lineNumber As String = item.Sequence.ToString()
                        Dim caption = "Invalid Entry!"
                        Dim variables = {"lineNumber", lineNumber}
                        Dim message = Messaging.Show(True, "MsgApArEmAccountsNotAllowed", "Error on line <{lineNumber}>. Supplier (A.P.)/Customer (A.R.)/Employee accounts not allowed for this transaction.", "Invalid Account Entry", variables)
                        retValue = False
                    End If
                Next
            End If
            Return retValue
        End Function

        'Public Shadows Sub Display(idNo As Integer)
        '    Dim modelData As GeneralJournalModel
        '    modelData = Model.GetRecordById(Of GeneralJournalModel)(idNo)
        '    If modelData IsNot Nothing Then
        '        OriginalModel = modelData
        '        If idNo <> 0 Then
        '            GlobalVariables.Mapper.Map(modelData, View)
        '        End If
        '    End If
        'End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            'If AddMode Then
            '    txtJournalCode.Text = AccountStrings.GeneralJournalPrefix
            'End If
            If DataModel.JournalItems Is Nothing OrElse DataModel.JournalItems.Count() = 0 Then

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
                '    DataModel.IdNo = passedValue
                'End If
                If DtInsertTable IsNot Nothing Then
                    DtInsertTable.Clear()
                End If
                If DtUpdateTable IsNot Nothing Then
                    DtUpdateTable.Clear()
                End If
                Dim nRowCount = 1
                For Each ji In DataModel.JournalItems
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
                    nRowCount = nRowCount + 1
                Next
            End If
        End Sub

        'Public Sub OnAfterSave() Handles MyBase.AfterSave
        '    'If IsEmpty(DataModel.ReferenceNo) Then
        '    '    UpdateGlReferenceNumber()
        '    'End If
        '    'If AddMode Then
        '    '    GoLastRecord()
        '    'End If
        'End Sub

        Public Function SaveChildren(ByVal retVal As Integer) Handles MyBase.ParentRecordAddedSuccessfully, MyBase.ParentRecordUpdatedSuccessfully
            Dim insertReturnValue
            Dim updateReturnValue
            If AddMode Then
                CallByName(DataModel, IdFieldName, CallType.Set, retVal)
            End If
            updateReturnValue = ModelPresenter.DelUpdateTvp(DtUpdateTable, DataModel.IdNo)
            If updateReturnValue >= 0 AndAlso DtInsertTable.Rows.Count > 0 Then

                For Each row As DataRow In DtInsertTable.Rows
                    row.Item("JournalIdNo") = retVal
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
                If IsEmpty(DataModel.ReferenceNo) Then
                    UpdateGlReferenceNumber()
                End If
                'If AddMode Then
                '    GoLastRecord()
                'End If
            End If
            Return retVal
        End Function

        'Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
        '    'txtJournalCode.Text = AccountStrings.CashDisbursementJournalPrefix
        '    DataModel.TransactionDate = Date.Now()
        '    DataModel.JournalItems.Clear()
        'End Sub
        Public Sub OnAfterRecordRetrieval(model As GeneralJournalModel) Handles MyBase.AfterRecordRetrieval
            model.TotalDebits = 0
            model.TotalCredits = 0
            If model.JournalItems IsNot Nothing Then
                For Each item In model.JournalItems
                    model.TotalDebits += item.Debit
                    model.TotalCredits += item.Credit
                Next
            End If
        End Sub

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

    End Class

End Namespace