' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Leave
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("LeaveName"))
                AddRule(New ValidateRequired("LeaveCode"))
            End If
        End Sub

        Public Property Earnable As Boolean
        Public Property IdNo As Int16
        Public Property LeaveCode As String
        Public Property LeaveCycle As String
        Public Property LeaveName As String
        Public Property LeaveNameAra As String
        Public Property LeaveAllowed As Decimal
        Public Property PaidPercent As Decimal
        Public Property Cumulative As Boolean
        Public Property Holiday As Boolean
        Public Property MaxCarryOver As Decimal
        Public Property MaxLimit As Decimal
        Public Property NoMaxLimit As Boolean
        Public Property Notes As String
    End Class

End Namespace