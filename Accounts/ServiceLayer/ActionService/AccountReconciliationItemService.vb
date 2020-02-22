
Imports System.Configuration
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class AccountReconciliationItemService
        Inherits ServiceAccounts
        Implements IAccountReconciliationItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly AccountReconciliationItemDao As IAccountReconciliationItemDao = Factory.AccountReconciliationItemDao

        Public Overrides Function GetServiceDao()
            Return AccountReconciliationItemDao
        End Function

        Public Function GetAcctReconItems(ByVal accountIdNo As Integer, ByVal reconciliationDate As Date, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItem) _
            Implements IAccountReconciliationItemService.GetAcctReconItems
            Return AccountReconciliationItemDao.GetAcctReconItems(accountIdNo, reconciliationDate, sortOrder)
        End Function

        Public Function GetReconciledRecordsWithIdNo(ByVal reconciled As Boolean, ByVal idNo As Integer, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItem) _
            Implements IAccountReconciliationItemService.GetReconciledRecordsWithIdNo
            Return AccountReconciliationItemDao.GetReconciledRecordsWithIdNo(reconciled, idNo, sortOrder)
        End Function

    End Class

    Public Interface IAccountReconciliationItemService

        Function GetAcctReconItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItem)

        Function GetReconciledRecordsWithIdNo(ByVal reconciled As Boolean, ByVal idNo As Integer, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItem)

    End Interface

End Namespace