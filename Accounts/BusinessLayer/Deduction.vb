' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Deduction
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("DeductionName"))
                AddRule(New ValidateRequired("DeductionCode"))
                AddRule(New ValidateRequired("DeductionType"))
                AddRule(New ValidateRequired("CalculationType"))
                AddRule(New ValidateRequired("AccountIdNo"))
            End If
        End Sub

        Public Property AccountIdNo As Int16
        Public Property BasePaymentIdNo As Int16
        Public Property CalculationType As Char
        Public Property DefaultQuantity As Decimal
        Public Property DeductionCode As String
        Public Property DeductionName As String
        Public Property DeductionNameAra As String
        Public Property DeductionType As Char
        Public Property Frequency As Char
        Public Property IdNo As Int16
        Public Property FactorValue As String
        Public Property FactorType As Char
        Public Property Notes As String
        Public Property Rate As Decimal
        Public Property Unit As Char
        Public Property UsePayGroups As Boolean
        Public Property PayrollDeductAccounts As List(Of PayrollDeductAccount)
    End Class

End Namespace