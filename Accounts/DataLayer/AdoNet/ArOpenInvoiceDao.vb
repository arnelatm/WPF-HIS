Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ArOpenInvoice
    ' ** DAO Pattern

    Public Class ArOpenInvoiceDao
        Implements IDaoOpenInvoice(Of ArOpenInvoice)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo As Integer) As ArOpenInvoice Implements IDaoOpenInvoice(Of ArOpenInvoice).GetRecordByIdNo
            Dim sql As String = "SELECT " &
                        "DiscountTaken," &
                        "IdNo," &
                        "JournalCode," &
                        "JournalIdNo," &
                        "JournalItemIdNo," &
                        "PaidAmount" &
                        " From ArOpenInvoice" &
                        " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ArOpenInvoice) =
                                    Function(reader) _
            New ArOpenInvoice() With {
            .DiscountTaken = Extensions.AsString(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsInt(Of Int32)(reader("JournaldNo")),
            .JournalItemIdNo = Extensions.AsInt(Of Int32)(reader("JournalItemIdNo")),
            .PaidAmount = Extensions.AsDecimal(reader("PaidAmount"))
            }

        Public Function AddRecord(ByRef arOpenInvoice As ArOpenInvoice) As Integer Implements IDaoOpenInvoice(Of ArOpenInvoice).AddRecord
            Dim sql As String =
                    "INSERT INTO [ArOpenInvoice] (" &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo" &
                    ") VALUES (" &
                    "@JournalCode," &
                    "@JournalIdNo," &
                    "@JournalItemIdNo" &
                    ")"
            Return Db.Insert(sql, Take(arOpenInvoice))
        End Function

        Private Function Take(arOpenInvoice As ArOpenInvoice) As Object()
            Return New Object() {"@IdNo", arOpenInvoice.IdNo,
                                 "@JournalCode", arOpenInvoice.JournalCode,
                                 "@JournalIdNo", arOpenInvoice.JournalIdNo,
                                 "@JournalItemIdNo", arOpenInvoice.JournalItemIdNo
                                 }
        End Function

    End Class

End Namespace