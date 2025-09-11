
Imports System.ComponentModel
Imports System.Globalization
Imports System.Transactions
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging

Namespace PresentationLayer.Presenters

    Public Class AccountReconciliationPresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IAccountReconciliationView, TM)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private _progressDisplayForm As DisplayProgressForm

        Public Sub New(view As IAccountReconciliationView)
            MyBase.New(view)
            TableName = "AccountReconciliation"
            WithTreeView = False
            Service = New AccountsService("AccountReconciliation")
            SortOrderKey = "IdNo"
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

            AddHandler view.ReconciliationAccountChangedEvent, AddressOf OnReconciliationAccountChangedEvent
            AddHandler view.ReconciliationClearEvent, AddressOf OnReconciliationClearEvent
            AddHandler view.ReconciliationPostingRequestEvent, AddressOf OnReconciliationPostingRequestEvent
            AddHandler view.ReconciliationRefreshRequestEvent, AddressOf OnReconciliationRefreshRequestEvent
            AddHandler view.EndingBankBalanceEntryChangedEvent, AddressOf OnEndingBankBalanceEntryChangedEvent
            AddHandler view.EndingReconciliationDateChangedEvent, AddressOf OnEndingReconciliationDateChangedEvent

            '_backgroundWorker.WorkerReportsProgress = True
            '_backgroundWorker.WorkerSupportsCancellation = True
            'AddHandler _backgroundworker.DoWork, AddressOf BackgroundWorker_DoWork
            'AddHandler _backgroundworker.ProgressChanged, AddressOf BackgroundWorker_ProgressChanged
            'AddHandler _backgroundworker.RunWorkerCompleted, AddressOf BackgroundWorker_RunWorkerCompleted
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateSpecialAccountDataSource("AccountIdNo", {EnumToCode(SpecialAccountSelection.Bank),
                                                           EnumToCode(SpecialAccountSelection.CheckingAccount),
                                                           EnumToCode(SpecialAccountSelection.Cash),
                                                           EnumToCode(SpecialAccountSelection.PettyCashAccount)
                                                          })
        End Sub

        Public Property MessageBox As Object

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.AccountReconciliationItems.Clear()
        End Sub

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

        Public Sub PostReconciliation(ByVal idNo As Int32, ByVal bsAccountReconciliationItems As BindingSource)
            Try
                Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 1, 0))
                    Dim dtInsertReconciledTable As New DataTable
                    dtInsertReconciledTable.Columns.Add("JournalCode", GetType(String))
                    dtInsertReconciledTable.Columns.Add("JournalItemIdNo", GetType(Int32))
                    dtInsertReconciledTable.Columns.Add("ReconciliationIdNo", GetType(Int32))
                    For Each item In bsAccountReconciliationItems
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
                    Service.UpdateRecordWithIdNo(Of Boolean)(idNo, "AccountReconciliation", "Posted", True)
                    scope.Complete()
                End Using
                MessagingService.Show(True, "MsgRecordSuccessfullyPosted")
                View.Posted = True
            Catch ex As TransactionAbortedException
                MessageBox.Show(ex.Message, "Transaction Aborted")
            Catch oEx As Exception
                Debugger.Break()
            End Try

        End Sub

        Public Overloads Function SaveReconciliation(ByRef dtInsert As DataTable, ByVal accountReconciliationIdNo As Int32)
            Dim insertReturnValue
            Dim reconciledService = New AccountsService("Reconciled")
            Dim retVal As Integer
            If dtInsert.Rows.Count > 0 Then
                insertReturnValue = reconciledService.InsertTvp(dtInsert)
                retVal = insertReturnValue
            Else
                Return 0
            End If
            Return retVal
        End Function

        'Public Sub GetAcctReconItems(ByVal AccountIdNo As Int16, ByVal reconciliationDate As Date, ByVal idNo As Int32, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemView)
        '    _backgroundWorker.RunWorkerAsync()
        'End Sub

        'Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        '    _progressDisplayForm = New ProgressDisplayForm()
        '    _progressDisplayForm.Show()

        'End Sub

        'Private Sub BackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
        '    _progressDisplayForm.ProgressBar.Value = e.ProgressPercentage
        '    _progressDisplayForm.lblProgress.Text = "Records processed : " + e.ProgressPercentage.ToString()
        'End Sub

        'Private Sub BackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)

        'End Sub

        Public Function GetAcctReconItems(ByVal accountIdNo As Int16, ByVal reconciliationDate As Date, ByVal idNo As Int32, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemView)
            Dim acctReconItems As New List(Of AccountReconciliationItemModel)
            Dim nSeq As Integer = 0
            'If Presenter.AddMode Or Presenter.EditMode Then
            Dim allAcctReconItems As List(Of AccountReconciliationItemModel) = Service.GetAcctReconItems(Of AccountReconciliationItemModel)(accountIdNo, reconciliationDate, sortOrder)
            Dim progressDisplayForm = New CBaseControlsLibrary.DisplayProgressForm
            Dim counter As Int16 = 1
            Dim nCount = allAcctReconItems.Count()
            Dim curItem As AccountReconciliationItemView
            If AddMode Then
                progressDisplayForm.Show()
                progressDisplayForm.InitializeDisplay(nCount)
                For Each acctReconItem In allAcctReconItems
                    nSeq += 1
                    curItem = View.AccountReconciliationItems.Find(Function(cc As AccountReconciliationItemView) cc.JournalCode = acctReconItem.JournalCode And cc.JournalItemIdNo = acctReconItem.JournalItemIdNo)
                    If Not IsNothing(curItem) Then
                        acctReconItem.Cleared = curItem.Cleared
                    End If
                    AddNewItem(acctReconItem, acctReconItems, nSeq)
                    progressDisplayForm.UpdateProgressBar(counter)
                    counter += 1
                Next
                progressDisplayForm.Close()
            Else
                'Dim oldReconciliationItems As List(Of AccountReconciliationItemModel)
                'oldReconciliationItems = ModelOfPresenter.GetRecordsWithGroupIdNo(Of AccountReconciliationItemModel)(idNo, "TransactionDate")
                progressDisplayForm.Show()
                progressDisplayForm.DisplayProgress(nCount)
                Dim caption = MessagingService.TranslateCaption("Please wait getting account transactions ...")
                progressDisplayForm.InitializeDisplay(nCount, caption)
                For Each acctReconItem In allAcctReconItems
                    'Dim found As Boolean = False
                    'For Each item As AccountReconciliationItemModel In oldReconciliationItems
                    '    If item.JournalCode = acctReconItem.JournalCode And item.JournalItemIdNo = acctReconItem.JournalItemIdNo Then
                    '        acctReconItem.IdNo = item.IdNo
                    '        acctReconItem.Cleared = item.Cleared
                    '        found = True
                    '        Exit For
                    '    End If
                    'Next
                    curItem = View.AccountReconciliationItems.Find(Function(cc As AccountReconciliationItemView) cc.JournalCode = acctReconItem.JournalCode And cc.JournalItemIdNo = acctReconItem.JournalItemIdNo)
                    If Not IsNothing(curItem) Then
                        acctReconItem.Cleared = curItem.Cleared
                    End If
                    nSeq += 1
                    AddNewItem(acctReconItem, acctReconItems, nSeq)
                    progressDisplayForm.UpdateProgressBar(counter)
                    'progressDisplayForm.ProgressBar.Value = counter
                    counter += 1
                Next
                progressDisplayForm.Close()
                'For Each reconciledItem As AccountReconciliationItemModel In oldReconciliationItems
                '    AddNewItem(reconciledItem, acctReconItems, nSeq)
                '    nSeq += 1
                'Next
            End If
            Dim result As New List(Of AccountReconciliationItemView)
            GlobalVariables.Mapper.Map(acctReconItems, result)
            Return result
        End Function

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
            Dim reportTitle As String
            Dim cForm
            Dim previousDate As Date
            Dim beginningDate As Date
            beginningDate = GregorianDateSerial(GregorianYear(View.ReconciliationDate), GregorianMonth(View.ReconciliationDate), 1)
            previousDate = DateAdd(DateInterval.Day, -1, beginningDate)
            reportTitle = MessagingService.TranslateCaption("Account Reconciliation")
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            Dim estName As String
            language = Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            If language = "ar" Then
                estName = EstablishmentNameAra
            Else
                estName = EstablishmentName
            End If
            cForm = New ReportForm("Account Reconciliation Report.Rpt", language, "Language", estName, "EstablishmentName", reportTitle, "ReportTitle", View.IdNo, "ReconciliationNumber", View.AccountIdNo, "AccountIdNo", previousDate, "PreviousDate", beginningDate, "BeginningDate", View.ReconciliationDate, "EndingDate")
            cForm.Show()
        End Sub

        Public Sub ProcessReconciliationRequest(sender As Object, all As Boolean, clear As Boolean, dataBindingSource As BindingSource)
            If all Then
                For Each accountReconciliationItem In dataBindingSource
                    If clear Then
                        accountReconciliationItem.Cleared = True
                    Else
                        accountReconciliationItem.Cleared = False
                    End If
                Next
                dataBindingSource.ResetBindings(False)
            Else
                If sender.Cleared Then
                    If sender.Debit > 0 Then
                        View.TotalDebitsCleared += sender.Debit
                        View.TotalQtyDebitsCleared += 1
                        View.TotalDebitsNotCleared -= sender.Debit
                        View.TotalQtyDebitsNotCleared -= 1
                    Else
                        View.TotalCreditsCleared += sender.Credit
                        View.TotalQtyCreditsCleared += 1
                        View.TotalCreditsNotCleared -= sender.Credit
                        View.TotalQtyCreditsNotCleared -= 1
                    End If
                Else
                    If sender.Debit > 0 Then
                        View.TotalDebitsCleared -= sender.Debit
                        View.TotalQtyDebitsCleared -= 1
                        View.TotalDebitsNotCleared += sender.Debit
                        View.TotalQtyDebitsNotCleared += 1
                    Else
                        View.TotalCreditsCleared -= sender.Credit
                        View.TotalQtyCreditsCleared -= 1
                        View.TotalCreditsNotCleared += sender.Credit
                        View.TotalQtyCreditsNotCleared += 1
                    End If
                End If
            End If
            ReComputeDifference()
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

        Public Sub OnReconciliationClearEvent(sender As Object, all As Boolean, clear As Boolean, dataBindingSource As BindingSource)
            If EditMode Or AddMode Then
                ProcessReconciliationRequest(sender, all, clear, dataBindingSource)
                If all Then
                    UpdateTotals()
                    dataBindingSource.ResetBindings(False)
                End If
            End If
        End Sub

        Public Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            UpdateTotals()
        End Sub

        Private Sub UpdateTotals()
            If View.AccountIdNo > 0 And View.ReconciliationDate IsNot Nothing Then
                View.TotalDebitsCleared = 0
                View.TotalCreditsCleared = 0
                View.TotalDebitsNotCleared = 0
                View.TotalCreditsNotCleared = 0
                View.TotalQtyDebitsCleared = 0
                View.TotalQtyCreditsCleared = 0
                View.TotalQtyDebitsNotCleared = 0
                View.TotalQtyCreditsNotCleared = 0
                Dim progressDisplayForm = New CBaseControlsLibrary.DisplayProgressForm
                progressDisplayForm.Show()
                Dim nCount = View.AccountReconciliationItems.Count()
                progressDisplayForm.DisplayProgress(nCount)
                Dim caption = MessagingService.TranslateCaption("Please wait computing reconciliation totals...")
                progressDisplayForm.InitializeDisplay(nCount, caption)
                Dim counter As Int32 = 1
                For Each accountReconciliationItem In View.AccountReconciliationItems
                    If accountReconciliationItem.Cleared Then
                        If accountReconciliationItem.Debit > 0 Then
                            View.TotalDebitsCleared += accountReconciliationItem.Debit
                            View.TotalQtyDebitsCleared += 1
                        Else
                            View.TotalCreditsCleared += accountReconciliationItem.Credit
                            View.TotalQtyCreditsCleared += 1
                        End If
                    Else
                        If accountReconciliationItem.Debit > 0 Then
                            View.TotalDebitsNotCleared += accountReconciliationItem.Debit
                            View.TotalQtyDebitsNotCleared += 1
                        Else
                            View.TotalCreditsNotCleared += accountReconciliationItem.Credit
                            View.TotalQtyCreditsNotCleared += 1
                        End If
                    End If
                    progressDisplayForm.UpdateProgressBar(counter)
                    counter = counter + 1
                Next
                View.GlSystemBalance = Service.GetAccountBalance(View.ReconciliationDate, View.AccountIdNo)
                ReComputeDifference()
                progressDisplayForm.Close()
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

        Private Sub OnReconciliationPostingRequestEvent(sender As Object, bsAccountReconciliationItem As BindingSource)
            If View.UnreconciledDifference = 0 Then
                Dim caption = MessagingService.TranslateCaption("Please confirm.")
                Dim action As String = MessagingService.TranslateCaption("post")
                Dim itemName As String = MessagingService.TranslateCaption("account reconciliation transaction")
                Dim msg = MessagingService.GetParametrizedMessage(True, "AskIfContinueAction", {"action", action, "itemName", itemName})
                If MessagingService.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    PostReconciliation(View.IdNo, bsAccountReconciliationItem)
                End If
            Else
                'Dim err = MessagingService.GetMessage(True, "MsgCannotPostUnreconciledEntry", "Sorry you can't post an un-reconciled entry!", "")
                MessagingService.Show(False, "MsgCannotPostUnreconciledEntry")
            End If
        End Sub

        Public Sub OnEndingBankBalanceEntryChangedEvent()
            ReComputeDifference()
        End Sub

        Private Sub OnEndingReconciliationDateChangedEvent()
            If EditMode Or AddMode Then
                If View.AccountIdNo <> 0 And View.ReconciliationDate IsNot Nothing Then
                    View.AccountReconciliationItems = GetAcctReconItems(View.AccountIdNo, View.ReconciliationDate, TargetIdNo, "TransactionDate")
                Else
                    View.AccountReconciliationItems.Clear()
                End If
                UpdateTotals()
            End If
        End Sub

        Public Sub OnReconciliationRefreshRequestEvent()
            If EditMode Or AddMode Then
                UpdateTotals()
            End If
        End Sub

        Public Sub OnReconciliationAccountChangedEvent(sender As Object, bindingSource As BindingSource)
            If EditMode Or AddMode Then
                If View.AccountIdNo IsNot Nothing And View.ReconciliationDate IsNot Nothing Then
                    View.AccountReconciliationItems = GetAcctReconItems(View.AccountIdNo, View.ReconciliationDate, TargetIdNo, "TransactionDate")
                    UpdateTotals()
                Else
                    View.AccountReconciliationItems.Clear()
                End If
                bindingSource.ResetBindings(False)
            End If
        End Sub

    End Class

    'Public Class ReconciliationClearEvent

    '    Public Sub New(sender As Object, all As Boolean, clear As Boolean, dataBindingSource As BindingSource)
    '        'all - set to true to clear/unclear all, false to clear single value
    '        'clear - set to true to clear , false to unClear
    '        Me.Sender = sender
    '        Me.All = all
    '        Me.Clear = clear
    '        Me.DataBindingSource = dataBindingSource
    '    End Sub

    '    Public Property Sender As Object
    '    Public Property All As Boolean
    '    Public Property Clear As Boolean
    '    Public Property DataBindingSource As BindingSource
    'End Class

    'Public Class ReconciliationPostingRequestEvent

    '    Public Sub New(sender As Object, idNo As Integer, unreconciledDifference As Decimal, bsAccountReconciliationItem As BindingSource)
    '        Me.Sender = sender
    '        Me.IdNo = idNo
    '        Me.UnreconciledDifference = unreconciledDifference
    '        Me.BsAccountReconciliationItem = bsAccountReconciliationItem
    '    End Sub

    '    Public Property Sender As Object
    '    Public Property IdNo As Integer
    '    Public Property UnreconciledDifference As Decimal
    '    Public Property BsAccountReconciliationItem As BindingSource
    'End Class

    'Public Class EndingBankBalanceEntryChangedEvent

    '    Public Sub New(sender As Object)
    '        Me.Sender = sender
    '    End Sub

    '    Public Property Sender As Object
    'End Class

    'Public Class EndingReconciliationDateChangedEvent

    '    Public Sub New(sender As Object)
    '        Me.Sender = sender
    '    End Sub

    '    Public Property Sender As Object
    'End Class

    'Public Class ReconciliationAccountChangedEventArgs
    '    Inherits EventArgs

    '    Public Sub New(sender As IAccountReconciliationView, bsAccountReconciliationItem As BindingSource)
    '        Me.Sender = sender
    '        BsAccountReconciliation = bsAccountReconciliationItem
    '    End Sub

    '    Public Property Sender As IAccountReconciliationView
    '    Public Property BsAccountReconciliation As BindingSource
    'End Class

    'Public Class ReconciliationRefreshRequestEvent

    '    Public Sub New(sender As Object)
    '        Me.Sender = sender
    '    End Sub

    '    Public Property Sender As Object
    'End Class

    'Public Class CreateDataSourcesEvent

    '    Public Sub New(accounts As List(Of Object)
    '        Me.Sender = sender
    '    End Sub

    '    Public Property Sender As Object
    'End Class

End Namespace