Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveView
        Inherits IView

        Property AppliedBy As Int32
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Integer
        Property EndDate As DateTime
        Property FullDay As Boolean
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        Property LeaveReason As String
        Property LeaveStatus As Char
        Property StartDate As DateTime

    End Interface

End Namespace