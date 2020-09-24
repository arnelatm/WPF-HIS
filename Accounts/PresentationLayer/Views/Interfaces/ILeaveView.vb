Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ILeaveView
        Inherits IView
        Property IdNo As Int16
        Property LeaveCode As String
        Property LeaveName As String
        Property LeaveNameAra As String
        Property LeaveAllowed As Int16
        Property PaidPercent As Decimal
        Property Cumulative As Boolean
        Property MaxCarryOver As Int16
        Property MaxLimit As Int16
        Property Notes As String
    End Interface

End Namespace