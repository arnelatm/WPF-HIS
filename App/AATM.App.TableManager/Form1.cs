using AATM.Contracts.Dtos;
using AATM.UI.Winforms.BaseControls;
using System.ComponentModel;
using System.Windows.Forms;

namespace AATM.App.TableManager
{
    public partial class Form1 : TranslationGridCrudForm
    {
        public Form1() : base() // use design-time-safe base ctor
        {
            InitializeComponent();
            if (!IsInDesignMode()) { /* runtime-only init */ }
        }

        private static bool IsInDesignMode()
            => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        // REQUIRED: implement abstract members from BaseGridCrudForm<T>
        protected override DataGridView Grid => _dataGridView;
        protected override Label StatusLabel => _statusLabel;

        protected override void PopulateFormFieldsFromGrid(int rowIndex)
        {
            // Map grid -> form fields when you add them
        }

        protected override TranslationDto BuildModelFromForm(TranslationDto current)
        {
            // Map form fields -> dto
            return current ?? new TranslationDto();
        }

        protected override int GetEntityId(TranslationDto entity) => entity?.ID ?? 0;

        protected override void ClearFormFieldsCore()
        {
            // Clear your form fields when you add them
            _dataGridView?.ClearSelection();
        }
    }
}
