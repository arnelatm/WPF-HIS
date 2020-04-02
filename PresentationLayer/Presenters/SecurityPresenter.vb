Imports AATM.PresentationLayer.Models

Public Class SecurityPresenter
    Public Shared Property Model As IModelSecurity

    Shared Sub New()
        Model = New ModelSecurity()
    End Sub

    Public Function GetControlSecurityIdNo(searchValue As String) As String
        Try
            Return Model.GetControlSecurityIdNo(searchValue)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList
        Return Model.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
    End Function

    Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Integer) As ArrayList
        Return Model.GetUserSecurityForKey(securityObjectName, securityGroupIdNo)
    End Function

End Class