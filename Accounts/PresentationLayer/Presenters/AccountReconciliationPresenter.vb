Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Transactions
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class AccountReconciliationPresenter
        Inherits AccountsPresenter(Of IAccountReconciliationView, AccountReconciliationModel)
        Implements ISubscriber(Of ReconciliationClearEvent),
                   ISubscriber(Of ReconciliationPostingRequestEvent),
                   ISubscriber(Of ReconciliationRefreshRequestEvent),
                   ISubscriber(Of EndingBankBalanceEntryChangedEvent),
                   ISubscriber(Of EndingReconciliationDateChangedEvent)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Public Sub New(view As IAccountReconciliationView)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("AccountReconciliation")
            TableName = "AccountReconciliation"
            SortOrderKey = "IdNo"
            OriginalModel = New AccountReconciliationModel()
            DataModel = New AccountReconciliationModel

            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            DtInsertTable.Columns.Add("AccountReconciliationIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Cleared", GetType(Boolean))
            DtInsertTable.Columns.Add("JournalCode", GetType(String))
            DtInsertTable.Columns.Add("JournalItemIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("AccountReconciliationIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Cleared", GetType(Boolean))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalCode", GetType(String))
            DtUpdateTable.Columns.Add("JournalItemIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))

            SubscribeEvent(Me)

        End Sub

        Public Property MessageBox As Object

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            View.AccountReconciliationItems.Clear()
        End Sub

        Public Sub OnReconciliationItemCheckedChangeEvent(sender, pView)
            Dim x = sender
            Dim y = pView

        End Sub

        'Public Sub CheckIfEditable() Handles MyBase.BeforeEdit
        '    If Posted Then
        '        Messaging.Show(True, "MsgReconciliationAlreadyPosted", $"This Reconciliation entry has already been posted. Edits not allowed!", "Posted Reconciliation")
        '        PresenterObj.CancelEdit = True
        '    End If
        'End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim parentIdNo As Integer
            If AddMode Then
                parentIdNo = retVal
                CallByName(View, IdFieldName, CallType.Set, retVal)
            Else
                parentIdNo = CallByName(View, IdFieldName, CallType.Get)
            End If
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            Dim nRowCount = 1
            For Each ji In View.AccountReconciliationItems
                Dim workRow As DataRow
                If ji.IdNo <= 0 Then
                    workRow = DtInsertTable.NewRow()
                Else
                    workRow = DtUpdateTable.NewRow()
                    workRow("IdNo") = ji.IdNo
                End If
                workRow("AccountReconciliationIdNo") = parentIdNo
                workRow("Cleared") = ji.Cleared
                workRow("JournalCode") = ji.JournalCode
                workRow("JournalItemIdNo") = ji.JournalItemIdNo
                workRow("Sequence") = nRowCount
                If ji.IdNo <= 0 Then
                    DtInsertTable.Rows.Add(workRow)
                Else
                    DtUpdateTable.Rows.Add(workRow)
                End If
                nRowCount += 1
            Next

            retVal = UpdateDataTables(DtUpdateTable, DtInsertTable, parentIdNo, "AccountReconciliationIdNo")

        End Sub

        Public Sub PostReconciliation(ByVal idNo As Int32, ByVal accountReconciliationItems As List(Of AccountReconciliationItemView))
            Try
                Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 1, 0))
                    Dim dtInsertReconciledTable As New DataTable
                    dtInsertReconciledTable.Columns.Add("JournalCode", GetType(String))
                    dtInsertReconciledTable.Columns.Add("JournalItemIdNo", GetType(Int32))
                    dtInsertReconciledTable.Columns.Add("ReconciliationIdNo", GetType(Int32))
                    For Each item In accountReconciliationItems
                        Dim workRow As DataRow
                        If item.Cleared Then
                            workRow = dtInsertReconciledTable.NewRow()
                            workRow("JournalCode") = item.JournalCode
                            workRow("JournalItemIdNo") = item.JournalItemIdNo
                            workRow("ReconciliationIdNo") = idNo
                            dtInsertReconciledTable.Rows.Add(workRow)
                        End If
                    Next
                    SaveReconciliation(dtInsertReconciledTable, idNo)
                    Model.UpdateRecordWithIdNo(Of Boolean)(idNo, "AccountReconciliation", "Posted", True)
                    scope.Complete()
                End Using
            Catch ex As TransactionAbortedException
                MessageBox.Show(ex.Message, "Transaction Aborted")
            Catch oEx As Exception
                Debugger.Break()
            End Try

        End Sub

        Public Overloads Function SaveReconciliation(ByRef dtInsert As DataTable, ByVal accountReconciliationIdNo As Int32)
            Dim insertReturnValue
            Dim modelReconciled = New ModelAccounts("Reconciled")
            Dim retVal As Integer
            If dtInsert.Rows.Count > 0 Then
                insertReturnValue = modelReconciled.InsertTvp(dtInsert)
                If insertReturnValue >= 0 Then
                    retVal = insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                Return 0
            End If
            Return retVal
        End Function

        Public Function GetAcctReconItems(ByVal AccountIdNo As Int16, ByVal reconciliationDate As Date, ByVal idNo As Int32, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemView)
            Dim acctReconItems As New List(Of AccountReconciliationItemModel)
            Dim nSeq As Integer = 0
            'If PresenterObj.AddMode Or PresenterObj.EditMode Then
            Dim allAcctReconItems As List(Of AccountReconciliationItemModel) = ModelOfPresenter.GetAcctReconItems(Of AccountReconciliationItemModel)(AccountIdNo, reconciliationDate, sortOrder)
            If AddMode Then
                For Each acctReconItem In allAcctReconItems
                    AddNewItem(acctReconItem, acctReconItems, nSeq)
                Next
            Else
                Dim oldReconciliationItems As List(Of AccountReconciliationItemModel)
                oldReconciliationItems = ModelOfPresenter.GetRecordsWithGroupIdNo(Of AccountReconciliationItemModel)(idNo, "TransactionDate")
                Dim oldReconItems = New DataTable
                oldReconItems = ToDataTable(oldReconciliationItems)
                Dim oldReconItem As New AccountReconciliationItemModel
                Dim dr() As DataRow
                For Each acctReconItem In allAcctReconItems
                    dr = oldReconItems.Select("JournalCode = '" & acctReconItem.JournalCode & "' and JournalItemIdNo = " & acctReconItem.JournalItemIdNo.ToString())
                    If dr.Length > 0 Then
                        AddNewItem(acctReconItem, acctReconItems, nSeq)
                    Else
                        nSeq += 1
                    End If
                Next
                For Each reconciledItem As AccountReconciliationItemModel In oldReconciliationItems
                    AddNewItem(reconciledItem, acctReconItems, nSeq)
                    nSeq += 1
                Next
            End If
            Dim result As New List(Of AccountReconciliationItemView)
            GlobalVariables.Mapper.Map(acctReconItems, result)
            Return result
        End Function

        'Public Function GetAcctReconItems(ByVal AccountIdNo As Int16, ByVal reconciliationDate As Date, ByVal idNo As Int32, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemView)
        '    Dim acctReconItems As New List(Of AccountReconciliationItemModel)
        '    Dim nSeq As Integer = 0
        '    'If PresenterObj.AddMode Or PresenterObj.EditMode Then
        '    Dim allAcctReconItems = ModelOfPresenter.GetAcctReconItems(Of AccountReconciliationItemModel)(AccountIdNo, reconciliationDate, sortOrder)
        '    If AddMode Then
        '        For Each acctReconItem In allAcctReconItems
        '            AddNewItem(acctReconItem, acctReconItems, nSeq)
        '        Next
        '    Else
        '        Dim oldReconciliationItems As List(Of AccountReconciliationItemModel)
        '        oldReconciliationItems = ModelOfPresenter.GetRecordsWithGroupIdNo(Of AccountReconciliationItemModel)(idNo, "TransactionDate")
        '        For Each acctReconItem In allAcctReconItems
        '            Dim found As Boolean = False
        '            For Each item As AccountReconciliationItemModel In oldReconciliationItems
        '                If item.JournalCode = acctReconItem.JournalCode And
        '                   item.JournalItemIdNo = acctReconItem.JournalItemIdNo Then
        '                    found = True
        '                    Exit For
        '                End If
        '            Next
        '            nSeq += 1
        '            If Not found Then
        '                AddNewItem(acctReconItem, acctReconItems, nSeq)
        '            End If
        '        Next
        '        For Each reconciledItem As AccountReconciliationItemModel In oldReconciliationItems
        '            AddNewItem(reconciledItem, acctReconItems, nSeq)
        '            nSeq += 1
        '        Next
        '    End If
        '    Dim result As New List(Of AccountReconciliationItemView)
        '    GlobalVariables.Mapper.Map(acctReconItems, result)
        '    Return result
        'End Function

        Private Sub AddNewItem(acctReconItem As AccountReconciliationItemModel, actualReconItems As List(Of AccountReconciliationItemModel), nSeq As Integer)
            Dim item As New AccountReconciliationItemModel With {
                    .AccountIdNo = acctReconItem.AccountIdNo,
                    .AccountReconciliationIdNo = acctReconItem.AccountReconciliationIdNo,
                    .Cleared = acctReconItem.Cleared,
                    .Credit = acctReconItem.Credit,
                    .Debit = acctReconItem.Debit,
                    .DocumentNumber = acctReconItem.DocumentNumber,
                    .IdNo = acctReconItem.IdNo,
                    .JournalCode = acctReconItem.JournalCode,
                    .JournalIdNo = acctReconItem.JournalIdNo,
                    .JournalItemIdNo = acctReconItem.JournalItemIdNo,
                    .PayDescription = IIf(GlobalVariables.RightToLeftLayout, acctReconItem.PayDescriptionAra, acctReconItem.PayDescription),
                    .PayDescriptionAra = acctReconItem.PayDescriptionAra,
                    .ReferenceNo = acctReconItem.ReferenceNo,
                    .TransactionDate = acctReconItem.TransactionDate,
                    .Sequence = nSeq}
            actualReconItems.Add(item)
        End Sub

        Public Overrides Sub GoPrintRecord()
            Dim currencies As New List(Of CurrencyInfo) From {
                New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia)
            }
            Dim cForm As New ReportForm("Account Reconciliation.Rpt", View.IdNo, "ReconciliationNumber")
            cForm.Show()

        End Sub

        Public Sub ProcessReconciliationRequest(eEvent As ReconciliationClearEvent)
            If eEvent.All Then
                For Each accountReconciliationItem In View.AccountReconciliationItems
                    If eEvent.Clear Then
                        accountReconciliationItem.Cleared = True
                    Else
                        accountReconciliationItem.Cleared = False
                    End If
                Next
            Else
                eEvent.Sender.Cleared = Not eEvent.Sender.Cleared
            End If
            eEvent.DataBindingSource.ResetBindings(False)
        End Sub

        Public Function ToDataTable(Of T)(data As IList(Of T)) As DataTable
            Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
            Dim table As DataTable = New DataTable()

            For Each prop As PropertyDescriptor In properties
                table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
            Next

            For Each item As T In data
                Dim row As DataRow = table.NewRow()

                For Each prop As PropertyDescriptor In properties
                    row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
                Next

                table.Rows.Add(row)
            Next

            Return table
        End Function

        Public Sub OnReconciliationClearEvent(ByRef e As ReconciliationClearEvent) Implements ISubscriber(Of ReconciliationClearEvent).OnEventHandler
            If EditMode Then
                ProcessReconciliationRequest(e)
                UpdateTotals()
                e.DataBindingSource.ResetBindings(False)
            End If
        End Sub

        Private Sub UpdateTotals()
            If View.AccountIdNo > 0 Then
                View.GlSystemBalance = ModelOfPresenter.GetAccountBalance(View.ReconciliationDate, View.AccountIdNo)
                ReComputeDifference()
            End If
        End Sub

        'Private Function GetGlSystemBalance() As Decimal
        '    If View.AccountIdNo >= 0 And View.ReconciliationDate IsNot Nothing Then
        '        Dim lastFiscalYearEndDate = Model.GetField(Of Date, String)("LastFiscalYearEnd", "LastPosting", "TransactionName", "LastPostingDate")
        '        If View.ReconciliationDate >= lastFiscalYearEndDate Then
        '            Dim previousBalance = Model.GetField(Of Decimal, Int16)(View.AccountIdNo, "AccountBalance", "AccountIdNo", "Debit-Credit", " year = " & DateAndTime.Year(lastFiscalYearEndDate))
        '            Dim condition = " AccountIdNo = " & View.AccountIdNo.ToString() &
        '                            " and TransactionDate > '" & DtoS(lastFiscalYearEndDate) &
        '                            "' and TransactionDate <= '" & DtoS(View.ReconciliationDate) & "'"
        '            Dim currentBalance As Decimal = GetFieldValue(Of Decimal)("sum(Debit-Credit)", "GlLedgers_View", condition)
        '            Return previousBalance + currentBalance
        '        End If
        '    End If
        '    'If ReconciliationDate Then
        '    '    Dim condition = "AccountIdNo = " & View.AccountIdNo.ToString() & " and Year = 2017"
        '    '    Dim x = GetFieldValue(Of Decimal)("Debit-Credit", "AccountBalance", condition)
        '    '    condition = "AccountIdNo = " & View.AccountIdNo.ToString() & " and TransactionDate <= '" & DtoS(View.ReconciliationDate) & "'"
        '    '    Dim y = GetFieldValue(Of Decimal)("sum(Debit-Credit)", "GlLedgers_View", condition)
        '    '    Return x + y
        '    'End If
        '    Return 0
        'End Function

        Private Sub ReComputeDifference()
            View.UnreconciledDifference = View.Balance + View.OutstandingDeposits - View.OutstandingCredits - View.GlSystemBalance
        End Sub

        Private Sub OnReconciliationPostingRequestEvent(ByRef e As ReconciliationPostingRequestEvent) Implements ISubscriber(Of ReconciliationPostingRequestEvent).OnEventHandler
            If View.UnreconciledDifference = 0 And Not View.Posted Then
                If e.Saved Then
                    AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgSaveReconFirstBeforePosting", "Please save first your reconciliation before posting!", "Unsaved entries exist")
                Else
                    Dim message = "Are you sure you want to {action} this {itemName} entry?"
                    Dim caption = "Please confirm."
                    Dim action = "post"
                    Dim itemName = "account reconciliation"
                    AATM.Libraries.MessagingLibrary.Messaging.GetMessage(True, "AskIfContinueAction", message, caption)
                    message = message.Interpolate(Function(x) action, Function(x) itemName)
                    If AATM.Libraries.MessagingLibrary.Messaging.Show(True, "AskIfContinueAction", message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        PostReconciliation(View.IdNo, View.AccountReconciliationItems)
                        'Else
                        '    MyErrorProvider.ClearAllErrorMessages()
                    End If
                End If
            Else
                If View.Posted Then
                    AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgAlreadyPosted", "Sorry this record has already been posted!", "Invalid Request")
                Else
                    Dim err = AATM.Libraries.MessagingLibrary.Messaging.GetMessage(True, "MsgCannotPostUnreconciledEntry", "Sorry you can't post an un-reconciled entry!", "")
                    AATM.Libraries.MessagingLibrary.Messaging.Show(False, "MsgCannotPostUnreconciledEntry")
                    'MyErrorProvider.SetError(txtUnreconciledDifference, err)
                End If
            End If
        End Sub

        Public Sub OnEndingBankBalanceEntryChangedEvent(ByRef eventType As EndingBankBalanceEntryChangedEvent) Implements ISubscriber(Of EndingBankBalanceEntryChangedEvent).OnEventHandler
            ReComputeDifference()
        End Sub

        Private Sub OnEndingReconciliationDateChangedEvent(ByRef eventType As EndingReconciliationDateChangedEvent) Implements ISubscriber(Of EndingReconciliationDateChangedEvent).OnEventHandler
            If AddMode Then
                If View.AccountIdNo <> 0 And View.ReconciliationDate IsNot Nothing Then
                    View.AccountReconciliationItems = GetAcctReconItems(View.AccountIdNo, View.ReconciliationDate, TargetIdNo, "TransactionDate")
                    UpdateTotals()
                End If
            End If
        End Sub

        Public Sub OnReconciliationRefreshRequestEvent(ByRef eventType As ReconciliationRefreshRequestEvent) Implements ISubscriber(Of ReconciliationRefreshRequestEvent).OnEventHandler
            If EditMode Then
                UpdateTotals()
            End If
        End Sub

    End Class

    Public Class ReconciliationClearEvent

        Public Sub New(sender As Object, all As Boolean, clear As Boolean, dataBindingSource As BindingSource)
            'all - set to true to clear/unclear all, false to clear single value
            'clear - set to true to clear , false to unClear
            Me.Sender = sender
            Me.All = all
            Me.Clear = clear
            Me.DataBindingSource = dataBindingSource
        End Sub

        Public Property Sender As Object
        Public Property All As Boolean
        Public Property Clear As Boolean
        Public Property DataBindingSource As BindingSource
    End Class

    Public Class ReconciliationPostingRequestEvent

        Public Sub New(sender As Object, saved As Boolean)
            Me.Sender = sender
            Me.Saved = saved
        End Sub

        Public Property Sender As Object
        Public Property Saved As Boolean
    End Class

    Public Class EndingBankBalanceEntryChangedEvent

        Public Sub New(sender As Object)
            Me.Sender = sender
        End Sub

        Public Property Sender As Object
    End Class

    Public Class EndingReconciliationDateChangedEvent

        Public Sub New(sender As Object)
            Me.Sender = sender
        End Sub

        Public Property Sender As Object
    End Class

    Public Class ReconciliationAccountChangedEvent

        Public Sub New(sender As Object)
            Me.Sender = sender
        End Sub

        Public Property Sender As Object
    End Class

    Public Class ReconciliationRefreshRequestEvent

        Public Sub New(sender As Object)
            Me.Sender = sender
        End Sub

        Public Property Sender As Object
    End Class

End Namespace