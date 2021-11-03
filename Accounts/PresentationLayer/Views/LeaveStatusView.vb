Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class LeaveStatusView
        Implements IEmployeeLeaveStatusView

        Public Sub New()
        End Sub

        Public Property EmployeeLeaveIdNo As Int32 Implements IEmployeeLeaveStatusView.EmployeeLeaveIdNo
        Public Property EnteredBy As Int32 Implements IEmployeeLeaveStatusView.EnteredBy
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Short Implements IEmployeeLeaveStatusView.IdNo
        Public Property Notes As String Implements IEmployeeLeaveStatusView.Notes
        Public Property Status As String Implements IEmployeeLeaveStatusView.Status

    End Class

End Namespace