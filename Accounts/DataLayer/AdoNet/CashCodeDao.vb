Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CashCode
    ' ** DAO Pattern

    Public Class CashCodeDao
        Inherits CommonDao
        Implements IDaoAll(Of CashCode)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As CashCode Implements IDaoAll(Of CashCode).GetRecordById
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo," &
                    "CashCode," &
                    "CashName," &
                    "CashNameAra," &
                    "IdNo," &
                    "Rate," &
                    " FROM [CashCode]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim x = Db.Read(sql, Make, params).FirstOrDefault()
            Return x
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of CashCode) _
            Implements IDaoAll(Of CashCode).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "CashName ASC"
            End If
            Dim sql As String = " SELECT " &
                    "AccountIdNo," &
                    "BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo," &
                    "CashCode," &
                    "CashName," &
                    "CashNameAra," &
                    "IdNo, " &
                    "Rate" &
                    " FROM [CashCode] order by CashName"
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef cashCode As CashCode) As Integer Implements IDaoAll(Of CashCode).UpdateRecord
            Dim sql As String =
                    "UPDATE [CashCode] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "BankChargesAccountIdNo = @BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo = @BankChargesVatAccountIdNo," &
                    "CashCode = @CashCode," &
                    "CashName = @CashName," &
                    "CashNameAra = @CashNameAra," &
                    "IdNo = @IdNo, " &
                    "Rate = @Rate" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(cashCode))
        End Function

        Public Function AddRecord(ByRef cashCode As CashCode) As Integer Implements IDaoAll(Of CashCode).AddRecord
            Dim sql As String =
                    "INSERT INTO [CashCode] (" &
                    "AccountIdNo," &
                    "BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo," &
                    "CashCode," &
                    "CashName," &
                    "CashNameAra," &
                    "IdNo, " &
                    "Rate" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@BankChargesAccountIdNo," &
                    "@BankChargesVatAccountIdNo," &
                    "@CashCode," &
                    "@CashName," &
                    "@CashNameAra," &
                    "@IdNo, " &
                    "@Rate" &
                    ")"
            Return Db.Insert(sql, Take(cashCode))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CashCode) =
                                    Function(reader) _
            New CashCode() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .BankChargesAccountIdNo = Extensions.AsInt(Of Integer)(reader("BankChargesAccountIdNo")),
            .BankChargesVatAccountIdNo = Extensions.AsInt(Of Integer)(reader("BankChargesVatAccountIdNo")),
            .CashCode = Extensions.AsString(reader("CashCode")),
            .CashName = Extensions.AsString(reader("CashName")),
            .CashNameAra = Extensions.AsString(reader("CashNameAra")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Rate = Extensions.AsDecimal(reader("Rate"))
            }

        Private Function Take(cashCode As CashCode) As Object()
            Return New Object() {
                                    "@AccountIdNo", cashCode.AccountIdNo,
                                    "@BankChargesAccountIdNo" = cashCode.BankChargesAccountIdNo,
                                    "@BankChargesVatAccountIdNo" = cashCode.BankChargesVatAccountIdNo,
                                    "@CashCode", cashCode.CashCode,
                                    "@CashName", cashCode.CashName,
                                    "@CashNameAra", cashCode.CashNameAra,
                                    "@IdNo", cashCode.IdNo,
                                    "@Rate", cashCode.Rate
                                }
        End Function

    End Class

End Namespace