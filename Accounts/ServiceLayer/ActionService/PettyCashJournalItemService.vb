
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class PettyCashJournalItemService
        Inherits ServiceAccounts
        Implements IJournalItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly PettyCashJournalItemDao As IJournalItemDao = Factory.PettyCashJournalItemDao

        'Public Overrides Function GetDataDao2()
        '    Return PettyCashJournalItemDao
        'End Function

        Public Overrides Function GetServiceDao()
            Return PettyCashJournalItemDao
        End Function

    End Class

End Namespace