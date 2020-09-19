' Data access object for PettyCashJournal
' ** DAO Pattern
Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PettyCashJournal
    ' ** DAO Pattern

    Public Class PettyCashJournalDao
        Inherits DaoAccounts
        Implements IDao(Of PettyCashJournal), IDaoJournals(Of PettyCashJournal), IDaoOiItem(Of PcsOiItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As PettyCashJournal _
            Implements IDao(Of PettyCashJournal).GetRecordById
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Applied," &
                    "Cancelled," &
                    "DateCreated," &
                    "DiscountAccountIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "Notes," &
                    "ORNumber," &
                    "PayeeIdNo," &
                    "PayeeName," &
                    "PaymentType," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate," &
                    "UnApplied," &
                    "VatAmount," &
                    "VatNumber" &
                    " FROM [PettyCashJournal]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim jiDao = New PettyCashJournalItemDao
            Dim oiDao = New PcsOiItemDao
            Dim ji = jiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            Dim oi = oiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            data.JournalItems = ji
            data.PcsOiItems = oi
            Return data
        End Function

        Public Function UpdateRecord(ByRef pettyCashJournal As PettyCashJournal) As Integer _
            Implements IDao(Of PettyCashJournal).UpdateRecord
            Dim sql As String =
                    " UPDATE [PettyCashJournal] Set " &
                    "AccountIdNo   = @AccountIdNo," &
                    "Amount        = @Amount," &
                    "Applied       = @Applied," &
                    "Cancelled     = @Cancelled," &
                    "DiscountAccountIdNo = @DiscountAccountIdNo," &
                    "DiscountTaken = @DiscountTaken," &
                    "Notes         = @Notes," &
                    "ORNumber      = @ORNumber," &
                    "PayeeIdNo     = @PayeeIdNo," &
                    "PayeeName     = @PayeeName," &
                    "PaymentType   = @PaymentType," &
                    "Posted        = @Posted," &
                    "ReferenceNo   = @ReferenceNo," &
                    "TransactionDate = @TransactionDate," &
                    "UnApplied     = @UnApplied," &
                    "VatAmount     = @VatAmount," &
                    "VatNumber     = @VatNumber" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(pettyCashJournal))
        End Function

        Public Function AddRecord(ByRef pettyCashJournal As PettyCashJournal) As Integer _
            Implements IDao(Of PettyCashJournal).AddRecord
            Dim sql As String = "INSERT INTO [PettyCashJournal] (" &
                    "AccountIdNo," &
                    "Amount," &
                    "Applied," &
                    "Cancelled," &
                    "DiscountAccountIdNo," &
                    "DiscountTaken," &
                    "Notes," &
                    "ORNumber," &
                    "PayeeIdNo," &
                    "PayeeName," &
                    "PaymentType," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate," &
                    "UnApplied," &
                    "VatAmount," &
                    "VatNumber" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Amount," &
                    "@Applied," &
                    "@Cancelled," &
                    "@DiscountAccountIdNo," &
                    "@DiscountTaken," &
                    "@Notes," &
                    "@ORNumber," &
                    "@PayeeIdNo," &
                    "@PayeeName," &
                    "@PaymentType," &
                    "@Posted," &
                    "@ReferenceNo," &
                    "@TransactionDate," &
                    "@UnApplied," &
                    "@VatAmount," &
                    "@VatNumber" &
                    ")"
            Return _db.Insert(sql, Take(pettyCashJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PettyCashJournal) =
                                    Function(reader) _
            New PettyCashJournal() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .DiscountAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("DiscountAccountIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OrNumber = Extensions.AsString(reader("ORNumber")),
            .PayeeIdNo = Extensions.AsNullable(Of Int32)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .UnApplied = Extensions.AsDecimal(reader("UnApplied")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = Extensions.AsString(reader("VatNumber"))
            }

        Private Function Take(pettyCashJournal As PettyCashJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", pettyCashJournal.AccountIdNo,
                                    "@Amount", pettyCashJournal.Amount,
                                    "@Applied", pettyCashJournal.Applied,
                                    "@Cancelled", pettyCashJournal.Cancelled,
                                    "@DateCreated", pettyCashJournal.DateCreated,
                                    "@DiscountAccountIdNo", pettyCashJournal.DiscountAccountIdNo,
                                    "@DiscountTaken", pettyCashJournal.DiscountTaken,
                                    "@IdNo", pettyCashJournal.IdNo,
                                    "@Notes", pettyCashJournal.Notes,
                                    "@ORNumber", pettyCashJournal.OrNumber,
                                    "@PayeeIdNo", pettyCashJournal.PayeeIdNo,
                                    "@PayeeName", pettyCashJournal.PayeeName,
                                    "@PaymentType", pettyCashJournal.PaymentType,
                                    "@Posted", pettyCashJournal.Posted,
                                    "@ReferenceNo", pettyCashJournal.ReferenceNo,
                                    "@TransactionDate", pettyCashJournal.TransactionDate,
                                    "@UnApplied", pettyCashJournal.UnApplied,
                                    "@VatAmount", pettyCashJournal.VatAmount,
                                    "@VatNumber", pettyCashJournal.VatNumber
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As PettyCashJournal) As Integer Implements IDaoJournals(Of PettyCashJournal).UpdateGlReferenceNumber
            Dim sql1 As String
            Dim sql2 As String
            Dim series = $"PCJOURNAL"
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update [PettyCashJournal] set ReferenceNo = (select value from series where seriesName = '" & series & "') where IdNo = " & bizObj.IdNo
            Return _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of PcsOiItem) Implements IDaoOiItem(Of PcsOiItem).GetOpenInvoices
            Dim oiDao = New PcsOiItemDao
            Return oiDao.GetOpenInvoices(idNo)
        End Function

    End Class

End Namespace