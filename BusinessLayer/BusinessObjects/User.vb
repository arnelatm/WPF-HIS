Imports AATM.HIS.BusinessLayer.BusinessRules

Namespace BusinessObjects

' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field


    Public Class User
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            AddRule(New ValidateRequired("UserName"))
            AddRule(New ValidateRequired("Password"))
            AddRule(New ValidateRequired("FullName"))
        End Sub

        Public Property IdNo As Integer
        Public Property UserName As String
        Public Property Password As String
        Public Property FullName As String
        Public Property SecurityGroupIdNo As Integer
    End Class
End NameSpace