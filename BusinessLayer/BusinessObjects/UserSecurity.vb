Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessObjects
    ' Category business object
    ' ** Enterprise Design Pattern: Domain Model, Identity Field

    Public Class UserSecurity
        Inherits BusinessObject


        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("UserName"))
            End If
        End Sub

        Public Property IdNo As Int16
        Public Property UserName As String
        Public Property Active As Boolean
        Public Property UserAccesses As List(Of UserAccess)

    End Class

End Namespace