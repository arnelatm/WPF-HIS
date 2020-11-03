Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PaymentType
    ' ** DAO Pattern

    Public Class PaymentTypeDao
        Inherits CommonDao
        Implements IDaoAll(Of PaymentType)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As PaymentType Implements IDaoAll(Of PaymentType).GetRecordById
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo," &
                    "PaymentTypeCode," &
                    "PaymentTypeName," &
                    "PaymentTypeNameAra," &
                    "IdNo," &
                    "Rate," &
                    " FROM [PaymentType]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim x = Db.Read(sql, Make, params).FirstOrDefault()
            Return x
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of PaymentType) _
            Implements IDaoAll(Of PaymentType).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "PaymentTypeName ASC"
            End If
            Dim sql As String = " SELECT " &
                    "AccountIdNo," &
                    "BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo," &
                    "PaymentTypeCode," &
                    "PaymentTypeName," &
                    "PaymentTypeNameAra," &
                    "IdNo, " &
                    "Rate" &
                    " FROM [PaymentType] order by PaymentTypeName"
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef PaymentType As PaymentType) As Integer Implements IDaoAll(Of PaymentType).UpdateRecord
            Dim sql As String =
                    "UPDATE [PaymentType] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "BankChargesAccountIdNo = @BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo = @BankChargesVatAccountIdNo," &
                    "PaymentTypeCode = @PaymentTypeCode," &
                    "PaymentTypeName = @PaymentTypeName," &
                    "PaymentTypeNameAra = @PaymentTypeNameAra," &
                    "IdNo = @IdNo, " &
                    "Rate = @Rate" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(PaymentType))
        End Function

        Public Function AddRecord(ByRef PaymentType As PaymentType) As Integer Implements IDaoAll(Of PaymentType).AddRecord
            Dim sql As String =
                    "INSERT INTO [PaymentType] (" &
                    "AccountIdNo," &
                    "BankChargesAccountIdNo," &
                    "BankChargesVatAccountIdNo," &
                    "PaymentTypeCode," &
                    "PaymentTypeName," &
                    "PaymentTypeNameAra," &
                    "IdNo, " &
                    "Rate" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@BankChargesAccountIdNo," &
                    "@BankChargesVatAccountIdNo," &
                    "@PaymentType," &
                    "@PaymentTypeName," &
                    "@PaymentTypeNameAra," &
                    "@IdNo, " &
                    "@Rate" &
                    ")"
            Return Db.Insert(sql, Take(PaymentType))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PaymentType) =
                                    Function(reader) _
            New PaymentType() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .BankChargesAccountIdNo = Extensions.AsInt(Of Int16)(reader("BankChargesAccountIdNo")),
            .BankChargesVatAccountIdNo = Extensions.AsInt(Of Int16)(reader("BankChargesVatAccountIdNo")),
            .PaymentTypeCode = Extensions.AsString(reader("PaymentTypeCode")),
            .PaymentTypeName = Extensions.AsString(reader("PaymentTypeName")),
            .PaymentTypeNameAra = Extensions.AsString(reader("PaymentTypeNameAra")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .Rate = Extensions.AsDecimal(reader("Rate"))
            }

        Private Function Take(PaymentType As PaymentType) As Object()
            Return New Object() {
                                    "@AccountIdNo", PaymentType.AccountIdNo,
                                    "@BankChargesAccountIdNo" = PaymentType.BankChargesAccountIdNo,
                                    "@BankChargesVatAccountIdNo" = PaymentType.BankChargesVatAccountIdNo,
                                    "@PaymentTypeCode", PaymentType.PaymentTypeCode,
                                    "@PaymentTypeName", PaymentType.PaymentTypeName,
                                    "@PaymentTypeNameAra", PaymentType.PaymentTypeNameAra,
                                    "@IdNo", PaymentType.IdNo,
                                    "@Rate", PaymentType.Rate
                                }
        End Function

    End Class

End Namespace