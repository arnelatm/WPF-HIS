Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CjOiItem
    ' ** DAO Pattern

    Public Class CjOiItemDao
        Inherits CommonDao
        Implements IDaoChild(Of CjOiItem), IDaoOiItem(Of CjOiItem)

        Private ReadOnly _db As New Db()

        Protected TableFileName As String
        Protected DboTvpUpdateFileName As String
        Protected DboTvpInsertFileName As String

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) As List(Of CjOiItem) Implements IDaoChild(Of CjOiItem).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "ApOpenInvoiceIdNo," &
                    "Balance," &
                    "CadIdNo," &
                    "DiscountTaken," &
                    "IdNo," &
                    "InvoiceNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "PreviousBalance," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE CadIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = _db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, cadIdNo As Int32) As Integer _
            Implements IDaoChild(Of CjOiItem).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", cadIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of CjOiItem).InsertTvp
            Return _db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
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

        Public Function GetOpenInvoices(idNo As Int32) _
            As List(Of CjOiItem) Implements IDaoOiItem(Of CjOiItem).GetOpenInvoices
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