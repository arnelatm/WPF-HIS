Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    ' Category business object
    ' ** Enterprise Design Pattern: Domain Model, Identity Field

    Public Class Religion
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("ReligionName"))
            End If
        End Sub

        Public Property IdNo As Integer
        Public Property ReligionCode As String
        Public Property ReligionName As String
        Public Property ReligionNameAra As String
        Public Property Notes As String
    End Class

End Namespace