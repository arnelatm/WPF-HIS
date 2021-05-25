Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class ProductCategoryPresenter
        Inherits AccountsPresenter(Of IProductCategoryView, ProductCategoryModel)

        Public Sub New(view As IProductCategoryView)
            MyBase.New(view)
            InitializerWithTv("ProductCategory")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace