' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class ShiftSummary
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("UserIdNo"))
                AddRule(New ValidateRequired("DateStart"))
                AddRule(New ValidateRequired("DateEnd"))
                AddRule(New ValidateCompare("DateStart", "DateEnd", ValidationOperator.LessThanOrEqual, ValidationDataType.Date))
            End If

        End Sub

        Public Property Cards As Decimal
        Public Property Cash As Decimal
        Public Property DateCreated As DateTime?
        Public Property DateEnd As DateTime
        Public Property DateStart As DateTime
        Public Property IdNo As Int32
        Public Property UserIdNo As Int16

    End Class

End Namespace