Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for PayrollDetail
    ' ** DAO Pattern

    Public Class PayrollDetailDao
        Inherits AccountsDao
        Implements IDaoChild(Of PayrollDetail)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithIdNo(PayrollIdNo, Optional sortExpression = Nothing) As List(Of PayrollDetail) Implements IDaoChild(Of PayrollDetail).GetRecordsWithIdNo
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
                    "Overtime," &
                    "PayrollIdNo," &
                    "ROW_NUMBER() over(Order by " & sortExpression & ") As 'Sequence'" &
                    " FROM [PayrollDetail_View]" &
                    " WHERE PayrollIdNo = @PayrollIdNo "
            Dim params() As Object = {"@PayrollIdNo", PayrollIdNo}
            Dim dta = Db.Read(sql, Make, params).ToList()
            Return dta
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PayrollDetail).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdatePayrollDetailTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PayrollDetail).InsertTvp
            Return Db.InsertTvp("InsertPayrollDetailTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayrollDetail) =
                                    Function(reader) _
            New PayrollDetail() With {
            .DaysAbsentWithoutPay = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysAbsentWithoutPay")),
            .DaysAbsentWithPay = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysAbsentWithPay")),
            .DaysOff = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysOff")),
            .DaysPresent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysPresent")),
            .DaysTotal = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysTotal")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeNameAra")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Overtime = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Overtime")),
            .PayrollIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayrollIdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("Sequence"))
           }

    End Class

End Namespace