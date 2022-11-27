Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class AttendanceItemView
        Implements IAttendanceItemView

        'Private _daysTotal As Decimal
        'Private _daysAbsentWithOutPay As Decimal
        'Private _daysAbsentWithPay As Decimal
        'Private _daysOff As Decimal
        'Private _daysPresent As Decimal

        Public Property DaysAbsentWithoutPay As Decimal Implements IAttendanceItemView.DaysAbsentWithoutPay
        '    Get
        '        Return _daysAbsentWithOutPay
        '    End Get
        '    Set(value As Decimal)
        '        _daysAbsentWithOutPay = value
        '        DaysTotal = _daysOff + _daysAbsentWithPay + value + _daysPresent
        '    End Set
        'End Property

        Public Property DaysAbsentWithPay As Decimal Implements IAttendanceItemView.DaysAbsentWithPay
        '    Get
        '        Return _daysAbsentWithPay
        '    End Get
        '    Set(value As Decimal)
        '        _daysAbsentWithPay = value
        '        DaysTotal = _daysOff + value + _daysAbsentWithOutPay + _daysPresent
        '    End Set
        'End Property

        Public Property DaysOff As Decimal Implements IAttendanceItemView.DaysOff
        '    Get
        '        Return _daysOff
        '    End Get
        '    Set(value As Decimal)
        '        _daysOff = value
        '        DaysTotal = value + _daysAbsentWithPay + _daysAbsentWithOutPay + _daysPresent
        '    End Set
        'End Property

        Public Property DaysPresent As Decimal Implements IAttendanceItemView.DaysPresent
        '    Get
        '        Return _daysPresent
        '    End Get
        '    Set(value As Decimal)
        '        _daysPresent = value
        '        DaysTotal = _daysOff + _daysAbsentWithPay + _daysAbsentWithOutPay + value
        '    End Set
        'End Property

        Public Property DaysTotal As Decimal Implements IAttendanceItemView.DaysTotal
        '    Get
        '        Return DaysOff + DaysAbsentWithPay + DaysAbsentWithoutPay + DaysPresent
        '    End Get
        '    Set(value As Decimal)
        '        _daysTotal = value
        '    End Set
        'End Property

        Public Property DaysVacationLeave As Decimal Implements IAttendanceItemView.DaysVacationLeave

        Public Property EmployeeIdNo As Int32 Implements IAttendanceItemView.EmployeeIdNo
        Public Property EmployeeName As String Implements IAttendanceItemView.EmployeeName
        Public Property EmployeeNameAra As String Implements IAttendanceItemView.EmployeeNameAra
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Int32 Implements IAttendanceItemView.IdNo
        Public Property PayrollIdNo As Int16 Implements IAttendanceItemView.PayrollIdNo
        Public Property Sequence As Int16 Implements IAttendanceItemView.Sequence
        Public Property Selected As Boolean Implements IAttendanceItemView.Selected
        Public Property DataFilter As String Implements IView.DataFilter

    End Class

End Namespace