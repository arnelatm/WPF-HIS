Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Payroll
    ' ** DAO Pattern

    Public Class PayrollDao
        Inherits CommonDao
        Implements IDaoAll(Of Payroll)

        Private ReadOnly Db As New Db()

        Private FieldList As String =
                                      "EndDate," &
                                      "IdNo," &
                                      "PayCycleIdNo," &
                                      "PayrollCode," &
                                      "PayrollName," &
                                      "PayrollNameAra," &
                                      "StartDate"

        Public Function GetRecordByIdNo(idNo) As Payroll Implements IDaoAll(Of Payroll).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [Payroll]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Dim attendanceDao = New AttendanceItemDao
            Dim attendance As List(Of AttendanceItem)
            If data Is Nothing Then
                Return Nothing
            End If
            attendance = attendanceDao.GetRecordsWithGroupIdNo(data.IdNo, "EmployeeName")
            Dim overtimeDao = New OtWorkHourDao
            Dim overtime As List(Of OtWorkHour) = overtimeDao.GetRecordsWithGroupIdNo(data.IdNo, "EmployeeName")
            data.PayrollAttendance = attendance
            data.PayrollOvertime = overtime
            Return data
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Payroll) _
            Implements IDaoAll(Of Payroll).GetAll
            If sortExpression = Nothing Then
                sortExpression = "StartDate ASC"
            End If
            Dim sql As String = "SELECT IdNo, PayrollName, PayrollNameAra, StartDate, EndDate" &
                    " FROM [Payroll] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef Payroll As Payroll) As Integer Implements IDaoAll(Of Payroll).UpdateRecord
            Dim sql As String =
                    " UPDATE [Payroll] SET " &
                    " EndDate = @EndDate," &
                    " PayCycleIdNo = @PayCycleIdNo," &
                    " PayrollCode = @PayrollCode," &
                    " PayrollName = @PayrollName," &
                    " PayrollNameAra = @PayrollNameAra," &
                    " StartDate = @StartDate" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Payroll))
        End Function

        Public Function AddRecord(ByRef Payroll As Payroll) As Integer Implements IDaoAll(Of Payroll).AddRecord
            Dim sql As String =
                    " INSERT INTO [Payroll] " &
                    " (PayrollCode,PayrollName,PayrollNameAra,StartDate,EndDate,PayCycleIdNo)" &
                    " VALUES (@PayrollCode,@PayrollName,@PayrollNameAra,@StartDate,@EndDate,@PayCycleIdNo) "
            Return Db.Insert(sql, Take(Payroll))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Payroll) =
                                    Function(reader) _
            New Payroll() With {
            .EndDate = Extensions.AsDate(reader("EndDate")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .PayCycleIdNo = Extensions.AsInt(Of Int16)(reader("PayCycleIdNo")),
            .PayrollCode = Extensions.AsString(reader("PayrollCode")),
            .PayrollName = Extensions.AsString(reader("PayrollName")),
            .PayrollNameAra = Extensions.AsString(reader("PayrollNameAra")),
            .StartDate = Extensions.AsDate(reader("StartDate"))
            }

        Private Function Take(Payroll As Payroll) As Object()
            Return New Object() {
                                 "@EndDate", Payroll.EndDate,
                                 "@IdNo", Payroll.IdNo,
                                 "@PayCycleIdNo", Payroll.PayCycleIdNo,
                                 "@PayrollCode", Payroll.PayrollCode,
                                 "@PayrollName", Payroll.PayrollName,
                                 "@PayrollNameAra", Payroll.PayrollNameAra,
                                 "@StartDate", Payroll.StartDate
                                 }
        End Function

    End Class

End Namespace