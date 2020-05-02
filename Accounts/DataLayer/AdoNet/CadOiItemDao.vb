Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CadOiItem
    ' ** DAO Pattern

    Public Class CadOiItemDao
        Inherits CommonDao
        Implements IDaoChild(Of CadOiItem), IDaoOiItem(Of CadOiItem)

        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Protected TableFileName As String = "CadOiItem_View"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateCadOiItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertCadOiItemTVP"

        Public Function GetRecordsWithIdNo(idNo As Int32, Optional sortExpression As String = Nothing) As List(Of CadOiItem) Implements IDaoChild(Of CadOiItem).GetRecordsWithIdNo
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Amount," &
                    "Balance," &
                    "CadIdNo," &
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
                    " WHERE CadIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, cadIdNo As Int32) As Integer _
            Implements IDaoChild(Of CadOiItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", cadIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of CadOiItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CadOiItem) =
                                    Function(reader) _
            New CadOiItem() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .CadIdNo = Extensions.AsString(reader("CadIdNo")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .JournalCode = Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = Extensions.AsId(Of Int32)(reader("JournalIdNo")),
            .JournalItemIdNo = Extensions.AsId(Of Int32)(reader("JournalItemIdNo")),
            .OpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("OpenInvoiceIdNo")),
            .PreviousBalance = Extensions.AsDecimal(reader("PreviousBalance")),
            .Sequence = Extensions.AsInt(Of Integer)(reader("sequence")),
            .TransactionDate = Extensions.AsDate((reader("TransactionDate")))
            }

        '' ReSharper disable once UnusedMember.Local
        'Private Function Take(cadOiItem As CadOiItem) As Object()
        '    Return New Object() {
        '                            "@AccountIdNo", cadOiItem.AccountIdNo,
        '                            "@Amount", cadOiItem.Amount,
        '                            "@Balance", cadOiItem.Balance,
        '                            "@CadIdNo", cadOiItem.CadIdNo,
        '                            "@DiscountTaken", cadOiItem.DiscountTaken,
        '                            "@IdNo", cadOiItem.IdNo,
        '                            "@InvoiceNo", cadOiItem.InvoiceNo,
        '                            "@JournalItemIdNo", cadOiItem.JournalItemIdNo,
        '                            "@OpenInvoiceIdNo", cadOiItem.OpenInvoiceIdNo,
        '                            "@PreviousBalance", cadOiItem.PreviousBalance,
        '                            "@Sequence", cadOiItem.Sequence,
        '                            "@TransactionDate", cadOiItem.TransactionDate
        '                         }
        'End Function

        Public Function GetOpenInvoices(idNo As Int32) _
            As List(Of CadOiItem) Implements IDaoOiItem(Of CadOiItem).GetOpenInvoices
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
            Dim x = Db.Read(sql, MakeCadOiItem).ToList()
            Return x
        End Function

        Public Shared ReadOnly MakeCadOiItem As Func(Of IDataReader, CadOiItem) = Function(reader) New CadOiItem() With
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