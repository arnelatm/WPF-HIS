' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeePhone
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("PhoneIdNo"))
            End If
        End Sub

        Public Property AreaCode As String
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32
        Public Property CountryTelCode As String
        Public Property PhoneTypeIdNo As Int16
        Public Property PhoneNumber As String
        Public Property Sequence As Int16
    End Class

End Namespace