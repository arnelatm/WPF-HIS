Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ITranslatedCaptionsView
        Inherits IView
        Property IdNo As Integer
        Property Caption As String
        Property LanguageIdNo As Integer
        Property TranslatedCaption As String
        Property CaptionIdNo as Integer
        Property CultureInfoCode As String
        Property LanguageCode2 As String
    End Interface

End Namespace