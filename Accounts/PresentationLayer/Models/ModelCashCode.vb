
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelCashCode
        Inherits ModelAccounts
        Implements IModelCashCode

        Private Shared ReadOnly Property Service As New CashCodeService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelCashCode
        Inherits IModelAccounts

    End Interface
End NameSpace