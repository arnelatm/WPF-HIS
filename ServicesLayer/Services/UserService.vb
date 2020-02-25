
Imports System.Configuration
Imports AATM.DataLayer

Namespace Services

    Public Class UserService
        Inherits ServiceOld

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly UserDao As IUserDao = Factory.UserDao

        Public Sub New()
            DataDao = UserDao
        End Sub

    End Class

End Namespace