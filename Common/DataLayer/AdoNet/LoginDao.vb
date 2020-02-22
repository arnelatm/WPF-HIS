
Imports AATM.DataLayer.AdoNet
Imports AATM.Common.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for Login
    ' ** DAO Pattern

    Public Class LoginDao
        Inherits CommonDaoOld
        Implements ILoginDao

        Private Shared ReadOnly Db As New Db()

        Public Sub New()
            DbCommon = Db
        End Sub

        Public Function GetLogin(idNo As Integer) As Login Implements ILoginDao.GetLogin
            Dim sql As String =
                    " SELECT IDNo, UserName, Password" &
                    "  FROM [User]" &
                    " WHERE IDNo = @IDNo"

            Dim parms() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, parms).FirstOrDefault()
        End Function

        Public Function GetLoginByUserName(userName As String) As Login Implements ILoginDao.GetLoginByUserName
            Dim sql As String =
                    " SELECT IDNo, UserName, Password" &
                    "   FROM [User]" &
                    "  WHERE UserName = @UserName"

            Dim parms() As Object = {"@UserName", userName}
            Dim x = Db.Read(sql, Make, parms).FirstOrDefault()
            Return x
        End Function

        Public Function GetLogins(Optional ByVal sortExpression As String = "IDNo ASC") As List(Of Login) _
            Implements ILoginDao.GetLogins
            Dim sql As String =
                    " SELECT IDNo, UserName, Password" &
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
                    "  WHERE IDNo = @IDNo"
            Db.Update(sql, Take(login))
        End Sub

        Public Sub DeleteLogin(login As Login) Implements ILoginDao.DeleteLogin
            Dim sql As String =
                    " DELETE FROM [User]" &
                    "  WHERE IDNo = @IDNo"

            Db.Update(sql, Take(login))
        End Sub

        ' creates a Login object based on DataReader

        Private Shared ReadOnly Make As Func(Of IDataReader, Login) =
                                    Function(reader) _
            New Login() With {
            .IdNo = Extensions.AsInt(Of Integer)(reader("IDNo")),
            .UserName = Extensions.AsString(reader("UserName")),
            .Password = Extensions.AsString(reader("Password"))
            }

        ' creates query parameters list from Login object

        Private Function Take(login As Login) As Object()
            Return New Object() {
                                    "@UserName", login.UserName,
                                    "@Password", login.Password}
        End Function

    End Class

End Namespace