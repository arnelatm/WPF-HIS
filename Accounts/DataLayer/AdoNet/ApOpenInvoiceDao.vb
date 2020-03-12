Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports IOpenInvoiceDao = AATM.Accounts.DataLayer.IOpenInvoiceDao

Namespace DataLayer.AdoNet
    ' Data access object for ApOpenInvoice
    ' ** DAO Pattern

    Public Class ApOpenInvoiceDao
        Implements IOpenInvoiceDao

        Private Shared ReadOnly Db As New Db()

        'Private Shared ReadOnly Make As Func(Of IDataReader, ApOpenInvoice) =
        '                            Function(reader) _
        '    New ApOpenInvoice() With {
        '    .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
        '    .IdNo = Extensions.AsId(reader("IdNo")),
        '    .JournalCode = Extensions.AsString(reader("JournalCode")),
        '    .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
        '    .JournalItemIdNo = Extensions.AsId(reader("JournalItemIdNo")),
        '    .PaidAmount = Extensions.AsDecimal(reader("PaidAmount"))
        '    }

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IOpenInvoiceDao.AddInvoicePayment
            Dim params() As Object = {"@IdNo", idNo, "@Amount", amount, "@DiscountTaken", discountTaken}
            Dim sql As String = "UPDATE [ApOpenInvoice] Set PaidAmount = (PaidAmount + @Amount), DiscountTaken = (DiscountTaken + @DiscountTaken) WHERE IdNo = @IdNo"
            Return Db.Update(sql, params)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IOpenInvoiceDao.RemoveInvoicePayment
            Dim params() As Object = {"@IdNo", idNo, "@Amount", amount, "@DiscountTaken", discountTaken}
            Dim sql As String = "UPDATE [ApOpenInvoice] Set PaidAmount = (PaidAmount - @Amount), DiscountTaken = (DiscountTaken - @DiscountTaken) WHERE IdNo = @IdNo"
            Return Db.Update(sql, params)
        End Function

        'Private Function Take(apOpenInvoice As ApOpenInvoice) As Object()
        '    Return New Object() {
        '                            "@DiscountTaken", apOpenInvoice.DiscountTaken,
        '                            "@IdNo", apOpenInvoice.IdNo,
        '                            "@JournalCode", apOpenInvoice.JournalCode,
        '                            "@JournalIdNo", apOpenInvoice.JournalIdNo,
        '                            "@JournalItemIdNo", apOpenInvoice.JournalItemIdNo,
        '                            "@PaidAmount", apOpenInvoice.PaidAmount
        '                         }
        'End Function

    End Class

End Namespace