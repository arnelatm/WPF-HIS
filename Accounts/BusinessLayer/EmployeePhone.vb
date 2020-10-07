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
                AddRule(New ValidateRequired("PhoneNumber"))
            End If
        End Sub

        Public Property AreaCode As String
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32
        Public Property CountryTelIdNo As Int16
        Public Property PhoneTypeIdNo As Int16
        Public Property PhoneNumber As String
        Public Property Sequence As Int16
        Public Property FullPhone As String
        Public Property FullPhoneAra As String
    End Class

End Namespace