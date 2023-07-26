Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ISaleView
        Inherits IView


        Property Amount As Decimal
        Property Cancelled As Boolean
        Property CustomerIdNo As Int32?
        Property DateCreated As DateTime?
        Property DueDate As Date?
        Property IdNo As Int32
        Property InvoiceNo As String
        Property PatientIdNo As Int32?
        Property PatientName As String
        Property Posted As Boolean
        Property ProductsByCode As Object
        Property TransactionDate As Date?
        Property UnitsByCode As Object
        Property UnitsByProduct As Object
        Property UserIdNo As Int16
        Property VatAmount As Decimal
        Property WarehouseIdNo As Int16

        Property SaleDetails As List(Of SaleDetailView)
        Event ProductUnitEditing(productIdNo As Int32, bs As BindingSource)
        Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource)
        Event ProductCodeChanged(productCode As String, bs As BindingSource)
        Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String)
        Event UnitChanged(oldUnit As Short, newUnit As Short, bs As BindingSource, formattedValue As String)
        Event RowChanged(productIdNo As Integer)
        'Event ProductNameChanged(productName As String, bs As BindingSource)
    End Interface

End Namespace