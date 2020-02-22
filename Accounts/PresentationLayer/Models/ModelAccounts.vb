
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelAccounts
        Inherits ModelCommon
        Implements IModelAccounts

        Private Shared ReadOnly Property ServiceAccounts As New ServiceAccounts()

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

    End Class
End NameSpace