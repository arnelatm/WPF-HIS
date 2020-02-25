
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ApJournalItemService
        Inherits ServiceAccounts
        Implements IJournalItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly ApJournalItemDao As IJournalItemDao = Factory.ApJournalItemDao

        Public Overrides Function GetServiceDao()
            Return ApJournalItemDao
        End Function

    End Class

End Namespace