Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPurchaseDetailView
        Inherits IPurchaseDetailBaseView

        Property AmtBefVat As Decimal
        Property BaseUnitIdNo As Int16
        Property BatchNo As String
        Property BonusQuantity As Decimal
        Property CategoryIdNo As Int16
        Property DiscountAmount As Decimal
        Property DiscountPercent As Decimal
        Property ExpiryDate As Date?
        Property GrossAmount As Decimal
        Property NeedsExpiryDate As Boolean
        Property PurchaseIdNo As Int32
        Property UnitCount As Int16
        Property UnitCost As Decimal
        Property UnitSalesPrice As Decimal
        Property VatAmount As Decimal
        Property VatPercent As Decimal
    End Interface


    Public Interface IPurchaseHistoryView
        Inherits IView


        Property BatchNo As String
        Property BonusQuantity As Decimal
        Property ExpiryDate As Date?
        Property GrossAmount As Decimal
        Property IdNo As Int32
        Property Price As Decimal
        Property PurchaseIdNo As Int32
        Property Quantity As Decimal
        Property SupplierCode As String
        Property SupplierName As String
        Property SupplierNameAra As String
        Property TransactionDate As Date
        Property UnitCost As Decimal
        Property UnitName As String
        Property UnitSalesPrice As Decimal

    End Interface

    Public Interface IPurchaseDetailBaseView
        Inherits IView

        Property IdNo As Int32
        Property NetAmount As Decimal
        Property Price As Decimal
        Property ProductCode As String
        Property ProductIdNo As Int32
        Property ProductName As String
        Property ProductNameAra As String
        Property Quantity As Decimal
        Property Sequence As Int16
        Property UnitIdNo As Int16

    End Interface

End Namespace