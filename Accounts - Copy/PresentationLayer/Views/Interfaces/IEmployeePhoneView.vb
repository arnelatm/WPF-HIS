Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeePhoneView
        Inherits IView
        Property AreaCode As String
        Property CountryTelIdNo As Int16
        Property CountryTelCode As String
        Property EmployeeIdNo As Int32
        Property FullPhone As String
        Property FullPhoneAra As String
        Property IdNo As Int32
        Property PhoneNumber As String
        Property PhoneTypeIdNo As Int16
        Property PhoneTypeName As String
        Property PhoneTypeNameAra As String
        Property Sequence As Int16
    End Interface

End Namespace