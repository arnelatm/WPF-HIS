' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PayGroup
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("PayGroupName"))
                AddRule(New ValidateRequired("PayGroupCode"))
            End If
        End Sub

        Public Property ParentIdNo As Int16?
        Public Property PayGroupCode As String
        Public Property PayGroupName As String
        Public Property PayGroupNameAra As String
        Public Property IdNo As Int16
        Public Property Notes As String
    End Class

End Namespace