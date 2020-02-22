
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelChequeDisbursementJournalItem
        Inherits ModelAccounts
        Implements IModelChequeDisbursementJournalItem

        Private Shared ReadOnly Property Service As New ChequeDisbursementJournalItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelChequeDisbursementJournalItem
    End Interface
End NameSpace