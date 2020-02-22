Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class LoginEntryError
        Inherits BfMain
        Implements ILoginView

        ' The Presenter
        Private _loginOk As Boolean

        Private ReadOnly _loginPresenter As LoginPresenter
        Private _cancelClose As Boolean
        Private ReadOnly _cancelLogin As Boolean
        Public Property MainTableName As String = "Login"

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                RightToLeftLayout = True
                RightToLeft = RightToLeft.Yes
            Else
                RightToLeftLayout = False
                RightToLeft = RightToLeft.No
            End If
            ' Add any initialization after the InitializeComponent() call.
            _cancelLogin = False
            AddHandler FormClosing, AddressOf FormLogin_Closing
            textBoxUserName.Text = Environment.UserName
            _loginPresenter = New LoginPresenter(Me)

        End Sub

        Public ReadOnly Property UserName As String Implements ILoginView.UserName
            Get
                Return textBoxUserName.Text.Trim()
            End Get
        End Property

        ''' <summary>
        '''     Gets the password.
        ''' </summary>
        Public ReadOnly Property Password As String Implements ILoginView.Password
            Get
                Return textBoxPassword.Text.Trim()
            End Get
        End Property

        ''' <summary>
        '''     Performs login and upon success closes dialog.
        ''' </summary>
        Private Sub Btn_Login_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
            Try
                If _loginPresenter.Login() Then
                    _loginOk = True
                    GlobalVariables.UserName = textBoxUserName.Text.Trim()
                    GlobalVariables.UserIdNo = Convert.ToInt32(_loginPresenter.GetRecordFieldWithKey(textBoxUserName.Text.Trim(),
                                                                                                     "User", "UserName", "IdNo"))
                    GlobalVariables.SecurityGroupIdNo =
                        Convert.ToInt32(_loginPresenter.GetRecordFieldWithKey(GlobalVariables.UserIdNo, "User", "IdNo",
                                                                              "SecurityGroupIDNo"))
                    Close()
                Else
                    MessageBox.Show("Invalid User Name or Password.")
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
        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
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

        Private Sub FormLogin_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            If _cancelLogin Then
                Close()
            End If
        End Sub

        Public Function LoginOk()
            Return _loginOk
        End Function

        Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'Me.Show()
            'LoginPresenter.Display()
        End Sub

        Private Sub CGroupBox1_Enter(sender As Object, e As EventArgs)

        End Sub
    End Class

End Namespace