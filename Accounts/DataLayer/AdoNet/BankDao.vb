Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for Bank
    ' ** DAO Pattern

    Public Class BankDao
        Inherits CommonDaoOld
        Implements IBankDao

        Private Shared ReadOnly Db As New Db()

        Public Sub New()
            DbCommon = Db
        End Sub

        Public Function GetRecordById(idNo As Integer) As Bank Implements IBankDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, BankCode, BankName, BankNameAra" &
                    "   FROM [Bank]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "BankName ASC") As List(Of Bank) _
            Implements IBankDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, BankCode, BankName, BankNameAra" &
                    "   FROM [Bank] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef bank As Bank) As Integer Implements IBankDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [Bank]" &
                    "    SET BankCode = @BankCode," &
                    "        BankName = @BankName," &
                    "        BankNameAra = @BankNameAra" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(bank))
        End Function

        Public Function AddRecord(ByRef bank As Bank) As Integer Implements IBankDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [Bank] " &
                    " (BankCode,BankName,BankNameAra) " &
                    " VALUES (@BankCode,@BankName,@BankNameAra) "
            Return Db.Insert(sql, Take(bank))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Bank) =
                                    Function(reader) _
            New Bank() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .BankCode = Extensions.AsString(reader("BankCode")),
            .BankName = Extensions.AsString(reader("BankName")),
            .BankNameAra = Extensions.AsString(reader("BankNameAra"))
            }

        Private Function Take(bank As Bank) As Object()
            Return New Object() {
                                    "@IDNo", bank.IdNo,
                                    "@BankCode", bank.BankCode,
                                    "@BankName", bank.BankName,
                                    "@BankNameAra", bank.BankNameAra
                                }
        End Function

    End Class

End Namespace