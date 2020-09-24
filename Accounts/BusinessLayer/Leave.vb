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

        Public Property IdNo As Int16
        Public Property LeaveCode As String
        Public Property LeaveName As String
        Public Property LeaveNameAra As String
        Public Property LeaveAllowed As Byte
        Public Property PaidPercent As Decimal
        Public Property Cumulative As Boolean
        Public Property MaxCarryOver As Int16
        Public Property MaxLimit As Int16
        Public Property NoMaxLimit As Boolean
        Public Property Notes As String
    End Class

End Namespace