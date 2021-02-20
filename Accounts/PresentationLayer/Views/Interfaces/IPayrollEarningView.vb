Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayrollEarningView
        Inherits IView

        Property Amount As Decimal
        Property EmployeeIdNo As Int32
        Property EarningIdNo As Int16
        Property IdNo As Int32
        Property PayPeriodIdNo As Int32

    End Interface

End Namespace