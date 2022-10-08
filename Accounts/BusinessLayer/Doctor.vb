' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Doctor
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeIdNo"))
                'AddRule(New ValidateRequired("SpecialtyIdNo"))
            End If

        End Sub

        Public Property DateCreated As DateTime?
        Public Property DoctorCode As String
        Public Property DoctorName As String
        Public Property DoctorNameAra As String
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32
        Public Property SpecialtyIdNo As Int32


    End Class

End Namespace