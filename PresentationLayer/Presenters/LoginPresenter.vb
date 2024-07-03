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
        CreateBranchSource()
    End Sub

    Public Sub CreateBranchSource()
        View.BranchIdNoData = MakeVarDataSource({"Branch"})
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
