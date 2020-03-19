Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for SalesJournal
    ' ** DAO Pattern

    Public Class SalesJournalDao
        Implements IDao(Of SalesJournal), IDaoJournals(Of SalesJournal)

        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo As Integer) As SalesJournal _
            Implements IDao(Of SalesJournal).GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Cancelled," &
                    "DateCreated," &
                    "IdNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    " FROM [SalesJournal]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef salesJournal As SalesJournal) As Integer _
            Implements IDao(Of SalesJournal).UpdateRecord
            Dim sql As String =
                    "UPDATE [SalesJournal] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "Cancelled = @Cancelled," &
                    "Notes = @Notes," &
                    "Posted = @Posted," &
                    "ReferenceNo = @ReferenceNo," &
                    "TransactionDate = @TransactionDate" &
                    " WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(salesJournal))
        End Function

        Public Function AddRecord(ByRef salesJournal As SalesJournal) As Integer _
            Implements IDao(Of SalesJournal).AddRecord
            Dim sql As String =
                    " INSERT INTO [SalesJournal] " &
                    "(" &
                    "AccountIdNo," &
                    "Cancelled," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Cancelled," &
                    "@Notes," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@TransactionDate" &
                    ")"
            Return Db.Insert(sql, Take(salesJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, SalesJournal) =
                                    Function(reader) _
            New SalesJournal() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .IdNo = Extensions.AsId(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

        Private Function Take(salesJournal As SalesJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", salesJournal.AccountIdNo,
                                    "@Cancelled", salesJournal.Cancelled,
                                    "@DateCreated", salesJournal.DateCreated,
                                    "@IdNo", salesJournal.IdNo,
                                    "@Notes", salesJournal.Notes,
                                    "@Posted", salesJournal.Posted,
                                    "@ReferenceNo", salesJournal.ReferenceNo,
                                    "@TransactionDate", salesJournal.TransactionDate
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As SalesJournal) As Integer Implements IDaoJournals(Of SalesJournal).UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql As String
            Dim transactionDate = bizObj.TransactionDate
            Dim referenceNo As String
            referenceNo = "S" + Right("00" + Month(transactionDate).ToString, 2) & "-" & Right("00" + DateAndTime.Day(transactionDate).ToString, 2)
            sql = "Update [SalesJournal] set ReferenceNo = '" & referenceNo & "' where IdNo = " & bizObj.IdNo
            retVal = Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql, "")
            Return retVal
        End Function

    End Class

End Namespace