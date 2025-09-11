Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interface

    Public Interface ITranslatedMessagesView
        Inherits IView
        Property IdNo As Int32
        Property MessageIdNo As Int16
        Property LanguageIdNo As Int16
        Property TranslatedMessage As String
        Property TranslatedCaption As String
    End Interface

End Namespace