
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class SalesCashItemService
        Inherits ServiceAccounts
        Implements ISalesCashItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly SaleCashItemDao As ISalesCashItemDao = Factory.SalesCashItemDao

        Public Overrides Function GetServiceDao()
            Return SaleCashItemDao
        End Function

    End Class

    Friend Interface ISalesCashItemService

    End Interface

End Namespace