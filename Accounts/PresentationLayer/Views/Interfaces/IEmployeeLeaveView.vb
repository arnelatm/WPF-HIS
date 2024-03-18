Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveView
        Inherits IView

        Property EnteredBy As Int32
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Integer
        Property EndDate As Date
        Property FullDay As Boolean
        Property Holiday As Boolean
        Property HolidayIdNo As Int16
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        Property Reason As String
        Property Status As String
        Property StartDate As Date
        Property SupervisorIdNo As Int32?
        Property Approve As Boolean
        Property Disapprove As Boolean
        Property ApprovalNote As String
        Property ApprovalHistory As List(Of EmployeeLeaveApprovalHistoryView)
        Property Users As DataTable
        Property StatusList As DataTable
        Property UserIsASupervisor As Boolean
        Property UserHasHrManagerAccess As Boolean
        Property NoOfDays As Int32
        Event DateValuesChanged()
        Event EmployeeIdChanged()
        Event ComputeNumberOfDays()

    End Interface

End Namespace