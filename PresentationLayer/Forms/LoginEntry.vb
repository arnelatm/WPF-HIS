Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
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

    Private ReadOnly _myPresenter

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
        textBoxUserName.Text = $"Arnel" 'Environment.UserName

        UserName = My.Settings.UserName
        Password = My.Settings.Oterkis

        _rememberPassword = My.Settings.RememberPassword
        If UserName IsNot Nothing Then
            If Password IsNot Nothing Then
                textBoxPassword.Text = Password
            End If
            textBoxUserName.Text = UserName
        End If
        chkSaveUserNameAndPassword.Checked = _rememberPassword
        _myPresenter = New UserPresenter(Me)
        If _changingPassword Then
            textNewPassword.Visible = True
            textConfirmation.Visible = True
            lblNewPassword.Visible = True
            lblConfirmation.Visible = True
            textNewPassword.DisplayOnly = False
            textConfirmation.DisplayOnly = False
            btn_Login.Text = Messaging.TranslateCaption("Save")
            textNewPassword.Text = Space(20)
            textConfirmation.Text = Space(20)
            textNewPassword.Editable = True
            textConfirmation.Editable = True
            PresenterObj.EnableEdit()
            Height = 388
            floPasswordEntry.Height = 134
        Else
            Height = 342
            floPasswordEntry.Height = 134 - 46
        End If

    End Sub

    Public Property MainTableName As String = "User"

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
            Return textBoxUserName.Text.Trim()
        End Get
        Set(value As String)
            textBoxUserName.Text = value
        End Set
    End Property

    Public Property IdNo As Int32 Implements IUserView.IdNo

    Public Property FullName As String Implements IUserView.FullName

    Public Property FullNameAra As String Implements IUserView.FullNameAra

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
            If _myPresenter.Login() Then
                _loginOk = True
                If Not _changingPassword Then
                    AfterSuccessfulLogin()
                Else
                    If _myPresenter.SaveNewPassword(GlobalVariables.UserIdNo, textNewPassword.Text, textConfirmation.Text) > 0 Then
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
            MessageBox.Show(ex.Message, "Login failed")
            _cancelClose = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AfterSuccessfulLogin()
        SaveUserPasswordSetting()
        GlobalVariables.UserName = UserName
        GlobalVariables.UserIdNo = IdNo
        GlobalVariables.SecurityGroupIdNo = SecurityGroupIdNo
    End Sub

    Private Sub SaveUserPasswordSetting()
        If chkSaveUserNameAndPassword.Checked Then
            My.Settings.UserName = textBoxUserName.Text.Trim()
            My.Settings.Oterkis = _oterkis
            My.Settings.RememberPassword = True
            My.Settings.Save()
        Else
            My.Settings.UserName = ""
            My.Settings.Oterkis = ""
            My.Settings.RememberPassword = False
            My.Settings.Save()
        End If
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
        _textBoxUserName.ReadOnly = False
        _textBoxPassword.ReadOnly = False
        _textConfirmation.ReadOnly = False
        _textNewPassword.ReadOnly = False
        _textBoxUserName.DisplayOnly = False
        _textBoxPassword.DisplayOnly = False
        _textNewPassword.DisplayOnly = False
        _textConfirmation.DisplayOnly = False
        'Me.Show()
        'MyPresenter.Display()
    End Sub

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

    Private Sub SaveNewPassword()
        Dim userIdNo = Convert.ToInt16(PresenterObj.GetRecordFieldWithKey(textBoxUserName.Text.Trim(), "User", "UserName", "IdNo"))
        Dim encryptedPassword As String = PresenterObj.EncryptPassword(userIdNo, textNewPassword.Text.Trim())
        PresenterObj.SavePassword(userIdNo, encryptedPassword)
    End Sub

    Protected Sub EnableEdit()
        PresenterObj.EditMode = True
    End Sub

End Class