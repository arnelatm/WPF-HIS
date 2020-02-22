Imports AATM.BusinessLayer.BusinessObject
Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Presenters

    Public Class UserPresenter
        Inherits CommonPresenterOld(Of IUserView, User, UserModel)

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

End Namespace