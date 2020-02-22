
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class PurchaseItemService
        Inherits ServiceAccounts
        Implements IPurchaseItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly PurchaseItemDao As IPurchaseItemDao = Factory.PurchaseItemDao

        Public Overrides Function GetServiceDao()
            Return PurchaseItemDao
        End Function

    End Class

End Namespace