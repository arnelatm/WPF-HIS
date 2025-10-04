#if DEBUG
#define DESIGN_TIME_SAFE
#endif
using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using AATM.Modules.Localization;
using AATM.UI.Winforms.BaseControls;
using AATM.UI.Winforms.Localization;
using System;
using System.Windows.Forms;

namespace AATM.App.TableManager
{
    public partial class TranslationForm : BaseGridCrudForm
    {
        private ToolStripProgressBar _statusProgress;
        private readonly ILocalizationService _localizationService;
        private readonly IUiLocalizationManager _uiLocalizationManager;
        private ToolStripComboBox _languageCombo;
        private ToolStripButton _applyLangButton;
        private bool _languageUiNeedsInit; // flag to defer helper init until after ctor

        public TranslationForm() : base("TranslationForm")
        {
            InitializeComponent();
            if (IsDesignTime()) return;

            EnsureErrorProvider();

            // Navigator (and thus language combo creation) happens in base ctor via virtual override below.
            // So by the time we reach here, _languageCombo may already exist but helper not yet initialized.

            InitializeTypedController<TranslationDto>(() => new TranslationCrudService());

            // Create localization service AFTER potential combo created, but before helper init.
            _localizationService = ResolveLocalizationService();
            _uiLocalizationManager = ResolveUiLocalizationManager();

            _statusProgress = new ToolStripProgressBar
            {
                Name = "statusProgress",
                Style = ProgressBarStyle.Marquee,
                Visible = false
            };
            statusStrip.Items.Add(_statusProgress);

            AutoBindFormFields(typeof(TranslationDto));

            //InitializeLanguageHelperIfNeeded();
        }

        protected override DataGridView Grid => _dataGridView;
        protected override ToolStripStatusLabel StatusStripLabel => statusLabel;
        protected override ToolStripProgressBar StatusProgress => _statusProgress;
        protected override bool AutoLoadOnShown => true;

        protected override string GetDeleteConfirmationText(IEntityWithId entity)
        {
            var t = entity as TranslationDto;
            if (t == null) return base.GetDeleteConfirmationText(entity);

            string original = t.OriginalString ?? string.Empty;
            if (original.Length > 80)
                original = original.Substring(0, 77) + "...";

            return "Are you sure you want to delete this translation?"
                   + Environment.NewLine + Environment.NewLine
                   + "ID: " + t.ID + Environment.NewLine
                   + "Module: " + (t.ModuleName ?? string.Empty) + Environment.NewLine
                   + "UI Identifier: " + (t.UIIdentifier ?? string.Empty) + Environment.NewLine
                   + "Language: " + (t.LanguageCode ?? string.Empty) + Environment.NewLine
                   + "Original: " + original;
        }

        protected override string ValidateBeforeSave(IEntityWithId entity)
        {
            EnsureErrorProvider();
            errorProvider1?.Clear();

            var t = entity as TranslationDto;
            if (t == null)
                return "Invalid entity.";

            if (t.ModuleName != null) t.ModuleName = t.ModuleName.Trim();
            if (t.LocalizedString != null) t.LocalizedString = t.LocalizedString.Trim();
            if (t.UIIdentifier != null) t.UIIdentifier = t.UIIdentifier.Trim();
            if (t.LanguageCode != null) t.LanguageCode = t.LanguageCode.Trim();
            if (t.OriginalString != null) t.OriginalString = t.OriginalString.Trim();

            if (string.IsNullOrWhiteSpace(t.ModuleName)) { SetFieldError(_txtModuleName, "Module is required."); _txtModuleName?.Focus(); return "Module is required."; }
            if (string.IsNullOrWhiteSpace(t.LocalizedString)) { SetFieldError(_txtLocalizedString, "Localized String is required."); _txtLocalizedString?.Focus(); return "Localized String is required."; }
            if (string.IsNullOrWhiteSpace(t.UIIdentifier)) { SetFieldError(_txtUIIdentifier, "UI Identifier is required."); _txtUIIdentifier?.Focus(); return "UI Identifier is required."; }
            if (string.IsNullOrWhiteSpace(t.LanguageCode)) { SetFieldError(_txtLanguageCode, "Language code is required."); _txtLanguageCode?.Focus(); return "Language code is required."; }
            if (string.IsNullOrWhiteSpace(t.OriginalString)) { SetFieldError(_txtOriginalString, "Original text is required."); _txtOriginalString?.Focus(); return "Original text is required."; }

            if (t.ModuleName.Length > 100) { SetFieldError(_txtModuleName, "Module exceeds 100 characters."); _txtModuleName?.Focus(); return "Module exceeds 100 characters."; }
            if (t.UIIdentifier.Length > 150) { SetFieldError(_txtUIIdentifier, "UI Identifier exceeds 150 characters."); _txtUIIdentifier?.Focus(); return "UI Identifier exceeds 150 characters."; }
            if (t.LanguageCode.Length > 10) { SetFieldError(_txtLanguageCode, "Language code exceeds 10 characters."); _txtLanguageCode?.Focus(); return "Language code exceeds 10 characters."; }

            if (!System.Text.RegularExpressions.Regex.IsMatch(t.LanguageCode, @"^[a-z]{2,3}(-[A-Z]{2})?$") )
            {
                SetFieldError(_txtLanguageCode, "Language code format invalid (e.g. en-US).");
                _txtLanguageCode?.Focus();
                return "Language code format invalid.";
            }

            if (string.Equals(t.ModuleName, t.UIIdentifier, StringComparison.OrdinalIgnoreCase))
            {
                SetFieldError(_txtUIIdentifier, "UI Identifier must differ from Module.");
                _txtUIIdentifier?.Focus();
                return "UI Identifier must differ from Module.";
            }

            return null;
        }
    }
}