Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICustomerView
        Inherits IView
        Property IdNo As Integer
        Property CustomerCode As String
        Property CustomerName As String
        Property CustomerNameAra As String
        Property ContactPerson As String
        Property ContactDesignation As String
        Property Street As String
        Property District As String
        Property TownCity As String
        Property ProvinceState As String
        Property CountryCode As String
        Property PoBox As String
        Property ZipCode As String
        Property Phone1 As String
        Property Phone2 As String
        Property Mobile As String
        Property Fax As String
        Property Email As String
        Property Website As String
        Property VatNumber As String
        Property CrNumber As String
        Property AccountStatus As String
        Property ArAccountIdNo As Int32?
        Property RevAccountIdNo As Int32?
        Property DiscountSchemeIdNo As Int16?
        Property CreditLimit As Single
        Property SettlementDueDays As Int16
        Property SettlementDiscount As Decimal
        Property PaymentDueDays As Int16
        Property DateAccountOpen As Date?
        Property BankIdNo As Int16?
        Property BankAccountNo As String
        Property Iban As String
        Property PaymentMethod As String
        Property Notes As String
        Property OpeningBalance As Single
        Property Active As Boolean
    End Interface

End Namespace