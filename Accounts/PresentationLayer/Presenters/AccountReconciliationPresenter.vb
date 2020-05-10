Imports System.Transactions
Imports AATM.Accounts.PresentationLayer.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class AccountReconciliationPresenter
        Inherits AccountsPresenter(Of IAccountReconciliationView, AccountReconciliationModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        'Protected ModelItemPresenter As New ModelAccounts("AccountReconciliationItem")

        Public Sub New(view As IAccountReconciliationView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("AccountReconciliation")
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
            DtInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtUpdateTable.Columns.Add("AccountReconciliationIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Cleared", GetType(Boolean))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalCode", GetType(String))
            DtUpdateTable.Columns.Add("JournalItemIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

        Public Property MessageBox As Object

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            View.AccountReconciliationItems.Clear()
        End Sub

        Public Overloads Function SaveChildren(ByRef retVal As Integer) Handles MyBase.ParentRecordAddedSuccessfully, MyBase.ParentRecordUpdatedSuccessfully
            Dim headerIdNo As Integer
            Dim insertReturnValue
            Dim updateReturnValue
            If AddMode Then
                headerIdNo = retVal
                CallByName(View, IdFieldName, CallType.Set, retVal)
            Else
                headerIdNo = CallByName(View, IdFieldName, CallType.Get)
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
                workRow("AccountReconciliationIdNo") = headerIdNo
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
            updateReturnValue = ModelPresenter.DelUpdateTvp(DtUpdateTable, headerIdNo)
            If updateReturnValue >= 0 AndAlso DtInsertTable.Rows.Count > 0 Then
                For Each row As DataRow In DtInsertTable.Rows
                    row.Item("AccountReconciliationIdNo") = headerIdNo
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

        Public Sub PostReconciliation(ByVal idNo As Int32, ByVal accountReconciliationItems As List(Of AccountReconciliationItemModel))
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
                    DataModel.UpdateRecordWithIdNo(Of Boolean)(idNo, "AccountReconciliation", "Posted", True)
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

        Public Function GetAcctReconItems(ByVal accountIdNo As Int32, ByVal reconciliationDate As Date, ByVal idNo As Int32, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemView)
            Dim acctReconItems As New List(Of AccountReconciliationItemModel)
            Dim nSeq As Integer = 0
            'If PresenterObj.AddMode Or PresenterObj.EditMode Then
            Dim allAcctReconItems = ModelPresenter.GetAcctReconItems(Of AccountReconciliationItemModel)(accountIdNo, reconciliationDate, sortOrder)
            If AddMode Then
                For Each acctReconItem In allAcctReconItems
                    AddNewItem(acctReconItem, acctReconItems, nSeq)
                Next
            Else
                Dim oldReconciliationItems As List(Of AccountReconciliationItemModel)
                oldReconciliationItems = ModelPresenter.GetRecordsWithIdNo(Of AccountReconciliationItemModel)(idNo, "TransactionDate")
                For Each acctReconItem In allAcctReconItems
                    Dim found As Boolean = False
                    For Each item As AccountReconciliationItemModel In oldReconciliationItems
                        If item.JournalCode = acctReconItem.JournalCode And
                           item.JournalItemIdNo = acctReconItem.JournalItemIdNo Then
                            found = True
                            Exit For
                        End If
                    Next
                    nSeq = nSeq + 1
                    If Not found Then
                        AddNewItem(acctReconItem, acctReconItems, nSeq)
                    End If
                Next
                For Each reconciledItem As AccountReconciliationItemModel In oldReconciliationItems
                    AddNewItem(reconciledItem, acctReconItems, nSeq)
                    nSeq = nSeq + 1
                Next
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
            Dim cForm As New AccountReconciliationReport(View.IdNo)
            cForm.Show()
        End Sub

    End Class

End Namespace