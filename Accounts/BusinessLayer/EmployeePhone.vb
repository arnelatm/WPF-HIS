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
        Public Property CountryTelCode As String
        Public Property CountryTelIdNo As Int16
        Public Property EmployeeIdNo As Int32
        Public Property FullPhone As String
        Public Property FullPhoneAra As String
        Public Property IdNo As Int32
        Public Property PhoneNumber As String
        Public Property PhoneTypeIdNo As Int16
        Public Property PhoneTypeName As String
        Public Property PhoneTypeNameAra As String
        Public Property Sequence As Int16
    End Class

End Namespace