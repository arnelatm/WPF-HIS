Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ILeaveView
        Inherits IView

        Property Earnable As Boolean
        Property IdNo As Int16
        Property LeaveCode As String
        Property LeaveType As String
        Property LeaveName As String
        Property LeaveNameAra As String
        Property LeaveAllowed As Decimal
        Property PaidPercent As Decimal
        Property Cumulative As Boolean
        Property Holiday As Boolean
        Property MaxCarryOver As Decimal
        Property MaxLimit As Decimal
        Property NoMaxLimit As Boolean
        Property Notes As String
    End Interface

End Namespace