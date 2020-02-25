
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class GeneralJournalService
        Inherits ServiceAccounts
        Implements IGeneralJournalService

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly GeneralJournalDao As IGeneralJournalDao = Factory.GeneralJournalDao

        'Public Overrides Function GetDataDao4()
        '    Return GeneralJournalDao
        'End Function

        Public Overrides Function GetServiceDao()
            Return GeneralJournalDao
        End Function

    End Class

End Namespace