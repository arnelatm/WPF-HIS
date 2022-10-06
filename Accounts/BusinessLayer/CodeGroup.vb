' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class CodeGroup
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("CodeGroupName"))
                AddRule(New ValidateRequired("CodeGroupCode"))
            End If
        End Sub

        Public Property IdNo As Int16
        Public Property CodeGroupCode As String
        Public Property CodeGroupName As String
        Public Property CodeGroupNameAra As String
        Public Property Notes As String

    End Class

End Namespace