Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class OtWorkHourView
        Implements IOtWorkHourView

        Public Property EmployeeIdNo As Int32 Implements IOtWorkHourView.EmployeeIdNo
        Public Property EmployeeName As String Implements IOtWorkHourView.EmployeeName
        Public Property EmployeeNameAra As String Implements IOtWorkHourView.EmployeeNameAra
        Public Property HoursWorked As Decimal Implements IOtWorkHourView.HoursWorked
        Public Property IdNo As Int32 Implements IOtWorkHourView.IdNo
        Public Property OvertimeRegular As Decimal Implements IOtWorkHourView.OvertimeRegular
        Public Property OvertimeHoliday As Decimal Implements IOtWorkHourView.OvertimeHoliday
        Public Property OvertimeSpecial As Decimal Implements IOtWorkHourView.OvertimeSpecial
        Public Property PayrollIdNo As Int16 Implements IOtWorkHourView.PayrollIdNo
        Public Property Sequence As Int16 Implements IOtWorkHourView.Sequence
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors



    End Class

End Namespace