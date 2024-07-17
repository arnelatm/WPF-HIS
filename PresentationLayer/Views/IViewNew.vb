' marker interface, no members

Imports System.Globalization
Imports System.Windows.Forms

Public Interface IViewNew

    Event ArabicDisplayRequested()
    Event FormCaptionTranslator(formTranslator As Object, cForm As Object)
    Event FormLoaded(sender As Object, captionCollection As Collection, allControls As List(Of Control))
    Event OrigLanguageDisplayRequested()

    Property CaptionCollection As Collection
    Property FormCulture As CultureInfo
    Property RightToLeftDisplay As String
    Property ViewDisplayName As String
    Property LanguageCode As String

End Interface