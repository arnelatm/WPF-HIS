
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class SupplierService
        Inherits ServiceAccounts
        Implements ISupplierService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly SupplierDao As ISupplierDao = Factory.SupplierDao

        Public Overrides Function GetServiceDao()
            Return SupplierDao
        End Function

    End Class

    Friend Interface ISupplierService
    End Interface

End Namespace