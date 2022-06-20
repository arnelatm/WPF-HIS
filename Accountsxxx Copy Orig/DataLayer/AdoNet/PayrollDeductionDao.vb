Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for PayrollDeduction
    ' ** DAO Pattern

    Public Class PayrollDeductionDao
        Inherits AccountsDao
        Implements IDaoChild(Of PayrollDeduction), IDaoTvp(Of PayrollDeduction)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PayrollDeduction) Implements IDaoChild(Of PayrollDeduction).GetRecordsWithGroupIdNo
            Dim sql As String =
                    " SELECT " &
                    "Amount," &
                    "DeductionIdNo," &
                    "EmployeeIdNo," &
                    "IdNo," &
                    "PayrollIdNo" &
                    " FROM [PayrollDeduction]" &
                    " WHERE PayrollIdNo = @IdNo " &
                    " ORDER BY EmployeeIdNo,DeductionIdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PayrollDeduction).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdatePayrollDeductionTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PayrollDeduction).InsertTvp
            Return Db.InsertTvp("InsertPayrollDeductionTVP", tvpTable)
        End Function

        Public Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, ByVal groupIdNo As Integer) As Integer Implements IDaoTvp(Of PayrollDeduction).UpdateInsertTvp
            Return Db.UpdateInsertTvp("UpdateInsertPayrollDeductionTVP", updateTvpTable, insertTvpTable, groupIdNo)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayrollDeduction) =
                                    Function(reader) _
            New PayrollDeduction() With {
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .DeductionIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("DeductionIdNo")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayrollIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("PayrollIdNo"))
           }

    End Class

End Namespace