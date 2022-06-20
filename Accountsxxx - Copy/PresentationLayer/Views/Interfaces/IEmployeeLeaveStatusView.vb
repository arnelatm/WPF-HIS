Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveStatusView
        Inherits IView
        Property DateCreated As DateTime
        Property EnteredBy As Int32
        Property IdNo As Int16
        Property EmployeeLeaveIdNo As Int32
        Property Notes As String
        Property Status As String
    End Interface

End Namespace