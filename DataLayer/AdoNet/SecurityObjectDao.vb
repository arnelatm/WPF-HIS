
Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for SecurityObject
    ' ** DAO Pattern

    Public Class SecurityObjectDao
        Inherits CommonDao
        Implements ISecurityObjectDao

        Private Shared ReadOnly Db As New Db()

        'Public Sub New()
        '    DbCommon = Db
        'End Sub


        Public Function GetRecordById(idNo As Integer) As SecurityObject _
            Implements ISecurityObjectDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, SecurityObjectName, SecurityObjectNameAra, Notes" &
                    "   FROM [SecurityObject]" &
                    " WHERE IDNo = @IDNo"
            Dim parms() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, parms).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "SecurityObjectName") As List(Of SecurityObject) Implements ISecurityObjectDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, SecurityObjectName, SecurityObjectNameAra, Notes" &
                    "   FROM [SecurityObject] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef securityObject As SecurityObject) As Integer Implements ISecurityObjectDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [SecurityObject]" &
                    "    SET SecurityObjectName = @SecurityObjectName," &
                    "        SecurityObjectNameAra = @SecurityObjectNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(securityObject))
        End Function

        Public Function AddRecord(ByRef securityObject As SecurityObject) As Integer Implements ISecurityObjectDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [SecurityObject] " &
                    " (SecurityObjectName,SecurityObjectNameAra,Notes) " &
                    " VALUES (@SecurityObjectName,@SecurityObjectNameAra,@Notes)"
            Return Db.Insert(sql, Take(securityObject))
        End Function

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

    End Class

End Namespace