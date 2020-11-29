Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for DisbursementJournal
    ' ** DAO Pattern

    Public MustInherit Class DisbursementJournalDao
        Inherits DaoAccounts

        Private ReadOnly _db As New Db()
        Private _tableName As String
        Private _seriesName As String

        Protected Property TableName As String
            Get
                Return _tableName
            End Get
            Set(value As String)
                _tableName = value
            End Set
        End Property

        Protected Property SeriesName As String
            Get
                Return _seriesName
            End Get
            Set(value As String)
                _seriesName = value
            End Set
        End Property

        Protected Function DjGetRecordById(idNo) As DisbursementJournal
            Dim sql As String
            Dim data
            Dim params() As Object = {"@IdNo", idNo}
            If TableName = "CkJournal" Then
                sql = "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Applied," &
                    "Cancelled," &
                    "CheckDate," &
                    "CheckNumber," &
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
                    " FROM " & TableName &
                    " WHERE IdNo = @IdNo"
                data = _db.Read(sql, CkMake, params).FirstOrDefault()
            Else
                sql = "SELECT " &
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
                    " FROM " & TableName &
                    " WHERE IdNo = @IdNo"
                data = _db.Read(sql, DjMake, params).FirstOrDefault()
            End If
            Dim jiDao = GetJiDao()
            Dim oiDao = GetDjOiItemDao()
            Dim ji = jiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            Dim oi = oiDao.GetRecordsWithIdNo(data.IdNo, "sequence")
            data.JournalItems = ji
            data.DjOiItems = oi
            Return data
        End Function

        Protected MustOverride Function GetJiDao()

        Protected MustOverride Function GetDjOiItemDao()

        Public Function DjUpdateRecord(ByRef disbursementJournal As DisbursementJournal) As Integer
            Dim sql As String
            If TableName = "CkJournal" Then
                sql = " UPDATE " & TableName & " SET " &
                    "AccountIdNo   = @AccountIdNo," &
                    "Amount        = @Amount," &
                    "Applied       = @Applied," &
                    "Cancelled     = @Cancelled," &
                    "CheckDate     = @CheckDate," &
                    "CheckNumber   = @CheckNumber," &
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
            Else
                sql = " UPDATE " & TableName & " SET " &
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
            End If
            Return _db.Update(sql, DjTake(disbursementJournal))
        End Function

        Public Function DjAddRecord(ByRef disbursementJournal As DisbursementJournal) As Integer
            Dim sql As String
            If TableName = "CkJournal" Then
                sql = " INSERT INTO " & TableName & " (" &
                        "AccountIdNo," &
                        "Amount," &
                        "Applied," &
                        "Cancelled," &
                        "CheckDate," &
                        "CheckNumber," &
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
                Return _db.Insert(sql, CkTake(disbursementJournal))
            Else
                sql = " INSERT INTO " & TableName & " (" &
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
                Return _db.Insert(sql, DjTake(disbursementJournal))
            End If
        End Function

        Private Shared ReadOnly DjMake As Func(Of IDataReader, DisbursementJournal) =
                                    Function(reader) _
            New DisbursementJournal() With {
            .AccountIdNo = Extensions.AsNullable(Of Int16?)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .DiscountAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("DiscountAccountIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OrNumber = Extensions.AsString(reader("ORNumber")),
            .PayeeIdNo = Extensions.AsNullable(Of Int32?)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .UnApplied = Extensions.AsDecimal(reader("UnApplied")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = Extensions.AsString(reader("VatNumber"))
            }

        Private Shared ReadOnly CkMake As Func(Of IDataReader, DisbursementJournal) =
                            Function(reader) _
            New DisbursementJournal() With {
            .AccountIdNo = Extensions.AsNullable(Of Int16?)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Applied = Extensions.AsDecimal(reader("Applied")),
            .Cancelled = Extensions.AsBool(reader("Cancelled")),
            .CheckDate = Extensions.AsNullable(Of Date?)(reader("CheckDate")),
            .CheckNumber = Extensions.AsString(reader("CheckNumber")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .DiscountAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("DiscountAccountIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OrNumber = Extensions.AsString(reader("ORNumber")),
            .PayeeIdNo = Extensions.AsNullable(Of Int32?)(reader("PayeeIdNo")),
            .PayeeName = Extensions.AsString(reader("PayeeName")),
            .PaymentType = Extensions.AsString(reader("PaymentType")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
            .UnApplied = Extensions.AsDecimal(reader("UnApplied")),
            .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
            .VatNumber = Extensions.AsString(reader("VatNumber"))
            }

        Private Function DjTake(disbursementJournal As DisbursementJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", disbursementJournal.AccountIdNo,
                                    "@Amount", disbursementJournal.Amount,
                                    "@Applied", disbursementJournal.Applied,
                                    "@Cancelled", disbursementJournal.Cancelled,
                                    "@DateCreated", disbursementJournal.DateCreated,
                                    "@DiscountAccountIdNo", disbursementJournal.DiscountAccountIdNo,
                                    "@DiscountTaken", disbursementJournal.DiscountTaken,
                                    "@IdNo", disbursementJournal.IdNo,
                                    "@Notes", disbursementJournal.Notes,
                                    "@ORNumber", disbursementJournal.OrNumber,
                                    "@PayeeIdNo", disbursementJournal.PayeeIdNo,
                                    "@PayeeName", disbursementJournal.PayeeName,
                                    "@PaymentType", disbursementJournal.PaymentType,
                                    "@Posted", disbursementJournal.Posted,
                                    "@ReferenceNo", disbursementJournal.ReferenceNo,
                                    "@TransactionDate", disbursementJournal.TransactionDate,
                                    "@UnApplied", disbursementJournal.UnApplied,
                                    "@VatAmount", disbursementJournal.VatAmount,
                                    "@VatNumber", disbursementJournal.VatNumber
                                }
        End Function

        Private Function CkTake(disbursementJournal As DisbursementJournal) As Object()
            Return New Object() {
                                    "@AccountIdNo", disbursementJournal.AccountIdNo,
                                    "@Amount", disbursementJournal.Amount,
                                    "@Applied", disbursementJournal.Applied,
                                    "@Cancelled", disbursementJournal.Cancelled,
                                    "@CheckDate", disbursementJournal.CheckDate,
                                    "@CheckNumber", disbursementJournal.CheckNumber,
                                    "@DateCreated", disbursementJournal.DateCreated,
                                    "@DiscountAccountIdNo", disbursementJournal.DiscountAccountIdNo,
                                    "@DiscountTaken", disbursementJournal.DiscountTaken,
                                    "@IdNo", disbursementJournal.IdNo,
                                    "@Notes", disbursementJournal.Notes,
                                    "@ORNumber", disbursementJournal.OrNumber,
                                    "@PayeeIdNo", disbursementJournal.PayeeIdNo,
                                    "@PayeeName", disbursementJournal.PayeeName,
                                    "@PaymentType", disbursementJournal.PaymentType,
                                    "@Posted", disbursementJournal.Posted,
                                    "@ReferenceNo", disbursementJournal.ReferenceNo,
                                    "@TransactionDate", disbursementJournal.TransactionDate,
                                    "@UnApplied", disbursementJournal.UnApplied,
                                    "@VatAmount", disbursementJournal.VatAmount,
                                    "@VatNumber", disbursementJournal.VatNumber
                                }
        End Function

        Public Function DjUpdateGlReferenceNumber(ByRef bizObj As DisbursementJournal) As Integer
            Dim retVal As Boolean
            Dim sql1 As String
            Dim sql2 As String
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & SeriesName & "'"
            sql2 = "Update [" & _tableName & "] set ReferenceNo = (select value from series where seriesName = '" & SeriesName & "') where IdNo = " & bizObj.IdNo
            retVal = _db.ExecuteSqlTransaction("UpdateGlReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        Public Function CdGetOpenInvoices(idNo As Integer) As List(Of DjOiItem)
            Dim oiDao = GetDjOiItemDao()
            Return oiDao.GetOpenInvoices(idNo)
        End Function

    End Class

End Namespace