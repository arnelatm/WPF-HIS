Imports System.Security.Cryptography
Imports System.Text

Namespace Services

    Public Module LoginSecurity
        'Public Function LoginSecurity(ByVal username As String, ByVal password As String)
        '    Try
        '        Dim isOK As Boolean = False
        '        'Get the salt value for this username
        '        Dim saltValue As Object = Me.SaltTableAdapter1.GetSaltByUserName(Me.txtUserName.Text)

        '        If Not IsDBNull(saltValue) Then
        '            'Hash the user entered password with the salt value stored in the Salt table
        '            Dim password As String = HashEncryptStringWithSalt(Me.txtPassword.Text, saltValue.ToString)

        '            'Now check the Login table to see if this hashed password matches
        '            isOK = CType(Me.LoginTableAdapter1.GetLoginByUserNameAndPassword(Me.txtUserName.Text, password), Integer) = 1
        '        End If

        '        If isOK Then
        '            MsgBox("Welcome to my Application!")
        '        Else
        '            MsgBox("Invalid user name or password.")
        '        End If

        '    Catch ex As Exception
        '        MsgBox(ex.ToString)
        '    End Try
        'End Function

        Private ReadOnly _hasher As New SHA1CryptoServiceProvider()
        'Private Hasher As New MD5CryptoServiceProvider()

        Friend Function GetSalt(saltSize As Integer) As String
            Dim buffer = New Byte(saltSize) {}
            Dim rng As New RNGCryptoServiceProvider()
            rng.GetBytes(buffer)
            Return Convert.ToBase64String(buffer)
        End Function

        Friend Function HashEncryptString(s As String) As String
            Dim clearBytes As Byte() = Encoding.UTF8.GetBytes(s)
            Dim hashedBytes As Byte() = _hasher.ComputeHash(clearBytes)
            Return Convert.ToBase64String(hashedBytes)
        End Function

        Friend Function HashEncryptStringWithSalt(s As String, salt As String) As String
            Return HashEncryptString(salt + s)
        End Function
    End Module
End NameSpace