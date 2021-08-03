Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayElementItem
    ' ** DAO Pattern

    Public Class PayElementItemDao
        Inherits AccountsDao
        Implements IDaoChild(Of PayElementItem), IDaoTvp(Of PayElementItem)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PayElementItem) Implements IDaoChild(Of PayElementItem).GetRecordsWithGroupIdNo
            Dim sql As String =
                    "SELECT " &
                    "FactorType," &
                    "FactorValue," &
                    "IdNo," &
                    "ParentIdNo," &
                    "PayElementIdNo," &
                    "Sequence" &
                    " FROM [PayElementItem]" &
                    " WHERE ParentIdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PayElementItem).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdatePayElementItemTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PayElementItem).InsertTvp
            Return Db.InsertTvp("InsertPayElementItemTVP", tvpTable)
        End Function

        Public Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, ByVal groupIdNo As Integer) As Integer Implements IDaoTvp(Of PayElementItem).UpdateInsertTvp
            Return Db.UpdateInsertTvp("UpdateInsertPayElementItemTVP", updateTvpTable, insertTvpTable, groupIdNo)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayElementItem) =
                                    Function(reader) _
            New PayElementItem() With {
            .FactorType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("FactorType")),
            .FactorValue = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("FactorValue")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .ParentIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("ParentIdNo")),
            .PayElementIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayElementIdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence"))
            }

    End Class

End Namespace