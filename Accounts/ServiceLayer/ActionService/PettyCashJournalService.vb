
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class PettyCashJournalService
        Inherits ServiceAccounts
        Implements IPettyCashJournalService

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly PettyCashJournalDao As IPettyCashJournalDao = Factory.PettyCashJournalDao

        Public Overrides Function GetServiceDao()
            Return PettyCashJournalDao
        End Function

    End Class

End Namespace