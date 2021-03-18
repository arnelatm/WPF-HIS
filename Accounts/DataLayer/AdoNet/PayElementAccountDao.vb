Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayElementAccount
    ' ** DAO Pattern

    Public Class PayElementAccountDao
        Inherits AccountsDao
        Implements IDaoChild(Of PayElementAccount)

        Private ReadOnly _db As New Db()
        Protected TableFileName As String = ""
        Protected DboTvpInsertFileName As String = ""
        Protected DboTvpUpdateFileName As String = ""

        Public Sub New()
            TableFileName = "PayElementAccount_View"
            DboTvpUpdateFileName = "dbo.UpdatePayElementAccountTVP"
            DboTvpInsertFileName = "dbo.InsertPayElementAccountTVP"
        End Sub

        Public Function GetRecordsWithGroupIdNo(PayElementIdNo, Optional sortKey = Nothing) As List(Of PayElementAccount) Implements IDaoChild(Of PayElementAccount).GetRecordsWithGroupIdNo
            If sortKey Is Nothing Then
                sortKey = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "AccountName," &
                    "PayElementIdNo," &
                    "IdNo," &
                    "PayGroupIdNo," &
                    "PayGroupName," &
                    "Sequence" &
                    " FROM " & TableFileName &
                    " WHERE PayElementIdNo = @PayElementIdNo" &
                    " ORDER BY " & sortKey
            Dim params() As Object = {"@PayElementIdNo", PayElementIdNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, PayElementIdNo As Int32) As Integer _
            Implements IDaoChild(Of PayElementAccount).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", PayElementIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
            Implements IDaoChild(Of PayElementAccount).InsertTvp
            Return _db.InsertTvp(DboTvpInsertFileName, tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayElementAccount) =
                                    Function(reader) _
            New PayElementAccount() With {
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .AccountName = Extensions.AsString(reader("AccountName")),
            .PayElementIdNo = Extensions.AsInt(Of Int16)(reader("PayElementIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayGroupIdNo = Extensions.AsInt(Of Int16)(reader("PayGroupIdNo")),
            .PayGroupName = Extensions.AsString(reader("PayGroupName")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("Sequence"))
            }

    End Class

End Namespace