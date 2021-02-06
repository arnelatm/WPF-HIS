Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for DisbursementJournal
    ' ** DAO Pattern

    Public Class DisbursementJournalDao
        Implements IDao(Of BusinessLayer.DisbursementJournal), IDaoJournals(Of BusinessLayer.DisbursementJournal), IDaoOiItem(Of DjOiItem), IDaoAutoVatUpdate

        Public ReadOnly Property Args As Object()
        Private ReadOnly _db As New Db()
        Protected TableOrViewName As String
        Protected JournalCode As String
        Protected JiDataNames As Object
        Protected OiDataNames As Object

        Public Sub New(dataNames As Object())
            Me.Args = dataNames
            TableOrViewName = dataNames(0)
            JournalCode = dataNames(1)
            JiDataNames = dataNames(2)
            OiDataNames = dataNames(3)
        End Sub

        Public Function GetRecordById(idNo) As BusinessLayer.DisbursementJournal Implements IDao(Of BusinessLayer.DisbursementJournal).GetRecordById
            Dim sql As String
            Dim data
            Dim params() As Object = {"@IdNo", idNo}
            Dim jiDao
            Dim oiDao
            If TableOrViewName = "CdJournal" Then
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
                    "PcClosed," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate," &
                    "UnApplied," &
                    "VatAmount," &
                    "VatNumber" &
                    " FROM " & TableOrViewName &
                    " WHERE IdNo = @IdNo"
                data = _db.Read(sql, CdMake, params).FirstOrDefault()
            Else
                sql = "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Applied," &
                    "Cancelled," &
                    "CdJournalIdNo," &
                    "DateCreated," &
                    "DiscountAccountIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "Notes," &
                    "ORNumber," &
                    "PayeeIdNo," &
                    "PayeeName," &
                    "PaymentType," &
                    "PcClosed," &
                    "Posted," &
                    "ReferenceNo," &
                    "TransactionDate," &
                    "UnApplied," &
                    "VatAmount," &
                    "VatNumber" &
                    " FROM " & TableOrViewName &
                    " WHERE IdNo = @IdNo"
                data = _db.Read(sql, PcMake, params).FirstOrDefault()
            End If
            jiDao = New JournalItemDao(JiDataNames)
            oiDao = New DjOiItemDao(OiDataNames)
            If data Is Nothing Then
                Debugger.Break()
            Else
                Dim ji = jiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
                Dim oi = oiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
                data.JournalItems = ji
                data.DjOiItems = oi
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef disbursementJournal As BusinessLayer.DisbursementJournal) As Integer Implements IDao(Of BusinessLayer.DisbursementJournal).UpdateRecord
            Dim sql As String
            If TableOrViewName = "CdJournal" Then
                sql = " UPDATE " & TableOrViewName & " SET " &
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
                    "PcClosed      = @PcClosed," &
                    "Posted        = @Posted," &
                    "ReferenceNo   = @ReferenceNo," &
                    "TransactionDate = @TransactionDate," &
                    "UnApplied     = @UnApplied," &
                    "VatAmount     = @VatAmount," &
                    "VatNumber     = @VatNumber" &
                    " WHERE IdNo = @IdNo"
                Return _db.Update(sql, CdTake(disbursementJournal))
            Else
                sql = " UPDATE " & TableOrViewName & " SET " &
                    "AccountIdNo   = @AccountIdNo," &
                    "Amount        = @Amount," &
                    "Applied       = @Applied," &
                    "Cancelled     = @Cancelled," &
                    "CdJournalIdNo = @CdJournalIdNo," &
                    "DiscountAccountIdNo = @DiscountAccountIdNo," &
                    "DiscountTaken = @DiscountTaken," &
                    "Notes         = @Notes," &
                    "ORNumber      = @ORNumber," &
                    "PayeeIdNo     = @PayeeIdNo," &
                    "PayeeName     = @PayeeName," &
                    "PaymentType   = @PaymentType," &
                    "PcClosed      = @PcClosed," &
                    "Posted        = @Posted," &
                    "ReferenceNo   = @ReferenceNo," &
                    "TransactionDate = @TransactionDate," &
                    "UnApplied     = @UnApplied," &
                    "VatAmount     = @VatAmount," &
                    "VatNumber     = @VatNumber" &
                    " WHERE IdNo = @IdNo"
                Return _db.Update(sql, PcTake(disbursementJournal))
            End If
        End Function

        Public Function AddRecord(ByRef disbursementJournal As BusinessLayer.DisbursementJournal) As Integer Implements IDao(Of BusinessLayer.DisbursementJournal).AddRecord
            Dim sql As String
            If TableOrViewName = "CdJournal" Then
                sql = " INSERT INTO " & TableOrViewName & " (" &
                        "AccountIdNo," &
                        "Amount," &
                        "Applied," &
                        "Cancelled," &
                        "CheckDate," &
                        "CheckNumber," &
                        "PayType," &
                        "DiscountAccountIdNo," &
                        "DiscountTaken," &
                        "Notes," &
                        "ORNumber," &
                        "PayeeIdNo," &
                        "PayeeName," &
                        "PaymentType," &
                        "PcClosed," &
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
                        "@CheckDate," &
                        "@CheckNumber," &
                        "@PayType," &
                        "@DiscountAccountIdNo," &
                        "@DiscountTaken," &
                        "@Notes," &
                        "@ORNumber," &
                        "@PayeeIdNo," &
                        "@PayeeName," &
                        "@PaymentType," &
                        "@PcClosed," &
                        "@Posted," &
                        "@ReferenceNo," &
                        "@TransactionDate," &
                        "@UnApplied," &
                        "@VatAmount," &
                        "@VatNumber" &
                        ")"
                Return _db.Insert(sql, CdTake(disbursementJournal))
            Else
                sql = " INSERT INTO " & TableOrViewName & " (" &
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
                        "PcClosed," &
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
                        "@PcClosed," &
                        "@Posted," &
                        "@ReferenceNo," &
                        "@TransactionDate," &
                        "@UnApplied," &
                        "@VatAmount," &
                        "@VatNumber" &
                        ")"
                Return _db.Insert(sql, PcTake(disbursementJournal))
            End If
        End Function

        Private ReadOnly PcMake As Func(Of IDataReader, BusinessLayer.DisbursementJournal) =
                                    Function(reader) _
            New DisbursementJournal(JournalCode) With {
            .AccountIdNo = Extensions.AsNullable(Of Int16?)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .CdJournalIdNo = Extensions.AsInt(Of Int32)(reader("CdJournalIdNO")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .DiscountAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("DiscountAccountIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OrNumber = Extensions.AsString(reader("ORNumber")),
            .PayeeIdNo = Extensions.AsNullable(Of Int32?)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .PcClosed = Extensions.AsBool(reader("PcClosed")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .UnApplied = Extensions.AsDecimal(reader("UnApplied")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = Extensions.AsString(reader("VatNumber"))
            }

        Private ReadOnly CdMake As Func(Of IDataReader, BusinessLayer.DisbursementJournal) =
                            Function(reader) _
            New DisbursementJournal(JournalCode) With {
            .AccountIdNo = Extensions.AsNullable(Of Int16?)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .CheckDate = Extensions.AsNullable(Of Date?)(reader("CheckDate")),
            .CheckNumber = Extensions.AsString(reader("CheckNumber")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .PayType = Extensions.AsString(reader("PayType")),
            .DiscountAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("DiscountAccountIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OrNumber = Extensions.AsString(reader("ORNumber")),
            .PayeeIdNo = Extensions.AsNullable(Of Int32?)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .PcClosed = Extensions.AsBool(reader("PcClosed")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .UnApplied = Extensions.AsDecimal(reader("UnApplied")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = Extensions.AsString(reader("VatNumber"))
            }

        Private Function PcTake(disbursementJournal As BusinessLayer.DisbursementJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", disbursementJournal.AccountIdNo,
                                    "@Amount", disbursementJournal.Amount,
                                    "@Applied", disbursementJournal.Applied,
                                    "@Cancelled", disbursementJournal.Cancelled,
                                    "@CdJournalIdNo", disbursementJournal.CdJournalIdNo,
                                    "@DateCreated", disbursementJournal.DateCreated,
                                    "@DiscountAccountIdNo", disbursementJournal.DiscountAccountIdNo,
                                    "@DiscountTaken", disbursementJournal.DiscountTaken,
                                    "@IdNo", disbursementJournal.IdNo,
                                    "@Notes", disbursementJournal.Notes,
                                    "@ORNumber", disbursementJournal.OrNumber,
                                    "@PayeeIdNo", disbursementJournal.PayeeIdNo,
                                    "@PayeeName", disbursementJournal.PayeeName,
                                    "@PaymentType", disbursementJournal.PaymentType,
                                    "@PcClosed", disbursementJournal.PcClosed,
                                    "@Posted", disbursementJournal.Posted,
                                    "@ReferenceNo", disbursementJournal.ReferenceNo,
                                    "@TransactionDate", disbursementJournal.TransactionDate,
                                    "@UnApplied", disbursementJournal.UnApplied,
                                    "@VatAmount", disbursementJournal.VatAmount,
                                    "@VatNumber", disbursementJournal.VatNumber
                                }
        End Function

        Private Function CdTake(disbursementJournal As BusinessLayer.DisbursementJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", disbursementJournal.AccountIdNo,
                                    "@Amount", disbursementJournal.Amount,
                                    "@Applied", disbursementJournal.Applied,
                                    "@Cancelled", disbursementJournal.Cancelled,
                                    "@CheckDate", disbursementJournal.CheckDate,
                                    "@CheckNumber", disbursementJournal.CheckNumber,
                                    "@DateCreated", disbursementJournal.DateCreated,
                                    "@PayType", disbursementJournal.PayType,
                                    "@DiscountAccountIdNo", disbursementJournal.DiscountAccountIdNo,
                                    "@DiscountTaken", disbursementJournal.DiscountTaken,
                                    "@IdNo", disbursementJournal.IdNo,
                                    "@Notes", disbursementJournal.Notes,
                                    "@ORNumber", disbursementJournal.OrNumber,
                                    "@PayeeIdNo", disbursementJournal.PayeeIdNo,
                                    "@PayeeName", disbursementJournal.PayeeName,
                                    "@PaymentType", disbursementJournal.PaymentType,
                                    "@PcClosed", disbursementJournal.PcClosed,
                                    "@Posted", disbursementJournal.Posted,
                                    "@ReferenceNo", disbursementJournal.ReferenceNo,
                                    "@TransactionDate", disbursementJournal.TransactionDate,
                                    "@UnApplied", disbursementJournal.UnApplied,
                                    "@VatAmount", disbursementJournal.VatAmount,
                                    "@VatNumber", disbursementJournal.VatNumber
                                }
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As BusinessLayer.DisbursementJournal) As Integer Implements IDaoJournals(Of BusinessLayer.DisbursementJournal).UpdateGlReferenceNumber
            Dim retVal As Boolean
            Dim sql1 As String
            Dim sql2 As String
            Dim seriesName As String
            If TableOrViewName = "CdJournal" AndAlso bizObj.PayType = GlobalFunctions.EnumToCode(PayTypeSelection.BankTransfer) Then
                seriesName = "BTJournal"
                sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & seriesName & "'"
                sql2 = "Update [" & TableOrViewName & "] set ReferenceNo = (select value from series where seriesName = '" & seriesName & "') where IdNo = " & bizObj.IdNo
                retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            ElseIf TableOrViewName = "CdJournal" AndAlso bizObj.PayType = GlobalFunctions.EnumToCode(PayTypeSelection.CheckPayment) Then
                seriesName = "CKJournal"
                sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & seriesName & "'"
                sql2 = "Update [" & TableOrViewName & "] set ReferenceNo = (select value from series where seriesName = '" & seriesName & "') where IdNo = " & bizObj.IdNo
                retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Else
                Dim transactionDate = bizObj.TransactionDate
                Dim series = "GL" + Year(transactionDate).ToString() + Right("00" + Month(transactionDate).ToString, 2)
                Dim maxlength As Int16
                Dim prefix As String
                If _db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                    seriesName = "GJ"
                    maxlength = 4
                    prefix = Right("00" + Month(transactionDate).ToString, 2) & "-"
                    Dim sql As String = "INSERT INTO [Series] " &
                        " (SeriesName,Value,MaxLength,Prefix,Description)" &
                        " VALUES (@SeriesName,@Value,@MaxLength,@Prefix,@Description)"
                    Dim params() As Object = {"@SeriesName", series,
                                              "@Value", 0,
                                              "@MaxLength", 4,
                                              "@Prefix", prefix,
                                              "@Description", "GL Series for " & Year(transactionDate).ToString() & Microsoft.VisualBasic.Strings.Right("00" + Month(transactionDate).ToString, 2)
                                             }
                    retVal = _db.Insert(sql, params)
                    If retVal < 0 Then
                        Return retVal
                    End If
                Else
                    prefix = _db.Scalar("select prefix from series where seriesName = '" & series & "'")
                    maxlength = _db.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
                End If
                sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
                sql2 = "Update [CDJournal] set ReferenceNo = Concat( '" & prefix & "', RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                       ")) where IdNo = " & bizObj.IdNo
                retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
                Return retVal
            End If
            Return retVal
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of DjOiItem) Implements IDaoOiItem(Of DjOiItem).GetOpenInvoices
            Dim oiDao = New DjOiItemDao(JiDataNames)
            Return oiDao.GetOpenInvoices(idNo)
        End Function

        Public Function UpdateVatNumber(vatNumber As String, idNo As Integer) As Integer Implements IDaoAutoVatUpdate.UpdateVatNumber
            Dim retVal As Boolean
            Dim sql1 As String
            sql1 = "Update Supplier set VatNumber = '" & vatNumber & "' where IdNo = " & idNo.ToString() & " and (VatNumber IS NULL or VatNumber = '')"
            retVal = _db.ExecuteSqlTransaction("UpdateVatNumber", sql1, "")
            Return retVal
        End Function

    End Class

End Namespace