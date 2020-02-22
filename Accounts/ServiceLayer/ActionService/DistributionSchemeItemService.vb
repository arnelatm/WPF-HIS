
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class DistributionSchemeItemService
        Inherits AATM.ServicesLayer.Services.ServiceOld

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        Private Shared ReadOnly DistributionSchemeItemDao As IDistributionSchemeItemDao = Factory.DistributionSchemeItemDao

        Public Sub New()
            DataDao = DistributionSchemeItemDao
        End Sub

    End Class

End Namespace