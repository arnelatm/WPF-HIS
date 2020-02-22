
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelSalesJournalItem
        Inherits ModelAccounts
        Implements IModelSalesJournalItem

        Private Shared ReadOnly Property Service As New SalesJournalItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelSalesJournalItem
    End Interface
End NameSpace