Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for PayrollEarning
    ' ** DAO Pattern

    Public Class PayrollEarningDao
        Inherits AccountsDao
        Implements IDaoChild(Of PayrollEarning)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) As List(Of PayrollEarning) Implements IDaoChild(Of PayrollEarning).GetRecordsWithIdNo
            Dim sql As String =
                    " SELECT " &
                    "Amount," &
                    "EarningIdNo," &
                    "EmployeeIdNo," &
                    "IdNo," &
                    "PayrollIdNo" &
                    " FROM [PayrollEarning]" &
                    " WHERE PayrollIdNo = @IdNo " &
                    " ORDER BY EmployeeIdNo,EarningIdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PayrollEarning).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdatePayrollEarningTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PayrollEarning).InsertTvp
            Return Db.InsertTvp("InsertPayrollEarningTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayrollEarning) =
                                    Function(reader) _
            New PayrollEarning() With {
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .EarningIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("EarningIdNo")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayrollIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("PayrollIdNo"))
           }

    End Class

End Namespace