Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PensionProviderModel
        Public Property Active As Boolean
        Public Property BankAccountNo As String
        Public Property BankIdNo As Int16?
        Public Property ContactDesignation As String
        Public Property ContactPerson As String
        Public Property CountryCode As String
        Public Property District As String
        Public Property Email As String
        Public Property Errors As List(Of String)
        Public Property Fax As String
        Public Property Iban As String
        Public Property IdNo As Int32
        Public Property Mobile As String
        Public Property Notes As String
        Public Property PaymentMethod As String
        Public Property Phone1 As String
        Public Property Phone2 As String
        Public Property PoBox As String
        Public Property ProvinceState As String
        Public Property Street As String
        Public Property PensionProviderCode As String
        Public Property PensionProviderName As String
        Public Property PensionProviderNameAra As String
        Public Property TownCity As String
        Public Property Website As String
        Public Property ZipCode As String

    End Class

End Namespace