Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet

    Public Class DaoAccounts
        Inherits CommonDao
        Implements IDaoAccounts

        Private ReadOnly _db As New Db()

        'Public Function GetSupplierOpenInvoices(Of TM As New)(idNo As Int32) As List(Of TM) Implements IDaoAccounts.GetSupplierOpenInvoices
        '    Dim sql As String =
        '            "SELECT " &
        '            "AccountIdNo," &
        '            "Balance," &
        '            "IdNo," &
        '            "InvoiceNo," &
        '            "JournalCode," &
        '            "JournalIdNo," &
        '            "JournalItemIdNo," &
        '            "TransactionDate" &
        '            " FROM ApOpenInvoice_View " &
        '            " WHERE Balance <> 0 and SupplierIdNo = " & idNo.ToString() &
        '            " ORDER BY TransactionDate"
        '    Dim x = _db.Read(sql, _makeCadOiItem(Of TM)).ToList()
        '    Return x
        'End Function

        'Private ReadOnly _makeCadOiItem(Of TM) As Func(Of IDataReader, TM) = Function(reader) New TM With
        '    {
        '    .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
        '    .Balance = Extensions.AsDecimal(reader("Balance")),
        '    .OpenInvoiceIdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
        '    .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
        '    .JournalCode = Extensions.AsString(reader("JournalCode")),
        '    .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
        '    .JournalItemIdNo = Extensions.AsInt(Of Integer)(reader("JournalItemIdNo")),
        '    .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
        '    }

    End Class

End Namespace