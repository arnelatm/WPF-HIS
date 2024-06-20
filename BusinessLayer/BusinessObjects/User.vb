Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessObjects
    ' Category business object
    ' ** Enterprise Design Pattern: Domain Model, Identity Field

    Public Class User
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("UserName"))
                AddRule(New ValidateRequired("Password"))
            End If
        End Sub

        Public Property Active As Boolean
        Public Property IdNo As Int16
        Public Property EmployeeIdNo As Int32?
        Public Property UserName As String
        Public Property Password As String
        Public Property SecurityLevel As Int16
        Public Property SecurityGroupIdNo As Int16
    End Class

End Namespace