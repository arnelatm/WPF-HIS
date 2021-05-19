Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for SalaryLoanSchedule
    ' ** DAO Pattern

    Public Class SalaryLoanScheduleDao
        Inherits CommonDao
        Implements IDaoAll(Of SalaryLoanSchedule)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As SalaryLoanSchedule Implements IDaoAll(Of SalaryLoanSchedule).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, EmployeeIdNo, Amount, StartDate, PeriodicPayment" &
                    "   FROM [SalaryLoanSchedule]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of SalaryLoanSchedule) _
            Implements IDaoAll(Of SalaryLoanSchedule).GetAll
            If sortExpression = Nothing Then
                sortExpression = " ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EmployeeIdNo" &
                    "   FROM [SalaryLoanSchedule] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef SalaryLoanSchedule As SalaryLoanSchedule) As Integer Implements IDaoAll(Of SalaryLoanSchedule).UpdateRecord
            Dim sql As String =
                    " UPDATE [SalaryLoanSchedule]" &
                    " SET EmployeeIdNo = @EmployeeIdNo," &
                    " Amount = @Amount," &
                    " StartDate = @StartDate," &
                    " PeriodicPayment = @PeriodicPayment" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(SalaryLoanSchedule))
        End Function

        Public Function AddRecord(ByRef SalaryLoanSchedule As SalaryLoanSchedule) As Integer Implements IDaoAll(Of SalaryLoanSchedule).AddRecord
            Dim sql As String =
                    " INSERT INTO [SalaryLoanSchedule] " &
                    " (EmployeeIdNo,StartDate,PeriodicPayment,Amount) " &
                    " VALUES (@EmployeeIdNo,@StartDate,@PeriodicPayment,@Amount) "
            Return Db.Insert(sql, Take(SalaryLoanSchedule))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, SalaryLoanSchedule) =
                                    Function(reader) _
            New SalaryLoanSchedule() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .Amount = Extensions.AsBool(reader("Amount")),
            .EmployeeIdNo = Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .StartDate = Extensions.AsDate(reader("StartDate")),
            .PeriodicPayment = Extensions.AsDecimal(reader("PeriodicPayment"))
            }

        Private Function Take(SalaryLoanSchedule As SalaryLoanSchedule) As Object()
            Return New Object() {
                                    "@IdNo", SalaryLoanSchedule.IdNo,
                                    "@Amount", SalaryLoanSchedule.Amount,
                                    "@EmployeeIdNo", SalaryLoanSchedule.EmployeeIdNo,
                                    "@StartDate", SalaryLoanSchedule.StartDate,
                                    "@PeriodicPayment", SalaryLoanSchedule.PeriodicPayment
                                }
        End Function

    End Class

End Namespace