Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ICountryView
        Inherits IView

        Property IdNo As Int16
        Property Isoa2 As String
        Property CountryName As String
        Property CountryNameAra As String
        Property Nationality As String
        Property NationalityAra As String
        Property Isoa3 As String
        Property Ison As String
        Property Flag32 As String
        Property Flag128 As String
        Property PhoneCode As String
    End Interface

End Namespace