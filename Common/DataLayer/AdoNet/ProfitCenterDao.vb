Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ProfitCenter
    ' ** DAO Pattern

    Public Class ProfitCenterDao
        Inherits CommonDao
        Implements IDaoAll(Of ProfitCenter)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo As Integer) As ProfitCenter Implements IDaoAll(Of ProfitCenter).GetRecordById
            Dim sql As String =
                    " SELECT IDNo, ParentIdNo, ProfitCenterCode, ProfitCenterName, ProfitCenterNameAra, ProfitCenterType, LevelNumber, Notes, SortKey" &
                    "   FROM [ProfitCenter_View]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of ProfitCenter) _
            Implements IDaoAll(Of ProfitCenter).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "SortKey"
            End If
            Dim sql As String =
                    " SELECT IDNo, ParentIdNo, ProfitCenterCode, ProfitCenterName, ProfitCenterNameAra, ProfitCenterType, LevelNumber, Notes, SortKey" &
                    "   FROM [ProfitCenter_View] order by '" + sortExpression + "'"
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef profitCenter As ProfitCenter) As Integer Implements IDaoAll(Of ProfitCenter).UpdateRecord
            Dim sql As String =
                    " UPDATE [ProfitCenter]" &
                    "    SET ParentIdNo = @ParentIdNo," &
                    "        ProfitCenterCode = @ProfitCenterCode," &
                    "        ProfitCenterName = @ProfitCenterName," &
                    "        ProfitCenterNameAra = @ProfitCenterNameAra," &
                    "        ProfitCenterType = @ProfitCenterType," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return _db.Update(sql, Take(profitCenter))
        End Function

        Public Function AddRecord(ByRef profitCenter As ProfitCenter) As Integer Implements IDaoAll(Of ProfitCenter).AddRecord
            Dim sql As String =
                    " INSERT INTO [ProfitCenter] " &
                    " (ParentIdNo,ProfitCenterCode,ProfitCenterName,ProfitCenterType,ProfitCenterNameAra,Notes) " &
                    " VALUES (@ParentIdNo,@ProfitCenterCode,@ProfitCenterName,@ProfitCenterType,@ProfitCenterNameAra,@Notes)"
            Return _db.Insert(sql, Take(profitCenter))
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