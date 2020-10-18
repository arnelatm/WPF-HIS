Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayCycle
    ' ** DAO Pattern

    Public Class PayCycleDao
        Inherits CommonDao
        Implements IDaoAll(Of PayCycle)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As PayCycle Implements IDaoAll(Of PayCycle).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, PayFrequency, PayCycleCode, PayCycleName, PayCycleNameAra, Notes " &
                    "   FROM [PayCycle]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of PayCycle) _
            Implements IDaoAll(Of PayCycle).GetAll
            If sortExpression = Nothing Then
                sortExpression = "PayCycleName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, PayCycleCode, PayCycleName, PayCycleNameAra" &
                    "   FROM [PayCycle] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef PayCycle As PayCycle) As Integer Implements IDaoAll(Of PayCycle).UpdateRecord
            Dim sql As String =
                    " UPDATE [PayCycle] Set " &
                    " PayFrequency = @PayFrequency," &
                    " PayCycleCode = @PayCycleCode," &
                    " PayCycleName = @PayCycleName," &
                    " PayCycleNameAra = @PayCycleNameAra," &
                    " Notes = @Notes" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(PayCycle))
        End Function

        Public Function AddRecord(ByRef PayCycle As PayCycle) As Integer Implements IDaoAll(Of PayCycle).AddRecord
            Dim sql As String =
                    " INSERT INTO [PayCycle] " &
                    " (PayFrequency,PayCycleCode,PayCycleName,PayCycleNameAra,Notes) " &
                    " VALUES (@PayFrequency,@PayCycleCode,@PayCycleName,@PayCycleNameAra,@Notes) "
            Return Db.Insert(sql, Take(PayCycle))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayCycle) =
                                    Function(reader) _
            New PayCycle() With {
            .PayFrequency = Extensions.AsChar(reader("PayFrequency")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .PayCycleCode = Extensions.AsString(reader("PayCycleCode")),
            .PayCycleName = Extensions.AsString(reader("PayCycleName")),
            .PayCycleNameAra = Extensions.AsString(reader("PayCycleNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(PayCycle As PayCycle) As Object()
            Return New Object() {
                                    "PayFrequency", PayCycle.PayFrequency,
                                    "@IdNo", PayCycle.IdNo,
                                    "@PayCycleCode", PayCycle.PayCycleCode,
                                    "@PayCycleName", PayCycle.PayCycleName,
                                    "@PayCycleNameAra", PayCycle.PayCycleNameAra,
                                    "@Notes", PayCycle.Notes
                                }
        End Function

    End Class

End Namespace