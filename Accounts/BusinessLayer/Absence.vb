' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Absence
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeIdNo"))
                AddRule(New ValidateRequired("AbsenceType"))
            End If

        End Sub

        Public Property AbsenceReason As String
        Public Property AbsenceType As Char
        Public Property AddedBy As Int16
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property EquivalentHours As Decimal
        Public Property IdNo As Int32
        Public Property PayrollIdNo As Int16

    End Class

End Namespace