Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayGroup
    ' ** DAO Pattern

    Public Class PayGroupDao
        Inherits CommonDao
        Implements IDaoAll(Of PayGroup)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As PayGroup Implements IDaoAll(Of PayGroup).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, PayGroupCode, PayGroupName, PayGroupNameAra, ParentIdNo, Notes " &
                    "   FROM [PayGroup_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of PayGroup) _
            Implements IDaoAll(Of PayGroup).GetAll
            If sortExpression = Nothing Then
                sortExpression = "PayGroupName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, PayGroupCode, PayGroupName, PayGroupNameAra" &
                    "   FROM [PayGroup] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef PayGroup As PayGroup) As Integer Implements IDaoAll(Of PayGroup).UpdateRecord
            Dim sql As String =
                    " UPDATE [PayGroup]" &
                    " SET PayGroupCode = @PayGroupCode," &
                    " PayGroupName = @PayGroupName," &
                    " PayGroupNameAra = @PayGroupNameAra," &
                    " ParentIdNo = @ParentIdNo," &
                    " Notes = @Notes" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(PayGroup))
        End Function

        Public Function AddRecord(ByRef PayGroup As PayGroup) As Integer Implements IDaoAll(Of PayGroup).AddRecord
            Dim sql As String =
                    " INSERT INTO [PayGroup] " &
                    " (PayGroupCode,PayGroupName,PayGroupNameAra,ParentIdNo,Notes) " &
                    " VALUES (@PayGroupCode,@PayGroupName,@PayGroupNameAra,@ParentIdNo,@Notes) "
            Return Db.Insert(sql, Take(PayGroup))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayGroup) =
                                    Function(reader) _
            New PayGroup() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .PayGroupCode = Extensions.AsString(reader("PayGroupCode")),
            .PayGroupName = Extensions.AsString(reader("PayGroupName")),
            .PayGroupNameAra = Extensions.AsString(reader("PayGroupNameAra")),
            .ParentIdNo = Extensions.AsNullable(Of Int16?)(reader("ParentIdNo"))
            }

        Private Function Take(PayGroup As PayGroup) As Object()
            Return New Object() {
                                    "@IdNo", PayGroup.IdNo,
                                    "@PayGroupCode", PayGroup.PayGroupCode,
                                    "@PayGroupName", PayGroup.PayGroupName,
                                    "@PayGroupNameAra", PayGroup.PayGroupNameAra,
                                    "@ParentIdNo", PayGroup.ParentIdNo,
                                    "@Notes", PayGroup.Notes
                                }
        End Function

    End Class

End Namespace