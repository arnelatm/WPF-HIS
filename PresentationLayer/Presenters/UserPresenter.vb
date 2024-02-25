Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class UserPresenter(Of TM As New)
    Inherits Presenter(Of IUserView, TM)

    Public ParentViewList As List(Of TM)
    Private ReadOnly _serviceLogin As New ServiceLogin

    Public Sub New(view As IUserView)
        MyBase.New(view)
        Service = New Service("User")
        TableName = "User"
        SortOrderKey = "UserName"
        TreeViewMainField = "UserName"
        TreeViewSecondaryField = "EmployeeIdNo"
    End Sub

    Protected Overrides Sub CreateDataSources()
        MakeControlDataSources({New String() {"SecurityGroup", "SecurityGroupIdNo", Nothing, Nothing},
                             New String() {"Employee", "EmployeeIdNo", Nothing, Nothing}})
        CreateEnumDataSource(Of SecurityLevelSelection)("SecurityLevel")
    End Sub

    Public Sub CreateBranchSource()
        MakeControlDataSources({New String() {"Branch", "BranchIdNo", Nothing, Nothing}})
    End Sub

    Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        If Not CancelSave Then
            If View.Password <> OriginalModel.Password Then
                View.Password = _serviceLogin.EncryptPassword(View.IdNo, View.Password)
            End If
        End If
    End Sub

    Private Sub OnSuccessfulAdd(ByRef newIdNo As Int32) Handles MyBase.RecordAddedSuccessfully
        Dim ePassword As String
        ePassword = _serviceLogin.EncryptPassword(newIdNo, View.Password)
        If ePassword IsNot Nothing Then
            View.Password = ePassword
            Dim userModel As New TM
            GlobalVariables.Mapper.Map(View, userModel)
            If UpdateRecord(userModel) <= 0 Then
                Messaging.Show(True, "MsgPasswordNotSaved", "Password not saved")
            End If
        End If
    End Sub

    Public Function Login(userName As String, password As String) As Boolean
        Dim serviceLogin As New ServiceLogin
        Return serviceLogin.Login(userName, password)
    End Function

    Public Function SaveNewPassword(newPassword As String)
        Dim userIdNo = Convert.ToInt16(Service.GetRecordFieldWithKey(View.UserName.Trim(), "User", "UserName", "IdNo"))
        Return _serviceLogin.SavePassword(userIdNo, newPassword.Trim())
    End Function

End Class

Public Enum SecurityLevelSelection
    None
    Guest
    User1
    User2
    User3
    Manager1
    Manager2
    Manager3
    Administrator1
    Administrator2
    Administrator3
End Enum