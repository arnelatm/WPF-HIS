Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Holiday
    ' ** DAO Pattern

    Public Class HolidayDao
        Inherits CommonDao
        Implements IDaoAll(Of Holiday)

        Private ReadOnly Db As New Db()

        Private FieldList As String = "DateCreated," &
                                      "HolidayDate," &
                                      "HolidayName," &
                                      "HolidayNameAra," &
                                      "IdNo"

        Public Function GetRecordByIdNo(idNo) As Holiday Implements IDaoAll(Of Holiday).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [Holiday]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Holiday) _
            Implements IDaoAll(Of Holiday).GetAll
            If sortExpression = Nothing Then
                sortExpression = "StartDate ASC"
            End If
            Dim sql As String = "SELECT IdNo, HolidayName, " &
                " FROM [Holiday] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef holiday As Holiday) As Integer Implements IDaoAll(Of Holiday).UpdateRecord
            Dim sql As String =
                    " UPDATE [Holiday] SET " &
                    " HolidayDate = @HolidayDate," &
                    " HolidayName = @HolidayName," &
                    " HolidayNameAra = @HolidayNameAra" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(holiday))
        End Function

        Public Function AddRecord(ByRef holiday As Holiday) As Integer Implements IDaoAll(Of Holiday).AddRecord
            Dim sql As String = " INSERT INTO [Holiday] " &
                    " (HolidayDate,HolidayName,HolidayNameAra)" &
                    " VALUES (@HolidayDate,@HolidayName,@HolidayNameAra)"
            Return Db.Insert(sql, Take(holiday))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Holiday) =
                                    Function(reader) _
            New Holiday() With {
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .HolidayDate = Extensions.AsDate(reader("HolidayDate")),
            .HolidayName = Extensions.AsString(reader("HolidayName")),
            .HolidayNameAra = Extensions.AsString(reader("HolidayNameAra")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo"))
            }

        Private Function Take(holiday As Holiday) As Object()
            Return New Object() {
                            "DateCreated", holiday.DateCreated,
                            "HolidayDate", holiday.HolidayDate,
                            "HolidayName", holiday.HolidayName,
                            "HolidayNameAra", holiday.HolidayNameAra,
                            "IdNo", holiday.IdNo
                            }
        End Function

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