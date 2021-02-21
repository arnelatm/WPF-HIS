Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries
Imports AutoMapper

Namespace DataLayer.AdoNet
    ' Data access object for Payroll
    ' ** DAO Pattern

    Public Class PayrollDao
        Inherits CommonDao
        Implements IDaoAll(Of Payroll)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As Payroll Implements IDaoAll(Of Payroll).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, PayrollCode, PayrollName, PayrollNameAra, StartDate, EndDate, PayCycleIdNo" &
                    "   FROM [Payroll]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Dim attendanceDao = New AttendanceItemDao
            Dim attendance As List(Of AttendanceItem) = attendanceDao.GetRecordsWithIdNo(data.IdNo, "EmployeeName")
            data.PayrollAttendance = attendance
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
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .PayrollCode = Extensions.AsString(reader("PayrollCode")),
            .PayrollName = Extensions.AsString(reader("PayrollName")),
            .PayrollNameAra = Extensions.AsString(reader("PayrollNameAra")),
            .StartDate = Extensions.AsDate(reader("StartDate")),
            .EndDate = Extensions.AsDate(reader("EndDate")),
            .PayCycleIdNo = Extensions.AsInt(Of Int16)(reader("PayCycleIdNo"))
            }

        Private Function Take(Payroll As Payroll) As Object()
            Return New Object() {
                                 "@IdNo", Payroll.IdNo,
                                 "@PayrollCode", Payroll.PayrollCode,
                                 "@PayrollName", Payroll.PayrollName,
                                 "@PayrollNameAra", Payroll.PayrollNameAra,
                                 "@StartDate", Payroll.StartDate,
                                 "@EndDate", Payroll.EndDate,
                                 "@PayCycleIdNo", Payroll.PayCycleIdNo
                                 }
        End Function

    End Class

End Namespace