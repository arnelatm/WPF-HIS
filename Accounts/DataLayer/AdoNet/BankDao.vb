Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Bank
    ' ** DAO Pattern

    Public Class BankDao
        Inherits CommonDao
        Implements IDaoAll(Of Bank)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As Bank Implements IDaoAll(Of Bank).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, BankCode, BankName, BankNameAra" &
                    "   FROM [Bank]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Bank) _
            Implements IDaoAll(Of Bank).GetAll
            If sortExpression = Nothing Then
                sortExpression = "BankName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, BankCode, BankName, BankNameAra" &
                    "   FROM [Bank] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef bank As Bank) As Integer Implements IDaoAll(Of Bank).UpdateRecord
            Dim sql As String =
                    " UPDATE [Bank]" &
                    "    SET BankCode = @BankCode," &
                    "        BankName = @BankName," &
                    "        BankNameAra = @BankNameAra" &
                    "  WHERE IdNo = @IdNo"

            Return Db.Update(sql, Take(bank))
        End Function

        Public Function AddRecord(ByRef bank As Bank) As Integer Implements IDaoAll(Of Bank).AddRecord
            Dim sql As String =
                    " INSERT INTO [Bank] " &
                    " (BankCode,BankName,BankNameAra) " &
                    " VALUES (@BankCode,@BankName,@BankNameAra) "
            Return Db.Insert(sql, Take(bank))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Bank) =
                                    Function(reader) _
            New Bank() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .BankCode = Extensions.AsString(reader("BankCode")),
            .BankName = Extensions.AsString(reader("BankName")),
            .BankNameAra = Extensions.AsString(reader("BankNameAra"))
            }

        Private Function Take(bank As Bank) As Object()
            Return New Object() {
                                    "@IdNo", bank.IdNo,
                                    "@BankCode", bank.BankCode,
                                    "@BankName", bank.BankName,
                                    "@BankNameAra", bank.BankNameAra
                                }
        End Function

    End Class

End Namespace