Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PayrollDetailView
        Implements IPayrollDetailView

        Public Property IdNo As Integer Implements IPayrollDetailView.IdNo
        Public Property PayrollIdNo As Short Implements IPayrollDetailView.PayrollIdNo
        Public Property EmployeeIdNo As Integer Implements IPayrollDetailView.EmployeeIdNo
        Public Property EmployeeCode As String Implements IPayrollDetailView.EmployeeCode
        Public Property EmployeeName As String Implements IPayrollDetailView.EmployeeName
        Public Property EmployeeNameAra As String Implements IPayrollDetailView.EmployeeNameAra
        Public Property PayrollEarnings As List(Of PayrollPayElementView) Implements IPayrollDetailView.PayrollEarnings
        Public Property PayrollDeductions As List(Of PayrollPayElementView) Implements IPayrollDetailView.PayrollDeductions
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property StartDate As Date Implements IPayrollDetailView.StartDate
        Public Property EndDate As Date Implements IPayrollDetailView.EndDate
        Public Property PayPeriodName As String Implements IPayrollDetailView.PayPeriodName
        Public Property PayPeriodNameAra As String Implements IPayrollDetailView.PayPeriodNameAra
        'Public Event UpdateDataFilterEvent(pPayrollIdNo As Short) Implements IPayrollDetailView.UpdateDataFilterEvent
    End Class

End Namespace