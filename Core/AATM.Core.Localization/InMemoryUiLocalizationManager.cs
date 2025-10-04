using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AATM.Core.Localization
{
    /// <summary>
    /// Simple in-memory implementation of IUiLocalizationManager for forms that want to capture
    /// original UI text then apply a localized dictionary. Suitable for prototyping / testing.
    /// </summary>
    public class InMemoryUiLocalizationManager : IUiLocalizationManager
    {
        private readonly Dictionary<string, Dictionary<string, string>> _registeredStrings =
            new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

        public void RegisterFormStrings(Form form, string moduleName, string languageCode)
        {
            if (form == null) return;
            var key = BuildKey(moduleName, languageCode);
            if (!_registeredStrings.ContainsKey(key))
                _registeredStrings[key] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (Control c in GetAllControls(form))
            {
                var uiId = c.Name;
                var original = c.Text;
                if (!string.IsNullOrWhiteSpace(uiId) && !string.IsNullOrWhiteSpace(original))
                    _registeredStrings[key][uiId] = original;
            }
        }

        public void SetLocalizedText(Form form, Dictionary<string, string> localizedStrings)
        {
            if (form == null || localizedStrings == null) return;
            foreach (Control c in GetAllControls(form))
            {
                var uiId = c.Name;
                if (!string.IsNullOrWhiteSpace(uiId) && localizedStrings.TryGetValue(uiId, out var loc))
                    c.Text = loc;
            }
        }

        private static string BuildKey(string module, string lang)
            => (module ?? string.Empty) + ":" + (lang ?? string.Empty);

        private static IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }
    }
}
