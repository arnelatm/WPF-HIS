Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PurchaseDetailView
        Implements IPurchaseDetailView

        Public Property BonusQuantity As Int16 Implements IPurchaseDetailView.BonusQuantity
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property DiscountAmount As Decimal Implements IPurchaseDetailView.DiscountAmount
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Int32 Implements IPurchaseDetailView.IdNo
        Public Property NetAmount As Decimal Implements IPurchaseDetailView.NetAmount
        Public Property Price As Decimal Implements IPurchaseDetailView.Price
        Public Property ProductCode As String Implements IPurchaseDetailView.ProductCode
        Public Property ProductIdNo As Int32 Implements IPurchaseDetailView.ProductIdNo
        Public Property ProductName As String Implements IPurchaseDetailView.ProductName
        Public Property PurchaseIdNo As Int32 Implements IPurchaseDetailView.PurchaseIdNo
        Public Property Quantity As Int16 Implements IPurchaseDetailView.Quantity
        Public Property Sequence As Int16 Implements IPurchaseDetailView.Sequence
        Public Property UnitCount As Int16 Implements IPurchaseDetailView.UnitCount
        Public Property UnitIdNo As Int16 Implements IPurchaseDetailView.UnitIdNo
        Public Property VatAmount As Decimal Implements IPurchaseDetailView.VatAmount
        Public Property VatPercent As Decimal Implements IPurchaseDetailView.VatPercent


    End Class

End Namespace