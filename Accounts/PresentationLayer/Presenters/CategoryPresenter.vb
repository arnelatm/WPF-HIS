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
            TableName = "Category"
            SortOrderKey = "IdNo"
            TreeViewMainField = "CategoryName"
            TreeViewSecondaryField = "CategoryCode"
            ModelPresenter = New ModelCategory()
            TreeViewList = New List(Of CategoryModel)
            OriginalModel = New CategoryModel()
            DataBizObject = New Category(True)
            DataModel = New CategoryModel
        End Sub

    End Class

End Namespace