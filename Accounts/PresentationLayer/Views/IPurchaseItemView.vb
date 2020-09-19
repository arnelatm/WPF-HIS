Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IPurchaseItemView
        Inherits IView
        Property IdNo As Int32
        Property ProductCategoryIdNo As Int32
        Property PurchaseItemCode As String
        Property PurchaseItemName As String
        Property PurchaseItemNameAra As String
        Property GlAccountIdNo As Int16?
        Property VatAccountIdNo As Int16?
        Property Unit1 As String
        Property Unit2 As String
        Property Unit3 As String
        Property Unit1Ara As String
        Property Unit2Ara As String
        Property Unit3Ara As String
        Property StdPrice1 As Decimal
        Property StdPrice2 As Decimal
        Property StdPrice3 As Decimal
        Property Active As Boolean
        Property DateCreated As Date?
    End Interface

End Namespace