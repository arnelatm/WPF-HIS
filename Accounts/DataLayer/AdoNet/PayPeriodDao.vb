Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayPeriod
    ' ** DAO Pattern

    Public Class PayPeriodDao
        Inherits CommonDao
        Implements IDaoAll(Of PayPeriod)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As PayPeriod Implements IDaoAll(Of PayPeriod).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, PayPeriodCode, PayPeriodName, PayPeriodNameAra, StartDate, EndDate, PayCycleIdNo" &
                    "   FROM [PayPeriod]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Dim attendance As List(Of Attendance) = AttendanceDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            data.RegularEmployeeDeductions = attendance

        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of PayPeriod) _
            Implements IDaoAll(Of PayPeriod).GetAll
            If sortExpression = Nothing Then
                sortExpression = "StartDate ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, PayPeriodName, PayPeriodNameAra, StartDate, EndDate" &
                    "   FROM [PayPeriod] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef PayPeriod As PayPeriod) As Integer Implements IDaoAll(Of PayPeriod).UpdateRecord
            Dim sql As String =
                    " UPDATE [PayPeriod] SET " &
                    " EndDate = @EndDate," &
                    " PayCycleIdNo = @PayCycleIdNo," &
                    " PayPeriodCode = @PayPeriodCode," &
                    " PayPeriodName = @PayPeriodName," &
                    " PayPeriodNameAra = @PayPeriodNameAra," &
                    " StartDate = @StartDate" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(PayPeriod))
        End Function

        Public Function AddRecord(ByRef PayPeriod As PayPeriod) As Integer Implements IDaoAll(Of PayPeriod).AddRecord
            Dim sql As String =
                    " INSERT INTO [PayPeriod] " &
                    " (PayPeriodCode,PayPeriodName,PayPeriodNameAra,StartDate,EndDate,PayCycleIdNo)" &
                    " VALUES (@PayPeriodCode,@PayPeriodName,@PayPeriodNameAra,@StartDate,@EndDate,@PayCycleIdNo) "
            Return Db.Insert(sql, Take(PayPeriod))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayPeriod) =
                                    Function(reader) _
            New PayPeriod() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .PayPeriodCode = Extensions.AsString(reader("PayPeriodCode")),
            .PayPeriodName = Extensions.AsString(reader("PayPeriodName")),
            .PayPeriodNameAra = Extensions.AsString(reader("PayPeriodNameAra")),
            .StartDate = Extensions.AsDate(reader("StartDate")),
            .EndDate = Extensions.AsDate(reader("EndDate")),
            .PayCycleIdNo = Extensions.AsInt(Of Int16)(reader("PayCycleIdNo"))
            }

        Private Function Take(PayPeriod As PayPeriod) As Object()
            Return New Object() {
                                 "@IdNo", PayPeriod.IdNo,
                                 "@PayPeriodCode", PayPeriod.PayPeriodCode,
                                 "@PayPeriodName", PayPeriod.PayPeriodName,
                                 "@PayPeriodNameAra", PayPeriod.PayPeriodNameAra,
                                 "@StartDate", PayPeriod.StartDate,
                                 "@EndDate", PayPeriod.EndDate,
                                 "@PayCycleIdNo", PayPeriod.PayCycleIdNo
                                 }
        End Function

    End Class

End Namespace