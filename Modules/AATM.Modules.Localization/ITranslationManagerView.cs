using AATM.Contracts.Dtos;
using System;
using System.Collections.Generic;

namespace AATM.Modules.Localization
{


    /// <summary>
/// Defines the contract for the Translation Manager View.
/// This decouples the Presenter from the specific WinForms UI implementation.
/// </summary>
    public interface ITranslationManagerView
    {

        /// <summary>
    /// Event raised when the user clicks the save button.
    /// The presenter will subscribe to this event to save the translation.
    /// </summary>
        event Action<string, string, string, string, string> SaveTranslation;

        /// <summary>
    /// Event raised when the user selects a new language.
    /// The presenter will handle this to load translations for the new language.
    /// </summary>
        event Action<string> LanguageSelected;

        /// <summary>
    /// Displays the list of available languages in the language dropdown.
    /// </summary>
        void DisplayLanguages(List<(string display, string code)> languages);

        /// <summary>
    /// Displays translations in a DataGridView or similar control.
    /// </summary>
        void DisplayTranslations(List<TranslationDto> translations);

        /// <summary>
    /// Displays a message to the user, for example in a status bar or message box.
    /// </summary>
        void ShowMessage(string message);

        /// <summary>
    /// Gets the selected language code from the view.
    /// </summary>
        string GetSelectedLanguageCode();

        /// <summary>
    /// Gets the original string entered by the user.
    /// </summary>
        string GetOriginalString();

        /// <summary>
    /// Gets the translated string entered by the user.
    /// </summary>
        string GetLocalizedString();

    }
}




// Imports System.Collections.Generic

// Public Interface ITranslationManagerView
// ' Events that the presenter will subscribe to
// Event LoadView As EventHandler
// Event SaveTranslation(originalString As String, localizedString As String)
// Event LanguageChanged(languageCode As String)

// ' Methods the presenter will call to update the view
// Sub DisplayStrings(translations As List(Of (original As String, localized As String)))
// Sub DisplayLanguages(languages As List(Of (display As String, code As String)))
// Sub ShowSuccessMessage(message As String)
// Sub ShowErrorMessage(message As String)
// End Interface
