Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPurchaseOrderDetailView
        Inherits IView
        Property BaseUnitIdNo As Int16
        Property CategoryIdNo As Int16
        Property IdNo As Int32
        Property PurchaseOrderIdNo As Int32
        Property NetAmount As Decimal
        Property ProductCode As String
        Property ProductIdNo As Int32
        Property ProductName As String
        Property ProductNameAra As String
        Property Quantity As Decimal
        Property Sequence As Int16
        Property UnitCost As Decimal
        Property UnitCount As Int16
        Property UnitIdNo As Int16

    End Interface

    Public Interface IPurchaseOrderApprovalDetailView

        Property BaseUnitName As String
        Property QtyApproved As Decimal
        Property QtyOnHand As Decimal
        Property QtySupplied As Decimal
        Property UnitName As String

    End Interface



End Namespace