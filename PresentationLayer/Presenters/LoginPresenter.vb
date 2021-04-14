Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

''' <summary>
'''     Login Presenter class.
''' </summary>
''' <remarks>
'''     MV Patterns: MVP design pattern.
''' </remarks>
Public Class LoginPresenter
    Inherits Presenter(Of ILoginView, LoginModel)

    ''' <summary>
    '''     Constructor.
    ''' </summary>
    ''' <param name="view">The view</param>
    Public Sub New(ByVal view As ILoginView)
        MyBase.New(view)
        ModelOfPresenter = New ModelLogin
        DataModel = New LoginModel
    End Sub

    ''' <summary>
    '''     Perform login. Gets data from view and calls model.
    ''' </summary>
    Function Login()
        Dim username As String = View.UserName
        Dim password As String = View.Password
        Return Model.Login(username, password)
    End Function

    Public Function SaveNewPassword(userIdNo As Int32, password As String, confirmation As String)
        Dim retVal As Int32 = 0
        If password = confirmation >= 6 Then
            Messaging.Show(True, "MsgPasswordMatchError")
        ElseIf Len(password) < 6 Then
            Messaging.Show(True, "MsgPasswordLengthError")
        Else
            Dim ePassword As String
            ePassword = EncryptPassword(userIdNo, password)
            If Model.GenericUpdateRecordWithIdNo(Of String)(userIdNo, "User", "Password", ePassword) Then
                retVal = Messaging.Show(True, "MsgPasswordSaved", "Password saved")
            Else
                Messaging.Show(True, "MsgPasswordNotSaved", "Password not saved")
            End If
        End If
        Return retVal
    End Function

    Public Sub EnableEdit()
        DisableSaveMemento = True
        EditMode = True
    End Sub

End Class