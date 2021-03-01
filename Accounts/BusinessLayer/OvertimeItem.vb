' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class OvertimeItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
        End Sub

        Public Property IdNo As Int32
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property OvertimeRegular As Decimal
        Public Property OvertimeHoliday As Decimal
        Public Property OvertimeSpecial As Decimal
        Public Property PayrollIdNo As Int16
        Public Property Sequence As Int16
    End Class

End Namespace