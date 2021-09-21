Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveCreditView
        Inherits IView
        Property IdNo As Int16
        Property EmployeeIdNo As Int32
        Property LeaveIdNo As Int16
        Property LeaveAllowed As Int16
        Property PaidPercent As Decimal
        Property Cumulative As Boolean
        Property MaxCarryOver As Int16
        Property MaxLimit As Int16
        Property AccumulatedLeaves As Int16
    End Interface

End Namespace