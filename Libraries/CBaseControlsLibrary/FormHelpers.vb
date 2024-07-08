Imports System.Drawing
Imports System.Globalization
Imports System.Reflection
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
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

    Public Sub MakeFormRightToLeft(pForm As Form, allControls As List(Of Control))
        For Each cCtrl As Control In GlobalFunctions.FindControlRecursive(allControls, pForm)
            If TypeOf cCtrl Is CButton OrElse TypeOf cCtrl Is Button Then
                If GlobalFuncNSub.GetPropertyValue(cCtrl, "Image") IsNot Nothing Then
                    Dim btnImageName As String
                    btnImageName = (cCtrl.Name.ToString() + "_" + Strings.Left(CultureInfo.CurrentCulture.Name, 2)).ToLower()
                    Dim resource As Object = My.Resources.ResourceManager.GetObject(btnImageName)
                    If Not (resource Is Nothing) Then
                        Dim i = CType(cCtrl, CButton)
                        i.Image = DirectCast(resource, Image)
                    End If
                ElseIf TypeOf cCtrl Is CTabControl OrElse TypeOf cCtrl Is TabControl Then
                    Dim c = CType(cCtrl, CTabControl)
                    c.RightToLeftLayout = True
                    c.RightToLeft = RightToLeft.No
                End If
            End If
        Next cCtrl
    End Sub

    'Public Function FindControlRecursive(ByVal list As List(Of Control), ByVal parentControl As Control) As List(Of Control)
    '    If parentControl Is Nothing Then Return list
    '    list.Add(parentControl)
    '    For Each child As Control In parentControl.Controls
    '        FindControlRecursive(list, child)
    '    Next
    '    Return list
    'End Function


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


'Public Class FormFunctions

'    Public Shared Function GetFormByName(ByVal formName As String) As Form
'        Dim T As Type = GetFormObjectByName(formName)
'        Return CType(Activator.CreateInstance(T), Form)
'    End Function

'    Private Shared Function GetFormObjectByName(formName As String) As Type
'        'first try: in case the full namespace has been provided (as it should ;-) )
'        Dim T As Type = Type.GetType(formName, False)
'        'if not found, search for it
'        If T Is Nothing Then T = FindType(formName)
'        'if still not found, throw exception
'        If T Is Nothing Then Throw New Exception(formName + " could not be found")
'        Return T
'    End Function

'    'Public Shared Function GetFormByName(ByVal formName As String, parameter As ArrayList) As Form
'    '    Dim T As Type = GetFormObjectByName(formName)
'    '    Return CType(Activator.CreateInstance(T, parameter), Form)
'    'End Function

'    Public Shared Function GetFormByName(ByVal formName As String, report As ReportModel) As Form
'        Dim T As Type = GetFormObjectByName(formName)
'        Return CType(Activator.CreateInstance(T, report), Form)
'    End Function

'#Region "Assemblies and types"

'    Public Shared Function GetAllAssemblies() As ArrayList
'        Dim al As New ArrayList
'        Dim a As [Assembly] = [Assembly].GetEntryAssembly()
'        FillAssemblies(a, al)
'        Return al
'    End Function

'    Private Shared Sub FillAssemblies(ByVal a As [Assembly], ByVal al As ArrayList)
'        If Not al.Contains(a) Then
'            al.Add(a)
'            Dim an As AssemblyName
'            For Each an In a.GetReferencedAssemblies()
'                If Not an.Name.StartsWith("System") Then FillAssemblies([Assembly].Load(an), al)
'            Next
'        End If
'    End Sub

'    Public Shared Function GetAllTypes() As ArrayList
'        Dim a As [Assembly], t As Type, al As New ArrayList
'        For Each a In GetAllAssemblies()
'            For Each t In a.GetTypes
'                If Not al.Contains(t) Then al.Add(t)
'            Next
'        Next
'        Return al
'    End Function

'    Public Shared Function FindType(ByVal Name As String) As Type
'        Dim T As Type
'        For Each T In GetAllTypes()
'            If T.Name = Name Then Return T
'        Next
'        Return Nothing
'    End Function

'#End Region

'End Class

''example call:
''Dim f As Form = FormFunctions.GetFormByName("Form1")
''f.Show()