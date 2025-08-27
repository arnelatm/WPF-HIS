Imports System.Collections.Concurrent

Namespace Core
    Public Class TranslationCache
        Private ReadOnly _repo As ITranslationRepository
        Private ReadOnly _cache As New ConcurrentDictionary(Of String, IDictionary(Of String, String))(StringComparer.OrdinalIgnoreCase)

        Public Sub New(repo As ITranslationRepository)
            _repo = repo
        End Sub

        Private Shared Function Key(culture As String, viewId As Integer) As String
            Return culture & "_" & viewId
        End Function

        Public Function GetOrAdd(culture As String, viewId As Integer) As IDictionary(Of String, String)
            Return _cache.GetOrAdd(
                Key(culture, viewId),
                Function(k) _repo.GetViewTranslations(culture, viewId))
        End Function

        Public Sub Preload(cultures As IEnumerable(Of String), viewIds As IEnumerable(Of Integer))
            For Each c In cultures
                For Each v In viewIds
                    GetOrAdd(c, v)
                Next
            Next
        End Sub

        Public Sub Clear()
            _cache.Clear()
        End Sub
    End Class
End Namespace