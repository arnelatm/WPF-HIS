Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ISupplierView
        Inherits IView

        Property AccountStatus As String
        Property Active As Boolean
        Property ApAccountIdNo As Int16?
        Property BankAccountNo As String
        Property BankIdNo As Int16?
        Property ContactDesignation As String
        Property ContactPerson As String
        Property CountryCode As String
        Property CreditLimit As Decimal
        Property CrNumber As String
        Property DateAccountOpen As Date?
        Property District As String
        Property Email As String
        Property ExpAccountIdNo As Int16?
        Property Fax As String
        Property Iban As String
        Property IdNo As Int32
        Property Mobile As String
        Property Notes As String
        Property OpeningBalance As Decimal
        Property PaymentDueDays As Int16
        Property PaymentMethod As String
        Property Phone1 As String
        Property Phone2 As String
        Property PoBox As String
        Property ProvinceState As String
        Property SettlementDiscount As Decimal
        Property SettlementDueDays As Int16
        Property Street As String
        Property SupplierCode As String
        Property SupplierName As String
        Property SupplierNameAra As String
        Property TownCity As String
        Property VatNumber As String
        Property Website As String
        Property ZipCode As String

    End Interface

End Namespace