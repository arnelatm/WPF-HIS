
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelSalesJournal
        Inherits ModelAccounts
        Implements IModelSalesJournal

        Private Shared ReadOnly Property Service As New SalesJournalService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelSalesJournal
    End Interface
End NameSpace