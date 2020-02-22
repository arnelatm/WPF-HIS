
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelPettyCashJournal
        Inherits ModelAccounts
        Implements IModelPettyCashJournal

        Private Shared ReadOnly Property Service As New PettyCashJournalService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelPettyCashJournal
    End Interface
End NameSpace