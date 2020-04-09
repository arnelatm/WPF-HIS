Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class CategoryPresenter
        Inherits AccountsPresenter(Of ICategoryView, CategoryModel)

        Public Sub New(view As ICategoryView)
            MyBase.New(view)
            InitializerWithTv("Category")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace