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
        Implements IDaoChild(Of PayrollEarning), IDaoTvp(Of PayrollEarning), IDaoGetRecords(Of PayrollEarning), IDaoGetRecord(Of PayrollEarning)

        Private ReadOnly _db As New Db()

        Private Const FieldList = "Amount," &
                                  "EarningIdNo," &
                                  "EmployeeIdNo," &
                                  "IdNo," &
                                  "PayrollIdNo"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PayrollEarning) Implements IDaoChild(Of PayrollEarning).GetRecordsWithGroupIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [PayrollEarning]" &
                    " WHERE PayrollIdNo = @IdNo " &
                    " ORDER BY EmployeeIdNo,EarningIdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PayrollEarning).DelUpdateTvp
            Return _db.DelUpdateTvp("UpdatePayrollEarningTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PayrollEarning).InsertTvp
            Return _db.InsertTvp("InsertPayrollEarningTVP", tvpTable)
        End Function

        Public Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, ByVal groupIdNo As Integer) As Integer Implements IDaoTvp(Of PayrollEarning).UpdateInsertTvp
            Return _db.UpdateInsertTvp("UpdateInsertPayrollEarningTVP", updateTvpTable, insertTvpTable, groupIdNo)
        End Function

        Public Function GetRecords(Optional filter As String = Nothing) As List(Of PayrollEarning) Implements IDaoGetRecords(Of PayrollEarning).GetRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [PayrollEarning]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecord(Optional filter As String = Nothing) As PayrollEarning Implements IDaoGetRecord(Of PayrollEarning).GetRecord
            Dim sql As String = "SELECT Top 1 " &
                                FieldList &
                                " FROM [PayrollEarning]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).FirstOrDefault()
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