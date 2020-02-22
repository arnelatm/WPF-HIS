
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class CkdOiItemService
        Inherits ServiceAccounts
        Implements ICkdOiItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly CkdOiItemDao As ICkdOiItemDao = Factory.CkdOiItemDao

        Public Overrides Function GetServiceDao()
            Return CkdOiItemDao
        End Function

        Public Function GetSupplierOpenInvoices(ByVal idNo As Integer) As List(Of CkdOiItem) Implements ICkdOiItemService.GetSupplierOpenInvoices
            Return CkdOiItemDao.GetSupplierOpenInvoices(idNo)
        End Function

    End Class

    Friend Interface ICkdOiItemService

        Function GetSupplierOpenInvoices(idNo As Integer) As List(Of CkdOiItem)

    End Interface

End Namespace