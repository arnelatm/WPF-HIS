Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    ' Category business object
    ' ** Enterprise Design Pattern: Domain Model, Identity Field

    Public Class Customer
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("CustomerName"))
                AddRule(New ValidateRequired("CustomerNameAra"))
                'AddRule(New ValidateRequired("CustomerCode"))
                AddRule(New ValidateEmail("Email"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property CustomerCode As String
        Public Property CustomerName As String
        Public Property CustomerNameAra As String
        Public Property ContactPerson As String
        Public Property ContactDesignation As String
        Public Property Street As String
        Public Property District As String
        Public Property TownCity As String
        Public Property ProvinceState As String
        Public Property CountryCode As String
        Public Property PoBox As String
        Public Property ZipCode As String
        Public Property Phone1 As String
        Public Property Phone2 As String
        Public Property Mobile As String
        Public Property Fax As String
        Public Property Email As String
        Public Property Website As String
        Public Property VatNumber As String
        Public Property CrNumber As String
        Public Property AccountStatus As String
        Public Property ArAccountIdNo As Int16?
        Public Property RevAccountIdNo As Int16?
        Public Property CreditLimit As Decimal
        Public Property SettlementDueDays As Int16
        Public Property SettlementDiscount As Decimal
        Public Property PaymentDueDays As Int16
        Public Property DateAccountOpen As Date?
        Public Property BankIdNo As Int16?
        Public Property BankAccountNo As String
        Public Property Iban As String
        Public Property PaymentMethod As String
        Public Property Notes As String
        Public Property OpeningBalance As Decimal
        Public Property DiscountSchemeIdNo As Int16?
        Public Property Active As Boolean
    End Class

End Namespace