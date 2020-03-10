Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelAccounts
        Inherits ModelCommon
        Implements IModelAccounts

        Public Function UpdateGlReferenceNumber(Of TBiz)(ByRef modelBiz As TBiz) As Integer Implements IModelAccounts.UpdateGlReferenceNumber
            Dim updateResult As Integer
            updateResult = GetDataService().UpdateGlReferenceNumber(modelBiz)
            Return updateResult
        End Function

        Public Overrides Function GetCommonService() Implements IModelCommon.GetCommonService
            Return GetAccountsService()
        End Function

        Public Overridable Function GetAccountsService()
            Return New ServiceAccounts
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

End NameSpace