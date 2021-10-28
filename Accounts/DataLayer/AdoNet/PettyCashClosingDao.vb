Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for PettyCashClosing
    ' ** DAO Pattern

    Public Class PettyCashClosingDao
        Implements IDao(Of PettyCashClosing), IDaoJournals(Of PettyCashClosing)

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
                "CheckDate," &
                "CheckNumber," &
                "IdNo," &
                "Notes," &
                "PayeeIdNo," &
                "PayeeName," &
                "PaymentType," &
                "PayType," &
                "PcClosed," &
                "Posted," &
                "ReferenceNo," &
                "TransactionDate" &
                " FROM PcJournal " &
                " WHERE IdNo = @IdNo"
            data = _db.Read(sql, _cdMake, params).FirstOrDefault()
            If data Is Nothing Then
                Debugger.Break()
            Else
                Dim pcDao = New PcClosingJournalDao()
                data.PcClosingJournals = pcDao.GetRecordsWithGroupIdNo(0)
            End If
            
            Return data
        End Function

        'Public Function UpdateRecord(ByRef pettyCashClosing As PettyCashClosing) As Integer Implements IDao(Of PettyCashClosing).UpdateRecord
        '    Dim sql As String
        '    sql = " UPDATE CdJournal SET " &
        '            "AccountIdNo   = @AccountIdNo," &
        '            "Amount        = @Amount," &
        '            "Applied       = @Applied," &
        '            "CheckDate     = @CheckDate," &
        '            "CheckNumber   = @CheckNumber," &
        '            "PayType       = @PayType," &
        '            "PcClosed      = @PcClosed," &
        '            "Notes         = @Notes," &
        '            "PayeeIdNo     = @PayeeIdNo," &
        '            "PayeeName     = @PayeeName," &
        '            "PaymentType   = @PaymentType," &
        '            "Posted        = @Posted," &
        '            "ReferenceNo   = @ReferenceNo," &
        '            "TransactionDate = @TransactionDate" &
        '            " WHERE IdNo = @IdNo"
        '    Return _db.Update(sql, CdTake(pettyCashClosing))
        'End Function

        Public Function AddRecord(ByRef pettyCashClosing As PettyCashClosing) As Integer Implements IDao(Of PettyCashClosing).AddRecord
            Dim sql As String
            sql = " INSERT INTO CdJournal (" &
                        "AccountIdNo," &
                        "Amount," &
                        "Applied," &
                        "CheckDate," &
                        "CheckNumber," &
                        "Notes," &
                        "PayeeIdNo," &
                        "PayeeName," &
                        "PaymentType," &
                        "PayType," &
                        "PcClosed," &
                        "Posted," &
                        "ReferenceNo," &
                        "TransactionDate" &
                        ") VALUES (" &
                        "@AccountIdNo," &
                        "@Amount," &
                        "@Applied," &
                        "@CheckDate," &
                        "@CheckNumber," &
                        "@Notes," &
                        "@PayeeIdNo," &
                        "@PayeeName," &
                        "@PaymentType," &
                        "@PayType," &
                        "@PcClosed," &
                        "@Posted," &
                        "@ReferenceNo," &
                        "@TransactionDate" &
                        ")"
            Return _db.Insert(sql, CdTake(pettyCashClosing))
        End Function

        Private ReadOnly _cdMake As Func(Of IDataReader, PettyCashClosing) =
                            Function(reader) _
            New PettyCashClosing() With {
            .AccountIdNo = Extensions.AsNullable(Of Int16?)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .CheckDate = Extensions.AsNullable(Of Date?)(reader("CheckDate")),
            .CheckNumber = Extensions.AsString(reader("CheckNumber")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .PayeeIdNo = Extensions.AsNullable(Of Int32?)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .PayType = Extensions.AsString(reader("PayType")),
            .PcClosed = Extensions.AsBool(reader("PcClosed")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

        Private Function CdTake(pettyCashClosing As PettyCashClosing) As Object()
            Return New Object() {
                                    "@AccountIdNo", pettyCashClosing.AccountIdNo,
                                    "@Amount", pettyCashClosing.Amount,
                                    "@Applied", pettyCashClosing.Applied,
                                    "@CheckDate", pettyCashClosing.CheckDate,
                                    "@CheckNumber", pettyCashClosing.CheckNumber,
                                    "@IdNo", pettyCashClosing.IdNo,
                                    "@Notes", pettyCashClosing.Notes,
                                    "@PayeeIdNo", pettyCashClosing.PayeeIdNo,
                                    "@PayeeName", pettyCashClosing.PayeeName,
                                    "@PaymentType", pettyCashClosing.PaymentType,
                                    "@PayType", pettyCashClosing.PayType,
                                    "@PcClosed", pettyCashClosing.PcClosed,
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
                    "IdNo," &
                    "Notes," &
                    "PayeeName," &
                    "PayeeNameAra," &
                    "PaymentType," &
                    "PcClosed," &
                    "ReferenceNo," &
                    "TransactionDate" &
                    " FROM PcJournal_View" &
                    " WHERE IsNull(PcClosed,0) = 0 and Cancelled = 0" &
                    " ORDER BY IdNo"
            Return _db.Read(sql, MakeOpenPc).ToList()
        End Function

        Public Function UpdateRecord(ByRef recordData As PettyCashClosing) As Integer Implements IDao(Of PettyCashClosing).UpdateRecord
            Throw New NotImplementedException()
        End Function

        Private Shared ReadOnly MakeOpenPc As Func(Of IDataReader, PcClosingJournal) =
                                    Function(reader) _
            New PcClosingJournal() With {
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .CdJournalIdNo = Extensions.AsInt(Of Int32)(reader("CdJournalIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PayeeNameAra = Extensions.AsString(reader("PayeeNameAra")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .PcClosed = Extensions.AsBool(reader("PcClosed")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

    End Class

End Namespace