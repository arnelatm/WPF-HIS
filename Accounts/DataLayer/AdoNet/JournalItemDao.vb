Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer

Namespace DataLayer.AdoNet
    ' Data access object for JournalItem
    ' ** DAO Pattern

    Public Class JournalItemDao
        Inherits CommonDao
        Implements IDaoChild(Of JournalItem)

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = ""
        Protected DboTvpUpdateFileName As String = ""
        Protected DboTvpInsertFileName As String = ""

        'Public Sub New()
        '    DbCommon = Db
        'End Sub

        'Public Function GetRecordById(idNo As Integer) As JournalItem Implements IDaoChild(Of JournalItem).GetRecordById
        '    Dim sql As String =
        '            "SELECT " &
        '            "AccountIdNo," &
        '            "AccountName," &
        '            "Credit," &
        '            "DiscountTaken," &
        '            "Debit," &
        '            "IDNo," &
        '            "JournalIdNo," &
        '            "Notes," &
        '            "OpenInvoiceIdNo," &
        '            "OriginalAmount," &
        '            "PaidAmount," &
        '            "PayeeType," &
        '            "ProfitCenterIdNo," &
        '            "Sequence," &
        '            "SpecialAccount" &
        '            " FROM " & TableFileName &
        '            " WHERE IDNo = @IDNo"
        '    Dim params() As Object = {"@IDNo", idNo}
        '    Return Db.Read(sql, Make, params).FirstOrDefault()
        'End Function

        Public Function GetJournalItems(journalIdNo As Integer) As List(Of JournalItem)
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "AccountName," &
                    "Credit," &
                    "Debit," &
                    "DiscountTaken," &
                    "IDNo," &
                    "JournalIdNo," &
                    "Notes," &
                    "OpenInvoiceIdNo," &
                    "OriginalAmount," &
                    "PaidAmount," &
                    "PayeeType," &
                    "ProfitCenterIdNo," &
                    "Sequence," &
                    "SpecialAccount" &
                    " FROM " & TableFileName &
                    " WHERE JournalIdNo = @JournalIdNo" &
                    " ORDER BY Sequence"
            Dim params() As Object = {"@JournalIdNo", journalIdNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        'Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of JournalItem) _
        '    Implements IDaoChild(Of JournalItem).GetAll
        '    Dim sql As String =
        '            " SELECT IDNo, JournalIdNo,  " &
        '            "   FROM " & TableFileName & " order by " & sortExpression
        '    Return Db.Read(sql, Make).ToList()
        'End Function

        Public Function GetRecordsById(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of JournalItem) Implements IDaoChild(Of JournalItem).GetRecordsById
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "AccountName," &
                    "Credit," &
                    "Debit," &
                    "DiscountTaken," &
                    "IDNo," &
                    "JournalIdNo," &
                    "Notes," &
                    "OriginalAmount," &
                    "OpenInvoiceIdNo," &
                    "PaidAmount," &
                    "PayeeType," &
                    "ProfitCenterIdNo," &
                    "Sequence," &
                    "SpecialAccount" &
                    " FROM " & TableFileName &
                    " WHERE JournalIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, journalItemIdNo As Integer) As Integer _
            Implements IDaoChild(Of JournalItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", journalItemIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of JournalItem).InsertTvp
            Return Db.TvpInsert(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, JournalItem) =
                                    Function(reader) _
            New JournalItem() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .AccountName = Extensions.AsString(reader("AccountName")),
            .Credit = Extensions.AsDecimal(reader("Credit")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .Debit = Extensions.AsDecimal(reader("Debit")),
            .IdNo = Extensions.AsId(reader("IDNo")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OriginalAmount = Extensions.AsDecimal(reader("OriginalAmount")),
            .OpenInvoiceIdNo = Extensions.AsDecimal(reader("OpenInvoiceIdNo")),
            .PaidAmount = Extensions.AsDecimal(reader("PaidAmount")),
            .PayeeType = Extensions.AsString(reader("PayeeType")),
            .ProfitCenterIdNo = Extensions.AsInt(Of Integer)(reader("ProfitCenterIdNo")),
            .Sequence = Extensions.AsInt(Of Integer)(reader("Sequence")),
            .SpecialAccount = Extensions.AsString(reader("SpecialAccount"))
            }

        Private Function Take(journalItem As JournalItem) As Object()
            Return New Object() {
                                    "@AccountIdNo", journalItem.AccountIdNo,
                                    "@AccountName", journalItem.AccountName,
                                    "@Credit", journalItem.Credit,
                                    "@Debit", journalItem.Debit,
                                    "DiscountTaken", journalItem.DiscountTaken,
                                    "@IDNo", journalItem.IdNo,
                                    "@JournalIdNo", journalItem.JournalIdNo,
                                    "@Notes", journalItem.Notes,
                                    "@OriginalAmount", journalItem.OriginalAmount,
                                    "@OpenInvoiceIdNo", journalItem.OpenInvoiceIdNo,
                                    "@PaidAmount", journalItem.PaidAmount,
                                    "@PayeeType", journalItem.PayeeType,
                                    "@ProfitCenterIdNo", journalItem.ProfitCenterIdNo,
                                    "@Sequence", journalItem.Sequence,
                                    "@SpecialAccount", journalItem.SpecialAccount
                                }
        End Function

    End Class

End Namespace