Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IInvTransactionDetailView
        Inherits IView
        Property BaseUnitIdNo As Int16
        Property BatchNo As String
        Property CategoryIdNo As Int16
        Property ExpiryDate As Date?
        Property IdNo As Int32
        Property InventoryIdNo As Int32
        Property InvTransactionIdNo As Int32
        Property NeedsExpiryDate As Boolean
        Property NetAmount As Decimal
        Property ProductCode As String
        Property ProductIdNo As Int32
        Property ProductName As String
        Property ProductNameAra As String
        Property Quantity As Int16
        Property Sequence As Int16
        Property UnitCost As Decimal
        Property UnitCount As Int16
        Property UnitIdNo As Int16

    End Interface

    Public Interface IInvRequestDetailView

        Property BaseUnitName As String
        Property QtyApproved As Decimal
        Property QtyOnHand As Decimal
        Property QtySupplied As Decimal
        Property UnitName As String

    End Interface



End Namespace