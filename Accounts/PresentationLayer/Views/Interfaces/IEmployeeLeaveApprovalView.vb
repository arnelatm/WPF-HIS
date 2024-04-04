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
        Property StatusList As DataTable
        Property ApprovalStatusList As DataTable
        Property UserIsASuperAdministrator As Boolean
        Property UserIsASupervisor As Boolean
        Property UserHasHrAccess As Boolean
        Property UserHasHrManagerAccess As Boolean

        Event ApprovalCheckedEvent(sender As Object)

    End Interface

    Public Interface IEmployeeLeaveEarnedApprovalView
        Inherits IView

        Property IdNo As Int32
        Property ApprovedBy As Int32
        Property DateCreated As DateTime?
        Property EmployeeLeaveEarnedApprovalItems As List(Of EmployeeLeaveEarnedApprovalItemView)
        Property EmployeeList As DataTable
        Property LeaveList As DataTable
        Property UserIsASuperAdministrator As Boolean
        Property UserIsASupervisor As Boolean
        Property UserHasHrAccess As Boolean
        Property UserHasHrManagerAccess As Boolean

        Event ApprovalCheckedEvent(sender As Object)

    End Interface


End Namespace