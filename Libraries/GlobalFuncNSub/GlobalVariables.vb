Imports System.Configuration
Imports System.Drawing
Imports System.Globalization
Imports AutoMapper

Public Class GlobalVariables
    Private Shared _useOriginalAppTextLanguageForEnglish As Nullable(Of Boolean)
    Private Shared _maximumOpenForms As Int16
    Private Shared _appCultureInfo As CultureInfo
    Private Shared _appCurrentCultureInfo As CultureInfo
    Private Shared _defaultUnmirroredCultureInfoStr As String

    'Private Shared _defaultMirroredLanguageIdNo As Integer
    Private Shared _defaultMirroredCultureInfoStr As String

    Private Shared _defaultCountryIsoa3 As String = ""
    Private Shared _originalCultureUiInfo As CultureInfo = CultureInfo.CurrentUICulture
    Private Shared _defaultFormBackgroundColor As Nullable(Of Color)
    Private Shared _defaultFormForegroundColor As Nullable(Of Color)
    Private Shared _defaultFormControlBackgroundColor As Nullable(Of Color)
    Private Shared _defaultFormControlForegroundColor As Nullable(Of Color)
    Private Shared _defaultFormControlReadOnlyBackgroundColor As Nullable(Of Color)
    Private Shared _defaultFormControlReadOnlyForegroundColor As Nullable(Of Color)
    Private Shared _defaultFormControlEditingBackgroundColor As Nullable(Of Color)
    Private Shared _defaultFormControlEditingForegroundColor As Nullable(Of Color)

    Public Shared ReadOnly Property OriginalAppTextLanguage As String = "en-PH"

    Public Shared ReadOnly Property OriginalAppTextLanguageIdNo As Int16 = 0

    Public Shared EventAggregator As New EventAggregator()
    Public Shared EaEmployee As New EventAggregator()

    'Private _ltrCultureInfo As CultureInfo
    'Private _rtlCultureINfo As CultureInfo
    'Public Shared Property CurrentAppCultureInfo as CultureInfo

    Public Shared Property IsUserLoggedIn As Boolean = False

    Public Shared Property UserName As String

    Public Shared Property RightToLeftLayout As Boolean = False

    Public Shared Property SecurityGroupIdNo As Integer = 0

    Public Shared Property UserIdNo As Integer

#Region "Colors"

    Public Shared Property DefaultFormBackgroundColor As Color
        Get
            If _defaultFormBackgroundColor Is Nothing Then
                Dim cColor As String
                cColor = ConfigurationManager.AppSettings("DefaultFormBackgroundColor")
                If Not (cColor Is Nothing Or cColor = "") Then
                    _defaultFormBackgroundColor = System.Drawing.Color.FromName(cColor)
                Else
                    _defaultFormBackgroundColor = Color.LemonChiffon
                End If
            End If
            Return _defaultFormBackgroundColor
        End Get
        Set
            _defaultFormBackgroundColor = Value
        End Set
    End Property

    Public Shared Property DefaultFormForegroundColor As Color
        Get
            If _defaultFormForegroundColor Is Nothing Then
                Dim cColor As String
                cColor = ConfigurationManager.AppSettings("DefaultFormForegroundColor")
                If Not (cColor Is Nothing Or cColor = "") Then
                    _defaultFormForegroundColor = System.Drawing.Color.FromName(cColor)
                Else
                    _defaultFormForegroundColor = Color.Black
                End If
            End If
            Return _defaultFormForegroundColor
        End Get
        Set
            _defaultFormForegroundColor = Value
        End Set
    End Property

    Public Shared Property DefaultFormControlBackgroundColor As Color
        Get
            If _defaultFormControlBackgroundColor Is Nothing Then
                Dim cColor As String
                cColor = ConfigurationManager.AppSettings("DefaultFormControlBackgroundColor")
                If Not (cColor Is Nothing Or cColor = "") Then
                    _defaultFormControlBackgroundColor = System.Drawing.Color.FromName(cColor)
                Else
                    _defaultFormControlBackgroundColor = Color.White
                End If
            End If
            Return _defaultFormControlBackgroundColor
        End Get
        Set
            _defaultFormControlBackgroundColor = Value
        End Set
    End Property

    Public Shared Property DefaultFormControlForegroundColor As Color
        Get
            If _defaultFormControlForegroundColor Is Nothing Then
                Dim cColor As String
                cColor = ConfigurationManager.AppSettings("DefaultFormControlForegroundColor")
                If Not (cColor Is Nothing Or cColor = "") Then
                    _defaultFormControlForegroundColor = System.Drawing.Color.FromName(cColor)
                Else
                    _defaultFormControlForegroundColor = Color.Black
                End If
            End If
            Return _defaultFormControlForegroundColor
        End Get
        Set
            _defaultFormControlForegroundColor = Value
        End Set
    End Property

    Public Shared Property DefaultFormControlReadOnlyBackgroundColor As Color
        Get
            If _defaultFormControlReadOnlyBackgroundColor Is Nothing Then
                Dim cColor As String
                cColor = ConfigurationManager.AppSettings("DefaultFormControlReadOnlyBackgroundColor")
                If Not (cColor Is Nothing Or cColor = "") Then
                    _defaultFormControlReadOnlyBackgroundColor = System.Drawing.Color.FromName(cColor)
                Else
                    _defaultFormControlReadOnlyBackgroundColor = Color.White
                End If
            End If
            Return _defaultFormControlReadOnlyBackgroundColor
        End Get
        Set
            _defaultFormControlReadOnlyBackgroundColor = Value
        End Set
    End Property

    Public Shared Property DefaultFormControlReadOnlyForegroundColor As Color
        Get
            If _defaultFormControlReadOnlyForegroundColor Is Nothing Then
                Dim cColor As String
                cColor = ConfigurationManager.AppSettings("DefaultFormControlReadOnlyForegroundColor")
                If Not (cColor Is Nothing Or cColor = "") Then
                    _defaultFormControlReadOnlyForegroundColor = System.Drawing.Color.FromName(cColor)
                Else
                    _defaultFormControlReadOnlyForegroundColor = Color.Black
                End If
            End If
            Return _defaultFormControlReadOnlyForegroundColor
        End Get
        Set
            _defaultFormControlReadOnlyForegroundColor = Value
        End Set
    End Property

    Public Shared Property DefaultFormControlEditingBackgroundColor As Color
        Get
            If _defaultFormControlEditingBackgroundColor Is Nothing Then
                Dim cColor As String
                cColor = ConfigurationManager.AppSettings("DefaultFormControlEditingBackgroundColor")
                If Not (cColor Is Nothing Or cColor = "") Then
                    _defaultFormControlEditingBackgroundColor = System.Drawing.Color.FromName(cColor)
                Else
                    _defaultFormControlEditingBackgroundColor = Color.Blue
                End If
            End If
            Return _defaultFormControlEditingBackgroundColor
        End Get
        Set
            _defaultFormControlEditingBackgroundColor = Value
        End Set
    End Property

    Public Shared Property DefaultFormControlEditingForegroundColor As Color
        Get
            If _defaultFormControlEditingForegroundColor Is Nothing Then
                Dim cColor As String
                cColor = ConfigurationManager.AppSettings("DefaultFormControlEditingForegroundColor")
                If Not (cColor Is Nothing Or cColor = "") Then
                    _defaultFormControlEditingForegroundColor = System.Drawing.Color.FromName(cColor)
                Else
                    _defaultFormControlEditingForegroundColor = Color.White
                End If
            End If
            Return _defaultFormControlEditingForegroundColor
        End Get
        Set
            _defaultFormControlEditingForegroundColor = Value
        End Set
    End Property

#End Region

    Public Shared Property Mapper As AutoMapper.Mapper
    'Public Shared Property Mapper As IMapper
    'Public Shared Property Mapper As MapperConfiguration

    Public Shared Property AppCurrentCultureInfo() As CultureInfo
        Get
            Try
                Dim useComputerCultureInfo As Boolean
                Dim cultureInfoStr As String
                useComputerCultureInfo = ConfigurationManager.AppSettings("UseComputerCultureInfo")
                If useComputerCultureInfo Then
                    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture
                    cultureInfoStr = CultureInfo.CurrentCulture.Name
                    _appCurrentCultureInfo = CultureInfo.CurrentCulture
                Else
                    cultureInfoStr = ConfigurationManager.AppSettings("CultureInfo")
                    If IsNothing(_appCurrentCultureInfo) Then
                        cultureInfoStr = ConfigurationManager.AppSettings("CultureInfo")
                        _appCurrentCultureInfo = New CultureInfo(cultureInfoStr)
                    End If
                End If
            Catch
                _appCurrentCultureInfo = New CultureInfo("en-GB")
            End Try
            Return _appCurrentCultureInfo
        End Get
        Set(value As CultureInfo)
            _appCurrentCultureInfo = value
        End Set
    End Property

    Public Shared ReadOnly Property MaximumOpenForms() As Int16
        Get
            Try
                If _maximumOpenForms > 0 Then
                    Return _maximumOpenForms
                End If
                Return Convert.ToInt16(ConfigurationManager.AppSettings("MaximumOpenForms"))
            Catch
                _maximumOpenForms = 8
                Return _maximumOpenForms
            End Try
        End Get
    End Property

    Public Shared ReadOnly Property UseOriginalAppTextLanguageForEnglish() As Boolean
        Get
            Try
                If _useOriginalAppTextLanguageForEnglish Is Nothing Then
                    Return ConfigurationManager.AppSettings("UseOriginalAppTextLanguageForEnglish")
                End If
            Catch
                _useOriginalAppTextLanguageForEnglish = True
            End Try
            Return True
        End Get
    End Property

    Public Shared Property AppLanguage As String = "en-GB"

    Public Shared Property OriginalCultureInfo As CultureInfo = CultureInfo.CurrentCulture

    Public Shared Property AppCultureInfo As CultureInfo
        Get
            Try
                Dim useComputerCultureInfo As Boolean
                Dim cultureInfoStr As String
                useComputerCultureInfo = ConfigurationManager.AppSettings("UseComputerCultureInfo")
                If useComputerCultureInfo Then
                    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture
                    cultureInfoStr = CultureInfo.CurrentCulture.Name
                    _appCultureInfo = CultureInfo.CurrentCulture
                Else
                    cultureInfoStr = ConfigurationManager.AppSettings("CultureInfo")
                    If IsNothing(_appCultureInfo) Then
                        cultureInfoStr = ConfigurationManager.AppSettings("CultureInfo")
                        _appCultureInfo = New CultureInfo(cultureInfoStr)
                    End If
                End If
            Catch
                _appCultureInfo = New CultureInfo("en-GB")
            Finally
                If CultureInfo.CurrentCulture.Name <> _appCultureInfo.Name Then
                    CultureInfo.CurrentCulture = _appCultureInfo
                End If
                CultureInfo.DefaultThreadCurrentCulture = _appCultureInfo
            End Try
            Return _appCultureInfo
        End Get
        Set
            Dim current As CultureInfo = CultureInfo.CurrentCulture
            _appCultureInfo = Value
            If current.Name <> _appCultureInfo.Name Then
                CultureInfo.CurrentCulture = _appCultureInfo
            End If
            CultureInfo.DefaultThreadCurrentCulture = _appCultureInfo
        End Set
    End Property

    Public Shared Property DefaultUnmirroredCultureInfoStr As String
        Get
            Dim cultureInfoStr = ""
            Try
                If _defaultUnmirroredCultureInfoStr Is Nothing Then
                    Dim useComputerCultureInfo As Boolean

                    useComputerCultureInfo = ConfigurationManager.AppSettings("UseComputerCultureInfo")
                    If useComputerCultureInfo Then
                        If Not CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                            cultureInfoStr = CultureInfo.CurrentCulture.Name
                        End If
                    Else
                        ' get application setup string
                        cultureInfoStr = ConfigurationManager.AppSettings("DefaultUnmirroredCultureInfoStr")
                        If IsNothing(cultureInfoStr) Then
                            If Not CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                                cultureInfoStr = CultureInfo.CurrentCulture.Name
                            End If
                        End If
                    End If
                Else
                    ' return the stored value
                    cultureInfoStr = _defaultUnmirroredCultureInfoStr
                End If
            Catch
                ''
            Finally
                If String.IsNullOrEmpty(cultureInfoStr) Then
                    If String.IsNullOrEmpty(ConfigurationManager.AppSettings("DefaultUnmirroredCultureInfoStr")) Then
                        cultureInfoStr = "en-US"
                    Else
                        cultureInfoStr = ConfigurationManager.AppSettings("DefaultUnmirroredCultureInfoStr")
                    End If
                End If
            End Try
            _defaultUnmirroredCultureInfoStr = cultureInfoStr
            Return _defaultUnmirroredCultureInfoStr
        End Get
        Set
            _defaultUnmirroredCultureInfoStr = Value
        End Set
    End Property

    Public Shared Property DefaultMirroredCultureInfoStr As String
        Get
            Dim cultureInfoStr = ""
            Try
                If _defaultMirroredCultureInfoStr Is Nothing Then
                    Dim useComputerCultureInfo As Boolean

                    useComputerCultureInfo = ConfigurationManager.AppSettings("UseComputerCultureInfo")
                    If useComputerCultureInfo Then
                        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                            cultureInfoStr = CultureInfo.CurrentCulture.Name
                        End If
                    Else
                        ' get application setup string
                        cultureInfoStr = ConfigurationManager.AppSettings("DefaultMirroredCultureInfoStr")
                        If IsNothing(cultureInfoStr) Then
                            If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                                cultureInfoStr = CultureInfo.CurrentCulture.Name
                            End If
                        End If
                    End If
                Else
                    ' return the stored value
                    cultureInfoStr = _defaultMirroredCultureInfoStr
                End If
            Catch
                ''
            Finally
                If String.IsNullOrEmpty(cultureInfoStr) Then
                    If String.IsNullOrEmpty(ConfigurationManager.AppSettings("DefaultMirroredCultureInfoStr")) Then
                        cultureInfoStr = "ar-SA"
                    Else
                        cultureInfoStr = ConfigurationManager.AppSettings("DefaultMirroredCultureInfoStr")
                    End If
                End If
            End Try
            _defaultMirroredCultureInfoStr = cultureInfoStr
            Return _defaultMirroredCultureInfoStr
        End Get
        Set
            _defaultMirroredCultureInfoStr = Value
        End Set
    End Property

    Public Shared Property DefaultCountryIsoa3
        Get
            If _defaultCountryIsoa3 Is Nothing Then
                _defaultCountryIsoa3 = ConfigurationManager.AppSettings("DefaultCountryISOA3")
            End If
            Return _defaultCountryIsoa3
        End Get
        Set(value)
            _defaultCountryIsoa3 = value
        End Set
    End Property

    'Private Shared Sub GetAppCultureInfo()
    '    If _AppLanguage = "" Then
    '        Try
    '            _AppLanguage = ConfigurationManager.AppSettings("CultureInfo")
    '        Catch
    '            _AppLanguage = "en"
    '        Finally

    '        End Try

    '        'Return _AppLanguage
    '    End If

    '    'Dim rWriter As IResourceWriter
    '    'If _AppLanguage = "" Then
    '    '    Try
    '    '        Dim reader As New ResourceReader("HIS.Language")
    '    '        Dim dEnum As IDictionaryEnumerator = reader.GetEnumerator()

    '    '        While dEnum.MoveNext()
    '    '            Select Case dEnum.Key
    '    '                Case "DefaultLanguage"
    '    '                    _AppLanguage = dEnum.Value
    '    '                    Exit Select
    '    '                Case Else
    '    '                    _AppLanguage = "English"
    '    '            End Select
    '    '        End While
    '    '        reader.Close()
    '    '    Catch
    '    '        rWriter = New ResourceWriter("HIS.Language")
    '    '        rWriter.AddResource("DefaultLanguage", "English")
    '    '        rWriter.Close()
    '    '        _AppLanguage = "English"
    '    '    Finally
    '    '        If _AppLanguage = "" Then
    '    '            _AppLanguage = "English"
    '    '        End If
    '    '    End Try
    '    'End If
    'End Sub

    'Public Shared Sub SetLanguage(ByVal NewLanguage As String)
    '    _AppLanguage = NewLanguage
    'End Sub
End Class