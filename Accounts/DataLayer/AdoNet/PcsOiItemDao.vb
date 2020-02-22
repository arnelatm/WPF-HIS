Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for PcsOiItem
    ' ** DAO Pattern

    Public Class PcsOiItemDao
        Inherits CommonDao
        Implements IPcsOiItemDao

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "PcsOiItem_View"
        Protected DboTvpUpdateFileName As String = "dbo.UpdatePcsOiItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertPcsOiItemTVP"

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of PcsOiItem) _
            Implements IPcsOiItemDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, Amount " &
                    "   FROM [PcsOiItem] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecordById(idNo As Integer) As PcsOiItem _
                        Implements IPcsOiItemDao.GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Balance," &
                    "PcsIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "OpenInvoiceIdNo" &
                    "PreviousBalance," &
                    "Sequence," &
                    "TransactionDate" &
                    "   FROM " & TableFileName &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = "Sequence") _
            As List(Of PcsOiItem)
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Balance," &
                    "PcsIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "OpenInvoiceIdNo," &
                    "PreviousBalance," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE PcsIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, pcsIdNo As Integer) As Integer _
            Implements IPcsOiItemDao.DelUpdateTvp
            Return Db.TvpDelUpdate(DboTvpUpdateFileName, tvpTable, "@MParam", pcsIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IPcsOiItemDao.InsertTvp
            Return Db.TvpInsert(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PcsOiItem) =
                                    Function(reader) _
            New PcsOiItem() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .PcsIdNo = Extensions.AsString(reader("PcsIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsId(reader("JournalIdNo")),
            .JournalItemIdNo = Extensions.AsId(reader("JournalItemIdNo")),
            .OpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("OpenInvoiceIdNo")),
            .PreviousBalance = Extensions.AsDecimal(reader("PreviousBalance")),
            .Sequence = Extensions.AsInt(Of Integer)(reader("sequence")),
            .TransactionDate = Extensions.AsDate((reader("TransactionDate")))
            }

        '' ReSharper disable once UnusedMember.Local
        'Private Function Take(PcsOiItem As PcsOiItem) As Object()
        '    Return New Object() {
        '                            "@AccountIdNo", PcsOiItem.AccountIdNo,
        '                            "@Amount", PcsOiItem.Amount,
        '                            "@Balance", PcsOiItem.Balance,
        '                            "@PcsIdNo", PcsOiItem.PcsIdNo,
        '                            "@DiscountTaken", PcsOiItem.DiscountTaken,
        '                            "@IdNo", PcsOiItem.IdNo,
        '                            "@InvoiceNo", PcsOiItem.InvoiceNo,
        '                            "@JournalItemIdNo", PcsOiItem.JournalItemIdNo,
        '                            "@OpenInvoiceIdNo", PcsOiItem.OpenInvoiceIdNo,
        '                            "@PreviousBalance", PcsOiItem.PreviousBalance,
        '                            "@Sequence", PcsOiItem.Sequence,
        '                            "@TransactionDate", PcsOiItem.TransactionDate
        '                         }
        'End Function

        Public Function GetSupplierOpenInvoices(idNo As Integer) _
            As List(Of PcsOiItem) Implements IPcsOiItemDao.GetSupplierOpenInvoices
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Balance," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "TransactionDate" &
                    " FROM ApOpenInvoice_View " &
                    " WHERE Balance <> 0 and SupplierIdNo = " & idNo.ToString() &
                    " ORDER BY TransactionDate"
            Dim x = Db.Read(sql, MakePcsOiItem).ToList()
            Return x
        End Function

        Public Shared ReadOnly MakePcsOiItem As Func(Of IDataReader, PcsOiItem) = Function(reader) New PcsOiItem() With
            {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .OpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .JournalItemIdNo = Extensions.AsInt(Of Integer)(reader("JournalItemIdNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

    End Class

End Namespace