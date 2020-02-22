
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelPettyCashJournalItem
        Inherits ModelAccounts
        Implements IModelPettyCashJournalItem

        Private Shared ReadOnly Property Service As New PettyCashJournalItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelPettyCashJournalItem
    End Interface
End NameSpace