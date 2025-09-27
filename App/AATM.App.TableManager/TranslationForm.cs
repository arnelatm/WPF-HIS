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

        private void ApplyLanguage(string languageCode)
        {
            if (_localizationService == null || _uiLocalizationManager == null) return;

            // OPTIONAL: If your implementation needs to switch internal state,
            // add a SetCurrentLanguage(languageCode) method to ILocalizationService.
            // _localizationService.SetCurrentLanguage(languageCode);  // (Requires extension)

            // Register any strings not yet in the store (only once per language)
            try
            {
                _uiLocalizationManager.RegisterFormStrings(this, "TranslationModule", languageCode);
            }
            catch { /* ignore */ }

            IDictionary<string, string> dict = null;
            try { dict = _localizationService.GetLocalizedStrings(); } catch { }

            if (dict != null && dict.Count > 0)
            {
                try
                {
                    _uiLocalizationManager.SetLocalizedText(this, dict.ToDictionary(k => k.Key, v => v.Value));
                }
                catch { /* ignore mapping issues */ }
            }

            // Adjust RightToLeft if Arabic (or service indicates RTL)
            bool rtl = _localizationService.IsRightToLeft || languageCode.StartsWith("ar", StringComparison.OrdinalIgnoreCase);
            ApplyRightToLeft(rtl);
            statusLabel.Text = $"Language applied: {languageCode}";
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
            // TODO: replace with real implementation / DI.
            // Return null if not yet wired; the form will degrade gracefully.
            return null;
        }

        private IUiLocalizationManager ResolveUiLocalizationManager()
        {
            // TODO: replace with real implementation / DI.
            return null;
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
    }
}