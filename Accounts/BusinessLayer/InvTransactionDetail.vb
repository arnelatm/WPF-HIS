' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Accounts.PresentationLayer.Views

Namespace BusinessLayer

    Public Class InvTransactionDetail
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property BaseUnitIdNo As Int16
        Public Property BatchNo As String
        Public Property CategoryIdNo As Int16
        Public Property ExpiryDate As Date?
        Public Property IdNo As Int32
        Public Property InvTransactionIdNo As Int32
        Public Property InventoryIdNo As Int32
        Public Property NeedsExpiryDate As Boolean
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


    Public Class InvRequestDetail
        Inherits InvTransactionDetail

        Public Property QtyOnHand As Decimal
        Public Property QtySupplied As Decimal
        Public Property UnitName As String
        Public Property BaseUnitName As String


    End Class

End Namespace