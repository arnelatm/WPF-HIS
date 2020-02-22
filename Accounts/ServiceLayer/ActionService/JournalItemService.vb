
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class JournalItemService
        Inherits ServiceAccounts
        Implements IJournalItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly JournalItemDao As IJournalItemDao = Factory.JournalItemDao

        Public Overrides Function GetDao()
            Return JournalItemDao
        End Function

    End Class

    Friend Interface IJournalItemService
    End Interface

End Namespace