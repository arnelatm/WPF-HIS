Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IOriginalMessagesView
        Inherits IView

        Property Caption As String
        Property IdNo As Integer
        Property IdNoTranslated As Integer
        ReadOnly Property LanguageIdNo As Integer
        Property Message As String
        Property MessageKey As String
        Property Notes As String
        Property TranslatedCaption As String
        Property TranslatedMessage As String

    End Interface

End Namespace