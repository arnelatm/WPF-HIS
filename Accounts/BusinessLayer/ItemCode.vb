' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class ItemCode
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("CodeGroupIdNo"))
                AddRule(New ValidateRequired("ItemCodeName"))
                AddRule(New ValidateRequired("ItemCodeCode"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property CodeGroupIdNo As Int16
        Public Property ItemCodeCode As String
        Public Property ItemCodeName As String
        Public Property ItemCodeNameAra As String
        Public Property DateCreated As Date

    End Class

End Namespace