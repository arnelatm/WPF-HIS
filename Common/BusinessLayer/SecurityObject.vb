Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class SecurityObject
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            AddRule(New ValidateRequired("SecurityObjectName"))
        End Sub

        Public Property IdNo As Integer
        Public Property SecurityObjectName As String
        Public Property SecurityObjectNameAra As String
        Public Property Notes As String

    End Class
End NameSpace