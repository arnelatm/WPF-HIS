Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Public Class UserPresenter
    Inherits Presenter(Of IUserView, UserModel)

    Public ParentViewList As List(Of UserModel)

    Public Sub New(view As IUserView)
        MyBase.New(view)
        CurrentModel = New ModelUser
        TableName = "User"
        SortOrderKey = "FullName"
        TreeViewMainField = "FullName"
        TreeViewSecondaryField = "UserName"
        OriginalModel = New UserModel()
        BizObject = New User
        DataModel = New UserModel
        TreeViewList = New List(Of UserModel)
        ParentViewList = New List(Of UserModel)

    End Sub

End Class