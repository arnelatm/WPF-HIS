Imports AATM.Accounts.BusinessLayer
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

    End Interface

End Namespace