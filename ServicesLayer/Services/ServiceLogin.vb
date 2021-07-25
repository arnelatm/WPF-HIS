Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.ServicesLayer.Services

Namespace Services

    Public Class ServiceLogin

        Public Property IdNo As Int32

        'Public Property UserName As String
        Public Property FullName As String

        Public Property FullNameAra As String

        'Public Property Password As String
        Public Property SecurityLevel As Int16

        Public Property SecurityGroupIdNo As Int16
        Public Service As New Service("User")

        Public Function Login(userName As String, Password As String) As Boolean
            If String.IsNullOrWhiteSpace(userName) Then
                Return False
            End If
            If String.IsNullOrWhiteSpace(Password) Then
                Return False
            End If
            Dim nLoginIdNo As Int32 = 0
            nLoginIdNo = Service.GetField(userName, "User", "UserName", "IdNo")
            If nLoginIdNo <> 0 Then
                'Get the salt value for this username
                Dim salt As String
                Try
                    salt = GetSalt(nLoginIdNo)
                    If salt IsNot Nothing Then
                        'Hash the user entered password with the salt value stored in the Salt table
                        Dim ePassword As String
                        ePassword = HashEncryptStringWithSalt(Password, salt.ToString)
                        Dim eSavedPassword As String
                        eSavedPassword = GetPassword(nLoginIdNo)
                        If eSavedPassword = ePassword Then
                            Dim userDao = Service.GetDao("User")
                            Dim user As New User
                            user = userDao.GetRecordByIdNo(nLoginIdNo)
                            GlobalVariables.UserName = user.UserName
                            GlobalVariables.SecurityGroupIdNo = user.SecurityGroupIdNo
                            GlobalVariables.UserIdNo = user.IdNo
                            'GlobalVariables.Mapper.Map(user, Me)
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

        Private Function GetSalt(loginIdNo As Int32)
            Return Service.GetField(loginIdNo, "Salt", "LoginIdNo", "Salt")
        End Function

        Private Function GetPassword(loginIdNo As Int32)
            Return Service.GetField(loginIdNo, "User", "IdNo", "Password")
        End Function

        Public Function HashEncryptString(s As String) As String
            Dim clearBytes As Byte() = Encoding.UTF8.GetBytes(s)
            Dim hashedBytes As Byte() = _hasher.ComputeHash(clearBytes)
            Return Convert.ToBase64String(hashedBytes)
        End Function

        Public Function EncryptPassword(userLoginIdNo As Int32, password As String) As String
            Dim salt As String
            Dim ePassword As String = Nothing
            Dim saltString As String
            Try
                If userLoginIdNo = 0 Then
                    ePassword = password
                Else
                    salt = GetSalt(userLoginIdNo)
                    If salt Is Nothing Then
                        saltString = HashEncryptString(password)
                        Dim newSalt As New Salt
                        newSalt.Salt = saltString.PadLeft(25)
                        newSalt.LoginIdNo = userLoginIdNo
                        Dim saltDao = Service.GetDao("Salt")
                        If saltDao.InsertSalt(newSalt) > 0 Then
                            ePassword = HashEncryptStringWithSalt(password, newSalt.Salt)
                        Else
                            MessageBox.Show("Password was not encrypted!")
                        End If
                    Else
                        'Hash the user entered password with the salt value stored in the Salt table
                        ePassword = HashEncryptStringWithSalt(password, salt)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return False
            End Try

            Return ePassword
        End Function

        'Public Function DecryptPassword(userName As String, password As String) As String
        '    Dim ePassword As String = ""
        '    If String.IsNullOrWhiteSpace(userName) Then
        '        Return ""
        '    End If
        '    If String.IsNullOrWhiteSpace(password) Then
        '        Return ""
        '    End If
        '    Dim nLoginIdNo As Int32
        '    nLoginIdNo = GetLoginByUserName(userName).IdNo
        '    If nLoginIdNo <> 0 Then
        '        'Get the salt value for this username
        '        Dim salt As String
        '        Try
        '            salt = GetSalt(nLoginIdNo)
        '            If Not IsDBNull(salt) Then
        '                'Hash the user entered password with the salt value stored in the Salt table
        '                ePassword = HashEncryptStringWithSalt(password, salt)
        '            End If
        '        Catch ex As Exception
        '            MsgBox(ex.ToString)
        '            Return False
        '        End Try
        '    End If
        '    Return ePassword
        'End Function

        Public Function HashEncryptStringWithSalt(s As String, salt As String) As String
            Return HashEncryptString(salt + s)
        End Function

        Public Function SavePassword(userIdNo As Int32, password As String)
            Dim retVal As Boolean
            Dim ePassword As String
            ePassword = EncryptPassword(userIdNo, password)
            If Service.GenericUpdateRecordWithIdNo(Of String)(userIdNo, "User", "Password", ePassword) Then
                Messaging.Show(True, "MsgPasswordSaved", "Password saved")
                retVal = True
            Else
                Messaging.Show(True, "MsgPasswordNotSaved", "Password not saved")
                retVal = False
            End If
            Return retVal
        End Function

    End Class

End Namespace