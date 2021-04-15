Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces

''' <summary>
'''     Login Presenter class.
''' </summary>
''' <remarks>
'''     MV Patterns: MVP design pattern.
''' </remarks>
Public Class LoginPresenter

    Protected Property ModelLogin As IModelLogin

    ''' <summary>
    '''     Constructor.
    ''' </summary>
    ''' <param name="view">The view</param>
    Public Sub New(ByVal view As IUserView)
        Me.View = view
        ModelLogin = New UserModel
    End Sub

    ''' <summary>
    '''     Perform login. Gets data from view and calls model.
    ''' </summary>
    Function Login()
        Dim username As String = View.UserName
        Dim password As String = View.Password
        Return ModelLogin.Login(username, password)
    End Function

    Public Property View As IUserView

    Public Function SaveNewPassword(userIdNo As Int32, password As String, confirmation As String)
        Dim retVal As Int32 = 0
        If password = confirmation >= 6 Then
            Messaging.Show(True, "MsgPasswordMatchError")
        ElseIf Len(password) < 6 Then
            Messaging.Show(True, "MsgPasswordLengthError")
        Else
            retVal = ModelLogin.SavePassword(userIdNo, password)
        End If
        Return retVal
    End Function

End Class