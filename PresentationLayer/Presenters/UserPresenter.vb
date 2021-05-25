Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views.Interfaces

Public Class UserPresenter
    Inherits Presenter(Of IUserView, UserModel)

    Public ParentViewList As List(Of UserModel)

    Public Sub New(view As IUserView)
        MyBase.New(view)
        ModelOfPresenter = New Model("User")
        TableName = "User"
        SortOrderKey = "FullName"
        TreeViewMainField = "FullName"
        TreeViewSecondaryField = "UserName"
        OriginalModel = New UserModel()
        DataModel = New UserModel
        TreeViewList = New List(Of UserModel)
        ParentViewList = New List(Of UserModel)
        Ea = New EventAggregator()
        Ea.SubscribeEvent(Me)
    End Sub

    Public Function Login() As Boolean
        Dim loginOk As Boolean
        GlobalVariables.Mapper.Map(View, DataModel)
        loginOk = DataModel.Login()
        GlobalVariables.Mapper.Map(DataModel, View)
        Return loginOk
    End Function

    Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        View.Password = DataModel.EncryptPassword(View.IdNo, View.Password)
    End Sub

    Private Sub OnSuccessfulAdd(ByRef newIdNo As Int32) Handles MyBase.RecordAddedSuccessfully
        Dim ePassword As String
        ePassword = DataModel.EncryptPassword(newIdNo, View.Password)
        If ePassword IsNot Nothing Then
            View.Password = ePassword
            Dim userModel As New UserModel
            GlobalVariables.Mapper.Map(View, userModel)
            If UpdateRecord(userModel) <= 0 Then
                Messaging.Show(True, "MsgPasswordNotSaved", "Password not saved")
            End If
        End If
    End Sub

End Class