' Purchaseitem business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PurchaseItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("PurchaseItemName"))
                AddRule(New ValidateRequired("PurchaseItemCode"))
                AddRule(New ValidateRequired("GlAccountIdNo"))
            End If
        End Sub

        Public Property Active As Boolean
        Public Property ProductCategoryIdNo As Int16
        Public Property DateCreated As DateTime?
        Public Property GlAccountIdNo As Int16?
        Public Property IdNo As Int32
        Public Property PurchaseItemCode As String
        Public Property PurchaseItemName As String
        Public Property PurchaseItemNameAra As String
        Public Property StdPrice1 As Decimal
        Public Property StdPrice2 As Decimal
        Public Property StdPrice3 As Decimal
        Public Property Unit1 As String
        Public Property Unit1Ara As String
        Public Property Unit2 As String
        Public Property Unit2Ara As String
        Public Property Unit3 As String
        Public Property Unit3Ara As String
        Public Property VatAccountIdNo As Int16?

    End Class

End Namespace