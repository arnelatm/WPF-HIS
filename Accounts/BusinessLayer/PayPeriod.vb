' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PayPeriod
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("PayPeriodName"))
                AddRule(New ValidateRequired("PayPeriodCode"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property PayCycleIdNo As Int16
        Public Property StartDate As Date
        Public Property EndDate As Date
        Public Property Description As String
    End Class

End Namespace