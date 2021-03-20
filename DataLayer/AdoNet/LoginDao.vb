Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for Login
    ' ** DAO Pattern

    Public Class LoginDao
        Implements ILoginDao

        Private ReadOnly Db As New Db()

        Public Function GetLogin(idNo As Int32) As Login Implements ILoginDao.GetLogin
            Dim sql As String =
                    " SELECT IdNo, UserName, Password" &
                    "  FROM [User]" &
                    " WHERE IdNo = @IdNo"

            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetLoginByUserName(userName As String) As Login Implements ILoginDao.GetLoginByUserName
            Dim sql As String =
                    " SELECT IdNo, UserName, Password" &
                    "   FROM [User]" &
                    "  WHERE UserName = @UserName"
            Dim params() As Object = {"@UserName", userName}
            Dim x = Db.Read(sql, Make, params).FirstOrDefault()
            Return x
        End Function

        Public Function GetLogins(Optional ByVal sortExpression As String = "IdNo ASC") As List(Of Login) _
            Implements ILoginDao.GetLogins
            Dim sql As String =
                    " SELECT IdNo, UserName, Password" &
                    "   FROM [User] ".OrderBy(sortExpression)
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Sub InsertLogin(login As Login) Implements ILoginDao.InsertLogin
            Dim sql As String =
                    " INSERT INTO [User] (UserName, Password) " &
                    " VALUES (@UserName, @Password)"

            login.IdNo = Db.Insert(sql, Take(login))
        End Sub

        Public Sub UpdateLogin(login As Login) Implements ILoginDao.UpdateLogin
            Dim sql As String =
                    " UPDATE [User]" &
                    "    SET UserName = @UserName, " &
                    "        Password = @Password" &
                    "  WHERE IdNo = @IdNo"
            Db.Update(sql, Take(login))
        End Sub

        Public Sub DeleteLogin(login As Login) Implements ILoginDao.DeleteLogin
            Dim sql As String =
                    " DELETE FROM [User]" &
                    "  WHERE IdNo = @IdNo"

            Db.Update(sql, Take(login))
        End Sub

        ' creates a Login object based on DataReader

        Private Shared ReadOnly Make As Func(Of IDataReader, Login) =
                                    Function(reader) _
            New Login() With {
            .IdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .UserName = Extensions.AsString(reader("UserName")),
            .Password = Extensions.AsString(reader("Password"))
            }

        ' creates query parameters list from Login object

        Private Function Take(login As Login) As Object()
            Return New Object() {
                                    "@UserName", login.UserName,
                                    "@Password", login.Password}
        End Function

        'Public Function GetRecordByIdNo(idNo) As Login Implements IDao(Of Login).GetRecordByIdNo
        '    Dim sql As String =
        '            " SELECT IdNo, UserName, Password" &
        '            "  FROM [User]" &
        '            " WHERE IdNo = @IdNo"
        '    Dim params() As Object = {"@IdNo", idNo}
        '    Return Db.Read(sql, Make, params).FirstOrDefault()
        'End Function
    End Class

End Namespace