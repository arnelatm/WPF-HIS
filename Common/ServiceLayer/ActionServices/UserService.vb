
Imports System.Configuration
Imports AATM.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionServices

    Public Class UserService
        Inherits Service

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly UserDao As IUserDao = Factory.UserDao

        Public Sub New()
            DataDao = UserDao
        End Sub

    End Class

End Namespace