' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class RecurringPayElement
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeIdNo"))
                AddRule(New ValidateRequired("StartDate"))
                AddRule(New ValidateRequired("RecurType"))
                'AddRule(New ValidateContent("LimitAmount", 0, ValidationOperator.GreaterThan, ValidationDataType.Decimal))
                AddRule(New ValidateContent("PeriodicAmount", 0, ValidationOperator.GreaterThan, ValidationDataType.Decimal))
                'AddRule(New ValidateCompare("LimitAmount", "PeriodicAmount", ValidationOperator.GreaterThan, ValidationDataType.Decimal))
            End If

        End Sub

        Public Property Active As Boolean
        Public Property LimitAmount As Decimal
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property EndDate As Date?
        Public Property IdNo As Int32
        Public Property PayElementIdNo As Int16
        Public Property PeriodicAmount As Decimal
        Public Property RecurType As String
        Public Property StartDate As Date?
        Public Property TotalAmount As Decimal

    End Class

End Namespace