' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Deduction
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("DeductionName"))
                AddRule(New ValidateRequired("DeductionCode"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property DeductionCode As String
        Public Property DeductionName As String
        Public Property DeductionNameAra As String
        Public Property AccountIdNo As Int32
        Public Property DefaultFrequency As Char
        Public Property DeductionType As Char
        Public Property Notes As String
    End Class

End Namespace