Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPurchaseOrderView
        Inherits IPurchaseOrderBaseView

        Property PurchaseOrderDetails As List(Of PurchaseOrderDetailView)
        Property UnitsByCode As Object
        Property UnitsByProduct As Object
        Property ProductsByCode As DataTable
        Property PurchaseOrderDetailsBs As BindingSource
        Property ProductCodeIsValid As Boolean
        Property NumberOfUnits As Int16
        WriteOnly Property WarehouseToIdNoEnabled As Boolean
        Property ProductNameIsValid As Boolean
        Property ValidationErrorText As String

        Event ProductUnitEditing(productIdNo As Int32)
        Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource)
        Event ProductCodeChanged(productCode As String, bs As BindingSource)
        Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String)
        Event RowChanged(productIdNo As Integer)
        Event PostData(idNo As Int32)
        Event PurchaseOrderTypeChanged(invTransTypeIdNo As Int16)
        Event ProductCodeValidating(productCode As String, control As Control)
        Event ProductNameValidating(productName As String, control As Control)
    End Interface

    Public Interface IPurchaseOrderBaseView
        Inherits IView

        Property Amount As Decimal
        Property Approved As Boolean
        Property Cancelled As Boolean
        Property DateCreated As DateTime
        Property Disapproved As Boolean
        Property IdNo As Int32
        Property Notes As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property SupplierIdNo As Int32
        Property TransactionDate As Date?
        Property UserIdNo As Int16
        Property WarehouseIdNo As Int16

    End Interface

    Public Interface IPurchaseOrderApprovalView
        Inherits IView
        Property UnpostedPurchaseOrders As List(Of IPurchaseOrderBaseView)
        Property WarehouseIdNo As Int16
        Property WarehouseList As DataTable
        Property UserList As DataTable
        Property UnitList As DataTable
        Property PurchaseOrderDetails As List(Of PurchaseOrderDetailView)

        Event RowChanged(productIdNo As Integer)
        Event FormLoaded()
        Event SupplyQuantityClicked(invTransIdNo As Integer)
        Event TransferRequestClicked(invTransIdNo As Integer)
    End Interface
End Namespace