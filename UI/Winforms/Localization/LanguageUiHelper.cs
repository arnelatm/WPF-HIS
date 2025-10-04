using System;
using System.Linq;
using System.Windows.Forms;
using AATM.Contracts.Interfaces.Services;
using AATM.UI.Winforms.Localization; // For ControlLocalizer
using AATM.Core.Localization; // For LocalizationHelper

namespace AATM.UI.Winforms.Localization
{
    /// <summary>
    /// Helper to populate a language selection ToolStripComboBox and apply UI localization + grid header text.
    /// Keeps TranslationForm lean and reusable for other forms needing localization.
    /// </summary>
    public sealed class LanguageUiHelper
    {
        private readonly Func<ILocalizationService> _getLocalizationService;
        private readonly Func<DataGridView> _getGrid;
        private readonly Action<string> _afterApply; // callback in form (e.g. apply RTL + status text)

        public LanguageUiHelper(Func<ILocalizationService> getLocalizationService,
                                 Func<DataGridView> getGrid,
                                 Action<string> afterApply)
        {
            _getLocalizationService = getLocalizationService ?? throw new ArgumentNullException(nameof(getLocalizationService));
            _getGrid = getGrid ?? (() => null);
            _afterApply = afterApply ?? (_ => { });
        }

        public sealed class LanguageItem
        {
            public string Display { get; }
            public string Code { get; }
            public LanguageItem(string display, string code) { Display = display; Code = code; }
            public override string ToString() => Display;
        }

        public void PopulateLanguages(ToolStripComboBox combo)
        {
            var service = _getLocalizationService();
            if (combo == null || service == null) return;
            combo.Items.Clear();
            var langs = LocalizationHelper.SafeGetLanguages(service);
            foreach (var (display, code) in langs)
                combo.Items.Add(new LanguageItem(display, code));

            int idx = -1;
            for (int i = 0; i < combo.Items.Count; i++)
            {
                var li = combo.Items[i] as LanguageItem;
                if (li == null) continue;
                if (li.Code.StartsWith("ar", StringComparison.OrdinalIgnoreCase)) { idx = i; break; }
                if (idx == -1 && li.Code.StartsWith("en", StringComparison.OrdinalIgnoreCase)) idx = i;
            }
            if (idx == -1 && combo.Items.Count > 0) idx = 0;
            if (idx >= 0) combo.SelectedIndex = idx;
        }

        public void ApplySelectedLanguage(Form form, ToolStripComboBox combo)
        {
            if (form == null || combo == null) return;
            var li = combo.SelectedItem as LanguageItem;
            if (li == null) return;
            ApplyLanguage(form, li.Code);
        }

        public void ApplyLanguage(Form form, string languageCode)
        {
            var service = _getLocalizationService();
            if (service == null || form == null || string.IsNullOrWhiteSpace(languageCode)) return;

            service.SetLanguage(languageCode);

            try
            {
                var dict = service.GetLocalizedStrings();
                ControlLocalizer.TranslateControls(form, dict, languageCode, ControlLocalizer.TranslateToolStripButtonImage);
            }
            catch { }

            try
            {
                var dict = service.GetLocalizedStrings();
                var grid = _getGrid();
                if (grid != null)
                {
                    foreach (DataGridViewColumn col in grid.Columns)
                    {
                        var key = col.Tag != null ? col.Tag.ToString() : col.Name;
                        if (dict.TryGetValue(key, out var localized)
                            && !string.IsNullOrEmpty(localized)
                            && localized != col.HeaderText)
                        {
                            col.HeaderText = localized;
                        }
                    }
                }
            }
            catch { }

            _afterApply(languageCode);
        }
    }
}
