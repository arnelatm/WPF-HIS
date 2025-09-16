using System.Collections.Generic;
using System.Windows.Forms;
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

        /// <summary>
    /// Initializes a new instance of the UILocalizationManager.
    /// </summary>
    /// <param name="localizationService">The localization service to use.</param>
        public UILocalizationManager(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        /// <summary>
    /// Recursively walks the controls on a form and registers their text with the localization service.
    /// </summary>
        public void RegisterFormStrings(Form form, string moduleName, string languageCode)
        {
            var strings = new Dictionary<string, string>();
            CollectStrings(form.Controls, ref strings);

            // Add the form's title manually
            if (!string.IsNullOrWhiteSpace(form.Text))
            {
                strings.Add(form.Text, form.Text);
            }

            // The localization service now only needs to receive the strings.
            _localizationService.AddStrings(moduleName, languageCode, strings);
        }

        private void RegisterControlStrings(Control.ControlCollection controls, string moduleName, string languageCode)
        {
            foreach (Control ctrl in controls)
            {
                if (!string.IsNullOrWhiteSpace(ctrl.Text))
                {
                    _localizationService.AddString(moduleName, ctrl.Text, languageCode);
                }

                if (ctrl.Controls.Count > 0)
                {
                    RegisterControlStrings(ctrl.Controls, moduleName, languageCode);
                }
            }
        }

        private void CollectStrings(Control.ControlCollection controls, ref Dictionary<string, string> strings)
        {
            foreach (Control control in controls)
            {
                if (!string.IsNullOrWhiteSpace(control.Text))
                {
                    // Use the control's text as the key
                    if (!strings.ContainsKey(control.Text))
                    {
                        strings.Add(control.Text, control.Text);
                    }
                }

                if (control.HasChildren)
                {
                    CollectStrings(control.Controls, ref strings);
                }
            }
        }

        /// <summary>
    /// Translates all controls on a form using a provided dictionary of localized strings.
    /// </summary>
        public void SetLocalizedText(Form form, Dictionary<string, string> localizedStrings)
        {
            SetText(form.Controls, localizedStrings);
            if (localizedStrings.ContainsKey(form.Text))
            {
                form.Text = localizedStrings[form.Text];
            }
        }

        private void SetText(Control.ControlCollection controls, Dictionary<string, string> localizedStrings)
        {
            foreach (Control control in controls)
            {
                if (localizedStrings.ContainsKey(control.Text))
                {
                    control.Text = localizedStrings[control.Text];
                }

                if (control.HasChildren)
                {
                    SetText(control.Controls, localizedStrings);
                }
            }
        }

        private void IUiLocalizationManager_RegisterFormStrings(Form form, string moduleName, string languageCode)
        {
            RegisterFormStrings(form, moduleName, languageCode);
        }

        void IUiLocalizationManager.RegisterFormStrings(Form form, string moduleName, string languageCode) => IUiLocalizationManager_RegisterFormStrings(form, moduleName, languageCode);

        private void IUiLocalizationManager_SetLocalizedText(Form form, Dictionary<string, string> localizedStrings)
        {
            SetLocalizedText(form, localizedStrings);
        }

        void IUiLocalizationManager.SetLocalizedText(Form form, Dictionary<string, string> localizedStrings) => IUiLocalizationManager_SetLocalizedText(form, localizedStrings);
    }
}