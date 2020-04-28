Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Text
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer
Imports AATM.Libraries

Namespace Services

    Public Class ServiceLogin
        Inherits Service

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly SaltDao As ISaltDao = Factory.SaltDao

        Protected Shared ReadOnly LoginDao As ILoginDao = Factory.LoginDao()

        Public Sub New()
            DataDao = LoginDao
            DataBo = New Login
        End Sub

        Public Function Login(userName As String, password As String) As Boolean
            ' websecurity does not accept null or empty

            If String.IsNullOrWhiteSpace(userName) Then
                Return False
            End If
            If String.IsNullOrWhiteSpace(password) Then
                Return False
            End If

            Dim nLoginIdNo As Integer = 0
            Dim xLogin As Login
            xLogin = DataDao.GetLoginByUserName(userName)
            If xLogin IsNot Nothing Then
                nLoginIdNo = xLogin.IdNo
            End If
            'nLoginIdNo = LoginDao.GetLoginByUserName(userName).IdNo

            If nLoginIdNo <> 0 Then
                'Get the salt value for this username
                Dim salt As String

                Try
                    Dim result = SaltDao.GetSaltByLoginIdNo(nLoginIdNo)
                    If result IsNot Nothing Then
                        salt = result.Salt
                    Else
                        salt = Nothing
                    End If
                    'Dim SaltValue As String
                    'SaltValue = HashEncryptString(nLoginIdNo.ToString())
                    If salt IsNot Nothing Then
                        'Hash the user entered password with the salt value stored in the Salt table

                        Dim ePassword As String
                        ePassword = HashEncryptStringWithSalt(password, salt.ToString)

                        If DataDao.GetLoginByUserName(userName).Password = ePassword Then
                            ' MsgBox("Welcome to my Application!")
                        Else
                            'MsgBox("Invalid user name or password.")
                            Return False
                        End If
                    Else
                        Return False

                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    Return False
                End Try
            Else

                Return False
            End If
            Return True
            'Return WebSecurity.Login(email, password)
        End Function

        Private ReadOnly _hasher As New SHA1CryptoServiceProvider()

        Public Function HashEncryptString(s As String) As String
            Dim clearBytes As Byte() = Encoding.UTF8.GetBytes(s)
            Dim hashedBytes As Byte() = _hasher.ComputeHash(clearBytes)
            Return Convert.ToBase64String(hashedBytes)
        End Function

        Public Function EncryptPassword(userLoginIdNo As Integer, password As String) As String
            Dim salt As Salt
            Dim ePassword As String = Nothing
            Dim saltString As String
            Try

                If userLoginIdNo = 0 Then
                    ePassword = password
                    'saltString = GetSalt(28)
                    'ePassword = HashEncryptStringWithSalt(password, saltString)
                    ' new user no Salt record yet
                Else
                    salt = SaltDao.GetSaltByLoginIdNo(userLoginIdNo)
                    If salt Is Nothing Then
                        saltString = HashEncryptString(password)
                        Dim newSalt As New Salt
                        newSalt.Salt = saltString.PadLeft(25)
                        newSalt.LoginIdNo = userLoginIdNo
                        If SaltDao.InsertSalt(newSalt) > 0 Then
                            ePassword = HashEncryptStringWithSalt(password, newSalt.Salt)
                        Else
                            MessageBox.Show("Password was not encrypted!")
                        End If
                    Else
                        'Hash the user entered password with the salt value stored in the Salt table
                        ePassword = HashEncryptStringWithSalt(password, salt.Salt)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return False
            End Try

            Return ePassword
        End Function

        Public Function DecryptPassword(userName As String, password As String) As String
            Dim ePassword As String = ""
            If String.IsNullOrWhiteSpace(userName) Then
                Return ""
            End If
            If String.IsNullOrWhiteSpace(password) Then
                Return ""
            End If
            Dim nLoginIdNo As Integer
            nLoginIdNo = DataDao.GetLoginByUserName(userName).IdNo

            If nLoginIdNo <> 0 Then
                'Get the salt value for this username
                Dim salt As String

                Try
                    salt = SaltDao.GetSaltByLoginIdNo(nLoginIdNo).Salt
                    'Dim SaltValue As String
                    'SaltValue = HashEncryptString(nLoginIdNo.ToString())
                    If Not IsDBNull(salt) Then
                        'Hash the user entered password with the salt value stored in the Salt table
                        ePassword = HashEncryptStringWithSalt(password, salt.ToString)
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    Return False
                End Try

            End If

            Return ePassword
        End Function

        Public Function HashEncryptStringWithSalt(s As String, salt As String) As String
            Return HashEncryptString(salt + s)
        End Function

    End Class

End Namespace