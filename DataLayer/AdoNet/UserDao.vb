Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet

    ' Data access object for User
    ' ** DAO Pattern
    Public Class UserDao
        Inherits BaseDao
        Implements IDao(Of User)

        Private ReadOnly Db As New Db()

        'Public Sub DeleteUser(user As User) Implements IDao(Of User).DeleteRecord
        '    Throw New NotImplementedException()
        'End Sub

        Public Function GetRecordByIdNo(idNo) As User Implements IDao(Of User).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, UserName, EmployeeIdNo, Password, SecurityLevel, SecurityGroupIdNo, Active " &
                    "   FROM [User]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        'Public Function GetUserByName(fullName As String) As User Implements IDao(Of User).GetUserByName
        '    Throw New NotImplementedException
        'End Function

        Public Function AddRecord(ByRef user As User) As Integer Implements IDao(Of User).AddRecord
            Dim sql As String =
                    " INSERT INTO [User] " &
                    " (UserName,Password,EmployeeIdNo,SecurityLevel,SecurityGroupIdNo,Active) " &
                    " VALUES (@UserName,@Password,@EmployeeIdNo,@SecurityLevel,@SecurityGroupIdNo,@Active)"
            Return Db.Insert(sql, Take(user))
        End Function

        Public Function UpdateRecord(ByRef user As User) As Integer Implements IDao(Of User).UpdateRecord
            Dim sql As String =
                    " UPDATE [User]" &
                    "    SET UserName = @UserName," &
                    "        EmployeeIdNo = @EmployeeIdNo," &
                    "        Password = @Password," &
                    "        SecurityLevel = @SecurityLevel," &
                    "        SecurityGroupIdNo = @SecurityGroupIdNo," &
                    "        Active = @Active" &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(user))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, User) = Function(reader) _
            New User() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .UserName = Extensions.AsString(reader("UserName")),
            .EmployeeIdNo = Extensions.AsNullable(Of Int32?)(reader("EmployeeIdNo")),
            .Password = Extensions.AsString(reader("Password")),
            .Active = Extensions.AsBool(reader("Active")),
            .SecurityLevel = Extensions.AsInt(Of Int16)(reader("SecurityLevel")),
            .SecurityGroupIdNo = Extensions.AsInt(Of Int16)(reader("SecurityGroupIdNo"))}

        Private Function Take(user As User) As Object()
            Return New Object() {
                                    "@IdNo", user.IdNo,
                                    "@UserName", user.UserName,
                                    "@EmployeeIdNo", user.EmployeeIdNo,
                                    "@Password", user.Password,
                                    "@SecurityLevel", user.SecurityLevel,
                                    "@SecurityGroupIdNo", user.SecurityGroupIdNo,
                                    "@Active", user.Active}
        End Function

    End Class

End Namespace
