Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PurchaseDetailView
        Inherits PurchaseDetailBaseView
        Implements IPurchaseDetailView


        Public Property AmtBefVat As Decimal Implements IPurchaseDetailView.AmtBefVat
        Public Property BaseUnitIdNo As Int16 Implements IPurchaseDetailView.BaseUnitIdNo
        Public Property BatchNo As String Implements IPurchaseDetailView.BatchNo
        Public Property BonusQuantity As Decimal Implements IPurchaseDetailView.BonusQuantity
        Public Property CategoryIdNo As Short Implements IPurchaseDetailView.CategoryIdNo
        Public Property DiscountAmount As Decimal Implements IPurchaseDetailView.DiscountAmount
        Public Property DiscountPercent As Decimal Implements IPurchaseDetailView.DiscountPercent
        Public Property ExpiryDate As Date? Implements IPurchaseDetailView.ExpiryDate
        Public Property GrossAmount As Decimal Implements IPurchaseDetailView.GrossAmount
        Public Property NeedsExpiryDate As Boolean Implements IPurchaseDetailView.NeedsExpiryDate
        Public Property PurchaseIdNo As Int32 Implements IPurchaseDetailView.PurchaseIdNo
        Public Property UnitCount As Int16 Implements IPurchaseDetailView.UnitCount
        Public Property UnitCost As Decimal Implements IPurchaseDetailView.UnitCost
        Public Property UnitSalesPrice As Decimal Implements IPurchaseDetailView.UnitSalesPrice
        Public Property VatAmount As Decimal Implements IPurchaseDetailView.VatAmount
        Public Property VatPercent As Decimal Implements IPurchaseDetailView.VatPercent

    End Class

    Public Class PurchaseHistoryView
        Implements IPurchaseHistoryView


        Public Property BatchNo As String Implements IPurchaseHistoryView.BatchNo
        Public Property BonusQuantity As Decimal Implements IPurchaseHistoryView.BonusQuantity
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property ExpiryDate As Date? Implements IPurchaseHistoryView.ExpiryDate
        Public Property GrossAmount As Decimal Implements IPurchaseHistoryView.GrossAmount
        Public Property IdNo As Int32 Implements IPurchaseHistoryView.IdNo
        Public Property Price As Decimal Implements IPurchaseHistoryView.Price
        Public Property PurchaseIdNo As Int32 Implements IPurchaseHistoryView.PurchaseIdNo
        Public Property Quantity As Decimal Implements IPurchaseHistoryView.Quantity
        Public Property SupplierCode As String Implements IPurchaseHistoryView.SupplierCode
        Public Property SupplierName As String Implements IPurchaseHistoryView.SupplierName
        Public Property SupplierNameAra As String Implements IPurchaseHistoryView.SupplierNameAra
        Public Property TransactionDate As Date Implements IPurchaseHistoryView.TransactionDate
        Public Property UnitCost As Decimal Implements IPurchaseHistoryView.UnitCost
        Public Property UnitName As String Implements IPurchaseHistoryView.UnitName
        Public Property UnitSalesPrice As Decimal Implements IPurchaseHistoryView.UnitSalesPrice

    End Class

    Public Class PurchaseDetailBaseView
        Implements IPurchaseDetailBaseView

        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property IdNo As Integer Implements IPurchaseDetailBaseView.IdNo
        Public Property NetAmount As Decimal Implements IPurchaseDetailBaseView.NetAmount
        Public Property Price As Decimal Implements IPurchaseDetailBaseView.Price
        Public Property ProductCode As String Implements IPurchaseDetailBaseView.ProductCode
        Public Property ProductIdNo As Integer Implements IPurchaseDetailBaseView.ProductIdNo
        Public Property ProductName As String Implements IPurchaseDetailBaseView.ProductName
        Public Property ProductNameAra As String Implements IPurchaseDetailBaseView.ProductNameAra
        Public Property Quantity As Decimal Implements IPurchaseDetailBaseView.Quantity
        Public Property Sequence As Short Implements IPurchaseDetailBaseView.Sequence
        Public Property UnitIdNo As Short Implements IPurchaseDetailBaseView.UnitIdNo

    End Class

End Namespace