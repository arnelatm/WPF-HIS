
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelAccountsOld
        Inherits ModelCommonOld
        Implements IModelAccountsOld

        Public Shared Property ModelAccounts As IModelAccounts
        Protected Shared ServiceAccounts

        Public Sub New()
            ServiceAccounts = New ServiceAccounts()
        End Sub

        Public Function UpdateGlReferenceNumber(Of TBiz)(ByRef modelBiz As TBiz) As Integer Implements IModelAccountsOld.UpdateGlReferenceNumber
            Dim updateResult As Integer
            Dim dbDataDao = ""
            updateResult = ServiceAccounts.UpdateGlReferenceNumber(modelBiz, dbDataDao)
            Return updateResult
        End Function

    End Class
End NameSpace