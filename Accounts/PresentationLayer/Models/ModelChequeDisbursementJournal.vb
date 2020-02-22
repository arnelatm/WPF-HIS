
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelChequeDisbursementJournal
        Inherits ModelAccounts
        Implements IModelChequeDisbursementJournal

        Private Shared ReadOnly Property Service As New ChequeDisbursementJournalService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelChequeDisbursementJournal
    End Interface
End NameSpace