
Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer.AdoNet


Namespace DataLayer.AdoNet
    ' Data access object for RevenueGroup
    ' ** DAO Pattern

    Public Class RevenueGroupDao
        Inherits CommonDao
        Implements IRevenueGroupDao

        Private Shared ReadOnly Db As New Db()

        Public Function GetRecordById(idNo As Integer) As RevenueGroup Implements IRevenueGroupDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, ParentIdNo, RevenueGroupCode, RevenueGroupName, RevenueGroupNameAra, LevelNumber, Notes, SortKey" &
                    "   FROM [RevenueGroup_View]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "SortKey") As List(Of RevenueGroup) _
            Implements IRevenueGroupDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, ParentIdNo, RevenueGroupCode, RevenueGroupName, RevenueGroupNameAra, LevelNumber, Notes, SortKey" &
                    "   FROM [RevenueGroup_View] order by sortKey"
            Return Db.Read(sql, Make).ToList()
        End Function

        'Public Function GetAll(Optional sortExpression As String = "RevenueGroupName ASC") As List(Of RevenueGroup) _
        '    Implements IRevenueGroupDao.GetAll
        '    Dim sql As String =
        '            " SELECT IDNo, ParentIdNo, RevenueGroupCode, RevenueGroupName, RevenueGroupNameAra, LevelNumber, Notes, SortKey" &
        '            "   FROM [RevenueGroup] " & "order by " & sortExpression
        '    Return Db.Read(sql, Make).ToList()
        'End Function

        Public Function UpdateRecord(ByRef revenueGroup As RevenueGroup) As Integer Implements IRevenueGroupDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [RevenueGroup]" &
                    "    SET ParentIdNo = @ParentIdNo," &
                    "        RevenueGroupCode = @RevenueGroupCode," &
                    "        RevenueGroupName = @RevenueGroupName," &
                    "        RevenueGroupNameAra = @RevenueGroupNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(revenueGroup))
        End Function

        Public Function AddRecord(ByRef revenueGroup As RevenueGroup) As Integer Implements IRevenueGroupDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [RevenueGroup] " &
                    " (ParentIdNo,RevenueGroupCode,RevenueGroupName,RevenueGroupNameAra,Notes) " &
                    " VALUES (@ParentIdNo,@RevenueGroupCode,@RevenueGroupName,@RevenueGroupNameAra,@Notes)"
            Return Db.Insert(sql, Take(revenueGroup))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, RevenueGroup) =
                                    Function(reader) _
            New RevenueGroup() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .ParentIdNo = Extensions.AsNullableInt(Of Integer)(reader("ParentIdNo")),
            .RevenueGroupCode = Extensions.AsString(reader("RevenueGroupCode")),
            .RevenueGroupName = Extensions.AsString(reader("RevenueGroupName")),
            .RevenueGroupNameAra = Extensions.AsString(reader("RevenueGroupNameAra")),
            .LevelNumber = Extensions.AsInt(Of Short)(reader("LevelNumber")),
            .Notes = Extensions.AsString(reader("Notes")),
            .SortKey = Extensions.AsString(reader("SortKey"))
            }

        Private Function Take(revenueGroup As RevenueGroup) As Object()
            Return New Object() {
                                    "@IDNo", revenueGroup.IdNo,
                                    "@ParentIdNo", revenueGroup.ParentIdNo,
                                    "@RevenueGroupCode", revenueGroup.RevenueGroupCode,
                                    "@RevenueGroupName", revenueGroup.RevenueGroupName,
                                    "@RevenueGroupNameAra", revenueGroup.RevenueGroupNameAra,
                                    "@LevelNumber", revenueGroup.LevelNumber,
                                    "@Notes", revenueGroup.Notes,
                                    "@SortKey", revenueGroup.SortKey
                                }
        End Function

    End Class

End Namespace