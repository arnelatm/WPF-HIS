Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class SupplierModel

        Public Property AccountStatus As String
        Public Property Active As Boolean
        Public Property ApAccountIdNo As Int32?
        Public Property BankAccountNo As String
        Public Property BankIdNo As Int16?
        Public Property ContactDesignation As String
        Public Property ContactPerson As String
        Public Property CountryCode As String
        Public Property CreditLimit As Single
        Public Property CrNumber As String
        Public Property DateAccountOpen As Date?
        Public Property District As String
        Public Property Email As String
        Public Property Errors As List(Of String)
        Public Property ExpAccountIdNo As Int32?
        Public Property Fax As String
        Public Property Iban As String
        Public Property IdNo As Integer
        Public Property Mobile As String
        Public Property Notes As String
        Public Property OpeningBalance As Single
        Public Property PaymentDueDays As Int16
        Public Property PaymentMethod As String
        Public Property Phone1 As String
        Public Property Phone2 As String
        Public Property PoBox As String
        Public Property ProvinceState As String
        Public Property SettlementDiscount As Decimal
        Public Property SettlementDueDays As Int16
        Public Property Street As String
        Public Property SupplierCode As String
        Public Property SupplierName As String
        Public Property SupplierNameAra As String
        Public Property TownCity As String
        Public Property VatNumber As String
        Public Property Website As String
        Public Property ZipCode As String

    End Class

End Namespace