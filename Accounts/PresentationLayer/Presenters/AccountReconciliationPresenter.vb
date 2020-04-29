Imports System.Transactions
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class AccountReconciliationPresenter
        Inherits AccountsPresenter(Of IAccountReconciliationView, AccountReconciliationModel)

        Public Sub New(view As IAccountReconciliationView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("AccountReconciliation")
            TableName = "AccountReconciliation"
            SortOrderKey = "IdNo"
            OriginalModel = New AccountReconciliationModel()
            DataModel = New AccountReconciliationModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Property AccountReconciliationItemsPresenter As AccountReconciliationItemsPresenter
        Public Property MessageBox As Object

        Public Sub PostReconciliation(ByVal idNo As Int32, ByVal accountReconciliationItems As List(Of AccountReconciliationItemModel))
            Try
                Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 1, 0))
                    Dim reconciled As New ReconciledModel
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
                    _AccountReconciliationItemsPresenter.SaveReconciliation(dtInsertReconciledTable, idNo)
                    DataModel.UpdateRecordWithIdNo(Of Boolean)(idNo, "AccountReconciliation", "Posted", True)
                    scope.Complete()
                End Using
            Catch ex As TransactionAbortedException
                MessageBox.Show(ex.Message, "Transaction Aborted")
            Catch oEx As Exception
                Debugger.Break()
            End Try

        End Sub

    End Class

End Namespace