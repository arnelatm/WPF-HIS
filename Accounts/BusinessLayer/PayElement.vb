' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PayElement
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("PayElementKind"))
                AddRule(New ValidateRequired("PayElementName"))
                AddRule(New ValidateRequired("PayElementCode"))
                AddRule(New ValidateRequired("PayElementType"))
                AddRule(New ValidateRequired("CalculationType"))
            End If
        End Sub

        Public Property AccountIdNo As Int16
        Public Property Active As Boolean
        Public Property BasePaymentIdNo As Int16
        Public Property CalculationType As Char
        Public Property DefaultQuantity As Decimal
        Public Property PayElementCode As String
        Public Property PayElementKind As String
        Public Property PayElementName As String
        Public Property PayElementNameAra As String
        Public Property PayElementType As Char
        Public Property ReportGroupIdNo As Int16
        Public Property FactorType As String
        Public Property FactorValue As Decimal
        Public Property Frequency As Char
        Public Property IdNo As Int16
        Public Property IncludeInEos As Boolean
        Public Property Notes As String
        Public Property QuantityType As Char
        Public Property Rate As Decimal
        Public Property Summary As Boolean
        Public Property Taxable As Boolean
        Public Property Unit As Char
        Public Property UsePayGroups As Boolean
        Public Property UsePayGroupSetting As Boolean
        Public Property PayElementAccounts As List(Of PayElementAccount)
        Public Property PayElementItems As List(Of PayElementItem)

    End Class

End Namespace