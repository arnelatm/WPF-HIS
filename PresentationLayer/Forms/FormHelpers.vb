Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary

Public Module FormHelpers

    Public Function GetFallBackLanguageIdNo(TranslatorDAC As Dac, ByVal desiredLanguage As String) As Int16
        Dim cmd As String
        Dim fallBackLanguageIdNo As Int16
        Dim languageBaseCode = Strings.Left(desiredLanguage, desiredLanguage.IndexOf("-", StringComparison.Ordinal))
        cmd = "SELECT TOP 1 LanguageIdNo,COUNT(LanguageIdNo) AS value_occurrence FROM TranslatedCaption_View where RTrim(LanguageCode2) = '" + languageBaseCode + "' " +
              "GROUP BY LanguageIdNo ORDER BY value_occurrence DESC"
        fallBackLanguageIdNo = TranslatorDAC.ExecScalar(Of Int16)(cmd)
        Return fallBackLanguageIdNo
    End Function

    Public Function GetFallBackMessage(TranslatorDAC As Dac, ByVal message As String, ByVal desiredLanguage As String) As String
        Dim cmd As String
        Dim languageBaseCode = Strings.Left(desiredLanguage, desiredLanguage.IndexOf("-", StringComparison.Ordinal))
        cmd = "SELECT TranslatedCaption from TranslatedMessages_View where Caption = '" + RTrim(message) + "' and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
        Return TranslatorDAC.ExecScalar(Of String)(cmd)
    End Function

    Public Function GetSystemViewIdNo(TranslatorDAC As Dac, ViewDisplayName As String, Name As String)
        Dim cmd As String
        If ViewDisplayName Is Nothing Or ViewDisplayName = "" Then
            ViewDisplayName = Name
        End If
        cmd = "SELECT IdNo FROM SystemView where SystemViewName ='" + ViewDisplayName.Trim() + "'"
        Return TranslatorDAC.ExecScalar(Of Int16)(cmd)
    End Function

    Public Function GetTranslations(TranslatorDAC As Dac, targetLanguageIdNo As Integer, viewDisplayName As String, formName As String) As DataSet
        Dim cmd As String = "Select Caption, translatedCaption from SystemViewItemOriginal_view where LanguageIdNo = " + targetLanguageIdNo.ToString() + " and SystemViewIdNo = " + GetSystemViewIdNo(TranslatorDAC, viewDisplayName, formName).ToString()
        Dim translations As DataSet
        translations = TranslatorDAC.ReturnDs(cmd)
        Return translations
    End Function

    Public Function GetTargetLanguageIdNo(translatorDAC As Dac, desiredLanguage As String, allowFallBack As Boolean) As Short
        Dim cmd As String
        Dim desiredLanguageIdNo As Int16
        Dim fallBackLanguageIdNo As Int16
        Dim fallBackLanguage As String
        Dim targetLanguageIdNo As Int16
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            cmd = "Select IdNo from Languages where cultureInfoCode = '" + desiredLanguage + "'"
            desiredLanguageIdNo = translatorDAC.ExecScalar(Of Int16)(cmd)
            If desiredLanguageIdNo = 0 Then
                targetLanguageIdNo = 0
            Else
                If Not TranslationLanguageExist(translatorDAC, desiredLanguage) Then
                    If allowFallBack Then
                        fallBackLanguageIdNo = GetFallBackLanguageIdNo(translatorDAC, desiredLanguage)
                        cmd = "Select cultureInfoCode from Languages where IdNo = " + fallBackLanguageIdNo.ToString()
                        fallBackLanguage = translatorDAC.ExecScalar(Of String)(cmd)
                        If Not AATM.Libraries.GlobalFuncNSub.GlobalFunctions.NeedToTranslateText(fallBackLanguage) Then
                            targetLanguageIdNo = 0
                        Else
                            targetLanguageIdNo = fallBackLanguageIdNo
                        End If
                    Else
                        targetLanguageIdNo = 0
                    End If
                Else
                    targetLanguageIdNo = desiredLanguageIdNo
                End If
            End If
        End If
        Return targetLanguageIdNo
    End Function

    Public Function TranslationLanguageExist(translatorDac As Dac, ByVal desiredLanguage As String)
        Dim cmd As String
        cmd = "SELECT count(*) FROM TranslatedCaption_View WHERE CultureInfoCode = '" _
              + desiredLanguage.TrimEnd + "'"
        Dim howMany As Integer = translatorDac.ExecScalar(Of Integer)(cmd)
        If howMany > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetFieldType(obj As Object, fieldName As String) As Type
        If Invoker.GetProperty(obj, fieldName) IsNot Nothing Then
            Return Invoker.GetProperty(obj, fieldName).GetType
        End If
        Return Nothing
    End Function

End Module


Public Class ControlSettingsSaver

    Private _top As UInt16
    Private _left As UInt16
    Private _width As UInt16
    Private _height As UInt16
    Private _visible As Boolean

    Public Sub SaveSetting(control As Control)
        _top = Math.Max(control.Top, 0)
        _left = Math.Max(control.Left, 0)
        _width = control.Width
        _height = control.Height
        _visible = control.Visible
    End Sub

    Public Sub RestoreSetting(control As Control)
        control.Top = _top
        control.Left = _left
        control.Width = _width
        control.Height = _height
        control.Visible = _visible
    End Sub

End Class

