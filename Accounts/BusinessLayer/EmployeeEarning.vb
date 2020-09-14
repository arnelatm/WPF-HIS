' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeeEarning
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeEarningName"))
                AddRule(New ValidateRequired("EmployeeEarningCode"))
            End If
        End Sub

        Public Property AccountIdNo As Int32
        Public Property Amount As Decimal
        Public Property DefaultFrequency As String
        Public Property EarningCode As String
        Public Property EarningIdNo As Int16
        Public Property EarningName As String
        Public Property EarningNameAra As String
        Public Property EarningType As String
        Public Property EmployeeIdNo As Int32
        Public Property Frequency As Char
        Public Property IdNo As Int32
        Public Property PayFrequency As Char
        Public Property Percentage As Decimal

    End Class

End Namespace