Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayGroup
    ' ** DAO Pattern

    Public Class PayGroupDao
        Inherits CommonDao
        Implements IDaoAll(Of PayGroup)

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As PayGroup Implements IDaoAll(Of PayGroup).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, ParentIdNo, PayGroupCode, PayGroupName, PayGroupNameAra, LevelNumber, Notes, SortKey" &
                    "   FROM PayGroup_View " &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of PayGroup) _
            Implements IDaoAll(Of PayGroup).GetAll
            If sortExpression = Nothing Then
                sortExpression = "SortKey ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, ParentIdNo, PayGroupCode, PayGroupName, PayGroupNameAra, LevelNumber, Notes, SortKey" &
                    "   FROM PayGroup_View order by sortKey"
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef PayGroup As PayGroup) As Integer _
            Implements IDaoAll(Of PayGroup).UpdateRecord
            Dim sql As String =
                    " UPDATE [PayGroup]" &
                    "    SET ParentIdNo = @ParentIdNo," &
                    "        PayGroupCode = @PayGroupCode," &
                    "        PayGroupName = @PayGroupName," &
                    "        PayGroupNameAra = @PayGroupNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo"

            Return _db.Update(sql, Take(PayGroup))
        End Function

        Public Function AddRecord(ByRef PayGroup As PayGroup) As Integer Implements IDaoAll(Of PayGroup).AddRecord
            Dim sql As String =
                    " INSERT INTO [PayGroup] " &
                    " (ParentIdNo,PayGroupCode,PayGroupName,PayGroupNameAra,Notes) " &
                    " VALUES (@ParentIdNo,@PayGroupCode,@PayGroupName,@PayGroupNameAra,@Notes)"
            Return _db.Insert(sql, Take(PayGroup))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayGroup) =
                                    Function(reader) _
            New PayGroup() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ParentIdNo = Extensions.AsNullable(Of Int32?)(reader("ParentIdNo")),
            .PayGroupCode = Extensions.AsString(reader("PayGroupCode")),
            .PayGroupName = Extensions.AsString(reader("PayGroupName")),
            .PayGroupNameAra = Extensions.AsString(reader("PayGroupNameAra")),
            .LevelNumber = Extensions.AsInt(Of Short)(reader("LevelNumber")),
            .Notes = Extensions.AsString(reader("Notes")),
            .SortKey = Extensions.AsString(reader("SortKey"))
            }

        Private Function Take(PayGroup As PayGroup) As Object()
            Return New Object() {
                                    "@IdNo", PayGroup.IdNo,
                                    "@ParentIdNo", PayGroup.ParentIdNo,
                                    "@PayGroupCode", PayGroup.PayGroupCode,
                                    "@PayGroupName", PayGroup.PayGroupName,
                                    "@PayGroupNameAra", PayGroup.PayGroupNameAra,
                                    "@LevelNumber", PayGroup.LevelNumber,
                                    "@Notes", PayGroup.Notes,
                                    "@SortKey", PayGroup.SortKey
                                }
        End Function

    End Class

End Namespace