Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeePhoneModel
        Public Property AreaCode As String
        Public Property CountryTelCode As String
        Public Property CountryTelIdNo As Int16
        Public Property EmployeeIdNo As Int32
        Public Property Errors As List(Of String)
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