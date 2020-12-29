Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for PayPeriodAttendance
    ' ** DAO Pattern

    Public Class PayPeriodAttendanceDao
        Inherits DaoAccounts
        Implements IDaoChild(Of PayPeriodAttendance)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) As List(Of PayPeriodAttendance) Implements IDaoChild(Of PayPeriodAttendance).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "IdNo," &
                    "EmployeeIdNo," &
                    "EmployeeName," &
                    "EmployeeNameAra," &
                    "EmployeeNameAra," &
                    "EmployeeType," &
                    "EmployeeIdNo," &
                    "IdNo," &
                    "Sequence" &
                    " FROM [PayPeriodAttendance_View]" &
                    " WHERE EmployeeIdNo = @IdNo " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PayPeriodAttendance).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdatePayPeriodAttendanceTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PayPeriodAttendance).InsertTvp
            Return Db.InsertTvp("InsertPayPeriodAttendanceTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayPeriodAttendance) =
                                    Function(reader) _
            New PayPeriodAttendance() With {
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .EmployeeCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeCode")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("EmployeeIdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeNameAra")),
            .EmployeeType = AATM.DataLayer.AdoNet.Extensions.AsChar(reader("EmployeeType")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence"))
           }

    End Class

End Namespace