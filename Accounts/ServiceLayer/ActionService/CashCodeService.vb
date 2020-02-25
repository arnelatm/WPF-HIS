
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class CashCodeService
        Inherits ServiceAccounts
        Implements ICashCodeService

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly CashCodeDao As ICashCodeDao = Factory.CashCodeDao

        'Public Overrides Function GetDataDao4()
        '    Return CashCodeDao
        'End Function

        Public Overrides Function GetServiceDao()
            Return CashCodeDao
        End Function

    End Class

    Friend Interface ICashCodeService
    End Interface

End Namespace