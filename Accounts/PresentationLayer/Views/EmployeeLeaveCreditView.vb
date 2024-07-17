Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeLeaveCreditView
        Implements IEmployeeLeaveCreditView

        Public Property AccumulatedLeave As Decimal Implements IEmployeeLeaveCreditView.AccumulatedLeave
        Public Property Cumulative As Boolean Implements IEmployeeLeaveCreditView.Cumulative
        Public Property EmployeeIdNo As Int32 Implements IEmployeeLeaveCreditView.EmployeeIdNo
        Public Property IdNo As Int32 Implements IEmployeeLeaveCreditView.IdNo
        Public Property LeaveAllowed As Decimal Implements IEmployeeLeaveCreditView.LeaveAllowed
        Public Property LeaveIdNo As Int16 Implements IEmployeeLeaveCreditView.LeaveIdNo
        Public Property MaxCarryOver As Decimal Implements IEmployeeLeaveCreditView.MaxCarryOver
        Public Property MaxLimit As Decimal Implements IEmployeeLeaveCreditView.MaxLimit
        Public Property NoMaxLimit As Boolean Implements IEmployeeLeaveCreditView.NoMaxLimit
        Public Property PaidPercent As Decimal Implements IEmployeeLeaveCreditView.PaidPercent
        Public Property Sequence As Int16 Implements IEmployeeLeaveCreditView.Sequence
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors


    End Class

End Namespace