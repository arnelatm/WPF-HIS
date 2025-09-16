using System.Collections.Generic;
using System.Windows.Forms;

namespace AATM.Core.Localization
{


    /// <summary>
/// Defines a contract for a service that handles UI-specific localization tasks.
/// This decouples the Presenter from the concrete UI implementation (WinForms).
/// </summary>
    public interface IUiLocalizationManager
    {

        /// <summary>
    /// Recursively extracts and registers all localizable strings from a form's controls.
    /// </summary>
    /// <param name="form">The form to register strings from.</param>
    /// <param name="moduleName">The name of the module (e.g., "CustomerModule").</param>
    /// <param name="languageCode">The language code (e.g., "en-US", "ar-SA").</param>
        void RegisterFormStrings(Form form, string moduleName, string languageCode);

        /// <summary>
    /// Applies the given dictionary of localized strings to a form's controls.
    /// </summary>
    /// <param name="form">The form to apply translations to.</param>
    /// <param name="localizedStrings">The dictionary of localized strings.</param>
        void SetLocalizedText(Form form, Dictionary<string, string> localizedStrings);

    }
}