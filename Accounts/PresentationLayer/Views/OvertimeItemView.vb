Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class OvertimeItemView
        Implements IOvertimeItemView

        Public Property EmployeeIdNo As Int32 Implements IOvertimeItemView.EmployeeIdNo
        Public Property EmployeeName As String Implements IOvertimeItemView.EmployeeName
        Public Property EmployeeNameAra As String Implements IOvertimeItemView.EmployeeNameAra
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Int32 Implements IOvertimeItemView.IdNo
        Public Property OvertimeRegular As Decimal Implements IOvertimeItemView.OvertimeRegular
        Public Property OvertimeHoliday As Decimal Implements IOvertimeItemView.OvertimeHoliday
        Public Property OvertimeSpecial As Decimal Implements IOvertimeItemView.OvertimeSpecial
        Public Property PayrollIdNo As Int16 Implements IOvertimeItemView.PayrollIdNo
        Public Property Sequence As Int16 Implements IOvertimeItemView.Sequence

    End Class

End Namespace