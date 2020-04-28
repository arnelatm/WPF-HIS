Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for Salt
    ' ** DAO Pattern

    Public Class SaltDao
        Implements ISaltDao

        Private ReadOnly Db As New Db()

        Public Function GetSalt(idNo As Integer) As Salt Implements ISaltDao.GetSalt
            Dim sql As String =
                    " SELECT IDNo, LoginIDNo, Salt" &
                    "  FROM [Salt]" &
                    " WHERE IDNo = @lDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetSaltByLoginIdNo(loginIdNo As Integer) As Salt Implements ISaltDao.GetSaltByLoginIdNo
            Dim sql As String =
                    " SELECT IDNo, LoginIDNo, Salt" &
                    "   FROM [Salt]" &
                    "  WHERE LoginIDNo = @LoginIDNo"
            Dim params() As Object = {"@LoginIDNo", loginIdNo}
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
                    "  WHERE IDNo = @IDNo"

            Db.Update(sql, Take(salt))
        End Sub

        ' creates a Salt object based on DataReader

        Private Shared ReadOnly Make As Func(Of IDataReader, Salt) =
                                    Function(reader) _
            New Salt() With {
            .IdNo = Extensions.AsInt(Of Integer)(reader("IDNo")),
            .LoginIdNo = Extensions.AsInt(Of Integer)(reader("LoginIDNo")),
            .Salt = Extensions.AsString(reader("Salt"))
            }

        ' creates query parameters list from Salt object

        Private Function Take(salt As Salt) As Object()
            Return New Object() {
                                    "@LoginIDNo", salt.LoginIdNo,
                                    "@Salt", salt.Salt}
        End Function

    End Class

End Namespace