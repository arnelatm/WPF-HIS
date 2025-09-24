using AATM.Contracts.Dtos;
using AATM.Modules.Localization;
using AATM.UI.Winforms.BaseControls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AATM.App.TableManager
{
    public partial class TranslationForm : TranslationGridCrudForm
    {
        private ToolStripProgressBar _statusProgress;

        // Use factory so the base gets a real ICrudService at runtime and no-op at design-time
        public TranslationForm() : base(() => new TranslationCrudService())
        {
            InitializeComponent();

            // Wire toolbar buttons to base helpers
            WireNavigationButtons(_btnFirst, _btnPrevious, _btnNext, _btnLast);
            WireCrudButtons(null, tsbSave, tsbDelete);

            // Add a marquee progress bar to the StatusStrip (toggled by base SetBusy)
            _statusProgress = new ToolStripProgressBar
            {
                Name = "statusProgress",
                Style = ProgressBarStyle.Marquee,
                Visible = false
            };
            statusStrip.Items.Add(_statusProgress);
        }

        private static bool IsInDesignMode()
            => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        // Hook base to actual controls
        protected override DataGridView Grid { get { return _dataGridView; } }
        protected override ToolStripStatusLabel StatusStripLabel { get { return statusLabel; } }
        protected override ToolStripProgressBar StatusProgress { get { return _statusProgress; } }

        // Optional: define grid columns/formatting once
        protected override void ConfigureGrid(DataGridView grid)
        {
            if (grid.Columns.Count > 0) return;

            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.RowHeadersVisible = false;

            // Optional: reduce flicker
            var pi = grid.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (pi != null) pi.SetValue(grid, true, null);

            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.ID), DataPropertyName = nameof(TranslationDto.ID), HeaderText = "ID", Width = 60, Visible = false, ValueType = typeof(int) });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.ModuleName), DataPropertyName = nameof(TranslationDto.ModuleName), HeaderText = "Module", Width = 140 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.UIIdentifier), DataPropertyName = nameof(TranslationDto.UIIdentifier), HeaderText = "UI Identifier", Width = 160 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.OriginalString), DataPropertyName = nameof(TranslationDto.OriginalString), HeaderText = "Original", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.LanguageCode), DataPropertyName = nameof(TranslationDto.LanguageCode), HeaderText = "Lang", Width = 70 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.LocalizedString), DataPropertyName = nameof(TranslationDto.LocalizedString), HeaderText = "Localized", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.DefaultCellStyle.NullValue = string.Empty;
            }
        }

        // Map selected grid row -> form fields
        protected override void PopulateFormFieldsFromGrid(int rowIndex)
        {
            var row = _dataGridView.Rows[rowIndex];
            if (row == null || row.IsNewRow) return;

            _txtModuleName.Text = Convert.ToString(row.Cells[nameof(TranslationDto.ModuleName)].Value) ?? string.Empty;
            _txtUIIdentifier.Text = Convert.ToString(row.Cells[nameof(TranslationDto.UIIdentifier)].Value) ?? string.Empty;
            _txtOriginalString.Text = Convert.ToString(row.Cells[nameof(TranslationDto.OriginalString)].Value) ?? string.Empty;
            _txtLanguageCode.Text = Convert.ToString(row.Cells[nameof(TranslationDto.LanguageCode)].Value) ?? string.Empty;
            _txtLocalizedString.Text = Convert.ToString(row.Cells[nameof(TranslationDto.LocalizedString)].Value) ?? string.Empty;
        }

        // Map form fields -> dto (include ID if a row is selected)
        protected override TranslationDto BuildModelFromForm(TranslationDto current)
        {
            var dto = current ?? new TranslationDto();

            if (_dataGridView.SelectedRows.Count > 0 && !_dataGridView.SelectedRows[0].IsNewRow)
            {
                var cellValue = _dataGridView.SelectedRows[0].Cells[nameof(TranslationDto.ID)].Value;
                int id;
                if (cellValue != null && int.TryParse(Convert.ToString(cellValue), out id))
                    dto.ID = id;
            }

            dto.ModuleName = _txtModuleName.Text;
            dto.UIIdentifier = _txtUIIdentifier.Text;
            dto.OriginalString = _txtOriginalString.Text;
            dto.LanguageCode = _txtLanguageCode.Text;
            dto.LocalizedString = _txtLocalizedString.Text;
            return dto;
        }

        protected override int GetEntityId(TranslationDto entity) { return entity != null ? entity.ID : 0; }

        protected override void ClearFormFieldsCore()
        {
            _txtModuleName.Text = string.Empty;
            _txtUIIdentifier.Text = string.Empty;
            _txtOriginalString.Text = string.Empty;
            _txtLanguageCode.Text = string.Empty;
            _txtLocalizedString.Text = string.Empty;
        }

        // OPTIONAL: richer delete confirmation (contextual details)
        protected override string GetDeleteConfirmationText(TranslationDto entity)
        {
            if (entity == null) return base.GetDeleteConfirmationText(null);

            string original = entity.OriginalString ?? string.Empty;
            if (original.Length > 80) original = original.Substring(0, 77) + "...";

            return "Are you sure you want to delete this translation?" + Environment.NewLine + Environment.NewLine
                 + "ID: " + entity.ID + Environment.NewLine
                 + "Module: " + (entity.ModuleName ?? string.Empty) + Environment.NewLine
                 + "UI Identifier: " + (entity.UIIdentifier ?? string.Empty) + Environment.NewLine
                 + "Language: " + (entity.LanguageCode ?? string.Empty) + Environment.NewLine
                 + "Original: " + original;
        }
    }
}
