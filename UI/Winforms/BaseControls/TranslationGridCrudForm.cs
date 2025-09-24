using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services; // ensure this matches Contracts project
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AATM.UI.Winforms.BaseControls
{
    /// <summary>
    /// Concrete shim for WinForms Designer compatibility.
    /// Provides design-time safe overrides so Designer can instantiate it
    /// without touching abstract generic base logic.
    /// </summary>
    [DesignerCategory("Form")]
    public class TranslationGridCrudForm : BaseGridCrudForm<TranslationDto>
    {
        // Stable design-time controls so overrides don't return new instances each access
        private readonly DataGridView _designGrid = new DataGridView { Dock = DockStyle.Fill };
        private readonly Label _designStatusLabel = new Label { Dock = DockStyle.Bottom, Height = 18, Text = "Design-time status" };

        // Designer-safe default: always return the no-op service here.
        // Runtime forms (e.g., TranslationForm) pass their own factory.
        public TranslationGridCrudForm()
            : base(() => new BaseGridCrudForm<TranslationDto>.DesignTimeCrudService())
        {
            if (IsInDesignMode)
            {
                // Provide something visible at design-time
                Controls.Add(_designGrid);
                Controls.Add(_designStatusLabel);
                Text = "TranslationGridCrudForm (Design)";
            }
        }

        public TranslationGridCrudForm(Func<ICrudService<TranslationDto>> serviceFactory)
            : base(serviceFactory) { }

        public TranslationGridCrudForm(ICrudService<TranslationDto> service)
            : base(service) { }

        private static bool IsInDesignMode =>
            LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        // Avoid auto-loading when designer is active
        protected override bool AutoLoadOnShown => !IsInDesignMode;

        // Stubbed overrides for design-time safety
        protected override DataGridView Grid => _designGrid;
        protected override Label StatusLabel => _designStatusLabel;

        protected override TranslationDto BuildModelFromForm(TranslationDto current) => new TranslationDto();
        protected override void ClearFormFieldsCore() { /* no-op for design-time */ }
        protected override int GetEntityId(TranslationDto entity) => entity?.ID ?? 0;
        protected override void PopulateFormFieldsFromGrid(int rowIndex) { /* no-op for design-time */ }
    }
}