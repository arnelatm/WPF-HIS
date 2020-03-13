Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer

Namespace DataLayer.AdoNet
    ' Data access object for ArJournal
    ' ** DAO Pattern

    Public Class ArJournalDao
        Implements IDao(Of ArJournal), IDaoJournals(Of ArJournal)

        Private Shared ReadOnly Db As New Db()

        Public Function GetRecordById(idNo As Integer) As ArJournal _
        Implements IDao(Of ArJournal).GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Cancelled," &
                    "CustomerIdNo," &
                    "DateCreated," &
                    "DueDate," &
                    "IdNo," &
                    "InvoiceNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "SettlementDiscount," &
                    "SettlementDueDate," &
                    "TransactionDate," &
                    "TransactionType" &
                    " FROM [ArJournal]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef arJournal As ArJournal) As Integer _
            Implements IDao(Of ArJournal).UpdateRecord
            Dim sql As String =
                    "UPDATE [ArJournal] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "Amount = @Amount," &
                    "Cancelled = @Cancelled," &
                    "CustomerIdNo = @CustomerIdNo," &
                    "DueDate = @DueDate," &
                    "InvoiceNo = @InvoiceNo," &
                    "Notes = @Notes," &
                    "Posted = @Posted," &
                    "ReferenceNo = @ReferenceNo," &
                    "SettlementDiscount = @SettlementDiscount," &
                    "SettlementDueDate = @SettlementDueDate," &
                    "TransactionDate = @TransactionDate," &
                    "TransactionType = @TransactionType" &
                    " WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(arJournal))
        End Function

        Public Function AddRecord(ByRef arJournal As ArJournal) As Integer _
            Implements IDao(Of ArJournal).AddRecord
            Dim sql As String = "INSERT INTO [ArJournal] (" &
                    "AccountIdNo," &
                    "Amount," &
                    "Cancelled," &
                    "CustomerIdNo," &
                    "DueDate," &
                    "InvoiceNo," &
                    "Notes," &
                    "Posted," &
                    "ReferenceNo," &
                    "SettlementDiscount," &
                    "SettlementDueDate," &
                    "TransactionDate," &
                    "TransactionType" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Amount," &
                    "@Cancelled," &
                    "@CustomerIdNo," &
                    "@DueDate," &
                    "@InvoiceNo," &
                    "@Notes," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@SettlementDiscount," &
                    "@SettlementDueDate," &
                    "@TransactionDate," &
                    "@TransactionType" &
                    ")"
            Return Db.Insert(sql, Take(arJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ArJournal) =
                                    Function(reader) _
            New ArJournal() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .CustomerIdNo = Extensions.AsInt(Of Integer)(reader("CustomerIdNo")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .DueDate = Extensions.AsDate(reader("DueDate")),
            .IdNo = Extensions.AsId(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .SettlementDiscount = Extensions.AsDecimal(reader("SettlementDiscount")),
            .SettlementDueDate = Extensions.AsDate(reader("SettlementDueDate")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .TransactionType = Extensions.AsString(reader("TransactionType"))
            }

        Private Function Take(arJournal As ArJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", arJournal.AccountIdNo,
                                    "@Amount", arJournal.Amount,
                                    "@Cancelled", arJournal.Cancelled,
                                    "@CustomerIdNo", arJournal.CustomerIdNo,
                                    "@DateCreated", arJournal.DateCreated,
                                    "@DueDate", arJournal.DueDate,
                                    "@IdNo", arJournal.IdNo,
                                    "@InvoiceNo", arJournal.InvoiceNo,
                                    "@Notes", arJournal.Notes,
                                    "@Posted", arJournal.Posted,
                                    "@ReferenceNo", arJournal.ReferenceNo,
                                    "@SettlementDiscount", arJournal.SettlementDiscount,
                                    "@SettlementDueDate", arJournal.SettlementDueDate,
                                    "@TransactionDate", arJournal.TransactionDate,
                                    "@TransactionType", arJournal.TransactionType
                                 }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef model As ArJournal) As Integer Implements IDaoJournals(Of ArJournal).UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql1 As String
            Dim sql2 As String
            Dim transactionDate = model.TransactionDate
            Dim series = "GL" + Year(transactionDate).ToString() + Right("00" + Month(transactionDate).ToString, 2)
            Dim maxlength As Int16
            Dim prefix As String
            If Db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                maxlength = 4
                prefix = Right("00" + Month(transactionDate).ToString, 2) & "-"
                Dim sql As String = "INSERT INTO [Series] " &
                    " (SeriesName,Value,MaxLength,Prefix,Description)" &
                    " VALUES (@SeriesName,@Value,@MaxLength,@Prefix,@Description)"
                Dim params() As Object = {"@SeriesName", series,
                                          "@Value", 0,
                                          "@MaxLength", 4,
                                          "@Prefix", prefix,
                                          "@Description", "GL Series for " & Year(transactionDate).ToString() & Right("00" + Month(transactionDate).ToString, 2)
                                         }
                If Db.Insert(sql, params) Then
                    Return -1
                End If
            Else
                prefix = Db.Scalar("select prefix from series where seriesName = '" & series & "'")
                maxlength = Db.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
            End If
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update [ArJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & model.IdNo
            retVal = Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

    End Class

End Namespace