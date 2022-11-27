Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeLeaveApprovalItemView
        Implements IEmployeeLeaveApprovalItemView

        Public Sub New()
        End Sub

        Public Property ApprovalNote As String Implements IEmployeeLeaveApprovalItemView.ApprovalNote
        Public Property EmployeeLeaveIdNo As Integer Implements IEmployeeLeaveApprovalItemView.EmployeeLeaveIdNo
        Public Property EmployeeIdNo As Integer Implements IEmployeeLeaveApprovalItemView.EmployeeIdNo
        Public Property EmployeeName As String Implements IEmployeeLeaveApprovalItemView.EmployeeName
        Public Property EmployeeNameAra As String Implements IEmployeeLeaveApprovalItemView.EmployeeNameAra
        Public Property EmployeeLeaveApprovalIdNo As Integer Implements IEmployeeLeaveApprovalItemView.EmployeeLeaveApprovalIdNo
        Public Property EndDate As Date Implements IEmployeeLeaveApprovalItemView.EndDate
        Public Property EnteredBy As Integer Implements IEmployeeLeaveApprovalItemView.EnteredBy
        Public Property FullDay As Boolean Implements IEmployeeLeaveApprovalItemView.FullDay
        Public Property IdNo As Integer Implements IEmployeeLeaveApprovalItemView.IdNo
        Public Property LeaveDate As Date Implements IEmployeeLeaveApprovalItemView.LeaveDate
        Public Property LeaveIdNo As Short Implements IEmployeeLeaveApprovalItemView.LeaveIdNo
        Public Property LeaveName As String Implements IEmployeeLeaveApprovalItemView.LeaveName
        Public Property LeaveNameAra As String Implements IEmployeeLeaveApprovalItemView.LeaveNameAra
        Public Property LeaveReason As String Implements IEmployeeLeaveApprovalItemView.LeaveReason
        Public Property LeaveStatus As String Implements IEmployeeLeaveApprovalItemView.LeaveStatus
        Public Property StartDate As Date Implements IEmployeeLeaveApprovalItemView.StartDate
        Public Property Status As String Implements IEmployeeLeaveApprovalItemView.Status
        Public Property SupervisorIdNo As Integer Implements IEmployeeLeaveApprovalItemView.SupervisorIdNo
        Public Property Approve As Boolean Implements IEmployeeLeaveApprovalItemView.Approve
        Public Property Disapprove As Boolean Implements IEmployeeLeaveApprovalItemView.Disapprove
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter
    End Class

End Namespace