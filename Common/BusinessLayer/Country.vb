Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    ' Category business object
    ' ** Enterprise Design Pattern: Domain Model, Identity Field
    Public Class Country
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("CountryName"))
                AddRule(New ValidateLength("CountryCode", 2, 2))
                AddRule(New ValidateLength("IsoA3", 3, 3))
                AddRule(New ValidateRegex("IsoN", "\d{3}"))
                AddRule(New ValidateRegex("CountryTelCode", "\d{1,7}"))
            End If
        End Sub

        Public Property IdNo As Int16
        Public Property CountryCode As String
        Public Property CountryName As String
        Public Property CountryNameAra As String
        Public Property Nationality As String
        Public Property NationalityAra As String
        Public Property Flag32 As String
        Public Property Flag128 As String
        Public Property IsoA3 As String
        Public Property IsoN As String
        Public Property CountryTelCode As String
    End Class

End Namespace