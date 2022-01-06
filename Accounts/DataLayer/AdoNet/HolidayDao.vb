Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Holiday
    ' ** DAO Pattern

    Public Class HolidayDao
        Inherits CommonDao
        Implements iDao(Of Holiday)

        Private ReadOnly Db As New Db()

        Private FieldList As String = "DateCreated," &
                                      "DateEnd," &
                                      "DateStart," &
                                      "EnteredBy," &
                                      "IdNo," &
                                      "LeaveIdNo"

        '"PayrollCode," &
        '"PayrollIdNo," &
        '"PayrollName," &
        '"PayrollStartDate," &
        '"PayrollEndDate"

        Public Function GetRecordByIdNo(idNo) As Holiday Implements iDao(Of Holiday).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & FieldList &
                    " FROM Holiday" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef holiday As Holiday) As Integer Implements iDao(Of Holiday).UpdateRecord
            Dim sql As String =
                    " UPDATE [Holiday] SET " &
                    " DateEnd = @DateEnd," &
                    " DateStart = @DateStart," &
                    " EnteredBy = @EnteredBy," &
                    " LeaveIdNo = @LeaveIdNo" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(holiday))
        End Function

        Public Function AddRecord(ByRef holiday As Holiday) As Integer Implements iDao(Of Holiday).AddRecord
            Dim sql As String = " INSERT INTO [Holiday] " &
                    " (DateEnd,DateStart,EnteredBy,LeaveIdNo)" &
                    " VALUES (@DateEnd,@DateStart,@EnteredBy,@LeaveIdNo)"
            Return Db.Insert(sql, Take(holiday))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Holiday) =
                            Function(reader) _
            New Holiday() With {
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .DateEnd = Extensions.AsDate(reader("DateEnd")),
            .DateStart = Extensions.AsDate(reader("DateStart")),
            .EnteredBy = Extensions.AsInt(Of Int32)(reader("EnteredBy")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveIdNo = Extensions.AsInt(Of Int16)(reader("LeaveIdNo"))
            }

        Private Function Take(holiday As Holiday) As Object()
            Return New Object() {
                            "DateCreated", holiday.DateCreated,
                            "DateEnd", holiday.DateEnd,
                            "DateStart", holiday.DateStart,
                            "EnteredBy", holiday.EnteredBy,
                            "IdNo", holiday.IdNo,
                            "LeaveIdNo", holiday.LeaveIdNo
                            }
        End Function

        'Private Shared ReadOnly Make As Func(Of IDataReader, Holiday) =
        '                            Function(reader) _
        '    New Holiday() With {
        '    .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
        '    .DateEnd = Extensions.AsDate(reader("DateEnd")),
        '    .DateStart = Extensions.AsDate(reader("DateStart")),
        '    .EnteredBy = Extensions.AsInt(Of Int32)(reader("EnteredBy")),
        '    .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
        '    .LeaveIdNo = Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
        '    .PayrollName = Extensions.AsString(reader("PayrollName")),
        '    .PayrollCode = Extensions.AsString(reader("PayrollCode")),
        '    .PayrollIdNo = Extensions.AsId(Of Int32)(reader("PayrollIdNo")),
        '    .PayrollStartDate = Extensions.AsString(reader("PayrollStartDate")),
        '    .PayrollEndDate = Extensions.AsString(reader("PayrollEndDate"))
        '    }

        'Private Function Take(holiday As Holiday) As Object()
        '    Return New Object() {
        '                    "DateCreated", holiday.DateCreated,
        '                    "DateEnd", holiday.DateEnd,
        '                    "DateStart", holiday.DateStart,
        '                    "EnteredBy", holiday.EnteredBy,
        '                    "IdNo", holiday.IdNo,
        '                    "LeaveIdNo", holiday.LeaveIdNo,
        '                    "PayrollIdNo", holiday.PayrollIdNo
        '                    }
        'End Function

        'Public Function GetRecordsWithGroupIdNo(payrollIdNo, Optional sortExpression = Nothing) As List(Of Holiday) Implements IDaoChild(Of Holiday).GetRecordsWithGroupIdNo
        '    If sortExpression Is Nothing Then
        '        sortExpression = "Sequence"
        '    End If
        '    Dim sql As String =
        '            "SELECT " & FieldList &
        '            " FROM Holiday_View" &
        '            " WHERE PayrollIdNo = @PayrollIdNo" &
        '            " ORDER BY " & sortExpression.ToString()
        '    Dim params() As Object = {"@PayrollIdNo", payrollIdNo}
        '    Return Db.Read(sql, Make, params).ToList()
        'End Function

        'Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of Holiday).DelUpdateTvp
        '    Throw New NotImplementedException()
        'End Function

        'Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of Holiday).InsertTvp
        '    Throw New NotImplementedException()
        'End Function

    End Class

End Namespace