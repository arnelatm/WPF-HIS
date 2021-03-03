' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EarningSummary
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateContent("Multiplier", 0, ValidationOperator.NotEqual, ValidationDataType.Decimal))
            End If
        End Sub

        Public Property EarningGroupIdNo As Int16
        Public Property EarningIdNo As Int16
        Public Property IdNo As Int16
        Public Property Multiplier As Decimal
        Public Property Sequence As Int16

    End Class

End Namespace