Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class ProductCategoryPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IProductCategoryView, TM)

        Public Sub New(view As IProductCategoryView)
            MyBase.New(view)
            Service = New AccountsService("ProductCategory")
            TableName = "ProductCategory"
            TreeViewMainField = "ProductCategoryName"
            TreeViewSecondaryField = "ProductCategoryCode"
            SortOrderKey = "ProductCategoryName"
        End Sub

    End Class

End Namespace