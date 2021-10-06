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

        Public Function UpdateRecord(ByRef Leave As Leave) As Integer Implements IDaoAll(Of Leave).UpdateRecord
            Dim sql As String =
                    " UPDATE [Leave] SET " &
                    " Cumulative = @Cumulative," &
                    " LeaveAllowed = @LeaveAllowed," &
                    " LeaveCode = @LeaveCode," &
                    " LeaveName = @LeaveName," &
                    " LeaveNameAra = @LeaveNameAra," &
                    " MaxCarryOver = @MaxCarryOver," &
                    " MaxLimit = @MaxLimit," &
                    " Notes = @Notes," &
                    " PaidPercent = @PaidPercent" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Leave))
        End Function

        Public Function AddRecord(ByRef Leave As Leave) As Integer Implements IDaoAll(Of Leave).AddRecord
            Dim sql As String =
                    " INSERT INTO [Leave] " &
                    " (Cumulative,LeaveAllowed,LeaveCode,LeaveName,LeaveNameAra,MaxCarryOver,MaxLimit,Notes,PaidPercent)" &
                    " VALUES (@Cumulative,@LeaveAllowed,@LeaveCode,@LeaveName,@LeaveNameAra,@MaxCarryOver,@MaxLimit,@Notes,@PaidPercent)"
            Return Db.Insert(sql, Take(Leave))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Leave) =
                                    Function(reader) _
            New Leave() With {
            .Cumulative = Extensions.AsBool(reader("Cumulative")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .LeaveAllowed = Extensions.AsDecimal(reader("LeaveAllowed")),
            .LeaveCode = Extensions.AsString(reader("LeaveCode")),
            .LeaveName = Extensions.AsString(reader("LeaveName")),
            .LeaveNameAra = Extensions.AsString(reader("LeaveNameAra")),
            .MaxCarryOver = Extensions.AsDecimal(reader("MaxCarryOver")),
            .Notes = Extensions.AsString(reader("Notes")),
            .PaidPercent = Extensions.AsDecimal(reader("PaidPercent"))
            }

        Private Function Take(Leave As Leave) As Object()
            Return New Object() {
                                    "@Cumulative", Leave.Cumulative,
                                    "@IdNo", Leave.IdNo,
                                    "@LeaveAllowed", Leave.LeaveAllowed,
                                    "@LeaveCode", Leave.LeaveCode,
                                    "@LeaveName", Leave.LeaveName,
                                    "@LeaveNameAra", Leave.LeaveNameAra,
                                    "@MaxCarryOver", Leave.MaxCarryOver,
                                    "@MaxLimit", Leave.MaxLimit,
                                    "@Notes", Leave.Notes,
                                    "@PaidPercent", Leave.PaidPercent
                                }
        End Function

    End Class

End Namespace