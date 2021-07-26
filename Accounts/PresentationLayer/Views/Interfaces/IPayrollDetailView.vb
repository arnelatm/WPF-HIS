Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayrollDetailView
        Inherits IView

        Property IdNo As Int32
        Property PayrollIdNo As Int16
        Property EmployeeIdNo As Int32
        Property EmployeeCode As String
        Property EmployeeName As String
        Property EmployeeNameAra As String
        Property StartDate As Date
        Property EndDate As Date
        Property PayPeriodName As String
        Property PayPeriodNameAra As String
        Property PayrollEarnings As List(Of PayrollPayElementView)
        Property PayrollDeductions As List(Of PayrollPayElementView)

        Event UpdateDataFilterEvent(pPayrollIdNo As Int16)

    End Interface

End Namespace