' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class PurchaseItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        
        Public Property BonusQuantity As Int32
        Public Property DiscountAmount As Decimal
        Public Property IdNo As Int32
        Public Property NetAmount As Decimal
        Public Property Price As Decimal
        Public Property ProductIdNo As Int16?
        Public Property ProductName As String
        Public Property PurchaseIdNo As Int32
        Public Property Quantity As Int32
        Public Property Sequence As Int16
        Public Property UnitIdNo As Int16
        Public Property VatAmount As Decimal
        Public Property VatPercent As Decimal

    End Class

End Namespace