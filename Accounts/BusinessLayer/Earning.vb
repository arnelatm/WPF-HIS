' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Earning
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EarningName"))
                AddRule(New ValidateRequired("EarningCode"))
            End If
        End Sub

        Public Property AccountIdNo As Int16
        Public Property Frequency As Char
        Public Property EarningCode As String
        Public Property EarningName As String
        Public Property EarningNameAra As String
        Public Property EarningType As Char
        Public Property IdNo As Int16
        Public Property Notes As String
        Public Property PayrollEarnAccounts As List(Of PayrollEarnAccount)
    End Class

End Namespace