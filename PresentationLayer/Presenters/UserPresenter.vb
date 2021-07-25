Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class UserPresenter(Of TM As New)
    Inherits PresenterNew(Of IUserView, TM)

    Public ParentViewList As List(Of TM)
    Private serviceLogin As New ServiceLogin

    Public Sub New(view As IUserView)
        MyBase.New(view)
        Service = New Service("User")
        TableName = "User"
        SortOrderKey = "FullName"
        TreeViewMainField = "FullName"
        TreeViewSecondaryField = "UserName"
    End Sub

    Public Function Login() As Boolean
        Dim loginOk As Boolean
        Dim userModel = New TM
        GlobalVariables.Mapper.Map(View, userModel)
        loginOk = Service.Login()
        GlobalVariables.Mapper.Map(userModel, View)
        Return loginOk
    End Function

    Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        View.Password = serviceLogin.EncryptPassword(View.IdNo, View.Password)
    End Sub

    Private Sub OnSuccessfulAdd(ByRef newIdNo As Int32) Handles MyBase.RecordAddedSuccessfully
        Dim ePassword As String
        ePassword = serviceLogin.EncryptPassword(newIdNo, View.Password)
        If ePassword IsNot Nothing Then
            View.Password = ePassword
            Dim userModel As New TM
            GlobalVariables.Mapper.Map(View, userModel)
            If UpdateRecord(userModel) <= 0 Then
                Messaging.Show(True, "MsgPasswordNotSaved", "Password not saved")
            End If
        End If
    End Sub

End Class