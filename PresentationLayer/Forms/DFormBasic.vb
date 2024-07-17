Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports System.Windows.Forms
Imports AATM.PresentationLayer.Views
Imports System.Globalization
Imports System.ComponentModel
Imports AATM.Libraries.MessagingLibrary

Public Class DFormBasic
    Implements IViewNew

    Private _debugSwitch As Byte = 0
    Private _displayedRightToLeft As Boolean = False
    Private _firstLoadSwitch As Integer = 0
    Private _formCulture As CultureInfo
    Private _initialDisplayIsRightToLeft As Boolean
    Private _originalText As String
    Private _systemViewIdNo As Int32
    Protected Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = False
        If ViewDisplayName Is Nothing OrElse ViewDisplayName = "" Then
            ViewDisplayName = Name
        End If
        _formCulture = GlobalVariables.AppCurrentCultureInfo
        LanguageCode = GetCultureLanguageCode(_formCulture)
        If IsRightToLeft(LanguageCode) Then
            _initialDisplayIsRightToLeft = True
        Else
            _initialDisplayIsRightToLeft = False
        End If
    End Sub

    Public Event ArabicDisplayRequested() Implements IViewNew.ArabicDisplayRequested
    Public Event FormCaptionTranslator(formTranslator As Object, cform As Object) Implements IViewNew.FormCaptionTranslator
    Public Event FormLoaded(sender As Object, captionCollection As Collection, allControls As List(Of Control)) Implements IViewNew.FormLoaded
    Public Event OrigLanguageDisplayRequested() Implements IViewNew.OrigLanguageDisplayRequested
    Public Event MakeDataRequested(tableName As String, ByRef variableName As DataTable) Implements IViewNew.MakeDataRequested
    Public Property CaptionCollection As New Collection Implements IViewNew.CaptionCollection

    Public Overridable Sub OnMakeDataRequested(tableName As String, ByRef variableName As DataTable)
        RaiseEvent MakeDataRequested(tableName, variableName)
    End Sub

    Public Property FormCulture As CultureInfo Implements IViewNew.FormCulture
        Get
            If _formCulture Is Nothing Then
                _formCulture = GlobalVariables.AppCurrentCultureInfo
                LanguageCode = GetCultureLanguageCode(_formCulture)
            End If
            Return _formCulture
        End Get
        Set(value As CultureInfo)
            _formCulture = value
            Dim cultureCode As String = Strings.Left(value.Name, 2)
            If IsRightToLeft(cultureCode) Then
                SwitchDisplayToArabicLanguage()
                _displayedRightToLeft = True
            Else
                If _initialDisplayIsRightToLeft Then
                    SwitchDisplayToOriginalLanguage()
                Else
                    If _displayedRightToLeft Then
                        SwitchDisplayToOriginalLanguage()
                    Else
                        ' no need to switch since we haven't yet displayed RightToLeft Layout
                        ' only switch if we have already displayed in RightToLeft Layout
                    End If

                End If
            End If
            LanguageCode = GetCultureLanguageCode(value)
        End Set
    End Property

    Public Property LanguageCode As String Implements IViewNew.LanguageCode
    Public Property RightToLeftDisplay As String Implements IViewNew.RightToLeftDisplay
    Public Property ViewDisplayName As String Implements IViewNew.ViewDisplayName

    Protected Property VSystemViewIdNo As Short
        Get
            Return GetSystemViewIdNo(Me)
        End Get
        Set(value As Short)
            _systemViewIdNo = value
        End Set
    End Property
    Protected Sub DFormBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _firstLoadSwitch = 0 Then
            RaiseEvent FormLoaded(sender, CaptionCollection, AllControls)
            _firstLoadSwitch = 1
        End If
        If FormCulture Is Nothing Then
            FormCulture = GlobalVariables.AppCurrentCultureInfo
        End If
        'If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
        '    TextDisplayLanguage = CultureInfo.CurrentCulture.Name
        'End If
        'RaiseEvent BeforeLoad()
    End Sub

    Protected Sub SwitchDisplayToOriginalLanguage()
        Me.Visible = False
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            Dim cultureCode As String = GlobalVariables.DefaultUnmirroredCultureInfoStr
            If IsCultureInfoNameOk(cultureCode) Then
                FormCulture = New CultureInfo(cultureCode, False)
                RightToLeftDisplay = False
                RightToLeft = RightToLeft.No
                btnArabic.Visible = True
                btnOriginal.Visible = False
                btnArabic.Enabled = True
                btnOriginal.Enabled = False
                RaiseEvent OrigLanguageDisplayRequested()
            Else
                MessageBox.Show("Invalid DefaultMirroredCultureInfoStr " & cultureCode & ".")
            End If
        End If
        Me.Visible = True
    End Sub

    Private Sub BtnArabic_Click(sender As Object, e As EventArgs) Handles btnArabic.Click
        SwitchDisplayToArabicLanguage()
    End Sub

    Private Sub btnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
        If _debugSwitch = 0 Then
            _debugSwitch = 1
            Debugger.Break()
            btnDebug.Checked = False
        Else
            _debugSwitch = 0
            btnDebug.Checked = True
        End If
    End Sub

    Private Sub btnOriginal_Click(sender As Object, e As EventArgs) Handles btnOriginal.Click
        SwitchDisplayToOriginalLanguage()
    End Sub
    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        CheckIfDebug()
        Close()
    End Sub

    Private Sub btnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        CheckIfDebug()
        Dim frm As New TranslationTableManager With {
            .SystemViewIdNoToTranslate = VSystemViewIdNo,
            .AppDataDAC = New Dac,
            .TranslatorDAC = New Dac
        }
        frm.Show()
    End Sub

    Private Sub CheckIfDebug()
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        CopyText()
    End Sub

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        CutText()
    End Sub
    Private Sub DFormBasic_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If FormCulture.TextInfo.IsRightToLeft Then
            RightToLeftDisplay = True
            RightToLeft = RightToLeft.Yes
        Else
            RightToLeftDisplay = False
            RightToLeft = RightToLeft.No
        End If
        If RightToLeftDisplay Then
            btnArabic.Visible = False
            btnOriginal.Visible = True
        Else
            btnArabic.Visible = True
            btnOriginal.Visible = False
        End If
    End Sub

    Private Sub SwitchDisplayToArabicLanguage()
        Me.Visible = False
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            Dim cultureCode = GlobalVariables.DefaultMirroredCultureInfoStr
            If IsCultureInfoNameOk(cultureCode) AndAlso IsRightToLeft(cultureCode) Then
                btnArabic.Visible = False
                btnOriginal.Visible = True
                btnArabic.Enabled = False
                btnOriginal.Enabled = True
                RightToLeftDisplay = True
                Dim curFormCulture As CultureInfo
                curFormCulture = New CultureInfo(cultureCode, False)
                _formCulture = curFormCulture
                RightToLeft = RightToLeft.Yes
                TranslateForm(Me, AllControls)
                RaiseEvent ArabicDisplayRequested()
            Else
                MessageBox.Show("Invalid DefaultMirroredCultureInfoStr " & cultureCode & ".")
            End If
        End If
        Me.Visible = True
    End Sub

End Class
