Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveApprovalHistoryView

        Property ApprovalDate As DateTime?
        Property ApprovalIdNo As Int32?
        Property ApprovedByName As String
        Property ApprovalNote As String
        Property ApprovedBy As Int32?
        Property EmployeeLeaveIdNo As Int32
        Property IdNo As Int32
        Property Status As String

    End Interface

    Public Interface IEmployeeLeaveEarnedApprovalHistoryView

        Property ApprovalDate As DateTime?
        Property ApprovalIdNo As Int32?
        Property ApprovedByName As String
        Property ApprovalNote As String
        Property ApprovedBy As Int32?
        Property EmployeeLeaveEarnedIdNo As Int32
        Property IdNo As Int32
        Property Status As String

    End Interface


End Namespace