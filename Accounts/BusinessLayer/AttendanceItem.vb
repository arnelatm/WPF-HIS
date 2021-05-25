' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace BusinessLayer

    Public Class AttendanceItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
        End Sub

        Public Property IdNo As Int32
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property DaysPresent As Decimal
        Public Property DaysAbsentWithPay As Decimal
        Public Property DaysAbsentWithoutPay As Decimal
        Public Property DaysOff As Decimal
        Public Property DaysTotal As Decimal
        Public Property PayrollIdNo As Int16
        Public Property Sequence As Int16
    End Class

End Namespace