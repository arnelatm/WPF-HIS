
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelChart
        Inherits ModelAccounts
        Implements IModelChart

        Private Shared ReadOnly Property Service As New ChartService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelChart
    End Interface
End NameSpace