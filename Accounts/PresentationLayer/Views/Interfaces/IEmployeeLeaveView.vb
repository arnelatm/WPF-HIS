Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveView
        Inherits IView

        Property EnteredBy As Int32
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Integer
        Property EndDate As DateTime
        Property FullDay As Boolean
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        Property LeaveReason As String
        Property LeaveStatus As String
        Property StartDate As DateTime
        Property SupervisorIdNo As Int32
        Property Approve As Boolean
        Property Disapprove As Boolean
        Property ApprovalNote As String
        Property ApprovalHistory As List(Of IEmployeeLeaveApprovalHistoryView)
        Property Users As List(Of Lookup.LookupData)
        Property LeaveStatusList As List(Of Lookup.LookupData)
    End Interface

End Namespace