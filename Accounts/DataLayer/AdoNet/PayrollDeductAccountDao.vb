Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayrollDeductAccount
    ' ** DAO Pattern

    Public Class PayrollDeductAccountDao
        Inherits DaoAccounts
        Implements IDaoChild(Of PayrollDeductAccount)

        Private ReadOnly _db As New Db()
        Protected TableFileName As String = ""
        Protected DboTvpInsertFileName As String = ""
        Protected DboTvpUpdateFileName As String = ""

        Public Sub New()
            TableFileName = "PayrollDeductAccount_View"
            DboTvpUpdateFileName = "dbo.UpdatePayrollDeductAccountTVP"
            DboTvpInsertFileName = "dbo.InsertPayrollDeductAccountTVP"
        End Sub

        Public Function GetRecordsWithIdNo(deductionIdNo, Optional sortKey = Nothing) As List(Of PayrollDeductAccount) Implements IDaoChild(Of PayrollDeductAccount).GetRecordsWithIdNo
            If sortKey Is Nothing Then
                sortKey = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "AccountName," &
                    "DeductionIdNo," &
                    "IdNo," &
                    "PayGroupIdNo," &
                    "PayGroupName," &
                    "Sequence" &
                    " FROM " & TableFileName &
                    " WHERE DeductionIdNo = @DeductionIdNo" &
                    " ORDER BY " & sortKey
            Dim params() As Object = {"@DeductionIdNo", deductionIdNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, deductionIdNo As Int32) As Integer _
            Implements IDaoChild(Of PayrollDeductAccount).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", deductionIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
            Implements IDaoChild(Of PayrollDeductAccount).InsertTvp
            Return _db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayrollDeductAccount) =
                                    Function(reader) _
            New PayrollDeductAccount() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .AccountName = Extensions.AsString(reader("AccountName")),
            .DeductionIdNo = Extensions.AsInt(Of Int16)(reader("DeductionIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayGroupIdNo = Extensions.AsInt(Of Int16)(reader("PayGroupIdNo")),
            .PayGroupName = Extensions.AsString(reader("PayGroupName")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("Sequence"))
            }

    End Class

End Namespace