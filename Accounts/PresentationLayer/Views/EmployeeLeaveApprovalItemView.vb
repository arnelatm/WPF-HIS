Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeLeaveApprovalItemView
        Implements IEmployeeLeaveApprovalItemView

        Public Sub New()
        End Sub

        Public Property ApprovalNote As String Implements IEmployeeLeaveApprovalItemView.ApprovalNote
        Public Property Approved As Boolean Implements IEmployeeLeaveApprovalItemView.Approved
        Public Property Disapproved As Boolean Implements IEmployeeLeaveApprovalItemView.Disapproved
        Public Property DateCreated As DateTime? Implements IEmployeeLeaveApprovalItemView.DateCreated
        Public Property EmployeeLeaveIdNo As Integer Implements IEmployeeLeaveApprovalItemView.EmployeeLeaveIdNo
        Public Property EmployeeIdNo As Integer Implements IEmployeeLeaveApprovalItemView.EmployeeIdNo
        Public Property EmployeeName As String Implements IEmployeeLeaveApprovalItemView.EmployeeName
        Public Property EmployeeNameAra As String Implements IEmployeeLeaveApprovalItemView.EmployeeNameAra
        Public Property EmployeeLeaveApprovalIdNo As Integer Implements IEmployeeLeaveApprovalItemView.EmployeeLeaveApprovalIdNo
        Public Property EndDate As Date Implements IEmployeeLeaveApprovalItemView.EndDate
        Public Property EnteredBy As Integer Implements IEmployeeLeaveApprovalItemView.EnteredBy
        Public Property FullDay As Boolean Implements IEmployeeLeaveApprovalItemView.FullDay
        Public Property IdNo As Integer Implements IEmployeeLeaveApprovalItemView.IdNo
        Public Property LeaveIdNo As Short Implements IEmployeeLeaveApprovalItemView.LeaveIdNo
        Public Property LeaveName As String Implements IEmployeeLeaveApprovalItemView.LeaveName
        Public Property LeaveNameAra As String Implements IEmployeeLeaveApprovalItemView.LeaveNameAra
        Public Property NoOfDays As Int32 Implements IEmployeeLeaveApprovalItemView.NoOfDays
        Public Property Reason As String Implements IEmployeeLeaveApprovalItemView.Reason
        Public Property Status As String Implements IEmployeeLeaveApprovalItemView.Status
        Public Property StartDate As Date Implements IEmployeeLeaveApprovalItemView.StartDate
        Public Property SupervisorIdNo As Integer Implements IEmployeeLeaveApprovalItemView.SupervisorIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter
    End Class


    Public Class EmployeeLeaveEarnedApprovalItemView
        Implements IEmployeeLeaveEarnedApprovalItemView

        Public Sub New()
        End Sub

        Public Property ApprovalNote As String Implements IEmployeeLeaveEarnedApprovalItemView.ApprovalNote
        Public Property Approved As Boolean Implements IEmployeeLeaveEarnedApprovalItemView.Approved
        Public Property Disapproved As Boolean Implements IEmployeeLeaveEarnedApprovalItemView.Disapproved
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property DateCreated As DateTime? Implements IEmployeeLeaveEarnedApprovalItemView.DateCreated
        Public Property DaysEarned As Decimal Implements IEmployeeLeaveEarnedApprovalItemView.DaysEarned
        Public Property EmployeeLeaveEarnedIdNo As Integer Implements IEmployeeLeaveEarnedApprovalItemView.EmployeeLeaveEarnedIdNo
        Public Property EmployeeIdNo As Integer Implements IEmployeeLeaveEarnedApprovalItemView.EmployeeIdNo
        Public Property EmployeeName As String Implements IEmployeeLeaveEarnedApprovalItemView.EmployeeName
        Public Property EmployeeNameAra As String Implements IEmployeeLeaveEarnedApprovalItemView.EmployeeNameAra
        Public Property EmployeeLeaveEarnedApprovalIdNo As Integer Implements IEmployeeLeaveEarnedApprovalItemView.EmployeeLeaveEarnedApprovalIdNo
        Public Property EndDate As Date Implements IEmployeeLeaveEarnedApprovalItemView.EndDate
        Public Property EnteredBy As Integer Implements IEmployeeLeaveEarnedApprovalItemView.EnteredBy
        Public Property IdNo As Integer Implements IEmployeeLeaveEarnedApprovalItemView.IdNo
        Public Property LeaveIdNo As Short Implements IEmployeeLeaveEarnedApprovalItemView.LeaveIdNo
        Public Property LeaveName As String Implements IEmployeeLeaveEarnedApprovalItemView.LeaveName
        Public Property LeaveNameAra As String Implements IEmployeeLeaveEarnedApprovalItemView.LeaveNameAra
        Public Property Reason As String Implements IEmployeeLeaveEarnedApprovalItemView.Reason
        Public Property Status As String Implements IEmployeeLeaveEarnedApprovalItemView.Status
        Public Property StartDate As Date Implements IEmployeeLeaveEarnedApprovalItemView.StartDate
        Public Property SupervisorIdNo As Integer Implements IEmployeeLeaveEarnedApprovalItemView.SupervisorIdNo

    End Class
End Namespace