Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PayrollEarningView
        Implements IPayrollEarningView

        Public Property Amount As Decimal Implements IPayrollEarningView.Amount
        Public Property EarningIdNo As Short Implements IPayrollEarningView.EarningIdNo
        Public Property EmployeeIdNo As Int32 Implements IPayrollEarningView.EmployeeIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Int32 Implements IPayrollEarningView.IdNo
        Public Property PayPeriodIdNo As Int32 Implements IPayrollEarningView.PayPeriodIdNo

    End Class

End Namespace