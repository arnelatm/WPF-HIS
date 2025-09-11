Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPurchaseView
        Inherits IPurchaseBaseView

        Property ProductsByCode As DataTable
        Property PurchaseDetails As List(Of PurchaseDetailView)
        Property PurchaseHistory As List(Of PurchaseHistoryView)
        Property PurchaseDetailsBs As BindingSource
        Property UnitsByCode As Object
        Property UnitsByProduct As Object
        Property ProductCodeIsValid As Boolean
        Property NumberOfUnits As Short
        Property ProductNameIsValid As Boolean
        Property PurchaseOrder As Boolean
        Event ProductUnitEditing(productIdNo As Int32) ', bs As BindingSource)
        Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource)
        Event ProductCodeChanged(productCode As String, bs As BindingSource)
        Event RowChanged(productIdNo As Integer)
        Event PostData(idNo As Int32)
        Event ProductCodeValidating(productCode As String, control As Control)
        Event ProductNameValidating(productName As String, control As Control)
        Event FilterRecords()
        'Event ProductNameChanged(productName As String, bs As BindingSource)
    End Interface

    Public Interface IPurchaseBaseView
        Inherits IView
        Property Amount As Decimal
        Property Approved As Boolean
        Property Cancelled As Boolean
        Property DateCreated As DateTime?
        Property Disapproved As Boolean
        Property DueDate As Date?
        Property IdNo As Int32
        Property InvoiceDate As Date?
        Property InvoiceNo As String
        Property Notes As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property SupplierIdNo As Int32?
        Property TransactionDate As Date?
        Property UserIdNo As Int16
        Property VatAmount As Decimal
        Property VatNumber As String
        Property WarehouseIdNo As Int16

    End Interface

    Public Interface IPurchaseOrderApprovalView
        Inherits IView
        Property UnpostedPurchaseOrders As List(Of IPurchaseBaseView)
        Property WarehouseIdNo As Int16
        Property WarehouseList As DataTable
        Property SupplierList As DataTable
        Property UserList As DataTable
        Property UnitList As DataTable
        Property PurchaseOrderDetails As List(Of PurchaseOrderApprovalDetailView)

        Event RowChanged(productIdNo As Integer)
        Event FormLoaded()
        Event SupplyQuantityClicked(invTransIdNo As Integer)
        Event ApproveSelectedPO(invTransIdNo As Integer)
    End Interface

End Namespace