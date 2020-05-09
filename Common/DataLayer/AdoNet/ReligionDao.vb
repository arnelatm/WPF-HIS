Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Religion
    ' ** DAO Pattern

    Public Class ReligionDao
        Inherits CommonDao
        Implements IDaoAll(Of Religion)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As Religion Implements IDaoAll(Of Religion).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, ReligionCode, ReligionName, ReligionNameAra, Notes" &
                    "   FROM [Religion]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Religion) _
            Implements IDaoAll(Of Religion).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "ReligionName"
            End If
            Dim sql As String =
                    " SELECT IdNo, ReligionCode, ReligionName, ReligionNameAra, Notes" &
                    "   FROM [Religion] " & "order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef religion As Religion) As Integer Implements IDaoAll(Of Religion).UpdateRecord
            Dim sql As String =
                    " UPDATE [Religion]" &
                    "    SET ReligionCode = @ReligionCode," &
                    "        ReligionName = @ReligionName," &
                    "        ReligionNameAra = @ReligionNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo"

            Return _db.Update(sql, Take(religion))
        End Function

        Public Function AddRecord(ByRef religion As Religion) As Integer Implements IDaoAll(Of Religion).AddRecord
            Dim sql As String =
                    " INSERT INTO [Religion] " &
                    " (ReligionCode,ReligionName,ReligionNameAra,Notes) " &
                    " VALUES (@ReligionCode,@ReligionName,@ReligionNameAra,@Notes) "
            Return _db.Insert(sql, Take(religion))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Religion) =
                                    Function(reader) _
            New Religion() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ReligionCode = Extensions.AsString(reader("ReligionCode")),
            .ReligionName = Extensions.AsString(reader("ReligionName")),
            .ReligionNameAra = Extensions.AsString(reader("ReligionNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(religion As Religion) As Object()
            Return New Object() {
                                    "@IdNo", religion.IdNo,
                                    "@ReligionCode", religion.ReligionCode,
                                    "@ReligionName", religion.ReligionName,
                                    "@ReligionNameAra", religion.ReligionNameAra,
                                    "@Notes", religion.Notes
                                }
        End Function

    End Class

End Namespace