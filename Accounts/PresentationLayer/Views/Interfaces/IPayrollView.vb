Imports AATM.Accounts.BusinessLayer
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayrollView
        Inherits IView
        Property EndDate As Date
        Property IdNo As Int32
        Property PayCycleIdNo As Int16
        Property PayrollCode As String
        Property PayrollName As String
        Property PayrollNameAra As String
        Property StartDate As Date
        Property PayrollAttendance As List(Of AttendanceItemView)
        Property PayrollOvertime As List(Of OtWorkHourView)
    End Interface

End Namespace