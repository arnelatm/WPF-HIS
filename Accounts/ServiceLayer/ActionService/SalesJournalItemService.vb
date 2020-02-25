
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class SalesJournalItemService
        Inherits ServiceAccounts
        Implements IJournalItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly SalesJournalItemDao As IJournalItemDao = Factory.SalesJournalItemDao

        'Public Overrides Function GetDataDao2()
        '    Return CashDisbursementJournalItemDao
        'End Function

        Public Overrides Function GetServiceDao()
            Return SalesJournalItemDao
        End Function

    End Class

End Namespace