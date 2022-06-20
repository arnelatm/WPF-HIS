Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PurchaseItemPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IPurchaseItemView, TM)

        Public Sub New(view As IPurchaseItemView)
            MyBase.New(view)
            Service = New AccountsService("PurchaseItem")
            TableName = "PurchaseItem"
            TreeViewMainField = "PurchaseItemName"
            'TreeViewSecondaryField = "PurchaseItemCode"
            SortOrderKey = "PurchaseItemName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("ProductCategory", "ProductCategoryIdNo")
            CreateDataSource("Account", "GlAccountIdNo", "DetailAccount=1")
            CreateDataSource("Account", "VatAccountIdNo", "SpecialAccount=" & GlobalFunctions.EnumToCode(SpecialAccountSelection.VatInput))
        End Sub

    End Class

End Namespace