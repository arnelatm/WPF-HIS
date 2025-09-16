Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports AATM.Contracts

''' <summary>
''' Provides localized strings by retrieving them from a database and managing them
''' for a given language. This class implements the ILocalizationService interface.
''' </summary>
Public Class LocalizationService
    Implements ILocalizationService

    Private ReadOnly _language As String
    Private ReadOnly _localizedStrings As IDictionary(Of String, String)

    ''' <summary>
    ''' Initializes a new instance of the LocalizationService.
    ''' The constructor loads all localized strings for the specified language
    ''' into a local dictionary for fast retrieval.
    ''' </summary>
    ''' <param name="language">The language code for the strings to retrieve (e.g., "en-US").</param>
    Public Sub New(language As String)
        _language = language
        _localizedStrings = Me.GetLocalizedStrings()
    End Sub

    ''' <summary>
    ''' Retrieves a dictionary of all localized strings for the current language.
    ''' This method simulates retrieving data from a database and mapping it
    ''' to the TranslationDTO.
    ''' </summary>
    ''' <returns>A Dictionary where the key is the UI identifier and the value is the localized string.</returns>
    Public Function GetLocalizedStrings() As IDictionary(Of String, String) Implements ILocalizationService.GetLocalizedStrings
        Dim localizedStrings As New Dictionary(Of String, String)
        Dim translationDTOs As New List(Of TranslationDTO)

        ' =========================================================================
        ' TODO: In a real application, replace this section with your actual
        ' database connection and query logic to populate the translationDTOs list.
        ' =========================================================================

        ' Placeholder data to simulate database records
        Select Case _language.ToLower()
            Case "en-us"
                translationDTOs.Add(New TranslationDTO With {.UIIdentifier = "btnSave_Text", .LocalizedString = "Save"})
                translationDTOs.Add(New TranslationDTO With {.UIIdentifier = "btnCancel_Text", .LocalizedString = "Cancel"})
                translationDTOs.Add(New TranslationDTO With {.UIIdentifier = "msgConfirmDelete", .LocalizedString = "Are you sure you want to delete this record?"})
                translationDTOs.Add(New TranslationDTO With {.UIIdentifier = "lblFirstName_Text", .LocalizedString = "First Name:"})

            Case "es-es"
                translationDTOs.Add(New TranslationDTO With {.UIIdentifier = "btnSave_Text", .LocalizedString = "Guardar"})
                translationDTOs.Add(New TranslationDTO With {.UIIdentifier = "btnCancel_Text", .LocalizedString = "Cancelar"})
                translationDTOs.Add(New TranslationDTO With {.UIIdentifier = "msgConfirmDelete", .LocalizedString = "¿Estás seguro de que quieres eliminar este registro?"})
                translationDTOs.Add(New TranslationDTO With {.UIIdentifier = "lblFirstName_Text", .LocalizedString = "Nombre:"})

            Case Else
                ' You could implement a fallback to a default language here,
                ' or simply return an empty dictionary.
                Return New Dictionary(Of String, String)
        End Select

        ' Convert the list of DTOs into a dictionary for quick lookups
        For Each translation In translationDTOs
            If Not localizedStrings.ContainsKey(translation.UIIdentifier) Then
                localizedStrings.Add(translation.UIIdentifier, translation.LocalizedString)
            End If
        Next

        Return localizedStrings
    End Function

    ''' <summary>
    ''' Gets a localized string from the pre-loaded dictionary.
    ''' </summary>
    ''' <returns>The localized string or the original string if the translation is not found.</returns>
    Public Function GetString(uiIdentifier As String, originalString As String) As String Implements ILocalizationService.GetString
        Dim localizedString As String = ""
        If _localizedStrings.TryGetValue(uiIdentifier, localizedString) Then
            Return localizedString
        Else
            ' Log a warning that a translation was not found.
            ' Consider implementing a mechanism to automatically add the new
            ' key to the database here if it's missing.
            ' Console.WriteLine($"Warning: Translation for '{uiIdentifier}' not found. Returning original string.")
            Return originalString
        End If
    End Function

    ''' <summary>
    ''' Adds or updates a localized string in the database.
    ''' This method simulates writing data to a database.
    ''' </summary>
    Public Sub AddOrUpdateString(moduleName As String, uiIdentifier As String, originalString As String, languageCode As String, localizedString As String) Implements ILocalizationService.AddOrUpdateString
        ' =========================================================================
        ' TODO: Implement your database write logic here.
        ' You would check if a record with the same uiIdentifier and languageCode
        ' exists and either update it or insert a new record.
        ' =========================================================================
        Console.WriteLine($"Simulating DB write: Added/Updated string for UIIdentifier: {uiIdentifier}, Language: {languageCode}")
    End Sub

    ''' <summary>
    ''' Gets a list of available languages.
    ''' </summary>
    ''' <returns>A list of tuples with the display name and language code.</returns>
    Public Function GetAvailableLanguages() As List(Of (display As String, code As String)) Implements ILocalizationService.GetAvailableLanguages
        ' =========================================================================
        ' TODO: Query your database for a list of unique language codes and their
        ' display names to populate this list dynamically.
        ' =========================================================================
        Return New List(Of (String, String)) From {
            ("English", "en-US"),
            ("Español", "es-ES")
        }
    End Function

    Public Function Translate(sourceLang As String, targetLang As String, textToTranslate As String) As String Implements ILocalizationService.Translate
        Throw New NotImplementedException()
    End Function

    ''' <summary>
    ''' Indicates whether the current language is a right-to-left language.
    ''' </summary>
    Public ReadOnly Property IsRightToLeft As Boolean Implements ILocalizationService.IsRightToLeft
        Get
            Try
                Dim culture As New CultureInfo(_language)
                Return culture.TextInfo.IsRightToLeft
            Catch ex As Exception
                ' Handle cases where the language code is invalid.
                Return False
            End Try
        End Get
    End Property

End Class




'Imports System.Collections.Generic
'Imports System.IO
'Imports System.Linq
'Imports System.Globalization


'''' <summary>
'''' Manages localized strings for the application.
'''' It loads localization data from a repository and provides a single point of access.
'''' </summary>
'Public Class LocalizationService
'    Implements ILocalizationService

'    Private ReadOnly _localizationRepository As ILocalizationRepository
'    Private ReadOnly _languages As New List(Of (display As String, code As String))()
'    ' The primary dictionary holds the language code, and the nested dictionary
'    ' holds the UIIdentifier and the translated string.
'    Private ReadOnly _localizedStrings As New Dictionary(Of String, Dictionary(Of String, String))()
'    Private _currentLanguageCode As String = "en-US"
'    Private _isRightToLeft As Boolean = False
'    Private Const DEFAULT_LANGUAGE_CODE As String = "en-US"

'    Public Sub New(localizationRepository As ILocalizationRepository)
'        _localizationRepository = localizationRepository
'        LoadLanguages()
'        LoadAllLocalizedStrings()
'    End Sub

'    ''' <summary>
'    ''' Gets a localized string for a specific UI element in the current language.
'    ''' If the translation is not found, the original string is returned.
'    ''' </summary>
'    ''' <param name="uiIdentifier">The unique identifier of the UI element (e.g., "btnSave").</param>
'    ''' <param name="originalString">The original, untranslated text (e.g., "Save").</param>
'    ''' <returns>The localized string or the original string if not found.</returns>
'    Public Function GetString(uiIdentifier As String, originalString As String) As String Implements ILocalizationService.GetString
'        ' Check if we have translations for the current language.
'        If _localizedStrings.ContainsKey(_currentLanguageCode) Then
'            ' Check if the specific UI element has a translation.
'            Dim translationsForLang As Dictionary(Of String, String) = _localizedStrings(_currentLanguageCode)
'            If translationsForLang.ContainsKey(uiIdentifier) Then
'                Return translationsForLang(uiIdentifier)
'            End If
'        End If

'        ' If no translation is found, return the original string.
'        Return originalString
'    End Function

'    ''' <summary>
'    ''' Adds a new localized string to the database or updates an existing one.
'    ''' </summary>
'    Public Sub AddOrUpdateString(moduleName As String, uiIdentifier As String, originalString As String, languageCode As String, localizedString As String) Implements ILocalizationService.AddOrUpdateString
'        _localizationRepository.AddOrUpdateLocalization(originalString, moduleName, uiIdentifier, languageCode, localizedString)
'        ' After adding or updating in the database, reload the in-memory cache.
'        LoadAllLocalizedStrings()
'    End Sub

'    Public Sub SetLanguage(languageCode As String) Implements ILocalizationService.SetLanguage
'        If _languages.Any(Function(lang) lang.code = languageCode) Then
'            _currentLanguageCode = languageCode
'            Dim culture As New CultureInfo(languageCode)
'            _isRightToLeft = culture.TextInfo.IsRightToLeft
'        End If
'    End Sub

'    Public Function GetAvailableLanguages() As List(Of (display As String, code As String)) Implements ILocalizationService.GetAvailableLanguages
'        Return _languages.ToList()
'    End Function

'    Public ReadOnly Property IsRightToLeft As Boolean Implements ILocalizationService.IsRightToLeft
'        Get
'            Return _isRightToLeft
'        End Get
'    End Property

'    Private Sub LoadLanguages()
'        ' In a real-world app, this would be loaded from a configuration or a database table.
'        _languages.Add(("English", "en-US"))
'        _languages.Add(("Arabic", "ar-SA"))
'    End Sub

'    ''' <summary>
'    ''' Loads all localized strings from the repository into memory.
'    ''' This should be called once on application startup or after a translation is saved.
'    ''' </summary>
'    Private Sub LoadAllLocalizedStrings()
'        _localizedStrings.Clear()
'        For Each language In _languages
'            Dim localizedStringsForLang As New Dictionary(Of String, String)()
'            Dim translations As List(Of TranslationDTO) = _localizationRepository.GetLocalizedStrings(language.code)
'            For Each translation As TranslationDTO In translations
'                ' We use the UIIdentifier as the lookup key for the string.
'                localizedStringsForLang(translation.UIIdentifier) = translation.LocalizedString
'            Next
'            _localizedStrings(language.code) = localizedStringsForLang
'        Next
'    End Sub
'End Class



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

