Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for ArOpenInvoice
    ' ** DAO Pattern

    Public Class ArOpenInvoiceDao
        Implements IArOpenInvoiceDao

        Private Shared ReadOnly Make As Func(Of IDataReader, ArOpenInvoice) =
                                    Function(reader) _
            New ArOpenInvoice() With {
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(reader("IdNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsString(reader("JournalIdNo")),
            .JournalItemIdNo = Extensions.AsId(reader("JournalItemIdNo")),
            .PaidAmount = Extensions.AsDecimal(reader("PaidAmount"))
            }

        Private Shared Db As New Db()

        Public Function AddRecord(ByRef arOpenInvoice As ArOpenInvoice) As Integer _
            Implements IArOpenInvoiceDao.AddRecord
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

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of ArOpenInvoice) _
            Implements IArOpenInvoiceDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, PaidAmount " &
                    "   FROM [ArOpenInvoice] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecordById(idNo As Integer) As ArOpenInvoice _
                        Implements IArOpenInvoiceDao.GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "DiscountTaken" &
                    "IdNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "PaidAmount" &
                    "   FROM [ArOpenInvoice]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetRecordByJournalItemIdNo(ByVal journalItemIdNo As Integer, ByVal journalCode As String) As ArOpenInvoice _
            Implements IArOpenInvoiceDao.GetRecordByJournalItemIdNo
            Dim sql As String =
                    " SELECT " &
                    "DiscountTaken" &
                    "IdNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "PaidAmount" &
                    "   FROM [ArOpenInvoice]" &
                    " WHERE JournalItemIDNo = @journalItemIdNo and JournalCode = @journalCode"
            Dim params() As Object = {"@JournalItemIdNo", journalItemIdNo, "@JournalCode", journalCode}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef arOpenInvoice As ArOpenInvoice) As Integer _
            Implements IArOpenInvoiceDao.UpdateRecord
            Dim sql As String = "UPDATE [ArOpenInvoice] Set Balance = @Balance WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(arOpenInvoice))
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IArOpenInvoiceDao.AddInvoicePayment
            Dim params() As Object = {"@IdNo", idNo, "@Amount", amount, "@DiscountTaken", discountTaken}
            Dim sql As String = "UPDATE [ArOpenInvoice] Set PaidAmount = (PaidAmount + @Amount), DiscountTaken = (DiscountTaken + @DiscountTaken) WHERE IdNo = @IdNo"
            Return Db.Update(sql, params)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IArOpenInvoiceDao.RemoveInvoicePayment
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