
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelPurchaseItem
        Inherits ModelAccounts
        Implements IModelPurchaseItem

        Private Shared ReadOnly Property Service As New PurchaseItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelPurchaseItem
    End Interface
End NameSpace