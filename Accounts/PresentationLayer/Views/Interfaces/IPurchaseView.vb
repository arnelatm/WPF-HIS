Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPurchaseView
        Inherits IView

        Property Amount As Decimal
        ReadOnly Property BranchIdNo As Int16
        Property Cancelled As Boolean
        Property DateCreated As DateTime?
        Property DueDate As Date?
        Property IdNo As Int32
        Property InvoiceDate As Date?
        Property InvoiceNo As String
        Property ReferenceNo As String
        Property SupplierIdNo As Int32?
        Property TransactionDate As Date?
        Property VatAmount As Decimal
        Property VatNumber As String
        Property Posted As Boolean
        Property WarehouseIdNo As Int16
        Property PurchaseDetails As List(Of PurchaseDetailView)
        Property PurchaseHistory As List(Of PurchaseHistoryView)
        Property ProductsByCode As DataTable
        Property UnitsByCode As DataTable
        Property UnitsByProduct As DataTable

        Event ProductUnitEditing(productIdNo As Int32) ', bs As BindingSource)
        Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource)
        Event ProductCodeChanged(productCode As String, bs As BindingSource)
        Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String)
        Event UnitChanged(oldUnit As Short, newUnit As Short, bs As BindingSource, formattedValue As String)
        Event RowChanged(productIdNo As Integer)
        'Event ProductNameChanged(productName As String, bs As BindingSource)
    End Interface

End Namespace