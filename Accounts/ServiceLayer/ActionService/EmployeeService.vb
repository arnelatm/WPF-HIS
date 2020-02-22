
Imports System.Configuration
Imports AATM.Accounts.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionService

    Public Class EmployeeService
        Inherits ServiceOld

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        Private Shared ReadOnly EmployeeDao As IEmployeeDao = Factory.EmployeeDao

        Public Sub New()
            DataDao = EmployeeDao
        End Sub

    End Class

End Namespace