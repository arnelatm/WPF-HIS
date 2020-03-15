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
        Public Property CategoryIdNo As Integer
        Public Property DateCreated As Date?
        Public Property GlAccountIdNo As Integer
        Public Property IdNo As Integer
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
        Public Property VatAccountIdNo As Integer

    End Class

End Namespace