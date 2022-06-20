Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class CustomerModel
        'Implements IModelNew

        Public Property AccountStatus As String
        Public Property Active As Boolean
        Public Property ArAccountIdNo As Int16?
        Public Property Balance As Decimal
        Public Property BankAccountNo As String
        Public Property BankIdNo As Int16?
        Public Property ContactDesignation As String
        Public Property ContactPerson As String
        Public Property CountryCode As String
        Public Property CreditLimit As Decimal
        Public Property CrNumber As String
        Public Property CustomerCode As String
        Public Property CustomerName As String
        Public Property CustomerNameAra As String
        Public Property DateAccountOpen As Date?
        Public Property DiscountSchemeIdNo As Int16?
        Public Property District As String
        Public Property Email As String
        Public Property Errors As List(Of String)
        Public Property Fax As String
        Public Property Iban As String
        Public Property IdNo As Int32
        Public Property Mobile As String
        Public Property Notes As String
        Public Property OpeningBalance As Decimal
        Public Property PaymentDueDays As Int16
        Public Property PaymentMethod As String
        Public Property Phone1 As String
        Public Property Phone2 As String
        Public Property PoBox As String
        Public Property ProvinceState As String
        Public Property RevAccountIdNo As Int16?
        Public Property SettlementDiscount As Decimal
        Public Property SettlementDueDays As Int16
        Public Property Street As String
        Public Property TownCity As String
        Public Property VatNumber As String
        Public Property Website As String
        Public Property ZipCode As String
    End Class

End Namespace