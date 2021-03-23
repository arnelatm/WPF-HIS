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
        Implements IDao(Of PayrollDetail), IDaoTvp(Of PayrollDetail), IDaoGetRecord(Of PayrollDetail), IDaoGetRecords(Of PayrollDetail), IGetRecordsWithGroupIdNo(Of PayrollDetail)
        Private ReadOnly _db As New Db()

        Private Const FieldList = "EmployeeCode," &
                                  "EmployeeIdNo," &
                                  "EmployeeName," &
                                  "EmployeeNameAra," &
                                  "IdNo," &
                                  "PayrollIdNo"

        Public Function GetRecordByIdNo(idNo) As PayrollDetail Implements IDao(Of PayrollDetail).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " &
                    "EmployeeCode," &
                    "EmployeeIdNo," &
                    "EmployeeName," &
                    "EmployeeNameAra," &
                    "IdNo," &
                    "PayrollIdNo" &
                    " FROM [PayrollDetail_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            'Dim peaDao = New PayElementAccountDao()
            'data.PayElementAccounts = peaDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
            Return data
        End Function

        Public Function UpdateRecord(ByRef PayrollDetail As PayrollDetail) As Integer Implements IDao(Of PayrollDetail).UpdateRecord
            Dim sql As String = " UPDATE [PayrollDetail] Set" &
                    " EmployeeIdNo = @EmployeeIdNo," &
                    " PayrollIdNo = @PayrollIdNo," &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(PayrollDetail))
        End Function

        Public Function AddRecord(ByRef PayrollDetail As PayrollDetail) As Integer Implements IDao(Of PayrollDetail).AddRecord
            Dim sql As String =
                    " INSERT INTO [PayrollDetail] " &
                    " (EmployeeIdNo,PayrollIdNo) " &
                    " VALUES (@EmployeeIdNo,@PayrollIdNo) "
            Return _db.Insert(sql, Take(PayrollDetail))
        End Function

        Private Function Take(PayrollDetail As PayrollDetail) As Object()
            Return New Object() {
                                    "@EmployeeIdNo", PayrollDetail.EmployeeIdNo,
                                    "@PayrollIdNo", PayrollDetail.PayrollIdNo,
                                    "@IdNo", PayrollDetail.IdNo
                                }
        End Function

        Public Function GetRecords(Optional filter As String = Nothing) As List(Of PayrollDetail) Implements IDaoGetRecords(Of PayrollDetail).GetRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [PayrollDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecord(Optional filter As String = Nothing) As PayrollDetail Implements IDaoGetRecord(Of PayrollDetail).GetRecord
            Dim sql As String = "SELECT Top 1 " &
                                FieldList &
                                " FROM [PayrollDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).FirstOrDefault()
        End Function

        Public Function GetRecordsWithGroupIdNo(idNo As Object, Optional sortExpression As Object = Nothing) As List(Of PayrollDetail) Implements IGetRecordsWithGroupIdNo(Of PayrollDetail).GetRecordsWithGroupIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [PayrollDetail_View]" &
                    " WHERE PayrollIdNo = @IdNo " &
                    " ORDER BY EmployeeIdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, ByVal groupIdNo As Integer) As Integer Implements IDaoTvp(Of PayrollDetail).UpdateInsertTvp
            Return _db.UpdateInsertTvp("UpdateInsertPayrollDetailTVP", updateTvpTable, insertTvpTable, groupIdNo)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayrollDetail) =
                                    Function(reader) _
            New PayrollDetail() With {
            .EmployeeCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeCode")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("EmployeeIdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeNameAra")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayrollIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("PayrollIdNo"))
            }

    End Class

End Namespace