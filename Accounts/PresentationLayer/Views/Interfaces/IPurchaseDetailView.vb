Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPurchaseDetailView
        Inherits IView

        Property BonusQuantity As Int16
        Property DiscountAmount As Decimal
        Property IdNo As Int32
        Property NetAmount As Decimal
        Property Price As Decimal
        Property ProductCode As String
        Property ProductIdNo As Int32
        Property ProductName As String
        Property PurchaseIdNo As Int32
        Property Quantity As Int16
        Property Sequence As Int16
        Property UnitCount As Int16
        Property UnitIdNo As Int16
        Property UnitSalesPrice As Decimal
        Property VatAmount As Decimal
        Property VatPercent As Decimal


    End Interface

End Namespace