Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveApprovalView
        Inherits IView

        Property EmployeeLeaveList As List(Of IEmployeeLeaveView)

        'Event ClearAllEmployee(sender As Object, clear As Boolean)

        'Event EmployeeIdCheckedEvent(sender As Object)

    End Interface

End Namespace