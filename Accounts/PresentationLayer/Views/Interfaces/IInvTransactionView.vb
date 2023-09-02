Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IInvTransactionView
        Inherits IInvTransactionBaseView

        Property InvTransactionDetails As List(Of InvTransactionDetailView)
        'Property UnitsByCode As DataTable
        Property UnitsByCode As Object
        'Property UnitsByProduct As DataTable
        Property UnitsByProduct As Object
        Property ProductsByCode As DataTable
        Property InventoryAction As String
        Property InvTransactionDetailsBs As BindingSource
        Property ProductCodeIsValid As Boolean
        Property NumberOfUnits As Int16
        WriteOnly Property WarehouseToIdNoEnabled As Boolean
        Property ProductNameIsValid As Boolean
        Property ProductInInventory As Boolean
        Property ValidationErrorText As String
        Event ProductUnitEditing(productIdNo As Int32) ', bs As BindingSource)
        Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource)
        Event ProductCodeChanged(productCode As String, bs As BindingSource)
        Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String)
        'Event UnitChanged(oldUnit As Short, newUnit As Short, bs As BindingSource, formattedValue As String)
        Event RowChanged(productIdNo As Integer)
        Event PostData(idNo As Int32)
        Event InvTransactionTypeChanged(invTransTypeIdNo As Int16)
        Event ProductCodeValidating(productCode As String, control As Control)
        Event ProductNameValidating(productName As String, control As Control)
    End Interface

    Public Interface IInvTransactionBaseView
        Inherits IView

        Property Amount As Decimal
        Property Cancelled As Boolean
        Property DateCreated As Date
        Property IdNo As Int32
        Property InvTransTypeIdNo As Int16
        Property Notes As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property TransactionDate As Date?
        Property UserIdNo As Int16
        Property WarehouseIdNo As Int16
        Property WarehouseToIdNo As Int16?
    End Interface

    Public Interface IInvRequestView
        Inherits IView
        Property InvTransactionRequests As List(Of IInvTransactionBaseView)
        Property WarehouseIdNo As Int16
        Property WarehouseList As DataTable
        Property UserList As DataTable
        Property InvTransactionDetails As List(Of InvTransactionDetailView)
        Event WarehouseIdNoChanged()
        Event RowChanged(productIdNo As Integer)
    End Interface

    'Public Interface IInvRequestListView
    '    Inherits IView

    '    Property Amount As Decimal
    '    Property Cancelled As Boolean
    '    Property DateCreated As Date
    '    Property IdNo As Int32
    '    Property InvTransTypeIdNo As Int16
    '    Property Notes As String
    '    Property Posted As Boolean
    '    Property ReferenceNo As String
    '    Property TransactionDate As Date?
    '    Property UserIdNo As Int16
    '    Property WarehouseIdNo As Int16
    '    Property WarehouseToIdNo As Int16?
    'End Interface

End Namespace