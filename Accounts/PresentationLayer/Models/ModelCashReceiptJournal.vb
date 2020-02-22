
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelCashReceiptJournal
        Inherits ModelAccounts
        Implements IModelCashReceiptJournal

        Private Shared ReadOnly Property Service As New CashReceiptJournalService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelCashReceiptJournal
    End Interface
End NameSpace