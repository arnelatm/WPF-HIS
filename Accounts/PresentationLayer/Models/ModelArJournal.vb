
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelArJournal
        Inherits ModelAccounts
        Implements IModelArJournal

        Private Shared ReadOnly Property Service As New ArJournalService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelArJournal
    End Interface
End NameSpace