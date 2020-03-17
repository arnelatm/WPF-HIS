Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Presenters

    Public Class CategoryPresenter
        Inherits AccountsPresenter(Of ICategoryView, CategoryModel)

        Public Sub New(view As ICategoryView)
            MyBase.New(view)
            InitializerWithTv("Category")
        End Sub

    End Class

End Namespace