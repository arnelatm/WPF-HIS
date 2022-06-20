Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for JournalPrefix
    ' ** DAO Pattern

    Public Class JournalPrefixDao
        Inherits CommonDao
        Implements iDao(Of JournalPrefix)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As JournalPrefix Implements iDao(Of JournalPrefix).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, JournalCode, JournalName, JournalNameAra, JournalCodeAra" &
                    "   FROM [JournalPrefix]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef JournalPrefix As JournalPrefix) As Integer Implements iDao(Of JournalPrefix).UpdateRecord
            Dim sql As String =
                    " UPDATE [JournalPrefix]" &
                    " SET JournalCode = @JournalCode," &
                    " JournalName = @JournalName," &
                    " JournalNameAra = @JournalNameAra," &
                    " JournalCodeAra = @JournalCodeAra" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(JournalPrefix))
        End Function

        Public Function AddRecord(ByRef JournalPrefix As JournalPrefix) As Integer Implements iDao(Of JournalPrefix).AddRecord
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