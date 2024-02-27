' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeeLeaveEarned
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeIdNo"))
                AddRule(New ValidateRequired("StartDate"))
                AddRule(New ValidateRequired("EndDate"))
                AddRule(New ValidateRequired("Reason"))
                AddRule(New ValidateCompare("StartDate", "EndDate", ValidationOperator.LessThanOrEqual, ValidationDataType.Date))
                AddRule(New ValidateRange("EndDate", Date.MinValue, Date.Today, ValidationDataType.Date))
                AddRule(New ValidateContent("DaysEarned", 0, ValidationOperator.GreaterThan, ValidationDataType.Decimal))
            End If

        End Sub

        Public Property DateCreated As DateTime?
        Public Property DaysEarned As Decimal
        Public Property EmployeeIdNo As Int32
        Public Property EndDate As Date?
        Public Property EnteredBy As Int32
        Public Property IdNo As Int32
        Public Property LeaveIdNo As Int16
        Public Property Reason As String
        Public Property StartDate As Date?


    End Class

End Namespace