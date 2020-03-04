Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Common.PresentationLayer.Models
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class UserPresenter
        Inherits CommonPresenter(Of IUserView, UserModel)

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

        'Public Function GetUserList()
        '    Return GetTreeViewList("UserName")
        'End Function
    End Class

End Namespace