
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ArJournalItemService
        Inherits ServiceAccounts
        Implements IJournalItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly ArJournalItemDao As IJournalItemDao = Factory.ArJournalItemDao

        Public Overrides Function GetServiceDao()
            Return ArJournalItemDao
        End Function

    End Class

End Namespace