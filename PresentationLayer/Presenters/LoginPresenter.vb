Imports System.Windows.Forms
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class LoginPresenter(Of TM As New)
    Inherits PresenterB(Of IUserViewNew, TM)
    Implements IDisposable

    Private ReadOnly _serviceLogin As New ServiceLogin
    Private disposedValue As Boolean

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

    Private Function OnLogin()
        Try
            If Login(View.UserName, View.Password) Then
                If Not View.ChangePassword Then
                    View.LoginOk = True
                Else
                    If SaveNewPassword() Then
                        View.Password = View.NewPassword
                        View.LoginOk = True
                    Else
                        View.LoginOk = False
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

    Private Function SaveNewPassword()
        If View.NewPassword.Trim().Length() > 0 Then
            If View.ConfirmedPassword <> View.NewPassword Then
                Messaging.Show(True, "MsgPasswordMatchError")
            Else
                Dim userIdNo = Convert.ToInt16(Service.GetRecordFieldWithKey(View.UserName.Trim(), "User", "UserName", "IdNo"))
                Return _serviceLogin.SavePassword(userIdNo, View.NewPassword.Trim())
            End If
        End If
        Return False
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
