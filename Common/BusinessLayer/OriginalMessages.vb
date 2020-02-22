' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class OriginalMessages
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            AddRule(New ValidateRequired("MessageKey"))
            AddRule(New ValidateRequired("Message"))
        End Sub

        Public Property IdNo As Integer
        Public Property MessageKey As String
        Public Property Message As String
        Public Property Caption As String
        Public Property Notes As String
    End Class
End NameSpace