' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Unit
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("UnitName"))
                AddRule(New ValidateRequired("UnitCode"))
            End If
        End Sub

        Public Property UnitCode As String
        Public Property UnitName As String
        Public Property UnitNameAra As String
        Public Property IdNo As Int16
    End Class

End Namespace