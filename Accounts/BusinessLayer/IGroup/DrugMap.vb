' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class DrugMap
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("GTIN"))
                AddRule(New ValidateRequired("Expiry"))
                AddRule(New ValidateRequired("SerialNo"))
                AddRule(New ValidateRequired("Batch"))
                'AddRule(New ValidateRequired("DrugMapCode"))
            End If

        End Sub

        Public Property Batch As String
        Public Property BranchID As String
        Public Property CashPrice As Decimal
        Public Property Expiry As Date
        Public Property GTIN As String
        Public Property IdNo As Int32
        Public Property Item_Code As String
        Public Property ItemNameEnglish As String
        Public Property PurchaseNo As Decimal
        Public Property Quantity As Decimal
        Public Property SerialNo As String

    End Class

End Namespace