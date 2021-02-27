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
        Implements IDao(Of PayrollDetail), IDaoAll(Of PayrollDetail)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As PayrollDetail Implements IDao(Of PayrollDetail).GetRecordById
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
            Dim peaDao = New PayrollEarnAccountDao()
            'data.PayrollEarnAccounts = peaDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
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

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of PayrollDetail) Implements IDaoAll(Of PayrollDetail).GetAll
            Dim sql As String =
                    "SELECT " &
                    "EmployeeIdNo," &
                    "PayrollIdNo," &
                    " FROM [PayrollDetail]"
            Return _db.Read(sql, Make).ToList()
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