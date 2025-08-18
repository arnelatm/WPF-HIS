Imports System.Data

Namespace AATM.Libraries.HelperLibraries

    ''' <summary>
    ''' Provides global translation caching and retrieval for all forms/views/languages.
    ''' </summary>
    Public NotInheritable Class TranslationUtility
        Private Sub New()
        End Sub

        ' Global translation cache: key = "lang_viewId", value = translation dictionary
        Private Shared ReadOnly _globalTranslationCache As New Dictionary(Of String, Dictionary(Of String, String))(StringComparer.OrdinalIgnoreCase)

        ''' <summary>
        ''' Preloads translations for multiple languages and views into the global cache.
        ''' </summary>
        ''' <param name="languages">Enumerable of language codes (e.g., "en-US").</param>
        ''' <param name="viewIds">Enumerable of view IDs.</param>
        ''' <param name="translatorDac">Instance of your data access component.</param>
        Public Shared Sub PreloadTranslations(languages As IEnumerable(Of String), viewIds As IEnumerable(Of Integer), translatorDac As Object)
            For Each lang In languages
                For Each viewId In viewIds
                    Dim cacheKey = lang & "_" & viewId
                    If Not _globalTranslationCache.ContainsKey(cacheKey) Then
                        Dim cmd As String = "Select Caption, translatedCaption from SystemViewItemOriginal_view where LanguageIdNo = " & viewId.ToString() & " and CultureInfoCode = '" & lang & "'"
                        Dim ds As DataSet = translatorDac.ReturnDs(cmd)
                        Dim dict As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
                        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                            Dim table = ds.Tables(0)
                            If table.Columns.Contains("Caption") AndAlso table.Columns.Contains("translatedCaption") Then
                                For Each row As DataRow In table.Rows
                                    Dim key = Convert.ToString(row("Caption"))
                                    Dim value = Convert.ToString(row("translatedCaption"))
                                    If Not dict.ContainsKey(key) Then
                                        dict.Add(key, value)
                                    End If
                                Next
                            End If
                        End If
                        _globalTranslationCache(cacheKey) = dict
                    End If
                Next
            Next
        End Sub

        ''' <summary>
        ''' Gets the translation dictionary for a specific language and view.
        ''' </summary>
        ''' <param name="language">Language code (e.g., "en-US").</param>
        ''' <param name="viewId">View ID.</param>
        ''' <param name="translatorDac">Instance of your data access component.</param>
        ''' <returns>Dictionary of translations for the given language and view.</returns>
        Public Shared Function GetTranslationDictionary(language As String, viewId As Integer, translatorDac As Object) As Dictionary(Of String, String)
            Dim cacheKey = language & "_" & viewId
            If _globalTranslationCache.ContainsKey(cacheKey) Then
                Return _globalTranslationCache(cacheKey)
            End If

            ' Fallback: load and cache on demand
            Dim cmd As String = "Select Caption, translatedCaption from SystemViewItemOriginal_view where LanguageIdNo = " & viewId.ToString() & " and CultureInfoCode = '" & language & "'"
            Dim ds As DataSet = translatorDac.ReturnDs(cmd)
            Dim dict As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                Dim table = ds.Tables(0)
                If table.Columns.Contains("Caption") AndAlso table.Columns.Contains("translatedCaption") Then
                    For Each row As DataRow In table.Rows
                        Dim key = Convert.ToString(row("Caption"))
                        Dim value = Convert.ToString(row("translatedCaption"))
                        If Not dict.ContainsKey(key) Then
                            dict.Add(key, value)
                        End If
                    Next
                End If
            End If
            _globalTranslationCache(cacheKey) = dict
            Return dict
        End Function

        ''' <summary>
        ''' Clears the global translation cache.
        ''' </summary>
        Public Shared Sub ClearCache()
            _globalTranslationCache.Clear()
        End Sub

    End Class

End Namespace