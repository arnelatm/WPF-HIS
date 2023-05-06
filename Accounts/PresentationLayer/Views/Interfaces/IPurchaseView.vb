Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPurchaseView
        Inherits IView

        Property Amount As Decimal
        Property Cancelled As Boolean
        Property DateCreated As DateTime?
        Property DueDate As Date?
        Property IdNo As Int32
        Property InvoiceDate As Date?
        Property InvoiceNo As String
        Property SupplierIdNo As Int32?
        Property TransactionDate As Date?
        Property VatAmount As Decimal
        Property VatNumber As String
        Property Posted As Boolean
        Property PurchaseDetails As List(Of PurchaseDetailView)
        Property ProductsByCode As Object
        Property UnitsByCode As Object
        Property UnitsByProduct As Object
        Event ProductUnitEditing(productIdNo As Int32, bs As BindingSource)
        Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource)
        Event ProductCodeChanged(productCode As String, bs As BindingSource)
        Event ProductNameChanged(productName As String, bs As BindingSource)
    End Interface

End Namespace