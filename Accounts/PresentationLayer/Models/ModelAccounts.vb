
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelAccounts
        Inherits ModelCommon
        Implements IModelAccounts

        Private Shared ReadOnly Property ServiceAccounts As New ServiceAccounts()
        Private Shared Shadows Property DataBizObject

        Public Function UpdateGlReferenceNumber(Of TBiz)(ByRef modelBiz As TBiz) As Integer Implements IModelAccounts.UpdateGlReferenceNumber
            Dim updateResult As Integer
            updateResult = GetDataService().UpdateGlReferenceNumber(modelBiz)
            Return updateResult
        End Function

        Public Overrides Function GetCommonService()
            Return GetAccountsService()
        End Function

        Public Overridable Function GetAccountsService()
            Return ServiceAccounts
        End Function

        Public Overridable Function GetCommonBo()
            Return Nothing
        End Function

    End Class
End NameSpace