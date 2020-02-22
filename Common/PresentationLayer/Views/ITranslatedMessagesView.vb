Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ITranslatedMessagesView
        Inherits IView
        Property IdNo As Integer
        Property OriginalIdNo As Integer
        Property LanguageIdNo As Integer
        Property TranslatedMessage As String
        Property TranslatedCaption As String

    End Interface

End Namespace