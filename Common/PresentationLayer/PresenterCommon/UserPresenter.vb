Imports AATM.HIS.Common.BusinessLayer
Imports AATM.HIS.Common.DataLayer.AdoNet
Imports AATM.HIS.Common.PresentationLayer.Models
Imports AATM.HIS.Common.PresentationLayer.Views
Imports AATM.HIS.Common.ServiceLayer.ActionService

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