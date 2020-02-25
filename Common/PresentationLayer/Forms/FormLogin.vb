Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

''' <summary>
'''     Form where users enter login credentials.
''' </summary>
''' <remarks>
'''     Valid demo values are:
'''     userName: debbie@company.com
'''     password: secret123
''' </remarks>
Partial Public Class FormLogin
    Implements ILoginView

    Private ReadOnly _cancelLogin As Boolean

    Private ReadOnly _loginPresenter As LoginPresenter

    Private _cancelClose As Boolean

    Private _errorText As String

    ' The Presenter
    Private _loginOk As Boolean

    Private _securityGroupPresenter As SecurityGroupPresenter

    ''' <summary>
    '''     Default constructor of FormLogin.
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        _cancelLogin = False
        AddHandler Me.FormClosing, AddressOf FormLogin_Closing
        textBoxUserName.Text = Environment.UserName
        _loginPresenter = New LoginPresenter(Me)
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

    ''' <summary>
    '''     Gets the username.
    ''' </summary>
    Public ReadOnly Property UserName As String Implements ILoginView.UserName
        Get
            Return textBoxUserName.Text.Trim()
        End Get
    End Property

    Public Property Errors As List(Of String) Implements IView.Errors

    Public Function LoginOk()
        Return _loginOk
    End Function

    ''' <summary>
    '''     Performs login and upon success closes dialog.
    ''' </summary>
    Private Sub Btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        Try
            If _loginPresenter.Login() Then
                _loginOk = True
                GlobalVariables.UserName = textBoxUserName.Text.Trim()
                GlobalVariables.UserIdNo = Convert.ToInt32(_loginPresenter.GetRecordFieldWithKey(textBoxUserName.Text.Trim(),
                                                                                                 "User", "UserName", "IdNo"))
                GlobalVariables.SecurityGroupIdNo =
                    Convert.ToInt32(_loginPresenter.GetRecordFieldWithKey(GlobalVariables.UserIdNo, "User", "IdNo",
                                                                          "SecurityGroupIDNo"))
            Else
                MessageBox.Show("Login failed")
                _cancelClose = True

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
        'Me.Show()
        'LoginPresenter.Display()
    End Sub

    Private Sub FormLogin_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If _cancelLogin Then
            Close()
        End If
    End Sub

    ''' <summary>
    '''     Displays valid demo credentials
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LinkLabelValid_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        MessageBox.Show(
            "You can use the following credentials: " & vbCrLf & vbCrLf & "    User Name : User " & vbCrLf &
            "    PassWord:  secret123", "Login Credentials")
    End Sub

End Class