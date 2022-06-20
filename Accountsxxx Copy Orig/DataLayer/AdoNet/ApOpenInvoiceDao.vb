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