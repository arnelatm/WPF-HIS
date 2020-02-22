
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class AccountReconciliationService
        Inherits ServiceAccounts
        Implements IAccountReconciliationService

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly AccountReconciliationDao As IAccountReconciliationDao = Factory.AccountReconciliationDao

        'Public Overrides Function GetDataDao4()
        '    Return AccountReconciliationDao
        'End Function

        Public Overrides Function GetServiceDao()
            Return AccountReconciliationDao
        End Function

    End Class

    Public Interface IAccountReconciliationService
    End Interface

End Namespace