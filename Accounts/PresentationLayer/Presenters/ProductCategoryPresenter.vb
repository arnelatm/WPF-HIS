Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters

    Public Class ProductCategoryPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IProductCategoryView, TM)

        Public Sub New(view As IProductCategoryView)
            MyBase.New(view)
            Service = New ServiceAccounts("ProductCategory")
            TableName = "ProductCategory"
            TreeViewMainField = "ProductCategoryName"
            TreeViewSecondaryField = "ProductCategoryCode"
            SortOrderKey = "ProductCategoryName"
        End Sub

    End Class

End Namespace