Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    ' Category business object
    ' ** Enterprise Design Pattern: Domain Model, Identity Field

    Public Class PhoneType
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("PhoneTypeName"))
            End If
        End Sub

        Public Property IdNo As Integer
        Public Property PhoneTypeCode As String
        Public Property PhoneTypeName As String
        Public Property PhoneTypeNameAra As String
        Public Property Notes As String
    End Class

End Namespace