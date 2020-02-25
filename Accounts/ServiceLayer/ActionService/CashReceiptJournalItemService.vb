
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class CashReceiptJournalItemService
        Inherits ServiceAccounts
        Implements IJournalItemService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        Private Shared ReadOnly CashReceiptJournalItemDao As IJournalItemDao = Factory.CashReceiptJournalItemDao

        Public Overrides Function GetServiceDao()
            Return CashReceiptJournalItemDao
        End Function

    End Class

End Namespace