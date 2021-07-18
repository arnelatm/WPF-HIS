' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules
Imports AATM.Libraries
Imports AATM.Libraries.Lookup

Namespace BusinessLayer

    Public Class SalaryLoanSchedule
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeIdNo"))
                AddRule(New ValidateRequired("StartDate"))
                AddRule(New ValidateContent("Amount", 0, ValidationOperator.GreaterThan, ValidationDataType.Decimal))
                AddRule(New ValidateContent("PeriodicPayment", 0, ValidationOperator.GreaterThan, ValidationDataType.Decimal))
                AddRule(New ValidateCompare("Amount", "PeriodicPayment", ValidationOperator.GreaterThan, ValidationDataType.Decimal))
            End If

        End Sub

        Public Property Amount As Decimal
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32
        Public Property PeriodicPayment As Decimal
        Public Property StartDate As Date?

    End Class

End Namespace