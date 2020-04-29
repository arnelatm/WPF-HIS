Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ApOpenInvoice
    ' ** DAO Pattern

    Public Class ApOpenInvoiceDao
        Implements IDaoOpenInvoice(Of ApOpenInvoice)

        Private ReadOnly Db As New Db()

        Public Function AddRecord(ByRef apOpenInvoice As ApOpenInvoice) As Integer _
            Implements IDaoOpenInvoice(Of ApOpenInvoice).AddRecord
            Dim sql As String =
                    "INSERT INTO [ApOpenInvoice] (" &
                    "DiscountTaken," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "PaidAmount" &
                    ") VALUES (" &
                    "@DiscountTaken," &
                    "@JournalCode," &
                    "@JournalIdNo," &
                    "@JournalItemIdNo," &
                    "@PaidAmount" &
                    ")"
            Return Db.Insert(sql, Take(apOpenInvoice))
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IDaoOpenInvoice(Of ApOpenInvoice).AddInvoicePayment
            Dim params() As Object = {"@IdNo", idNo, "@Amount", amount, "@DiscountTaken", discountTaken}
            Dim sql As String = "UPDATE [ApOpenInvoice] Set PaidAmount = (PaidAmount + @Amount), DiscountTaken = (DiscountTaken + @DiscountTaken) WHERE IdNo = @IdNo"
            Return Db.Update(sql, params)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IDaoOpenInvoice(Of ApOpenInvoice).RemoveInvoicePayment
            Dim params() As Object = {"@IdNo", idNo, "@Amount", amount, "@DiscountTaken", discountTaken}
            Dim sql As String = "UPDATE [ApOpenInvoice] Set PaidAmount = (PaidAmount - @Amount), DiscountTaken = (DiscountTaken - @DiscountTaken) WHERE IdNo = @IdNo"
            Return Db.Update(sql, params)
        End Function

        Private Function Take(apOpenInvoice As ApOpenInvoice) As Object()
            Return New Object() {
                                    "@DiscountTaken", apOpenInvoice.DiscountTaken,
                                    "@IdNo", apOpenInvoice.IdNo,
                                    "@JournalCode", apOpenInvoice.JournalCode,
                                    "@JournalIdNo", apOpenInvoice.JournalIdNo,
                                    "@JournalItemIdNo", apOpenInvoice.JournalItemIdNo,
                                    "@PaidAmount", apOpenInvoice.PaidAmount
                                }
        End Function

    End Class

End Namespace