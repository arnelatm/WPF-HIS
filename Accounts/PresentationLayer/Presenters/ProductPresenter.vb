Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ProductPresenter(Of TM As New)
        Inherits CommonPresenter(Of IProductView, TM)

        Public Sub New(view As IProductView)
            MyBase.New(view)
            Service = New AccountsService("Product")
            TableName = "Product"
            TreeViewMainField = "ProductName"
            'TreeViewSecondaryField = "ProductCode"
            SortOrderKey = "ProductName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("ProductCategory", "ProductCategoryIdNo")
            CreateDataSource("Account", "GlAccountIdNo", "DetailAccount=1")
            CreateDataSource("Account", "VatAccountIdNo", "SpecialAccount=" & GlobalFunctions.EnumToCode(SpecialAccountSelection.VatInput))
        End Sub

    End Class

End Namespace