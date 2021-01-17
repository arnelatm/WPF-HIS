Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for DjOiItem
    ' ** DAO Pattern

    Public Class DjOiItemDao
        Inherits DaoAccounts
        Implements IDaoChild(Of DjOiItem), IDaoOiItem(Of DjOiItem)

        Private ReadOnly _db As New Db()

        Protected TableOrViewName As String = ""
        Protected DboTvpUpdateName As String = ""
        Protected DboTvpInsertName As String = ""

        Public Sub New()
        End Sub

        Public Sub New(dataNames As Object())
            TableOrViewName = dataNames(0).ToString()
            DboTvpUpdateName = dataNames(1).ToString()
            DboTvpInsertName = dataNames(2).ToString()
        End Sub

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) As List(Of DjOiItem) Implements IDaoChild(Of DjOiItem).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "ApOpenInvoiceIdNo," &
                    "Balance," &
                    "DjIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "PreviousBalance," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableOrViewName &
                    " WHERE DjIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = _db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, djIdNo As Int32) As Integer Implements IDaoChild(Of DjOiItem).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateName, tvpTable, "@MParam", djIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of DjOiItem).InsertTvp
            Return _db.InsertTvp(DboTvpInsertName, tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DjOiItem) =
                                    Function(reader) _
            New DjOiItem() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .ApOpenInvoiceIdNo = Extensions.AsId(Of Int32)(reader("ApOpenInvoiceIdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .DjIdNo = Extensions.AsString(reader("DjIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsId(Of Int32)(reader("JournalIdNo")),
            .PreviousBalance = Extensions.AsDecimal(reader("PreviousBalance")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("sequence")),
            .TransactionDate = Extensions.AsDate((reader("TransactionDate")))
            }

        Public Function GetOpenInvoices(idNo As Int32) As List(Of DjOiItem) Implements IDaoOiItem(Of DjOiItem).GetOpenInvoices
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
            Dim x = _db.Read(sql, MakeDjOiItem).ToList()
            Return x
        End Function

        Public Shared ReadOnly MakeDjOiItem As Func(Of IDataReader, DjOiItem) = Function(reader) New DjOiItem() With
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