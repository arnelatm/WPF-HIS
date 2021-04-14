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

    Public Function SavePassword(userIdNo As Int32, password As String)
        Dim retVal As Int32 = 0
        Dim userModel As New UserModel With {.IdNo = userIdNo,
                                              .Password = password}

        If Model.GenericUpdateRecordWithIdNo(Of String)(userIdNo, "User", "Password", password) Then
            retVal = Messaging.Show(True, "MsgPasswordSaved", "Password saved")
        Else
            Messaging.Show(True, "MsgPasswordNotSaved", "Password not saved")
        End If
        Return retVal
    End Function

    Public Sub EnableEdit()
        DisableSaveMemento = True
        EditMode = True
    End Sub

End Class