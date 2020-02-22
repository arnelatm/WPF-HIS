Imports AATM.Businesslayer
Imports AATM.DataLayer.AdoNet

Public Class UserPresenter
    Inherits Presenter(Of IUserView)

    Public Sub New(ByRef view As IUserView)
        MyBase.New(view)
        TableName = "User"
        SortOrderKey = "FullName"
        OriginalModel = New UserModel
        BizObject = New User
        DbDataDao = New UserDao
    End Sub

    Public Function EncryptPassword(userLoginIdNo As Integer, password As String) As String
        Return Model.EncryptPassword(userLoginIdNo, password)
    End Function

    Public Function GetSaltByLoginId(userLoginIdNo As Integer) As SaltModel
        Return Model.GetSaltByLoginIdNo(userLoginIdNo)
    End Function

    Public Function AddSalt(userLoginIdNo As Integer, password As String) As Integer
        Dim ePassword As String
        Dim salt As New SaltModel
        Dim saltString As String
        salt.Salt = Model.CreateNewSaltString(18)
        salt.LoginIdNo = userLoginIdNo
        Return Model.AddSalt(salt)
    End Function
End Class