' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class PurchaseOrderDetail
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property BaseUnitIdNo As Int16
        Public Property CategoryIdNo As Int16
        Public Property IdNo As Int32
        Public Property PurchaseOrderIdNo As Int32
        Public Property NetAmount As Decimal
        Public Property ProductCode As String
        Public Property ProductIdNo As Int32
        Public Property ProductName As String
        Public Property ProductNameAra As String
        Public Property Quantity As Int16
        Public Property Sequence As Int16
        Public Property UnitCost As Decimal
        Public Property UnitCount As Int16
        Public Property UnitIdNo As Int16

    End Class


    Public Class PurchaseOrderApprovalDetail
        Inherits PurchaseOrderDetail

        Public Property QtyApproved As Decimal
        Public Property QtyOnHand As Decimal
        Public Property QtySupplied As Decimal
        Public Property UnitName As String
        Public Property BaseUnitName As String


    End Class

End Namespace