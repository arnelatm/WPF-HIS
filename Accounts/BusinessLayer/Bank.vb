' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Bank
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("BankName"))
                AddRule(New ValidateRequired("BankCode"))
                AddRule(New ValidateCompare("BankCode", "BankName", ValidationOperator.NotEqual, ValidationDataType.String))
                AddRule(New ValidateLength("BankName", 5, 10))
                AddRule(New ValidateRange("BankName", "A", "J", ValidationDataType.String))
                AddRule(New ValidateRequiredOne({"BankCode", "BankName"}))
            End If
        End Sub

        Public Property IdNo As Int16
        Public Property BankCode As String
        Public Property BankName As String
        Public Property BankNameAra As String
        Public Property Notes As String
    End Class

End Namespace