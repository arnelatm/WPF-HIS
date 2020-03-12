Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelAccounts
        Inherits ModelCommon
        Implements IModelAccounts

        Private Shared ReadOnly Service = New ServiceAccounts

        Public Function UpdateGlReferenceNumber(Of TBiz)(ByRef modelBiz As TBiz) As Integer Implements IModelAccounts.UpdateGlReferenceNumber
            Dim updateResult As Integer
            updateResult = GetAccountsService().UpdateGlReferenceNumber(modelBiz)
            Return updateResult
        End Function

        Public Overrides Function GetCommonService() Implements IModelCommon.GetCommonService
            Return GetAccountsService()
        End Function

        Public Overridable Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Class ModelCategory
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceCategory()
        End Function

    End Class

    Public Class ModelEmployee
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceEmployee()
        End Function

    End Class

    Public Class ModelApJournal
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceApJournal()
        End Function

    End Class

    Public Class ModelJournalItems
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceJournalItem()
        End Function

    End Class

    Public Class ModelApJournalItems
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceApJournalItems()
        End Function

    End Class

    Public Class ModelGeneralJournal
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceGeneralJournal()
        End Function

    End Class

    Public Class ModelGeneralJournalItem
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceGeneralJournalItem()
        End Function

    End Class

    Public Class ModelApOpenInvoice
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceApOpenInvoice()
        End Function

    End Class

End Namespace