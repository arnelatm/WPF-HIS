using System.Collections.Generic;
using System.Windows.Forms;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;

namespace Winforms
{
    /// <summary>
    /// Manages the process of reading UI control text and registering it with the localization service.
    /// This class is specific to Windows Forms and decouples the localization core from the UI.
    /// </summary>
    public partial class UILocalizationManager : IUiLocalizationManager
    {
        private readonly ILocalizationService _localizationService;

        public UILocalizationManager(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        /// <summary>
        /// Recursively walks the controls on a form and registers their text with the localization service.
        /// </summary>
        public void RegisterFormStrings(Form form, string moduleName, string languageCode)
        {
            RegisterControlStrings(form.Controls, moduleName, languageCode);
            // Add the form's title manually as a localizable string
            if (!string.IsNullOrWhiteSpace(form.Text))
            {
                _localizationService.AddString(moduleName, form.Text, languageCode);
            }
        }

        private void RegisterControlStrings(Control.ControlCollection controls, string moduleName, string languageCode)
        {
            foreach (Control ctrl in controls)
            {
                if (!string.IsNullOrWhiteSpace(ctrl.Text))
                {
                    _localizationService.AddString(moduleName, ctrl.Text, languageCode);
                }
                // Recursively register child controls
                if (ctrl.HasChildren)
                {
                    RegisterControlStrings(ctrl.Controls, moduleName, languageCode);
                }
            }
        }

        /// <summary>
        /// Translates all controls on a form using a provided dictionary of localized strings.
        /// </summary>
        public void SetLocalizedText(Form form, Dictionary<string, string> localizedStrings)
        {
            SetText(form.Controls, localizedStrings);
            // Localize the form's title if present in the dictionary
            if (!string.IsNullOrWhiteSpace(form.Text) && localizedStrings.ContainsKey(form.Text))
            {
                form.Text = localizedStrings[form.Text];
            }
        }

        private void SetText(Control.ControlCollection controls, Dictionary<string, string> localizedStrings)
        {
            foreach (Control control in controls)
            {
                // Only update if a translation exists for the original text
                if (!string.IsNullOrWhiteSpace(control.Text) && localizedStrings.ContainsKey(control.Text))
                {
                    control.Text = localizedStrings[control.Text];
                }
                // Recursively localize child controls
                if (control.HasChildren)
                {
                    SetText(control.Controls, localizedStrings);
                }
            }
        }
    }
}