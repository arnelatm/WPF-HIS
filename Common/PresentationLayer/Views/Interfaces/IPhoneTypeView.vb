Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IPhoneTypeView
        Inherits IView
        Property IdNo As Byte
        Property PhoneTypeCode As String
        Property PhoneTypeName As String
        Property PhoneTypeNameAra As String
        Property Notes As String
    End Interface

End Namespace