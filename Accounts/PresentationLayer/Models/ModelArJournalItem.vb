
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelArJournalItem
        Inherits ModelAccounts
        Implements IModelArJournalItem

        Private Shared ReadOnly Property Service As New ArJournalItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelArJournalItem
    End Interface
End NameSpace