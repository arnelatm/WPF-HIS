
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelPurchaseJournal
        Inherits ModelAccounts
        Implements IModelPurchaseJournal

        Private Shared ReadOnly Property Service As New PurchaseJournalService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelPurchaseJournal
    End Interface
End NameSpace