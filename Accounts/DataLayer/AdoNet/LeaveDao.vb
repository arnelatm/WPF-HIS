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

        Private Const FieldList =
                    "Cumulative," &
                    "Holiday," &
                    "IdNo," &
                    "LeaveAllowed," &
                    "LeaveCode," &
                    "LeaveName," &
                    "LeaveNameAra," &
                    "MaxCarryOver," &
                    "MaxLimit," &
                    "Notes," &
                    "PaidPercent"

        Public Function GetRecordByIdNo(idNo) As Leave Implements IDaoAll(Of Leave).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [Leave]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Leave) _
            Implements IDaoAll(Of Leave).GetAll
            If sortExpression = Nothing Then
                sortExpression = "LeaveName ASC"
            End If
            Dim sql As String = "Select " & FieldList & " FROM [Leave] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef leave As Leave) As Integer Implements IDaoAll(Of Leave).UpdateRecord
            Dim sql As String =
                    " UPDATE [Leave] SET " &
                    " Cumulative = @Cumulative," &
                    " Holiday = @Holiday," &
                    " LeaveAllowed = @LeaveAllowed," &
                    " LeaveCode = @LeaveCode," &
                    " LeaveName = @LeaveName," &
                    " LeaveNameAra = @LeaveNameAra," &
                    " MaxCarryOver = @MaxCarryOver," &
                    " MaxLimit = @MaxLimit," &
                    " Notes = @Notes," &
                    " PaidPercent = @PaidPercent" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(leave))
        End Function

        Public Function AddRecord(ByRef leave As Leave) As Integer Implements IDaoAll(Of Leave).AddRecord
            Dim sql As String =
                    " INSERT INTO [Leave] " &
                    " (Cumulative,Holiday,LeaveAllowed,LeaveCode,LeaveName,LeaveNameAra,MaxCarryOver,MaxLimit,Notes,PaidPercent)" &
                    " VALUES (@Cumulative,@Holiday,@LeaveAllowed,@LeaveCode,@LeaveName,@LeaveNameAra,@MaxCarryOver,@MaxLimit,@Notes,@PaidPercent)"
            Return Db.Insert(sql, Take(leave))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Leave) =
                                    Function(reader) _
            New Leave() With {
            .Cumulative = Extensions.AsBool(reader("Cumulative")),
            .Holiday = Extensions.AsBool(reader("Holiday")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .LeaveAllowed = Extensions.AsDecimal(reader("LeaveAllowed")),
            .LeaveCode = Extensions.AsString(reader("LeaveCode")),
            .LeaveName = Extensions.AsString(reader("LeaveName")),
            .LeaveNameAra = Extensions.AsString(reader("LeaveNameAra")),
            .MaxCarryOver = Extensions.AsDecimal(reader("MaxCarryOver")),
            .Notes = Extensions.AsString(reader("Notes")),
            .PaidPercent = Extensions.AsDecimal(reader("PaidPercent"))
            }

        Private Function Take(leave As Leave) As Object()
            Return New Object() {
                                    "@Cumulative", leave.Cumulative,
                                    "@Holiday", leave.Holiday,
                                    "@IdNo", leave.IdNo,
                                    "@LeaveAllowed", leave.LeaveAllowed,
                                    "@LeaveCode", leave.LeaveCode,
                                    "@LeaveName", leave.LeaveName,
                                    "@LeaveNameAra", leave.LeaveNameAra,
                                    "@MaxCarryOver", leave.MaxCarryOver,
                                    "@MaxLimit", leave.MaxLimit,
                                    "@Notes", leave.Notes,
                                    "@PaidPercent", leave.PaidPercent
                                }
        End Function

    End Class

End Namespace