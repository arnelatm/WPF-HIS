
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class PcsOiItemService
        Inherits ServiceAccounts
        Implements IPcsOiItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly PcsOiItemDao As IPcsOiItemDao = Factory.PcsOiItemDao

        Public Overrides Function GetServiceDao()
            Return PcsOiItemDao
        End Function

        Public Function GetSupplierOpenInvoices(ByVal idNo As Integer) As List(Of PcsOiItem) Implements IPcsOiItemService.GetSupplierOpenInvoices
            Return PcsOiItemDao.GetSupplierOpenInvoices(idNo)
        End Function

    End Class

    Friend Interface IPcsOiItemService

        Function GetSupplierOpenInvoices(idNo As Integer) As List(Of PcsOiItem)

    End Interface

End Namespace