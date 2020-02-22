
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ChartService
        Inherits ServiceAccounts
        Implements IChartService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly ChartDao As IChartDao = Factory.ChartDao

        Public Overrides Function GetServiceDao()
            Return ChartDao
        End Function

        Public Function GetDetailAccounts() As List(Of Chart) Implements IChartService.GetDetailAccounts
            Return ChartDao.GetDetailAccounts()
        End Function

    End Class

End Namespace