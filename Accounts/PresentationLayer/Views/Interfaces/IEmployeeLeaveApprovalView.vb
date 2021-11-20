Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveApprovalView
        Inherits IView

        Property EmployeeLeaveList As List(Of IEmployeeLeaveView)
        Property EmployeeList As List(Of Lookup.LookupData)
        Property LeaveList As List(Of Lookup.LookupData)
        Property LeaveStatusList As List(Of Lookup.LookupData)
        Property ApprovalStatusList As List(Of Lookup.LookupData)

        'Event ClearAllEmployee(sender As Object, clear As Boolean)

        'Event EmployeeIdCheckedEvent(sender As Object)

    End Interface

End Namespace