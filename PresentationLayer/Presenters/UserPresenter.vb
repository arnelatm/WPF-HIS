Imports AATM.BusinessLayer
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer.AdoNet
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services


Public Class UserPresenter
    Inherits Presenter(Of IUserView, User, UserModel)

    Public ParentViewList As List(Of UserModel)

    Public Sub New(view As IUserView)
        MyBase.New(view)
        TableName = "User"
        SortOrderKey = "FullName"
        TreeViewMainField = "FullName"
        TreeViewSecondaryField = "UserName"
        OriginalModel = New UserModel()
        BizObject = New User
        DataModel = New UserModel
        DbDataDao = New UserDao
        TreeViewList = New List(Of UserModel)
        ParentViewList = New List(Of UserModel)
        Model.SetService(New UserService)
    End Sub

    'Public Function GetUserList()
    '    Return GetTreeViewList("UserName")
    'End Function
End Class