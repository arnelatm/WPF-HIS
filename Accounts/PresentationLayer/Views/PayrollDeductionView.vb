Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PayrollDeductionView
        Implements IPayrollDeductionView

        Public Property Amount As Decimal Implements IPayrollDeductionView.Amount
        Public Property DeductionIdNo As Short Implements IPayrollDeductionView.DeductionIdNo
        Public Property EmployeeIdNo As Int32 Implements IPayrollDeductionView.EmployeeIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Int32 Implements IPayrollDeductionView.IdNo
        Public Property PayrollIdNo As Int16 Implements IPayrollDeductionView.PayrollIdNo

    End Class

End Namespace