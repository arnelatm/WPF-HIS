Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports AATM.Libraries.MessagingLibrary

Public Class LoginEntry
    Implements ILoginView

    Private ReadOnly _cancelLogin As Boolean

    'Private ReadOnly _loginPresenter As LoginPresenter

    Private _cancelClose As Boolean
    Private _rememberPassword As Boolean = False
    Private _changingPassword As Boolean = False

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
        textBoxUserName.Text = $"Arnel" 'Environment.UserName
        Dim userName = My.Settings.UserName
        Dim password = My.Settings.Oterkis
        _rememberPassword = My.Settings.RememberPassword
        If userName IsNot Nothing Then
            If password IsNot Nothing Then
                textBoxPassword.Text = password
            End If
            textBoxUserName.Text = userName
        End If
        chkSaveUserNameAndPassword.Checked = _rememberPassword
        'Dim model = New LoginModel
        PresenterObj = New LoginPresenter(Me)
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

    Public Property MainTableName As String = "Login"

    ''' <summary>
    '''     Gets the password.
    ''' </summary>
    Public ReadOnly Property Password As String Implements ILoginView.Password
        Get
            Return textBoxPassword.Text.Trim()
        End Get
    End Property

    Public ReadOnly Property UserName As String Implements ILoginView.UserName
        Get
            Return textBoxUserName.Text.Trim()
        End Get
    End Property

    Public ReadOnly Property IdNo As Int32 Implements ILoginView.IdNo
        Get
            Return 0
        End Get
    End Property

    Public Function LoginOk()
        Return _loginOk
    End Function

    ''' <summary>
    '''     Performs login and upon success closes dialog.
    ''' </summary>
    Private Sub Btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        Try
            If PresenterObj.Login() Then
                _loginOk = True
                If Not _changingPassword Then
                    SaveUserPasswordSetting()
                    GlobalVariables.UserName = textBoxUserName.Text.Trim()
                    GlobalVariables.UserIdNo = Convert.ToInt32(PresenterObj.GetRecordFieldWithKey(textBoxUserName.Text.Trim(),"User", "UserName", "IdNo"))
                    GlobalVariables.SecurityGroupIdNo =
                        Convert.ToInt16(PresenterObj.GetRecordFieldWithKey(GlobalVariables.UserIdNo, "User", "IdNo",
                                                                              "SecurityGroupIdNo"))
                Else
                    Dim userIdNo as Int32 
                    userIdNo = Convert.ToInt32(PresenterObj.GetRecordFieldWithKey(textBoxUserName.Text.Trim(),"User", "UserName", "IdNo"))
                    If PresenterObj.SaveNewPassword(GlobalVariables.UserIdNo, textNewPassword.Text, textConfirmation.Text) > 0 Then
                        SaveUserPasswordSetting()
                    End If
                End If
            Else
                Messaging.Show(True, "MsgInvalidUserNameOrPassword", "Invalid User Name or Password.", "Login Error")
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

    Private Sub SaveUserPasswordSetting()
        If chkSaveUserNameAndPassword.Checked Then
            My.Settings.UserName = textBoxUserName.Text.Trim()
            My.Settings.Oterkis = textBoxPassword.Text
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
        'LoginPresenter.Display()
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