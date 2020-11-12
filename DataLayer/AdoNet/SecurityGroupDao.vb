Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for SecurityGroup
    ' ** DAO Pattern

    Public Class SecurityGroupDao
        Inherits BaseDao
        Implements IDaoAll(Of SecurityGroup), IDaoChild(Of GroupAccess)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As SecurityGroup Implements IDao(Of SecurityGroup).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, Notes, ParentIdNo, SecurityGroupCode, SecurityGroupName, SecurityGroupNameAra" &
                    "   FROM [SecurityGroup]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            data.GroupAccesses = GetRecordsWithIdNo(idNo, "SecurityObjectName")
            Return data
        End Function

        Private Function GetAll(Optional sortExpression As String = Nothing) As List(Of SecurityGroup) _
            Implements IDaoAll(Of SecurityGroup).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "SecurityGroupName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, Notes, ParentIdNo, SecurityGroupCode, SecurityGroupName, SecurityGroupNameAra" &
                    "   FROM [SecurityGroup] order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef securityGroup As SecurityGroup) As Integer _
            Implements IDao(Of SecurityGroup).UpdateRecord
            Dim sql As String =
                    " UPDATE [SecurityGroup]" &
                    " Set Notes = @Notes, " &
                    " ParentIdNo = @ParentIdNo, " &
                    " SecurityGroupCode = @SecurityGroupCode, " &
                    " SecurityGroupName = @SecurityGroupName," &
                    " SecurityGroupNameAra = @SecurityGroupNameAra" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(securityGroup))
        End Function

        Public Function AddRecord(ByRef securityGroup As SecurityGroup) As Integer _
            Implements IDao(Of SecurityGroup).AddRecord
            Dim sql As String =
                    " INSERT INTO [SecurityGroup] " &
                    " (Notes,ParentIdNo,SecurityGroupCode,SecurityGroupName,SecurityGroupNameAra)" &
                    " VALUES (@Notes,@ParentIdNo,@SecurityGroupCode,@SecurityGroupName,@SecurityGroupNameAra)"
            Return Db.Insert(sql, Take(securityGroup))
        End Function

        'Public Sub DeleteSecurityGroup(securityGroup As SecurityGroup) Implements IDao(Of SecurityGroup).DeleteSecurityGroup
        '    Dim sql As String =
        '            " DELETE FROM [SecurityGroup]" &
        '            "  WHERE IdNo = @IdNo"
        '    Db.Update(sql, Take(SecurityGroup))
        'End Sub

        Private Shared ReadOnly Make As Func(Of IDataReader, SecurityGroup) =
                                    Function(reader) _
            New SecurityGroup() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .ParentIdNo = Extensions.AsNullable(Of Int32?)(reader("ParentIdNo")),
            .SecurityGroupCode = Extensions.AsString(reader("SecurityGroupCode")),
            .SecurityGroupName = Extensions.AsString(reader("SecurityGroupName")),
            .SecurityGroupNameAra = Extensions.AsString(reader("SecurityGroupNameAra"))}

        Private Function Take(securityGroup As SecurityGroup) As Object()
            Return New Object() {
                                    "@IdNo", securityGroup.IdNo,
                                    "@Notes", securityGroup.Notes,
                                    "@ParentIdNo", securityGroup.ParentIdNo,
                                    "@SecurityGroupCode", securityGroup.SecurityGroupCode,
                                    "@SecurityGroupName", securityGroup.SecurityGroupName,
                                    "@SecurityGroupNameAra", securityGroup.SecurityGroupNameAra}
        End Function

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) _
            As List(Of GroupAccess) Implements IDaoChild(Of GroupAccess).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "IdNo"
            End If
            Dim sql As String =
                    "select GroupAccess.IdNo , GroupAccess.SecurityGroupIdNo ,  SecurityObject.IdNo as 'SecurityObjectIdNo' , SecurityObject.SecurityObjectName, GroupAccess.Visible, GroupAccess.Editable from SecurityObject  " &
                    "left join groupAccess " &
                    "on SecurityObject.IdNo = GroupAccess.SecurityObjectIdNo  and SecurityGroupIdNo = @SecurityGroupIdNo " &
                    "Order By " & sortExpression & " ASC "
            Dim params() As Object = {"@SecurityGroupIdNo", idNo}
            Return Db.Read(sql, MakeGroupAccess, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupAccessIdNo As Int32) As Integer _
            Implements IDaoChild(Of GroupAccess).DelUpdateTvp
            Return Db.DelUpdateTvp("dbo.UpdateGroupAccessTVP", tvpTable, "@MParam", groupAccessIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of GroupAccess).InsertTvp
            Return Db.InsertTvp("dbo.InsertGroupAccessTVP", tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly MakeGroupAccess As Func(Of IDataReader, GroupAccess) =
                                    Function(reader) _
            New GroupAccess() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .SecurityGroupIdNo = Extensions.AsInt(Of Int16?)(reader("SecurityGroupIdNo")),
            .SecurityObjectIdNo = Extensions.AsInt(Of Int16?)(reader("SecurityObjectIdNo")),
            .SecurityObjectName = Extensions.AsString(reader("SecurityObjectName")),
            .Visible = Extensions.AsBool(reader("Visible")),
            .Editable = Extensions.AsBool(reader("Editable"))
            }

    End Class

End Namespace