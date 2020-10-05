Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Views.Forms
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer

    Public Class UserPresenter
        Inherits Presenter(Of IUserView, UserModel)

        Public ParentViewList As List(Of UserModel)

        Public Sub New(view As IUserView)
            MyBase.New(view)
            ModelPresenter = New Model("User")
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

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            'Password = Service.Encrypt
            Dim serviceLogin = New ServiceLogin
            View.Password = serviceLogin.EncryptPassword(View.IdNo, View.Password)
        End Sub

        Private Sub OnSuccessfulAdd(ByRef newIdNo As Int32) Handles MyBase.RecordAddedSuccessfully
            Dim serviceLogin = New ServiceLogin
            Dim ePassword As String
            ePassword = serviceLogin.EncryptPassword(newIdNo, View.Password)
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
End Namespace