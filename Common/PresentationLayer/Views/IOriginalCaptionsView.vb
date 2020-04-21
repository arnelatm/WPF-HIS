Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IOriginalCaptionsView
        Inherits IView
        Property IdNo As Integer
        Property Caption As String
        Property TranslatedCaption As String
        Property IdNoTranslated As Integer
        ReadOnly Property LanguageIdNo As Integer
    End Interface

End Namespace