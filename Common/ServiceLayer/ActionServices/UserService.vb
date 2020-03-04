
Imports System.Configuration
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionServices

    Public Class UserService
        Inherits ServiceCommon

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As ICommonDaoFactory = CommonDaoFactories.GetFactory(Provider)
        Private Shared ReadOnly UserDao As IUserDao = Factory.UserDao

        Public Overrides Function GetDao()
            Return UserDao
        End Function

    End Class

End Namespace