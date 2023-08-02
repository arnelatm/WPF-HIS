Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IInvTransactionView
        Inherits IView

        Property Amount As Decimal
        Property Cancelled As Boolean
        Property DateCreated As DateTime
        Property IdNo As Int32
        Property InvTransTypeIdNo As Int16
        Property Notes As String
        Property Posted As Boolean
        Property InvTransactionDetails As List(Of InvTransactionDetailView)
        Property ReferenceNo As String
        Property TransactionDate As Date?
        Property UserIdNo As Int16
        Property WarehouseIdNo As Int16
        Property WarehouseToIdNo As Int16?

        Property UnitsByCode As DataTable
        Property UnitsByProduct As DataTable
        Property ProductsByCode As DataTable
        Property ProductInventory As List(Of InventoryModel)
        Event ProductUnitEditing(productIdNo As Int32) ', bs As BindingSource)
        Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource)
        Event ProductCodeChanged(productCode As String, bs As BindingSource)
        Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String)
        Event UnitChanged(oldUnit As Short, newUnit As Short, bs As BindingSource, formattedValue As String)
        Event RowChanged(productIdNo As Integer)
        Event PostData(idNo As Int32)


    End Interface

End Namespace