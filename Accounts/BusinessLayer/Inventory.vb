' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Inventory
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern

        Public Property BatchNo As String
        Public Property ExpiryDate As Date
        Public Property IdNo As Int32
        Public Property NetAmount As Decimal
        Public Property ProductIdNo As Int32
        Public Property PurchaseDetailIdNo As Int32
        Public Property QtyOnHand As Decimal
        Public Property UnitCost As Decimal
        Public Property UnitSalesPrice As Decimal
        Public Property WarehouseIdNo As Int16

    End Class

End Namespace