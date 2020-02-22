
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelApJournalItem
        Inherits ModelAccounts
        Implements IModelApJournalItem

        Private Shared ReadOnly Property Service As New ApJournalItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelApJournalItem
    End Interface
End NameSpace