Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IInvTransactionDetailView
        Inherits IView

        Property AmtBefVat As Decimal
        Property BaseUnitIdNo As Int16
        Property BatchNo As String
        Property BonusQuantity As Int16
        Property CategoryIdNo As Int16
        Property DiscountAmount As Decimal
        Property DiscountPercent As Decimal
        Property ExpiryDate As Date?
        Property GrossAmount As Decimal
        Property IdNo As Int32
        Property NeedsExpiryDate As Boolean
        Property NetAmount As Decimal
        Property Price As Decimal
        Property ProductCode As String
        Property ProductIdNo As Int32
        Property ProductName As String
        Property ProductNameAra As String
        Property InvTransactionIdNo As Int32
        Property Quantity As Int16
        Property Sequence As Int16
        Property UnitCount As Int16
        Property UnitIdNo As Int16
        Property UnitCost As Decimal
        Property UnitSalesPrice As Decimal
        Property VatAmount As Decimal
        Property VatPercent As Decimal
        Property WarehouseIdNo As Int16

    End Interface


End Namespace