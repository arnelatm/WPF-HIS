
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelCashDisbursementJournal
        Inherits ModelAccounts
        Implements IModelCashDisbursementJournal

        Private Shared ReadOnly Property Service As New CashDisbursementJournalService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelCashDisbursementJournal
    End Interface
End NameSpace