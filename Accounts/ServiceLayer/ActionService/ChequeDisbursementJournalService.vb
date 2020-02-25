
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ChequeDisbursementJournalService
        Inherits ServiceAccounts
        Implements IChequeDisbursementJournalService

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly ChequeDisbursementJournalDao As IChequeDisbursementJournalDao = Factory.ChequeDisbursementJournalDao

        Public Overrides Function GetServiceDao()
            Return ChequeDisbursementJournalDao
        End Function

    End Class

End Namespace