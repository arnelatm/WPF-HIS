
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ApJournalService
        Inherits ServiceAccounts
        Implements IApJournalService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly ApJournalDao As IApJournalDao = Factory.ApJournalDao

        Public Overrides Function GetServiceDao()
            Return ApJournalDao
        End Function

    End Class

End Namespace