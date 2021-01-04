Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class AttendanceItemView
        Implements IAttendanceItemView
        Private _credit As Decimal

        'Private _daysTotal As Decimal
        Private _debit As Decimal

        Public Property DaysAbsentWithoutPay As Decimal Implements IAttendanceItemView.DaysAbsentWithoutPay
        Public Property DaysAbsentWithPay As Decimal Implements IAttendanceItemView.DaysAbsentWithPay
        Public Property DaysOff As Decimal Implements IAttendanceItemView.DaysOff
        Public Property DaysPresent As Decimal Implements IAttendanceItemView.DaysPresent
        Public Property DaysTotal As Decimal Implements IAttendanceItemView.DaysTotal
        '    Get
        '        Return DaysOff + DaysAbsentWithPay + DaysAbsentWithoutPay + DaysPresent
        '    End Get
        '    Set(value As Decimal)
        '        _daysTotal = value
        '    End Set
        'End Property

        Public Property EmployeeIdNo As Int32 Implements IAttendanceItemView.EmployeeIdNo
        Public Property EmployeeName As String Implements IAttendanceItemView.EmployeeName
        Public Property EmployeeNameAra As String Implements IAttendanceItemView.EmployeeNameAra
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Int32 Implements IAttendanceItemView.IdNo
        Public Property PayPeriodIdNo As Int16 Implements IAttendanceItemView.PayPeriodIdNo
        Public Property Sequence As Int16 Implements IAttendanceItemView.Sequence

    End Class

End Namespace