Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ArOpenInvoice
    ' ** DAO Pattern

    Public Class ArOpenInvoiceDao
        Implements IDaoOpenInvoice(Of ArOpenInvoice)

        Private ReadOnly Db As New Db()

        Public Function AddRecord(ByRef arOpenInvoice As ArOpenInvoice) As Integer _
            Implements IDaoOpenInvoice(Of ArOpenInvoice).AddRecord
            Dim sql As String =
                    "INSERT INTO [ArOpenInvoice] (" &
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
            Return Db.Insert(sql, Take(arOpenInvoice))
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
        Implements IDaoOpenInvoice(Of ArOpenInvoice).AddInvoicePayment
            Dim params() As Object = {"@IdNo", idNo, "@Amount", amount, "@DiscountTaken", discountTaken}
            Dim sql As String = "UPDATE [ArOpenInvoice] Set PaidAmount = (PaidAmount + @Amount), DiscountTaken = (DiscountTaken + @DiscountTaken) WHERE IdNo = @IdNo"
            Return Db.Update(sql, params)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
        Implements IDaoOpenInvoice(Of ArOpenInvoice).RemoveInvoicePayment
            Dim params() As Object = {"@IdNo", idNo, "@Amount", amount, "@DiscountTaken", discountTaken}
            Dim sql As String = "UPDATE [ArOpenInvoice] Set PaidAmount = (PaidAmount - @Amount), DiscountTaken = (DiscountTaken - @DiscountTaken) WHERE IdNo = @IdNo"
            Return Db.Update(sql, params)
        End Function

        Private Function Take(arOpenInvoice As ArOpenInvoice) As Object()
            Return New Object() {
                                    "@DiscountTaken", arOpenInvoice.DiscountTaken,
                                    "@IdNo", arOpenInvoice.IdNo,
                                    "@JournalCode", arOpenInvoice.JournalCode,
                                    "@JournalIdNo", arOpenInvoice.JournalIdNo,
                                    "@JournalItemIdNo", arOpenInvoice.JournalItemIdNo,
                                    "@PaidAmount", arOpenInvoice.PaidAmount
                                }
        End Function

    End Class

End Namespace