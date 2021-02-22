' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Payroll
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("PayrollName"))
                AddRule(New ValidateRequired("PayrollCode"))
                AddRule(New ValidateCompare("StartDate", "EndDate", ValidationOperator.LessThanOrEqual, ValidationDataType.Date))
            End If
        End Sub

        Public Property EndDate As Date
        Public Property IdNo As Int32
        Public Property PayCycleIdNo As Int16
        Public Property PayrollCode As String
        Public Property PayrollName As String
        Public Property PayrollNameAra As String
        Public Property StartDate As Date
        Public Property PayrollAttendance As List(Of AttendanceItem)
    End Class

End Namespace