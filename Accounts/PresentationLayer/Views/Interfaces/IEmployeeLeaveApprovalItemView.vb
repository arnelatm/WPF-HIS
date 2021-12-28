Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveApprovalItemView
        Inherits IView

        Property ApprovalNote As String
        Property EmployeeIdNo As Int32
        Property EmployeeName As String
        Property EmployeeNameAra As String
        Property EmployeeLeaveApprovalIdNo As Int32
        Property EmployeeLeaveIdNo As Int16
        Property EndDate As Date
        Property EnteredBy As Int32
        Property FullDay As Boolean
        Property IdNo As Int32
        Property LeaveDate As Date
        Property LeaveIdNo As Int16
        Property LeaveName As String
        Property LeaveNameAra As String
        Property LeaveReason As String
        Property LeaveStatus As String
        Property StartDate As Date
        Property Status As String
        Property SupervisorIdNo As Int32
        Property Approve As Boolean
        Property Disapprove As Boolean

    End Interface

End Namespace