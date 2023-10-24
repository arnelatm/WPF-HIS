Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class SaleDetailView
        Implements ISaleDetailView


        Public Property AmtBefVat As Decimal Implements ISaleDetailView.AmtBefVat
        Public Property BaseUnitIdNo As Int16 Implements ISaleDetailView.BaseUnitIdNo
        Public Property BatchNo As String Implements ISaleDetailView.BatchNo
        Public Property CategoryIdNo As Short Implements ISaleDetailView.CategoryIdNo
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property DiscountAmount As Decimal Implements ISaleDetailView.DiscountAmount
        Public Property DiscountPercent As Decimal Implements ISaleDetailView.DiscountPercent
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property ExpiryDate As Date? Implements ISaleDetailView.ExpiryDate
        Public Property GrossAmount As Decimal Implements ISaleDetailView.GrossAmount
        Public Property IdNo As Int32 Implements ISaleDetailView.IdNo
        Public Property NeedsExpiryDate As Boolean Implements ISaleDetailView.NeedsExpiryDate
        Public Property NetAmount As Decimal Implements ISaleDetailView.NetAmount
        Public Property Price As Decimal Implements ISaleDetailView.Price
        Public Property ProductCode As String Implements ISaleDetailView.ProductCode
        Public Property ProductIdNo As Int32 Implements ISaleDetailView.ProductIdNo
        Public Property ProductName As String Implements ISaleDetailView.ProductName
        Public Property ProductNameAra As String Implements ISaleDetailView.ProductNameAra
        Public Property SaleIdNo As Int32 Implements ISaleDetailView.SaleIdNo
        Public Property Quantity As Decimal Implements ISaleDetailView.Quantity
        Public Property Sequence As Int16 Implements ISaleDetailView.Sequence
        Public Property UnitCount As Int16 Implements ISaleDetailView.UnitCount
        Public Property UnitIdNo As Int16 Implements ISaleDetailView.UnitIdNo
        Public Property UnitCost As Decimal Implements ISaleDetailView.UnitCost
        Public Property VatAmount As Decimal Implements ISaleDetailView.VatAmount
        Public Property VatPercent As Decimal Implements ISaleDetailView.VatPercent

    End Class

End Namespace