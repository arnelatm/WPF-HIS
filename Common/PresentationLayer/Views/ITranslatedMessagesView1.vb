Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ITranslatedMessagesView1
        Inherits IView
        Property IdNo As Integer
        Property OriginalIdNo As Integer
        Property LanguageIdNo As Integer
        Property TranslatedMessage As String
        Property TranslatedCaption As String
        Property MessageKey As String
        Property Message As String
        Property Caption As String
        Property IdNoOrig
        Property Notes As String
        Property CultureInfoCode As String
        Property LanguageCode2 As String
    End Interface

End Namespace