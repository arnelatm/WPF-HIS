Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for User
    ' ** DAO Pattern

    Public Class UserDao
        Inherits CommonDaoOld
        Implements IUserDao

        Private Shared ReadOnly Db As New Db()
        Private ReadOnly _loginService As New LoginService

        Public Sub New()
            DbCommon = Db
        End Sub

        Public Function GetRecordById(idNo As Integer) As User Implements IUserDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, UserName, FullName, FullNameAra, SecurityLevel, SecurityGroupIdNo, Password " &
                    "   FROM [User]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Dim x As User
            x = Db.Read(sql, Make, params).FirstOrDefault()
            Return x
            'Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Private Function GetAll(Optional sortExpression As String = "UserName ASC") As List(Of User) _
            Implements IUserDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, UserName, FullName, FullNameName " &
                    "   FROM [User] order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef user As User) As Integer Implements IUserDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [User]" &
                    "   SET UserName = @UserName," &
                    "       FullName = @FullName," &
                    "       FullNameAra = @FullNameAra," &
                    "       SecurityLevel = @SecurityLevel," &
                    "       SecurityGroupIdNo = @SecurityGroupIdNo," &
                    "       Password = @Password" &
                    "  WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(user))
        End Function

        Public Function AddRecord(ByRef user As User) As Integer Implements IUserDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [User] " &
                    "        (UserName,FullName,FullNameAra,SecurityLevel,SecurityGroupIdNo,Password)" &
                    " VALUES (@UserName,@FullName,@FullNameAra,@SecurityLevel,@SecurityGroupIdNo,@Password)"
            Return Db.Insert(sql, Take(user))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, User) =
                                    Function(reader) _
            New User() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .UserName = Extensions.AsString(reader("UserName")),
            .FullName = Extensions.AsString(reader("FullName")),
            .FullNameAra = Extensions.AsString(reader("FullNameAra")),
            .SecurityLevel = Extensions.AsNumber(Of Int16)(reader("SecurityLevel")),
            .Password = Extensions.AsString(reader("Password")),
            .SecurityGroupIdNo = Extensions.AsInt(Of Integer)(reader("SecurityGroupIdNo"))
            }

        Private Function Take(ByRef user As User) As Object()
            Return New Object() {
                                    "@IDNo", user.IdNo,
                                    "@UserName", user.UserName,
                                    "@FullName", user.FullName,
                                    "@FullNameAra", user.FullNameAra,
                                    "@Password", _loginService.EncryptPassword(user.IdNo, user.Password),
                                    "@SecurityLevel", user.SecurityLevel,
                                    "@SecurityGroupIdNo", user.SecurityGroupIdNo
                                }
        End Function

    End Class

End Namespace