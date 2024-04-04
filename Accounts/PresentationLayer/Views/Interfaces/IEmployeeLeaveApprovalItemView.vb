Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveApprovalItemView
        Inherits IView

        Property ApprovalNote As String
        Property Approved As Boolean
        Property Disapproved As Boolean
        Property DateCreated As DateTime?
        Property EmployeeLeaveIdNo As Int32
        Property EmployeeIdNo As Int32
        Property EmployeeName As String
        Property EmployeeNameAra As String
        Property EmployeeLeaveApprovalIdNo As Int32
        Property EndDate As Date
        Property EnteredBy As Int32
        Property FullDay As Boolean
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        Property LeaveName As String
        Property LeaveNameAra As String
        Property Reason As String
        Property Status As String
        Property StartDate As Date
        Property SupervisorIdNo As Int32


    End Interface


    Public Interface IEmployeeLeaveEarnedApprovalItemView
        Inherits IView

        Property ApprovalNote As String
        Property Approved As Boolean
        Property Disapproved As Boolean
        Property DateCreated As DateTime?
        Property DaysEarned As Decimal
        Property EmployeeLeaveEarnedIdNo As Int32
        Property EmployeeIdNo As Int32
        Property EmployeeName As String
        Property EmployeeNameAra As String
        Property EmployeeLeaveEarnedApprovalIdNo As Int32
        Property EndDate As Date
        Property EnteredBy As Int32
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        Property LeaveName As String
        Property LeaveNameAra As String
        Property Reason As String
        Property Status As String
        Property StartDate As Date
        Property SupervisorIdNo As Int32


    End Interface

End Namespace