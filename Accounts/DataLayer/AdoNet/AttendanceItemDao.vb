Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for AttendanceItem
    ' ** DAO Pattern

    Public Class AttendanceItemDao
        Inherits DaoAccounts
        Implements IDaoChild(Of AttendanceItem)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithIdNo(payPeriodIdNo, Optional sortExpression = Nothing) As List(Of AttendanceItem) Implements IDaoChild(Of AttendanceItem).GetRecordsWithIdNo
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
                    " FROM [AttendanceItem_View]" &
                    " WHERE PayPeriodIdNo = @PayPeriodIdNo " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@payPeriodIdNo", payPeriodIdNo}
            Dim dta = Db.Read(sql, Make, params).ToList()
            Return dta
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of AttendanceItem).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateAttendanceItemTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of AttendanceItem).InsertTvp
            Return Db.InsertTvp("InsertAttendanceItemTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, AttendanceItem) =
                                    Function(reader) _
            New AttendanceItem() With {
            .DaysAbsentWithoutPay = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysAbsentWithoutPay")),
            .DaysAbsentWithPay = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysAbsentWithPay")),
            .DaysOff = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysOff")),
            .DaysPresent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysPresent")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeNameAra")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayPeriodIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayPeriodIdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayPeriodIdNo"))
           }

    End Class

End Namespace