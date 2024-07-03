Imports System.ComponentModel
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views.Interfaces

Public Class LoginEntry
    Implements IUserViewNew

    Private _mainFieldsDictionary As Dictionary(Of String, Object)
    Private _oterkis As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ViewDisplayName = "LoginEntry"

    End Sub

    Public Sub New(pChangePassword As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        MainTableName = "User"
        ChangePassword = pChangePassword

        ' Add any initialization after the InitializeComponent() call.
        AddHandler FormClosing, AddressOf FormLogin_Closing

        If pChangePassword Then
            UserName = GlobalVariables.UserName
            Password = ""
        Else
            UserName = My.Settings.UserName
            Password = My.Settings.Oterkis
            BranchIdNo = My.Settings.BranchIdNo
        End If
        If UserName IsNot Nothing Then
            If Password IsNot Nothing Then
                textBoxPassword.Text = Password
            End If
            txtUserName.Text = UserName
        End If
        chkSaveUserNameAndPassword.Checked = My.Settings.RememberPassword

        If ChangePassword Then
            textNewPassword.Visible = True
            textConfirmation.Visible = True
            lblNewPassword.Visible = True
            lblConfirmation.Visible = True
            textNewPassword.DisplayOnly = False
            textConfirmation.DisplayOnly = False
            btn_Login.Text = Messaging.TranslateCaption("Save")
            textNewPassword.Text = "" 'Space(20)
            textConfirmation.Text = "" 'Space(20)
            textBoxPassword.Text = "" 'Space(20)
            textNewPassword.Editable = True
            textConfirmation.Editable = True
            txtUserName.DisplayOnly = True
            Refresh()
            Height = 448
            floPasswordEntry.Height = 413
        Else
            txtUserName.DisplayOnly = False
            Height = 402
            floPasswordEntry.Height = 413 - 46
        End If

    End Sub

    Public Event Login As IUserViewNew.LoginEventHandler Implements IUserViewNew.Login
    Public Property LoginOk As Boolean Implements IUserViewNew.LoginOk
    Public Property Active As Boolean Implements IUserViewNew.Active
    Public Property BranchIdNo As Int16
        Get
            Return cboBranchIdNo.GetValue(Of Int16)
        End Get
        Set
            cboBranchIdNo.SetValue(Value)
        End Set
    End Property

    Private _brIdData As DataTable

    Public Property BranchIdNoData As DataTable Implements IUserViewNew.BranchIdNoData
        Get
            Return _brIdData
        End Get
        Set(value As DataTable)
            _brIdData = value
            cboBranchIdNo.DataSource = value
        End Set
    End Property

    Public Property CancelClose As Boolean Implements IUserViewNew.CancelClose
    Public Property ChangePassword As Boolean Implements IUserViewNew.ChangePassword
    Public Property DataFilter As String Implements Views.IView.DataFilter
    Public Property EmployeeIdNo As Int32? Implements IUserViewNew.EmployeeIdNo
    Public Property Errors As List(Of String) Implements Views.IView.Errors
    Public Property IdNo As Int16 Implements IUserViewNew.IdNo
    Public ReadOnly Property MainFieldsDictionary As Dictionary(Of String, Object) Implements Views.IViewNew.MainFieldsDictionary
        Get
            Return New Dictionary(Of String, Object) From
            {
             {"BranchIdNo", cboBranchIdNo},
             {"UserName", txtUserName}
            }
        End Get
    End Property

    Public Property MainTableName As String = "User"
    Public Property NewPassword As String Implements IUserViewNew.NewPassword
        Get
            Return textNewPassword.Text.Trim()
        End Get
        Set(value As String)
            textNewPassword.Text = value
        End Set
    End Property

    Public Property Password As String Implements IUserViewNew.Password
        Get
            Return textBoxPassword.Text.Trim()
        End Get
        Set(value As String)
            textBoxPassword.Text = value
        End Set
    End Property

    Public Property SecurityGroupIdNo As Short Implements IUserViewNew.SecurityGroupIdNo

    Public Property SecurityLevel As Short Implements IUserViewNew.SecurityLevel

    Public Property UserName As String Implements IUserViewNew.UserName
        Get
            Return txtUserName.Text.Trim()
        End Get
        Set(value As String)
            txtUserName.Text = value
        End Set
    End Property

    Public Property ViewDisplayName As String Implements Views.IViewNew.ViewDisplayName

    Private Shared Sub ClearPasswordSetting()
        My.Settings.UserName = ""
        My.Settings.Oterkis = ""
        My.Settings.BranchIdNo = 1
        My.Settings.RememberPassword = False
        My.Settings.Save()
    End Sub

    Private Sub AfterSuccessfulLogin()
        SaveUserPasswordSetting()
        GlobalVariables.BranchIdNo = cboBranchIdNo.SelectedValue
    End Sub

    Private Sub Btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        _oterkis = textBoxPassword.Text
        RaiseEvent Login()
        If LoginOk Then
            AfterSuccessfulLogin()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub FormLogin_Closing(sender As Object, e As CancelEventArgs)
        If ChangePassword Then
            CancelClose = True
            Show()
            Exit Sub
        End If
        e.Cancel = CancelClose
        CancelClose = False
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ChangePassword Then
            _txtUserName.ReadOnly = True
            _txtUserName.DisplayOnly = True
        Else
            _txtUserName.ReadOnly = False
            _txtUserName.DisplayOnly = False
        End If
        _textBoxPassword.ReadOnly = False
        _textConfirmation.ReadOnly = False
        _textNewPassword.ReadOnly = False
        _textBoxPassword.DisplayOnly = False
        _textNewPassword.DisplayOnly = False
        _textConfirmation.DisplayOnly = False
    End Sub

    Private Sub SaveUserPasswordSetting()
        If Not chkSaveUserNameAndPassword.Checked Then
            ClearPasswordSetting()
        Else
            SavePasswordSetting()
        End If
        GlobalVariables.BranchIdNo = cboBranchIdNo.SelectedValue
    End Sub

    Private Sub SavePasswordSetting()
        My.Settings.UserName = txtUserName.Text.Trim()
        My.Settings.Oterkis = _oterkis
        My.Settings.RememberPassword = True
        My.Settings.BranchIdNo = cboBranchIdNo.SelectedValue
        My.Settings.Save()
    End Sub

End Class