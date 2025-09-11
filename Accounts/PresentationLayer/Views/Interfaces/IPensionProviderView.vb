Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPensionProviderView
        Inherits IView
        Property Active As Boolean
        Property BankAccountNo As String
        Property BankIdNo As Int16?
        Property ContactDesignation As String
        Property ContactPerson As String
        Property CountryCode As String
        Property District As String
        Property Email As String
        Property Fax As String
        Property Iban As String
        Property IdNo As Int32
        Property Mobile As String
        Property Notes As String
        Property PaymentMethod As String
        Property Phone1 As String
        Property Phone2 As String
        Property PoBox As String
        Property ProvinceState As String
        Property Street As String
        Property PensionProviderCode As String
        Property PensionProviderName As String
        Property PensionProviderNameAra As String
        Property TownCity As String
        Property Website As String
        Property ZipCode As String

    End Interface

End Namespace