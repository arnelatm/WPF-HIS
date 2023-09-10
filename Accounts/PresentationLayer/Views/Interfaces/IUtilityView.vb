Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces
    Public Interface IUtilityView
        Inherits IView

        Event UtilityButtonClicked(parameters As Object)
        ReadOnly Property UtilityName As String


    End Interface

End Namespace
