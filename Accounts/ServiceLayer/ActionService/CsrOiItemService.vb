
Imports System.Configuration
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class CsrOiItemService
        Inherits ServiceAccounts
        Implements ICsrOiItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly CsrOiItemDao As ICsrOiItemDao = Factory.CsrOiItemDao

        Public Overrides Function GetServiceDao()
            Return CsrOiItemDao
        End Function

        Public Function GetSupplierOpenInvoices(ByVal idNo As Integer) As List(Of CsrOiItem) Implements ICsrOiItemService.GetCustomerOpenInvoices
            Return CsrOiItemDao.GetCustomerOpenInvoices(idNo)
        End Function

    End Class

    Friend Interface ICsrOiItemService

        Function GetCustomerOpenInvoices(idNo As Integer) As List(Of CsrOiItem)

    End Interface

End Namespace