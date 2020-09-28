Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayrollEarnAccount
    ' ** DAO Pattern

    Public Class PayrollEarnAccountDao
        Inherits DaoAccounts
        Implements IDaoChild(Of PayrollEarnAccount)

        Private ReadOnly _db As New Db()
        Protected TableFileName As String = ""
        Protected DboTvpUpdateFileName As String = ""
        Protected DboTvpInsertFileName As String = ""

        Public Function GetRecordsWithIdNo(earningIdNo As Int32, Optional sortKey As String = Nothing) As List(Of PayrollEarnAccount) Implements IDaoChild(Of PayrollEarnAccount).GetRecordsWithIdNo
            If sortKey Is Nothing Then
                sortKey = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "EarningIdNo," &
                    "PayrollGroup," &
                    "Credit," &
                    "Debit," &
                    "DiscountTaken," &
                    "IdNo," &
                    "EarningIdNo," &
                    "Notes," &
                    "OpenInvoiceIdNo," &
                    "OriginalAmount," &
                    "PaidAmount," &
                    "PayeeType," &
                    "RevCostCenterIdNo," &
                    "Sequence," &
                    "SpecialAccount" &
                    " FROM " & TableFileName &
                    " WHERE EarningIdNo = @EarningIdNo" &
                    " ORDER BY " & sortKey
            Dim params() As Object = {"@EarningIdNo", earningIdNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, PayrollEarnAccountIdNo As Int32) As Integer _
            Implements IDaoChild(Of PayrollEarnAccount).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", PayrollEarnAccountIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
            Implements IDaoChild(Of PayrollEarnAccount).InsertTvp
            Return _db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayrollEarnAccount) =
                                    Function(reader) _
            New PayrollEarnAccount() With {

            .AccountName = Extensions.AsString(reader("AccountName")),
            .Credit = Extensions.AsDecimal(reader("Credit")),
            .DiscountTaken = Extensions.AsDecimal(reader("DiscountTaken")),
            .Debit = Extensions.AsDecimal(reader("Debit")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .EarningIdNo = Extensions.AsInt(Of Integer)(reader("EarningIdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OriginalAmount = Extensions.AsDecimal(reader("OriginalAmount")),
            .OpenInvoiceIdNo = Extensions.AsDecimal(reader("OpenInvoiceIdNo")),
            .PaidAmount = Extensions.AsDecimal(reader("PaidAmount")),
            .PayeeType = Extensions.AsString(reader("PayeeType")),
            .RevCostCenterIdNo = Extensions.AsInt(Of Integer)(reader("RevCostCenterIdNo")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("sequence")),
            .SpecialAccount = Extensions.AsString(reader("SpecialAccount"))
            }

    End Class

End Namespace