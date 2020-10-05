Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeePhoneView
        Inherits IView
        Property AreaCode As String
        Property CountryTelCode As String
        Property PhoneNumber As String
        Property PhoneTypeIdNo As Int16
        Property EmployeeIdNo As Int32
        Property IdNo As Int32
        Property Sequence As Int16
    End Interface

End Namespace