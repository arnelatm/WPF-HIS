Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Payroll
    ' ** DAO Pattern

    Public Class PayrollDao
        Inherits CommonDao
        Implements IDao(Of Payroll)

        Private ReadOnly Db As New Db()

        Private FieldList As String =
                                      "EndDate," &
                                      "IdNo," &
                                      "PayCycleIdNo," &
                                      "PayrollCode," &
                                      "PayrollName," &
                                      "PayrollNameAra," &
                                      "PayFrequency," &
                                      "StartDate"

        Public Function GetRecordByIdNo(idNo) As Payroll Implements iDao(Of Payroll).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [Payroll_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
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
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef Payroll As Payroll) As Integer Implements iDao(Of Payroll).UpdateRecord
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

        Public Function AddRecord(ByRef Payroll As Payroll) As Integer Implements iDao(Of Payroll).AddRecord
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
            .PayFrequency = Extensions.AsChar(reader("PayFrequency")),
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