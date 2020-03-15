Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class SupplierPresenter
        Inherits AccountsPresenter(Of ISupplierView, SupplierModel)

        Public ParentViewList As List(Of SupplierModel)

        Public Sub New(view As ISupplierView)
            MyBase.New(view)
            ModelPresenter = New ModelSupplier()
            TableName = "Supplier"
            SortOrderKey = "SupplierName"
            TreeViewMainField = "SupplierName"
            TreeViewSecondaryField = "SupplierCode"
            TreeViewList = New List(Of SupplierModel)
            OriginalModel = New SupplierModel()
            DataModel = New SupplierModel
            ParentViewList = New List(Of SupplierModel)

        End Sub

    End Class

End Namespace