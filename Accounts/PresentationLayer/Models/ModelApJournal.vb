
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelApJournal
        Inherits ModelAccounts
        Implements IModelApJournal

        Private Shared ReadOnly Property Service As New ApJournalService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelApJournal
    End Interface
End NameSpace