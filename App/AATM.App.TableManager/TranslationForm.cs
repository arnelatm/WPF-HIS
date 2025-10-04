using AATM.Business.Logic.Validators;
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

            ShowErrorsInStatusBar = false; // Only show errors in txtError
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

            IList<String> errors = TranslationDtoValidator.Validate(t);

            // Optionally, map errors to controls for UI feedback
            foreach (var error in errors)
            {
                // Example: AddValidationError(errors, control, error);
                // You may need to parse error messages or use a more structured error object
            }


            if (errors.Count > 0)
            {
                ShowValidationErrors(errors);
                var firstErrorBox = new[] { _txtModuleName, _txtLocalizedString, _txtUIIdentifier, _txtLanguageCode, _txtOriginalString }
                .FirstOrDefault(tb => myErrorProvider.GetError(tb) != "");
                firstErrorBox?.Focus();
                return ErrorDisplayControl.Text;
            }
            return null;
        }
    }
}
