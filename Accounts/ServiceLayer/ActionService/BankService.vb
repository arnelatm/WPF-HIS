
Imports System.Configuration
Imports AATM.Accounts.DataLayer
Imports AATM.ServicesLayer.Services
Imports ServicesLayer.Services

Namespace ServiceLayer.ActionService

    Public Class BankService
        Inherits ServiceOld

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        Private Shared ReadOnly BankDao As IBankDao = Factory.BankDao

        Public Sub New()

            DataDao = BankDao
        End Sub

    End Class

End Namespace