Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for JournalPrefix
    ' ** DAO Pattern

    Public Class JournalPrefixDao
        Inherits CommonDao
        Implements IDaoAll(Of JournalPrefix)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As JournalPrefix Implements IDaoAll(Of JournalPrefix).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, JournalCode, JournalName, JournalNameAra, JournalCodeAra" &
                    "   FROM [JournalPrefix]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of JournalPrefix) _
            Implements IDaoAll(Of JournalPrefix).GetAll
            If sortExpression = Nothing Then
                sortExpression = " ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, JournalCode" &
                    "   FROM [JournalPrefix] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef JournalPrefix As JournalPrefix) As Integer Implements IDaoAll(Of JournalPrefix).UpdateRecord
            Dim sql As String =
                    " UPDATE [JournalPrefix]" &
                    " SET JournalCode = @JournalCode," &
                    " JournalName = @JournalName," &
                    " JournalNameAra = @JournalNameAra," &
                    " JournalCodeAra = @JournalCodeAra" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(JournalPrefix))
        End Function

        Public Function AddRecord(ByRef JournalPrefix As JournalPrefix) As Integer Implements IDaoAll(Of JournalPrefix).AddRecord
            Dim sql As String =
                    " INSERT INTO [JournalPrefix] " &
                    " (JournalCode,JournalNameAra,JournalCodeAra,JournalName) " &
                    " VALUES (@JournalCode,@JournalNameAra,@JournalCodeAra,@JournalName) "
            Return Db.Insert(sql, Take(JournalPrefix))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, JournalPrefix) =
                                    Function(reader) _
            New JournalPrefix() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .JournalName = Extensions.AsString(reader("JournalName")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalNameAra = Extensions.AsString(reader("JournalNameAra")),
            .JournalCodeAra = Extensions.AsString(reader("JournalCodeAra"))
            }

        Private Function Take(JournalPrefix As JournalPrefix) As Object()
            Return New Object() {
                                    "@IdNo", JournalPrefix.IdNo,
                                    "@JournalName", JournalPrefix.JournalName,
                                    "@JournalCode", JournalPrefix.JournalCode,
                                    "@JournalNameAra", JournalPrefix.JournalNameAra,
                                    "@JournalCodeAra", JournalPrefix.JournalCodeAra
                                }
        End Function

    End Class

End Namespace