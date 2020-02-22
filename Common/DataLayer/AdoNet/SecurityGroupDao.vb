
Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for SecurityGroup
    ' ** DAO Pattern

    Public Class SecurityGroupDao
        Inherits CommonDaoOld
        Implements ISecurityGroupDao

        Private Shared ReadOnly Db As New Db()

        Public Sub New()
            DbCommon = Db
        End Sub

        Public Function GetRecordById(idNo As Integer) As SecurityGroup Implements ISecurityGroupDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, SecurityGroupName, SecurityGroupNameAra, SecurityGroupCode, Notes" &
                    "   FROM [SecurityGroup]" &
                    " WHERE IDNo = @IDNo"
            Dim parms() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, parms).FirstOrDefault()
        End Function

        Private Function GetAll(Optional sortExpression As String = "SecurityGroupName ASC") As List(Of SecurityGroup) Implements ISecurityGroupDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, SecurityGroupName, FullName, FullNameName " &
                    "   FROM [SecurityGroup] order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef securityGroup As SecurityGroup) As Integer Implements ISecurityGroupDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [SecurityGroup]" &
                    "    SET SecurityGroupName = @SecurityGroupName," &
                    "        SecurityGroupNameAra = @SecurityGroupNameAra, " &
                    "        SecurityGroupCode = @SecurityGroupCode, " &
                    "        Notes = @Notes " &
                    "  WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(securityGroup))
        End Function

        Public Function AddRecord(ByRef securityGroup As SecurityGroup) As Integer Implements ISecurityGroupDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [SecurityGroup] " &
                    " (SecurityGroupName,SecurityGroupNameAra,SecurityGroupCode,Notes) " &
                    " VALUES (@SecurityGroupName,@SecurityGroupNameAra,@SecurityGroupCode,@Notes)"
            Return Db.Insert(sql, Take(securityGroup))
        End Function

        'Public Sub DeleteSecurityGroup(securityGroup As SecurityGroup) Implements ISecurityGroupDao.DeleteSecurityGroup
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

        'Public Function GetSecurityGroups(Optional sortExpression As String = "SecurityGroupName ASC") _
        '    As List(Of SecurityGroup) Implements ISecurityGroupDao.GetSecurityGroups
        '    Dim sql As String =
        '            " SELECT IDNo, SecurityGroupName, SecurityGroupNameAra, SecurityGroupCode, Notes " &
        '            "   FROM [SecurityGroup] " &
        '            "   Order by " & sortExpression
        '    Return Db.Read(sql, Make).ToList()
        'End Function

        'Public Function GetSecurityGroupList(Optional sortExpression As String = "SecurityGroupName ASC") _
        '    As List(Of SecurityGroup) Implements ISecurityGroupDao.GetSecurityGroupList
        '    Dim sql As String =
        '            " SELECT IDNo, SecurityGroupName, SecurityGroupNameAra, SecurityGroupCode " &
        '            "   FROM [SecurityGroup] " &
        '            "   Order by " & sortExpression
        '    Return Db.Read(sql, Make).ToList()
        'End Function

        'Public Function GetSecurityGroupByGroupAccess(idNo As Integer) As SecurityGroup _
        '    Implements ISecurityGroupDao.GetSecurityGroupByGroupAccess
        '    Dim sql As String =
        '            " SELECT C.IDNo, SecurityGroupName, SecurityGroupNameAra, SecurityGroupCode,         Public Property GeneralJournalItemsPresenter As GeneralJournalItemsPresenter
        '" &
        '            "  FROM [groupAccess] O " &
        '            "  JOIN [SecurityGroup] C " &
        '            "  ON O.SecurityGroupIdNo = C.IDNo" &
        '            "  WHERE O.IDNo = @IDNo"

        '    Dim parms() As Object = {"@IDNo", IDNo}
        '    Return Db.Read(sql, Make, parms).FirstOrDefault()
        'End Function
    End Class

End Namespace