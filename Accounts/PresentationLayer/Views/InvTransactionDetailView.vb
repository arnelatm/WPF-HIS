Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class InvTransactionDetailView
        Implements IInvTransactionDetailView


        Public Property AmtBefVat As Decimal Implements IInvTransactionDetailView.AmtBefVat
        Public Property BaseUnitIdNo As Int16 Implements IInvTransactionDetailView.BaseUnitIdNo
        Public Property BatchNo As String Implements IInvTransactionDetailView.BatchNo
        Public Property BonusQuantity As Int16 Implements IInvTransactionDetailView.BonusQuantity
        Public Property CategoryIdNo As Short Implements IInvTransactionDetailView.CategoryIdNo
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property DiscountAmount As Decimal Implements IInvTransactionDetailView.DiscountAmount
        Public Property DiscountPercent As Decimal Implements IInvTransactionDetailView.DiscountPercent
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property ExpiryDate As Date? Implements IInvTransactionDetailView.ExpiryDate
        Public Property GrossAmount As Decimal Implements IInvTransactionDetailView.GrossAmount
        Public Property IdNo As Int32 Implements IInvTransactionDetailView.IdNo
        Public Property NeedsExpiryDate As Boolean Implements IInvTransactionDetailView.NeedsExpiryDate
        Public Property NetAmount As Decimal Implements IInvTransactionDetailView.NetAmount
        Public Property Price As Decimal Implements IInvTransactionDetailView.Price
        Public Property ProductCode As String Implements IInvTransactionDetailView.ProductCode
        Public Property ProductIdNo As Int32 Implements IInvTransactionDetailView.ProductIdNo
        Public Property ProductName As String Implements IInvTransactionDetailView.ProductName
        Public Property ProductNameAra As String Implements IInvTransactionDetailView.ProductNameAra
        Public Property InvTransactionIdNo As Int32 Implements IInvTransactionDetailView.InvTransactionIdNo
        Public Property Quantity As Int16 Implements IInvTransactionDetailView.Quantity
        Public Property Sequence As Int16 Implements IInvTransactionDetailView.Sequence
        Public Property UnitCount As Int16 Implements IInvTransactionDetailView.UnitCount
        Public Property UnitIdNo As Int16 Implements IInvTransactionDetailView.UnitIdNo
        Public Property UnitCost As Decimal Implements IInvTransactionDetailView.UnitCost
        Public Property UnitSalesPrice As Decimal Implements IInvTransactionDetailView.UnitSalesPrice
        Public Property VatAmount As Decimal Implements IInvTransactionDetailView.VatAmount
        Public Property VatPercent As Decimal Implements IInvTransactionDetailView.VatPercent
        Public Property WarehouseIdNo As Int16 Implements IInvTransactionDetailView.WarehouseIdNo


    End Class

End Namespace