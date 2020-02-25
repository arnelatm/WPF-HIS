
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class SalesJournalService
        Inherits ServiceAccounts
        Implements ISalesJournalService

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly SalesJournalDao As ISalesJournalDao = Factory.SalesJournalDao

        'Public Overrides Function GetDataDao4()
        '    Return SalesJournalDao
        'End Function

        Public Overrides Function GetServiceDao()
            Return SalesJournalDao
        End Function

    End Class

    Public Interface ISalesJournalService

    End Interface

End Namespace