Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class StockRequestApprovalItemView
        Implements IStockRequestApprovalItemView

        Public Sub New()
        End Sub

        Public Property ApprovalNote As String Implements IStockRequestApprovalItemView.ApprovalNote
        Public Property StockRequestIdNo As Integer Implements IStockRequestApprovalItemView.StockRequestIdNo
        Public Property EmployeeIdNo As Integer Implements IStockRequestApprovalItemView.EmployeeIdNo
        Public Property EmployeeName As String Implements IStockRequestApprovalItemView.EmployeeName
        Public Property EmployeeNameAra As String Implements IStockRequestApprovalItemView.EmployeeNameAra
        Public Property StockRequestApprovalIdNo As Integer Implements IStockRequestApprovalItemView.StockRequestApprovalIdNo
        Public Property EndDate As Date Implements IStockRequestApprovalItemView.EndDate
        Public Property EnteredBy As Integer Implements IStockRequestApprovalItemView.EnteredBy
        Public Property FullDay As Boolean Implements IStockRequestApprovalItemView.FullDay
        Public Property IdNo As Integer Implements IStockRequestApprovalItemView.IdNo
        Public Property LeaveDate As Date Implements IStockRequestApprovalItemView.LeaveDate
        Public Property LeaveIdNo As Short Implements IStockRequestApprovalItemView.LeaveIdNo
        Public Property LeaveName As String Implements IStockRequestApprovalItemView.LeaveName
        Public Property LeaveNameAra As String Implements IStockRequestApprovalItemView.LeaveNameAra
        Public Property LeaveReason As String Implements IStockRequestApprovalItemView.LeaveReason
        Public Property LeaveStatus As String Implements IStockRequestApprovalItemView.LeaveStatus
        Public Property StartDate As Date Implements IStockRequestApprovalItemView.StartDate
        Public Property Status As String Implements IStockRequestApprovalItemView.Status
        Public Property SupervisorIdNo As Integer Implements IStockRequestApprovalItemView.SupervisorIdNo
        Public Property Approve As Boolean Implements IStockRequestApprovalItemView.Approve
        Public Property Disapprove As Boolean Implements IStockRequestApprovalItemView.Disapprove
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter
    End Class

End Namespace