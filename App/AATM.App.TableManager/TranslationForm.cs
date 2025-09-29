#if DEBUG
#define DESIGN_TIME_SAFE
#endif
using AATM.Contracts.Dtos;
using AATM.Modules.Localization;
using AATM.UI.Winforms.BaseControls;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using AATM.UI.Winforms.Localization; // <-- Add this using for ControlLocalizer

namespace AATM.App.TableManager
{
#if DESIGN_TIME_SAFE
    public partial class TranslationForm : BaseGridCrudForm<TranslationDto>
#else
    public partial class TranslationForm : StrictGridCrudForm<TranslationDto>
#endif
    {
        private ToolStripProgressBar _statusProgress;

        // --- Added localization dependencies + UI items ---
        private readonly ILocalizationService _localizationService;
        private readonly IUiLocalizationManager _uiLocalizationManager;
        private ToolStripComboBox _languageCombo;
        private ToolStripButton _applyLangButton;

        private sealed class LanguageItem
        {
            public string Display { get; }
            public string Code { get; }
            public LanguageItem(string display, string code) { Display = display; Code = code; }
            public override string ToString() => Display;
        }

        public TranslationForm()
            : base(() => GetCrudServiceSafe(() => new TranslationCrudService()))
        {
            InitializeComponent();
            if (IsDesignTime()) return;

            // Resolve (or create) localization services.
            // Replace with your DI container resolution if available.
            _localizationService = ResolveLocalizationService();
            _uiLocalizationManager = ResolveUiLocalizationManager();

            AutoBindFormFields();

            _statusProgress = new ToolStripProgressBar
            {
                Name = "statusProgress",
                Style = ProgressBarStyle.Marquee,
                Visible = false
            };
            statusStrip.Items.Add(_statusProgress);

            InitializeLanguageUi();   // Populate language selector
        }

        // Allow base navigator to be extended
        protected override void OnCreateAdditionalNavigatorItems(BindingNavigator navigator)
        {
            base.OnCreateAdditionalNavigatorItems(navigator);

            navigator.Items.Add(new ToolStripSeparator());

            _languageCombo = new ToolStripComboBox
            {
                Name = "tscLanguage",
                DropDownStyle = ComboBoxStyle.DropDownList,
                ToolTipText = "Select UI language"
            };
            _languageCombo.SelectedIndexChanged += (s, e) => ApplySelectedLanguage();

            _applyLangButton = new ToolStripButton("Apply")
            {
                ToolTipText = "Apply selected language to this form"
            };
            _applyLangButton.Click += (s, e) => ApplySelectedLanguage();

            navigator.Items.Add(new ToolStripLabel("Lang:"));
            navigator.Items.Add(_languageCombo);
            navigator.Items.Add(_applyLangButton);
        }

        private void InitializeLanguageUi()
        {
            if (_languageCombo == null) return;
            _languageCombo.Items.Clear();

            var langs = SafeGetLanguages();
            foreach (var (display, code) in langs)
                _languageCombo.Items.Add(new LanguageItem(display, code));

            // Prefer Arabic if present; else English; else first.
            int idx = -1;
            for (int i = 0; i < _languageCombo.Items.Count; i++)
            {
                var li = (LanguageItem)_languageCombo.Items[i];
                if (li.Code.StartsWith("ar", StringComparison.OrdinalIgnoreCase)) { idx = i; break; }
                if (idx == -1 && li.Code.StartsWith("en", StringComparison.OrdinalIgnoreCase)) idx = i;
            }
            if (idx == -1 && _languageCombo.Items.Count > 0) idx = 0;
            if (idx >= 0) _languageCombo.SelectedIndex = idx;
        }

        private List<(string display, string code)> SafeGetLanguages()
        {
            try
            {
                return _localizationService?.GetAvailableLanguages() ??
                       new List<(string display, string code)> { ("English", "en-US"), ("Arabic", "ar-SA") };
            }
            catch
            {
                return new List<(string display, string code)> { ("English", "en-US"), ("Arabic", "ar-SA") };
            }
        }

        private void ApplySelectedLanguage()
        {
            var li = _languageCombo != null && _languageCombo.SelectedItem is LanguageItem
                ? (LanguageItem)_languageCombo.SelectedItem
                : null;
            if (li == null) return;
            ApplyLanguage(li.Code);
        }

        private void ApplyRightToLeft(bool rtl)
        {
            var rtlMode = rtl ? RightToLeft.Yes : RightToLeft.No;
            RightToLeft = rtlMode;
            RightToLeftLayout = rtl;
            void Recurse(Control c)
            {
                c.RightToLeft = rtlMode;
                foreach (Control child in c.Controls) Recurse(child);
            }
            foreach (Control c in Controls) Recurse(c);
        }

        private ILocalizationService ResolveLocalizationService()
        {
            // Replace with your actual implementation from LocalizationService.cs
            // For example, if your class is named LocalizationService and has a suitable constructor:
            return new LocalizationService(_languageCombo?.SelectedItem is LanguageItem li ? li.Code : "en-US", this.Name);
        }

        // Minimal in-memory implementation for demonstration purposes.
        private class InMemoryLocalizationService : ILocalizationService
        {
            private readonly Dictionary<string, Dictionary<string, string>> _strings = new Dictionary<string, Dictionary<string, string>>();
            private string _currentLanguage = "en-US";
            public bool IsRightToLeft => _currentLanguage.StartsWith("ar", StringComparison.OrdinalIgnoreCase);

            public void AddOrUpdateString(string moduleName, string uiIdentifier, string originalString, string languageCode, string localizedString)
            {
                var key = $"{moduleName}:{uiIdentifier}:{languageCode}";
                if (!_strings.ContainsKey(key))
                    _strings[key] = new Dictionary<string, string>();
                _strings[key][originalString] = localizedString;
            }

            public string Translate(string sourceLang, string targetLang, string textToTranslate)
            {
                // Dummy translation: just returns the text for demonstration.
                return textToTranslate;
            }

            public List<(string display, string code)> GetAvailableLanguages()
            {
                return new List<(string display, string code)>
                {
                    ("English", "en-US"),
                    ("Arabic", "ar-SA")
                };
            }

            public string GetString(string moduleName, string uiIdentifier, string originalString)
            {
                if (originalString == "Original") System.Diagnostics.Debugger.Break();
                // Example breakpoint for debugging
                var key = $"{moduleName}:{uiIdentifier}:{_currentLanguage}";
                if (_strings.TryGetValue(key, out var dict) && dict.TryGetValue(originalString, out var localized))
                    return localized;
                return originalString;
            }

            public IDictionary<string, string> GetLocalizedStrings()
            {
                // Returns all strings for the current language.
                var result = new Dictionary<string, string>();
                foreach (var kvp in _strings)
                {
                    if (kvp.Key.EndsWith(_currentLanguage))
                    {
                        foreach (var strKvp in kvp.Value)
                            result[strKvp.Key] = strKvp.Value;
                    }
                }
                return result;
            }

            public void AddString(string moduleName, string text, string languageCode)
            {
                AddOrUpdateString(moduleName, text, text, languageCode, text);
            }

            public void SetLanguage(string languageCode)
            {
                if (string.IsNullOrWhiteSpace(languageCode))
                    return;

                _currentLanguage = languageCode;
            }
        }

        private IUiLocalizationManager ResolveUiLocalizationManager()
        {
            // Simple in-memory implementation for demonstration.
            // Replace with DI or a real service in production.
            return new InMemoryUiLocalizationManager();
        }

        // Minimal in-memory implementation for demonstration purposes.
        private class InMemoryUiLocalizationManager : IUiLocalizationManager
        {
            // Stores registered strings per form/module/language
            private readonly Dictionary<string, Dictionary<string, string>> _registeredStrings =
                new Dictionary<string, Dictionary<string, string>>();

            public void RegisterFormStrings(Form form, string moduleName, string languageCode)
            {
                if (form == null) return;
                var key = $"{moduleName}:{languageCode}";
                if (!_registeredStrings.ContainsKey(key))
                    _registeredStrings[key] = new Dictionary<string, string>();

                foreach (Control c in GetAllControls(form))
                {
                    string uiId = c.Name;
                    string original = c.Text;
                    if (!string.IsNullOrWhiteSpace(uiId) && !string.IsNullOrWhiteSpace(original))
                    {
                        _registeredStrings[key][uiId] = original;
                    }
                }
            }

            public void SetLocalizedText(Form form, Dictionary<string, string> localizedStrings)
            {
                if (form == null || localizedStrings == null) return;
                foreach (Control c in GetAllControls(form))
                {
                    string uiId = c.Name;
                    if (!string.IsNullOrWhiteSpace(uiId) && localizedStrings.TryGetValue(uiId, out var localized))
                    {
                        c.Text = localized;
                    }
                }
            }

            private IEnumerable<Control> GetAllControls(Control parent)
            {
                foreach (Control c in parent.Controls)
                {
                    yield return c;
                    foreach (var child in GetAllControls(c))
                        yield return child;
                }
            }
        }

        protected override DataGridView Grid => _dataGridView;
        protected override ToolStripStatusLabel StatusStripLabel => statusLabel;
        protected override ToolStripProgressBar StatusProgress => _statusProgress;
        protected override bool AutoLoadOnShown => true;

        protected override void DefineColumns(DataGridView grid)
        {
            AddHiddenIdColumn(grid, nameof(TranslationDto.ID));
            AddTextColumn(grid, nameof(TranslationDto.ModuleName), "Module", 140);
            AddTextColumn(grid, nameof(TranslationDto.UIIdentifier), "UI Identifier", 160);
            AddTextColumn(grid, nameof(TranslationDto.OriginalString), "Original", 100, fill: true);
            AddTextColumn(grid, nameof(TranslationDto.LanguageCode), "Lang", 70);
            AddTextColumn(grid, nameof(TranslationDto.LocalizedString), "Localized", 100, fill: true);
        }

        protected override string GetDeleteConfirmationText(TranslationDto entity)
        {
            if (entity == null) return base.GetDeleteConfirmationText(null);

            string original = entity.OriginalString ?? string.Empty;
            if (original.Length > 80)
                original = original.Substring(0, 77) + "...";

            return "Are you sure you want to delete this translation?" + Environment.NewLine + Environment.NewLine
                 + "ID: " + entity.ID + Environment.NewLine
                 + "Module: " + (entity.ModuleName ?? string.Empty) + Environment.NewLine
                 + "UI Identifier: " + (entity.UIIdentifier ?? string.Empty) + Environment.NewLine
                 + "Language: " + (entity.LanguageCode ?? string.Empty) + Environment.NewLine
                 + "Original: " + original;
        }

        // Event handler for language change
        private void ComboBoxLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected language code from ComboBox
            var li = _languageCombo != null && _languageCombo.SelectedItem is LanguageItem
                ? (LanguageItem)_languageCombo.SelectedItem
                : null;
            if (li == null || string.IsNullOrWhiteSpace(li.Code))
                return;

            ApplyLanguage(li.Code);
        }

        // Add this method to TranslationForm to automate registration and application of localized strings.
        private void RegisterAndApplyAllLocalizedStrings(string languageCode)
        {
            // Register all control strings for the current language if not already registered.
            foreach (Control c in GetAllControls(this))
            {
                // Only register if not already present for this language.
                var existing = _localizationService.GetString(this.GetType().Name, c.Name, c.Text);
                if (existing == c.Text)
                {
                    // Add default translation (could be extended to load from resources/database)
                    _localizationService.AddOrUpdateString(this.GetType().Name, c.Name, c.Text, languageCode, c.Text);
                }
            }

        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                yield return c;
                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }

        // Call this method in ApplyLanguage after setting the language:
        private void ApplyLanguage(string languageCode)
        {
            if (_localizationService == null || _uiLocalizationManager == null) return;

            _localizationService.SetLanguage(languageCode);

            // NEW: Use ControlLocalizer to apply translations to all controls
            try
            {
                var translationDict = _localizationService.GetLocalizedStrings();
                ControlLocalizer.TranslateControls(this, translationDict, languageCode, ControlLocalizer.TranslateToolStripButtonImage);
            }
            catch { /* ignore mapping issues */ }

            // Translate grid column headers
            try
            {
                var translationDict = _localizationService.GetLocalizedStrings();
                foreach (DataGridViewColumn col in _dataGridView.Columns)
                {
                    var key = col.Tag != null ? col.Tag.ToString() : col.Name;
                    if (translationDict.TryGetValue(key, out var localized) && !string.IsNullOrEmpty(localized) && localized != col.HeaderText)
                        col.HeaderText = localized;
                }
            }
            catch { /* ignore mapping issues */ }

            bool rtl = _localizationService.IsRightToLeft || languageCode.StartsWith("ar", StringComparison.OrdinalIgnoreCase);
            ApplyRightToLeft(rtl);
            statusLabel.Text = $"Language applied: {languageCode}";
        }

    }
}