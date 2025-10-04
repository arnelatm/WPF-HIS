using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.Modules.Localization;
using AATM.UI.Winforms.BaseControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AATM.App.TableManager
{
    public partial class TranslationForm : BaseGridCrudForm
    {
        private ToolStripProgressBar _statusProgress;
        private ToolStripComboBox _languageCombo;
        private ToolStripButton _applyLangButton;
        private bool _languageUiNeedsInit; // flag to defer helper init until after ctor

        public TranslationForm() : base("TranslationForm")
        {
            InitializeComponent();
            if (IsDesignTime()) return;

            EnsureErrorProvider();
            ErrorDisplayControl = txtErrors;

            InitializeTypedController<TranslationDto>(() => new TranslationCrudService());

            _statusProgress = new ToolStripProgressBar
            {
                Name = "statusProgress",
                Style = ProgressBarStyle.Marquee,
                Visible = false
            };
            statusStrip.Items.Add(_statusProgress);

            AutoBindFormFields(typeof(TranslationDto));

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
            myErrorProvider?.Clear();

            var t = entity as TranslationDto;
            if (t == null)
                return "Invalid entity.";

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(t.ModuleName))
            {
                SetFieldError(_txtModuleName, "Module is required.");
                errors.Add("Module is required.");
            }
            if (string.IsNullOrWhiteSpace(t.LocalizedString))
            {
                SetFieldError(_txtLocalizedString, "Localized String is required.");
                errors.Add("Localized String is required.");
            }
            if (string.IsNullOrWhiteSpace(t.UIIdentifier))
            {
                SetFieldError(_txtUIIdentifier, "UI Identifier is required.");
                errors.Add("UI Identifier is required.");
            }
            if (string.IsNullOrWhiteSpace(t.LanguageCode))
            {
                SetFieldError(_txtLanguageCode, "Language code is required.");
                errors.Add("Language code is required.");
            }
            if (string.IsNullOrWhiteSpace(t.OriginalString))
            {
                SetFieldError(_txtOriginalString, "Original text is required.");
                errors.Add("Original text is required.");
            }

            if (t.ModuleName != null && t.ModuleName.Length > 100)
            {
                SetFieldError(_txtModuleName, "Module exceeds 100 characters.");
                errors.Add("Module exceeds 100 characters.");
            }
            if (t.UIIdentifier != null && t.UIIdentifier.Length > 150)
            {
                SetFieldError(_txtUIIdentifier, "UI Identifier exceeds 150 characters.");
                errors.Add("UI Identifier exceeds 150 characters.");
            }
            if (t.LanguageCode != null && t.LanguageCode.Length > 10)
            {
                SetFieldError(_txtLanguageCode, "Language code exceeds 10 characters.");
                errors.Add("Language code exceeds 10 characters.");
            }
            if (t.LanguageCode != null && !System.Text.RegularExpressions.Regex.IsMatch(t.LanguageCode, @"^[a-z]{2,3}(-[A-Z]{2})?$"))
            {
                SetFieldError(_txtLanguageCode, "Language code format invalid (e.g. en-US).");
                errors.Add("Language code format invalid.");
            }
            if (t.ModuleName != null && t.UIIdentifier != null &&
                string.Equals(t.ModuleName, t.UIIdentifier, StringComparison.OrdinalIgnoreCase))
            {
                SetFieldError(_txtUIIdentifier, "UI Identifier must differ from Module.");
                errors.Add("UI Identifier must differ from Module.");
            }

            if (errors.Count > 0)
            {
                txtErrors.Text = string.Join(Environment.NewLine, errors);
                var firstErrorBox = new[] { _txtModuleName, _txtLocalizedString, _txtUIIdentifier, _txtLanguageCode, _txtOriginalString }
                .FirstOrDefault(tb => myErrorProvider.GetError(tb) != "");
                firstErrorBox?.Focus();
                return txtErrors.Text;
            }
            else
            {
                txtErrors.Text = ""; // Clear previous errors
            }

            return null;
        }

        protected override async System.Threading.Tasks.Task OnAfterSaveAsync(IEntityWithId saved)
        {
            txtErrors.Text = ""; // Clear error messages
            await base.OnAfterSaveAsync(saved);
        }
    }
}
//protected override string ValidateBeforeSave(IEntityWithId entity)
//{
//    EnsureErrorProvider();
//    myErrorProvider?.Clear();

//    var t = entity as TranslationDto;
//    if (t == null)
//        return "Invalid entity.";

//    if (t.ModuleName != null) t.ModuleName = t.ModuleName.Trim();
//    if (t.LocalizedString != null) t.LocalizedString = t.LocalizedString.Trim();
//    if (t.UIIdentifier != null) t.UIIdentifier = t.UIIdentifier.Trim();
//    if (t.LanguageCode != null) t.LanguageCode = t.LanguageCode.Trim();
//    if (t.OriginalString != null) t.OriginalString = t.OriginalString.Trim();

//    if (string.IsNullOrWhiteSpace(t.ModuleName)) { SetFieldError(_txtModuleName, "Module is required."); _txtModuleName?.Focus(); return "Module is required."; }
//    if (string.IsNullOrWhiteSpace(t.LocalizedString)) { SetFieldError(_txtLocalizedString, "Localized String is required."); _txtLocalizedString?.Focus(); return "Localized String is required."; }
//    if (string.IsNullOrWhiteSpace(t.UIIdentifier)) { SetFieldError(_txtUIIdentifier, "UI Identifier is required."); _txtUIIdentifier?.Focus(); return "UI Identifier is required."; }
//    if (string.IsNullOrWhiteSpace(t.LanguageCode)) { SetFieldError(_txtLanguageCode, "Language code is required."); _txtLanguageCode?.Focus(); return "Language code is required."; }
//    if (string.IsNullOrWhiteSpace(t.OriginalString)) { SetFieldError(_txtOriginalString, "Original text is required."); _txtOriginalString?.Focus(); return "Original text is required."; }

//    if (t.ModuleName.Length > 100) { SetFieldError(_txtModuleName, "Module exceeds 100 characters."); _txtModuleName?.Focus(); return "Module exceeds 100 characters."; }
//    if (t.UIIdentifier.Length > 150) { SetFieldError(_txtUIIdentifier, "UI Identifier exceeds 150 characters."); _txtUIIdentifier?.Focus(); return "UI Identifier exceeds 150 characters."; }
//    if (t.LanguageCode.Length > 10) { SetFieldError(_txtLanguageCode, "Language code exceeds 10 characters."); _txtLanguageCode?.Focus(); return "Language code exceeds 10 characters."; }

//    if (!System.Text.RegularExpressions.Regex.IsMatch(t.LanguageCode, @"^[a-z]{2,3}(-[A-Z]{2})?$") )
//    {
//        SetFieldError(_txtLanguageCode, "Language code format invalid (e.g. en-US).");
//        _txtLanguageCode?.Focus();
//        return "Language code format invalid.";
//    }

//    if (string.Equals(t.ModuleName, t.UIIdentifier, StringComparison.OrdinalIgnoreCase))
//    {
//        SetFieldError(_txtUIIdentifier, "UI Identifier must differ from Module.");
//        _txtUIIdentifier?.Focus();
//        return "UI Identifier must differ from Module.";
//    }

//    return null;
//}