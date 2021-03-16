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
                AddRule(New ValidateRequired("EarningType"))
                AddRule(New ValidateRequired("CalculationType"))
            End If
        End Sub

        Public Property AccountIdNo As Int16
        Public Property BasePaymentIdNo As Int16
        Public Property CalculationType As Char
        Public Property DefaultQuantity As Decimal
        Public Property EarningCode As String
        Public Property Summary As Boolean
        Public Property EarningName As String
        Public Property EarningNameAra As String
        Public Property EarningType As Char
        Public Property Frequency As Char
        Public Property IdNo As Int16
        Public Property IncludeInEos As Boolean
        Public Property FactorValue As Decimal
        Public Property FactorType as String
        Public Property Notes As String
        Public Property Rate As Decimal
        Public Property Taxable As Boolean
        Public Property Unit As Char
        Public Property UnitAttendance As Char
        Public Property UsePayGroups As Boolean
        Public Property PayrollEarnAccounts As List(Of PayrollEarnAccount)
        Public Property EarningsSummary As List(Of EarningSummary)

    End Class

End Namespace