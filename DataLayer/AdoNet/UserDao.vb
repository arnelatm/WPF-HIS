Imports AATM.HIS.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for User
    ' ** DAO Pattern
    Public Class UserDao
        Implements IUserDao

        Private Shared ReadOnly _db As New Db()

        Public Sub DeleteUser(user As User) Implements IUserDao.DeleteUser
            Throw New NotImplementedException()
        End Sub

        Public Function GetUser(idNo As Integer) As User Implements IUserDao.GetUser
            Dim sql As String =
                    " SELECT IDNo, UserName, Password, FullName, SecurityGroupIDNo " &
                    "   FROM [User]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetUserByUserName(userName As String) As User Implements IUserDao.GetUserByName
            Throw New NotImplementedException()
        End Function

        Public Function GetUsers(Optional sortExpression As String = "FullName ASC") As List(Of User) _
            Implements IUserDao.GetUsers
            Dim sql As String =
                    " SELECT IDNo, UserName, Password, FullName, SecurityGroupIDNo " &
                    "   FROM [User] order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function InsertUser(user As User) As Integer Implements IUserDao.InsertUser
            Dim sql As String =
                    " INSERT INTO [User] " &
                    " (UserName,Password,FullName,SecurityGroupIDNo) " &
                    " VALUES (@UserName,@Password,@FullName,@SecurityGroupIDNo)"
            Return _db.Insert(sql, Take(user))
        End Function

        Public Function UpdateUser(user As User) As Integer Implements IUserDao.UpdateUser
            Dim sql As String =
                    " UPDATE [User]" &
                    "    SET UserName = @UserName," &
                    "        Password = @Password," &
                    "        FullName = @FullName," &
                    "        SecurityGroupIDNo = @SecurityGroupIDNo" &
                    "  WHERE IDNo = @IDNo"
            Return _db.Update(sql, Take(user))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, User) = Function(reader) _
            New User() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .UserName = Extensions.AsString(reader("UserName")),
            .Password = Extensions.AsString(reader("Password")),
            .FullName = Extensions.AsString(reader("FullName")),
            .SecurityGroupIdNo = Extensions.AsInt(Of Int16)(reader("SecurityGroupIDNo"))}

        Private Function Take(user As User) As Object()
            Return New Object() { _
                                    "@IDNo", user.IdNo,
                                    "@UserName", user.UserName,
                                    "@Password", user.Password,
                                    "@FullName", user.FullName,
                                    "@SecurityGroupIDNo", user.SecurityGroupIdNo}
        End Function
    End Class
End Namespace

