
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class PurchaseJournalService
        Inherits ServiceAccounts
        Implements IPurchaseJournalService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly PurchaseJournalDao As IPurchaseJournalDao = Factory.PurchaseJournalDao

        Public Overrides Function GetServiceDao()
            Return PurchaseJournalDao
        End Function

    End Class

End Namespace