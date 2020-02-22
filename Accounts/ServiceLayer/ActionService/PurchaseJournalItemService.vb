
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class PurchaseJournalItemService
        Inherits ServiceAccounts
        Implements IJournalItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly PurchaseJournalItemDao As IJournalItemDao = Factory.PurchaseJournalItemDao

        Public Overrides Function GetServiceDao()
            Return PurchaseJournalItemDao
        End Function

    End Class

End Namespace