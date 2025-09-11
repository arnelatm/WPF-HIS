Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IOriginalMessagesView
        Inherits IView

        Property Caption As String
        Property IdNo As Int32
        Property IdNoTranslated As Integer
        ReadOnly Property LanguageIdNo As Int16
        Property Message As String
        Property MessageKey As String
        Property Notes As String
        Property TranslatedCaption As String
        Property TranslatedMessage As String

    End Interface

End Namespace