Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PayrollDetailView
        Implements IPayrollDetailView

        Public Property EmployeeIdNo As Int32 Implements IPayrollDetailView.EmployeeIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Int32 Implements IPayrollDetailView.IdNo
        Public Property PayrollIdNo As Short Implements IPayrollDetailView.PayrollIdNo

    End Class

End Namespace