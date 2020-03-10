Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Common.ServiceLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionService

    Public Class ServiceAccounts
        Inherits ServiceCommon
        Implements IServiceAccounts

        Protected Service As Object

        Private Shared ReadOnly AccountsFactory As IAccountsDaoFactory = AccountsDaoFactories.GetAccountsFactory(Provider)
        Protected Shared ReadOnly AccountsDao As IAccountsDao = AccountsFactory.AccountsDao
        Protected Shared ReadOnly CategoryDao As ICategoryDao = AccountsFactory.CategoryDao
        Protected Shared ReadOnly EmployeeDao As IEmployeeDao = AccountsFactory.EmployeeDao

        Public ReadOnly Property AccountsDaoProp
            Get
                Return AccountsDao
            End Get
        End Property
        
        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer Implements IServiceAccounts.UpdateGlReferenceNumber
            Return GetServiceDao().UpdateGlReferenceNumber(model)
        End Function

        Public Overrides Function GetBaseDao() As Object
            Return GetServiceDao()
        End Function

        Public Overridable Function GetServiceDao()
            Return CommonDaoProp
        End Function

    End Class

    Public Class ServiceCategory
        Inherits ServiceAccounts

        Public Overrides Function GetDao()
            Return CategoryDao
        End Function

    End Class

    Public Class ServiceEmployee
        Inherits ServiceAccounts

        Public Overrides Function GetDao()
            Return EmployeeDao
        End Function

    End Class

End Namespace