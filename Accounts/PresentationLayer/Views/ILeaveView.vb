Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ILeaveView
        Inherits IView
        Property IdNo As Int16
        Property LeaveCode As String
        Property LeaveName As String
        Property LeaveNameAra As String
        Property LeaveType As Char
        Property LeaveAllowed As Byte
        Property PaidPercent As Byte
        Property Cumulative As Boolean
        Property MaxCarryOver As Int16
        Property MaxLimit As Int16
        Property Notes As String
    End Interface

End Namespace