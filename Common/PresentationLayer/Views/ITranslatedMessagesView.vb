Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ITranslatedMessagesView
        Inherits IView
        Property TranslatedMessageIdNo As Int32
        Property MessageIdNo As Int32
        Property LanguageIdNo As Int32
        Property TranslatedMessage As String
        Property TranslatedCaption As String
    End Interface

End Namespace