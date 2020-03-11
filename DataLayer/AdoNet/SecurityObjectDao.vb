Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for SecurityObject
    ' ** DAO Pattern

    Public Class SecurityObjectDao
        Inherits BaseDao
        Implements IDaoAll(Of SecurityObject)

        Private Shared ReadOnly Db As New Db()

        Private Shared ReadOnly Make As Func(Of IDataReader, SecurityObject) =
                                    Function(reader) _
            New SecurityObject() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .SecurityObjectName = Extensions.AsString(reader("SecurityObjectName")),
            .SecurityObjectNameAra = Extensions.AsString(reader("SecurityObjectNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))}

        Private Function Take(securityObject As SecurityObject) As Object()
            Return New Object() {
                                    "@IDNo", securityObject.IdNo,
                                    "@SecurityObjectName", securityObject.SecurityObjectName,
                                    "@SecurityObjectNameAra", securityObject.SecurityObjectNameAra,
                                    "@Notes", securityObject.Notes}
        End Function

        Public Function GetRecordById(idNo As Integer) As SecurityObject Implements IDaoAll(Of SecurityObject).GetRecordById
            Dim sql As String =
                    " SELECT IDNo, SecurityObjectName, SecurityObjectNameAra, Notes" &
                    "   FROM [SecurityObject]" &
                    " WHERE IDNo = @IDNo"
            Dim parms() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, parms).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of SecurityObject) Implements IDaoAll(Of SecurityObject).GetAll
            Dim sql As String =
                    " SELECT IDNo, SecurityObjectName, SecurityObjectNameAra, Notes" &
                    "   FROM [SecurityObject] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function AddRecord(ByRef recordData As SecurityObject) As Integer Implements IDao(Of SecurityObject).AddRecord
            Dim sql As String =
                    " UPDATE [SecurityObject]" &
                    "    SET SecurityObjectName = @SecurityObjectName," &
                    "        SecurityObjectNameAra = @SecurityObjectNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(recordData))
        End Function

        Public Function UpdateRecord(ByRef recordData As SecurityObject) As Integer Implements IDao(Of SecurityObject).UpdateRecord
            Dim sql As String =
                    " UPDATE [SecurityObject]" &
                    "    SET SecurityObjectName = @SecurityObjectName," &
                    "        SecurityObjectNameAra = @SecurityObjectNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(recordData))
        End Function

    End Class

End Namespace