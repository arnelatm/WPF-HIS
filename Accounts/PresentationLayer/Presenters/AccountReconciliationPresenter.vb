Imports System.Transactions
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Languages

Namespace PresentationLayer.Presenters


    Public Class AccountReconciliationPresenter
        Inherits AccountsPresenter(Of IAccountReconciliationView, AccountReconciliation, AccountReconciliationModel)

        Public ParentViewList As List(Of AccountReconciliationModel)

        'Shared Sub New()
        '    ModelTblColProp = New ModelTblColProp
        '    ModelDefaultFieldValue = New ModelDefaultFieldValue
        'End Sub

        Public Sub New(view As IAccountReconciliationView)
            MyBase.New(view)
            CurrentModel = New ModelAccountReconciliation()
            TableName = "AccountReconciliation"
            SortOrderKey = "IdNo"
            OriginalModel = New AccountReconciliationModel()
            BizObject = New AccountReconciliation
            DataModel = New AccountReconciliationModel
        End Sub

        Public Property AccountReconciliationItemsPresenter As AccountReconciliationItemsPresenter
        Public Property MessageBox As Object

        Public Overrides Function ChangesMade() As Boolean
            Dim accountReconciliationChangesMade As Boolean
            If GlobalFunctions.ObjectsCompare(OriginalModel, View) Then
                If AccountReconciliationItemsPresenter.ChangesMadeInAccountReconciliationItems Then
                    accountReconciliationChangesMade = True
                Else
                    accountReconciliationChangesMade = False
                End If
            Else
                accountReconciliationChangesMade = True
            End If
            Return accountReconciliationChangesMade
        End Function

        Public Sub PostReconciliation(ByVal idNo As Integer, ByVal accountReconciliationItems As List(Of AccountReconciliationItemModel))
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
                    CommonModel.UpdateRecordWithIdNo(Of Boolean)(idNo, "AccountReconciliation", "Posted", True)
                    scope.Complete()
                End Using
            Catch ex As TransactionAbortedException
                MessageBox.Show(ex.Message, StringWords.Transaction_Aborted)
            Catch oEx As Exception
                Debugger.Break()
            End Try

        End Sub

    End Class
End Namespace