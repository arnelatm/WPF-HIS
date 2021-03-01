Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for AttendanceItem
    ' ** DAO Pattern

    Public Class AttendanceItemDao
        Inherits AccountsDao
        Implements IDaoChild(Of AttendanceItem)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithGroupIdNo(PayrollIdNo, Optional sortExpression = Nothing) As List(Of AttendanceItem) Implements IDaoChild(Of AttendanceItem).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "EmployeeName"
            End If
            If GlobalVariables.RightToLeftLayout Then
                If sortExpression = "EmployeeName" Then
                    sortExpression = "EmployeeNameAra"
                End If
            End If
            Dim sql As String =
                    "SELECT " &
                    "DaysAbsentWithoutPay," &
                    "DaysAbsentWithPay," &
                    "DaysOff," &
                    "DaysPresent," &
                    "DaysTotal," &
                    "EmployeeIdNo," &
                    "EmployeeName," &
                    "EmployeeNameAra," &
                    "IdNo," &
                    "PayrollIdNo," &
                    "ROW_NUMBER() over(Order by " & sortExpression & ") As 'Sequence'" &
                    " FROM [AttendanceItem_View]" &
                    " WHERE PayrollIdNo = @PayrollIdNo "
            Dim params() As Object = {"@PayrollIdNo", PayrollIdNo}
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
            .DaysTotal = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysTotal")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeNameAra")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayrollIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayrollIdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("Sequence"))
           }

    End Class

End Namespace