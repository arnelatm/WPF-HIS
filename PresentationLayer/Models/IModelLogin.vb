Public Interface IModelLogin

    Function Login(userName As String, password As String) As Boolean

    Function EncryptPassword(userLoginIdNo As Integer, password As String) As String

    Function DecryptPassword(userName As String, password As String) As String

    Function SavePassword(userIdNo As Object, password As Object) As Object

End Interface