#if DEBUG
#define DESIGN_TIME_SAFE
#endif
using AATM.Contracts.Dtos;
using AATM.Modules.Localization;
using AATM.UI.Winforms.BaseControls;
using System;
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

        public TranslationForm()
            : base(() => GetCrudServiceSafe(() => new TranslationCrudService()))
        {
            InitializeComponent();
            if (IsDesignTime()) return;

            // Register simple text bindings (eliminates manual populate/collect/clear code)
            RegisterTextBinding(_txtModuleName,     d => d.ModuleName);
            RegisterTextBinding(_txtUIIdentifier,  d => d.UIIdentifier);
            RegisterTextBinding(_txtOriginalString,d => d.OriginalString);
            RegisterTextBinding(_txtLanguageCode,  d => d.LanguageCode);
            RegisterTextBinding(_txtLocalizedString,d => d.LocalizedString);

            WireNavigationButtons(_btnFirst, _btnPrevious, _btnNext, _btnLast);
            WireCrudButtons(null, tsbSave, tsbDelete);

            _statusProgress = new ToolStripProgressBar
            {
                Name = "statusProgress",
                Style = ProgressBarStyle.Marquee,
                Visible = false
            };
            statusStrip.Items.Add(_statusProgress);
        }

        protected override DataGridView Grid => _dataGridView;
        protected override ToolStripStatusLabel StatusStripLabel => statusLabel;
        protected override ToolStripProgressBar StatusProgress => _statusProgress;
        protected override bool AutoLoadOnShown => true;

        // Only define columns; defaults + buffering handled by base
        protected override void DefineColumns(DataGridView grid)
        {
            AddHiddenIdColumn(grid, nameof(TranslationDto.ID));
            AddTextColumn(grid, nameof(TranslationDto.ModuleName), "Module", 140);
            AddTextColumn(grid, nameof(TranslationDto.UIIdentifier), "UI Identifier", 160);
            AddTextColumn(grid, nameof(TranslationDto.OriginalString), "Original", 100, fill: true);
            AddTextColumn(grid, nameof(TranslationDto.LanguageCode), "Lang", 70);
            AddTextColumn(grid, nameof(TranslationDto.LocalizedString), "Localized", 100, fill: true);
        }

        // Custom delete confirmation remains (optional)
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