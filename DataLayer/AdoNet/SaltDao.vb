Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for Salt
    ' ** DAO Pattern

    Public Class SaltDao
        Implements ISaltDao

        Private ReadOnly Db As New Db()

        Public Function GetSalt(idNo As Int32) As Salt Implements ISaltDao.GetSalt
            Dim sql As String =
                    " SELECT IdNo, LoginIdNo, Salt" &
                    "  FROM [Salt]" &
                    " WHERE IdNo = @lDNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetSaltByLoginIdNo(loginIdNo As Int32) As Salt Implements ISaltDao.GetSaltByLoginIdNo
            Dim sql As String =
                    " SELECT IdNo, LoginIdNo, Salt" &
                    "   FROM [Salt]" &
                    "  WHERE LoginIdNo = @LoginIdNo"
            Dim params() As Object = {"@LoginIdNo", loginIdNo}
            Dim salt = Db.Read(sql, Make, params).FirstOrDefault()
            Return salt
        End Function

        Public Function InsertSalt(salt As Salt) As Integer Implements ISaltDao.InsertSalt
            Dim sql As String =
                    " INSERT INTO [Salt] " &
                    " (LoginIdNo, Salt) " &
                    " VALUES (@LoginIdNo,@Salt)"
            Return Db.Insert(sql, Take(salt))
        End Function

        Public Sub DeleteSalt(salt As Salt) Implements ISaltDao.DeleteSalt
            Dim sql As String =
                    " DELETE FROM [Salt]" &
                    "  WHERE IdNo = @IdNo"

            Db.Update(sql, Take(salt))
        End Sub

        ' creates a Salt object based on DataReader

        Private Shared ReadOnly Make As Func(Of IDataReader, Salt) =
                                    Function(reader) _
            New Salt() With {
            .IdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
            .LoginIdNo = Extensions.AsInt(Of Integer)(reader("LoginIdNo")),
            .Salt = Extensions.AsString(reader("Salt"))
            }

        ' creates query parameters list from Salt object

        Private Function Take(salt As Salt) As Object()
            Return New Object() {
                                    "@LoginIdNo", salt.LoginIdNo,
                                    "@Salt", salt.Salt}
        End Function

    End Class

End Namespace