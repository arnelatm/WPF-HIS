Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PurchaseDetailView
        Implements IPurchaseDetailView

        Public Property BonusQuantity As Int32 Implements IPurchaseDetailView.BonusQuantity
        Public Property DiscountAmount As Decimal Implements IPurchaseDetailView.DiscountAmount
        Public Property IdNo As Int32 Implements IPurchaseDetailView.IdNo
        Public Property NetAmount As Decimal Implements IPurchaseDetailView.NetAmount
        Public Property Price As Decimal Implements IPurchaseDetailView.Price
        Public Property ProductIdNo As Int32 Implements IPurchaseDetailView.ProductIdNo
        Public Property ProductName As String Implements IPurchaseDetailView.ProductName
        Public Property PurchaseIdNo As Int32 Implements IPurchaseDetailView.PurchaseIdNo
        Public Property Quantity As Int32 Implements IPurchaseDetailView.Quantity
        Public Property Sequence As Int16 Implements IPurchaseDetailView.Sequence
        Public Property UnitIdNo As Int32 Implements IPurchaseDetailView.UnitIdNo
        Public Property VatAmount As Decimal Implements IPurchaseDetailView.VatAmount
        Public Property VatPercent As Decimal Implements IPurchaseDetailView.VatPercent
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter

    End Class

End Namespace