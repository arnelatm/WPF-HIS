using AATM.Contracts.Dtos;
using AATM.UI.Winforms.BaseControls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AATM.App.TableManager
{
    public partial class TranslationFrm : TranslationGridCrudForm
    {
        // Use factory so the base gets a real ICrudService at runtime and no-op at design-time
        public TranslationFrm() : base(() => new TranslationCrudService())
        {
            InitializeComponent();

            // Load data when the form is first shown (skips design-time)
            if (!IsInDesignMode())
            {
                this.Shown += async (s, e) => await LoadDataAsync();
            }
        }

        private static bool IsInDesignMode()
            => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        // Hook base to actual controls
        protected override DataGridView Grid => _dataGridView;
        protected override ToolStripStatusLabel StatusStripLabel => statusLabel;

        // Optional: define grid columns/formatting once
        protected override void ConfigureGrid(DataGridView grid)
        {
            if (grid.Columns.Count > 0) return;

            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToAddRows = false;

            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", DataPropertyName = "ID", HeaderText = "ID", Width = 60, Visible = false });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "ModuleName", DataPropertyName = "ModuleName", HeaderText = "Module", Width = 140 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "UIIdentifier", DataPropertyName = "UIIdentifier", HeaderText = "UI Identifier", Width = 160 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "OriginalString", DataPropertyName = "OriginalString", HeaderText = "Original", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "LanguageCode", DataPropertyName = "LanguageCode", HeaderText = "Lang", Width = 70 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "LocalizedString", DataPropertyName = "LocalizedString", HeaderText = "Localized", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        // Map selected grid row -> form fields
        protected override void PopulateFormFieldsFromGrid(int rowIndex)
        {
            var row = _dataGridView.Rows[rowIndex];
            if (row == null || row.IsNewRow) return;

            _txtModuleName.Text = row.Cells["ModuleName"].Value?.ToString() ?? string.Empty;
            _txtUIIdentifier.Text = row.Cells["UIIdentifier"].Value?.ToString() ?? string.Empty;
            _txtOriginalString.Text = row.Cells["OriginalString"].Value?.ToString() ?? string.Empty;
            _txtLanguageCode.Text = row.Cells["LanguageCode"].Value?.ToString() ?? string.Empty;
            _txtLocalizedString.Text = row.Cells["LocalizedString"].Value?.ToString() ?? string.Empty;
        }

        // Map form fields -> dto (include ID if a row is selected)
        protected override TranslationDto BuildModelFromForm(TranslationDto current)
        {
            var dto = current ?? new TranslationDto();

            if (_dataGridView.SelectedRows.Count > 0 && !_dataGridView.SelectedRows[0].IsNewRow)
            {
                var cellValue = _dataGridView.SelectedRows[0].Cells["ID"].Value;
                int id;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out id))
                    dto.ID = id;
            }

            dto.ModuleName = _txtModuleName.Text;
            dto.UIIdentifier = _txtUIIdentifier.Text;
            dto.OriginalString = _txtOriginalString.Text;
            dto.LanguageCode = _txtLanguageCode.Text;
            dto.LocalizedString = _txtLocalizedString.Text;
            return dto;
        }

        protected override int GetEntityId(TranslationDto entity) => entity?.ID ?? 0;

        protected override void ClearFormFieldsCore()
        {
            _txtModuleName.Text = string.Empty;
            _txtUIIdentifier.Text = string.Empty;
            _txtOriginalString.Text = string.Empty;
            _txtLanguageCode.Text = string.Empty;
            _txtLocalizedString.Text = string.Empty;
        }

        // Designer already wires click events; delegate them to base helpers

        private void _btnFirst_Click(object sender, EventArgs e) => GoFirst();
        private void _btnPrevious_Click(object sender, EventArgs e) => GoPrevious();
        private void _btnNext_Click(object sender, EventArgs e) => GoNext();
        private void _btnLast_Click(object sender, EventArgs e) => GoLast();

        private async void tsbSave_Click(object sender, EventArgs e) => await SaveOrUpdateAsync();
        private async void tsbDelete_Click(object sender, EventArgs e) => await DeleteSelectedAsync();

        // Present in designer; keep as no-op unless needed
        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
    }
}
