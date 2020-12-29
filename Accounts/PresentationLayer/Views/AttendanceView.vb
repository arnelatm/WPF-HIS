Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class AttendanceView
        Implements IAttendanceView, ISelfDuplicating

        Private _debit As Decimal
        Private _credit As Decimal
        Private _daysTotal As Decimal

        Public Property Errors As List(Of String) Implements IView.Errors

        Public Property EmployeeIdNo As Integer Implements IAttendanceView.EmployeeIdNo

        Public Property EmployeeName As String Implements IAttendanceView.EmployeeName

        Public Property EmployeeNameAra As String Implements IAttendanceView.EmployeeNameAra

        Public Property DaysPresent As Decimal Implements IAttendanceView.DaysPresent

        Public Property DaysAbsentWithPay As Decimal Implements IAttendanceView.DaysAbsentWithPay

        Public Property DaysAbsentWithoutPay As Decimal Implements IAttendanceView.DaysAbsentWithoutPay

        Public Property DaysOff As Decimal Implements IAttendanceView.DaysOff

        Public Property DaysTotal As Decimal Implements IAttendanceView.DaysTotal
            Get
                Return DaysOff + DaysAbsentWithPay + DaysAbsentWithoutPay + DaysPresent
            End Get
            Set(value As Decimal)
                _daysTotal = value
            End Set
        End Property

        Public Property PayPeriodIdNo As Short Implements IAttendanceView.PayPeriodIdNo

        Public Property IdNo As Integer Implements IAttendanceView.IdNo

        Public Property Sequence As Short Implements IAttendanceView.Sequence

        Public Function BlankCopy() As Object Implements ISelfDuplicating.BlankCopy
            Return New AttendanceView
        End Function

    End Class

End Namespace