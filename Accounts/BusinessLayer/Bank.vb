' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Bank
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            AddRule(New ValidateRequired("BankName"))
        End Sub

        Public Property IdNo As Integer
        Public Property BankCode As String
        Public Property BankName As String
        Public Property BankNameAra As String
        Public Property Description As String
    End Class
End NameSpace