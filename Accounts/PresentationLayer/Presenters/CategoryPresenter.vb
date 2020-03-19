Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class CategoryPresenter
        Inherits AccountsPresenter(Of ICategoryView, CategoryModel)

        Public Sub New(view As ICategoryView)
            MyBase.New(view)
            InitializerWithTv("Category")
        End Sub

    End Class

End Namespace