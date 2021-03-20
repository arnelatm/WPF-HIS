Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for PayrollPayElement
    ' ** DAO Pattern

    Public Class PayrollPayElementDao
        Inherits AccountsDao
        Implements IDaoChild(Of PayrollPayElement), IDaoTvp(Of PayrollPayElement), IDaoGetRecords(Of PayrollPayElement), IDaoGetRecord(Of PayrollPayElement)

        Private ReadOnly _db As New Db()

        Private Const FieldList = "Amount," &
                                  "IdNo," &
                                  "PayElementIdNo," &
                                  "PayrollIdNo"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PayrollPayElement) Implements IDaoChild(Of PayrollPayElement).GetRecordsWithGroupIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [PayrollPayElement]" &
                    " WHERE PayrollIdNo = @IdNo " &
                    " ORDER BY EmployeeIdNo,PayElementIdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PayrollPayElement).DelUpdateTvp
            Return _db.DelUpdateTvp("UpdatePayrollPayElementTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PayrollPayElement).InsertTvp
            Return _db.InsertTvp("InsertPayrollPayElementTVP", tvpTable)
        End Function

        Public Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, ByVal groupIdNo As Integer) As Integer Implements IDaoTvp(Of PayrollPayElement).UpdateInsertTvp
            Return _db.UpdateInsertTvp("UpdateInsertPayrollPayElementTVP", updateTvpTable, insertTvpTable, groupIdNo)
        End Function

        Public Function GetRecords(Optional filter As String = Nothing) As List(Of PayrollPayElement) Implements IDaoGetRecords(Of PayrollPayElement).GetRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [PayrollPayElement]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecord(Optional filter As String = Nothing) As PayrollPayElement Implements IDaoGetRecord(Of PayrollPayElement).GetRecord
            Dim sql As String = "SELECT Top 1 " &
                                FieldList &
                                " FROM [PayrollPayElement]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).FirstOrDefault()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayrollPayElement) =
                                    Function(reader) _
            New PayrollPayElement() With {
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .PayElementIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayElementIdNo")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayrollIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("PayrollIdNo"))
           }

    End Class

End Namespace