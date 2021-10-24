Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class UserPresenter(Of TM As New)
    Inherits Presenter(Of IUserView, TM)

    Public ParentViewList As List(Of TM)
    Private serviceLogin As New ServiceLogin

    Public Sub New(view As IUserView)
        MyBase.New(view)
        Service = New Service("User")
        TableName = "User"
        SortOrderKey = "UserName"
        TreeViewMainField = "UserName"
        TreeViewSecondaryField = "EmployeeIdNo"
    End Sub

    'Public Function Login() As Boolean
    '    Dim loginOk As Boolean
    '    Dim userModel = New TM
    '    GlobalVariables.Mapper.Map(View, userModel)
    '    loginOk = Service.Login()
    '    GlobalVariables.Mapper.Map(userModel, View)
    '    Return loginOk
    'End Function

    Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        View.Password = serviceLogin.EncryptPassword(View.IdNo, View.Password)
    End Sub

    Private Sub OnSuccessfulAdd(ByRef newIdNo As Int32) Handles MyBase.RecordAddedSuccessfully
        Dim ePassword As String
        ePassword = serviceLogin.EncryptPassword(newIdNo, View.Password)
        If ePassword IsNot Nothing Then
            View.Password = ePassword
            Dim userModel As New TM
            GlobalVariables.Mapper.Map(View, userModel)
            If UpdateRecord(userModel) <= 0 Then
                Messaging.Show(True, "MsgPasswordNotSaved", "Password not saved")
            End If
        End If
    End Sub

    Public Function Login() As Boolean
        If String.IsNullOrWhiteSpace(View.UserName) Then
            Return False
        End If
        If String.IsNullOrWhiteSpace(View.Password) Then
            Return False
        End If
        Dim nLoginIdNo As Int32
        nLoginIdNo = Service.GetField(View.UserName, "User", "UserName", "IdNo")
        If nLoginIdNo <> 0 Then
            'Get the salt value for this username
            Dim salt As String
            Try
                salt = GetSalt(nLoginIdNo)
                If salt IsNot Nothing Then
                    'Hash the user entered password with the salt value stored in the Salt table
                    Dim ePassword As String
                    ePassword = HashEncryptStringWithSalt(View.Password, salt.ToString)
                    Dim eSavedPassword As String
                    eSavedPassword = GetPassword(nLoginIdNo)
                    If eSavedPassword = ePassword Then
                        Dim userDao = Service.GetDao("User")
                        Dim user As User
                        user = userDao.GetRecordByIdNo(nLoginIdNo)
                        GlobalVariables.Mapper.Map(user, Me)
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
                        MessageBox.Show($"Password was not encrypted!")
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
    '    nLoginIdNo = DataService.GetLoginByUserName(userName).IdNo
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
        If DataService.GenericUpdateRecordWithIdNo(Of String)(userIdNo, "User", "Password", ePassword) Then
            Messaging.Show(True, "MsgPasswordSaved", "Password saved")
            retVal = True
        Else
            Messaging.Show(True, "MsgPasswordNotSaved", "Password not saved")
            retVal = False
        End If
        Return retVal
    End Function

End Class