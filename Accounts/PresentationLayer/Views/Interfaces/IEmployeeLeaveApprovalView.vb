Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveApprovalView
        Inherits IView

        Property IdNo As Int32
        Property ApprovedBy As Int32
        Property DateCreated As DateTime?
        Property EmployeeLeaveApprovalItems As List(Of EmployeeLeaveApprovalItemView)
        Property EmployeeList As DataTable
        Property LeaveList As DataTable
        Property LeaveStatusList As DataTable
        Property ApprovalStatusList As DataTable

        Event ApprovalCheckedEvent(sender As Object)

    End Interface

End Namespace