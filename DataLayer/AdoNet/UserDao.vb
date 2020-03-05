Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for User
    ' ** DAO Pattern
    Public Class UserDao
        Inherits CommonDao
        Implements IUserDao

        Private Shared ReadOnly _db As New Db()

        Public Sub DeleteUser(user As User) Implements IUserDao.DeleteRecord
            Throw New NotImplementedException()
        End Sub

        Public Function GetRecordById(idNo As Integer) As User Implements IUserDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, UserName, Password, FullName, SecurityGroupIDNo " &
                    "   FROM [User]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetUserByName(fullName As String) As User Implements IUserDao.GetUserByName
            Throw New NotImplementedException
        End Function

        Public Function GetAll(Optional sortExpression As String = "FullName ASC") As List(Of User) _
            Implements IUserDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, UserName, Password, FullName, SecurityGroupIDNo " &
                    "   FROM [User] order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function AddUser(user As User) As Integer Implements IUserDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [User] " &
                    " (UserName,Password,FullName,SecurityGroupIDNo) " &
                    " VALUES (@UserName,@Password,@FullName,@SecurityGroupIDNo)"
            Return _db.Insert(sql, Take(user))
        End Function

        Public Function UpdateRecord(user As User) As Integer Implements IUserDao.UpdateRecord
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

