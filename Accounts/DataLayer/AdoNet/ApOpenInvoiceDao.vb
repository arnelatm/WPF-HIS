Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for ApOpenInvoice
    ' ** DAO Pattern

    Public Class ApOpenInvoiceDao
        Implements IApOpenInvoiceDao

        Private Shared ReadOnly Make As Func(Of IDataReader, ApOpenInvoice) =
                                    Function(reader) _
            New ApOpenInvoice() With {
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(reader("IdNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .JournalItemIdNo = Extensions.AsId(reader("JournalItemIdNo")),
            .PaidAmount = Extensions.AsDecimal(reader("PaidAmount"))
            }

        Private Shared ReadOnly Db As New Db()

        Public Function AddRecord(ByRef apOpenInvoice As ApOpenInvoice) As Integer _
            Implements IApOpenInvoiceDao.AddRecord
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

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of ApOpenInvoice) _
            Implements IApOpenInvoiceDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, PaidAmount " &
                    "   FROM [ApOpenInvoice] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecordById(idNo As Integer) As ApOpenInvoice _
                        Implements IApOpenInvoiceDao.GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "DiscountTaken" &
                    "IdNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "PaidAmount" &
                    "   FROM [ApOpenInvoice]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetRecordByJournalItemIdNo(ByVal journalItemIdNo As Integer, ByVal journalCode As String) As ApOpenInvoice _
            Implements IApOpenInvoiceDao.GetRecordByJournalItemIdNo
            Dim sql As String =
                    " SELECT " &
                    "DiscountTaken" &
                    "IdNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "PaidAmount" &
                    "   FROM [ApOpenInvoice]" &
                    " WHERE JournalItemIDNo = @journalItemIdNo and JournalCode = @journalCode"
            Dim params() As Object = {"@JournalItemIdNo", journalItemIdNo, "@JournalCode", journalCode}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef apOpenInvoice As ApOpenInvoice) As Integer _
            Implements IApOpenInvoiceDao.UpdateRecord
            Dim sql As String = "UPDATE [ApOpenInvoice] Set Balance = @Balance WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(apOpenInvoice))
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IApOpenInvoiceDao.AddInvoicePayment
            Dim params() As Object = {"@IdNo", idNo, "@Amount", amount, "@DiscountTaken", discountTaken}
            Dim sql As String = "UPDATE [ApOpenInvoice] Set PaidAmount = (PaidAmount + @Amount), DiscountTaken = (DiscountTaken + @DiscountTaken) WHERE IdNo = @IdNo"
            Return Db.Update(sql, params)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer _
            Implements IApOpenInvoiceDao.RemoveInvoicePayment
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