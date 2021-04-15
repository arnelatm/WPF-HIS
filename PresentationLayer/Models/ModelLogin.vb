Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

''' <summary>
'''     The Model in MVP design pattern.
'''     Implements IModel and communicates with WCF Service.
''' </summary>
Public Class ModelLogin
    Implements IModelLogin

    Public Sub New()
    End Sub

    Public Shared ReadOnly Property LoginService As Object
        Get
            Return New ServiceLogin()
        End Get
    End Property

    Public Function Login(userName As String, password As String) As Boolean Implements IModelLogin.Login
        Return LoginService.Login(userName, password)
    End Function

    Public Function EncryptPassword(userLoginIdNo As Int32, password As String) As String Implements IModelLogin.EncryptPassword
        Return LoginService.EncryptPassword(userLoginIdNo, password)
    End Function

    Public Function DecryptPassword(userName As String, password As String) As String Implements IModelLogin.DecryptPassword
        Return LoginService.DecryptPassword(userName, password)
    End Function

    Public Function SavePassword(userIdNo, password) Implements IModelLogin.SavePassword
        Return LoginService.SavePassword(userIdNo, password)
    End Function

End Class