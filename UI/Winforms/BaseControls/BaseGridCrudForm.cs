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

        // Re-entrancy guards
        private bool _isLoading;
        private bool _isMutating;

        // Cancellation support
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

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

        // CHANGED: make optional; derived forms can keep overriding if they have a Label
        protected virtual Label StatusLabel { get { return null; } }
        // ADDED: optional ToolStripStatusLabel support
        protected virtual ToolStripStatusLabel StatusStripLabel { get { return null; } }

        // Unified status writer
        protected virtual void SetStatusText(string text)
        {
            if (StatusStripLabel != null)
                StatusStripLabel.Text = text ?? string.Empty;
            else if (StatusLabel != null)
                StatusLabel.Text = text ?? string.Empty;
        }

        protected abstract void PopulateFormFieldsFromGrid(int rowIndex);
        protected abstract T BuildModelFromForm(T current);
        protected abstract int GetEntityId(T entity);
        protected abstract void ClearFormFieldsCore();

        // OPTIONAL: give derived forms a place to configure columns/formatting
        protected virtual void ConfigureGrid(DataGridView grid) { }

        // Hooks (override as needed)
        protected virtual Task OnBeforeLoadAsync() { return Task.CompletedTask; }
        protected virtual Task OnAfterLoadAsync() { return Task.CompletedTask; }
        protected virtual Task OnBeforeSaveAsync() { return Task.CompletedTask; }
        protected virtual Task OnAfterSaveAsync(T saved) { return Task.CompletedTask; }
        protected virtual Task OnBeforeDeleteAsync(int id, T entity) { return Task.CompletedTask; }
        protected virtual Task OnAfterDeleteAsync(int id, bool ok) { return Task.CompletedTask; }

        // Confirmation abstraction
        protected virtual DialogResult ConfirmDelete(string message)
        {
            return MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        protected async Task LoadDataAsync()
        {
            if (_isLoading) return;
            _isLoading = true;
            SetStatusText("Loading...");
            try
            {
                await OnBeforeLoadAsync();

                var result = await _service.GetAllAsync(_cts.Token);
                _items = result != null ? result.ToList() : new List<T>();

                Grid.DataSource = null;
                // Let derived configure columns first; if none, allow auto-generate
                ConfigureGrid(Grid);
                if (Grid.Columns.Count == 0)
                    Grid.AutoGenerateColumns = true;

                Grid.DataSource = _items;

                SetStatusText("Loaded " + _items.Count + " records.");
                GoFirst();

                await OnAfterLoadAsync();
            }
            catch (OperationCanceledException)
            {
                SetStatusText("Load canceled.");
            }
            catch (Exception ex)
            {
                SetStatusText("Load failed: " + ex.Message);
            }
            finally
            {
                _isLoading = false;
            }
        }

        protected void NavigateToRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= Grid.Rows.Count) return;

            var row = Grid.Rows[rowIndex];
            if (row.IsNewRow) return;

            Grid.ClearSelection();
            row.Selected = true;

            var firstVisibleCell = row.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible);
            if (firstVisibleCell != null)
                Grid.CurrentCell = firstVisibleCell;

            Grid.FirstDisplayedScrollingRowIndex = rowIndex;
            PopulateFormFieldsFromGrid(rowIndex);
        }

        // Convenience: navigate by predicate on T
        protected bool NavigateToEntity(Predicate<T> match)
        {
            if (match == null || _items == null || _items.Count == 0) return false;
            for (int i = 0; i < _items.Count; i++)
            {
                if (match(_items[i]))
                {
                    // Find matching bound row index (same ordering as _items with List<T> binding)
                    NavigateToRow(i);
                    return true;
                }
            }
            return false;
        }

        protected async Task SaveOrUpdateAsync()
        {
            if (_isMutating) return;
            _isMutating = true;

            try
            {
                await OnBeforeSaveAsync();

                var dto = BuildModelFromForm(null);
                var saved = await _service.UpsertAsync(dto, _cts.Token);
                SetStatusText("Saved (ID=" + GetEntityId(saved) + ")");

                await OnAfterSaveAsync(saved);

                await LoadDataAsync();
                ClearFormFields();
            }
            catch (OperationCanceledException)
            {
                SetStatusText("Save canceled.");
            }
            catch (Exception ex)
            {
                SetStatusText("Save failed: " + ex.Message);
            }
            finally
            {
                _isMutating = false;
            }
        }

        protected async Task DeleteSelectedAsync()
        {
            if (_isMutating) return;
            _isMutating = true;

            try
            {
                if (Grid.SelectedRows.Count == 0 || Grid.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Select a row to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var selectedRow = Grid.SelectedRows[0];
                var entity = selectedRow.DataBoundItem as T;

                // Fallback if DataBoundItem is null (shouldn't happen with List<T> binding)
                if (entity == null)
                {
                    var index = selectedRow.Index;
                    if (index < 0 || index >= _items.Count)
                    {
                        MessageBox.Show("Invalid selection.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    entity = _items[index];
                }

                var id = GetEntityId(entity);

                if (ConfirmDelete("Delete selected record?") != DialogResult.Yes)
                    return;

                await OnBeforeDeleteAsync(id, entity);

                var ok = await _service.DeleteAsync(id, _cts.Token);
                SetStatusText(ok ? "Deleted (ID=" + id + ")" : "Delete failed (ID=" + id + ")");

                await OnAfterDeleteAsync(id, ok);

                await LoadDataAsync();
            }
            catch (OperationCanceledException)
            {
                SetStatusText("Delete canceled.");
            }
            catch (Exception ex)
            {
                SetStatusText("Delete failed: " + ex.Message);
            }
            finally
            {
                _isMutating = false;
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
                    SetStatusText("First record.");
                    return;
                }
            }
            SetStatusText("No records.");
        }

        protected void GoLast()
        {
            for (int i = Grid.Rows.Count - 1; i >= 0; i--)
            {
                if (!Grid.Rows[i].IsNewRow)
                {
                    NavigateToRow(i);
                    SetStatusText("Last record.");
                    return;
                }
            }
            SetStatusText("No records.");
        }

        protected void GoPrevious()
        {
            var rows = Grid.Rows;
            int firstIndex = -1;
            for (int i = 0; i < rows.Count; i++)
            {
                if (!rows[i].IsNewRow) { firstIndex = i; break; }
            }
            if (firstIndex == -1) { SetStatusText("No records."); return; }

            int currentIndex = Grid.SelectedRows.Count > 0 ? Grid.SelectedRows[0].Index :
                               Grid.CurrentCell != null ? Grid.CurrentCell.RowIndex : firstIndex;

            if (currentIndex <= firstIndex)
            {
                NavigateToRow(firstIndex);
                SetStatusText("Already at first.");
                return;
            }

            for (int i = currentIndex - 1; i >= firstIndex; i--)
            {
                if (!rows[i].IsNewRow) { NavigateToRow(i); SetStatusText("Previous record."); return; }
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
            if (lastIndex == -1) { SetStatusText("No records."); return; }

            int currentIndex = Grid.SelectedRows.Count > 0 ? Grid.SelectedRows[0].Index :
                               Grid.CurrentCell != null ? Grid.CurrentCell.RowIndex : -1;

            if (currentIndex == -1)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    if (!rows[i].IsNewRow) { currentIndex = i; break; }
                }
                if (currentIndex == -1) { SetStatusText("No records."); return; }
            }

            if (currentIndex >= lastIndex)
            {
                NavigateToRow(lastIndex);
                SetStatusText("Already at last.");
                return;
            }

            for (int i = currentIndex + 1; i <= lastIndex; i++)
            {
                if (!rows[i].IsNewRow) { NavigateToRow(i); SetStatusText("Next record."); return; }
            }
            NavigateToRow(lastIndex);
        }

        // OPTIONAL: helpers to auto-wire buttons in derived forms
        protected void WireNavigationButtons(Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast)
        {
            if (btnFirst != null) btnFirst.Click += (s, e) => GoFirst();
            if (btnPrevious != null) btnPrevious.Click += (s, e) => GoPrevious();
            if (btnNext != null) btnNext.Click += (s, e) => GoNext();
            if (btnLast != null) btnLast.Click += (s, e) => GoLast();
        }

        protected void WireCrudButtons(Button btnSave, ToolStripButton tsbSave, ToolStripButton tsbDelete)
        {
            if (btnSave != null) btnSave.Click += async (s, e) => await SaveOrUpdateAsync();
            if (tsbSave != null) tsbSave.Click += async (s, e) => await SaveOrUpdateAsync();
            if (tsbDelete != null) tsbDelete.Click += async (s, e) => await DeleteSelectedAsync();
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { _cts.Cancel(); } catch { }
            base.OnFormClosing(e);
        }
    }
}