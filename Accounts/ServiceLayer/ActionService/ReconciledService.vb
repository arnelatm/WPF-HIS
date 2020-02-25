
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ReconciledService
        Inherits ServiceAccounts
        Implements IReconciledService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly ReconciledDao As IReconciledDao = Factory.ReconciledDao

        Public Overrides Function GetServiceDao()
            Return ReconciledDao
        End Function

    End Class

    Friend Interface IReconciledService
    End Interface

End Namespace