Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IInternationalPhoneView
        Inherits IView
        Property IdNo() As Int16
        Property CountryTelCode() As String
        Property CountryName() As String
        Property CountryNameAra() As String
    End Interface

End Namespace