
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ArJournalService
        Inherits ServiceAccounts
        Implements IArJournalService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly ArJournalDao As IArJournalDao = Factory.ArJournalDao

        Public Overrides Function GetServiceDao()
            Return ArJournalDao
        End Function

    End Class

End Namespace