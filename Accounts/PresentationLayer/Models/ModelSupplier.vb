
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelSupplier
        Inherits ModelAccounts
        Implements IModelSupplier

        Private Shared ReadOnly Property Service As New SupplierService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelSupplier
    End Interface
End NameSpace