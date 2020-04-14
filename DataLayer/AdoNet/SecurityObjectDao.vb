Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for SecurityObject
    ' ** DAO Pattern

    Public Class SecurityObjectDao
        Inherits BaseDao
        Implements IDaoAll(Of SecurityObject)

        Private ReadOnly Db As New Db()

        Private ReadOnly Make As Func(Of IDataReader, SecurityObject) =
                             Function(reader) _
            New SecurityObject() With {
            .IdNo = Extensions.AsId(reader("IdNo")),
            .ParentIdNo = Extensions.AsInt(Of Integer)(reader("ParentIdNo")),
            .SecurityObjectName = Extensions.AsString(reader("SecurityObjectName")),
            .SecurityObjectNameAra = Extensions.AsString(reader("SecurityObjectNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))}

        Private Function Take(securityObject As SecurityObject) As Object()
            Return New Object() {
                                    "@IdNo", securityObject.IdNo,
                                    "@ParentIdNo", securityObject.ParentIdNo,
                                    "@SecurityObjectName", securityObject.SecurityObjectName,
                                    "@SecurityObjectNameAra", securityObject.SecurityObjectNameAra,
                                    "@Notes", securityObject.Notes}
        End Function

        Public Function GetRecordById(idNo As Integer) As SecurityObject _
            Implements IDaoAll(Of SecurityObject).GetRecordById
            Dim sql As String =
                    " SELECT IDNo, ParentIdNo, SecurityObjectName, SecurityObjectNameAra, Notes" &
                    "   FROM [SecurityObject]" &
                    " WHERE IDNo = @IDNo"
            Dim parms() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, parms).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of SecurityObject) _
            Implements IDaoAll(Of SecurityObject).GetAll
            Dim sql As String =
                    " SELECT IdNo, ParentIdNo, SecurityObjectName, SecurityObjectNameAra, Notes" &
                    "   FROM [SecurityObject] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function AddRecord(ByRef recordData As SecurityObject) As Integer _
            Implements IDao(Of SecurityObject).AddRecord
            Dim sql As String =
                    " INSERT INTO [SecurityObject] " &
                    " (ParentIdNo,SecurityObjectName,SecurityObjectNameAra,Notes) " &
                    " VALUES (@ParentIdNo, @SecurityObjectName, @SecurityObjectNameAra,@Notes) "
            Return Db.Insert(sql, Take(recordData))
        End Function

        Public Function UpdateRecord(ByRef recordData As SecurityObject) As Integer _
            Implements IDao(Of SecurityObject).UpdateRecord
            Dim sql As String =
                    " UPDATE [SecurityObject]" &
                    "    SET SecurityObjectName = @SecurityObjectName," &
                    "        SecurityObjectNameAra = @SecurityObjectNameAra," &
                    "        ParentIdNo = @ParentIdNo," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(recordData))
        End Function

    End Class

End Namespace