
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class CategoryService
        Inherits ServiceAccounts
        Implements ICategoryService

        Private Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly CategoryDao As ICategoryDao = Factory.CategoryDao

        Public Overrides Function GetServiceDao()
            Return CategoryDao
        End Function

    End Class

End Namespace