' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeeLeaveCredit
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeIdNo"))
                AddRule(New ValidateRequired("LeaveIdNo"))
            End If
        End Sub

        Public Property AccumulatedLeave As Decimal
        Public Property Cumulative As Boolean
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int16
        Public Property LeaveAllowed As Decimal
        Public Property LeaveIdNo As Int16
        Public Property MaxCarryOver As Decimal
        Public Property MaxLimit As Decimal
        Public Property NoMaxLimit As Boolean
        Public Property PaidPercent As Decimal
        Public Property Sequence As Int16

    End Class

End Namespace