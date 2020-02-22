
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelCashDisbursementJournalItem
        Inherits ModelAccounts
        Implements IModelCashDisbursementJournalItem

        Private Shared ReadOnly Property Service As New CashDisbursementJournalItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelCashDisbursementJournalItem
    End Interface
End NameSpace