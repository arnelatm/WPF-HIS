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
    public class TranslationGridCrudForm : BaseGridCrudForm<TranslationDto>
    {

        // Pseudocode:
        // - Use a factory lambda to defer service creation until base invokes it.
        // - If in design mode, immediately return the design-time no-op service.
        // - Otherwise, try to create the real TranslationCrudService.
        // - If creation fails (e.g., designer quirks), fall back to the design-time service.
        // - Avoid explicit casts; rely on the generic interface implementation.

        // Designer-safe default: always return the no-op service here.
        // Runtime forms (e.g., TranslationFrm) pass their own factory.
        public TranslationGridCrudForm()
            : base(() => new BaseGridCrudForm<TranslationDto>.DesignTimeCrudService())
        { }

        public TranslationGridCrudForm(Func<ICrudService<TranslationDto>> serviceFactory)
            : base(serviceFactory) { }

        public TranslationGridCrudForm(ICrudService<TranslationDto> service)
            : base(service) { }

        private static bool IsInDesignMode =>
            LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        // Stubbed overrides for design-time safety
        protected override DataGridView Grid => new DataGridView();
        protected override Label StatusLabel => new Label();

        protected override TranslationDto BuildModelFromForm(TranslationDto current) => new TranslationDto();
        protected override void ClearFormFieldsCore() { /* no-op for design-time */ }
        protected override int GetEntityId(TranslationDto entity) => entity?.ID ?? 0;
        protected override void PopulateFormFieldsFromGrid(int rowIndex) { /* no-op for design-time */ }
    }
}