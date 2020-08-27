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