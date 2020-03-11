Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for SecurityGroup
    ' ** DAO Pattern

    Public Class SecurityGroupDao
        Inherits BaseDao
        Implements IDaoAll(Of SecurityGroup)

        Private Shared ReadOnly Db As New Db()

        Public Function GetRecordById(idNo As Integer) As SecurityGroup Implements IDao(Of SecurityGroup).GetRecordById
            Dim sql As String =
                    " SELECT IDNo, SecurityGroupName, SecurityGroupNameAra, SecurityGroupCode, Notes" &
                    "   FROM [SecurityGroup]" &
                    " WHERE IDNo = @IDNo"
            Dim parms() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, parms).FirstOrDefault()
        End Function

        Private Function GetAll(Optional sortExpression As String = Nothing) As List(Of SecurityGroup) Implements IDaoAll(Of SecurityGroup).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "SecurityGroupName ASC"
            End If
            Dim sql As String =
                    " SELECT IDNo, SecurityGroupName, FullName, FullNameName " &
                    "   FROM [SecurityGroup] order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef securityGroup As SecurityGroup) As Integer Implements IDao(Of SecurityGroup).UpdateRecord
            Dim sql As String =
                    " UPDATE [SecurityGroup]" &
                    "    SET SecurityGroupName = @SecurityGroupName," &
                    "        SecurityGroupNameAra = @SecurityGroupNameAra, " &
                    "        SecurityGroupCode = @SecurityGroupCode, " &
                    "        Notes = @Notes " &
                    "  WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(securityGroup))
        End Function

        Public Function AddRecord(ByRef securityGroup As SecurityGroup) As Integer Implements IDao(Of SecurityGroup).AddRecord
            Dim sql As String =
                    " INSERT INTO [SecurityGroup] " &
                    " (SecurityGroupName,SecurityGroupNameAra,SecurityGroupCode,Notes) " &
                    " VALUES (@SecurityGroupName,@SecurityGroupNameAra,@SecurityGroupCode,@Notes)"
            Return Db.Insert(sql, Take(securityGroup))
        End Function

        'Public Sub DeleteSecurityGroup(securityGroup As SecurityGroup) Implements IDao(Of SecurityGroup).DeleteSecurityGroup
        '    Dim sql As String =
        '            " DELETE FROM [SecurityGroup]" &
        '            "  WHERE IDNo = @IDNo"
        '    Db.Update(sql, Take(SecurityGroup))
        'End Sub

        Private Shared ReadOnly Make As Func(Of IDataReader, SecurityGroup) =
                                    Function(reader) _
            New SecurityGroup() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .SecurityGroupName = Extensions.AsString(reader("SecurityGroupName")),
            .SecurityGroupNameAra = Extensions.AsString(reader("SecurityGroupNameAra")),
            .SecurityGroupCode = Extensions.AsString(reader("SecurityGroupCode")),
            .Notes = Extensions.AsString(reader("Notes"))}

        Private Function Take(securityGroup As SecurityGroup) As Object()
            Return New Object() {
                                    "@IDNo", securityGroup.IdNo,
                                    "@SecurityGroupName", securityGroup.SecurityGroupName,
                                    "@SecurityGroupNameAra", securityGroup.SecurityGroupNameAra,
                                    "@SecurityGroupCode", securityGroup.SecurityGroupCode,
                                    "@Notes", securityGroup.Notes}
        End Function

    End Class

End Namespace