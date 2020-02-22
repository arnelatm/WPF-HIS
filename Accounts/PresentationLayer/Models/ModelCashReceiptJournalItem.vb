
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelCashReceiptJournalItem
        Inherits ModelAccounts
        Implements IModelCashReceiptJournalItem

        Private Shared ReadOnly Property Service As New CashReceiptJournalItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelCashReceiptJournalItem
    End Interface
End NameSpace