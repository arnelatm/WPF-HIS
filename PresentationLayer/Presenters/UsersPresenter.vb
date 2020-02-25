Imports AATM.BusinessLayer
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer.AdoNet
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Public Class UsersPresenter
    Inherits Presenter(Of IUsersView, User, UserModel)

    Protected ViewObject As List(Of UserModel)

    ''' <summary>
    '''     Constructor
    ''' </summary>
    ''' <param name="view">The view.</param>
    Public Sub New(view As IUsersView)
        MyBase.New(view)
        TableName = "User"
        SortOrderKey = "FullName"
        OriginalModel = New List(Of UserModel)
        BizObject = New List(OF User)
        ViewObject = New List(Of UserModel)
        DbDataDao = New UserDao
    End Sub
End Class