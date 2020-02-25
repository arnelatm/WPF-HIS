
Imports System.Configuration
Imports AATM.Accounts.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionService

    Public Class DistributionSchemeService
        Inherits ServiceOld

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        Private Shared ReadOnly DistributionSchemeDao As IDistributionSchemeDao = Factory.DistributionSchemeDao

        Public Sub New()

            DataDao = DistributionSchemeDao
        End Sub

    End Class

End Namespace