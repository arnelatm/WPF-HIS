Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Leave
    ' ** DAO Pattern

    Public Class LeaveDao
        Inherits CommonDao
        Implements iDao(Of Leave)

        Private ReadOnly Db As New Db()

        Private Const FieldList =
                    "Cumulative," &
                    "Earnable," &
                    "Holiday," &
                    "IdNo," &
                    "LeaveAllowed," &
                    "LeaveCode," &
                    "LeaveType," &
                    "LeaveName," &
                    "LeaveNameAra," &
                    "MaxCarryOver," &
                    "MaxLimit," &
                    "NoMaxLimit," &
                    "Notes," &
                    "PaidPercent"

        Public Function GetRecordByIdNo(idNo) As Leave Implements iDao(Of Leave).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [Leave]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef leave As Leave) As Integer Implements iDao(Of Leave).UpdateRecord
            Dim sql As String =
                    " UPDATE [Leave] SET " &
                    " Cumulative = @Cumulative," &
                    " Earnable = @Earnable," &
                    " Holiday = @Holiday," &
                    " LeaveAllowed = @LeaveAllowed," &
                    " LeaveCode = @LeaveCode," &
                    " LeaveType = @LeaveType," &
                    " LeaveName = @LeaveName," &
                    " LeaveNameAra = @LeaveNameAra," &
                    " MaxCarryOver = @MaxCarryOver," &
                    " MaxLimit = @MaxLimit," &
                    " NoMaxLimit = @NoMaxLimit," &
                    " Notes = @Notes," &
                    " PaidPercent = @PaidPercent" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(leave))
        End Function

        Public Function AddRecord(ByRef leave As Leave) As Integer Implements iDao(Of Leave).AddRecord
            Dim sql As String =
                    " INSERT INTO [Leave] " &
                    " (Cumulative,Earnable,Holiday,LeaveAllowed,LeaveCode,LeaveType,LeaveName,LeaveNameAra,MaxCarryOver,MaxLimit,NoMaxLimit,Notes,PaidPercent)" &
                    " VALUES (@Cumulative,@Earnable,@Holiday,@LeaveAllowed,@LeaveCode,@LeaveType,@LeaveName,@LeaveNameAra,@MaxCarryOver,@MaxLimit,@NoMaxLimit,@Notes,@PaidPercent)"
            Return Db.Insert(sql, Take(leave))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Leave) =
                                    Function(reader) _
            New Leave() With {
            .Cumulative = Extensions.AsBool(reader("Cumulative")),
            .Earnable = Extensions.AsBool(reader("Earnable")),
            .Holiday = Extensions.AsBool(reader("Holiday")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .LeaveAllowed = Extensions.AsDecimal(reader("LeaveAllowed")),
            .LeaveCode = Extensions.AsString(reader("LeaveCode")),
            .LeaveType = Extensions.AsString(reader("LeaveType")),
            .LeaveName = Extensions.AsString(reader("LeaveName")),
            .LeaveNameAra = Extensions.AsString(reader("LeaveNameAra")),
            .MaxCarryOver = Extensions.AsDecimal(reader("MaxCarryOver")),
            .MaxLimit = Extensions.AsDecimal(reader("MaxLimit")),
            .NoMaxLimit = Extensions.AsBool(reader("NoMaxLimit")),
            .Notes = Extensions.AsString(reader("Notes")),
            .PaidPercent = Extensions.AsDecimal(reader("PaidPercent"))
            }

        Private Function Take(leave As Leave) As Object()
            Return New Object() {
                                    "@Cumulative", leave.Cumulative,
                                    "@Earnable", leave.Earnable,
                                    "@Holiday", leave.Holiday,
                                    "@IdNo", leave.IdNo,
                                    "@LeaveAllowed", leave.LeaveAllowed,
                                    "@LeaveCode", leave.LeaveCode,
                                    "@LeaveType", leave.LeaveType,
                                    "@LeaveName", leave.LeaveName,
                                    "@LeaveNameAra", leave.LeaveNameAra,
                                    "@MaxCarryOver", leave.MaxCarryOver,
                                    "@MaxLimit", leave.MaxLimit,
                                    "@NoMaxLimit", leave.NoMaxLimit,
                                    "@Notes", leave.Notes,
                                    "@PaidPercent", leave.PaidPercent
                                }
        End Function

    End Class

End Namespace