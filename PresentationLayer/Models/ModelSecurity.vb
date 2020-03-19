Imports AATM.ServicesLayer.Services

''' <summary>
'''     The Model in MVP design pattern.
'''     Implements IModel and communicates with WCF Service.
''' </summary>
Public Class ModelSecurity
    Implements IModelSecurity

    Private ReadOnly _service = New SecurityService()

    Public Function GetControlSecurityIdNo(searchValue As String) As String _
        Implements IModelSecurity.GetControlSecurityIdNo
        Return _service.GetControlSecurityIdNo(searchValue)
    End Function

    Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList _
        Implements IModelSecurity.GetUserSecurity
        Return _service.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
    End Function

End Class