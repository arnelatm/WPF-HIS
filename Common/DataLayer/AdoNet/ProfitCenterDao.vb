
Imports AATM.DataLayer.AdoNet
Imports AATM.Common.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for ProfitCenter
    ' ** DAO Pattern

    Public Class ProfitCenterDao
        Inherits CommonDao
        Implements IProfitCenterDao

        Private Shared ReadOnly Db As New Db()
        
        Public Function GetRecordById(idNo As Integer) As ProfitCenter Implements IProfitCenterDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, ParentIdNo, ProfitCenterCode, ProfitCenterName, ProfitCenterNameAra, ProfitCenterType, LevelNumber, Notes, SortKey" &
                    "   FROM [ProfitCenter_View]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "SortKey") As List(Of ProfitCenter) _
            Implements IProfitCenterDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, ParentIdNo, ProfitCenterCode, ProfitCenterName, ProfitCenterNameAra, ProfitCenterType, LevelNumber, Notes, SortKey" &
                    "   FROM [ProfitCenter_View] order by sortKey"
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef profitCenter As ProfitCenter) As Integer Implements IProfitCenterDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [ProfitCenter]" &
                    "    SET ParentIdNo = @ParentIdNo," &
                    "        ProfitCenterCode = @ProfitCenterCode," &
                    "        ProfitCenterName = @ProfitCenterName," &
                    "        ProfitCenterNameAra = @ProfitCenterNameAra," &
                    "        ProfitCenterType = @ProfitCenterType," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(profitCenter))
        End Function

        Public Function AddRecord(ByRef profitCenter As ProfitCenter) As Integer Implements IProfitCenterDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [ProfitCenter] " &
                    " (ParentIdNo,ProfitCenterCode,ProfitCenterName,ProfitCenterType,ProfitCenterNameAra,Notes) " &
                    " VALUES (@ParentIdNo,@ProfitCenterCode,@ProfitCenterName,@ProfitCenterType,@ProfitCenterNameAra,@Notes)"
            Return Db.Insert(sql, Take(profitCenter))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ProfitCenter) =
                                    Function(reader) _
            New ProfitCenter() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .ParentIdNo = Extensions.AsNullableInt(Of Integer)(reader("ParentIdNo")),
            .ProfitCenterCode = Extensions.AsString(reader("ProfitCenterCode")),
            .ProfitCenterName = Extensions.AsString(reader("ProfitCenterName")),
            .ProfitCenterNameAra = Extensions.AsString(reader("ProfitCenterNameAra")),
            .ProfitCenterType = Extensions.AsString(reader("ProfitCenterType")),
            .LevelNumber = Extensions.AsInt(Of Short)(reader("LevelNumber")),
            .Notes = Extensions.AsString(reader("Notes")),
            .SortKey = Extensions.AsString(reader("SortKey"))
            }

        Private Function Take(profitCenter As ProfitCenter) As Object()
            Return New Object() {
                                    "@IDNo", profitCenter.IdNo,
                                    "@ParentIdNo", profitCenter.ParentIdNo,
                                    "@ProfitCenterCode", profitCenter.ProfitCenterCode,
                                    "@ProfitCenterName", profitCenter.ProfitCenterName,
                                    "@ProfitCenterNameAra", profitCenter.ProfitCenterNameAra,
                                    "@ProfitCenterType", profitCenter.ProfitCenterType,
                                    "@LevelNumber", profitCenter.LevelNumber,
                                    "@Notes", profitCenter.Notes,
                                    "@SortKey", profitCenter.SortKey
                                }
        End Function

    End Class

End Namespace