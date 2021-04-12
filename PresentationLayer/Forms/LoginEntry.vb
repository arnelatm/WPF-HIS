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
    Private _rememberPassword as Boolean = False

    ' The Presenter
    Private _loginOk As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        MainTableName = "User"
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
                If chkSaveUserNameAndPassword.Checked Then
                    My.Settings.UserName = textBoxUserName.Text.Trim()
                    My.Settings.Oterkis = textBoxPassword.Text
                    My.Settings.RememberPassword = True
                    My.Settings.Save()
                else
                    My.Settings.UserName = ""
                    My.Settings.Oterkis = ""
                    My.Settings.RememberPassword = False
                    My.Settings.Save()
                End If
                GlobalVariables.UserName = textBoxUserName.Text.Trim()
                GlobalVariables.UserIdNo = Convert.ToInt16(PresenterObj.GetRecordFieldWithKey(textBoxUserName.Text.Trim(),
                                                                                                 "User", "UserName", "IdNo"))
                GlobalVariables.SecurityGroupIdNo =
                    Convert.ToInt16(PresenterObj.GetRecordFieldWithKey(GlobalVariables.UserIdNo, "User", "IdNo",
                                                                          "SecurityGroupIdNo"))
            Else
                Messaging.Show(True, "MsgInvalidUserNameOrPassword", "Invalid User Name or Password.", "Login Error")
            End If
        Catch ex As ApplicationException
            MessageBox.Show(ex.Message, "Login failed")
            _cancelClose = True
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    ''' <summary>
    '''     Cancel was requested. Now closes dialog
    ''' </summary>
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    ''' <summary>
    '''     Provides opportunity to cancel the dialog close.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormLogin_Closing(sender As Object, e As CancelEventArgs)
        e.Cancel = _cancelClose
        _cancelClose = False
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _textBoxUserName.ReadOnly = False
        _textBoxPassword.ReadOnly = False
        _textBoxUserName.DisplayOnly = False
        _textBoxPassword.DisplayOnly = False
        'Me.Show()
        'LoginPresenter.Display()
    End Sub

    Private Sub FormLogin_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If _cancelLogin Then
            Close()
        End If
    End Sub

End Class