Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IOriginalCaptionsView
        Inherits IView
        Property IdNo As Int32
        Property Caption As String
        Property TranslatedCaption As String
        Property IdNoTranslated As Integer
        ReadOnly Property LanguageIdNo As Int32
    End Interface

End Namespace