
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class CashDisbursementJournalService
        Inherits ServiceAccounts
        Implements ICashDisbursementJournalService

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly CashDisbursementJournalDao As ICashDisbursementJournalDao = Factory.CashDisbursementJournalDao

        Public Overrides Function GetServiceDao()
            Return CashDisbursementJournalDao
        End Function

    End Class

End Namespace