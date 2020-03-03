
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelCategory
        Inherits ModelAccounts
        Implements IModelCategory

        Private Shared ReadOnly Property Service As New CategoryService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

        Public Shadows Function GetBo()
            Return New Category
        End Function

    End Class

    Public Interface IModelCategory
    End Interface
End Namespace