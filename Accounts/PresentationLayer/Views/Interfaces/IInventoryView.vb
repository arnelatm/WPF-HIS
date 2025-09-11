Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IInventoryView
        Inherits IView

        Property BatchNo As String
        Property ExpiryDate As Date
        Property IdNo As Int32
        Property ProductIdNo As Int32
        Property QtyOnHand As Decimal
        Property TotalCost As Decimal
        Property TransactionIdNo As Int32
        Property UnitCost As Decimal
        Property UnitSalesPrice As Decimal
        Property WarehouseIdNo As Int16

    End Interface

End Namespace