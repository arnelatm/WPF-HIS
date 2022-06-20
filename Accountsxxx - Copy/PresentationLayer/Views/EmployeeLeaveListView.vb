Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeLeaveApprovalView
        Implements IEmployeeLeaveView

        Public Sub New()
        End Sub

        Public Property IdNo As Int32 Implements EmployeeLeaveApprovalView.IdNo

        Public Property EmployeeName As String Implements EmployeeLeaveApprovalView.EmployeeName

        Public Property NationalIdNo As String Implements EmployeeLeaveApprovalView.NationalIdNo

        Public Property Errors As List(Of String) Implements IView.Errors

        Public Property Picture As Image Implements EmployeeLeaveApprovalView.Picture
        Public Property Print As Boolean Implements EmployeeLeaveApprovalView.Print

    End Class

End Namespace