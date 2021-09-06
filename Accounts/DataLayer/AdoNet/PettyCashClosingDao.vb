Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for PettyCashClosing
    ' ** DAO Pattern

    Public Class PettyCashClosingDao
        Implements IDao(Of PettyCashClosing), IDaoJournals(Of PettyCashClosing)

        Public ReadOnly Property Args As Object()
        Private ReadOnly _db As New Db()
        Protected TableOrViewName As String
        Protected JournalCode As String
        Protected PcClosing As Object

        Public Function GetRecordByIdNo(idNo) As PettyCashClosing Implements IDao(Of PettyCashClosing).GetRecordByIdNo
            Dim sql As String
            Dim data
            Dim params() As Object = {"@IdNo", idNo}
            sql = "SELECT " &
                "AccountIdNo," &
                "Amount," &
                "Applied," &
                "Cancelled," &
                "CheckDate," &
                "CheckNumber," &
                "DateCreated," &
                "PayType," &
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
                " FROM PcJournal " &
                " WHERE IdNo = @IdNo"
            data = _db.Read(sql, CdMake, params).FirstOrDefault()
            If data Is Nothing Then
                Debugger.Break()
            Else
                Dim pcDao = New PcClosingJournalDao()
                data.PcClosingJournals = pcDao.GetRecordsWithGroupIdNo(0)
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef pettyCashClosing As PettyCashClosing) As Integer Implements IDao(Of PettyCashClosing).UpdateRecord
            Dim sql As String
            sql = " UPDATE CdJournal SET " &
                    "AccountIdNo   = @AccountIdNo," &
                    "Amount        = @Amount," &
                    "Applied       = @Applied," &
                    "Cancelled     = @Cancelled," &
                    "CheckDate     = @CheckDate," &
                    "CheckNumber   = @CheckNumber," &
                    "PayType       = @PayType," &
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
            Return _db.Update(sql, CdTake(pettyCashClosing))
        End Function

        Public Function AddRecord(ByRef pettyCashClosing As PettyCashClosing) As Integer Implements IDao(Of PettyCashClosing).AddRecord
            Dim sql As String
            sql = " INSERT INTO CdJournal (" &
                        "AccountIdNo," &
                        "Amount," &
                        "Applied," &
                        "Cancelled," &
                        "CheckDate," &
                        "CheckNumber," &
                        "PayType," &
                        "PcClosed," &
                        "Notes," &
                        "ORNumber," &
                        "PayeeIdNo," &
                        "PayeeName," &
                        "PaymentType," &
                        "Posted," &
                        "ReferenceNo," &
                        "TransactionDate" &
                        ") VALUES (" &
                        "@AccountIdNo," &
                        "@Amount," &
                        "@Applied," &
                        "@Cancelled," &
                        "@CheckDate," &
                        "@CheckNumber," &
                        "@PayType," &
                        "@PcClosed," &
                        "@Notes," &
                        "@ORNumber," &
                        "@PayeeIdNo," &
                        "@PayeeName," &
                        "@PaymentType," &
                        "@Posted," &
                        "@ReferenceNo," &
                        "@TransactionDate" &
                        ")"
            Return _db.Insert(sql, CdTake(pettyCashClosing))
        End Function

        Private ReadOnly CdMake As Func(Of IDataReader, PettyCashClosing) =
                            Function(reader) _
            New PettyCashClosing() With {
            .AccountIdNo = Extensions.AsNullable(Of Int16?)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .CheckDate = Extensions.AsNullable(Of Date?)(reader("CheckDate")),
            .CheckNumber = Extensions.AsString(reader("CheckNumber")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .PayType = Extensions.AsString(reader("PayType")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OrNumber = Extensions.AsString(reader("ORNumber")),
            .PayeeIdNo = Extensions.AsNullable(Of Int32?)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

        Private Function CdTake(pettyCashClosing As PettyCashClosing) As Object()
            Return New Object() {
                                    "@AccountIdNo", pettyCashClosing.AccountIdNo,
                                    "@Amount", pettyCashClosing.Amount,
                                    "@Applied", pettyCashClosing.Applied,
                                    "@Cancelled", pettyCashClosing.Cancelled,
                                    "@CheckDate", pettyCashClosing.CheckDate,
                                    "@CheckNumber", pettyCashClosing.CheckNumber,
                                    "@DateCreated", pettyCashClosing.DateCreated,
                                    "@PayType", pettyCashClosing.PayType,
                                    "@PcClosed", pettyCashClosing.PcClosed,
                                    "@IdNo", pettyCashClosing.IdNo,
                                    "@Notes", pettyCashClosing.Notes,
                                    "@ORNumber", pettyCashClosing.OrNumber,
                                    "@PayeeIdNo", pettyCashClosing.PayeeIdNo,
                                    "@PayeeName", pettyCashClosing.PayeeName,
                                    "@PaymentType", pettyCashClosing.PaymentType,
                                    "@Posted", pettyCashClosing.Posted,
                                    "@ReferenceNo", pettyCashClosing.ReferenceNo,
                                    "@TransactionDate", pettyCashClosing.TransactionDate
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As PettyCashClosing) As Integer Implements IDaoJournals(Of PettyCashClosing).UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql1 As String
            Dim sql2 As String
            Dim seriesName As String
            seriesName = "CKJournal"
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & seriesName & "'"
            sql2 = "Update [CdJournal] set ReferenceNo = (select value from series where seriesName = '" & seriesName & "') where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        Public Function GetOpenPettyCash()
            Dim sql As String =
                    "SELECT " &
                    "Amount," &
                    "CdJournalIdNo," &
                    "PcClosed," &
                    "IdNo," &
                    "Notes," &
                    "PayeeName," &
                    "PayeeNameAra," &
                    "PaymentType," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    " FROM PcJournal_View" &
                    " WHERE IsNull(PcClosed,0) = 0 " &
                    " ORDER BY IdNo"
            Return _db.Read(sql, MakeOpenPc).ToList()
        End Function

        Private Shared ReadOnly MakeOpenPc As Func(Of IDataReader, PcClosingJournal) =
                                    Function(reader) _
            New PcClosingJournal() With {
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .CdJournalIdNo = Extensions.AsInt(Of Int32)(reader("CdJournalIdNo")),
            .PcClosed = Extensions.AsBool(reader("PcClosed")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PayeeNameAra = Extensions.AsString(reader("PayeeNameAra")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

    End Class

End Namespace