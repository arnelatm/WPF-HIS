Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views

    Public Class PayrollPayElementView
        Implements IPayrollPayElementView

        Public Property Amount As Decimal Implements IPayrollPayElementView.Amount
        Public Property EmployeeIdNo As Integer Implements IPayrollPayElementView.EmployeeIdNo
        Public Property Errors As List(Of String) Implements IPayrollPayElementView.Errors
        Public Property IdNo As Integer Implements IPayrollPayElementView.IdNo
        Public Property PayElementIdNo As Short Implements IPayrollPayElementView.PayElementIdNo
        Public Property PayrollDetailIdNo As Integer Implements IPayrollPayElementView.PayrollDetailIdNo
        Public Property PayrollIdNo As Short Implements IPayrollPayElementView.PayrollIdNo
        Public Property RecurringPayElementIdNo As Integer Implements IPayrollPayElementView.RecurringPayElementIdNo
    End Class

End Namespace