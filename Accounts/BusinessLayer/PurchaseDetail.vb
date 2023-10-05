' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class PurchaseDetail
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Sub New()

        End Sub

        Public Sub New(parameter As Object)
            ' establish business rules
        End Sub

        Public Property AmtBefVat As Decimal
        Public Property BaseUnitIdNo As Int16
        Public Property BatchNo As String
        Public Property BonusQuantity As Decimal
        Public Property CategoryIdNo As Int16
        Public Property DiscountAmount As Decimal
        Public Property DiscountPercent As Decimal
        Public Property ExpiryDate As Date?
        Public Property GrossAmount As Decimal
        Public Property IdNo As Int32
        Public Property NeedsExpiryDate As Boolean
        Public Property NetAmount As Decimal
        Public Property Price As Decimal
        Public Property ProductCode As String
        Public Property ProductIdNo As Int32
        Public Property ProductName As String
        Public Property ProductNameAra As String
        Public Property PurchaseIdNo As Int32
        Public Property Quantity As Decimal
        Public Property Sequence As Int16
        Public Property UnitCount As Int16
        Public Property UnitIdNo As Int16
        Public Property UnitCost As Decimal
        Public Property UnitSalesPrice As Decimal

        Public Property VatAmount As Decimal
        Public Property VatPercent As Decimal

    End Class

    Public Class PurchaseHistory
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property BatchNo As String
        Public Property BonusQuantity As Decimal
        Public Property ExpiryDate As Date?
        Public Property GrossAmount As Decimal
        Public Property IdNo As Int32
        Public Property PurchaseIdNo As Int32
        Public Property Quantity As Int16
        Public Property SupplierCode As String
        Public Property SupplierName As String
        Public Property SupplierNameAra As String
        Public Property TransactionDate As Date
        Public Property UnitCost As Decimal
        Public Property UnitName As String
        Public Property UnitSalesPrice As Decimal


    End Class

End Namespace