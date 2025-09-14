Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Globalization


''' <summary>
''' Manages localized strings for the application.
''' It loads localization data from a repository and provides a single point of access.
''' </summary>
Public Class LocalizationService
    Implements ILocalizationService

    Private ReadOnly _localizationRepository As ILocalizationRepository
    Private ReadOnly _languages As New List(Of (display As String, code As String))()
    ' The primary dictionary holds the language code, and the nested dictionary
    ' holds the UIIdentifier and the translated string.
    Private ReadOnly _localizedStrings As New Dictionary(Of String, Dictionary(Of String, String))()
    Private _currentLanguageCode As String = "en-US"
    Private _isRightToLeft As Boolean = False
    Private Const DEFAULT_LANGUAGE_CODE As String = "en-US"

    Public Sub New(localizationRepository As ILocalizationRepository)
        _localizationRepository = localizationRepository
        LoadLanguages()
        LoadAllLocalizedStrings()
    End Sub

    ''' <summary>
    ''' Gets a localized string for a specific UI element in the current language.
    ''' If the translation is not found, the original string is returned.
    ''' </summary>
    ''' <param name="uiIdentifier">The unique identifier of the UI element (e.g., "btnSave").</param>
    ''' <param name="originalString">The original, untranslated text (e.g., "Save").</param>
    ''' <returns>The localized string or the original string if not found.</returns>
    Public Function GetString(uiIdentifier As String, originalString As String) As String Implements ILocalizationService.GetString
        ' Check if we have translations for the current language.
        If _localizedStrings.ContainsKey(_currentLanguageCode) Then
            ' Check if the specific UI element has a translation.
            Dim translationsForLang As Dictionary(Of String, String) = _localizedStrings(_currentLanguageCode)
            If translationsForLang.ContainsKey(uiIdentifier) Then
                Return translationsForLang(uiIdentifier)
            End If
        End If

        ' If no translation is found, return the original string.
        Return originalString
    End Function

    ''' <summary>
    ''' Adds a new localized string to the database or updates an existing one.
    ''' </summary>
    Public Sub AddOrUpdateString(moduleName As String, uiIdentifier As String, originalString As String, languageCode As String, localizedString As String) Implements ILocalizationService.AddOrUpdateString
        _localizationRepository.AddOrUpdateLocalization(originalString, moduleName, uiIdentifier, languageCode, localizedString)
        ' After adding or updating in the database, reload the in-memory cache.
        LoadAllLocalizedStrings()
    End Sub

    Public Sub SetLanguage(languageCode As String) Implements ILocalizationService.SetLanguage
        If _languages.Any(Function(lang) lang.code = languageCode) Then
            _currentLanguageCode = languageCode
            Dim culture As New CultureInfo(languageCode)
            _isRightToLeft = culture.TextInfo.IsRightToLeft
        End If
    End Sub

    Public Function GetAvailableLanguages() As List(Of (display As String, code As String)) Implements ILocalizationService.GetAvailableLanguages
        Return _languages.ToList()
    End Function

    Public ReadOnly Property IsRightToLeft As Boolean Implements ILocalizationService.IsRightToLeft
        Get
            Return _isRightToLeft
        End Get
    End Property

    Private Sub LoadLanguages()
        ' In a real-world app, this would be loaded from a configuration or a database table.
        _languages.Add(("English", "en-US"))
        _languages.Add(("Arabic", "ar-SA"))
    End Sub

    ''' <summary>
    ''' Loads all localized strings from the repository into memory.
    ''' This should be called once on application startup or after a translation is saved.
    ''' </summary>
    Private Sub LoadAllLocalizedStrings()
        _localizedStrings.Clear()
        For Each language In _languages
            Dim localizedStringsForLang As New Dictionary(Of String, String)()
            Dim translations As List(Of TranslationDTO) = _localizationRepository.GetLocalizedStrings(language.code)
            For Each translation As TranslationDTO In translations
                ' We use the UIIdentifier as the lookup key for the string.
                localizedStringsForLang(translation.UIIdentifier) = translation.LocalizedString
            Next
            _localizedStrings(language.code) = localizedStringsForLang
        Next
    End Sub
End Class



'Imports System.Collections.Generic
'Imports System.Globalization
'Imports System.IO
'Imports AATM.Core.Configuration
'Imports Newtonsoft.Json

'''' <summary>
'''' A concrete implementation of ILocalizationService.
'''' This class holds the logic for loading and providing localized strings.
'''' </summary>
'Public Class LocalizationService
'    Implements ILocalizationService


'    Private ReadOnly _languages As New Dictionary(Of String, (strings As Dictionary(Of String, Dictionary(Of String, String)), isRtl As Boolean))
'    Private ReadOnly _languageDisplayNames As New Dictionary(Of String, String)
'    Private ReadOnly _configService As IConfigurationService
'    Private _currentLanguage As String = "en-US" ' Default language
'    Private _isRightToLeft As Boolean
'    Private ReadOnly _strings As Dictionary(Of String, Dictionary(Of String, String))
'    Private ReadOnly _defaultLanguage As String = "en-US"
'    Private ReadOnly _localizedStrings As New Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String)))


'    Public Sub New(configService As IConfigurationService)
'        ' Initialize English language strings
'        'Dim englishStrings As New Dictionary(Of String, Dictionary(Of String, String))
'        'englishStrings("CustomerModule") = New Dictionary(Of String, String) From
'        '{
'        '    {"CustomerFormTitle", "Customer Management"},
'        '    {"FirstNameLabel", "First Name"},
'        '    {"LastNameLabel", "Last Name"},
'        '    {"EmailLabel", "Email"},
'        '    {"LanguageLabel", "Language"},
'        '    {"SaveButtonText", "Save"},
'        '    {"DeleteButtonText", "Delete"},
'        '    {"ClearButtonText", "Clear"},
'        '    {"CustomerSaved", "Customer saved successfully."},
'        '    {"CustomerDeleted", "Customer deleted successfully."},
'        '    {"ValidationError", "Validation Error: "}
'        '}
'        '_languages.Add("en-US", (englishStrings, False))
'        '_languageDisplayNames.Add("en-US", "English")

'        '' Initialize Arabic language strings
'        'Dim arabicStrings As New Dictionary(Of String, Dictionary(Of String, String))
'        'arabicStrings("CustomerModule") = New Dictionary(Of String, String) From
'        '{
'        '    {"CustomerFormTitle", "إدارة العملاء"},
'        '    {"FirstNameLabel", "الاسم الأول"},
'        '    {"LastNameLabel", "الاسم الأخير"},
'        '    {"EmailLabel", "البريد الإلكتروني"},
'        '    {"LanguageLabel", "اللغة"},
'        '    {"SaveButtonText", "حفظ"},
'        '    {"DeleteButtonText", "حذف"},
'        '    {"ClearButtonText", "مسح"},
'        '    {"CustomerSaved", "تم حفظ العميل بنجاح."},
'        '    {"CustomerDeleted", "تم حذف العميل بنجاح."},
'        '    {"ValidationError", "خطأ في التحقق: "}
'        '}
'        '_languages.Add("ar-SA", (arabicStrings, True))
'        '_languageDisplayNames.Add("ar-SA", "العربية")
'        _configService = configService
'        LoadLanguages()
'        '_languageDisplayNames.Add("en-US", "English")
'        '_languages.Add("en-US", (New Dictionary(Of String, Dictionary(Of String, String)), False))
'        '_languageDisplayNames.Add("ar-SA", "العربية")
'        '_languages.Add("ar-SA", (New Dictionary(Of String, Dictionary(Of String, String)), True))

'        '' Get the default language from the configuration file.
'        'Dim defaultLanguage As String = configService.GetSetting("LanguageCode")
'        '' Get the default language from the configuration file.
'        'SetLanguage(If(Not String.IsNullOrEmpty(defaultLanguage) AndAlso _languages.ContainsKey(defaultLanguage), defaultLanguage, "en-US"))

'    End Sub

'    ''' <summary>
'    ''' Loads all language files from the "Resources" directory.
'    ''' </summary>
'    Private Sub LoadLanguages()
'        Dim basePath As String = AppDomain.CurrentDomain.BaseDirectory
'        Dim resourcePath As String = Path.Combine(basePath, "Resources")

'        If Not Directory.Exists(resourcePath) Then
'            Directory.CreateDirectory(resourcePath)
'        End If

'        For Each filePath In Directory.GetFiles(resourcePath, "*.json")
'            Try
'                Dim languageCode As String = Path.GetFileNameWithoutExtension(filePath)
'                Dim json As String = File.ReadAllText(filePath)
'                Dim modules As Dictionary(Of String, Dictionary(Of String, String)) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Dictionary(Of String, String)))(json)
'                _localizedStrings(languageCode) = modules
'            Catch ex As Exception
'                ' Log this error in a real application
'                Console.WriteLine($"Error loading localization file: {filePath}. {ex.Message}")
'            End Try
'        Next
'    End Sub

'    ''' <summary>
'    ''' Adds a string to the in-memory localization dictionary.
'    ''' </summary>
'    Public Sub AddString(moduleName As String, originalString As String, languageCode As String) Implements ILocalizationService.AddString
'        If Not _localizedStrings.ContainsKey(languageCode) Then
'            _localizedStrings(languageCode) = New Dictionary(Of String, Dictionary(Of String, String))()
'        End If
'        If Not _localizedStrings(languageCode).ContainsKey(moduleName) Then
'            _localizedStrings(languageCode)(moduleName) = New Dictionary(Of String, String)()
'        End If
'        If Not _localizedStrings(languageCode)(moduleName).ContainsKey(originalString) Then
'            _localizedStrings(languageCode)(moduleName).Add(originalString, originalString)
'        End If
'    End Sub


'    Public Sub AddStrings(moduleName As String, languageCode As String, strings As Dictionary(Of String, String)) Implements ILocalizationService.AddStrings
'        If _languages.ContainsKey(languageCode) Then
'            _languages(languageCode).strings(moduleName) = strings
'        End If
'    End Sub

'    'Public Sub New(configService As IConfigurationService)
'    '    _strings = New Dictionary(Of String, Dictionary(Of String, String))()
'    '    LoadLanguages()

'    '    ' Get the language code from the configuration service
'    '    Dim languageCode As String = configService.GetSetting("LanguageCode")
'    '    _currentLanguage = If(Not String.IsNullOrEmpty(languageCode) AndAlso _strings.ContainsKey(languageCode), languageCode, _defaultLanguage)

'    '    ' Set the RightToLeft property based on the current language
'    '    _isRightToLeft = (_currentLanguage = "ar-SA")
'    'End Sub

'    Public Function GetString(key As String) As String Implements ILocalizationService.GetString
'        ' The presenter is now responsible for getting the full module dictionary.
'        ' This method is now a convenience method, but will not be used with our new design.
'        Return key
'    End Function

'    Public Function GetAvailableLanguages() As List(Of (display As String, code As String)) Implements ILocalizationService.GetAvailableLanguages
'        Dim languages As New List(Of (String, String))()
'        For Each lang In _localizedStrings.Keys
'            Try
'                Dim culture As New CultureInfo(lang)
'                languages.Add((culture.NativeName, lang))
'            Catch ex As Exception
'                ' Ignore invalid culture codes
'            End Try
'        Next
'        Return languages
'    End Function


'    'Public Sub SetLanguage(languageCode As String) Implements ILocalizationService.SetLanguage
'    '    If _languages.ContainsKey(languageCode) Then
'    '        _currentLanguageCode = languageCode
'    '        _isRightToLeft = _languages(languageCode).isRtl
'    '    Else
'    '        _currentLanguageCode = "en-US"
'    '        _isRightToLeft = False
'    '    End If
'    'End Sub

'    '''' <summary>
'    '''' Gets the localized string for a specified key.
'    '''' </summary>
'    'Public Function GetString(key As String) As String Implements ILocalizationService.GetString
'    '    If _strings.ContainsKey(_currentLanguage) AndAlso _strings(_currentLanguage).ContainsKey(key) Then
'    '        Return _strings(_currentLanguage)(key)
'    '    Else
'    '        ' Return the key itself as a fallback
'    '        Return key
'    '    End If
'    'End Function

'    ''' <summary>
'    ''' Indicates whether the current language is a Right-to-Left language.
'    ''' </summary>
'    Public ReadOnly Property IsRightToLeft As Boolean Implements ILocalizationService.IsRightToLeft
'        Get
'            Dim culture As New CultureInfo(_currentLanguage)
'            Return culture.TextInfo.IsRightToLeft
'        End Get
'    End Property


'    Public Function GetLocalizedStrings(moduleName As String) As Dictionary(Of String, String) Implements ILocalizationService.GetLocalizedStrings
'        If _localizedStrings.ContainsKey(_currentLanguage) AndAlso _localizedStrings(_currentLanguage).ContainsKey(moduleName) Then
'            Return _localizedStrings(_currentLanguage)(moduleName)
'        End If

'        ' Return an empty dictionary if not found.
'        Return New Dictionary(Of String, String)()
'    End Function

'    Public Sub SetLanguage(languageCode As String) Implements ILocalizationService.SetLanguage
'        If _localizedStrings.ContainsKey(languageCode) Then
'            _currentLanguage = languageCode
'        Else
'            ' Default to English if the language is not found
'            _currentLanguage = "en-US"
'        End If
'    End Sub

'    'Public Function GetAvailableLanguages() As List(Of (display As String, code As String)) Implements ILocalizationService.GetAvailableLanguages
'    '    Dim languages As New List(Of (display As String, code As String))
'    '    languages.Add(("English", "en-US"))
'    '    languages.Add(("العربية", "ar-SA"))
'    '    Return languages
'    'End Function

'    '''' <summary>
'    '''' Simulates loading language resources from a data source.
'    '''' </summary>
'    'Private Sub LoadLanguages()
'    '    ' English Strings
'    '    Dim enStrings As New Dictionary(Of String, String)()
'    '    enStrings.Add("FormTitle", "Customer Management")
'    '    enStrings.Add("FirstNameLabel", "First Name:")
'    '    enStrings.Add("LastNameLabel", "Last Name:")
'    '    enStrings.Add("EmailLabel", "Email:")
'    '    enStrings.Add("SaveButton", "Save")
'    '    enStrings.Add("DeleteButton", "Delete")
'    '    enStrings.Add("ClearButton", "Clear")
'    '    enStrings.Add("CustomerSaved", "Customer saved successfully.")
'    '    enStrings.Add("CustomerDeleted", "Customer deleted successfully.")
'    '    enStrings.Add("FieldRequired", "This field is required.")
'    '    enStrings.Add("InvalidEmail", "Please enter a valid email address.")
'    '    _strings.Add("en-US", enStrings)

'    '    ' Spanish Strings
'    '    Dim esStrings As New Dictionary(Of String, String)()
'    '    esStrings.Add("FormTitle", "Gestión de Clientes")
'    '    esStrings.Add("FirstNameLabel", "Nombre:")
'    '    esStrings.Add("LastNameLabel", "Apellido:")
'    '    esStrings.Add("EmailLabel", "Correo electrónico:")
'    '    esStrings.Add("SaveButton", "Guardar")
'    '    esStrings.Add("DeleteButton", "Eliminar")
'    '    esStrings.Add("ClearButton", "Limpiar")
'    '    esStrings.Add("CustomerSaved", "Cliente guardado con éxito.")
'    '    esStrings.Add("CustomerDeleted", "Cliente eliminado con éxito.")
'    '    esStrings.Add("FieldRequired", "Este campo es requerido.")
'    '    esStrings.Add("InvalidEmail", "Por favor, introduce una dirección de correo válida.")
'    '    _strings.Add("es-ES", esStrings)

'    '    ' Arabic Strings (Right-to-Left)
'    '    Dim arStrings As New Dictionary(Of String, String)()
'    '    arStrings.Add("FormTitle", "إدارة العملاء")
'    '    arStrings.Add("FirstNameLabel", "الاسم الأول:")
'    '    arStrings.Add("LastNameLabel", "اسم العائلة:")
'    '    arStrings.Add("EmailLabel", "البريد الإلكتروني:")
'    '    arStrings.Add("SaveButton", "حفظ")
'    '    arStrings.Add("DeleteButton", "حذف")
'    '    arStrings.Add("ClearButton", "مسح")
'    '    arStrings.Add("CustomerSaved", "تم حفظ العميل بنجاح.")
'    '    arStrings.Add("CustomerDeleted", "تم حذف العميل بنجاح.")
'    '    arStrings.Add("FieldRequired", "هذا الحقل مطلوب.")
'    '    arStrings.Add("InvalidEmail", "الرجاء إدخال عنوان بريد إلكتروني صالح.")
'    '    _strings.Add("ar-SA", arStrings)
'    'End Sub

'End Class

