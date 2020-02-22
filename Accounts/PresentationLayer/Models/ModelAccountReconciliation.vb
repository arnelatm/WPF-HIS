
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelAccountReconciliation
        Inherits ModelAccounts
        Implements IModelAccountReconciliation

        Private Shared ReadOnly Property Service As New AccountReconciliationService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelAccountReconciliation
    End Interface
End NameSpace