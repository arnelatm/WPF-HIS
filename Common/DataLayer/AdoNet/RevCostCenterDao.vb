Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for RevCostCenter
    ' ** DAO Pattern

    Public Class RevCostCenterDao
        Inherits CommonDao
        Implements IDaoAll(Of RevCostCenter)

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As RevCostCenter Implements IDaoAll(Of RevCostCenter).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, ParentIdNo, RevCostCenterCode, RevCostCenterName, RevCostCenterNameAra, RCType, LevelNumber, Notes, SortKey" &
                    "   FROM [RevCostCenter_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of RevCostCenter) _
            Implements IDaoAll(Of RevCostCenter).GetAll
            If sortExpression = Nothing Then
                sortExpression = "SortKey ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, ParentIdNo, RevCostCenterCode, RevCostCenterName, RevCostCenterNameAra, RCType, LevelNumber, Notes, SortKey" &
                    "   FROM [RevCostCenter_View] order by sortKey"
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef RevCostCenter As RevCostCenter) As Integer _
            Implements IDaoAll(Of RevCostCenter).UpdateRecord
            Dim sql As String =
                    " UPDATE [RevCostCenter]" &
                    "    SET ParentIdNo = @ParentIdNo," &
                    "        RevCostCenterCode = @RevCostCenterCode," &
                    "        RevCostCenterName = @RevCostCenterName," &
                    "        RevCostCenterNameAra = @RevCostCenterNameAra," &
                    "        RCType = @RCType," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo"

            Return _db.Update(sql, Take(RevCostCenter))
        End Function

        Public Function AddRecord(ByRef RevCostCenter As RevCostCenter) As Integer Implements IDaoAll(Of RevCostCenter).AddRecord
            Dim sql As String =
                    " INSERT INTO [RevCostCenter] " &
                    " (ParentIdNo,RevCostCenterCode,RevCostCenterName,RevCostCenterNameAra,RCType,Notes) " &
                    " VALUES (@ParentIdNo,@RevCostCenterCode,@RevCostCenterName,@RevCostCenterNameAra,@RCType,@Notes)"
            Return _db.Insert(sql, Take(RevCostCenter))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, RevCostCenter) =
                                    Function(reader) _
            New RevCostCenter() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ParentIdNo = Extensions.AsNullable(Of Int32?)(reader("ParentIdNo")),
            .RevCostCenterCode = Extensions.AsString(reader("RevCostCenterCode")),
            .RevCostCenterName = Extensions.AsString(reader("RevCostCenterName")),
            .RevCostCenterNameAra = Extensions.AsString(reader("RevCostCenterNameAra")),
            .RCType = Extensions.AsString(reader("RCType")),
            .LevelNumber = Extensions.AsInt(Of Short)(reader("LevelNumber")),
            .Notes = Extensions.AsString(reader("Notes")),
            .SortKey = Extensions.AsString(reader("SortKey"))
            }

        Private Function Take(RevCostCenter As RevCostCenter) As Object()
            Return New Object() {
                                    "@IdNo", RevCostCenter.IdNo,
                                    "@ParentIdNo", RevCostCenter.ParentIdNo,
                                    "@RevCostCenterCode", RevCostCenter.RevCostCenterCode,
                                    "@RevCostCenterName", RevCostCenter.RevCostCenterName,
                                    "@RevCostCenterNameAra", RevCostCenter.RevCostCenterNameAra,
                                    "@RCType", RevCostCenter.RCType,
                                    "@LevelNumber", RevCostCenter.LevelNumber,
                                    "@Notes", RevCostCenter.Notes,
                                    "@SortKey", RevCostCenter.SortKey
                                }
        End Function

    End Class

End Namespace