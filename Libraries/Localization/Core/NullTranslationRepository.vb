Namespace Core
    Public Class NullTranslationRepository
        Implements ITranslationRepository

        Public Function GetViewTranslations(culture As String, systemViewId As Integer) As IDictionary(Of String, String) _
            Implements ITranslationRepository.GetViewTranslations
            Return New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        End Function

        Public Function CultureHasTranslations(culture As String) As Boolean _
            Implements ITranslationRepository.CultureHasTranslations
            Return False
        End Function

        Public Function GetLanguageId(culture As String) As Integer _
            Implements ITranslationRepository.GetLanguageId
            Return 0
        End Function

        Public Function GetFallbackLanguageId(culture As String) As Integer _
            Implements ITranslationRepository.GetFallbackLanguageId
            Return 0
        End Function

        Public Function GetFallbackMessage(messageKey As String, culture As String) As String _
            Implements ITranslationRepository.GetFallbackMessage
            Return String.Empty
        End Function
    End Class
End Namespace