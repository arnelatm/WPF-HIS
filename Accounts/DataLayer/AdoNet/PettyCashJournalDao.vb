' Data access object for PettyCashJournal
' ** DAO Pattern
Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet

    Public Class PettyCashJournalDao
        Implements IDao(Of PettyCashJournal), IDaoJournals(Of PettyCashJournal)

        Private Shared ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As PettyCashJournal _
            Implements IDao(Of PettyCashJournal).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, TransactionDate, ReferenceNo, Amount, AccountIdNo, PaymentType, PayeeIdNo, PayeeName, " &
                    " ORNumber, DiscountTaken, DiscountAccountIdNo, Applied, UnApplied, Notes, VatNumber, VatAmount, Posted, Cancelled, DateCreated" &
                    "   FROM [PettyCashJournal]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef pettyCashJournal As PettyCashJournal) As Integer _
            Implements IDao(Of PettyCashJournal).UpdateRecord
            Dim sql As String =
                    " UPDATE [PettyCashJournal]" &
                    " SET TransactionDate = @TransactionDate," &
                    "       ReferenceNo   = @ReferenceNo," &
                    "       Amount        = @Amount," &
                    "       AccountIdNo   = @AccountIdNo," &
                    "       PaymentType   = @PaymentType," &
                    "       PayeeIdNo     = @PayeeIdNo," &
                    "       PayeeName     = @PayeeName," &
                    "       ORNumber      = @ORNumber," &
                    "       DiscountTaken = @DiscountTaken," &
                    "       DiscountAccountIdNo = @DiscountAccountIdNo," &
                    "       Applied       = @Applied," &
                    "       UnApplied     = @UnApplied," &
                    "       Notes         = @Notes," &
                    "       VatNumber     = @VatNumber," &
                    "       VatAmount     = @VatAmount," &
                    "       Posted        = @Posted," &
                    "       Cancelled     = @Cancelled" &
                    "  WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(pettyCashJournal))
        End Function

        Public Function AddRecord(ByRef pettyCashJournal As PettyCashJournal) As Integer _
            Implements IDao(Of PettyCashJournal).AddRecord
            Dim sql As String =
                    " INSERT INTO [PettyCashJournal] " &
                    " (TransactionDate,ReferenceNo,Amount,AccountIdNo,PaymentType,PayeeIdNo,PayeeName,ORNumber,DiscountTaken,DiscountAccountIdNo,Applied,UnApplied,Notes,VatNumber,VatAmount,Posted,Cancelled)" &
                    " VALUES (@TransactionDate,@ReferenceNo,@Amount,@AccountIdNo,@PaymentType,@PayeeIdNo,@PayeeName,@ORNumber,@DiscountTaken,@DiscountAccountIdNo,@Applied,@UnApplied,@Notes,@VatNumber,@VatAmount,@Posted,@Cancelled)"
            Return Db.Insert(sql, Take(pettyCashJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PettyCashJournal) =
                                    Function(reader) _
            New PettyCashJournal() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .PayeeIdNo = Extensions.AsInt(Of Integer)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .OrNumber = Extensions.AsString(reader("ORNumber")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .DiscountAccountIdNo = Extensions.AsNullable(Of Int32?)(reader("DiscountAccountIdNo")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .UnApplied = Extensions.AsDecimal(reader("UnApplied")),
            .Notes = Extensions.AsString(reader("Notes")),
            .VatNumber = Extensions.AsString(reader("VatNumber")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .Cancelled = Extensions.AsBool(reader("Cancelled"))
            }

        Private Function Take(pettyCashJournal As PettyCashJournal) As Object()
            Return New Object() {
                                    "@IdNo", pettyCashJournal.IdNo,
                                    "@TransactionDate", pettyCashJournal.TransactionDate,
                                    "@ReferenceNo", pettyCashJournal.ReferenceNo,
                                    "@Amount", pettyCashJournal.Amount,
                                    "@AccountIdNo", pettyCashJournal.AccountIdNo,
                                    "@PaymentType", pettyCashJournal.PaymentType,
                                    "@PayeeIdNo", pettyCashJournal.PayeeIdNo,
                                    "@PayeeName", pettyCashJournal.PayeeName,
                                    "@ORNumber", pettyCashJournal.OrNumber,
                                    "@DiscountTaken", pettyCashJournal.DiscountTaken,
                                    "@DiscountAccountIdNo", pettyCashJournal.DiscountAccountIdNo,
                                    "@Applied", pettyCashJournal.Applied,
                                    "@UnApplied", pettyCashJournal.UnApplied,
                                    "@Notes", pettyCashJournal.Notes,
                                    "@VatNumber", pettyCashJournal.VatNumber,
                                    "@VatAmount", pettyCashJournal.VatAmount,
                                    "@Posted", pettyCashJournal.Posted,
                                    "@Cancelled", pettyCashJournal.Cancelled,
                                    "@DateCreated", pettyCashJournal.DateCreated
                                }
        End Function

        'Public Function UpdateGlReferenceNumber(ByRef model) As Integer Implements IDao(Of PettyCashJournal).UpdateGlReferenceNumber
        '    Dim retVal As Boolean
        '    Dim sql1 As String
        '    Dim sql2 As String
        '    Dim transactionDate = model.TransactionDate
        '    Dim series = "CDJOURNAL"
        '    sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
        '    sql2 = "Update [PettyCashJournal] set ReferenceNo = (select value from series where seriesName = '" & series & "') where IdNo = " & model.IdNo
        '    retVal = Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
        '    Return retVal
        'End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As PettyCashJournal) As Integer Implements IDaoJournals(Of PettyCashJournal).UpdateGlReferenceNumber
            Dim sql1 As String
            Dim sql2 As String
            Dim series = $"PCJOURNAL"
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update [PettyCashJournal] set ReferenceNo = (select value from series where seriesName = '" & series & "') where IdNo = " & bizObj.IdNo
            Return Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
        End Function

    End Class

End Namespace