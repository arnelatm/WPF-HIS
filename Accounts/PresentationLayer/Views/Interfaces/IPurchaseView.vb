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
        Property Posted As Boolean
        Property ProductsByCode As DataTable
        Property PurchaseDetails As List(Of PurchaseDetailView)
        Property PurchaseHistory As List(Of PurchaseHistoryView)
        Property ReferenceNo As String
        Property SupplierIdNo As Int32?
        Property TransactionDate As Date?
        Property UserIdNo As Int16
        Property VatAmount As Decimal
        Property VatNumber As String
        Property WarehouseIdNo As Int16

        Property PurchaseDetailsBs As BindingSource
        'Property UnitsByCode As DataTable
        Property UnitsByCode As Object
        'Property UnitsByProduct As DataTable
        Property UnitsByProduct As Object
        Property ProductCodeIsValid As Boolean
        Property NumberOfUnits As Short
        Property ProductNameIsValid As Boolean
        Event ProductUnitEditing(productIdNo As Int32) ', bs As BindingSource)
        Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource)
        Event ProductCodeChanged(productCode As String, bs As BindingSource)
        Event RowChanged(productIdNo As Integer)
        Event PostData(idNo As Int32)
        Event ProductCodeValidating(productCode As String, control As Control)
        Event ProductNameValidating(productName As String, control As Control)
        'Event ProductNameChanged(productName As String, bs As BindingSource)
    End Interface

End Namespace