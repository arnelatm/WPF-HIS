Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ISaleDetailView
        Inherits IView

        Property AmtBefVat As Decimal
        Property BaseUnitIdNo As Int16
        Property BatchNo As String
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
        Property SaleIdNo As Int32
        Property Quantity As Decimal
        Property Sequence As Int16
        Property UnitCount As Int16
        Property UnitIdNo As Int16
        Property UnitCost As Decimal
        Property VatAmount As Decimal
        Property VatPercent As Decimal

    End Interface

End Namespace