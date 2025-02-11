' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeeAbsence
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
        Public Property AbsenceType As String
        Public Property AddedByUser As Int16
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32

        Public Property EndDate As DateTime?
        Public Property EquivalentHours As Decimal

        Public Property IdNo As Int32
        Public Property PayrollIdNo As Int16

        Public Property PayrollName As String
        Public Property PayrollNameAra As String
        Public Property StartDate As DateTime?
        Public Property UserName As String

    End Class

End Namespace