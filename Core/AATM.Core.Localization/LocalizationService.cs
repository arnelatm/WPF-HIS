using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AATM.Core.Localization
{

    /// <summary>
    /// Provides localized strings by retrieving them from a database and managing them
    /// for a given language. This class implements the ILocalizationService interface.
    /// </summary>
    public class LocalizationService : ILocalizationService
    {

        private string _language;
        private string _moduleName;
        private IDictionary<string, string> _localizedStrings;
        private IDictionary<string, string> _localizedStringsByOriginal;
        /// <summary>
        /// Initializes a new instance of the LocalizationService.
        /// The constructor loads all localized strings for the specified language
        /// into a local dictionary for fast retrieval.
        /// </summary>
        /// <param name="language">The language code for the strings to retrieve (e.g., "en-US").</param>
        public LocalizationService(string language, string moduleName)
        {
            _language = language;
            _moduleName = moduleName;
            _localizedStringsByOriginal = GetAllLocalizedStrings(language);
            GetLocalizedStrings();
            //_localizedStrings = GetLocalizedStrings();
            /// _localizedStringsByOriginal = _localizedStrings.ToDictionary(kvp => kvp.Value, kvp => kvp.Key); 
        }

        /// <summary>
        /// Retrieves a dictionary of all localized strings for the current language.
        /// This method simulates retrieving data from a database and mapping it
        /// to the TranslationDto.
        /// </summary>
        /// <returns>A Dictionary where the key is the UI identifier and the value is the localized string.</returns>
        public IDictionary<string, string> GetLocalizedStrings()
        {
            var localizedStrings = new Dictionary<string, string>();
            string connectionString = ConfigurationManager.ConnectionStrings["LocalizationDb"]?.ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT OriginalString, LocalizedString, UIIdentifier from Localization where LanguageCode = @LanguageCode and ModuleName = @ModuleName ";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LanguageCode", _language);
                    command.Parameters.AddWithValue("@ModuleName", _moduleName);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string uiIdentifier = reader["UIIdentifier"].ToString();
                            string originalString = reader["OriginalString"].ToString();
                            string localizedString = reader["LocalizedString"].ToString();
                            string key = $"{uiIdentifier}";
                            if (!localizedStrings.ContainsKey(key))
                                localizedStrings.Add(key, localizedString);
                            if (_language != "en-US")
                            {
                                if (!_localizedStringsByOriginal.ContainsKey(originalString))
                                    _localizedStringsByOriginal.Add(originalString, localizedString);

                                if (!localizedStrings.ContainsKey(key))
                                {
                                    localizedStrings.Add(key, localizedString);
                                }
                                else if (!_localizedStringsByOriginal.ContainsKey(originalString))

                                {
                                    _localizedStringsByOriginal.Add(originalString, localizedString);
                                    // Optionally log a warning about duplicate UIIdentifier entries.
                                    // Console.WriteLine($"Warning: Duplicate UIIdentifier '{uiIdentifier}' found in localization data.");
                                }
                            }
                        }
                    }
                }
            }

            _localizedStrings = localizedStrings;
            return _localizedStrings;
        }

        public IDictionary<string, string> GetAllLocalizedStrings(String languageCode)
        {
            var localizedStringsByOriginal = new Dictionary<string, string>();
            string connectionString = ConfigurationManager.ConnectionStrings["LocalizationDb"]?.ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT OriginalString, LocalizedString from Localization where LanguageCode = @LanguageCode ";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LanguageCode", _language);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string originalString = reader["OriginalString"].ToString();
                            string localizedString = reader["LocalizedString"].ToString();
                            if (!localizedStringsByOriginal.ContainsKey(originalString))
                            {
                                localizedStringsByOriginal.Add(originalString, localizedString);
                            }
                            // Optionally, you could log or handle duplicates here if needed.
                        }
                    }
                }
            }
            return localizedStringsByOriginal;
        }
        /// <summary>
        /// Gets a localized string from the pre-loaded dictionary.
        /// </summary>
        /// <returns>The localized string or the original string if the translation is not found.</returns>
        public string GetString(string moduleName, string uiIdentifier, string originalString)
        {
            if (originalString.Trim() == "Language") System.Diagnostics.Debugger.Break();

            if (_localizedStrings.TryGetValue(uiIdentifier, out var localizedString))
                if (localizedString != null && localizedString.Trim() != originalString.Trim()) return localizedString;
            _localizedStringsByOriginal.TryGetValue(originalString, out localizedString);
            if (localizedString != null && localizedString.Trim() != originalString.Trim()) return localizedString;

            // If not found, add to database as a new entry
            AddMissingTranslationToDatabase(moduleName, uiIdentifier, originalString, _language);

            // Optionally, add to in-memory dictionary to avoid repeated DB writes
            _localizedStrings[uiIdentifier] = originalString;
            _localizedStringsByOriginal[originalString] = originalString;

            // Log a warning that a translation was not found.
            // Console.WriteLine($"Warning: Translation for '{uiIdentifier}' not found. Added to database as fallback.");
            return originalString;

        }


        // Helper method to add missing translation to the database
        private void AddMissingTranslationToDatabase(string moduleName, string uiIdentifier, string originalString, string languageCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LocalizationDb"]?.ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Localization (ModuleName, UIIdentifier, OriginalString, LocalizedString, LanguageCode)
                         VALUES (@ModuleName, @UIIdentifier, @OriginalString, @LocalizedString, @LanguageCode)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ModuleName", moduleName);
                    command.Parameters.AddWithValue("@UIIdentifier", uiIdentifier);
                    command.Parameters.AddWithValue("@OriginalString", originalString);
                    command.Parameters.AddWithValue("@LocalizedString", originalString); // fallback: original text
                    command.Parameters.AddWithValue("@LanguageCode", languageCode);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Adds or updates a localized string in the database.
        /// This method simulates writing data to a database.
        /// </summary>
        public void AddOrUpdateString(string moduleName, string uiIdentifier, string originalString, string languageCode, string localizedString)
        {
            // Simulate DB write...
            var key = uiIdentifier; // or $"{moduleName}.{uiIdentifier}"
            _localizedStrings[key] = localizedString;
        }

        /// <summary>
        /// Gets a list of available languages.
        /// </summary>
        /// <returns>A list of tuples with the display name and language code.</returns>
        public List<(string display, string code)> GetAvailableLanguages()
        {
            var languages = new List<(string display, string code)>();

            // Add default language
            languages.Add(("English", "en-US"));

            // Replace with your actual connection string
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"]?.ConnectionString;

            // Query the database for unique language codes and their display names
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT LanguageCode, DisplayName FROM Translation";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string code = reader["LanguageCode"].ToString();
                            string display = reader["DisplayName"].ToString();

                            // Avoid adding duplicate default language
                            if (!languages.Any(l => l.code == code))
                            {
                                languages.Add((display, code));
                            }
                        }
                    }
                }
            }

            return languages;
        }

        public string Translate(string sourceLang, string targetLang, string textToTranslate)
        {
            // Simple stub implementation for demonstration.
            // In a real application, you would call an external translation API/service here.
            // For example, you could use Microsoft Translator, Google Translate, or your own translation database.

            // If the source and target languages are the same, return the original text.
            if (string.Equals(sourceLang, targetLang, StringComparison.OrdinalIgnoreCase))
                return textToTranslate;

            // Simulate translation for demonstration purposes.
            // You can expand this with actual translation logic or API calls.
            if (sourceLang == "en-US" && targetLang == "es-ES")
            {
                if (textToTranslate == "Save") return "Guardar";
                if (textToTranslate == "Cancel") return "Cancelar";
                if (textToTranslate == "First Name:") return "Nombre:";
                if (textToTranslate == "Are you sure you want to delete this record?") return "¿Estás seguro de que quieres eliminar este registro?";
            }
            else if (sourceLang == "es-ES" && targetLang == "en-US")
            {
                if (textToTranslate == "Guardar") return "Save";
                if (textToTranslate == "Cancelar") return "Cancel";
                if (textToTranslate == "Nombre:") return "First Name:";
                if (textToTranslate == "¿Estás seguro de que quieres eliminar este registro?") return "Are you sure you want to delete this record?";
            }

            // Fallback: return the original text if no translation is found.
            return textToTranslate;
        }

        /// <summary>
        /// Indicates whether the current language is a right-to-left language.
        /// </summary>
        public bool IsRightToLeft
        {
            get
            {
                try
                {
                    var culture = new CultureInfo(_language);
                    return culture.TextInfo.IsRightToLeft;
                }
                catch (Exception ex)
                {
                    // Handle cases where the language code is invalid.
                    return false;
                }
            }
        }

        public void SetLanguage(string language)
        {
            if (string.IsNullOrWhiteSpace(language) || string.Equals(_language, language, StringComparison.OrdinalIgnoreCase))
                return;
            _language = language;
            _localizedStrings = GetLocalizedStrings();
        }

        public void AddString(string moduleName, string text, string languageCode)
        {
            // Simulate adding a new localized string for the given module and language.
            // In a real application, this would write to a database or persistent store.

            // For this stub, we'll use the UI identifier as the text itself.
            // If you have a specific UI identifier, you can pass it as a parameter.

            // If the language is not the current one, reload the dictionary for that language.
            if (!string.Equals(_language, languageCode, StringComparison.OrdinalIgnoreCase))
            {
                // Optionally, you could switch context or update another dictionary.
                // For simplicity, we do nothing here.
                return;
            }

            // Add the string to the in-memory dictionary if it doesn't exist.
            if (!_localizedStrings.ContainsKey(text))
            {
                _localizedStrings.Add(text, text);
            }
            else
            {
                // Optionally, update the value if needed.
                _localizedStrings[text] = text;
            }
        }
    }
}




// Imports System.Collections.Generic
// Imports System.IO
// Imports System.Linq
// Imports System.Globalization


// ''' <summary>
// ''' Manages localized strings for the application.
// ''' It loads localization data from a repository and provides a single point of access.
// ''' </summary>
// Public Class LocalizationService
// Implements ILocalizationService

// Private ReadOnly _localizationRepository As ILocalizationRepository
// Private ReadOnly _languages As New List(Of (display As String, code As String))()
// ' The primary dictionary holds the language code, and the nested dictionary
// ' holds the UIIdentifier and the translated string.
// Private ReadOnly _localizedStrings As New Dictionary(Of String, Dictionary(Of String, String))()
// Private _currentLanguageCode As String = "en-US"
// Private _isRightToLeft As Boolean = False
// Private Const DEFAULT_LANGUAGE_CODE As String = "en-US"

// Public Sub New(localizationRepository As ILocalizationRepository)
// _localizationRepository = localizationRepository
// LoadLanguages()
// LoadAllLocalizedStrings()
// End Sub

// ''' <summary>
// ''' Gets a localized string for a specific UI element in the current language.
// ''' If the translation is not found, the original string is returned.
// ''' </summary>
// ''' <param name="uiIdentifier">The unique identifier of the UI element (e.g., "btnSave").</param>
// ''' <param name="originalString">The original, untranslated text (e.g., "Save").</param>
// ''' <returns>The localized string or the original string if not found.</returns>
// Public Function GetString(uiIdentifier As String, originalString As String) As String Implements ILocalizationService.GetString
// ' Check if we have translations for the current language.
// If _localizedStrings.ContainsKey(_currentLanguageCode) Then
// ' Check if the specific UI element has a translation.
// Dim translationsForLang As Dictionary(Of String, String) = _localizedStrings(_currentLanguageCode)
// If translationsForLang.ContainsKey(uiIdentifier) Then
// Return translationsForLang(uiIdentifier)
// End If
// End If

// ' If no translation is found, return the original string.
// Return originalString
// End Function

// ''' <summary>
// ''' Adds a new localized string to the database or updates an existing one.
// ''' </summary>
// Public Sub AddOrUpdateString(moduleName As String, uiIdentifier As String, originalString As String, languageCode As String, localizedString As String) Implements ILocalizationService.AddOrUpdateString
// _localizationRepository.AddOrUpdateLocalization(originalString, moduleName, uiIdentifier, languageCode, localizedString)
// ' After adding or updating in the database, reload the in-memory cache.
// LoadAllLocalizedStrings()
// End Sub

// Public Sub SetLanguage(languageCode As String) Implements ILocalizationService.SetLanguage
// If _languages.Any(Function(lang) lang.code = languageCode) Then
// _currentLanguageCode = languageCode
// Dim culture As New CultureInfo(languageCode)
// _isRightToLeft = culture.TextInfo.IsRightToLeft
// End If
// End Sub

// Public Function GetAvailableLanguages() As List(Of (display As String, code As String)) Implements ILocalizationService.GetAvailableLanguages
// Return _languages.ToList()
// End Function

// Public ReadOnly Property IsRightToLeft As Boolean Implements ILocalizationService.IsRightToLeft
// Get
// Return _isRightToLeft
// End Get
// End Property

// Private Sub LoadLanguages()
// ' In a real-world app, this would be loaded from a configuration or a database table.
// _languages.Add(("English", "en-US"))
// _languages.Add(("Arabic", "ar-SA"))
// End Sub

// ''' <summary>
// ''' Loads all localized strings from the repository into memory.
// ''' This should be called once on application startup or after a translation is saved.
// ''' </summary>
// Private Sub LoadAllLocalizedStrings()
// _localizedStrings.Clear()
// For Each language In _languages
// Dim localizedStringsForLang As New Dictionary(Of String, String)()
// Dim translations As List(Of TranslationDto) = _localizationRepository.GetLocalizedStrings(language.code)
// For Each translation As TranslationDto In translations
// ' We use the UIIdentifier as the lookup key for the string.
// localizedStringsForLang(translation.UIIdentifier) = translation.LocalizedString
// Next
// _localizedStrings(language.code) = localizedStringsForLang
// Next
// End Sub
// End Class



// Imports System.Collections.Generic
// Imports System.Globalization
// Imports System.IO
// Imports AATM.Core.Configuration
// Imports Newtonsoft.Json

// ''' <summary>
// ''' A concrete implementation of ILocalizationService.
// ''' This class holds the logic for loading and providing localized strings.
// ''' </summary>
// Public Class LocalizationService
// Implements ILocalizationService


// Private ReadOnly _languages As New Dictionary(Of String, (strings As Dictionary(Of String, Dictionary(Of String, String)), isRtl As Boolean))
// Private ReadOnly _languageDisplayNames As New Dictionary(Of String, String)
// Private ReadOnly _configService As IConfigurationService
// Private _currentLanguage As String = "en-US" ' Default language
// Private _isRightToLeft As Boolean
// Private ReadOnly _strings As Dictionary(Of String, Dictionary(Of String, String))
// Private ReadOnly _defaultLanguage As String = "en-US"
// Private ReadOnly _localizedStrings As New Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String)))


// Public Sub New(configService As IConfigurationService)
// ' Initialize English language strings
// 'Dim englishStrings As New Dictionary(Of String, Dictionary(Of String, String))
// 'englishStrings("CustomerModule") = New Dictionary(Of String, String) From
// '{
// '    {"CustomerFormTitle", "Customer Management"},
// '    {"FirstNameLabel", "First Name"},
// '    {"LastNameLabel", "Last Name"},
// '    {"EmailLabel", "Email"},
// '    {"LanguageLabel", "Language"},
// '    {"SaveButtonText", "Save"},
// '    {"DeleteButtonText", "Delete"},
// '    {"ClearButtonText", "Clear"},
// '    {"CustomerSaved", "Customer saved successfully."},
// '    {"CustomerDeleted", "Customer deleted successfully."},
// '    {"ValidationError", "Validation Error: "}
// '}
// '_languages.Add("en-US", (englishStrings, False))
// '_languageDisplayNames.Add("en-US", "English")

// '' Initialize Arabic language strings
// 'Dim arabicStrings As New Dictionary(Of String, Dictionary(Of String, String))
// 'arabicStrings("CustomerModule") = New Dictionary(Of String, String) From
// '{
// '    {"CustomerFormTitle", "إدارة العملاء"},
// '    {"FirstNameLabel", "الاسم الأول"},
// '    {"LastNameLabel", "الاسم الأخير"},
// '    {"EmailLabel", "البريد الإلكتروني"},
// '    {"LanguageLabel", "اللغة"},
// '    {"SaveButtonText", "حفظ"},
// '    {"DeleteButtonText", "حذف"},
// '    {"ClearButtonText", "مسح"},
// '    {"CustomerSaved", "تم حفظ العميل بنجاح."},
// '    {"CustomerDeleted", "تم حذف العميل بنجاح."},
// '    {"ValidationError", "خطأ في التحقق: "}
// '}
// '_languages.Add("ar-SA", (arabicStrings, True))
// '_languageDisplayNames.Add("ar-SA", "العربية")
// _configService = configService
// LoadLanguages()
// '_languageDisplayNames.Add("en-US", "English")
// '_languages.Add("en-US", (New Dictionary(Of String, Dictionary(Of String, String)), False))
// '_languageDisplayNames.Add("ar-SA", "العربية")
// '_languages.Add("ar-SA", (New Dictionary(Of String, Dictionary(Of String, String)), True))

// '' Get the default language from the configuration file.
// 'Dim defaultLanguage As String = configService.GetSetting("LanguageCode")
// '' Get the default language from the configuration file.
// 'SetLanguage(If(Not String.IsNullOrEmpty(defaultLanguage) AndAlso _languages.ContainsKey(defaultLanguage), defaultLanguage, "en-US"))

// End Sub

// ''' <summary>
// ''' Loads all language files from the "Resources" directory.
// ''' </summary>
// Private Sub LoadLanguages()
// Dim basePath As String = AppDomain.CurrentDomain.BaseDirectory
// Dim resourcePath As String = Path.Combine(basePath, "Resources")

// If Not Directory.Exists(resourcePath) Then
// Directory.CreateDirectory(resourcePath)
// End If

// For Each filePath In Directory.GetFiles(resourcePath, "*.json")
// Try
// Dim languageCode As String = Path.GetFileNameWithoutExtension(filePath)
// Dim json As String = File.ReadAllText(filePath)
// Dim modules As Dictionary(Of String, Dictionary(Of String, String)) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Dictionary(Of String, String)))(json)
// _localizedStrings(languageCode) = modules
// Catch ex As Exception
// ' Log this error in a real application
// Console.WriteLine($"Error loading localization file: {filePath}. {ex.Message}")
// End Try
// Next
// End Sub

// ''' <summary>
// ''' Adds a string to the in-memory localization dictionary.
// ''' </summary>
// Public Sub AddString(moduleName As String, originalString As String, languageCode As String) Implements ILocalizationService.AddString
// If Not _localizedStrings.ContainsKey(languageCode) Then
// _localizedStrings(languageCode) = New Dictionary(Of String, Dictionary(Of String, String))()
// End If
// If Not _localizedStrings(languageCode).ContainsKey(moduleName) Then
// _localizedStrings(languageCode)(moduleName) = New Dictionary(Of String, String)()
// End If
// If Not _localizedStrings(languageCode)(moduleName).ContainsKey(originalString) Then
// _localizedStrings(languageCode)(moduleName).Add(originalString, originalString)
// End If
// End Sub


// Public Sub AddStrings(moduleName As String, languageCode As String, strings As Dictionary(Of String, String)) Implements ILocalizationService.AddStrings
// If _languages.ContainsKey(languageCode) Then
// _languages(languageCode).strings(moduleName) = strings
// End If
// End Sub

// 'Public Sub New(configService As IConfigurationService)
// '    _strings = New Dictionary(Of String, Dictionary(Of String, String))()
// '    LoadLanguages()

// '    ' Get the language code from the configuration service
// '    Dim languageCode As String = configService.GetSetting("LanguageCode")
// '    _currentLanguage = If(Not String.IsNullOrEmpty(languageCode) AndAlso _strings.ContainsKey(languageCode), languageCode, _defaultLanguage)

// '    ' Set the RightToLeft property based on the current language
// '    _isRightToLeft = (_currentLanguage = "ar-SA")
// 'End Sub

// Public Function GetString(key As String) As String Implements ILocalizationService.GetString
// ' The presenter is now responsible for getting the full module dictionary.
// ' This method is now a convenience method, but will not be used with our new design.
// Return key
// End Function

// Public Function GetAvailableLanguages() As List(Of (display As String, code As String)) Implements ILocalizationService.GetAvailableLanguages
// Dim languages As New List(Of (String, String))()
// For Each lang In _localizedStrings.Keys
// Try
// Dim culture As New CultureInfo(lang)
// languages.Add((culture.NativeName, lang))
// Catch ex As Exception
// ' Ignore invalid culture codes
// End Try
// Next
// Return languages
// End Function


// 'Public Sub SetLanguage(languageCode As String) Implements ILocalizationService.SetLanguage
// '    If _languages.ContainsKey(languageCode) Then
// '        _currentLanguageCode = languageCode
// '        _isRightToLeft = _languages(languageCode).isRtl
// '    Else
// '        _currentLanguageCode = "en-US"
// '        _isRightToLeft = False
// '    End If
// 'End Sub

// '''' <summary>
// '''' Gets the localized string for a specified key.
// '''' </summary>
// 'Public Function GetString(key As String) As String Implements ILocalizationService.GetString
// '    If _strings.ContainsKey(_currentLanguage) AndAlso _strings(_currentLanguage).ContainsKey(key) Then
// '        Return _strings(_currentLanguage)(key)
// '    Else
// '        ' Return the key itself as a fallback
// '        Return key
// '    End If
// 'End Function

// ''' <summary>
// ''' Indicates whether the current language is a Right-to-Left language.
// ''' </summary>
// Public ReadOnly Property IsRightToLeft As Boolean Implements ILocalizationService.IsRightToLeft
// Get
// Dim culture As New CultureInfo(_currentLanguage)
// Return culture.TextInfo.IsRightToLeft
// End Get
// End Property


// Public Function GetLocalizedStrings(moduleName As String) As Dictionary(Of String, String) Implements ILocalizationService.GetLocalizedStrings
// If _localizedStrings.ContainsKey(_currentLanguage) AndAlso _localizedStrings(_currentLanguage).ContainsKey(moduleName) Then
// Return _localizedStrings(_currentLanguage)(moduleName)
// End If

// ' Return an empty dictionary if not found.
// Return New Dictionary(Of String, String)()
// End Function

// Public Sub SetLanguage(languageCode As String) Implements ILocalizationService.SetLanguage
// If _localizedStrings.ContainsKey(languageCode) Then
// _currentLanguage = languageCode
// Else
// ' Default to English if the language is not found
// _currentLanguage = "en-US"
// End If
// End Sub

// 'Public Function GetAvailableLanguages() As List(Of (display As String, code As String)) Implements ILocalizationService.GetAvailableLanguages
// '    Dim languages As New List(Of (display As String, code As String))
// '    languages.Add(("English", "en-US"))
// '    languages.Add(("العربية", "ar-SA"))
// '    Return languages
// 'End Function

// '''' <summary>
// '''' Simulates loading language resources from a data source.
// '''' </summary>
// 'Private Sub LoadLanguages()
// '    ' English Strings
// '    Dim enStrings As New Dictionary(Of String, String)()
// '    enStrings.Add("FormTitle", "Customer Management")
// '    enStrings.Add("FirstNameLabel", "First Name:")
// '    enStrings.Add("LastNameLabel", "Last Name:")
// '    enStrings.Add("EmailLabel", "Email:")
// '    enStrings.Add("SaveButton", "Save")
// '    enStrings.Add("DeleteButton", "Delete")
// '    enStrings.Add("ClearButton", "Clear")
// '    enStrings.Add("CustomerSaved", "Customer saved successfully.")
// '    enStrings.Add("CustomerDeleted", "Customer deleted successfully.")
// '    enStrings.Add("FieldRequired", "This field is required.")
// '    enStrings.Add("InvalidEmail", "Please enter a valid email address.")
// '    _strings.Add("en-US", enStrings)

// '    ' Spanish Strings
// '    Dim esStrings As New Dictionary(Of String, String)()
// '    esStrings.Add("FormTitle", "Gestión de Clientes")
// '    esStrings.Add("FirstNameLabel", "Nombre:")
// '    esStrings.Add("LastNameLabel", "Apellido:")
// '    esStrings.Add("EmailLabel", "Correo electrónico:")
// '    esStrings.Add("SaveButton", "Guardar")
// '    esStrings.Add("DeleteButton", "Eliminar")
// '    esStrings.Add("ClearButton", "Limpiar")
// '    esStrings.Add("CustomerSaved", "Cliente guardado con éxito.")
// '    esStrings.Add("CustomerDeleted", "Cliente eliminado con éxito.")
// '    esStrings.Add("FieldRequired", "Este campo es requerido.")
// '    esStrings.Add("InvalidEmail", "Por favor, introduce una dirección de correo válida.")
// '    _strings.Add("es-ES", esStrings)

// '    ' Arabic Strings (Right-to-Left)
// '    Dim arStrings As New Dictionary(Of String, String)()
// '    arStrings.Add("FormTitle", "إدارة العملاء")
// '    arStrings.Add("FirstNameLabel", "الاسم الأول:")
// '    arStrings.Add("LastNameLabel", "اسم العائلة:")
// '    arStrings.Add("EmailLabel", "البريد الإلكتروني:")
// '    arStrings.Add("SaveButton", "حفظ")
// '    arStrings.Add("DeleteButton", "حذف")
// '    arStrings.Add("ClearButton", "مسح")
// '    arStrings.Add("CustomerSaved", "تم حفظ العميل بنجاح.")
// '    arStrings.Add("CustomerDeleted", "تم حذف العميل بنجاح.")
// '    arStrings.Add("FieldRequired", "هذا الحقل مطلوب.")
// '    arStrings.Add("InvalidEmail", "الرجاء إدخال عنوان بريد إلكتروني صالح.")
// '    _strings.Add("ar-SA", arStrings)
// 'End Sub

// End Class

