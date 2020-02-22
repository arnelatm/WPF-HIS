
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class CustomerService
        Inherits ServiceOld

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        Private Shared ReadOnly CustomerDao As ICustomerDao = Factory.CustomerDao

        Public Sub New()
            DataDao = CustomerDao
        End Sub

    End Class

End Namespace