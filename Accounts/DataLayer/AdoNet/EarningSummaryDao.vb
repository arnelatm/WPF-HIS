Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for EarningSummary
    ' ** DAO Pattern

    Public Class EarningSummaryDao
        Inherits AccountsDao
        Implements IDaoChild(Of EarningSummary), IDaoTvp(Of EarningSummary)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of EarningSummary) Implements IDaoChild(Of EarningSummary).GetRecordsWithGroupIdNo
            Dim sql As String =
                    "SELECT " &
                    "EarningSummaryIdNo," &
                    "EarningIdNo," &
                    "IdNo," &
                    "FactorValue" &
                    " FROM [EarningSummary]" &
                    " WHERE EarningSummaryIdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EarningSummary).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateEarningSummaryTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EarningSummary).InsertTvp
            Return Db.InsertTvp("InsertEarningSummaryTVP", tvpTable)
        End Function

        Public Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, ByVal groupIdNo As Integer) As Integer Implements IDaoTvp(Of EarningSummary).UpdateInsertTvp
            Return Db.UpdateInsertTvp("UpdateInsertEarningSummaryTVP", updateTvpTable, insertTvpTable, groupIdNo)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EarningSummary) =
                                    Function(reader) _
            New EarningSummary() With {
            .EarningSummaryIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("EarningSummaryIdNo")),
            .EarningIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("EarningIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .FactorValue = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("FactorValue"))
           }

    End Class

End Namespace