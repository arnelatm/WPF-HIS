Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class MainPresenter
        Inherits Presenter(Of IUserView, UserModel)

        ''' <summary>
        '''     Constructor.
        ''' </summary>
        ''' <param name="view">The view</param>
        Public Sub New(ByVal view As IUserView)
            MyBase.New(view)
            ModelPresenter = New Model("User")
            'TableName = "User"
            'SortOrderKey = "FullName"
            'TreeViewMainField = "FullName"
            'TreeViewSecondaryField = "UserName"
            'OriginalModel = New UserModel()
            'DataModel = New UserModel
            'TreeViewList = New List(Of UserModel)
            'Ea = New EventAggregator()
            'Ea.SubscribeEvent(Me)

        End Sub
    End Class
End Namespace