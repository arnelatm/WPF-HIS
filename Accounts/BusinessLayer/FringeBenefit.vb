' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class FringeBenefit
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("FringeBenefitName"))
                AddRule(New ValidateRequired("FringeBenefitCode"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property FringeBenefitCode As String
        Public Property FringeBenefitName As String
        Public Property FringeBenefitNameAra As String
        Public Property AccountIdNo As Int32
        Public Property DefaultFrequency As Char
        Public Property FringeBenefitType As Char
        Public Property Notes As String
    End Class

End Namespace