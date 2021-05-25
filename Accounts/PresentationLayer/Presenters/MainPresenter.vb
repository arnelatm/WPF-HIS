Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Presenters

    Public Class MainPresenter
        Inherits Presenter(Of IUserView, UserModel)

        ''' <summary>
        '''     Constructor.
        ''' </summary>
        ''' <param name="view">The itemView</param>
        Public Sub New(ByVal view As IUserView)
            'MyBase.New(view)
            ModelOfPresenter = New Model("User")
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