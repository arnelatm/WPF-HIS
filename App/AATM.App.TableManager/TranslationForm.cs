#if DEBUG
#define DESIGN_TIME_SAFE
#endif
using AATM.Contracts.Dtos;
using AATM.Contracts.Interfaces.Services;
using AATM.Modules.Localization;
using AATM.UI.Winforms.BaseControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
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

        public TranslationForm()
            : base(() => GetCrudServiceSafe())
        {
            InitializeComponent();

            if (IsDesignTime())
                return;

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

        // More reliable design-time detection than LicenseManager alone
        private static bool IsDesignTime()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return true;

            try
            {
                var proc = Process.GetCurrentProcess();
                if (proc != null && proc.ProcessName.Equals("devenv", StringComparison.OrdinalIgnoreCase))
                    return true;

                // Heuristic: VS designer assemblies loaded
                if (AppDomain.CurrentDomain.GetAssemblies()
                      .Any(a => a.FullName.StartsWith("Microsoft.VisualStudio", StringComparison.OrdinalIgnoreCase)))
                    return true;
            }
            catch { /* swallow – never block design mode */ }

            return false;
        }

        private static ICrudService<TranslationDto> GetCrudServiceSafe()
        {
            if (IsDesignTime())
                return new BaseGridCrudForm<TranslationDto>.DesignTimeCrudService();

            try
            {
                // Only touch the real service in true runtime
                return new TranslationCrudService();
            }
            catch (Exception)
            {
                // Fallback – never let designer or startup crash
                return new BaseGridCrudForm<TranslationDto>.DesignTimeCrudService();
            }
        }

        protected override DataGridView Grid => _dataGridView;
        protected override ToolStripStatusLabel StatusStripLabel => statusLabel;
        protected override ToolStripProgressBar StatusProgress => _statusProgress;
        protected override bool AutoLoadOnShown => true;

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

            var pi = grid.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi?.SetValue(grid, true, null);

            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.ID), DataPropertyName = nameof(TranslationDto.ID), HeaderText = "ID", Width = 60, Visible = false, ValueType = typeof(int) });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.ModuleName), DataPropertyName = nameof(TranslationDto.ModuleName), HeaderText = "Module", Width = 140 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.UIIdentifier), DataPropertyName = nameof(TranslationDto.UIIdentifier), HeaderText = "UI Identifier", Width = 160 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.OriginalString), DataPropertyName = nameof(TranslationDto.OriginalString), HeaderText = "Original", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.LanguageCode), DataPropertyName = nameof(TranslationDto.LanguageCode), HeaderText = "Lang", Width = 70 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = nameof(TranslationDto.LocalizedString), DataPropertyName = nameof(TranslationDto.LocalizedString), HeaderText = "Localized", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            foreach (DataGridViewColumn col in grid.Columns)
                col.DefaultCellStyle.NullValue = string.Empty;
        }

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

        protected override TranslationDto BuildModelFromForm(TranslationDto current)
        {
            var dto = current ?? new TranslationDto();

            if (_dataGridView.SelectedRows.Count > 0 && !_dataGridView.SelectedRows[0].IsNewRow)
            {
                var cellValue = _dataGridView.SelectedRows[0].Cells[nameof(TranslationDto.ID)].Value;
                if (cellValue != null && int.TryParse(Convert.ToString(cellValue), out int id))
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