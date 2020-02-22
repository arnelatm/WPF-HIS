Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for DistributionSchemeItem
    ' ** DAO Pattern

    Public Class DistributionSchemeItemDao
        Inherits CommonDaoOld
        Implements IDistributionSchemeItemDao

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String
        Protected DboTvpUpdateFileName As String
        Protected DboTvpInsertFileName As String

        Public Sub New()
            DbCommon = Db
            TableFileName = "DistributionSchemeItem"
            DboTvpUpdateFileName = "dbo.UpdateDistributionSchemeItemTVP"
            DboTvpInsertFileName = "dbo.InsertDistributionSchemeItemTVP"
        End Sub

        Public Function GetRecordById(idNo As Integer) As DistributionSchemeItem Implements IDistributionSchemeItemDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, DistributionSchemeIdNo, Sequence, ProfitCenterIdNo, Percentage" &
                    "   FROM " & TableFileName &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetDistributionSchemeItems(distributionSchemeIdNo As Integer) As List(Of DistributionSchemeItem)
            Dim sql As String =
                    " SELECT IdNo, DistributionSchemeIdNo, Sequence, ProfitCenterIdNo, Percentage " &
                    "   FROM " & TableFileName &
                    "  WHERE DistributionSchemeIdNo = @DistributionSchemeIdNo" &
                    "  ORDER BY Sequence"
            Dim params() As Object = {"@DistributionSchemeIdNo", distributionSchemeIdNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of DistributionSchemeItem) _
            Implements IDistributionSchemeItemDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, DistributionSchemeIdNo,  " &
                    "   FROM " & TableFileName & " order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = "Sequence") _
            As List(Of DistributionSchemeItem)
            Dim sql As String =
                    " SELECT IDNo, DistributionSchemeIdNo, Sequence, ProfitCenterIdNo, Percentage" &
                    "   FROM " & TableFileName &
                    "  WHERE DistributionSchemeIdNo = " & idNo &
                    "  ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, distributionSchemeItemIdNo As Integer) As Integer _
            Implements IDistributionSchemeItemDao.DelUpdateTvp
            Return Db.TvpDelUpdate(DboTvpUpdateFileName, tvpTable, "@MParam", distributionSchemeItemIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDistributionSchemeItemDao.InsertTvp
            Return Db.TvpInsert(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DistributionSchemeItem) =
                                    Function(reader) _
            New DistributionSchemeItem() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .DistributionSchemeIdNo = Extensions.AsInt(Of Integer)(reader("DistributionSchemeIdNo")),
            .Sequence = Extensions.AsInt(Of Integer)(reader("Sequence")),
            .ProfitCenterIdNo = Extensions.AsInt(Of Integer)(reader("ProfitCenterIdNo")),
            .Percentage = Extensions.AsString(reader("Percentage"))
            }

        Private Function Take(distributionSchemeItem As DistributionSchemeItem) As Object()
            Return New Object() {
                                    "@IDNo", distributionSchemeItem.IdNo,
                                    "@DistributionSchemeIdNo", distributionSchemeItem.DistributionSchemeIdNo,
                                    "@Sequence", distributionSchemeItem.Sequence,
                                    "@ProfitCenterIdNo", distributionSchemeItem.ProfitCenterIdNo,
                                    "@Percentage", distributionSchemeItem.Percentage
                                }
        End Function

    End Class

End Namespace