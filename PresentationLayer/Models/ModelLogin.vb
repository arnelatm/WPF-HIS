Imports AATM.ServicesLayer.Services



Public Class ModelLogin
        Implements IModelLogin

        Private Shared ReadOnly Property Service As New LoginService()

    Public Function GetLoginService()
        Return Service
    End Function


    Public Function Login(ByVal userName As String, ByVal password As String)
        Return Service.Login(userName, password)
    End Function

End Class

    Public Interface IModelLogin
    End Interface

