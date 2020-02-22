
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelPurchaseJournalItem
        Inherits ModelAccounts
        Implements IModelPurchaseJournalItem

        Private Shared ReadOnly Property Service As New PurchaseJournalItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelPurchaseJournalItem
    End Interface
End NameSpace