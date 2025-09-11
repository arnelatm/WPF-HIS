Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IOriginalCaptionsView
        Inherits IView
        Property IdNo As Int32
        Property Caption As String
        Property TranslatedCaption As String
        Property IdNoTranslated As Integer
        ReadOnly Property LanguageIdNo As Int16
    End Interface

End Namespace