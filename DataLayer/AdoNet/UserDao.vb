Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet

    ' Data access object for User
    ' ** DAO Pattern
    Public Class UserDao
        Inherits BaseDao
        Implements IDaoAll(Of User)

        Private ReadOnly Db As New Db()

        'Public Sub DeleteUser(user As User) Implements IDao(Of User).DeleteRecord
        '    Throw New NotImplementedException()
        'End Sub

        Public Function GetRecordByIdNo(idNo) As User Implements IDao(Of User).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, UserName, Password, FullName, SecurityGroupIdNo " &
                    "   FROM [User]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        'Public Function GetUserByName(fullName As String) As User Implements IDao(Of User).GetUserByName
        '    Throw New NotImplementedException
        'End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of User) _
            Implements IDaoAll(Of User).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "FullName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, UserName, Password, FullName, SecurityGroupIdNo " &
                    "   FROM [User] order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function AddRecord(ByRef user As User) As Integer Implements IDao(Of User).AddRecord
            Dim sql As String =
                    " INSERT INTO [User] " &
                    " (UserName,Password,FullName,SecurityGroupIdNo) " &
                    " VALUES (@UserName,@Password,@FullName,@SecurityGroupIdNo)"
            Return Db.Insert(sql, Take(user))
        End Function

        Public Function UpdateRecord(ByRef user As User) As Integer Implements IDao(Of User).UpdateRecord
            Dim sql As String =
                    " UPDATE [User]" &
                    "    SET UserName = @UserName," &
                    "        Password = @Password," &
                    "        FullName = @FullName," &
                    "        SecurityGroupIdNo = @SecurityGroupIdNo" &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(user))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, User) = Function(reader) _
            New User() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .UserName = Extensions.AsString(reader("UserName")),
            .Password = Extensions.AsString(reader("Password")),
            .FullName = Extensions.AsString(reader("FullName")),
            .SecurityGroupIdNo = Extensions.AsInt(Of Int16)(reader("SecurityGroupIdNo"))}

        Private Function Take(user As User) As Object()
            Return New Object() {
                                    "@IdNo", user.IdNo,
                                    "@UserName", user.UserName,
                                    "@Password", user.Password,
                                    "@FullName", user.FullName,
                                    "@SecurityGroupIdNo", user.SecurityGroupIdNo}
        End Function

    End Class

End Namespace