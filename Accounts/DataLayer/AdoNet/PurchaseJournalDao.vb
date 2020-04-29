Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PurchaseJournal
    ' ** DAO Pattern

    Public Class PurchaseJournalDao
        Implements IDao(Of PurchaseJournal), IDaoJournals(Of PurchaseJournal)

        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As PurchaseJournal _
        Implements IDao(Of PurchaseJournal).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, SupplierIdNo, TransactionDate, ReferenceNo, Amount, AccountIdNo, DueDate, " &
                    " InvoiceNo, InvoiceDate, SettlementDiscount, SettlementDueDate, VatNumber, VatAmount, Posted, " &
                    " Cancelled, Notes, VatNumber, VatAmount, Posted, Cancelled, DateCreated" &
                    "   FROM [PurchaseJournal]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef purchaseJournal As PurchaseJournal) As Integer _
            Implements IDao(Of PurchaseJournal).UpdateRecord
            Dim sql As String =
                    " UPDATE [PurchaseJournal]" &
                    "   SET SupplierIdNo = @SupplierIdNo," &
                    "       AccountIdNo = @AccountIdNo," &
                    "       Amount = @Amount," &
                    "       Cancelled = @Cancelled," &
                    "       DueDate = @DueDate," &
                    "       InvoiceDate = @InvoiceDate," &
                    "       InvoiceNo = @InvoiceNo," &
                    "       Notes = @Notes," &
                    "       Posted = @Posted," &
                    "       ReferenceNo = @ReferenceNo," &
                    "       TransactionDate = @TransactionDate," &
                    "       SettlementDiscount = @SettlementDiscount," &
                    "       SettlementDueDate = @SettlementDueDate," &
                    "       VatAmount = @VatAmount," &
                    "       VatNumber = @VatNumber" &
                    "  WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(purchaseJournal))
        End Function

        Public Function AddRecord(ByRef purchaseJournal As PurchaseJournal) As Integer _
            Implements IDao(Of PurchaseJournal).AddRecord
            Dim sql As String =
                    " INSERT INTO [PurchaseJournal] " &
                    " (SupplierIdNo,TransactionDate,ReferenceNo,Amount,AccountIdNo,DueDate,InvoiceNo,InvoiceDate,SettlementDiscount,SettlementDueDate,VatNumber,VatAmount,Posted,Cancelled,Notes)" &
                    " VALUES (@SupplierIdNo,@TransactionDate,@ReferenceNo,@Amount,@AccountIdNo,@DueDate,@InvoiceNo,@InvoiceDate,@SettlementDiscount,@SettlementDueDate,@VatNumber,@VatAmount,@Posted,@Cancelled,@Notes)"
            Return Db.Insert(sql, Take(purchaseJournal))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PurchaseJournal) =
                                    Function(reader) _
            New PurchaseJournal() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .DueDate = Extensions.AsDate(reader("DueDate")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .SettlementDiscount = Extensions.AsDecimal(reader("SettlementDiscount")),
            .SettlementDueDate = Extensions.AsDate(reader("SettlementDueDate")),
            .SupplierIdNo = Extensions.AsInt(Of Integer)(reader("SupplierIdNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = Extensions.AsString(reader("VatNumber")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .InvoiceDate = Extensions.AsDate(reader("InvoiceDate")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(purchaseJournal As PurchaseJournal) As Object()
            Return New Object() {
                                    "@IdNo", purchaseJournal.IdNo,
                                    "@SupplierIdNo", purchaseJournal.SupplierIdNo,
                                    "@TransactionDate", purchaseJournal.TransactionDate,
                                    "@ReferenceNo", purchaseJournal.ReferenceNo,
                                    "@Amount", purchaseJournal.Amount,
                                    "@AccountIdNo", purchaseJournal.AccountIdNo,
                                    "@DueDate", purchaseJournal.DueDate,
                                    "@InvoiceNo", purchaseJournal.InvoiceNo,
                                    "@InvoiceDate", purchaseJournal.InvoiceDate,
                                    "@SettlementDiscount", purchaseJournal.SettlementDiscount,
                                    "@SettlementDueDate", purchaseJournal.SettlementDueDate,
                                    "@VatNumber", purchaseJournal.VatNumber,
                                    "@VatAmount", purchaseJournal.VatAmount,
                                    "@Notes", purchaseJournal.Notes,
                                    "@Posted", purchaseJournal.Posted,
                                    "@Cancelled", purchaseJournal.Cancelled,
                                    "@DateCreated", purchaseJournal.DateCreated
                                 }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As PurchaseJournal) As Integer Implements IDaoJournals(Of PurchaseJournal).UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql1 As String
            Dim sql2 As String
            Dim transactionDate = bizObj.TransactionDate
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
            sql2 = "Update [PurchaseJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = Db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

    End Class

End Namespace