Namespace Core
    Public Interface ITranslationRepository
        ' Returns translation key/value pairs for a given culture + view.
        Function GetViewTranslations(culture As String, systemViewId As Integer) As IDictionary(Of String, String)

        ' Does the culture have any translations at all (for fallback logic)?
        Function CultureHasTranslations(culture As String) As Boolean

        ' Returns Languages.IdNo by culture code; 0 if not found.
        Function GetLanguageId(culture As String) As Integer

        ' Finds best fallback language IdNo using base culture part (e.g. "en" from "en-GB").
        Function GetFallbackLanguageId(culture As String) As Integer

        ' Gets a fallback message (for message keys) using base culture code.
        Function GetFallbackMessage(messageKey As String, culture As String) As String
    End Interface
End Namespace