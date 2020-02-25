
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ChequeDisbursementJournalItemService
        Inherits ServiceAccounts
        Implements IJournalItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly ChequeDisbursementJournalItemDao As IJournalItemDao = Factory.ChequeDisbursementJournalItemDao

        'Public Overrides Function GetDataDao2()
        '    Return ChequeDisbursementJournalItemDao
        'End Function

        Public Overrides Function GetServiceDao()
            Return ChequeDisbursementJournalItemDao
        End Function

    End Class

End Namespace