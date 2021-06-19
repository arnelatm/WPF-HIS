Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IReligionView
        Inherits IView
        Property IdNo As Int16
        Property ReligionCode As String
        Property ReligionName As String
        Property ReligionNameAra As String
        Property Notes As String
    End Interface

End Namespace