
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelGeneralJournalItem
        Inherits ModelAccounts
        Implements IModelGeneralJournalItem

        Private Shared ReadOnly Property Service As New GeneralJournalItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelGeneralJournalItem
    End Interface
End NameSpace