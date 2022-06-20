Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for DepositType
    ' ** DAO Pattern

    Public Class DepositTypeDao1
        Inherits CommonDao
        Implements iDao(Of DepositType)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As DepositType Implements iDao(Of DepositType).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo," &
                    "DepositTypeCode," &
                    "DepositTypeName," &
                    "DepositTypeNameAra," &
                    "IdNo," &
                    "Notes," &
                    "Rate," &
                    "WithBankCharges" &
                    " FROM [DepositType]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim x = Db.Read(sql, Make, params).FirstOrDefault()
            Return x
        End Function

        Public Function UpdateRecord(ByRef depositType As DepositType) As Integer Implements iDao(Of DepositType).UpdateRecord
            Dim sql As String =
                    "UPDATE [DepositType] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "BankChargesAccountIdNo = @BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo = @BankChargesVatAccountIdNo," &
                    "DepositTypeCode = @DepositTypeCode," &
                    "DepositTypeName = @DepositTypeName," &
                    "DepositTypeNameAra = @DepositTypeNameAra," &
                    "Notes = @Notes," &
                    "Rate = @Rate," &
                    "WithBankCharges = @WithBankCharges" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(depositType))
        End Function

        Public Function AddRecord(ByRef depositType As DepositType) As Integer Implements iDao(Of DepositType).AddRecord
            Dim sql As String =
                    "INSERT INTO [DepositType] (" &
                    "AccountIdNo," &
                    "BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo," &
                    "DepositTypeCode," &
                    "DepositTypeName," &
                    "DepositTypeNameAra," &
                    "Notes," &
                    "Rate," &
                    "WithBankCharges" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@BankChargesAccountIdNo," &
                    "@BankChargesVatAccountIdNo," &
                    "@DepositTypeCode," &
                    "@DepositTypeName," &
                    "@DepositTypeNameAra," &
                    "@Notes," &
                    "@Rate," &
                    "@WithBankCharges" &
                    ")"
            Return Db.Insert(sql, Take(depositType))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DepositType) =
                                    Function(reader) _
            New DepositType() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .BankChargesAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("BankChargesAccountIdNo")),
            .BankChargesVatAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("BankChargesVatAccountIdNo")),
            .DepositTypeCode = Extensions.AsString(reader("DepositTypeCode")),
            .DepositTypeName = Extensions.AsString(reader("DepositTypeName")),
            .DepositTypeNameAra = Extensions.AsString(reader("DepositTypeNameAra")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .Rate = Extensions.AsDecimal(reader("Rate")),
            .WithBankCharges = Extensions.AsBool(reader("WithBankCharges"))
            }

        Private Function Take(depositType As DepositType) As Object()
            Return New Object() {
                                    "@AccountIdNo", depositType.AccountIdNo,
                                    "@BankChargesAccountIdNo", depositType.BankChargesAccountIdNo,
                                    "@BankChargesVatAccountIdNo", depositType.BankChargesVatAccountIdNo,
                                    "@DepositTypeCode", depositType.DepositTypeCode,
                                    "@DepositTypeName", depositType.DepositTypeName,
                                    "@DepositTypeNameAra", depositType.DepositTypeNameAra,
                                    "@IdNo", depositType.IdNo,
                                    "@Notes", depositType.Notes,
                                    "@Rate", depositType.Rate,
                                    "@WithBankCharges", depositType.WithBankCharges
                                }
        End Function

    End Class

End Namespace