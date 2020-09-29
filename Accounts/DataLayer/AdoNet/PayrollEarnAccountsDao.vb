Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayrollEarnAccount
    ' ** DAO Pattern

    Public Class PayrollEarnAccountDao
        Inherits DaoAccounts
        Implements IDaoChild(Of PayrollEarnAccount)

        Protected DboTvpInsertFileName As String = ""
        Protected DboTvpUpdateFileName As String = ""
        Protected TableFileName As String = "PayrollEarnAccount_View"

        Private Shared ReadOnly Make As Func(Of IDataReader, PayrollEarnAccount) =
                                    Function(reader) _
            New PayrollEarnAccount() With {
            .EarningIdNo = Extensions.AsInt(Of Int16)(reader("EarningIdNo")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .PayGroupIdNo = Extensions.AsInt(Of Int16)(reader("PayGroupIdNo")),
            .PayGroupName = Extensions.AsString(reader("PayGroupName")),
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("PayGroupIdNo")),
            .AccountName = Extensions.AsString(reader("AccountName"))
            }

        Private ReadOnly _db As New Db()

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, PayrollEarnAccountIdNo As Int32) As Integer _
            Implements IDaoChild(Of PayrollEarnAccount).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", PayrollEarnAccountIdNo)
        End Function

        Public Function GetRecordsWithIdNo(earningIdNo As Int32, Optional sortKey As String = Nothing) As List(Of PayrollEarnAccount) Implements IDaoChild(Of PayrollEarnAccount).GetRecordsWithIdNo
            If sortKey Is Nothing Then
                sortKey = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "EarningIdNo," &
                    "PayGroupIdNo," &
                    "PayGroupName," &
                    "AccountIdNo," &
                    "AccountName" &
                    " FROM " & TableFileName &
                    " WHERE EarningIdNo = @EarningIdNo" &
                    " ORDER BY " & sortKey
            Dim params() As Object = {"@EarningIdNo", earningIdNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
            Implements IDaoChild(Of PayrollEarnAccount).InsertTvp
            Return _db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

    End Class

End Namespace