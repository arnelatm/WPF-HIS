
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Models

    Public Class ModelAccountReconciliationItem
        Inherits ModelAccounts
        Implements IModelAccountReconciliationItem

        Private Shared ReadOnly Property Service As New AccountReconciliationItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

        Public Function GetAcctReconItems(ByVal accountIdNo As Integer, ByVal reconciliationDate As Date, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemModel) Implements IModelAccountReconciliationItem.GetAcctReconItems
            Dim data = Service.GetAcctReconItems(accountIdNo, reconciliationDate, sortOrder)
            Dim viewObject As New List(Of AccountReconciliationItemModel)
            For Each bObject In data
                Dim model As New AccountReconciliationItemModel
                model = GlobalVariables.Mapper.Map(Of AccountReconciliationItemModel)(bObject)
                viewObject.Add(model)
            Next
            Return viewObject
        End Function

        Public Function GetReconciledRecordsWithIdNo(ByVal reconciled As Boolean, ByVal idNo As Integer, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemModel) _
            Implements IModelAccountReconciliationItem.GetReconciledRecordsWithIdNo
            Dim data = Service.GetReconciledRecordsWithIdNo(reconciled, idNo, sortOrder)
            Dim viewObject As New List(Of AccountReconciliationItemModel)
            For Each bObject In data
                Dim model As New AccountReconciliationItemModel
                model = GlobalVariables.Mapper.Map(Of AccountReconciliationItemModel)(bObject)
                viewObject.Add(model)
            Next
            Return viewObject
        End Function

    End Class

    Public Interface IModelAccountReconciliationItem

        Function GetAcctReconItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemModel)

        Function GetReconciledRecordsWithIdNo(reconciled As Boolean, idNo As Integer, Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemModel)

    End Interface
End NameSpace