
Imports System.Configuration
Imports AATM.Accounts.DataLayer
Imports AATM.ServicesLayer.Services
Imports ServicesLayer.Services

Namespace ServiceLayer.ActionService

    Public Class DesignationService
        Inherits ServiceOld

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        Private Shared ReadOnly DesignationDao As IDesignationDao = Factory.DesignationDao

        Public Sub New()

            DataDao = DesignationDao
        End Sub

    End Class

End Namespace