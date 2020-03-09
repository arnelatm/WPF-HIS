Imports AATM.DataLayer.AdoNet
Imports AATM.Common.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for CostCenter
    ' ** DAO Pattern

    Public Class CostCenterDao
        Inherits CommonDao
        Implements ICostCenterDao

        Private Shared ReadOnly Db As New Db()

        Public Function GetRecordById(idNo As Integer) As CostCenter Implements ICostCenterDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, ParentIdNo, CostCenterCode, CostCenterName, CostCenterNameAra, ProfitCenterIdNo, LevelNumber, Notes, SortKey" &
                    "   FROM [CostCenter_View]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "SortKey") As List(Of CostCenter) _
            Implements ICostCenterDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, ParentIdNo, CostCenterCode, CostCenterName, CostCenterNameAra, ProfitCenterIdNo, LevelNumber, Notes, SortKey" &
                    "   FROM [CostCenter_View] order by sortKey"
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef costCenter As CostCenter) As Integer Implements ICostCenterDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [CostCenter]" &
                    "    SET ParentIdNo = @ParentIdNo," &
                    "        CostCenterCode = @CostCenterCode," &
                    "        CostCenterName = @CostCenterName," &
                    "        CostCenterNameAra = @CostCenterNameAra," &
                    "        ProfitCenterIdNo = @ProfitCenterIdNo," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(costCenter))
        End Function

        Public Function AddRecord(ByRef costCenter As CostCenter) As Integer Implements ICostCenterDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [CostCenter] " &
                    " (ParentIdNo,CostCenterCode,CostCenterName,CostCenterNameAra,ProfitCenterIdNo,Notes) " &
                    " VALUES (@ParentIdNo,@CostCenterCode,@CostCenterName,@CostCenterNameAra,@ProfitCenterIdNo,@Notes)"
            Return Db.Insert(sql, Take(costCenter))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CostCenter) =
                                    Function(reader) _
            New CostCenter() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .ParentIdNo = Extensions.AsNullableInt(Of Integer)(reader("ParentIdNo")),
            .CostCenterCode = Extensions.AsString(reader("CostCenterCode")),
            .CostCenterName = Extensions.AsString(reader("CostCenterName")),
            .CostCenterNameAra = Extensions.AsString(reader("CostCenterNameAra")),
            .ProfitCenterIdNo = Extensions.AsInt(Of Int32)(reader("ProfitCenterIdNo")),
            .LevelNumber = Extensions.AsInt(Of Short)(reader("LevelNumber")),
            .Notes = Extensions.AsString(reader("Notes")),
            .SortKey = Extensions.AsString(reader("SortKey"))
            }

        Private Function Take(costCenter As CostCenter) As Object()
            Return New Object() {
                                    "@IDNo", costCenter.IdNo,
                                    "@ParentIdNo", costCenter.ParentIdNo,
                                    "@CostCenterCode", costCenter.CostCenterCode,
                                    "@CostCenterName", costCenter.CostCenterName,
                                    "@CostCenterNameAra", costCenter.CostCenterNameAra,
                                    "@ProfitCenterIdNo", costCenter.ProfitCenterIdNo,
                                    "@LevelNumber", costCenter.LevelNumber,
                                    "@Notes", costCenter.Notes,
                                    "@SortKey", costCenter.SortKey
                                }
        End Function

    End Class

End Namespace