Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ITranslatedMessagesView
        Inherits IView
        Property TranslatedMessageIdNo As Int32
        Property MessageIdNo As Int16
        Property LanguageIdNo As Int16
        Property TranslatedMessage As String
        Property TranslatedCaption As String
    End Interface

End Namespace