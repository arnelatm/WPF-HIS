Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for Attendance
    ' ** DAO Pattern

    Public Class AttendanceDao
        Inherits DaoAccounts
        Implements IDaoChild(Of Attendance)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithIdNo(payPeriodIdNo, Optional sortExpression = Nothing) As List(Of Attendance) Implements IDaoChild(Of Attendance).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "DaysAbsentWithoutPay," &
                    "DaysAbsentWithPay," &
                    "DaysOff," &
                    "DaysPresent," &
                    "EmployeeIdNo," &
                    "EmployeeName," &
                    "EmployeeNameAra," &
                    "IdNo," &
                    "PayPeriodIdNo," &
                    "Sequence" &
                    " FROM [Attendance_View]" &
                    " WHERE PayPeriodIdNo = @PayPeriodIdNo " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@payPeriodIdNo", payPeriodIdNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of Attendance).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateAttendanceTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of Attendance).InsertTvp
            Return Db.InsertTvp("InsertAttendanceTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Attendance) =
                                    Function(reader) _
            New Attendance() With {
            .DaysAbsentWithoutPay = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysAbsentWithoutPay")),
            .DaysAbsentWithPay = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysAbsentWithPay")),
            .DaysOff = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysOff")),
            .DaysPresent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysPresent")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("IdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("IdNo")),
            .PayPeriodIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayPeriodIdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayPeriodIdNo"))
           }

    End Class

End Namespace