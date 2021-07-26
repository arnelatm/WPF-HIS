Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class PurchaseItemPresenter(Of TM As New)
        Inherits PresenterNew(Of IPurchaseItemView, TM)

        Public Sub New(view As IPurchaseItemView)
            MyBase.New(view)
            Service = New AccountsService("PurchaseItem")
            TableName = "PurchaseItem"
            TreeViewMainField = "PurchaseItemName"
            TreeViewSecondaryField = "PurchaseItemCode"
            SortOrderKey = "PurchaseItemName"
        End Sub

    End Class

End Namespace