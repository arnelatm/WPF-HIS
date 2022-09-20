Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CodeGroup
    ' ** DAO Pattern

    Public Class CodeGroupDao
        Inherits CommonDao
        Implements IDao(Of CodeGroup)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As CodeGroup Implements IDao(Of CodeGroup).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, CodeGroupCode, CodeGroupName, CodeGroupNameAra, Notes" &
                    "   FROM [CodeGroup]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef CodeGroup As CodeGroup) As Integer Implements IDao(Of CodeGroup).UpdateRecord
            Dim sql As String =
                    " UPDATE [CodeGroup]" &
                    "    SET CodeGroupCode = @CodeGroupCode," &
                    "        CodeGroupName = @CodeGroupName," &
                    "        CodeGroupNameAra = @CodeGroupNameAra," &
                    "        Notes = @Notes " &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(CodeGroup))
        End Function

        Public Function AddRecord(ByRef CodeGroup As CodeGroup) As Integer Implements IDao(Of CodeGroup).AddRecord
            Dim sql As String =
                    " INSERT INTO [CodeGroup] " &
                    " (CodeGroupCode,CodeGroupName,CodeGroupNameAra,Notes) " &
                    " VALUES (@CodeGroupCode,@CodeGroupName,@CodeGroupNameAra,@Notes) "
            Return Db.Insert(sql, Take(CodeGroup))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CodeGroup) =
                                    Function(reader) _
            New CodeGroup() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .CodeGroupCode = Extensions.AsString(reader("CodeGroupCode")),
            .CodeGroupName = Extensions.AsString(reader("CodeGroupName")),
            .CodeGroupNameAra = Extensions.AsString(reader("CodeGroupNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(CodeGroup As CodeGroup) As Object()
            Return New Object() {
                                    "@CodeGroupCode", CodeGroup.CodeGroupCode,
                                    "@CodeGroupName", CodeGroup.CodeGroupName,
                                    "@CodeGroupNameAra", CodeGroup.CodeGroupNameAra,
                                    "@IdNo", CodeGroup.IdNo,
                                    "@Notes", CodeGroup.Notes
                                }
        End Function

    End Class

End Namespace