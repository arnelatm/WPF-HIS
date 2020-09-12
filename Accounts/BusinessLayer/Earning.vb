' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Earning
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EarningName"))
                AddRule(New ValidateRequired("EarningCode"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property EarningCode As String
        Public Property EarningName As String
        Public Property EarningNameAra As String
        Public Property AccountIdNo As Int32
        Public Property DefaultFrequency As Char
        Public Property EarningType As Char
        Public Property Notes As String
    End Class

End Namespace