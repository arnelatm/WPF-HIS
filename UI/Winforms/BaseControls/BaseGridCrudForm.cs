using AATM.Contracts.Interfaces.Services; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AATM.UI.Winforms.BaseControls
{
    public abstract class BaseGridCrudForm<T> : Form where T : class
    {
        protected readonly ICrudService<T> _service;
        protected List<T> _items = new List<T>();

        // ADDED: parameterless ctor for the Designer (routes to factory ctor)
        protected BaseGridCrudForm() : this(() => new DesignTimeCrudService()) { }

        // ADDED: factory-based ctor to avoid creating real services at design-time
        protected BaseGridCrudForm(Func<ICrudService<T>> serviceFactory)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                _service = new DesignTimeCrudService();
            }
            else
            {
                _service = (serviceFactory?.Invoke()) ?? new DesignTimeCrudService();
            }
        }

        // EXISTING: runtime ctor remains for callers that pass a real service
        protected BaseGridCrudForm(ICrudService<T> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // ADDED: no-op service used at design-time
        public sealed class DesignTimeCrudService : ICrudService<T>
        {
            public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default)
                => Task.FromResult((IReadOnlyList<T>)new List<T>());
            public Task<T> GetByIdAsync(int id, CancellationToken ct = default)
                => Task.FromResult(default(T));
            public Task<T> UpsertAsync(T dto, CancellationToken ct = default)
                => Task.FromResult(dto);
            public Task<bool> DeleteAsync(int id, CancellationToken ct = default)
                => Task.FromResult(false);
        }

        protected abstract DataGridView Grid { get; }
        protected abstract Label StatusLabel { get; }

        protected abstract void PopulateFormFieldsFromGrid(int rowIndex);
        protected abstract T BuildModelFromForm(T current);
        protected abstract int GetEntityId(T entity);
        protected abstract void ClearFormFieldsCore();

        // Pseudocode plan:
        // - Problem: _service.GetAllAsync() returns IReadOnlyList<T>, but _items is List<T> causing CS0266.
        // - Fix: Convert the returned IReadOnlyList<T> to List<T> using ToList().
        // - Add null-coalescing to ensure _items is never null.
        // - Keep rest of method logic unchanged.

        protected async Task LoadDataAsync()
        {
            if (StatusLabel != null) StatusLabel.Text = "Loading...";
            try
            {
                var result = await _service.GetAllAsync();
                _items = result?.ToList() ?? new List<T>();

                Grid.DataSource = null;
                Grid.AutoGenerateColumns = true;
                Grid.DataSource = _items;
                if (StatusLabel != null) StatusLabel.Text = $"Loaded {_items.Count} records.";
                GoFirst();
            }
            catch (Exception ex)
            {
                if (StatusLabel != null) StatusLabel.Text = $"Load failed: {ex.Message}";
            }
        }

        protected void NavigateToRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= Grid.Rows.Count) return;
            var row = Grid.Rows[rowIndex];
            if (row.IsNewRow) return;

            Grid.ClearSelection();
            row.Selected = true;
            Grid.CurrentCell = row.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible);
            Grid.FirstDisplayedScrollingRowIndex = rowIndex;
            PopulateFormFieldsFromGrid(rowIndex);
        }

        protected async Task SaveOrUpdateAsync()
        {
            try
            {
                var dto = BuildModelFromForm(null);
                var saved = await _service.UpsertAsync(dto);
                if (StatusLabel != null) StatusLabel.Text = $"Saved (ID={GetEntityId(saved)})";
                await LoadDataAsync();
                ClearFormFields();
            }
            catch (Exception ex)
            {
                if (StatusLabel != null) StatusLabel.Text = $"Save failed: {ex.Message}";
            }
        }

        protected async Task DeleteSelectedAsync()
        {
            try
            {
                if (Grid.SelectedRows.Count == 0 || Grid.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Select a row to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var index = Grid.SelectedRows[0].Index;
                if (index < 0 || index >= _items.Count)
                {
                    MessageBox.Show("Invalid selection.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var entity = _items[index];
                var id = GetEntityId(entity);

                if (MessageBox.Show("Delete selected record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                var ok = await _service.DeleteAsync(id);
                if (StatusLabel != null) StatusLabel.Text = ok ? $"Deleted (ID={id})" : $"Delete failed (ID={id})";
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                if (StatusLabel != null) StatusLabel.Text = $"Delete failed: {ex.Message}";
            }
        }

        protected void ClearFormFields()
        {
            ClearFormFieldsCore();
            Grid.ClearSelection();
        }

        // Navigation helpers
        protected void GoFirst()
        {
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (!Grid.Rows[i].IsNewRow)
                {
                    NavigateToRow(i);
                    if (StatusLabel != null) StatusLabel.Text = "First record.";
                    return;
                }
            }
            if (StatusLabel != null) StatusLabel.Text = "No records.";
        }

        protected void GoLast()
        {
            for (int i = Grid.Rows.Count - 1; i >= 0; i--)
            {
                if (!Grid.Rows[i].IsNewRow)
                {
                    NavigateToRow(i);
                    if (StatusLabel != null) StatusLabel.Text = "Last record.";
                    return;
                }
            }
            if (StatusLabel != null) StatusLabel.Text = "No records.";
        }

        protected void GoPrevious()
        {
            var rows = Grid.Rows;
            int firstIndex = -1;
            for (int i = 0; i < rows.Count; i++)
            {
                if (!rows[i].IsNewRow) { firstIndex = i; break; }
            }
            if (firstIndex == -1) { if (StatusLabel != null) StatusLabel.Text = "No records."; return; }

            int currentIndex = Grid.SelectedRows.Count > 0 ? Grid.SelectedRows[0].Index :
                               Grid.CurrentCell != null ? Grid.CurrentCell.RowIndex : firstIndex;

            if (currentIndex <= firstIndex)
            {
                NavigateToRow(firstIndex);
                if (StatusLabel != null) StatusLabel.Text = "Already at first.";
                return;
            }

            for (int i = currentIndex - 1; i >= firstIndex; i--)
            {
                if (!rows[i].IsNewRow) { NavigateToRow(i); if (StatusLabel != null) StatusLabel.Text = "Previous record."; return; }
            }
            NavigateToRow(firstIndex);
        }

        protected void GoNext()
        {
            var rows = Grid.Rows;

            int lastIndex = -1;
            for (int i = rows.Count - 1; i >= 0; i--)
            {
                if (!rows[i].IsNewRow) { lastIndex = i; break; }
            }
            if (lastIndex == -1) { if (StatusLabel != null) StatusLabel.Text = "No records."; return; }

            int currentIndex = Grid.SelectedRows.Count > 0 ? Grid.SelectedRows[0].Index :
                               Grid.CurrentCell != null ? Grid.CurrentCell.RowIndex : -1;

            if (currentIndex == -1)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    if (!rows[i].IsNewRow) { currentIndex = i; break; }
                }
                if (currentIndex == -1) { if (StatusLabel != null) StatusLabel.Text = "No records."; return; }
            }

            if (currentIndex >= lastIndex)
            {
                NavigateToRow(lastIndex);
                if (StatusLabel != null) StatusLabel.Text = "Already at last.";
                return;
            }

            for (int i = currentIndex + 1; i <= lastIndex; i++)
            {
                if (!rows[i].IsNewRow) { NavigateToRow(i); if (StatusLabel != null) StatusLabel.Text = "Next record."; return; }
            }
            NavigateToRow(lastIndex);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseGridCrudForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseGridCrudForm";
            this.Load += new System.EventHandler(this.BaseGridCrudForm_Load);
            this.ResumeLayout(false);

        }

        private void BaseGridCrudForm_Load(object sender, EventArgs e)
        {

        }
    }
}
