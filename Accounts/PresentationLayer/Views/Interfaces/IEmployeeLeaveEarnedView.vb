Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveEarnedView
        Inherits IView

        Property DateCreated As DateTime?
        Property DaysEarned As Decimal
        Property EmployeeIdNo As Int32
        Property EndDate As Date?
        Property EnteredBy As Int32
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        Property Reason As String
        Property StartDate As Date?

    End Interface

End Namespace