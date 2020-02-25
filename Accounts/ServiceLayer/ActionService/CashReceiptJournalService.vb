
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class CashReceiptJournalService
        Inherits ServiceAccounts
        Implements ICashReceiptJournalService

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly CashReceiptJournalDao As ICashReceiptJournalDao = Factory.CashReceiptJournalDao

        Public Overrides Function GetServiceDao()
            Return CashReceiptJournalDao
        End Function

    End Class

End Namespace