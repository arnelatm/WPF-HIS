Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayrollView
        Inherits IView
        Property EndDate As Date?
        Property IdNo As Int16
        Property PayCycleIdNo As Byte
        Property PayrollCode As String
        Property PayrollName As String
        Property PayrollNameAra As String
        Property StartDate As Date?
        Property PayrollAttendance As List(Of AttendanceItemView)
        Property PayrollOvertime As List(Of OtWorkHourView)
        Property PayFrequency As Char
        Property Employees

        Event InitializeAttendance(sender As Object)

        Event InitializeOvertime(sender As Object)

        Event GenerateRegularPayElements(sender As Object)

        Event GenerateCsvFile(payrollIdNo As Int16)

        Event InitializePayroll(sender As Object)

        Event SelectedPayrollChanged(payrollIdNo As Int16)
        Event ClearAllEmployee(sender As Object, clear As Boolean)
        Event PayCycleChanged(sender As Object)
    End Interface

End Namespace