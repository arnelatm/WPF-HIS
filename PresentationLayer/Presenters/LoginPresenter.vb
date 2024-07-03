Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class LoginPresenter(Of TM As New)
    Inherits PresenterB(Of IUserViewNew, TM)

    Private ReadOnly _serviceLogin As New ServiceLogin

    Public Sub New(itemView As IUserViewNew)
        MyBase.New(itemView)
        Service = New Service("User")
        TableName = "User"
        CreateDataSource()
        AddHandler View.Login, AddressOf OnLogin
    End Sub

    Public Sub CreateDataSource()
        View.BranchIdNoData = MakeDataTable({"Branch"})
    End Sub

    Public Function Login(userName As String, password As String) As Boolean
        Dim serviceLogin As New ServiceLogin
        Return serviceLogin.Login(userName, password)
    End Function

    Private Function SaveNewPassword()
        If View.NewPassword.Trim().Length() > 0 Then
            Dim userIdNo = Convert.ToInt16(Service.GetRecordFieldWithKey(View.UserName.Trim(), "User", "UserName", "IdNo"))
            Return _serviceLogin.SavePassword(userIdNo, View.NewPassword.Trim())
        End If
        Return False
    End Function

    Private Function OnLogin()
        Try
            If Login(View.UserName, View.Password) Then
                If Not View.ChangePassword Then
                    View.LoginOk = True
                Else
                    If SaveNewPassword() Then
                        View.Password = View.NewPassword
                        View.LoginOk = True
                    End If
                End If
            Else
                Messaging.Show(True, "MsgInvalidUserNameOrPassword")
                View.CancelClose = True
                View.LoginOk = False
            End If
        Catch ex As ApplicationException
            MessageBox.Show(ex.Message, $"Login failed")
            View.CancelClose = True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
