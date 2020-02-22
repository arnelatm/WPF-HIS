
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelReconciled
        Inherits ModelAccounts
        Implements IModelReconciled

        Private Shared ReadOnly Property Service As New ReconciledService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelReconciled
        Inherits IModelAccounts
    End Interface
End NameSpace