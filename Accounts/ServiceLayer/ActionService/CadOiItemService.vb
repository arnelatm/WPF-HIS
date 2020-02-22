
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class CadOiItemService
        Inherits ServiceAccounts
        Implements ICadOiItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly CadOiItemDao As ICadOiItemDao = Factory.CadOiItemDao

        Public Overrides Function GetServiceDao()
            Return CadOiItemDao
        End Function

        Public Function GetSupplierOpenInvoices(ByVal idNo As Integer) As List(Of CadOiItem) Implements ICadOiItemService.GetSupplierOpenInvoices
            Return CadOiItemDao.GetSupplierOpenInvoices(idNo)
        End Function

    End Class

    Friend Interface ICadOiItemService

        Function GetSupplierOpenInvoices(idNo As Integer) As List(Of CadOiItem)

    End Interface

End Namespace