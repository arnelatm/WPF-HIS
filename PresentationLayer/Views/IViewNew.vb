' marker interface, no members

Imports System.Globalization
Imports System.Windows.Forms

Public Interface IViewNew

    Property ViewDisplayName As String
    Property CaptionCollection As Collection
    ReadOnly Property FormName As String
    Property RightToLeftDisplay As String
    Property FormCulture As CultureInfo
    Event ArabicDisplayRequested()
    Event OrigLanguageDisplayRequested()
    Event FormTranslating(sender As Object)
    Event FormLoaded(sender As Object, captionCollection As Collection)
    Event FormCaptionTranslator(vSystemViewIdNo As Short)


    ' No members..
End Interface