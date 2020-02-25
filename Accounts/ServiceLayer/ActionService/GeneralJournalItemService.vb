
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class GeneralJournalItemService
        Inherits ServiceAccounts
        Implements IJournalItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly GeneralJournalItemDao As IJournalItemDao = Factory.GeneralJournalItemDao

        'Public Overrides Function GetDataDao2()
        '    Return CashDisbursementJournalItemDao
        'End Function

        Public Overrides Function GetServiceDao()
            Return GeneralJournalItemDao
        End Function

    End Class

End Namespace