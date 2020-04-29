Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ITranslatedCaptionView
        Inherits IView

        Property IdNo As Int32
        Property Caption As String
        Property CaptionIdNo As Int32
        Property LanguageIdNo As Int32
        Property TranslatedCaption As String
    End Interface

End Namespace