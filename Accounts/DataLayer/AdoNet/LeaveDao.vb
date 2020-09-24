Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Leave
    ' ** DAO Pattern

    Public Class LeaveDao
        Inherits CommonDao
        Implements IDaoAll(Of Leave)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As Leave Implements IDaoAll(Of Leave).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, LeaveCode, LeaveName, LeaveNameAra, PaidPercent, Cumulative, MaxCarryOver, MaxLimit, NoMaxLimit, Notes " &
                    "   FROM [Leave]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Leave) _
            Implements IDaoAll(Of Leave).GetAll
            If sortExpression = Nothing Then
                sortExpression = "LeaveName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, LeaveCode, LeaveName, LeaveNameAra" &
                    "   FROM [Leave] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef Leave As Leave) As Integer Implements IDaoAll(Of Leave).UpdateRecord
            Dim sql As String =
                    " UPDATE [Leave]" &
                    " SET LeaveCode = @LeaveCode," &
                    " LeaveName = @LeaveName," &
                    " LeaveNameAra = @LeaveNameAra," &
                    " PaidPercent = @PaidPercent," &
                    " Cumulative = @Cumulative," &
                    " MaxCarryOver = @MaxCarryOver," &
                    " MaxLimit = @MaxLimit," &
                    " NoMaxLimit = @NoMaxLimit," &
                    " Notes = @Notes" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Leave))
        End Function

        Public Function AddRecord(ByRef Leave As Leave) As Integer Implements IDaoAll(Of Leave).AddRecord
            Dim sql As String =
                    " INSERT INTO [Leave] " &
                    " (LeaveCode,LeaveName,LeaveNameAra,PaidPercent,Cumulative,MaxCarryOver,MaxLimit,NoMaxLimit,Notes) " &
                    " VALUES (@LeaveCode,@LeaveName,@LeaveNameAra,@PaidPercent,@Cumulative,@MaxCarryOver,@MaxLimit,@NoMaxLimit,@Notes) "
            Return Db.Insert(sql, Take(Leave))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Leave) =
                                    Function(reader) _
            New Leave() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .LeaveCode = Extensions.AsString(reader("LeaveCode")),
            .LeaveName = Extensions.AsString(reader("LeaveName")),
            .LeaveNameAra = Extensions.AsString(reader("LeaveNameAra")),
            .PaidPercent = Extensions.AsDecimal(reader("PaidPercent")),
            .Cumulative = Extensions.AsBool(reader("Cumulative")),
            .MaxCarryOver = Extensions.AsInt(Of Int16)(reader("MaxCarryOver")),
            .MaxLimit = Extensions.AsInt(Of Int16)(reader("MaxLimit")),
            .NoMaxLimit = Extensions.AsBool(reader("NoMaxLimit")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(Leave As Leave) As Object()
            Return New Object() {
                                    "@IdNo", Leave.IdNo,
                                    "@LeaveCode", Leave.LeaveCode,
                                    "@LeaveName", Leave.LeaveName,
                                    "@LeaveNameAra", Leave.LeaveNameAra,
                                    "@PaidPercent", Leave.PaidPercent,
                                    "@Cumulative", Leave.Cumulative,
                                    "@MaxCarryOver", Leave.MaxCarryOver,
                                    "@MaxLimit", Leave.MaxLimit,
                                    "@NoMaxLimit", Leave.NoMaxLimit,
                                    "@Notes", Leave.Notes
                                }
        End Function

    End Class

End Namespace