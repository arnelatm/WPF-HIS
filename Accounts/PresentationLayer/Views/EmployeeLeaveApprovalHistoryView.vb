Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeLeaveApprovalHistoryView
        Implements IEmployeeLeaveApprovalHistoryView

        Public Sub New()
        End Sub

        Public Property ApprovalIdNo As Integer Implements IEmployeeLeaveApprovalHistoryView.ApprovalIdNo
        Public Property ApprovalNote As String Implements IEmployeeLeaveApprovalHistoryView.ApprovalNote
        Public Property ApprovalDate As Date? Implements IEmployeeLeaveApprovalHistoryView.ApprovalDate
        Public Property EmployeeLeaveIdNo As Short Implements IEmployeeLeaveApprovalHistoryView.EmployeeLeaveIdNo
        Public Property ApprovedBy As Integer Implements IEmployeeLeaveApprovalHistoryView.ApprovedBy
        Public Property IdNo As Integer Implements IEmployeeLeaveApprovalHistoryView.IdNo
        Public Property LeaveStatus As String Implements IEmployeeLeaveApprovalHistoryView.LeaveStatus

    End Class

End Namespace