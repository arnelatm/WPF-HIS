
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class CategoryService
        Inherits ServiceAccounts
        Implements ICategoryService

        Private Shared Shadows ReadOnly Factory As IAccountsDaoFactory = AccountsDaoFactories.GetFactory(Provider)
        Private Shared ReadOnly CategoryDao As ICategoryDao = Factory.CategoryDao

        Public Overrides Function GetServiceDao()
            Return CategoryDao
        End Function

    End Class

End Namespace