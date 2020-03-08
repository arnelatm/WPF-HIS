Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    ' Category business object
    ' ** Enterprise Design Pattern: Domain Model, Identity Field
    Public Class Country
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("CountryName"))
                AddRule(New ValidateLength("ISOA2", 2, 2))
                AddRule(New ValidateLength("ISOA3", 3, 3))
                AddRule(New ValidateRegex("ISON", "\d{1,4}"))
                AddRule(New ValidateRegex("PhoneCode", "\d{1,4}"))
            End If
        End Sub

        Public Property IdNo As Integer
        Public Property Isoa2 As String
        Public Property CountryName As String
        Public Property CountryNameAra As String
        Public Property Nationality As String
        Public Property NationalityAra As String
        Public Property Flag32 As String
        Public Property Flag128 As String
        Public Property Isoa3 As String
        Public Property Ison As String
        Public Property PhoneCode As String
    End Class

End Namespace