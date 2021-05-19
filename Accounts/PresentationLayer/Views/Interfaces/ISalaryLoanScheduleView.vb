Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ISalaryLoanScheduleView
        Inherits IViewNew

        Property Amount As Decimal
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Int32
        Property IdNo As Int32
        Property PeriodicPayment As Decimal
        Property StartDate As Date?

    End Interface

End Namespace