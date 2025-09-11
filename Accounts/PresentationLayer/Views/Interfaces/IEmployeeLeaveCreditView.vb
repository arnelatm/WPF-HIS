Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveCreditView
        Inherits IView
        Property AccumulatedLeave As Decimal
        Property Cumulative As Boolean
        Property EmployeeIdNo As Int32
        Property IdNo As Int32
        Property LeaveAllowed As Decimal
        Property LeaveIdNo As Int16
        Property MaxCarryOver As Decimal
        Property MaxLimit As Decimal
        Property NoMaxLimit As Boolean
        Property PaidPercent As Decimal
        Property Sequence As Int16
    End Interface

End Namespace