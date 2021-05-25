Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ApOpenInvoice
    ' ** DAO Pattern

    Public Class ApOpenInvoiceDao
        Implements IDaoOpenInvoice(Of ApOpenInvoice)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo As Integer) As ApOpenInvoice Implements IDaoOpenInvoice(Of ApOpenInvoice).GetRecordByIdNo
            Dim sql As String = "SELECT " &
                        "DiscountTaken," &
                        "IdNo," &
                        "JournalCode," &
                        "JournalIdNo," &
                        "JournalItemIdNo," &
                        "PaidAmount" &
                        " From ApOpenInvoice " &
                        " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ApOpenInvoice) =
                                    Function(reader) _
            New ApOpenInvoice() With {
            .DiscountTaken = Extensions.AsString(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsInt(Of Int32)(reader("JournalIdNo")),
            .JournalItemIdNo = Extensions.AsInt(Of Int32)(reader("JournalItemIdNo")),
            .PaidAmount = Extensions.AsDecimal(reader("PaidAmount"))
            }


        Public Function AddRecord(ByRef apOpenInvoice As ApOpenInvoice) As Integer _
            Implements IDaoOpenInvoice(Of ApOpenInvoice).AddRecord
            Dim sql As String =
                    "INSERT INTO [ApOpenInvoice] (" &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo" &
                    ") VALUES (" &
                    "@JournalCode," &
                    "@JournalIdNo," &
                    "@JournalItemIdNo" &
                    ")"
            Return Db.Insert(sql, Take(apOpenInvoice))
        End Function

        Private Function Take(apOpenInvoice As ApOpenInvoice) As Object()
            Return New Object() {
                                    "@IdNo", apOpenInvoice.IdNo,
                                    "@JournalCode", apOpenInvoice.JournalCode,
                                    "@JournalIdNo", apOpenInvoice.JournalIdNo,
                                    "@JournalItemIdNo", apOpenInvoice.JournalItemIdNo
                                }
        End Function


    End Class

End Namespace