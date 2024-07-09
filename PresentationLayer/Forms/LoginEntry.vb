Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views.Interfaces

Public Class LoginEntry
    Implements IUserViewNew

    Private _brIdData As DataTable
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
            textConfirmedPassword.Visible = True
            lblNewPassword.Visible = True
            lblConfirmation.Visible = True
            textNewPassword.DisplayOnly = False
            textConfirmedPassword.DisplayOnly = False
            btn_Login.Text = Messaging.TranslateCaption("Save")
            textNewPassword.Text = "" 'Space(20)
            textConfirmedPassword.Text = "" 'Space(20)
            textBoxPassword.Text = "" 'Space(20)
            textNewPassword.Editable = True
            textConfirmedPassword.Editable = True
            txtUserName.DisplayOnly = True
            Refresh()
            Height = 456
            'floPasswordEntry.Height = 413
        Else
            txtUserName.DisplayOnly = False
            Height = 456 - 46
            'floPasswordEntry.Height = 413 - 46
        End If

    End Sub

    Public Event ArabicDisplayRequested As Views.IViewNew.ArabicDisplayRequestedEventHandler Implements Views.IViewNew.ArabicDisplayRequested

    Public Event FormLoaded As Views.IViewNew.FormLoadedEventHandler Implements Views.IViewNew.FormLoaded

    Public Event FormTranslating As Views.IViewNew.FormTranslatingEventHandler Implements Views.IViewNew.FormTranslating

    Public Event Login As IUserViewNew.LoginEventHandler Implements IUserViewNew.Login
    Public Event OrigLanguageDisplayRequested As Views.IViewNew.OrigLanguageDisplayRequestedEventHandler Implements Views.IViewNew.OrigLanguageDisplayRequested
    Public Property Active As Boolean Implements IUserViewNew.Active
    Public Property BranchIdNo As Int16
        Get
            Return cboBranchIdNo.GetValue(Of Int16)
        End Get
        Set
            cboBranchIdNo.SetValue(Value)
        End Set
    End Property

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
    Public Property CaptionCollection As Collection Implements Views.IViewNew.CaptionCollection
    Public Property ChangePassword As Boolean Implements IUserViewNew.ChangePassword
    Public Property ConfirmedPassword As String Implements IUserViewNew.ConfirmedPassword
        Get
            Return textConfirmedPassword.Text.Trim()
        End Get
        Set(value As String)
            textConfirmedPassword.Text = value
        End Set
    End Property

    Public Property EmployeeIdNo As Int32? Implements IUserViewNew.EmployeeIdNo
    Public Property FormCulture As CultureInfo Implements Views.IViewNew.FormCulture
    Public ReadOnly Property FormName As String Implements Views.IViewNew.FormName
        Get
            Return Name
        End Get
    End Property

    Public Property IdNo As Int16 Implements IUserViewNew.IdNo
    Public Property LoginOk As Boolean Implements IUserViewNew.LoginOk
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

    Public Property RightToLeftDisplay As String Implements Views.IViewNew.RightToLeftDisplay
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
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
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
        _textConfirmedPassword.ReadOnly = False
        _textNewPassword.ReadOnly = False
        _textBoxPassword.DisplayOnly = False
        _textNewPassword.DisplayOnly = False
        _textConfirmedPassword.DisplayOnly = False
    End Sub

    Private Sub SavePasswordSetting()
        My.Settings.UserName = txtUserName.Text.Trim()
        My.Settings.Oterkis = _oterkis
        My.Settings.RememberPassword = True
        My.Settings.BranchIdNo = cboBranchIdNo.SelectedValue
        My.Settings.Save()
    End Sub

    Private Sub SaveUserPasswordSetting()
        If Not chkSaveUserNameAndPassword.Checked Then
            ClearPasswordSetting()
        Else
            SavePasswordSetting()
        End If
        GlobalVariables.BranchIdNo = cboBranchIdNo.SelectedValue
    End Sub
End Class