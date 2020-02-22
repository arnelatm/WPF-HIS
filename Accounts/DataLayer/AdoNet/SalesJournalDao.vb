Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for SalesJournal
    ' ** DAO Pattern

    Public Class SalesJournalDao
        Implements ISalesJournalDao

        Private Shared Db As New Db()

        Public Function GetRecordById(idNo As Integer) As SalesJournal _
            Implements ISalesJournalDao.GetRecordById
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

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of SalesJournal) _
            Implements ISalesJournalDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, TransactionDate " &
                    "   FROM [SalesJournal] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef salesJournal As SalesJournal) As Integer _
            Implements ISalesJournalDao.UpdateRecord
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
            Implements ISalesJournalDao.AddRecord
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

        Public Function UpdateGlReferenceNumber(ByRef model) As Integer Implements ISalesJournalDao.UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql As String
            Dim transactionDate = model.TransactionDate
            Dim referenceNo As String
            referenceNo = "S" + Right("00" + Month(transactionDate).ToString, 2) & "-" & Right("00" + DateAndTime.Day(transactionDate).ToString, 2)
            sql = "Update [SalesJournal] set ReferenceNo = '" & referenceNo & "' where IdNo = " & model.IdNo
            retVal = Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql, "")
            Return retVal
        End Function

    End Class

End Namespace