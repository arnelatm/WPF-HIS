Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views

    Public Class EmployeeLeaveApprovalHistoryView
        Implements IEmployeeLeaveApprovalHistoryView

        Public Sub New()
        End Sub

        Public Property ApprovedByName As String Implements IEmployeeLeaveApprovalHistoryView.ApprovedByName
        Public Property ApprovalIdNo As Int32? Implements IEmployeeLeaveApprovalHistoryView.ApprovalIdNo
        Public Property ApprovalNote As String Implements IEmployeeLeaveApprovalHistoryView.ApprovalNote
        Public Property ApprovalDate As Date? Implements IEmployeeLeaveApprovalHistoryView.ApprovalDate
        Public Property EmployeeLeaveIdNo As Int32 Implements IEmployeeLeaveApprovalHistoryView.EmployeeLeaveIdNo
        Public Property ApprovedBy As Int32? Implements IEmployeeLeaveApprovalHistoryView.ApprovedBy
        Public Property IdNo As Integer Implements IEmployeeLeaveApprovalHistoryView.IdNo
        Public Property Status As String Implements IEmployeeLeaveApprovalHistoryView.Status

    End Class

    Public Class EmployeeLeaveEarnedApprovalHistoryView
        Implements IEmployeeLeaveEarnedApprovalHistoryView

        Public Sub New()
        End Sub

        Public Property ApprovedByName As String Implements IEmployeeLeaveEarnedApprovalHistoryView.ApprovedByName
        Public Property ApprovalIdNo As Int32? Implements IEmployeeLeaveEarnedApprovalHistoryView.ApprovalIdNo
        Public Property ApprovalNote As String Implements IEmployeeLeaveEarnedApprovalHistoryView.ApprovalNote
        Public Property ApprovalDate As Date? Implements IEmployeeLeaveEarnedApprovalHistoryView.ApprovalDate
        Public Property EmployeeLeaveIdNo As Int32 Implements IEmployeeLeaveEarnedApprovalHistoryView.EmployeeLeaveEarnedIdNo
        Public Property ApprovedBy As Int32? Implements IEmployeeLeaveEarnedApprovalHistoryView.ApprovedBy
        Public Property IdNo As Integer Implements IEmployeeLeaveEarnedApprovalHistoryView.IdNo
        Public Property Status As String Implements IEmployeeLeaveEarnedApprovalHistoryView.Status

    End Class

End Namespace