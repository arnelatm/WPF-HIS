Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Presenters


    Public Class SupplierPresenter
        Inherits AccountsPresenter(Of ISupplierView, Supplier, SupplierModel)

        Public ParentViewList As List(Of SupplierModel)

        Shared Sub New()
            ModelTblColProp = New ModelTblColProp
            ModelDefaultFieldValue = New ModelDefaultFieldValue
        End Sub

        Public Sub New(view As ISupplierView)
            MyBase.New(view)
            CurrentModel = New ModelSupplier()
            TableName = "Supplier"
            SortOrderKey = "SupplierName"
            TreeViewMainField = "SupplierName"
            TreeViewSecondaryField = "SupplierCode"
            TreeViewList = New List(Of SupplierModel)
            OriginalModel = New SupplierModel()
            BizObject = New Supplier
            DataModel = New SupplierModel
            ParentViewList = New List(Of SupplierModel)

        End Sub

    End Class
End NameSpace