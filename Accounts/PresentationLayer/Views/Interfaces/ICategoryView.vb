Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ICategoryView
        Inherits IView
        Property IdNo As Int16
        Property CategoryCode As String
        Property CategoryName As String
        Property CategoryNameAra As String
        Property PurchaseAccountIdNo As Int16
        Property SaleAccountIdNo As Int16
        Property VatPurchaseAccountIdNo As Int16
        Property VatSaleAccountIdNo As Int16
        Property VatPercentage As Decimal
        Property Notes As String
    End Interface

End Namespace