Imports AATM.Libraries

Namespace AATM.Libraries.Localization.Core
    Public Class TranslationRepository
        Implements ITranslationRepository

        Private ReadOnly _dac As Dac
        Public Sub New(dac As Dac)
            _dac = dac
        End Sub

        Public Function GetViewTranslations(culture As String, systemViewId As Integer) As IDictionary(Of String, String) _
            Implements ITranslationRepository.GetViewTranslations
            Dim cmd = "Select Caption, TranslatedCaption from SystemViewItemOriginal_view " &
                      "where SystemViewIdNo = " & systemViewId & " and CultureInfoCode = '" & culture & "'"
            Dim ds = _dac.ReturnDs(cmd)
            Dim dict = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim key = CStr(row("Caption"))
                    Dim val = CStr(row("TranslatedCaption"))
                    If Not dict.ContainsKey(key) Then dict.Add(key, val)
                Next
            End If
            Return dict
        End Function

        Public Function CultureHasTranslations(culture As String) As Boolean _
            Implements ITranslationRepository.CultureHasTranslations
            Dim cmd = "SELECT COUNT(*) FROM TranslatedCaption_View WHERE CultureInfoCode = '" & culture.TrimEnd() & "'"
            Return _dac.ExecScalar(Of Integer)(cmd) > 0
        End Function

        Public Function GetLanguageId(culture As String) As Integer _
            Implements ITranslationRepository.GetLanguageId
            Dim cmd = "Select IdNo from Languages where CultureInfoCode = '" & culture & "'"
            Return _dac.ExecScalar(Of Integer)(cmd)
        End Function

        Public Function GetFallbackLanguageId(culture As String) As Integer _
            Implements ITranslationRepository.GetFallbackLanguageId
            Dim baseCode = culture.Split("-"c)(0)
            Dim cmd = "SELECT TOP 1 LanguageIdNo,COUNT(LanguageIdNo) AS value_occurrence " &
                      "FROM TranslatedCaption_View where RTrim(LanguageCode2) = '" & baseCode & "' " &
                      "GROUP BY LanguageIdNo ORDER BY value_occurrence DESC"
            Return _dac.ExecScalar(Of Integer)(cmd)
        End Function

        Public Function GetFallbackMessage(messageKey As String, culture As String) As String _
            Implements ITranslationRepository.GetFallbackMessage
            Dim baseCode = culture.Split("-"c)(0)
            Dim cmd = "SELECT TranslatedCaption from TranslatedMessages_View " &
                      "where Caption = '" & messageKey.Replace("'", "''") & "' and RTrim(LanguageCode2) = '" & baseCode & "'"
            Return _dac.ExecScalar(Of String)(cmd)
        End Function
    End Class
End Namespace