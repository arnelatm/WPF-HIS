Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CjOiItem
    ' ** DAO Pattern

    Public MustInherit Class CjOiItemDao
        Inherits CommonDao

        Private ReadOnly _db As New Db()

        Public Property TableName As String
        Public Property DboTvpUpdateName As String
        Public Property DboTvpInsertName As String

        Protected Function CdGetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) As List(Of CjOiItem)
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "ApOpenInvoiceIdNo," &
                    "Balance," &
                    "CjIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "PreviousBalance," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableName &
                    " WHERE CjIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = _db.Read(sql, Make).ToList()
            Return x
        End Function

        Protected Function CdDelUpdateTvp(ByRef tvpTable As DataTable, cjIdNo As Int32) As Integer
            Return _db.DelUpdateTvp(DboTvpUpdateName, tvpTable, "@MParam", cjIdNo)
        End Function

        Public Function CdInsertTvp(ByRef tvpTable As DataTable) As Integer
            Return _db.InsertTvp(DboTvpInsertName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CjOiItem) =
                                    Function(reader) _
            New CjOiItem() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .ApOpenInvoiceIdNo = Extensions.AsId(Of Int32)(reader("ApOpenInvoiceIdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .CjIdNo = Extensions.AsString(reader("CjIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsId(Of Int32)(reader("JournalIdNo")),
            .PreviousBalance = Extensions.AsDecimal(reader("PreviousBalance")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("sequence")),
            .TransactionDate = Extensions.AsDate((reader("TransactionDate")))
            }

        Public Function CdGetOpenInvoices(idNo As Int32) As List(Of CjOiItem)
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Balance," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "TransactionDate" &
                    " FROM ApOpenInvoice_View " &
                    " WHERE Balance <> 0 and SupplierIdNo = " & idNo.ToString() &
                    " ORDER BY TransactionDate"
            Dim x = _db.Read(sql, MakeCjOiItem).ToList()
            Return x
        End Function

        Public Shared ReadOnly MakeCjOiItem As Func(Of IDataReader, CjOiItem) = Function(reader) New CjOiItem() With
            {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .ApOpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .IdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
            }

    End Class

End Namespace