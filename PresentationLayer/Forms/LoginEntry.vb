Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing
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
    Private ReadOnly _floCurrentHeight As Integer
    Private ReadOnly _formHeight As Integer
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
        _floCurrentHeight = floPasswordEntry.Height
        _formHeight = Me.Height
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
            floPasswordEntry.Height = _floCurrentHeight
            Me.Height = _formHeight
        Else
            UserName = My.Settings.UserName
            Password = My.Settings.Oterkis
            BranchIdNo = My.Settings.BranchIdNo
            floPasswordEntry.Height = _floCurrentHeight - 46
            Me.Height = _formHeight - 46
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
            textNewPassword.Text = ""
            textConfirmation.Text = ""
            textBoxPassword.Text = ""
            textNewPassword.Editable = True
            textConfirmation.Editable = True
            txtUserName.DisplayOnly = True
            Refresh()
        Else
            txtUserName.DisplayOnly = False
        End If

        ApplyPasswordModeVisibility()
        ConfigureConnectionInfoLabel()

    End Sub

    Private Sub ConfigureConnectionInfoLabel()
        lblInfoSystem.AutoEllipsis = True
        lblInfoSystem.BackColor = Color.FromArgb(224, 245, 232)
        lblInfoSystem.BorderStyle = BorderStyle.None
        lblInfoSystem.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular)
        lblInfoSystem.ForeColor = Color.FromArgb(32, 82, 62)
        lblInfoSystem.Padding = New Padding(8, 0, 8, 0)
        lblInfoSystem.TextAlign = ContentAlignment.MiddleCenter
        'lblInfoSystem.Dock = DockStyle.Fill
        lblInfoSystem.Height = 22
        'TableLayoutPanel1.Controls.Add(lblInfoSystem, 0, 6)
        'TableLayoutPanel1.SetColumnSpan(lblInfoSystem, 3)
        'TableLayoutPanel1.RowStyles(6).SizeType = SizeType.Absolute
        'TableLayoutPanel1.RowStyles(6).Height = 22
        'TableLayoutPanel1.Height += 22
        'floPasswordEntry.Height += 22
        'Height += 22
        UpdateConnectionInfoLabel()
    End Sub


    Private Sub UpdateConnectionInfoLabel()
        Dim serverName = "Unavailable"
        Dim databaseName = "Unavailable"
        Try
            If Not String.IsNullOrWhiteSpace(GlobalVariables.DacConnectionString) Then
                Dim settings As New SqlConnectionStringBuilder(GlobalVariables.DacConnectionString)
                serverName = If(String.IsNullOrWhiteSpace(settings.DataSource), "Unspecified", settings.DataSource)
                databaseName = If(String.IsNullOrWhiteSpace(settings.InitialCatalog), "Unspecified", settings.InitialCatalog)
            End If
        Catch
            serverName = "Unavailable"
            databaseName = "Unavailable"
        End Try

        Dim entryAssembly = Reflection.Assembly.GetEntryAssembly()
        Dim applicationVersion = If(entryAssembly Is Nothing,
                                    Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                                    entryAssembly.GetName().Version.ToString())
        lblInfoSystem.Text = $"Server.Database: {serverName}.{databaseName} | Version {applicationVersion}"
        'lblInfoSystem.ForeColor = Color.FromArgb(32, 82, 62)
    End Sub

    Private Sub ApplyPasswordModeVisibility()
        textNewPassword.Visible = _changingPassword
        textConfirmation.Visible = _changingPassword
        lblNewPassword.Visible = _changingPassword
        lblConfirmation.Visible = _changingPassword
        textNewPassword.TabStop = _changingPassword
        textConfirmation.TabStop = _changingPassword
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
            Return cboBranchIdNo.GetValue(Of Int16)
        End Get
        Set
            cboBranchIdNo.SetValue(Value)
        End Set
    End Property

    Public Property IdNo As Int32 Implements IUserView.IdNo

    Public Property SecurityLevel As Short Implements IUserView.SecurityLevel

    Public Property SecurityGroupIdNo As Short Implements IUserView.SecurityGroupIdNo

    Public Property Active As Boolean Implements IUserView.Active

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
        ApplyPasswordModeVisibility()
    End Sub


    Public MainFieldsDictionary As New Dictionary(Of String, Object)

    Private Sub FormLogin_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ApplyPasswordModeVisibility()
        If _cancelLogin Then
            Close()
        End If
    End Sub

    Private Function SaveNewPassword()
        Return Presenter.SavePassword(textNewPassword.Text)
    End Function

    Protected Sub EnableEdit()
        Presenter.EditMode = True
    End Sub


End Class
