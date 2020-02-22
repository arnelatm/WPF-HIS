
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelGeneralJournal
        Inherits ModelAccounts
        Implements IModelGeneralJournal

        Private Shared ReadOnly Property Service As New GeneralJournalService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelGeneralJournal
    End Interface
End NameSpace