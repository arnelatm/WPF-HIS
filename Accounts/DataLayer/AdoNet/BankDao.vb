Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Bank
    ' ** DAO Pattern

    Public Class BankDao
        Inherits CommonDao
        Implements iDao(Of Bank)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Bank Implements iDao(Of Bank).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, BankCode, BankName, BankNameAra, Notes" &
                    "   FROM [Bank]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef bank As Bank) As Integer Implements iDao(Of Bank).UpdateRecord
            Dim sql As String =
                    " UPDATE [Bank]" &
                    "    SET BankCode = @BankCode," &
                    "        BankName = @BankName," &
                    "        BankNameAra = @BankNameAra," &
                    "        Notes = @Notes " &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(bank))
        End Function

        Public Function AddRecord(ByRef bank As Bank) As Integer Implements iDao(Of Bank).AddRecord
            Dim sql As String =
                    " INSERT INTO [Bank] " &
                    " (BankCode,BankName,BankNameAra,Notes) " &
                    " VALUES (@BankCode,@BankName,@BankNameAra,@Notes) "
            Return Db.Insert(sql, Take(bank))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Bank) =
                                    Function(reader) _
            New Bank() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .BankCode = Extensions.AsString(reader("BankCode")),
            .BankName = Extensions.AsString(reader("BankName")),
            .BankNameAra = Extensions.AsString(reader("BankNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(bank As Bank) As Object()
            Return New Object() {
                                    "@BankCode", bank.BankCode,
                                    "@BankName", bank.BankName,
                                    "@BankNameAra", bank.BankNameAra,
                                    "@IdNo", bank.IdNo,
                                    "@Notes", bank.Notes
                                }
        End Function

    End Class

End Namespace