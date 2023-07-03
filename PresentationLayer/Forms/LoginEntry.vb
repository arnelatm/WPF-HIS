Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views.Interfaces

Public Class LoginEntry
    Implements IUserView

    Private ReadOnly _cancelLogin As Boolean

    'Private ReadOnly _loginPresenter As MyPresenter

    Private _cancelClose As Boolean
    Private ReadOnly _rememberPassword As Boolean = False
    Private ReadOnly _changingPassword As Boolean = False
    Private _oterkis As String

    ' The Presenter
    Private _loginOk As Boolean

    Public Sub New(changePassword As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        MainTableName = "User"
        If changePassword Then
            _changingPassword = True
        End If
        ' Add any initialization after the InitializeComponent() call.
        _cancelLogin = False
        AddHandler FormClosing, AddressOf FormLogin_Closing
        'textBoxUserName.Text = Environment.UserName

        Presenter = New UserPresenter(Of UserModel)(Me)

        MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
             {"BranchIdNo", cboBranchIdNo},
             {"UserName", txtUserName}
            }
        Presenter.CreateBranchSource()

        If changePassword Then
            UserName = GlobalVariables.UserName
            Password = ""
        Else
            UserName = My.Settings.UserName
            Password = My.Settings.Oterkis
            BranchIdNo = My.Settings.BranchIdNo
        End If

        _rememberPassword = My.Settings.RememberPassword
        If UserName IsNot Nothing Then
            If Password IsNot Nothing Then
                textBoxPassword.Text = Password
            End If
            txtUserName.Text = UserName
        End If
        chkSaveUserNameAndPassword.Checked = _rememberPassword

        If _changingPassword Then
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
            ' Presenter.EnableEdit()
            Height = 448
            floPasswordEntry.Height = 413
        Else
            txtUserName.DisplayOnly = False
            Height = 402
            floPasswordEntry.Height = 413 - 46
        End If

    End Sub

    Public Property MainTableName As String = "User"

    Public Property EmployeeIdNo As Int32? Implements IUserView.EmployeeIdNo

    ''' <summary>
    '''     Gets the password.
    ''' </summary>
    Public Property Password As String Implements IUserView.Password
        Get
            Return textBoxPassword.Text.Trim()
        End Get
        Set(value As String)
            textBoxPassword.Text = value
        End Set
    End Property

    Public Property UserName As String Implements IUserView.UserName
        Get
            Return txtUserName.Text.Trim()
        End Get
        Set(value As String)
            txtUserName.Text = value
        End Set
    End Property

    Public Property BranchIdNo As Int16
        Get
            Return cboBranchIdNo.GetNullableValue(Of Int16)
        End Get
        Set
            cboBranchIdNo.SetValue(Value)
        End Set
    End Property

    Public Property IdNo As Int32 Implements IUserView.IdNo

    Public Property SecurityLevel As Short Implements IUserView.SecurityLevel

    Public Property SecurityGroupIdNo As Short Implements IUserView.SecurityGroupIdNo

    Public Function LoginOk()
        Return _loginOk
    End Function

    ''' <summary>
    '''     Performs login and upon success closes dialog.
    ''' </summary>
    Private Sub Btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        Try
            _oterkis = textBoxPassword.Text
            If Presenter.Login(UserName, Password) Then
                _loginOk = True
                If Not _changingPassword Then
                    AfterSuccessfulLogin()
                Else
                    If Presenter.SaveNewPassword(textNewPassword.Text.Trim()) > 0 Then
                        textBoxPassword = textNewPassword
                        AfterSuccessfulLogin()
                    End If
                End If
            Else
                Messaging.Show(True, "MsgInvalidUserNameOrPassword")
                _cancelClose = True
                _loginOk = False
            End If
        Catch ex As ApplicationException
            MessageBox.Show(ex.Message, $"Login failed")
            _cancelClose = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AfterSuccessfulLogin()
        SaveUserPasswordSetting()
        GlobalVariables.BranchIdNo = cboBranchIdNo.SelectedValue
    End Sub

    Private Sub SaveUserPasswordSetting()
        If chkSaveUserNameAndPassword.Checked Then
            My.Settings.UserName = txtUserName.Text.Trim()
            My.Settings.Oterkis = _oterkis
            My.Settings.RememberPassword = True
            My.Settings.BranchIdNo = cboBranchIdNo.SelectedValue
            My.Settings.Save()
        Else
            My.Settings.UserName = ""
            My.Settings.Oterkis = ""
            My.Settings.BranchIdNo = 1
            My.Settings.RememberPassword = False
            My.Settings.Save()
        End If
        GlobalVariables.BranchIdNo = cboBranchIdNo.SelectedValue

    End Sub

    ''' <summary>
    '''     Cancel was requested. Now closes dialog
    ''' </summary>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    ''' <summary>
    '''     Provides opportunity to cancel the dialog close.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormLogin_Closing(sender As Object, e As CancelEventArgs)
        If _changingPassword Then
            _cancelClose = True
            Show()
            Exit Sub
        End If
        e.Cancel = _cancelClose
        _cancelClose = False
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _changingPassword Then
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


    Public MainFieldsDictionary As New Dictionary(Of String, Object)

    Private Sub FormLogin_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If _cancelLogin Then
            Close()
        End If
    End Sub


    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    If txtConfirmation.Visible Then
    '        If txtConfirmation.Visible = txtNewPassword.Visible AndAlso txtConfirmation.Text.Length >= 6 Then
    '            SaveNewPassword()
    '            txtConfirmation.Visible = False
    '            txtNewPassword.Visible = False
    '            lblConfirmation.Visible = False
    '            lblNewPassword.Visible = False
    '            Height = 360
    '        End If
    '    Else
    '        txtConfirmation.Visible = True
    '        txtNewPassword.Visible = True
    '        lblConfirmation.Visible = True
    '        lblNewPassword.Visible = True
    '        Height = 417
    '    End If
    '    _changingPassword = True
    'End Sub

    Private Function SaveNewPassword()
        Return Presenter.SavePassword(textNewPassword.Text)
    End Function

    Protected Sub EnableEdit()
        Presenter.EditMode = True
    End Sub

End Class