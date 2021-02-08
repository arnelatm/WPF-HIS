Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayrollEarnAccount
    ' ** DAO Pattern

    Public Class PayrollEarnAccountDao
        Inherits AccountsDao
        Implements IDaoChild(Of PayrollEarnAccount)

        Private ReadOnly _db As New Db()
        Protected TableFileName As String = ""
        Protected DboTvpInsertFileName As String = ""
        Protected DboTvpUpdateFileName As String = ""

        Public Sub New()
            TableFileName = "PayrollEarnAccount_View"
            DboTvpUpdateFileName = "dbo.UpdatePayrollEarnAccountTVP"
            DboTvpInsertFileName = "dbo.InsertPayrollEarnAccountTVP"
        End Sub

        Public Function GetRecordsWithIdNo(earningIdNo, Optional sortKey = Nothing) As List(Of PayrollEarnAccount) Implements IDaoChild(Of PayrollEarnAccount).GetRecordsWithIdNo
            If sortKey Is Nothing Then
                sortKey = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "AccountName," &
                    "EarningIdNo," &
                    "IdNo," &
                    "PayGroupIdNo," &
                    "PayGroupName," &
                    "Sequence" &
                    " FROM " & TableFileName &
                    " WHERE EarningIdNo = @EarningIdNo" &
                    " ORDER BY " & sortKey
            Dim params() As Object = {"@EarningIdNo", earningIdNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, earningIdNo As Int32) As Integer _
            Implements IDaoChild(Of PayrollEarnAccount).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", earningIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
            Implements IDaoChild(Of PayrollEarnAccount).InsertTvp
            Return _db.InsertTvp(DboTvpInsertFileName, tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayrollEarnAccount) =
                                    Function(reader) _
            New PayrollEarnAccount() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .AccountName = Extensions.AsString(reader("AccountName")),
            .EarningIdNo = Extensions.AsInt(Of Int16)(reader("EarningIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayGroupIdNo = Extensions.AsInt(Of Int16)(reader("PayGroupIdNo")),
            .PayGroupName = Extensions.AsString(reader("PayGroupName")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("Sequence"))
            }

    End Class

End Namespace