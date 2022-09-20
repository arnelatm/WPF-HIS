' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class DrugSale
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("GTin"))
                AddRule(New ValidateRequired("Expiry"))
                AddRule(New ValidateRequired("SerializationNo"))
                AddRule(New ValidateRequired("BatchNo"))
            End If

        End Sub

        Public Property BatchNo As String
        Public Property Expiry As Date?
        Public Property GTin As String
        Public Property IdNo As Int32
        Public Property Item_Code As String
        Public Property ItemNameEnglish As String
        Public Property SaleDate As Date?
        Public Property SerializationNo As String

    End Class

End Namespace