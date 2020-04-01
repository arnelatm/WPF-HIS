Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ITranslatedCaptionView
        Inherits IView

        Property IdNo As Integer
        Property Caption As String
        Property CaptionIdNo As Integer
        Property LanguageIdNo As Integer
        Property TranslatedCaption As String

    End Interface

End Namespace