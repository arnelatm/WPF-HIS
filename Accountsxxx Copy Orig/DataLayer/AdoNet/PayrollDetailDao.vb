Imports AATM.Accounts.BusinessLayer
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

        Private Const FieldList = "BankTransfer," &
                                  "EmployeeCode," &
                                  "EmployeeIdNo," &
                                  "EmployeeName," &
                                  "EmployeeNameAra," &
                                  "IdNo," &
                                  "PaymentMethod," &
                                  "PayrollIdNo," &
                                  "SponsorType"

        Public Function GetRecordByIdNo(idNo) As PayrollDetail Implements IDao(Of PayrollDetail).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " &
                    "BankTransfer," &
                    "EmployeeCode," &
                    "EmployeeIdNo," &
                    "EmployeeName," &
                    "EmployeeNameAra," &
                    "IdNo," &
                    "PaymentMethod," &
                    "PayrollIdNo," &
                    "SponsorType" &
                    " FROM [PayrollDetail_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim ppeDao = New PayrollPayElementDao()
                Dim payrollDao = New PayrollDao()
                Dim payroll = payrollDao.GetRecordByIdNo(data.PayrollIdNo)
                data.StartDate = payroll.StartDate
                data.EndDate = payroll.EndDate
                data.PayPeriodName = payroll.PayrollName
                data.PayPeriodNameAra = payroll.PayrollNameAra
                data.PayrollEarnings = ppeDao.GetDaoRecords("PayrollDetailIdNo = " & idNo & " and PayElementKind = '" & EnumToCode(PayElementKindSelection.Earning) & "'")
                data.PayrollDeductions = ppeDao.GetDaoRecords("PayrollDetailIdNo = " & idNo & " and PayElementKind = '" & EnumToCode(PayElementKindSelection.Deduction) & "'")
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef PayrollDetail As PayrollDetail) As Integer Implements IDao(Of PayrollDetail).UpdateRecord
            Dim sql As String = " UPDATE [PayrollDetail] Set" &
                    " BankTransfer = @BankTransfer," &
                    " EmployeeIdNo = @EmployeeIdNo," &
                    " PayrollIdNo = @PayrollIdNo" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(PayrollDetail))
        End Function

        Public Function AddRecord(ByRef PayrollDetail As PayrollDetail) As Integer Implements IDao(Of PayrollDetail).AddRecord
            Dim sql As String =
                    " INSERT INTO [PayrollDetail] " &
                    " (BankTransfer, EmployeeIdNo,PayrollIdNo) " &
                    " VALUES (@BankTransfer,@EmployeeIdNo,@PayrollIdNo) "
            Return _db.Insert(sql, Take(PayrollDetail))
        End Function

        Private Function Take(PayrollDetail As PayrollDetail) As Object()
            Return New Object() {
                                    "@BankTransfer", PayrollDetail.BankTransfer,
                                    "@EmployeeIdNo", PayrollDetail.EmployeeIdNo,
                                    "@PayrollIdNo", PayrollDetail.PayrollIdNo,
                                    "@IdNo", PayrollDetail.IdNo
                                }
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of PayrollDetail) Implements IDaoGetRecords(Of PayrollDetail).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [PayrollDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function GetDaoRecord(Optional filter As String = Nothing) As PayrollDetail Implements IDaoGetRecord(Of PayrollDetail).GetDaoRecord
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
            .BankTransfer = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("BankTransfer")),
            .EmployeeCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeCode")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("EmployeeIdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeNameAra")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .PaymentMethod = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PaymentMethod")),
            .PayrollIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("PayrollIdNo")),
            .SponsorType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("SponsorType"))
            }

    End Class

End Namespace