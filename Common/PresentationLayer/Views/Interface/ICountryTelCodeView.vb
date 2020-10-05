Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface ICountryTelCodeView
        Inherits IView

        Property IdNo As Int16
        Property CountryName As String
        Property CountryNameAra As String
        Property CountryTelCode As String

    End Interface

End Namespace