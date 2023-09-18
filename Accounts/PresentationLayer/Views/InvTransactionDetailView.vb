Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class InvTransactionDetailView
        Implements IInvTransactionDetailView

        Public Property BaseUnitIdNo As Int16 Implements IInvTransactionDetailView.BaseUnitIdNo
        Public Property BatchNo As String Implements IInvTransactionDetailView.BatchNo
        Public Property CategoryIdNo As Short Implements IInvTransactionDetailView.CategoryIdNo
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property ExpiryDate As Date? Implements IInvTransactionDetailView.ExpiryDate
        Public Property IdNo As Int32 Implements IInvTransactionDetailView.IdNo
        Public Property InventoryIdNo As Int32 Implements IInvTransactionDetailView.InventoryIdNo
        Public Property InvTransactionIdNo As Int32 Implements IInvTransactionDetailView.InvTransactionIdNo
        Public Property NeedsExpiryDate As Boolean Implements IInvTransactionDetailView.NeedsExpiryDate
        Public Property NetAmount As Decimal Implements IInvTransactionDetailView.NetAmount
        Public Property ProductCode As String Implements IInvTransactionDetailView.ProductCode
        Public Property ProductIdNo As Int32 Implements IInvTransactionDetailView.ProductIdNo
        Public Property ProductName As String Implements IInvTransactionDetailView.ProductName
        Public Property ProductNameAra As String Implements IInvTransactionDetailView.ProductNameAra
        Public Property Quantity As Int16 Implements IInvTransactionDetailView.Quantity
        Public Property Sequence As Int16 Implements IInvTransactionDetailView.Sequence
        Public Property UnitCost As Decimal Implements IInvTransactionDetailView.UnitCost
        Public Property UnitCount As Int16 Implements IInvTransactionDetailView.UnitCount
        Public Property UnitIdNo As Int16 Implements IInvTransactionDetailView.UnitIdNo

    End Class


    Public Class InvRequestDetailView
        Inherits InvTransactionDetailView
        Implements IInvRequestDetailView

        Public Property BaseUnitName As String Implements IInvRequestDetailView.BaseUnitName
        Public Property QtyApproved As Decimal Implements IInvRequestDetailView.QtyApproved
        Public Property QtyOnHand As Decimal Implements IInvRequestDetailView.QtyOnHand
        Public Property QtySupplied As Decimal Implements IInvRequestDetailView.QtySupplied
        Public Property UnitName As String Implements IInvRequestDetailView.UnitName

    End Class

End Namespace